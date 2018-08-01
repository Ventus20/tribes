addCMDToHelp("CMDHelp", "Usage: /CMDHelp [Command]: tells you about a command.");
function ccCMDHelp(%sender, %args) {
   %cmd = getWord(%args, 0);
   if($CCHelp[%cmd] $= "") {
      messageclient(%sender, 'MsgClient', "\c3Command "@%cmd@" is not in the /CMDHelp Database.");
      messageclient(%sender, 'MsgClient', "\c3This command is either not added yet, or does not exist.");
      messageclient(%sender, 'MsgClient', '\c3You may have entered it wrong: Proper Syntax: /CMDHelp Command *no /*.');
   }
   else {
      messageclient(%sender, 'MsgClient', "\c2/"@%cmd@": "@$CCHelp[%cmd]@"");
   }
   return 1;
}

addCMDToHelp("SetRot", "Usage: /SetRot [Angle]: set your construction tool's rotation angle.");
function ccSetRot(%sender, %args) {
   if(%args $= "" || %args < 0 || %args > 360) {
      %sender.RotateAngle = $pi / 8;
      messageclient(%sender, 'MsgClient', "\c2Rotate Angle Reset.");
      return 1;
   }
   messageclient(%sender, 'MsgClient', "\c2Rotate Angle Set To \c3"@%args@"\c2.");
   %sender.RotateAngle = %args;
   return 1;
}

//CONTENT SAVING SYSTEM
addCMDToHelp("NameSlot", "Usage: /NameSlot [Save Slot] [Name]: Names a CSS Slot.");
function ccNameSlot(%sender, %args) {
   %slot = getWord(%args,0);
   %name = getWords(%args,1);
   if($SaveFile::Save[%sender.guid,%slot] $= "") {
      messageclient(%sender, 'MsgClient', "\c2There is nothing saved in slot "@%slot@".");
      return 1;
   }
   if(%name $= "") {
      messageclient(%sender, 'MsgClient', "\c2Please Specify a Name.");
      return 1;
   }
   $SaveFile::SlotName[%sender.guid,%slot] = ""@%name@"";
   export( "$SaveFile::*", "prefs/ContentSave.cs", false );
   messageclient(%sender, 'MsgClient', "\c2Slot "@%slot@" Has Been Named "@%name@".");
   return 1;
}

addCMDToHelp("Control", "Usage: /Control [AI Name]: Sets you to control a BOT.");
function ccControl(%sender,%args) {
   if(!isobject(%sender.player) || %sender.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2You must have a player object.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such Bot.');
      return 1;
   }
   if(!isobject(%target.player) || %target.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2The Target Player must have a player object.');
      return 1;
   }
   if (!%target.isAIControlled()) {
      messageclient(%sender, 'MsgClient', '\c2Cant control non-bots.');
      return 1;
   }
   %sender.setcontrolobject(%target.player);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 is now controling \c3"@ %target.namebase@"\c2.");
   messageclient(%sender,'MsgClient', "\c5Now Controlling " @%target.namebase@ ".");
   return 1;
}


addCMDToHelp("me", "Usage: /me [Text]: Sends a message under the \c0 Tag.");
function ccme(%sender,%args){
   messageall("MsgAdminForce", "\c0"@%sender.namebase SPC %args);
   return 1;
}
addCMDToHelp("me1", "Usage: /me1 [Text]: Sends a message under the \c1 Tag.");
function ccme1(%sender,%args){
   messageall("MsgAdminForce", "\c1"@%sender.namebase SPC %args);
   return 1;
}
addCMDToHelp("me2", "Usage: /me2 [Text]: Sends a message under the \c2 Tag.");
function ccme2(%sender,%args){
   messageall("MsgAdminForce", "\c2"@%sender.namebase SPC %args);
   return 1;
}
addCMDToHelp("me3", "Usage: /me3 [Text]: Sends a message under the \c3 Tag.");
function ccme3(%sender,%args){
   messageall("MsgAdminForce", "\c3"@%sender.namebase SPC %args);
   return 1;
}
addCMDToHelp("me4", "Usage: /me4 [Text]: Sends a message under the \c4 Tag.");
function ccme4(%sender,%args){
   messageall("MsgAdminForce", "\c4"@%sender.namebase SPC %args);
   return 1;
}
addCMDToHelp("me5", "Usage: /me5 [Text]: Sends a message under the \c5 Tag.");
function ccme5(%sender,%args){
   messageall("MsgAdminForce", "\c5"@%sender.namebase SPC %args);
   return 1;
}
addCMDToHelp("r", "Usage: /r [Text]: Sends a radio message with the \c3 tag, good for RPs.");
function ccr(%sender,%args){
   messageall("MsgStatic", "\c3[R]-"@getTaggedString(%sender.name)@": "@%args@"~wfx/misc/static.wav");
   return 1;
}

addCMDToHelp("givecard", "Usage: /givecard [name] [Level# 1,2,or 3]: Gives a player a card for leveled doors.");
function ccgivecard(%sender,%args) {
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   %level=getword(%args,1);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(%level == 1) {
      %target.haslev1[%sender.GUID] = 1;
      messageclient(%sender, 'MsgClient', "\c2Green Access Card Given to "@getTaggedString(%target.name)@".");
      messageclient(%target, 'MsgClient', "\c2"@getTaggedString(%sender.name)@" Gave you a Green Access Card.");
      return 1;
   }
   else if(%level == 2) {
      %target.haslev2[%sender.GUID] = 1;
      messageclient(%sender, 'MsgClient', "\c2Yellow Access Card Given to "@getTaggedString(%target.name)@".");
      messageclient(%target, 'MsgClient', "\c2"@getTaggedString(%sender.name)@" Gave you a Yellow Access Card.");
      return 1;
   }
   else if(%level == 3) {
      %target.haslev3[%sender.GUID] = 1;
      messageclient(%sender, 'MsgClient', "\c2Red Access Card Given to "@getTaggedString(%target.name)@".");
      messageclient(%target, 'MsgClient', "\c2"@getTaggedString(%sender.name)@" Gave you a Red Access Card.");
      return 1;
   }
   else {
      messageclient(%sender, 'MsgClient', '\c2Invalid Level, 1 - Green, 2 - Yellow, 3 - Red.');
      return 1;
   }
}

addCMDToHelp("takecard", "Usage: /takecard [name] [Level# 1,2,or 3]: remove a player's card for leveled doors.");
function cctakecard(%sender,%args) {
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   %level=getword(%args,1);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(%level == 1) {
      %target.haslev1[%sender.GUID] = 0;
      messageclient(%sender, 'MsgClient', "\c2Green Access Card Taken From "@getTaggedString(%target.name)@".");
      messageclient(%target, 'MsgClient', "\c2"@getTaggedString(%sender.name)@" Took Your Green Access Card.");
      return 1;
   }
   else if(%level == 2) {
      %target.haslev2[%sender.GUID] = 0;
      messageclient(%sender, 'MsgClient', "\c2Yellow Access Card Taken From "@getTaggedString(%target.name)@".");
      messageclient(%target, 'MsgClient', "\c2"@getTaggedString(%sender.name)@" Took Your Yellow Access Card.");
      return 1;
   }
   else if(%level == 3) {
      %target.haslev3[%sender.GUID] = 0;
      messageclient(%sender, 'MsgClient', "\c2Red Access Card Taken From "@getTaggedString(%target.name)@".");
      messageclient(%target, 'MsgClient', "\c2"@getTaggedString(%sender.name)@" Took Your Red Access Card.");
      return 1;
   }
   else {
      messageclient(%sender, 'MsgClient', '\c2Invalid Level, 1 - Green, 2 - Yellow, 3 - Red.');
      return 1;
   }
}

