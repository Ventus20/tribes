//--------------------------------------------------------------------------
// Plasma Turret
// 
// 
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
// Sounds
//--------------------------------------------------------------------------
datablock EffectProfile(PBLSwitchEffect)
{
   effectname = "powered/turret_light_activate";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock EffectProfile(PBLFireEffect)
{
   effectname = "powered/turret_plasma_fire";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock AudioProfile(PBLSwitchSound)
{
   filename    = "fx/powered/turret_light_activate.wav";
   description = AudioClose3d;
   preload = true;
   effect = PBLSwitchEffect;
};

datablock AudioProfile(PBLFireSound)
{
   filename    = "fx/powered/turret_plasma_fire.wav";
   description = AudioDefault3d;
   preload = true;
   effect = PBLFireEffect;
};

datablock AudioProfile(HeavyCGTurretFireSound)
{
   filename    = "fx/vehicles/tank_chaingun_fire.wav";
   description = AudioDefault3d;
   preload = true;
   effect = PBLFireEffect;
};

//--------------------------------------------------------------------------
// Explosion
//--------------------------------------------------------------------------

datablock AudioProfile(PlasmaBarrelExpSound)
{
   filename    = "fx/powered/turret_plasma_explode.wav";
   description = "AudioExplosion3d";
   preload = true;
};


datablock ParticleData( PlasmaBarrelCrescentParticle )
{
   dragCoefficient      = 2;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = -0.0;
   lifetimeMS           = 600;
   lifetimeVarianceMS   = 000;
   textureName          = "special/crescent3";

   colors[0]     = "0.3 0.4 1.0 1.0";
   colors[1]     = "0.3 0.4 1.0 0.5";
   colors[2]     = "0.3 0.4 1.0 0.0";
   sizes[0]      = 2.0;
   sizes[1]      = 4.0;
   sizes[2]      = 5.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData( PlasmaBarrelCrescentEmitter )
{
   ejectionPeriodMS = 25;
   periodVarianceMS = 0;
   ejectionVelocity = 20;
   velocityVariance = 5.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 80;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 200;
   particles = "PlasmaBarrelCrescentParticle";
};

datablock ParticleData(PlasmaBarrelExplosionParticle)
{
   dragCoefficient      = 2;
   gravityCoefficient   = 0.2;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 750;
   lifetimeVarianceMS   = 150;
   textureName          = "particleTest";
   colors[0]     = "0.3 0.4 1.0 1.0";
   colors[1]     = "0.3 0.4 1.0 0.0";
   sizes[0]      = 1;
   sizes[1]      = 2;
};

datablock ParticleEmitterData(PlasmaBarrelExplosionEmitter)
{
   ejectionPeriodMS = 7;
   periodVarianceMS = 0;
   ejectionVelocity = 12;
   velocityVariance = 1.75;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 60;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "PlasmaBarrelExplosionParticle";
};


datablock ExplosionData(PlasmaBarrelSubExplosion1)
{
   explosionShape = "disc_explosion.dts";
   faceViewer           = true;

   delayMS = 50;

   offset = 3.0;

   playSpeed = 1.5;

   sizes[0] = "0.25 0.25 0.25";
   sizes[1] = "0.25 0.25 0.25";
   times[0] = 0.0;
   times[1] = 1.0;

};             

datablock ExplosionData(PlasmaBarrelSubExplosion2)
{
   explosionShape = "disc_explosion.dts";
   faceViewer           = true;

   delayMS = 100;

   offset = 3.5;

   playSpeed = 1.0;

   sizes[0] = "0.5 0.5 0.5";
   sizes[1] = "0.5 0.5 0.5";
   times[0] = 0.0;
   times[1] = 1.0;
};

datablock ExplosionData(PlasmaBarrelSubExplosion3)
{
   explosionShape = "disc_explosion.dts";
   faceViewer           = true;

   delayMS = 0;

   offset = 0.0;

   playSpeed = 0.7;


   sizes[0] = "0.5 0.5 0.5";
   sizes[1] = "1.0 1.0 1.0";
   times[0] = 0.0;
   times[1] = 1.0;

};

datablock ExplosionData(PlasmaBarrelBoltExplosion)
{
   soundProfile   = PlasmaBarrelExpSound;
   particleEmitter = PlasmaBarrelExplosionEmitter;
   particleDensity = 250;
   particleRadius = 1.25;
   faceViewer = true;

   emitter[0] = PlasmaBarrelCrescentEmitter;

   subExplosion[0] = PlasmaBarrelSubExplosion1;
   subExplosion[1] = PlasmaBarrelSubExplosion2;
   subExplosion[2] = PlasmaBarrelSubExplosion3;

   shakeCamera = true;
   camShakeFreq = "10.0 9.0 9.0";
   camShakeAmp = "10.0 10.0 10.0";
   camShakeDuration = 0.5;
   camShakeRadius = 15.0;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock TracerProjectileData(HVCGTurretBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.09; // z0dd - ZOD, 9-27-02. Was 0.0825
   directDamageType    = $DamageType::Vulcan;
   hasDamageRadius     = true;
   indirectDamage      = 0.09;
   damageRadius        = 5.0;
   radiusDamageType    = $DamageType::Vulcan;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;

   kickBackStrength  = 18.0;
   sound 				= ChaingunProjectile;

   //dryVelocity       = 425.0;
   dryVelocity       = 1250.0; // z0dd - ZOD, 8-12-02. Was 425.0
   wetVelocity       = 1000.0;
   velInheritFactor  = 0.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 1000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 25.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.25;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = ChaingunDecal1;
   decalData[1] = ChaingunDecal2;
   decalData[2] = ChaingunDecal3;
   decalData[3] = ChaingunDecal4;
   decalData[4] = ChaingunDecal5;
   decalData[5] = ChaingunDecal6;
};


//--------------------------------------------------------------------------
// Plasma Turret Image
//--------------------------------------------------------------------------

datablock TurretImageData(PlasmaBarrelLarge)
{
   shapeFile = "turret_tank_barrelmortar.dts";
   item      = PlasmaBarrelPack; // z0dd - ZOD, 4/25/02. Was wrong: PlasmaBarrelLargePack

   projectile = HVCGTurretBullet;
   projectileType = TracerProjectile;
   usesEnergy = true;
   fireEnergy = 1;
   minEnergy = 1;
   emap = true;

   // Turret parameters
   activationMS      = 700; // z0dd - ZOD, 3/27/02. Was 1000. Amount of time it takes turret to unfold
   deactivateDelayMS = 1500;
   thinkTimeMS       = 140; // z0dd - ZOD, 3/27/02. Was 200. Amount of time before turret starts to unfold (activate)
   degPerSecTheta    = 300;
   degPerSecPhi      = 500;
   attackRadius      = 250; // z0dd - ZOD, 3/27/02. Was 300

   // State transitions
   stateName[0]                  = "Activate";
   stateTransitionOnNotLoaded[0] = "Dead";
   stateTransitionOnLoaded[0]    = "ActivateReady";

   stateName[1]                  = "ActivateReady";
   stateSequence[1]              = "Activate";
   stateSound[1]                 = PBLSwitchSound;
   stateTimeoutValue[1]          = 1;
   stateTransitionOnTimeout[1]   = "Ready";
   stateTransitionOnNotLoaded[1] = "Deactivate";
   stateTransitionOnNoAmmo[1]    = "NoAmmo";

   stateName[2]                    = "Ready";
   stateTransitionOnNotLoaded[2]   = "Deactivate";
   stateTransitionOnTriggerDown[2] = "Fire";
   stateTransitionOnNoAmmo[2]      = "NoAmmo";

   stateName[3]                = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3]        = 0.1;
   stateFire[3]                = true;
   stateRecoil[3]              = LightRecoil;
   stateAllowImageChange[3]    = false;
   stateSequence[3]            = "Fire";
   stateSound[3]               = HeavyCGTurretFireSound;
   stateScript[3]              = "onFire";

   stateName[4]                  = "Reload";
   stateTimeoutValue[4]          = 0.02;
   stateAllowImageChange[4]      = false;
   stateSequence[4]              = "Reload";
   stateTransitionOnTimeout[4]   = "Ready";
   stateTransitionOnNotLoaded[4] = "Deactivate";
   stateTransitionOnNoAmmo[4]    = "NoAmmo";

   stateName[5]                = "Deactivate";
   stateSequence[5]            = "Activate";
   stateDirection[5]           = false;
   stateTimeoutValue[5]        = 1;
   stateTransitionOnLoaded[5]  = "ActivateReady";
   stateTransitionOnTimeout[5] = "Dead";

   stateName[6]               = "Dead";
   stateTransitionOnLoaded[6] = "ActivateReady";

   stateName[7]             = "NoAmmo";
   stateTransitionOnAmmo[7] = "Reload";
   stateSequence[7]         = "NoAmmo";
};

datablock TurretImageData(SCGBarrelLarge)
{
   shapeFile = "turret_tank_barrelmortar.dts";
   item      = PlasmaBarrelPack; // z0dd - ZOD, 4/25/02. Was wrong: PlasmaBarrelLargePack

   projectile = SCGBullet;
   projectileType = TracerProjectile;
   usesEnergy = true;
   fireEnergy = 1;
   minEnergy = 1;
   emap = true;

   // Turret parameters
   activationMS      = 700; // z0dd - ZOD, 3/27/02. Was 1000. Amount of time it takes turret to unfold
   deactivateDelayMS = 1500;
   thinkTimeMS       = 140; // z0dd - ZOD, 3/27/02. Was 200. Amount of time before turret starts to unfold (activate)
   degPerSecTheta    = 300;
   degPerSecPhi      = 500;
   attackRadius      = 500; // z0dd - ZOD, 3/27/02. Was 300

   //--------------------------------------
   stateName[0]             = "Activate";
   stateSequence[0]         = "Activate";
   stateSound[0]            = ChaingunSwitchSound;
   stateAllowImageChange[0] = false;
   //
   stateTimeoutValue[0]        = 0.5;
   stateTransitionOnTimeout[0] = "Ready";
   stateTransitionOnNoAmmo[0]  = "NoAmmo";

   //--------------------------------------
   stateName[1]       = "Ready";
   stateSpinThread[1] = Stop;
   //
   stateTransitionOnTriggerDown[1] = "Spinup";
   stateTransitionOnNoAmmo[1]      = "NoAmmo";

   //--------------------------------------
   stateName[2]               = "NoAmmo";
   stateTransitionOnAmmo[2]   = "Ready";
   stateSpinThread[2]         = Stop;
   stateTransitionOnTriggerDown[2] = "DryFire";

   //--------------------------------------
   stateName[3]         = "Spinup";
   stateSpinThread[3]   = SpinUp;
   stateSound[3]        = ChaingunSpinupSound;
   //
   stateTimeoutValue[3]          = 0.0;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   //--------------------------------------
   stateName[4]             = "Fire";
   stateSequence[4]            = "Fire";
   stateSequenceRandomFlash[4] = true;
   stateSpinThread[4]       = FullSpeed;
   stateSound[4]            = ChaingunFireSound;
   //stateRecoil[4]           = LightRecoil;
   stateAllowImageChange[4] = false;
   stateScript[4]           = "onFire";
   stateFire[4]             = true;
   stateEjectShell[4]       = true;
   //
   stateTimeoutValue[4]          = 0.01;
   stateTransitionOnTimeout[4]   = "Fire";
   stateTransitionOnTriggerUp[4] = "Spindown";
   stateTransitionOnNoAmmo[4]    = "EmptySpindown";

   //--------------------------------------
   stateName[5]       = "Spindown";
   stateSound[5]      = ChaingunSpinDownSound;
   stateSpinThread[5] = SpinDown;
   //
   stateTimeoutValue[5]            = 0.0;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[5]     = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   //--------------------------------------
   stateName[6]       = "EmptySpindown";
   stateSound[6]      = ChaingunSpinDownSound;
   stateSpinThread[6] = SpinDown;
   //
   stateTimeoutValue[6]        = 0.5;
   stateTransitionOnTimeout[6] = "NoAmmo";

   //--------------------------------------
   stateName[7]       = "DryFire";
   stateSound[7]      = ChaingunDryFireSound;
   stateTimeoutValue[7]        = 0.5;
   stateTransitionOnTimeout[7] = "NoAmmo";
};
