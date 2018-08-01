
datablock TurretData(TurretDeployedFloor30Indoor) : TurretDamageProfile
{
   className = DeployedTurret;
   shapeFile = "turret_indoor_deployf.dts";

   mass = 5.0;
   maxDamage = 2.0;
   destroyedLevel = 2.0;
   disabledLevel = 1.8;
   explosion      = SmallTurretExplosion;
      expDmgRadius = 5.0;
      expDamage = 0.25;
      expImpulse = 500.0;
   repairRate = 0;
   heatSignature = 0.0;

	deployedObject = true;

   thetaMin = 5;
   thetaMax = 145;
   thetaNull = 90;

   primaryAxis = zaxis;

   isShielded = true;
   energyPerDamagePoint = 110;
   maxEnergy = 30;
   rechargeRate = 0.10;
   barrel = Deployable30IndoorBarrel;

   canControl = true;
   cmdCategory = "DTactical";
   cmdIcon = CMDTurretIcon;
   cmdMiniIconName = "commander/MiniIcons/com_turret_grey";
   targetNameTag = '30-Caliber Automated';
   targetTypeTag = 'Turret';
   sensorData = DeployedIndoorTurretSensor;
   sensorRadius = DeployedIndoorTurretSensor.detectRadius;
   sensorColor = "191 0 226";

   firstPersonOnly = true;
   renderWhenDestroyed = false;

   debrisShapeName = "debris_generic_small.dts";
   debris = TurretDebrisSmall;
};

datablock TurretData(TurretDeployedWall30Indoor) : TurretDamageProfile
{
   className = DeployedTurret;
   shapeFile = "turret_indoor_deployw.dts";

   mass = 5.0;
   maxDamage = 2.0;
   destroyedLevel = 2.0;
   disabledLevel = 1.8;
   explosion      = SmallTurretExplosion;
      expDmgRadius = 5.0;
      expDamage = 0.25;
      expImpulse = 500.0;
   repairRate = 0;
   heatSignature = 0.0;

   thetaMin = 5;
   thetaMax = 145;
   thetaNull = 90;

   deployedObject = true;

   primaryAxis = yaxis;

   isShielded = true;
   energyPerDamagePoint = 110;
   maxEnergy = 30;
   rechargeRate = 0.10;
   barrel = Deployable30IndoorBarrel;

   canControl = true;
   cmdCategory = "DTactical";
   cmdIcon = CMDTurretIcon;
   cmdMiniIconName = "commander/MiniIcons/com_turret_grey";
   targetNameTag = '30-Caliber Automated';
   targetTypeTag = 'Turret';
   sensorData = DeployedIndoorTurretSensor;
   sensorRadius = DeployedIndoorTurretSensor.detectRadius;
   sensorColor = "191 0 226";

   firstPersonOnly = true;
   renderWhenDestroyed = false;

   debrisShapeName = "debris_generic_small.dts";
   debris = TurretDebrisSmall;
};

datablock TurretData(TurretDeployedCeiling30Indoor) : TurretDamageProfile
{
   className = DeployedTurret;
   shapeFile = "turret_indoor_deployc.dts";

   mass = 5.0;
   maxDamage = 2.0;
   destroyedLevel = 2.0;
   disabledLevel = 1.8;
   explosion      = SmallTurretExplosion;
      expDmgRadius = 5.0;
      expDamage = 0.5;
      expImpulse = 500.0;
   repairRate = 0;
   explosion = SmallTurretExplosion;

   //thetaMin = 5;
   //thetaMax = 145;
   thetaMin = 35;
   thetaMax = 175;
   thetaNull = 90;
   heatSignature = 0.0;

   deployedObject = true;

   primaryAxis = revzaxis;

   isShielded = true;
   energyPerDamagePoint = 110;
   maxEnergy = 75;
   rechargeRate = 0.5;
   barrel = Deployable30IndoorBarrel;

   canControl = true;
   cmdCategory = "DTactical";
   cmdIcon = CMDTurretIcon;
   cmdMiniIconName = "commander/MiniIcons/com_turret_grey";
   targetNameTag = '30-Caliber Automated';
   targetTypeTag = 'Turret';
   sensorData = DeployedIndoorTurretSensor;
   sensorRadius = DeployedIndoorTurretSensor.detectRadius;
   sensorColor = "191 0 226";

   firstPersonOnly = true;
   renderWhenDestroyed = false;

   debrisShapeName = "debris_generic_small.dts";
   debris = TurretDebrisSmall;
};