addCMDToHelp("help", "Usage: /help: lists chat commands for: clients, objects, and other /helps.");
function ccHelp(%sender,%args) {
   messageclient(%sender, 'MsgClient', '\c5 CCM Mod Chat Commands.');
   messageclient(%sender, 'MsgClient', '\c5 /bf, /opendoor, /setdoorpass, /name, /music, /radius');
   messageclient(%sender, 'MsgClient', '\c5 /delmypieces, /clearspawn, /buycmds, /nameSlot');
   messageclient(%sender, 'MsgClient', '\c5 /setspawn, /pm, /admincmds, /sacmds, /devcmds');
   messageclient(%sender, 'MsgClient', '\c5 /rankingcmds, /scale, /objmove, /power, /hover');
   messageclient(%sender, 'MsgClient', '\c5 /ViewZKill, /del, /givepieces, /getscale, /me');
   messageclient(%sender, 'MsgClient', '\c5 /me1, /me2, /me3, /me4, /me5, /r, /control');
   messageclient(%sender, 'MsgClient', '\c5 /givecard, /takecard, /time, /eventinfo, /moveAll');

   return 1;
}

addCMDToHelp("rankingcmds", "Usage: /rankingcmds: Lists all commands related to the TWM ranking system.");
function ccrankingcmds(%sender,%args) {
   messageclient(%sender, 'MsgClient', '\c5 CCM Mod Ranking-System Chat Commands.');
   messageclient(%sender, 'MsgClient', '\c5 /checkstats, /top5, /top10, /createsquad');
   messageclient(%sender, 'MsgClient', '\c5 /join, /leavesquad, /invite, /S');
   messageclient(%sender, 'MsgClient', '\c5 /ListSquads, /RequestInvite, /O, /Force');
   messageclient(%sender, 'MsgClient', '\c5 /SOL, /ranks, /Training');
   return 1;
}

addCMDToHelp("training", "Usage: /training [topic]: Gives you information on topics in TWM.");
function ccTraining(%sender,%args) {
   %bleh = getwords(%args,0);
   if(%bleh $="basics") {
      messageclient(%sender, 'MsgClient', '\c5 Chapter I : Starting Warfare.');
      messageclient(%sender, 'MsgClient', '\c5 TWM is a team warfare combat mod based off of CCM');
      messageclient(%sender, 'MsgClient', '\c5 TWM uses a different form of gameplay called the ranking system');
      messageclient(%sender, 'MsgClient', '\c5 For Each kill, you earn EXP. Once a certian level is reached, you will "Rank Up".');
      messageclient(%sender, 'MsgClient', '\c5 By Ranking up, you will unlock new weapons and abilities..');
      return 1;
   }
   else if(%bleh $="ranking") {
      messageclient(%sender, 'MsgClient', '\c5 Chapter II : The Ranking System, Part I.');
      messageclient(%sender, 'MsgClient', '\c5 Ranking is what adds a challenge to TWM.');
      messageclient(%sender, 'MsgClient', '\c5 Starters can only use a USP-45, Now this sounds kind of stupid but be thankful for having a gun in your hands');
      messageclient(%sender, 'MsgClient', '\c5 Starters should focus on getting their XP to 50 or Prv.G2.');
      return 1;
   }
   else if(%bleh $="ranking2") {
      messageclient(%sender, 'MsgClient', '\c5 Chapter III : The Ranking System, Part II.');
      messageclient(%sender, 'MsgClient', '\c5 Ranking Status Updates Every Fifteen Seconds.');
      messageclient(%sender, 'MsgClient', '\c5 To check your current rank info type /checkstats');
      messageclient(%sender, 'MsgClient', '\c5 The Goal for all people is to get a position in the top 10.');
      messageclient(%sender, 'MsgClient', '\c5 To view the top 10, type /top10. All of these are found in /rankingcmds.');
      return 1;
   }
   else if(%bleh $="guns") {
      messageclient(%sender, 'MsgClient', '\c5 Chapter IV : The Ranking System and Your Arsenal.');
      messageclient(%sender, 'MsgClient', '\c5 Your Arsenal is based off of your current Rank.');
      messageclient(%sender, 'MsgClient', '\c5 Obviously, the higher your rank is, the stronger the weapons you can use');
      messageclient(%sender, 'MsgClient', '\c5 However, ranking does take time, so focus on using what you have to your advantage.');
      messageclient(%sender, 'MsgClient', '\c5 To check weapon to rank info type /ranks #.');
      return 1;
   }
   else if(%bleh $="squads") {
      messageclient(%sender, 'MsgClient', '\c5 Chapter V : Teamwork Powerhouses, or Squads.');
      messageclient(%sender, 'MsgClient', '\c5 Obviously, Working Alone In TWM can be challenging at times.');
      messageclient(%sender, 'MsgClient', '\c5 Thats where Squads come in. Squads Consist Of Leaders And Members');
      messageclient(%sender, 'MsgClient', '\c5 To Make a Squad, type /createsquad *name*, You can only have one squad.');
      messageclient(%sender, 'MsgClient', '\c5 To Invite others type /invite name, if invited type /join. Squad chat is used with /s.');
      messageclient(%sender, 'MsgClient', '\c5 type /listsquads to see other squads.');
      messageclient(%sender, 'MsgClient', '\c5 During combat, you may want a better spawn point, type /SOL to spawn on your leader..');
      return 1;
   }
   else {
      messageclient(%sender, 'MsgClient', '\c5TWM Starting Assistance.. Or you can call this training!');
      messageclient(%sender, 'MsgClient', '\c5Type /Training topic');
      messageclient(%sender, 'MsgClient', '\c5Topics: basics,ranking,ranking2,guns, and squads');
      return 1;
   }
}

