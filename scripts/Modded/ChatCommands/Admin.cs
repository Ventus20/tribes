addCMDToHelp("Freeze", "Usage: /Freeze [name]: EMP Locks a player.");
function ccFreeze(%sender,%args) {
   if (!%sender.isAdmin) {
      messageclient(%sender,'msgclient',"Admin Clearance for Level 1 Required.");
      return 1;
   }
   %name=getword(%args,0);
   %time=getword(%args,1);
   %target=plnametocid(%name);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', "Unknown player: "@%args@".");
      return 1;
   }
   if (%time $="")
      %time = 60; //60 seconds.
   messageall('Msgall', "\c3"@%sender.namebase@"\c2 froze \c3"@%target.namebase@"\c2 for \c3"@%time@"\c2 second(s).");
   messageclient(%target, 'MsgClient', "You have been frozen by "@%sender.namebase@" for "@%time@" second(s).");
   %target.player.isemped = 0;
   %ff = PlayerEmpLock(%target.player,%time*1000); //Not sure if this is correct
   %target.player.setDamageFlash(1);
   %target.player.setMoveState(false);
   %target.player.setMoveState(true);
   %target.player.schedule(%time*1000, setMoveState, false);
   %ff.schedule(%time*1000, "Delete");
   return 1;
}

addCMDToHelp("moveme", "Usage: /moveme [x] [y] [z]: moves you relative to your current position.");
function ccmoveme(%sender,%args) {
   if(!isobject(%sender.player) || %sender.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2You must have a player object.');
      return 1;
   }
   if (!%sender.isadmin) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 1 Needed.');
      return 1;
   }
   %currentpos = %sender.player.getposition();
   %movepos = %args;
   %gototarget = vectoradd(%currentpos, %movepos);
   %sender.player.settransform(%gototarget);
   messageclient(%sender,'MsgClient', "\c5Moving "@%args@".");
   return 1;
}

addCMDToHelp("moveto", "Usage: /moveto [x] [y] [z]: moves to the specified position.");
function ccmoveto(%sender,%args) {
   if(!isobject(%sender.player) || %sender.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2You must have a player object.');
      return 1;
   }
   if (!%sender.isadmin) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 1 Needed.');
      return 1;
   }
   %movepos = %args;
   %sender.player.settransform(%movepos);
   messageclient(%sender,'MsgClient', "\c2Moving to \c3"@%args@".");
   return 1;
}

addCMDToHelp("getPos", "Usage: /getPos: gets your current position.");
function ccgetpos(%sender,%args) {
   if(!isobject(%sender.player) || %sender.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2You must have a player object.');
      return 1;
   }
   if (!%sender.isadmin) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 1 Needed.');
      return 1;
   }
   %pos = %sender.player.getposition();
   %xpos = getword(%pos,0);
   %fx = mfloor(%xpos);
   %ypos = getword(%pos,1);
   %fy = mfloor(%ypos);
   %zpos = getword(%pos,2);
   %fz = mfloor(%zpos);
   messageclient(%sender,'MsgClient', "\c5Your Current Position Is: "@%pos@".");
   messageclient(%sender,'MsgClient', "\c5Rounded Coordinates: "@%fx@" "@%fy@" "@%fz@".");
   return 1;
}

addCMDToHelp("AdminCmds", "Usage: /AdminCmds: lists all commands open to admins.");
function ccAdminCMDS(%sender,%args) {
   if (!%sender.isadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 1 Needed.');
      return 1;
   }
   messageclient(%sender, 'MsgClient', '\c5 CCM Mod Admin Chat Commands.');
   messageclient(%sender, 'MsgClient', '\c5 /summon, /goto, /zombiecmds, /kill');
   messageclient(%sender, 'MsgClient', '\c5 /giveorphans, /passvote, /removePieces');
   messageclient(%sender, 'MsgClient', '\c5 /givegun, /twoteams, /myname, /forcepieces');
   messageclient(%sender, 'MsgClient', '\c5 /setname, /cancelvote, /a, /freeze');
   messageclient(%sender, 'MsgClient', '\c5 /moveme, /moveto, /getpos, /getmines');
   messageclient(%sender, 'MsgClient', '\c5 /slap, /confiscate, /getDBs, /gag');
   return 1;
}

