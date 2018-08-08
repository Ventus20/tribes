//LORD \/ARDISON
//THE BOSS TO END ALL BOSSES
datablock LinearFlareProjectileData(SuperlaserProjectile) {
   scale               = "15.0 15.0 15.0";
   faceViewer          = false;
   directDamage        = 1.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.9;
   damageRadius        = 30.0;
   kickBackStrength    = 1000.0;
   radiusDamageType    = $DamageType::Explosion;

   explosion[0]           = "HyperDevCannonExplosion2";
   explosion[1]           = "SatchelMainExplosion";
   splash              = PlasmaSplash;
   baseEmitter         = HyperDevCannonBaseEmitter;


   dryVelocity       = 200.0;
   wetVelocity       = 200;
   velInheritFactor  = 0.5;
   fizzleTimeMS      = 2000;
   lifetimeMS        = 2000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   //activateDelayMS = 100;
   activateDelayMS = -1;

   size[0]           = 9;
   size[1]           = 10;
   size[2]           = 11;


   numFlares         = 400;
   flareColor        = "0.0 1.0 0";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   sound        = MissileProjectileSound;
   fireSound    = PlasmaFireSound;
   wetFireSound = PlasmaFireWetSound;

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "0 0.75 0.25";

};

//
datablock ParticleData(ShadowBaseParticle) {
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = -0.2;
   inheritedVelFactor   = 0.0;

   lifetimeMS           = 800;
   lifetimeVarianceMS   = 500;

   useInvAlpha = true;
   spinRandomMin = -160.0;
   spinRandomMax = 160.0;

   animateTexture = true;
   framesPerSec = 15;

   textureName = "special/cloudflash";

   colors[0] = "0.1 0.1 0.1 1.0";// ////////////////////
   colors[1] = "0.1 0.1 0.1 1.0";// ////////////////////
   colors[2] = "0.1 0.1 0.1 1.0";// \\\\\\\\\\\\\\\\\\\\

   sizes[0]      = 2.5;
   sizes[1]      = 2.7;
   sizes[2]      = 3.0;

   times[0]      = 0.0;
   times[1]      = 0.7;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(ShadowBaseEmitter) {
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;

   ejectionVelocity = 1.5;
   velocityVariance = 0.3;

   thetaMin         = 0.0;
   thetaMax         = 30.0;

   particles = "ShadowBaseParticle";
};

datablock ParticleData(SmallShadowBaseParticle) {
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = -0.2;
   inheritedVelFactor   = 0.0;

   lifetimeMS           = 9999999999999;
   lifetimeVarianceMS   = 9999999999999;

   useInvAlpha = true;
   spinRandomMin = -160.0;
   spinRandomMax = 160.0;

   animateTexture = true;
   framesPerSec = 15;

   textureName = "special/cloudflash";

   colors[0] = "0.1 0.1 0.1 1.0";// ////////////////////
   colors[1] = "0.1 0.1 0.1 1.0";// ////////////////////
   colors[2] = "0.1 0.1 0.1 1.0";// \\\\\\\\\\\\\\\\\\\\

   sizes[0]      = 0.5;
   sizes[1]      = 0.7;
   sizes[2]      = 1.0;

   times[0]      = 0.0;
   times[1]      = 0.7;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(SmallShadowBaseEmitter) {
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;

   ejectionVelocity = 1.5;
   velocityVariance = 0.3;

   thetaMin         = 0.0;
   thetaMax         = 30.0;

   particles = "SmallShadowBaseParticle";
};

datablock ParticleData(JetShadowParticle) {
	dragCoeffiecient     = 0.0;
	gravityCoefficient   = 0;
	inheritedVelFactor   = 0.0;

	lifetimeMS           = 2500;
	lifetimeVarianceMS   = 0;

	textureName          = "particleTest";

	useInvAlpha = true;
	spinRandomMin = -160.0;
	spinRandomMax = 160.0;

	animateTexture = true;
	framesPerSec = 15;

	animTexName[0]       = "special/Explosion/exp_0016";
	animTexName[1]       = "special/Explosion/exp_0018";
	animTexName[2]       = "special/Explosion/exp_0020";
	animTexName[3]       = "special/Explosion/exp_0022";
	animTexName[4]       = "special/Explosion/exp_0024";
	animTexName[5]       = "special/Explosion/exp_0026";
	animTexName[6]       = "special/Explosion/exp_0028";
	animTexName[7]       = "special/Explosion/exp_0030";
	animTexName[8]       = "special/Explosion/exp_0032";

    colors[0] = "0.1 0.1 0.1 1.0";// ////////////////////
    colors[1] = "0.1 0.1 0.1 1.0";// ////////////////////
    colors[2] = "0.1 0.1 0.1 1.0";// \\\\\\\\\\\\\\\\\\\\
	sizes[0]      = 2.5;
	sizes[1]      = 1.25;
	sizes[2]      = 0.625;
	times[0]      = 0.0;
	times[1]      = 0.7;
	times[2]      = 1.0;
};

datablock ParticleEmitterData(JetShadowEmitter) {
   ejectionPeriodMS = 2;
   periodVarianceMS = 0;

   ejectionVelocity = 0;
   velocityVariance = 0;
   ejectionOffset   = 5;
   thetaMin         = 22.5;
   thetaMax         = 45;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   spinRandomMin   = "200";
   spinRandomMax   = "-200";
   overrideAdvances = false;
   particles = "JetShadowParticle";
};

datablock ParticleData(LaserBallGlobeSmoke) {
   dragCoefficient = 50;/////////-----------------------
   gravityCoefficient = 0.0;
   inheritedVelFactor = 1.0;
   constantAcceleration = 0.0;
   lifetimeMS = 1000;
   lifetimeVarianceMS = 0;
   useInvAlpha = true;
   spinRandomMin = -360.0;
   spinRandomMax = 360.0;
   textureName = "particleTest";
   colors[0] = "0.1 0.1 0.1 1.0";// ////////////////////
   colors[1] = "0.1 0.1 0.1 1.0";// ////////////////////
   colors[2] = "0.1 0.1 0.1 1.0";// \\\\\\\\\\\\\\\\\\\\
   colors[3] = "0.1 0.1 0.1 1.0";// \\\\\\\\\\\\\\\\\\\\
   sizes[0] = 1.0;
   sizes[1] = 1.0;
   sizes[2] = 1.0;
   sizes[3] = 1.0;
   times[0] = 0.0;
   times[1] = 0.33;
   times[2] = 0.66;
   times[3] = 1.0;
   mass = 0.7;
   elasticity = 0.2;
   friction = 1;
   computeCRC = true;
   haslight = true;
   lightType = "PulsingLight";
   lightColor = "0.2 0.0 0.5 1.0";
   lightTime = "200";
   lightRadius = "2.0";
};

datablock ParticleEmitterData(MiniShadowBallEmitter) {
   ejectionPeriodMS = 0.3;
   periodVarianceMS = 0;
   ejectionVelocity = 0.0;
   velocityVariance = 0.0;
   ejectionOffset = 2;
   thetaMin = 0;
   thetaMax = 180;
   overrideAdvances = false;
   particles = "LaserBallGlobeSmoke";
};

datablock LinearFlareProjectileData(ShadowBomb) : FlamethrowerBolt {
   baseEmitter        = ShadowBaseEmitter;
   fizzleTimeMS      = 14000;
   lifetimeMS        = 10000; // z0dd - ZOD, 4/25/02. Was 6000
};

datablock SeekerProjectileData(VardisonNightmareMissile){
   casingShapeName     = "weapon_missile_casement.dts";
   projectileShapeName = "weapon_missile_projectile.dts";
   hasDamageRadius     = true;
   indirectDamage      = 0.8;
   damageRadius        = 8.0;
   radiusDamageType    = $DamageType::Missile;
   kickBackStrength    = 2000;

   explosion           = "MissileExplosion";
   splash              = MissileSplash;
   velInheritFactor    = 1.0;    // to compensate for slow starting velocity, this value
                                 // is cranked up to full so the missile doesn't start
                                 // out behind the player when the player is moving
                                 // very quickly - bramage

   delayEmitter        = MissileFireEmitter;
   puffEmitter         = MissilePuffEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;
   bubbleEmitTime      = 1.0;

   exhaustEmitter      = MissileLauncherExhaustEmitter;
   exhaustTimeMs       = 300;
   exhaustNodeName     = "muzzlePoint1";

   lifetimeMS          = 30000;
   muzzleVelocity      = 10.0;
   maxVelocity         = 150.0;
   turningSpeed        = 110.0;
   acceleration        = 350.0;

   proximityRadius     = 3;

   terrainAvoidanceSpeed         = 180;
   terrainScanAhead              = 25;
   terrainHeightFail             = 12;
   terrainAvoidanceRadius        = 100;

   flareDistance = 200;
   flareAngle    = 30;

   sound = MissileProjectileSound;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0.2 0.05 0";

   useFlechette = true;
   flechetteDelayMs = 550;
   casingDeb = FlechetteDebris;

   explodeOnWaterImpact = false;

   baseEmitter         = NMMissileBaseEmitter;
};

function VardisonNightmareMissile::OnExplode(%data, %proj, %pos, %mod) {
   %source = %proj.SourceObject;
   InitContainerRadiusSearch(%proj.getPosition(), 6, $TypeMasks::PlayerObjectType);
   while ((%potentialTarget = ContainerSearchNext()) != 0) {
      %cl = %potentialTarget.client;
      if(%cl !$= "")
         Yvexnightmareloop(%source, %cl);
   }
}

datablock SeekerProjectileData(VardisonLaserBallMissile) : VardisonNightmareMissile {
   baseEmitter         = ShadowBaseEmitter;
};

function VardisonLaserBallMissile::OnExplode(%data, %proj, %pos, %mod) {
   //LaserBall
   %ball = CreateEmitter(%pos, "MiniShadowBallEmitter", "0 0 0 0");
   %ball.schedule(10000, "Delete");
   LaserBallStrike(vectorAdd(%pos, "0 0 3"), 0);
}

function LaserBallStrike(%position, %count) {
   %count++;
   if(%count > 100) {
      %p = new LinearFlareProjectile() {
	     dataBlock        = VardisonSubShadowBomb;
         initialDirection = "0 0 -1";
	     initialPosition  = %position;
      };
      return; //stop here
   }
   else {
      if(%count % 3 == 0) {     //multiples of 3 == strike
         %p = new TracerProjectile() {
	        dataBlock        = PlasmaCannonMainProj;
            initialDirection = vectorAdd(%postition, getRandomPosition(25,0));
	        initialPosition  = %position;
         };
      }
   }
   schedule(100, 0, "LaserBallStrike", %position, %count);
}

datablock LinearFlareProjectileData(VardisonSubShadowBomb) : DMPlasma {
   explosion = MortarExplosion;
   dryVelocity       = 500.0; // z0dd - ZOD, 4/25/02. Was 50. Velocity of projectile out of water
   wetVelocity       = -1;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 14000;
   lifetimeMS        = 10000; // z0dd - ZOD, 4/25/02. Was 6000
};

//ARMOR DBs
datablock PlayerData(VardisonStage1Armor) : LightMaleHumanArmor {
   runForce = 60.20 * 90;
   runEnergyDrain = 0.0;
   minRunEnergy = 10;
   maxForwardSpeed = 9;
   maxBackwardSpeed = 7;
   maxSideSpeed = 7;

   jumpForce = 14.0 * 90;

   maxDamage = 300.0;
   minImpactSpeed = 35;
   shapeFile = "light_male.dts";
   jetEmitter = BiodermArmorJetEmitter;
   jetEffect =  BiodermArmorJetEffect;

   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData   = LightBiodermFootprint;
   decalOffset = 0.3;

   waterBreathSound = WaterBreathBiodermSound;

   damageScale[$DamageType::M1700] = 3.0;

	max[RepairKit]			= 0;
	max[Mine]			= 0;
	max[Grenade]			= 0;
};

datablock FlyingVehicleData(VardisonStage2Flyer) : ShrikeDamageProfile {
   spawnOffset = "0 0 2";
   canControl = false;
   catagory = "Vehicles";
   shapeFile = "vehicle_air_bomber.dts";
   multipassenger = false;
   computeCRC = true;

   debrisShapeName = "vehicle_air_bomber.dts";
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

   maxDamage = 50.0;
   destroyedLevel = 50.0;

   HDAddMassLevel = 49.9;
   HDMassImage = LflyerHDMassImage;

   isShielded = false;
   energyPerDamagePoint = 0;
   maxEnergy = 5000;      // Afterburner and any energy weapon pool
   rechargeRate = 4;

   minDrag = 22;           // Linear Drag (eventually slows you down when not thrusting...constant drag)
   rotationalDrag = 900;        // Anguler Drag (dampens the drift after you stop moving the mouse...also tumble drag)

   maxAutoSpeed = 50;       // Autostabilizer kicks in when less than this speed. (meters/second)
   autoAngularForce = 400;       // Angular stabilizer force (this force levels you out when autostabilizer kicks in)
   autoLinearForce = 1;        // Linear stabilzer force (this slows you down when autostabilizer kicks in)
   autoInputDamping = 0.8;      // Dampen control input so you don't` whack out at very slow speeds


   // Maneuvering
   maxSteeringAngle = 4.5;    // Max radiens you can rotate the wheel. Smaller number is more maneuverable.
   horizontalSurfaceForce = 6;   // Horizontal center "wing" (provides "bite" into the wind for climbing/diving and turning)
   verticalSurfaceForce = 4;     // Vertical center "wing" (controls side slip. lower numbers make MORE slide.)
   maneuveringForce = 5250;      // Horizontal jets (W,S,D,A key thrust)
   steeringForce = 675;         // Steering jets (force applied when you move the mouse)
   steeringRollForce = 3000;      // Steering jets (how much you heel over when you turn)
   rollForce = 1;                // Auto-roll (self-correction to right you after you roll/invert)
   hoverHeight = 2.5;        // Height off the ground at rest
   createHoverHeight = 1;  // Height off the ground when created
   maxForwardSpeed = 165;  // speed in which forward thrust force is no longer applied (meters/second)

   // Turbo Jet
   jetForce = 2500;      // Afterburner thrust (this is in addition to normal thrust)
   minJetEnergy = 40;     // Afterburner can't be used if below this threshhold.
   jetEnergyDrain = 10;       // Energy use of the afterburners (low number is less drain...can be fractional)                                                                                                                                                                                                                                                                                          // Auto stabilize speed
   vertThrustMultiple = 1.25;

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
   minTrailSpeed = 70;      // The speed your contrail shows up at.
   trailEmitter = JetShadowEmitter;
   forwardJetEmitter = JetShadowEmitter;
   downJetEmitter = JetShadowEmitter;

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

   damageEmitter[0] = MeLightDamageSmoke;
   damageEmitter[1] = MeHeavyDamageSmoke;
   damageEmitter[2] = MeDamageBubbles;
   damageEmitterOffset[0] = "0.0 -3.0 0.0 ";
   damageLevelTolerance[0] = 0.4;
   damageLevelTolerance[1] = 0.75;
   numDmgEmitterAreas = 1;

   //
   max[chaingunAmmo] = 2000;
   max[MissileLauncherAmmo] = 200;
   max[MortarAmmo] = 200;

   minMountDist = 7;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDFlyingScoutIcon;
   cmdMiniIconName = "commander/MiniIcons/com_scout_grey";
   targetNameTag = 'Lord Vardison';
   targetTypeTag = '';
   sensorData = SSTurretBaseSensorObj;
   sensorRadius = SSTurretBaseSensorObj.detectRadius;
   sensorColor = "9 9 255";

   checkRadius = 5.5;
   observeParameters = "1 10 10";

   runningLight[0] = ShrikeLight1;
//   runningLight[1] = ShrikeLight2;

   shieldEffectScale = "0.937 1.125 0.60";

   numWeapons = 3;

   replaceTime = 90;
};

datablock PlayerData(VardisonStage3Armor) : LightMaleHumanArmor {
   runForce = 60.20 * 90;
   runEnergyDrain = 0.0;
   minRunEnergy = 10;
   maxForwardSpeed = 9;
   maxBackwardSpeed = 7;
   maxSideSpeed = 7;

   jumpForce = 14.0 * 90;

   maxDamage = 500.0;
   minImpactSpeed = 35;
   shapeFile = "TR2Heavy_Male.dts";
   jetEmitter = BiodermArmorJetEmitter;
   jetEffect =  BiodermArmorJetEffect;

   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData   = LightBiodermFootprint;
   decalOffset = 0.3;
   
   boundingBox = "5 5 10";

   waterBreathSound = WaterBreathBiodermSound;

   damageScale[$DamageType::M1700] = 3.0;
   damageScale[$DamageType::PlasmaCannon] = 0.001;

	max[RepairKit]			= 0;
	max[Mine]			= 0;
	max[Grenade]			= 0;
};

function StartVardison1(%pos) {

	%Vardison = new player(){
	   Datablock = "VardisonStage1Armor";
	};
	%Cpos = vectorAdd(%pos, "0 0 5");
    MessageAll('MsgVardison', "\c4"@$TWM2::BossName["Vardison"]@": "@$TWM2::BossName["Vardison"]@", Checking into duty, and about to slaughter some fuckin' enemies!!!");

	%command = "Vardison1movetotarget";
    %zombie.ticks = 0;
    InitiateBoss(%Vardison, "Vardison1");

   %Vardison.team = 30;
   %zname = CollapseEscape("\c7"@$TWM2::BossName["Vardison"]@""); // <- To Hosts, Enjoy, You can
                                      //Change the Zombie Names now!!!
   %Vardison.target = createTarget(%Vardison, %zname, "", "Derm3", '', %Vardison.team, PlayerSensor);
   setTargetSensorData(%Vardison.target, PlayerSensor);
   setTargetSensorGroup(%Vardison.target, 30);
   setTargetName(%Vardison.target, addtaggedstring(%zname));
   setTargetSkin(%Vardison.target, 'Inferno');
   //
   %Vardison.setPosition(%cpos);
   %Vardison.canjump = 1;
   %Vardison.hastarget = 1;
   MissionCleanup.add(%Vardison);
   schedule(1000, %Vardison, %command, %Vardison);

   VardisonAttacks(%Vardison);
}

function StartVardison2(%pos) {
   %StartPos = VectorAdd(%pos, "0 0 100");
	%team = 30;
	%rotation = "1 0 0 0";
    %skill = 10;

   %Drone = new FlyingVehicle() {
      dataBlock    = VardisonStage2Flyer;
      position     = %StartPos;
      rotation     = %rotation;
      team         = %team;
   };
   MissionCleanUp.add(%Drone);
   
   MessageAll('MsgVardison', "\c4"@$TWM2::BossName["Vardison"]@": HA! I'm nowhere near finished with you, Lets take this to the skies.. shall we.");

   setTargetSensorGroup(%Drone.getTarget(), %team);

   %Drone.isdrone = 1;
   %drone.dodgeGround = 0;

   %drone.isace = 1;

   %drone.skill = 0.2 + (%skill / 12.5);

   schedule(100, 0, "DroneForwardImpulse", %drone); //special impulse
   schedule(101, 0, "DronefindTarget", %drone);
   schedule(102, 0, "DroneScanGround", %drone);

   InitiateBoss(%drone, "Vardison2");
   VardisonDroneAttacks(%drone);
}

function StartVardison3(%pos) {
	%Vardison = new player(){
	   Datablock = "VardisonStage3Armor";
	};
	%Cpos = vectorAdd(%pos, "0 0 5");
    MessageAll('MsgVardison', "\c4"@$TWM2::BossName["Vardison"]@": Now you will see the full power of a shadow demon!!!");

	%command = "Vardison3movetotarget";
    %zombie.ticks = 0;
    InitiateBoss(%Vardison, "Vardison3");

   %Vardison.team = 30;
   %zname = CollapseEscape("\c7"@$TWM2::BossName["Vardison"]@""); // <- To Hosts, Enjoy, You can
                                      //Change the Zombie Names now!!!
   %Vardison.target = createTarget(%Vardison, %zname, "", "Derm3", '', %Vardison.team, PlayerSensor);
   setTargetSensorData(%Vardison.target, PlayerSensor);
   setTargetSensorGroup(%Vardison.target, 30);
   setTargetName(%Vardison.target, addtaggedstring(%zname));
   setTargetSkin(%Vardison.target, 'Inferno');
   //
   %Vardison.setTransform(%cpos);
   %Vardison.canjump = 1;
   %Vardison.hastarget = 1;
   MissionCleanup.add(%Vardison);
   schedule(1000, %Vardison, %command, %Vardison);
   
   VardisonDemonAttacks(%Vardison);
   
   //SpawnVardHelper(%Vardison, vectorAdd(%Vardison.getPosition(), "15 0 100"));

}

function Vardison1movetotarget(%zombie){
   if(!isobject(%zombie))
	return;
   if(%zombie.getState() $= "dead")
	return;
   %pos = %zombie.getworldboxcenter();
   %closestClient = ZombieLookForTarget(%zombie);
   %z = getWord(%pos, 2);
   if(%z < -300) {
      %zombie.startFade(400, 0, true);
      %zombie.startFade(1000, 0, false);
      %zombie.setPosition(vectorAdd(vectoradd(%closestclient.player.getPosition(), "0 0 20"), getRandomPosition(25, 1)));
      %zombie.setVelocity("0 0 0");
      MessageAll('MsgVardison', "\c4"@$TWM2::BossName["Vardison"]@": I'm back....");
   }
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;
   if(%closestDistance <= $zombie::detectDist){
       if(%closestDistance < 15) {
          GOVDoFlameCano(%zombie, %closestClient);
          MessageAll('MsgVardison', "\c4"@$TWM2::BossName["Vardison"]@": Now you will all suffer!!!");
       }
	   if(%zombie.hastarget != 1){
	      LZDoYell(%zombie);
	      %zombie.hastarget = 1;
       }
       %chance = (getrandom() * 20);
   	   if(%chance >= 19)
	      LZDoMoan(%zombie);

       %vector = ZgetFacingDirection(%zombie,%closestClient,%pos);

	%vector = vectorscale(%vector, $Zombie::DForwardSpeed);
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= ($Zombie::DForwardSpeed))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
   %zombie.moveloop = schedule(500, %zombie, "Vardison1movetotarget", %zombie);
}

function Vardison3movetotarget(%zombie){
   if(!isobject(%zombie))
	return;
   if(%zombie.getState() $= "dead")
	return;
   %pos = %zombie.getworldboxcenter();
   %closestClient = ZombieLookForTarget(%zombie);
   %z = getWord(%pos, 2);
   if(%z < -300) {
      %zombie.startFade(400, 0, true);
      %zombie.startFade(1000, 0, false);
      %zombie.setPosition(vectorAdd(vectoradd(%closestclient.getPosition(), "0 0 20"), getRandomPosition(25, 1)));
      %zombie.setVelocity("0 0 0");
      MessageAll('MsgVardison', "\c4"@$TWM2::BossName["Vardison"]@": I'm back....");
   }
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;
   if(%closestDistance <= $zombie::detectDist){
       if(%closestDistance < 10) {
          %closestClient.scriptKill(0);
          MessageAll('MsgVardison', "\c4"@$TWM2::BossName["Vardison"]@": DIE!!!!!!");
       }
	   if(%zombie.hastarget != 1){
	      LZDoYell(%zombie);
	      %zombie.hastarget = 1;
       }
       %chance = (getrandom() * 20);
   	   if(%chance >= 19)
	      LZDoMoan(%zombie);

       %vector = ZgetFacingDirection(%zombie,%closestClient,%pos);

	%vector = vectorscale(%vector, $Zombie::DForwardSpeed*1.8);
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= ($Zombie::DForwardSpeed))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
   %zombie.moveloop = schedule(500, %zombie, "Vardison3movetotarget", %zombie);
}

//ATTACKS

function ShadowBomb::onExplode(%data, %proj, %pos, %mod) {
   %vec = %proj.spdvec;
   %vec = getword(%vec, 0)@" "@getword(%vec, 1)@" 0";
   %vec = vectorNormalize(%vec);
   %vec = vectorscale(%vec, 30);
   %result = containerRayCast(vectoradd(%pos,"0 0 10"), vectoradd(%pos,%vec), $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType, %proj);
   for(%i = 0; %i < 3; %i++) {
      if(%result)
	     schedule((5 * %i), 0, "NapalmFindNewDir", %pos, %vec, %proj.sourceobject, 0, 0);
	  else {
	     %rndvec = (getRandom(1, 15) - 7.5)@" "@(getRandom(1, 15) - 7.5)@" "@((getRandom() * 5) + 5);
	     %newvec = vectoradd(%vec,%rndvec);
	     %newvec = vectoradd(%pos,%newvec);
	     %p = new LinearFlareProjectile() {
	   	    dataBlock        = VardisonSubShadowBomb;
	   	    initialDirection = "0 0 -1";
	   	    initialPosition  = %newvec;
	   	    sourceObject     = %proj.sourceobject;
            SourceSlot       = 5;
	     };
	     %p.sourceobject = %proj.sourceobject;
	     %p.vector = %vec;
	     %p.count = 1;
         if(%proj.maxExplode $= "") {
            %p.maxExplode = 15;
         }
         else {
            %p.maxExplode = %proj.maxExplode;
         }
      }
   }
   if (%data.hasDamageRadius)
      RadiusExplosion(%proj, %pos, %data.damageRadius, %data.indirectDamage, %data.kickBackStrength, %proj.sourceObject, %data.radiusDamageType);
}

function VardisonSubShadowBomb::onExplode(%data, %proj, %pos, %mod) {
   if(%proj.count < %proj.maxExplode) { //holy... christ
      %vec = vectorscale(vectornormalize(%proj.vector), 24);
      %result = containerRayCast(vectoradd(%pos,"0 0 10"), vectoradd(%pos,%vec), $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType, %proj);
      if(%result)
         schedule(5, 0, "Napalm2FindNewDir", %pos, %vec, %proj.sourceobject, %proj.count, 0);
	  else {
	     %rndvec = (getRandom(1, 10) - 5)@" "@(getRandom(1, 10) - 5)@" "@((getRandom() * 5) + 5);
	     %newvec = vectoradd(%vec,%rndvec);
	     %newvec = vectoradd(%pos,%newvec);
	     %p = new LinearFlareProjectile() {
		    dataBlock        = VardisonSubShadowBomb;
		    initialDirection = "0 0 -1";
		    initialPosition  = %newvec;
		    sourceObject     = %proj.sourceobject;
   		    sourceSlot       = 5;
         };
         %p.sourceobject = %proj.sourceobject;
	     %p.vector = %vec;
	     %p.count = %proj.count + 1;
      }
   }
   if (%data.hasDamageRadius)
      RadiusExplosion(%proj, %pos, %data.damageRadius, %data.indirectDamage, %data.kickBackStrength, %proj.sourceObject, %data.radiusDamageType);
}

function Napalm2FindNewDir(%pos, %vec, %source, %count, %count2) {
   if(%count2 == 2) {
	  %rndvec = getRandom(1, 10)@" "@getRandom(1, 10)@" "@((getRandom() * 5) + 4);
	  %newvec = vectoradd(%pos,%rndvec);
	  %p = new LinearFlareProjectile() {
	     dataBlock        = VardisonSubShadowBomb;
	     initialDirection = "0 0 -1";
	     initialPosition  = %newvec;
	     sourceObject     = %source;
         sourceSlot       = 5;
	  };
	  %p.sourceobject = %source;
	  %p.vector = %vec;
	  %p.count = %count+1;
	  return;
   }
   if(%count2 == 1) {
      %vec = vectorscale(%vec,-1);
      %result = containerRayCast(vectoradd(%pos,"0 0 10"), vectoradd(%pos,%vec), $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType, 0);
	  if(!(%result)){
	     %rndvec = getRandom(1, 10)@" "@getRandom(1, 10)@" "@((getRandom() * 5) + 4);
	     %newvec = vectoradd(%vec,%rndvec);
	     %newvec = vectoradd(%pos,%newvec);
	     %p = new LinearFlareProjectile() {
		    dataBlock        = VardisonSubShadowBomb;
		    initialDirection = "0 0 -1";
		    initialPosition  = %newvec;
		    sourceObject     = %source;
   		    sourceSlot       = 5;
	     };
	     %p.sourceobject = %source;
	     %p.vector = %vec;
	     %p.count = %count+1;
	     return;
      }
   }
   else {
      %chance = getrandom(1,4);
      if(%chance <= 2){
	     %nv2 = (getword(%vec, 0) * -1);
	     %nv1 = getword(%vec, 1);
	     %vec = %nv1@" "@%nv2@" 0";
	  }
      else {
	     %nv2 = getword(%vec, 0);
	     %nv1 = (getword(%vec, 1) * -1);
	     %vec = %nv1@" "@%nv2@" 0";
	  }
      %result = containerRayCast(vectoradd(%pos,"0 0 10"), vectoradd(%pos,%vec), $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType, 0);
	  if(!(%result)){
	     %rndvec = getRandom(1, 10)@" "@getRandom(1, 10)@" "@((getRandom() * 5) + 4);
	     %newvec = vectoradd(%vec,%rndvec);
	     %newvec = vectoradd(%pos,%newvec);
	     %p = new LinearFlareProjectile() {
		    dataBlock        = VardisonSubShadowBomb;
		    initialDirection = "0 0 -1";
		    initialPosition  = %newvec;
		    sourceObject     = %source;
   		    sourceSlot       = 5;
	     };
	     %p.sourceobject = %source;
	     %p.vector = %vec;
	     %p.count = %count+1;
	     return;
      }
   }
   %count2++;
   schedule(2, 0, "NapalmFindNewDir", %pos, %vec, %source, %count, %count2);
}

function GOVDoFlameCano(%g, %target) {
   if(!isObject(%g) || %g.getState() $= "dead") {
      return;
   }
   %g.setPosition(VectorAdd(%target.getPosition(), "0 0 70"));
   %Pad = new StaticShape() {
      dataBlock = DeployedSpine;
      scale = ".1 .1 1";
      position = VectorAdd(%target.getPosition(), "0 0 69");
   };
   %g.setMoveState(true);
   %Pad.setCloaked(true);
   %Pad.schedule(3000, "setPosition", vectorSub(%Pad.getPosition(), "0 0 10"));
   %Pad.schedule(4000, "setPosition", vectorSub(%Pad.getPosition(), "0 0 20"));
   %Pad.schedule(5000, "setPosition", vectorSub(%Pad.getPosition(), "0 0 30"));
   %Pad.schedule(6000, "setPosition", vectorSub(%Pad.getPosition(), "0 0 40"));
   %g.schedule(6500, "SetMoveState", false);
   %pad.schedule(6500, "Delete");
   //The Vector Crap
   schedule(2500,0,"DropFlameCano2", %g, %target);
}

function DropFlameCano2(%g, %target) {
   if(!isObject(%g) || %g.getState() $= "dead") {
      return;
   }
   //First, Specify All Directions
   %vec[1] = vectorscale(vectornormalize("1 0 0"), 24);  // +X 0Y
   %vec[2] = vectorscale(vectornormalize("1 1 0"), 24);  // +X +Y
   %vec[3] = vectorscale(vectornormalize("1 -1 0"), 24); // +X -Y
   %vec[4] = vectorscale(vectornormalize("-1 0 0"), 24); // -X 0Y
   %vec[5] = vectorscale(vectornormalize("-1 1 0"), 24); // -X +Y
   %vec[6] = vectorscale(vectornormalize("-1 -1 0"), 24); //-X -Y
   %vec[7] = vectorscale(vectornormalize("0 1 0"), 24);  // 0X +Y
   %vec[8] = vectorscale(vectornormalize("0 -1 0"), 24); // 0X -Y
   //Oh.. long crap
   for(%i = 1; %i <= 8; %i++) {
      %p = new LinearFlareProjectile() {
	      	dataBlock        = ShadowBomb;
	    	initialDirection = "0 0 -30";
	    	initialPosition  = vectorAdd(%g.getPosition(), "0 0 -3");
	    	sourceObject     = %g;
   	    	sourceSlot       = 5;
      };
      %p.vector = %vec[%i];
      %p.count = 1;
      %p.MaxExplode = 15;
   }
}

//The evilness Begins Here
function VardisonAttacks(%boss) {
   if(!isObject(%boss) || %boss.getState() $= "dead") {
      return;
   }
   schedule(23500, 0, "VardisonAttacks", %boss);
   %attack = getRandom(1,5);
   switch(%attack) {
      case 1:
         %target = FindValidTarget(%boss);
         if(isObject(%target.player)) {
            %target = %target.player;
	        %vec = vectorNormalize(vectorSub(%target.getPosition(),%boss.getPosition()));
   	        %p = new SeekerProjectile() {
               dataBlock        = VardisonNightmareMissile;
	           initialDirection = %vec;
	           initialPosition  = %boss.getPosition();
	           sourceObject     = %boss;
	           sourceSlot       = 4;
   	        };
   	        %beacon = new BeaconObject() {
               dataBlock = "SubBeacon";
               beaconType = "vehicle";
               position = %target.getWorldBoxCenter();
            };
   	        %beacon.team = 0;
   	        %beacon.setTarget(0);
   	        MissionCleanup.add(%beacon);
            %p.setObjectTarget(%beacon);
            DemonMotherMissileFollow(%target,%beacon,%p);
         }
      case 2:
         %target = FindValidTarget(%boss);
         if(isObject(%target.player)) {
            %target = %target.player;
	        %vec = vectorNormalize(vectorSub(%target.getPosition(),%boss.getPosition()));
   	        %p = new SeekerProjectile() {
               dataBlock        = VardisonLaserBallMissile;
	           initialDirection = %vec;
	           initialPosition  = %boss.getPosition();
	           sourceObject     = %boss;
	           sourceSlot       = 4;
   	        };
   	        %beacon = new BeaconObject() {
               dataBlock = "SubBeacon";
               beaconType = "vehicle";
               position = %target.getWorldBoxCenter();
            };
   	        %beacon.team = 0;
   	        %beacon.setTarget(0);
   	        MissionCleanup.add(%beacon);
            %p.setObjectTarget(%beacon);
            DemonMotherMissileFollow(%target,%beacon,%p);
         }
      case 3:
         %target = FindValidTarget(%boss);
         if(isObject(%target.player)) {
            %target = %target.player;
	        %vec = vectorNormalize(vectorSub(%target.getPosition(),%boss.getPosition()));
   	        %p = new LinearFlareProjectile() {
               dataBlock        = ShadowBomb;
	           initialDirection = %vec;
	           initialPosition  = %boss.getPosition();
	           sourceObject     = %boss;
	           sourceSlot       = 4;
   	        };
            %p.maxExplode = 2;
         }
      case 4:
         %target = FindValidTarget(%boss);
         if(isObject(%target.player)) {
            %target = %target.player;
	        %vec = vectorNormalize(vectorSub(%target.getPosition(),%boss.getPosition()));
   	        %p = new TracerProjectile() {
               dataBlock        = InsigniaGravityShot;
	           initialDirection = %vec;
	           initialPosition  = %boss.getPosition();
	           sourceObject     = %boss;
	           sourceSlot       = 4;
   	        };
            %p.maxExplode = 2;
         }
      case 5:
         %target = FindValidTarget(%boss);
         if(isObject(%target.player)) {
            %target = %target.player;
	        %vec = vectorNormalize(vectorSub(%target.getPosition(),%boss.getPosition()));
   	        %p = new LinearFlareProjectile() {
               dataBlock        = ShadowBomb;
	           initialDirection = %vec;
	           initialPosition  = %boss.getPosition();
	           sourceObject     = %boss;
	           sourceSlot       = 4;
   	        };
            %p.maxExplode = 4;
         }
   }
}

function VardisonDroneAttacks(%boss) {
   if(!isObject(%boss)) {
      return;
   }
   schedule(10000, 0, "VardisonDroneAttacks", %boss);
   %attack = getRandom(1,2);
   switch(%attack) {
      case 1:
         %target = FindValidTarget(%boss);
         if(isObject(%target.player)) {
            %target = %target.player;
	        %vec = vectorNormalize(vectorSub(%target.getPosition(),%boss.getPosition()));
   	        %p = new SeekerProjectile() {
               dataBlock        = VardisonNightmareMissile;
	           initialDirection = %vec;
	           initialPosition  = %boss.getPosition();
	           sourceObject     = %boss;
	           sourceSlot       = 4;
   	        };
   	        %beacon = new BeaconObject() {
               dataBlock = "SubBeacon";
               beaconType = "vehicle";
               position = %target.getWorldBoxCenter();
            };
   	        %beacon.team = 0;
   	        %beacon.setTarget(0);
   	        MissionCleanup.add(%beacon);
            %p.setObjectTarget(%beacon);
            DemonMotherMissileFollow(%target,%beacon,%p);
         }
      case 2:
         %target = FindValidTarget(%boss);
         if(isObject(%target.player)) {
            %target = %target.player;
	        %vec = vectorNormalize(vectorSub(%target.getPosition(),%boss.getPosition()));
   	        %p = new SeekerProjectile() {
               dataBlock        = VardisonLaserBallMissile;
	           initialDirection = %vec;
	           initialPosition  = %boss.getPosition();
	           sourceObject     = %boss;
	           sourceSlot       = 4;
   	        };
   	        %beacon = new BeaconObject() {
               dataBlock = "SubBeacon";
               beaconType = "vehicle";
               position = %target.getWorldBoxCenter();
            };
   	        %beacon.team = 0;
   	        %beacon.setTarget(0);
   	        MissionCleanup.add(%beacon);
            %p.setObjectTarget(%beacon);
            DemonMotherMissileFollow(%target,%beacon,%p);
         }
      }
}

function FireLaserBallMissile(%boss, %target) {
   if(!isObject(%boss) || %boss.getState() $= "dead") {
      return;
   }
   if(!isObject(%target) || %target.getState() $= "dead") {
      return;
   }
   %vec = vectorNormalize(vectorSub(%target.getPosition(),%boss.getPosition()));
   %p = new SeekerProjectile() {
      dataBlock        = VardisonLaserBallMissile;
      initialDirection = %vec;
      initialPosition  = %boss.getPosition();
      sourceObject     = %boss;
      sourceSlot       = 4;
   };
   %beacon = new BeaconObject() {
      dataBlock = "SubBeacon";
      beaconType = "vehicle";
      position = %target.getWorldBoxCenter();
   };
   %beacon.team = 0;
   %beacon.setTarget(0);
   MissionCleanup.add(%beacon);
   %p.setObjectTarget(%beacon);
   DemonMotherMissileFollow(%target,%beacon,%p);
}

function VardisonDemonAttacks(%boss) {
   if(!isObject(%boss)) {
      return;
   }
   %boss.setMoveState(true);
   schedule(15000, 0, "VardisonDemonAttacks", %boss);
   %attack = getRandom(1,5);
   switch(%attack) {
      case 1:
         %target = FindValidTarget(%boss);
         if(isObject(%target.player)) {
            %target = %target.player;
            FireLaserBallMissile(%boss, %target);
            schedule(2500, 0, "FireLaserBallMissile", %boss, %target);
            schedule(3500, 0, "FireLaserBallMissile", %boss, %target);
            schedule(5000, 0, "FireLaserBallMissile", %boss, %target);
            schedule(5100, 0, "FireLaserBallMissile", %boss, %target);
            %boss.schedule(5100, "SetMoveState", false);
            MessageAll('MsgVardison', "\c4"@$TWM2::BossName["Vardison"]@": I've got some missiles for you "@%target.client.namebase@".");
            return;
         }
         %boss.schedule(1, "SetMoveState", false);
      case 2:
         %target = FindValidTarget(%boss);
         if(isObject(%target.player)) {
            %target = %target.player;
	        %vec = vectorNormalize(vectorSub(%target.getPosition(),%boss.getPosition()));
   	        %p = new SeekerProjectile() {
               dataBlock        = VardisonNightmareMissile;
	           initialDirection = %vec;
	           initialPosition  = %boss.getPosition();
	           sourceObject     = %boss;
	           sourceSlot       = 4;
   	        };
   	        %beacon = new BeaconObject() {
               dataBlock = "SubBeacon";
               beaconType = "vehicle";
               position = %target.getWorldBoxCenter();
            };
   	        %beacon.team = 0;
   	        %beacon.setTarget(0);
   	        MissionCleanup.add(%beacon);
            %p.setObjectTarget(%beacon);
            DemonMotherMissileFollow(%target,%beacon,%p);
            MessageAll('MsgVardison', "\c4"@$TWM2::BossName["Vardison"]@": It's time to invoke darkness upon "@%target.client.namebase@".");
            %boss.schedule(1000, "SetMoveState", false);
            return;
         }
         %boss.schedule(1, "SetMoveState", false);
      case 3:
         setgravity(-1000);
         MessageAll('MsgVardison', "\c4"@$TWM2::BossName["Vardison"]@": I'll disorient you all!");
         schedule(3000, 0, "SetGravity", 1000);
         schedule(7500, 0, "SetGravity", -20);
         %boss.schedule(7500, "SetMoveState", false);
         //%boss.InvokeLoop = InvokeStillwallLoop(%boss);
         schedule(7500, 0, "Cancel", %boss.InvokeLoop);
      case 4:
         %target = FindValidTarget(%boss);
         if(isObject(%target.player)) {
            %target = %target.player;
   	        %p = new LinearFlareProjectile() {
               dataBlock        = HyperDevestatorBeam;
	           initialDirection = "0 0 -10";
	           initialPosition  = vectoradd(%target.getPosition(), "0 0 500");
	           sourceObject     = %boss;
	           sourceSlot       = 4;
   	        };
            %boss.schedule(3000, "SetMoveState", false);
            MessageAll('MsgVardison', "\c4"@$TWM2::BossName["Vardison"]@": Your time has come "@%target.client.namebase@".");
            return;
         }
         %boss.schedule(1, "SetMoveState", false);
      case 5:
         %target = FindValidTarget(%boss);
         if(isObject(%target.player)) {
            %target = %target.player;
            for(%i = 0; %i < 25; %i++) {
               schedule(50+(%i*150), 0, "UnleashLaser", %boss, %target);
            }
            %boss.schedule(10000, "SetMoveState", false);
            MessageAll('MsgVardison', "\c4"@$TWM2::BossName["Vardison"]@": BLAAAAHAAHAHAHAAHA!!!");
            return;
         }
         %boss.schedule(1, "SetMoveState", false);
   }
}

function UnleashLaser(%boss, %toDie) {
   if(!isObject(%boss) || %boss.getState() $= "dead") {
      return;
   }
   if(!isObject(%toDie) || %toDie.getState() $= "dead") {
      return;
   }
   %vec = vectorNormalize(vectorSub(%toDie.getPosition(),%boss.getPosition()));
   %p = new LinearFlareProjectile() {
       dataBlock        = SuperlaserProjectile;
       initialDirection = %vec;
       initialPosition  = %boss.getPosition();
       sourceObject     = %boss;
       sourceSlot       = 4;
   };
}

function InvokeStillwallLoop(%boss) {
   if(!isObject(%boss) || %boss.getState() $= "dead") {
      return;
   }
   %boss.setVelocity("0 0 0");
   %boss.InvokeLoop = schedule(100, 0, "InvokeStillwallLoop", %boss);
}
