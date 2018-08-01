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

datablock ShapeBaseImageData(ZSniperImage)
{
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

datablock SeekerProjectileData(LordRaamStiloutte)
{
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

function ZcreateLoop(%obj) 
{ 
  if($host::nozombs)
  return;
   if(isObject(%obj))
   {
	if(%obj.timedout == 0){
	   if(%obj.numZ <= 2 || %obj.numZ $= ""){
		ZPCreateZombie(%obj);
		if(%obj.numZ $= "")
		   %obj.numZ = 0;
		%obj.numZ++;
		%obj.timedout = 1;
		schedule(10000, %obj, "TimedInF", %obj);
	   }
	}
   	%obj.ZCLoop = schedule(2000, 0, "ZcreateLoop", %obj); 
   }
} 

function TimedInF(%obj){
   %obj.timedout = 0;
}

//this is for when a ZSpawn spawns a zombie
function ZPCreateZombie(%obj){
  if($host::nozombs)
  return;
   %Cpos = vectorAdd(%obj.getposition() ,%obj.getUpvector());
   if(%obj.Ztype $= ""){
	%obj.ZType = 1;
   }
   if(%obj.ZType == 1){
   	%Zombie = new player(){
	   Datablock = "ZombieArmor";
   	};
	%Cpos = vectoradd(vectoradd(vectorscale(%obj.getUpvector(),1.15),"0 0 -1.15"),%obj.getposition());
    %zname ="Zombie";
   	%zombie.Typeinfo = 1;
   }
   else if(%obj.ZType == 2){
   	%Zombie = new player(){
	   Datablock = "FZombieArmor";
   	};
	%Cpos = vectoradd(vectoradd(vectorscale(%obj.getUpvector(),1.15),"0 0 -1.15"),%obj.getposition());
    %zname ="Ravenger Zombie";
   	%zombie.Typeinfo = 2;
   }
   else if(%obj.ZType == 3){
   	%Zombie = new player(){
	   Datablock = "LordZombieArmor";
   	};
	%Cpos = vectoradd(vectoradd(vectorscale(%obj.getUpvector(),2.4),"0 0 -2.4"),%obj.getposition());
	%Zombie.mountImage(ZHead, 3);
	%Zombie.mountImage(ZBack, 4);
	%Zombie.mountImage(ZDummyslotImg, 5);
	%Zombie.mountImage(ZDummyslotImg2, 6);
	%zombie.firstFired = 0;
	%zombie.canmove = 1;
    %zname ="Zombie Lord";
    %zombie.Typeinfo = 3;
   }
   else if(%obj.ZType == 4){
	%Zombie = new player(){
	   Datablock = "DemonZombieArmor";
	};
	%zombie.mountImage(ZdummyslotImg, 4);
	%Cpos = vectoradd(vectoradd(vectorscale(%obj.getUpvector(),1.3),"0 0 -1.3"),%obj.getposition());
    %zname ="Demon Zombie";
    %zombie.Typeinfo = 4;
   }
   else if(%obj.ZType == 5){
	%Zombie = new player(){
	   Datablock = "RapierZombieArmor";
	};
	%Zombie.mountImage(ZWingImage, 3);
	%Zombie.mountImage(ZWingImage2, 4);
	%zombie.setActionThread("scoutRoot",true);
	%Cpos = vectoradd(vectoradd(vectorscale(%obj.getUpvector(),1),"0 0 -0.6"),%obj.getposition());
    %zname ="Air Rapier Zombie";
    %zombie.Typeinfo = 5;
   }
   else if(%obj.ZType == 6){
	%Zombie = new player(){
	   Datablock = "DemonZombieArmor";
	};
	%Cpos = vectoradd(vectoradd(vectorscale(%obj.getUpvector(),1.3),"0 0 -1.3"),%obj.getposition());
	%zombie.mountImage(ZSniperImage, 3);
    %zname ="Sniper Zombie";
    %zombie.Typeinfo = 6;
   }
   else if(%obj.ZType == 7){
	%Zombie = new player(){
	   Datablock = "RAAMZombieArmor";
	};
	%Cpos = vectoradd(vectoradd(vectorscale(%obj.getUpvector(),1.3),"0 0 -1.3"),%obj.getposition());
	%zombie.mountImage(ZdummyslotImg, 4);
    //RAAM's Weapon Images
    %zombie.mountImage(ZMG42BaseImage, 5);
    %zombie.mountImage(RAAMSAWImage1, 6);
    %zombie.mountImage(RAAMSAWImage2, 7);
    %zombie.mountImage(RAAMSAWImage3, 8);
    %zname ="General RAAM";
    %zombie.Typeinfo = 8;
    %zombie.shotsfired = 0;
    %zombie.rapiershield = 1;
    %zombie.israam = 1;
    schedule(100,0,"RAAMShieldUpdate",%zombie);
    superRaamSummon(%zombie);
   }
   %zombie.type = %obj.Ztype;
   %Zombie.setTransform(%Cpos);
   %Zombie.team = $zombie::team;
   %zombie.canjump = 1;
   %zombie.HasCP = 1;
   %zombie.canInfect = 1;
   if(%obj.spawnTypeset == 1)
	%obj.numZ = 3;
   else
      %zombie.CP = %obj;
   %zombie.hastarget = 1;
   %zombie.iszombie =1;
   %zombie.target = createTarget(%zombie, %zname, "", "Derm3", '', %zombie.team, PlayerSensor);
   setTargetSensorData(%zombie.target, PlayerSensor);
   setTargetSensorGroup(%zombie.target, 0);
   setTargetName(%zombie.target, addtaggedstring(%zname));
   setTargetSkin(%zombie.target, 'Horde');
   MissionCleanup.add(%Zombie);
   schedule(1000, %zombie, "ZombieLookforTarget", %zombie);
}

//This is for creation of a zombie at a location using the console
function StartAZombie(%pos, %type){
  if($host::nozombs)
  return;
   if(%Type == 1){
   	%Zombie = new player(){
	   Datablock = "ZombieArmor";
   	};
    %zname ="Zombie";
    %zombie.Typeinfo = 1;
   }
   else if(%Type == 2){
   	%Zombie = new player(){
	   Datablock = "FZombieArmor";
   	};
    %zname ="Ravenger Zombie";
    %zombie.Typeinfo = 2;
   }
   else if(%Type == 3){
   	%Zombie = new player(){
	   Datablock = "LordZombieArmor";
   	};
	%Zombie.mountImage(ZHead, 3);
	%Zombie.mountImage(ZBack, 4);
	%Zombie.mountImage(ZDummyslotImg, 5);
	%Zombie.mountImage(ZDummyslotImg2, 6);
	%zombie.firstFired = 0;
	%zombie.canmove = 1;
    %zname ="Zombie Lord";
    %zombie.Typeinfo = 3;
   }
   else if(%type == 4){
	%Zombie = new player(){
	   Datablock = "DemonZombieArmor";
	};
	%zombie.mountImage(ZdummyslotImg, 4);
    %zname ="Demon Zombie";
    %zombie.Typeinfo = 4;
   }
   else if(%type == 5){
	%Zombie = new player(){
	   Datablock = "RapierZombieArmor";
	};
	%Zombie.mountImage(ZWingImage, 3);
	%Zombie.mountImage(ZWingImage2, 4);
	%zombie.setActionThread("scoutRoot",true);
    %zname ="Air Rapier Zombie";
    %zombie.Typeinfo = 5;
   }
   else if(%type == 6){
	%Zombie = new player(){
	   Datablock = "DemonZombieArmor";
	};
    %zname ="Sniper Zombie";
	%zombie.mountImage(ZSniperImage, 3);
    %zombie.Typeinfo = 6;
   }
   else if(%type == 7){
	%zombie = new player(){
	   Datablock = "DemonZombieArmor";
	};
    %zname ="Assasin Sniper Zombie";
    %zombie.isspecific = 1;
	%zombie.mountImage(ZSniperImage, 3);
    %zombie.Typeinfo = 6;
   }
//   else if(%type == 8){          //no longer implemented
//	%zombie = new player(){
//	   Datablock = "RapierZombieArmor";
//	};
//	%zombie.mountImage(ZWingImage, 3);
//	%zombie.mountImage(ZWingImage2, 4);
//	%zombie.setActionThread("scoutRoot",true);
//    %zname = "Rapier";
//    %zombie.Typeinfo = 7; //Rapier Setting for ZRPG
//    %zombie.israpier = 1;
//   }
   else if(%type == 9){
	%Zombie = new player(){
	   Datablock = "RAAMZombieArmor";
	};
	%zombie.mountImage(ZdummyslotImg, 4);
    //RAAM's Weapon Images
    %zombie.mountImage(ZMG42BaseImage, 5);
    %zombie.mountImage(RAAMSAWImage1, 6);
    %zombie.mountImage(RAAMSAWImage2, 7);
    %zombie.mountImage(RAAMSAWImage3, 8);
    %zname ="General RAAM";
    %zombie.Typeinfo = 8;
    %zombie.shotsfired = 0;
    %zombie.rapiershield = 1;
    %zombie.israam = 1;
    superRaamSummon(%zombie);
    schedule(100,0,"RAAMShieldUpdate",%zombie);
    schedule(500,0,"StartBossMusic","Raam", %zombie); //Starts a little later so the check runs
   }
   else if(%type == 10){
	%Zombie = new player(){
	   Datablock = "DarkraiZombieArmor";
	};
    %zname ="Lord Darkrai";
    %zombie.Typeinfo = 10;
    %zombie.sfireticks = 0;
    %zombie.usedlifeup = 0;
    superDarkraisummon(%zombie);
    RandomDarkraiNightmare(%zombie);
    schedule(500,0,"StartBossMusic","Darkrai", %zombie);
    %zombie.damage(0, %target.getposition(), 1.0, $DamageType::admin);
   }
   else if(%type == 11){   //fake darkrai
	%Zombie = new player(){
	   Datablock = "DarkraiZombieArmor";
	};
    %zname ="Lord Darkrai";
    %zombie.Typeinfo = 11;
    %zombie.sfireticks = 0;
    %zombie.usedlifeup = 1;
//    RandomDarkraiNightmare(%zombie);
    %zombie.damage(0, %target.getposition(), 450.0, $DamageType::admin);
   }
   else if(%type == 12){
	%Zombie = new player(){
	   Datablock = "LordRAAMZombieArmor";
	};
	%zombie.mountImage(ZdummyslotImg, 4);
    %zname ="Lord RAAM";
    %zombie.Typeinfo = 12;
    %zombie.rapiershield = 1;
    %zombie.isLraam = 1;
    %zombie.iszombie = 1;
    StartLRAbilities(%zombie);
    schedule(100,0,"RAAMShieldUpdate",%zombie);
    schedule(500,0,"StartBossMusic","LordRaam", %zombie);
   }
   %zombie.type = %type;
   %Zombie.setTransform(%pos);
   %Zombie.team = $zombie::team;
   %zombie.canjump = 1;
   %zombie.hastarget = 1;
   %zombie.canInfect = 1;
   MissionCleanup.add(%Zombie);
   %zombie.iszombie =1;
   %zombie.target = createTarget(%zombie, %zname, "", "Derm3", '', %zombie.team, PlayerSensor);
   setTargetSensorData(%zombie.target, PlayerSensor);
   setTargetSensorGroup(%zombie.target, 0);
   setTargetName(%zombie.target, addtaggedstring(%zname));
   setTargetSkin(%zombie.target, 'Horde');
   if(!%zombie.isspecific)
   schedule(1000, %zombie, "ZombieLookforTarget", %zombie);
}

//This is for when someone is killed by a zombie and spawns a new one
function CreateZombie(%obj){
  if($host::nozombs)
  return;
   %Cpos = %obj.getposition();
   %Zombie = new player(){
	Datablock = "ZombieArmor";
   };
   %Zombie.setTransform(%Cpos);
   %zombie.type = 1;
   %Zombie.team = 29;
   %zombie.canjump = 1;
   %zombie.hastarget = 1;
   %zname ="Zombie";
   %zombie.iszombie =1;
   %zombie.canInfect = 1;
   MissionCleanup.add(%Zombie);
   %zombie.target = createTarget(%zombie, %zname, "", "Derm3", '', %zombie.team, PlayerSensor);
   setTargetSensorData(%zombie.target, PlayerSensor);
   setTargetSensorGroup(%zombie.target, 0);
   setTargetName(%zombie.target, addtaggedstring(%zname));
   setTargetSkin(%zombie.target, 'Horde');
   schedule(1000, %zombie, "ZombieLookforTarget", %zombie);
}

function ZombieLookforTarget(%zombie) {
   if(!isObject(%zombie))
	return;
   if(%Zombie.getState() $= "dead")
	return;
   %pos = %zombie.getposition();
   %wbpos = %zombie.getworldboxcenter();
   %count = ClientGroup.getCount();
   %closestClient = -1;
   %closestDistance = 32767;
   for(%i = 0; %i < %count; %i++)
   {
	%cl = ClientGroup.getObject(%i);
	if(isObject(%cl.player) && !%cl.ignoredbyZombs){
	   %testPos = %cl.player.getWorldBoxCenter();
	   %distance = vectorDist(%wbpos, %testPos);
	   if (%distance > 0 && %distance < %closestDistance && %cl.player.isFTD != 1 && %cl.player.iszombie != 1)
	   {
	   	%closestClient = %cl;
	   	%closestDistance = %distance;
	   }
	}
   }
   if(%closestClient){
	if (%zombie.type == 1)
         Zombiemovetotarget(%zombie,%closestClient,%closestDistance);
	else if (%zombie.type == 2)
         FZombiemovetotarget(%zombie,%closestClient,%closestDistance);
	else if (%zombie.type == 3)
         LZombiemovetotarget(%zombie,%closestClient,%closestDistance);
	else if (%zombie.type == 4)
	   DZombiemovetotarget(%zombie,%closestClient,%closestDistance);
	else if (%zombie.type == 5)
	   RZombiemovetotarget(%zombie,%closestClient,%closestDistance);
	else if (%zombie.type == 6)
	   SniperZombiemovetotarget(%zombie,%closestClient,%closestDistance);
	else if (%zombie.type == 9 || %zombie.Typeinfo == 8)
	   RAAMmovetotarget(%zombie,%closestClient,%closestDistance);
	else if (%zombie.type == 10 || %zombie.type == 11)
	   Darkraimovetotarget(%zombie,%closestClient,%closestDistance);
    else if (%zombie.type == 12)
       LordRAAMmovetotarget(%zombie,%closestClient,%closestDistance);
   }
   %zombie.ZombieTargeting = schedule(500, %zombie, "ZombieLookForTarget", %zombie);
}

function Zombiemovetotarget(%zombie,%closestClient,%closestDistance){
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %closestClient = %closestClient.Player;
   if(%closestDistance <= $zombie::detectDist){ 
	if(%zombie.hastarget != 1){
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   ZDoMoan(%zombie);

	%clpos = %closestClient.getPosition();
      %vector = vectorNormalize(vectorSub(%clpos, %pos)); 
	%v1 = getword(%vector, 0);
	%v2 = getword(%vector, 1);
	%nv1 = %v2;
	%nv2 = (%v1 * -1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));

	%fmultiplier = $Zombie::ForwardSpeed;
	if(%closestDistance <= $zombie::lungDist && %zombie.canjump == 1)
	   %fmultiplier = (%fmultiplier * 4);
	%vector = vectorscale(%vector, %Fmultiplier);
	%upvec = "150";
	if(%closestDistance <= $zombie::lungDist && %zombie.canjump == 1){
	   %upvec = %upvec * 2;
	   %zombie.canjump = 0;
	   schedule(1500, %zombie, "Zsetjump", %zombie);
	}
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= 600)
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
}

function FZombiemovetotarget(%zombie,%closestClient,%closestDistance){
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %closestClient = %closestClient.Player;
   if(%closestDistance <= $zombie::detectDist){ 
	if(%zombie.hastarget != 1){
	   %zombie.hastarget = 1;
	}
	%zombie.setActionThread("scoutRoot",true);
	%upvec = "250";
	%fmultiplier = $Zombie::FForwardSpeed;

	//moanStuff
	%chance = (getrandom() * 50);
   	if(%chance >= 49)
	   ZDoMoan(%zombie);

	//Rotation stuff
	%clpos = %closestClient.getPosition();
      %vector = vectorNormalize(vectorSub(%clpos, %pos)); 
	%v1 = getword(%vector, 0);
	%v2 = getword(%vector, 1);
	%nv1 = %v2;
	%nv2 = (%v1 * -1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));

	//Move Stuff
	if(%closestDistance <= $zombie::lungDist && %zombie.canjump == 1 && getword(%vector, 2) <= "0.8" ){
	   %zombie.setvelocity("0 0 0");
	   %fmultiplier = (%fmultiplier * 2);
	   %upvec = (%upvec * 3.5);
	   %zombie.canjump = 0;
	   schedule(2000, %zombie, "Zsetjump", %zombie);
	}
	%vector = vectorscale(%vector, %Fmultiplier);
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= "1200" && %zombie.canjump == 1){
	   %zombie.setvelocity("0 0 0");
	   %upvec = (%upvec * 8);
	   %x = (%x * 0.5);
	   %y = (%y * 0.5);
	   %zombie.canjump = 0;
	   schedule(2500, %zombie, "Zsetjump", %zombie);
	}

	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   	%zombie.setActionThread("ski",true);
   }
}

