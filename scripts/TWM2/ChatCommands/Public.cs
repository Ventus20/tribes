function ccHelp(%sender, %admin) {
   messageclient(%sender, 'MsgClient', "\c5TWM2 Chat Commands.");
   messageclient(%sender, 'MsgClient', "\c3/cmdHelp, /nameSlot, /me, /me1, /me2, /me3");
   messageclient(%sender, 'MsgClient', "\c3/me4, /me5, /r, /giveCard, /TakeCard, /bf, /invDep");
   messageclient(%sender, 'MsgClient', "\c3/getScale, /getObj, /pm, /OpenDoor, /setPass");
   messageclient(%sender, 'MsgClient', "\c3/setSpawn, /clearSpawn, /delMyPieces, /name");
   messageclient(%sender, 'MsgClient', "\c3/scale, /objmove, /del, /givePieces, /power");
   messageclient(%sender, 'MsgClient', "\c3/hover, /moveAll, /Radius, /admincmds, /sacmds");
   messageclient(%sender, 'MsgClient', "\c3/objPower, /idea, /Timer, /setRot, /setNudge, /undo");
   messageclient(%sender, 'MsgClient', "\c3/getGUID, /voteBoss, /myPhrase, /whois, /depSec");
   messageclient(%sender, 'MsgClient', "\c3/usave, /uload, /saverank, /loadrank");
   return 1;
}

function ccWhois(%sender, %args) {
   if (!strlen(trim(%args)))
      messageClient(%sender, 'NoArgs', "\c2No Name/GUID?");
   else
   {
      %reqcl = plnametocid(%args);
      if (%reqcl == 0)
      {
          //search through clients and look for a matching guid
          %isguid = 1;
          %count = ClientGroup.getCount();
          for (%i = 0; %i < %count; %i++)
          {
               %c = ClientGroup.getObject(%i);
               if (%c.guid == %args)
               {
                   %reqcl = %c;
                   break;
               }
          }
          if (%reqcl == 0)
          {
             messageClient(%sender, 'NoCl', "\c2No Client was found with that name/guid.");
             return 1;
          }
      }
      %auth     = %reqcl.getAuthInfo();
      %name     = stripChars(detag(getTaggedString(%reqcl.name)), "\cp\co\c6\c7\c8\c9");
      %namebase = stripChars(detag(%reqcl.namebase),"\cp\co\c6\c7\c8\c9" );
      %realname = stripChars(detag(getField(%auth,0)), "\cp\co\c6\c7\c8\c9");
      %guid     = %reqcl.guid;
      %lastjoin = %reqcl.joinedtime;
      %ip       = strReplace(%reqcl.getAddress(), "IP:", "");
      %ip       = getSubStr(%ip, 0, strPos(%ip, ":"));
      %admin    = %reqcl.isAdmin + %reqcl.isSuperadmin;

      %isastr   = (%admin == 2 ? "is a Super Admin" : (%admin == 0 ? "isn't an Admin" : "is an Admin"));
      %smurf    = (strcmp(%name, %realname) == 0 ? 0 : 1);
      %nstr     = (%smurf == 1 ? "("@%realname@")" : "");
      if (%isguid)
         %nstr = trim(%nstr) SPC "is" SPC %guid;
      messageClient(%sender, 'WhoisReply', "\c2"@%name SPC %nstr);
      messageClient(%sender, 'WhoisReply', "\c2\t" SPC %name SPC "is"  SPC (%smurf ? "not a Smurf" : "a Smurf"));
      messageClient(%sender, 'WhoisReply', "\c2\t" SPC %name @   "'s GUID is" SPC %guid);
      messageClient(%sender, 'WhoisReply', "\c2\t" SPC %name SPC "is connecting from" SPC %ip);
      messageClient(%sender, 'WhoisReply', "\c2\t" SPC %name SPC (%reqcl.isAIControlled() ? "is" : "isn't") SPC "a bot");
      messageClient(%sender, 'WhoisReply', "\c2\t" SPC %name SPC (%reqcl.isPGDConnected() ? "is" : "isn't") SPC "PGD Connected");
      messageClient(%sender, 'WhoisReply', "\c2\t" SPC %name SPC "last connected on" SPC %lastjoin);
      messageClient(%sender, 'WhoisReply', "\c2\t" SPC %name SPC %isastr);

   }
   return 1;
}

