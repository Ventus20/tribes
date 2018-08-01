//Napalm Bomb Launcher
//--------------------------------------
datablock ParticleData(NapalmExplosionParticle)
{
   dragCoefficient      = 2;
   gravityCoefficient   = 0.2;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 450;
   lifetimeVarianceMS   = 150;
   textureName          = "particleTest";
   colors[0]     = "1 0 0";
   colors[1]     = "1 0 0";
   sizes[0]      = 0.5;
   sizes[1]      = 2;
};

datablock ParticleEmitterData(NapalmExplosionEmitter)
{
   ejectionPeriodMS = 7;
   periodVarianceMS = 0;
   ejectionVelocity = 5;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 60;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "NapalmExplosionParticle";
};

datablock ExplosionData(NapalmExplosion)
{
   explosionShape = "effect_plasma_explosion.dts";
   soundProfile   = plasmaExpSound;
   particleEmitter = NapalmExplosionEmitter;
   particleDensity = 150;
   particleRadius = 1.25;
   faceViewer = true;

   sizes[0] = "3.0 3.0 3.0";
   sizes[1] = "3.0 3.0 3.0";
   times[0] = 0.0;
   times[1] = 1.5;
};

//--------------------------------------
//Napalm projectile
//--------------------------------------
datablock LinearProjectileData(NapalmShot)
{
   projectileShapeName = "mortar_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.5;
   damageRadius        = 20.0;
   radiusDamageType    = $DamageType::Plasma;
   kickBackStrength    = 3000;

   explosion           = "NapalmExplosion";
//   underwaterExplosion = "UnderwaterNapalmExplosion";
   velInheritFactor    = 0.5;
//   splash              = NapalmSplash;
   depthTolerance      = 10.0; // depth at which it uses underwater explosion

   baseEmitter         = MissileFireEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;

   grenadeElasticity = 0.15;
   grenadeFriction   = 0.4;
   armingDelayMS     = 2000;
   muzzleVelocity    = 63.7;
   drag              = 0.1;

   sound          = MortarProjectileSound;

   hasLight    = true;
   lightRadius = 4;
   lightColor  = "1.00 0.9 1.00";

   hasLightUnderwaterColor = true;
   underWaterLightColor = "0.05 0.075 0.2";

   dryVelocity       = 90;
   wetVelocity       = 50;
   velInheritFactor  = 0.5;
   fizzleTimeMS      = 5000;
   lifetimeMS        = 2700;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 15.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 5000;

};

//--------------------------------------------------------------------------
// Ammo
//--------------------------------------

datablock ItemData(NapalmAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_grenade.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "some Napalm";
};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------

datablock ShapeBaseImageData(NapalmImage)
{
   className = WeaponImage;
   shapeFile = "ammo_grenade.dts";
   item = Napalm;
   ammo = NapalmAmmo;
   offset = "0 0 0";
   armThread = lookms;
   emap = true;

   projectileSpread = 0;

   RankReqName = "ZH7C8 Napalm Cannon"; //Called By TWMFuncitons.cs & Weapons.cs
   projectile = NapalmShot;
   projectileType = LinearProjectile;

   // State Data
   stateName[0]                     = "ActivateReady";
   stateTransitionOnLoaded[0]       = "Activate";
   stateTransitionOnNoAmmo[0]       = "NoAmmo";

   stateName[1]                     = "Activate";
   stateTransitionOnTimeout[1]      = "Ready";
   stateTimeoutValue[1]             = 0.5;
   stateSequence[1]                 = "Activated";
   stateSound[1]                    = PlasmaSwitchSound;

   stateName[2]                     = "Ready";
   stateTransitionOnNoAmmo[2]       = "NoAmmo";
   stateTransitionOnTriggerDown[2]  = "Fire";
   stateSequence[2]                 = "DiscSpin";
//   stateSound[2]                    = DiscLoopSound;

   stateName[3]                     = "Fire";
   stateTransitionOnTimeout[3]      = "Reload";
   stateTimeoutValue[3]             = 0.3;
   stateFire[3]                     = true;
   stateRecoil[3]                   = LightRecoil;
   stateAllowImageChange[3]         = false;
   stateSequence[3]                 = "Fire";
   stateScript[3]                   = "onFire";
   stateSound[3]                    = MortarFireSound;

   stateName[4]                     = "Reload";
   stateTransitionOnNoAmmo[4]       = "NoAmmo";
   stateTransitionOnTimeout[4]      = "Ready";
   stateTimeoutValue[4]             = 2.2; // 0.25 load, 0.25 spinup
   stateAllowImageChange[4]         = false;
   stateSequence[4]                 = "Reload";
//   stateSound[4]                    = DiscReloadSound;

   stateName[5]                     = "NoAmmo";
   stateTransitionOnAmmo[5]         = "Reload";
   stateSequence[5]                 = "NoAmmo";
   stateTransitionOnTriggerDown[5]  = "DryFire";

   stateName[6]                     = "DryFire";
   stateSound[6]                    = GrenadeDryFireSound;
   stateTimeoutValue[6]             = 0.3;
   stateTransitionOnTimeout[6]      = "NoAmmo";

};

datablock ItemData(Napalm)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "ammo_grenade.dts";
   image = NapalmImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "a Napalm Gun";
   emap = true;
};

function NapalmImage::onFire(%data,%obj,%slot) {
   //We need to cool down the weapon...
   if(%obj.overHeated) {
      commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Armor Heat Systems Locked.. Cooling<spop>", 1, 1);
      return;
   }
   %p = Parent::onFire(%data, %obj, %slot);
}