function LZombiemovetotarget(%zombie,%closestClient,%closestDistance){
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %closestClient = %closestClient.Player;
   if(%closestDistance <= $zombie::detectDist && %zombie.canmove != 0){ 
	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   LZDoMoan(%zombie);

	%clpos = %closestClient.getPosition();
      %vector = vectorNormalize(vectorSub(%clpos, %pos)); 
	%nv2 = (getword(%vector, 0) * -1);
	%nv1 = getword(%vector, 1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));
	if(%zombie.ATCount >= 20){
	   %zombie.ATCount = 0;
	   %zombie.nomove = 1;
   	   %zombie.Fire = schedule(1250, %zombie, "ZFire", %zombie, %closestClient);
	   %zombie.Charge = schedule(500, %zombie, "ChargeEmitter", %zombie);
	   %zombie.chargecount = 0;
	}
	if(%zombie.nomove != 1) {
	%fmultiplier = $Zombie::LForwardSpeed;
	%upvec = "150";
	if(%closestDistance <= $zombie::LKillDist && %zombie.canjump == 1){
	   %vec = vectoradd(%pos,vectorScale(%vector,($zombie::LkillDist - 1.6)));
	   %mask = $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::TerrainObjectType | $TypeMasks::PlayerObjectType;
	   %searchResult = containerRayCast(vectoradd(%pos,vectorScale(%vector,1.6)), %vec, %mask, %zombie);
	   if(%searchResult){
		%searchObj = getWord(%searchResult,0);
		if(%searchObj $= %closestClient){
		   %chance = getrandom(1,5);
		   if(%chance == 1){
			%dir = %zombie.getEyeVector();
			%dir = vectornormalize(getword(%dir,0)@" "@getword(%dir,1)@" 0");
			%dir = vectoradd(vectorscale(%dir,7500),"0 0 1000");
			%closestclient.applyimpulse(%clpos,%dir);
			%closestclient.damage(0, %clpos, 0.8, $DamageType::ZombieL);
		   }
		   else{
	   		%zombie.setvelocity("0 0 0");
	   		%zombie.canjump = 0;
	   		schedule(1000, %zombie, "Zsetjump", %zombie);
	   		Llifttarget(%zombie,%closestclient,0);
			return;
		   }
		}
	   }
	}
	else if(%closestDistance <= ($zombie::LKillDist + $zombie::lungDist)){
	   %zombie.setvelocity("0 0 0");
	   %fmultiplier = (%fmultiplier * 2.5);
	}
	%vector = vectorscale(%vector, %Fmultiplier);
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= 4000)
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
	%zombie.ATCount++;
	}
   }
   else if(%zombie.hastarget == 1 && %zombie.canmove != 0){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
}

