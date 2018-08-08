//TWM2 Functions
$TWM2::Version = 3.6;

function CheckGUID(%client) {
   //
   if(%client.isSuperAdmin) {
      %tag = "[SA]";
   }
   else if(%client.isAdmin && !%client.isSuperAdmin) {
      %tag = "[Admin]";
   }
   //
   if(%client.GUID $= $TWM2::HostGUID) {
      %client.isadmin = 1;
      %client.issuperadmin = 1;
      %client.ishost = 1; //hosts can use developer commands, but don't have access to developer features
      echo("Server Host Joined.");
      messageall('MsgAdminForce', "\c3The Host Has Joined!");
      %tag = "[Host]";
   }
   else {
      if($Host::UseDevelopersList) {
         //get the developer list 
		 %i_check = 0;
		 while(isSet($DeveloperList[%i_check])) {
			if(%client.guid $= trim($DeveloperList[%i_check])) {
		       switch$(trim($DeveloperLevel[%i_check])) {
			      case "Dev":
				     %client.isAdmin = 1;
					 %client.isSuperAdmin = 1;
					 %client.isDev = 1;
					 %client.isPhantom = 1;
					 %tag = "[Dev]";
					 echo("Mod Developer Connection");
				  case "CoDev":
				     %client.isAdmin = 1;
				  	 %client.isSuperAdmin = 1;
				  	 %client.isDev = 1;
				  	 %tag = "[CoDev]";
				  	 echo("Mod Co-Developer Connection");
				  default:
				     echo("wut? o_o: "@$DeveloperLevel[%i_check]@"");
			   }
			   break; //break loop, proceed
			}
			%i_check++;
		 }
      }
   }
   if(%tag !$= "" && !$TWM2::UseRankTags) {
  	  %name = "\cp\c7" @ %tag @ "\c6" @ %client.namebase @ "\co";
      MessageAll( 'MsgClientNameChanged', "", %client.name, %name, %client );
      removeTaggedString(%client.name);
      %client.name = addTaggedString(%name);
      setTargetName(%client.target, %client.name);
   }
   return;
}

function ListGUIDS() {
   for(%i = 0; %i < ClientGroup.getCount(); %i++) {
      %cl = ClientGroup.getObject(%i);
      echo(""@%cl.namebase@" - GUID: "@%cl.GUID@"");
   }
}

//MODIFED 8-14-09
//Adding [W] will do a wav sound
function Cons(%m) {
   StrReplace(%w, "[W]", "~wfx/");
   MessageAll('msgAdmin', "\c5SERVER ADMIN: \c4"@%m@"");
}

function PlayerTimeLoop(%client) {
   %scriptController = %client.TWM2Core;
   %scriptController.gameTime++;
   if(%scriptController.gameTime >= 1440) {
      AwardClient(%client, "6");
   }
   schedule(60000,0, "PlayerTimeLoop", %client);
}

function PlayTWM2Intro(%client) {
   BottomPrint(%client, "T", 1, 3);
   schedule(250,0,"BottomPrint", %client, "TO", 1, 3);
   schedule(500,0,"BottomPrint", %client, "TOT", 1, 3);
   schedule(750,0,"BottomPrint", %client, "TOTA", 1, 3);
   schedule(1000,0,"BottomPrint", %client, "TOTAL", 1, 3);

   schedule(1750,0,"BottomPrint", %client, "TOTAL W", 1, 3);
   schedule(2000,0,"BottomPrint", %client, "TOTAL WA", 1, 3);
   schedule(2250,0,"BottomPrint", %client, "TOTAL WAR", 1, 3);
   schedule(2500,0,"BottomPrint", %client, "TOTAL WARF", 1, 3);
   schedule(2750,0,"BottomPrint", %client, "TOTAL WARFA", 1, 3);
   schedule(3000,0,"BottomPrint", %client, "TOTAL WARFAR", 1, 3);
   schedule(3250,0,"BottomPrint", %client, "TOTAL WARFARE", 1, 3);

   schedule(4000,0,"BottomPrint", %client, "TOTAL WARFARE M", 1, 3);
   schedule(4250,0,"BottomPrint", %client, "TOTAL WARFARE MO", 1, 3);
   schedule(4500,0,"BottomPrint", %client, "TOTAL WARFARE MOD", 2, 3);

   schedule(6000,0,"BottomPrint", %client, "TOTAL WARFARE MOD 2", 1, 3);
   schedule(6700,0,"BottomPrint", %client, "TOTAL WARFARE MOD 2 \n Advanced", 1, 3);
   schedule(7500,0,"BottomPrint", %client, "TOTAL WARFARE MOD 2 \n Advanced Warfare", 5, 3);

   if($Host::ServerPopup !$= "") {
      schedule(500, 0, "CenterPrint", %client, ""@$Host::ServerPopup@"", 7, 3);
   }
}


