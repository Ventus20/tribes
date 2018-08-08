//$Zombie::TurningSpeed = 100;
$Zombie::ForwardSpeed = 750;
$Zombie::FForwardSpeed = 1500;
$Zombie::LForwardSpeed = 4000;
$Zombie::DForwardSpeed = 1200;
$Zombie::RForwardSpeed = 1500;

datablock PlayerData(ZombieArmor) : LightMaleHumanArmor
{
   runForce = 60.20 * 90;
   runEnergyDrain = 0.0;
   minRunEnergy = 10;
   maxForwardSpeed = 9;
   maxBackwardSpeed = 7;
   maxSideSpeed = 7;

   jumpForce = 14.0 * 90;

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

   damageScale[$DamageType::M1700] = 3.0;

	max[RepairKit]			= 0;
	max[Mine]			= 0;
	max[Grenade]			= 0;
};

datablock PlayerData(FZombieArmor) : LightMaleBiodermArmor
{
   maxDamage = 1.0;
   minImpactSpeed = 50;
   speedDamageScale = 0.015;

   damageScale[$DamageType::M1700] = 2.0;

	max[RepairKit]			= 0;
	max[Mine]			= 0;
	max[Grenade]			= 0;
};

datablock AudioProfile(ZLordFootSound)
{
   filename    = "fx/weapons/grenade_explode_UW.wav";
   description = AudioBomb3d;
   preload = true;
};

datablock AudioProfile(HZLordFootSound)
{
   filename    = "fx/weapons/SpinFusor_explode_UW.wav";
   description = AudioBomb3d;
   preload = true;
};

datablock PlayerData(LordZombieArmor) : HeavyMaleBiodermArmor
{
   shapefile = "TR2medium_male.dts";
   mass = 500;
   maxDamage = 18.0;
   minImpactSpeed = 50;
   speedDamageScale = 0.015;
   boundingBox = "2.9 2.9 4.8";

   underwaterJetForce = 10;

   LFootSoftSound       = ZLordFootSound;
   RFootSoftSound       = ZLordFootSound;
   LFootHardSound       = HZLordFootSound;
   RFootHardSound       = HZLordFootSound;
   LFootMetalSound      = ZLordFootSound;
   RFootMetalSound      = ZLordFootSound;
   LFootSnowSound       = ZLordFootSound;
   RFootSnowSound       = ZLordFootSound;

   damageScale[$DamageType::M1700] = 1.5;

	max[RepairKit]			= 0;
	max[Mine]			= 0;
	max[Grenade]			= 0;
};

datablock PlayerData(DemonZombieArmor) : LightMaleHumanArmor
{
   boundingBox = "1.63 1.63 2.6";
   maxDamage = 4.0;
   minImpactSpeed = 35;
   shapeFile = "bioderm_heavy.dts";

   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData   = HeavyBiodermFootprint;
   decalOffset = 0.4;

   waterBreathSound = WaterBreathBiodermSound;

   damageScale[$DamageType::M1700] = 2.0;

	max[RepairKit]			= 0;
	max[Mine]				= 0;
	max[Grenade]			= 0;
};

datablock PlayerData(RapierZombieArmor) : FZombieArmor
{
   minImpactSpeed = 75;
   maxDamage = 1.0;
   maxEnergy =  80;
   repairRate = 0.0033;
   energyPerDamagePoint = 75.0; // shield energy required to block one point of damage

   rechargeRate = 0.256;
   jetForce = 25.22 * 130 * 1.5;
   underwaterJetForce = 25.22 * 130 * 1.5;
   underwaterVertJetFactor = 1.5;
   jetEnergyDrain =  1.0;
   underwaterJetEnergyDrain =  0.6;
   minJetEnergy = 1;
   maxJetHorizontalPercentage = 0.8;

   boundingBox = "2.0 2.0 1.2";
};

datablock PlayerData(DemonMotherZombieArmor) : LightMaleHumanArmor
{
   boundingBox = "1.5 1.5 2.6";
   maxDamage = 9.0;
   minImpactSpeed = 35;
   shapeFile = "medium_female.dts";

   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData   = HeavyBiodermFootprint;
   decalOffset = 0.4;

   waterBreathSound = WaterBreathBiodermSound;

   damageScale[$DamageType::M1700] = 2.0;

	max[RepairKit]			= 0;
	max[Mine]				= 0;
	max[Grenade]			= 0;
};