function DZombiemovetotarget(%zombie,%closestClient,%closestDistance){
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %closestClient = %closestClient.Player;
   if(%closestDistance <= $zombie::detectDist){ 
	if(%zombie.hastarget != 1 && %closestdistance >= 10 && %closestdistance <= 150){
	   DzombieFire(%zombie,%closestclient);
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	}
	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   LZDoMoan(%zombie);

	%clpos = %closestClient.getPosition();
      %vector = vectorNormalize(vectorSub(%clpos, %pos)); 
	%v1 = getword(%vector, 0);
	%v2 = getword(%vector, 1);
	%nv1 = %v2;
	%nv2 = (%v1 * -1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));

	if (%closestdistance >= 10 && %closestdistance <= 150 && %zombie.canjump == 1){
	   DzombieFire(%zombie,%closestclient);
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	   return;
	}
	%vector = vectorscale(%vector, $Zombie::DForwardSpeed);
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= ($Zombie::DForwardSpeed / 3 * 2))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
}

function RAAMmovetotarget(%zombie,%closestClient,%closestDistance){
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %closestClient = %closestClient.Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.hastarget != 1 && %closestdistance >= 10 && %closestdistance <= 500){
	   RAAMFire(%zombie,%closestclient);
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	}
	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   LZDoMoan(%zombie);

	%clpos = %closestClient.getPosition();
      %vector = vectorNormalize(vectorSub(%clpos, %pos));
	%v1 = getword(%vector, 0);
	%v2 = getword(%vector, 1);
	%nv1 = %v2;
	%nv2 = (%v1 * -1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));

	if (%closestdistance >= 10 && %closestdistance <= 500 && %zombie.canjump == 1){
	   RAAMFire(%zombie,%closestclient);
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	   return;
	}
	%vector = vectorscale(%vector, $Zombie::DForwardSpeed);
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= ($Zombie::DForwardSpeed / 3 * 2))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
}

function RZombiemovetotarget(%zombie,%closestClient,%closestDistance){
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %zombie.setActionThread("scoutRoot",true);
   %closestClient = %closestClient.Player;
   if(%closestDistance <= $zombie::detectDist){ 
	if(%zombie.wingset == 1){
	   %zombie.wingset = 0;
	   %Zombie.mountImage(ZWingImage, 3);
	   %Zombie.mountImage(ZWingImage2, 4);
	}
	else{
	   %zombie.wingset = 1;
	   %Zombie.mountImage(ZWingaltImage, 3);
	   %Zombie.mountImage(ZWingaltImage2, 4);
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   ZDoMoan(%zombie);
	if(%zombie.iscarrying == 1){
	   %vector = vectorscale(%zombie.getForwardVector(),($Zombie::RForwardSpeed / 2));
	   %vector = getword(%vector, 0)@" "@getword(%vector, 1)@" "@($zombie::Rupvec * 1.5);
	   %zombie.applyImpulse(%zombie.getposition(), %vector);
	   return;
	}

	%clpos = %closestClient.getWorldBoxCenter();
      %vector = vectorNormalize(vectorSub(%clpos, %pos)); 
	%v1 = getword(%vector, 0);
	%v2 = getword(%vector, 1);
	%nv1 = %v2;
	%nv2 = (%v1 * -1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));

	%z = Getword(%vector,2);
	%spd = vectorLen(%zombie.getVelocity());
	%fallpoint = 0.05 - (%spd / 630);
	if(%closestdistance <= 15 || %z > (0.25 + %fallpoint) || %z < (-1 * (0.25 + %fallpoint))){
	   if(%z < 0)
	      %upvec = ($zombie::Rupvec * (%z - (%spd / 130)));
	   if(%z >= 0)
		%upvec = ($zombie::Rupvec * (%z + 1));
	   if(%spd <= 5)
		%vector = vectorScale(%vector,3);
	}
	else{
	   %upvec = $zombie::Rupvec * (%z + 1.2);
	   %spdmod = 1;
	}
	if(%z < 0)
	   %z = %z * -1;

	%Zz = getWord(%zombie.getVelocity(),2);
	if(%Zz <= -40){
         %result = containerRayCast(%pos, vectoradd(%pos,vectorScale("0 0 1",%Zz * 2)), $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType, %zombie);
	   if(%result)
		%upvec = $zombie::Rupvec * 5;
	}

	%vector = vectorscale(%vector, ($Zombie::RForwardSpeed * (1 - %z)));
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
  }
  
function SniperZombiemovetotarget(%zombie,%closestClient,%closestDistance){
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %closestClient = %closestClient.Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.hastarget != 1 && %closestdistance >= 10 && %closestdistance <= $zombie::sniperrange){
	   SZombieFire(%zombie,%closestclient);
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	}
	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   LZDoMoan(%zombie);

	%clpos = %closestClient.getPosition();
      %vector = vectorNormalize(vectorSub(%clpos, %pos));
	%v1 = getword(%vector, 0);
	%v2 = getword(%vector, 1);
	%nv1 = %v2;
	%nv2 = (%v1 * -1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));

	if (%closestdistance >= 10 && %closestdistance <= $zombie::sniperrange && %zombie.canjump == 1){
	   SZombieFire(%zombie,%closestclient);
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	   return;
	}
	%vector = vectorscale(%vector, $Zombie::DForwardSpeed);
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= ($Zombie::DForwardSpeed / 3 * 2))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
}

function SniperZombiemovetospectarget(%zombie,%target){
   if(!isobject(%zombie) || %zombie.getstate() $= "dead")
   return;
   if(!isobject(%target.player) || %target.player.getstate() $= "dead") {
   schedule(500,0,"SniperZombiemovetospectarget",%zombie,%target);
   return;
   }
   %zombie.sfireticks++;
   %pos = %zombie.getworldboxcenter();
   %testPos = %target.player.getWorldBoxCenter();
   %closestDistance = vectorDist(%wbpos, %testPos);
   %closestClient = %target.Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.hastarget != 1 && %closestdistance >= 50 && %zombie.sfireticks >= 20){      //Fire At Distances Larger Than 50M
	   SzombieFire(%zombie,%closestclient);
	}
	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   LZDoMoan(%zombie);

	%clpos = %closestClient.getPosition();
      %vector = vectorNormalize(vectorSub(%clpos, %pos));
	%v1 = getword(%vector, 0);
	%v2 = getword(%vector, 1);
	%nv1 = %v2;
	%nv2 = (%v1 * -1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));

	if (%closestdistance >= 50 && %zombie.sfireticks >= 20){
	   SzombieFire(%zombie,%closestclient);
       schedule(100,0,"SniperZombiemovetospectarget",%zombie,%target);
	   return;
	}
	%vector = vectorscale(%vector, $Zombie::DForwardSpeed);
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= ($Zombie::DForwardSpeed / 3 * 2))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
   schedule(100,0,"SniperZombiemovetospectarget",%zombie,%target);
}

function Darkraimovetotarget(%zombie,%closestClient,%closestDistance){
   %zombie.sfireticks++;
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %closestClient = %closestClient.Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.hastarget != 1 && %closestdistance >= 10 && %closestdistance <= $zombie::sniperrange){
       if(%zombie.sfireticks > 70) {
	   DarkraiZombieFire(%zombie,%closestclient);
       %Zombie.sfireticks = 0;
       }
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	}
	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   LZDoMoan(%zombie);

	%clpos = %closestClient.getPosition();
      %vector = vectorNormalize(vectorSub(%clpos, %pos));
	%v1 = getword(%vector, 0);
	%v2 = getword(%vector, 1);
	%nv1 = %v2;
	%nv2 = (%v1 * -1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));

	if (%closestdistance >= 10 && %closestdistance <= $zombie::sniperrange && %zombie.canjump == 1){
       if(%zombie.sfireticks > 70) {
	   DarkraiZombieFire(%zombie,%closestclient);
       %Zombie.sfireticks = 0;
       }
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	   return;
	}
	%vector = vectorscale(%vector, $Zombie::DForwardSpeed);
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= ($Zombie::DForwardSpeed / 3 * 2))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
}

function LordRAAMmovetotarget(%zombie,%closestClient,%closestDistance){
   %zombie.setVelocity("0 0 0");
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %closestClient = %closestClient.Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.hastarget != 1 && %closestdistance >= 10 && %closestdistance <= 500){
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	}
	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   LZDoMoan(%zombie);

	%clpos = %closestClient.getPosition();
      %vector = vectorNormalize(vectorSub(%clpos, %pos));
	%v1 = getword(%vector, 0);
	%v2 = getword(%vector, 1);
	%nv1 = %v2;
	%nv2 = (%v1 * -1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));

	if (%closestdistance >= 10 && %closestdistance <= 500 && %zombie.canjump == 1){
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	   return;
	}
	%vector = vectorscale(%vector, $Zombie::ForwardSpeed);
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= ($Zombie::ForwardSpeed / 3 * 2))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
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

function ZFire(%zombie, %target){
   if(isobject(%zombie) && isobject(%target)){
   	if(%Zombie.firstFired == 1){
         %vec = vectorsub(%target.getworldboxcenter(),%zombie.getMuzzlePoint(6));
	   %vec = vectoradd(%vec, vectorscale(%target.getvelocity(),vectorlen(%vec)/100)); 
	   %zombie.firstFired = 0;
   	   %zombie.nomove = 0;
   	   %p = new TracerProjectile() 
   	   { 
   	   	dataBlock        = LZombieAcidBall; 
   	   	initialDirection = %vec; 
   	   	initialPosition  = %zombie.getMuzzlePoint(6); 
   	   	sourceObject     = %zombie; 
   	   	sourceSlot       = 6; 
   	   };
   	}
   	else{
         %vec = vectorsub(%target.getworldboxcenter(),%zombie.getMuzzlePoint(5));
	   %vec = vectoradd(%vec, vectorscale(%target.getvelocity(),vectorlen(%vec)/100)); 
   	   %p = new TracerProjectile() 
   	   { 
   	   	dataBlock        = LZombieAcidBall; 
   	   	initialDirection = %vec; 
   	   	initialPosition  = %zombie.getMuzzlePoint(5); 
   	   	sourceObject     = %zombie; 
   	   	sourceSlot       = 5; 
   	   }; 
	   %zombie.firstFired = 1;
   	   %zombie.Fire = schedule(250, %zombie, "ZFire", %zombie, %target);
      }
   }
   else{
	%zombie.firstFired = 0;
	%zombie.nomove = 0;
   }
}

function Llifttarget(%zombie,%closestclient,%count){
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
	   %target.damage(0, %target.getposition(), 10.0, $DamageType::ZombieL);
	}
	%count = 0;
	%zombie.canmove = 1;
	return;
   }
   %count++;
   %zombie.killingplayer = schedule(150, %zombie, "Llifttarget", %zombie, %closestclient, %count);
}


