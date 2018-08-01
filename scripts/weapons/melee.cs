//--------------------------------------
// Default blaster
//--------------------------------------

datablock AudioProfile(BOVHitSound) {
   filename    = "fx/misc/flag_snatch.wav";
   description = AudioClose3d;
   preload = true;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock TracerProjectileData(meleehit)
{
   doDynamicClientHits = true;

   directDamage        = 0.45;
   directDamageType    = $DamageType::melee;
   explosion           = ChaingunExplosion;
   splash              = ChaingunSplash;
   HeadMultiplier = 5.0;

   hasDamageRadius     = true;
   indirectDamage      = 0.001;
   damageRadius        = 0.1;
   radiusDamageType    = $DamageType::melee;

   kickBackStrength  = 1500;
   sound             = ChaingunProjectile;

   dryVelocity       = 50.0; // z0dd - ZOD, 8-12-02. Was 425.0
   wetVelocity       = 50.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 6;
   lifetimeMS        = 60;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 0.1;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.01;
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
datablock ShapeBaseImageData(MeleeImage)
{
   className = WeaponImage;
   shapeFile = "turret_muzzlepoint.dts";
   item = melee;
   projectile = meleehit;
   projectileType = TracerProjectile;

   usesEnergy = true;
   fireEnergy = 20;
   minEnergy = 30;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 1.0;
   stateSequence[0] = "Activate";
   stateSound[0] = BlasterSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.5;
   stateFire[3] = true;
   stateRecoil[3] = NoRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateScript[3] = "onFire";

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";
   
   stateName[6] = "DryFire";
   stateTimeoutValue[6] = 1.0;
   stateSound[6] = BlasterDryFireSound;
   stateTransitionOnTimeout[6] = "Ready";
};

datablock ItemData(melee)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_energy.dts";
   image = meleeImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a gun butt";
};

datablock ShapeBaseImageData(MeleeButt) 
{ 
   shapeFile = "weapon_targeting.dts"; 
   mountPoint = 1; 

   offset = "0.0 0.8 0.55"; // L/R - F/B - T/B
   rotation = "2.0 -2.0 3.0 45"; // L/R - F/B - T/B
}; 

datablock ShapeBaseImageData(MeleeButtSwing) 
{ 
   shapeFile = "weapon_targeting.dts"; 
   mountPoint = 1; 

   offset = "0.0 1.45 -0.4"; // L/R - F/B - T/B
   rotation = "0 0 1 180"; // L/R - F/B - T/B
};

datablock ShapeBaseImageData(SOButt)
{
   shapeFile = "disc.dts";
   mountPoint = 1;

   offset = "0.0 0.8 0.55"; // L/R - F/B - T/B
   rotation = "2.0 -2.0 3.0 45"; // L/R - F/B - T/B
};

datablock ShapeBaseImageData(BOVButt)
{
   shapeFile = "weapon_grenade_launcher.dts";
   mountPoint = 1;

   offset = "0.0 0.8 0.55"; // L/R - F/B - T/B
   rotation = "2.0 -2.0 3.0 45"; // L/R - F/B - T/B
};

function MeleeImage::onMount(%data, %obj, %node)
{
   %obj.mountImage(MeleeButt, 5);
}

function MeleeImage::onUnMount(%data, %obj, %node)
{
   %obj.unmountImage(5);
}

function MeleeImage::onFire(%data, %obj, %node)
{
   %obj.unmountImage(5);
   %obj.mountImage(MeleeButtSwing, 6);
   %obj.backswing = schedule(300, 0, "swingback", %obj, 1);

   %p = new (TracerProjectile)() { 
	dataBlock = meleehit; 
	initialDirection = %obj.getMuzzleVector(%slot); 
	initialPosition = %obj.getMuzzlePoint(%slot); 
	sourceObject = %obj; 
	sourceSlot = %slot; 
	vehicleObject = %vehicle; 
   };
   MissionCleanup.add(%p); 
}

function swingback(%obj, %type)
{ 
   %obj.unmountImage(6);
   if(%type == 1)
   %obj.mountImage(MeleeButt, 5);
   else if(%type == 2)
   %obj.mountImage(SOButt, 5);
   else if(%type == 3)
   %obj.mountImage(BOVButt, 5);
} 

function meleehit::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal)
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
	   else
	   {
		%modifier = 1;
		%targetObject.getOwnerClient().headShot = 0;
	   }
	}

    %targetObject.damage(%projectile.sourceObject, %position, %modifier * %data.directDamage, %data.directDamageType);
}

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock TracerProjectileData(SOmeleehit)
{
   doDynamicClientHits = true;

   directDamage        = 0.7;
   directDamageType    = $DamageType::melee;
   explosion           = ChaingunExplosion;
   splash              = ChaingunSplash;
   HeadMultiplier = 5.0;

   hasDamageRadius     = true;
   indirectDamage      = 0.001;
   damageRadius        = 0.1;
   radiusDamageType    = $DamageType::melee;

   kickBackStrength  = 1500;
   sound             = ChaingunProjectile;

   dryVelocity       = 50.0; // z0dd - ZOD, 8-12-02. Was 425.0
   wetVelocity       = 50.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 6;
   lifetimeMS        = 60;  //shorter range
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 0.1;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.01;
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
datablock ShapeBaseImageData(SOMeleeImage)
{
   className = WeaponImage;
   shapeFile = "turret_muzzlepoint.dts";
   item = SOmelee;
   projectile = SOmeleehit;
   projectileType = TracerProjectile;

   usesEnergy = true;
   fireEnergy = 20;
   minEnergy = 30;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 1.0;
   stateSequence[0] = "Activate";
   stateSound[0] = BlasterSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.5;
   stateFire[3] = true;
   stateRecoil[3] = NoRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateScript[3] = "onFire";

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";
   
   stateName[6] = "DryFire";
   stateTimeoutValue[6] = 1.0;
   stateSound[6] = BlasterDryFireSound;
   stateTransitionOnTimeout[6] = "Ready";
};

datablock ItemData(SOmelee)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_energy.dts";
   image = SOMeleeImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a combat knife";
};

