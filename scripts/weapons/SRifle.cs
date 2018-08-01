//--------------------------------------------------------------------------
// Spec Ops Rifle RX-12 (SRifle)
//--------------------------------------

datablock TracerProjectileData(SRifleBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.16;
   directDamageType    = $DamageType::SRifle;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;
   HeadMultiplier      = 1.3;
   LegsMultiplier      = 0.6;

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

datablock ItemData(SRifleAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "Some RX-12 Ammo";

   computeCRC = true;

};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ShapeBaseImageData(SRifleImage)
{
   className = WeaponImage;
   shapeFile = "weapon_targeting.dts";
   mass = 10;
   item = SRifleSG;
   ammo = SRifleAmmo;
   projectile = SRifleBullet;
   projectileType = TracerProjectile;
   emap = true;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   RankReqName = "RX-12 w ShotGun"; //Called By TWMFuncitons.cs & Weapons.cs
   projectileSpread = 1 / 1000.0;
   maxSpread = 10 / 1000.0;

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
   stateTransitionOnNoAmmo[3] = "NoAmmo";
   stateTransitionOnTimeout[3] = "Fire2";
   stateTimeoutValue[3] = 0.05;
   stateFire[3] = true;
   stateEmitter[3] = "GunFireEffectEmitter";
   stateEmitterNode[3] = "muzzlepoint1";
   stateEmitterTime[3] = 1; 
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = KriegFireSound;

   stateName[4] = "Fire2";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Fire3";
   stateTimeoutValue[4] = 0.05;
   stateFire[4] = true;
   stateEmitter[4] = "GunFireEffectEmitter";
   stateEmitterNode[4] = "muzzlepoint1";
   stateEmitterTime[4] = 1; 
   stateRecoil[4] = LightRecoil;
   stateAllowImageChange[4] = false;
   stateScript[4] = "onFire";
   stateEmitterTime[4] = 0.2;
   stateSound[4] = KriegFireSound;

   stateName[5] = "Fire3";
   stateTransitionOnNoAmmo[5] = "NoAmmo";
   stateTransitionOnTimeout[5] = "Reload";
   stateTimeoutValue[5] = 0.1;
   stateFire[5] = true;
   stateEmitter[5] = "GunFireEffectEmitter";
   stateEmitterNode[5] = "muzzlepoint1";
   stateEmitterTime[5] = 1; 
   stateRecoil[5] = LightRecoil;
   stateAllowImageChange[5] = false;
   stateScript[5] = "onFire";
   stateEmitterTime[5] = 0.2;
   stateSound[5] = KriegFireSound;

   stateName[6] = "Reload";
   stateTransitionOnNoAmmo[6] = "NoAmmo";
   stateTransitionOnTimeout[6] = "Ready";
   stateTimeoutValue[6] = 0.2;
   stateAllowImageChange[6] = false;
   stateSequence[6] = "Reload";

   stateName[7] = "NoAmmo";
   stateTransitionOnAmmo[7] = "Reload";
   stateSequence[7] = "NoAmmo";
   stateTransitionOnTriggerDown[7] = "DryFire";

   stateName[8]       = "DryFire";
   stateSound[8]      = ChaingunDryFireSound;
   stateTimeoutValue[8]        = 1.0;
   stateTransitionOnTimeout[8] = "NoAmmo";
   
   stateName[9]       = "WetFire";
   stateSound[9]      = PlasmaFireWetSound;
   stateTimeoutValue[9]        = 1.0;
   stateTransitionOnTimeout[9] = "Ready";
   
   stateName[10]               = "CheckWet";
   stateTransitionOnWet[10]    = "WetFire";
   stateTransitionOnNotWet[10] = "Fire";
};

datablock ItemData(SRifleSG)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_shocklance.dts";
   image        = SRifleImage;
   mass         = 1.0;
   elasticity   = 0.0;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "a RX-12 Rifle";

   computeCRC = true;
   emap = true;
};

datablock ItemData(SRifleGL)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_shocklance.dts";
   image        = SRifleImage;
   mass         = 1.0;
   elasticity   = 0.0;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "a RX-12 Rifle";

   computeCRC = true;
   emap = true;
};

datablock ShapeBaseImageData(SRifleImage2)
{
   className = WeaponImage;
   ammo = SRifleAmmo;
   shapeFile = "weapon_shocklance.dts";
   offset = "0.0 0.1 0.0";
   emap = true;
};

datablock ShapeBaseImageData(SRifleClipImage)
{
   shapeFile = "grenade.dts";
   ammo = SRifleAmmo;
   offset = "0.0 0.4 -0.25";
   emap = true;
};

//--------------------------------------------------------------------------
// SRifle Attachments
//--------------------------------------


datablock ItemData(SRifleSGAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "Some RX-12 ShotGun Ammo";

   computeCRC = true;
};

