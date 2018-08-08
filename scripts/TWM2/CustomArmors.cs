//MICROBUSRT ARMOR
//2 WEAPONS
//SPEC ABILITY: SHOCK LAUNCHER on S3
datablock PlayerData(MicroburstMaleHumanArmor) : MediumPlayerDamageProfile {
   emap = true;

   className = Armor;
   shapeFile = "medium_male.dts";
   cameraMaxDist = 3;
   computeCRC = true;

   debrisShapeName = "debris_player.dts";
   debris = HumanRedPlayerDebris;

   canObserve = true;
   cmdCategory = "Clients";
   cmdIcon = CMDPlayerIcon;
   cmdMiniIconName = "commander/MiniIcons/com_player_grey";

   hudImageNameFriendly[0] = "gui/hud_playertriangle";
   hudImageNameEnemy[0] = "gui/hud_playertriangle_enemy";
   hudRenderModulated[0] = true;

   hudImageNameFriendly[1] = "commander/MiniIcons/com_flag_grey";
   hudImageNameEnemy[1] = "commander/MiniIcons/com_flag_grey";
   hudRenderModulated[1] = true;
   hudRenderAlways[1] = true;
   hudRenderCenter[1] = true;
   hudRenderDistance[1] = true;

   hudImageNameFriendly[2] = "commander/MiniIcons/com_flag_grey";
   hudImageNameEnemy[2] = "commander/MiniIcons/com_flag_grey";
   hudRenderModulated[2] = true;
   hudRenderAlways[2] = true;
   hudRenderCenter[2] = true;
   hudRenderDistance[2] = true;

   // z0dd - ZOD, 10/06/02. Was missing these parameters.
   cameraDefaultFov = 90.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 120.0;

   aiAvoidThis = true;

   minLookAngle = -1.5;
   maxLookAngle = 1.5;
   maxFreelookAngle = 3.0;

   mass = 130;
   drag = 0.3;
   maxdrag = 0.5;
   density = 10;
   maxDamage = 1.6;
   maxEnergy =  80;
   repairRate = 0.0033;
   energyPerDamagePoint = 75.0; // shield energy required to block one point of damage

   rechargeRate = 0.256;
   jetForce = 0;
   underwaterJetForce = 25.22 * 130 * 1.5;
   underwaterVertJetFactor = 1.5;
   jetEnergyDrain =  1.0;
   underwaterJetEnergyDrain =  0.6;
   minJetEnergy = 1;
   maxJetHorizontalPercentage = 0.8;

   runForce = 46 * 130;
   runEnergyDrain = 0;
   minRunEnergy = 0;
   maxForwardSpeed = 12;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;

   maxUnderwaterForwardSpeed = 8.5;
   maxUnderwaterBackwardSpeed = 7.5;
   maxUnderwaterSideSpeed = 7.5;

   recoverDelay = 9;
   recoverRunForceScale = 1.2;

   // heat inc'ers and dec'ers
   heatDecayPerSec      = 1.0 / 4.0; // takes 4 seconds to clear heat sig.
   heatIncreasePerSec   = 1.0 / 3.0; // takes 3.0 seconds of constant jet to get full heat sig.

   jumpForce = 8.3 * 130;
   jumpEnergyDrain = 0;
   minJumpEnergy = 0;
   jumpSurfaceAngle = 75;
   jumpDelay = 0;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 70;
   jumpSurfaceAngle = 80;

   minJumpSpeed = 15;
   maxJumpSpeed = 25;

   horizMaxSpeed = 60;
   horizResistSpeed = 28;
   horizResistFactor = 0.32;
   maxJetForwardSpeed = 22;

   upMaxSpeed = 70;
   upResistSpeed = 30;
   upResistFactor = 0.23;

   minImpactSpeed = 45;
   speedDamageScale = 0.004;

   jetSound = ArmorJetSound;
   wetJetSound = ArmorWetJetSound;

   jetEmitter = HumanArmorJetEmitter;
   jetEffect = HumanMediumArmorJetEffect;

   boundingBox = "1.45 1.45 2.4";
   pickupRadius = 0.75;

   // damage location details
   boxNormalHeadPercentage       = 0.83;
   boxNormalTorsoPercentage      = 0.49;
   boxHeadLeftPercentage         = 0;
   boxHeadRightPercentage        = 1;
   boxHeadBackPercentage         = 0;
   boxHeadFrontPercentage        = 1;

   //Foot Prints
   decalData   = MediumMaleFootprint;
   decalOffset = 0.35;

   footPuffEmitter = LightPuffEmitter;
   footPuffNumParts = 15;
   footPuffRadius = 0.25;

   dustEmitter = LiftoffDustEmitter;

   splash = PlayerSplash;
   splashVelocity = 4.0;
   splashAngle = 67.0;
   splashFreqMod = 300.0;
   splashVelEpsilon = 0.60;
   bubbleEmitTime = 0.4;
   splashEmitter[0] = PlayerFoamDropletsEmitter;
   splashEmitter[1] = PlayerFoamEmitter;
   splashEmitter[2] = PlayerBubbleEmitter;
   mediumSplashSoundVelocity = 10.0;
   hardSplashSoundVelocity = 20.0;
   exitSplashSoundVelocity = 5.0;

   footstepSplashHeight = 0.35;
   //Footstep Sounds
   LFootSoftSound       = LFootMediumSoftSound;
   RFootSoftSound       = RFootMediumSoftSound;
   LFootHardSound       = LFootMediumHardSound;
   RFootHardSound       = RFootMediumHardSound;
   LFootMetalSound      = LFootMediumMetalSound;
   RFootMetalSound      = RFootMediumMetalSound;
   LFootSnowSound       = LFootMediumSnowSound;
   RFootSnowSound       = RFootMediumSnowSound;
   LFootShallowSound    = LFootMediumShallowSplashSound;
   RFootShallowSound    = RFootMediumShallowSplashSound;
   LFootWadingSound     = LFootMediumWadingSound;
   RFootWadingSound     = RFootMediumWadingSound;
   LFootUnderwaterSound = LFootMediumUnderwaterSound;
   RFootUnderwaterSound = RFootMediumUnderwaterSound;
   LFootBubblesSound    = LFootMediumBubblesSound;
   RFootBubblesSound    = RFootMediumBubblesSound;
   movingBubblesSound   = ArmorMoveBubblesSound;
   waterBreathSound     = WaterBreathMaleSound;

   impactSoftSound      = ImpactMediumSoftSound;
   impactHardSound      = ImpactMediumHardSound;
   impactMetalSound     = ImpactMediumMetalSound;
   impactSnowSound      = ImpactMediumSnowSound;

   skiSoftSound         = SkiAllSoftSound;
   skiHardSound         = SkiAllHardSound;
   skiMetalSound        = SkiAllMetalSound;
   skiSnowSound         = SkiAllSnowSound;

   impactWaterEasy      = ImpactMediumWaterEasySound;
   impactWaterMedium    = ImpactMediumWaterMediumSound;
   impactWaterHard      = ImpactMediumWaterHardSound;

   groundImpactMinSpeed    = 10.0;
   groundImpactShakeFreq   = "4.0 4.0 4.0";
   groundImpactShakeAmp    = "1.0 1.0 1.0";
   groundImpactShakeDuration = 0.8;
   groundImpactShakeFalloff = 10.0;

   exitingWater         = ExitingWaterMediumSound;

   maxWeapons = 2;            // Max number of different weapons the player can have
   maxGrenades = 1;           // Max number of different grenades the player can have
   maxMines = 1;              // Max number of different mines the player can have

	// Inventory restrictions
	max[RepairKit]			= 1;
	max[Mine]			    = 4;
	max[StaticGrenade]		= 6;
	max[RepairGun]			= 1;
	max[RepairPack]			= 1;
	max[AmmoPack]			= 1;
	max[SatchelCharge]		= 1;
	max[TargetingLaser]		= 1;
	max[Beacon]			= 3;

	max[ShockLance]			= 1;
	max[S3Rifle]			= 1;
	max[S3RifleAmmo]			= 10;
	max[ShadowRifle]			= 0;
    max[IonLauncher]            = 1;
    max[IonLauncherAmmo]            = 2;
    max[IonRifle]            = 1;
	max[MiniColliderCannon]			= 1;
	max[PulsePhaser]			= 1;
	max[LD06Savager]			= 1;
	max[LD06SavagerAmmo]			= 10;
	max[G17SniperRifle]			= 1;
	max[G17SniperRifleAmmo]			= 1;
	max[GrappleHook]			= 1;
	max[pistol]			= 1;
	max[pistolAmmo]			= 10;
	max[Dualpistol]			= 1;
	max[DualpistolAmmo]			= 20;
	max[SCD343]			= 0;
	max[SCD343Ammo]			= 0;
	max[Model1887]			= 1;
    max[Model1887Ammo]			= 7;
	max[DEagle]			= 1;
	max[DEagleAmmo]			= 7;
    max[melee]			= 1;
    max[BOV]			= 1;
    max[C4]			= 5;
    max[MedPack]            = 1;
	max[ConcussionGun]			= 1;
	max[ConcussionGunAmmo]			= 1;
    max[GravityAxe]			= 0;
    max[spiker]			= 1;
    max[Plasmasaber]			= 1;
	max[SA2400]			= 0;
	max[SA2400Ammo]			= 0;
	max[Javelin]			= 1;
	max[JavelinAmmo]			= 1;
	max[Stinger]			= 1;
	max[StingerAmmo]			= 1;
	max[M4A1]			= 0;
	max[M4A1Ammo]			= 0;
	max[RPG]			= 1;
	max[RPGAmmo]			= 1;
 	max[PulseRifle]			= 1;
	max[PulseRifleAmmo]			= 20;
	max[PulseSMG]			= 1;
	max[PulseSMGAmmo]			= 45;
    max[ALSWPSniperRifle]       = 1;
    max[ALSWPSniperRifleAmmo]       = 10;
    max[P90]       = 1;
    max[P90Ammo]       = 65;
    max[PlasmaTorpedo]       = 1;
	max[MRXX]			= 1;
	max[MRXXAmmo]			= 150;
    max[m93]       = 1;
    max[m93Ammo]       = 15;
    max[CrimsonHawk]       = 1;
    max[CrimsonHawkAmmo]       = 15;

	observeParameters = "0.5 4.5 4.5";
	shieldEffectScale = "0.7 0.7 1.0";
};

