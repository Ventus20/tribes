//DATABLOCKS
datablock ParticleData(InflictionNightmareGlobeSmoke)
{
dragCoefficient = 50;/////////-----------------------
gravityCoefficient = 0.0;
inheritedVelFactor = 1.0;
constantAcceleration = 0.0;
lifetimeMS = 5050;
lifetimeVarianceMS = 0;
useInvAlpha = true;
spinRandomMin = -360.0;
spinRandomMax = 360.0;
textureName = "particleTest";
colors[0] = "0.5 0.1 0.9 1.0";
colors[1] = "0.5 0.1 0.9 1.0";
colors[2] = "0.5 0.1 0.9 1.0";
colors[3] = "0.5 0.1 0.9";
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

datablock ParticleEmitterData(InfNightmareGlobeEmitter)
{
ejectionPeriodMS = 0.1;
periodVarianceMS = 0;
ejectionVelocity = 0.0;
velocityVariance = 0.0;
ejectionOffset = 5;
thetaMin = 0;
thetaMax = 180;
overrideAdvances = false;
particles = "InflictionNightmareGlobeSmoke";
};


datablock ParticleData(NightmareGlobeSmoke)
{
dragCoefficient = 50;/////////-----------------------
gravityCoefficient = 0.0;
inheritedVelFactor = 1.0;
constantAcceleration = 0.0;
lifetimeMS = 5050;
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

datablock ParticleEmitterData(NightmareGlobeEmitter)
{
ejectionPeriodMS = 0.1;
periodVarianceMS = 0;
ejectionVelocity = 0.0;
velocityVariance = 0.0;
ejectionOffset = 5;
thetaMin = 0;
thetaMax = 180;
overrideAdvances = false;
particles = "NightmareGlobeSmoke";
};

//Yvex STUFF.. MORE
datablock ParticleData(GreenEmitParticle)
{
   dragCoeffiecient     = 1;
   gravityCoefficient   = -0.3;   // rises slowly
   inheritedVelFactor   = 0;

   lifetimeMS           =  300;
   lifetimeVarianceMS   =  0;
   useInvAlpha          =  false;
   spinRandomMin        = 0.0;
   spinRandomMax        = 0.0;

   animateTexture = false;

   textureName = "flareBase"; // "special/Smoke/bigSmoke"

   colors[0]     = "0 1 0";
   colors[1]     = "0 1 0";
   colors[2]     = "0 1 0";

   sizes[0]      = 0.8;
   sizes[1]      = 0.8;
   sizes[2]      = 0.8;

   times[0]      = 0.0;
   times[1]      = 1.0;
   times[2]      = 5.0;

};

datablock ParticleEmitterData(PulseGreenEmitter)
{
   ejectionPeriodMS = 2;
   periodVarianceMS = 1;

   ejectionVelocity = 10;
   velocityVariance = 0;

   thetaMin         = 89.0;
   thetaMax         = 90.0;

   orientParticles = false;

   particles = "GreenEmitParticle";
};

datablock LinearFlareProjectileData(KillerPulse)
{
   scale               = "1.0 1.0 1.0";
   faceViewer          = false;
   directDamage        = 0.00001;
   hasDamageRadius     = false;
   indirectDamage      = 0.6;
   damageRadius        = 10.0;
   kickBackStrength    = 100.0;
   directDamageType    = $DamageType::Admin;
   indirectDamageType  = $DamageType::Admin;

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

   baseEmitter         = PulseGreenEmitter;
   delayEmitter        = PulseGreenEmitter;
   bubbleEmitter       = PulseGreenEmitter;

   //activateDelayMS = 100;
   activateDelayMS = -1;

   size[0]           = 0.2;
   size[1]           = 0.2;
   size[2]           = 0.2;


   numFlares         = 15;
   flareColor        = "0 1 0";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   sound        = MissileProjectileSound;
   fireSound    = PlasmaFireSound;
   wetFireSound = PlasmaFireWetSound;

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "0 1 0";

};

datablock ParticleData(PurpleNightmareEmitParticle)
{
   dragCoeffiecient     = 1;
   gravityCoefficient   = -0.3;   // rises slowly
   inheritedVelFactor   = 0;

   lifetimeMS           =  300;
   lifetimeVarianceMS   =  0;
   useInvAlpha          =  false;
   spinRandomMin        = 0.0;
   spinRandomMax        = 0.0;

   animateTexture = false;

   textureName = "flareBase"; // "special/Smoke/bigSmoke"

   colors[0] = "0.5 0.1 0.9 1.0";
   colors[1] = "0.5 0.1 0.9 1.0";
   colors[2] = "0.5 0.1 0.9";

   sizes[0]      = 0.4;
   sizes[1]      = 0.4;
   sizes[2]      = 0.4;

   times[0]      = 0.0;
   times[1]      = 1.0;
   times[2]      = 5.0;

};

datablock ParticleEmitterData(YvexSniperEmitter)
{
   ejectionPeriodMS = 2;
   periodVarianceMS = 1;

   ejectionVelocity = 10;
   velocityVariance = 0;

   thetaMin         = 89.0;
   thetaMax         = 90.0;

   orientParticles = false;

   particles = "PurpleNightmareEmitParticle";
};

datablock LinearFlareProjectileData(YvexSniperShot)
{
   projectileShapeName = "weapon_missile_projectile.dts";
   scale               = "3.0 5.0 3.0";
   faceViewer          = true;
   directDamage        = 0.01;
   kickBackStrength    = 4000.0;
   DirectDamageType    = $DamageType::Zombie;

   explosion           = "BlasterExplosion";

   dryVelocity       = 150.0;
   wetVelocity       = -1;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 10000;
   lifetimeMS        = 10000;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   activateDelayMS = 100;
   activateDelayMS = -1;

   baseEmitter = YvexSniperEmitter;

   size[0]           = 0.0;
   size[1]           = 0.0;
   size[2]           = 0.0;


   numFlares         = 0;
   flareColor        = "0.0 0.0 0.0";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

	sound        = PlasmaProjectileSound;
   fireSound    = PlasmaFireSound;
   wetFireSound = PlasmaFireWetSound;

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "1 0.75 0.25";
};

datablock SeekerProjectileData(YvexZombieMakerMissile)
{
   casingShapeName     = "weapon_missile_casement.dts";
   projectileShapeName = "weapon_missile_projectile.dts";
   hasDamageRadius     = true;
   indirectDamage      = 0.5;
   damageRadius        = 5.0;
   radiusDamageType    = $DamageType::Zombie;
   kickBackStrength    = 2000;

   explosion           = "MissileExplosion";
   splash              = MissileSplash;
   velInheritFactor    = 1.0;    // to compensate for slow starting velocity, this value
                                 // is cranked up to full so the missile doesn't start
                                 // out behind the player when the player is moving
                                 // very quickly - bramage

   baseEmitter         = MortarSmokeEmitter;
   delayEmitter        = MissileFireEmitter;
   puffEmitter         = MissilePuffEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;
   bubbleEmitTime      = 1.0;

   exhaustEmitter      = MissileLauncherExhaustEmitter;
   exhaustTimeMs       = 300;
   exhaustNodeName     = "muzzlePoint1";

   lifetimeMS          = 30000; // z0dd - ZOD, 4/14/02. Was 6000
   muzzleVelocity      = 30.0;
   maxVelocity         = 35.0; // z0dd - ZOD, 4/14/02. Was 80.0
   turningSpeed        = 23.0;
   acceleration        = 15.0;

   proximityRadius     = 2.5;

   terrainAvoidanceSpeed = 10;
   terrainScanAhead      = 7;
   terrainHeightFail     = 1;
   terrainAvoidanceRadius = 3;

   flareDistance = 40;
   flareAngle    = 20;
   minSeekHeat   = 0.0;

   sound = MissileProjectileSound;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0.2 0.05 0";

   useFlechette = true;
   flechetteDelayMs = 250;
   casingDeb = FlechetteDebris;

   explodeOnWaterImpact = false;
};

datablock PlayerData(YvexZombieArmor) : LightMaleHumanArmor       /// ooooo scary
{
   boundingBox = "1.63 1.63 2.6";
   maxDamage = 500.0;
   minImpactSpeed = 35;
   shapeFile = "medium_male.dts";

   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData   = HeavyBiodermFootprint;
   decalOffset = 0.4;

   waterBreathSound = WaterBreathBiodermSound;

   damageScale[$DamageType::W1700] = 3.0;

	max[RepairKit]			= 0;
	max[Mine]				= 0;
	max[Grenade]			= 0;
	max[SmokeGrenade]			= 0;
	max[BeaconSmokeGrenade]		= 0;
	max[Blaster]			= 0;
	max[Plasma]				= 0;
	max[PlasmaAmmo]			= 0;
	max[Disc]				= 0;
	max[DiscAmmo]			= 0;
	max[SniperRifle]			= 0;
	max[GrenadeLauncher]		= 0;
	max[GrenadeLauncherAmmo]	= 0;
	max[Mortar]				= 0;
	max[MortarAmmo]			= 0;
	max[MissileLauncher]		= 0;
	max[MissileLauncherAmmo]	= 0;
	max[Chaingun]			= 0;
	max[ChaingunAmmo]			= 0;
	max[RepairGun]			= 0;
	max[CloakingPack]			= 0;
	max[SensorJammerPack]		= 0;
	max[EnergyPack]			= 0;
	max[RepairPack]			= 0;
	max[ShieldPack]			= 0;
	max[AmmoPack]			= 0;
	max[SatchelCharge]		= 0;
	max[MortarBarrelPack]		= 0;
	max[MissileBarrelPack]		= 0;
	max[AABarrelPack]			= 0;
	max[PlasmaBarrelPack]		= 0;
	max[ELFBarrelPack]		= 0;
	max[artillerybarrelpack]	= 0;
	max[MedPack]			= 0;
	max[InventoryDeployable]	= 0;
	max[MotionSensorDeployable]	= 0;
	max[PulseSensorDeployable]	= 0;
	max[TurretOutdoorDeployable]	= 0;
	max[TurretIndoorDeployable]	= 0;
	max[FlashGrenade]			= 0;
	max[ConcussionGrenade]		= 0;
	max[FlareGrenade]			= 0;
	max[TargetingLaser]		= 0;
	max[ELFGun]				= 0;
	max[ShockLance]			= 0;
	max[CameraGrenade]		= 0;
	max[Beacon]				= 0;
	max[flamerAmmoPack]		= 0;
	max[ParachutePack]		= 0;
	max[ConstructionTool]		= 0;
	max[MergeTool]			= 0;
	max[NerfGun]			= 0;
	max[NerfBallLauncher]		= 0;
	max[NerfBallLauncherAmmo]	= 0;
	max[SuperChaingun]		= 0;
	max[SuperChaingunAmmo]		= 0;
	max[RPChaingun]			= 0;
	max[RPChaingunAmmo]		= 0;
	max[MGClip]				= 0;
	max[LSMG]				= 0;
	max[LSMGAmmo]			= 0;
	max[LSMGClip]			= 0;
	max[snipergun]			= 0;
	max[snipergunAmmo]		= 0;
	max[Bazooka]			= 0;
	max[BazookaAmmo]			= 0;
	max[BunkerBuster]				= 0;
	max[MG42]				= 0;
	max[MG42Ammo]			= 0;
	max[SPistol]			= 0;
	max[Pistol]				= 0;
	max[PistolAmmo]			= 0;
	max[Pistolclip]			= 0;
	max[flamer]				= 0;
	max[flamerAmmo]			= 0;
	max[AALauncher]			= 0;
	max[AALauncherAmmo]		= 0;
	max[melee]				= 0;
	max[SOmelee]			= 0;
	max[KriegRifle]			= 0;
	max[KriegAmmo]			= 0;
	max[Rifleclip]			= 0;
	max[Shotgun]			= 0;
	max[ShotgunAmmo]			= 0;
	max[ShotgunClip]			= 0;
	max[RShotgun]			= 0;
	max[RShotgunAmmo]			= 0;
	max[RShotgunClip]			= 0;
	max[LMissileLauncher]		= 0;
	max[LMissileLauncherAmmo]	= 0;
	max[HRPChaingun]			= 0;
	max[RPGAmmo]			= 0;
	max[RPGItem]			= 0;
	max[spineDeployable]		= 0;
	max[mspineDeployable]		= 0;
	max[wWallDeployable]		= 0;
	max[floorDeployable]		= 0;
	max[WallDeployable]		= 0;
      max[DoorDeployable]           = 0;
	max[TurretLaserDeployable]	= 0;
	max[TurretMissileRackDeployable]= 0;
	max[DiscTurretDeployable]	= 0;
	max[EnergizerDeployable]	= 0;
	max[TreeDeployable]		= 0;
	max[CrateDeployable]		= 0;
	max[DecorationDeployable]	= 0;
	max[LogoProjectorDeployable]	= 0;
	max[LightDeployable]		= 0;
	max[TripwireDeployable]		= 0;
	max[TelePadPack]			= 0;
	max[TurretBasePack]		= 0;
	max[LargeInventoryDeployable]	= 0;
	max[GeneratorDeployable]	= 0;
	max[SolarPanelDeployable]	= 0;
	max[SwitchDeployable]		= 0;
	max[MediumSensorDeployable]	= 0;
	max[LargeSensorDeployable]	= 0;
	max[SpySatelliteDeployable]	= 0;
	max[JumpadDeployable]		= 0;
	max[EscapePodDeployable]	= 0;
	max[ForceFieldDeployable]	= 0;
	max[GravityFieldDeployable]	= 0;
      max[VehiclePadPack]		= 0;
};

//CREATION
function SpawnYvex(%position) {
	%Zombie = new player(){
	   Datablock = "YvexZombieArmor";
	};
	%Cpos = vectorAdd(%position, "0 0 5");
    MessageAll('MsgYvexreturn', "\c4"@$TWM2::ZombieName[7]@": Did you miss me? Because... I WANT MY REVENGE!!!");
    superYvexsummon(%Zombie);
	%command = "Yvexmovetotarget";
    %zombie.ticks = 0;
    InitiateBoss(%zombie, "Yvex");
    
   %Zombie.team = 30;
   %zname = $TWM2::ZombieName[7]; // <- To Hosts, Enjoy, You can
                                      //Change the Zombie Names now!!!
   %zombie.target = createTarget(%zombie, %zname, "", "Derm3", '', %zombie.team, PlayerSensor);
   setTargetSensorData(%zombie.target, PlayerSensor);
   setTargetSensorGroup(%zombie.target, 30);
   setTargetName(%zombie.target, addtaggedstring(%zname));
   setTargetSkin(%zombie.target, 'Horde');
   //
   %zombie.type = %type;
   %Zombie.setTransform(%cpos);
   %zombie.canjump = 1;
   %zombie.hastarget = 1;
   %zombie.isZombie = 1;
   MissionCleanup.add(%Zombie);
   schedule(1000, %zombie, %command, %zombie);
}


//AI

function Yvexmovetotarget(%zombie){
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
      MessageAll('msgYvexAttack', "\c4"@$TWM2::ZombieName[7]@": I shall not fall to my end!");
   }
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.hastarget != 1 && %closestdistance >= 10 && %closestdistance <= 150 && %zombie.ticks >= 30){
       %attack = getRandom(1, 3);
       switch(%attack) {
          case 1:
	         YvexZombieFire(%zombie,%closestclient);
          case 2:
             YvexZombieFireCurse(%zombie,%closestclient);
          case 3:
             YvexZombieFireMissile(%zombie,%closestclient);
       }
       %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	}
	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   LZDoMoan(%zombie);

      %vector = ZgetFacingDirection(%zombie,%closestClient,%pos);

	if (%closestdistance >= 10 && %closestdistance <= 150 && %zombie.ticks >= 30){
       %attack = getRandom(1, 3);
       %zombie.ticks = 0;
       switch(%attack) {
          case 1:
	         YvexZombieFire(%zombie,%closestclient);
          case 2:
             YvexZombieFireCurse(%zombie,%closestclient);
          case 3:
             YvexZombieFireMissile(%zombie,%closestclient);
       }
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	}
    else if(%closestdistance > 150 && %zombie.ticks >= 30) {
       %action = getRandom(1, 3);
       %zombie.ticks = 0;
       switch(%action) {
          case 1:
             YvexZombieFireMissile(%zombie, %closestclient);
             schedule(250,0,"YvexZombieFireMissile", %zombie,%closestclient);
             schedule(500,0,"YvexZombieFireMissile", %zombie,%closestclient);
             MessageAll('msgYvexAttack', "\c4"@$TWM2::ZombieName[7]@": Here comes the horde!!!");
          case 2:
         	 %zombie.startFade(400, 0, true);
	         %zombie.startFade(1000, 0, false);
	         %zombie.setPosition(vectorAdd(vectoradd(%closestclient.getPosition(), "0 0 20"), getRandomPosition(25, 1)));
             MessageAll('msgYvexAttack', "\c4"@$TWM2::ZombieName[7]@": You cannot hide from me!");
             %zombie.setVelocity("0 0 0");
          case 3:
             MessageAll('msgYvexAttack', "\c4"@$TWM2::ZombieName[7]@": Don't move..."@%closestclient.client.namebase@".");
             YvexRiftPulse(%closestClient.client, 0);
       }
    }
    %zombie.ticks++;
	%vector = vectorscale(%vector, $Zombie::DForwardSpeed / 2);
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= ($Zombie::DForwardSpeed / 3 * 2))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
   %zombie.moveloop = schedule(500, %zombie, "Yvexmovetotarget", %zombie);
}