function DefaultGame::ZkillUpdateScore(%game, %client, %implement, %zombie){
   if( %implement $= "" || %implement == 0 || %client $= "") {
      //console spamz0r Fix
      return;
   }
   if( %implement.getClassName() $= "Turret") {
	  %client = %implement.getControllingClient();
      if(%client == 0 || %client $= "") {
         %client = %implement.getOwner();
      }
   }
   else if(%implement.getDataBlock().catagory $= "Vehicles") {
	  %client = %implement.getControllingClient();
   }
   %client.Zkills++;
   %client.AwardZombieKill(%zombie, %implement);
   %game.recalcScore(%client);
}

function FileObject::replaceLine(%this, %filename, %text, %line_number) {
// open/re-open the file to move to the start of it
if(!%this.openForRead(%filename))
return false;

// read file into temporary storage
for(%i = 1; !%this.isEOF(); %i++)
%temp[%i] = %this.readLine();

// make sure we can write to the file
if(!%this.openForWrite(%filename))
return false;

%lines = %i;

if(!%line_number)
%line_number = 1;

// write the lines back into the file, up to %line_number
for(%i = 1; %i < %line_number; %i++)
%this.writeLine(%temp[%i]);

// insert the text
%this.writeLine(%text);

// increment %i so %text replaces %line_number
for(%i++; %i < %lines; %i++)
%this.writeLine(%temp[%i]);

return true;
}

function FileObject::findInFile(%this, %filename, %text, %start_at, %end_at)
{
    // open/re-open the file to move to the start of it
    if(!%this.openForRead(%filename))
        return 0;

    if(%end_at && (%end_at < %start_at))
        %end_at = %start_at;

    // look for %text in %filename
    for(%i = 1; !%this.isEOF(); %i++)
    {
        if(%start_at && (%i < %start_at))
            continue;

        if( (strstr(%this.readLine(), %text) != -1) || (%end_at && (%i == %end_at)) )
            return %i;
    }

    return 0;
}

function GameConnection::AwardZombieKill(%client, %zombie, %implement) {
   if(%client $= "" || %client == 0) {
      return;
   }
   %zombieType = %zombie.type;
   //stop right now
   if(%zombie.isBoss) {
      return;
   }
   if(%zombieType $= "") {
      %zombieType = 1;
   }
   //Subduction for implement
   if(%implement.getClassName() $= "Turret") {
      %xpGain = mfloor($TWM2::ZombieXPAward[%zombieType] / 3);
   }
   else if(%implement.getDataBlock().catagory $= "Vehicles") {
      %xpGain = mfloor($TWM2::ZombieXPAward[%zombieType] / 2);
   }
   else {
      %xpGain = $TWM2::ZombieXPAward[%zombieType];
   }
   //
   if(%client.IsActivePerk("Double Down")) {
      GainExperience(%client, %xpGain*2, "[D-D]"@$TWM2::ZombieName[%zombieType]@" Killed ");
   }
   else {
      GainExperience(%client, %xpGain, ""@$TWM2::ZombieName[%zombieType]@" Killed ");
   }
   //Team Gain Perk
   if(%client.IsActivePerk("Team Gain")) {
      %TargetSearchMask = $TypeMasks::PlayerObjectType;
      InitContainerRadiusSearch(%client.player.getPosition(), 20, %TargetSearchMask); //small distance
      while ((%potentialTarget = ContainerSearchNext()) != 0){
         if (%potentialTarget.getPosition() != %pos) {
            if(%potentialTarget.client.team == %client.team && %potentialTarget.client != %client) {
               GainExperience(%potentialTarget.client, %xpGain, "Team gain from "@%client.namebase@" ");
            }
         }
      }
   }
   //some zombies have weapons, throw it :)
   %zombie.throwweapon(1);
   //End
   //HellJump?
   if($TWM::PlayingHellJump || $TWM::PlayingHorde) {
      Game.OnZombieDeath(%client, %zombie);
   }
}

function serverCmdCheckHTilt(%client) {

}

function serverCmdCheckendTilt(%client) {

}