datablock PlayerData(MicroburstFemaleHumanArmor) : MicroburstMaleHumanArmor
{
   shapeFile = "medium_female.dts";
   waterBreathSound = WaterBreathFemaleSound;
   jetEffect =  HumanArmorJetEffect;
};

datablock PlayerData(MicroburstMaleBiodermArmor) : MicroburstMaleHumanArmor
{
   shapeFile = "bioderm_medium.dts";
   jetEmitter = BiodermArmorJetEmitter;
   jetEffect =  BiodermArmorJetEffect;

   debrisShapeName = "bio_player_debris.dts";
   debris = BiodermPlayerDebris;

   //Foot Prints
   decalData   = MediumBiodermFootprint;
   decalOffset = 0.35;

   waterBreathSound = WaterBreathBiodermSound;
};

















//SHADOW COMMANDO ARMOR
//2 WEAPONS
//SPEC ABILITY: SHADE (Short Full Armor Camo)
datablock PlayerData(ShadowCommandoMaleHumanArmor) : MediumPlayerDamageProfile {
   emap = true;

   className = Armor;
   shapeFile = "medium_male.dts";
   cameraMaxDist = 3;
   computeCRC = true;

   debrisShapeName = "debris_player.dts";
   debris = HumanRedPlayerDebris;

   canObserve = true;
   cmdCategory = "Clients";
   cmdIcon = CMDPlayerIcon;
   cmdMiniIconName = "commander/MiniIcons/com_player_grey";

   hudImageNameFriendly[0] = "gui/hud_playertriangle";
   hudImageNameEnemy[0] = "gui/hud_playertriangle_enemy";
   hudRenderModulated[0] = true;

   hudImageNameFriendly[1] = "commander/MiniIcons/com_flag_grey";
   hudImageNameEnemy[1] = "commander/MiniIcons/com_flag_grey";
   hudRenderModulated[1] = true;
   hudRenderAlways[1] = true;
   hudRenderCenter[1] = true;
   hudRenderDistance[1] = true;

   hudImageNameFriendly[2] = "commander/MiniIcons/com_flag_grey";
   hudImageNameEnemy[2] = "commander/MiniIcons/com_flag_grey";
   hudRenderModulated[2] = true;
   hudRenderAlways[2] = true;
   hudRenderCenter[2] = true;
   hudRenderDistance[2] = true;

   // z0dd - ZOD, 10/06/02. Was missing these parameters.
   cameraDefaultFov = 90.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 120.0;

   aiAvoidThis = true;

   minLookAngle = -1.5;
   maxLookAngle = 1.5;
   maxFreelookAngle = 3.0;

   mass = 130;
   drag = 0.3;
   maxdrag = 0.5;
   density = 10;
   maxDamage = 1.6;
   maxEnergy =  80;
   repairRate = 0.0033;
   energyPerDamagePoint = 75.0; // shield energy required to block one point of damage

   rechargeRate = 0.256;
   jetForce = 0;
   underwaterJetForce = 25.22 * 130 * 1.5;
   underwaterVertJetFactor = 1.5;
   jetEnergyDrain =  1.0;
   underwaterJetEnergyDrain =  0.6;
   minJetEnergy = 1;
   maxJetHorizontalPercentage = 0.8;

   runForce = 46 * 130;
   runEnergyDrain = 0;
   minRunEnergy = 0;
   maxForwardSpeed = 12;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;

   maxUnderwaterForwardSpeed = 8.5;
   maxUnderwaterBackwardSpeed = 7.5;
   maxUnderwaterSideSpeed = 7.5;

   recoverDelay = 9;
   recoverRunForceScale = 1.2;

   // heat inc'ers and dec'ers
   heatDecayPerSec      = 1.0 / 4.0; // takes 4 seconds to clear heat sig.
   heatIncreasePerSec   = 1.0 / 3.0; // takes 3.0 seconds of constant jet to get full heat sig.

   jumpForce = 8.3 * 130;
   jumpEnergyDrain = 0;
   minJumpEnergy = 0;
   jumpSurfaceAngle = 75;
   jumpDelay = 0;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 70;
   jumpSurfaceAngle = 80;

   minJumpSpeed = 15;
   maxJumpSpeed = 25;

   horizMaxSpeed = 60;
   horizResistSpeed = 28;
   horizResistFactor = 0.32;
   maxJetForwardSpeed = 22;

   upMaxSpeed = 70;
   upResistSpeed = 30;
   upResistFactor = 0.23;

   minImpactSpeed = 45;
   speedDamageScale = 0.004;

   jetSound = ArmorJetSound;
   wetJetSound = ArmorWetJetSound;

   jetEmitter = HumanArmorJetEmitter;
   jetEffect = HumanMediumArmorJetEffect;

   boundingBox = "1.45 1.45 2.4";
   pickupRadius = 0.75;

   // damage location details
   boxNormalHeadPercentage       = 0.83;
   boxNormalTorsoPercentage      = 0.49;
   boxHeadLeftPercentage         = 0;
   boxHeadRightPercentage        = 1;
   boxHeadBackPercentage         = 0;
   boxHeadFrontPercentage        = 1;

   //Foot Prints
   decalData   = MediumMaleFootprint;
   decalOffset = 0.35;

   footPuffEmitter = LightPuffEmitter;
   footPuffNumParts = 15;
   footPuffRadius = 0.25;

   dustEmitter = LiftoffDustEmitter;

   splash = PlayerSplash;
   splashVelocity = 4.0;
   splashAngle = 67.0;
   splashFreqMod = 300.0;
   splashVelEpsilon = 0.60;
   bubbleEmitTime = 0.4;
   splashEmitter[0] = PlayerFoamDropletsEmitter;
   splashEmitter[1] = PlayerFoamEmitter;
   splashEmitter[2] = PlayerBubbleEmitter;
   mediumSplashSoundVelocity = 10.0;
   hardSplashSoundVelocity = 20.0;
   exitSplashSoundVelocity = 5.0;

   footstepSplashHeight = 0.35;
   //Footstep Sounds
   LFootSoftSound       = LFootMediumSoftSound;
   RFootSoftSound       = RFootMediumSoftSound;
   LFootHardSound       = LFootMediumHardSound;
   RFootHardSound       = RFootMediumHardSound;
   LFootMetalSound      = LFootMediumMetalSound;
   RFootMetalSound      = RFootMediumMetalSound;
   LFootSnowSound       = LFootMediumSnowSound;
   RFootSnowSound       = RFootMediumSnowSound;
   LFootShallowSound    = LFootMediumShallowSplashSound;
   RFootShallowSound    = RFootMediumShallowSplashSound;
   LFootWadingSound     = LFootMediumWadingSound;
   RFootWadingSound     = RFootMediumWadingSound;
   LFootUnderwaterSound = LFootMediumUnderwaterSound;
   RFootUnderwaterSound = RFootMediumUnderwaterSound;
   LFootBubblesSound    = LFootMediumBubblesSound;
   RFootBubblesSound    = RFootMediumBubblesSound;
   movingBubblesSound   = ArmorMoveBubblesSound;
   waterBreathSound     = WaterBreathMaleSound;

   impactSoftSound      = ImpactMediumSoftSound;
   impactHardSound      = ImpactMediumHardSound;
   impactMetalSound     = ImpactMediumMetalSound;
   impactSnowSound      = ImpactMediumSnowSound;

   skiSoftSound         = SkiAllSoftSound;
   skiHardSound         = SkiAllHardSound;
   skiMetalSound        = SkiAllMetalSound;
   skiSnowSound         = SkiAllSnowSound;

   impactWaterEasy      = ImpactMediumWaterEasySound;
   impactWaterMedium    = ImpactMediumWaterMediumSound;
   impactWaterHard      = ImpactMediumWaterHardSound;

   groundImpactMinSpeed    = 10.0;
   groundImpactShakeFreq   = "4.0 4.0 4.0";
   groundImpactShakeAmp    = "1.0 1.0 1.0";
   groundImpactShakeDuration = 0.8;
   groundImpactShakeFalloff = 10.0;

   exitingWater         = ExitingWaterMediumSound;

   maxWeapons = 2;            // Max number of different weapons the player can have
   maxGrenades = 1;           // Max number of different grenades the player can have
   maxMines = 1;              // Max number of different mines the player can have

	// Inventory restrictions
	max[RepairKit]			= 1;
	max[Mine]			    = 4;
	max[StaticGrenade]		= 6;
	max[RepairGun]			= 1;
	max[RepairPack]			= 1;
	max[AmmoPack]			= 1;
	max[SatchelCharge]		= 1;
	max[TargetingLaser]		= 1;
	max[Beacon]			= 3;

    max[GravityAxe]			= 1;
	max[ShockLance]			= 1;
	max[S3Rifle]			= 1;
	max[S3RifleAmmo]			= 10;
	max[PulsePhaser]			= 1;
	max[LD06Savager]			= 1;
	max[LD06SavagerAmmo]			= 10;
	max[ShadowRifle]			= 1;
	max[G17SniperRifle]			= 1;
	max[G17SniperRifleAmmo]			= 1;
	max[GrappleHook]			= 1;
	max[pistol]			= 1;
	max[pistolAmmo]			= 10;
	max[Dualpistol]			= 1;
	max[DualpistolAmmo]			= 20;
	max[DEagle]			= 1;
	max[DEagleAmmo]			= 7;
	max[MiniColliderCannon]			= 0;
	max[M4A1]			= 0;
	max[M4A1Ammo]			= 0;
    max[melee]			= 1;
    max[BOV]			= 1;
    max[Plasmasaber]			= 1;
    max[C4]			= 5;
    max[MedPack]            = 1;
	max[MRXX]			= 1;
	max[MRXXAmmo]			= 150;
	max[SA2400]			= 0;
	max[SA2400Ammo]			= 0;
    max[RPG]       = 1;
    max[RPGAmmo]       = 1;
	max[Javelin]			= 1;
	max[JavelinAmmo]			= 1;
	max[Stinger]			= 1;
	max[StingerAmmo]			= 1;
 	max[PulseRifle]			= 1;
	max[PulseRifleAmmo]			= 20;
	max[PulseSMG]			= 1;
	max[PulseSMGAmmo]			= 45;
	max[SCD343]			= 0;
	max[SCD343Ammo]			= 0;
    max[ALSWPSniperRifle]       = 1;
    max[ALSWPSniperRifleAmmo]       = 10;
    max[P90]       = 1;
    max[P90Ammo]       = 65;
    max[PlasmaTorpedo]       = 1;
    max[m93]       = 1;
    max[m93Ammo]       = 15;
    max[CrimsonHawk]       = 1;
    max[CrimsonHawkAmmo]       = 15;
    max[spiker]			= 1;
	max[Model1887]			= 1;
 max[Model1887Ammo]			= 7;

	observeParameters = "0.5 4.5 4.5";
	shieldEffectScale = "0.7 0.7 1.0";
};

