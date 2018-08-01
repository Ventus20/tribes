// Escape Pod

datablock FlyingVehicleData(escapepodvehicle) : ShrikeDamageProfile
{
   spawnOffset = "0 0 2";
   canControl = false;
   catagory = "Vehicles";
   shapeFile = "vehicle_grav_scout.dts";
   multipassenger = false;
   computeCRC = true;

   debrisShapeName = "vehicle_grav_scout.dts";
   debris = ShapeDebris;
   renderWhenDestroyed = false;

   drag    = 0.15;
   density = 1.0;

   mountPose[0] = sitting;
   numMountPoints = 1;
   isProtectedMountPoint[0] = false;
   cameraMaxDist = 15;
   cameraOffset = 2.5;
   cameraLag = 0.9;
   explosion = VehicleBombExplosion;
	explosionDamage = 5.0;
	explosionRadius = 35.0;

   maxDamage = 0.5;
   destroyedLevel = 0.5;

   HDAddMassLevel = 0.4;
   HDMassImage = MissileHDMassImage;

   isShielded = false;
   energyPerDamagePoint = 0;
   maxEnergy = 400;      // Afterburner and any energy weapon pool
   rechargeRate = 0.0;

   minDrag = 30;           // Linear Drag (eventually slows you down when not thrusting...constant drag)
   rotationalDrag = 100;        // Anguler Drag (dampens the drift after you stop moving the mouse...also tumble drag)

   maxAutoSpeed = 100000;       // Autostabilizer kicks in when less than this speed. (meters/second)
   autoAngularForce = 100;       // Angular stabilizer force (this force levels you out when autostabilizer kicks in)
   autoLinearForce = 0;        // Linear stabilzer force (this slows you down when autostabilizer kicks in)
   autoInputDamping = 1.0;      // Dampen control input so you don't` whack out at very slow speeds


   // Maneuvering
   maxSteeringAngle = 4.5;    // Max radiens you can rotate the wheel. Smaller number is more maneuverable.
   horizontalSurfaceForce = 6;   // Horizontal center "wing" (provides "bite" into the wind for climbing/diving and turning)
   verticalSurfaceForce = 4;     // Vertical center "wing" (controls side slip. lower numbers make MORE slide.)
   maneuveringForce = 0;      // Horizontal jets (W,S,D,A key thrust)
   steeringForce = 150;         // Steering jets (force applied when you move the mouse)
   steeringRollForce = 50;      // Steering jets (how much you heel over when you turn)
   rollForce = 10;                // Auto-roll (self-correction to right you after you roll/invert)
   hoverHeight = 5;        // Height off the ground at rest
   createHoverHeight = 3;  // Height off the ground when created
   maxForwardSpeed = 180;  // speed in which forward thrust force is no longer applied (meters/second)

   // Turbo Jet
   jetForce = 6000;      // Afterburner thrust (this is in addition to normal thrust)
   minJetEnergy = 1;     // Afterburner can't be used if below this threshhold.
   jetEnergyDrain = 0.5;       // Energy use of the afterburners (low number is less drain...can be fractional)                                                                                                                                                                                                                                                                                          // Auto stabilize speed
   vertThrustMultiple = 0.0;

   // Rigid body
   mass = 150;        // Mass of the vehicle
   bodyFriction = 0;     // Don't mess with this.
   bodyRestitution = 0.5;   // When you hit the ground, how much you rebound. (between 0 and 1)
   minRollSpeed = 0;     // Don't mess with this.
   softImpactSpeed = 14;       // Sound hooks. This is the soft hit.
   hardImpactSpeed = 25;    // Sound hooks. This is the hard hit.

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 1;      // If hit ground at speed above this then it's an impact. Meters/second
   speedDamageScale = 0.1;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 1.0;
   collDamageMultiplier   = 0.02;

   //
   minTrailSpeed = 150;      // The speed your contrail shows up at.
   trailEmitter = ContrailEmitter;
   forwardJetEmitter = MissileSmokeEmitter;
   downJetEmitter = FlyerJetEmitter;

   //
   jetSound = ScoutFlyerThrustSound;
   engineSound = ScoutFlyerEngineSound;
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

   damageEmitter[0] = LightDamageSmoke;
   damageEmitter[1] = HeavyDamageSmoke;
   damageEmitter[2] = DamageBubbles;
   damageEmitterOffset[0] = "0.0 -3.0 0.0 ";
   damageLevelTolerance[0] = 0.3;
   damageLevelTolerance[1] = 0.7;
   numDmgEmitterAreas = 1;

   minMountDist = 4;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDFlyingScoutIcon;
   cmdMiniIconName = "commander/MiniIcons/com_scout_grey";
   targetNameTag = 'TomaHawk';
   targetTypeTag = 'CruiseMissile';
   sensorData = PlayerSensor;

   checkRadius = 5.5;
   observeParameters = "1 10 10";

   runningLight[0] = ShrikeLight1;

   shieldEffectScale = "0.937 1.125 0.60";

   replaceTime = 1;
};

datablock StaticShapeData(TMShape) : StaticShapeDamageProfile {
   shapeFile      = "weapon_missile_projectile.dts";
   mass           = 1.0;
   repairRate     = 0;
   dynamicType    = $TypeMasks::StaticShapeObjectType;
   heatSignature  = 0;
};

function escapepodvehicle::onAdd(%this, %obj) {
   Parent::onAdd(%this, %obj);
   setTargetSensorGroup(%obj.getTarget(),%obj.team);

   %body = new StaticShape()
   {
       scale = "20 20 20";
       dataBlock = "TMShape";
   };
   MissionCleanup.add(%body);
   %obj.mountObject(%body, 1);
   %body.vehicleMounted = %obj;

   %wing = new StaticShape()
   {
       scale = "1.25 0.5 0.5";
   	 offset = "0 -3 0";
       dataBlock = "WHWing";
   };
   MissionCleanup.add(%wing);
   %obj.mountObject(%wing, 9);
   %obj.startFade(0,100,1);
   %wing.vehicleMounted = %obj;
}

function escapepodvehicle::deleteAllMounted(%data, %obj) {

   if(%obj.launchedByRC) {
      if(%obj.payload == 2) {
         CreateScorch(%obj.controllerofRC.player, %obj.position);
         CreateScorch(%obj.controllerofRC.player, vectorAdd(%obj.position, "7 0 0"));
         CreateScorch(%obj.controllerofRC.player, vectorAdd(%obj.position, "-7 0 0"));
         CreateScorch(%obj.controllerofRC.player, vectorAdd(%obj.position, "0 7 0"));
         CreateScorch(%obj.controllerofRC.player, vectorAdd(%obj.position, "0 -7 0"));
      }
      else if(%obj.payload == 3) {
         %p = new (GrenadeProjectile)() {
             dataBlock        = "BunkerBusterball";
             initialDirection = "0 0 0";
             initialPosition  = vectoradd(%obj.position, "0 0 15");
             damageFactor     = 1;
         };
         MissionCleanup.add(%p);
      }
      %obj.controllerofRC.setControlObject(%obj.controllerofRC.player);
      %obj.controllerofRC.RCUnit = "";
   }

   %body = %obj.getMountNodeObject(1);
   if(!%body)
      return;
   %body.delete();

   %wing = %obj.getMountNodeObject(9);
   if(!%wing)
      return;
   %wing.delete();
}

function escapepodvehicle::onEnterLiquid(%data, %obj, %coverage, %type)
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