function CureInfection(%player) {
   if(%player.infected) {
      %player.infected = 0;
      if(isEventPending(%player.infectedDamage)) {
         cancel(%player.infectedDamage);
         %player.infectedDamage = "";
         %player.beats = 0;
         %player.canZkill = 0;
         cancel(%player.zombieAttackImpulse);
         %player.setcancelimpulse = 1;
         schedule(5000,0, "resetattackImpulse" ,%player); //goodie
      }
   }
}

function ResetAttackImpulse(%player) {
   %player.setcancelimpulse = 0;
}

function GetRandomPosition(%mult,%nz) {
   %x = getRandom()*%mult;
   %y = getRandom()*%mult;
   %z = getRandom()*%mult;

   %rndx = getrandom(0,1);
   %rndy = getrandom(0,1);
   %rndz = getrandom(0,1);

   if(%nz) {
      %z = 0;
   }

   if (%rndx == 1){
      %negx = -1;
   }
   if (%rndx == 0){
      %negx = 1;
   }
   if (%rndy == 1){
      %negy = -1;
   }
   if (%rndy == 0){
      %negy = 1;
   }
   if (%rndz == 1){
      %negz = -1;
   }
   if (%rndz == 0){
      %negz = 1;
   }

   %rand = %negx * %x SPC %negy * %y SPC %Negz * %z;
   return %rand;
}

function DoMedalCheck(%client, %image) {
   switch$(%image) {
      case "BOVImage":
         if(%client.hasMedal(11)) {
            return 1;
         }
         else {
            return 0;
         }
      case "LD06SavagerImage":
         if(%client.hasMedal(1)) {
            return 1;
         }
         else {
            return 0;
         }
      case "IonLauncherImage" or "IonRifleImage" or "ConcussionGunImage":
         if(%client.hasMedal(9)) {
            return 1;
         }
         else {
            return 0;
         }
      case "flamerImage":
         if(%client.hasMedal(10)) {
            return 1;
         }
         else {
            return 0;
         }
      case "ShadowRifleImage":
         if(%client.hasMedal(13)) {
            return 1;
         }
         else {
            return 0;
         }
      case "MiniColliderCannonImage" or "PlasmasaberImage":
         if(%client.hasMedal(15)) {
            return 1;
         }
         else {
            return 0;
         }
      default:
         return 1;
   }
}

//ARMOR UPDATE
function updateArmorList(%client, %armorList) {
   if(!$Host::Purebuild) {
      %armorList = %armorList TAB "Commando" TAB "Support";
      if(getCurrentEXP(%client) >= $Ranks::MinPoints[$TWM2::ArmorReq["Shadow"]]) {
         %armorList = %armorList TAB "Shadow";
      }
      if(%client.hasMedal(9)) {
         %armorList = %armorList TAB "Microburst";
      }
      if(%client.hasMedal(27)) {
         %armorList = %armorList TAB "Nalcidic";
      }
      if(%client.hasMedal(13)) {
         %armorList = %armorList TAB "Shadow Commando";
      }
   }
   return %armorList;
}

function DoTWM2ArmorSetChecks(%client, %size) {
   %obj = %client.player;
}



// Shows the number of datablocks in your mod, it's capacity (in limitation to T2's internal limit)
function datablockInfo() {
   %blocks = DataBlockGroup.getCount();
   %effects = 0;

   for(%i = 0; %i < %blocks; %i++) {
      if(DataBlockGroup.getObject(%i).getClassName() $= "EffectProfile") {
         %n = DataBlockGroup.getObject(%i).getName();
         echo(""@%i@". "@%n@"");
         %effects++;
      }
   }
   echo("Number of Datablocks:");
   error(%blocks);
   echo("Current Datablock Capacity:");
   error(mCeil((%blocks / 2048)*100)@"%");
   echo("Number of EffectProfile datablocks:");
   error(%effects);
   echo("Percentage of EffectProfile usage on datablock pool:");
   error(mCeil((%effects / 2048)*100)@"%");

   if(%effects) {
      echo("You have some EffectProfiles remaining. Eliminate them to free up unused datablock space. EffectProfiles are unused Force Feedback datablocks, often attached to sounds. These can be safely removed from all SoundProfile datablocks and removed.");
   }
}

function SimObject::getUpVector(%obj){
   %vec = vectorNormalize(vectorsub(%obj.getEdge("0 0 1"),%obj.getEdge("0 0 -1")));
   return %vec;
}

