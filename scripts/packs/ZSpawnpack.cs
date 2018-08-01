//---------------------------------------------------------
// Zombie Spawn Point
//---------------------------------------------------------

//GLOBAL VARIBLES
$zombie::detectDist = 9999;
$zombie::lungDist = 10;
$zombie::LKillDist = 5;
$zombie::Rupvec = 750;
$zombie::killpoints = 1;
$zombie::sniperrange = 400; //default
$zombie::falldieheight = -500;
$Zombie::RAAMThread = "cel1";
$zombie::team = 30;
$zombie::Traitorteam = 29; //Ally Zombies... coming soon.



// AUDIO DATABLOCKS
datablock AudioProfile(ZombieMoan)
{
   filename    = "fx/environment/growl3.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(ZombieHOWL)
{
   filename    = "fx/environment/Yeti_Howl1.wav";
   description = AudioBomb3d;
   preload = true;
};

datablock AudioProfile(SniperShotExpSound)
{
   filename    = "fx/weapons/cg_soft4.wav";
   description = AudioClose3d;
   preload = true;
};



// ZOMBIE IMAGE DATABLOCKS
datablock ShapeBaseImageData(ZHead)
{
   shapeFile = "bioderm_heavy.dts";
   emap = false;
   mountPoint = 1;
   offset = "-0.75 0.25 -1.5";
   rotation = "1 0 0 15";
};

datablock ShapeBaseImageData(ZBack)
{
   shapeFile = "bioderm_medium.dts";
   emap = false;
   mountPoint = 1;
   offset = "0 0.25 -1.25";
   rotation = "-1 0 0 10";
};

datablock ShapeBaseImageData(ZDummyslotImg)
{
   shapeFile = "turret_muzzlepoint.dts";
   emap = false;
};

datablock ShapeBaseImageData(ZSniperImage) {
   shapeFile = "weapon_sniper.dts";
   emap = true;
   armThread = looksn;
};

//RAAM
datablock ShapeBaseImageData(ZMG42BaseImage)
{
   shapeFile = "weapon_sniper.dts";
   emap = true;
};

datablock ShapeBaseImageData(RAAMSAWImage1)
{
   shapeFile = "weapon_missile.dts";
   rotation = "0 0 1 180";
   offset = "0.01 0.04 0.0"; // L/R - F/B - T/B
};

datablock ShapeBaseImageData(RAAMSAWImage2)
{
   shapeFile = "ammo_mortar.dts";
   rotation = "0 0 1 90";
   offset = "-0.06 -0.23 0.25"; // L/R - F/B - T/B
};

datablock ShapeBaseImageData(RAAMSAWImage3)
{
   shapeFile = "ammo_chaingun.dts";
   offset = "0.08 0.4 -0.13"; // L/R - F/B - T/B
};
//END
datablock ShapeBaseImageData(ZDummyslotImg2)
{
   shapeFile = "turret_muzzlepoint.dts";
   emap = false;
   offset = "-1.5 0 0";
};

datablock ShapeBaseImageData(ZWingImage)
{
   shapeFile = "flag.dts";
   mountPoint = 1;

   offset = "0 0 0"; // L/R - F/B - T/B
   rotation = "0 1 0 90"; // L/R - F/B - T/B
};

datablock ShapeBaseImageData(ZWingImage2)
{
   shapeFile = "flag.dts";
   mountPoint = 1;

   offset = "0 0 0"; // L/R - F/B - T/B
   rotation = "0 -1 0 90"; // L/R - F/B - T/B
};

datablock ShapeBaseImageData(ZWingAltImage)
{
   shapeFile = "flag.dts";
   mountPoint = 1;

   offset = "0 0 0"; // L/R - F/B - T/B
   rotation = "-0.5 2 0 35"; // L/R - F/B - T/B
};

datablock ShapeBaseImageData(ZWingAltImage2)
{
   shapeFile = "flag.dts";
   mountPoint = 1;

   offset = "0 0 0"; // L/R - F/B - T/B
   rotation = "-0.5 -2 0 35"; // L/R - F/B - T/B
};



//PARTICLE DATABLOCKS
datablock ParticleData(GreensniperEmitParticle)
{
   dragCoeffiecient     = 1;
   gravityCoefficient   = -0.3;   // rises slowly
   inheritedVelFactor   = 0;

   lifetimeMS           =  300;
   lifetimeVarianceMS   =  0;
   useInvAlpha          =  false;
   spinRandomMin        = 0.0;
   spinRandomMax        = 0.0;

   animateTexture = false;

   textureName = "flareBase"; // "special/Smoke/bigSmoke"

   colors[0]     = "0 1 0";
   colors[1]     = "0 1 0";
   colors[2]     = "0 1 0";

   sizes[0]      = 0.4;
   sizes[1]      = 0.4;
   sizes[2]      = 0.4;

   times[0]      = 0.0;
   times[1]      = 1.0;
   times[2]      = 5.0;

};

datablock ParticleData(PurpleNightmareEmitParticle)
{
   dragCoeffiecient     = 1;
   gravityCoefficient   = -0.3;   // rises slowly
   inheritedVelFactor   = 0;

   lifetimeMS           =  300;
   lifetimeVarianceMS   =  0;
   useInvAlpha          =  false;
   spinRandomMin        = 0.0;
   spinRandomMax        = 0.0;

   animateTexture = false;

   textureName = "flareBase"; // "special/Smoke/bigSmoke"

   colors[0] = "0.5 0.1 0.9 1.0";
   colors[1] = "0.5 0.1 0.9 1.0";
   colors[2] = "0.5 0.1 0.9";

   sizes[0]      = 0.4;
   sizes[1]      = 0.4;
   sizes[2]      = 0.4;

   times[0]      = 0.0;
   times[1]      = 1.0;
   times[2]      = 5.0;

};

datablock ParticleData(ZAcidBallParticle)
{
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = 0.5;
   inheritedVelFactor   = 0.5;

   lifetimeMS           = 2000;
   lifetimeVarianceMS   = 200;

   spinRandomMin = -200.0;
   spinRandomMax =  200.0;

   textureName          = "special/bubbles";

   colors[0]     = "0.0 1.0 0.5 0.3";
   colors[1]     = "0.0 1.0 0.4 0.2";
   colors[2]     = "0.0 1.0 0.3 0.1";

   sizes[0]      = 0.6;
   sizes[1]      = 0.3;
   sizes[2]      = 0.1;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleData(DemonFBSmokeParticle)
{
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.0;

   lifetimeMS           = 2500;  
   lifetimeVarianceMS   = 500;

   textureName          = "particleTest";

   useInvAlpha =     true;

   spinRandomMin = -60.0;
   spinRandomMax = 60.0;

   colors[0]     = "0.5 0.5 0.5 0.5";
   colors[1]     = "0.4 0.4 0.4 0.2";
   colors[2]     = "0.3 0.3 0.3 0.0";
   sizes[0]      = 0.5;
   sizes[1]      = 1.75;
   sizes[2]      = 3.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};



// EXPLOSION DATABLOCKS
datablock ExplosionData(ZAcidBallExplosion)
{
   emitter[0]   = ZAcidBallExplosionEmitter;
   soundProfile = NerfBallExplosionSound;
};

datablock ExplosionData(SSExplosion)
{
   soundProfile   = SniperShotExpSound;

   explosionShape = "disc_explosion.dts";
   faceViewer           = true;
   explosionScale = "0.5 0.5 0.5";

   sizes[0] = "0.5 0.5 0.5";
   sizes[1] = "0.5 0.5 0.5";
   times[0] = 0.0;
   times[1] = 1.0;

   shakeCamera = true;
   camShakeFreq = "12.0 13.0 11.0";
   camShakeAmp = "35.0 35.0 35.0";
   camShakeDuration = 1.0;
   camShakeRadius = 15.0;
};



// EMITTER DATABLOCKS
datablock ParticleEmitterData(ZAcidBallExplosionEmitter)
{
   lifetimeMS       = 200;

   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionVelocity = 3.0;
   velocityVariance = 0.5;

   thetaMin         = 0.0;
   thetaMax         = 90.0;

   orientParticles  = false;
   orientOnVelocity = false;

   particles = "ZAcidBallParticle";
};

datablock ParticleEmitterData(DarkraiSniperEmitter)
{
   ejectionPeriodMS = 2;
   periodVarianceMS = 1;

   ejectionVelocity = 10;
   velocityVariance = 0;

   thetaMin         = 89.0;
   thetaMax         = 90.0;

   orientParticles = false;

   particles = "PurpleNightmareEmitParticle";
};

datablock ParticleEmitterData(DemonFBSmokeEmitter)
{
   ejectionPeriodMS = 7;
   periodVarianceMS = 0;

   ejectionVelocity = 0.75;  // A little oomph at the back end
   velocityVariance = 0.2;

   thetaMin         = 0.0;
   thetaMax         = 180.0;

   particles = "DemonFBSmokeParticle";
};


datablock ParticleEmitterData(PulseGreenSniperEmitter)
{
   ejectionPeriodMS = 2;
   periodVarianceMS = 1;

   ejectionVelocity = 10;
   velocityVariance = 0;

   thetaMin         = 89.0;
   thetaMax         = 90.0;

   orientParticles = false;

   particles = "GreensniperEmitParticle";
};



// PROJECTILE DATABLOCKS
datablock LinearFlareProjectileData(DarkraiSniperShot)
{
   projectileShapeName = "weapon_missile_projectile.dts";
   scale               = "3.0 5.0 3.0";
   faceViewer          = true;
   directDamage        = 0.01;
   kickBackStrength    = 4000.0;
   DirectDamageType    = $DamageType::Zombie;

   explosion           = "SSExplosion";

   dryVelocity       = 150.0;
   wetVelocity       = -1;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 10000;
   lifetimeMS        = 10000;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   activateDelayMS = 100;
   activateDelayMS = -1;

   baseEmitter = DarkraiSniperEmitter;

   size[0]           = 0.0;
   size[1]           = 0.0;
   size[2]           = 0.0;


   numFlares         = 0;
   flareColor        = "0.0 0.0 0.0";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

	sound        = PlasmaProjectileSound;
   fireSound    = PlasmaFireSound;
   wetFireSound = PlasmaFireWetSound;

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "1 0.75 0.25";
};

datablock LinearFlareProjectileData(SniperShot)
{
   projectileShapeName = "weapon_missile_projectile.dts";
   scale               = "3.0 5.0 3.0";
   faceViewer          = true;
   directDamage        = 0.6;
   hasDamageRadius     = true;
   indirectDamage      = 0.3;
   damageRadius        = 30;
   kickBackStrength    = 4000.0;
   radiusDamageType    = $DamageType::Zombie;

   explosion           = "SSExplosion";

   dryVelocity       = 150.0;
   wetVelocity       = -1;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 10000;
   lifetimeMS        = 10000;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   activateDelayMS = 100;
   activateDelayMS = -1;

   baseEmitter = PulseGreenSniperEmitter;

   size[0]           = 0.0;
   size[1]           = 0.0;
   size[2]           = 0.0;


   numFlares         = 0;
   flareColor        = "0.0 0.0 0.0";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

	sound        = PlasmaProjectileSound;
   fireSound    = PlasmaFireSound;
   wetFireSound = PlasmaFireWetSound;

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "1 0.75 0.25";
};

datablock TracerProjectileData(LZombieAcidBall)
{
   doDynamicClientHits = true;

   projectileShapeName = "";
   directDamage        = 0.0;
   directDamageType    = $DamageType::ZAcid;
   hasDamageRadius     = true;
   indirectDamage      = 0.24;
   damageRadius        = 4.0;
   kickBackStrength    = 0.0;
   radiusDamageType    = $DamageType::ZAcid;
   sound          	   = BlasterProjectileSound;
   explosion           = ZAcidBallExplosion;

   dryVelocity       = 100.0;
   wetVelocity       = 100.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 4000;
   lifetimeMS        = 1000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   activateDelayMS = 100;

   tracerLength    = 5;
   tracerAlpha     = false;
   tracerMinPixels = 3;
   tracerColor     = "0 1 0 1";
	tracerTex[0]  	 = "special/landSpikeBolt";
	tracerTex[1]  	 = "special/landSpikeBoltCross";
	tracerWidth     = 0.5;
   crossSize       = 0.79;
   crossViewAng    = 0.990;
   renderCross     = true;
   emap = true;
};

datablock GrenadeProjectileData(DemonFireball)
{
   projectileShapeName = "plasmabolt.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.4;
   damageRadius        = 5.0; // z0dd - ZOD, 8/13/02. Was 20.0
   radiusDamageType    = $DamageType::zombie;
   kickBackStrength    = 1500;

   explosion           = "PlasmaBoltExplosion";
   underwaterExplosion = "PlasmaBoltExplosion";
   velInheritFactor    = 0;
   splash              = PlasmaSplash;
   depthTolerance      = 100.0;
   
   baseEmitter         = DemonFBSmokeEmitter;
   bubbleEmitter       = DemonFBSmokeEmitter;
   
   grenadeElasticity = 0;
   grenadeFriction   = 0.4;
   armingDelayMS     = -1; // z0dd - ZOD, 4/14/02. Was 2000

   gravityMod        = 0.4;  // z0dd - ZOD, 5/18/02. Make mortar projectile heavier, less floaty
   muzzleVelocity    = 50.0; // z0dd - ZOD, 8/13/02. More velocity to compensate for higher gravity. Was 63.7
   drag              = 0;
   sound	     = PlasmaProjectileSound;

   hasLight    = true;
   lightRadius = 10;
   lightColor  = "1 0.75 0.25";

   hasLightUnderwaterColor = true;
   underWaterLightColor = "1 0.75 0.25";
};

datablock SeekerProjectileData(LordRaamStiloutte) {
   casingShapeName     = "weapon_missile_casement.dts";
   projectileShapeName = "weapon_missile_projectile.dts";
   hasDamageRadius     = true;
   indirectDamage      = 0.5;
   damageRadius        = 5.0;
   radiusDamageType    = $DamageType::Zombie;
   kickBackStrength    = 2000;

   explosion           = "MissileExplosion";
   splash              = MissileSplash;
   velInheritFactor    = 1.0;    // to compensate for slow starting velocity, this value
                                 // is cranked up to full so the missile doesn't start
                                 // out behind the player when the player is moving
                                 // very quickly - bramage

   baseEmitter         = MortarSmokeEmitter;
   delayEmitter        = MissileFireEmitter;
   puffEmitter         = MissilePuffEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;
   bubbleEmitTime      = 1.0;

   exhaustEmitter      = MissileLauncherExhaustEmitter;
   exhaustTimeMs       = 300;
   exhaustNodeName     = "muzzlePoint1";

   lifetimeMS          = 20000; // z0dd - ZOD, 4/14/02. Was 6000
   muzzleVelocity      = 10.0;
   maxVelocity         = 80.0; // z0dd - ZOD, 4/14/02. Was 80.0
   turningSpeed        = 23.0;
   acceleration        = 15.0;

   proximityRadius     = 2.5;

   terrainAvoidanceSpeed = 10;
   terrainScanAhead      = 7;
   terrainHeightFail     = 1;
   terrainAvoidanceRadius = 3;

   flareDistance = 40;
   flareAngle    = 20;
   minSeekHeat   = 0.0;

   sound = MissileProjectileSound;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0.2 0.05 0";

   useFlechette = true;
   flechetteDelayMs = 250;
   casingDeb = FlechetteDebris;

   explodeOnWaterImpact = false;
};

//////---- DARKRAI
datablock ParticleData(InflictionNightmareGlobeSmoke)
{
dragCoefficient = 50;/////////-----------------------
gravityCoefficient = 0.0;
inheritedVelFactor = 1.0;
constantAcceleration = 0.0;
lifetimeMS = 5050;
lifetimeVarianceMS = 0;
useInvAlpha = true;
spinRandomMin = -360.0;
spinRandomMax = 360.0;
textureName = "particleTest";
colors[0] = "0.5 0.1 0.9 1.0";
colors[1] = "0.5 0.1 0.9 1.0";
colors[2] = "0.5 0.1 0.9 1.0";
colors[3] = "0.5 0.1 0.9";
sizes[0] = 1.0;
sizes[1] = 1.0;
sizes[2] = 1.0;
sizes[3] = 1.0;
times[0] = 0.0;
times[1] = 0.33;
times[2] = 0.66;
times[3] = 1.0;
mass = 0.7;
elasticity = 0.2;
friction = 1;
computeCRC = true;
haslight = true;
lightType = "PulsingLight";
lightColor = "0.2 0.0 0.5 1.0";
lightTime = "200";
lightRadius = "2.0";
};

datablock ParticleEmitterData(InfNightmareGlobeEmitter)
{
ejectionPeriodMS = 0.004;
periodVarianceMS = 0;
ejectionVelocity = 0.0;
velocityVariance = 0.0;
ejectionOffset = 5;
thetaMin = 0;
thetaMax = 180;
overrideAdvances = false;
particles = "InflictionNightmareGlobeSmoke";
};


datablock ParticleData(NightmareGlobeSmoke)
{
dragCoefficient = 50;/////////-----------------------
gravityCoefficient = 0.0;
inheritedVelFactor = 1.0;
constantAcceleration = 0.0;
lifetimeMS = 5050;
lifetimeVarianceMS = 0;
useInvAlpha = true;
spinRandomMin = -360.0;
spinRandomMax = 360.0;
textureName = "particleTest";
colors[0] = "0.1 0.1 0.1 1.0";// ////////////////////
colors[1] = "0.1 0.1 0.1 1.0";// ////////////////////
colors[2] = "0.1 0.1 0.1 1.0";// \\\\\\\\\\\\\\\\\\\\
colors[3] = "0.1 0.1 0.1 1.0";// \\\\\\\\\\\\\\\\\\\\
sizes[0] = 1.0;
sizes[1] = 1.0;
sizes[2] = 1.0;
sizes[3] = 1.0;
times[0] = 0.0;
times[1] = 0.33;
times[2] = 0.66;
times[3] = 1.0;
mass = 0.7;
elasticity = 0.2;
friction = 1;
computeCRC = true;
haslight = true;
lightType = "PulsingLight";
lightColor = "0.2 0.0 0.5 1.0";
lightTime = "200";
lightRadius = "2.0";
};

datablock ParticleEmitterData(NightmareGlobeEmitter)
{
ejectionPeriodMS = 0.004;
periodVarianceMS = 0;
ejectionVelocity = 0.0;
velocityVariance = 0.0;
ejectionOffset = 5;
thetaMin = 0;
thetaMax = 180;
overrideAdvances = false;
particles = "NightmareGlobeSmoke";
};


// PACK DATABLOCKS
datablock StaticShapeData(DeployedZSpawnBase) : StaticShapeDamageProfile {
	className	= "lightbase";
	shapeFile	= "pack_deploy_sensor_motion.dts";

	maxDamage	= 2.5;
	destroyedLevel	= 2.5;
	disabledLevel	= 2.0;

	maxEnergy = 50;
	rechargeRate = 0.25;

	explosion	= HandGrenadeExplosion;
	expDmgRadius	= 1.0;
	expDamage	= 0.05;
	expImpulse	= 200;

	dynamicType			= $TypeMasks::StaticShapeObjectType;
	deployedObject		= true;
	cmdCategory			= "DSupport";
	cmdIcon			= CMDSensorIcon;
	cmdMiniIconName		= "commander/MiniIcons/com_deploymotionsensor";
	targetNameTag		= 'Deployed Zombie Spawner';
	deployAmbientThread	= true;
	debrisShapeName		= "debris_generic_small.dts";
	debris			= DeployableDebris;
	heatSignature		= 0;
	needsPower 			= true;
};

datablock ShapeBaseImageData(ZSpawnDeployableImage) {
	mass = 20;
	emap = true;
	shapeFile = "stackable1s.dts";
	item = ZSpawnDeployable;
	mountPoint = 1;
	offset = "0 0 0";
	deployed = DeployedZSpawnBase;
	heatSignature = 0;

	stateName[0] = "Idle";
	stateTransitionOnTriggerDown[0] = "Activate";

	stateName[1] = "Activate";
	stateScript[1] = "onActivate";
	stateTransitionOnTriggerUp[1] = "Idle";

	isLarge = false;
	maxDepSlope = 360;
	deploySound = ItemPickupSound;

	minDeployDis = 0.5;
	maxDeployDis = 50.0;
};

datablock ItemData(ZSpawnDeployable) {
	className = Pack;
	catagory = "Deployables";
	shapeFile = "stackable1s.dts";
	mass = 5.0;
	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 1;
	rotate = true;
	image = "ZSpawnDeployableImage";
	pickUpName = "a Zombie Spawn pack";
	heatSignature = 0;
	emap = true;
};

function ZSpawnDeployableImage::testObjectTooClose(%item) {
	return "";
}
function ZSpawnDeployableImage::testNoTerrainFound(%item) {}
function ZSpawnDeployable::onPickup(%this, %obj, %shape, %amount) {}

function ZSpawnDeployableImage::onDeploy(%item, %plyr, %slot) {
	%className = "StaticShape";

	%playerVector = vectorNormalize(-1 * getWord(%plyr.getEyeVector(),1) SPC getWord(%plyr.getEyeVector(),0) SPC "0");

	if (vAbs(floorVec(%item.surfaceNrm,100)) $= "0 0 1")
		%item.surfaceNrm2 = %playerVector;
	else
		%item.surfaceNrm2 = vectorNormalize(vectorCross(%item.surfaceNrm,"0 0 -1"));

	%rot = fullRot(%item.surfaceNrm,%item.surfaceNrm2);

	%deplObj = new (%className)() {
		dataBlock = %item.deployed;
	};

	// set orientation
	%deplObj.setTransform(%item.surfacePt SPC %rot);

	// set the recharge rate right away
	if (%deplObj.getDatablock().rechargeRate)
		%deplObj.setRechargeRate(%deplObj.getDatablock().rechargeRate);

	// set team, owner, and handle
	%deplObj.team = %plyr.client.Team;
	%deplObj.setOwner(%plyr);
	%deplObj.light.lightBase = %deplObj;

	// set the sensor group if it needs one
	if (%deplObj.getTarget() != -1)
		setTargetSensorGroup(%deplObj.getTarget(), %plyr.client.team);

	// place the deployable in the MissionCleanup/Deployables group (AI reasons)
	addToDeployGroup(%deplObj);

	//let the AI know as well...
	AIDeployObject(%plyr.client, %deplObj);

	// play the deploy sound
	serverPlay3D(%item.deploySound, %deplObj.getTransform());

	// increment the team count for this deployed object
	$TeamDeployedCount[%plyr.team, %item.item]++;

	addDSurface(%item.surface,%deplObj);

	%deplObj.playThread($PowerThread,"Power");
	%deplObj.playThread($AmbientThread,"ambient");

	// take the deployable off the player's back and out of inventory
	%plyr.unmountImage(%slot);
	%plyr.decInventory(%item.item, 1);

	// set power frequency
	%deplObj.powerFreq = %plyr.powerFreq;

	// Power object
	checkPowerObject(%deplObj);

	if (%plyr.packset==0)
	   %deplobj.ZType=1;
	else if (%plyr.packset==1)
	   %deplobj.ZType=2;
	else if (%plyr.packset==2){
	   %deplobj.ZType=3;
	   %deplobj.numZ=2;
	}
	else if (%plyr.packset==3)
	   %deplobj.Ztype=4;
	else if (%plyr.packset==4)
	   %deplobj.Ztype=5;
	else if (%plyr.packset==5)
	   %deplobj.Ztype=6;
	else if (%plyr.packset==6){
	   %deplobj.ZType=7;
	   %deplobj.numZ=1;
	}

	%deplobj.spawnTypeSet = %plyr.expertset;

	return %deplObj;
}

function DeployedZSpawnBase::onDestroyed(%this,%obj,%prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this,%obj,%prevState);
	$TeamDeployedCount[%obj.team, ZSpawnDeployable]--;
	remDSurface(%obj);
	%obj.schedule(500, "delete");
      if (%obj.ZCloop !$= "")
   	   Cancel(%obj.ZCLoop);
}

function DeployedZSpawnBase::disassemble(%data,%plyr,%obj) {
   	if (%obj.ZCloop !$= "")
   	   Cancel(%obj.ZCLoop);
	disassemble(%data,%plyr,%obj);
}

function ZSpawnDeployableImage::onMount(%data, %obj, %node) {
   %obj.hasZSpawn = true;
   %obj.expertset = 0;
}

function ZSpawnDeployableImage::onUnmount(%data, %obj, %node) {
   %obj.hasZSpawn = "";
}

function DeployedZSpawnBase::onGainPowerEnabled(%data,%obj) {
   if(%obj.spawnTypeSet == 1)
	%obj.numz = 0;
   if (%obj.ZCloop !$= "")
   	Cancel(%obj.ZCLoop);
   %obj.ZCLoop = schedule(1000, 0, "ZcreateLoop", %obj);
   Parent::onGainPowerEnabled(%data,%obj);
}

function DeployedZSpawnBase::onLosePowerDisabled(%data,%obj) {
   if (%obj.ZCloop !$= "")
   	Cancel(%obj.ZCLoop);
   Parent::onLosePowerDisabled(%data,%obj);
}

function ZDoMoan(%zombie){
   %chance = (getRandom() * 12);
   if(%chance <= 11)
	serverPlay3d("ZombieMoan",%zombie.getWorldBoxCenter()); 
   else
	serverPlay3d("ZombieHOWL",%zombie.getWorldBoxCenter()); 
}

function LZDoMoan(%zombie){
   serverPlay3d("ZombieMoan",%zombie.getWorldBoxCenter()); 
}

function LZDoYell(%zombie){
   serverPlay3d("ZombieHOWL",%zombie.getWorldBoxCenter());  
}

function Zsetjump(%zombie){
   %zombie.canjump = 1;
}

function ChargeEmitter(%zombie){
   if(!isobject(%zombie))
	return;
   if(%zombie.chargecount >= 2){
   	%charge2 = new ParticleEmissionDummy() 
   	{ 
   	   position = %zombie.getMuzzlePoint(6);
   	   dataBlock = "defaultEmissionDummy"; 
   	   emitter = "FlameEmitter"; 
      }; 
	MissionCleanup.add(%charge2);
	%charge2.schedule(100, "delete");
   }
   if(%zombie.chargecount <= 7){
   	%charge = new ParticleEmissionDummy() 
   	{ 
   	   position = %zombie.getMuzzlePoint(5);
   	   dataBlock = "defaultEmissionDummy"; 
   	   emitter = "FlameEmitter";  
      };
	MissionCleanup.add(%charge);
	%charge.schedule(100, "delete");
   }
   if(%zombie.chargecount <= 9){
      %zombie.Fire = schedule(100, %zombie, "ChargeEmitter", %zombie);
	%zombie.chargecount++;
   }
   else
	%zombie.chargecount = 0;
}

function ResetShield(%zombie) {
%zombie.rapiershield = 1;
}

function RAAMReset(%zombie) {
%zombie.shotsfired = 0;
}

function RkillLoop(%zombie,%target,%count){
   if(!isObject(%zombie)){
	%zombie.iscarrying = 0;
	%target.grabbed = 0;
	return;
   }
   if(!isObject(%target)){
	%zombie.iscarrying = 0;
	%target.grabbed = 0;
	return;
   }
   if (%Zombie.getState() $= "dead"){
	%zombie.iscarrying = 0;
	%target.grabbed = 0;
	return;
   }
   if (%target.getState() $= "dead"){
	%zombie.iscarrying = 0;
	%target.grabbed = 0;
	return;
   }
   if(%count == 50){
	%chance = getRandom(1,3);
	if(%chance == 3)
	   %target.damage(0, %tpos, 10.0, $DamageType::Zombie);
	else{
	   %target.isFTD = 1;
	   if(%target.getMountedImage($Backpackslot) !$= "")
   	      %target.throwPack();
   	   %target.finishingfall = schedule(5000, 0, "stopFTD", %target);
	}
	%zombie.iscarrying = 0;
	return;
   }
   %target.setPosition(vectoradd(%zombie.getPosition(),"0 0 -4"));
   %target.setVelocity(%zombie.getVelocity());
   %count++;
   %zombie.killingplayer = schedule(100, 0, "RkillLoop", %zombie, %target, %count);
}

function stopFTD(%target){
   %target.isFTD = 0;
   %target.grabbed = 0;
}

function InfectLoop(%obj){
   if($TWM::PlayingHorde || $TWM::PlayingInfection) {
   return;
   }
   if (%obj.getState() $= "dead")
	return;
   if(isObject(%obj)){
	if(%obj.beats $= "")
	   zombieAttackImpulse(%obj,0);
	if(%obj.beats < 15)
         %obj.setWhiteOut(%obj.beats * 0.05);
	else
	   %obj.setDamageFlash(1);
	if(%obj.beats == 15){
	   %obj.canZkill = 1;
	}
	if(%obj.beats >=15)
	   serverPlay3d("ZombieMoan",%obj.getWorldBoxCenter()); 
	else if (%obj.beats >= 10)
	   playDeathCry(%obj);
	else
	   playPain(%obj);
	if(%obj.beats == 20){
	   if($host::canZombie $= "")
		$host::canZombie = 0;
	   if($host::canZombie == 1)
	      makePersonZombie(%obj.getTransform(),%obj.client);
	   else
		%obj.damage(0, %obj.getposition(), 10.0, $DamageType::Zombie);
	   return;
	}
      %obj.beats++;
	%obj.infectedDamage = schedule(2000, %obj, "InfectLoop", %obj); 
   }
}

function ZkillUpdateScore(%game,%zombie,%client,%implement){
   %client.Zkills++;
   %game.recalcScore(%client);
   updateZkillXP(%zombie,%client);   //Ha! got it! -Phantom139
}

function updateZkillXP(%zombie,%client) {
   if(%zombie.Typeinfo == 1) {   //Normal, 1XP
   %client.XPGain = (1 * mfloor($TWM::EXPMultiplier));
   %client.XP = %client.XP + %client.XPGain;
   %client.SPGain = (10 * mfloor($TWM::SPMultiplier));
   %client.SP = %client.SP + %client.SPGain;
   if(%client.viewZDM)
   messageClient(%client, 'MsgClient', "\c5Normal Zombie Killed. (+"@%client.XPGain@"XP)");
   }
   else if(%zombie.Typeinfo == 2) { //Ravengers, 3XP
   %client.XPGain = (3 * mfloor($TWM::EXPMultiplier));
   %client.XP = %client.XP + %client.XPGain;
   %client.SPGain = (30 * mfloor($TWM::SPMultiplier));
   %client.SP = %client.SP + %client.SPGain;
   if(%client.viewZDM)
   messageClient(%client, 'MsgClient', "\c5Ravenger Zombie Killed. (+"@%client.XPGain@"XP)");
   }
   else if(%zombie.Typeinfo == 3) { //Lords, 10XP
   %client.XPGain = (10 * mfloor($TWM::EXPMultiplier));
   %client.XP = %client.XP + %client.XPGain;
   %client.SPGain = (100 * mfloor($TWM::SPMultiplier));
   %client.SP = %client.SP + %client.SPGain;
   if(%client.viewZDM)
   messageClient(%client, 'MsgClient', "\c5Zombie Lord Killed. (+"@%client.XPGain@"XP)");
   }
   else if(%zombie.Typeinfo == 4) { //Demons, 5XP
   %client.XPGain = (5 * mfloor($TWM::EXPMultiplier));
   %client.XP = %client.XP + %client.XPGain;
   %client.SPGain = (50 * mfloor($TWM::SPMultiplier));
   %client.SP = %client.SP + %client.SPGain;
   if(%client.viewZDM)
   messageClient(%client, 'MsgClient', "\c5Demon Zombie Killed. (+"@%client.XPGain@"XP)");
   }
   else if(%zombie.Typeinfo == 5) { //Air Rapiers, 3XP
   %client.XPGain = (3 * mfloor($TWM::EXPMultiplier));
   %client.XP = %client.XP + %client.XPGain;
   %client.SPGain = (30 * mfloor($TWM::SPMultiplier));
   %client.SP = %client.SP + %client.SPGain;
   if(%client.viewZDM)
   messageClient(%client, 'MsgClient', "\c5Air Rapier Zombie Killed. (+"@%client.XPGain@"XP)");
   }
   else if(%zombie.Typeinfo == 6) {  //Snipers, 7XP
   %client.XPGain = (7 * mfloor($TWM::EXPMultiplier));
   %client.XP = %client.XP + %client.XPGain;
   %client.SPGain = (70 * mfloor($TWM::SPMultiplier));
   %client.SP = %client.SP + %client.SPGain;
   if(%client.viewZDM)
   messageClient(%client, 'MsgClient', "\c5Sniper Zombie Killed. (+"@%client.XPGain@"XP)");
   }
   else if(%zombie.Typeinfo == 20) {  //Slashers, 30XP
   %client.XPGain = (30 * mfloor($TWM::EXPMultiplier));
   %client.XP = %client.XP + %client.XPGain;
   %client.SPGain = (300 * mfloor($TWM::SPMultiplier));
   %client.SP = %client.SP + %client.SPGain;
   if(%client.viewZDM)
   messageClient(%client, 'MsgClient', "\c5Slasher Zombie Killed. (+"@%client.XPGain@"XP)");
   }
   else if(%zombie.Typeinfo == 8) {  //RAAM, 250xp
   %client.XPGain = ($Boss::EXPGiven["GeneralRaam"] * mfloor($TWM::EXPMultiplier));
   %client.XP = %client.XP + %client.XPGain;
   %client.SPGain = ($Boss::EXPGiven["GeneralRaam"] * 10 * mfloor($TWM::SPMultiplier));
   %client.SP = %client.SP + %client.SPGain;
   if(%client.viewZDM)
   messageClient(%client, 'MsgClient', "\c5General RAAM Killed. (+"@%client.XPGain@"XP)");
   }
   else if(%zombie.Typeinfo == 10) {  //Darkrai, 10000xp
   %client.XPGain = ($Boss::EXPGiven["LordDarkrai"] * mfloor($TWM::EXPMultiplier));
   %client.XP = %client.XP + %client.XPGain;
   %client.SPGain = ($Boss::EXPGiven["LordDarkrai"] * 10 * mfloor($TWM::SPMultiplier));
   %client.SP = %client.SP + %client.SPGain;
   if(%client.viewZDM)
   messageClient(%client, 'MsgClient', "\c5Lord Darkrai Killed. (+"@%client.XPGain@"XP)");
   }
   else if(%zombie.Typeinfo == 11) {  //Fake Darkrai, 500xp
   %client.XPGain = (500 * mfloor($TWM::EXPMultiplier));
   %client.XP = %client.XP + %client.XPGain;
   %client.SPGain = (5000 * mfloor($TWM::SPMultiplier));
   %client.SP = %client.SP + %client.SPGain;
   if(%client.viewZDM)
   messageClient(%client, 'MsgClient', "\c5Clone Lord Darkrai Killed. (+"@%client.XPGain@"XP)");
   }
   else if(%zombie.Typeinfo == 12) {  //Lord RAAM, 50000xp
   %client.XPGain = ($Boss::EXPGiven["LordRAAM"] * mfloor($TWM::EXPMultiplier));
   %client.XP = %client.XP + %client.XPGain;
   %client.SPGain = ($Boss::EXPGiven["LordRAAM"] * 10 * mfloor($TWM::SPMultiplier));
   %client.SP = %client.SP + %client.SPGain;
   if(%client.viewZDM)
   messageClient(%client, 'MsgClient', "\c5Lord RAAM Killed. (+"@%client.XPGain@"XP)");
   }
   else {                   //If it doesnt check out, add 1XP
   %client.XPGain = (1 * mfloor($TWM::EXPMultiplier));
   %client.XP = %client.XP + %client.XPGain;
   %client.SPGain = (10 * mfloor($TWM::SPMultiplier));
   %client.SP = %client.SP + %client.SPGain;
   if(%client.viewZDM)
   messageClient(%client, 'MsgClient', "\c5Zombie Killed. (+"@%client.XPGain@"XP)");
   }
   //update
   UpdateClientRank(%client);
}

function StopZombieSpawnLoop(){
   cancel($zombieloop);
}

function ZombieBloodLust(%obj, %count){
   if(!isObject(%obj))
	return;
   if (%obj.getState() $= "dead")
	return;
   if(!$TWM::PlayingInfection)
      %obj.setDamageFlash(0.5);
   if(%count == 10){
	serverPlay3d("ZombieMoan",%obj.getWorldBoxCenter()); 
	%count = 0;
   }
   %count++;
   schedule(200, %obj, "ZombieBloodLust", %obj, %count); 
}

function resetattackImpulse(%obj) {
%obj.setcancelimpulse = 0;
}

function zombieAttackImpulse(%obj, %count){
   if($TWM::PlayingInfection) {
      return;
   }
   if(%obj.setcancelimpulse)
    return;
   if(!isObject(%obj))
	return;
   if (%obj.getState() $= "dead")
	return;
   %pos = %obj.getposition();
   InitContainerRadiusSearch(%pos, %count, $TypeMasks::PlayerObjectType);
   while ((%objtarget = containerSearchNext()) != 0){
	if(isObject(%objtarget) && %objtarget !$= %obj){
	   %objarmortype = %objtarget.getdatablock().getname();
	   if(%objarmortype $= "ZombieArmor" || %objarmortype $= "FZombieArmor" || %objarmortype $= "LordZombieArmor" || %objarmortype $= "DemonZombieArmor" || %objarmortype $= "RapierZombieArmor")
	      %objiszomb = 1;
	   if(!(%objiszomb) && %objtarget.iszombie != 1){
		%vec = vectorNormalize(vectorSub(%objtarget.getWorldBoxCenter(),%obj.getWorldBoxCenter()));
		if(vectorDist(%vec,%obj.getForwardVector()) <= 0.5){
		   if(%count <= 200){
		      %impulse = (%count / 20) * 90;
		      %up = (%count / 100) * 90;
		   }
		   else{
		      %impulse = 900;
		      %up = 180;
		   }
		   %vec = vectorScale(%vec,%impulse);
		   %vec = vectorAdd(%vec,"0 0 "@%up);
		   %obj.applyimpulse(%obj.getPosition(),%vec);
		   %count++;
   		   schedule(500, 0, "zombieAttackImpulse", %obj, %count);
		   return;
		}
         }
      }
	%objiszomb = 0;
   }
   %count++;
   schedule(500, 0, "zombieAttackImpulse", %obj, %count);
}

function RapierForwardImpulse(%obj){
   if(!isObject(%obj))
	return;
   if(%obj.getState() $= "Dead")
	return;
   %obj.setActionThread("scoutRoot",true);
   if(vectorLen(%obj.getVelocity()) < 50)
	%obj.applyImpulse(%obj.getPosition(),vectorScale(%obj.getMuzzleVector(0),$Zombie::Fforwardspeed * 0.6));
   schedule(100, 0, "RapierForwardImpulse", %obj);
}

function RavengerForwardImpulse(%obj){
   if(!isObject(%obj))
	return;
   if(%obj.getState() $= "Dead")
	return;
   %obj.setActionThread("scoutRoot",true);
   if(vectorLen(%obj.getVelocity()) < 100)
	%obj.applyImpulse(%obj.getPosition(),vectorScale(%obj.getForwardVector(),$Zombie::Fforwardspeed * 0.6));
   schedule(100, 0, "RavengerForwardImpulse", %obj);
}

function PlayerLordFire1(%Player) {
   if(%Player.recharging) {
   return;
   }
   Schedule(1000,0,PlayerLordFire2,%Player);
   Schedule(1500,0,PlayerLordFire2,%Player);
   	%charge = new ParticleEmissionDummy()
   	{
   	   position = %player.getMuzzlePoint(5);
   	   dataBlock = "defaultEmissionDummy";
   	   emitter = "FlameEmitter";
    };
	MissionCleanup.add(%charge);
    %Player.recharging = 1;
	%charge.schedule(1000, "delete");
    schedule(7000,0,"ResetZombieCharge",%player);
}

function PlayerLordFire2(%player) {
   	   %p = new TracerProjectile()
   	   {
   	   	dataBlock        = LZombieAcidBall;
        initialDirection = %player.getMuzzleVector(6);
        initialPosition  = %player.getMuzzlePoint(6);
   	   	sourceObject     = %player;
   	   	sourceSlot       = 6;
   	   };
       MissionCleanup.add(%p);
}

function ResetZombieCharge(%player) {
%player.recharging = 0;
}

function playerLiftTarget(%zombie,%count){
%pos         = %zombie.getMuzzlePoint($WeaponSlot);
%vec         = %zombie.getMuzzleVector($WeaponSlot);
%targetpos   = vectoradd(%pos,vectorscale(%vec,5));
%obj         = containerraycast(%pos,%targetpos,$typemasks::playerobjecttype,%zombie);
%closestclient = getword(%obj,0);
if (%obj <1)
   return;
   if(%count == 0)
	%zombie.canmove = 0;
   if(%closestclient.getState() $= "dead" || %Zombie.getState() $= "dead"){
	%zombie.canmove = 1;
	return;
   }
   %target = %closestclient;
   if(!isobject(%target)){
	%zombie.canmove = 1;
	return;
   }
   %pos = %zombie.getworldboxcenter();
   %Tpos = %target.getworldboxcenter();
   %ZtoT = vectorsub(%tpos,%pos);
   if (%count <= 12){
	%newpos = vectoradd(%ZtoT,vectoradd(%pos,"0 0 -0.6"));
	%target.setTransform(%newpos);
	%target.setvelocity("0 0 0");
   }
   else {
	%killtype = getrandom(1,2);
	if(%killtype == 1){
	   %closestwall = 20;
	   %nv2 = (getword(%ZtoT, 0) * -1);
	   %nv1 = getword(%ZtoT, 1);
	   %vector1 = vectorscale(vectornormalize(%nv1@" "@%nv2@" 0"),20);
	   %nvector1 = vectoradd(%tpos,%vector1);
	   %nv2 = getword(%ZtoT, 0);
	   %nv1 = (getword(%ZtoT, 1) * -1);
	   %vector2 = vectorscale(vectornormalize(%nv1@" "@%nv2@" 0"),20);
	   %nvector2 = vectoradd(%tpos,%vector2);
	   %searchresultR = containerRayCast(%tpos, %nvector1, $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::VehicleObjectType);
	   %searchresultL = containerRayCast(%tpos, %nvector2, $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::VehicleObjectType);
	   if(%searchresultR){
		%Hpos = getword(%searchresultR,1)@" "@getword(%searchresultR,2)@" "@getword(%searchresultR,3);
		%distance = vectordist(%Tpos, %Hpos);
		if(%distance <= %closestwall){
		   %closestwall = %distance;
		   %vector = vectoradd(vectorscale(%vector1,1500),"0 0 100");
		}
	   }
	   if(%searchresultL){
		%Hpos = getword(%searchresultL,1)@" "@getword(%searchresultL,2)@" "@getword(%searchresultL,3);
		%distance = vectordist(%Tpos, %Hpos);
		if(%distance <= %closestwall){
		   %closestwall = %distance;
		   %vector = vectoradd(vectorscale(%vector2,1500),"0 0 100");
		}
	   }
	   if(%closestwall == 20){
	   	%x = getword(%ZtoT, 0);
	   	%y = getword(%ZtoT, 1);
		%outvec = vectorscale(vectornormalize(%x@" "@%y@" 0"),50);
		%vector = vectoradd("0 0 -15000",%outvec);
	   }
	   %target.applyimpulse(%target.getposition(),%vector);
	}
	else if(%killtype == 2){
	   %target.infected = 1;
	   %target.damage(%zombie, %target.getposition(), 10.0, $DamageType::ZombieL);
	}
	%count = 0;
	%zombie.canmove = 1;
	return;
   }
   %count++;
   %zombie.killingplayer = schedule(150, %zombie, "Llifttarget", %zombie, %closestclient, %count);
}

function RAAMShieldUpdate(%zombie) {
if(!isobject(%zombie) || %zombie.getState() $= "Dead") {
return;
}
if(%zombie.cantRestore) {
return;
}
if(!%zombie.rapiershield) {
schedule(100,0,"RAAMShieldUpdate",%zombie);
return;
}
%zombie.playShieldEffect("1 1 1");
schedule(100,0,"RAAMShieldUpdate",%zombie);
}

function resetRaamField(%Z) {
%z.rapiershield = 1;
}

function playerRaamFire(%player) {
      if(%player.recharging) {
      return;
      }
      if(!isobject(%player) || %player.getState() $= "dead")
      return;
      if(%player.shotsfired >= 100) {
      %player.setMoveState(false); //unfreeze him
      %player.recharging = 1;
      %player.shotsfired = 0;
      schedule(7500,0,"ResetRaamField",%player);
      schedule(10000,0,"ResetZombieCharge",%player);
      return;
      }
      %player.rapiershield = 0;
      %player.setMoveState(true); //freeze him
      %pos = %player.getMuzzlePoint(5);
      %vec = %player.getMuzzleVector(5);

      %x = (getRandom() - 0.5) * 2 * 3.1415926 * (6/1000);
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * (6/1000);
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * (6/1000);
      %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
      %nvec = MatrixMulVector(%mat, %vec);
      %player.shotsfired++;
      %p = new LinearFlareProjectile()
      {
      dataBlock        = RAAMCGProjectile;
      initialDirection = %nvec;
	  initialPosition  = %pos;
	  sourceObject     = %player;
	  sourceSlot       = 5;
      };
      schedule(50,0,"playerRaamFire",%player);
}

function resetRAAMSummon(%RAAM) {
%RAAM.cansummon = 1;
}

function superPlayerRaamSummon(%cl,%RAAM) {
if(!isobject(%RAAM) || %RAAM.getState() $= "dead") {
return;
}
if(!%RAAM.cansummon) {
return;
}
if(%RAAM.getDatablock().maxDamage - %RAAM.getDamageLevel() > 75.0 ) {
%type = getrandom(1,6);
%RAAM.cansummon = 0;
messageall('RAAMMsg',"\c4"@getTaggedString(%cl.name)@": Destroy!!!");
if(!%cl.isdev) {
schedule(40000,0,"resetRAAMSummon",%RAAM);
}
else {
schedule(5000,0,"resetRAAMSummon",%RAAM);
}
for(%i=0;%i<3;%i++) {
%pos = vectoradd(%RAAM.getPosition(),getRandomPosition(10,1));
%fpos = vectoradd("0 0 5",%pos);
StartAZombie(%fpos, %type);
}
}
else if(%RAAM.getDatablock().maxDamage - %RAAM.getDamageLevel() > 40.0  && %RAAM.getDatablock().maxDamage - %RAAM.getDamageLevel() < 74.9) {
%type = getrandom(1,6);
%RAAM.cansummon = 0;
messageall('RAAMMsg',"\c4"@getTaggedString(%cl.name)@": Destroy Them All!!!");
if(!%cl.isdev) {
schedule(40000,0,"resetRAAMSummon",%RAAM);
}
else {
schedule(5000,0,"resetRAAMSummon",%RAAM);
}
for(%i=0;%i<8;%i++) {
%pos = vectoradd(%RAAM.getPosition(),getRandomPosition(10,1));
%fpos = vectoradd("0 0 5",%pos);
StartAZombie(%fpos, %type);
}
}
else if(%RAAM.getDatablock().maxDamage - %RAAM.getDamageLevel() < 39.9) {
%type = getrandom(1,6);
%RAAM.cansummon = 0;
messageall('RAAMMsg',"\c4"@getTaggedString(%cl.name)@": KILL THEM!! KILL THEM ALL!!!");
if(!%cl.isdev) {
schedule(40000,0,"resetRAAMSummon",%RAAM);
}
else {
schedule(5000,0,"resetRAAMSummon",%RAAM);
}
for(%i=0;%i<15;%i++) {
%pos = vectoradd(%RAAM.getPosition(),getRandomPosition(10,1));
%fpos = vectoradd("0 0 5",%pos);
StartAZombie(%fpos, %type);
}
}
%RAAM.setMoveState(true);
%RAAM.setActionThread($Zombie::RAAMThread,true);
schedule(3500,0,"unfreezeZombieobject",%RAAM);
}

function unfreezeZombieobject(%obj) {
%obj.setMoveState(false);
}

function resetLRLaserStorm(%z) {
%zomb.Storming = 0;
}

function RandomPlayerDarkraiNightmare(%zombie) {
   if(!isObject(%zombie) || %zombie.getState $= "dead") {
   return;
   }
   if(!%zombie.canRandNightmare) {
   return;
   }
   %client = FindValidTarget(%zombie);
   if(%client.player == %zombie) {
   %counts++;
      if(%counts > 5) {
      messageClient(%zombie.client,'msgZombie',"\c3No Targetable Clients Located.");
      return;
      }
   RandomPlayerDarkraiNightmare(%zombie);
   return;
   }
   %counts = 0;
   messageClient(%zombie.client,'msgZombie',"\c3Attempting Random Nightmare.");
   %zombie.canRandNightmare = 0;
   schedule(30000,0,"ResetNightmareLoop",%zombie);
      if(isObject(%client.player) && %client.player.getState !$= "dead" && !%client.ignoredbyZombs) {
      %c = createEmitter(%client.player.position,InfNightmareGlobeEmitter,"1 0 0");      //Rotate it
      MissionCleanup.add(%c); // I think This should be used
      schedule(3000,0,"killit",%c);
      %luck = getrandom(1,5);
         switch(%luck) {
         case 1:
         MessageAll('MessageAll', "\c4Lord Darkrai: Hah! I have you now "@%client.namebase@"!");
         Darkrainightmareloop(%zombie,%client);
         messageClient(%client,'msgClient',"~wfx/misc/diagnostic_on.wav");
         case 2:
         MessageAll('MessageAll', "\c4Lord Darkrai: Dammit!");
         case 3:
         MessageAll('MessageAll', "\c4Lord Darkrai: Hah! I have you now "@%client.namebase@"!");
         Darkrainightmareloop(%zombie,%client);
         messageClient(%client,'msgClient',"~wfx/misc/diagnostic_on.wav");
         case 4:
         MessageAll('MessageAll', "\c4Lord Darkrai: Dammit!");
         case 5:
         MessageAll('MessageAll', "\c4Lord Darkrai: Hah! I have you now "@%client.namebase@"!");
         Darkrainightmareloop(%zombie,%client);
         messageClient(%client,'msgClient',"~wfx/misc/diagnostic_on.wav");
         }
      }
}

function ResetNightmareLoop(%zombie) {
%zombie.canRandNightmare = 1;
}

function DarkraiSniperShot::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal) {
if(!isplayer(%targetObject)) {
return;
}
%targ = %targetObject.client;
%Zombie = %projectile.sourceObject;
%targ.nightmareticks = 0;
Darkrainightmareloop(%zombie,%targ);
       if(!%Zombie.isplayerDark) {
       %pos = vectoradd(%Zombie.getPosition(),"0 0 5");
	   %Zombie.setTransform(vectoradd(getRandomPosition(500,1),%pos));
       messageClient(%targ,'msgClient',"~wfx/misc/diagnostic_on.wav");
	   messageClient(%targ,'msgClient',"\c0Lord Darkrai Teleported!");
       }
       %randMessage = getrandom(3)+1;
          switch(%randMessage) {
          case 1:
          MessageAll('MessageAll', "\c4Lord Darkrai: Let the nightmare begin, "@%targ.namebase@".");
          case 2:
          MessageAll('MessageAll', "\c4Lord Darkrai: Taste my vengance... "@%targ.namebase@".");
          case 3:
          MessageAll('MessageAll', "\c4Lord Darkrai: Sleep Forever... "@%targ.namebase@".");
          default:
          MessageAll('MessageAll', "\c4Lord Darkrai: This Nightmare will lock you forever "@%targ.namebase@"!");
          }
}

