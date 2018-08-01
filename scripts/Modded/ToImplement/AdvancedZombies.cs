//------------------------------------------------------------------------------
//
// AdvancedZombies.cs
// Author: Dark Dragon DX
// Version: 0.1 Beta
// Description: Adds 'advanced' zombies using Tribes 2's bots.
//
//------------------------------------------------------------------------------

//Load XLib
exec("scripts/XLibrary.cs");

function SpawnNormAI(%trans)
{
%bot = aiConnectbyName("Zombie",0);
%bot.sex = "Male";
%bot.race = "Bioderm";
%bot.setVoice("Derm3");
%bot.setSkin("Storm");
%bot.hideClient();
%bot.clearAI();
%bot.player.setDatablock("ZombieArmorAI");
%bot.player.setTransform(%trans);
%bot.isZombie = true;
%bot.player.isZombie = true;
NormalZombieAI(%bot);

return %bot SPC %trans;
}

function NormalZombieAI(%client)
{
if (!IsObject(%client))
return;
if (!%client.isZombie)
return;
cancel(%client.AILoop);
if (!IsObject(%client.player) || !%client.player.getState() $= "dead")
return;

InitContainerRadiusSearch(%client.player.getWorldBoxCenter(),999999,$TypeMasks::PlayerObjectType);

   while ((%potentialTarget = ContainerSearchNext()) != 0)
   {
   if (%potentialTarget != %client.player && !%potentialTarget.isZombie && %potentialTarget.getState() !$= "dead")
   %client.stepMove(%potentialTarget.getWorldBoxCenter(),1);
   }

%client.AILoop = schedule(100,0,"NormalZombieAI",%client);
return;
}

function SpawnLordAI(%trans)
{
%bot = aiConnectbyName("Zombie Lord",0);
%bot.sex = "Male";
%bot.race = "Bioderm";
%bot.setVoice("Derm3");
%bot.setSkin("Storm");
%bot.hideClient();
%bot.clearAI();
%bot.player.setDatablock("LordZombieArmor");
%bot.player.setTransform(%trans);
%bot.isZombie = true;
%bot.player.isZombie = true;
//Mount the lord images
%bot.player.mountImage(ZHead, 3);
%bot.player.mountImage(ZBack, 4);
%bot.player.mountImage(ZDummyslotImg, 5);
%bot.player.mountImage(ZDummyslotImg2, 6);
ZombieLordAI(%bot);

return %bot SPC %trans;
}

//%col is the object we hit
//%obj is the parent
function LordZombieArmor::onCollision(%this,%obj,%col,%forceVehicleNode)
{
%obj.client.LordPwn = true;
}

function ZombieLordAI(%client)
{
if (!IsObject(%client))
return;
if (!%client.isZombie)
return;
cancel(%client.AILoop);
if (!IsObject(%client.player) || !%client.player.getState() $= "dead")
return;

if (!%client.LordPwn)
{

InitContainerRadiusSearch(%client.player.getWorldBoxCenter(),$Zombie::DetectDist,$TypeMasks::PlayerObjectType);

   while ((%potentialTarget = ContainerSearchNext()) != 0)
   {
   if (%potentialTarget != %client.player && !%potentialTarget.isZombie && %potentialTarget.getState() !$= "dead")
   %client.stepMove(%potentialTarget.getWorldBoxCenter(),1);
   }
}

%client.AILoop = schedule(100,0,"ZombieLordAI",%client);
return;
}

function ConstructionGame::onAIKilled(%game, %clVictim, %clAttacker, %damageType, %implement)
{
	DefaultGame::onAIKilled(%game, %clVictim, %clAttacker, %damageType, %implement);
    %clVictim.drop();
}