addCMDToHelp("slap", "Usage: /slap [name]: punish a player by slapping them down to the ground for 3 seconds.");
function ccSlap(%sender, %args) {
   if(!%sender.isAdmin) {
   messageclient(%sender, 'MsgClient', '\c5Admin Clearance For Level 1 Needed.');
   return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(isObject(%target.player)) {
      %target.player.setActionThread("death11",true);
      messageall('MsgSLAP', "\c3"@getTaggedString(%sender.name)@"\c2 Slapped \c3"@getTaggedString(%target.name)@"\c2. ~wfx/misc/slapshot.wav");
      %target.player.setDamageFlash(1);
      %target.player.setMoveState(true);
      schedule(3000,0,"UnFreezeObj",%target.player);
   }
   else {
      messageclient(%sender, 'MsgClient', "\c2"@%target.namebase@" be dead :)");
   }
   return 1;
}

addCMDToHelp("Kill", "Usage: /Kill [name]: Instantly kill a player.");
function ccKill(%sender,%args) {
   if (!%sender.isadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 1 Needed.');
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
   %target.player.scriptkill($DamageType::Admin);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 killed \c3"@ %target.namebase@"\c2.");
   messageclient(%target, 'MsgClient', "\c5you were Pinged by "@ %sender.namebase@", Enjoy your pain");
   return 1;
}

addCMDToHelp("goto", "Usage: /goto [name]: teleports you to a player.");
function ccgoto(%sender,%args) {
   if(!isobject(%sender.player) || %sender.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2The Target Player must have a player object.');
      return 1;
   }
   if (!%sender.isadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 1 Needed.');
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
   %targetpos = %target.player.getposition();
   %transoffset = getrandom(-2,2) SPC getrandom(-2,2) SPC getrandom(-2,2);
   %gototarget = vectoradd(%targetpos, %transoffset);
   %sender.player.settransform(%gototarget);
   %sender.player.setvelocity("0 0 0");
   messageclient(%sender,'MsgClient', "\c3you\c2 warped to \c3"@%target.namebase @"\c2.");
   messageclient(%target,'MsgClient', "\c5"@%sender.namebase @ " has come to you.");
   return 1;
}

addCMDToHelp("summon", "Usage: /summon [name]: brings you a player.");
function ccsummon(%sender,%args) {
   if(!isobject(%sender.player) || %sender.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2You must have a player object.');
      return 1;
   }
   if (!%sender.isadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 1 Needed.');
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
   if(%target.player.isPilot() == true) {
      messageclient(%sender, 'MsgClient', '\c2You cant summon pilots.');
      return 1;
   }
   %player=getword(%args,0);
   %target=plnametocid(%player);
   %senderpos = %sender.player.getposition();
   %transoffset = getrandom(-2,2) SPC getrandom(-2,2) SPC 2;
   %gotosender = vectoradd(%senderpos, %transoffset);
   %target.player.settransform(%gotosender);
   %target.player.setvelocity("0 0 0");
   messageclient(%sender,'MsgClient', "\c3You\c2 summoned \c3"@%target.namebase@"\c2.");
   messageclient(%target,'MsgClient', "\c3The admin has summoned you.");
   return 1;
}

addCMDToHelp("removePieces", "Usage: /removePieces [name]: deletes a player's deployables.");
function ccremovePieces(%sender,%args) {
   if (!%sender.isadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 1 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if (%target.isadmin && %sender.isadmin) {
      messageclient(%sender, 'MsgClient', "\c2You cannot remove another admin's pieces.");
      return 1;
   }
   if (%target.issuperadmin && %sender.isadmin) {
      messageclient(%sender, 'MsgClient', '\c2You cant remove SA pieces.');
      return 1;
   }
   if (%target.issuperadmin && %sender.issuperadmin) {
      messageclient(%sender, 'MsgClient', '\c2You cant remove Other SA pieces.');
      return 1;
   }
   if (%target == %sender) {
      messageclient(%sender, 'MsgClient', '\c2The Command for self piece removal is /delmypieces');
      return 1;
   }
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Removed \c3"@ %target.namebase@"'s\c2 Pieces.");
   %group = nameToID("MissionCleanup/Deployables");
   %count = %group.getCount();
   for (%i=0;%i<%count;%i++) {
      %obj =  %group.getObject(%i);
      if (%obj.getOwner() == %target) {
         %random = getRandom(500,3000);
         %obj.getDataBlock().schedule(%random,"disassemble",%sender.player,%obj);
      }
   }
   return 1;
}

addCMDToHelp("ForcePieces", "Usage: /ForcePieces [target] [name]: gives a target's pieces to another.");
function ccForcePieces(%sender,%args) {
   if (!%sender.isadmin) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 1 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such target player.');
      return 1;
   }
   //
   %nametotest2=getword(%args,1);
   %target2=plnametocid(%nametotest2);
   if(%nametotest2 $= "") {
      messageclient(%sender, 'MsgClient', '\c2No target player specified.');
      return 1;
   }
   if (%target2==0) {
      messageclient(%sender, 'MsgClient', '\c2Reciving player not located.');
      return 1;
   }
   //
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 gave \c3"@%target.namebase@"'s\c2 pieces to \c3"@ %target2.namebase@"\c2.");
   %group = nameToID("MissionCleanup/Deployables");
   %count = %group.getCount();
   for (%i=0;%i<%count;%i++) {
      %obj =  %group.getObject(%i);
      if (%obj.getOwner() $= %target) {
         %obj.owner = %target2;
         %obj.ownerGuid = %target2.guid;
      }
   }
   return 1;
}
  
addCMDToHelp("giveorphans", "Usage: /giveorphans [name]: gives all orphaned deployables to a player.");
function ccgiveorphans(%sender,%args) {
   if (!%sender.isadmin) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 1 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 gave all orphanned pieces to \c3"@ %target.namebase@"\c2.");
   %group = nameToID("MissionCleanup/Deployables");
   %count = %group.getCount();
   for (%i=0;%i<%count;%i++) {
      %obj =  %group.getObject(%i);
      if (%obj.getOwner() $= "") {
         %obj.owner = %target;
         %obj.ownerGuid = %target.guid;
      }
   }
   return 1;
}

addCMDToHelp("GetDBs", "Usage: /GetDBs: Lists all Item DB's, used for /giveGun.");
function ccGetDBs(%sender,%args) {
   if (!%sender.isadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 1 Needed.');
      return 1;
   }
   %count = DatablockGroup.getCount();
   %x = 0;
   for(%i = 0; %i < %count; %i++) {
      %db = DatablockGroup.GetObject(%i);
      if(%db.getName().getClassname() $= "ItemData") {
         if(%db.getName().classname $= "Weapon") {
            %Item[%x] = %db.getName();
            %x++;
         }
      }
   }
   %a = 0;
   for(%r = %x; %r > 0; %r -= 4) {
      %msg[%a] = ""@%Item[%r]@" "@%Item[%r-1]@" "@%Item[%r-2]@" "@%Item[%r-3]@"";
      messageclient(%sender, 'MsgClient', "\c5"@%msg[%a]@"");
      %a++;
   }
   return 1;
}
      
addCMDToHelp("giveGun", "Usage: /GiveGun [name] [DB]: Gives an object to a player.");
function ccgivegun(%sender,%args) {
   if (!%sender.isadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 1 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(!isobject(%target.player) || %target.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2The target player must have a player object.');
      return 1;
   }
   %gun = getword(%args,1);
   if(%gun.getClassname() !$= "ItemData") {
      messageclient(%sender, 'MsgClient', '\c2Unknown Item, use /getDBs to get items.');
      return 1;
   }
   else {
      %Target.player.setInventory(%gun, 1, true);
      %Target.player.setInventory(%gun @ "ammo", 999, true);
      return 1;
   }
   if(!%sender.nomssages) {
      messageclient(%target, 'MsgClient', "\c2You Recieved A "@%gun@" From "@%sender.namebase@".");
      messageclient(%sender, 'MsgClient', "\c2You Gave "@%target.namebase@" a "@%gun@".");
      return 1;
   }
}

addCMDToHelp("TwoTeams", "Usage: /TwoTeams: Opens a second team, used for Team combat in Single Team Maps.");
function ccTwoTeams(%sender) {
   if (!%sender.isadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 1 Needed.');
      return 1;
   }
   if (!$TWM::twoteams) {
      $TWM::twoteams = true;
      messageall('MsgAdminForce',"\c2There are now two teams");
      game.numteams=2;
      return 1;
   }
   else {
      $TWM::twoteams = false;
      messageall('MsgAdminForce',"\c2There is now only one team");
      game.numteams = 1;
      for(%i = 0; %i < ClientGroup.getCount(); %i++) {
         %cl = ClientGroup.getObject(%i);
         game.clientChangeTeam(%cl, 1, 0);
      }
      return 1;
   }
}

addCMDToHelp("MyName", "Usage: /MyName [name]: sets your name, you can use tags in this command, 'default' will reset your name.");
function ccMyName(%sender,%args) {
   if (!%sender.isadmin) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 1 Needed.');
      return 1;
   }
   %name=getwords(%args,0);
   %oldname = %sender.namebase;
   if (%name $= "default") {
      %authInfo = %sender.getAuthInfo();
      %name = getField( %authInfo, 0 );
      %tag = getField(%authInfo, 6);
      %append = getField(%authInfo, 7 );
      if ( %append )
         %name = "\cp\c6" @ %name @ "\c7" @ %tag @ "\co";
      else
  	     %name = "\cp\c7" @ %tag @ "\c6" @ %name @ "\co";
      messageclient(%sender, 'MsgClient', "\c2Your Name Has Reset");
      MessageAll( 'MsgClientNameChanged', "", %sender.name, %name, %sender );
      removeTaggedString(%sender.name);
      %sender.name = addTaggedString(%name);
      setTargetName(%sender.target, %sender.name);
      return 1;
   }
   %oldName = getTaggedString(%sender.name);
   %sender.name = addTaggedString(collapseEscape(%name));
   setTargetName(%sender.target, %sender.name);
   messageAll('MsgClientNameChanged', "", %oldName, %sender.name, %sender);
   messageclient(%sender, 'MsgClient', "\c2Your Name Has Been Set To "@%args@"");
   return 1;
}

addCMDToHelp("SetName", "Usage: /setname [target name] [new name]: Sets the name of a player, you can use tags in this command, 'default' resets it.");
function ccSetName(%sender,%args) {
   if (!%sender.isadmin) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 1 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   %nametoset=getwords(%args,1);
   %oldname = %target.namebase;
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if (%target.isdev) {
      messageclient(%sender, 'MsgClient', '\c2No changing Dev names.');
      return 1;
   }
   if (%target.issuperadmin && %sender.isadmin) {
      messageclient(%sender, 'MsgClient', "\c2Error: Over-ranking Issue, "@%target.name@" outranks you");
      return 1;
   }
   if (%nametoset $= "default") {
      %authInfo = %target.getAuthInfo();
      %name = getField( %authInfo, 0 );
      %tag = getField(%authInfo, 6);
      %append = getField(%authInfo, 7 );
      if ( %append )
         %name = "\cp\c6" @ %name @ "\c7" @ %tag @ "\co";
      else
  	     %name = "\cp\c7" @ %tag @ "\c6" @ %name @ "\co";
      messageclient(%sender, 'MsgClient', "\c2"@%oldname@"'s Name Has Reset");
      messageclient(%target, 'MsgClient', "\c2"@%sender.namebase@" Reset your name");
      MessageAll( 'MsgClientNameChanged', "", %target.name, %name, %target );
      removeTaggedString(%target.name);
      %target.name = addTaggedString(%name);
      setTargetName(%target.target, %target.name);
      return 1;
   }
   %oldName = getTaggedString(%Target.name);
   %Target.name = addTaggedString(collapseEscape(%nametoset));
   setTargetName(%Target.target, %Target.name);
   messageAll('MsgClientNameChanged', "", %oldName, %Target.name, %Target);
   messageclient(%target, 'MsgClient', "\c2Your Name Has Been Set To "@%name@"");
   return 1;
}

addCMDToHelp("passvote", "Usage: /passvote: instantly pass a current vote.");
function ccpassvote(%sender, %args) {
   if (!%sender.isadmin) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 1 Needed.');
      return 1;
   }
   if(game.schedulevote !$= "") {
      cancel(game.ScheduleVote);
      Game.evalVote(Game.voteType, %sender.namebase, Game.voteArg1, Game.voteArg2, Game.voteArg3, Game.voteArg4);
      Game.scheduleVote = "";
      Game.kickClient = "";
      clearVotes();
      %count = clientgroup.getcount();
      for(%i = 0; %i < %count; %i++) {
         messageClient(clientgroup.getobject(%i), 'closeVoteHud', "");
      }
      messageAll('MsgAdminForce', "\c2Vote Passed by \c3"@%sender.namebase@"\c2.");
      return 1;
   }
   else {
      messageclient(%sender, 'MsgClient', '\c2No Vote To Pass.');
      return 1;
   }
}

addCMDToHelp("cancelvote", "Usage: /cancelvote: instantly fail a current vote.");
function cccancelvote(%sender, %args) {
   if (!%sender.isadmin) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 1 Needed.');
      return 1;
   }
   if(game.schedulevote !$="") {
      cancel(game.ScheduleVote);
      Game.scheduleVote = "";
      Game.kickClient = "";
      clearVotes();
      %count = clientgroup.getcount();
      for(%i = 0; %i < %count; %i++) {
         messageClient(clientgroup.getobject(%i), 'closeVoteHud', "");
      }
      messageAll('MsgAdminForce', "\c2Vote Canceled by \c3"@%sender.namebase@"\c2.");
      return 1;
   }
   else {
      messageclient(%sender, 'MsgClient', '\c2No Vote To Cancel.');
      return 1;
   }
}

addCMDToHelp("getmines", "Usage: /getmines: gives you 999 mines, have fun.");
function ccgetmines(%sender) {
   if (!%sender.isadmin) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 1 Needed.');
      return 1;
   }
   %sender.player.setinventory("Mine",999,true);
   return 1;
}

addCMDToHelp("pulse", "Usage: /pulse [type]: instantly uses a SCG aid pulse on your position.");
function ccpulse(%sender,%args){
   if (!%sender.isadmin) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 1 Needed.');
      return 1;
   }
   %pulse = getWord(%args, 0);
   if (%pulse $= "Rep") {
      Aidpulse(%sender.player.position,"",0,0);
      messageclient(%sender, 'MsgClient', "\c2Repair Pulse Location - Self.");
      return 1;
   }
   else if (%pulse $= "Cloak") {
      Aidpulse(%sender.player.position,"",1,0);
      messageclient(%sender, 'MsgClient', "\Cloak Pulse Location - Self.");
      return 1;
   }
   else if (%pulse $= "Decon"){
      Aidpulse(%sender.player.position,"",2,0);
      messageclient(%sender, 'MsgClient', "\Dis-assemble Pulse Location - Self.");
      return 1;
   }
   else if (%pulse $= "EMP") {
      Aidpulse(%sender.player.position,"",3,0);
      messageclient(%sender, 'MsgClient', "\Electro-Static Pulse Location - Self.");
      return 1;
   }
   else if (%pulse $= "Morph") {
      Aidpulse(%sender.player.position,"",4,0);
      messageclient(%sender, 'MsgClient', "\Morph Pulse Location - Self.");
      return 1;
   }
   else {
      messageclient(%sender, 'MsgClient', "\c2That Pulse Doesnt Exist.");
      messageclient(%sender, 'MsgClient', "\c2The Pulses Are : Rep, Cloak, Decon, Morph, EMP.");
      return 1;
   }
}

