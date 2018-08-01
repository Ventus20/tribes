// --------------------------------------------------------------
// Outdoor Photon Deployable Turret barrel
// --------------------------------------------------------------

// --------------------------------------------------------------
// Sound datablocks
// --------------------------------------------------------------
datablock EffectProfile(POBSwitchEffect)
{
   effectname = "powered/turret_light_activate";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock EffectProfile(POBFireEffect)
{
   effectname = "powered/turret_outdoor_fire";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock AudioProfile(POBSwitchSound)
{
   filename    = "fx/powered/turret_light_activate.wav";
   description = AudioClose3d;
   preload = true;
   effect = POBSwitchEffect;
};

datablock AudioProfile(POBFireSound)
{
   filename    = "fx/powered/turret_outdoor_fire.wav";
   description = AudioDefault3d;
   preload = true;
   effect = POBFireEffect;
};

datablock LinearFlareProjectileData(FissionTurretBolt)
{
   directDamage        = 0.35;
   directDamageType    = $DamageType::Phaser;
   explosion           = "BlasterExplosion";
   kickBackStrength  = 0.0;

   dryVelocity       = 120.0;
   wetVelocity       = 40.0;
   velInheritFactor  = 0.5;
   fizzleTimeMS      = 2000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   numFlares         = 20;
   size              = 0.20;
   flareColor        = "1 0 1";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   sound = BlasterProjectileSound;

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "1 0 1";
};

datablock TurretData(TurretplasDeployedOutdoor) : TurretDamageProfile
{
   className = DeployedTurret;
   shapeFile = "turret_outdoor_deploy.dts";

   rechargeRate = 0.15;

   mass = 5.0;
   maxDamage = 0.80;
   destroyedLevel = 0.80;
   disabledLevel = 0.35;
   explosion      = HandGrenadeExplosion;
      expDmgRadius = 5.0;
      expDamage = 0.3;
      expImpulse = 500.0;
   repairRate = 0;

	deployedObject = true;

   thetaMin = 0;
   thetaMax = 145;
   thetaNull = 90;

   yawVariance          = 30.0; // these will smooth out the elf tracking code.
   pitchVariance        = 30.0; // more or less just tolerances

   isShielded = true;
   energyPerDamagePoint = 110;
   maxEnergy = 60;
   renderWhenDestroyed = false;
   barrel = DeployableOutdoorPlaBarrel;
   heatSignature = 0;

   canControl = true;
   cmdCategory = "DTactical";
   cmdIcon = CMDTurretIcon;
   cmdMiniIconName = "commander/MiniIcons/com_turret_grey";
   targetNameTag = 'Automated Fission';
   targetTypeTag = 'Turret';
   sensorData = DeployedOutdoorTurretSensor;
   sensorRadius = DeployedOutdoorTurretSensor.detectRadius;
   sensorColor = "191 0 226";

   firstPersonOnly = true;

   debrisShapeName = "debris_generic_small.dts";
   debris = TurretDebrisSmall;
};

datablock TurretImageData(DeployableOutdoorPlaBarrel)
{
   shapeFile = "turret_muzzlepoint.dts";
   // ---------------------------------------------
   // z0dd - ZOD, 5/8/02. Incorrect parameter value
   //item      = OutdoorTurretBarrel;
   item = TurretPlasOutdoorDeployable;

   projectileType = LinearFlareProjectile;
   projectile = FissionTurretBolt;
   usesEnergy = true;
   fireEnergy = 9.0;
   minEnergy = 9.0;

   lightType = "WeaponFireLight";
   lightColor = "0.25 0.25 0.15 0.2";
   lightTime = "1000";
   lightRadius = "2";

   muzzleFlash = OutdoorTurretMuzzleFlash;

   // Turret parameters
   activationMS      = 300;
   deactivateDelayMS = 600;
   thinkTimeMS       = 200;
   degPerSecTheta    = 580;
   degPerSecPhi      = 960;
   attackRadius      = 150;

   // State transitions
   stateName[0]                  = "Activate";
   stateTransitionOnNotLoaded[0] = "Dead";
   stateTransitionOnLoaded[0]    = "ActivateReady";

   stateName[1]                  = "ActivateReady";
   stateSequence[1]              = "Activate";
   stateSound[1]                 = POBSwitchSound;
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
   stateTimeoutValue[3]        = 0.3;
   stateFire[3]                = true;
   stateShockwave[3]           = true;
   stateRecoil[3]              = LightRecoil;
   stateAllowImageChange[3]    = false;
   stateSequence[3]            = "Fire";
   stateSound[3]               = POBFireSound;
   stateScript[3]              = "onFire";

   stateName[4]                  = "Reload";
   stateTimeoutValue[4]          = 0.6;
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