//DB
datablock PlayerData(ZombieArmorAI) : LightMaleHumanArmor
{
   runForce = 60.20 * 90;
   runEnergyDrain = 0.0;
   minRunEnergy = 10;
   maxForwardSpeed = 9;
   maxBackwardSpeed = 7;
   maxSideSpeed = 7;

   jumpForce = 0;

   maxDamage = 2.8;
   minImpactSpeed = 35;
   shapeFile = "bioderm_medium.dts";
   jetEmitter = BiodermArmorJetEmitter;
   jetEffect =  BiodermArmorJetEffect;

   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData   = LightBiodermFootprint;
   decalOffset = 0.3;

   waterBreathSound = WaterBreathBiodermSound;

   damageScale[$DamageType::shotgun] = 3.0;
   damageScale[$DamageType::bazooka] = 3.0;
   damageScale[$DamageType::PBC] = 0.25;

	max[RepairKit]			= 0;
	max[Mine]			= 0;
	max[Grenade]			= 0;
	max[SmokeGrenade]			= 0;
	max[BeaconSmokeGrenade]		= 0;
	max[Blaster]			= 0;
	max[Plasma]			= 0;
	max[PlasmaAmmo]			= 0;
	max[Disc]			= 0;
	max[DiscAmmo]			= 0;
	max[SniperRifle]		= 0;
	max[GrenadeLauncher]		= 0;
	max[GrenadeLauncherAmmo]	= 0;
	max[Mortar]			= 0;
	max[MortarAmmo]			= 0;
	max[MissileLauncher]		= 0;
	max[MissileLauncherAmmo]	= 0;
	max[Chaingun]			= 0;
	max[ChaingunAmmo]		= 0;
	max[RepairGun]			= 0;
	max[CloakingPack]		= 0;
	max[SensorJammerPack]		= 0;
	max[EnergyPack]			= 0;
	max[RepairPack]			= 0;
	max[ShieldPack]			= 0;
	max[AmmoPack]			= 0;
	max[SatchelCharge]		= 0;
	max[MortarBarrelPack]		= 0;
	max[MissileBarrelPack]		= 0;
	max[AABarrelPack]		= 0;
	max[PlasmaBarrelPack]		= 0;
	max[ELFBarrelPack]		= 0;
	max[artillerybarrelpack]	= 0;
	max[InventoryDeployable]	= 0;
	max[MotionSensorDeployable]	= 0;
	max[PulseSensorDeployable]	= 0;
	max[TurretOutdoorDeployable]	= 0;
	max[TurretIndoorDeployable]	= 0;
	max[FlashGrenade]		= 0;
	max[ConcussionGrenade]		= 0;
	max[FlareGrenade]		= 0;
	max[TargetingLaser]		= 0;
	max[ELFGun]			= 0;
	max[ShockLance]			= 0;
	max[CameraGrenade]		= 0;
	max[Beacon]			= 0;
	max[flamerAmmoPack]		= 0;
	max[ParachutePack]		= 0;
	max[MedPack]			= 0;
	//Guns
	max[ConstructionTool]		= 0;
	max[MergeTool]			= 0;
	max[NerfGun]			= 0;
	max[NerfBallLauncher]		= 0;
	max[NerfBallLauncherAmmo]	= 0;
	max[SuperChaingun]		= 0;
	max[SuperChaingunAmmo]		= 0;
	max[RPChaingun]			= 0;
	max[RPChaingunAmmo]		= 0;
	max[MGClip]				= 0;
	max[LSMG]				= 0;
	max[LSMGAmmo]			= 0;
	max[LSMGClip]			= 0;
	max[snipergun]			= 0;
	max[snipergunAmmo]		= 0;
	max[Bazooka]			= 0;
	max[BazookaAmmo]			= 0;
	max[nukeme]				= 0;
	max[nukemeAmmo]			= 0;
	max[MG42]				= 0;
	max[MG42Ammo]			= 0;
	max[SPistol]			= 0;
	max[Pistol]				= 0;
	max[PistolAmmo]			= 0;
	max[Pistolclip]			= 0;
	max[flamer]				= 0;
	max[flamerAmmo]			= 0;
	max[AALauncher]			= 0;
	max[AALauncherAmmo]		= 0;
	max[melee]				= 0;
	max[SOmelee]			= 0;
	max[KriegRifle]			= 0;
	max[KriegAmmo]			= 0;
	max[Rifleclip]			= 0;
	max[Shotgun]			= 0;
	max[ShotgunAmmo]			= 0;
	max[ShotgunClip]			= 0;
	max[RShotgun]			= 0;
	max[RShotgunAmmo]			= 0;
	max[RShotgunClip]			= 0;
	max[LMissileLauncher]		= 0;
	max[LMissileLauncherAmmo]	= 0;
	max[HRPChaingun]			= 0;
	max[RPGAmmo]			= 0;
	max[RPGItem]			= 0;
	//Building parts
	max[spineDeployable]		= 0;
	max[mspineDeployable]		= 0;
	max[wWallDeployable]		= 0;
	max[floorDeployable]		= 0;
	max[WallDeployable]		= 0;
      max[DoorDeployable]           = 0;
	//Turrets
	max[TurretLaserDeployable]	= 0;
	max[TurretMissileRackDeployable]= 0;
	max[DiscTurretDeployable]	= 0;
	//Largepacks
	max[EnergizerDeployable]	= 0;
	max[TreeDeployable]		= 0;
	max[CrateDeployable]		= 0;
	max[DecorationDeployable]	= 0;
	max[LogoProjectorDeployable]	= 0;
	max[LightDeployable]		= 0;
	max[TripwireDeployable]		= 0;
	max[TelePadPack]		= 0;
	max[TurretBasePack]		= 0;
	max[LargeInventoryDeployable]	= 0;
	max[GeneratorDeployable]	= 0;
	max[SolarPanelDeployable]	= 0;
	max[SwitchDeployable]		= 0;
	max[MediumSensorDeployable]	= 0;
	max[LargeSensorDeployable]	= 0;
	max[SpySatelliteDeployable]	= 0;
	//Misc
	max[JumpadDeployable]		= 0;
	max[EscapePodDeployable]	= 0;
	max[ForceFieldDeployable]	= 0;
	max[GravityFieldDeployable]	= 0;
      max[VehiclePadPack]		= 0;

};

