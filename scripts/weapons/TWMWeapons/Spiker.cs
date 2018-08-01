// Allows objects to scan a nearby area.
function containernearraycast(%obj,%distance,%nearness,%mask)
{
   InitContainerRadiusSearch(%obj.getPosition(),%distance,%mask);
   while ((%obj2 = containersearchnext()) != 0)
   {
      if(%obj == %obj2)
         continue;
      %pos = %obj.getposition();
      %pos2 = %obj2.getposition();
      %vec = vectorsub(%pos,%pos2);
      %len = vectorlen(%vec);
      %mvec = %obj.getMuzzleVector(0);
      %pos = %obj.getMuzzlePoint(0);
      %mnrm = vectornormalize(%mvec);
      %mvec = vectorscale(%mnrm,%len);
      %targetPos = vectoradd(%pos,%mvec);
      %distance = vectordist(%targetPos,%pos2);
      if(%distance <= %nearness)
      {
         return %obj2;
      }
   }
   return "";
}

datablock ItemData(spikerTarget)     //used for spike seeking
{
   shapeFile = "turret_muzzlepoint.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   computeCRC = true;
   emap=true;
};

datablock ParticleData(spikerParticle)
{
	dragCoefficient      = 0.0;
    windCoefficient      = 0.0;
	gravityCoefficient   = 0.0;
	inheritedVelFactor   = -0.2;
	constantAcceleration = -10;

	lifetimeMS           = 50;
	lifetimeVarianceMS   = 0;

	textureName          = "particletest";

	useInvAlpha = false;
	spinRandomMin = 0.0;
	spinRandomMax = 0.0;

	colors[0]     = "1.0 0.51 0.51 1.0";
	colors[1]     = "1.0 0.51 0.51 1.0";
	colors[2]     = "1.0 0.51 0.51 1.0";
	sizes[0]      = 0.08;
	sizes[1]      = 0.08;
	sizes[2]      = 0.02;
	times[0]      = 0.0;
	times[1]      = 0.5;
	times[2]      = 1.0;
};

datablock ParticleEmitterData(spikerEmitter)
{
	ejectionPeriodMS = 0.01;
	periodVarianceMS = 0;

	ejectionVelocity = 0.0;
	velocityVariance = 0.0;

	thetaMin         = 0.0;
	thetaMax         = 0.0;

    particles = "spikerParticle";
};

datablock SeekerProjectileData(spikerProj)
{
   directDamage        = 0.01;
   directDamageType    = $DamageType::Spiker;
   hasDamageRadius     = true;
   indirectDamage      = 0.1;
   damageRadius        = 3.0;
   radiusDamageType    = $DamageType::Spiker;
   projectileShapeName = "turret_muzzlepoint.dts";
   velInheritFactor    = 1.0;
   baseEmitter         = spikerEmitter;

   lifetimeMS          = 10000; // z0dd - ZOD, 4/14/02. Was 6000
   muzzleVelocity      = 10.0;
   maxVelocity         = 20.0; // z0dd - ZOD, 4/14/02. Was 80.0
   turningSpeed        = 60.0;
   acceleration        = 200.0;

   proximityRadius     = 8;      //seek distance for Spikes

   terrainAvoidanceSpeed         = 180;
   terrainScanAhead              = 0;
   terrainHeightFail             = 0;
   terrainAvoidanceRadius        = 100;

   hasLight    = true;
   lightRadius = 1.01;
   lightColor  = "1.0 0.51 0.51";

   explodeOnWaterImpact = false;

};

datablock LinearFlareProjectileData(RAAMCGProjectile)
{
   projectileShapeName = "turret_muzzlepoint.dts";
   scale               = "1.0 1.0 1.0";
   faceViewer          = true;
   directDamage        = 0.15;
   kickBackStrength    = 0.0;
   radiusDamageType    = $DamageType::MG42;

   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;
   HeadMultiplier      = 1.5;
   LegsMultiplier      = 0.5;

   baseEmitter        = spikerEmitter;

   dryVelocity       = 3000.0;
   wetVelocity       = 1000.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

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
   fireSound    = PlasmaFireSound;
   wetFireSound = PlasmaFireWetSound;

   hasLight    = true;
   lightRadius = 10.0;
   lightColor  = "0.94 0.03 0.12";
};
datablock ItemData(spiker)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_targeting.dts";
   image = spikerImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a spiker";

   computeCRC = true;
   emap=true;
};

datablock ShapeBaseImageData(spikerImage)
{
   className = WeaponImage;
   shapeFile = "bomb.dts";
   offset = "0 0.5 0";
   item = spiker;
   usesEnergy = true;
   fireEnergy = 4;
   minEnergy = 4;

   RankReqName = "Phantom Spiker"; //Called By TWMFuncitons.cs & Weapons.cs
   projectile = spikerProj;
   projectileType = SeekerProjectile;
   spike = true;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = BlasterSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Fire";
   stateTimeoutValue[3] = 0.1;
   stateFire[3] = true;
   stateRecoil[3] = NoRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateSound[3] = BlasterFireSound;
   stateScript[3] = "onFire";
   stateTransitionOnTriggerUp[3] = "Reload";
   stateTransitionOnNoAmmo[3] = "Dryfire";

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTimeoutValue[4] = 0.1;
   stateTransitionOnTimeout[4] = "Ready";
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateTimeoutValue[6] = 0.3;
   stateSound[6] = BlasterDryFireSound;
   stateTransitionOnTimeout[6] = "Ready";
};

function spikerImage::onFire(%data,%obj,%slot)
{
      if($Host::RankSystem == 1 && $Rank::XP[%obj.client.ranknum] < $TWM::WeaponRequirement["PhantomSpiker"] && !%obj.client.isaicontrolled()) {
      commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Your Rank Is Too Low To Use This Weapon \n You need "@$TWM::WeaponRequirement["PhantomSpiker"]@" EXP<spop>", 5, 2);
      }
      else {
      %p = Parent::onFire(%data, %obj, %slot);
   if(!isObject(%p))
      return;

   %target = containernearraycast(%obj,120,15,$TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType);
   if(%target)
      %p.targetloop(%obj,%target);
   else
      %p.setNoTarget();
      }
}

function SeekerProjectile::targetLoop(%proj,%obj,%target)
{
   if(!isObject(%target)) //no target
      return;
   if(!isObject(%proj)) //projectile's lifetime's up
      return;
   if(!isObject(%proj.looptarget)) //no target to track: give it one
   {
      %proj.looptarget = new Item()
      {
         datablock = "spikerTarget";
         position = %target.getWorldBoxCenter();
         static = true;
      };
      %proj.setObjectTarget(%proj.looptarget);
   }
   else //just update the position
      %proj.looptarget.setPosition(%target.getWorldBoxCenter());

   %proj.loop = %proj.schedule(200,targetloop,%obj,%target);
}