//ATTACKS
function YvexZombieFire(%zombie,%target){
   %vec = vectorsub(%target.getworldboxcenter(),%zombie.getMuzzlePoint(0));
   %vec = vectoradd(%vec, vectorscale(%target.getvelocity(),vectorlen(%vec)/100));
   %p = new LinearFlareProjectile() {
       dataBlock        = YvexSniperShot;
       initialDirection = %vec;
       initialPosition  = %zombie.getMuzzlePoint(0);
       sourceObject     = %zombie;
       sourceSlot       = 0;
   };
}

function YvexZombieFireCurse(%zombie,%target){
   MessageAll('msgWTFH', "\c4"@$TWM2::ZombieName[7]@": DIE!!!");
   %vec = vectorsub(%target.getworldboxcenter(),%zombie.getMuzzlePoint(0));
   %vec = vectoradd(%vec, vectorscale(%target.getvelocity(),vectorlen(%vec)/100));
   %p = new LinearFlareProjectile() {
       dataBlock        = KillerPulse;
       initialDirection = %vec;
       initialPosition  = %zombie.getMuzzlePoint(0);
       sourceObject     = %zombie;
       sourceSlot       = 0;
   };
}

function YvexZombieFireMissile(%obj, %target){
   if(!isObject(%obj))
	return;
   if(%obj.getState() $= "dead")
	return;

	%vec = vectorNormalize(vectorSub(%target.getPosition(),%obj.getPosition()));
   	%p = new SeekerProjectile() {
	   dataBlock        = YvexZombieMakerMissile;
	   initialDirection = %vec;
	   initialPosition  = %obj.getMuzzlePoint(4);
	   sourceObject     = %obj;
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

function YvexRiftPulse(%targ, %ct) {
   if(!isObject(%targ.player)) {
      return;
   }
   %pl = %targ.player;
   %pl.setMoveState(true);
   %ct++;
   if(%ct > 30) {
      %pl.setMoveState(false);
   }
   schedule(500, 0, "YvexRiftPulse", %targ, %ct);
}

function YvexSniperShot::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal) {
   if(!isplayer(%targetObject)) {
      return;
   }
   %targ = %targetObject.client;
   %Zombie = %projectile.sourceObject;
   %targ.nightmareticks = 0;
   Yvexnightmareloop(%zombie,%targ);
       %randMessage = getrandom(3)+1;
          switch(%randMessage) {
          case 1:
          MessageAll('MessageAll', "\c4"@$TWM2::ZombieName[7]@": Let the revenge begin, "@%targ.namebase@".");
          case 2:
          MessageAll('MessageAll', "\c4"@$TWM2::ZombieName[7]@": Taste my vengance... "@%targ.namebase@".");
          case 3:
          MessageAll('MessageAll', "\c4"@$TWM2::ZombieName[7]@": Sleep Forever... "@%targ.namebase@".");
          default:
          MessageAll('MessageAll', "\c4"@$TWM2::ZombieName[7]@": This Nightmare will lock you forever "@%targ.namebase@"!");
          }
}

function Yvexnightmareloop(%zombie,%viewer) {
   %enum = getRandom(1,5);
   switch(%enum) {
   case 1:
   %emote = "sitting";
   case 2:
   %emote = "standing";
   case 3:
   %emote = "death3";
   case 4:
   %emote = "death2";
   case 5:
   %emote = "death4";
   }
   if(!isobject(%viewer.player) || %viewer.player.getState() $= "dead") {
   %viewer.nightmared = 0;
   return;
   }
   if(!isobject(%zombie)) {
   %viewer.nightmared = 0;
   %viewer.player.setMoveState(false);
   return;
   }
   if(%viewer.nightmareticks > 30) {
   %viewer.player.setMoveState(false);
   %viewer.nightmareticks = 0;
   %viewer.nightmared = 0;
   return;
   }
   %c = createEmitter(%viewer.player.position,NightmareGlobeEmitter,"1 0 0");      //Rotate it
   MissionCleanup.add(%c); // I think This should be used
   schedule(500,0,"killit",%c);
   %viewer.nightmareticks++;
   %viewer.player.setMoveState(true);
   %viewer.nightmared = 1;
   %viewer.player.setActionThread(%emote,true);
   %viewer.player.setWhiteout(1.8);
   %viewer.player.setDamageFlash(1.5);

   %zombie.playShieldEffect("1 1 1");
   serverPlay3D(NightmareScreamSound, %viewer.player.position);
   schedule(500,0,"Yvexnightmareloop",%zombie, %viewer);
   %viewer.player.damage(0, %viewer.player.position, 0.01, $DamageType::Zombie);
   %zombie.setDamageLevel(%zombie.getDamageLevel() - 0.1);

   BottomPrint(%viewer,"You are locked in "@$TWM2::ZombieName[7]@"'s Nightmare.",5,1);
   schedule(1, 0, "messageclient", %viewer, 'MsgClient', "~wvoice/fem1/avo.deathcry_02.wav");
   schedule(5, 0, "messageclient", %viewer, 'MsgClient', "~wvoice/fem2/avo.deathcry_02.wav");
   schedule(10, 0, "messageclient", %viewer, 'MsgClient', "~wvoice/fem3/avo.deathcry_02.wav");
   schedule(15, 0, "messageclient", %viewer, 'MsgClient', "~wvoice/fem4/avo.deathcry_02.wav");
   schedule(20, 0, "messageclient", %viewer, 'MsgClient', "~wvoice/fem5/avo.deathcry_02.wav");
   schedule(25, 0, "messageclient", %viewer, 'MsgClient', "~wvoice/male1/avo.deathcry_02.wav");
   schedule(30, 0, "messageclient", %viewer, 'MsgClient', "~wvoice/male2/avo.deathcry_02.wav");
   schedule(35, 0, "messageclient", %viewer, 'MsgClient', "~wvoice/male3/avo.deathcry_02.wav");
   schedule(40, 0, "messageclient", %viewer, 'MsgClient', "~wvoice/male4/avo.deathcry_02.wav");
   schedule(45, 0, "messageclient", %viewer, 'MsgClient', "~wvoice/male5/avo.deathcry_02.wav");
   schedule(50, 0, "messageclient", %viewer, 'MsgClient', "~wvoice/derm1/avo.deathcry_02.wav");
   schedule(55, 0, "messageclient", %viewer, 'MsgClient', "~wvoice/derm2/avo.deathcry_02.wav");
   schedule(60, 0, "messageclient", %viewer, 'MsgClient', "~wvoice/derm3/avo.deathcry_02.wav");
}

function superYvexsummon(%Yvex) {
if(!isobject(%Yvex) || %Yvex.getState() $= "dead") {
return;
}
%type = GetRandom(1, 9);
if(%type > 5) {
   %type += 3;
   if(%type == 10) { //summoners don;t summon more summoners
      %type = 13;
   }
}
%msg = getrandom(1,3);
switch(%msg) {
case 1:
messageall('YvexMsg',"\c4"@$TWM2::ZombieName[7]@": Enlisted for revenge... ATTACK");
case 2:
messageall('YvexMsg',"\c4"@$TWM2::ZombieName[7]@": Attack my soldiers.. REVENGE is ours");
case 3:
messageall('YvexMsg',"\c4"@$TWM2::ZombieName[7]@": Take out the enemy, ALL OF THEM!");
}
schedule(40000,0,"superYvexsummon",%Yvex);
for(%i=0;%i<5;%i++) {
%pos = vectoradd(%Yvex.getPosition(),getRandomPosition(10,1));
%fpos = vectoradd("0 0 5",%pos);
StartAZombie(%fpos, %type);
}
%Yvex.setMoveState(true);
%Yvex.setActionThread($Zombie::RAAMThread,true);
%Yvex.schedule(3500, "setMoveState", false);
}

function KillerPulse::onCollision(%data,%projectile,%targetObject,%modifier,%position,%normal) {
   if (%targetObject.getClassName() $= "Player") {
      messageall('msgkillcurse', "\c5"@%targetobject.client.namebase@" Took a fatal Hit from "@$TWM2::ZombieName[7]@"'s Dark Energy");
      %targetObject.throwWeapon();
      %targetObject.clearinventory();
      killingcurseloop(%targetObject);
   }
}

function killingcurseloop(%player) {
   if(isObject(%player)) {
      %player.disablemove(true);
   if (%player.getState() $= "dead")
      return;
      if(isObject(%player)){
         %player.setActionThread("Death2");
         if(%player.beats == 1) {
            messageclient(%player.client, 'MsgClient', "\c2You feel the life slowly leave you.");
            messageclient(%player.client, 'MsgClient', "~wfx/misc/heartbeat.wav");
         }
         if(%player.beats < 10)
            %player.setWhiteOut(%player.beats * 0.2);
         else {
            %player.setDamageFlash(1);
            %player.scriptKill(0);
         }
      }
      %player.beats++;
      Schedule(600,0,killingcurseloop,%player);
   }
}

function YvexZombieMakerMissile::OnExplode(%data, %proj, %pos, %mod) {
   %c = CreateEmitter(%pos, NightmareGlobeEmitter, "0 0 1");
   %rand = getRandom(1, 6);
   %c.schedule(%rand * 750, "delete");
   for(%i = 0; %i < %rand; %i++) {
      %time = %i * 750;
       %type = GetRandom(1, 9);
       if(%type > 5) {
          %type += 3;
          if(%type == 10) { //summoners don;t summon more summoners
             %type = 13;
          }
       }
      schedule(%time, 0, "StartAZombie", vectoradd(%pos, "0 0 1"), %type);
   }
}
