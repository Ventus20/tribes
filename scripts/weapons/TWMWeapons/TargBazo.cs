//--------------------------------------
// BazookaII
//--------------------------------------


//--------------------------------------------------------------------------
// Projectile
//--------------------------------------
datablock GrenadeProjectileData(BazookaIIshot)
{
   projectileShapeName = "weapon_missile_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 3.5;
   damageRadius        = 8.5;
   radiusDamageType    = $DamageType::BazookaII;
   kickBackStrength    = 1000;

   explosion           = "MissileExplosion";
   underwaterExplosion = "MissileExplosion";
   velInheritFactor    = 0.5;
   splash              = MissileSplash;
   depthTolerance      = 0.01;

   baseEmitter         = MissileFireEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;

   grenadeElasticity = 0.0;
   grenadeFriction   = 0.0;
   armingDelayMS     = -1;

   gravityMod        = 0.01;
   muzzleVelocity    = 150.0;
   drag              = 0.01;
   sound	     = MissileProjectileSound;

   hasLight    = true;
   lightRadius = 4;
   lightColor  = "0.05 0.2 0.05";

   hasLightUnderwaterColor = true;
   underWaterLightColor = "0.05 0.075 0.2";

};

//--------------------------------------------------------------------------
// Ammo
//--------------------------------------

datablock ItemData(BazookaIIAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_missile.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some missiles";

   computeCRC = true;

};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ItemData(BazookaII)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_missile.dts";
   image = BazookaIIImage;
   mass = 1.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a BazookaII MK III";

   computeCRC = true;
   emap = true;
};

datablock ShapeBaseImageData(BazookaIIImage)
{
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   item = BazookaII;
   ammo = BazookaIIAmmo;
   offset = "0 -0.5 0";
   armThread = lookms;
   emap = true;
   mass = 30;

   RankReqName = "Enemia Rocket Launcher"; //Called By TWMFuncitons.cs & Weapons.cs
   projectile = BazookaIIshot;
   projectileType = GrenadeProjectile;

   //--------------------------------------
   stateName[0]             = "Activate";
   stateSequence[0]         = "Activate";
   stateSound[0]            = ChaingunSwitchSound;
   stateAllowImageChange[0] = false;
   stateTimeoutValue[0]        = 1.0;
   stateTransitionOnTimeout[0] = "Ready";
   stateTransitionOnNoAmmo[0]  = "NoAmmo";

   //--------------------------------------
   stateName[1]       = "Ready";
   stateScript[1]	    = "onReady";
   stateSpinThread[1] = Stop;
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
   stateScript[3]           = "onSpinup";
   stateTimeoutValue[3]          = 2;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   //--------------------------------------
   stateName[4]             = "Fire";
   stateSequence[4]            = "Fire";
   stateSpinThread[4]       = FullSpeed;

   stateEmitter[4] 	    = "BazookaFireEffectEmitter";
   stateEmitterNode[4]      = "muzzlepoint1";
   stateEmitterTime[4]      = 0.1;
   stateRecoil[4]           = LightRecoil;
   stateAllowImageChange[4] = false;

   stateScript[4]           = "onFire";
   stateFire[4]             = true;
   stateEjectShell[4]       = true;
   stateTimeoutValue[4]          = 1.0;
   stateTransitionOnTimeout[4]   = "Spindown";
   stateTransitionOnTriggerUp[4] = "Spindown";
   stateTransitionOnNoAmmo[4]    = "EmptySpindown";

   //--------------------------------------
   stateName[5]       = "Spindown";
   stateSpinThread[5] = SpinDown;
   stateScript[5]           = "onSpindown";
   stateTimeoutValue[5]            = 1.5;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[5]     = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   //--------------------------------------
   stateName[6]       = "EmptySpindown";
   stateSpinThread[6] = SpinDown;
   stateScript[6]           = "onSpindown";
   stateTimeoutValue[5]            = 1.5;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[6] = "NoAmmo";

   //--------------------------------------
   stateName[7]       = "DryFire";
   stateSound[7]      = ChaingunDryFireSound;
   stateTimeoutValue[7]        = 0.5;
   stateTransitionOnTimeout[7] = "NoAmmo";
};

datablock ShapeBaseImageData(BazookaIIMiddleImage)
{
   armThread = lookms;
   className = WeaponImage;
   shapeFile = "weapon_Mortar.dts";
   offset = "-0.1 -1.25 0.1"; 	// L/R - F/B - T/B
   rotation = "0 0 0 0"; 		// L/R - F/B - T/B
   emap = true;
};

datablock ShapeBaseImageData(BazookaIIBackImage)
{
   armThread = lookms;
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   offset = "0 -0.75 0"; 	// L/R - F/B - T/B
   rotation = "0 0 1 180"; 		// L/R - F/B - T/B
   emap = true;
   ammo = BazookaIIAmmo;
};

function BazookaIIImage::onFire(%data,%obj,%slot) {
   %p = Parent::onFire(%data, %obj, %slot);
   %obj.unmountImage(7);
   schedule(4000,0,"remountMisisle2",%obj);
   %velocity = vectorlen(%obj.getVelocity());
   if (%velocity < 1)
      %obj.applyKick(-750);
   else if (%velocity > 1 && %Velocity < (%obj.maxForwardSpeed - 1))
      %obj.applyKick(-1750);
   else
      %obj.applyKick(-3250);
}

function BazookaIIImage::onMount(%this,%obj,%slot)
{
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(BazookaIIMiddleImage, 5);
   %obj.mountImage(BazookaIIBackImage, 6);
   %obj.mountImage(BazookaMissileImage,7);
   %obj.usingbazooka2 = true;
}

function BazookaIIImage::onUnmount(%this,%obj,%slot)
{
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   %obj.unmountImage(7);
   %obj.usingbazooka2 = false;
}

function remountMisisle2(%obj) {
if(%obj.usingbazooka2) {
%obj.mountImage(BazookaMissileImage,7);
}
else {
return;
}
}
