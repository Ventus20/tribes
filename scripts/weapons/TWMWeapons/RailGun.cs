datablock TracerProjectileData(RailGunBeam) {
   doDynamicClientHits = true;

   directDamage        = 10.0;
   explosion           = "ScoutChaingunExplosion";
   splash              = ChaingunSplash;

   directDamageType    = $DamageType::RailGun;
   kickBackStrength  = 0.0;

   sound = ShrikeBlasterProjectileSound;

   dryVelocity       = 425.0;
   wetVelocity       = 100.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 1000;
   lifetimeMS        = 1000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 190.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = "1 0 0";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
   tracerWidth     = 1.75;
   crossSize       = 0.99;
   crossViewAng    = 0.990;
   renderCross     = true;

};

datablock ItemData(RailGun)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "turret_tank_barrelmortar.dts";
   image = RailGunImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "abunker buster nuke";

   computeCRC = true;
   emap = true;
};


datablock ShapeBaseImageData(RailGunImage)
{
   className = WeaponImage;
   shapeFile = "turret_tank_barrelmortar.dts";
   item = RailGun;
   offset = "0 0 0";
   emap = true;

   usesEnergy = true;
   fireEnergy = 4;
   minEnergy = 4;

   RankReqName = "NoRequire"; //Called By TWMFuncitons.cs & Weapons.cs

   projectile = RailGunBeam;
   projectileType = TracerProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = MortarSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.3;
   stateFire[3] = true;
   stateRecoil[3] = NoRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateSound[3] = MortarFireSound;
   stateScript[3] = "onFire";

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 2.3;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateTimeoutValue[6] = 0.3;
   stateSound[6] = MortarDryFireSound;
   stateTransitionOnTimeout[6] = "Ready";
};

function RailGunImage::onMount(%this,%obj,%slot) {
     Parent::onMount(%data,%obj,%slot);
     CommandToClient(%obj.client, 'BottomPrint', "<spush><font:Sui Generis:14>>>>Phantom Railgun<<<<spop>\n<spush><font:Arial:14>Unleashes A Mega Shot That Penetrates Anything<spop>", 3, 3 );
}

function RailGunImage::onunmount(%this,%obj,%slot) {
     Parent::onUnmount(%this, %obj, %slot);
}

function RailGunBeam::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal) {
   //If we cannot damage this object, we return
   if(!isObject(%targetObject) || %targetObject $= "" || %targetObject <= 0)
      return;

   echo(%targetObject.getDatablock().getClassName());

//   if(!Deployables.isMember(%targetObject)) {
      if(!isDamageAbleObject(%targetObject)) {
         echo("End");
         return;
      }
//   }
   // checks
   %targetObject.damage(%projectile.sourceObject, %position, %data.directDamage * 10, %data.directDamageType);
   %p = schedule(25,0,spawnprojectile, RailGunBeam, TracerProjectile, %position, %projectile.initialDirection, "");
}