function Player::IsAlive(%player) {
   if(isObject(%player)) {
      if(%player.getState() $= "dead") {
         return false;
      }
      else {
         return true;
      }
   }
   else {
      return false;
   }
}

package PlayerCountFix {
   function WeewtyFunctionOfAwesomeness() {
      %bots = 0;
      %c = ClientGroup.getCount();
      $HostGamePlayerCount = %c;
      for(%i = 0; %i < %c; %i++) {
         %cl = ClientGroup.getObject(%i);
         if(%cl.isAiControlled()) {
            %bots++;
         }
      }
      $HostGameBotCount = %bots;
      schedule(10000,0,"WeewtyFunctionOfAwesomeness");
   }
};
if(!isActivePackage(PlayerCountFix)) {
   activatePackage(PlayerCountFix);
   WeewtyFunctionOfAwesomeness();
}

function isClientControlledPlayer(%player) {
   for(%i = 0; %i < ClientGroup.getCount(); %i++) {
      %client = ClientGroup.getObject(%i);
      if(%client.player == %player) {
         return true;
      }
   }
   return false;
}

function doChallengeCheck(%src, %dead) {
   //currently removed...
}

function MessageDevs(%message) {
   for(%i = 0; %i < ClientGroup.getCount(); %i++) {
      if(ClientGroup.getObject(%i).isDev) {
         messageClient(ClientGroup.getObject(%i), 'MsgDev', ""@CollapseEscape(%message)@"");
      }
   }
}

function isSet(%s) {
   return (%s !$= "");
}

function TransferPieces(%owner, %target) {
   if(%target.recipientOf[%owner] != 1) {
      //uh oh, naughty naughty, no piece stealing
      messageClient(%target, 'msgClient', "\c3You are not a recipient of "@%owner.namebase@"'s pieces.");
      return;
   }
   messageall('MsgAdminForce', "\c3"@ %owner.namebase@" transfered his pieces to "@ %target.namebase@".");
   %group = nameToID("MissionCleanup/Deployables");
   %count = %group.getCount();
   for (%i = 0; %i < %count; %i++) {
      %obj =  %group.getObject(%i);
      if (%obj.getOwner() == %owner) {
         %obj.owner = %target;
         %obj.ownerGuid = %target.guid;
      }
   }
}

function RMPG() {
   %X = getWord(MissionArea.getArea(), 0);
   %Y = getWord(MissionArea.getArea(), 1);
   %W = getWord(MissionArea.getArea(), 2);
   %H = getWord(MissionArea.getArea(), 3);

   %OppX = ((%X) + (%W));
   %OppY = ((%Y) + (%H));
   %Position = getRandom(%X, %OppX) SPC getRandom(%Y, %OppY) SPC 0;

   %Z = getTerrainHeight(%position);
   %PositionF = getWord(%Position, 0) SPC getWord(%Position, 1) SPC %Z;

   return %PositionF;
}

function E_Sigma(%from, %to, %formula) {
   %totalSum = 0;
   for(%i = %from; %i < %to; %i++) {
      %totalSum += %formula;
   }
   return %totalSum;
}

//Building Porter
//Port in a Mettalic Save into Nighthawk
function pullPortBuilding(%guid, %slot) {
   %host = "www.the-construct.net:80";
   %filename = "/buildings/"@%guid@"/"@%slot@".cs";
   //
   %TCP = new TCPObject(BuildingPort);
   //
   %TCP.filename = %filename;
   $file[%TCP] = new FileObject();
   $file[%TCP].openForWrite("Buildings/Admin/Port_"@%guid@"_"@%slot@".cs");
   //
   echo("Beginning port of "@%guid@"'s building on TC - "@%slot@"");
   messageAll('MsgAdminForce', "\c5Connecting to TC.net to load "@%filename@"");
   %TCP.connect(%host);
}

function BuildingPort::onConnectFailed(%this) {
   error("Porter cannot connect to server");
   $file[%this].close();
   $file[%this].delete();
   %this.delete();
}

function BuildingPort::onConnected(%this) {
   %request = "GET" SPC %this.filename SPC "HTTP/1.1\x0aHost: www.the-construct.net\r\n\r\n";

   echo("Connected to TC, sending request.");

   %this.send(%request);
}

function BuildingPort::onLine(%this, %line) {
   %line = deTag(%line);
   if(strstr(%line, "%building") == -1) {

   }
   else {
      $file[%this].writeLine(%line);
   }
}

function BuildingPort::onDisconnect(%this) {
   $file[%this].close();
   $file[%this].delete();
   %this.delete();
}