addCMDToHelp("GetScale", "Usage: /GetScale: Displays the size of an object.");
function ccGetScale(%sender){
   if(!isobject(%sender.player) || %sender.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2You must have a player object.');
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
   %scale = %obj.getrealsize();
   messageclient(%sender, 'MsgClient', "\c5This object's scale is "@%scale@".");
   return 1;
}

addCMDToHelp("getobj", "Usage: /getobj: Displays object information.");
function ccGetObj(%sender){
   if(!isobject(%sender.player) || %sender.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2You must have a player object.');
      return 1;
   }
   %pos        = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec        = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos  = vectoradd(%pos,vectorscale(%vec,100));
   %obj        = containerraycast(%pos,%targetpos,$AllObjMask,%sender.player);
   %obj        = getword(%obj,0);
   %dataBlock  = %obj.getDataBlock();
   %className  = %dataBlock.className;
   %owner      = %obj.owner;
   if (!isobject(%obj)) {
      messageclient(%sender, 'MsgClient', '\c5No object in range.');
      return 1;
   }
   messageclient(%sender, 'MsgClient', "\c5ObjectID: ("@%obj@") DB: "@%obj.getDatablock().getName()@".");
   return 1;
}

addCMDToHelp("pm", "Usage: /pm [name] [message]: sends a private message to clients, ![name] [message] is another way.");
function ccPM(%sender,%args) {
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   %message=getwords(%args,1);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   messageclient(%target, 'MsgClient',"\c1From "@%sender.namebase@": "@%message);
   messageclient(%sender, 'MsgClient',"\c1To "@%target.namebase@": "@%message);
   echo("\c2Private Message from: "@%sender.namebase@" to: "@%target.namebase@"\c1 "@%message);
   return 1;
}

addCMDToHelp("opendoor", "Usage: /opendoor [pass ?]: opens a door.");
function ccopendoor(%sender,%args) {
   %pos        = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec        = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos  = vectoradd(%pos,vectorscale(%vec,100));
   %obj        = containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj        = getword(%obj,0);
   %dataBlock  = %obj.getDataBlock();
   %className  = %dataBlock.className;
   %cash       = %obj.amount;
   %owner      = %obj.owner;
   %obj.issliding = 0;
   if (%obj.Collision == true) //if is a colition door
      return 1;                  //stop here
   if (%obj.canmove == false) //if it cant move
      return 1;                  //stop here
   if (%obj.isdoor != 1 && %hitobj.getdatablock().getname() !$="DeployedTdoor"){
      messageclient(%sender, 'MsgClient', '\c5No door in range.');
      return 1;
   }
   if (!isobject(%obj)) {
      messageclient(%sender, 'MsgClient', '\c5No door in range.');
      return 1;
   }
   if (%obj.powercontrol == 1) {
      messageclient(%sender, 'MsgClient', '\c5This door is controlled by a power supply.');
      return 1;
   }
   %pass = %args;
   if (%obj.pw $= %pass) {
      if (%obj.toggletype ==1){
         if (%obj.moving $="close" || %obj.moving $="" || %going $="opening") {
         	schedule(10,0,"open",%obj);
            return 1;
         }
         else if (%obj.moving $="open" || %going $="closeing"){
           schedule(10,0,"close",%obj);
           return 1;
         }
      }
      else {
          schedule(10,0,"open",%obj);
          return 1;
      }
   }
   if (%obj.pw !$= %pass) {
      messageclient(%sender,'MsgClient',"\c2Password Denied.");
      return 1;
   }
}

addCMDToHelp("setdoorpass", "Usage: /setdoorpass [pass]: sets a password on Normal & Toggle Doors.");
function ccsetdoorpass(%sender,%args){
   %pos=%sender.player.getMuzzlePoint($WeaponSlot);
   %vec = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos=vectoradd(%pos,vectorscale(%vec,100));
   %obj=containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj=getword(%obj,0);
   %dataBlock = %obj.getDataBlock();
   %className = %dataBlock.className;
   if (%classname !$= "door") {
   messageclient(%sender, 'MsgClient', '\c2No door in range.');
      return 1;
   }
   if (%obj.owner!=%sender && %obj.owner !$="") {
	messageclient(%sender, 'MsgClient', '\c2You do not own this door.');
    return 1;
   }
   if (!isobject(%obj)) {
	messageclient(%sender, 'MsgClient', '\c2No door in range.');
    return 1;
   }
   if (%obj.Collision $= true) {
	messageclient(%sender, 'MsgClient', '\c2Collision doors can not have passwords.');
    return 1;
   }
   if(isobject(%obj) && %obj.owner==%sender) {
      %pw=getword(%args,0);
      %obj.pw=%pw;
	  messageclient(%sender, 'MsgClient', '\c2Password set, password is %1.',%pw);
      return 1;
   }
}

addCMDToHelp("bf", "Usage: /bf: gives you your current loadout in the inventory, purebuild must be on.");
function ccbf(%sender,%args) {
   if($Host::Purebuild == 1) {
   	  buyFavorites(%sender);
      return 1;
   }
   else if(!$host::purebuild && %sender.issuperadmin && $Host::AdminNoPureBF) {
      buyFavorites(%sender);
      return 1;
   }
   else {
      messageclient(%sender, 'MsgClient', "\c5Purebuild Is Off");
      return 1;
   }
}

addCMDToHelp("GetAmmo", "Usage: /GetAmmo [Unused?]: information about this command unknown.");
function ccGetAmmo(%sender,%args){
   %pos        = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec        = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos  = vectoradd(%pos,vectorscale(%vec,5));
   %obj        = containerraycast(%pos,%targetpos,$typemasks::VehicleObjectType,%sender.player);
   if(%obj != ""){
      %obj        = getword(%obj,0);
   	  %className  = %obj.getClassName();
	  %Name		= %obj.getDatablock().getName();
	  if(%className $= "WheeledVehicle" && %Name $= "AmmoCrateVeh"){
	     if(%obj.numReload >= 2){
            buyDeployableFavorites(%sender);
            %obj.numReload--;
            return 1;
	     }
	     else if(%obj.numReload == 1){
		    buyDeployableFavorites(%sender);
		    %obj.schedule(1000, delete);
            return 1;
	     }
         return 1;
      }
      return 1;
   }
   return 1;
}

addCMDToHelp("setSpawn", "Usage: /setSpawn: sets your spawn point.");
function ccsetspawn(%sender) {
   %pos=%sender.player.getMuzzlePoint($WeaponSlot);
   %vec = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos=vectoradd(%pos,vectorscale(%vec,100));
   %obj=containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj=getword(%obj,0);
   %dataBlock = %obj.getDataBlock();
   if (%datablock.isspawnpoint != 1) {
   messageclient(%sender, 'MsgClient', '\c2No spawn point in range.');
   return 1;
   }
   if ( (%obj.owner != %sender) && (%obj.ispersonal == 1) ) {
   messageclient(%sender, 'MsgClient', '\c2This is a personal spawn point, you cannot spawn here.');
   return 1;
   }
   if (!isobject(%obj)) {
   messageclient(%sender, 'MsgClient', '\c2No spawn point in range.');
   return 1;
   }
   if (%obj.team != %sender.team) {
   messageclient(%sender, 'MsgClient', '\c2This spawn point is not on your team.');
   return 1;
   }
   %sender.spawnpoint=%obj;
   messageclient(%sender, 'MsgClient', '\c2Spawn point set to this location');
   return 1;
}

addCMDToHelp("clearspawn", "Usage: /clearspawn: sets you to spawn at the default location.");
function ccclearspawn(%sender) {
   %sender.spawnpoint=0;
   messageclient(%sender, 'MsgClient', '\c2Spawn point set to default location.');
   return 1;
}

addCMDToHelp("DelMyPieces", "Usage: /Delmypieces: deletes all objects you have deployed.");
function ccDelmypieces(%sender,%args) {
   messageclient(%sender, 'MsgClient', "\c2You have deleted your pieces.");
   %group = nameToID("MissionCleanup/Deployables");
   %count = %group.getCount();
   for (%i=0;%i<%count;%i++) {
      %obj =  %group.getObject(%i);
      if (%obj.getOwner() == %sender) {
         %random = getRandom(500,3000);
         %obj.getDataBlock().schedule(%random,"disassemble",%sender.player,%obj);
      }
   }
   return 1;
}

addCMDToHelp("name", "Usage: /name [name]: names an object, you can use tags in this command.");
function ccname(%sender,%args) {
   %pos          = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec          = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos    = vectoradd(%pos,vectorscale(%vec,100));
   %obj          = containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj          = getword(%obj,0);
   %dataBlock    = %obj.getDataBlock();
   %className    = %dataBlock.className;

   if (%obj.getowner() != %sender && !%sender.isadmin){
      messageclient(%sender, 'MsgClient', "\c2You do not own this.");
      return 1;
   }
   if (%className $= "waypoint"){
      %obj.wp.schedule(10, "delete");
      %waypoint = new  (WayPoint)(){
         dataBlock        = WayPointMarker;
         position         = %obj.getPosition();
         name             = %args;
         scale            = "0.1 0.1 0.1";
         team             = %sender.team;
      };
      MissionCleanup.add(%waypoint);
      %obj.wp=%waypoint;
      return 1;
   }
   else {
      setTargetName(%Obj.target, addTaggedString(collapseEscape(%args)));
      return 1;
   }
}

addCMDToHelp("scale", "Usage: /scale [# or x] [# or x] [# or x]: Sets the size of an object, 'x' will leave the current size on that axis.");
function ccscale(%sender, %args) {
   %pos         = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec         = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos   = vectoradd(%pos,vectorscale(%vec,100));
   %obj         = containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj         = getword(%obj,0);
   if (%obj <1)
      return 1;
   %objectScale = getwords(%obj.getScale(),0,2);
   %dataBlock   = %obj.getDataBlock();
   %name        = %dataBlock.getname();
   %className   = %dataBlock.className;
   %old = %obj.getRealSize();
   if (!isobject(%obj)) {
      messageclient(%sender, 'MsgClient', '\c5No Object in range.');
      return 1;
   }
   if (!Deployables.isMember(%obj)) {
      messageClient(%sender, 'MsgClient', "\c2That piece is part of the map and cannot be resized.");
      return 1;
   }
   if (%obj.ownerguid != %sender.guid && (%sender.isadmin !=1 && (%obj.ownerguid !$="" && %obj.powerfreq !$=""))){
   messageclient(%sender, 'MsgClient', "\c2You do not own this.");
   return 1;
   }
   
   %x = getWord(%args, 0);
   %y = getWord(%args, 1);
   %z = getWord(%args, 2);
   
   if((%x < 0.1) && %x !$= "x" && %x > 500) {
      messageclient(%sender, 'MsgClient', "\c2Error: X Size Not Specified or Invalid");
      return 1;
   }
   if((%y < 0.1) && %y !$= "x" && %y > 500) {
      messageclient(%sender, 'MsgClient', "\c2Error: Y Size Not Specified or Invalid");
      return 1;
   }
   if((%z < 0.1) && %z !$= "x" && %z > 500) {
      messageclient(%sender, 'MsgClient', "\c2Error: Z Size Not Specified or Invalid");
      return 1;
   }
   if(%x $= "x") {
      %x = getword(%obj.getScale(),0);
   }
   if(%y $= "x") {
      %y = getword(%obj.getScale(),1);
   }
   if(%z $= "x") {
      %z = getword(%obj.getScale(),2);
   }
   if(%x <= 0 || %y <= 0 || %z <= 0) {
      messageclient(%sender, 'MsgClient', "\c2Error: Missing Side Value");
      return 1;
   }
   %set = ""@%x@" "@%y@" "@%z@"";
   %fullscale = ""@%x@" "@%y@" "@%z@"";
   //Redone 6/19/09
   if(%classname $= "spine" || %classname $= "mspine" || %classname $= "spine2" || %classname $= "wall" || %classname $= "wwall" || %classname $= "floor" || %classname $= "door") {
      %fullscale = VectorMultiply(%fullscale, "0.250 0.333333 2");   //thanks krash.
   }
   //APPLY
   //ensure sizes have not been modified
   %obj.setCloaked(true);
   %obj.schedule(150, "setCloaked", false);
   //
   messageclient(%sender, 'MsgClient', "\c2Rescaling object from "@%old@", to "@%set@".");
   %obj.SetRealSize(%fullscale);
   %obj.scale=%fullscale;
   %obj.settransform(%obj.gettransform());
   return 1;
}

addCMDToHelp("objmove", "Usage: /objmove [#] [#] [#]: moves an object.");
function ccobjmove(%sender,%args) {
   if(!isobject(%sender.player) || %sender.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2You must have a player object.');
      return 1;
   }
   %pos        = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec        = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos  = vectoradd(%pos,vectorscale(%vec,100));
   %obj        = containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj        = getword(%obj,0);
   %dataBlock  = %obj.getDataBlock();
   %className  = %dataBlock.className;
   %objpos     = %obj.getposition();
   %move       = getwords(%args,0);
   %moveto     = vectorAdd(%objpos, %move);

   if (!isobject(%obj)) {
      messageclient(%sender, 'MsgClient', '\c5No Object in range.');
      return 1;
   }
   if (%obj.ownerguid != %sender.guid && (%sender.isadmin !=1 && (%obj.ownerguid !$="" && %obj.powerfreq !$=""))){
      messageclient(%sender, 'MsgClient', "\c2You do not own this.");
      return 1;
   }
   if (!Deployables.isMember(%obj)) {
      messageClient(%sender, 'MsgClient', "\c2That piece is part of the map and cannot be moved.");
      return 1;
   }
   if (%obj.isdoor==1){//only move doors that are fully closed and not moving
      if (%obj.canmove == false){
         messageclient(%sender, 'MsgClient', "\c2You cannot move a door that is already moving.");
         return 1;
      }
      if(%obj.state !$="closed" && %obj.state !$=""){
         messageclient(%sender, 'MsgClient', "\c2You can only move fully closed doors.");
         return 1;
      }
   }
   %obj.setCloaked(true);
   %obj.schedule(150, "setCloaked", false);
   %obj.setposition(%moveto);
   messageclient(%sender, 'MsgClient', "\c2Object moved "@%move@".");
   return 1;
}

addCMDToHelp("del", "Usage: /del: Deletes an object you own.");
function ccdel(%sender,%args) {
   if(!isobject(%sender.player) || %sender.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2You must have a player object.');
      return 1;
   }
   %pos        = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec        = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos  = vectoradd(%pos,vectorscale(%vec,100));
   %obj        = containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj        = getword(%obj,0);
   %dataBlock  = %obj.getDataBlock();
   %className  = %dataBlock.className;

   if (!isobject(%obj)) {
      messageclient(%sender, 'MsgClient', '\c5No Object in range.');
      return 1;
   }
   if (%obj.ownerguid != %sender.guid && !%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', "\c2You do not own this.");
      return 1;
   }
   if (!Deployables.isMember(%obj)) {
      messageClient(%sender, 'MsgClient', "\c2That piece is part of the map and cannot be deleted.");
      return 1;
   }
   %obj.delete();
   messageclient(%sender, 'MsgClient', "\c2object deleted.");
   return 1;
}

addCMDToHelp("power", "Usage: /power [#]: sets your current power frequency.");
function ccpower(%sender,%args) {
   %client = %sender.player;
   if(%args > 150) {
      %client.powerfreq = 1;
      messageclient(%sender, 'MsgClient', "\c5Max Freq 150");
      messageclient(%sender, 'MsgClient', "\c2Setting To Freq 1");
      return 1;
   }
   %sender.player.powerFreq = %args;
   messageclient(%sender, 'MsgClient', "\c2Setting To Freq "@%args@".");
   return 1;
}

addCMDToHelp("givePieces", "Usage: /givePieces [name]: gives your pieces to another player.");
function ccgivepieces(%sender,%args) {
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if(%nametotest $= "") {
      messageclient(%sender, 'MsgClient', '\c2No target player specified.');
      return 1;
   }
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@" gave his pieces to "@ %target.namebase@".");
   %group = nameToID("MissionCleanup/Deployables");
   %count = %group.getCount();
   for (%i=0;%i<%count;%i++) {
      %obj =  %group.getObject(%i);
      if (%obj.getOwner() == %sender) {
         %obj.owner = %target;
         %obj.ownerGuid = %target.guid;
      }
   }
   return 1;
}

