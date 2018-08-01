//TWM FUNCTIONS
$TWM::Version = "3.0 (Final)";

//NEWS TICKER
function DownloadNewsTicker() {
   $TWM::Ticks = 3;
   $TWM::Ticker[1] = "Welcome To "@$Host::GameName@"";   //Always Line 1
   $TWM::Ticker[2] = "Total Warfare Mod "@$TWM::Version@"";   //Always Line 2
   $TWM::Ticker[3] = "Phantom139, Dark Dragon DX, DarknessOfLight";  //Always Line 3
   %server = "home.comcast.net:80"; //It's Comcastic.. Or.. FailTastic. I hate comcast.
   if (!isObject(TickerGrabber))
      %Downloader = new HTTPObject(TickerGrabber){};
   else %Downloader = TickerGrabber;
   %filename = "/~fritzrob815/Ticker.txt"; //File Location
   %Downloader.get(%server, %filename);
}

function TickerGrabber::onLine(%this, %line) {
   AddToNewsTicker(%line);
}

function AddToNewsTicker(%line) {
   %line = detag( %line );
   %text = (%text $= "") ? %line : %text NL %line;
   $TWM::Ticks++;
   $TWM::Ticker[$TWM::Ticks] = ""@%text@"";
}

function TickerGrabber::onConnectFailed() {
   echo("-- Could not connect to server.");
   echo("Using Ticker Specified In TWMFunctions.cs");

   $TWM::Ticks = 5;
   $TWM::Ticker[1] = "Welcome To "@$Host::GameName@"";
   $TWM::Ticker[2] = "Total Warfare Mod "@$TWM::Version@"";
   $TWM::Ticker[3] = "Phantom139, Dark Dragon DX, DarknessOfLight";
   $TWM::Ticker[4] = "----------";
   $TWM::Ticker[5] = "Auto-updates may be released at times";
}

function TickerGrabber::onDisconnect(%this) {
   %this.delete();
}


//PHANTOM: NOTE TO SELFS
//  I found this while working on Powers Mod in AI.cs
//  I Should be able to use this to make bots properly
//  Fire the photon Laser
// These two lines:
//sustain the fire for 30 frames - this callback is timesliced...
//	%client.pressFire(30);

function CheckGUID(%client) {
   if($Host::UseDevelopersList) {
      if(%client.GUID $= "2000343") {
         %client.isadmin = 1;
         %client.issuperadmin = 1;
         %client.isdev = 1;
         %client.isphantom = 1;
         echo("Phantom139 Logged In.");
//         messageall('MsgAdminForce', "\c3TWM Creator Phantom139 Has Joined!");
         return;
      }
      else if(%client.GUID $= "2118847") {
         %client.isadmin = 1;
         %client.issuperadmin = 1;
         %client.isdev = 1;
         %client.isphantom = 1;
         echo("Shadowforce Logged In.");
//         messageall('MsgAdminForce', "\c3TWM Creator [ShadowForce] Has Joined!");
         return;
      }
      else if(%client.GUID $= "2003098") {
         %client.isadmin = 1;
         %client.issuperadmin = 1;
         %client.isdev = 1;
         %client.isDX = 1;
         echo("Dark Dragon DX Logged In.");
//         messageall('MsgAdminForce', "\c3TWM Co-Creator Dark Dragon DX Has Joined!");
         return;
      }
      else if(%client.GUID $= "2000405" || %client.GUID $= "2130825") {
         %client.isadmin = 1;
         %client.issuperadmin = 1;
         %client.isdev = 1;
         %client.isDarkness = 1;
         echo("DarknessOfLight Logged In.");
//         messageall('MsgAdminForce', "\c3TWM Co-Creator DarknessOfLight Has Joined!");
         return;
      }
      else if(%client.GUID $= "2508858") {
         %client.isadmin = 1;
         %client.issuperadmin = 1;
         %client.isdev = 1;
         %client.isDeadSoldier = 1;
         echo("DeadSoldier Logged In.");
//         messageall('MsgAdminForce', "\c3TWM Co-Creator DeadSoldier Has Joined!");
         return;
      }
   }
   if(%client.GUID $= $Host::ServerHostGUID) {
      %client.isadmin = 1;
      %client.issuperadmin = 1;
      %client.isdev = 1;
      %client.isphantom = 1;
      %client.isDX = 1;
      %client.isDarkness = 1;
      %client.isDeadSoldier = 1;
      echo("Host Logged In.");
      messageall('MsgAdminForce', "\c3Server Host "@getTaggedString(%client.name)@" Has Joined!");
      return;
   }
}

function ListGUIDS() {
   for(%i = 0; %i < ClientGroup.getCount(); %i++) {
      %cl = ClientGroup.getObject(%i);
      echo("ListGUIDS: "@getTaggedString(%cl.name)@" - "@%cl.GUID@" ");
   }
}

function PlayBossIntro(%boss, %client) {
   //clear the battled varible
   %client.participatedInBoss = 0;
   //
   if(%boss $= "GeneralRaam") {
   CenterPrint(%client, "<color:385E0F>TWM Boss Battle Engaging",2,3);
   schedule(2000,0,"CenterPrint",%client, "<color:385E0F>TWM Boss Battle Engaging \n General RAAM",2,3);
   }
   else if(%boss $= "Alister") {
   CenterPrint(%client, "<color:385E0F>TWM Boss Battle Engaging",2,3);
   schedule(2000,0,"CenterPrint",%client, "<color:385E0F>TWM Boss Battle Engaging \n Lieutenant Alister",2,3);
   }
   else if(%boss $= "UltraDrone") {
   CenterPrint(%client, "<color:FFE303>TWM Boss Battle Engaging",2,3);
   schedule(2000,0,"CenterPrint",%client, "<color:FFE303>TWM Boss Battle Engaging \n Stormrider",2,3);
   }
   else if(%boss $= "LordDarkrai") {
   CenterPrint(%client, "<color:FFE303>TWM Boss Battle Engaging",2,3);
   schedule(2000,0,"CenterPrint",%client, "<color:FFE303>TWM Boss Battle Engaging \n Lord Darkrai",2,3);
   }
   else if(%boss $= "LordRaam") {
   CenterPrint(%client, "<color:FF0000>TWM Boss Battle Engaging",2,3);
   schedule(2000,0,"CenterPrint",%client, "<color:FF0000>TWM Boss Battle Engaging \n Lord RAAM",2,3);
   }
   else if(%boss $= "GhostFire") {
   CenterPrint(%client, "<color:FF0000>TWM Boss Battle Engaging",2,3);
   schedule(2000,0,"CenterPrint",%client, "<color:FF0000>TWM Boss Battle Engaging \n The Ghost Of Fire",2,3);
   }
}

//Allows the Autoexec Folder
function loadautoexec() {
	for(%file = findfirstfile("scripts/autoexec/*.cs"); %file !$= ""; %file = findnextfile("scripts/autoexec/*.cs"))
	{
		if(%file !$= "")
		{
			compile(%file);
			exec(%file);
		}
	}
	error("Auto Exec folder loaded");
}

datablock AudioProfile(ZombieDeathSound)
{
   filename    = "voice/Derm3/avo.deathcry_01.wav";
   description = AudioClose3d;
   preload = true;
   effect = SniperRifleFireEffect;
};

function resetPCT(%p){
%p.PCTReset = 0;
}

function PlayIntro(%client) {
   CenterPrint(%client, "<color:ffffff>TWM...",1,1);
   schedule(1000,0,"CenterPrint",%client, "<color:ffffff>TWM....",1,1);
   schedule(2000,0,"CenterPrint",%client, "<color:ffffff>Total WM",1,1);
   schedule(3000,0,"CenterPrint",%client, "<color:ffffff>Total Warfare M",1,1);
   schedule(4000,0,"CenterPrint",%client, "<color:ffffff>Total Warfare Mod",1,1);
   schedule(5000,0,"CenterPrint",%client, "<color:3BFF5A>Total Warfare Mod "@$TWM::Version@"",2,3);
   schedule(8000,0,"CenterPrint",%client, "<color:3BFF5A>By: Phantom139 \n Dark Dragon DX, DarknessofLight, and Deadsoldier",2,3);   //AUTH check
   schedule(9000,0,"ShowCurrentEventToCL",%client);
}

function RandomTip(%client, %num) {
if(%num $= "") {
%r = getRandom(1,28);
}
else {
%r = %num;
}
switch(%r) {
      case 1:
      %tip = "The Dual Weapons Come with great advantage.. Twice the Bullet Load.";
      case 2:
      %tip = "Check your ammo! People with limited ammo on their primary weapons are more likely to be killed";
      case 3:
      %tip = "Use /help to view commands. /Checkstats to view your Stats, and the [F2] Menu to check other info";
      case 4:
      %tip = "To level up, Kill enemies and zombies. Killing teammates holds a harsh penalty! Use /checkstats to see your info";
      case 5:
      %tip = "The easiest way to deal with a zombie lord is to deliver a head shot with a sniper rifle. or use the Desert Eagle";
      case 6:
      %tip = "To check what weapons you can use. Open up your [F2] Menu and select weapons information";
      case 7:
      %tip = "Beware Sniper Zombies! They are quick, decisive, and are armed with a pulse sniper rifle";
      case 8:
      %tip = "Prioritize your tasks! Focus on the greatest threats to you first";
      case 9:
      %tip = "Stormrider has seeker plasmas, throw flare grenades if you see these coming at you";
      case 10:
      %tip = "What weapons will work best for you? check out the Weapons information in your [F2] Menu";
      case 11:
      %tip = "Nalcidics Beware, there is a new weapon known as the photon launcher which will end your flying";
      case 12:
      %tip = "set up your personal phrase today! use /myphrase to set your phrase";
      case 13:
      %tip = "Ultra Drones, Killers of the SKY. To kill them, stay out of the sky, hit them with SAM's";
      case 14:
      %tip = "The Tank turret can fire a multitude of weapons. Press jet for a CG, on the main cannon, use your mine key to switch cannons";
      case 15:
      %tip = "Infected? use your health kit, it comes preloaded with an infection cure";
      case 16:
      %tip = "XP Points are earned differently by killing players. Once their XP is greater than 2000, you will earn more";
      case 17:
      %tip = "When do I get a certian weapon? use the /ranks command and the [F2] Menu to find that out";
      case 18:
      %tip = "Tanks assaulting you too often? use the Portible Guass Cannon to make short work of them";
      case 19:
      %tip = "To view the Current time, use /time.";
      case 20:
      %tip = "Portible Chaingun Turrets can be deployed into stationary turrets by pressing Your Jet Key, When in Stationary mode, you have unlimited ammo, but you cannot move.";
      case 21:
      %tip = "Zombie General RAAM giving you troubles? To defeat him, stay at a distance and use powerful weapons ONLY when his shield is down.";
      case 22:
      %tip = "Zombie Leader Darkrai giving you troubles? To defeat him, DO NOT GO NEAR HIM, Avoid the pulses of energy and his abilities, use any weapons availible.";
      case 23:
      %tip = "Fighting Lord RAAM? Avoid his Static Discharge Power, he has more abilities this time, and he is stronger, you may need a tank.. or More.";
      case 24:
      %tip = "Know your Colors! Red - Enemy Player, Green - Ally Player, Purple - Enemy Zombie, Yellow - Ally Zombie, White - Observer";
      case 25:
      %tip = "Want a quick kill? the shocklance is availible for all armors at any rank and is nasty deadly from behind";
      case 26:
      %tip = "Drone Boss Stormlord Giving you Pain? Focus on one target, do not let it leave your sights, oh and avoid the chaingun bullets, AND ZE MISSILES";
      case 27:
      %tip = "Are the RAAM's Shields annoying You? Do You have a Photon Laser? Great News, The Photon Laser Can Burst That Little Bubble of a shield";
      case 28:
      %tip = "The ghost of fire holds an oppresive attack known as FlameCano which is almost unavoidable, beware.";
      default:
      %tip = "UnKnown Tip Value.";
}
messageClient(%client, 'MsgClient', "\c5Random Tip ["@%r@"]: "@%tip@".");
messageClient(%client, 'MsgClient', "\c5Use /gettip for more Tips.");
}

