//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock HoverVehicleData(BattleMaster) : TankDamageProfile
{
   spawnOffset = "0 0 4";
   canControl = false;
   floatingGravMag = 4.5;

   catagory = "Vehicles";
   shapeFile = "vehicle_grav_tank.dts";
   multipassenger = true;
   computeCRC = true;
   renderWhenDestroyed = false;

   weaponNode = 1;

   debrisShapeName = "vehicle_grav_tank.dts";
   debris = GShapeDebris;

   drag = 0.0;
   density = 0.9;

   mountPose[0] = sitting;
   mountPose[1] = sitting;
   numMountPoints = 2;
   isProtectedMountPoint[0] = true;
   isProtectedMountPoint[1] = true;

   cameraMaxDist = 20;
   cameraOffset = 3;
   cameraLag = 1.5;
   explosion = HGVehicleExplosion;
   explosionDamage = 2.0;
   explosionRadius = 25.0;

   maxSteeringAngle = 0.35;  // 20 deg.

   maxDamage = 45.0;
   destroyedLevel = 45.0;

   HDAddMassLevel = 42.0;
   HDMassImage = TankHDMassImage;

   isShielded = false;
   rechargeRate = 1.5;
   energyPerDamagePoint = 0;
   maxEnergy = 1000;
   minJetEnergy = 60;
   jetEnergyDrain = 2.75;

   // Rigid Body
   mass = 1500;
   bodyFriction = 0.8;
   bodyRestitution = 0.5;
   minRollSpeed = 3;
   gyroForce = 400;
   gyroDamping = 0.3;
   stabilizerForce = 20;
   minDrag = 10;
   softImpactSpeed = 15;       // Play SoftImpact Sound
   hardImpactSpeed = 18;      // Play HardImpact Sound

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 35;
   speedDamageScale = 0.017;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 20;
   collDamageMultiplier   = 0.030;

   dragForce            = 40 / 20;
   vertFactor           = 0.0;
   floatingThrustFactor = 0.15;

   mainThrustForce    = 70;
   reverseThrustForce = 30;
   strafeThrustForce  = 5;
   turboFactor        = 1.25;

   brakingForce = 30;
   brakingActivationSpeed = 4;

   stabLenMin = 3.25;
   stabLenMax = 4;
   stabSpringConstant  = 50;
   stabDampingConstant = 20;

   gyroDrag = 20;
   normalForce = 20;
   restorativeForce = 10;
   steeringForce = 25;
   rollForce  = 7;
   pitchForce = 3;

   dustEmitter = TankDustEmitter;
   triggerDustHeight = 3.5;
   dustHeight = 1.5;
   dustTrailEmitter = TireEmitter;
   dustTrailOffset = "0.0 -1.0 0.5";
   triggerTrailHeight = 3.6;
   dustTrailFreqMod = 15.0;

   jetSound         = AssaultVehicleThrustSound;
   engineSound      = AssaultVehicleEngineSound;
   floatSound       = AssaultVehicleSkid;
   softImpactSound  = GravSoftImpactSound;
   hardImpactSound  = HardImpactSound;
   wheelImpactSound = WheelImpactSound;

   forwardJetEmitter = TankJetEmitter;

   //
   softSplashSoundVelocity = 5.0;
   mediumSplashSoundVelocity = 10.0;
   hardSplashSoundVelocity = 15.0;
   exitSplashSoundVelocity = 10.0;

   exitingWater      = VehicleExitWaterMediumSound;
   impactWaterEasy   = VehicleImpactWaterSoftSound;
   impactWaterMedium = VehicleImpactWaterMediumSound;
   impactWaterHard   = VehicleImpactWaterMediumSound;
   waterWakeSound    = VehicleWakeMediumSplashSound;

   minMountDist = 7;

   damageEmitter[0] = SmallLightDamageSmoke;
   damageEmitter[1] = MeHGHeavyDamageSmoke;
   damageEmitter[2] = DamageBubbles;
   damageEmitterOffset[0] = "0.0 -1.5 3.5 ";
   damageLevelTolerance[0] = 0.4;
   damageLevelTolerance[1] = 0.8;
   numDmgEmitterAreas = 1;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDGroundTankIcon;
   cmdMiniIconName = "commander/MiniIcons/com_tank_grey";
   targetNameTag = 'Battlemaster';
   targetTypeTag = 'Assault Tank';
   sensorData = SSTurretBaseSensorObj;
   sensorRadius = SSTurretBaseSensorObj.detectRadius;
   sensorColor = "9 9 255";

   checkRadius = 5.5535;
   observeParameters = "1 10 10";
   runningLight[0] = TankLight1;
   runningLight[1] = TankLight2;
   runningLight[2] = TankLight3;
   runningLight[3] = TankLight4;
   shieldEffectScale = "0.9 1.0 0.6";
   showPilotInfo = 1;

   max[PlasmaAmmo] = 4;

   replaceTime = 60;
   
   //Damage Scale
   damageScale[$DamageType::bazooka] = 0.2;
   damageScale[$DamageType::PGC] = 0.1;

};

