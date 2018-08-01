//--------------------------------------
// flamethrower
//--------------------------------------

//color tent for EVERYTHING its red really red 
//1 r
//0.18 g
//0.03 b

datablock AudioProfile(FlamethrowerFireSound)
{
   filename    = "fx/Bonuses/Nouns/snake.wav";
   description = AudioClose3d;
   preload = true;
   effect = SniperRifleFireEffect;
};

//--------------------------------------
// Trail
//--------------------------------------

datablock ParticleData(flameParticle)
{
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = -0.1;
   inheritedVelFactor   = 0.1;

   lifetimeMS           = 500;
   lifetimeVarianceMS   = 50;

   textureName          = "particleTest";

   spinRandomMin = -10.0;
   spinRandomMax = 10.0;

   colors[0]     = "1 0.18 0.03 0.4";
   colors[1]     = "1 0.18 0.03 0.3";
   colors[2]     = "1 0.18 0.03 0.0";
   sizes[0]      = 2.0;
   sizes[1]      = 1.0;
   sizes[2]      = 0.8;
   times[0]      = 0.0;
   times[1]      = 0.6;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(flameEmitter)
{
   ejectionPeriodMS = 3;
   periodVarianceMS = 0;

   ejectionOffset = 0.2;
   ejectionVelocity = 10.0;
   velocityVariance = 0.0;

   thetaMin         = 0.0;
   thetaMax         = 10.0;  

   particles = "flameParticle";
};

//--------------------------------------------------------------------------
// Explosion
//--------------------------------------
datablock ParticleData(flameExplosionParticle)
{
   dragCoefficient      = 2;
   gravityCoefficient   = 0.2;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 500;
   lifetimeVarianceMS   = 0;
   textureName          = "particleTest";
   colors[0]     = "1 0.18 0.03 0.6";
   colors[1]     = "1 0.18 0.03 0.0";
   sizes[0]      = 2;
   sizes[1]      = 2.5;
};

datablock ParticleEmitterData(flameExplosionEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionOffset = 2.0;
   ejectionVelocity = 4.0;
   velocityVariance = 0.0;
   thetaMin         = 60.0;
   thetaMax         = 90.0;
   lifetimeMS       = 250;

   particles = "flameExplosionParticle";
};

datablock ExplosionData(flameBoltExplosion)
{
   particleEmitter = flameExplosionEmitter;
   particleDensity = 150;
   particleRadius = 1.25;
   faceViewer = true;
};

//--------------------------------------------------------------------------
// Idle Flame
//--------------------------------------

datablock ParticleData(FlamerIdleFlame) 
{ 
   dragCoeffiecient     = 0.0; 
   gravityCoefficient   = -0.3;   // rises slowly 
   inheritedVelFactor   = 0.5; 
   constantAcceleration = 0.0; 

   lifetimeMS           = 500; 
   lifetimeVarianceMS   = 0; 

   textureName          = "particleTest"; 

   spinRandomMin = -30.0; 
   spinRandomMax =  30.0;  

   colors[0]     = "1 0.18 0.03 0.3"; 
   colors[1]     = "1 0.18 0.03 0.2"; 
   colors[2]     = "1 0.18 0.03 0.0"; 
   sizes[0]      = 0.2; 
   sizes[1]      = 0.4; 
   sizes[2]      = 0.5; 
   times[0]      = 0.0; 
   times[1]      = 0.5; 
   times[2]      = 1.0; 
}; 

datablock ParticleEmitterData(FlamerIdleFlameEmitter) 
{ 
   ejectionPeriodMS = 3; 
   periodVarianceMS = 1; 

   ejectionVelocity = 0.0; 
   velocityVariance = 0.0; 

   thetaMin         = 0.0; 
   thetaMax         = 45.0; 

   phiReferenceVel  = 0; 
   phiVariance      = 360; 
   overrideAdvances = false; 

   particles = "FlamerIdleFlame"; 
};

//--------------------------------------------------------------------------
// Projectiles
//--------------------------------------
datablock LinearFlareProjectileData(FlameboltMain)
{
   projectileShapeName = "turret_muzzlepoint.dts";
   scale               = "1.0 1.0 1.0";
   faceViewer          = true;
   directDamage        = 0.05;
   hasDamageRadius     = true;
   indirectDamage      = 0.1;
   damageRadius        = 4.0;
   kickBackStrength    = 0.0;
   radiusDamageType    = $DamageType::Plasma;

   explosion           = "flameBoltExplosion";
   splash              = PlasmaSplash;

   baseEmitter        = FlameEmitter;

   dryVelocity       = 50.0; // z0dd - ZOD, 7/20/02. Faster plasma projectile. was 55
   wetVelocity       = -1;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 250;
   lifetimeMS        = 1000;
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

////////////////////////////////
datablock ParticleData(GhostflameParticle)
{
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = -0.1;
   inheritedVelFactor   = 0.1;

   lifetimeMS           = 500;
   lifetimeVarianceMS   = 50;

   textureName          = "particleTest";

   spinRandomMin = -10.0;
   spinRandomMax = 10.0;

   colors[0]     = "0 1 0 0.4";
   colors[1]     = "0 1 0 0.3";
   colors[2]     = "0 1 0 0.0";
   sizes[0]      = 2.0;
   sizes[1]      = 1.0;
   sizes[2]      = 0.8;
   times[0]      = 0.0;
   times[1]      = 0.6;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(GhostflameEmitter)
{
   ejectionPeriodMS = 3;
   periodVarianceMS = 0;

   ejectionOffset = 0.2;
   ejectionVelocity = 10.0;
   velocityVariance = 0.0;

   thetaMin         = 0.0;
   thetaMax         = 10.0;

   particles = "GhostflameParticle";
};

datablock LinearFlareProjectileData(GhostFlameboltMain)
{
   projectileShapeName = "turret_muzzlepoint.dts";
   scale               = "1.0 1.0 1.0";
   faceViewer          = true;
   directDamage        = 0.05;
   hasDamageRadius     = true;
   indirectDamage      = 0.1;
   damageRadius        = 4.0;
   kickBackStrength    = 0.0;
   radiusDamageType    = $DamageType::Plasma;

   explosion           = "flameBoltExplosion";
   splash              = PlasmaSplash;

   baseEmitter        = GhostflameEmitter;

   dryVelocity       = 50.0; // z0dd - ZOD, 7/20/02. Faster plasma projectile. was 55
   wetVelocity       = -1;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 250;
   lifetimeMS        = 30000;
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
// Ammo
//--------------------------------------

datablock ItemData(flamerAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_plasma.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some flame thrower fuel";
};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ItemData(flamer)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_plasma.dts";
   image = flamerImage;
   mass = 1.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a flame thrower";
};

datablock ShapeBaseImageData(flamerImage)
{
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   mass = 10;
   item = flamer;
   ammo = flamerAmmo;
   offset = "0 0 0"; // L/R - F/B - T/B
   rotation = "0 1 0 180"; // L/R - F/B - T/B

   RankReqName = "Flame Thrower"; //Called By TWMFuncitons.cs & Weapons.cs
   projectileSpread = 7.0 / 1000.0;

   projectile = flameBoltmain;
   projectileType = LinearFlareProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = PlasmaSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateEmitter[2] = "FlamerIdleFlameEmitter";
   stateEmitterNode[2] = "muzzlepoint1";
   stateEmitterTime[2] = 10000; 
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "CheckWet";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.02;
   stateFire[3] = true;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateSound[3] = FlamethrowerFireSound;
   stateEmitterTime[3] = 0.02;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.02;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
   stateSound[4] = PlasmaReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = PlasmaDryFireSound;
   stateTimeoutValue[6]        = 1.0;
   stateTransitionOnTimeout[6] = "NoAmmo";
   
   stateName[7]       = "WetFire";
   stateSound[7]      = PlasmaFireWetSound;
   stateTimeoutValue[7]        = 1.0;
   stateTransitionOnTimeout[7] = "Ready";
   
   stateName[8]               = "CheckWet";
   stateTransitionOnWet[8]    = "WetFire";
   stateTransitionOnNotWet[8] = "Fire"; 
};

function flamerImage::onMount(%this,%obj,%slot) 
{ 
	Parent::onMount(%this,%obj,%slot);
	if(%obj.hasFlamerAmmopack == 0) {
	CommandToClient(%obj.client, 'BottomPrint', "You must have a Flamer ammo pack to get flamer ammo.", 3, 2 ); 
    }
}

function flamerImage::onFire(%data,%obj,%slot) {// ADDED HERE
   //We need to cool down the weapon...
   if(%obj.overHeated) {
      commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Armor Heat Systems Locked.. Cooling<spop>", 1, 1);
      return;
   }
   %p = Parent::onFire(%data, %obj, %slot);
   if(%obj.getInventory( %data.ammo ) <= 0) {
      if(%obj.hasFlamerAmmopack == 1) {
         commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Recharging Flamethrower<spop>", 8, 2);
         schedule(8000,0,"ReAddFlameAmmo",%obj);
      }
   }
}

function ReAddFlameAmmo(%obj) {
   %obj.setInventory(flamerAmmo,60,true);
}

function burnloop(%obj){
   if(!isobject(%obj))
	return;
   if(%obj.onfire == 0) {
   return;
   }
   if(%obj.firecount >= %obj.maxfirecount){
	%obj.firecount = "";
	%obj.maxfirecount = 0;
	%obj.onfire = 0;
    return;
   }
   else {
	%obj.damage(0, %obj.getposition(), 0.02, $DamageType::Burn);
   	%fire = new ParticleEmissionDummy(){ 
   	   position = vectoradd(%obj.getPosition(),"0 0 0.5");
   	   dataBlock = "defaultEmissionDummy"; 
   	   emitter = "FlameEmitter";  
      };
	MissionCleanup.add(%fire);
	%fire.schedule(100, "delete");
	%obj.firecount++;
	schedule(100, %obj, "burnloop", %obj);
   }
}