addCMDToHelp("A", "Usage: /A [message]: chat message to admins.");
function ccA(%sender, %args) {
   if (!%sender.isadmin) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 1 Needed.');
      return 1;
   }
   %count = ClientGroup.getCount();
   for (%i = 0; %i < %count; %i++) {
      %cl = ClientGroup.getObject( %i );
      if(%cl.isadmin) {
         messageclient(%cl, 'MsgClient', "\c5[A]"@%sender.namebase@" : \c4"@%args@"");
      }
   }
   return 1;
}

addCMDToHelp("bp", "Usage: /bp [message]: sends a bottom print to all players.");
function ccBP(%sender, %args) {
   if (!%sender.isadmin) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 1 Needed.');
      return 1;
   }
   MessageAll('MsgAdminPrint',"\c5[BP]"@%sender.namebase@": \c4"@%args@"");
   BottomPrintAll(""@%sender.namebase@" : "@%args, 5, 3);
   return 1;
}

addCMDToHelp("cp", "Usage: /cp [message]: sends a center print to all players.");
function ccCP(%sender, %args) {
   if (!%sender.isadmin) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 1 Needed.');
      return 1;
   }
   MessageAll('MsgAdminPrint',"\c5[CP]"@%sender.namebase@": \c4"@%args@"");
   CenterPrintAll(""@%sender.namebase@" : "@%args, 5, 3);
   return 1;
}