//Hover By: Dark Dragon DX
addCMDToHelp("hover", "Usage: /hover: allows you to maintain your position in mid air.");
function ccHover(%sender){
   if (!IsObject(%Sender.player)){
      messageclient(%sender, 'MsgClient', '\c5No player object.');
      return 1;
   }
   if (!$host::purebuild){
      messageclient(%sender, 'MsgClient', '\c5Purebuild is off.');
      return 1;
   }
   if (%Sender.ishovering == 0){
      %Pad = new StaticShape() {
          dataBlock = DeployedSpine;
          scale = ".3 .3 1";
          position = "0 0 0";
      };
      %Pad.setCloaked(true);
      %Pad.setowner(%Sender);
      %Sender.HoverPad = %Pad;
      %Sender.ishovering = 1;
      Hover(%Sender);
      messageclient(%sender, 'MsgClient', '\c5Now hovering...');
      return 1;
   }
   else {
      %Sender.ishovering = 0;
      messageclient(%sender, 'MsgClient', '\c5Stopped hovering.');
      %Sender.HoverPad.delete();
      return 1;
   }
}

addCMDToHelp("radius", "Usage: /radius [#]: sets the radius of a switch.");
function ccradius(%sender, %args) {
   if(!isobject(%sender.player) || %sender.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2You must have a player object.');
      return 1;
   }
   %pos         = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec         = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos   = vectoradd(%pos,vectorscale(%vec,100));
   %obj         = containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj         = getword(%obj,0);
   %dataBlock   = %obj.getDataBlock();
   %name        = %dataBlock.getname();
   if (%obj <1)
      return 1;
   %rad         = getword(%args,0);
   %obj.setCloaked(true);
   %obj.schedule(150, "setCloaked", false);
   %obj.switchRadius = %rad;
   messageclient(%sender, 'MsgClient', "\c5Radius Set to "@%rad@".");
   return 1;
}

