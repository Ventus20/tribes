addCMDToHelp("raamShield", "Usage: /raamShield [Name]: Activates a shield on a target.");
function ccraamshield(%sender, %args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
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
   if(!%target.player.playerRAAMShield) {
      %target.player.playerRAAMShield = 1;
      PlayerRAAMShieldUpdate(%target.player);
      messageclient(%target, 'MsgClient', '\c2Modified Rapier Shield Activated.');
      return 1;
   }
   else {
      %target.player.playerRAAMShield = 0;
      messageclient(%target, 'MsgClient', '\c2Modified Rapier Shield Disabled.');
      return 1;
   }
}

addCMDToHelp("BuyZPack", "Usage: /BuyZPack: gives you a zombie spawner.");
function ccBuyZPack(%sender,%args){
   if (!%sender.isadmin){
      if(!%sender.isZombieCommander) {
         messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 1 Needed.');
         return 1;
      }
   }
   if($TWM::combCons) {
      messageclient(%sender, 'MsgClient', '\c5No Zombies in Combat Construction.');
      return 1;
   }
   if($TWM::PlayingInfection) {
      messageclient(%sender, 'MsgClient', '\c5AI Controlled Zombies not used in Infection.');
      return 1;
   }
   if($TWM::PlayingHorde) {
      messageclient(%sender, 'MsgClient', '\c5No Zombie Spawners in Horde.');
      return 1;
   }
   if(isObject(%sender.player)) {
      if(%sender.player.getMountedImage($Backpackslot) !$= "")
   	     %sender.getControlObject().throwPack();
	  %sender.player.setinventory(ZSpawnDeployable,1,true);
      return 1;
   }
}