datablock PlayerData(ShadowCommandoFemaleHumanArmor) : ShadowCommandoMaleHumanArmor
{
   shapeFile = "medium_female.dts";
   waterBreathSound = WaterBreathFemaleSound;
   jetEffect =  HumanArmorJetEffect;
};

datablock PlayerData(ShadowCommandoMaleBiodermArmor) : ShadowCommandoMaleHumanArmor
{
   shapeFile = "bioderm_medium.dts";
   jetEmitter = BiodermArmorJetEmitter;
   jetEffect =  BiodermArmorJetEffect;

   debrisShapeName = "bio_player_debris.dts";
   debris = BiodermPlayerDebris;

   //Foot Prints
   decalData   = MediumBiodermFootprint;
   decalOffset = 0.35;

   waterBreathSound = WaterBreathBiodermSound;
};





























//SHADOW COMMANDO ARMOR
//2 WEAPONS
datablock PlayerData(ShadowMaleHumanArmor) : MediumPlayerDamageProfile {
   emap = true;

   className = Armor;
   shapeFile = "medium_male.dts";
   cameraMaxDist = 3;
   computeCRC = true;

   debrisShapeName = "debris_player.dts";
   debris = HumanRedPlayerDebris;

   canObserve = true;
   cmdCategory = "Clients";
   cmdIcon = CMDPlayerIcon;
   cmdMiniIconName = "commander/MiniIcons/com_player_grey";

   hudImageNameFriendly[0] = "gui/hud_playertriangle";
   hudImageNameEnemy[0] = "gui/hud_playertriangle_enemy";
   hudRenderModulated[0] = true;

   hudImageNameFriendly[1] = "commander/MiniIcons/com_flag_grey";
   hudImageNameEnemy[1] = "commander/MiniIcons/com_flag_grey";
   hudRenderModulated[1] = true;
   hudRenderAlways[1] = true;
   hudRenderCenter[1] = true;
   hudRenderDistance[1] = true;

   hudImageNameFriendly[2] = "commander/MiniIcons/com_flag_grey";
   hudImageNameEnemy[2] = "commander/MiniIcons/com_flag_grey";
   hudRenderModulated[2] = true;
   hudRenderAlways[2] = true;
   hudRenderCenter[2] = true;
   hudRenderDistance[2] = true;

   // z0dd - ZOD, 10/06/02. Was missing these parameters.
   cameraDefaultFov = 90.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 120.0;

   aiAvoidThis = true;

   minLookAngle = -1.5;
   maxLookAngle = 1.5;
   maxFreelookAngle = 3.0;

   mass = 130;
   drag = 0.3;
   maxdrag = 0.5;
   density = 10;
   maxDamage = 1.6;
   maxEnergy =  80;
   repairRate = 0.0033;
   energyPerDamagePoint = 75.0; // shield energy required to block one point of damage

   rechargeRate = 0.256;
   jetForce = 0;
   underwaterJetForce = 25.22 * 130 * 1.5;
   underwaterVertJetFactor = 1.5;
   jetEnergyDrain =  1.0;
   underwaterJetEnergyDrain =  0.6;
   minJetEnergy = 1;
   maxJetHorizontalPercentage = 0.8;

   runForce = 46 * 130;
   runEnergyDrain = 0;
   minRunEnergy = 0;
   maxForwardSpeed = 12;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;

   maxUnderwaterForwardSpeed = 8.5;
   maxUnderwaterBackwardSpeed = 7.5;
   maxUnderwaterSideSpeed = 7.5;

   recoverDelay = 9;
   recoverRunForceScale = 1.2;

   // heat inc'ers and dec'ers
   heatDecayPerSec      = 1.0 / 4.0; // takes 4 seconds to clear heat sig.
   heatIncreasePerSec   = 1.0 / 3.0; // takes 3.0 seconds of constant jet to get full heat sig.

   jumpForce = 8.3 * 130;
   jumpEnergyDrain = 0;
   minJumpEnergy = 0;
   jumpSurfaceAngle = 75;
   jumpDelay = 0;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 70;
   jumpSurfaceAngle = 80;

   minJumpSpeed = 15;
   maxJumpSpeed = 25;

   horizMaxSpeed = 60;
   horizResistSpeed = 28;
   horizResistFactor = 0.32;
   maxJetForwardSpeed = 22;

   upMaxSpeed = 70;
   upResistSpeed = 30;
   upResistFactor = 0.23;

   minImpactSpeed = 45;
   speedDamageScale = 0.004;

   jetSound = ArmorJetSound;
   wetJetSound = ArmorWetJetSound;

   jetEmitter = HumanArmorJetEmitter;
   jetEffect = HumanMediumArmorJetEffect;

   boundingBox = "1.45 1.45 2.4";
   pickupRadius = 0.75;

   // damage location details
   boxNormalHeadPercentage       = 0.83;
   boxNormalTorsoPercentage      = 0.49;
   boxHeadLeftPercentage         = 0;
   boxHeadRightPercentage        = 1;
   boxHeadBackPercentage         = 0;
   boxHeadFrontPercentage        = 1;

   //Foot Prints
   decalData   = MediumMaleFootprint;
   decalOffset = 0.35;

   footPuffEmitter = LightPuffEmitter;
   footPuffNumParts = 15;
   footPuffRadius = 0.25;

   dustEmitter = LiftoffDustEmitter;

   splash = PlayerSplash;
   splashVelocity = 4.0;
   splashAngle = 67.0;
   splashFreqMod = 300.0;
   splashVelEpsilon = 0.60;
   bubbleEmitTime = 0.4;
   splashEmitter[0] = PlayerFoamDropletsEmitter;
   splashEmitter[1] = PlayerFoamEmitter;
   splashEmitter[2] = PlayerBubbleEmitter;
   mediumSplashSoundVelocity = 10.0;
   hardSplashSoundVelocity = 20.0;
   exitSplashSoundVelocity = 5.0;

   footstepSplashHeight = 0.35;
   //Footstep Sounds
   LFootSoftSound       = LFootMediumSoftSound;
   RFootSoftSound       = RFootMediumSoftSound;
   LFootHardSound       = LFootMediumHardSound;
   RFootHardSound       = RFootMediumHardSound;
   LFootMetalSound      = LFootMediumMetalSound;
   RFootMetalSound      = RFootMediumMetalSound;
   LFootSnowSound       = LFootMediumSnowSound;
   RFootSnowSound       = RFootMediumSnowSound;
   LFootShallowSound    = LFootMediumShallowSplashSound;
   RFootShallowSound    = RFootMediumShallowSplashSound;
   LFootWadingSound     = LFootMediumWadingSound;
   RFootWadingSound     = RFootMediumWadingSound;
   LFootUnderwaterSound = LFootMediumUnderwaterSound;
   RFootUnderwaterSound = RFootMediumUnderwaterSound;
   LFootBubblesSound    = LFootMediumBubblesSound;
   RFootBubblesSound    = RFootMediumBubblesSound;
   movingBubblesSound   = ArmorMoveBubblesSound;
   waterBreathSound     = WaterBreathMaleSound;

   impactSoftSound      = ImpactMediumSoftSound;
   impactHardSound      = ImpactMediumHardSound;
   impactMetalSound     = ImpactMediumMetalSound;
   impactSnowSound      = ImpactMediumSnowSound;

   skiSoftSound         = SkiAllSoftSound;
   skiHardSound         = SkiAllHardSound;
   skiMetalSound        = SkiAllMetalSound;
   skiSnowSound         = SkiAllSnowSound;

   impactWaterEasy      = ImpactMediumWaterEasySound;
   impactWaterMedium    = ImpactMediumWaterMediumSound;
   impactWaterHard      = ImpactMediumWaterHardSound;

   groundImpactMinSpeed    = 10.0;
   groundImpactShakeFreq   = "4.0 4.0 4.0";
   groundImpactShakeAmp    = "1.0 1.0 1.0";
   groundImpactShakeDuration = 0.8;
   groundImpactShakeFalloff = 10.0;

   exitingWater         = ExitingWaterMediumSound;

   maxWeapons = 2;            // Max number of different weapons the player can have
   maxGrenades = 1;           // Max number of different grenades the player can have
   maxMines = 1;              // Max number of different mines the player can have

	// Inventory restrictions
	max[RepairKit]			= 1;
	max[Mine]			    = 4;
	max[StaticGrenade]		= 6;
	max[RepairGun]			= 1;
	max[RepairPack]			= 1;
	max[AmmoPack]			= 1;
	max[SatchelCharge]		= 1;
	max[TargetingLaser]		= 1;
	max[Beacon]			= 3;

    max[GravityAxe]			= 1;
	max[ShockLance]			= 1;
	max[S3Rifle]			= 1;
	max[S3RifleAmmo]			= 10;
	max[PulsePhaser]			= 1;
	max[LD06Savager]			= 1;
	max[LD06SavagerAmmo]			= 10;
	max[ShadowRifle]			= 0;
	max[G17SniperRifle]			= 1;
	max[G17SniperRifleAmmo]			= 1;
	max[GrappleHook]			= 1;
	max[pistol]			= 1;
	max[pistolAmmo]			= 10;
	max[Dualpistol]			= 1;
	max[DualpistolAmmo]			= 20;
	max[DEagle]			= 1;
	max[DEagleAmmo]			= 7;
	max[MiniColliderCannon]			= 0;
	max[M4A1]			= 1;
	max[M4A1Ammo]			= 30;
    max[melee]			= 1;
    max[BOV]			= 1;
    max[Plasmasaber]			= 1;
    max[C4]			= 5;
    max[MedPack]            = 1;
	max[SA2400]			= 1;
	max[SA2400Ammo]			= 21;
    max[RPG]       = 1;
    max[RPGAmmo]       = 1;
	max[Javelin]			= 1;
	max[JavelinAmmo]			= 1;
	max[Stinger]			= 1;
	max[StingerAmmo]			= 1;
 	max[PulseRifle]			= 1;
	max[PulseRifleAmmo]			= 20;
	max[PulseSMG]			= 1;
	max[PulseSMGAmmo]			= 45;
	max[SCD343]			= 1;
	max[SCD343Ammo]			= 1;
    max[ALSWPSniperRifle]       = 1;
    max[ALSWPSniperRifleAmmo]       = 10;
    max[P90]       = 1;
    max[P90Ammo]       = 65;
    max[PlasmaTorpedo]       = 1;
    max[m93]       = 1;
    max[m93Ammo]       = 15;
    max[CrimsonHawk]       = 1;
    max[CrimsonHawkAmmo]       = 15;
	max[MRXX]			= 1;
	max[MRXXAmmo]			= 150;
	max[Model1887]			= 1;
    max[spiker]			= 1;
 max[Model1887Ammo]			= 7;
    
	observeParameters = "0.5 4.5 4.5";
	shieldEffectScale = "0.7 0.7 1.0";
};

