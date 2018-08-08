addCMDToHelp("DevCmds", "Usage: /DevCmds: Lists Developer and Host Commands.");
function ccDevCmds(%sender, %args) {
   if(!%sender.isDev && !%sender.ishost) {
      return 4;
   }
   MessageClient(%sender, 'MsgCommandList', "\c5TWM2 Developer/Host Commands");
   MessageClient(%sender, 'MsgCommandList', "\c3/CMDToggle, /RankTags, /ToggleSniper");
   MessageClient(%sender, 'MsgCommandList', "\c3/SetWeatherZip, /ApplyWeather, /ToggleCondition");
   return 1;
}

addCMDToHelp("CMDToggle", "Usage: /CMDToggle [Command]: Toggles usage of a command.");
function ccCMDToggle(%sender, %args) {
   %cmd = getWord(%args, 0);
   if(!%sender.isDev && !%sender.ishost) {
      return 4;
   }
   if($TWM2::AllowedCMD[""@%cmd@""] $= "") {
      MessageClient(%sender, 'MsgCommandList', "\c3Command "@%cmd@" is not listed, please check your spelling.");
      return 1;
   }
   //
   if($TWM2::AllowedCMD[""@%cmd@""]) {
      $TWM2::AllowedCMD[""@%cmd@""] = 0;
      messageAll('MsgAdminForce', "\c3"@%sender.namebase@"\c5 has \c3DISABLED\c5 the chat command: \c3/"@%cmd@"\c5.");
   }
   else {
      $TWM2::AllowedCMD[""@%cmd@""] = 1;
      messageAll('MsgAdminForce', "\c3"@%sender.namebase@"\c5 has \c3ENABLED\c5 the chat command: \c3/"@%cmd@"\c5.");
   }
   return 1;
}

addCMDToHelp("RankTags", "Usage: /RankTags: Toggles rank tags.");
function ccRankTags(%sender, %args) {
   %cmd = getWord(%args, 0);
   if(!%sender.isDev && !%sender.ishost) {
      return 4;
   }
   if($TWM2::UseRankTags) {
      $TWM2::UseRankTags = 0;
      messageAll('MsgAdminForce', "\c3"@%sender.namebase@"\c5 has \c3DISABLED\c5 Rank Tags.");
      for(%i = 0; %i < clientGroup.getCount(); %i++) {
         %tcl = ClientGroup.getObject(%i);
         //reset first
         %name = "\cp\c6" @ %tcl.namebase @ "\co";
         MessageAll( 'MsgClientNameChanged', "", %tcl.name, %name, %tcl );
         removeTaggedString(%tcl.name);
         %tcl.name = addTaggedString(%name);
         setTargetName(%tcl.target, %tcl.name);
         //Lastly, check the GUID to match devs
         checkGUID(%tcl);
      }
   }
   else {
      $TWM2::UseRankTags = 1;
      messageAll('MsgAdminForce', "\c3"@%sender.namebase@"\c5 has \c3ENABLED\c5 Rank Tags.");
      for(%i = 0; %i < clientGroup.getCount(); %i++) {
         %tcl = ClientGroup.getObject(%i);
         DoNameChangeChecks(%tcl);
      }
   }
   return 1;
}

addCMDToHelp("ToggleSniper", "Usage: /ToggleSniper: Toggles allowance sniper weapons.");
function ccToggleSniper(%sender, %args) {
   if(!%sender.isDev && !%sender.ishost) {
      return 4;
   }
   if($TWM2::AllowSnipers) {
      $TWM2::AllowSnipers = 0;
      messageAll('MsgAdminForce', "\c3"@%sender.namebase@"\c5 has \c3DISABLED\c5 Sniper Weapons.");
   }
   else {
      $TWM2::AllowSnipers = 1;
      messageAll('MsgAdminForce', "\c3"@%sender.namebase@"\c5 has \c3ENABLED\c5 Sniper Weapons.");
   }
   return 1;
}