addCMDToHelp("SpawnZ", "Usage: /SpawnZ [Amount] [Type]: spawns zombies.");
function ccSpawnZ(%sender, %args) {
   //Initial Checks
   if (!%sender.isadmin){
      if(!%sender.isZombieCommander) {
         messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 1 Needed.');
         return 1;
      }
   }
   if(!isobject(%sender.player) || %sender.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2You must have a player object.');
      return 1;
   }
   if($TWM::PlayingHorde) {
      messageclient(%sender, 'MsgClient', '\c5 This command is forbidden in Horde.');
      return 1;
   }
   if($TWM::PlayingInfection) {
      messageclient(%sender, 'MsgClient', '\c5AI Controlled Zombies not used in Infection.');
      return 1;
   }
   if($TWM::combCons) {
      messageclient(%sender, 'MsgClient', '\c5No Zombies in Combat Construction.');
      return 1;
   }
   //How many?
   %amount = getWord(%args, 0);
   if(%amount < 1) {
      messageclient(%sender, 'MsgClient', '\c5HAHAHA.. NEGATIVE ZOMBIES... HA... Thats funny!!');
      return 1;
   }
   if(%amount > 100) {
      messageclient(%sender, 'MsgClient', '\c5Thats too many...');
      return 1;
   }
   // Zombie Selection
   %adminRequired = 1; //1- Admin, 2- SA, 3- Dev
   %type = getWord(%args, 1);
   if(%type $= "Norm") {
      %var = 1;
      %adminRequired = 1;
   }
   else if(%type $= "Rav") {
      %var = 2;
      %adminRequired = 1;
   }
   else if(%type $= "Lord") {
      %var = 3;
      %adminRequired = 1;
   }
   else if(%type $= "Dem") {
      %var = 4;
      %adminRequired = 1;
   }
   else if(%type $= "Rap") {
      %var = 5;
      %adminRequired = 1;
   }
   else if(%type $= "Snipe") {
      %var = 6;
      %adminRequired = 1;
   }
   else if(%type $= "Slash") {
      %var = 7;
      %adminRequired = 1;
   }
   else if(%type $= "RAAM") {
      %var = 8;
      %adminRequired = 2;
   }
   else if(%type $= "Darkrai") {
      %var = 9;
      %adminRequired = 2;
   }
   else if(%type $= "LordRAAM") {
      %var = 10;
      %adminRequired = 2;
   }
   else {
      messageclient(%sender, 'MsgClient', '\c2Unknown Type, These Are Accepted:');
      messageclient(%sender, 'MsgClient', '\c2Norm, Rav, Lord, Dem, Rap, Snipe, Slash, RAAM, Darkrai, LordRAAM');
      return 1; //stop here
   }
   //Admin Level Check
   if(%adminRequired == 3 && !%sender.isDev) {
      messageclient(%sender, 'MsgClient', "\c2Error: Admin Clearance For Level 3 Required For This Zombie Type");
      return 1;
   }
   else if(%adminRequired == 2 && !%sender.isSuperAdmin) {
      messageclient(%sender, 'MsgClient', "\c2Error: Admin Clearance For Level 2 Required For This Zombie Type");
      return 1;
   }
   // No need for 1, the command checks the above
   // Everything Checks Out, spawn the Zombie
   //************
   //the bosses - special checks
   if(%var >= 8) {
      if($TWM::BossBattle) {
         messageclient(%sender, 'MsgClient', '\c5A Boss Battle Is Already Occuring.');
         return 1;
      }
   }
   //*****
   // Assign The Position
   //*****
   //*****
   %pos1 = %sender.player.getposition();
   %pos2 = "0 0 "@(20 + (%var * 2))@"";
   %Fpos = vectoradd(%pos1,%pos2);
   //*****
   switch(%var) {
      case 1:
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 spawned a swarm of \c3"@%amount@"\c2 Zombies!!!");
         for(%i=0;%i<%amount;%i++) {
            %time = %i * 500;
            schedule(%time,0,StartAZombie,%Fpos,1);
         }
         return 1;
      case 2:
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 spawned a swarm of \c3"@%amount@"\c2 Ravenger Zombies!!!");
         for(%i=0;%i<%amount;%i++) {
            %time = %i * 500;
            schedule(%time,0,StartAZombie,%Fpos,2);
         }
         return 1;
      case 3:
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 started a \c3"@%amount@"\c2 LORD FRENZY!!!");
         for(%i=0;%i<%amount;%i++) {
            %time = %i * 1000;
            schedule(%time,0,StartAZombie,%Fpos,3);
         }
         return 1;
      case 4:
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 spawned a swarm of \c3"@%amount@"\c2 Demon Zombies!!!");
         for(%i=0;%i<%amount;%i++) {
            %time = %i * 500;
            schedule(%time,0,StartAZombie,%Fpos,4);
         }
         return 1;
      case 5:
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 spawned a swarm of \c3"@%amount@"\c2 Air-Rapier Zombies!!!");
         for(%i=0;%i<%amount;%i++) {
            %time = %i * 500;
            schedule(%time,0,StartAZombie,%Fpos,5);
         }
         return 1;
      case 6:
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 spawned a swarm of \c3"@%amount@"\c2 Sniper Zombies!!!");
         for(%i=0;%i<%amount;%i++) {
            %time = %i * 500;
            schedule(%time,0,StartAZombie,%Fpos,6);
         }
         return 1;
      case 7:
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 unleashed \c3"@%amount@"\c2 Slasher Zombies!!!");
         for(%i=0;%i<%amount;%i++) {
            %time = %i * 500;
            schedule(%time,0,StartAZombie,%Fpos,8);
         }
         return 1;
      case 8:
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 Summoned \c3General RAAM\c2 to the battlefield!!!");
         StartAZombie(%Fpos,9);
         return;
      case 9:
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 Summoned \c3Lord Darkrai\c2 to the Battlefield!");
         StartAZombie(%Fpos,10);
         return 1;
      case 10:
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 Summoned \c3Lord RAAM\c2 to the Battlefield!");
         StartAZombie(%Fpos,12);
         return 1;
   }
}