function BattleMaster::onTrigger(%data, %obj, %trigger, %state)
{
   if (%trigger ==4){
      switch (%state){
         case 0:
            %obj.fireWeapon = false;
         case 1:
		if (%obj.inv[PlasmaAmmo] > 0){
		   %frd = %obj.getForwardVector();
		   %bck = vectorScale(%frd, -0.85);
		   %lft = vectorNormalize(vectorCross(%frd,"0 0 1"));
		   %rgt = vectorScale(%lft, -0.9);
		   %obj.decInventory(PlasmaAmmo, 4);
      	   %p1 = new LinearFlareProjectile() {
         		dataBlock        = PhotonMissileProj;
         		initialDirection = vectorScale(%frd,0.85);
         		initialPosition  = getBoxCenter(%obj.getWorldBox());
         		sourceObject     = %obj;
         		sourceSlot       = 0;
      	   };
      	   MissionCleanup.add(%p1);
      	   %p2 = new LinearFlareProjectile() {
         		dataBlock        = PhotonMissileProj;
         		initialDirection = %bck;
         		initialPosition  = getBoxCenter(%obj.getWorldBox());
         		sourceObject     = %obj;
         		sourceSlot       = 0;
      	   };
      	   MissionCleanup.add(%p2);
      	   %p3 = new LinearFlareProjectile() {
         		dataBlock        = PhotonMissileProj;
         		initialDirection = vectorScale(%lft,0.9);
         		initialPosition  = getBoxCenter(%obj.getWorldBox());
         		sourceObject     = %obj;
         		sourceSlot       = 0;
      	   };
      	   MissionCleanup.add(%p3);
      	   %p4 = new LinearFlareProjectile() {
         		dataBlock        = PhotonMissileProj;
         		initialDirection = %rgt;
         		initialPosition  = getBoxCenter(%obj.getWorldBox());
         		sourceObject     = %obj;
         		sourceSlot       = 0;
      	   };
      	   MissionCleanup.add(%p4);
           schedule( 100,0, "seekingprojcheck" ,%obj,%p1, 0); // <- Not Stormrider
           schedule( 100,0, "PhotonShockwaveFunc" ,%obj,%p1);
           schedule( 100,0, "seekingprojcheck" ,%obj,%p2, 0); // <- Not Stormrider
           schedule( 100,0, "PhotonShockwaveFunc" ,%obj,%p2);
           schedule( 100,0, "seekingprojcheck" ,%obj,%p3, 0); // <- Not Stormrider
           schedule( 100,0, "PhotonShockwaveFunc" ,%obj,%p3);
           schedule( 100,0, "seekingprojcheck" ,%obj,%p4, 0); // <- Not Stormrider
           schedule( 100,0, "PhotonShockwaveFunc" ,%obj,%p4);
   		   serverPlay3D(GrenadeThrowSound, getBoxCenter(%obj.getWorldBox()));
		   %obj.schedule(30000, "setInventory", PlasmaAmmo, 4);
		}
      }
   }
}

//datablock ShapeBaseImageData(BattleBossImage)
//{
//    shapeFile = "vehicle_air_bomber.dts";
//    offset = "0 .5 -.5";
//};

function BattleMaster::onEnterLiquid(%data, %obj, %coverage, %type)
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

function BattleMaster::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);

   %obj.setInventory(plasmaAmmo, 4);

   %turret = TurretData::create(TankTurret);
   %turret.selectedWeapon = 1;
   MissionCleanup.add(%turret);
   %turret.team = %obj.teamBought;
   %turret.setSelfPowered();
   %obj.mountObject(%turret, 10);
   %turret.mountImage(TankMGTurretBarrel, 2);
   %turret.mountImage(TankCoaxBarrel, 3);
   %turret.mountImage(TankATurretBarrel, 4);
//   %obj.mountImage(BattleBossImage, 5);  //<testing
   %turret.setCapacitorRechargeRate( %turret.getDataBlock().capacitorRechargeRate );
   %turret.mountobj = %obj;
   %obj.turretObject = %turret;
   %turret.team = %obj.team;

   //vehicle turrets should not auto fire at targets
   %turret.setAutoFire(false);

   //Needed so we can set the turret parameters..
   %turret.mountImage(TankTurretParam, 0);
   %obj.schedule(6000, "playThread", $ActivateThread, "activate");
   
   
   %turret2 = TurretData::create(BTTurret);
   %turret2.selectedWeapon = 1;
   MissionCleanup.add(%turret2);
   %turret2.team = %obj.team;
   %turret2.setSelfPowered();
   %obj.mountObject(%turret2, 7);
   %turret2.setCapacitorRechargeRate(999);
   %turret2.mountobj = %obj;
   %turret2.team = %obj.team;
   %turret2.base = %obj;
   setTargetSensorGroup(%turret2.getTarget(),%turret2.team);
   MountBattlemasterTurret(%turret2); //mount the barrel
   %turret2.setAutoFire(true); //YES

   // set the turret's target info
   setTargetSensorGroup(%turret.getTarget(), %turret.team);
   setTargetNeverVisMask(%turret.getTarget(), 0xffffffff);
}