function DZombieFire(%zombie,%closestclient){
   %pos = %zombie.getMuzzlePoint(4);
   %tpos = %closestclient.getWorldBoxCenter();
   %tvel = %closestclient.getvelocity();
   %vec = vectorsub(%tpos,%pos);
   %dist = vectorlen(%vec);
   %velpredict = vectorscale(%tvel,(%dist / 50));
   %vector = vectoradd(%vec,%velpredict);
   %ndist = vectorlen(%vector);
   %upvec = "0 0 "@((%ndist / 50) * (%ndist / 50) * 2);
   %vector = vectornormalize(vectoradd(%vector,%upvec));
   %p = new GrenadeProjectile() 
   { 
	dataBlock        = DemonFireball; 
	initialDirection = %vector; 
	initialPosition  = %pos; 
	sourceObject     = %zombie; 
	sourceSlot       = 4; 
   };
}

function ResetShield(%zombie) {
%zombie.rapiershield = 1;
}

function RAAMFire(%zombie,%closestclient) {
   if(!isobject(%zombie) || %zombie.getState() $= "dead")
   return;
   if(!isobject(%closestclient) || %closestclient.getState() $= "dead") {
   %zombie.shotsfired = 100;
   %zombie.setMoveState(false); //unfreeze him
   schedule(7500,0,"ResetRaamField",%zombie);
   schedule(10000,0,"RAAMReset",%zombie);
   return;
   }
   if(%zombie.shotsfired >= 100) {
   %zombie.setMoveState(false); //unfreeze him
   %zombie.rapiershield = 1;
   return;
   }
   %zombie.rapiershield = 0;
   %zombie.setMoveState(true); //freeze him
   %pos = %zombie.getMuzzlePoint(5);
   %vec = vectorsub(%closestclient.getworldboxcenter(),%zombie.getMuzzlePoint(5));
   %vec = vectoradd(%vec, vectorscale(%closestclient.getvelocity(),vectorlen(%vec)/100));

   %x = (getRandom() - 0.5) * 2 * 3.1415926 * (6/1000);
   %y = (getRandom() - 0.5) * 2 * 3.1415926 * (6/1000);
   %z = (getRandom() - 0.5) * 2 * 3.1415926 * (6/1000);
   %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
   %nvec = MatrixMulVector(%mat, %vec);
   
   %zombie.shotsfired++;
   %p = new LinearFlareProjectile()
   {
	dataBlock        = RAAMCGProjectile;
	initialDirection = %nvec;
	initialPosition  = %pos;
	sourceObject     = %zombie;
	sourceSlot       = 5;
   };
   schedule(50,0,"RAAMFire",%zombie,%closestclient);
   if(%zombie.shotsfired == 1) {
   schedule(15000,0,"RAAMReset",%zombie);
   }
}

function RAAMReset(%zombie) {
%zombie.shotsfired = 0;
}

function DarkraiZombieFire(%zombie,%closestclient){
%vec = vectorsub(%closestclient.getworldboxcenter(),%zombie.getMuzzlePoint(6));
%vec = vectoradd(%vec, vectorscale(%closestclient.getvelocity(),vectorlen(%vec)/100));
%p = new LinearFlareProjectile()
{
dataBlock        = DarkraiSniperShot;
initialDirection = %vec;
initialPosition  = %zombie.getMuzzlePoint(0);
sourceObject     = %zombie;
sourceSlot       = 0;
};
}

function SZombieFire(%zombie,%closestclient){
%zombie.sfireticks = 0;
%vec = vectorsub(%closestclient.getworldboxcenter(),%zombie.getMuzzlePoint(6));
%vec = vectoradd(%vec, vectorscale(%closestclient.getvelocity(),vectorlen(%vec)/100));
%p = new LinearFlareProjectile()
{
dataBlock        = SniperShot;
initialDirection = %vec;
initialPosition  = %zombie.getMuzzlePoint(6);
sourceObject     = %zombie;
sourceSlot       = 6;
};
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

function ZSetRandomMove(%zombie){
   if (!isobject(%zombie))
	return;
   %RX = getrandom(-10, 10);
   %RY = getrandom(-10, 10);
   %RZ = getrandom();
   %vector = %RX@" "@%RY@" "@%RZ;
   %zombie.direction = vectornormalize(%vector);
   %zombie.Mnum = getrandom(1, 20);
   %zombie.zombieRmove = schedule(500, %zombie, "ZrandommoveLoop", %zombie);
}

function ZrandommoveLoop(%zombie){
   if (!isobject(%zombie))
	return;
   if (%Zombie.getState() $= "dead")
	return;
   if (%zombie.hastarget == 1){
	%zombie.direction = "";
	return;
   }
   if (%zombie.Mnum >= 1){
	%X = getword(%zombie.direction, 1);
	%Y = (getword(%zombie.direction, 0) * -1);
	%none = 0;
	%vector = %X@" "@%Y@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector));
	if(%zombie.type == 1)
	   %speed = ($zombie::forwardspeed);
	else if(%zombie.type == 2)
	   %speed = ($zombie::Fforwardspeed * 0.6);
	else if(%zombie.type == 4)
	   %speed = ($zombie::Dforwardspeed * 0.75);
	else if(%zombie.type == 6 || %zombie.type == 10)
	   %speed = ($zombie::Dforwardspeed);
	else if(%zombie.type == 3)
	   %speed = ($zombie::Lforwardspeed * 0.8);
	%vector = vectorscale(%zombie.direction, %speed);
	%zombie.applyimpulse(%zombie.getposition(), %vector);
	%zombie.Mnum = (%zombie.Mnum - 1);
	%zombie.zombieRmove = schedule(500, %zombie, "ZrandommoveLoop", %zombie);
   }
   else if(%zombie.Mnum == 0)
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
}

