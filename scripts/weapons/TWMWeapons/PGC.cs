
datablock TracerProjectileData(GaussWeaponProjectile)
{
   doDynamicClientHits = true;

   directDamage        = 8.0;
   directDamageType    = $DamageType::PGC;
   hasDamageRadius     = true;
   indirectDamage      = 1.8;
   damageRadius        = 5.0;
   radiusDamageType    = $DamageType::PGC;
   explosion           = "MissileExplosion";
   splash              = ChaingunSplash;

   kickBackStrength  = 1500.0;
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
	tracerWidth     = 2.25;
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


//--------------------------------------
// Rifle and item...
//--------------------------------------
datablock ItemData(portibleGauss)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_sniper.dts";
   image        = portibleGaussImage;
   mass         = 1;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
	pickUpName = "a Portible Gauss Cannon";

   computeCRC = true;

};

datablock ItemData(portibleGaussAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_plasma.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "Portible Gauss Cannon Shells";

   computeCRC = true;

};

datablock ShapeBaseImageData(portibleGaussImage)
{
   className = WeaponImage;
   shapeFile = "weapon_mortar.dts";
   item = portibleGauss;
   projectile =  GaussWeaponProjectile;
   projectileType = TracerProjectile;
   ammo 	 = portibleGaussAmmo;

   RankReqName = "PGC Cannon"; //Called By TWMFuncitons.cs & Weapons.cs
   usesEnergy = false;

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
   stateTimeoutValue[3]          = 0.9;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   //--------------------------------------
   stateName[4]             = "Fire";
   stateSequence[4]            = "Fire";
   stateSpinThread[4]       = FullSpeed;
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
   stateTimeoutValue[5]            = 0.6;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[5]     = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   //--------------------------------------
   stateName[6]       = "EmptySpindown";
   stateSpinThread[6] = SpinDown;
   stateScript[6]           = "onSpindown";
   stateTimeoutValue[5]            = 0.6;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[6] = "NoAmmo";

   //--------------------------------------
   stateName[7]       = "DryFire";
   stateSound[7]      = ChaingunDryFireSound;
   stateTimeoutValue[7]        = 0.5;
   stateTransitionOnTimeout[7] = "NoAmmo";
};

datablock ShapeBaseImageData(PGCBarrel1Image) : portibleGaussImage
{
    shapeFile = "weapon_ELF.dts";
    offset = "0 0.3 0.2";
    rotation = "0 1 0 180";
};

datablock ShapeBaseImageData(PGCBarrel2Image) : portibleGaussImage
{
    shapeFile = "weapon_ELF.dts";
    offset = "0 .5 0";
};


function portibleGaussImage::onMount(%this, %obj, %slot)
{
Parent::onMount(%this, %obj, %slot);
%obj.mountImage(PGCBarrel1Image, 5);
%obj.mountImage(PGCBarrel2Image, 6);
}

function portibleGaussImage::onUnmount(%this,%obj,%slot)
{
Parent::onUnmount(%this, %obj, %slot);
%obj.unmountImage(5);
%obj.unmountImage(6);
}

function portibleGaussImage::onFire(%data,%obj,%slot){
   serverPlay3d("SniperFireSound",%obj.getmuzzlepoint(0));
   %p = Parent::onFire(%data, %obj, %slot);
}