datablock ShapeBaseImageData(CKnifeSwing)
{
   shapeFile = "disc.dts";
   mountPoint = 1;

   offset = "0.0 1.45 -0.4"; // L/R - F/B - T/B
   rotation = "0 0 1 45"; // L/R - F/B - T/B
};

function SOMeleeImage::onMount(%data, %obj, %node)
{
   %obj.meleeIMG = %obj.mountImage(SOButt, 5);
}

function SOMeleeImage::onUnMount(%data, %obj, %node)
{
   %obj.unmountImage(5);
}

function SOMeleeImage::onFire(%data, %obj, %node)
{
   %obj.unmountImage(5);
   %obj.meleeIMG = %obj.mountImage(CKnifeSwing, 6);
   %obj.backswing = schedule(300, 0, "swingback", %obj, 2);

   %p = new (TracerProjectile)() { 
	dataBlock = SOmeleehit; 
	initialDirection = %obj.getMuzzleVector(%slot); 
	initialPosition = %obj.getMuzzlePoint(%slot); 
	sourceObject = %obj; 
	sourceSlot = %slot; 
	vehicleObject = %vehicle; 
   };
   MissionCleanup.add(%p); 
}

function SOmeleehit::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal)
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
	   else
	   {
		%modifier = 1;
		%targetObject.getOwnerClient().headShot = 0;
	   }
	}

    %targetObject.damage(%projectile.sourceObject, %position, %modifier * %data.directDamage, %data.directDamageType);
}

//BLADE OF VENGANCE (BOV)
//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock TracerProjectileData(BOVhit)
{
   doDynamicClientHits = true;

   directDamage        = 100.0; //OW?
   directDamageType    = $DamageType::admin; //already has a DM (See below)
   explosion           = ChaingunExplosion;
   splash              = ChaingunSplash;
   HeadMultiplier = 5.0;

   hasDamageRadius     = true;
   indirectDamage      = 0.001;
   damageRadius        = 0.1;
   radiusDamageType    = $DamageType::admin;

   kickBackStrength  = 1500;
   sound             = ChaingunProjectile;

   dryVelocity       = 50.0; // z0dd - ZOD, 8-12-02. Was 425.0
   wetVelocity       = 50.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 6;
   lifetimeMS        = 60;  //shorter range
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 0.1;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.01;
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
datablock ShapeBaseImageData(BOVImage)
{
   className = WeaponImage;
   shapeFile = "turret_muzzlepoint.dts";
   item = BOV;
   projectile = BOVhit;
   projectileType = TracerProjectile;

   usesEnergy = true;
   fireEnergy = 20;
   minEnergy = 30;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 1.0;
   stateSequence[0] = "Activate";
   stateSound[0] = BlasterSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.5;
   stateFire[3] = true;
   stateRecoil[3] = NoRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateScript[3] = "onFire";

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateTimeoutValue[6] = 1.0;
   stateSound[6] = BlasterDryFireSound;
   stateTransitionOnTimeout[6] = "Ready";
};

datablock ItemData(BOV)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_energy.dts";
   image = BOVImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a blade of vengance";
};

function BOVImage::onMount(%data, %obj, %node)
{
   %obj.meleeIMG = %obj.mountImage(BOVButt, 5);
}

function BOVImage::onUnMount(%data, %obj, %node)
{
   %obj.unmountImage(5);
}

datablock ShapeBaseImageData(BoVSwing)
{
   shapeFile = "weapon_grenade_launcher.dts";
   mountPoint = 1;

   offset = "0.0 1.45 -0.4"; // L/R - F/B - T/B
   rotation = "0 0 1 180"; // L/R - F/B - T/B
};