addCMDToHelp("confiscate", "Usage: /confiscate [SA Only - name]: removes your admin guns, SA - Removes your guns or the guns of other admins.");
function ccconfiscate(%sender,%args) {
   if (!%sender.isadmin) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 1 Needed.');
      return 1;
   }
   if(%sender.isAdmin && !%sender.isSuperAdmin) {
      if (%sender.isconfiscated) {
         if(%sender.Confisc["BySA"]) {
            messageclient(%sender, 'MsgClient', '\c5You cannot undo an SA confiscate');
            return 1;
         }
         else {
            messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 can now use his weapons again");
            messageclient(%sender, 'MsgClient', '\c5 You are re-allowed to your weapons');
            %sender.isconfiscated =0;
            return 1;
         }
      }
      else {
         %sender.isconfiscated =1;
         %sender.getsadminguns = 0;
         if(!isobject(%sender.player) || %sender.player.getState() $= "dead") {
            return 1;
         }
         else {
            %sender.player.use(SuperChaingun);
            %sender.player.throwweapon(1);
            %sender.player.throwweapon(0);
         }
         %Gender = (%sender.sex $= "Male" ? 'his' : 'her');
         messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Revoked "@getTaggedString(%gender)@" admin Weapons");
         messageclient(%sender, 'MsgClient', '\c5 You lost all of your admin weapons');
         return 1;
      }
   }
   else {
      %nametotest=getword(%args,0);
      %target=plnametocid(%nametotest);
      if(%nametotest $= "") {
         if (%sender.isconfiscated) {
            messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 can now use his weapons again");
            messageclient(%sender, 'MsgClient', '\c5 You are re-allowed to your weapons');
            %sender.isconfiscated =0;
            return 1;
         }
         else {
            %sender.isconfiscated =1;
            %sender.getsadminguns = 0;
            %sender.getsSAguns = 0;
            if(!isobject(%sender.player) || %sender.player.getState() $= "dead") {
               return 1;
            }
            else {
               %sender.player.use(SuperChaingun);
               %sender.player.throwweapon(1);
               %sender.player.throwweapon(0);
               %sender.player.use(BunkerBuster);
               %sender.player.throwweapon(1);
               %sender.player.throwweapon(0);
               %sender.player.use(RCMissile);
               %sender.player.throwweapon(1);
               %sender.player.throwweapon(0);
               %sender.player.use(Railgun);
               %sender.player.throwweapon(1);
               %sender.player.throwweapon(0);
            }
            %Gender = (%sender.sex $= "Male" ? 'his' : 'her');
            messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Revoked "@getTaggedString(%gender)@" admin Weapons");
            messageclient(%sender, 'MsgClient', '\c5 You lost all of your admin weapons');
            return 1;
         }
      }
      else {
         if (%target==0) {
            messageclient(%sender, 'MsgClient', '\c2No such player.');
            return 1;
         }
         if (%target.isconfiscated) {
            if(%target.isAdmin && !%target.isSuperAdmin && %target.Confisc["BySA"] == 1) {
               messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 allowed \c3"@ %target.namebase@" To get Weapons again");
               messageclient(%target, 'MsgClient', '\c5 You are re-allowed to weapons');
               %target.isconfiscated =0;
               %target.Confisc["BySA"] = 0;
               return 1;
            }
            else if(%target.isSuperAdmin){
               messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 allowed \c3"@ %target.namebase@" To get Weapons again");
               messageclient(%target, 'MsgClient', '\c5 You are re-allowed to weapons');
               %target.isconfiscated =0;
               return 1;
            }
         }
         else {
            if(%target.isAdmin && !%target.isSuperAdmin) {
               %target.isconfiscated =1;
               %target.getsSAguns = 0;
               %target.getsadminguns = 0;
               %target.Confisc["BySA"] = 1;
            }
            else if(%target.isSuperAdmin) {
               %target.isconfiscated =1;
               %target.getsSAguns = 0;
               %target.getsadminguns = 0;
            }
            if(!isobject(%target.player) || %target.player.getState() $= "dead") {
               return 1;
            }
            else {
               %target.player.use(SuperChaingun);
               %target.player.throwweapon(1);
               %target.player.throwweapon(0);
               %target.player.use(BunkerBuster);
               %target.player.throwweapon(1);
               %target.player.throwweapon(0);
               %target.player.use(PhantomCannon);
               %target.player.throwweapon(1);
               %target.player.throwweapon(0);
            }
            messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Revoked \c3"@ %target.namebase@"'s Weapons");
            messageclient(%target, 'MsgClient', '\c5 You lost all of your admin weapons');
            return 1;
         }
      }
   }
}

//Gagging
addCMDToHelp("gag", "Usage: /gag [name] [time or blank]: disables an annoying player's ability to talk.");
function ccgag(%sender, %args) {
   if (!%sender.isadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 1 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   %time = getword(%args,1);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(!%sender.isSuperAdmin && %sender.isAdmin && %target.isAdmin) {
      messageclient(%sender, 'MsgClient', '\c2You cannot gag another Admin.');
      return 1;
   }
   if(!%sender.isDev && %sender.isSuperAdmin && %target.isSuperAdmin) {
      messageclient(%sender, 'MsgClient', '\c2You cannot gag another SA.');
      return 1;
   }
   if(%time == 0 || %time $= "") {
      if(!%target.isgagged) {
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 Gagged \c3"@%target.namebase@"!");
         %target.isgagged = 1;
         return 1;
      }
      else {
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 Un-gagged \c3"@%target.namebase@"!");
         %target.isgagged = 0;
         return 1;
      }
   }
   else {
      if(!%target.isgagged) {
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 Gagged \c3"@%target.namebase@"\c2 for \c3"@%time@"\c2 seconds!");
         %target.isgagged = 1;
         schedule(%time * 1000,0,"ungag",%target);
         return 1;
      }
   }
}