addCMDToHelp("getTip", "Usage: /gettip [# or blank]: sends you a tip.");
function ccgettip(%sender, %args) {
   %num = getword(%args,0);
   RandomTip(%sender,%num);
   return 1;
}

addCMDToHelp("ranks", "Usage: /ranks [#]: displays the name of the rank, XP required for it, and what it gives you.");
function ccranks(%sender, %args) {
   %rank = getwords(%args,0);
   switch(%rank) {
      case 0: %Rankname = "Private - "@$Ranks::MinPoints[0]@"XP Needed";
      case 1: %Rankname = "Private Grade I - "@$Ranks::MinPoints[1]@"XP Needed";
      case 2: %Rankname = "Private Grade II - "@$Ranks::MinPoints[2]@"XP Needed";
      case 3: %Rankname = "Private Grade III - "@$Ranks::MinPoints[3]@"XP Needed";
      case 4: %Rankname = "Gunnary Private - "@$Ranks::MinPoints[4]@"XP Needed, Yields MP12 SMG";
      case 5: %Rankname = "Gunnary Private Grade I - "@$Ranks::MinPoints[5]@"XP Needed";
      case 6: %Rankname = "Gunnary Private Grade II - "@$Ranks::MinPoints[6]@"XP Needed";
      case 7: %Rankname = "Gunnary Private Grade III - "@$Ranks::MinPoints[7]@"XP Needed";
      case 8: %Rankname = "Corporal - "@$Ranks::MinPoints[8]@"XP Needed, Yields Commando Armor";
      case 9: %Rankname = "Corporal Grade I - "@$Ranks::MinPoints[9]@"XP Needed";
      case 10: %Rankname = "Corporal Grade II - "@$Ranks::MinPoints[10]@"XP Needed, Yields Flame Thrower";
      case 11: %Rankname = "Corporal Grade III - "@$Ranks::MinPoints[11]@"XP Needed, Yields Bazooka";
      case 12: %Rankname = "Corporal Grade IV - "@$Ranks::MinPoints[12]@"XP Needed, Yields Shot Gun";
      case 13: %Rankname = "Sergant - "@$Ranks::MinPoints[13]@"XP Needed, Yields Support Armor";
      case 14: %Rankname = "Sergant Grade I - "@$Ranks::MinPoints[14]@"XP Needed";
      case 15: %Rankname = "Sergant Grade II - "@$Ranks::MinPoints[15]@"XP Needed";
      case 16: %Rankname = "Sergant Grade III - "@$Ranks::MinPoints[16]@"XP Needed";
      case 17: %Rankname = "Sergant Grade IV - "@$Ranks::MinPoints[17]@"XP Needed, Yields Sniper Rifle";
      case 18: %Rankname = "Gunnary Sergant - "@$Ranks::MinPoints[18]@"XP Needed, Yields AV-Missile Launcher";
      case 19: %Rankname = "Gunnary Sergant Grade I - "@$Ranks::MinPoints[19]@"XP Needed";
      case 20: %Rankname = "Gunnary Sergant Grade II - "@$Ranks::MinPoints[20]@"XP Needed";
      case 21: %Rankname = "Gunnary Sergant Grade III - "@$Ranks::MinPoints[21]@"XP Needed";
      case 22: %Rankname = "Gunnary Sergant Grade IV - "@$Ranks::MinPoints[22]@"XP Needed";
      case 23: %Rankname = "Lieutenant - "@$Ranks::MinPoints[23]@"XP Needed, Yields M32";
      case 24: %Rankname = "Lieutenant Grade I - "@$Ranks::MinPoints[24]@"XP Needed";
      case 25: %Rankname = "Lieutenant Grade II - "@$Ranks::MinPoints[25]@"XP Needed, Yields M32 with RPG";
      case 26: %Rankname = "Lieutenant Grade III - "@$Ranks::MinPoints[26]@"XP Needed";
      case 27: %Rankname = "Lieutenant Grade IV - "@$Ranks::MinPoints[27]@"XP Needed";
      case 28: %Rankname = "Captain - "@$Ranks::MinPoints[28]@"XP Needed, Yields PCT";
      case 29: %Rankname = "Captain Grade I - "@$Ranks::MinPoints[29]@"XP Needed, Yields Rot. Shot Gun";
      case 30: %Rankname = "Captain Grade II - "@$Ranks::MinPoints[30]@"XP Needed, Yields Incindinary Grenade";
      case 31: %Rankname = "Captain Grade III - "@$Ranks::MinPoints[31]@"XP Needed, Yields Napalm Cannon, Nalcidic Armor";
      case 32: %Rankname = "Major - "@$Ranks::MinPoints[32]@"XP Needed, Yields SpecOps Armor, RX-12(SG), PGC";
      case 33: %Rankname = "Major Grade I - "@$Ranks::MinPoints[33]@"XP Needed, Yields RX-12(GL)";
      case 34: %Rankname = "Major Grade II - "@$Ranks::MinPoints[34]@"XP Needed, Yields Targeting Beaconer (AC-130)";
      case 35: %Rankname = "Major Grade III - "@$Ranks::MinPoints[35]@"XP Needed, Yields Silenced USP-45";
      case 36: %Rankname = "Lieutenant Colonel - "@$Ranks::MinPoints[36]@"XP Needed, Yields AT6 Rocket Launcher";
      case 37: %Rankname = "Lieutenant Colonel Grade I - "@$Ranks::MinPoints[37]@"XP Needed";
      case 38: %Rankname = "Lieutenant Colonel Grade II - "@$Ranks::MinPoints[38]@"XP Needed";
      case 39: %Rankname = "Lieutenant Colonel Grade III - "@$Ranks::MinPoints[39]@"XP Needed, Yields Pulse Phaser";
      case 40: %Rankname = "Colonel - "@$Ranks::MinPoints[40]@"XP Needed, Yields Blitz Rifle";
      case 41: %Rankname = "Colonel Grade I - "@$Ranks::MinPoints[41]@"XP Needed, Yields Phantom Spiker";
      case 42: %Rankname = "Colonel Grade II - "@$Ranks::MinPoints[42]@"XP Needed, Yields Pulse Chaingun";
      case 43: %Rankname = "Brigadier - "@$Ranks::MinPoints[43]@"XP Needed, Yields RSA Scout Armor, Desert Eagle Pistol";
      case 44: %Rankname = "Brigadier Grade I - "@$Ranks::MinPoints[44]@"XP Needed, Yields Photon Laser";
      case 45: %Rankname = "Brigadier Grade II - "@$Ranks::MinPoints[45]@"XP Needed, Yields RSA Laser Rifle";
      case 46: %Rankname = "General - "@$Ranks::MinPoints[46]@"XP Needed, Yields PBC Cannon, Missile Beaconing Mode, Enemia Rocket Launcher";
      case 47: %Rankname = "General 3 Stars - "@$Ranks::MinPoints[47]@"XP Needed, Yields Artillery Beaconing Mode";
      case 48: %Rankname = "General 5 Stars - "@$Ranks::MinPoints[48]@"XP Needed, Yields Volatage Cannon";
      case 49: %Rankname = "Commander In Chief - "@$Ranks::MinPoints[49]@"XP Needed, Yields ALSWP";
      default: %Rankname = "Invalid Rank Number, 0-49 Accepted";
   }
   messageClient(%sender, 'MsgClient', "\c5Rank Info: "@%Rankname@".");
   return 1;
}

