setPerfCounterEnable(0);  //leave this, reduces lag

$TWM::RanksDirectory = "Server/TWM/Saved";
// This is where all of the ranks will be saved
// I highly recommend leaving this alone

$TWM::DevToListOnly = 1;
// Set This To 0 Server Hosts, Otherwise, Only
// Devs will be able to add to admin/SA list

$Host::ServerHostGUID = "2000303";
//Obviously Put Your GUID In There
//Type ListGUIDS(); in the server console while in game to find yours

$TWM::MaxBots = 20;
//Max amount of bots a server can add

$Phantom::CSSEnabled = 1;
// CONTENT SAVING SYSTEM

$TWM::ConsoleName = ""@$Host:GM sora:GameName@" Admin";
//you can change this for cons(message);

$Host::ranksystem = 1;
//TWM Rank System, Default: Start Active

$Host::UseGlobalBanList = 1;
//Feel free to turn this off to allow perm-banned players in.

$Host::UseDevelopersList = 1;
//Do we set the mod developers as so?

$Server::MOTD = "Welcome to TWM, Enjoy Yourself and Behave, Disruptive players will be asked to leave.";
//MOTD shown in the loadscreen

$TWM::CSSTimeSave = 5;
//Time in Minutes to re-allow a building save

$TWM::CSSTimeLoad = 5;
//Time in Minutes to re-allow a building load

//////////////////////////////
//IN GAME MOD VARIABLES     //
//////////////////////////////
$Drone::LowestDistance = 50;
//Drones will fly this close to the ground before dodging it

//////////////////////////////
//PRELOADED GAME TYPES      //
//////////////////////////////
//INFECTION
$InfectionGame::TimeTilInfect = 15;
//This is the time (In Seconds) Before The Alpha Zombie(s) are
//Selected at the game start

$InfectionGame::Rounds = 5;
//Number of rounds played before the map changes

$InfectionGame::Min2Alphas = 7;
//Minimum Number Of Players For 2 Alphas, Must Be LESS Than Below

$InfectionGame::Min3Alphas = 10;
//Minimum Number Of Players For 3 Alphas, Must Be LARGER Than Above


////////////////////////////////////////
///////////BOSSES////////////////////////
//////////////EXPERIENCE CHART////////////
//////////////////VARIABLES////////////////
////////////////////////////////////////////
$Boss::EXPGiven["GeneralRaam"] = 7500;
$Boss::EXPGiven["UltraDroneHelp"] = 1000;
$Boss::EXPGiven["LordDarkrai"] = 10000;
$Boss::EXPGiven["Stormrider"] = 10000;
$Boss::EXPGiven["Alister"] = 7500;
$Boss::EXPGiven["LordRAAM"] = 50000;
$Boss::EXPGiven["TheGhostOfFire"] = 100000;