addCMDToHelp("MakeZ", "Usage: /MakeZ [Target] [Type]: makes a player a zombie.");
function ccMakeZ(%sender, %args) {
   if (!%sender.isadmin){
      if(!%sender.isZombieCommander) {
         messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 1 Needed.');
         return 1;
      }
   }
   // The Target Client Part
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
      messageclient(%sender, 'MsgClient', '\c2You cant infect pilots.');
      return 1;
   }
   if($TWM::combCons) {
      messageclient(%sender, 'MsgClient', '\c5No Zombies in Combat Construction.');
      return 1;
   }
   if($TWM::PlayingHorde) {
      messageclient(%sender, 'MsgClient', '\c5No Zombie Commands in Horde.');
      return 1;
   }
   if($TWM::PlayingInfection) {
      messageclient(%sender, 'MsgClient', '\c5Zombie commands restricted in Infection.');
      return 1;
   }
   // Zombie Selection
   %adminRequired = 1; //1- Admin, 2- SA, 3- Dev
   %type = getWord(%args, 1);
   if(%type $= "Norm") {
      %var = 1;
      %adminRequired = 1;
   }
   else if(%type $= "Rav") {
      %var = 2;
      %adminRequired = 1;
   }
   else if(%type $= "Lord") {
      %var = 3;
      %adminRequired = 1;
   }
   else if(%type $= "Dem") {
      %var = 4;
      %adminRequired = 1;
   }
   else if(%type $= "Rap") {
      %var = 5;
      %adminRequired = 1;
   }
   else if(%type $= "RAAM") {
      %var = 6;
      %adminRequired = 3;
   }
   else if(%type $= "Darkrai") {
      %var = 7;
      %adminRequired = 3;
   }
   else {
      messageclient(%sender, 'MsgClient', '\c2Unknown Type, These Are Accepted:');
      messageclient(%sender, 'MsgClient', '\c2Norm, Rav, Lord, Dem, Rap, RAAM, Darkrai');
      return 1; //stop here
   }
   //Admin Level Check
   if(%adminRequired == 3 && !%sender.isDev) {
      messageclient(%sender, 'MsgClient', "\c2Error: Admin Clearance For Level 3 Required For This Zombie Type");
      return 1;
   }
   else if(%adminRequired == 2 && !%sender.isSuperAdmin) {
      if(!%sender.isZombieCommander) {
         messageclient(%sender, 'MsgClient', "\c2Error: Admin Clearance For Level 2 Required For This Zombie Type");
         return 1;
      }
   }
   // No need for 1, the command checks the above
   // Everything Checks Out, Make the Zombie
   switch(%var) {
      case 1:
         %targetlastpos = %target.player.getworldboxcenter();
         makePersonZombie(%targetlastpos, %target);
         messageClient(%sender, 'MsgClient', "\c2you have made "@%target.namebase@" A Zombie.");
         messageClient(%target, 'MsgClient', "\c2you have been made a Zombie by "@%sender.namebase@".");
         return 1;
      case 2:
         %targetlastpos = %target.player.getworldboxcenter();
         makePersonRavengerZombie(%targetlastpos, %target);
         messageClient(%sender, 'MsgClient', "\c2you have made "@%target.namebase@" A Ravenger Zombie.");
         messageClient(%target, 'MsgClient', "\c2you have been made a Ravenger Zombie by "@%sender.namebase@".");
         return 1;
      case 3:
         %targetlastpos = %target.player.getworldboxcenter();
         makePersonZombieLord(%targetlastpos, %target);
         messageClient(%sender, 'MsgClient', "\c2you have made "@%target.namebase@" A Zombie Lord.");
         messageClient(%target, 'MsgClient', "\c2you have been made a Zombie Lord by "@%sender.namebase@".");
         messageclient(%target, 'MsgClient', "\c2Press 'Jet' to Fire the Gliver, and 'Mine' to lift targets.");
         return 1;
      case 4:
         %targetlastpos = %target.player.getworldboxcenter();
         makePersonDemonZombie(%targetlastpos, %target);
         messageClient(%sender, 'MsgClient', "\c2you have made "@%target.namebase@" A Demon Zombie.");
         messageClient(%target, 'MsgClient', "\c2you have been made a Demon Zombie by "@%sender.namebase@".");
         messageclient(%target, 'MsgClient', "\c2Press 'Jet' to Fire the fire bomb launcher.");
         return 1;
      case 5:
         %targetlastpos = %target.player.getworldboxcenter();
         makepersonAirRapier(%targetlastpos, %target);
         messageClient(%sender, 'MsgClient', "\c2you have made "@%target.namebase@" An air rapier.");
         messageClient(%target, 'MsgClient', "\c2you have been made an air rapier by "@%sender.namebase@".");
         return 1;
      case 6:
         %targetlastpos = %target.player.getworldboxcenter();
         makePersonRAAM(%targetlastpos, %target);
         messageClient(%sender, 'MsgClient', "\c2you have made "@%target.namebase@" General RAAM.");
         messageClient(%target, 'MsgClient', "\c2you have been made General RAAM by "@%sender.namebase@".");
         messageclient(%target, 'MsgClient', "\c2Press 'Jet' to Fire the Modified PCT, Coliding with humans will cause you to slash them with your sword.");
         messageclient(%target, 'MsgClient', "\c2Press 'Mine' to call in for reinforcements.");
         return 1;
      case 7:
         %targetlastpos = %target.player.getworldboxcenter();
         makePersonDarkrai(%targetlastpos, %target);
         messageClient(%sender, 'MsgClient', "\c2you have made "@%target.namebase@" Lord Darkrai.");
         messageClient(%target, 'MsgClient', "\c2you have been made Lord Darkrai by "@%sender.namebase@".");
         messageclient(%target, 'MsgClient', "\c2Press 'grenade' to Fire a burst of nightmare energy.");
         messageclient(%target, 'MsgClient', "\c2Colliding with humans will put them into a nightmare.");
         messageclient(%target, 'MsgClient', "\c2Press 'jet' to attempt to inflict a random nightmare.");
         messageclient(%target, 'MsgClient', "\c2Like RAAM, Darkrai can summon zombies via the 'mine' key.");
         return 1;
   }
}

