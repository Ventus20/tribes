addCMDToHelp("ZCmds", "Usage: /ZCmds: Lists zombie commands.");
function ccZCmds(%sender, %args) {
   messageclient(%sender, 'MsgClient', '\c5TWM2 Zombie Chat Commands');
   messageclient(%sender, 'MsgClient', '\c3/BuyZPack, /SpawnZ, /KillZombies, /cure');
   messageclient(%sender, 'MsgClient', '\c3/MakeZ');
   return 1;
}

addCMDToHelp("BuyZPack", "Usage: /BuyZPack: gives you a zombie spawner.");
function ccBuyZPack(%sender,%args){
   if (!%sender.isadmin){
      if(!%sender.isZombieCommander) {
         messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 1 Needed.');
         return 1;
      }
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
   else if(%type $= "DLord") {
      %var = 6;
      %adminRequired = 2;
   }
   else if(%type $= "Shift") {
      %var = 9;
      %adminRequired = 1;
   }
   else if(%type $= "Summon") {
      %var = 10;
      %adminRequired = 2;
   }
   else if(%type $= "Sniper") {
      %var = 11;
      %adminRequired = 1;
   }
   else if(%type $= "ULord") {
      %var = 12;
      %adminRequired = 1;
   }
   else if(%type $= "VRav") {
      %var = 13;
      %adminRequired = 1;
   }
   else if(%type $= "SS") {
      %var = 14;
      %adminRequired = 1;
   }
   else if(%type $= "Wraith") {
      %var = 15;
      %adminRequired = 2;
   }
   else {
      messageclient(%sender, 'MsgClient', '\c2Unknown Type, These Are Accepted:');
      messageclient(%sender, 'MsgClient', '\c2Norm, Rav, Lord, Dem, Rap, DLord');
      messageclient(%sender, 'MsgClient', '\c2Shift, Summon, Snipe, ULord, VRav, SS, Wraith');
      return 1; //stop here
   }
   //
   if(%amount > 10 && %var == 10) {
      messageclient(%sender, 'MsgClient', '\c5Summoners = More Zombies, thats too many pal.');
      return 1;
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
   //*****
   // Assign The Position
   //*****
   //*****
   %pos1 = %sender.player.getposition();
   %pos2 = "0 0 20";
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
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 spawned a group of \c3"@%amount@"\c2 Demon Lord Zombies!!!");
         for(%i=0;%i<%amount;%i++) {
            %time = %i * 500;
            schedule(%time,0,DemonMotherCreate,%Fpos);
         }
         return 1;
      case 9:
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 spawned a group of \c3"@%amount@"\c2 Shifter Zombies!!!");
         for(%i=0;%i<%amount;%i++) {
            %time = %i * 500;
            schedule(%time,0,StartAZombie,%Fpos,9);
         }
         return 1;
      case 10:
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 spawned a group of \c3"@%amount@"\c2 Summoner Zombies!!!");
         for(%i=0;%i<%amount;%i++) {
            %time = %i * 500;
            schedule(%time,0,StartAZombie,%Fpos,10);
         }
         return 1;
      case 11:
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 spawned a group of \c3"@%amount@"\c2 Sniper Zombies!!!");
         for(%i=0;%i<%amount;%i++) {
            %time = %i * 500;
            schedule(%time,0,StartAZombie,%Fpos,11);
         }
         return 1;
      case 12:
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 spawned a group of \c3"@%amount@"\c2 Ultra Demon Zombies!!!");
         for(%i=0;%i<%amount;%i++) {
            %time = %i * 500;
            schedule(%time,0,StartAZombie,%Fpos,12);
         }
         return 1;
      case 13:
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 spawned a swarm of \c3"@%amount@"\c2 Volatile Ravenger Zombies!!!");
         for(%i=0;%i<%amount;%i++) {
            %time = %i * 500;
            schedule(%time,0,StartAZombie,%Fpos,13);
         }
         return 1;
      case 14:
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 spawned a swarm of \c3"@%amount@"\c2 Slingshot Zombies, pilots beware!");
         for(%i=0;%i<%amount;%i++) {
            %time = %i * 500;
            schedule(%time,0,StartAZombie,%Fpos,14);
         }
         return 1;
      case 15:
         messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 spawned a swarm of \c3"@%amount@"\c2 Wraith Spec-Ops Zombies!");
         for(%i=0;%i<%amount;%i++) {
            %time = %i * 500;
            schedule(%time,0,StartAZombie,%Fpos,15);
         }
         return 1;
   }
}

addCMDToHelp("KillZombies", "Usage: /KillZombies: kills all zombies.");
function ccKillZombies(%sender, %args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
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
            %obj.scriptkill($DamageType::admin);
         }
         else {
            continue;
         }
      }
   }
   messageAll('MsgAdminForce', "\c3"@%sender.namebase@"\c2 Eliminated All Zombies and Cured All Infections.");
   return 1;
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
   //
   if(!isSet(trim(%args))) {
      %target = %sender;
   }
   //
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

addCMDToHelp("makeZ", "Usage: /makeZ [target] [Type]: makes player zombies.");
function ccmakeZ(%sender, %args) {
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
   // Zombie Selection
   %adminRequired = 1; //1- Admin, 2- SA, 3- Dev/host
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
   else if(%type $= "DLord") {
      %var = 6;
      %adminRequired = 2;
   }
   else if(%type $= "Yvex") {
      %var = 7;
      %adminRequired = 3;
   }
   else if(%type $= "Rog") {
      %var = 8;
      %adminRequired = 3;
   }
   else if(%type $= "Shift") {
      %var = 9;
      %adminRequired = 1;
   }
   else if(%type $= "Summon") {
      %var = 10;
      %adminRequired = 2;
   }
   else if(%type $= "Snipe") {
      %var = 11;
      %adminRequired = 2;
   }
   else if(%type $= "ULord") {
      %var = 12;
      %adminRequired = 2;
   }
   else {
      messageclient(%sender, 'MsgClient', '\c2Unknown Type, These Are Accepted:');
      messageclient(%sender, 'MsgClient', '\c2Norm, Rav, Lord, Dem, Rap, DLord, Snipe');
      messageclient(%sender, 'MsgClient', '\c2Yvex, Rog, Shift, Summon, ULord');
      return 1; //stop here
   }
   //
   //Admin Level Check
   if(%adminRequired == 3 && !%sender.isDev) {
      messageclient(%sender, 'MsgClient', "\c2Error: Admin Clearance For Level 3 Required For This Zombie Type");
      return 1;
   }
   else if(%adminRequired == 2 && !%sender.isSuperAdmin) {
      messageclient(%sender, 'MsgClient', "\c2Error: Admin Clearance For Level 2 Required For This Zombie Type");
      return 1;
   }
   //*****
   // Assign The Position
   //*****
   //*****
   %pos1 = %sender.player.getposition();
   %pos2 = "0 0 20";
   %Fpos = vectoradd(%pos1,%pos2);
   //*****
   makePersonZombie(%Fpos, %target, %var);
}