addCMDToHelp("MyPhrase", "Usage: /MyPhrase [phrase]: sets your personal phrase for your rank card.");
function ccMyPhrase(%sender, %args) {
   %clientController = %sender.TWM2Core;
   %clientController.phrase = %args;
   messageClient(%sender, 'msgClient', "\c5TWM2: You have set your phrase to: "@$Rank::Phrase[%sender.GUID]@"");
   updateClientRank(%sender);
   UpdateRankFile(%sender);
   //
   //PushPhraseToPGDConnect(%sender);
   return 1;
}

addCMDToHelp("VoteBoss", "Usage: /VoteBoss [name]: votes to start a boss.");
function ccVoteBoss(%sender, %args) {
   if(!$TWM2::AllowBossVotes) {
       messageclient(%sender, 'MsgClient', '\c2The server host has disabled boss votes.');
       return 1;
   }
   if($TWM2::BossAllowTimer != 0) {
       %min = getField(FormatTWM2Time($TWM2::BossAllowTimer), 0);
       %sec = getField(FormatTWM2Time($TWM2::BossAllowTimer), 1);
       messageclient(%sender, 'MsgClient', "\c2Boss Votes Not allowed for another "@%min@":"@%sec@"");
       return 1;
   }
   %Boss = getWord(%args, 0);
   if (!isObject(RndCli())) {
      messageclient(%sender, 'MsgClient', '\c2No Players seem to be spawned..');
   }
   else if (!%sender.canvote) {
       messageclient(%sender, 'MsgClient', '\c2You cannot vote yet.');
       return 1;
   }
   else if($TWM2::BossGoing) {
       messageclient(%sender, 'MsgClient', '\c2A Boss Is Already Spawned.');
       return 1;
   }
   else if (!isBoss(strlwr(%Boss))) {
       messageclient(%sender, 'MsgClient', '\c2Invalid Boss Name.');
       messageclient(%sender, 'MsgClient', '\c2Bosses: Yvex, CnlWindshear, GOL, GOF, Stormrider.');
       messageclient(%sender, 'MsgClient', '\c2GenVeg, LordRog, Insignia, Trebor, Vardison.');
       return 1;
   }
   else {
      if ( Game.scheduleVote !$= "" ) {
         messageclient(%sender, 'MsgClient', '\c2A Vote is in progress..');
         return 1;
      }
      %BossFName = BossFullname(%Boss); //get the boss' full name
      for ( %idx = 0; %idx < ClientGroup.getCount(); %idx++ ) {
            %cl = ClientGroup.getObject( %idx );
            if ( !%cl.isAIControlled() ) {
	           messageClient( %cl, 'VoteStarted', '\c2%1 wants to start boss \c1%2\c2!', %sender.name, %BossFName);
               %clientsVoting++;
            }
      }
      for ( %clientIndex = 0; %clientIndex < ClientGroup.getCount(); %clientIndex++ ) {
          %cl = ClientGroup.getObject( %clientIndex );
          if ( !%cl.isAIControlled() )
             messageClient(%cl, 'openVoteHud', "", %clientsVoting, ($Host::VotePassPercent / 100));
      }
      $TWM2::BossAllowTimer = 3600; //60 sec * 60 = 60 minutes, or 1 hour
      schedule(1000, 0, "LowerBossAllowTime");
      clearVotes();
      %sender.canVote = false;
      schedule(20*1000, 0, resetVotePrivs, %sender);
      Game.voteType = "BossVote";
      Game.BVoteboss = %Boss;
      Game.scheduleVote = schedule( ($Host::VoteTime * 1000), 0, "BossVoteEval", %Boss, false);
      %sender.vote = true;
      messageAll('addYesVote', "");
      return 1;
   }
}
addCMDToHelp("getGUID", "Usage: /getGUID: gives you your GUID.");
function ccgetGUID(%sender, %args) {
   MessageClient(%sender, 'MsgClient', "\c2Your GUID is: \c3"@%sender.guid@"\c2.");
   return 1;
}