addCMDToHelp("stalkcl", "Usage: /StalkCL [Target] [Type #] [Amount]: spawns zombies of a specific type around a player.");
function ccstalkcl(%sender, %args) {
   if (!%sender.isadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 1 Needed.');
      return 1;
   }
   if($TWM::PlayingHorde) {
      messageclient(%sender, 'MsgClient', '\c5 This command is forbidden in Horde.');
      return 1;
   }
   if($TWM::combCons) {
      messageclient(%sender, 'MsgClient', '\c5No Zombies in Combat Construction.');
      return 1;
   }
   if($TWM::PlayingInfection) {
      messageclient(%sender, 'MsgClient', '\c5AI Controlled Zombies not used in Infection.');
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
   %type = getword(%args,1);
   if(%type < 1 || %type > 6) {
      messageclient(%sender, 'MsgClient', '\c2Invalid Type Number. 1-reg, 2-rav, 3-lord, 4-dem, 5-rap, 6-sni');
      return 1;
   }
   %am = getword(%args,2);
   if(%am < 1 || %am > 200) {
      messageclient(%sender, 'MsgClient', '\c2Invalid Amount. Min - 1, Max - 200');
      return 1;
   }
   messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2spawned \c3"@%am@"\c2 zombies in \c3"@%target.namebase@"'s\c2 area");
   spawnaroundclient(%target,%type,%am);
   return 1;
}

addCMDToHelp("ZombieCMDS", "Usage: /ZombieCMDS: Lists Zombie Commands.");
function ccZombieCMDS(%sender,%args) {
   if (!%sender.isadmin){
      if(!%sender.isZombieCommander) {
         messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 1 Needed.');
         return 1;
      }
   }
   if(%sender.isZombieCommander) {
   messageclient(%sender, 'MsgClient', '\c5 Zombie Commander Chat Commands.');
   messageclient(%sender, 'MsgClient', '\c5 /spawnz, /makez, /buyzpack');
   return 1;
   }
   else {
   messageclient(%sender, 'MsgClient', '\c5 Admin/SA Zombie Chat Commands.');
   messageclient(%sender, 'MsgClient', '\c5 /makez, /cure, /infect, /buyzpack');
   messageclient(%sender, 'MsgClient', '\c5 /snipercl, /spawnz, /raamshield');
   messageclient(%sender, 'MsgClient', '\c5 /stalkcl');
   return 1;
   }
}

addCMDToHelp("snipercl", "Usage: /snipercl [Target]: sends an assassin sniper zombie after a player.");
function ccsnipercl(%sender, %args) {
   if(!isobject(%sender.player) || %sender.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2You must have a player object.');
      return 1;
   }
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   if($TWM::PlayingHorde) {
      messageclient(%sender, 'MsgClient', '\c5 This command is forbidden in Horde.');
      return 1;
   }
   if($TWM::PlayingInfection) {
      messageclient(%sender, 'MsgClient', '\c5AI Controlled Zombies not used in Infection.');
      return 1;
   }
   if($TWM::combCons) {
      messageclient(%sender, 'MsgClient', '\c5No Zombies in Combat Construction.');
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
   messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 sent an assassin sniper zombie after \c3"@%target.namebase@"\c2.");
   %pos = vectoradd(%sender.player.getPosition(), "0 0 100");
   %zombie = new player(){
      Datablock = "DemonZombieArmor";
   };
   %zname ="Assasin Sniper Zombie";
   %zombie.isspecific = 1;
   %zombie.mountImage(ZSniperImage, 3);
   %zombie.Typeinfo = 6;
   %zombie.type = 6;
   %Zombie.setTransform(%pos);
   %Zombie.team = 0;
   %zombie.hastarget = 1;
   MissionCleanup.add(%Zombie);
   %zombie.iszombie =1;
   %zombie.target = createTarget(%zombie, %zname, "", "Derm3", '', %zombie.team, PlayerSensor);
   setTargetSensorData(%zombie.target, PlayerSensor);
   setTargetSensorGroup(%zombie.target, 0);
   setTargetName(%zombie.target, addtaggedstring(%zname));
   setTargetSkin(%zombie.target, 'Horde');
   SniperZombiemovetospectarget(%zombie,%target);
   return 1;
}

addCMDToHelp("ZombIgnore", "Usage: /ZombIgnore [Target]: make zombies ignore specific players.");
function ccZombIgnore(%sender, %args) {
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
   if(%target.ignoredbyZombs) {
      %target.ignoredbyZombs = 0;
      messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 Re-Added \c3"@%target.namebase@"\c2 to the zombie targeting array.");
      return 1;
   }
   else {
      %target.ignoredbyZombs = 1;
      messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 Removed \c3"@%target.namebase@"\c2 from the zombie targeting array.");
      return 1;
   }
}

addCMDToHelp("ZombieToggle", "Usage: /ZombieToggle: toggles zombie spawning.");
function cczombietoggle(%sender, %args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   if($TWM::PlayingHorde) {
      messageclient(%sender, 'MsgClient', '\c5 This command is forbidden in Horde.');
      return 1;
   }
   if($TWM::PlayingInfection) {
      messageclient(%sender, 'MsgClient', '\c5AI Controlled Zombies not used in Infection.');
      return 1;
   }
   if($TWM::combCons) {
      messageclient(%sender, 'MsgClient', '\c5No Zombies in Combat Construction, So this command is not needed.');
      return 1;
   }
   if(!$Host::nozombs) {
      $Host::nozombs = 1;
      messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 disabled zombie spawning.");
      return 1;
   }
   else {
      $Host::nozombs = 0;
      messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 enabled zombie spawning.");
      return 1;
   }
}

addCMDToHelp("ViewZKill", "Usage: /ViewZKill: shows XP gained per Zombie Kill.");
function ccViewZKill(%sender,%args) {
   if(%sender.viewZDM) {
      messageclient(%sender, 'MsgClient',"\c5Zombie Kill Info Viewer Disabled");
      %sender.viewZDM = 0;
      return 1;
   }
   else {
      messageclient(%sender, 'MsgClient',"\c5Zombie Kill Info Viewer Enabled");
      %sender.viewZDM = 1;
      return 1;
   }
}

addCMDToHelp("Cure", "Usage: /Cure [Target]: cures the zombie infection in a player.");
function ccCure(%sender,%args) {
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
   if(%target.player.iszombie) {
      %targetlastpos = %target.player.getworldboxcenter();
      makePersonHumanFZomb(%targetlastpos, %target);
   }
   CureInfection(%target.player);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Cured \c3"@%target.namebase@"'s\c2 Infection.");
   messageclient(%target, 'MsgClient', "\c5Your Infection Has Been Cured");
   return 1;
}

addCMDToHelp("Infect", "Usage: /Infect [Target]: infects a player with the zombie virus.");
function ccInfect(%sender,%args) {
   if (!%sender.isadmin){
      messageclient(%sender, 'MsgClient', '\c5Admin Clearance For Level 1 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(%target.player.isPilot() == true) {
      messageclient(%sender, 'MsgClient', '\c2You cant infect pilots.');
      return 1;
   }
   if(!isobject(%target.player) || %target.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2The Target Player must have a player object.');
      return 1;
   }
   if($TWM::combCons) {
      messageclient(%sender, 'MsgClient', '\c5No Zombies in Combat Construction.');
      return 1;
   }
   messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 gave \c3"@%target.namebase@"\c2 a zombie infection pill!.");
   %target.player.Infected = 1;
   InfectLoop(%target.player);
   return 1;
}

addCMDToHelp("KillZombies", "Usage: /KillZombies: kills all zombies.");
function ccKillZombies(%sender, %args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   if($TWM::PlayingHorde) {
      messageclient(%sender, 'MsgClient', '\c5 This command is forbidden in Horde.');
      return 1;
   }
   if($TWM::combCons) {
      messageclient(%sender, 'MsgClient', '\c5No Zombies To eliminate, this is Combat Construction.');
      return 1;
   }
   if($TWM::PlayingInfection) {
      messageclient(%sender, 'MsgClient', '\c5AI Controlled Zombies not used in Infection.');
      return 1;
   }
   %count = MissionCleanup.getCount();
   for(%i = 0; %i < %count; %i++) {
      %obj = MissionCleanup.getObject(%i);
      if(isObject(%obj)) {
         if(%obj.infected) {
            %obj.infected = 0;
            messageclient(%obj.client, 'MsgClient', '\c2You have Been Cured.');
            if(isEventPending(%obj.infectedDamage)) {
               cancel(%obj.infectedDamage);
               %obj.infectedDamage = "";
               %obj.beats = 0;
               %obj.canZkill = 0;
               %obj.setcancelimpulse = 1;
               schedule(1000,0, "resetattackImpulse" ,%obj); //goodie
            }
         }
         if(%obj.iszombie) {
            %obj.scriptkill($DamageType::admin);  //They all went on crack and died XD
         }
         else {
            continue;
         }
      }
   }
   messageAll('MsgAdminForce', "\c3"@%sender.namebase@"\c2 Eliminated All Zombies and Cured All Infections.");
   return 1;
}