function superPlayerDarkraisummon(%player) {
if(!isobject(%player) || %player.getState() $= "dead") {
return;
}
if(!%player.cansummon) {
return;
}
%type = getrandom(1,6);
%msg = getrandom(1,3);
switch(%msg) {
case 1:
messageall('DarkraiMsg',"\c4Lord Darkrai: These Should do fine...");
case 2:
messageall('DarkraiMsg',"\c4Lord Darkrai: Deeestroy.. Hah! I always wanted to say that!");
case 3:
messageall('DarkraiMsg',"\c4Lord Darkrai: Take out my Target!");
}
%player.cansummon = 0;
schedule(40000,0,"resetRAAMSummon",%player);
for(%i=0;%i<5;%i++) {
%pos = vectoradd(%player.getPosition(),getRandomPosition(10,1));
%fpos = vectoradd("0 0 5",%pos);
StartAZombie(%fpos, %type);
}
%player.setMoveState(true);
%player.setActionThread($Zombie::RAAMThread,true);
schedule(3500,0,"unfreezeZombieobject",%player);
}

function PlayerFireTicksLoop(%player) {
if(!isobject(%player) || %player.getState $= "dead"){
return;
}
schedule(100,0,"PlayerFireTicksLoop", %player);
%player.sfireticks++;
if(%player.sfireticks > 300) {
%player.sfireticks = 300;
}
}

