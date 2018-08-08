datablock ParticleData(PBCParticle) {
	dragCoefficient = 0.5;
	WindCoefficient = 0;
	gravityCoefficient  = 0.0;
	inheritedVelFactor  = 1;
	constantAcceleration = 0;
	lifetimeMS      = 3000;
	lifetimeVarianceMS  = 0;
	textureName     = "special/lightning1frame2";
	useInvAlpha = 0;

	spinRandomMin = -800;
	spinRandomMax = 800;

	spinspeed = 50;
	colors[0]   = "0.1 1.0 0.1 1.0";
	colors[1]   = "0.6 0.9 0.6 1.0";
	colors[2]   = "0.8 0.8 1.0 1.0";
	colors[3]   = "0.8 0.8 1.0 0.0";
	sizes[0]   = 0.5;
	sizes[1]   = 1;
	sizes[2]   = 1.5;
	sizes[3]   = 1.5;
	times[0]   = 0.0;
	times[1]   = 0.1;
	times[2]   = 0.3;
	times[3]   = 1.0;
};

datablock ParticleEmitterData(PBCExpEmitter) {
   ejectionPeriodMS = 2;
   periodVarianceMS = 0;

   ejectionVelocity = 2.5;
   velocityVariance = 2.5;

   thetaMin         = 0.0;
   thetaMax         = 180.0;

   lifetimeMS       = 200;

   particles = "PBCParticle";
};