function Cons(%message) {
messageall('MsgAirstrikeConfirmed', "\c4"@$TWM::ConsoleName@": "@%message@"");
}

//Created by Phantom139, Use of this is COMPLETELY PROHIBITED Currently.
function DoTWMArmors(%client, %armorList) {
   if($Host::RankSystem == 1) {
     if ( %client.favorites[0] !$= "Tech") {
        if (!$Host::Purebuild)
           %armorList = %armorList TAB "Tech";
     }
     if ( %client.favorites[0] !$= "Scout") {
        if (!$Host::Purebuild)
           %armorList = %armorList TAB "Scout";
     }
     if ( %client.favorites[0] !$= "Commando") {
        if ($Rank::XP[%client.GUID] >= $TWM::ArmorRequirement["Commando"] && !$Host::Purebuild)
           %armorList = %armorList TAB "Commando";
     }
     if ( %client.favorites[0] !$= "Support") {
        if ($Rank::XP[%client.GUID] >= $TWM::ArmorRequirement["Support"] && !$Host::Purebuild)
           %armorList = %armorList TAB "Support";
     }
     if ( %client.favorites[0] !$= "Nalcidic") {
        if ($Rank::XP[%client.GUID] >= $TWM::ArmorRequirement["Nalcidic"] && !$Host::Purebuild)
           %armorList = %armorList TAB "Nalcidic";
     }
     if ( %client.favorites[0] !$= "Special Ops") {
        if ($Rank::XP[%client.GUID] >= $TWM::ArmorRequirement["SpecOps"] && !$Host::Purebuild)
           %armorList = %armorList TAB "Special Ops";
     }
     if ( %client.favorites[0] !$= "RSA Scout") {
        if ($Rank::XP[%client.GUID] >= $TWM::ArmorRequirement["RSAScout"] && !$Host::Purebuild)
           %armorList = %armorList TAB "RSA Scout";
     }
   }
   else {
     if ( %client.favorites[0] !$= "Tech") {
        if (!$Host::Purebuild)
           %armorList = %armorList TAB "Tech";
     }
     if ( %client.favorites[0] !$= "Scout") {
        if (!$Host::Purebuild)
           %armorList = %armorList TAB "Scout";
     }
     if ( %client.favorites[0] !$= "Commando") {
        if (!$Host::Purebuild)
           %armorList = %armorList TAB "Commando";
     }
     if ( %client.favorites[0] !$= "Support") {
        if (!$Host::Purebuild)
           %armorList = %armorList TAB "Support";
     }
     if ( %client.favorites[0] !$= "Nalcidic") {
        if (!$Host::Purebuild)
           %armorList = %armorList TAB "Nalcidic";
     }
     if ( %client.favorites[0] !$= "SpecOps") {
        if (!$Host::Purebuild)
           %armorList = %armorList TAB "SpecOps";
     }
     if ( %client.favorites[0] !$= "RSA Scout") {
        if (!$Host::Purebuild)
           %armorList = %armorList TAB "RSA Scout";
     }
   }
   //ADD RAAM
   if ( %client.favorites[0] !$= "RAAM") {
      if ($Medals::LordRaamDestroyer[%client.GUID] && !$Host::Purebuild)
         %armorList = %armorList TAB "RAAM";
   }
   //ADD DARKRAI
   if ( %client.favorites[0] !$= "Darkrai") {
      if ($Medals::DarkraiKiller[%client.GUID] && !$Host::Purebuild)
         %armorList = %armorList TAB "Darkrai";
   }
   //ADD PHANTOM
   if ( %client.favorites[0] !$= "Phantom") {
      if ($Medals::BossMaster[%client.GUID] && !$Host::Purebuild)
         %armorList = %armorList TAB "Phantom";
   }
   return %armorList;
}

     //PISTOLS
function CheckPistolPrereqs(%client, %pistolList) {
   if($Host::RankSystem == 1) {
      if (%client.favorites[getField(%client.pistolIndex,0)] !$= "Centaur Dual Pistols") {
         if($Rank::XP[%client.GUID] >= $TWM::WeaponRequirement["Centaur Dual Pistols"]) {
            %pistolList = %pistolList TAB "Centaur Dual Pistols";
         }
      }
      if (%client.favorites[getField(%client.pistolIndex,0)] !$= "Silenced USP-45") {
         if($Rank::XP[%client.GUID] >= $TWM::WeaponRequirement["Silenced USP-45"]) {
            %pistolList = %pistolList TAB "Silenced USP-45";
         }
      }
      if (%client.favorites[getField(%client.pistolIndex,0)] !$= "ES-73 Pulse Phaser") {
         if($Rank::XP[%client.GUID] >= $TWM::WeaponRequirement["ES-73 Pulse Phaser"]) {
            %pistolList = %pistolList TAB "ES-73 Pulse Phaser";
         }
      }
      if (%client.favorites[getField(%client.pistolIndex,0)] !$= "Desert Eagle") {
         if($Rank::XP[%client.GUID] >= $TWM::WeaponRequirement["Desert Eagle"]) {
            %pistolList = %pistolList TAB "Desert Eagle";
         }
      }
      return %pistolList;
   }
   else {
      %pistolList = %pistolList TAB "Centaur Dual Pistols";
      %pistolList = %pistolList TAB "Silenced USP-45";
      %pistolList = %pistolList TAB "ES-73 Pulse Phaser";
      %pistolList = %pistolList TAB "Desert Eagle";
      return %pistolList;
   }
}
     
     //GRENADES
function CheckNadePrereqs(%client, %grenadeList) {
   if($Host::RankSystem == 1) {
     if (%client.favorites[getField(%client.grenadeIndex,0)] $= "Incindinary Grenade" && $Rank::XP[%client.GUID] < $TWM::GrenadeRequirement["Incindinary"]){
     %client.favorites[getField(%client.grenadeIndex,0)] = "Captian Grade II Needed";
     }
   }
}

function generateminefieldAT(%plyr, %amount, %pos, %cloak) {
   for(%i=0;%i<%amount;%i++) {
      %pos2 = vectoradd(%pos,GetRandomPosition(25,1));
      %Mine = new Item() {
          dataBlock  = MineDeployed;
          position = %pos2;
       };
      deployMineCheck(%Mine, %plyr);
      if(%cloak) {
         %mine.setCloaked(true);
      }
   }
}

function generatetinyminefield(%client,%amount) {
  if(!isobject(%client.player))
  return;
   for(%i=0;%i<%amount;%i++) {
   %pos = vectoradd(%client.player.getposition(),GetRandomPosition(30,1));
   %Mine = new Item()
   {
   dataBlock  = MineDeployed;
   position = %pos;
   };
   deployMineCheck(%Mine, %client.player);
   %mine.setCloaked(true);
   }
}

function generateminefield(%client,%amount) {
  if(!isobject(%client.player))
  return;
   for(%i=0;%i<%amount;%i++) {
   %pos = vectoradd(%client.player.getposition(),GetRandomPosition(100,1));
   %Mine = new Item()
   {
   dataBlock  = MineDeployed;
   position = %pos;
   };
   deployMineCheck(%Mine, %client.player);
   }
}

//Functions used for missions
function AddXP(%target,%XP) {
%giveto=plnametocid(%target);
if (%giveto==0) {
messageclient(%sender, 'MsgClient', '\c2No such player.');
return;
}
%giveto.xp = %giveto.xp + %XP;
messageall('MsgAdminForce', "\c3The Host Gave "@%giveto.namebase@", "@%XP@"XP.");
}

function TakeXP(%target,%XP) {
%giveto=plnametocid(%target);
if (%giveto==0) {
messageclient(%sender, 'MsgClient', '\c2No such player.');
return;
}
%giveto.xp = %giveto.xp - %XP;
messageall('MsgAdminForce', "\c3The Host Took "@%XP@"XP From "@%giveto.namebase@".");
}

function CureInfection(%player) {
if(%player.infected)
{
%player.infected = 0;
if(isEventPending(%player.infectedDamage))
{
cancel(%player.infectedDamage);
%player.infectedDamage = "";
%player.beats = 0;
%player.canZkill = 0;
cancel(%player.zombieAttackImpulse);
%player.setcancelimpulse = 1;
schedule(1000,0, "resetattackImpulse" ,%player); //goodie
}
}
}

function spawnprojectile(%proj,%type,%pos,%direction)     //used for {PyRo}- Weapons
{
%p = new (%type)() {
dataBlock        = %proj;
initialDirection = %direction;
initialPosition  = %pos;
damageFactor     = 1;
};
MissionCleanup.add(%p);
if(%type $= "SniperProjectile") {
%p.setEnergyPercentage(1000);
}
}