function PlayerDarkraiFire(%player) {
   if(%player.sfireticks < 300) {
   return;
   }
   %player.sfireticks = 0;
   	   %p = new LinearFlareProjectile()
   	   {
   	   	dataBlock        = DarkraiSniperShot;
        initialDirection = %player.getMuzzleVector(6);
        initialPosition  = %player.getMuzzlePoint(6);
   	   	sourceObject     = %player;
   	   	sourceSlot       = 6;
   	   };
       MissionCleanup.add(%p);
}












function StartBossMusic(%bossName, %zombieObject) {
   if(%zombieObject.watched) {
   return;
   }
   echo("Boss Music Loaded");
   $TWM::BossBattle = 1; //Easier And More Efficient
   MusicZombieCheck(%zombieObject);
   %count = ClientGroup.getCount();
   for(%i = 0; %i < %count; %i++) {
      %cl = ClientGroup.getObject(%i);
      if(%bossName $= "Raam") {
      PlayBossIntro("GeneralRaam", %cl);
      CommandToClient(%cl,'StopMusic');
      CommandToClient(%cl,'PlayMusic',"RAAMBoss");
      }
      else if(%bossName $= "Darkrai") {
      PlayBossIntro("LordDarkrai", %cl);
      CommandToClient(%cl,'StopMusic');
      CommandToClient(%cl,'PlayMusic',"DarkraiBoss");
      }
      else if(%bossName $= "LordRaam") {
      PlayBossIntro("LordRaam", %cl);
      CommandToClient(%cl,'StopMusic');
      CommandToClient(%cl,'PlayMusic',"LordRaamBoss");
      }
      else if(%bossName $= "GOF") {
      PlayBossIntro("GhostFire", %cl);
      CommandToClient(%cl,'StopMusic');
      CommandToClient(%cl,'PlayMusic',"LordRaamBoss");
      }
      else {
      return;
      }
   echo("Music Loaded for "@%bossName@" on "@getTaggedString(%cl.name)@"");
   }
}

function MusicZombieCheck(%z) {
   if(!isObject(%z) || %z.getState() $= "dead") {
      $TWM::BossBattle = 0;
      %count = ClientGroup.getCount();
      for(%i = 0; %i < %count; %i++) {
         %cl = ClientGroup.getObject(%i);
         commandtoclient(%cl, 'playmusic', "desert");
      }
   echo("Music Stopped");
   return;
   }
   schedule(1000,0,"MusicZombieCheck", %z);
}

function FindValidTarget(%zombie) {   //This is usefull
   %client = ClientGroup.getObject(GetRandom()*ClientGroup.getCount());
   if(%client.ignoredbyZombs) {
   return schedule(500,0,"FindValidTarget", %zombie); //Keep Looking;
   }
   return %client; //target is good
}
