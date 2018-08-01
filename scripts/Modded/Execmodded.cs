//Execmodded.cs
// load all scripts for TWM
setPerfCounterEnable(0);
//
//--- Weapons
exec("scripts/weapons/TWMWeapons/Targeters.cs");      //Artillery, AC-130, Missile Storm ,and Nuke Targeters
exec("scripts/weapons/TWMWeapons/PulsePhaser.cs");    //Pulse Phaser
exec("scripts/weapons/TWMWeapons/PulseChaingun.cs");  //Pulse Phaser Chaingun
exec("scripts/weapons/TWMWeapons/PhotonLaser.cs");    //Photon Laser
exec("scripts/weapons/TWMWeapons/BRifle.cs");         //Blitz Rifle
exec("scripts/weapons/TWMWeapons/TargBazo.cs");       //Enemia Rocket Launcher
exec("scripts/weapons/TWMWeapons/Spiker.cs");         //Phantom Spiker
exec("scripts/weapons/TWMWeapons/PGC.cs");            //Portible Gauss Cannon
exec("scripts/weapons/TWMWeapons/EditGun.cs");        //Editing Tool
exec("scripts/weapons/TWMWeapons/EditingGun.cs");     //Editor Gun
//exec("scripts/Modded/ToxinRifle.cs");               //Infection Rifle
//exec("scripts/Modded/PhantomCannon.cs");            //Requested By Cast - Make a New Nuke
exec("scripts/weapons/TWMWeapons/NapalmGun.cs");      //Napalm Cannon
exec("scripts/weapons/TWMWeapons/VoltCannon.cs");     //Voltage Cannon
exec("scripts/modded/RCMissile.cs");                  //RC Cruise Missile
exec("scripts/weapons/TWMWeapons/Scorcher.cs");       //Scorcher Cannon
exec("scripts/weapons/TWMWeapons/DualSMG.cs");        //Dual MP12 Uzis
exec("scripts/weapons/TWMWeapons/RailGun.cs");        //Railgun

//--- Packs
//exec("scripts/packs/HellRaiser.cs");       //Team Hammer's - Flammer Missile Pod(Hell Raiser)
exec("scripts/packs/pbcbarrelpack.cs");    //PBC Turret Barrel Pack
exec("scripts/packs/waypointpack.cs");     //Waypoint Pack

//--- Turrets
exec("scripts/turrets/OutdoorFissionBarrel.cs");   //Pulse Fission Turret
exec("scripts/turrets/indoor30calturret.cs");      //30-Caliber Turret
exec("scripts/turrets/PBCBarrelLarge.cs");         //PBC Turret

//--- Functions
exec("TWM.MainConfig.cs");                            //Server Default Settings
exec("scripts/modded/TWMFunctions.cs");               //Mod Core Functioning Script
exec("scripts/modded/ProtPatch.cs");                  //Alv's CCM Patch
exec("scripts/modded/TWMEvents.cs");                  //Mod Events Script
exec("scripts/modded/buying.cs");                     //Buying/Upgrading Script
exec("scripts/modded/scoremenucmds.cs");              //[F2] Command Menu
exec("scripts/modded/PconFunctions.cs");              //Phantom Construction Mod Functions
exec("scripts/modded/GhostFireBoss.cs");              //GoF
exec("scripts/modded/Allies.cs");                     //Friendly Zombies
exec("scripts/modded/AdvancedRankSystem.cs");         //The New Ranking System
exec("scripts/modded/KillTrigger.cs");                //Kill Trigger


LoadRanksBase();

//--- Server Modifications
exec("scripts/modded/cynthia.cs");         //Server Assistant
exec("prefs/ContentSave.cs");              //C.S.S

//--- A.I.
exec("scripts/modded/AI/droneai.cs");
exec("scripts/modded/AI/droneai_missionpatrol.cs");
exec("scripts/modded/AI/droneai_tank.cs");

//--- Zombies
exec("scripts/modded/ZombCreation.cs");
exec("scripts/modded/ZombieBossAbilities.cs");
exec("scripts/modded/AI/ZombieAI.cs");

///////////////////////
//////CHAT COMMANDS
exec("scripts/Modded/ChatCommands/Public.cs");     //Public Chat Commands
exec("scripts/Modded/ChatCommands/Admin.cs");      //Admin Chat Commands
exec("scripts/Modded/ChatCommands/SuperAdmin.cs"); //SA Chat Commands
Sexec("scripts/Modded/ChatCommands/DevnServer.cs");//Dev / Server Chat Commands
exec("scripts/modded/ChatCommands/AICCs.cs");      //AI(Drones) Chat commands
exec("scripts/Modded/ChatCommands/Zombie.cs");     //Zombie Chat Commands
///////////////////////

//SERVER DATE SYSTEM
//exec("scripts/modded/ServerDate.cs");
exec("prefs/ServerDate.cs");

exec("scripts/weapons/TWMWeapons/PlasmaLauncher.cs"); //Plasma Launcher

//CIGTS
//exec("CIGTS.cs");

exec("scripts/modded/AutoUpdate.cs");
//Download Ban List
DownloadBanList();
DownloadNewsTicker();
WeewtyFunctionOfAwesomeness();
//Ok, now connect to the Auto Update Server
schedule(7000,0,"ConnectToTWMUpdate", "TWMAutoGrab");