addCMDToHelp("music", "Usage: /music [name]: plays T2 Music by name.");
function ccmusic(%sender, %args) {
   %music=getword(%args,0);
   if(%music $= "Desert" || %music $= "Volcanic" || %music $= "Badlands" || %music $= "Ice" || %music $= "Lush" || %music $= "Doom") {
      changemusic(%sender,%music);
      return 1;
   }
   else {
      messageclient(%sender, 'MsgClient', '\c5Invalid Option, Please Choose One Of These:');
      messageclient(%sender, 'MsgClient', '\c5Desert, Volcanic, Badlands, Ice, Lush, Doom');
      messageclient(%sender, 'MsgClient', '\c3SP1.0: RAAM, Darkrai, LRAAM');
      return 1;
   }
}

addCMDToHelp("time", "Usage: /time: sends you the current time at the server.");
function ccTime(%sender,%args) {
   messageclient(%sender,'Date',"\c5The Time Is \c6"@formattimestring("hh:nn a")@"\c5 On \c6"@formattimestring("mm-dd-yy")@"\c5.");
   return 1;
}

addCMDToHelp("buyHelp", "Usage: /BuyHelp [topic]: explains the TWM upgrade system.");
function ccbuyhelp(%sender,%args) {
   %bleh = getwords(%args,0);
   if(%bleh $="basics") {
      messageclient(%sender, 'MsgClient', '\c5 TWM Buying Chapter 1: Basics.');
      messageclient(%sender, 'MsgClient', '\c5 Buying is a new addition to this combat based mod.');
      messageclient(%sender, 'MsgClient', '\c5 You can use your kill points to buy weapon and armor upgrades');
      messageclient(%sender, 'MsgClient', '\c5 Sometimes these upgrades can help your teammates as well.');
      return 1;
   }
   else if(%bleh $="upgrades") {
      messageclient(%sender, 'MsgClient', '\c5 TWM Buying Chapter 2: Upgrades.');
      messageclient(%sender, 'MsgClient', '\c5 Upgrading your weapons and armor uses the /upgrade command.');
      messageclient(%sender, 'MsgClient', '\c5 These upgrades can give you an advantage in the battlefield at times.');
      messageclient(%sender, 'MsgClient', '\c5 Be aware that some upgrades can be deadly to you at times as well.');
      return 1;
   }
   else if(%bleh $="warfare") {
      messageclient(%sender, 'MsgClient', '\c5 TWM Buying Chapter 3: Warfare With Upgrades.');
      messageclient(%sender, 'MsgClient', '\c5 Using your upgrades Strategicly is important in warfare.');
      messageclient(%sender, 'MsgClient', '\c5 For Example.. dont put a freaking laser pointer on a targets head with a sniper.');
      messageclient(%sender, 'MsgClient', '\c5 Instead aim low and then look up and let them have it!');
      return 1;
   }
   else {
      messageclient(%sender, 'MsgClient', '\c5 TWM Upgrading System, Select A Topic.');
      messageclient(%sender, 'MsgClient', '\c5 Topics: basics, upgrades, warfare');
      messageclient(%sender, 'MsgClient', '\c5 For Example: /buyhelp basics.');
      return 1;
   }
}

addCMDToHelp("buycmds", "Usage: /buycmds: lists commands related to the TWM Upgrade System.");
function ccbuycmds(%sender,%args) {
   messageclient(%sender, 'MsgClient', '\c5 TWM Buying Commands.');
   messageclient(%sender, 'MsgClient', '\c5 /buyhelp, /weaponups, /armorups, /upgrade');
   messageclient(%sender, 'MsgClient', '\c5 /clientstats, /myphrase, /TPU, /PSG, /LTGL, /Psni');
   messageclient(%sender, 'MsgClient', '\c5 /terroristME');
   return 1;
}

addCMDToHelp("weaponups", "Usage: /weaponups: lists upgrades for your weapons.");
function ccweaponups(%sender,%args) {
   messageclient(%sender, 'MsgClient', '\c5 TWM Weapon Upgrades.');
   messageclient(%sender, 'MsgClient', '\c5 |NAME| - |Cost| - |Code|.');
   messageclient(%sender, 'MsgClient', '\c5 Laser Sight - 500 - Lsr');
   messageclient(%sender, 'MsgClient', '\c5 Artillery II - 1000 - Art2');
   messageclient(%sender, 'MsgClient', '\c5 Artillery III - 2000 - Art3');
   messageclient(%sender, 'MsgClient', '\c5 Tripple Pulse - 2000 - Tpuls');
   messageclient(%sender, 'MsgClient', '\c5 Pulse Shotgun - 2000 - PulsSgun');
   messageclient(%sender, 'MsgClient', '\c5 Vehicle Nightmare - 5000 - Vboom');
   messageclient(%sender, 'MsgClient', '\c5 Pulse Sniper Upgrade - 5000 - Psniper');
   messageclient(%sender, 'MsgClient', '\c5 Photon Storm - 10000 - Storm');
   return 1;
}

addCMDToHelp("armorups", "Usage: /armorups: lists upgrades for your player.");
function ccarmorups(%sender,%args) {
   messageclient(%sender, 'MsgClient', '\c5 TWM Player Armor Upgrades.');
   messageclient(%sender, 'MsgClient', '\c5 |NAME| - |Cost| - |Code|.');
   messageclient(%sender, 'MsgClient', '\c5 Rep. Patch Increase - 500 - Ptches');
   messageclient(%sender, 'MsgClient', '\c5 Exploding Armor - 2000 - Boomyarmor');
   messageclient(%sender, 'MsgClient', '\c5 Flashlight - 2500 - light');
   messageclient(%sender, 'MsgClient', '\c5 Last Chance - 5000 - chance');
   return 1;
}

addCMDToHelp("LTGL", "Usage: /LTGL: Toggles a pointer laser.");
function ccLTGL(%sender,%args) {
   if(!$Buying::LsrPnt[%sender.GUID]) {
      messageclient(%sender, 'MsgClient', '\c5You dont own the Laser Targeter Ability.');
      return 1;
   }
   if(!%sender.player.haslaseron) {
      %sender.player.haslaseron = 1;
      %t = new TargetProjectile() {
          dataBlock        = "BasicTargeter";
          initialDirection = %sender.player.getMuzzleVector($WeaponSlot);
          initialPosition  = %sender.player.getMuzzlePoint($WeaponSlot);   //Helmet Battery
          sourceObject     = %sender.player;
          sourceSlot       = 0;  //from ze gun?
          vehicleObject    = 0;
      };
      MissionCleanup.add(%t);
      %sender.player.LTGT = %t;
      checkstatusonlaser(%sender.player);
      messageclient(%sender, 'MsgClient', '\c5Laser Enabled.');
      return 1;
   }
   else {
      %sender.player.haslaseron = 0;
      if(isObject(%sender.player.LTGT))
         %sender.player.LTGT.delete();
      messageclient(%sender, 'MsgClient', '\c5Laser Disabled.');
      return 1;
   }
}