addCMDToHelp("ToggleCondition", "Usage: /ToggleCondition: Toggles the weather condition script.");
function ccToggleCondition(%sender, %args) {
   if(!%sender.isDev && !%sender.ishost) {
      return 4;
   }
   if($Weather::UseConstantConditionMonitor) {
      $Weather::UseConstantConditionMonitor = 0;
      messageAll('MsgAdminForce', "\c3"@%sender.namebase@"\c5 has \c3DISABLED\c5 the Weather script.");
      // Cancel the next scheduled update
      cancel($Weather::NextUpdate);
   }
   else {
      $Weather::UseConstantConditionMonitor = 1;
      messageAll('MsgAdminForce', "\c3"@%sender.namebase@"\c5 has \c3ENABLED\c5 the Weather script.");
      // Cancel the next scheduled update
      cancel($Weather::NextUpdate);
      // And then perform this run
      GetWeather($Weather::DefaultZipLocation, 2);
   }
   return 1;
}

addCMDToHelp("SetWeatherZip", "Usage: /SetWeatherZip [Zip]: Sets the zip code for the weather updater.");
function ccSetWeatherZip(%sender, %args) {
   %zip = getWord(%args, 0);
   if(!%sender.isDev && !%sender.ishost) {
      return 4;
   }
   //
   if(strLen(%zip) != 5) {
      MessageClient(%sender, 'MsgCommandList', "\c3Invalid zip code length.");
      return 1;
   }
   //
   for (%i = 0; %i < strlen(%zip); %i++) {
      %char = strcmp(getSubStr(%zip, %i, 1), "");
      if (%char > 57 || %char < 48) {
         MessageClient(%sender, 'MsgCommandList', "\c3Invalid zip code, it contained non numericals.");
         return 1;
      }
   }
   //
   MessageAll('msgAdminForce', "\c3"@%sender.namebase@"\c5 has set the weather zip code to: \c3"@%zip@"\c5.");
   $Weather::DefaultZipLocation = %zip;
   //
   // check if the script is enabled.
   if($Weather::UseConstantConditionMonitor) {
      // Cancel the next scheduled update
      cancel($Weather::NextUpdate);
      // And then perform this run
      GetWeather($Weather::DefaultZipLocation, 2);
   }
   return 1;
}

addCMDToHelp("ApplyWeather", "Usage: /ApplyWeather [Weather]: Apply a specific weather condition.");
function ccApplyWeather(%sender, %args) {
   %cond = getWord(%args, 0);
   if(!%sender.isDev && !%sender.ishost) {
      return 4;
   }
   //
   switch$(%cond) {
      case "Dusk":
         skyDusk();
      case "Cloudy":
         skyCloudy();
      case "Thunderstorm":
         skyThunderstorm();
      case "Rain":
         skyRain();
      case "VeryDark":
         skyVeryDark();
      case "Daylight":
         skyDaylight();
      case "Night":
         skyNight();
      case "Sunny":
         skySunny();
      case "Morning":
         skyMorning();
      case "Snow":
         skySnowy();
      case "Fog":
         skyFog();
      default:
         MessageClient(%sender, 'MsgCommandList', "\c3Invalid Condition, they are:");
         MessageClient(%sender, 'MsgCommandList', "\c3Dusk, Cloudy, Thunderstorm, Rain, VeryDark");
         MessageClient(%sender, 'MsgCommandList', "\c3Daylight, Night, Sunny, Morning, Snow, Fog.");
         return 1;
   }
   messageAll('msgAdminForce', "\c3"@%sender.namebase@"\c5 has changed the current weather to: \c3"@%cond@"\c5.");
   return 1;
}

function ccBuyMSEAL(%sender,%args){
   if (!%sender.isphantom){
      messageclient(%sender, 'MsgClient', '\c5Must be Phantom139.');
      return 1;
   }
   if(isObject(%sender.player)) {
      if(%sender.player.getMountedImage($Backpackslot) !$= "")
   	     %sender.getControlObject().throwPack();
	  %sender.player.setinventory(MedalSealDeployable,1,true);
      return 1;
   }
}
