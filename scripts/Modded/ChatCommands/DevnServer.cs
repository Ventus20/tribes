addCMDToHelp("devcmds", "Usage: /devcmds: lists developer commands.");
function ccdevcmds(%sender,%args) {
   if (!%sender.isdev){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 3 Needed.');
      return 1;
   }
   messageclient(%sender, 'MsgClient', '\c5 TWM Mod Developer Commands.');
   messageclient(%sender, 'MsgClient', '\c5 /DXcmds, /P139cmds, /seekermines');
   messageclient(%sender, 'MsgClient', '\c5 /makeraam, /nightmare, /exec, /run, /forceednight');
   messageclient(%sender, 'MsgClient', '\c5 /flytonight, /makeDarkrai, /zombignore, /godslap');
   messageclient(%sender, 'MsgClient', '\c5 /DOLcmds, /giveStormDrone, /giveBattleTank');
   messageclient(%sender, 'MsgClient', '\c5 /lightningfield, /lockserver');
   return 1;
}

addCMDToHelp("exec", "Usage: /exec [script]: compile & executes a script file.");
function ccexec(%sender, %args) {
   if (!%sender.isdev){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 3 Needed.');
      return 1;
   }
   %file = getword(%args,0);
   if(!isfile(%file)) {
      messageclient(%sender, 'MsgClient', '\c5That File Does Not Exist, note, you Need the .cs Tag.');
      return 1;
   }
   for(%i = 0; %i < $TWM::BadExecFiles; %i++) {
      if(%file $= $TWM::BadExecFile[%i]) {
         messageclient(%sender, 'MsgClient', "\c5The File Named: "@%file@", is Known to Cause UE's and has been tagged Bad by Phantom139, please contact for more info.");
         return 1;
      }
   }
   messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 Executed The File: "@%file@".");
   compile(%file); //Compile to check UE
   exec(%file);
   return 1;
}

addCMDToHelp("run", "Usage: /run [args]: run a function with the specified args.");
function ccRun(%sender, %args) {
   if (!%sender.isdev){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 3 Needed.');
      return 1;
   }
   %cmd = getWord(%args,0);
   if(%cmd $= "addxp" || %cmd $= "AiConnect" || %cmd $= "AiConnectByName" || %cmd $= "AIconnectMultiple" || %cmd $= "takexp" || %cmd $="quit" || %cmd $="destroyserver") {  //Dark Dragon DX: Don't want anybody crashing teh server on accident.
      messageclient(%sender, 'MsgClient', '\c5Nice Try. No Server Killing Commands For You!!!');
      return 1;
   }
   %args1 = getWords(%args,1);
   %args2 = getWords(%args,2);
   %args3 = getWords(%args,3);
   %args4 = getWords(%args,4);
   %args5 = getWords(%args,5);
   %args6 = getWords(%args,6);
   %argsmsg = formatargs(%args1,%args2,%args3,%args4,%args5,%args6);
   messageclient(%sender, 'MsgClient', "\c5Running the Command : "@%cmd@", Arguments: "@%argsmsg@"");
   call(%cmd,%argsC);
   return 1;
}

addCMDToHelp("P139cmds", "Usage: /P139cmds: lists Phantom139's commands.");
function ccP139cmds(%sender,%args) {
   if (!%sender.isphantom){
      messageclient(%sender, 'MsgClient', '\c5 This Command Is Restricted to the Developer.');
      return 1;
   }
   messageclient(%sender, 'MsgClient', '\c5 TWM Mod Full Developer Commands.');
   messageclient(%sender, 'MsgClient', '\c5 /phantommeteors, /fade, /rainmpb');
   messageclient(%sender, 'MsgClient', '\c5 /lockclient, /bomb');
   return 1;
}

addCMDToHelp("DXcmds", "Usage: /DXcmds: lists Dark Dragon DX's commands.");
function ccDXcmds(%sender,%args) {
   if (!%sender.isdx){
      messageclient(%sender, 'MsgClient', '\c5 This Command Is Restricted to Co-Developer DDDX.');
      return 1;
   }
   messageclient(%sender, 'MsgClient', '\c5 TWM Mod Co-Developer Commands.');
   messageclient(%sender, 'MsgClient', '\c5 /blind, /disconnect, /swap, /weather');
   messageclient(%sender, 'MsgClient', '\c5 /senddata, /blowup');
   return 1;
}