datablock TracerProjectileData(ThirtyCalBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.02; // z0dd - ZOD, 9-27-02. Was 0.0825
   directDamageType    = $DamageType::MG;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;

   kickBackStrength  = 1000.0;
   sound 				= ChaingunProjectile;

   //dryVelocity       = 425.0;
   dryVelocity       = 1500.0; // z0dd - ZOD, 8-12-02. Was 425.0
   wetVelocity       = 1000.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 15.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.12;
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

datablock TurretImageData(Deployable30IndoorBarrel)
{
   shapeFile = "turret_tank_barrelchain.dts";
   item      = TurretIndoor30calDeployable; // z0dd - ZOD, 4/25/02. Was wrong: IndoorTurretBarrel
   offset = "0 -1 0"; 	// L/R - F/B - T/B
   rotation = "0 1 0 90";

   projectile = ThirtyCalBullet;
   projectileType = TracerProjectile;

   usesEnergy = true;
   fireEnergy = 0.2;
   minEnergy = 0.2;
   projectileSpread = 0.5 / 1000.0;
   maxSpread = 5 / 1000.0;

   lightType = "WeaponFireLight";
   lightColor = "0.25 0.15 0.15 1.0";
   lightTime = "1000";
   lightRadius = "2";

   muzzleFlash = IndoorTurretMuzzleFlash;

   // Turret parameters
   activationMS      = 1000;
   deactivateDelayMS = 1000;
   thinkTimeMS       = 100000;
   degPerSecTheta    = 580;
   degPerSecPhi      = 960;
   attackRadius      = 300;

   // State transitions
   stateName[0]                  = "Activate";
   stateTransitionOnNotLoaded[0] = "Dead";
   stateTransitionOnLoaded[0]    = "ActivateReady";

   stateName[1]                  = "ActivateReady";
   stateSequence[1]              = "Activate";
   stateSound[1]                 = IBLSwitchSound;
   stateTimeoutValue[1]          = 1;
   stateTransitionOnTimeout[1]   = "Ready";
   stateTransitionOnNotLoaded[1] = "Deactivate";
   stateTransitionOnNoAmmo[1]    = "NoAmmo";

   stateName[2]                    = "Ready";
   stateTransitionOnNotLoaded[2]   = "Deactivate";
   stateTransitionOnTriggerDown[2] = "Fire";
   stateTransitionOnNoAmmo[2]      = "NoAmmo";

   stateName[3]                = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3]        = 0.01;
   stateFire[3]                = true;
   stateShockwave[3]           = true;
   stateRecoil[3]              = LightRecoil;
   stateAllowImageChange[3]    = false;
   stateSequence[3]            = "Fire";
   stateSound[3]               = IBLFireSound;
   stateScript[3]              = "onFire";

   stateName[4]                  = "Reload";
   stateTimeoutValue[4]          = 0.02;
   stateAllowImageChange[4]      = false;
   stateSequence[4]              = "Reload";
   stateTransitionOnTimeout[4]   = "Ready";
   stateTransitionOnNotLoaded[4] = "Deactivate";
   stateTransitionOnNoAmmo[4]    = "NoAmmo";

   stateName[5]                = "Deactivate";
   stateSequence[5]            = "Activate";
   stateDirection[5]           = false;
   stateTimeoutValue[5]        = 1;
   stateTransitionOnLoaded[5]  = "ActivateReady";
   stateTransitionOnTimeout[5] = "Dead";

   stateName[6]               = "Dead";
   stateTransitionOnLoaded[6] = "ActivateReady";

   stateName[7]             = "NoAmmo";
   stateTransitionOnAmmo[7] = "Reload";
   stateSequence[7]         = "NoAmmo";
};

function Deployable30IndoorBarrel::onFire(%data, %obj, %slot){
   %data.lightStart = getSimTime();

   if(%obj.spread $= "")
	%obj.spread = %data.projectileSpread;
   else
      %obj.spread = %obj.spread + (4 / 10000);

   if(%obj.lowSpreadLoop $= "")
	%obj.lowSpreadLoop = schedule(250, 0, "lowerSpread", %data, %obj);
   if(%obj.spread > %data.maxspread)
	%obj.spread = %data.maxspread;

   %vec = %obj.getMuzzleVector(%slot);
   %x = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
   %y = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
   %z = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
   %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
   %vector = MatrixMulVector(%mat, %vec);
   %initialPos = %obj.getMuzzlePoint(%slot);

   %p = new (%data.projectileType)() {
      dataBlock        = %data.projectile;
      initialDirection = %vector;
      initialPosition  = %initialPos;
      sourceObject     = %obj;
      sourceSlot       = %slot;
   };
   %obj.lastProjectile = %p;
   MissionCleanup.add(%p);

   if(%obj.client)
      %obj.client.projectile = %p;
}

function lowerSpread(%data, %obj){
   %obj.spread = %obj.spread - (4 / 10000);
   if(%obj.spread < %data.projectileSpread){
	%obj.spread = %data.projectileSpread;
	%obj.lowSpreadLoop = "";
	return;
   }
   %obj.lowSpreadLoop = schedule(120, 0, "lowerSpread", %data, %obj);
}