function BOVImage::onFire(%data, %obj, %node) {
   //dumbass use
   //Person without the medal
   if(!$Medals::RAAMKiller[%obj.client.GUID] && !%obj.client.isAiControlled()) {
      messageClient(%obj.client, 'MsgClient', "\c3You must aquire the 'RAAM Killer' Medal to use this.");
      messageall('MsgDummy', "\c0In an effort to use the blade of vengance, "@ %obj.client.namebase@" stabbed himself!");
      %obj.scriptKill($DamageType::Admin);
      return;
   }
   if(%obj.cannotuseBOV) {  //in the kill anim?
      return;
   }
   //
   %obj.unmountImage(5);
   %obj.meleeIMG = %obj.mountImage(BoVSwing, 6);
   %obj.backswing = schedule(300, 0, "swingback", %obj, 3);

   %p = new (TracerProjectile)() {
	dataBlock = BOVhit;
	initialDirection = %obj.getMuzzleVector(%slot);
	initialPosition = %obj.getMuzzlePoint(%slot);
	sourceObject = %obj;
	sourceSlot = %slot;
	vehicleObject = %vehicle;
   };
   MissionCleanup.add(%p);
}

function BOVhit::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal) {
    %source = %projectile.SourceObject;
    %hitObj = %targetObject;
    
    %muzzlePos = %source.getMuzzlePoint(0);
    %muzzleVec = %source.getMuzzleVector(0);
    
	// extra damage for head shot or less for close range shots
	if(!(%hitObj.getType() & ($TypeMasks::InteriorObjectType | $TypeMasks::TerrainObjectType)) &&
        (%hitObj.getDataBlock().getClassName() $= "PlayerData")) {

         if(%hitObj.getDataBlock().getClassName() $= "PlayerData") {
            // Now we see if we hit from behind...
            %forwardVec = %hitobj.getForwardVector();
            %objDir2D   = getWord(%forwardVec, 0) @ " " @ getWord(%forwardVec,1) @ " " @ "0.0";
            %objPos     = %hitObj.getPosition();
            %dif        = VectorSub(%objPos, %muzzlePos);
            %dif        = getWord(%dif, 0) @ " " @ getWord(%dif, 1) @ " 0";
            %dif        = VectorNormalize(%dif);
            %dot        = VectorDot(%dif, %objDir2D);

            // 120 Deg angle test...
            // 1.05 == 60 degrees in radians
            if (%dot >= mCos(1.05)) {
               // Rear hit
               %source.applyRepair("0.45"); //we get a bonus repair for rear
               if(%source.team == %hitObj.team && !$TeamDamage) {
                  ServerPlay3d(BOVHitSound, %targetObject.getPosition());
                  return; //stops shredding
               }
               %source.cannotuseBOV = 1;
               DoBOVRearKill(%source, %hitObj, 0);
               return;
            }
         }

    ServerPlay3d(BOVHitSound, %targetObject.getPosition());
    //The Blade Only Works On Players
    %targetObject.damage(%projectile.sourceObject, %position, %data.directDamage, %data.directDamageType);
       if(isObject(%source) || %source.getState() !$= "dead") {
       %source.applyRepair("0.15"); //15%
       }
       if(%targetObject.client !$= "") { //a Player.. goodie
          if(%targetObject.getState() $= "dead") {
             MessageAll('MessageAll', "\c0"@%targetObject.client.namebase@" was stabbed by "@%source.client.namebase@"'s Sword.");
          }
       }
   }
}

function DoBOVRearKill(%source, %target, %count) {
   %count++;
   if(!isObject(%source) || %source.getState() $= "dead") {
      %target.setMoveState(false);
      return;
   }
   %source.setMoveState(true);
   %target.setMoveState(true);
   %target.clearInventory(); //ha, no guns for You!
   //lift
   if(%count <= 15) {
      %ZPos = %count * 0.025;
	  %newpos = vectoradd(%target.getPosition(),"0 0 "@%ZPos@"");
	  %target.setTransform(%newpos);
	  %target.setvelocity("0 0 0");
   }
   else if(%count == 16) {
      MessageAll('MsgDIE', "\c4"@%source.client.namebase@": You're so.... weak...");
	  %newpos = vectoradd(%target.getPosition(),"0 0 "@%ZPos * -1@"");
	  %target.setTransform(%newpos);
	  %target.setvelocity("0 0 0");
   }
   else if(%count == 17) {
      %target.blowup();//BAM!
      ServerPlay3d(BOVHitSound, %target.getPosition());
      ServerPlay3d(BOVHitSound, %target.getPosition());
      ServerPlay3d(BOVHitSound, %target.getPosition());
      %target.damage(%source, %target.getposition(), 9999, $DamageType::BladeOfVengance);
      if(%target.client !$= "") { //a Player.. goodie
         MessageAll('MessageAll', "\c0"@%target.client.namebase@" was stabbed by "@%source.client.namebase@"'s Sword.");
      }
      %source.cannotuseBOV = 0;
      %source.setMoveState(false);
      return;
   }
   schedule(100,0,"DoBOVRearKill", %source, %target, %count);
}