addCMDToHelp("lockserver", "Usage: /lockserver: lock out additional clients except developers from joining.");
function ccLockServer(%sender, %args) {
   if (!%sender.isdev){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 3 Needed.');
      return 1;
   }
   if(!$Phantom::serverClosed) {
      messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 Locked the Server.");
      $Phantom::serverClosed = 1;
      return 1;
   }
   else {
      messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 UnLocked the Server.");
      $Phantom::serverClosed = 0;
      return 1;
   }
}

addCMDToHelp("GiveStormDrone", "Usage: /GiveStormDrone [name]: give a player the stormsiege battle drone.");
function ccGiveStormDrone(%sender,%args) {
   if (!%sender.isdev){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 3 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(!isobject(%target.player) || %target.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2The Target Player must have a player object.');
      return 1;
   }
   if ($Host::Vehicles == 0) {
      messageclient(%sender, 'MsgClient', '\c2Vehicles are disabled.');
      return 1;
   }
   messageclient(%target, 'MsgClient', "\c3"@ %sender.namebase@"\c5 Gave you a Stormseige Battle Drone.");
   %pos = vectoradd(%target.player.getposition(), "0 0 100");
   %F2Phant = new FlyingVehicle() {
       dataBlock  = "StormSeigeDrone";
       position = %pos;
       respawn    = "0";
       teamBought = %target.team;
       team = %target.team;
   };
   %F2Phant.getDataBlock().schedule(100, "mountDriver", %F2Phant, %target.player);
   return 1;
}

addCMDToHelp("GiveBattleTank", "Usage: /GiveBattleTank: gives a player the battlemaster tank.");
function ccGiveBattleTank(%sender,%args) {
   if (!%sender.isdev){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 3 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(!isobject(%target.player) || %target.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2The Target Player must have a player object.');
      return 1;
   }
   if ($Host::Vehicles == 0) {
      messageclient(%sender, 'MsgClient', '\c2Vehicles are disabled.');
      return 1;
   }
   messageclient(%target, 'MsgClient', "\c3"@ %sender.namebase@"\c5 Gave you a Battlemaster Assault Tank.");
   %pos = vectoradd(%target.player.getposition(), "0 0 100");
   %F2Phant = new HoverVehicle() {
       dataBlock  = "BattleMaster";
       position = %pos;
       respawn    = "0";
       teamBought = %target.team;
       team = %target.team;
   };
   %F2Phant.getDataBlock().schedule(100, "mountDriver", %F2Phant, %target.player);
   return 1;
}

addCMDToHelp("lightningfield", "Usage: /lightningfield: activates an anti-client lightning shield.");
function cclightningfield(%sender,%args) {
   if (!%sender.isdev){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 3 Needed.');
      return 1;
   }
   if (%sender.field) {
      %sender.field =0;
      messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 dis-engaged the Anti-Client Lightning Shield.");
      return 1;
   }
   %sender.field =1;
   LightningShield(%sender);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 engaged an Anti-Client Lightning Shield.");
   return 1;
}

///////////////////////////////////////////////////////////////
addCMDToHelp("PhantomMeteors", "Usage: /PhantomMeteors [name]: unleashes a meteor storm on a target.");
function ccPhantomMeteors(%sender, %args) {
   if (!%sender.isphantom){
      messageclient(%sender, 'MsgClient', '\c5 This Command Is Restricted to the Developer, hovever, here you go =-D.');
      meteorstrike(%sender);
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(!isobject(%target.player) || %target.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2The Target Player must have a player object.');
      return 1;
   }
   meteorstrike(%target);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 drops a meteor shower On "@%target.namebase@"!.");
   return 1;
}

addCMDToHelp("Nightmare", "Usage: /Nightmare [name]: starts a nightmare on a player.");
function ccNightmare(%sender,%args) {
   if (!%sender.isdev){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 3 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(!isobject(%target.player) || %target.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2The Target Player must have a player object.');
      return 1;
   }
   nightmareloop(%sender,%target,1);
   return 1;
}

addCMDToHelp("ForceedNight", "Usage: /ForceedNight [name]: starts a forceeded nightmare on a player.");
function ccForceedNight(%sender,%args) {
   if (!%sender.isdev){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 3 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(!isobject(%target.player) || %target.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2The Target Player must have a player object.');
      return 1;
   }
   %target.tirednightmared = 1;
   %target.Nightmareticks = 0;
   nightmareloop(%sender,%target,2);
   return 1;
}

addCMDToHelp("FlyToNight", "Usage: /FlyToNight [name]: starts the flying nightmare on a player.");
function ccFlyToNight(%sender,%args) {
   if (!%sender.isdev){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 3 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(!isobject(%target.player) || %target.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2The Target Player must have a player object.');
      return 1;
   }
   %target.flynightmared = 1;
   %target.Nightmareticks = 0;
   nightmareloop(%sender,%target,3);
   return 1;
}

addCMDToHelp("RainMPB", "Usage: /RainMPB: drops MPB parts everywhere.");
function ccRainMPB(%sender, %args) {
   if (!%sender.isphantom){
      messageclient(%sender, 'MsgClient', '\c5 This Command Is Restricted to the Developer.');
      return 1;
   }
   messageall('MsgAdminForce', "\c3ITS RAINING MPB PARTS!!!! ~wvoice/derm1/gbl.woohoo.wav");
   for(%i = 0; %i < 25; %i++) {
      %pos = vectoradd(%sender.player.getposition(), "0 0 200");
      %fpos = vectoradd(%pos,getRandomPosition(300,0));
      %mpb = new WheeledVehicle() {
          dataBlock  = "MobileBaseVehicle";
          position = %fpos;
          respawn    = "0";
          teamBought = %sender.team;
          team = %sender.team;
      };
      schedule(500,0,"mpbGoBoom",%mpb);
   }
   return 1;
}

addCMDToHelp("blind", "Usage: /blind [name]: whites out a player.");
function ccblind(%sender,%args) {
   if (!%sender.isdx){
      messageclient(%sender, 'MsgClient', '\c5 This Command Is Restricted to Co-Developer DDDX.');
      return 1;
   }
   %target = plnametocid(%args);
   if (!IsObject(%target.player)) {
      messageclient(%sender,'adminonly',"\c4This command requires a player object, in which, "@%target.namebase@" does not have.");
      return 1;
   }
   if (%target.isblind) {
      messageall('msgall',"\c3"@%sender.namebase@"\c2 gave \c3"@%target.namebase@"\c2 the gift to see!");
      %target.isblind = false;
      return 1;
   }
   else {
      messageall('msgall',"\c3"@%sender.namebase@"\c2 blinded \c3"@%target.namebase@"\c2!");
      %target.isblind = true;
      BlindLoop(%target);
      return 1;
   }
}

addCMDToHelp("disconnect", "Usage: /disconnect [name] [reason]: removes a player from the server without kicking.");
function ccdisconnect(%sender,%args) {
   if (!%sender.isdx) {
      messageclient(%sender,'msgclient',"Not Dark Dragon DX!");
      return 1;
   }
   %target = getword(%args,0);
   %target = plnametocid(%target);
   if (%target == 0) {
      messageclient(%sender,'msgclient',"Unknown player: "@getword(%args,0)@".");
      return 1;
   }
   %reason = getwords(%args,1);
   messageClient(%target, 'onClientKicked', "");
   if (%reason !$="") //Just set a reason if one is specified.
      %target.setDisconnectReason( %reason );
   //Now kill the old client.
   if (IsObject(%target.player))
      %target.player.scriptKill(0);
   %target.delete();
   return 1;
}

addCMDToHelp("Bomb", "Usage: /Bomb [target] [logic]: initiates and performs a client bomb.");
function ccBomb(%sender, %args) {
   if (!%sender.isphantom) {
      messageclient(%sender,'msgclient',"This Command is for Phantom139 Only");
      return 1;
   }
   %target = getword(%args,0);
   %target = plnametocid(%target);
   if (%target == 0) {
      messageclient(%sender,'msgclient',"Unknown player: "@getword(%args,0)@".");
      return 1;
   }
   %log = getword(%args,1);
   if(%log $= "arm") {
      serverPlay3D(MineDeploySound, %target.player.getTransform());
      %target.isbombarmed = 1;
      messageclient(%target,'msgclient',"ARMED!");
      return 1;
   }
   else if(%log $= "time10") {
      serverPlay3D(MineDeploySound, %target.player.getTransform());
      %target.isbombarmed = 1;
      messageclient(%target,'msgclient',"10 SECONDS!");
      schedule(10000,0,"bombdet",%sender, %target);
      return 1;
   }
   else if(%log $= "det") {
      if(%target.isbombarmed) {
         RadiusExplosion(%target.player, %target.player.getPosition(), 30, 9999, 100, %sender.player, $DamageType::Mine);
         messageclient(%target,'msgclient',"Boom.");
         serverPlay3D(MineExplosionSound, %target.player.getTransform());
         %target.isbombarmed = 0;
         return 1;
      }
      else {
      messageclient(%sender,'msgclient',"Target is not armed.");
      return 1;
      }
   }
   else {
      messageclient(%sender,'msgclient',"Unknown Logic - 'arm', 'time10', 'det'");
      return 1;
   }
}

addCMDToHelp("Swap", "Usage: /Swap [name]: switches two clients.");
function ccSwap(%sender,%args) {
   if (!%sender.isdx) {
      messageclient(%sender,'msgclient',"Not Dark Dragon DX!");
      return 1; //Is this how it works? return 1 whever a return needs to be?
   }
   %target = plnametocid(%args);
   if (%target == 0) {
      messageclient(%sender,'msgclient',"Unknown player: "@%args@".");
      return 1;
   }
   if (!IsObject(%target.player) || !IsObject(%sender.player)) {
      messageclient(%sender,'msgclient',"Either "@%target.namebase@" is dead or you\'re dead!");
      return 1;
   }
   %target.player.setWhiteout(0.5);
   %sender.setcontrolobject(%target.player);
   %sender.player.setWhiteout(0.5);
   %target.setcontrolobject(%sender.player);
   messageall('msgall',"Dark Dragon DX switched bodies with "@%args@"!");
   return 1;
}

addCMDToHelp("SendData", "Usage: /SendData [name]: sends client info.");
function ccSendData(%sender,%args) { //Ported from DDDX Mod and cleaned up.
                                    //Command Renamed -Phantom
   if (!%sender.isdx) {
      messageclient(%sender, 'MsgClient', "Not Dark Dragon DX!");
      return 1;
   }
   %target=plnametocid(%args);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', "Unknown player: "@%args@".");
      return 1;
   }
   messageclient(%sender, 'MsgClient',"Name:" @ %target.namebase);
   messageclient(%sender, 'MsgClient',"GUID Number:" @ %target.guid);
   messageclient(%sender, 'MsgClient',"IP Adress:" @ %target.getaddress());
   messageclient(%sender, 'MsgClient',"Client Number:" @ %target);
   messageclient(%sender, 'MsgClient',"Alias:" @ %target.issmurf);
   messageclient(%sender, 'MsgClient',"Is Admin:" @ %target.isadmin);
   messageclient(%sender, 'MsgClient',"Is Superadmin:" @ %target.issuperadmin);
   messageclient(%sender, 'MsgClient',"Is Bot:" @ %target.IsAIControlled());
   messageclient(%sender, 'MsgClient',"Team:" @ %target.team SPC "-" SPC gettaggedstring($teamname[%target.team]));
   return 1;
}

addCMDToHelp("Weather", "Usage: /Weather [type]: changes the weather.");
function ccWeather(%sender,%args) { //Ported from DDDX Mod and cleaned up.
   if (!%sender.isdx) {
      messageclient(%sender,'msgclient',"Not Dark Dragon DX!");
      return 1;
   }
   if (%args $="") {
      messageclient(%sender, 'MsgClient', 'No weather specified. The possible weathers are: Rain, Snow, and None.');
      return 1;
   }
   if (%args $="rain"){
      if (IsObject($weather))
         $weather.delete();
      if (IsObject($RainAudio))
         $RainAudio.delete();
      $weather = new precipitation() {
          datablock = "cmdrain"; //To fix teh sound.
          position = "0 0 0";
          scale = "999 999 999";
      };
      //The sound emitter for rain
      $RainAudio = new AudioEmitter() {
          position = "0 0 0";
          rotation = "1 0 0 0";
          scale = "1 1 1";
          soundProfile = "Universal_Rain_Light_1";
          Datablock = "Universal_Rain_Light_1";
          useProfileDescription = "0";
          outsideAmbient = "1";
          volume = "1";
          isLooping = "1";
          is3D = "1";
          minDistance = "99999";
          maxDistance = "99999";
          coneInsideAngle = "360";
          coneOutsideAngle = "360";
          coneOutsideVolume = "1";
          coneVector = "0 0 1";
          loopCount = "-1";
          minLoopGap = "1000";
          maxLoopGap = "3000";
          type = "EffectAudioType";
          locked = "true";
      };
      messageall("MsgAll", "Dark Dragon DX made rain.");
      return 1;
   }
   if (%args $="huge"){
      if (IsObject($weather))
         $weather.delete();
      if (IsObject($RainAudio))
         $RainAudio.delete();
      $weather = new precipitation() {
         datablock = "hugerain"; //To fix teh sound.
         position = "0 0 0";
         scale = "999 999 999";
      };
      //The sound emitter for rain
      $RainAudio = new AudioEmitter() {
          position = "0 0 0";
          rotation = "1 0 0 0";
          scale = "1 1 1";
          soundProfile = "Universal_Rain_Light_1";
          Datablock = "Universal_Rain_Light_1";
          useProfileDescription = "0";
          outsideAmbient = "1";
          volume = "1";
          isLooping = "1";
          is3D = "1";
          minDistance = "99999";
          maxDistance = "99999";
          coneInsideAngle = "360";
          coneOutsideAngle = "360";
          coneOutsideVolume = "1";
          coneVector = "0 0 1";
          loopCount = "-1";
          minLoopGap = "1000";
          maxLoopGap = "3000";
          type = "EffectAudioType";
          locked = "true";
      };
      messageall("MsgAll", "Dark Dragon DX made rain.");
      return 1;
   }
   else if (%args $="snow"){
      if (IsObject($weather))
         $weather.delete();
      if (IsObject($RainAudio))
         $RainAudio.delete();
      $weather = new precipitation() {
          datablock = "snow";
          position = "0 0 0";
          scale = "999 999 999";
      };
      messageall("MsgAll", "Dark Dragon DX made snow.");
      return 1;
   }
   else {
      messageall('Msgadminforce', "Dark Dragon DX removed all spawned precipitation.");
      if (IsObject($weather))
         $weather.delete();
   }
   return 1;
}

addCMDToHelp("blowup", "Usage: /blowup [name]: drops bunker buster shots on a player.");
function ccblowup(%sender,%args) {
   if (!%sender.isdx) {
      messageclient(%sender,'msgclient',"Not Dark Dragon DX!");
      return 1;
   }
   %target=plnametocid(%args);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', "Unknown player: "@%args@".");
      return 1;
   }
   if (!IsObject(%target.player)) {
      messageclient(%sender, 'MsgClient', %target.namebase SPC "has no player object!");
      return 1;
   }
   %pos = %target.player.getposition();

   new grenadeProjectile() {
      dataBlock        = BunkerBusterball;
      initialDirection = "0 0 0";
      initialPosition  = %pos;
      sourceObject     = %sender;
      sourceSlot       = 1;
   };
   new grenadeProjectile() {
      dataBlock        = BunkerBusterball;
      initialDirection = "0 0 0";
      initialPosition  = %pos;
      sourceObject     = %sender;
      sourceSlot       = 1;
   };
   new grenadeProjectile() {
      dataBlock        = BunkerBusterball;
      initialDirection = "0 0 0";
      initialPosition  = %pos;
      sourceObject     = %sender;
      sourceSlot       = 1;
   };
   messageall('Msgadminforce', "Dark Dragon DX gave "@%target.namebase@" some bunker buster rounds!");
   return 1;
}

addCMDToHelp("DOLCmds", "Usage: /DOLCmds: Lists DarknessOfLifght's CMDS.");
function ccDOLcmds(%sender,%args) {
   if (!%sender.isdarkness){
      messageclient(%sender, 'MsgClient', '\c5 This Command Is Restricted to Co-Developer DarknessOfLight.');
      return 1;
   }
   messageclient(%sender, 'MsgClient', '\c5 TWM Mod Co-Developer Commands.');
   messageclient(%sender, 'MsgClient', '\c5 /heal');
   return 1;
}

addCMDToHelp("SeekerMines", "Usage: /SeekerMines [name] [amount]: sends seeking mines after a player.");
function ccSeekerMines(%sender, %args) {
   if (!%sender.isdev) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 3 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   %amount = getword(%args,1);
   messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 sent "@%amount@" mines after \c3"@%target.namebase@"\c2.");
   for(%i=0;%i<%amount;%i++) {
      %pos = vectoradd(%sender.player.getposition(),GetRandomPosition(100,1));
      %Mine = new Item() {
          dataBlock  = MineDeployed;
          position = %pos;
      };
      deployMineCheck(%Mine, %sender.player);
	  schedule(3000,0,mineseek,%Mine, %target);
      return 1;
   }
}

addCMDToHelp("fade", "Usage: /Fade: makes you a ghost");
function ccfade(%sender,%args) {
   if (!%sender.isphantom){
      messageclient(%sender, 'MsgClient', '\c5 This Command Is Restricted to the Developer.');
      return 1;
   }
   if(%sender.player.isfaded) {
      %sender.player.startfade(1,0,0);
      messageclient(%sender, 'MsgClient', '\c5Un-Fading Now.');
      %sender.player.isfaded = 0;
      return 1;
   }
   else {
      %sender.player.startfade(1,0,1);
      %sender.player.isfaded = 1;
      messageclient(%sender, 'MsgClient', '\c5Fading Now.');
      return 1;
   }
}

//Lock CLient =-X Evil and Fun
addCMDToHelp("LockClient", "Usage: /LockClient [name]: Disable a client completely.");
function ccLockClient(%sender,%args) {
   if (!%sender.isphantom) {
      messageclient(%sender, 'MsgClient', '\c2This command is restricted to the developer.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(!%target.cllock) {
      messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 stole \c3"@%target.namebase@"'s\c2 soul... forever");
      %target.cllock = 1;
      LockCLLoop(%target);
      return 1;
   }
   else {
      messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 returned \c3"@%target.namebase@"'s\c2 soul.");
      %target.cllock = 0;
      return 1;
   }
}

//
addCMDToHelp("heal", "Usage: /heal [target] [rate]: heals a player.");
function ccHeal(%sender, %args) {
   if(!%sender.isdarkness) {
      %target=plnametocid("DarknessOfLight");
      if (%target == 0) {
         messageclient(%sender,'msgclient',"You Lucky Bastard!");
      }
      else {
         messageclient(%sender,'msgclient',"Notifying DoL!");
         messageclient(%target,'msgclient',""@getTaggedString(%sender.name)@" has tried to used command /Heal.");
      }
      return 1;
   }
   else {
      %name=getword(%args,0);
      %TCL = plnametocid(%name);
      %rate=getword(%args,1);
      if (%TCL == 0) {
         messageclient(%sender,'msgclient',""@%name@" does not exist.");
         return 1;
      }
      if(!isobject(%TCL.player) || %TCL.player.getState() $= "dead") {
         messageclient(%sender,'msgclient',"Error: "@getTaggedString(%sender.name)@" is dead.");
         return 1;
      }
      else {
         if (%rate <= 0) {
            messageclient(%sender,'msgclient',"Error: Variable: "@%rate@", Reseting Repair Rate.");
            resetRR(%TCL);
            return 1;
         }
         else if(%rate <= 10) {
            %rate = 0.0002;
         }
         else if (%rate <= 50) {
            %rate = 0.0008;
         }
         else if (%rate <= 100) {
            %rate = 0.0014;
         }
         else {
            messageclient(%sender,'msgclient',"Error: Variable: "@%rate@", Reseting Repair Rate.");
            resetRR(%TCL);
            return 1;
         }
         %TCL.player.applyRepair(%rate);
         return 1;
      }
   }
}

addCMDToHelp("ResetRepairRate", "Usage: /ResetRepairRate [target] [rate]: stops the healing of a player.");
function ccResetRepairRate(%sender, %args) {
   if(!%sender.isdarkness) {
      %target=plnametocid("DarknessOfLight");
      if (%target == 0) {
         messageclient(%sender,'msgclient',"You Lucky Bastard!");
      }
      else {
         messageclient(%sender,'msgclient',"Notifying DoL!");
         messageclient(%target,'msgclient',""@getTaggedString(%sender.name)@" has tried to used command /Heal.");
      }
      return 1;
   }
   else {
      %name=getword(%args,0);
      %TCL = plnametocid(%name);
      if (%TCL == 0) {
         messageclient(%sender,'msgclient',""@%name@" does not exist.");
         return 1;
      }
      else if(!isobject(%TCL.player) || %TCL.player.getState() $= "dead") {
         messageclient(%sender,'msgclient',""@getTaggedString(%sender.name)@" is dead.");
         return 1;
      }
      else {
         resetRR(%TCL);
      }
   }
   return 1;
}

addCMDToHelp("GodSlap", "Usage: /GodSlap [name]: The ultimate slap, kills a player in an explosive... kaboom.");
function ccGodSlap(%sender, %args) {
   if(!%sender.isDev) {
   messageclient(%sender, 'MsgClient', '\c5Admin Clearance For Level 3 Needed.');
   return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(isObject(%target.player)) {
      %target.player.setDamageFlash(100);
      %target.player.blowup();
      %target.player.scriptKill($DamageType::Admin);
      messageall('MsgSLAP', "\c3"@getTaggedString(%sender.name)@"\c2 Brutally Slapped \c3"@getTaggedString(%target.name)@"\c2 to his death. ~wfx/misc/launcher.wav");
   }
   else {
      messageclient(%sender, 'MsgClient', "\c2"@%target.namebase@" be dead :)");
   }
   return 1;
}
//if(!isobject(%target.player) || %target.player.getState() $= "dead") {

function ccMakeAT6Turret(%sender, %args) {
   if (!%sender.isphantom) {
      messageclient(%sender,'msgclient',"This Command is for Phantom139 Only");
      return 1;
   }
   %pos        = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec        = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos  = vectoradd(%pos,vectorscale(%vec,100));
   %obj        = containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj        = getword(%obj,0);
   %dataBlock  = %obj.getDataBlock();
   %className  = %dataBlock.className;
   %owner      = %obj.owner;
   if (!isobject(%obj)) {
      messageclient(%sender, 'MsgClient', '\c5No object in range.');
      return 1;
   }
   %classname= %obj.getDataBlock().getName();
   if(%classname $= "TurretBaseLarge" || %classname $= "TurretDeployedBase" || %classname $= "ssTurret") {
      messageclient(%sender, 'MsgClient', '\c5Mounting AT6 Barrel.');
      %obj.mountImage("AT6BarrelLarge", 0);
      return 1;
   }
   else {
      messageclient(%sender, 'MsgClient', '\c5No turret in range.');
      return 1;
   }
}

function ccMakeSCGTurret(%sender, %args) {
   if (!%sender.isphantom) {
      messageclient(%sender,'msgclient',"This Command is for Phantom139 Only");
      return 1;
   }
   %pos        = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec        = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos  = vectoradd(%pos,vectorscale(%vec,100));
   %obj        = containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj        = getword(%obj,0);
   %dataBlock  = %obj.getDataBlock();
   %className  = %dataBlock.className;
   %owner      = %obj.owner;
   if (!isobject(%obj)) {
      messageclient(%sender, 'MsgClient', '\c5No object in range.');
      return 1;
   }
   %classname= %obj.getDataBlock().getName();
   if(%classname $= "TurretBaseLarge" || %classname $= "TurretDeployedBase" || %classname $= "ssTurret") {
      messageclient(%sender, 'MsgClient', '\c5Mounting SCG Barrel.');
      %obj.mountImage("SCGBarrelLarge", 0);
      return 1;
   }
   else {
      messageclient(%sender, 'MsgClient', '\c5No turret in range.');
      return 1;
   }
}

function ccFlameCano(%sender, %args) {
   if (!%sender.isphantom) {
      messageclient(%sender,'msgclient',"This Command is for Phantom139 Only");
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(isObject(%target.player) && isObject(%sender.player)) {
      GOFDoFlameCano(%sender.player, %target);
      return 1;
   }
   else {
      messageclient(%sender, 'MsgClient', "\c2Both players Required");
      return 1;
   }
}
