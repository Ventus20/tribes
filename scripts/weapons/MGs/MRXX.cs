datablock TracerProjectileData(MRXXBullet) {
   doDynamicClientHits = true;

   directDamage        = 0.043;
   directDamageType    = $DamageType::MRXX;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;
   HeadMultiplier      = 1.25;
   LegsMultiplier      = 0.75;
   
   ImageSource         = "MRXXImage";

   kickBackStrength  = 15.0;
   sound 				= ChaingunProjectile;

   dryVelocity       = 1750.0;
   wetVelocity       = 1500.0;
   velInheritFactor  = 0.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 9.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.09;
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

datablock ItemData(MRXXAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 3;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some MRXX ammo";

   computeCRC = true;

};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ShapeBaseImageData(MRXXImage) {
   className = WeaponImage;
   shapeFile = "weapon_mortar.dts";
   item      = MRXX;
   ammo 	 = MRXXAmmo;
   projectile = MRXXBullet;
   projectileType = TracerProjectile;
   emap = true;
   mass = 26;

   //ClipStuff
   ClipName = "MRXXClip";
   ClipPickupName["MRXXClip"] = "some MRXX Clip Boxes";
   ShowsClipInHud = 1;
   ClipReloadTime = 9;
   ClipReturn = 150;
   InitialClips = 5;
   //
   HasChallenges = 1;
   ChallengeCt = 8;
   Challenge[1] = "MRXX ZC4 Killer\t50\t100\tNone";
   Challenge[2] = "MRXX ZC4 Expert\t100\t250\tNone";
   Challenge[3] = "MRXX ZC4 Master\t250\t500\tGrip";
   Challenge[4] = "MRXX ZC4 God\t500\t1000\tSilencer";
   Challenge[5] = "MRXX ZC4 Bronze Commendation\t1500\t10000\tNone";
   Challenge[6] = "MRXX ZC4 Silver Commendation\t5000\t25000\tNone";
   Challenge[7] = "MRXX ZC4 Gold Commendation\t10000\t50000\tNone";
   Challenge[8] = "MRXX ZC4 Titan Commendation\t25000\t75000\tNone";
   Upgrade[1] = "Grip";
   Upgrade[2] = "Silencer";
   GunName = "MRXX ZC4 Machine Gun";

   RankRequire = $TWM2::RankRequire["MRXX"];

   casing              = ShellDebris;
   shellExitDir        = "0.5 0 1";
   shellExitOffset     = "0.0 0.75 0.0";
   shellExitVariance   = 5.0;
   shellVelocity       = 4.5;

   projectileSpread = 10.0 / 1000.0;


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
   stateTimeoutValue[3]          = 0.1;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   //--------------------------------------
   stateName[4]             = "Fire";
   stateSequence[4]            = "Fire";
   stateSequenceRandomFlash[4] = true;
   stateSpinThread[4]       = FullSpeed;
   //stateSound[4]            = MRXXFireSound;

   stateAllowImageChange[4] = false;
   stateScript[4]           = "onFire";
   stateFire[4]             = true;
   stateEjectShell[4]       = true;
   stateTimeoutValue[4]          = 0.02;
   stateTransitionOnTimeout[4]   = "Fire";
   stateTransitionOnTriggerUp[4] = "Spindown";
   stateTransitionOnNoAmmo[4]    = "EmptySpindown";

   //--------------------------------------
   stateName[5]       = "Spindown";
   stateSound[5]      = ChaingunSpinDownSound;
   stateSpinThread[5] = SpinDown;
   //
   stateTimeoutValue[5]            = 0.1;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[5]     = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   //--------------------------------------
   stateName[6]       = "EmptySpindown";
   stateSound[6]      = ChaingunSpinDownSound;
   stateSpinThread[6] = SpinDown;
   //
   stateTimeoutValue[6]        = 1.0;
   stateTransitionOnTimeout[6] = "NoAmmo";

   //--------------------------------------
   stateName[7]       = "DryFire";
   stateSound[7]      = ChaingunDryFireSound;
   stateTimeoutValue[7]        = 0.5;
   stateTransitionOnTimeout[7] = "NoAmmo";
};

datablock ItemData(MRXX) {
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "turret_tank_barrelchain.dts";
   image        = MRXXImage;
   mass         = 1.0;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "a MRXX ZC4 MG";

   computeCRC = true;
   emap = true;
};

function MRXXImage::onFire(%data, %obj, %slot) {
   %p = Parent::onFire(%data, %obj, %slot);
   if(%obj.client.UpgradeOn("Silencer", %data.getName())) {
      //zero sound :p
   }
   else {
      ServerPlay3d(ChaingunFireSound, %obj.getPosition());
   }
}
