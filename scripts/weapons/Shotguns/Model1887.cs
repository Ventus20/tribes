datablock TracerProjectileData(Model1887Pellet)
{
   doDynamicClientHits = true;

   directDamage        = (0.064 * 1.5);
   directDamageType    = $DamageType::Model1887;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;
   HeadMultiplier      = 1.2;
   LegsMultiplier      = 0.75;

   longRangeMultiplier  = 0.75;
   kickBackStrength  = 0.0;
   sound 				= ChaingunProjectile;
   
   ImageSource         = "Model1887Image";

   dryVelocity       = 1500.0;
   wetVelocity       = 1000.0;
   velInheritFactor  = 0.0;
   fizzleTimeMS      = 500;
   lifetimeMS        = 500;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 5.0;
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

//--------------------------------------------------------------------------
// Ammo
//--------------------------------------

datablock ItemData(Model1887Ammo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some Model 1887 rounds";

   computeCRC = true;

};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ShapeBaseImageData(Model1887Image)
{
   className = WeaponImage;
   shapeFile = "weapon_disc.dts";
   item      = Model1887;
   ammo 	 = Model1887Ammo;
   projectile = Model1887Pellet;
   projectileType = TracerProjectile;
   emap = true;
   mass = 20;

   casing              = ShellDebris;
   shellExitDir        = "0.5 0.0 1.0"; // L/R - F/B - T/B
   shellExitOffset     = "0.15 -0.51 -0.1"; // L/R - F/B - T/B
   shellExitVariance   = 10.0;
   shellVelocity       = 4.0;

   //ClipStuff
   ClipName = "Model1887Clip";
   ClipPickupName["Model1887Clip"] = "some Model 1887 Clip Boxes";
   ShowsClipInHud = 1;
   ClipReloadTime = 9;
   ClipReturn = 7;
   InitialClips = 3;
   
   ReloadSingle = 1;
   SingleShotAdd = 1;
   //
   RankRequire = $TWM2::RankRequire["RSALaserRifle"];
   PrestigeRequire = 1;

   //Challenges
   HasChallenges = 1;
   ChallengeCt = 9;
   Challenge[1] = "Model 1887 Killer\t50\t100\tNone";
   Challenge[2] = "Model 1887 Extremist\t100\t150\tNone";
   Challenge[3] = "Model 1887 Expert\t250\t250\tNone";
   Challenge[4] = "Model 1887 Master\t500\t500\tNone";
   Challenge[5] = "Model 1887 God\t1000\t1000\tNone";
   Challenge[6] = "Model 1887 Bronze Commendation\t2500\t10000\tNone";
   Challenge[7] = "Model 1887 Silver Commendation\t5000\t25000\tNone";
   Challenge[8] = "Model 1887 Gold Commendation\t10000\t50000\tNone";
   Challenge[9] = "Model 1887 Titan Commendation\t25000\t75000\tNone";
   GunName = "Model 1887 Shotgun";
   //

   projectileSpread = 7.0 / 1000.0;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = ChaingunSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "CheckWet";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.0001;
   stateFire[3] = true;
   stateEjectShell[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 1.0;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = ChaingunDryFireSound;
   stateTimeoutValue[6]        = 1.0;
   stateTransitionOnTimeout[6] = "NoAmmo";

   stateName[7]       = "WetFire";
   stateSound[7]      = ChaingunDryFireSound;
   stateTimeoutValue[7]        = 1.0;
   stateTransitionOnTimeout[7] = "Ready";

   stateName[8]               = "CheckWet";
   stateTransitionOnWet[8]    = "WetFire";
   stateTransitionOnNotWet[8] = "Fire";
};

datablock ItemData(Model1887)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_plasma.dts";
   image        = Model1887Image;
   mass         = 1.0;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "a Model 1887";

   computeCRC = true;
   emap = true;
};

function Model1887Image::onMount(%this,%obj,%slot) {
   Parent::onMount(%this, %obj, %slot);
}

function Model1887Image::onFire(%data,%obj,%slot) {
    serverPlay3D(ShotgunFireSound, %obj.getPosition());

    %obj.applyKick(-250);
    %obj.decInventory(%data.ammo,1);

    %vector = %obj.getMuzzleVector(%slot);
    %mp = %obj.getMuzzlePoint(%slot);

	for (%i = 0; %i < 14; %i++) {
      %x = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
      %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
      %newvector = MatrixMulVector(%mat, %vector);

      %p = new (%data.projectileType)() {
            dataBlock        = %data.projectile;
            initialDirection = %newvector;
            initialPosition  = %mp;
            sourceObject     = %obj;
		    damageFactor	 = 1;
            sourceSlot       = %slot;
      };

      %p.WeaponImageSource = %data.getName();
    }
    if(%obj.inv[Model1887Ammo] == 0) { //Added Phantom139, TWM2
       AttemptReload(%data, %obj, %slot);
    }
}