//NEW TYPES (1.2)
//SHIFTER
datablock PlayerData(ShifterZombieArmor) : LightMaleHumanArmor
{
   runForce = 60.20 * 90;
   runEnergyDrain = 0.0;
   minRunEnergy = 10;
   maxForwardSpeed = 9;
   maxBackwardSpeed = 7;
   maxSideSpeed = 7;

   jumpForce = 14.0 * 90;

   maxDamage = 2.8;
   minImpactSpeed = 35;
   shapeFile = "bioderm_light.dts";
   jetEmitter = BiodermArmorJetEmitter;
   jetEffect =  BiodermArmorJetEffect;

   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData   = LightBiodermFootprint;
   decalOffset = 0.3;

   waterBreathSound = WaterBreathBiodermSound;

   damageScale[$DamageType::M1700] = 3.0;

	max[RepairKit]			= 0;
	max[Mine]			= 0;
	max[Grenade]			= 0;

};

//SUMMONER
datablock PlayerData(SummonerZombieArmor) : LightMaleHumanArmor
{
   runForce = 60.20 * 90;
   runEnergyDrain = 0.0;
   minRunEnergy = 10;
   maxForwardSpeed = 9;
   maxBackwardSpeed = 7;
   maxSideSpeed = 7;

   jumpForce = 14.0 * 90;

   maxDamage = 2.8;
   minImpactSpeed = 35;
   shapeFile = "light_male.dts";
   jetEmitter = BiodermArmorJetEmitter;
   jetEffect =  BiodermArmorJetEffect;

   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData   = LightBiodermFootprint;
   decalOffset = 0.3;

   waterBreathSound = WaterBreathBiodermSound;

   damageScale[$DamageType::M1700] = 3.0;

	max[RepairKit]			= 0;
	max[Mine]			= 0;
	max[Grenade]			= 0;
};

//SNIPER
datablock ShapeBaseImageData(ZSniperImage1) {
   shapeFile = "weapon_sniper.dts";
   emap = true;
   armThread = looksn;
};

datablock ShapeBaseImageData(ZSniperImage2) {
   shapeFile = "weapon_targeting.dts";
   offset = "0.0 1.0 0.41";
   rotation = "90 0 0 90";
   armThread = looksn;
   emap = true;
};


//DEMON ULTRA
datablock PlayerData(DemonUltraZombieArmor) : LightMaleHumanArmor
{
   runForce = 60.20 * 90;
   runEnergyDrain = 0.0;
   minRunEnergy = 10;
   maxForwardSpeed = 9;
   maxBackwardSpeed = 7;
   maxSideSpeed = 7;

   jumpForce = 14.0 * 90;

   maxDamage = 2.8;
   minImpactSpeed = 35;
   shapeFile = "heavy_male.dts";
   jetEmitter = BiodermArmorJetEmitter;
   jetEffect =  BiodermArmorJetEffect;

   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData   = LightBiodermFootprint;
   decalOffset = 0.3;

   waterBreathSound = WaterBreathBiodermSound;

   damageScale[$DamageType::M1700] = 3.0;

	max[RepairKit]			= 0;
	max[Mine]			= 0;
	max[Grenade]			= 0;
};

datablock PlayerData(SSZombieArmor) : LightMaleBiodermArmor
{
   maxDamage = 1.0;
   minImpactSpeed = 50;
   speedDamageScale = 0.015;

   damageScale[$DamageType::M1700] = 2.0;

	max[RepairKit]			= 0;
	max[Mine]			= 0;
	max[Grenade]			= 0;
};

datablock ShapeBaseImageData(SSZombImage2) {
   shapeFile = "turret_aa_large.dts";
   offset = "0.4 0.0 0.2";
   rotation = "0 0 0 1";
   emap = true;
};

datablock ShapeBaseImageData(SSZombImage3) {
   shapeFile = "turret_aa_large.dts";
   offset = "-0.8 0.0 0.2";
   rotation = "0 0 0 1";
   emap = true;
};

datablock PlayerData(WraithZombieArmor) : LightMaleHumanArmor
{
   boundingBox = "1.63 1.63 2.6";
   maxDamage = 4.0;
   minImpactSpeed = 35;
   shapeFile = "bioderm_heavy.dts";
   
   //shields mo-fo's
   shieldHealthCharge = 0.05;
   maxShieldLevel = 4.0;

   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData   = HeavyBiodermFootprint;
   decalOffset = 0.4;

   waterBreathSound = WaterBreathBiodermSound;

   damageScale[$DamageType::M1700] = 2.0;

	max[RepairKit]			= 0;
	max[Mine]				= 0;
	max[Grenade]			= 0;
};


//DEATH
datablock AudioProfile(ZombieDeathSound1)
{
   filename    = "voice/Derm3/avo.deathcry_01.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(ZombieDeathSound2)
{
   filename    = "voice/Derm2/avo.deathcry_01.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(ZombieDeathSound3)
{
   filename    = "voice/Derm1/avo.deathcry_01.wav";
   description = AudioClose3d;
   preload = true;
};