datablock ItemData(SRifleGLAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "grenade.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some RX-12 Grenade Launcher ammo";

   computeCRC = true;
};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ShapeBaseImageData(SRifleSGImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   mass = 10;
   item = SRifleSG;
   ammo = SRifleSGAmmo;
   offset 	 = "0.0 0.7 0.07"; // L/R - F/B - T/B
   projectile = ShotgunPellet;
   projectileType = TracerProjectile;
   emap = true;
   
   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   RankReqName = "RX-12 w ShotGun"; //Called By TWMFuncitons.cs & Weapons.cs
   projectileSpread = 6 / 1000.0;

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
   stateSound[3] = SniperFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 1.2;
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

datablock GrenadeProjectileData(SRifleGLshot)
{
   projectileShapeName = "grenade.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 1.0;
   damageRadius        = 12.0;
   radiusDamageType    = $DamageType::RPG;
   kickBackStrength    = 2000;

   explosion           = "GrenadeExplosion";
   underwaterExplosion = "GrenadeExplosion";
   velInheritFactor    = 0.5;
   splash              = MissileSplash;
   depthTolerance      = 0.01;
   
   baseEmitter         = GrenadeSmokeEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;
   
   grenadeElasticity = 0.0;
   grenadeFriction   = 0.0;
   armingDelayMS     = -1;

   gravityMod        = 1.1;
   muzzleVelocity    = 45.0;
   drag              = 0.2;
   sound	     = MissileProjectileSound;

   hasLight    = true;
   lightRadius = 4;
   lightColor  = "0.05 0.2 0.05";

   hasLightUnderwaterColor = true;
   underWaterLightColor = "0.05 0.075 0.2";
};

datablock ShapeBaseImageData(SRifleGLImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item      = SRifleGL;
   ammo 	 = SRifleGLAmmo;
   offset 	 = "0.0 0.7 0.07"; // L/R - F/B - T/B
   emap 	 = true;

   RankReqName = "RX-12 w Grenade Launcher"; //Called By TWMFuncitons.cs & Weapons.cs
   projectile = SRifleGLshot;
   projectileType = GrenadeProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 1.0;
   stateSequence[0] = "Activate";
   stateSound[0] = GrenadeSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.1;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateScript[3] = "onFire";
   stateSound[3] = GrenadeFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 4.0;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
   stateSound[4] = GrenadeReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = GrenadeDryFireSound;
   stateTimeoutValue[6]        = 4.0;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

//--------------------------------------------------------------------------
// Functions
//--------------------------------------

function SRifleImage::onMount(%this,%obj,%slot)
{
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(SRifleImage2, 5);
   %obj.mountImage(SRifleClipImage, 6);

   if ( %obj.inv[SRifleSGAmmo] >= 1)
	%obj.mountImage(SRifleSGImage, 7);
   else if ( %obj.inv[SRifleGLAmmo] >= 1)
	%obj.mountImage(SRifleGLImage, 7);

   if (%obj.inv[SRifleAmmo] == 0)
      %obj.SRiflecheckclip = schedule(100, 0, "SRifleCheckforclip", %obj);
}

function SRifleImage::onUnmount(%this,%obj,%slot)
{
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   %obj.unmountImage(7);
   if (%obj.clipReloading != false)
   {
	Cancel(%obj.SRifleClipAdd);
	%obj.clipReloading = false;
   }
}

function SRifleImage::onFire(%data,%obj,%slot) {
    %obj.decInventory(%data.ammo,1);

   if(%obj.spread $= "" || %obj.spread < %data.projectileSpread)
	%obj.spread = %data.projectileSpread;
   else
      %obj.spread = %obj.spread + (1 / 1000);

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

   if (%obj.inv[SRifleAmmo] == 0)
      %obj.SRiflecheckclip = schedule(500, 0, "SRifleCheckforclip", %obj);
}

function SRifleSGImage::onFire(%data,%obj,%slot) {
    %obj.decInventory(%data.ammo,1);

    %vector = %obj.getMuzzleVector(%slot);
    %mp = %obj.getMuzzlePoint(%slot);

	for (%i=0; %i < 8; %i++)
	{
      %x = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
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

	}
   if (%obj.inv[SRifleSGAmmo] == 0)
      %obj.unmountImage(%slot);
}

function SRifleGLImage::onFire(%data,%obj,%slot) {
   %p = Parent::onFire(%data, %obj, %slot);
   if (%obj.inv[SRifleGLAmmo] == 0)
      %obj.unmountImage(%slot);
}

function SRifleCheckforclip(%obj)
{
   if (%obj.inv[MGClip] > 0)
   {
      %obj.unmountImage(6);
	%obj.clipReloading = true;
      %obj.SRifleClipAdd = schedule(2000, 0, "SRifleReloadClip", %obj);
   }
}

function SRifleReloadClip(%obj) 
{ 
   %obj.clipReloading = false;
   %obj.decInventory(MGClip, 1);
   %obj.mountImage(SRifleClipImage, 6);
   %obj.setInventory(SRifleAmmo, 30);
} 

function SRifleBullet::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal)
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

function RiflelowerSpread(%data, %obj){
   %obj.spread = %obj.spread - (4 / 10000);
   if(%obj.spread < 0){
	%obj.spread = 0;
	%obj.lowSpreadLoop = "";
	return;
   }
   %obj.lowSpreadLoop = schedule(120, 0, "RiflelowerSpread", %data, %obj);
}