/////////////////////////////////////////////
/////////////////////////////////////////////
///////////////WEAPONS///////////////////////
//////////////////RANK REQUIRED//////////////
////////////////////VARIABLES////////////////
/////////////////////////////////////////////
// SERVER HOSTS: Here you can mess around  //
// with what weapons are availible at what //
// Ranks.. Have fun :)                     //
/////////////////////////////////////////////
// You should leave these like so.
$TWM::WeaponRequirement["NoRequire"] = -999999; //For guns with no XP requirement
$TWM::WeaponRequirement["USP-45"] = -999999;
$TWM::WeaponRequirement["Krieg Rifle"] = -999999;
//
$TWM::WeaponRequirement["MP12 SMG"] = $Ranks::MinPoints[4];
$TWM::WeaponRequirement["Dual MP12 Uzis"] = $Ranks::MinPoints[7];
$TWM::WeaponRequirement["Flame Thrower"] = $Ranks::MinPoints[10];
$TWM::WeaponRequirement["Bazooka"] = $Ranks::MinPoints[11];
$TWM::WeaponRequirement["Shot Gun"] = $Ranks::MinPoints[12];
$TWM::WeaponRequirement["Centaur Dual Pistols"] = $Ranks::MinPoints[15];
$TWM::WeaponRequirement["Sniper Rifle"] = $Ranks::MinPoints[17];
$TWM::WeaponRequirement["Vehicle Destroyer"] = $Ranks::MinPoints[18];
$TWM::WeaponRequirement["M32"] = $Ranks::MinPoints[23];
$TWM::WeaponRequirement["M32 w RPG"] = $Ranks::MinPoints[25];
$TWM::WeaponRequirement["Portible Chaingun Turret"] = $Ranks::MinPoints[28];
$TWM::WeaponRequirement["Rotary ShotGun"] = $Ranks::MinPoints[29];
$TWM::WeaponRequirement["ZH7C8 Napalm Cannon"] = $Ranks::MinPoints[31];
$TWM::WeaponRequirement["PGC Cannon"] = $Ranks::MinPoints[32];
$TWM::WeaponRequirement["RX-12 w ShotGun"] = $Ranks::MinPoints[32];
$TWM::WeaponRequirement["RX-12 w Grenade Launcher"] = $Ranks::MinPoints[33];
$TWM::WeaponRequirement["Targeting Beacon"] = $Ranks::MinPoints[34];
$TWM::WeaponRequirement["Silenced USP-45"] = $Ranks::MinPoints[35];
$TWM::WeaponRequirement["AT6 Rocket Launcher"] = $Ranks::MinPoints[36];
$TWM::WeaponRequirement["Scorcher Cannon"] = $Ranks::MinPoints[39];
$TWM::WeaponRequirement["ES-73 Pulse Phaser"] = $Ranks::MinPoints[39];
$TWM::WeaponRequirement["Blitz Rifle"] = $Ranks::MinPoints[40];
$TWM::WeaponRequirement["Phantom Spiker"] = $Ranks::MinPoints[41];
$TWM::WeaponRequirement["EX-73 Pulse Chaingun"] = $Ranks::MinPoints[42];
$TWM::WeaponRequirement["Desert Eagle"] = $Ranks::MinPoints[43];
$TWM::WeaponRequirement["RTM-85C Photon Laser"] = $Ranks::MinPoints[44];
$TWM::WeaponRequirement["RSA Laser Rifle"] = $Ranks::MinPoints[45];
$TWM::WeaponRequirement["PBC Cannon"] = $Ranks::MinPoints[46];
$TWM::WeaponRequirement["Enemia Rocket Launcher"] = $Ranks::MinPoints[46];
$TWM::WeaponRequirement["ETM-XCC98 Plasma Launcher"] = $Ranks::MinPoints[47];
$TWM::WeaponRequirement["Tesla Volatge Cannon"] = $Ranks::MinPoints[48];
$TWM::WeaponRequirement["ALSWP"] = $Ranks::MinPoints[49];
//TARGETER MODES
$TWM::ARTRequirement["TBeac(Missiles)"] = $Ranks::MinPoints[46];
$TWM::ARTRequirement["TBeac(Artillery)"] = $Ranks::MinPoints[47];
$TWM::ARTRequirement["TBeac(LStorm)"] = $Ranks::MinPoints[48];
//GRENADE
$TWM::GrenadeRequirement["Incindinary"] = $Ranks::MinPoints[30];
//ARMOR
$TWM::ArmorRequirement["Commando"] = $Ranks::MinPoints[8];
$TWM::ArmorRequirement["Support"] = $Ranks::MinPoints[13];
$TWM::ArmorRequirement["Nalcidic"] = $Ranks::MinPoints[31];
$TWM::ArmorRequirement["SpecOps"] = $Ranks::MinPoints[32];
$TWM::ArmorRequirement["RSAScout"] = $Ranks::MinPoints[43];
////////////////////////////////////////////
