//--------------------------------------------------------------------------
// ELF Turret barrel
//--------------------------------------------------------------------------

datablock LinearFlareProjectileData(TurretFlameBolt)
{
   projectileShapeName = "turret_muzzlepoint.dts";
   scale               = "1.0 1.0 1.0";
   faceViewer          = true;
   directDamage        = 0.1;
   hasDamageRadius     = true;
   indirectDamage      = 0.1;
   damageRadius        = 8.0;
   kickBackStrength    = 0.0;
   radiusDamageType    = $DamageType::Plasma;

   explosion           = "flameBoltExplosion";
   splash              = PlasmaSplash;

   baseEmitter        = FlameEmitter;

   dryVelocity       = 90.0; // z0dd - ZOD, 7/20/02. Faster plasma projectile. was 55
   wetVelocity       = -1;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 250;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   //activateDelayMS = 100;
   activateDelayMS = -1;

   size[0]           = 0.2;
   size[1]           = 0.5;
   size[2]           = 0.1;


   numFlares         = 35;
   flareColor        = "1 0.18 0.03";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

	sound        = PlasmaProjectileSound;
   fireSound    = FlamethrowerFireSound;
   wetFireSound = PlasmaFireWetSound;

   hasLight    = true;
   lightRadius = 10.0;
   lightColor  = "0.94 0.03 0.12";
};

//--------------------------------------------------------------------------
// Sounds
//--------------------------------------------------------------------------

datablock TurretImageData(ELFBarrelLarge)
{
   shapeFile = "turret_elf_large.dts";
   // ---------------------------------------------
   // z0dd - ZOD, 5/8/02. Incorrect parameter value
   //item      = ELFBarrelLargePack;
   item = ELFBarrelPack;

   projectile = TurretFlameBolt;
   projectileType = LinearFlareProjectile;
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
   attackRadius      = 70; // z0dd - ZOD, 3/27/02. Was 300

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
   stateTimeoutValue[3]        = 0.04;
   stateFire[3]                = true;
   stateRecoil[3]              = LightRecoil;
   stateAllowImageChange[3]    = false;
   stateSequence[3]            = "Fire";
   stateSound[3]               = FlamethrowerFireSound;
   stateScript[3]              = "onFire";

   stateName[4]                  = "Reload";
   stateTimeoutValue[4]          = 0.04;
   stateAllowImageChange[4]      = false;
   stateSequence[4]              = "Reload";
   stateTransitionOnTimeout[4]   = "Ready";
   stateTransitionOnNotLoaded[4] = "Deactivate";
   stateTransitionOnNoAmmo[4]    = "NoAmmo";

   stateName[5]                = "Deactivate";
   stateSequence[5]            = "Activate";
   stateDirection[5]           = false;
   stateTimeoutValue[5]        = 0.1;
   stateTransitionOnLoaded[5]  = "ActivateReady";
   stateTransitionOnTimeout[5] = "Dead";

   stateName[6]               = "Dead";
   stateTransitionOnLoaded[6] = "ActivateReady";

   stateName[7]             = "NoAmmo";
   stateTransitionOnAmmo[7] = "Reload";
   stateSequence[7]         = "NoAmmo";
};

