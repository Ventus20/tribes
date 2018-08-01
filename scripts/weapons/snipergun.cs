//--------------------------------------
// RPChaingun
//--------------------------------------             

datablock AudioProfile(SniperFireSound)
{
   filename    = "fx/vehicles/tank_mortar_fire.wav";
   description = AudioDefault3d;
   preload = true;
   effect = AssaultChaingunFireEffect;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock TracerProjectileData(snipergunBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.6; // z0dd - ZOD, 9-27-02. Was 0.0825
   directDamageType    = $DamageType::Sniper;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;
   closeRangeMultiplier  = 0.5;

   kickBackStrength  = 50.0;
   sound 				= ChaingunProjectile;

   //dryVelocity       = 425.0;
   dryVelocity       = 5000.0; // z0dd - ZOD, 8-12-02. Was 425.0
   wetVelocity       = 4500.0;
   velInheritFactor  = 0.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 30.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.10;
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

datablock ItemData(snipergunAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some sniperrifle ammo";

   computeCRC = true;

};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ShapeBaseImageData(snipergunImage)
{
   className = WeaponImage;
   shapeFile = "weapon_sniper.dts";
   item      = snipergun;
   ammo 	 = snipergunAmmo;
   projectile = snipergunBullet;
   projectileType = TracerProjectile;
   emap = true;
	armThread = looksn;
   mass = 10;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   RankReqName = "Sniper Rifle"; //Called By TWMFuncitons.cs & Weapons.cs
   maxSpread = 10.0 / 1000.0;

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
   stateTimeoutValue[4] = 2.0;
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

datablock ItemData(snipergun)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_chaingun.dts";
   image        = snipergunImage;
   mass         = 1.0;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "a snipergun";

   computeCRC = true;
   emap = true;
};

function snipergunBullet::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal)
{
	// extra damage for head shot or less for close range shots
	if(!(%targetObject.getType() & ($TypeMasks::InteriorObjectType | $TypeMasks::TerrainObjectType)) &&
        (%targetObject.getDataBlock().getClassName() $= "PlayerData"))
	{
	   %damLoc = firstWord(%targetObject.getDamageLocation(%position));
	   %dist = vectorDist(%position, %projectile.sourceObject.getPosition());
	   if(%damLoc $= "head")
	   {
		%targetObject.getOwnerClient().headShot = 1;
        if(%targetObject.getDatablock().getName() $= "RAAMZombieArmor" || %targetObject.isGOF) {
		%modifier *= 1.2;
        }
        else {
        bottomPrint(%projectile.sourceObject.client, ">>> :D HEADSHOT :D <<<", 3);
        if(%targetObject.client !$= "") {
        bottomPrint(%targetObject.client, ">>> D: You Lost Your Head D: <<<", 3);
        }
		%modifier *= 100.0;
        }
	   }
	   else if(%damLoc $= "legs")
	   {
		%modifier *= 0.2;
	   }
	   else if (%dist <= 125)
 	   {
		%modifier *= %data.closeRangeMultiplier;
	   }
	   else
	   {
		%modifier = 1;
		%targetObject.getOwnerClient().headShot = 0;
	   }
	}

    %targetObject.damage(%projectile.sourceObject, %position, %modifier * %data.directDamage, %data.directDamageType);
}

function snipergunImage::onFire(%data, %obj, %slot){
   %vector = %obj.getMuzzleVector(%slot);
   %mp = %obj.getMuzzlePoint(%slot);
   if(!$Host::SniperRifles) {
      commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Sniper Weapons Are Disabled<spop>", 5, 2);
      return;
   }
   //Upgraded
   if(%obj.client.Psniper) {
      %p = new (LinearFlareProjectile)() {
          dataBlock        = SniperShot;
          initialDirection = %vector;
          initialPosition  = %mp;
          sourceObject     = %obj;
          damageFactor	 = 1;
          sourceSlot       = %slot;
      };
      MissionCleanup.add(%p);
      %obj.decInventory(%data.ammo,1);
   }
   else {
      %p = Parent::onFire(%data, %obj, %slot);
   }
}


 // LASER RIFLE
 datablock EffectProfile(LaserRifleFireEffect)
{
   effectname = "weapons/laser_fire";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock AudioProfile(LaserRifleFireSound)
{
   filename    = "fx/weapons/sniper_fire.wav";
   description = AudioClose3d;
   preload = true;
   effect = LaserRifleFireEffect;
};

datablock ParticleData(RedFlareParticle)
{
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = 0.15;
   inheritedVelFactor   = 0.5;

   lifetimeMS           = 1800;
   lifetimeVarianceMS   = 200;

   textureName          = "special/flareSpark";

   colors[0]     = "1.0 1.0 1.0 1.0";
   colors[1]     = "1.0 1.0 1.0 1.0";
   colors[2]     = "1.0 1.0 1.0 0.0";

   sizes[0]      = 0.6;
   sizes[1]      = 0.3;
   sizes[2]      = 0.1;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(RedFlareemmiter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;

   ejectionVelocity = 1.0;
   velocityVariance = 0.0;

   thetaMin         = 0.0;
   thetaMax         = 90.0;

   orientParticles  = true;
   orientOnVelocity = false;

   particles = "RedFlareParticle";
};

datablock LinearFlareProjectileData(LaserShot)
{
   scale               = "1.0 1.0 1.0";
   faceViewer          = false;
   directDamage        = 1.6;
   kickBackStrength    = 100.0;
   directDamageType    = $DamageType::LaserRifle;

   explosion           = "BlasterExplosion";
   splash              = PlasmaSplash;

   dryVelocity       = 200.0;
   wetVelocity       = 10;
   velInheritFactor  = 0.5;
   fizzleTimeMS      = 30000;
   lifetimeMS        = 30000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   baseEmitter         = RedFlareemmiter;
   delayEmitter        = RedFlareemmiter;
   bubbleEmitter       = RedFlareemmiter;

   //activateDelayMS = 100;
   activateDelayMS = -1;

   size[0]           = 0.2;
   size[1]           = 0.2;
   size[2]           = 0.2;


   numFlares         = 15;
   flareColor        = "1 0 0";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   sound        = MissileProjectileSound;
   fireSound    = PlasmaFireSound;
   wetFireSound = PlasmaFireWetSound;

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "1 0 0";

};

//--------------------------------------------------------------------------
// Ammo
//--------------------------------------

datablock ItemData(lasergunAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some laser rifle ammo";

   computeCRC = true;

};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ShapeBaseImageData(lasergunImage)
{
   className = WeaponImage;
   shapeFile = "weapon_sniper.dts";
   item      = lasergun;
   ammo 	 = lasergunAmmo;
   projectile = LaserShot;
   projectileType = LinearFlareProjectile;
   emap = true;
	armThread = looksn;
   mass = 10;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   RankReqName = "RSA Laser Rifle"; //Called By TWMFuncitons.cs & Weapons.cs
   maxSpread = 10.0 / 1000.0;

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
   stateEmitter[3] = "GunFireEffectEmitter";
   stateEmitterNode[3] = "muzzlepoint1";
   stateEmitterTime[3] = 1;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.1;
   stateSound[3] = LaserRifleFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.7;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = ChaingunDryFireSound;
   stateTimeoutValue[6]        = 0.2;
   stateTransitionOnTimeout[6] = "NoAmmo";

   stateName[7]       = "WetFire";
   stateSound[7]      = ChaingunDryFireSound;
   stateTimeoutValue[7]        = 0.2;
   stateTransitionOnTimeout[7] = "Ready";

   stateName[8]               = "CheckWet";
   stateTransitionOnWet[8]    = "WetFire";
   stateTransitionOnNotWet[8] = "Fire";
};

datablock ItemData(lasergun)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_chaingun.dts";
   image        = lasergunImage;
   mass         = 1.0;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "a Laser Rifle";

   computeCRC = true;
   emap = true;
};

function lasergunImage::onFire(%data, %obj, %slot){
   %data.lightStart = getSimTime();

   %spd = vectorLen(%obj.getVelocity());
   %spread = %data.maxSpread * (%spd / %obj.getDatablock().maxForwardSpeed);
   if(%spread > %data.maxspread)
	%spread = %data.maxspread;
   %vec = %obj.getMuzzleVector(%slot);
   %x = (getRandom() - 0.5) * 2 * 3.1415926 * %spread;
   %y = (getRandom() - 0.5) * 2 * 3.1415926 * %spread;
   %z = (getRandom() - 0.5) * 2 * 3.1415926 * %spread;
   %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
   %vector = MatrixMulVector(%mat, %vec);
   %initialPos = %obj.getMuzzlePoint(%slot);

   %p = Parent::onFire(%data, %obj, %slot);

   %obj.lastProjectile = %p;
   %obj.deleteLastProjectile = %data.deleteLastProjectile;
   MissionCleanup.add(%p);

   if(%obj.client)
      %obj.client.projectile = %p;
   //%obj.decInventory(%data.ammo,1);
}

//ALSWP
datablock TracerProjectileData(ALSWPBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.3; // z0dd - ZOD, 9-27-02. Was 0.0825
   directDamageType    = $DamageType::ALSWP;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;
   closeRangeMultiplier  = 0.5;

   kickBackStrength  = 50.0;
   sound 				= ChaingunProjectile;

   //dryVelocity       = 425.0;
   dryVelocity       = 5000.0; // z0dd - ZOD, 8-12-02. Was 425.0
   wetVelocity       = 4500.0;
   velInheritFactor  = 0.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 30.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.10;
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

datablock ItemData(ALSWPAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some sniperrifle ammo";

   computeCRC = true;

};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ShapeBaseImageData(ALSWPImage)
{
   className = WeaponImage;
   shapeFile = "weapon_sniper.dts";
   item      = ALSWP;
   ammo 	 = ALSWPAmmo;
   projectile = ALSWPBullet;
   projectileType = TracerProjectile;
   emap = true;
	armThread = looksn;
   mass = 10;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   RankReqName = "ALSWP"; //Called By TWMFuncitons.cs & Weapons.cs
   maxSpread = 10.0 / 1000.0;

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
   stateTimeoutValue[4] = 0.5;
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

datablock ItemData(ALSWP)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_chaingun.dts";
   image        = ALSWPImage;
   mass         = 1.0;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "a ALSWP Rapid Sniper";

   computeCRC = true;
   emap = true;
};

function ALSWPBullet::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal)
{
	// extra damage for head shot or less for close range shots
	if(!(%targetObject.getType() & ($TypeMasks::InteriorObjectType | $TypeMasks::TerrainObjectType)) &&
        (%targetObject.getDataBlock().getClassName() $= "PlayerData"))
	{
	   %damLoc = firstWord(%targetObject.getDamageLocation(%position));
	   %dist = vectorDist(%position, %projectile.sourceObject.getPosition());
	   if(%damLoc $= "head")
	   {
		%targetObject.getOwnerClient().headShot = 1;
        bottomPrint(%projectile.sourceObject.client, ">>> :D HEADSHOT :D <<<", 3);
        if(%targetObject.client !$= "") {
        bottomPrint(%targetObject.client, ">>> D: You Lost Your Head D: <<<", 3);
        }
        if(%targetObject.getDatablock().getName() $= "RAAMZombieArmor" || %targetObject.isGOF) {
		%modifier *= 1.2;
        }
        else {
		%modifier *= 100.0;
        }
        }
	   }
	   else if(%damLoc $= "legs")
	   {
		%modifier *= 0.2;
	   }
	   else if (%dist <= 125)
 	   {
		%modifier *= %data.closeRangeMultiplier;
	   }
	   else
	   {
		%modifier = 1;
		%targetObject.getOwnerClient().headShot = 0;
	   }
    %targetObject.damage(%projectile.sourceObject, %position, %modifier * %data.directDamage, %data.directDamageType);
}

function ALSWPImage::onFire(%data, %obj, %slot){
   %vector = %obj.getMuzzleVector(%slot);
   %mp = %obj.getMuzzlePoint(%slot);
   if(!$Host::SniperRifles) {
      commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Sniper Weapons Are Disabled<spop>", 5, 2);
      return;
   }
   else {
      %p = Parent::onFire(%data, %obj, %slot);
   }
}
