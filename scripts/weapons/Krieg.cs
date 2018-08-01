//--------------------------------------
// Chaingun
//--------------------------------------          

datablock AudioProfile(KriegFireSound)
{
   filename    = "fx/vehicles/tank_chaingun.wav";
   description = AudioDefault3d;
   preload = true;
   effect = AssaultChaingunFireEffect;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------


datablock TracerProjectileData(KriegBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.4;
   directDamageType    = $DamageType::Rifle;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;
   HeadMultiplier      = 1.5;
   LegsMultiplier      = 0.35;

   kickBackStrength  = 15.0;
   sound 		   = ChaingunProjectile;

   dryVelocity       = 3000.0;
   wetVelocity       = 2000.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 1000;
   lifetimeMS        = 1000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 20.0;
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

datablock ItemData(KriegAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "Some Krieg Rifle Ammo";

   computeCRC = true;

};

datablock ItemData(RifleClip)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "specialized 7.62mm cartidges";
};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ShapeBaseImageData(KriegRifleImage)
{
   className = WeaponImage;
   shapeFile = "weapon_sniper.dts";
   mass = 10;
   item = KriegRifle;
   ammo = KriegAmmo;
   projectile = KriegBullet;
   projectileType = TracerProjectile;
   emap = true;
   
   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   projectileSpread = 0.5 / 1000.0;
   maxSpread = 3 / 1000.0;
   RankReqName = "Krieg Rifle"; //Called By TWMFuncitons.cs & Weapons.cs

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
   stateTimeoutValue[3] = 0.01;
   stateFire[3] = true;
   stateEmitter[3] = "GunFireEffectEmitter";
   stateEmitterNode[3] = "muzzlepoint1";
   stateEmitterTime[3] = 1; 
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = KriegFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.4;
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
   stateSound[7]      = PlasmaFireWetSound;
   stateTimeoutValue[7]        = 1.0;
   stateTransitionOnTimeout[7] = "Ready";
   
   stateName[8]               = "CheckWet";
   stateTransitionOnWet[8]    = "WetFire";
   stateTransitionOnNotWet[8] = "Fire";
};

datablock ItemData(KriegRifle)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_sniper.dts";
   image        = KriegRifleImage;
   mass         = 1.0;
   elasticity   = 0.0;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "a Krieg Rifle";

   computeCRC = true;
   emap = true;
};

datablock ShapeBaseImageData(ScopeImage)
{
   className = WeaponImage;
   ammo = KriegAmmo;
   shapeFile = "weapon_targeting.dts";
   offset = "0.0 -0.2 0.1";
   emap = true;
};

datablock ShapeBaseImageData(ClipImage1)
{
   shapeFile = "grenade.dts";
   ammo = KriegAmmo;
   offset = "0.0 .2 -0.2";
   emap = true;
};

function KriegRifleImage::onMount(%this,%obj,%slot)
{
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(ScopeImage, 5);
   %obj.mountImage(ClipImage1, 6);
   if (%obj.inv[KriegAmmo] == 0)
      %obj.Kriegcheckclip = schedule(10, 0, "KriegCheckforclip", %obj);
   %obj.hasKrieg = true;
}

function KriegRifleImage::onUnmount(%this,%obj,%slot)
{
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   if (%obj.clipReloading != false)
   {
	Cancel(%obj.KriegClipAdd);
	%obj.clipReloading = false;
   }
}

function KriegRifleImage::onFire(%data,%obj,%slot) {
   %obj.decInventory(%data.ammo,1);
   if(%obj.spread $= "" || %obj.spread < %data.projectileSpread)
	%obj.spread = %data.projectileSpread;
   else
      %obj.spread = %obj.spread + (2 / 1000);

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

   if (%obj.inv[KriegAmmo] == 0)
      %obj.Kriegcheckclip = schedule(500, 0, "KriegCheckforclip", %obj);
}

function KriegCheckforclip(%obj)
{
   if (%obj.inv[Rifleclip] > 0)
   {
      %obj.unmountImage(6);
	%obj.clipReloading = true;
      %obj.KriegClipAdd = schedule(1750, 0, "KriegReloadClip", %obj);
   }
}

function KriegReloadClip(%obj) 
{ 
   %obj.clipReloading = false;
   %obj.decInventory(RifleClip, 1);
   %obj.mountImage(ClipImage1, 6);
   %obj.setInventory(KriegAmmo, 10);
} 

function KriegBullet::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal)
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