addCMDToHelp("SetNudge", "Usage: /SetNudge [Val]: sets your move tool's move snap.");
function ccSetNudge(%sender, %args) {
   if(%args $= "" || (%args < 0)) {
      %sender.MoveSetting = 0.1;
      MessageClient(%sender, 'MsgClient', "\c2Move Tool Nudge Set To Default (0.1).");
      return 1;
   }
   %sender.MoveSetting = %args;
   MessageClient(%sender, 'MsgClient', "\c2Move Tool Nudge Set To "@%args@".");
   return 1;
}

addCMDToHelp("SetRot", "Usage: /SetRot [Angle]: set your construction tool's rotation angle.");
function ccSetRot(%sender, %args) {
   if(%args $= "" || %args < 0 || %args > 360) {
      %sender.RotateAngle = 22.5;
      messageclient(%sender, 'MsgClient', "\c2Rotate Angle Reset.");
      return 1;
   }
   messageclient(%sender, 'MsgClient', "\c2Rotate Angle Set To \c3"@%args@"\c2.");
   %sender.RotateAngle = %args;
   return 1;
}

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
   messageclient(%sender, 'MsgClient', "\c5This object's ("@%obj@") scale is "@%scale@".");
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

addCMDToHelp("setpass", "Usage: /setpass [pass]: sets a password on Normal & Toggle Doors.");
function ccsetpass(%sender,%args){
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
      %obj.nametoset = %args;
      %obj.wp=%waypoint;
      return 1;
   }
   else {
      setTargetName(%Obj.target, addTaggedString(collapseEscape(%args)));
      %obj.nametoset = %args;
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
   messageclient(%sender, 'MsgClient', "\c2Rescaling "@%obj@", To "@%set@", From "@%old@".");
   %obj.SetRealSize(%fullscale);
   %obj.scale=%fullscale;
   %obj.settransform(%obj.gettransform());
   return 1;
}

addCMDToHelp("objmove", "Usage: /objmove [#] [#] [#|Grd]: moves an object.");
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
   %z = getWord(%args, 2);
   %obj.setCloaked(true);
   %obj.schedule(150, "setCloaked", false);
   %obj.setposition(%moveto);
   if(%z $= "grd") {
      %NewPos = %obj.getPosition();
      %x = getWord(%NewPos, 0);
      %y = getWord(%NewPos, 1);
      %z = GetTerrainHeight(%NewPos); //fun fun :)
      %goto = ""@%x@" "@%y@" "@%z@"";
      %obj.setposition(%goto);
   }
   adjustTrigger(%obj); //inv fix
   messageclient(%sender, 'MsgClient', "\c2object moved "@%move@".");
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

