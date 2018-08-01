//Drone Chat commands
addCMDToHelp("DroneHelp", "Usage: /DroneHelp: Lists AI Vehicle Commands.");
function ccDroneHelp(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   messageclient(%sender, 'MsgClient', '\c5 TWM Drone Help Menu ');
   messageclient(%sender, 'MsgClient', '\c2 >>> Drones <<< ');
   messageclient(%sender, 'MsgClient', '\c5 /Dronebattle, /dronebattlet, /dronebattleth');
   messageclient(%sender, 'MsgClient', '\c5 /Dronebattlelow, /dronespawns, /dronetype');
   messageclient(%sender, 'MsgClient', '\c2 >>> Tanks <<< ');
   messageclient(%sender, 'MsgClient', '\c5 /tankbattle, /tankbattlet');
   return 1;
}

addCMDToHelp("DroneType", "Usage: /DroneType [Type]: Gives info on specific drone types.");
function ccDronetype(%sender,%args){
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %Type = getWord(%args, 0);
   if (%Type $= "Normal"){
      messageclient(%sender, 'MsgClient', "\c2Normal drones are basic drones, They can come in a group of any amount, and be on multiple teams.");
      return 1;
   }
   else if (%Type $= "Stlth"){
      messageclient(%sender, 'MsgClient', "\c2Stealth Drones are fast and cloaked, they are a little more challenging to beat but come in less amounts.");
      return 1;
   }
   else if (%Type $= "Strike"){
      messageclient(%sender, 'MsgClient', "\c2Strike drones will do anything to take out a target, they dont mind blowing themselves up to destroy you.");
      return 1;
   }
   else if (%Type $= "Elite"){
      messageclient(%sender, 'MsgClient', "\c2Elite drones are Deadly, they strike quick and are hard to beat, use caution when fighting these drones.");
      return 1;
   }
   else if (%Type $= "Ace"){
      messageclient(%sender, 'MsgClient', "\c2If Elite wasn't enough, Ace drones are worse, they are quick, and will always get their kill, use extreme caution.");
      return 1;
   }
   else if (%Type $= "Ultra"){
      messageclient(%sender, 'MsgClient', "\c2Ultra Drones are extremely Rare to find, but they are the deadliest of them all, they employ methods from every other type to destroy you.");
      return 1;
   }
   else{
      messageclient(%sender, 'MsgClient', "\c2That type of drone doesnt exist.");
      messageclient(%sender, 'MsgClient', "\c2These however, do : Normal, Stlth, Strike, Elite, Ace, Ultra.");
      return 1;
   }
}

addCMDToHelp("DroneBattle", "Usage: /DroneBattle [Count]: Starts a Drone Battle.");
function ccDroneBattle(%sender,%args) {
   %pos = vectoradd(%sender.player.getposition(), "0 0 1000");
   %Amount=getword(%args,0);
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   if(%Amount < 1 ||%Amount > 50) {
      messageclient(%sender, 'MsgClient', '\c5Error: Invalid Amount.');
      return 1;
   }
   DroneBattle(%pos, 500, %Amount, 1, 100, 5, 0);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Spawned "@%Amount@" ,Normal Type Fighters 1000M above himself.");
   return 1;
}

addCMDToHelp("DroneBattleLow", "Usage: /DroneBattleLow [Count]: Starts a Drone Battle, at a lower altitude.");
function ccDroneBattleLow(%sender,%args) {
   %pos = vectoradd(%sender.player.getposition(), "0 0 200");
   %Amount=getword(%args,0);
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   if(%Amount < 1 ||%Amount > 50) {
      messageclient(%sender, 'MsgClient', '\c5Error: Invalid Amount.');
      return 1;
   }
   DroneBattle(%pos, 500, %Amount, 1, 100, 5, 0);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Spawned "@%Amount@" ,Normal Type Fighters 200M above himself.");
   return 1;
}

addCMDToHelp("DroneBattleT", "Usage: /DroneBattleT [Count] [Team]: Spawn Drones on a specifc team.");
function ccDroneBattleT(%sender,%args) {
   %pos = vectoradd(%sender.player.getposition(), "0 0 500");
   %Amount=getword(%args,0);
   %teamtobe=getword(%args,1);
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   if(%Amount < 1 ||%Amount > 50) {
      messageclient(%sender, 'MsgClient', '\c5Error: Invalid Amount.');
      return 1;
   }
   if(%teamtobe < 1 || %teamtobe > 99) {
      messageclient(%sender, 'MsgClient', '\c5Error: Invalid Team.');
      return 1;
   }
   DroneBattle(%pos, 500, %Amount, %teamtobe, %teamtobe, 5, 0);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Spawned "@%Amount@" ,Normal Type Fighters 500M On team "@%teamtobe@" above himself.");
   return 1;
}