function BattleMaster::playerMounted(%data, %obj, %player, %node)
{
//[[CHANGE]]
   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);

   if (%node == 0) {
      // driver position
      // is there someone manning the turret?
      //%turreteer = %obj.getMountedNodeObject(1);
	   commandToClient(%player.client, 'setHudMode', 'Pilot', "Assault", %node);
   }
   else if (%node == 1)
   {
      // turreteer position
      %turret = %obj.getMountNodeObject(10);
      %player.vehicleTurret = %turret;
      %player.setTransform("0 0 0 0 0 1 0");
      %player.lastWeapon = %player.getMountedImage($WeaponSlot);
      %player.unmountImage($WeaponSlot);
      if (!%player.client.isAIControlled())
      {
         %player.setControlObject(%turret);
         %player.client.setObjectActiveImage(%turret, 2);
      }
      %turret.turreteer = %player;
      // if the player is the turreteer, show vehicle's weapon icons
      //commandToClient(%player.client, 'showVehicleWeapons', %data.getName());
      //%player.client.setVWeaponsHudActive(1); // plasma turret icon (default)

      $aWeaponActive = 0;
      commandToClient(%player.client,'SetWeaponryVehicleKeys', true);
      %obj.getMountNodeObject(10).selectedWeapon = 1;
	   commandToClient(%player.client, 'setHudMode', 'Pilot', "Assault", %node);
   }

   // update observers who are following this guy...
   if ( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, false );

   // build a space-separated string representing passengers
   // 0 = no passenger; 1 = passenger (e.g. "1 0 ")
   %passString = buildPassengerString(%obj);
	// send the string of passengers to all mounted players
	for(%i = 0; %i < %data.numMountPoints; %i++)
		if (%obj.getMountNodeObject(%i) > 0)
		   commandToClient(%obj.getMountNodeObject(%i).client, 'checkPassengers', %passString);

   bottomPrint(%player.client, "BattleMaster: Flak, CG, Tank Cannon, Automated Gauss Turret", 5, 2 );
}

function BattleMaster::deleteAllMounted(%data, %obj)
{
   %turret = %obj.getMountNodeObject(10);
   if (!%turret)
      return;
      
   %turret2 = %obj.getMountNodeObject(7);
   if (!%turret2)
      return;

   if (%client = %turret.getControllingClient())
   {
      %client.player.setControlObject(%client.player);
      %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
      %client.player.mountVehicle = false;
   }
   %turret.schedule(2000, delete);
   %turret2.schedule(2000, delete);
}

///OTHER TURRET
datablock TurretData(BTTurret) : TurretDamageProfile
{
   className = VehicleTurret;
   catagory       = "Turrets";
   shapeFile = "turret_base_large.dts";
   preload        = true;

   mass           = 1.0;  // Not really relevant

   maxEnergy               = 1;
   maxDamage               = BattleMaster.maxDamage;
   destroyedLevel          = BattleMaster.destroyedLevel;
   repairRate              = 0;

   // capacitor
   maxCapacitorEnergy      = 250;
   capacitorRechargeRate   = 1.0;

   thetaMin = 0;
   thetaMax = 100;

   inheritEnergyFromMount = true;
   firstPersonOnly = true;
   useEyePoint = true;
   numWeapons = 1;

   cameraDefaultFov = 90.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 120.0;

   targetNameTag = 'Battlemaster Gauss';
   targetTypeTag = 'Turret';
};

function MountBattlemasterTurret(%turret) {
%turret.mountImage("PlasmaBarrelLarge", 0);
}

function BTTurret::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);
   setTargetSensorGroup(%obj.target, %obj.team);
   //setTargetNeverVisMask(%obj.target, 0xffffffff);
}

function BTTurret::onDamage(%data, %obj)
{
   %newDamageVal = %obj.getDamageLevel();
   if(%obj.lastDamageVal !$= "")
      if(isObject(%obj.getObjectMount()) && %obj.lastDamageVal > %newDamageVal)
         %obj.getObjectMount().setDamageLevel(%newDamageVal);
   %obj.lastDamageVal = %newDamageVal;
}

function BTTurret::damageObject(%this, %targetObject, %sourceObject, %position, %amount, %damageType ,%vec, %client, %projectile)
{
   //If vehicle turret is hit then apply damage to the vehicle
   %vehicle = %targetObject.getObjectMount();
   if(%vehicle)
      %vehicle.getDataBlock().damageObject(%vehicle, %sourceObject, %position, %amount, %damageType, %vec, %client, %projectile);
}

