//**************************************************************
// SHRIKE SCOUT FLIER
//**************************************************************

datablock SensorData(combatSensor)
{
   detects = true;
   detectsUsingLOS = true;
   detectsPassiveJammed = false;
   detectsActiveJammed = false;
   detectsCloaked = false;
   detectionPings = true;
   detectRadius = 500;
};

//**************************************************************
// SOUNDS
//**************************************************************
datablock EffectProfile(F56HornetThrustEffect)
{
   effectname = "vehicles/shrike_boost";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(F56HornetEngineEffect)
{
   effectname = "vehicles/shrike_engine";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(ShrikeBlasterFireEffect)
{
   effectname = "vehicles/shrike_blaster";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock AudioProfile(F56HornetThrustSound)
{
   filename    = "fx/vehicles/shrike_boost.wav";
   description = AudioDefaultLooping3d;
   preload = true;
   effect = F56HornetThrustEffect;
};

datablock AudioProfile(F56HornetEngineSound)
{
   filename    = "fx/vehicles/shrike_engine.wav";
   description = AudioDefaultLooping3d;
   preload = true;
};

datablock AudioProfile(ShrikeBlasterFire)
{
   filename    = "fx/vehicles/tank_chaingun.wav";
   description = AudioDefault3d;
   preload = true;
   effect = F56HornetEngineEffect;
};

datablock AudioProfile(ShrikeBlasterProjectile)
{
   filename    = "fx/weapons/shrike_blaster_projectile.wav";
   description = ProjectileLooping3d;
   preload = true;
   effect = ShrikeBlasterFireEffect;
};

datablock AudioProfile(ShrikeBlasterDryFireSound)
{
   filename    = "fx/weapons/chaingun_dryfire.wav";
   description = AudioClose3d;
   preload = true;
};

//**************************************************************
// LIGHTS
//**************************************************************
datablock RunningLightData(ShrikeLight1)
{
   type        = 1;
   radius      = 2.0;
   length      = 3.0;
   color       = "1.0  1.0  1.0  1.0";
   direction   = "0.0  1.0 -1.0 ";
   offset      = "0.0  0.0 -0.5";
   texture     = "special/lightcone04";
};

datablock RunningLightData(ShrikeLight2)
{
   radius = 1.5;
   color = "1.0 1.0 1.0 0.3";
   direction = "0.0 0.0 -1.0";
   offset      = "0.0  0.8 -1.2";
   texture = "special/headlight4";
};

//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock FlyingVehicleData(F56Hornet) : ShrikeDamageProfile
{
   spawnOffset = "0 0 2";
   canControl = false;
   catagory = "Vehicles";
   shapeFile = "vehicle_air_scout.dts";
   multipassenger = false;
   computeCRC = true;

   debrisShapeName = "vehicle_air_scout.dts";
   debris = MeShapeDebris;
   renderWhenDestroyed = false;

   drag    = 0.15;
   density = 1.0;

   mountPose[0] = sitting;
   numMountPoints = 1;
   isProtectedMountPoint[0] = false;
   cameraMaxDist = 15;
   cameraOffset = 2.5;
   cameraLag = 0.9;
   explosion = MeVehicleExplosion;
	explosionDamage = 1.0;
	explosionRadius = 10.0;

   maxDamage = 2.5;
   destroyedLevel = 2.5;

   HDAddMassLevel = 1.9;
   HDMassImage = LflyerHDMassImage;

   isShielded = false;
   energyPerDamagePoint = 0;
   maxEnergy = 3000;      // Afterburner and any energy weapon pool
   rechargeRate = 20;

   minDrag = 30;           // Linear Drag (eventually slows you down when not thrusting...constant drag)
   rotationalDrag = 900;        // Anguler Drag (dampens the drift after you stop moving the mouse...also tumble drag)

   maxAutoSpeed = 5;       // Autostabilizer kicks in when less than this speed. (meters/second)
   autoAngularForce = 50;       // Angular stabilizer force (this force levels you out when autostabilizer kicks in)
   autoLinearForce = 300;        // Linear stabilzer force (this slows you down when autostabilizer kicks in)
   autoInputDamping = 0.95;      // Dampen control input so you don't` whack out at very slow speeds

   // Maneuvering
   maxSteeringAngle = 5;    // Max radiens you can rotate the wheel. Smaller number is more maneuverable.
   horizontalSurfaceForce = 6;   // Horizontal center "wing" (provides "bite" into the wind for climbing/diving and turning)
   verticalSurfaceForce = 8;     // Vertical center "wing" (controls side slip. lower numbers make MORE slide.)
   maneuveringForce = 3000;      // Horizontal jets (W,S,D,A key thrust)
   steeringForce = 1200;         // Steering jets (force applied when you move the mouse)
   steeringRollForce = 1600;      // Steering jets (how much you heel over when you turn)
   rollForce = 18;                // Auto-roll (self-correction to right you after you roll/invert)
   hoverHeight = 2;        // Height off the ground at rest
   createHoverHeight = 3;  // Height off the ground when created
   maxForwardSpeed = 400;  // speed in which forward thrust force is no longer applied (meters/second)

   // Turbo Jet
   jetForce = 3000;      // Afterburner thrust (this is in addition to normal thrust)
   minJetEnergy = 1;     // Afterburner can't be used if below this threshhold.
   jetEnergyDrain = 0;       // Energy use of the afterburners (low number is less drain...can be fractional)                                                                                                                                                                                                                                                                                          // Auto stabilize speed
   vertThrustMultiple = 3.0;

   // Rigid body
   mass = 150;        // Mass of the vehicle
   bodyFriction = 0;     // Don't mess with this.
   bodyRestitution = 0.5;   // When you hit the ground, how much you rebound. (between 0 and 1)
   minRollSpeed = 0;     // Don't mess with this.
   softImpactSpeed = 14;       // Sound hooks. This is the soft hit.
   hardImpactSpeed = 25;    // Sound hooks. This is the hard hit.

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 20;      // If hit ground at speed above this then it's an impact. Meters/second
   speedDamageScale = 0.06;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 23.0;
   collDamageMultiplier   = 0.02;

   //
   minTrailSpeed = 150;      // The speed your contrail shows up at.
   trailEmitter = ContrailEmitter;
   forwardJetEmitter = FlyerJetEmitter;
   downJetEmitter = FlyerJetEmitter;

   //
   jetSound = F56HornetThrustSound;
   engineSound = F56HornetEngineSound;
   softImpactSound = SoftImpactSound;
   hardImpactSound = HardImpactSound;
   //wheelImpactSound = WheelImpactSound;

   //
   softSplashSoundVelocity = 10.0;
   mediumSplashSoundVelocity = 15.0;
   hardSplashSoundVelocity = 20.0;
   exitSplashSoundVelocity = 10.0;

   exitingWater      = VehicleExitWaterMediumSound;
   impactWaterEasy   = VehicleImpactWaterSoftSound;
   impactWaterMedium = VehicleImpactWaterMediumSound;
   impactWaterHard   = VehicleImpactWaterMediumSound;
   waterWakeSound    = VehicleWakeMediumSplashSound;

   dustEmitter = VehicleLiftoffDustEmitter;
   triggerDustHeight = 4.0;
   dustHeight = 1.0;

   damageEmitter[0] = MeLightDamageSmoke;
   damageEmitter[1] = MeHeavyDamageSmoke;
   damageEmitter[2] = MeDamageBubbles;
   damageEmitterOffset[0] = "0.0 -3.0 0.0 ";
   damageLevelTolerance[0] = 0.4;
   damageLevelTolerance[1] = 0.75;
   numDmgEmitterAreas = 1;

   //
   max[chaingunAmmo] = 2000;
   max[MissileLauncherAmmo] = 50; //The Hornet is A missile Using Vehicle

   minMountDist = 7;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDFlyingScoutIcon;
   cmdMiniIconName = "commander/MiniIcons/com_scout_grey";
   targetNameTag = 'F-56';
   targetTypeTag = 'Hornet';
   sensorData = combatSensor;
   sensorRadius = combatSensor.detectRadius;
   sensorColor = "9 9 255";

   checkRadius = 5.5;
   observeParameters = "1 10 10";

   runningLight[0] = ShrikeLight1;
//   runningLight[1] = ShrikeLight2;

   shieldEffectScale = "0.937 1.125 0.60";

   numWeapons = 2;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock TracerProjectileData(HornetShreder)
{
   doDynamicClientHits = true;

   directDamage        = 1.4;
   directDamageType    = $DamageType::Shreder;
   explosion           = ChaingunExplosion;
   splash              = ChaingunSplash;

   hasDamageRadius     = true;
   indirectDamage      = 0.7;
   damageRadius        = 4.5;
   radiusDamageType    = $DamageType::ShrederScap;

   kickBackStrength  = 5;
   sound             = ChaingunProjectile;

   dryVelocity       = 1750.0;
   wetVelocity       = 1250.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 6000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 40.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.20;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = ChaingunDecal1;
   decalData[1] = ChaingunDecal2;
   decalData[2] = ChaingunDecal3;
   decalData[3] = ChaingunDecal4;
   decalData[4] = ChaingunDecal5;
   decalData[5] = ChaingunDecal6;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0.5 0.5 0.175";
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------
datablock SeekerProjectileData(HornetMissiles)
{
   casingShapeName     = "weapon_missile_casement.dts";
   projectileShapeName = "weapon_missile_projectile.dts";
   hasDamageRadius     = true;
   indirectDamage      = 0.5;
   damageRadius        = 6.0;
   radiusDamageType    = $DamageType::MissileTurret;
   kickBackStrength    = 500;

   flareDistance = 200;
   flareAngle    = 30;
   minSeekHeat   = 0.0;

   explosion           = "MissileExplosion";
   velInheritFactor    = 1.0;

   splash              = MissileSplash;
   baseEmitter         = MortarSmokeEmitter;
   delayEmitter        = MissileFireEmitter;
   puffEmitter         = MissilePuffEmitter;

   lifetimeMS          = 15000; // z0dd - ZOD, 4/14/02. Was 6000
   muzzleVelocity      = 12.0;
   maxVelocity         = 225.0; // z0dd - ZOD, 4/14/02. Was 80.0
   turningSpeed        = 50.0;
   acceleration        = 100.0;

   proximityRadius     = 4;

   terrainAvoidanceSpeed = 100;
   terrainScanAhead      = 50;
   terrainHeightFail     = 50;
   terrainAvoidanceRadius = 150;

   useFlechette = true;
   flechetteDelayMs = 225;
   casingDeb = FlechetteDebris;
};


//**************************************************************
// WEAPONS
//**************************************************************

datablock ShapeBaseImageData(F56HornetChaingunPairImage)
{
   className = WeaponImage;
   shapeFile = "turret_tank_barrelchain.dts";
   item      = Chaingun;
   ammo   = ChaingunAmmo;
   projectile = HornetShreder;
   projectileType = TracerProjectile;
   mountPoint = 10;
//**original**   offset = ".73 0 0";
   offset = "1.05 0.8 1";

   projectileSpread = 1.0 / 1000.0;

   usesEnergy = false;
   useMountEnergy = true;
   // DAVEG -- balancing numbers below!
   minEnergy = 1;
   fireEnergy = 1;
   fireTimeout = 125;

   //--------------------------------------
   stateName[0]             = "Activate";
   stateSequence[0]         = "Activate";
   stateAllowImageChange[0] = false;
   stateTimeoutValue[0]        = 0.05;
   stateTransitionOnTimeout[0] = "Ready";
   stateTransitionOnNoAmmo[0]  = "NoAmmo";
   //--------------------------------------
   stateName[1]       = "Ready";
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
   stateTimeoutValue[3]          = 0.01;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";
   //--------------------------------------
   stateName[4]             = "Fire";
   stateSpinThread[4]       = FullSpeed;
   stateRecoil[4]           = LightRecoil;
   stateAllowImageChange[4] = false;
   stateScript[4]           = "onFire";
   stateFire[4]             = true;
   stateSound[4]            = ShrikeBlasterFire;
   // IMPORTANT! The stateTimeoutValue below has been replaced by fireTimeOut
   // above.
   stateTimeoutValue[4]          = 0.01;
   stateTransitionOnTimeout[4]   = "checkState";
   //--------------------------------------
   stateName[5]       = "Spindown";
   stateSpinThread[5] = SpinDown;
   stateTimeoutValue[5]            = 0.01;
   stateWaitForTimeout[5]          = false;
   stateTransitionOnTimeout[5]     = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";
   //--------------------------------------
   stateName[6]       = "EmptySpindown";
//   stateSound[6]      = ChaingunSpindownSound;
   stateSpinThread[6] = SpinDown;
   stateTransitionOnAmmo[6]   = "Ready";
   stateTimeoutValue[6]        = 0.01;
   stateTransitionOnTimeout[6] = "NoAmmo";
   //--------------------------------------
   stateName[7]       = "DryFire";
   stateSound[7]      = ShrikeBlasterDryFireSound;
   stateTransitionOnTriggerUp[7] = "NoAmmo";
   stateTimeoutValue[7]        = 0.25;
   stateTransitionOnTimeout[7] = "NoAmmo";

   stateName[8] = "checkState";
   stateTransitionOnTriggerUp[8] = "Spindown";
   stateTransitionOnNoAmmo[8]    = "EmptySpindown";
   stateTimeoutValue[8]          = 0.01;
   stateTransitionOnTimeout[8]   = "ready";
};

//------------------------------------------------------
//Vehicle Functions
//------------------------------------------------------

function F56Hornet::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);
   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);

   %obj.mountImage(F56HornetChaingunParam, 0);
   %obj.mountImage(F56HornetMissileImage, 2);
   %obj.mountImage(F56HornetChaingunImage, 4);
   %obj.mountImage(HATDummy, 6);                // Helicopter.cs
   %obj.mountImage(HATDummy2, 7);               //---> Makes It Look Like Missile Pods
   %obj.selectedWeapon = 1;
   %obj.nextWeaponFire = 2;
   %obj.setInventory(chaingunammo, 2000);
   %obj.setInventory(MissileLauncherAmmo, 50);
   %obj.schedule(5500, "playThread", $ActivateThread, "activate");
}

function F56Hornet::playerMounted(%data, %obj, %player, %node)
{
   %ammoAmt = %player.inv[MissileLauncherAmmo];
   if(%ammoAmt)
      %obj.setInventory(MissileLauncherAmmo, 50);

   %ammoAmt = %player.inv[chaingunAmmo];
   if(%ammoAmt)
     %obj.incInventory(chaingunAmmo, %ammoAmt);

   bottomPrint(%player.client, "F56-Hornet: wep1 : Missile Pod, wep2 : Hornet Shreder", 5, 2 );


   commandToClient(%player.client, 'setHudMode', 'Pilot', "shrike", %node);
   %obj.selectedWeapon = 1;
   $numVWeapons = 2;
   commandToClient(%player.client, 'SetWeaponryVehicleKeys', true);
   if( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, false );
}

function F56Hornet::playerDismounted(%data, %obj, %player)
{
   %obj.fireWeapon = false;
   %obj.setImageTrigger(2, false);
   %obj.setImageTrigger(4, false);
   setTargetSensorGroup(%obj.getTarget(), %obj.team);
   if( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, true );
}

function F56Hornet::onTrigger(%data, %obj, %trigger, %state)
{
   // data = ScoutFlyer datablock
   // obj = ScoutFlyer object number
   // trigger = 0 for "fire", 1 for "jump", 3 for "thrust"
   // state = 1 for firing, 0 for not firing
   if(%trigger == 0)
   {
      switch (%state) {
         case 0:
            %obj.fireWeapon = false;
            %obj.setImageTrigger(2, false);
            %obj.setImageTrigger(4, false);
         case 1:
            %obj.fireWeapon = true;
		if(%obj.selectedWeapon == 1)
            {
               if(%obj.nextWeaponFire == 2)
               {
                  %obj.setImageTrigger(2, true);
                  %obj.setImageTrigger(4, false);
               }
            }
            else
            {
               %obj.setImageTrigger(2, false);
               %obj.setImageTrigger(4, true);
            }
      }
   }
}

datablock ShapeBaseImageData(F56HornetChaingunImage) : F56HornetChaingunPairImage
{
//**original**   offset = "-.73 0 0";
   offset = "-1.05 0.8 0.45";
   stateScript[3]           = "onTriggerDown";
   stateScript[5]           = "onTriggerUp";
   stateScript[6]           = "onTriggerUp";
};

datablock ShapeBaseImageData(F56HornetMissileImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item = MissileLauncher;
   ammo = MissileLauncherAmmo;
   projectile = HornetMissiles;
   projectileType = SeekerProjectile;

   mountPoint = 10;
   offset = "0 -0 -0.15"; // L/R - F/B - T/B

   isSeeker = true;
   seekRadius = $Bomber::SeekRadius;
   maxSeekAngle = 45;
   seekTime = 0.25;
   minSeekHeat = $Bomber::minSeekHeat;
   minTargetingDistance = 50;
   useTargetAudio = $Bomber::useTargetAudio;

   usesEnergy = false;
   useMountEnergy = true;
   minEnergy = 100;
   fireEnergy = 100;
   fireTimeout = 125;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";

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
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = MissileFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.4;
   stateAllowImageChange[4] = false;
   stateSound[4] = MissileReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateSound[6] = ShrikeBlasterDryFireSound;
   stateTimeoutValue[6] = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

datablock ShapeBaseImageData(F56HornetChaingunParam)
{
   mountPoint = 2;
   shapeFile = "turret_muzzlepoint.dts";

   projectile = HornetMissiles;
   projectileType = SeekerProjectile;
   isSeeker = true;
   seekRadius = $Bomber::SeekRadius;
   maxSeekAngle = 45;
   seekTime = 0.25;
   minSeekHeat = $Bomber::minSeekHeat;
   minTargetingDistance = 50;
   useTargetAudio = $Bomber::useTargetAudio;
};

function F56HornetMissileImage::onFire(%data,%obj,%slot)
{
   %p = Parent::onFire(%data, %obj, %slot);
   %obj.getMountNodeObject(0).decInventory(%data.ammo, 1);
   MissileSet.add(%p);
   if(%obj.isdrone == 1) {
	%p.setObjectTarget(%obj.target);
    }
   else{
      if (%obj.getControllingClient())
         %target = %obj.getLockedTarget();
      else
        %target = %obj.getTargetObject();

      %homein = missileCheckAirTarget(%target);
      if(%target && %homein)  {
         %p.setObjectTarget(%target);
         }
      else if(%obj.isLocked()) {
         %p.setPositionTarget(%obj.getLockedPosition());
         }
      else    {
         %p.setNoTarget();
         }
   }
}

function F56Hornet::onDestroyed(%data, %obj, %prevState)
{
   if(%obj.lastPilot.lastVehicle == %obj)
      if(%obj.getMountNodeObject(0) == %obj.lastPilot)
         schedule(200, %obj.lastPilot, "scKillPilot", %obj.lastPilot, %obj.lastDamagedBy);

   Parent::onDestroyed(%data, %obj, %prevState);
}

function F56Hornet::onEnterLiquid(%data, %obj, %coverage, %type)
{
   switch(%type)
   {
      case 0:
         //Water
         %obj.setHeat(0.0);
         %obj.liquidDamage(%data, 0.1, $DamageType::Crash);
      case 1:
         //Ocean Water
         %obj.setHeat(0.0);
         %obj.liquidDamage(%data, 0.1, $DamageType::Crash);
      case 2:
         //River Water
         %obj.setHeat(0.0);
         %obj.liquidDamage(%data, 0.1, $DamageType::Crash);
      case 3:
         //Stagnant Water
         %obj.setHeat(0.0);
         %obj.liquidDamage(%data, 0.1, $DamageType::Crash);
      case 4:
         //Lava
         %obj.liquidDamage(%data, $VehicleDamageLava, $DamageType::Lava);
      case 5:
         //Hot Lava
         %obj.liquidDamage(%data, $VehicleDamageHotLava, $DamageType::Lava);
      case 6:
         //Crusty Lava
         %obj.liquidDamage(%data, $VehicleDamageCrustyLava, $DamageType::Lava);
      case 7:
         //Quick Sand
   }
}