addCMDToHelp("PSni", "Usage: /PSni: Toggles the pulse sniper mode for the sniper rifle.");
function ccPSni(%sender,%args) {
   if(!$Buying::PSnip[%sender.GUID]) {
      messageclient(%sender, 'MsgClient', '\c5You dont own the Pulse Sniper Ability.');
      return 1;
   }
   if(!%sender.Psniper) {
      %sender.Psniper = 1;
      messageclient(%sender, 'MsgClient', '\c5Pulse Sniper Enabled.');
      return 1;
   }
   else {
      %sender.Psniper = 0;
      messageclient(%sender, 'MsgClient', '\c5Pulse Sniper Disabled.');
      return 1;
   }
}

addCMDToHelp("TPU", "Usage: /TPU: Toggles tripple pulse for the pulse phaser.");
function ccTPU(%sender,%args) {
   if(!$Buying::TPuls[%sender.GUID]) {
      messageclient(%sender, 'MsgClient', '\c5You dont own the Tripple Pulse Ability.');
      return 1;
   }
   if(!%sender.TPUon && !%sender.PSGon) {
      %sender.TPUon = 1;
      messageclient(%sender, 'MsgClient', '\c5Tripple Pulse Enabled.');
      return 1;
   }
   else if(!%sender.TPUon && %sender.PSGon) {
      %sender.TPUon = 1;
      %sender.PSGon = 0;
      messageclient(%sender, 'MsgClient', '\c5Tripple Pulse Enabled, Pulse Shotgun Disabled.');
      return 1;
   }
   else {
      %sender.TPUon = 0;
      messageclient(%sender, 'MsgClient', '\c5Tripple Pulse Disabled.');
      return 1;
   }
}

addCMDToHelp("TerroristME", "Usage: /TerroristME: Toggles exploding armor.");
function ccTerroristME(%sender,%args) {
   if(!$Buying::boomArmor[%sender.GUID]) {
      messageclient(%sender, 'MsgClient', '\c5You dont own the Exploding Armor Ability.');
      return 1;
   }
   if(!%sender.BoomArmorOn) {
      %sender.BoomArmorOn = 1;
      messageclient(%sender, 'MsgClient', '\c5Exploding Armor Enabled.');
      return 1;
   }
   else {
      %sender.BoomArmorOn = 0;
      messageclient(%sender, 'MsgClient', '\c5Exploding Armor Disabled.');
      return 1;
   }
}

addCMDToHelp("PSG", "Usage: /PSG: Toggles the pulse shotgun on the pulse phaser.");
function ccPSG(%sender,%args) {
   if(!$Buying::PulsSGun[%sender.GUID]) {
      messageclient(%sender, 'MsgClient', '\c5You dont own the Pulse Shotgun Ability.');
      return 1;
   }
   if(!%sender.PSGon && !%sender.TPUon) {
      %sender.PSGon = 1;
      messageclient(%sender, 'MsgClient', '\c5Pulse Shotgun Enabled.');
      return 1;
   }
   else if(%sender.TPUon && !%sender.PSGon) {
      %sender.TPUon = 0;
      %sender.PSGon = 1;
      messageclient(%sender, 'MsgClient', '\c5Pulse Shotgun Enabled, Tripple Pulse Disabled.');
      return 1;
   }
   else {
      %sender.PSGon = 0;
      messageclient(%sender, 'MsgClient', '\c5Pulse Shotgun Disabled.');
      return 1;
   }
}