datablock SeekerProjectileData(LordRogStiloutte) {
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

   lifetimeMS          = 20000; // z0dd - ZOD, 4/14/02. Was 6000
   muzzleVelocity      = 10.0;
   maxVelocity         = 80.0; // z0dd - ZOD, 4/14/02. Was 80.0
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

datablock PlayerData(LordRogZombieArmor) : LightMaleHumanArmor {
   boundingBox = "1.63 1.63 2.6";
   maxDamage = 650.0;
   minImpactSpeed = 35;
   shapeFile = "bioderm_heavy.dts";

   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData   = HeavyBiodermFootprint;
   decalOffset = 0.4;

   waterBreathSound = WaterBreathBiodermSound;

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


function SpawnLordRog(%position) {
	%Zombie = new player(){
	   Datablock = "LordRogZombieArmor";
	};
	%Cpos = vectorAdd(%position, "0 0 5");
    MessageAll('MsgDarkraireturn', "\c4"@$TWM2::ZombieName[8]@": I AM ALIVE!!! I SHALL KILL YOU ALL");

    %zombie.iszombie = 1;
    StartLRAbilities(%zombie);

	%command = "LordRogmovetotarget";

    %zombie.ticks = 0;
    InitiateBoss(%zombie, "LordRog");

   %Zombie.team = 30;
   %zname = $TWM2::ZombieName[8]; // <- To Hosts, Enjoy, You can
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

function LordRogmovetotarget(%zombie){
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
      MessageAll('msgDarkraiAttack', "\c4"@$TWM2::ZombieName[8]@": You think I will fall to my death!?!?");
   }
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;
   if(%closestDistance <= $zombie::detectDist){
   
       //Sword Mount / Unmount
       if(%closestDistance < 12) {
          if(!%zombie.ImageMounted) {
             %zombie.ImageMounted = 1;
             %zombie.mountImage(BoVSwing, 7);
             ServerPlay3D(BlasterSwitchSound, %zombie.getPosition());
          }
       }
       else {
          %zombie.unMountImage(7);
          %zombie.ImageMounted = 0;
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
   %zombie.moveloop = schedule(500, %zombie, "LordRogmovetotarget", %zombie);
}


function ResetShield(%zombie) {
   %zombie.rapiershield = 1;
}

function RogShieldUpdate(%zombie) {
   if(!isobject(%zombie) || %zombie.getState() $= "Dead") {
      return;
   }
   if(%zombie.cantRestore) {
      return;
   }
   if(!%zombie.rapiershield) {
      schedule(100,0,"RogShieldUpdate",%zombie);
      return;
   }
   %zombie.playShieldEffect("1 1 1");
   schedule(100,0,"RogShieldUpdate",%zombie);
}

function resetRogField(%Z) {
   %z.rapiershield = 1;
}

function superLordRogSummon(%Rog) {
   if(!isobject(%Rog) || %Rog.getState() $= "dead") {
      return;
   }
   %type = GetRandom(1, 9);
   if(%type > 5) {
      %type += 3;
      if(%type == 10) { //summoners don;t summon more summoners
         %type = 13;
      }
   }
   messageall('RogMsg',"\c4"@$TWM2::ZombieName[8]@": Attack my target!");
   for(%i=0;%i<5;%i++) {
      %pos = vectoradd(%Rog.getPosition(),getRandomPosition(10,1));
      %fpos = vectoradd("0 0 5",%pos);
      StartAZombie(%fpos, %type);
   }
   %Rog.setMoveState(true);
   %Rog.setActionThread($Zombie::RogThread,true);
   %Rog.schedule(3500, "SetMoveState", false);
}

function StartLRAbilities(%zombie) {
   if(!isobject(%zombie) || %zombie.getState() $= "dead") {
   return;
   }
   %z = %zombie; //< Im lazy =-P
   %z.setVelocity("0 0 0");
   superLordRogSummon(%z);
   %rand = getRandom(1,9);
   switch(%rand) {
      case 1:
      %target = FindValidTarget(%z);
      if(isObject(%target.player) && !%target.ignoredbyZombs) {
         MessageAll('MessageAll', "\c4"@$TWM2::ZombieName[8]@": Launch!");
         %SPos1 = vectorAdd(%z.getPosition(),"1 0 0");
         %SPos2 = vectorAdd(%z.getPosition(),"-1 0 0");
   	      %p1 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRogStiloutte;
           initialDirection = "0 0 1";
           initialPosition  = %SPos1;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
   	      %p2 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRogStiloutte;
           initialDirection = "0 0 1";
           initialPosition  = %SPos2;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
          MissionCleanup.add(%p1);
          MissionCleanup.add(%p2);
          schedule(5000,0,"MissileDrop",%p1, %target.player);
          schedule(5000,0,"MissileDrop",%p2, %target.player);
       }
       else {
          MessageAll('MessageAll', "\c4"@$TWM2::ZombieName[8]@": Fools, you cannot withstand my power!");
       }
      case 2:
      %target = FindValidTarget(%z);
      if(isObject(%target.player) && !%target.ignoredbyZombs) {
         %z.laserStormSount = 0;
         MessageAll('MessageAll', "\c4"@$TWM2::ZombieName[8]@": Laser Storm Begin!");
         LRLaserStorm(%z, %target.player);
       }
       else {
          MessageAll('MessageAll', "\c4"@$TWM2::ZombieName[8]@": Fools, you cannot withstand my power!");
       }
      case 3:
      %target = FindValidTarget(%z);
      if(isObject(%target.player) && !%target.ignoredbyZombs) {
         MessageAll('MessageAll', "\c4"@$TWM2::ZombieName[8]@": Metros Maul!");
         %fpos = vectoradd(%target.player.getposition(),getRandomposition(50,0));
         %pos2 = vectoradd(%fpos,"0 0 700");
         schedule(500,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
         schedule(1000,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
         schedule(1500,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
       }
       else {
          MessageAll('MessageAll', "\c4"@$TWM2::ZombieName[8]@": Fools, you cannot withstand my power!");
       }
      case 4:
      %target = FindValidTarget(%z);
      if(isObject(%target.player) && !%target.ignoredbyZombs) {
         MessageAll('MessageAll', "\c4"@$TWM2::ZombieName[8]@": Storm Begins!");
         %SPos1 = vectorAdd(%z.getPosition(),"1 0 0");
         %SPos2 = vectorAdd(%z.getPosition(),"-1 0 0");
   	      %p1 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRogStiloutte;
           initialDirection = "0 0 10";
           initialPosition  = %SPos1;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
   	      %p2 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRogStiloutte;
           initialDirection = "0 0 10";
           initialPosition  = %SPos2;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
          MissionCleanup.add(%p1);
          MissionCleanup.add(%p2);
          schedule(5000,0,"MissileDrop",%p1, %target.player);
          schedule(5000,0,"MissileDrop",%p2, %target.player);
          schedule(1000,0,"FireMoreMissiles", %z, %target.player);
          schedule(2000,0,"FireMoreMissiles", %z, %target.player);
       }
      case 5:
         %z.setMoveState(true);
         schedule(7000,0,"unfreezeZombieobject",%z);
         %TargetSearchMask = $TypeMasks::PlayerObjectType;
         %c = createEmitter(%z.position,FlashLEmitter,"1 0 0");      //Rotate it
         schedule(1000,0,"killit",%c);
         InitContainerRadiusSearch(%z.getPosition(),200,%TargetSearchMask);
         while ((%potentialTarget = ContainerSearchNext()) != 0){
            if (%potentialTarget.getPosition() != %z.getPosition() && !%potentialtarget.client.ignoredbyZombs) {
               %potentialTarget.staticTicks = 0;
               SDischLoop(%potentialTarget);
            }
         }
         MessageAll('MessageAll', "\c4"@$TWM2::ZombieName[8]@": Static Discharge!");
      case 6:
         %z.setMoveState(true);
         schedule(7000,0,"unfreezeZombieobject",%z);
         %TargetSearchMask = $TypeMasks::PlayerObjectType;
         %c = createEmitter(%z.position,FlashLEmitter,"1 0 0");      //Rotate it
         schedule(1000,0,"killit",%c);
         InitContainerRadiusSearch(%z.getPosition(),200,%TargetSearchMask);
         while ((%potentialTarget = ContainerSearchNext()) != 0){
            if (%potentialTarget.getPosition() != %z.getPosition() && !%potentialtarget.client.ignoredbyZombs) {
               %potentialTarget.staticTicks = 0;
               SDischLoop(%potentialTarget);
            }
         }
         MessageAll('MessageAll', "\c4"@$TWM2::ZombieName[8]@": Static Discharge!");
      case 7:
      %target = FindValidTarget(%z);
      if(isObject(%target.player) && !%target.ignoredbyZombs) {
         MessageAll('MessageAll', "\c4"@$TWM2::ZombieName[8]@": Metros EXTREMITY!!!!");
         %fpos = vectoradd(%target.player.getposition(),getRandomposition(50,0));
         %pos2 = vectoradd(%fpos,"0 0 700");
         schedule(500,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
         schedule(1000,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
         schedule(1500,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
         schedule(2000,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
         schedule(2500,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
         schedule(3000,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
         schedule(3500,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
         schedule(4000,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
         schedule(4500,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
         schedule(5000,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
         schedule(5500,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
         schedule(6000,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
         schedule(6500,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
         schedule(7000,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
         schedule(7500,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
       }
       else {
          MessageAll('MessageAll', "\c4"@$TWM2::ZombieName[8]@": Fools, you cannot withstand my power!");
       }
      case 8:
         %type = GetRandom(1, 9);
         if(%type > 5) {
            %type += 3;
            if(%type == 10) { //summoners don;t summon more summoners
               %type = 13;
            }
         }
         MessageAll('MessageAll', "\c4"@$TWM2::ZombieName[8]@": Additional Reinforcements!!! NOW!");
         %typeCaller = %type SPC %type SPC %type SPC %type;
         %callPos = vectorAdd(%z.getPosition(), "2000 0 400");
         spawnHunterDropship(%callPos, "AA", %typeCaller);
      default:
      %target = FindValidTarget(%z);
      if(isObject(%target.player) && !%target.ignoredbyZombs) {
         MessageAll('MessageAll', "\c4"@$TWM2::ZombieName[8]@": Launch!");
         %SPos1 = vectorAdd(%z.getPosition(),"1 0 0");
         %SPos2 = vectorAdd(%z.getPosition(),"-1 0 0");
   	      %p1 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRogStiloutte;
           initialDirection = "0 0 1";
           initialPosition  = %SPos1;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
   	      %p2 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRogStiloutte;
           initialDirection = "0 0 1";
           initialPosition  = %SPos2;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
          MissionCleanup.add(%p1);
          MissionCleanup.add(%p2);
          schedule(5000,0,"MissileDrop",%p1, %target.player);
          schedule(5000,0,"MissileDrop",%p2, %target.player);
       }
       else {
          MessageAll('MessageAll', "\c4"@$TWM2::ZombieName[8]@": Fools, you cannot withstand my power!");
       }
   }
   schedule(30000,0,"StartLRAbilities",%zombie);
}

function SDischLoop(%obj) {
   if(!isobject(%obj) || %obj.getState() $= "dead") {
      return;
   }
   if(%obj.staticTicks > 15) {
      %obj.setMoveState(false);
      return;
   }
   %c = createEmitter(%obj.position,PBCExpEmitter,"1 0 0");      //Rotate it
   schedule(1000,0,"killit",%c);
   %obj.setMoveState(true);
   %obj.staticTicks++;
   %obj.damage(0, %viewer.player.position, 0.05, $DamageType::Zombie);
   schedule(1000,0,"SDischLoop",%obj);
}

function FireMoreMissiles(%z, %t) {
         %SPos1 = vectorAdd(%z.getPosition(),"1 0 0");
         %SPos2 = vectorAdd(%z.getPosition(),"-1 0 0");
   	      %p1 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRogStiloutte;
           initialDirection = "0 0 10";
           initialPosition  = %SPos1;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
   	      %p2 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRogStiloutte;
           initialDirection = "0 0 10";
           initialPosition  = %SPos2;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
          MissionCleanup.add(%p1);
          MissionCleanup.add(%p2);
          schedule(5000,0,"MissileDrop",%p1, %t);
          schedule(5000,0,"MissileDrop",%p2, %t);
}

function LRLaserStorm(%z, %t) {
   if(!isObject(%t) || %t.getState() $= "dead") {
      %z.Storming = 0;
      return;
   }
   if(!isObject(%z) || %z.getState() $= "dead") {
      return;
   }
   %z.laserStormSount++;
   if(%z.laserStormSount < 40) {
        %vec = vectorsub(%t.getworldboxcenter(),%z.getMuzzlePoint(6));
        %vec = vectoradd(%vec, vectorscale(%t.getvelocity(),vectorlen(%vec)/100));
   	      %p = new LinearFlareProjectile()
   	      {
   	   	   dataBlock        = LaserShot;
           initialDirection = %vec;
           initialPosition  = %z.getMuzzlePoint(6);
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
          MissionCleanup.add(%p);
   }
   else {
      %z.Storming = 0;
      return;
   }
   schedule(100,0,"LRLaserStorm",%z, %t);
}


function unfreezeZombieobject(%obj) {
%obj.setMoveState(false);
}
