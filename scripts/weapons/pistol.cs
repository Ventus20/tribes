//--------------------------------------
// Pistol
//--------------------------------------

datablock AudioProfile(PistolFireSound)
{
   filename    = "fx/vehicles/tank_chaingun.wav";
   description = AudioDefault3d;
   preload = true;
   effect = AssaultChaingunFireEffect;
};

datablock AudioProfile(DeagleFireSound)
{
   filename    = "fx/weapons/cg_metal1.wav";
   description = AudioDefault3d;
   preload = true;
   effect = AssaultChaingunFireEffect;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------------------------------------------

datablock TracerProjectileData(coltBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.2; // z0dd - ZOD, 9-27-02. Was 0.0825
   directDamageType    = $DamageType::pistol;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;
   HeadMultiplier      = 1.5;
   LegsMultiplier      = 0.5;

   kickBackStrength  = 5.0;
   sound 				= ChaingunProjectile;

   //dryVelocity       = 425.0;
   dryVelocity       = 2000.0; // z0dd - ZOD, 8-12-02. Was 425.0
   wetVelocity       = 1750.0;
   velInheritFactor  = 0.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
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

datablock TracerProjectileData(DeagleBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.6; // z0dd - ZOD, 9-27-02. Was 0.0825
   directDamageType    = $DamageType::deserteagle;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;

   kickBackStrength  = 5.0;
   sound 				= ChaingunProjectile;

   //dryVelocity       = 425.0;
   dryVelocity       = 2000.0; // z0dd - ZOD, 8-12-02. Was 425.0
   wetVelocity       = 1750.0;
   velInheritFactor  = 0.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
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
// Weapon
//--------------------------------------
datablock ItemData(pistol)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_energy_vehicle.dts";
   image = pistolImage;
   mass = 2;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a USP-45";
};

datablock ShapeBaseImageData(PistolImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item = pistol;
   offset = "0 0 0";
   rotation = "0 1 0 180";
   mass = 4;

   usesEnergy = true;
   fireEnergy = 4;
   minEnergy = 4;

   projectile = coltbullet;
   projectileType = tracerProjectile;
   projectileSpread = 1.0 / 1000.0;
   maxSpread = 10 / 1000.0;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = PlasmaSwitchSound;

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
   stateEmitter[3] = "GunFireEffectEmitter";
   stateEmitterNode[3] = "muzzlepoint1";
   stateEmitterTime[3] = 1; 
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = PistolFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.1;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = ChaingunDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

function PistolImage::onMount(%this,%obj,%slot)
{
   Parent::onMount(%this, %obj, %slot);
}

function PistolImage::onFire(%data,%obj,%slot) 
{ 
   if(%obj.spread $= "" || %obj.spread < %data.projectileSpread)
	%obj.spread = %data.projectileSpread;
   else
      %obj.spread = %obj.spread + (2.5 / 1000);

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
}

datablock ItemData(SPistol)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_energy_vehicle.dts";
   image = SPistolImage;
   mass = 2;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a silenced USP-45";
};

datablock ShapeBaseImageData(SPistolImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item = SPistol;
   offset = "0 0 0";
   rotation = "0 1 0 180";
   mass = 6;

   RankReqName = "Silenced USP-45"; //Called By TWMFuncitons.cs & Weapons.cs
   projectile = coltbullet;
   projectileType = tracerProjectile;
   projectileSpread = 0;
   maxSpread = 7 / 1000.0;
   
   usesEnergy = true;
   fireEnergy = 4;
   minEnergy = 4;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = PlasmaSwitchSound;

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
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.1;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = ChaingunDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

function SPistolImage::onMount(%this,%obj,%slot)
{
   Parent::onMount(%this, %obj, %slot);
}

function SPistolImage::onFire(%data,%obj,%slot) {
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
}

datablock ShapeBaseImageData(DeagleImage2)
{
   className = WeaponImage;
   shapeFile = "weapon_sniper.dts";
   offset = "0 0 0"; 	// L/R - F/B - T/B
   rotation = "0 0 0 0"; 		// L/R - F/B - T/B
   emap = true;
};

datablock ItemData(Deagle)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_energy_vehicle.dts";
   image = DeagleImage;
   mass = 2;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a Desert Eagle";
};

datablock ShapeBaseImageData(DeagleImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item = Deagle;
   offset = "0 0 0";
   rotation = "0 1 0 180";
   mass = 6;

   usesEnergy = true;
   fireEnergy = 4;
   minEnergy = 4;

   RankReqName = "Desert Eagle"; //Called By TWMFuncitons.cs & Weapons.cs
   projectile = DeagleBullet;
   projectileType = tracerProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = PlasmaSwitchSound;

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
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;
   stateSound[3] =DeagleFireSound;

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
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

function DeagleImage::onMount(%this,%obj,%slot)
{
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(DeagleImage2, 5);
}

function DeagleImage::onUnmount(%this,%obj,%slot)
{
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(5);
}

function DeagleImage::onFire(%data,%obj,%slot) {
   %p = Parent::onFire(%data,%obj,%slot);
}

function ColtBullet::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal)
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




//CENTAUR DUAL
datablock ItemData(Dualpistol)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_energy_vehicle.dts";
   image = DualpistolImage;
   mass = 2;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "Centaur Dual Pistols";
};

datablock ShapeBaseImageData(DualPistolImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item = Dualpistol;
   RankReqName = "Centaur Dual Pistols"; //Called By TWMFuncitons.cs & Weapons.cs
   offset = "0 0 0";
   rotation = "0 1 0 180";
   mass = 4;

   usesEnergy = true;
   fireEnergy = 4;
   minEnergy = 4;

   projectile = coltbullet;
   projectileType = tracerProjectile;
   projectileSpread = 1.0 / 1000.0;
   maxSpread = 10 / 1000.0;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = PlasmaSwitchSound;

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
   stateEmitter[3] = "GunFireEffectEmitter";
   stateEmitterNode[3] = "muzzlepoint1";
   stateEmitterTime[3] = 1;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = PistolFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.1;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = ChaingunDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

datablock ShapeBaseImageData(DualPistolImage2) : DualPistolImage {
   offset = "-0.5 0 0";

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = PlasmaSwitchSound;

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
   stateEmitter[3] = "GunFireEffectEmitter";
   stateEmitterNode[3] = "muzzlepoint1";
   stateEmitterTime[3] = 1;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = PistolFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.1;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = ChaingunDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

function DualPistolImage::onMount(%this,%obj,%slot) {
   %obj.mountImage(DualPistolImage2, 5);
   Parent::onMount(%this, %obj, %slot);
}

function DualPistolImage::onUnMount(%this,%obj,%slot) {
   %obj.unmountImage(5);
   Parent::onUnMount(%this, %obj, %slot);
}

function DualPistolImage::onFire(%data, %obj, %slot) {
   FirePistolShot(%data, %obj, %slot);
   schedule(200,0,"FirePistolShot", %data, %obj, 5);
}

function FirePistolShot(%data, %obj, %slot) {
   serverPlay3d("PistolFireSound", %obj.getPosition());
   if(%obj.spread $= "" || %obj.spread < %data.projectileSpread)
	  %obj.spread = %data.projectileSpread;
   else
      %obj.spread = %obj.spread + (2.5 / 1000);

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

      %p = new (%data.projectileType)() {
            dataBlock        = %data.projectile;
            initialDirection = %newvector;
            initialPosition  = %mp;
            sourceObject     = %obj;
		    damageFactor	 = 1;
            sourceSlot       = %slot;
      };
}