datablock PlayerData(ShadowFemaleHumanArmor) : ShadowMaleHumanArmor
{
   shapeFile = "medium_female.dts";
   waterBreathSound = WaterBreathFemaleSound;
   jetEffect =  HumanArmorJetEffect;
};

datablock PlayerData(ShadowMaleBiodermArmor) : ShadowMaleHumanArmor
{
   shapeFile = "bioderm_medium.dts";
   jetEmitter = BiodermArmorJetEmitter;
   jetEffect =  BiodermArmorJetEffect;

   debrisShapeName = "bio_player_debris.dts";
   debris = BiodermPlayerDebris;

   //Foot Prints
   decalData   = MediumBiodermFootprint;
   decalOffset = 0.35;

   waterBreathSound = WaterBreathBiodermSound;
};














//RETURN TO THE CLASSICS!!
//NALCIDIC ARMOR
//2 WEAPONS
//ABILITY: GAUSSIAN FIRE JETPACK



datablock ParticleData(FlammerArmorJetParticle)
{
   dragCoefficient      = 0.0;
   gravityCoefficient   = 0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 500;
   lifetimeVarianceMS   = 0;
   textureName          = "particleTest";
   colors[0]     = "0.6 0.2 0.0 1.0";
   colors[1]     = "0.4 0.0 0.0 0";
   sizes[0]      = 0.40;
   sizes[1]      = 0.15;
};