addCMDToHelp("DroneBattleTH", "Usage: /DroneBattleTH [Count] [Team]: Starts drones on a team, at 5000M up.");
function ccDroneBattleTH(%sender,%args) {
      %pos = vectoradd(%sender.player.getposition(), "0 0 5000");
      %Amount=getword(%args,0);
      %teamtobe=getword(%args,1);
      if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
      }
      if(%Amount < 1 ||%Amount > 50) {
      messageclient(%sender, 'MsgClient', '\c5Error: Invalid Amount.');
      return 1;
      }
      if(%teamtobe < 1 || %teamtobe > 99) {
      messageclient(%sender, 'MsgClient', '\c5Error: Invalid Team.');
      return 1;
      }
      DroneBattle(%pos, 500, %Amount, %teamtobe, %teamtobe, 5, 0);
      messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Spawned "@%Amount@" ,Normal Type Fighters 5000M On team "@%teamtobe@" above himself.");
      return 1;
 }
 
////////// Different Drone Types
// Order of Function Dronebattle
// Position, Radius/Speed, Amount, LowestTeam#, HighestTeam#, Level, Stealthed?
addCMDToHelp("DroneSpawns", "Usage: /DroneSpawns: List drone spawns for non-normal drones.");
function ccDroneSpawns(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   messageclient(%sender, 'MsgClient', '\c5 CCM Modded Drone Spawn help menu');
   messageclient(%sender, 'MsgClient', '\c5 /1Slth, /5Slth - Spawn Stealth Drones');
   messageclient(%sender, 'MsgClient', '\c5 /1stri, /5stri, /10stri - Spawn Strike Drones');
   messageclient(%sender, 'MsgClient', '\c5 /1eli, /5eli, /10eli - Spawn Elite Drones');
   messageclient(%sender, 'MsgClient', '\c5 /1Ace, /5Ace - Spawn Ace Drones');
   messageclient(%sender, 'MsgClient', '\c5 /1Ultr - Spawn an ultra drone');
   messageclient(%sender, 'MsgClient', '\c5 /Ultrboss - Start The Stormrider Battle');
   messageclient(%sender, 'MsgClient', '\c5 /Battlemaster - Start the Alister Battle');
   return 1;
}

addCMDToHelp("1Slth", "Usage: /1Slth: Spawn 1 Stealth Drone.");
function cc1Slth(%sender,%args) {       //1 Stealth Drone
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %pos = vectoradd(%sender.player.getposition(), "0 0 500");
   DroneBattle(%pos, 500, 1, 96, 96, 20, 1);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Spawned A Stealth Type Fighter.");
   return 1;
}
 
addCMDToHelp("5Slth", "Usage: /5Slth: Spawn 5 Stealth Drones.");
function cc5Slth(%sender,%args) {       //5 Stealth Drones
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %pos = vectoradd(%sender.player.getposition(), "0 0 500");
   DroneBattle(%pos, 500, 5, 96, 96, 20, 1);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Spawned Five Stealth Type Fighters.");
   return 1;
}
 
addCMDToHelp("1Stri", "Usage: /1Stri: Spawn 1 Strike Drone.");
function cc1Stri(%sender,%args) {       //1 Strike Drones
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %pos = vectoradd(%sender.player.getposition(), "0 0 500");
   DroneBattle(%pos, 500, 1, 97, 97, 35, 0);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Spawned A Strike Type Fighter.");
   return 1;
}
 
addCMDToHelp("5Stri", "Usage: /5Stri: Spawn 5 Strike Drones.");
function cc5Stri(%sender,%args) {       //5 Strike Drones
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %pos = vectoradd(%sender.player.getposition(), "0 0 500");
   DroneBattle(%pos, 500, 5, 97, 97, 35, 0);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Spawned Five Strike Type Fighters.");
   return 1;
}

addCMDToHelp("10Stri", "Usage: /10Stri: Spawn 10 Strike Drones.");
function cc10Stri(%sender,%args) {       //10 Strike Drones
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %pos = vectoradd(%sender.player.getposition(), "0 0 500");
   DroneBattle(%pos, 500, 10, 97, 97, 35, 0);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Spawned Ten Strike Type Fighters.");
   return 1;
}
 
addCMDToHelp("1Eli", "Usage: /1Eli: Spawn 1 Elite Drone.");
function cc1Eli(%sender,%args) {       //1 Elite Drones
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %pos = vectoradd(%sender.player.getposition(), "0 0 500");
   DroneBattle(%pos, 500, 1, 98, 98, 50, 0);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Spawned A Elite Type Fighter.");
   return 1;
}

addCMDToHelp("5Eli", "Usage: /5Eli: Spawn 5 Elite Drones.");
function cc5Eli(%sender,%args) {       //5 Elite Drones
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %pos = vectoradd(%sender.player.getposition(), "0 0 500");
   DroneBattle(%pos, 500, 5, 98, 98, 50, 0);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Spawned Five Elite Type Fighters.");
   return 1;
}