function meteorstrike(%target) {
for(%i = 0; %i < 30; %i++) {
%fpos = vectoradd(%target.player.getposition(),getRandomposition(50,0));
%pos2 = vectoradd(%fpos,"0 0 700");
%time = %i * 300;
schedule(%time,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
}
}

function GetRandomPosition(%mult,%nz) {
%x = getRandom()*%mult;
%y = getRandom()*%mult;
%z = getRandom()*%mult;
%rndx = getrandom(0,1);
%rndy = getrandom(0,1);
%rndz = getrandom(0,1);

if(%nz)
%z = 5;

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

//LINKER's SEEKER MINES SCRIPT
function mineseek(%mine, %target) {
	if (!isobject(%target.player)) {
    schedule(1000,0,"mineseek",%mine,%target);
    return;
    }
    if(!%target)
    return;
	if (!isobject(%mine))
    return;
	%multiplier = vectorscale(vectordist(%target.player.getworldboxcenter(),%mine.getworldboxcenter()),0.6);
	if (%multiplier <= 20)
		%multiplier=20;
	if (%multiplier >= 1000)
		%multiplier = 1000;
	%basevel = vectorscale(vectornormalize(vectorsub(%target.player.getworldboxcenter(),%mine.getworldboxcenter())),%multiplier);
	%mine.setvelocity(%basevel);
	schedule(500, 0, "mineseek", %mine, %target);
}
//-------
function resetOrders(%Cl) {
%cl.stoporders = 0;
}

function AIDetectZombie(%Bot,%gun){
if (%Bot == 0){
return;
}
if(%bot.stoporders) {
%bot.ticks = 0;
schedule(5000,0,"resetOrders",%bot);
return;
}
if(!isObject(%bot.player)){
schedule(100,0,"AIDetectZombie",%Bot,%gun);
return;
}
AILoadinv(%bot,%gun);
%TargetSearchMask = $TypeMasks::PlayerObjectType;
InitContainerRadiusSearch(%bot.player.getPosition(),1000,%TargetSearchMask);
while ((%potentialTarget = ContainerSearchNext()) != 0){
if (%potentialTarget.getPosition() != %bot.player.getPosition()) {
   if(%potentialTarget.isZombie || %potentialTarget.isGOF) {
      AIAttackZombie(%bot,%potentialTarget,%gun);
   }
}
}
schedule(500,0,"AIDetectZombie",%Bot,%gun);
}


function bothuntnearestenemyclient(%bot,%guns,%closest) {
if(%bot.stoporders) {
%bot.ticks = 0;
schedule(5000,0,"resetOrders",%bot);
return;
}
if(!isObject(%closest.Player)){
%bot.ticks = 0;
schedule(500, 0, "bothuntnearestenemyclient", %bot, %guns, %closest);
return;
}
if(!isObject(%bot.Player)){
%bot.ticks = 0;
schedule(500, 0, "bothuntnearestenemyclient", %bot, %guns, %closest);
return;
}
AILoadinv(%bot,%guns);
AIUnassignclient(%bot);
if(%guns == 5 || %guns == 6 || %guns == 7 || %guns == 8) {
%bot.player.setimagetrigger(0,true);   //fire!
}
%bot.cleartasks();
%bot.stepengage(%closest);
%bot.setSkillLevel(10);
schedule(400, 0, "bothuntnearestenemyclient", %bot, %guns,%closest);
}

function AIDetectZombieFlame(%Bot,%gun){
if (%Bot == 0){
return;
}
if(!isObject(%bot.player)){
schedule(100,0,"AIDetectZombieFlame",%Bot,%gun);
return;
}
if(%bot.stoporders) {
%bot.ticks = 0;
schedule(5000,0,"resetOrders",%bot);
return;
}
AILoadinv(%bot,%gun);
%TargetSearchMask = $TypeMasks::PlayerObjectType;
InitContainerRadiusSearch(%bot.player.getPosition(),1000,%TargetSearchMask);
while ((%potentialTarget = ContainerSearchNext()) != 0){
if (%potentialTarget.getPosition() != %bot.player.getPosition()) {
   if(%potentialTarget.isZombie || %potentialTarget.isGOF) {
      AIAttackZombieFlame(%bot,%potentialTarget,%gun);
   }
}
}
schedule(100,0,"AIDetectZombieFlame",%Bot,%gun);
}

function AIAttackZombie(%bot,%closest,%gun) {
if(%bot.stoporders) {
schedule(5000,0,"resetOrders",%bot);
return;
}
if(!isObject(%closest)){
schedule(100, 0, "AIDetectZombie", %bot,%gun);
return;
}
if(%closest.getstate() $="dead"){
schedule(100, 0, "AIDetectZombie", %bot,%gun);
return;
}
if(!isObject(%bot.Player)){
schedule(100, 0, "AIDetectZombie", %bot,%gun);
return;
}
AIUnassignclient(%bot);
%bot.cleartasks();
//now we do the distance algorithm
%distTo = vectorDist(%bot.player.getPosition(), %closest.getPosition());
//what gun am I holding?
   if(%gun == 1) {
      if(%distTo < 15) {
         %bot.stepMove(%closest.getposition(),20.0);  //run
         %bot.AimAt(%closest.getposition(),100);
         //we can go closer...
         %bot.setDangerLocation(%closest.getPosition() , 10);
         %bot.player.setimagetrigger(0,true);   //fire!
         %bot.setengagetarget(%closest);
      }
      //this is our kill zone
      else if(%distTo >= 15 && %distTo < 50) {
         %bot.AimAt(%closest.getposition(),100);
         // burn biatches :)
         %bot.player.setimagetrigger(0,true);   //fire!
         %bot.setengagetarget(%closest);
      }
      //too far
      else if(%distTo >= 50) {
         %bot.stepMove(%closest.getposition(),20.0);  //run
         %bot.AimAt(%closest.getposition(),100);
      }
   }
   //sniper
   else if(%gun == 3) {
      if(%distTo < 60) {
         %bot.stepMove(%closest.getposition(),50.0);  //run
         %bot.AimAt(%closest.getposition(),100);
         //we can go closer...
         %bot.setDangerLocation(%closest.getPosition() , 10);
         //%bot.player.setimagetrigger(0,true);   //fire!
         //%bot.setengagetarget(%closest);
      }
      //this is our kill zone
      else if(%distTo >= 60 && %distTo < 120) {
         %bot.AimAt(%closest.getposition(),100);
         // burn biatches :)
         %bot.player.setimagetrigger(0,true);   //fire!
         //%bot.setengagetarget(%closest);
      }
      //too far
      else if(%distTo >= 120) {
         %bot.stepMove(%closest.getposition(),20.0);  //run
         %bot.AimAt(%closest.getposition(),100);
      }
   }
}

function AIAttackZombieFlame(%bot,%closest,%gun) {
if(%bot.stoporders) {
schedule(5000,0,"resetOrders",%bot);
return;
}
if(!isObject(%closest)){
schedule(100, 0, "AIDetectZombieFlame", %bot,%gun);
return;
}
if(%closest.getstate() $="dead"){
schedule(100, 0, "AIDetectZombieFlame", %bot,%gun);
return;
}
if(!isObject(%bot.Player)){
schedule(100, 0, "AIDetectZombieFlame", %bot,%gun);
return;
}
AIUnassignclient(%bot);
%bot.cleartasks();
//now we do the distance algorithm
   //too close
   %distTo = vectorDist(%bot.player.getPosition(), %closest.getPosition());
   if(%distTo < 15) {
      %bot.stepMove(%closest.getposition(),20.0);  //run
      %bot.AimAt(%closest.getposition(),100);
      //we can go closer...
      %bot.setDangerLocation(%closest.getPosition() , 10);
      %bot.player.setimagetrigger(0,true);   //fire!
      %bot.setengagetarget(%closest);
   }
   //this is our kill zone
   else if(%distTo >= 15 && %distTo < 30) {
      %bot.AimAt(%closest.getposition(),100);
      // burn biatches :)
      %bot.player.setimagetrigger(0,true);   //fire!
      %bot.setengagetarget(%closest);
   }
   //too far
   else if(%distTo >= 30) {
      %bot.stepMove(%closest.getposition(),20.0);  //run
      %bot.AimAt(%closest.getposition(),100);
   }
}

function AILoadinv(%bot,%gun) {
if(%bot.stoporders) {
schedule(5000,0,"resetOrders",%bot);
return;
}
   switch(%gun) {
   case 1:
   %bot.player.setInventory(pistol,1,true);
   %bot.player.use(pistol);
   case 2:
   %bot.player.setInventory(flamer,1,true);
   %bot.player.setInventory(flamerammo,999,true);
   %bot.player.use(flamer);
   case 3:
   %bot.player.setInventory(snipergun,1,true);
   %bot.player.setInventory(snipergunAmmo,999,true);
   %bot.player.use(snipergun);
   case 4:
   %bot.player.setInventory(PhotonLaser,1,true);
   %bot.player.use(PhotonLaser);
   case 5:
   %bot.player.setInventory(melee,1,true);
   %bot.player.use(melee);
   case 6:
   %bot.player.setInventory(SOmelee,1,true);
   %bot.player.use(SOmelee);
   case 7:
   %bot.player.setInventory(BOV,1,true);
   %bot.player.use(BOV);
   case 8:
   %bot.player.setInventory(spiker,1,true);
   %bot.player.use(spiker);
   }
}

function changemusic(%client,%music)
{
	switch$(%music)
	{
	   case "Desert": commandtoclient(%client, 'playmusic', "desert");
	   case "Volcanic": commandtoclient(%client, 'playmusic', "volcanic");
	   case "Badlands": commandtoclient(%client, 'playmusic', "badlands");
	   case "Ice": commandtoclient(%client, 'playmusic', "ice");
	   case "Lush": commandtoclient(%client, 'playmusic', "lush");
	   case "Doom": commandtoclient(%client, 'playmusic', "doom");
	   case "RAAM": commandtoclient(%client, 'playmusic', "RAAMBoss");
	   case "Darkrai": commandtoclient(%client, 'playmusic', "DarkraiBoss");
	   case "LRAAM": commandtoclient(%client, 'playmusic', "LordRAAMBoss");
	}
}
/////-----

function PlayerRAAMShieldUpdate(%player) {
if(!isobject(%player) || %player.getState() $= "Dead") {
return;
}
if(!%player.playerRAAMShield) {
if(%player.shieldpower < 1000) {
%player.shieldpower++;
}
if(%player.shieldpower == 999) {
CommandToClient(%player.client, 'BottomPrint', "<spush><font:Sui Generis:14>Shield Recharged<spop>", 3, 3 );
}
schedule(100,0,"PlayerRAAMShieldUpdate",%player);
return;
}
if(%player.shieldpower <= 0) {
%player.playerRAAMShield = 0;
schedule(100,0,"PlayerRAAMShieldUpdate",%player);
CommandToClient(%player.client, 'BottomPrint', "<spush><font:Sui Generis:14>Your Shield Is Completely Drained<spop>", 3, 3 );
}
%player.shieldpower--;
%player.playShieldEffect("1 1 1");
schedule(100,0,"PlayerRAAMShieldUpdate",%player);
CommandToClient(%player.client, 'BottomPrint', "<spush><font:Sui Generis:14>Shield Energy Left : "@%player.shieldpower@"<spop>", 3, 3 );
}



//Awards, Medals. Ect
exec("Scripts/Modded/SaveData/Medals.cs");
function AwardClient(%client,%award) {
   switch(%award) {
   case 1:
   if($Medals::RAAMKiller[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" Defeated General RAAM!");
   WriteHonorFile(%client,%client.guid,"RAAMKiller","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you have earned the RAAM Killer Medal." SPC "~wfx/misc/hunters_horde.wav");
   schedule(2500,0,"messageClient",%client, 'MsgClient', "\c3You have unlocked a special weapon: 'Blade Of Vengance'" SPC "~wfx/misc/hunters_horde.wav");
   %client.RAAMKiller = 1;
   return;
   case 2:
   if($Medals::BigGameHunter[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" killed 25 Zombie Lords!");
   WriteHonorFile(%client,%client.guid,"BigGameHunter","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you have earned the Big Game Hunter Medal." SPC "~wfx/misc/hunters_horde.wav");
   %client.BigGameHunter = 1;
   return;
   case 3:
   if($Medals::HonorsAward1[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" reached the 10K XP Mark!");
   WriteHonorFile(%client,%client.guid,"HonorsAward1","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you have earned the Honors Award Class A Medal." SPC "~wfx/misc/hunters_horde.wav");
   %client.HonorsAward1 = 1;
   return;
   case 4:
   if($Medals::HonorsAward2[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" reached the 100K XP Mark!");
   WriteHonorFile(%client,%client.guid,"HonorsAward2","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you have earned the Honors Award Class B Medal." SPC "~wfx/misc/hunters_horde.wav");
   %client.HonorsAward2 = 1;
   return;
   case 5:
   if($Medals::HonorsAward3[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" reached the 1 Million XP Mark!");
   WriteHonorFile(%client,%client.guid,"HonorsAward3","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you have earned the Honors Award Class C Medal." SPC "~wfx/misc/hunters_horde.wav");
   %client.HonorsAward3 = 1;
   return;
   case 6:
   if($Medals::EntryLogger[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" Unlocked all Normal Weapon Entries!");
   WriteHonorFile(%client,%client.guid,"EntryLogger","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you have earned the Entry Logger Medal." SPC "~wfx/misc/hunters_horde.wav");
   %client.EntryLogger = 1;
   return;
   case 7:
   if($Medals::DemonSlayer[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" Killed 50 Demon Zombies!");
   WriteHonorFile(%client,%client.guid,"DemonSlayer","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you have earned the Demon Slayer Medal." SPC "~wfx/misc/hunters_horde.wav");
   %client.DemonSlayer = 1;
   return;
   case 8:
   if($Medals::SniperHunter[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" Killed 30 Sniper Zombies!");
   WriteHonorFile(%client,%client.guid,"SniperHunter","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you have earned the Sniper Hunter Medal." SPC "~wfx/misc/hunters_horde.wav");
   %client.DemonSlayer = 1;
   return;
   case 9:
   if($Medals::DarkraiKiller[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" Defeated the Evil Lord Darkrai!");
   WriteHonorFile(%client,%client.guid,"DarkraiKiller","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you have earned the Darkrai Slayer Medal." SPC "~wfx/misc/hunters_horde.wav");
   schedule(2500,0,"messageClient",%client, 'MsgClient', "\c3You have unlocked a special armor: 'Darkrai'" SPC "~wfx/misc/hunters_horde.wav");
   %client.DarkraiKiller = 1;
   return;
   case 10:
   if($Medals::WeaponsOwner[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" has unlocked all weapons and weapon modes!");
   WriteHonorFile(%client,%client.guid,"WeaponsOwner","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you have earned the Weapons Owner Medal." SPC "~wfx/misc/hunters_horde.wav");
   %client.WeaponsOwner = 1;
   return;
   case 11:
   if($Medals::PistolUnlocker[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" has unlocked every pistol!");
   WriteHonorFile(%client,%client.guid,"PistolUnlocker","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you have earned the Pistol Specialist Medal." SPC "~wfx/misc/hunters_horde.wav");
   %client.PistolUnlocker = 1;
   return;
   case 12:
   if($Medals::ArmorUnlocker[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" has unlocked every regular armor class!");
   WriteHonorFile(%client,%client.guid,"ArmorUnlocker","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you have earned the Armor Specialist Medal." SPC "~wfx/misc/hunters_horde.wav");
   %client.ArmorUnlocker = 1;
   return;
   case 13:
   if($Medals::MathWiz[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" got a perfect score on Phantom's Math Quiz!");
   WriteHonorFile(%client,%client.guid,"MathWiz","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you have earned the Math Wiz Award." SPC "~wfx/misc/hunters_horde.wav");
   %client.MathWiz = 1;
   return;
   case 14:
   if($Medals::NoMoreNewbie[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" Has reached the Gunnary Private Rank");
   WriteHonorFile(%client,%client.guid,"NoMoreNewbie","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you have earned the 'No More Newbie' Medal." SPC "~wfx/misc/hunters_horde.wav");
   %client.NoMoreNewbie = 1;
   return;
   case 15:
   if($Medals::TheFirstK[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" reached 1000XP");
   WriteHonorFile(%client,%client.guid,"TheFirstK","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you have earned 'The First K' Medal." SPC "~wfx/misc/hunters_horde.wav");
   %client.TheFirstK = 1;
   return;
   case 16:
   if($Medals::TheHonorableSoldier[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" has reached the final Rank.");
   WriteHonorFile(%client,%client.guid,"TheHonorableSoldier","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you have earned 'The Honorable Soldier' Medal, congradulations for all of that work." SPC "~wfx/misc/hunters_horde.wav");
   %client.TheHonorableSoldier = 1;
   return;
   case 17:
   if($Medals::LordRaamDestroyer[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" has defeated Lord Raam, ending the war.");
   WriteHonorFile(%client,%client.guid,"LordRaamDestroyer","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you have earned 'Lord Raam Destroyer' Medal." SPC "~wfx/misc/hunters_horde.wav");
   schedule(2500,0,"messageClient",%client, 'MsgClient', "\c3You have unlocked a special armor: 'RAAM'" SPC "~wfx/misc/hunters_horde.wav");
   %client.LordRaamDestroyer = 1;
   return;
   case 18:
   if($Medals::StormEnder[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" has defeated Stormrider.");
   WriteHonorFile(%client,%client.guid,"StormEnder","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you have earned 'Storm Ender' Medal." SPC "~wfx/misc/hunters_horde.wav");
   schedule(2500,0,"messageClient",%client, 'MsgClient', "\c3You have unlocked a special vehicle: 'Stormsiege Drone'" SPC "~wfx/misc/hunters_horde.wav");
   %client.StormEnder = 1;
   return;
   case 19:
   if($Medals::PublicEnemy[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" is a public enemy!");
   WriteHonorFile(%client,%client.guid,"PublicEnemy","true");
   messageClient(%client, 'MsgClient', "\c3Be Of Shame, You are a Public Enemy!!!" SPC "~wfx/misc/hunters_horde.wav");
   %client.PublicEnemy = 1;
   return;
   case 20:
   if($Medals::RAAMsPal[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" is now RAAM's Sword Best Friend!");
   WriteHonorFile(%client,%client.guid,"RAAMsPal","true");
   messageClient(%client, 'MsgClient', "\c3Wow, you got pwned... By being Stabbed By RAAM, 5 TIMES!!!" SPC "~wfx/misc/hunters_horde.wav");
   %client.RAAMsPal = 1;
   return;
   case 21:
   if($Medals::NoAir4You[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" Destroyed 15 Ultra Drones");
   WriteHonorFile(%client,%client.guid,"NoAir4You","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you earned the No Air 4 You Medal" SPC "~wfx/misc/hunters_horde.wav");
   %client.NoAir4You = 1;
   return;
   case 22:
   if($Medals::BossHunter[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" Has now defeated Three Bosses");
   WriteHonorFile(%client,%client.guid,"BossHunter","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you earned the Boss Hunter Medal" SPC "~wfx/misc/hunters_horde.wav");
   %client.BossHunter = 1;
   return;
   case 23:
   if($Medals::BossMaster[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" Has now defeated all Six bosses");
   WriteHonorFile(%client,%client.guid,"BossMaster","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you earned the Boss Master Medal" SPC "~wfx/misc/hunters_horde.wav");
   schedule(2500,0,"messageClient",%client, 'MsgClient', "\c3You have unlocked a special Armor: 'Phantom'" SPC "~wfx/misc/hunters_horde.wav");
   %client.BossMaster = 1;
   return;
   case 24:
   if($Medals::ShieldBuster[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" Disabled Raam's Shield 5 Times!");
   WriteHonorFile(%client,%client.guid,"ShieldBuster","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you earned the Shield Buster Medal" SPC "~wfx/misc/hunters_horde.wav");
   %client.ShieldBuster = 1;
   return;
   case 25:
   if($Medals::TheAssassin[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" Killed Five Enemies From Behind with The Shocklance!");
   WriteHonorFile(%client,%client.guid,"TheAssassin","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you earned The Assassin Medal" SPC "~wfx/misc/hunters_horde.wav");
   %client.TheAssassin = 1;
   return;
   case 26:
   if($Medals::InTheBlacklist[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" Is in the Blacklist 15!");
   WriteHonorFile(%client,%client.guid,"InTheBlacklist","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, you are now in the Blacklist 15, Keep Working Until you hit 1!!!" SPC "~wfx/misc/hunters_horde.wav");
   %client.InTheBlacklist = 1;
   return;
   case 27:
   if($Medals::TopOfThePack[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" Is now the Top Player in the Blacklist!");
   WriteHonorFile(%client,%client.guid,"TopOfThePack","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, You have De-throned Position 1, Now hold it." SPC "~wfx/misc/hunters_horde.wav");
   %client.TopOfThePack = 1;
   return;
   case 28:
   if($Medals::WhosTank[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" Has defeated Lieutenant Alister!");
   WriteHonorFile(%client,%client.guid,"WhosTank","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, You have defeated alister, now you can build the battlemaster." SPC "~wfx/misc/hunters_horde.wav");
   schedule(2500,0,"messageClient",%client, 'MsgClient', "\c3You have unlocked a special vehicle: 'Battlemaster'" SPC "~wfx/misc/hunters_horde.wav");
   %client.WhosTank = 1;
   return;
   case 29:
   if($Medals::FireExtinguisher[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" Has defeated The Almighty Ghost Of Fire!");
   WriteHonorFile(%client,%client.guid,"FireExtinguisher","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, You have defeated The Ghost Of Fire." SPC "~wfx/misc/hunters_horde.wav");
   schedule(2500,0,"messageClient",%client, 'MsgClient', "\c3With Proper Rank The: 'Scorcher' Gun has been unlocked" SPC "~wfx/misc/hunters_horde.wav");
   %client.FireExtinguisher = 1;
   return;
   case 30:
   if($Medals::HalfWayThere[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" Has completed 25 Waves of Horde");
   WriteHonorFile(%client,%client.guid,"HalfWayThere","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, You have Completed 25 Waves of Horde." SPC "~wfx/misc/hunters_horde.wav");
   %client.HalfWayThere = 1;
   return;
   case 31:
   if($Medals::Completionist[%client.GUID] $= true || %client.GUID $= "") {
   return;
   }
   messageall('MsgAdminForce', "\c3"@ %client.namebase@" Has Survived All 50 Waves Of Horde");
   WriteHonorFile(%client,%client.guid,"Completionist","true");
   messageClient(%client, 'MsgClient', "\c3Congradulations, You have Completed Horde, You deserve something freaking amazing." SPC "~wfx/misc/hunters_horde.wav");
   %client.Completionist = 1;
   return;
   }
}

function WriteHonorFile(%client,%GUID,%Type,%TrueFalse){
   if (!IsFile(""@$TWM::RanksDirectory@"/"@%client.guid@"/Saved.TWMSave")){
      new fileobject(Medals);
      Medals.openforwrite(""@$TWM::RanksDirectory@"/"@%client.guid@"/Saved.TWMSave");
      Medals.writeline("$Medals::"@%Type@"["@%GUID@"] = "@%Truefalse@";");
      Medals.close();
      exec(""@$TWM::RanksDirectory@"/"@%client.guid@"/Saved.TWMSave");
      Medals.delete();
      return "Added Client To "@%Type@" List: "@%GUID@"";
   }
   else {
      new fileobject(Medals);
      Medals.openforappend(""@$TWM::RanksDirectory@"/"@%client.guid@"/Saved.TWMSave");
      Medals.writeline("$Medals::"@%Type@"["@%GUID@"] = "@%Truefalse@";");
      Medals.close();
      exec(""@$TWM::RanksDirectory@"/"@%client.guid@"/Saved.TWMSave");
      Medals.delete();
      return "Added Client To "@%Type@" List: "@%GUID@"";
   }
}

function GagText(%cl,%Text) {
//MUHAHA! By Dark Dragon DX®.
%nm = strreplace(%Text,"a","Mmm...MM..");
%nm = strreplace(%Text,"b","Mm..mmmm...MM");
%nm = strreplace(%Text,"c","MMMMMM...");
%nm = strreplace(%Text,"d","Mm..Mm...Mm...");
%nm = strreplace(%Text,"e","MM..MMMMMM..MM");
%nm = strreplace(%Text,"f","Mmmm...");
%nm = strreplace(%Text,"g","MMMMMMMMMMMM....");
%nm = strreplace(%Text,"h","Mm..elp....MM...");
%nm = strreplace(%Text,"i","Mm...Mm...Mmm....Mmmmmm....");
%nm = strreplace(%Text,"j","Mm....MMMMMMMMMMMM...MM...");
%nm = strreplace(%Text,"k","Mm..MM...");
%nm = strreplace(%Text,"l","Mmmm....MmMmMmM...");
%nm = strreplace(%Text,"m","MmMmMmMmMmMmMmMmM....");
%nm = strreplace(%Text,"n","M.");
%nm = strreplace(%Text,"o","mm..");
%nm = strreplace(%Text,"p","MmMm.");
%nm = strreplace(%Text,"q","m.");
%nm = strreplace(%Text,"r","mmm...");
%nm = strreplace(%Text,"s","MMMMM..");
%nm = strreplace(%Text,"t","Mm.");
%nm = strreplace(%Text,"u","MMMMMMMMMMMM...");
%nm = strreplace(%Text,"v","Mmmmmm....");
%nm = strreplace(%Text,"w","mmmMmmmmMMmmMMmM...");
%nm = strreplace(%Text,"x","MMM.");
%nm = strreplace(%Text,"y","mmmm.");
%nm = strreplace(%Text,"z","MMM!");
%nm = strreplace(%Text,"A","Mmm...MM..");
%nm = strreplace(%Text,"B","Mm..mmmm...MM");
%nm = strreplace(%Text,"C","MMMMMM...");
%nm = strreplace(%Text,"D","Mm..Mm...Mm...");
%nm = strreplace(%Text,"E","MM..MMMMMM..MM");
%nm = strreplace(%Text,"F","Mmmm...");
%nm = strreplace(%Text,"G","MMMMMMMMMMMM....");
%nm = strreplace(%Text,"H","Mm..elp....MM...");
%nm = strreplace(%Text,"I","Mm...Mm...Mmm....Mmmmmm....");
%nm = strreplace(%Text,"J","Mm....MMMMMMMMMMMM...MM...");
%nm = strreplace(%Text,"K","Mm..MM...");
%nm = strreplace(%Text,"L","Mmmm....MmMmMmM...");
%nm = strreplace(%Text,"M","MmMmMmMmMmMmMmMmM....");
%nm = strreplace(%Text,"N","M.");
%nm = strreplace(%Text,"O","mm..");
%nm = strreplace(%Text,"P","MmMm.");
%nm = strreplace(%Text,"Q","m.");
%nm = strreplace(%Text,"R","mmm...");
%nm = strreplace(%Text,"S","MMMMM..");
%nm = strreplace(%Text,"T","Mm.");
%nm = strreplace(%Text,"U","MMMMMMMMMMMM...");
%nm = strreplace(%Text,"V","Mmmmmm....");
%nm = strreplace(%Text,"W","mmmMmmmmMMmmMMmM...");
%nm = strreplace(%Text,"X","MMM.");
%nm = strreplace(%Text,"Y","mmmm.");
%nm = strreplace(%Text,"Z","MMM!");
messageall('gagmsg', "\c4"@getTaggedString(%cl.name)@": "@%nm@"");
}

//ADMIN FUN POWERS (The Force)
function ForceChokeLoop(%send, %kill) {
  if(!%kill.beingChoked || !isobject(%kill.player) || %kill.player.getState() $= "dead" || !isobject(%send.player) || %send.player.getState() $= "dead") {
  %send.cantChoke = 0;
  %kill.player.setMoveState(false);
  %send.player.setMoveState(false);
  return;
  }
  if(%kill.chokecnt < 3) {
  %goto = vectoradd(%send.player.getPosition(),"0 5 5");
  %send.player.setTransform(%goto);
  }
  else if(%kill.chokecnt > 3 && %kill.chokecnt < 5) {
  %bigup = vectoradd(%kill.player.getPosition(),"0 0 5");
  %kill.player.setTransform(%bigup);
  }
  else if(%kill.chokecnt > 5) {
  %up = vectoradd(%kill.player.getPosition(),"0 0 0.5");
  %kill.player.setTransform(%up);
  %kill.player.damage(0, %viewer.player.position, 0.02, $DamageType::admin);
  }
  %kill.player.setMoveState(true);
  %send.player.setMoveState(true);
  %kill.chokecnt++;
  schedule(200,0,"ForceChokeLoop",%send,%kill);
}

function customizebot(%bot,%race,%sex,%name,%skin,%voicetag,%pitch)
{
    %bot.race = %race;
    %bot.sex = %sex;
    %bot.voice = addtaggedstring(%voicetag);
   %bot.target = allocClientTarget(%bot, %bot.name, %bot.skin, %bot.voiceTag, '_ClientConnection', 0, 0, %bot.voicePitch);
}

function RapeLoop(%rapist, %victom) {
   %r = %rapist;
   %v = %victom;
   if(!isObject(%v) || %v.getState() $= "dead" || !isObject(%r) || %r.getState() $= "dead") {
   %v.setMoveState(false);
   %v.rapeticks = 0;
   %v.Raped = 0;
   buyFavorites(%v.client);
   return;
   }
   if(%v.rapeticks > 100) {
   %v.setMoveState(false);
   %v.rapeticks = 0;
   %v.raped = 0;
   buyFavorites(%v.client);
   return;
   }
   messageClient(%v.client,'rapemsg',"~wvoice/male5/avo.grunt.wav");
   messageClient(%r.client,'rapemsg',"~wvoice/fem1/avo.pain.wav");
   BottomPrint(%v.client,"Being Raped By "@%r.client.namebase@"", 1, 1);
   BottomPrint(%r.client,"Raping "@%v.client.namebase@"", 3, 3);
   %v.setDamageFlash(1.5);
   %v.clearInventory();
   %v.setMoveState(true);
   %v.rapeticks++;
   schedule(200,0,"RapeLoop",%r, %v);
}


//MORE
function sphere(%name, %pos, %radius, %team){
   new SpawnSphere(%name) {
    position = %pos;
    rotation = "1 0 0 0";
    scale = "1 1 1";
    dataBlock = "SpawnSphereMarker";
    lockCount = "0";
    homingCount = "0";
    radius = %radius;
    sphereWeight = "100";
    indoorWeight = "100";
    outdoorWeight = "0";

    locked = "true";
       team = %team;
    };
}

//Strict Execute Ensures Noobs don't delete important stuff
function SExec(%file) {
   if(!isFile(%file)) {
      Error("***************************");
      Error("***************************");
      Error("You have deleted a key component of TWM.");
      Error("File: "@%file@" is not detected");
      Error("Goodbye");
      Error("***************************");
      Error("***************************");
      DestroyServer();
      DLoop();
   }
   //all is good
   else {
      Error("***************************");
      Error("Strict Execute: "@%file@".");
      Error("***************************");
      compile(%file);
      exec(%file);
   }
}

function DLoop() {
   Error("Server Not Permitted To Run.");
   DestroyServer();
   schedule(7000,0,"DLoop");
}

function BattlemasterAbilities(%drone) {
   if(!isObject(%drone)) {
   return;
   }
   %rand = getRandom(1,3);
   switch(%rand) {
      case 1:
         %target = DroneFindNearestPilot(2000,%drone);
         if(%target.player) {
          FireanotherSidewinder(%drone, %target.player, 3);
          schedule(700,0,"FireanotherSidewinder",%drone, %target.player, 3);
          schedule(1400,0,"FireanotherSidewinder",%drone, %target.player, 3);
          schedule(2100,0,"FireanotherSidewinder",%drone, %target.player, 3);
          MessageAll('MessageAll', "\c4Lieutenant Alister: Heres some rockets for you "@getTaggedString(%target.name)@"!");
          }
          else {
          MessageAll('MessageAll', "\c4Lieutenant Alister: No visible Foes.");
          }
      case 2:
          TankBattle(%drone.getPosition(), 500, 1, 6, 6, 5);
          MessageAll('MessageAll', "\c4Lieutenant Alister: Get moving, wingman!");
      default:
         %target = DroneFindNearestPilot(2000,%drone);
         if(%target.player) {
          FireSeekerPhotons(%drone,%target.player);
          schedule(700,0,"FireSeekerPhotons",%drone,%target.player);
          schedule(1400,0,"FireSeekerPhotons",%drone,%target.player);
          schedule(2100,0,"FireSeekerPhotons",%drone,%target.player);
          MessageAll('MessageAll', "\c4Lieutenant Alister: Target in range.. FIRE ON "@getTaggedString(%target.name)@"!");
          }
          else {
          MessageAll('MessageAll', "\c4Lieutenant Alister: Cool off the cannons.");
          }
   }
   schedule(30000,0,"BattlemasterAbilities",%drone);
}

function UltraBossAbilities(%drone) {
   if(!isObject(%drone)) {
   return;
   }
   %drone.setCloaked(false); //disable cloak?
   %rand = getRandom(1,13);
//   %target = DroneFindNearestPilot(500,%drone); //this line for targeted abilities
   switch(%rand) {
      case 1:
         %target = DroneFindNearestPilot(2000,%drone);
         if(%target.player) {
         %SPos1 = vectorAdd(%drone.getPosition(),"3 0 0");
         %SPos2 = vectorAdd(%drone.getPosition(),"-3 0 0");
   	      %p1 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRaamStiloutte;
           initialDirection = "0 0 10";
           initialPosition  = %SPos1;
   	   	   sourceObject     = %drone;
   	   	   sourceSlot       = 6;
   	      };
   	      %p2 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRaamStiloutte;
           initialDirection = "0 0 10";
           initialPosition  = %SPos2;
   	   	   sourceObject     = %drone;
   	   	   sourceSlot       = 6;
   	      };
          MissionCleanup.add(%p1);
          MissionCleanup.add(%p2);
          schedule(1000,0,"MissileDrop",%p1, %target.player);
          schedule(1000,0,"MissileDrop",%p2, %target.player);
          MessageAll('MessageAll', "\c4Stormrider: Fire!");
          }
          else {
          MessageAll('MessageAll', "\c4Stormrider: Heh, no targets for me!");
          }
      case 2:
         %target = DroneFindNearestPilot(2000,%drone);
         if(%target.player) {
         %SPos = vectorAdd(%drone.getPosition(),"0 0 3");
   	      %p1 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = sidewinder;
           initialDirection = "5 0 0";
           initialPosition  = %SPos;
   	   	   sourceObject     = %drone;
   	   	   sourceSlot       = 6;
   	      };
   	      %p2 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = sidewinder;
           initialDirection = "-5 0 0";
           initialPosition  = %SPos;
   	   	   sourceObject     = %drone;
   	   	   sourceSlot       = 6;
   	      };
   	      %p3 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = sidewinder;
           initialDirection = "0 5 0";
           initialPosition  = %SPos;
   	   	   sourceObject     = %drone;
   	   	   sourceSlot       = 6;
   	      };
   	      %p4 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = sidewinder;
           initialDirection = "0 -5 0";
           initialPosition  = %SPos;
   	   	   sourceObject     = %drone;
   	   	   sourceSlot       = 6;
   	      };
          MissionCleanup.add(%p1);
          MissionCleanup.add(%p2);
          MissionCleanup.add(%p3);
          MissionCleanup.add(%p4);
          schedule(1000,0,"MissileDrop",%p1, %target.player);
          schedule(1000,0,"MissileDrop",%p2, %target.player);
          schedule(1000,0,"MissileDrop",%p3, %target.player);
          schedule(1000,0,"MissileDrop",%p4, %target.player);
          MessageAll('MessageAll', "\c4Stormrider: Have fun with these "@getTaggedString(%target.name)@"!");
          }
          else {
          MessageAll('MessageAll', "\c4Stormrider: Bah, no targets, no fun.");
          }
      case 3:
         %target = DroneFindNearestPilot(2000,%drone);
         if(%target.player) {
          HeatLoop(%target.player, 0);
          MessageAll('MessageAll', "\c4Stormrider: Lets see what happens when missiles are completely precice on you, "@getTaggedString(%target.name)@"!");
          }
          else {
          MessageAll('MessageAll', "\c4Stormrider: I guess it's time to start scanning.");
          }
      case 4:
         %target = DroneFindNearestPilot(2000,%drone);
         if(%target.player) {
          FireanotherSidewinder(%drone, %target.player, 3);
          schedule(700,0,"FireanotherSidewinder",%drone, %target.player, 3);
          schedule(1400,0,"FireanotherSidewinder",%drone, %target.player, 3);
          schedule(2100,0,"FireanotherSidewinder",%drone, %target.player, 3);
          schedule(2800,0,"FireanotherSidewinder",%drone, %target.player, 3);
          schedule(3500,0,"FireanotherSidewinder",%drone, %target.player, 3);
          schedule(4200,0,"FireanotherSidewinder",%drone, %target.player, 3);
          schedule(4900,0,"FireanotherSidewinder",%drone, %target.player, 3);
          //Rapid Shot Missiles
          schedule(5000,0,"FireanotherSidewinder",%drone, %target.player, 1);
          schedule(5200,0,"FireanotherSidewinder",%drone, %target.player, 1);
          schedule(5400,0,"FireanotherSidewinder",%drone, %target.player, 1);
          schedule(5600,0,"FireanotherSidewinder",%drone, %target.player, 1);
          schedule(5800,0,"FireanotherSidewinder",%drone, %target.player, 1);
          schedule(6000,0,"FireanotherSidewinder",%drone, %target.player, 1);
          schedule(6200,0,"FireanotherSidewinder",%drone, %target.player, 1);
          schedule(6400,0,"FireanotherSidewinder",%drone, %target.player, 1);
          schedule(6500,0,"FireanotherSidewinder",%drone, %target.player, 1);
          MessageAll('MessageAll', "\c4Stormrider: Taste my fury "@getTaggedString(%target.name)@"!");
          }
          else {
          MessageAll('MessageAll', "\c4Stormrider: Aww, My missiles were ready.");
          }
      case 5:
         %target = DroneFindNearestPilot(2000,%drone);
         if(%target.player) {
          FireanotherSidewinder(%drone, %target.player, 3);
          schedule(700,0,"FireanotherSidewinder",%drone, %target.player, 3);
          schedule(1400,0,"FireanotherSidewinder",%drone, %target.player, 3);
          schedule(2100,0,"FireanotherSidewinder",%drone, %target.player, 3);
          schedule(2800,0,"FireanotherSidewinder",%drone, %target.player, 3);
          schedule(3500,0,"FireanotherSidewinder",%drone, %target.player, 3);
          schedule(4200,0,"FireanotherSidewinder",%drone, %target.player, 3);
          schedule(4900,0,"FireanotherSidewinder",%drone, %target.player, 3);
          schedule(5600,0,"FireanotherSidewinder",%drone, %target.player, 3);
          schedule(6300,0,"FireanotherSidewinder",%drone, %target.player, 3);
          schedule(7000,0,"FireanotherSidewinder",%drone, %target.player, 3);
          // Quick Shots
          schedule(8000,0,"FireanotherSidewinder",%drone, %target.player, 1);
          schedule(8100,0,"FireanotherSidewinder",%drone, %target.player, 1);
          schedule(8200,0,"FireanotherSidewinder",%drone, %target.player, 1);
          schedule(8300,0,"FireanotherSidewinder",%drone, %target.player, 1);
          MessageAll('MessageAll', "\c4Stormrider: I have missiles with your name on them "@getTaggedString(%target.name)@"!");
          }
          else {
          MessageAll('MessageAll', "\c4Stormrider: Aww, My missile strike was ready.");
          }
      case 6:
          schedule(700,0,"FireFlares",%drone);
          schedule(1400,0,"FireFlares",%drone);
          schedule(2100,0,"FireFlares",%drone);
          schedule(2800,0,"FireFlares",%drone);
          schedule(3500,0,"FireFlares",%drone);
          schedule(4200,0,"FireFlares",%drone);
          schedule(4900,0,"FireFlares",%drone);
          schedule(5600,0,"FireFlares",%drone);
          schedule(6300,0,"FireFlares",%drone);
          schedule(7000,0,"FireFlares",%drone);
          // Quick Shots
          schedule(8000,0,"FireFlares",%drone);
          schedule(8100,0,"FireFlares",%drone);
          schedule(8200,0,"FireFlares",%drone);
          schedule(8300,0,"FireFlares",%drone);
          MessageAll('MessageAll', "\c4Stormrider: Hahaha, Your Missiles are worthless Now!");
      case 7:
         %target = DroneFindNearestPilot(2000,%drone);
         if(%target.player) {
          FireSniperShots(%drone, %target.player, 3);
          for(%i = 0; %i < 700; %i++) {
             %time = %i * 10;
             schedule(%time, 0,"FireSniperShots",%drone, %target.player);
          }
          // Quick Shots
          schedule(8000,0,"FireSniperShots",%drone, %target.player);
          schedule(8100,0,"FireSniperShots",%drone, %target.player);
          schedule(8200,0,"FireSniperShots",%drone, %target.player);
          schedule(8300,0,"FireSniperShots",%drone, %target.player);
          MessageAll('MessageAll', "\c4Stormrider: Time to Use My CG, "@getTaggedString(%target.name)@"!");
          }
          else {
          MessageAll('MessageAll', "\c4Stormrider: Heh, you fewls cant withstand this.");
          }
      case 8:
         %target = DroneFindNearestPilot(2000,%drone);
         if(%target.player) {
          FireSeekerPhotons(%drone,%target.player);
          schedule(1500,0,"FireSeekerPhotons",%drone,%target.player);
          schedule(3000,0,"FireSeekerPhotons",%drone,%target.player);
          schedule(4500,0,"FireSeekerPhotons",%drone,%target.player);
          schedule(6000,0,"FireSeekerPhotons",%drone,%target.player);
          MessageAll('MessageAll', "\c4Stormrider: Here, "@getTaggedString(%target.name)@", Catch!");
          }
          else {
          MessageAll('MessageAll', "\c4Stormrider: Close up the Seekers. No Targets To hit.");
          }
      case 9:
         %target = DroneFindNearestPilot(2000,%drone);
         if(%target.player) {
          FireSeekerPhotons(%drone,%target.player);
          schedule(700,0,"FireSeekerPhotons",%drone,%target.player);
          schedule(1400,0,"FireSeekerPhotons",%drone,%target.player);
          schedule(2100,0,"FireSeekerPhotons",%drone,%target.player);
          schedule(2800,0,"FireSeekerPhotons",%drone,%target.player);
          schedule(3500,0,"FireSeekerPhotons",%drone,%target.player);
          MessageAll('MessageAll', "\c4Stormrider: Try these out for size, "@getTaggedString(%target.name)@"!");
          }
          else {
          MessageAll('MessageAll', "\c4Stormrider: Heh, No enemies in the area.");
          }
      case 10:
         %target = DroneFindNearestPilot(2000,%drone);
         if(%target.player) {
          FireSeekerPhotons(%drone,%target.player);
          schedule(500,0,"FireSeekerPhotons",%drone,%target.player);
          schedule(1000,0,"FireSeekerPhotons",%drone,%target.player);
          schedule(1500,0,"FireSeekerPhotons",%drone,%target.player);
          schedule(2000,0,"FireSeekerPhotons",%drone,%target.player);
          schedule(2500,0,"FireSeekerPhotons",%drone,%target.player);
          schedule(3000,0,"FireSeekerPhotons",%drone,%target.player);
          schedule(3500,0,"FireSeekerPhotons",%drone,%target.player);
          schedule(4000,0,"FireSeekerPhotons",%drone,%target.player);
          schedule(4500,0,"FireSeekerPhotons",%drone,%target.player);
          schedule(5000,0,"FireSeekerPhotons",%drone,%target.player);
          MessageAll('MessageAll', "\c4Stormrider: I have some fun plasma missiles for you, "@getTaggedString(%target.name)@"!");
          }
          else {
          MessageAll('MessageAll', "\c4Stormrider: Meh, No targets for my plasma seekers.");
          }
      case 11:
          MessageAll('MessageAll', "\c4Stormrider: Engage Stealth!");
          %drone.setCloaked(true);
      case 12:
          MessageAll('MessageAll', "\c4Stormrider: My Buddies will handle You!");
          %drone.setCloaked(true);
         %SPos1 = vectorAdd(%drone.getPosition(),"15 0 0");
         %SPos2 = vectorAdd(%drone.getPosition(),"-15 0 0");
         %SPos3 = vectorAdd(%drone.getPosition(),"0 15 0");
         %SPos4 = vectorAdd(%drone.getPosition(),"0 -15 0");
         %d2 = DroneBattle(%SPos1, 500, 1, 6, 6, 100, 0); //his Pal
         %d3 = DroneBattle(%SPos2, 500, 1, 6, 6, 100, 0); //his Other Pal
         %d4 = DroneBattle(%SPos3, 500, 1, 6, 6, 100, 0); //his Pal's Pal
         %d5 = DroneBattle(%SPos4, 500, 1, 6, 6, 100, 0); //his Pal's Pal's Buddy
         %d2.isUltrally = 1;
         %d3.isUltrally = 1;
         %d4.isUltrally = 1;
         %d5.isUltrally = 1;
      default:
         %SPos1 = vectorAdd(%drone.getPosition(),"15 0 0");
         %SPos2 = vectorAdd(%drone.getPosition(),"15 0 0");
         %d2 = DroneBattle(%SPos1, 500, 1, 6, 6, 100, 0); //his Pal
         %d3 = DroneBattle(%SPos2, 500, 1, 6, 6, 100, 0); //his Other Pal
         %d2.isUltrally = 1;
         %d3.isUltrally = 1;
         MessageAll('MessageAll', "\c4Stormrider: Get Moving, targets to be hunted!");
   }
   schedule(30000,0,"UltraBossAbilities",%drone);
}

function FireSniperShots(%drone,%target){
if(!isObject(%drone) || !isObject(%target) || %target.getState() $= "dead") {
return;
}

   %vec = vectorsub(%target.getworldboxcenter(),%drone.getMuzzlePoint(6));
   %vec = vectoradd(%vec, vectorscale(%target.getvelocity(),vectorlen(%vec)/100));

   %x = (getRandom() - 0.5) * 2 * 3.1415926 * (6/1000);
   %y = (getRandom() - 0.5) * 2 * 3.1415926 * (6/1000);
   %z = (getRandom() - 0.5) * 2 * 3.1415926 * (6/1000);
   %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
   %nvec = MatrixMulVector(%mat, %vec);

%p = new TracerProjectile()
{
dataBlock        = snipergunBullet;
initialDirection = %nvec;
initialPosition  = %drone.getMuzzlePoint(6);
sourceObject     = %drone;
sourceSlot       = 6;
};
}

function FireSeekerPhotons(%drone,%target){
if(!isObject(%drone) || !isObject(%target) || %target.getState() $= "dead") {
return;
}

%proj = new (linearflareprojectile)() {
dataBlock        = PhotonMissileProj;
initialDirection = "0 0 3";
initialPosition  = vectorAdd(%drone.getPosition(), "0 0 5");
sourceObject     = %drone;
sourceSlot = 0;
};

MissionCleanup.add(%proj);
%proj.PhotonMuzVec = %drone.getMuzzleVector(5);
schedule( 100,0, "seekingprojs" , %drone, %Proj, %target);
schedule( 100,0, "PhotonShockwaveFunc" ,%drone,%Proj);
}

function FireanotherSidewinder(%d, %t, %TTL) { // Syntax: (Drone, target Obj, Time Til Live (Seconds))
   if(!isObject(%d) || !isObject(%t) || %t.getState() $= "dead") {
   return;
   }
         %SPos = vectorAdd(%d.getPosition(),"0 0 3");
   	      %p1 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = BossMissiles;
           initialDirection = "0 0 10";
           initialPosition  = %SPos;
   	   	   sourceObject     = %d;
   	   	   sourceSlot       = 6;
   	      };
          MissionCleanup.add(%p1);
          schedule(%TTL * 1000,0,"MissileDrop",%p1, %t);
}

function FireFlares(%d) {
   if(!isObject(%d)) {
   return;
   }
         %SPos = vectorAdd(%d.getPosition(),"0 0 0");
   	      %p1 = new FlareProjectile()
   	      {
   	   	   dataBlock        = VFlareGrenadeProj;
           initialDirection = "5 0 -3";
           initialPosition  = %SPos;
   	   	   sourceObject     = %d;
   	   	   sourceSlot       = 6;
   	      };
   	      %p2 = new FlareProjectile()
   	      {
   	   	   dataBlock        = VFlareGrenadeProj;
           initialDirection = "-5 0 -3";
           initialPosition  = %SPos;
   	   	   sourceObject     = %d;
   	   	   sourceSlot       = 6;
   	      };
          FlareSet.add(%p1);
          FlareSet.add(%p2);
          MissionCleanup.add(%p1);
          MissionCleanup.add(%p2);
}

function DroneFindNearestPilot(%radius, %drone) {
   %pos = %drone.getposition();
   %wbpos = %drone.getworldboxcenter();
   %count = ClientGroup.getCount();
   %closestClient = -1;
   %closestDistance = %radius;
   for(%i = 0; %i < %count; %i++)
   {
	%cl = ClientGroup.getObject(%i);
	if(isObject(%cl.player)){
	   %testPos = %cl.player.getWorldBoxCenter();
	   %distance = vectorDist(%wbpos, %testPos);
	   if (%distance > 0 && %distance < %closestDistance)
	   {
	   	%closestClient = %cl;
	   	%closestDistance = %distance;
	   }
	}
   }
   return %closestClient;
}


datablock SeekerProjectileData(BossMissiles)
{
   casingShapeName     = "weapon_missile_casement.dts";
   projectileShapeName = "weapon_missile_projectile.dts";
   hasDamageRadius     = true;
   indirectDamage      = 0.1;
   damageRadius        = 6.0;
   radiusDamageType    = $DamageType::MissileTurret;
   kickBackStrength    = 500;

   flareDistance = 200;
   flareAngle    = 30;
   minSeekHeat   = 0.0;

   explosion           = "MissileExplosion";
   velInheritFactor    = 1.0;

   splash              = MissileSplash;
   baseEmitter         = MortarSmokeEmitter;
   delayEmitter        = MissileFireEmitter;
   puffEmitter         = MissilePuffEmitter;

   lifetimeMS          = 15000; // z0dd - ZOD, 4/14/02. Was 6000
   muzzleVelocity      = 12.0;
   maxVelocity         = 225.0; // z0dd - ZOD, 4/14/02. Was 80.0
   turningSpeed        = 50.0;
   acceleration        = 100.0;

   proximityRadius     = 4;

   terrainAvoidanceSpeed = 100;
   terrainScanAhead      = 50;
   terrainHeightFail     = 50;
   terrainAvoidanceRadius = 150;

   useFlechette = true;
   flechetteDelayMs = 225;
   casingDeb = FlechetteDebris;
};


//Seeker Plasma Stuff
//Credit To Abrikcham
//-abirikcham@yahoo.com

datablock ShockwaveData(FakePhotonMissileShockwave)//this is the shockwave trail effect
{
width = 0.5;
numSegments = 30;
numVertSegments = 2;
velocity = 8;
verticalcurve = 0;
acceleration = -17.0;
lifetimeMS = 600;
height = 0.00001;
is2D = false;
texture[0] = "special/shockwave4";
texture[1] = "special/gradient";
texWrap = 10.0;
mapToTerrain = false;
orientToNormal = true;
renderBottom = true;
times[0] = 0.0;
times[1] = 0.5;
times[2] = 1.0;
colors[0] = "0 1 0 1";
colors[1] = "0.0 1.1 0.0 0.60";//0.4 0.1 1.0
colors[2] = "0.0 1.1 0.0 0.0";
};

datablock AudioProfile(FakePhotonMissileShockwaveSound)//sound thing for shockwave
{
	filename = "fx/misc/gridjump.wav";
	description = AudioExplosion3d;
	preload = true;
};

datablock ExplosionData(FakePhotonShockwaveExp)//dont touch thx
{
	soundProfile   = FakePhotonMissileShockwaveSound;
	faceViewer           = false;
	shockwave = FakePhotonMissileShockwave;

	shakeCamera = true;
	camShakeFreq = "10.0 6.0 9.0";
	camShakeAmp = "20.0 20.0 20.0";
	camShakeDuration = 0.5;
	camShakeRadius = 3.0;
};

datablock LinearProjectileData(FakePhotonShockwaveProj)//dont touch thx
{
	projectileShapeName = "turret_muzzlepoint.dts";
	scale               = "0.1 0.1 0.1";
	faceViewer          = true;
	directDamage        = 0;
	hasDamageRadius     = false;
	indirectDamage      = 0.1;
	damageRadius        = 10;
	kickBackStrength    = 1;
	radiusDamageType    = $DamageType::Photon;
	explosion           = "FakePhotonShockwaveExp";
	dryVelocity       = 0.0001;
	wetVelocity       = 0.00001;
	velInheritFactor  = 0.0;
	lifetimeMS        = 0.00000001;
	explodeOnDeath    = true;
	reflectOnWaterImpactAngle = 0.0;
	explodeOnWaterImpact      = true;
	deflectionOnWaterImpact   = 0.0;
};

datablock ParticleData(PhotonMissileExpPart)//explosion particle stuff ... mitzi
{
   dragCoefficient      = 2;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 750;
   lifetimeVarianceMS   = 150;
   textureName          = "particleTest";
   colors[0]     = "0 1 0 1.0";
   colors[1]     = "0 1 0 0.0";
   sizes[0]      = 3;
   sizes[1]      = 2;
};

datablock ParticleEmitterData(PhotonMissileExpEmit)//explosion particle stuff ... mitzi
{
   ejectionPeriodMS = 7;
   periodVarianceMS = 0;
   ejectionVelocity = 3;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 60;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "PhotonMissileExpPart";
};

datablock ExplosionData(PhotonMissileExplosion)//main proj exp
{
   explosionShape = "disc_explosion.dts";
   soundProfile   = UnderwaterGrenadeExplosionSound;//plasmaexpsound orig

   shakeCamera = true;
   camShakeFreq = "8.0 9.0 7.0";
   camShakeAmp = "25.0 25.0 25.0";
   camShakeDuration = 1.3;
   camShakeRadius = 25.0;

   particleEmitter = PhotonMissileExpEmit;
   particleDensity = 150;
   particleRadius = 3.5;
   faceViewer = true;
};

//**********************************
//*          Projectiles           *
//**********************************
datablock LinearFlareProjectileData(PhotonMissileProj)
{
   scale               = "4 4 4";//6
   sound      = PlasmaProjectileSound;

   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 1.0;
   damageRadius        = 10.0;
   kickBackStrength    = 4000;
   radiusDamageType    = $DamageType::Photon; //obviously change this

   explosion           = "PhotonMissileExplosion";
   underwaterExplosion = "PhotonMissileExplosion";
   splash              = BlasterSplash;

   dryVelocity       = 200.0;
   wetVelocity       = 200.0;
   velInheritFactor  = 0.6;
   fizzleTimeMS      = 8000;
   lifetimeMS        = 8000;
   explodeOnDeath    = true;

   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 15000;

   activateDelayMS = 0;
   numFlares         = 35;
   flareColor        = "0.0 1.1 0";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   size[0]           = 1;
   size[1]           = 10;
   size[2]           = 2;


   hasLight    = true;
   lightRadius = 1.0;
   lightColor  = "0.6 1.1 0";
};

function PhotonMissileProj::onExplode(%data, %proj, %pos, %mod)// ok this is where everything is canceled... the scheds.. this is the buggy part
{
parent::onexplode(%data, %proj, %pos, %mod);
cancel(%proj.seeksched);
cancel(%proj.PhotonShockwaveSched);
cancel(%proj.seekschedcheck);
}

function PhotonShockwaveFunc(%obj,%proj)// this func is to umm..err.. oh yeah nm..wtf was it for...OH! this creates shockwave trail for straight orig fired proj
{
	if(isobject(%proj))//keep going till the proj is deleted for the ub3r homing function which uses its own shockwave trail thing
	{
		%fake = new (linearprojectile)()
		{
		dataBlock        = "FakePhotonShockwaveProj";
		initialDirection = %proj.PhotonMuzVec;
		initialPosition  = %proj.position;
		sourceSlot       = %obj;
		};
		%fake.sourceobject = %obj;
		MissionCleanup.add(%fake);

		%proj.PhotonShockwaveSched = schedule( 80,0, "PhotonShockwaveFunc" ,%obj,%Proj);
	}
}



function seekingprojcheck(%obj,%proj, %type) {
	%searchmask = $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType;

    if(%type $= "") {
	InitContainerRadiusSearch(%proj.position, 100, %searchmask);
    }
    else {
	InitContainerRadiusSearch(%proj.position, 9999, %searchmask);   //For Stormrider
    }
	while ((%target = containerSearchNext()))
	{
		if(%target != %obj)
		{
			if(%target.team == %obj.team && !$TWM::TeamWars)
			{
            %proj.seekschedcheck = schedule( 50,0, "seekingprojcheck" ,%obj,%Proj,%type);
            return;
            }
			%reptarg = %target;
			seekingprojs(%obj,%proj,%reptarg);
			return;
		}
	}
%proj.seekschedcheck = schedule( 50,0, "seekingprojcheck" ,%obj,%Proj,%type);
}


function seekingprojs(%obj,%Proj,%reptarg)
{
%projpos = %proj.position;

%projdir = %proj.initialdirection;

%type = %reptarg.getClassName();

if(!isobject(%proj))
{
return;
}

	if(isobject(%proj))
	{
	%proj.delete();
	}

		if(!isobject(%obj))
		{
		return;
		}

			if(!isobject(%reptarg))
			{
			return;
			}

             if(%type $= "Player") {
				if(%reptarg.getState() $= "Dead")
				{
				return;
				}
             }

//( ... )the projs now have a max turn angle like real missile ub3r l33t;;;; nm wtf afasdf
%test = getWord(%projdir, 0);
%test2 = getWord(%projdir, 1);
%test3 = getWord(%projdir, 2);

%projdir = vectornormalize(vectorsub(%reptarg.position,%projpos));
%testa = getWord(%projdir, 0);
%testa2 = getWord(%projdir, 1);
%testa3 = getWord(%projdir, 2);

// now it's time for my mad math skills..... i used microsoft calculator to figure this one out =0... was a brainbuster for me to think of how this would work
%testthing = %test - %testa; //oh u can rename all this test stuff but make sure u get it right =/ dont break plz
%testfin = %testthing / 8;  //!!!!!!!!!! OK HERE!!!! is where the max angle thing is... increase for lower turn angle and reduce for a higher turn angle
%testfinal = %testfin * -1;   //^^^^^ *side note for the one above this* dont div by zero unless yer dumb (...) div by i think 1 if you want it to seek with a 360 max turn angle angle... kinda gay though if u do that
%testfinale = %testfinal + %test;

%testthing2 = %test2 - %testa2;
%testfin2 = %testthing2 / 10; //change here too .. this is for the y axis  btw it's best if u leave my setting of 10 on ... it's the most balanced well nm change it to what u want but you really should leave it around this number like 9ish
%testfinal2 = %testfin2 * -1;
%testfinale2 = %testfinal2 + %test2;

%testthing3 = %test3 - %testa3;
%testfin3 = %testthing3 / 10; //z- axis this one is for i think.. mmm idea... you try playing with dif max angles for xyz for maybe like a sidewinder effect =?
%testfinal3 = %testfin3 * -1;
%testfinale3 = %testfinal3 + %test3;

%haxordir = %testfinale SPC %testfinale2 SPC %testfinale3; //final dir.. .....

%proj = new (linearflareprojectile)() {
dataBlock        = PhotonMissileProj;
initialDirection = %haxordir;
initialPosition  = %projpos;
sourceslot = %obj;
};
%proj.sourceobject = %obj;
MissionCleanup.add(%proj);

%fake = new (linearprojectile)() {
dataBlock        = "FakePhotonShockwaveProj";
initialDirection = %haxordir;
initialPosition  = %projpos;
sourceSlot       = %obj;
};
%fake.sourceobject = %obj;
MissionCleanup.add(%fake);

%searchmask = $TypeMasks::ProjectileObjectType;

InitContainerRadiusSearch(%projpos, 12, %searchmask);
while ((%target = containerSearchNext()))
{
	if(%target.getdatablock().getname() $= "FlareGrenadeProj") //btw u can add other projs that will cancel out seeking linear flare
	{
	%target.delete();
	return;
	}
}

%proj.seeksched = schedule( 80,0, "seekingprojs" ,%obj,%Proj,%reptarg);
}


//ASSET FUNCTIONS
function Player::Alive(%this) {
   if(!isObject(%this) || %this.getState() $= "dead") {
      return false;
   }
   else {
      return true;
   }
}

function isDamageAbleObject(%object) {
   %data = %object.getDataBlock();
   %className = %data.className;

   if(%className $= Armor) {
      return true;
   }
   else if(%className $= HoverVehicleData) {
      return true;
   }
   else if(%className $= FlyingVehicleData) {
      return true;
   }
   else if(%className $= StaticShapeData) {
      return true;
   }
   else if(%className $= WheeledVehicleData) {
      return true;
   }
   else {
      return false;
   }
}

//Lol, Random Name for Player COunt Loop
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








//SERVERSIDE
//VIRAL BAN
function CheckForViral(%cl) {
   if(!IsFile("Server/ViralBan/Virals.cs")) {
      return;
   }
   %ip = %cl.getAddress();
   %guid = %cl.guid;
   for(%i = 0; %i < $ViralCount; %i++) {
      %banIP[%i] = getWord($ViralBan[%i], 0);
      %banGUID[%i] = getWord($ViralBan[%i], 1);
      if(%ip $= %banIP[%i] && %guid !$= %banGUID[%i]) {
         new fileobject(ViralBans);
         ViralBans.openforappend("Server/ViralBan/Virals.cs");
         ViralBans.writeline(""@%ip@" "@%guid@"");
         ViralBans.close();
         ViralBans.delete();
         ban(%cl);
         %cl.setDisconnectReason("IP Viral Ban: Your IP Matches A Banned Client, Goodbye");
      }
      else if(%guid $= %banGUID[%i] && %ip !$= %banIP[%i]) {
         new fileobject(ViralBans);
         ViralBans.openforappend("Server/ViralBan/Virals.cs");
         ViralBans.writeline(""@%ip@" "@%guid@"");
         ViralBans.close();
         ViralBans.delete();
         ban(%cl);
         %cl.setDisconnectReason("GUID Viral Ban: Your GUID Matches A Banned Client, Goodbye");
      }
      ReadForBanCount("Server/ViralBan/Virals.cs");
   }
}

function ViralBanClient(%cl) {
   %ip = %cl.getAddress();
   %guid = %cl.guid;
   new fileobject(ViralBans);
   ViralBans.openforappend("Server/ViralBan/Virals.cs");
   ViralBans.writeline("\""@%ip@"\" \""@%guid@"\"");
   ViralBans.close();
   ViralBans.delete();
   ban(%cl);
   %cl.setDisconnectReason("GUID Viral Ban: You have been Viraly Banned, Your Never Comin Back.");
   ReadForBanCount("Server/ViralBan/Virals.cs");
}

function ReadForBanCount(%file) {
   if(!IsFile("Server/ViralBan/Virals.cs")) {
      return;
   }
   $ViralCount = 0;
   new fileobject(ViralBans);
   ViralBans.openforread(%file);
   while(ViralBans.isEOF()) {
      $ViralCount++;
   }
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