addCMDToHelp("upgrade", "Usage: /upgrade [Upgrade Tag]: buys an upgrade.");
function ccupgrade(%sender,%args) {
   %sp = $Rank::SP[%sender.GUID];
   %bleh = getword(%args,0);
   if(%bleh $= "Lsr") {
      if($Buying::LsrPnt[%sender.GUID]) {
         messageclient(%sender, 'MsgClient', '\c5You Already Own this, TO toggle type /LTGL.');
         return 1;
      }
      if(%sp >= 500) {
      WriteBuyingFile(%sender,%sender.GUID,"LsrPnt",true);
      %sender.SP = %sender.SP - 500;
      messageclient(%sender, 'MsgClient', '\c5Bought Laser Sight, type /LTGL to activate.');
      return 1;
      }
      else {
      messageclient(%sender, 'MsgClient', '\c5Incefficient Points, You Need 500.');
      return 1;
      }
   }
   else if(%bleh $= "Art2") {
      if($Buying::Art2[%sender.GUID]) {
      messageclient(%sender, 'MsgClient', '\c5You Already Own this.');
      return 1;
      }
      if(%sp >= 1000) {
      WriteBuyingFile(%sender,%sender.GUID,"Art2",true);
      %sender.SP = %sender.SP - 1000;
      messageclient(%sender, 'MsgClient', '\c5Bought Artillery Level 2, Call in Sixteen!');
      return 1;
      }
      else {
      messageclient(%sender, 'MsgClient', '\c5Incefficient Points, You Need 1K.');
      return 1;
      }
   }
   else if(%bleh $= "Art3") {
      if($Buying::Art3[%sender.GUID]) {
      messageclient(%sender, 'MsgClient', '\c5You Already Own this.');
      return 1;
      }
      if(!$Buying::Art2[%sender.GUID]) {
      messageclient(%sender, 'MsgClient', '\c5You must own Artillery 2 Before you can get Artillery 3.');
      return 1;
      }
      if(%sp >= 2000) {
      WriteBuyingFile(%sender,%sender.GUID,"Art3",true);
      %sender.SP = %sender.SP - 2000;
      messageclient(%sender, 'MsgClient', '\c5Bought Artillery Level 3, Call in Twenty-Four!');
      return 1;
      }
      else {
      messageclient(%sender, 'MsgClient', '\c5Incefficient Points, You Need 2K.');
      return 1;
      }
   }
   else if(%bleh $= "Tpuls") {
      if($Buying::TPuls[%sender.GUID]) {
      messageclient(%sender, 'MsgClient', '\c5You Already Own this, type /TPU to activate.');
      return 1;
      }
      if(%sp >= 2000) {
      WriteBuyingFile(%sender,%sender.GUID,"TPuls",true);
      %sender.SP = %sender.SP - 2000;
      messageclient(%sender, 'MsgClient', '\c5Bought Tripple Pulse Phaser Shots, /type TPU To Activate.');
      return 1;
      }
      else {
      messageclient(%sender, 'MsgClient', '\c5Incefficient Points, You Need 2K.');
      return 1;
      }
   }
   else if(%bleh $= "PulsSgun") {
      if($Buying::PulsSgun[%sender.GUID]) {
      messageclient(%sender, 'MsgClient', '\c5You Already Own this, type /PSG to activate.');
      return 1;
      }
      if(%sp >= 2000) {
      WriteBuyingFile(%sender,%sender.GUID,"PulsSGun",true);
      %sender.SP = %sender.SP - 2000;
      messageclient(%sender, 'MsgClient', '\c5Bought Pulse Shotgun, type /PSG To Activate.');
      return 1;
      }
      else {
      messageclient(%sender, 'MsgClient', '\c5Incefficient Points, You Need 2K.');
      return 1;
      }
   }
   else if(%bleh $= "Psniper") {
      if($Buying::PSnip[%sender.GUID]) {
      messageclient(%sender, 'MsgClient', '\c5You Already Own this.');
      return 1;
      }
      if(%sp >= 5000) {
      WriteBuyingFile(%sender,%sender.GUID,"PSnip",true);
      %sender.SP = %sender.SP - 5000;
      messageclient(%sender, 'MsgClient', '\c5Bought Pulse Sniper, type /Psni To Activate');
      return 1;
      }
      else {
      messageclient(%sender, 'MsgClient', '\c5Incefficient Points, You Need 5K.');
      return 1;
      }
   }
   else if(%bleh $= "VBoom") {
      if($Buying::VBoom[%sender.GUID]) {
      messageclient(%sender, 'MsgClient', '\c5You Already Own this.');
      return 1;
      }
      if(%sp >= 5000) {
      WriteBuyingFile(%sender,%sender.GUID,"VBoom",true);
      %sender.SP = %sender.SP - 5000;
      messageclient(%sender, 'MsgClient', '\c5Bought Vehicle Nightmare, Happy Hunting!');
      return 1;
      }
      else {
      messageclient(%sender, 'MsgClient', '\c5Incefficient Points, You Need 5K.');
      return 1;
      }
   }
   else if(%bleh $= "Storm") {
      if($Buying::TheStorm[%sender.GUID]) {
      messageclient(%sender, 'MsgClient', '\c5You Already Own this.');
      return 1;
      }
      if(%sp >= 10000) {
      WriteBuyingFile(%sender,%sender.GUID,"TheStorm",true);
      %sender.SP = %sender.SP - 10000;
      messageclient(%sender, 'MsgClient', '\c5Bought Photon Storm, Laze Those Bitches!');
      return 1;
      }
      else {
      messageclient(%sender, 'MsgClient', '\c5Incefficient Points, You Need 10K.');
      return 1;
      }
   }
   //Player Upgrades
   else if(%bleh $= "Ptches") {
      if($Buying::Ptches[%sender.GUID]) {
      messageclient(%sender, 'MsgClient', '\c5You Already Own this.');
      return 1;
      }
      if(%sp >= 500) {
      WriteBuyingFile(%sender,%sender.GUID,"Ptches",true);
      %sender.SP = %sender.SP - 500;
      messageclient(%sender, 'MsgClient', '\c5Bought Patch Incremental Upgrade');
      return 1;
      }
      else {
      messageclient(%sender, 'MsgClient', '\c5Incefficient Points, You Need 500.');
      return 1;
      }
   }
   else if(%bleh $= "Boomyarmor") {
      if($Buying::BoomArmor[%sender.GUID]) {
      messageclient(%sender, 'MsgClient', '\c5You Already Own this.');
      return 1;
      }
      if(%sp >= 2000) {
      WriteBuyingFile(%sender,%sender.GUID,"boomArmor",true);
      %sender.SP = %sender.SP - 2000;
      messageclient(%sender, 'MsgClient', '\c5Bought Exploding Armor Upgrade. AAALALALALALALA!!!, Activate with /TerroristME');
      return 1;
      }
      else {
      messageclient(%sender, 'MsgClient', '\c5Incefficient Points, You Need 2000.');
      return 1;
      }
   }
   else if(%bleh $= "light") {
      if($Buying::Light[%sender.GUID]) {
      messageclient(%sender, 'MsgClient', '\c5You Already Own this.');
      return 1;
      }
      if(%sp >= 2500) {
      WriteBuyingFile(%sender,%sender.GUID,"Light",true);
      %sender.SP = %sender.SP - 2500;
      messageclient(%sender, 'MsgClient', '\c5Bought Flashlight, You will now have a flashlight in your inventory.');
      return 1;
      }
      else {
      messageclient(%sender, 'MsgClient', '\c5Incefficient Points, You Need 2500.');
      return 1;
      }
   }
   else if(%bleh $= "chance") {
      if($Buying::Chance[%sender.GUID]) {
      messageclient(%sender, 'MsgClient', '\c5You Already Own this.');
      return 1;
      }
      if(%sp >= 5000) {
      WriteBuyingFile(%sender,%sender.GUID,"chance",true);
      %sender.SP = %sender.SP - 5000;
      messageclient(%sender, 'MsgClient', '\c5Bought Last Chance.. Retreating made Easier.');
      return 1;
      }
      else {
      messageclient(%sender, 'MsgClient', '\c5Incefficient Points, You Need 5000.');
      return 1;
      }
   }
   else {
   messageclient(%sender, 'MsgClient', '\c5 Unknown Upgrade, use /upgrade code.');
   return 1;
   }
}

addCMDToHelp("myphrase", "Usage: /myphrase [message]: sets your personal message.");
function ccmyphrase(%sender,%args) {
   messageclient(%sender, 'MsgClient', "\c5Personal Phrase Set To :'"@%args@"'.");
   $Rank::Phrase[%sender.GUID] = ""@%args@"";
   return 1;
}

addCMDToHelp("clientstats", "Usage: /clientstats [name or blank]: Tells you the upgrades a player has.");
function ccclientstats(%sender,%args) {
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if(%nametotest$="") {
      %sp = $Rank::SP[%sender.GUID];
      %phrs = $Rank::Phrase[%sender.GUID];
      if(%sp $="")
         %sp = 0;
      if(%phrs $="")
         %phrs = "I dont Have A Phrase.";
      messageclient(%sender, 'MsgClient', '\c5Your Stats Card.');
      messageclient(%sender, 'MsgClient', "\c5Spendable Points: "@%sp@"");
      messageclient(%sender, 'MsgClient', "\c5My Phrase: "@%phrs@"");
      return 1;
   }
   else if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   else {
      %sp = $Rank::SP[%target.GUID];
      %phrs = $Rank::Phrase[%target.GUID];
      if(%sp $="")
         %sp = 0;
      if(%phrs $="")
         %phrs = "I dont Have A Phrase.";
      messageclient(%sender, 'MsgClient', "\c5"@%target.namebase@"'s Stats Card.");
      messageclient(%sender, 'MsgClient', "\c5Spendable Points: "@%sp@"");
      messageclient(%sender, 'MsgClient', "\c5"@%target.namebase@"'s Phrase: "@%phrs@"");
   return 1;
   }
}

addCMDToHelp("EventInfo", "Usage: /EventInfo: Sends you the Center Print Message about the current Server Event.");
function ccEventInfo(%sender, %args) {
   ShowCurrentEventToCL(%sender);
   return 1;
}

addCMDToHelp("MoveAll", "Usage: /MoveAll [X] [Y] [Z]: Moves All You Your Pieces");
function ccMoveAll(%sender, %args) {
   if(%sender.cantMoveAll) {
      messageclient(%sender, 'MsgClient', "\c5You have only recently moved all deployables.");
      return 1;
   }
   %x = getWord(%args, 0);
   %y = getWord(%args, 1);
   %z = getWord(%args, 2);
   if(%x $= "") {
      messageclient(%sender, 'MsgClient', "\c5Missing 'X' Variable.");
      return 1;
   }
   if(%y $= "") {
      messageclient(%sender, 'MsgClient', "\c5Missing 'Y' Variable.");
      return 1;
   }
   if(%z $= "") {
      messageclient(%sender, 'MsgClient', "\c5Missing 'Z' Variable.");
      return 1;
   }
   %move = ""@%x@" "@%y@" "@%z@"";
   %group = nameToID("MissionCleanup/Deployables");
   %count = %group.getCount();
   for (%i = 0; %i < %count; %i++) {
      %obj =  %group.getObject(%i);
      if (%obj.getOwner() == %sender) {
         %newPos = vectorAdd(%obj.getPosition(), %move);
         %obj.setPosition(%newPos);
   	     adjustTrigger(%obj);
      }
   }
   schedule(30000,0,"ResetMoveAll", %sender);
   %sender.cantMoveAll = 1;
   messageclient(%sender, 'MsgClient', "\c5Moving your pieces "@%move@".");
   return 1;
}