addCMDToHelp("10Eli", "Usage: /10Eli: Spawn 10 Elite Drones.");
function cc10Eli(%sender,%args) {       //10 Elite Drones
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %pos = vectoradd(%sender.player.getposition(), "0 0 500");
   DroneBattle(%pos, 500, 10, 98, 98, 50, 0);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Spawned Ten Elite Type Fighters.");
   return 1;
}
 
addCMDToHelp("1Ace", "Usage: /1Ace: Spawn 1 Ace Drone.");
function cc1Ace(%sender,%args) {       //1 ACE Drones
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %pos = vectoradd(%sender.player.getposition(), "0 0 500");
   DroneBattle(%pos, 500, 1, 99, 99, 70, 0);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Spawned A Ace Type Fighter.");
   return 1;
}

addCMDToHelp("5Ace", "Usage: /5Ace: Spawn 5 Ace Drones.");
function cc5Ace(%sender,%args) {       //5 ACE Drones
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %pos = vectoradd(%sender.player.getposition(), "0 0 500");
   DroneBattle(%pos, 500, 5, 99, 99, 70, 0);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Spawned Five Ace Type Fighters.");
   return 1;
}

addCMDToHelp("1Ultr", "Usage: /1Ultr: Spawn 1 Ultra Drone.");
function cc1Ultr(%sender,%args) {       //1 Ultra Drone
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %pos = vectoradd(%sender.player.getposition(), "0 0 500");
   %drone = DroneBattle(%pos, 500, 1, 99, 99, 100, 1); //yes this bad guy is stealthed
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Spawned An Ultra Fighter, Pilots Beware.");
   return 1;
}
 
addCMDToHelp("UltrBoss", "Usage: /UltrBoss: spawns The Lv. 2 TWM Boss, Stormrider.");
function ccUltrBoss(%sender,%args) {       //1 Ultra Drone
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   if($TWM::BossBattle) {
      messageclient(%sender, 'MsgClient', '\c5A Boss Battle Is Already Occuring.');
      return 1;
   }
   %pos = vectoradd(%sender.player.getposition(), "0 0 500");
   %pos2 = vectoradd(%sender.player.getposition(), "15 0 500");
   %pos3 = vectoradd(%sender.player.getposition(), "-15 0 500");
   %drone = UltrDroneBattle(%pos, 500, 1, 6, 6, "ace", 0); //yes this bad guy is stealthed
   %d2 = DroneBattle(%pos2, 500, 1, 6, 6, 100, 0); //his Pal
   %d3 = DroneBattle(%pos3, 500, 1, 6, 6, 100, 0); //his Other Pal
   %drone.isUltr = 1;
   %d2.isUltrally = 1;
   %d3.isUltrally = 1;
   schedule(1000,0,"StartObjBossMusic", "ADrone", %drone);
   UltraBossAbilities(%drone);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Spawned \c3Stormrider\c2, Pilots Beware.");
   return 1;
}
 
addCMDToHelp("BattleMaster", "Usage: /BattleMaster: spawns The Lv. 1 TWM Boss, Lt. Alister.");
function ccBattlemaster(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   if($TWM::BossBattle) {
      messageclient(%sender, 'MsgClient', '\c5A Boss Battle Is Already Occuring.');
      return 1;
   }
   %pos = vectoradd(%sender.player.getposition(), "0 0 15");
   %drone = BattlemasterTankBattle(%pos, 500, 1, 6, 6, 10);
   %drone.isBattlemaster = 1;
   BattlemasterAbilities(%drone);
   schedule(1000,0,"StartObjBossMusic", "Battlemaster", %drone);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Spawned \c3Lt. Alister\c2 To The Battlefield");
   return 1;
}

addCMDToHelp("TankBattle", "Usage: /TankBattle [Count]: Spawns AI Controlled Tanks.");
function ccTankBattle(%sender,%args) {
   %pos = vectoradd(%sender.player.getposition(), "0 0 5");
   %Amount=getword(%args,0);
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   if(%Amount < 1 ||%Amount > 30) {
      messageclient(%sender, 'MsgClient', '\c5Error: Invalid Amount.');
      return 1;
   }
   TankBattle(%pos, 500, %Amount, 1, 100, 5);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Spawned "@%Amount@" ,Tanks.");
   return 1;
}
 
addCMDToHelp("TankBattleT", "Usage: /TankBattleT [Count] [Team]: Spawns AI Controlled Tanks On a Specific Team.");
function ccTankBattlet(%sender,%args) {
   %pos = vectoradd(%sender.player.getposition(), "0 0 5");
   %Amount=getword(%args,0);
   %team = getword(%args,1);
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   if(%Amount < 1 ||%Amount > 30) {
      messageclient(%sender, 'MsgClient', '\c5Error: Invalid Amount.');
      return 1;
   }
   if(%team < 1 || %team > 99) {
      messageclient(%sender, 'MsgClient', '\c5Error: Invalid Team.');
      return 1;
   }
   TankBattle(%pos, 500, %Amount, %team, %team, 5);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Spawned "@%Amount@" ,Tanks on team "@%team@".");
   return 1;
}