datablock ParticleEmitterData(FlammerArmorJetEmitter)
{
   ejectionPeriodMS = 3;
   periodVarianceMS = 0;
   ejectionVelocity = 10;
   velocityVariance = 2.9;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 5;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "FlammerArmorJetParticle";
};

datablock PlayerData(FlameMaleHumanArmor) : MediumPlayerDamageProfile
{
   emap = true;

   className = Armor;
   shapeFile = "medium_male.dts";
   cameraMaxDist = 3;
   computeCRC = true;

   debrisShapeName = "debris_player.dts";
   debris = HumanRedPlayerDebris;

   canObserve = true;
   cmdCategory = "Clients";
   cmdIcon = CMDPlayerIcon;
   cmdMiniIconName = "commander/MiniIcons/com_player_grey";

   hudImageNameFriendly[0] = "gui/hud_playertriangle";
   hudImageNameEnemy[0] = "gui/hud_playertriangle_enemy";
   hudRenderModulated[0] = true;

   hudImageNameFriendly[1] = "commander/MiniIcons/com_flag_grey";
   hudImageNameEnemy[1] = "commander/MiniIcons/com_flag_grey";
   hudRenderModulated[1] = true;
   hudRenderAlways[1] = true;
   hudRenderCenter[1] = true;
   hudRenderDistance[1] = true;

   hudImageNameFriendly[2] = "commander/MiniIcons/com_flag_grey";
   hudImageNameEnemy[2] = "commander/MiniIcons/com_flag_grey";
   hudRenderModulated[2] = true;
   hudRenderAlways[2] = true;
   hudRenderCenter[2] = true;
   hudRenderDistance[2] = true;

   aiAvoidThis = true;

   minLookAngle = -1.5;
   maxLookAngle = 1.5;
   maxFreelookAngle = 3.0;

   mass = 70;
   drag = 0.3;
   maxdrag = 0.5;
   density = 10;
   maxDamage = 1.5;
   maxEnergy =  100;
   repairRate = 0.0053;
   energyPerDamagePoint = 75.0; // shield energy required to block one point of damage

   rechargeRate = 0.456;
   jetForce = 21.22 * 230;
   underwaterJetForce = 25.22 * 130 * 1.5;
   underwaterVertJetFactor = 1.5;
   jetEnergyDrain = 4.0;
   underwaterJetEnergyDrain =  1.0;
   minJetEnergy = 10;
   maxJetHorizontalPercentage = 0.8;

   runForce = 60 * 150;
   runEnergyDrain = 0;
   minRunEnergy = 0;
   maxForwardSpeed = 18;
   maxBackwardSpeed = 18;
   maxSideSpeed = 18;

   maxUnderwaterForwardSpeed = 10.5;
   maxUnderwaterBackwardSpeed = 9.5;
   maxUnderwaterSideSpeed = 9.5;

   recoverDelay = 4;
   recoverRunForceScale = 0.7;

   // heat inc'ers and dec'ers
   heatDecayPerSec      = 1.0 / 5.0; // takes 4 seconds to clear heat sig.
   heatIncreasePerSec   = 1.0 / 2.0; // takes 3.0 seconds of constant jet to get full heat sig.

   jumpForce = 8.3 * 130;
   jumpEnergyDrain = 0;
   minJumpEnergy = 0;
   jumpSurfaceAngle = 75;
   jumpDelay = 0;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 85;
   jumpSurfaceAngle = 85;

   minJumpSpeed = 25;
   maxJumpSpeed = 35;

   horizMaxSpeed = 70;
   horizResistSpeed = 28;
   horizResistFactor = 0.32;
   maxJetForwardSpeed = 18;

   upMaxSpeed = 80;
   upResistSpeed = 30;
   upResistFactor = 0.23;

   minImpactSpeed = 45;
   speedDamageScale = 0.006;

   jetSound = ArmorJetSound;
   wetJetSound = ArmorWetJetSound;

   jetEmitter = FlammerArmorJetEmitter; //Pyro jets
   jetEffect = HumanMediumArmorJetEffect;

   boundingBox = "1.45 1.45 2.4";
   pickupRadius = 0.75;

   // damage location details
   boxNormalHeadPercentage       = 0.83;
   boxNormalTorsoPercentage      = 0.49;
   boxHeadLeftPercentage         = 0;
   boxHeadRightPercentage        = 1;
   boxHeadBackPercentage         = 0;
   boxHeadFrontPercentage        = 1;

   //Foot Prints
   decalData   = MediumMaleFootprint;
   decalOffset = 0.35;

   footPuffEmitter = LightPuffEmitter;
   footPuffNumParts = 15;
   footPuffRadius = 0.25;

   dustEmitter = LiftoffDustEmitter;

   splash = PlayerSplash;
   splashVelocity = 4.0;
   splashAngle = 67.0;
   splashFreqMod = 300.0;
   splashVelEpsilon = 0.60;
   bubbleEmitTime = 0.4;
   splashEmitter[0] = PlayerFoamDropletsEmitter;
   splashEmitter[1] = PlayerFoamEmitter;
   splashEmitter[2] = PlayerBubbleEmitter;
   mediumSplashSoundVelocity = 10.0;
   hardSplashSoundVelocity = 20.0;
   exitSplashSoundVelocity = 5.0;

   footstepSplashHeight = 0.35;
   //Footstep Sounds
   LFootSoftSound       = LFootMediumSoftSound;
   RFootSoftSound       = RFootMediumSoftSound;
   LFootHardSound       = LFootMediumHardSound;
   RFootHardSound       = RFootMediumHardSound;
   LFootMetalSound      = LFootMediumMetalSound;
   RFootMetalSound      = RFootMediumMetalSound;
   LFootSnowSound       = LFootMediumSnowSound;
   RFootSnowSound       = RFootMediumSnowSound;
   LFootShallowSound    = LFootMediumShallowSplashSound;
   RFootShallowSound    = RFootMediumShallowSplashSound;
   LFootWadingSound     = LFootMediumWadingSound;
   RFootWadingSound     = RFootMediumWadingSound;
   LFootUnderwaterSound = LFootMediumUnderwaterSound;
   RFootUnderwaterSound = RFootMediumUnderwaterSound;
   LFootBubblesSound    = LFootMediumBubblesSound;
   RFootBubblesSound    = RFootMediumBubblesSound;
   movingBubblesSound   = ArmorMoveBubblesSound;
   waterBreathSound     = WaterBreathMaleSound;

   impactSoftSound      = ImpactMediumSoftSound;
   impactHardSound      = ImpactMediumHardSound;
   impactMetalSound     = ImpactMediumMetalSound;
   impactSnowSound      = ImpactMediumSnowSound;

   skiSoftSound         = SkiAllSoftSound;
   skiHardSound         = SkiAllHardSound;
   skiMetalSound        = SkiAllMetalSound;
   skiSnowSound         = SkiAllSnowSound;

   impactWaterEasy      = ImpactMediumWaterEasySound;
   impactWaterMedium    = ImpactMediumWaterMediumSound;
   impactWaterHard      = ImpactMediumWaterHardSound;

   groundImpactMinSpeed    = 10.0;
   groundImpactShakeFreq   = "4.0 4.0 4.0";
   groundImpactShakeAmp    = "1.0 1.0 1.0";
   groundImpactShakeDuration = 0.8;
   groundImpactShakeFalloff = 10.0;

   exitingWater         = ExitingWaterMediumSound;

   maxWeapons = 2;            // Max number of different weapons the player can have
   maxGrenades = 1;           // Max number of different grenades the player can have
   maxMines = 1;              // Max number of different mines the player can have

   damageScale[$DamageType::plasma] = 0.2;
   damageScale[$DamageType::burn] = 0.1;

   // Inventory restrictions
	max[ShockLance]			= 1;
	max[S3Rifle]			= 1;
	max[S3RifleAmmo]			= 10;
	max[PulsePhaser]			= 1;
	max[LD06Savager]			= 1;
	max[LD06SavagerAmmo]			= 10;
	max[GrappleHook]			= 0;
	max[pistol]			= 1;
	max[pistolAmmo]			= 10;
	max[Dualpistol]			= 1;
	max[DualpistolAmmo]			= 20;
	max[DEagle]			= 1;
	max[DEagleAmmo]			= 7;
	max[M4A1]			= 1;
	max[M4A1Ammo]			= 30;
    max[melee]			= 1;
    max[BOV]			= 1;
    max[Plasmasaber]			= 1;
    max[C4]			= 5;
    max[MedPack]            = 1;
	max[SA2400]			= 1;
	max[SA2400Ammo]			= 21;
    max[RPG]       = 1;
    max[RPGAmmo]       = 1;
    max[m93]       = 1;
    max[m93Ammo]       = 15;
    max[CrimsonHawk]       = 1;
    max[CrimsonHawkAmmo]       = 15;
	max[flamer]				= 1;
	max[flamerAmmo]			= 100;
    max[spiker]			= 0;
   // -END

   observeParameters = "0.5 4.5 4.5";

   shieldEffectScale = "0.7 0.7 1.0";
};

datablock PlayerData(FlameFemaleHumanArmor) : FlameMaleHumanArmor
{
   shapeFile = "medium_female.dts";
   waterBreathSound = WaterBreathFemaleSound;
   jetEffect =  HumanMediumArmorJetEffect;
};

datablock PlayerData(FlameMaleBiodermArmor) : FlameMaleHumanArmor
{
   shapeFile = "bioderm_medium.dts";
   jetEmitter = FlammerArmorJetEmitter;
   jetEffect =  BiodermArmorJetEffect;


   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData   = LightBiodermFootprint;
   decalOffset = 0.3;

   waterBreathSound = WaterBreathBiodermSound;
};