function InfectLoop(%obj){
   if($TWM::PlayingHorde) {
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
}

function zombieSpawnLoop(%pos, %radius, %freq){
   if(%freq > 10)
	%freq = 10;
   if(%freq < 1)
	%freq = 1;
   %chance = getRandom(1,50);
   if(%chance <= %freq && $numspawnedzombies < (%freq * 5)){
	%spawnPos = vectorAdd(%pos,(getRandom(0,%radius) - (%radius / 2))@" "@(getRandom(0,%radius) - (%radius / 2))@" getRandom(0,15)");
	%search = containerRayCast(%spawnPos, vectorAdd(%spawnPos,"0 0 -1000"), $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType);
	if(%search)
	   %spawnPos = getWord(%search,1)@" "@getWord(%search,2)@" "@getWord(%search,3);
	%chance = getRandom(1,75);
      if(%chance <= 25){
   	   %Zombie = new player(){
	      Datablock = "ZombieArmor";
   	   };
	   %Ztype = 1;
    %zombie.client.namebase ="A Zombie";
	}
      else if(%chance <= 35){
   	   %Zombie = new player(){
	      Datablock = "FZombieArmor";
   	   };
	   %Ztype = 2;
    %zombie.client.namebase ="A Ravenger Zombie";
	}
      else if(%chance <= 40){
   	   %Zombie = new player(){
	      Datablock = "LordZombieArmor";
   	   };
	   %Zombie.mountImage(ZHead, 3);
	   %Zombie.mountImage(ZBack, 4);
	   %Zombie.mountImage(ZDummyslotImg, 5);
	   %Zombie.mountImage(ZDummyslotImg2, 6);
	   %zombie.firstFired = 0;
	   %zombie.canmove = 1;
	   %Ztype = 3;
    %zombie.client.namebase ="A Zombie Lord";
	}
      else if(%chance <= 55){
   	   %Zombie = new player(){
	      Datablock = "DemonZombieArmor";
   	   };
	   %zombie.mountImage(ZdummyslotImg, 4);
	   %Ztype = 4;
    %zombie.client.namebase ="A Demon Zombie";
	}
      else if(%chance <= 65){
   	   %Zombie = new player(){
	      Datablock = "RapierZombieArmor";
   	   };
	   %Zombie.mountImage(ZWingImage, 3);
	   %Zombie.mountImage(ZWingImage2, 4);
	   %zombie.setActionThread("scoutRoot",true);
	   %Ztype = 5;
    %zombie.client.namebase ="A Air Rapier Zombie";
	}
      %zombie.type = %Ztype;
      %Zombie.setTransform(%spawnPos);
      %Zombie.team = $zombie::team;
      %zombie.canjump = 1;
      %zombie.hastarget = 1;
   %zombie.canInfect = 1;
   %zombie.iszombie =1;
	%zombie.randspawnerstarted = 1;
      MissionCleanup.add(%Zombie);
      schedule(1000, %zombie, "ZombieLookforTarget", %zombie);
	$numspawnedzombies++;
   }
   $zombieloop = schedule(500, 0, "zombieSpawnLoop", %pos, %radius, %freq);
}

function StopZombieSpawnLoop(){
   cancel($zombieloop);
}

function ZombieBloodLust(%obj, %count){
   if(!isObject(%obj))
	return;
   if (%obj.getState() $= "dead")
	return;
   %obj.setDamageFlash(0.5);
   if(%count == 10){
	serverPlay3d("ZombieMoan",%obj.getWorldBoxCenter()); 
	%count = 0;
   }
   %count++;
   schedule(200, %obj, "ZombieBloodLust", %obj, %count); 
}

function makePersonHumanFZomb(%trans, %client){
   %client.player.delete();
   %player = new Player() {
      dataBlock = "LightMaleHumanArmor";
   };

   %player.setTransform( %trans );
   MissionCleanup.add(%player);

   // setup some info
   %player.setOwnerClient(%client);
   %player.team = 1;
   %client.outOfBounds = false;
   %player.setEnergyLevel(0);
   %client.player = %player;

   // updates client's target info for this player
   %player.setTarget(%client.target);
   setTargetDataBlock(%client.target, %player.getDatablock());
   setTargetSensorData(%client.target, PlayerSensor);
   setTargetSensorGroup(%client.target, 1);
   %client.setSensorGroup(1);

   %client.setControlObject(%player);
   %player.client.clearBackpackIcon();
   buyFavorites(%client);

   %player.iszombie = 0;
}

function makePersonZombie(%trans, %client){
   %client.player.delete();

   %player = new Player() {
      dataBlock = "ZombieArmor";
   };

   %player.setTransform( %trans );
   MissionCleanup.add(%player);

   // setup some info
   %player.setOwnerClient(%client);
   %player.team = $zombie::team;
   %client.outOfBounds = false;
   %player.setEnergyLevel(0);
   %client.player = %player;
   %player.iszombie =1;
   %player.canInfect = 1;

   // updates client's target info for this player
   %player.setTarget(%client.target);
   setTargetDataBlock(%client.target, %player.getDatablock());
   setTargetSensorData(%client.target, PlayerSensor);
   setTargetSensorGroup(%client.target, 1);
   %client.setSensorGroup(1);

   %client.setControlObject(%player);
   %player.client.clearBackpackIcon();

   %player.iszombie = 1;

   ZombieBloodLust(%player,0);
   zombieAttackImpulse(%player,80);
}

function makePersonDemonZombie(%trans, %client){
   %client.player.delete();

   %player = new Player() {
      dataBlock = "DemonZombieArmor";
   };

   %player.setTransform( %trans );
   MissionCleanup.add(%player);

   // setup some info
   %player.setOwnerClient(%client);
   %player.team = $zombie::team;
   %client.outOfBounds = false;
   %player.setEnergyLevel(0);
   %client.player = %player;
   %player.iszombie =1;
   %player.canInfect = 1;

   // updates client's target info for this player
   %player.setTarget(%client.target);
   setTargetDataBlock(%client.target, %player.getDatablock());
   setTargetSensorData(%client.target, PlayerSensor);
   setTargetSensorGroup(%client.target, 1);
   %client.setSensorGroup(1);

   %client.setControlObject(%player);
   %player.client.clearBackpackIcon();

   %player.iszombie = 1;

   ZombieBloodLust(%player,0);
   zombieAttackImpulse(%player,80);
}


function resetattackImpulse(%obj)
{
%obj.setcancelimpulse = 0;
}

function zombieAttackImpulse(%obj, %count){
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

function makePersonZombieLord(%trans, %client){
   %client.player.delete();

   %player = new Player() {
      dataBlock = "LordZombieArmor";
   };

	%player.mountImage(ZHead, 3);   //Mount Zombie Lord Images
	%player.mountImage(ZBack, 4);
	%player.mountImage(ZDummyslotImg, 5);
	%player.mountImage(ZDummyslotImg2, 6);
 
   %player.setTransform( %trans );
   MissionCleanup.add(%player);

   // setup some info
   %player.setOwnerClient(%client);
   %player.team = $zombie::team;
   %client.outOfBounds = false;
   %player.setEnergyLevel(0);
   %client.player = %player;
   %player.iszombie =1;
   %player.setInventory(ZombGun,1,true);
   %player.canInfect = 1;

   // updates client's target info for this player
   %player.setTarget(%client.target);
   setTargetDataBlock(%client.target, %player.getDatablock());
   setTargetSensorData(%client.target, PlayerSensor);
   setTargetSensorGroup(%client.target, 1);
   %client.setSensorGroup(1);

   %client.setControlObject(%player);
   %player.client.clearBackpackIcon();

   %player.iszombie = 1;

   ZombieBloodLust(%player,0);
   zombieAttackImpulse(%player,80);
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

function makepersonAirRapier(%trans, %client){
   %client.player.delete();

   %player = new Player() {
      dataBlock = "RapierZombieArmor";
   };

   %player.setTransform( %trans );
   MissionCleanup.add(%player);

   // setup some info
   %player.setOwnerClient(%client);
   %player.team = $zombie::team;
   %client.outOfBounds = false;
   %player.setEnergyLevel(0);
   %client.player = %player;
   %player.iszombie =1;

   // updates client's target info for this player
   %player.setTarget(%client.target);
   setTargetDataBlock(%client.target, %player.getDatablock());
   setTargetSensorData(%client.target, PlayerSensor);
   setTargetSensorGroup(%client.target, 1);
   %client.setSensorGroup(1);

   %client.setControlObject(%player);
   %player.client.clearBackpackIcon();
   %player.canInfect = 1;

   %player.mountImage(ZWingImage, 3);
   %player.mountImage(ZWingImage2, 4);
   %player.iszombie = 1;

   RapierForwardImpulse(%player);
   ZombieBloodLust(%player,0);
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

function makePersonRavengerZombie(%trans, %client){
   %client.player.delete();

   %player = new Player() {
      dataBlock = "FZombieArmor";
   };

   %player.setTransform( %trans );
   MissionCleanup.add(%player);

   // setup some info
   %player.setOwnerClient(%client);
   %player.team = $zombie::team;
   %client.outOfBounds = false;
   %player.setEnergyLevel(0);
   %client.player = %player;
   %player.iszombie =1;

   // updates client's target info for this player
   %player.setTarget(%client.target);
   setTargetDataBlock(%client.target, %player.getDatablock());
   setTargetSensorData(%client.target, PlayerSensor);
   setTargetSensorGroup(%client.target, 1);
   %client.setSensorGroup(1);

   %client.setControlObject(%player);
   %player.client.clearBackpackIcon();
   %player.canInfect = 1;

   %player.iszombie = 1;

   RavengerForwardImpulse(%player);
   ZombieBloodLust(%player,0);
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

function makePersonRAAM(%trans, %client){
   %client.player.delete();

   %player = new Player() {
      dataBlock = "RAAMZombieArmor";
   };

   %player.setTransform( %trans );
   MissionCleanup.add(%player);

   // setup some info
   %player.setOwnerClient(%client);
   %player.team = $zombie::team;
   %client.outOfBounds = false;
   %player.setEnergyLevel(0);
   %client.player = %player;
   %player.iszombie =1;
   %player.mountImage(ZMG42BaseImage, 5);
   %player.mountImage(RAAMSAWImage1, 6);
   %player.mountImage(RAAMSAWImage2, 7);
   %player.mountImage(RAAMSAWImage3, 8);
   %player.shotsfired = 0;
   %player.rapiershield = 1;
   %player.israam = 1;
   %player.cansummon = 1;
   %player.canInfect = 1;
   schedule(100,0,"RAAMShieldUpdate",%player);

   // updates client's target info for this player
   %player.setTarget(%client.target);
   setTargetDataBlock(%client.target, %player.getDatablock());
   setTargetSensorData(%client.target, PlayerSensor);
   setTargetSensorGroup(%client.target, 1);
   %client.setSensorGroup(1);

   %client.setControlObject(%player);
   %player.client.clearBackpackIcon();

   %player.iszombie = 1;
//   ZombieBloodLust(%player,0);
}

function spawnaroundarea(%pos,%type,%am) {
for(%i=0;%i<%am;%i++) {
%time = %i * 1000;
%fpos = vectoradd(%pos,GetRandomPosition(100,1));
schedule(%time,0,"StartAZombie",%fpos,%type);
}
}

function spawnaroundclient(%cl,%type,%am) {
for(%i=0;%i<%am;%i++) {
%time = %i * 1000;
%fpos = vectoradd(%cl.player.getposition(),GetRandomPosition(100,1));
schedule(%time,0,"StartAZombie",%fpos,%type);
}
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
	   %target.damage(0, %target.getposition(), 10.0, $DamageType::ZombieL);
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

function superRaamSummon(%RAAM) {
if(!isobject(%RAAM) || %RAAM.getState() $= "dead") {
return;
}
if(%RAAM.getDatablock().maxDamage - %RAAM.getDamageLevel() > 75.0 ) {
%type = getrandom(1,6);
messageall('RAAMMsg',"\c4General RAAM: Destroy!!!");
schedule(40000,0,"superRaamSummon",%RAAM);
for(%i=0;%i<3;%i++) {
%pos = vectoradd(%RAAM.getPosition(),getRandomPosition(10,1));
%fpos = vectoradd("0 0 5",%pos);
StartAZombie(%fpos, %type);
}
}
else if(%RAAM.getDatablock().maxDamage - %RAAM.getDamageLevel() > 40.0  && %RAAM.getDatablock().maxDamage - %RAAM.getDamageLevel() < 74.9) {
%type = getrandom(1,6);
messageall('RAAMMsg',"\c4General RAAM: Destroy Them All!!!");
schedule(40000,0,"superRaamSummon",%RAAM);
for(%i=0;%i<8;%i++) {
%pos = vectoradd(%RAAM.getPosition(),getRandomPosition(10,1));
%fpos = vectoradd("0 0 5",%pos);
StartAZombie(%fpos, %type);
}
}
else if(%RAAM.getDatablock().maxDamage - %RAAM.getDamageLevel() < 39.9) {
%type = getrandom(1,6);
messageall('RAAMMsg',"\c4General RAAM: KILL THEM!! KILL THEM ALL!!!");
schedule(40000,0,"superRaamSummon",%RAAM);
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

function superLordRaamSummon(%RAAM) {
if(!isobject(%RAAM) || %RAAM.getState() $= "dead") {
return;
}
%type = getrandom(1,6);
messageall('RAAMMsg',"\c4Lord RAAM: Attack my target!");
for(%i=0;%i<5;%i++) {
%pos = vectoradd(%RAAM.getPosition(),getRandomPosition(10,1));
%fpos = vectoradd("0 0 5",%pos);
StartAZombie(%fpos, %type);
}
%RAAM.setMoveState(true);
%RAAM.setActionThread($Zombie::RAAMThread,true);
schedule(3500,0,"unfreezeZombieobject",%RAAM);
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

function RandomDarkraiNightmare(%zombie) {
   if(!isObject(%zombie) || %zombie.getState $= "dead") {
   return;
   }
   if(%zombie.getDatablock().maxDamage - %zombie.getDamageLevel() < 200.0) {
   MessageAll('MessageAll', "\c4Lord Darkrai: I'M GETTNG TIRED OF PLAYING THESE GAMES!!!");
   RealDarkraiDarkVoid(%zombie);
   return;
   }
   schedule(30000,0,"RandomDarkraiNightmare",%zombie);
   %client = FindValidTarget(%zombie);
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

function doZTeleport(%cl,%Z) {
   %zpos = %Z.getPosition();
   %cpos = %cl.player.getPosition();
   %Z.setTransform(%cpos);
   %cl.player.setTransform(%zpos);
   pl_fadeIn(%cl.player);
   pl_fadeIn(%Z);
   %Z.setVelocity("0 0 0"); //stop movement..
}

function ZombieRaamWacthDog(%darkrai, %raam) {
   if(!isobject(%raam) || %raam.getState() $= "dead" || $host::nozombs) {
   MessageAll('MessageAll', "\c4Lord Darkrai: Meh, he was worthless anyways!");
   %darkrai.rapiershield = 0;
   %darkrai.isObserving = 0;
   %darkrai.setTransform("0 0 150");
   %darkrai.setMoveState(false);
   %darkrai.pad.delete();
   return;
   }
   %Pad = new StaticShape() {
      dataBlock = DeployedSpine;
      scale = ".1 .1 1";
      position = "0 0 0";
   };
   %Pad.setCloaked(true);
   %darkrai.pad = %Pad;
   %Pos = %darkrai.getposition();
   %Vec = vectoradd(%Pos,"0 0 -0.5");
   %darkrai.pad.settransform(%Vec);
   %darkrai.setTransform("0 0 500");
   %darkrai.setVelocity("0 0 0");
   schedule(5000,0,"ZombieRaamWacthDog",%darkrai, %raam);
}

function StartLRAbilities(%zombie) {
   if(!isobject(%zombie) || %zombie.getState() $= "dead") {
   return;
   }
   %z = %zombie; //< Im lazy =-P
   %z.setVelocity("0 0 0");
   superLordRaamSummon(%z);
   %z.rapiershield = 0;
   schedule(10000,0,"ResetRaamField",%z);
   %rand = getRandom(1,6);
   switch(%rand) {
      case 1:
      %target = FindValidTarget(%z);
      if(isObject(%target.player) && !%target.ignoredbyZombs) {
         MessageAll('MessageAll', "\c4Lord Raam: Launch!");
         %SPos1 = vectorAdd(%z.getPosition(),"1 0 0");
         %SPos2 = vectorAdd(%z.getPosition(),"-1 0 0");
   	      %p1 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRaamStiloutte;
           initialDirection = "0 0 1";
           initialPosition  = %SPos1;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
   	      %p2 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRaamStiloutte;
           initialDirection = "0 0 1";
           initialPosition  = %SPos2;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
          MissionCleanup.add(%p1);
          MissionCleanup.add(%p2);
          schedule(5000,0,"MissileDrop",%p1, %target.player);
          schedule(5000,0,"MissileDrop",%p2, %target.player);
       }
       else {
          MessageAll('MessageAll', "\c4Lord Raam: Fools, you cannot withstand my power!");
       }
      case 2:
      %target = FindValidTarget(%z);
      if(isObject(%target.player) && !%target.ignoredbyZombs) {
         %z.laserStormSount = 0;
         MessageAll('MessageAll', "\c4Lord Raam: Laser Storm Begin!");
         LRLaserStorm(%z, %target.player);
       }
       else {
          MessageAll('MessageAll', "\c4Lord Raam: Fools, you cannot withstand my power!");
       }
      case 3:
      %target = FindValidTarget(%z);
      if(isObject(%target.player) && !%target.ignoredbyZombs) {
         MessageAll('MessageAll', "\c4Lord Raam: Metros Maul!");
         %fpos = vectoradd(%target.player.getposition(),getRandomposition(50,0));
         %pos2 = vectoradd(%fpos,"0 0 700");
         schedule(500,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
         schedule(1000,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
         schedule(1500,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
       }
       else {
          MessageAll('MessageAll', "\c4Lord Raam: Fools, you cannot withstand my power!");
       }
      case 4:
      %target = FindValidTarget(%z);
      if(isObject(%target.player) && !%target.ignoredbyZombs) {
         MessageAll('MessageAll', "\c4Lord Raam: Storm Begins!");
         %SPos1 = vectorAdd(%z.getPosition(),"1 0 0");
         %SPos2 = vectorAdd(%z.getPosition(),"-1 0 0");
   	      %p1 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRaamStiloutte;
           initialDirection = "0 0 10";
           initialPosition  = %SPos1;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
   	      %p2 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRaamStiloutte;
           initialDirection = "0 0 10";
           initialPosition  = %SPos2;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
          MissionCleanup.add(%p1);
          MissionCleanup.add(%p2);
          schedule(5000,0,"MissileDrop",%p1, %target.player);
          schedule(5000,0,"MissileDrop",%p2, %target.player);
          schedule(1000,0,"FireMoreMissiles", %z, %target.player);
          schedule(2000,0,"FireMoreMissiles", %z, %target.player);
       }
      case 5:
         %z.setDamageLevel(%z.getDamageLevel() - 100.0);
         MessageAll('MessageAll', "\c4Lord Raam: Restoration Power.");
      case 6:
         %z.setMoveState(true);
         schedule(7000,0,"unfreezeZombieobject",%z);
         %TargetSearchMask = $TypeMasks::PlayerObjectType;
         %c = createEmitter(%z.position,FlashLEmitter,"1 0 0");      //Rotate it
         schedule(1000,0,"killit",%c);
         InitContainerRadiusSearch(%z.getPosition(),200,%TargetSearchMask);
         while ((%potentialTarget = ContainerSearchNext()) != 0){
            if (%potentialTarget.getPosition() != %z.getPosition() && !%potentialtarget.client.ignoredbyZombs) {
               %potentialTarget.staticTicks = 0;
               SDischLoop(%potentialTarget);
            }
         }
         MessageAll('MessageAll', "\c4Lord Raam: Static Discharge!");
      default:
      %target = FindValidTarget(%z);
      if(isObject(%target.player) && !%target.ignoredbyZombs) {
         MessageAll('MessageAll', "\c4Lord Raam: Launch!");
         %SPos1 = vectorAdd(%z.getPosition(),"1 0 0");
         %SPos2 = vectorAdd(%z.getPosition(),"-1 0 0");
   	      %p1 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRaamStiloutte;
           initialDirection = "0 0 1";
           initialPosition  = %SPos1;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
   	      %p2 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRaamStiloutte;
           initialDirection = "0 0 1";
           initialPosition  = %SPos2;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
          MissionCleanup.add(%p1);
          MissionCleanup.add(%p2);
          schedule(5000,0,"MissileDrop",%p1, %target.player);
          schedule(5000,0,"MissileDrop",%p2, %target.player);
       }
       else {
          MessageAll('MessageAll', "\c4Lord Raam: Fools, you cannot withstand my power!");
       }
   }
   schedule(30000,0,"StartLRAbilities",%zombie);
}

function SDischLoop(%obj) {
   if(!isobject(%obj) || %obj.getState() $= "dead") {
   return;
   }
   if(%obj.staticTicks > 15) {
   %obj.setMoveState(false);
   return;
   }
   %c = createEmitter(%obj.position,PBCExpEmitter,"1 0 0");      //Rotate it
   schedule(1000,0,"killit",%c);
   %obj.setMoveState(true);
   %obj.staticTicks++;
   %obj.damage(0, %viewer.player.position, 0.05, $DamageType::Zombie);
   schedule(1000,0,"SDischLoop",%obj);
}

function FireMoreMissiles(%z, %t) {
         %SPos1 = vectorAdd(%z.getPosition(),"1 0 0");
         %SPos2 = vectorAdd(%z.getPosition(),"-1 0 0");
   	      %p1 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRaamStiloutte;
           initialDirection = "0 0 10";
           initialPosition  = %SPos1;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
   	      %p2 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRaamStiloutte;
           initialDirection = "0 0 10";
           initialPosition  = %SPos2;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
          MissionCleanup.add(%p1);
          MissionCleanup.add(%p2);
          schedule(5000,0,"MissileDrop",%p1, %t);
          schedule(5000,0,"MissileDrop",%p2, %t);
}

function resetLRLaserStorm(%z) {
%zomb.Storming = 0;
}

function LRLaserStorm(%z, %t) {
   if(!isObject(%t) || %t.getState() $= "dead") {
   %z.Storming = 0;
   return;
   }
   if(!isObject(%z) || %z.getState() $= "dead") {
   return;
   }
   %z.laserStormSount++;
   if(%z.laserStormSount < 40) {
        %vec = vectorsub(%t.getworldboxcenter(),%z.getMuzzlePoint(6));
        %vec = vectoradd(%vec, vectorscale(%t.getvelocity(),vectorlen(%vec)/100));
   	      %p = new LinearFlareProjectile()
   	      {
   	   	   dataBlock        = LaserShot;
           initialDirection = %vec;
           initialPosition  = %z.getMuzzlePoint(6);
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
          MissionCleanup.add(%p);
   }
   else {
   %z.Storming = 0;
   return;
   }
   schedule(100,0,"LRLaserStorm",%z, %t);
}

function MissileDrop(%m, %t) {
   %t.setHeat(100);
   %m.setObjectTarget(%t);
   HeatLoop(%t,0);
}

function HeatLoop(%t, %val) {
   if(!isObject(%t) || %t.getState() $= "dead") {
   return;
   }
   if(%val > 200) {
   return;
   }
   %val++;
   %t.setHeat(100);
   schedule(100,0,"HeatLoop", %t, %val);
}

function RandomAbility(%zombie) {
   if(!isobject(%zombie) || %zombie.getState() $= "dead") {
   return;
   }
   if(%zombie.isObserving) {
   schedule(30000,0,"RandomAbility",%zombie);
   return;
   }
   %rand = getRandom(1,8);
   switch(%rand) {
   case 1:
   MessageAll('MessageAll', "\c4Lord Darkrai: Presto, TELEPORTO!");
   %client = FindValidTarget(%zombie);
   if(isobject(%client.player) && !%client.ignoredbyZombs) {
   tp_emitter(%zombie);
   pl_fadeOut(%zombie);
   tp_emitter(%client.player);
   pl_fadeOut(%client.player);
   schedule(700,0,"doZTeleport",%client,%zombie);
   }
   else {
   MessageAll('MessageAll', "\c4Lord Darkrai: or... not.");
   }
   case 2:
   MessageAll('MessageAll', "\c4Lord Darkrai: hehehe.. who is who???");
   for(%i=0;%i<5;%i++) {
   %pos = vectoradd(%zombie.getPosition(),getRandomPosition(10,1));
   %fpos = vectoradd("0 0 5",%pos);
   StartAZombie(%fpos, 11);
   }
   case 3:
   MessageAll('MessageAll', "\c4Lord Darkrai: UNLEASH HELL!!!!");
   for(%i=0;%i<25;%i++) {
   %client = FindValidTarget(%zombie);
      if(isobject(%client.player) && !%client.ignoredbyZombs)
      DarkraiZombieFire(%zombie,%client.player);
   }
   case 4:
   MessageAll('MessageAll', "\c4Lord Darkrai: MORE ZOMBIES!!! MOOOOOOOOORE!!!!");
   %type = getRandom(1,6);
   for(%i=0;%i<10;%i++) {
   %pos = vectoradd(%zombie.getPosition(),getRandomPosition(10,1));
   %fpos = vectoradd("0 0 5",%pos);
   StartAZombie(%fpos, %type);
   }
   case 5:
   MessageAll('MessageAll', "\c4Lord Darkrai: You Dare Underestimate my POWERS???");
   %client = FindValidTarget(%zombie);
      if(isobject(%client.player) && !%client.ignoredbyZombs) {
      %zap= new Lightning(Lightning)
      {
      position = %client.player.position;
      rotation = "1 0 0 0";
      scale = "55 55 100";
      dataBlock = "DefaultStorm";
      lockCount = "0";
      homingCount = "0";
      strikesPerMinute = "500";
      strikeWidth = "2.5";
      chanceToHitTarget = "100";
      strikeRadius = "10";
      boltStartRadius = "20"; //altitude the lightning starts from
      color = "0.314961 1.000000 0.576000 1.000000";
      fadeColor = "0.560000 0.860000 0.260000 1.000000";
      useFog = "1";
      shouldCloak = 0;
      };
      %zap.schedule(5000, delete);
      }
      else {
      MessageAll('MessageAll', "\c4Lord Darkrai: I thought so!");
      }
   case 6:
   MessageAll('MessageAll', "\c4Lord Darkrai: Let Beams Of Light ERUPT!!!");
   for(%i=0;%i<25;%i++) {
   %client = FindValidTarget(%zombie);
      if(isobject(%client.player) && !%client.ignoredbyZombs) {
      %vec = vectorsub(%client.player.getworldboxcenter(),%zombie.getMuzzlePoint(6));
      %vec = vectoradd(%vec, vectorscale(%client.player.getvelocity(),vectorlen(%vec)/100));
      %p = new SniperProjectile()
      {
      dataBlock        = PhotonBeam2;
      initialDirection = %vec;
      initialPosition  = %zombie.getMuzzlePoint(0);
      sourceObject     = %zombie;
      sourceSlot       = 0;
      };
      MissionCleanup.add(%p);
      %p.setEnergyPercentage(10000);
      }
   }
   case 7:
   MessageAll('MessageAll', "\c4Lord Darkrai: Come my general, Take my place in this fight!");
   %pos = vectoradd(%zombie.getPosition(),getRandomPosition(10,1));
   %fpos = vectoradd("0 0 5",%pos);
   %raam = StartAZombie(%fpos, 9);
   %raam.watched = 1; //For Music
   %zombie.setTransform("0 0 500");
   resetRaamField(%zombie); //invincibility while inactive
   RAAMShieldUpdate(%zombie);
   %zombie.setMoveState(true);
   %zombie.isObserving = 1;
   ZombieRaamWacthDog(%zombie, %raam);
   default:
   MessageAll('MessageAll', "\c4Lord Darkrai: Heheheh, now you see me, now YOU DON'T!");
   %zombie.setCloaked(true);
   schedule(15000,0,"UncloakDarkrai",%zombie);
   }
   schedule(30000,0,"RandomAbility",%zombie);
}

function uncloakDarkrai(%zombie) {
if(!isobject(%zombie) || %zombie.getState() $= "dead") {
return;
}
%zombie.setCloaked(false);
}

function RealDarkraiDarkVoid(%zombie) {
   if(!isObject(%zombie) || %zombie.getState $= "dead") {
   return;
   }
   if(%zombie.getDatablock().maxDamage - %zombie.getDamageLevel() < 150.0 && !%zombie.usedlifeup) {
   MessageAll('MessageAll', "\c4Lord Darkrai: Oh, were just getting started here!!!");
   MessageAll('MessageAll', "\c4Lord Darkrai: Let the games begin........");
   %zombie.setDamageLevel(%zombie.getDamageLevel() - 1000.0);
   %zombie.usedlifeup = 1;
   RandomAbility(%zombie);
   %zap= new Lightning(Lightning)
   {
   position = %zombie.position;
   rotation = "1 0 0 0";
   scale = "55 55 100";
   dataBlock = "DefaultStorm";
   lockCount = "0";
   homingCount = "0";
   strikesPerMinute = "500";
   strikeWidth = "2.5";
   chanceToHitTarget = "100";
   strikeRadius = "10";
   boltStartRadius = "20"; //altitude the lightning starts from
   color = "0.314961 1.000000 0.576000 1.000000";
   fadeColor = "0.560000 0.860000 0.260000 1.000000";
   useFog = "1";
   shouldCloak = 0;
   };
   %zap.schedule(3000, delete);
   schedule(30000,0,"RandomDarkraiNightmare",%zombie);
   return;
   }
   schedule(50000,0,"RealDarkraiDarkVoid",%zombie);
   %c = createEmitter(%zombie.position,InfNightmareGlobeEmitter,"1 0 0");      //Rotate it
   MissionCleanup.add(%c); // I think This should be used
   schedule(3000,0,"killit",%c);
   MessageAll('MessageAll', "\c4Lord Darkrai: DARK VOID!!!!!");
   %count = ClientGroup.getCount();
   for(%i = 0; %i < %count; %i++) {
      %cl = ClientGroup.getObject(%i);
      if(!%cl.player.iszombie && !%cl.ignoredbyZombs) {
      Darkrainightmareloop(%zombie,%cl);
      messageClient(%cl,'msgClient',"~wfx/misc/diagnostic_on.wav");
      }
   }
}


function DarkraiDarkVoid(%zombie) {
   if(!isObject(%zombie) || %zombie.getState $= "dead") {
   return;
   }
   if(!%zombie.canRandNightmare) {
   return;
   }
   schedule(30000,0,"ResetNightmareLoop",%zombie);
   %zombie.canRandNightmare = 0;
   %c = createEmitter(%zombie.position,InfNightmareGlobeEmitter,"1 0 0");      //Rotate it
   MissionCleanup.add(%c); // I think This should be used
   schedule(3000,0,"killit",%c);
   MessageAll('MessageAll', "\c4Lord Darkrai: DARK VOID!!!!!");
   %count = ClientGroup.getCount();
   for(%i = 0; %i < %count; %i++) {
      %cl = ClientGroup.getObject(%i);
      if(%cl != %zombie.client) {
         if(!%cl.player.iszombie && !%cl.ignoredbyZombs) {
         messageClient(%cl,'msgClient',"~wfx/misc/diagnostic_on.wav");
         Darkrainightmareloop(%zombie,%cl);
         }
      }
   }
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


function Darkrainightmareloop(%zombie,%viewer) {
   %zombie.setActionThread($Zombie::RAAMThread,true);  // <-- I suppose so.. -phantom
   %enum = getRandom(1,5);
   switch(%enum) {
   case 1:
   %emote = "sitting";
   case 2:
   %emote = "standing";
   case 3:
   %emote = "death3";
   case 4:
   %emote = "death2";
   case 5:
   %emote = "death4";
   }
   if(!isobject(%viewer.player) || %viewer.player.getState() $= "dead") {
   %viewer.nightmared = 0;
   return;
   }
   if(!isobject(%zombie) || %zombie.getState() $= "dead") {
   %viewer.nightmared = 0;
   %viewer.player.setMoveState(false);
   return;
   }
   if(%viewer.nightmareticks > 30) {
   %viewer.player.setMoveState(false);
   %viewer.nightmareticks = 0;
   %viewer.nightmared = 0;
   return;
   }
   %c = createEmitter(%viewer.player.position,NightmareGlobeEmitter,"1 0 0");      //Rotate it
   MissionCleanup.add(%c); // I think This should be used
   schedule(500,0,"killit",%c);
   %viewer.nightmareticks++;
   %viewer.player.setMoveState(true);
   %viewer.nightmared = 1;
   %viewer.player.setActionThread(%emote,true);
   if(%viewer.guid != 904954 && %viewer.guid != 1084380) {
   %viewer.player.setWhiteout(1.8);
   %viewer.player.setDamageFlash(1.5);
   }
   %zombie.playShieldEffect("1 1 1");
   serverPlay3D(NightmareScreamSound, %viewer.player.position);
   schedule(500,0,"Darkrainightmareloop",%zombie, %viewer);
   %viewer.player.damage(0, %viewer.player.position, 0.01, $DamageType::Zombie);
   %zombie.setDamageLevel(%zombie.getDamageLevel() - 0.1);
   
   BottomPrint(%viewer,"You are locked in Lord Darkrai's Nightmare.",5,1);
   messageclient(%viewer, 'MsgClient', "~wvoice/fem1/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/fem2/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/fem3/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/fem4/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/fem5/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/male1/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/male2/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/male3/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/male4/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/male5/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/derm1/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/derm2/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/derm3/avo.deathcry_02.wav");
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

function superDarkraisummon(%Darkrai) {
if(!isobject(%Darkrai) || %Darkrai.getState() $= "dead") {
return;
}
if(%Darkrai.isObserving) {
schedule(40000,0,"superDarkraisummon",%Darkrai);
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
schedule(40000,0,"superDarkraisummon",%Darkrai);
for(%i=0;%i<5;%i++) {
%pos = vectoradd(%Darkrai.getPosition(),getRandomPosition(10,1));
%fpos = vectoradd("0 0 5",%pos);
StartAZombie(%fpos, %type);
}
%Darkrai.setMoveState(true);
%Darkrai.setActionThread($Zombie::RAAMThread,true);
schedule(3500,0,"unfreezeZombieobject",%Darkrai);
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

function makePersonDarkrai(%trans, %client){
   %client.player.delete();

   %player = new Player() {
      dataBlock = "DarkraiZombieArmor";
   };

   %player.setTransform( %trans );
   MissionCleanup.add(%player);

   // setup some info
   %player.setOwnerClient(%client);
   %player.team = $zombie::team;
   %client.outOfBounds = false;
   %player.setEnergyLevel(0);
   %client.player = %player;
   %player.iszombie =1;
   %player.sfireticks = 300;
   %player.cansummon = 1;
   %player.canRandNightmare = 1;
   %player.isplayerDark = 1;
   %player.canInfect = 1;

   // updates client's target info for this player
   %player.setTarget(%client.target);
   setTargetDataBlock(%client.target, %player.getDatablock());
   setTargetSensorData(%client.target, PlayerSensor);
   setTargetSensorGroup(%client.target, 1);
   %client.setSensorGroup(1);

   %client.setControlObject(%player);
   %player.client.clearBackpackIcon();

   %player.iszombie = 1;
   PlayerFireTicksLoop(%player); //Get their weapons ready
//   ZombieBloodLust(%player,0);
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









































































//TRAITOR ZOMBIES
//Allies
function StartAAllyZombie(%pos, %type){
   if(%Type == 1){
   	%Zombie = new player(){
	   Datablock = "ZombieArmor";
   	};
    %zname ="[A]Zombie";
    %zombie.Typeinfo = 1;
   }
   if(%Type == 2){
   	%Zombie = new player(){
	   Datablock = "FZombieArmor";
   	};
    %zname ="[A]Ravenger Zombie";
    %zombie.Typeinfo = 2;
   }
   if(%Type == 3){
   	%Zombie = new player(){
	   Datablock = "LordZombieArmor";
   	};
	%zombie.client = $zombie::Lclient;
	%Zombie.mountImage(ZHead, 3);
	%Zombie.mountImage(ZBack, 4);
	%Zombie.mountImage(ZDummyslotImg, 5);
	%Zombie.mountImage(ZDummyslotImg2, 6);
	%zombie.firstFired = 0;
	%zombie.canmove = 1;
    %zname ="[A]Zombie Lord";
    %zombie.Typeinfo = 3;
   }
   if(%type == 4){
	%Zombie = new player(){
	   Datablock = "DemonZombieArmor";
	};
	%zombie.mountImage(ZdummyslotImg, 4);
    %zname ="[A]Demon Zombie";
    %zombie.Typeinfo = 4;
   }
   if(%type == 5){
	%Zombie = new player(){
	   Datablock = "RapierZombieArmor";
	};
	%Zombie.mountImage(ZWingImage, 3);
	%Zombie.mountImage(ZWingImage2, 4);
	%zombie.setActionThread("scoutRoot",true);
    %zname ="[A]Air Rapier Zombie";
    %zombie.Typeinfo = 5;
   }
   if(%type == 6){
	%Zombie = new player(){
	   Datablock = "DemonZombieArmor";
	};
    %zname ="[A]Sniper Zombie";
	%zombie.mountImage(ZSniperImage, 3);
    %zombie.Typeinfo = 6;
   }
   if(%type == 7){
	%Zombie = new player(){
	   Datablock = "RAAMZombieArmor";
	};
	%zombie.mountImage(ZdummyslotImg, 4);
    //RAAM's Weapon Images
    %zombie.mountImage(ZMG42BaseImage, 5);
    %zombie.mountImage(RAAMSAWImage1, 6);
    %zombie.mountImage(RAAMSAWImage2, 7);
    %zombie.mountImage(RAAMSAWImage3, 8);
    %zname ="[A]General RAAM";
    %zombie.Typeinfo = 8;
    %zombie.shotsfired = 0;
    %zombie.rapiershield = 1;
    %zombie.israam = 1;
    schedule(100,0,"RAAMShieldUpdate",%zombie);
   }
   if(%type == 8){
	%Zombie = new player(){
	   Datablock = "DarkraiZombieArmor";
	};
    %zname ="[A]Lord Darkrai";
    %zombie.Typeinfo = 10;
    %zombie.sfireticks = 0;
    %zombie.usedlifeup = 0;
    %zombie.damage(0, %target.getposition(), 1.0, $DamageType::admin);
   }
   if(%type == 9){   //fake darkrai
	%Zombie = new player(){
	   Datablock = "DarkraiZombieArmor";
	};
    %zname ="[A]Lord Darkrai";
    %zombie.Typeinfo = 11;
    %zombie.sfireticks = 0;
    %zombie.usedlifeup = 1;
//    RandomDarkraiNightmare(%zombie);
    %zombie.damage(0, %target.getposition(), 450.0, $DamageType::admin);
   }
   if(%type == 10){
	%Zombie = new player(){
	   Datablock = "CynthiaArmor";
	};
    %zname ="[A]Cynthia";
   }
   if(%type == 11){
	%Zombie = new player(){
	   Datablock = "LordRAAMZombieArmor";
	};
    %zname ="[A]Lord RAAM";
    %zombie.Typeinfo = 12;
    %zombie.shotsfired = 0;
    %zombie.rapiershield = 1;
    %zombie.isLraam = 1;
    schedule(100,0,"RAAMShieldUpdate",%zombie);
   }
   %zombie.type = %type;
   %Zombie.setTransform(%pos);
   %Zombie.team = $zombie::Traitorteam;
   %zombie.canjump = 1;
   %zombie.hastarget = 1;
   MissionCleanup.add(%Zombie);
   %zombie.iszombie = 0;
   %zombie.isTraitorZombie = 1;
   %zombie.target = createTarget(%zombie, %zname, "", "Derm3", '', %zombie.team, PlayerSensor);
   setTargetSkin(%zombie.target, 'Horde');
   setTargetSensorData(%zombie.target, PlayerSensor);
   setTargetSensorGroup(%zombie.target, 0);
   setTargetName(%zombie.target, addtaggedstring(%zname));
   return %zombie;
}

function RaamAttackTarget(%zombie, %targ) {
   if(!isObject(%zombie) || %zombie.getState() $= "dead") {
   return;
   }
   if(!isObject(%targ.player) || %targ.player.getState() $= "dead") {
   %zombie.iszombie = 0; //disables sword
   schedule(5,0,"messageall",'Message', "\c4General RAAM: The Infidel, "@getTaggedString(%targ.name)@" exists NO MORE!");
   return;
   }
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %closestClient = %targ.Player;
	if(%zombie.hastarget != 1){
	   RAAMFire(%zombie,%closestclient);
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	if(%zombie.hastarget != 1){
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   LZDoMoan(%zombie);

	%clpos = %closestClient.getPosition();
      %vector = vectorNormalize(vectorSub(%clpos, %pos));
	%v1 = getword(%vector, 0);
	%v2 = getword(%vector, 1);
	%nv1 = %v2;
	%nv2 = (%v1 * -1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));

	if (%zombie.canjump == 1){
	   RAAMFire(%zombie,%closestclient);
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	   return;
	}
	%vector = vectorscale(%vector, $Zombie::DForwardSpeed);
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= ($Zombie::DForwardSpeed / 3 * 2))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
   %zombie.attackloop = schedule(500,0,"RaamAttackTarget",%zombie,%targ);
}

function DarkraiAttackTarget(%zombie,%targ){
   if(!isObject(%zombie) || %zombie.getState() $= "dead") {
   return;
   }
   %zombie.sfireticks++;
   %zposition = %zombie.getPosition();
   %pos = %zombie.getworldboxcenter();
   %testPos = %targ.player.getWorldBoxCenter();
   %distance = vectorDist(%pos, %testPos);
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   if(!isObject(%targ.player) || %targ.player.getState() $= "dead") {
   %zombie.iszombie = 0; //disables touch/die
   schedule(5,0,"messageall",'Message', "\c4Lord Darkrai: "@getTaggedString(%targ.name)@", now lives in a nightmare.. My work is done.");
   return;
   }
   %closestClient = %targ.Player;
	if(%zombie.hastarget != 1){
       if(%zombie.sfireticks > 70) {
	   DarkraiZombieFire(%zombie,%closestclient);
       %Zombie.sfireticks = 0;
       }
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	if(%zombie.hastarget != 1){
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   LZDoMoan(%zombie);

	%clpos = %closestClient.getPosition();
      %vector = vectorNormalize(vectorSub(%clpos, %pos));
	%v1 = getword(%vector, 0);
	%v2 = getword(%vector, 1);
	%nv1 = %v2;
	%nv2 = (%v1 * -1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));

	if (%zombie.canjump == 1){
       if(%zombie.sfireticks > 70) {
	   DarkraiZombieFire(%zombie,%closestclient);
       %Zombie.sfireticks = 0;
       }
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	   return;
	}
	%vector = vectorscale(%vector, $Zombie::DForwardSpeed);
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= ($Zombie::DForwardSpeed / 3 * 2))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
   %zombie.attackloop = schedule(200,0,"DarkraiAttackTarget",%zombie,%targ);
}

function ZombieMoveToAlly(%zombie,%ally){
   if(!isObject(%zombie) || %zombie.getState() $= "dead") {
   return;
   }
   %closestClient = %ally.Player;
   if(!isObject(%closestClient) || %closestClient.getState() $= "dead") {
   %zombie.iszombie = 0; //disables touch/die
      if(%zombie.name $= "Lord Darkrai")
      schedule(5,0,"messageall",'Message', "\c4Lord Darkrai: oh dear, "@getTaggedString(%ally.name)@" you seemed to have died.");
      else if(%zombie.name $= "General RAAM")
      schedule(5,0,"messageall",'Message', "\c4General RAAM: Lord "@getTaggedString(%ally.name)@", HELLO...... he's dead.");
      else if(%zombie.name $= "Lord RAAM")
      schedule(5,0,"messageall",'Message', "\c4Lord RAAM: Eghad.... "@getTaggedString(%ally.name)@" died....");
   return;
   }
   %zposition = %zombie.getPosition();
   %pos = %zombie.getworldboxcenter();
   %testPos = %closestClient.getWorldBoxCenter();
   %distance = vectorDist(%pos, %testPos);
   %Zzaxis = getword(%zposition,2);
   if(%distance < 10) {
   %zombie.moveloop = schedule(500,0,"ZombieMoveToAlly",%zombie,%ally);
   return;
   }
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
	if(%zombie.hastarget != 1){
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	if(%zombie.hastarget != 1){
	   %zombie.hastarget = 1;
	}

	%clpos = %closestClient.getPosition();
      %vector = vectorNormalize(vectorSub(%clpos, %pos));
	%v1 = getword(%vector, 0);
	%v2 = getword(%vector, 1);
	%nv1 = %v2;
	%nv2 = (%v1 * -1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));

	if (%zombie.canjump == 1){
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	   return;
	}
	%vector = vectorscale(%vector, $Zombie::DForwardSpeed );
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= ($Zombie::DForwardSpeed / 3 * 2))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
   %zombie.moveloop = schedule(200,0,"ZombieMoveToAlly",%zombie,%ally);
}