addCMDToHelp("invDep", "Usage: /invDep: Toggles Object Invincibility.");
function ccinvDep(%sender,%args) {
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
   %obj.Invincible = !%obj.Invincible;
   messageclient(%sender, 'MsgClient', "\c2object invincibility toggled to "@%obj.Invincible@".");
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
   if (%target == 0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   //
   %target.recipientOf[%sender] = 1;
   %target.canAcceptDenyPieces = 1;
   %target.pieceTransferFrom = %sender;
   messageClient(%sender, 'msgCli', "\c3Offering your pieces to "@%target.namebase@".");
   messageClient(%target, 'msgCli', "\c3"@%sender.namebase@" wants to transfer his pieces to you.");
   messageClient(%target, 'msgCli', "\c3Press INSERT to accept or DELETE to deny.");
   //
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

addCMDToHelp("ObjPower", "Usage: /ObjPower [freq]: sets the power freq of an object.");
function ccObjPower(%sender, %args){
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
   %owner      = %obj.GetOwner();
   if (!isobject(%obj)) {
      messageclient(%sender, 'MsgClient', '\c5No object in range.');
      return 1;
   }
   if(%owner != %sender) {
      messageclient(%sender, 'MsgClient', '\c5You do not own this.');
      return 1;
   }
   %freq = getWord(%args, 0);
   if(%freq < 0 || %freq > 150) {
      messageclient(%sender, 'MsgClient', '\c5Invalid Power Freq.');
      return 1;
   }
   %obj.setCloaked(true);
   %obj.schedule(300, "SetCloaked", false);
   %obj.powerFreq = %freq;
   checkPowerObject(%obj);
   messageclient(%sender, 'MsgClient', "\c5Object "@%obj@", power Freq Set To "@%freq@".");
   return 1;
}

addCMDToHelp("Idea", "Usage: /Idea [idea]: suggest something for the mod.");
function ccIdea(%sender, %args) {
   if(%sender.IdeaSubmits > 5) {
      messageclient(%sender, 'MsgClient', "\c5Do not flood the /idea command, you will be kicked/banned if you continue.");
      echo("TWM2: "@%sender@" "@%sender.namebase@", flooding /idea cmd");
      return 1;
   }
   %sender.IdeaSubmits++;
   new fileobject(IdeaSubmit);
   IdeaSubmit.openforWrite(""@$TWM::RanksDirectory@"/"@%sender.guid@"/Ideas.TWMSave");
   IdeaSubmit.WriteLine("//Idea Submit Thread For GUID "@%sender.guid@"");
   IdeaSubmit.WriteLine("IDEA: "@%args@".");
   IdeaSubmit.close();
   IdeaSubmit.delete();
   messageclient(%sender, 'MsgClient', "\c5Idea Submitted To The Host.");
   echo("IDEA SUBMITTED, GUID FOLDER "@%sender.guid@"");
   schedule(45000, 0, "ReduceIdeaSubmits", %sender);
   return 1;
}

addCMDToHelp("Timer", "Usage: /Timer [time > 1.5]: sets the switch delay on a switch.");
function ccTimer(%sender, %args){
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
   %owner      = %obj.GetOwner();
   if (!isobject(%obj)) {
      messageclient(%sender, 'MsgClient', '\c5No object in range.');
      return 1;
   }
   if(%owner != %sender) {
      messageclient(%sender, 'MsgClient', '\c5You do not own this.');
      return 1;
   }
   if(%dataBlock.getName() !$= "DeployedSwitch") {
      messageclient(%sender, 'MsgClient', '\c5Object is not a switch.');
      return 1;
   }
   %time = getWord(%args, 0);
   if(%time < 1.5) {
      messageclient(%sender, 'MsgClient', '\c5Time must be larger than 1.5 seconds.');
      return 1;
   }
   %obj.SwitchTimer = %time * 1000;
   messageclient(%sender, 'MsgClient', "\c5Switch "@%obj@", time delay Set To "@%time@" seconds.");
   return 1;
}

addCMDToHelp("DepSec", "Usage: /DepSec: secure deploy rights on your pieces.");
function ccDepSec(%sender, %args) {
   %statString = %sender.pieceSecured ? "are no longer" : "are now";
   %sender.pieceSecured = !%sender.pieceSecured;
   messageClient(%sender, 'msgClient', "\c3Deploy rights on your pieces "@%statString@" secured.");
   return 1;
}

addCMDToHelp("undo", "Usage: /undo: undo your last construction action.");
function ccundo(%sender, %args) {
   messageClient(%sender, 'msgClient', "\c3Undoing previous action.");
   %sender.undoLastConstructionAction();
   return 1;
}
