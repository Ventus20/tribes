//--------------------------------------------------------------------------
// PBC Turret
//
//
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
// PBC Turret Image
//--------------------------------------------------------------------------

datablock TracerProjectileData(PBCTurretMainProj)
{
   doDynamicClientHits = true;

   directDamage        = 25.5;
   explosion           = "PBCexplosion";
   splash              = ChaingunSplash;

   directDamageType    = $DamageType::PBCTurret;
   kickBackStrength  = 0.0;

   sound = ShrikeBlasterProjectileSound;

   dryVelocity       = 5000.0;
   wetVelocity       = 0.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 200;
   lifetimeMS        = 200;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 45.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = "0.1 1.0 0.1 1.0";
	tracerTex[0]  	 = "special/shrikeBolt";
	tracerTex[1]  	 = "special/shrikeBoltCross";
	tracerWidth     = 1.4;
   crossSize       = 0.99;
   crossViewAng    = 0.990;
   renderCross     = true;
};

datablock TurretImageData(PBCBarrelLarge)
{
   shapeFile = "turret_fusion_large.dts";
   item      = PBCBarrelPack; // z0dd - ZOD, 4/25/02. Was wrong: PlasmaBarrelLargePack

   projectile = PBCTurretMainProj;
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
   attackRadius      = 350; // z0dd - ZOD, 3/27/02. Was 120

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
   stateTimeoutValue[4]          = 5.0;
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
