//--------------------------------------
// Light SMG
//--------------------------------------             

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock TracerProjectileData(LSMGBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.15;
   directDamageType    = $DamageType::MP5;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;
   HeadMultiplier      = 1.25;
   LegsMultiplier      = 0.75;

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

//--------------------------------------------------------------------------
// Ammo
//--------------------------------------

datablock ItemData(LSMGAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some MP12 ammo";

   computeCRC = true;
};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ShapeBaseImageData(LSMGImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item      = LSMG;
   ammo 	 = LSMGAmmo;
   projectile = LSMGBullet;
   projectileType = TracerProjectile;
   emap = true;
   offset = "0 0.5 0";  // L/R - F/B - T/B
   rotation = "0 1 0 180";
   mass = 11;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   RankReqName = "MP12 SMG"; //Called By TWMFuncitons.cs & Weapons.cs
   projectileSpread = 2 / 1000.0;
   maxSpread = 12 / 1000;

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
   stateTimeoutValue[3]          = 0.01;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   //--------------------------------------
   stateName[4]             = "Fire";
   stateSequence[4]            = "Fire";
   stateSequenceRandomFlash[4] = true;
   stateSpinThread[4]       = FullSpeed;
   stateSound[4]            = ChaingunFireSound;
   stateRecoil[4]           = LightRecoil;
   stateEmitter[4] = "GunFireEffectEmitter";
   stateEmitterNode[4] = "muzzlepoint1";
   stateEmitterTime[4] = 1; 
   stateAllowImageChange[4] = false;
   stateScript[4]           = "onFire";
   stateFire[4]             = true;
   stateEjectShell[4]       = true;
   //
   stateTimeoutValue[4]          = 0.05;
   stateTransitionOnTimeout[4]   = "Fire";
   stateTransitionOnTriggerUp[4] = "Spindown";
   stateTransitionOnNoAmmo[4]    = "EmptySpindown";

   //--------------------------------------
   stateName[5]       = "Spindown";
   stateSound[5]      = ChaingunSpinDownSound;
   stateSpinThread[5] = SpinDown;
   //
   stateTimeoutValue[5]            = 0.05;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[5]     = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   //--------------------------------------
   stateName[6]       = "EmptySpindown";
   stateSound[6]      = ChaingunSpinDownSound;
   stateSpinThread[6] = SpinDown;
   //
   stateTimeoutValue[6]        = 0.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
   
   //--------------------------------------
   stateName[7]       = "DryFire";
   stateSound[7]      = ChaingunDryFireSound;
   stateTimeoutValue[7]        = 0.5;
   stateTransitionOnTimeout[7] = "NoAmmo";
};

datablock ItemData(LSMG)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_energy_vehicle.dts";
   image        = LSMGImage;
   mass         = 1.0;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "a MP12 SMG";

   computeCRC = true;
   emap = true;
};

datablock ItemData(LSMGClip)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "some 6mm clips";

   computeCRC = true;
};

datablock ShapeBaseImageData(LSMGmain)
{
   ammo = LSMGAmmo;
   shapeFile = "weapon_targeting.dts";
   offset = "0.0 0.0 0.0";
   emap = true;
};

datablock ShapeBaseImageData(LSMGClipImage)
{
   shapeFile = "grenade.dts";
   ammo = LSMGAmmo;
   offset = "0.0 0.64 -0.2";
   emap = true;
};

function LSMGImage::onMount(%this,%obj,%slot)
{
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(LSMGClipImage, 5);
   %obj.mountImage(LSMGmain, 6);
   %obj.clipReloading = false;
   if (%obj.inv[LSMGAmmo] == 0)
      %obj.LSMGcheckclip = schedule(10, 0, "LSMGCheckforclip", %obj);
}

function LSMGImage::onUnmount(%this,%obj,%slot)
{
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   if (%obj.clipReloading != false)
	{
	Cancel(%obj.LSMGClipAdd);
	%obj.clipReloading = false;
	}
}

function LSMGImage::onFire(%data,%obj,%slot) {
   %obj.decInventory(%data.ammo,1);

   if(%obj.spread $= "" || %obj.spread < %data.projectileSpread)
	%obj.spread = %data.projectileSpread;
   else
      %obj.spread = %obj.spread + (1.5 / 1000);

   if(%obj.lowSpreadLoop $= "")
	%obj.lowSpreadLoop = schedule(250, 0, "RiflelowerSpread", %data, %obj);
   if(%obj.spread > %data.maxspread)
	%obj.spread = %data.maxspread;

    %vector = %obj.getMuzzleVector(%slot);
    %mp = %obj.getMuzzlePoint(%slot);

      %x = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
      %newvector = MatrixMulVector(%mat, %vector);
      %p = new (%data.projectileType)()
	   {
            dataBlock        = %data.projectile;
            initialDirection = %newvector;
            initialPosition  = %mp;
            sourceObject     = %obj;
		    damageFactor	 = 1;
            sourceSlot       = %slot;
      };
      if (%obj.inv[LSMGAmmo] == 0)
         %obj.LSMGcheckclip = schedule(10, 0, "LSMGCheckforclip", %obj);
}

function LSMGCheckforclip(%obj)
{
   if (%obj.inv[LSMGclip] > 0)
   {
	%obj.clipReloading = true;
      %obj.unmountImage(5);
      %obj.LSMGClipAdd = schedule(1500, 0, "LSMGReloadClip", %obj);
   }
}

function LSMGReloadClip(%obj) 
{ 
   %obj.clipReloading = false;
   %obj.decInventory(LSMGClip, 1);
   %obj.mountImage(LSMGClipImage, 5);
   %obj.setInventory(LSMGAmmo, 45);
}  

function LSMGBullet::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal)
{
	// extra damage for head shot or less for close range shots
	if(!(%targetObject.getType() & ($TypeMasks::InteriorObjectType | $TypeMasks::TerrainObjectType)) &&
        (%targetObject.getDataBlock().getClassName() $= "PlayerData"))
	{
	   %damLoc = firstWord(%targetObject.getDamageLocation(%position));
	   if(%damLoc $= "head")
	   {
		%targetObject.getOwnerClient().headShot = 1;
		%modifier *= %data.HeadMultiplier;
	   }
	   else if(%damLoc $= "legs")
	   {
		%modifier *= %data.LegsMultiplier;
	   }
	   else
	   {
		%modifier = 1;
		%targetObject.getOwnerClient().headShot = 0;
	   }
	}

    %targetObject.damage(%projectile.sourceObject, %position, %modifier * %data.directDamage, %data.directDamageType);
}
