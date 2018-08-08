//DATABLOCKS
datablock StaticShapeData(NoCollideBio) : StaticShapeDamageProfile {
	className = "player";
	shapeFile = "bioderm_light.dts"; // dmiscf.dts, alternate
    mass = 1;
	elasticity = 0.1;
	friction = 0.9;
	collideable = 0;
    isInvincible = true;
};

datablock StaticShapeData(NoCollideHum) : StaticShapeDamageProfile {
	className = "player";
	shapeFile = "light_male.dts"; // dmiscf.dts, alternate
    mass = 1;
	elasticity = 0.1;
	friction = 0.9;
	collideable = 0;
    isInvincible = true;
};

//Stops console spammage
function NoCollideBio::shouldApplyImpulse(%targetObject) {
   return false;
}
function NoCollideHum::shouldApplyImpulse(%targetObject) {
   return false;
}

datablock PlayerData(InsigniaZombieArmor) : LightMaleBiodermArmor {
   maxDamage = 700.0;
   minImpactSpeed = 50;
   speedDamageScale = 0.015;

   damageScale[$DamageType::M1700] = 2.0;

	max[RepairKit]			= 0;
	max[Mine]			= 0;
	max[Grenade]			= 0;
	max[SmokeGrenade]			= 0;
	max[BeaconSmokeGrenade]		= 0;
	max[Blaster]			= 0;
	max[Plasma]			= 0;
	max[PlasmaAmmo]			= 0;
	max[Disc]			= 0;
	max[DiscAmmo]			= 0;
	max[SniperRifle]		= 0;
	max[GrenadeLauncher]		= 0;
	max[GrenadeLauncherAmmo]	= 0;
	max[Mortar]			= 0;
	max[MortarAmmo]			= 0;
	max[MissileLauncher]		= 0;
	max[MissileLauncherAmmo]	= 0;
	max[Chaingun]			= 0;
	max[ChaingunAmmo]		= 0;
	max[RepairGun]			= 0;
	max[CloakingPack]		= 0;
	max[SensorJammerPack]		= 0;
	max[EnergyPack]			= 0;
	max[RepairPack]			= 0;
	max[ShieldPack]			= 0;
	max[AmmoPack]			= 0;
	max[SatchelCharge]		= 0;
	max[MortarBarrelPack]		= 0;
	max[MissileBarrelPack]		= 0;
	max[AABarrelPack]		= 0;
	max[PlasmaBarrelPack]		= 0;
	max[ELFBarrelPack]		= 0;
	max[artillerybarrelpack]	= 0;
	max[InventoryDeployable]	= 0;
	max[MotionSensorDeployable]	= 0;
	max[PulseSensorDeployable]	= 0;
	max[TurretOutdoorDeployable]	= 0;
	max[TurretIndoorDeployable]	= 0;
	max[FlashGrenade]		= 0;
	max[ConcussionGrenade]		= 0;
	max[FlareGrenade]		= 0;
	max[TargetingLaser]		= 0;
	max[ELFGun]			= 0;
	max[ShockLance]			= 0;
	max[CameraGrenade]		= 0;
	max[Beacon]			= 0;
	max[flamerAmmoPack]		= 0;
	max[ParachutePack]		= 0;
	max[MedPack]			= 0;
	//Guns
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
	max[nukeme]				= 0;
	max[nukemeAmmo]			= 0;
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
	//Building parts
	max[spineDeployable]		= 0;
	max[mspineDeployable]		= 0;
	max[wWallDeployable]		= 0;
	max[floorDeployable]		= 0;
	max[WallDeployable]		= 0;
      max[DoorDeployable]           = 0;
	//Turrets
	max[TurretLaserDeployable]	= 0;
	max[TurretMissileRackDeployable]= 0;
	max[DiscTurretDeployable]	= 0;
	//Largepacks
	max[EnergizerDeployable]	= 0;
	max[TreeDeployable]		= 0;
	max[CrateDeployable]		= 0;
	max[DecorationDeployable]	= 0;
	max[LogoProjectorDeployable]	= 0;
	max[LightDeployable]		= 0;
	max[TripwireDeployable]		= 0;
	max[TelePadPack]		= 0;
	max[TurretBasePack]		= 0;
	max[LargeInventoryDeployable]	= 0;
	max[GeneratorDeployable]	= 0;
	max[SolarPanelDeployable]	= 0;
	max[SwitchDeployable]		= 0;
	max[MediumSensorDeployable]	= 0;
	max[LargeSensorDeployable]	= 0;
	max[SpySatelliteDeployable]	= 0;
	//Misc
	max[JumpadDeployable]		= 0;
	max[EscapePodDeployable]	= 0;
	max[ForceFieldDeployable]	= 0;
	max[GravityFieldDeployable]	= 0;
      max[VehiclePadPack]		= 0;
};

//CREATION
function SpawnInsignia(%position) {
	%Zombie = new player(){
	   Datablock = "InsigniaZombieArmor";
	};
	%Cpos = vectorAdd(%position, "0 0 5");
    MessageAll('MsgDarkraireturn', "\c4"@$TWM2::BossName["Insignia"]@": Oh, a battle, lets see if I know how to do this...");

	%command = "Insigniamovetotarget";
    %zombie.ticks = 0;
    InitiateBoss(%zombie, "Insignia");
    InsigniaSummon(%zombie);
    InsigniaAttack(%zombie);

   %Zombie.team = 30;
   %zname = $TWM2::BossName["Insignia"]; // <- To Hosts, Enjoy, You can
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

function Insigniamovetotarget(%zombie){
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
      MessageAll('msgDarkraiAttack', "\c4"@$TWM2::BossName["Insignia"]@": OH FALLING IS NOT FUN!!!!");
   }
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;
   if(%closestDistance <= $zombie::detectDist){
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
   %zombie.moveloop = schedule(500, %zombie, "Insigniamovetotarget", %zombie);
}

//
function GravShot(%plyr, %vec) {
   if(%plyr.isAlive()) {
      %plyr.applyImpulse(%plyr.getPosition(), VectorScale(%vec, 2000));
      %plyr.flight = 1;
      schedule(4000, 0, "resetFlight", %plyr);
      for( %i = 0; %i < 20; %i++ ) {
         schedule(%i * 80,0,createBiodermProjection,%plyr);
      }
   }
}

function resetFlight(%plyr) {
   %plyr.flight = 0;
}

function createBiodermProjection(%plyr) {
   if(isPlayer(%plyr)) {
      %trans2 = %plyr.getTransform();
      %player = new StaticShape(){
	     Datablock = "NoCollideBio";
	  };
      %player.setTransform(%trans2);
      %player.startfade(2000, 0, true);
      %player.schedule(5000, "Delete");
   }
}

function createHumanProjection(%plyr) {
   if(isPlayer(%plyr)) {
      %trans2 = %plyr.getTransform();
      %player = new StaticShape(){
	     Datablock = "NoCollideHum";
	  };
      %player.setTransform(%trans2);
      %player.startfade(2000, 0, true);
      %player.schedule(5000, "Delete");
   }
}


function PhotonShockwaveFunc(%obj,%proj)// this func is to umm..err.. oh yeah nm..wtf was it for...OH! this creates shockwave trail for straight orig fired proj
{
	if(isobject(%proj))//keep going till the proj is deleted for the ub3r homing function which uses its own shockwave trail thing
	{
		%fake = new (linearprojectile)()
		{
		dataBlock        = "FakePhotonShockwaveProj";
		initialDirection = %proj.PhotonMuzVec;
		initialPosition  = %proj.position;
		sourceSlot       = %obj;
		};
		%fake.sourceobject = %obj;
		MissionCleanup.add(%fake);

		%proj.PhotonShockwaveSched = schedule( 80,0, "PhotonShockwaveFunc" ,%obj,%Proj);
	}
}
//

//ATTACKS

function InsigniaAttack(%zombie) {
   if(!isObject(%zombie) || %zombie.getState() $= "dead") {
      return;
   }
   schedule(27000, 0, "InsigniaAttack", %zombie);
   %attack = getRandom(1, 8);
   switch(%attack) {
      case 1:
         %target = FindValidTarget(%zombie);
         %target = %target.player;
         if(!isObject(%target) || %target.getState() $= "Dead") {
            MessageAll('msgDarkraiAttack', "\c4"@$TWM2::BossName["Insignia"]@": I suppose I can wait...");
            return;
         }
         %vec = vectorsub(%target.getworldboxcenter(),%zombie.getMuzzlePoint(0));
         %vec = vectoradd(%vec, vectorscale(%target.getvelocity(),vectorlen(%vec)/100));
         %p = new TracerProjectile() {
             dataBlock        = InsigniaGravityShot;
             initialDirection = %vec;
             initialPosition  = %zombie.getMuzzlePoint(0);
             sourceObject     = %zombie;
             sourceSlot       = 0;
         };
         MissionCleanup.add(%p);
         PhotonShockwaveFunc(%zombie, %p);
         MessageAll('msgDarkraiAttack', "\c4"@$TWM2::BossName["Insignia"]@": Zero-G, Coming Right Up "@%target.client.namebase@".");
      case 2:
         %target = FindValidTarget(%zombie);
         %target = %target.player;
         if(!isObject(%target) || %target.getState() $= "Dead") {
            MessageAll('msgDarkraiAttack', "\c4"@$TWM2::BossName["Insignia"]@": I suppose I can wait...");
            return;
         }
         MessageAll('msgDarkraiAttack', "\c4"@$TWM2::BossName["Insignia"]@": Lets shorten the distance... "@%target.client.namebase@".");
         %vec = vectorsub(%target.getworldboxcenter(),%zombie.getMuzzlePoint(0));
         %vec = vectoradd(%vec, vectorscale(%target.getvelocity(),vectorlen(%vec)/100));
         GravShot(%zombie, %vec);
      case 3:
         %target = FindValidTarget(%zombie);
         %target = %target.player;
         if(!isObject(%target) || %target.getState() $= "Dead") {
            MessageAll('msgDarkraiAttack', "\c4"@$TWM2::BossName["Insignia"]@": I suppose I can wait...");
            return;
         }
         GravShot(%zombie, "0 0 200");
         MessageAll('msgDarkraiAttack', "\c4"@$TWM2::BossName["Insignia"]@": Death from above "@%target.client.namebase@".");
         %vec = vectorsub(%target.getworldboxcenter(),%zombie.getMuzzlePoint(0));
         %vec = vectoradd(%vec, vectorscale(%target.getvelocity(),vectorlen(%vec)/100));
         schedule(1000,0, "GravShot", %zombie, %vec);
      case 4:
         %target = FindValidTarget(%zombie);
         %target = %target.player;
         if(!isObject(%target) || %target.getState() $= "Dead") {
            MessageAll('msgDarkraiAttack', "\c4"@$TWM2::BossName["Insignia"]@": I suppose I can wait...");
            return;
         }
         %zombie.setMoveState(true);
         FireZLordPulse(%zombie, %target);
         schedule(500, 0, "FireZLordPulse", %zombie, %target);
         schedule(1000, 0, "FireZLordPulse", %zombie, %target);
         schedule(1500, 0, "FireZLordPulse", %zombie, %target);
         schedule(2000, 0, "FireZLordPulse", %zombie, %target);
         schedule(2500, 0, "FireZLordPulse", %zombie, %target);
         schedule(3000, 0, "FireZLordPulse", %zombie, %target);
         schedule(3500, 0, "FireZLordPulse", %zombie, %target);
         schedule(4000, 0, "FireZLordPulse", %zombie, %target);
         schedule(4500, 0, "FireZLordPulse", %zombie, %target);
         %zombie.schedule(5000, "setMoveState", false);
         MessageAll('msgDarkraiAttack', "\c4"@$TWM2::BossName["Insignia"]@": Acid Storm, just for you... "@%target.client.namebase@".");
      case 5:
         %target = FindValidTarget(%zombie);
         %target = %target.player;
         if(!isObject(%target) || %target.getState() $= "Dead") {
            MessageAll('msgDarkraiAttack', "\c4"@$TWM2::BossName["Insignia"]@": I suppose I can wait...");
            return;
         }
         InsigniaLaunchPulse(%zombie, %target, 0);
         MessageAll('msgDarkraiAttack', "\c4"@$TWM2::BossName["Insignia"]@": Hey, "@%target.client.namebase@". Watch this.");
      case 6:
         %target = FindValidTarget(%zombie);
         %target = %target.player;
         if(!isObject(%target) || %target.getState() $= "Dead") {
            MessageAll('msgDarkraiAttack', "\c4"@$TWM2::BossName["Insignia"]@": I suppose I can wait...");
            return;
         }
         MessageAll('msgDarkraiAttack', "\c4"@$TWM2::BossName["Insignia"]@": ENOUGH, "@%target.client.namebase@". DIE.");
         for(%i = 0; %i < 40; %i++) {
            schedule(%i * 100, 0, "FireZLordPulse", %zombie, %target);
         }
      case 7:
         %target = FindValidTarget(%zombie);
         %target = %target.player;
         if(!isObject(%target) || %target.getState() $= "Dead") {
            MessageAll('msgDarkraiAttack', "\c4"@$TWM2::BossName["Insignia"]@": I suppose I can wait...");
            return;
         }
         MessageAll('msgDarkraiAttack', "\c4"@$TWM2::BossName["Insignia"]@": C'Mere, "@%target.client.namebase@".");
         %target.setMoveState(true);
         %target.schedule(1500, "SetMoveState", false);
         %target.setPosition(vectorAdd(%zombie.getPosition(), "0 0 20"));
         GravShot(%target, "0 0 -1");
      case 8:
         %type = GetRandom(1, 9);
         if(%type > 5) {
            %type += 3;
            if(%type == 10) { //summoners don;t summon more summoners
               %type = 13;
            }
         }
         MessageAll('MessageAll', "\c4"@$TWM2::BossName["Insignia"]@": It's time for you to take on my reinforcements!");
         %typeCaller = %type SPC %type SPC %type SPC %type;
         %callPos1 = vectorAdd(%zombie.getPosition(), "2000 100 400");
         spawnHunterDropship(%callPos1, "AA", %typeCaller);
         %callPos2 = vectorAdd(%zombie.getPosition(), "2000 -100 400");
         spawnHunterDropship(%callPos2, "AA", %typeCaller);
   }
}

function InsigniaLaunchPulse(%zombie, %target, %ct) {
   if(!isObject(%zombie) || %zombie.getState() $= "dead") {
      return;
   }
   if(!isObject(%target) || %target.getState() $= "dead") {
      return;
   }
   if(%ct > 30) {
      return;
   }
   %ct++;
   schedule(200, 0, "InsigniaLaunchPulse", %zombie, %target, %ct);
   if(%ct < 5) {
      %zombie.setVelocity("0 0 10");
   }
   else if(%ct >= 5 && %ct <= 10) {
      %zombie.startFade(400, 0, true);
      %zombie.startFade(1000, 0, false);
      %zombie.schedule(700, "setPosition", vectorAdd(%target.getPosition(), "20 0 50"));
   }
   else if(%ct == 10 || %ct == 11) {
      schedule(1, 0, "FireZLordPulse", %zombie, %target);
   }
   else if(%ct >= 12 && %ct <= 17) {
      %zombie.startFade(400, 0, true);
      %zombie.startFade(1000, 0, false);
      %zombie.schedule(700, "setPosition", vectorAdd(%target.getPosition(), "-20 0 50"));
   }
   else if(%ct == 18 || %ct == 19 || %ct == 20) {
      schedule(1, 0, "FireZLordPulse", %zombie, %target);
   }
   else if(%ct > 20 && %ct <= 25) {
      %zombie.setVelocity("0 0 10");
      %zombie.startFade(400, 0, true);
      %zombie.startFade(1000, 0, false);
      %zombie.schedule(700, "setPosition", vectorAdd(%target.getPosition(), "-20 20 50"));
   }
   else if(%ct == 26) {
      %vec = vectorsub(%target.getworldboxcenter(),%zombie.getMuzzlePoint(0));
      %vec = vectoradd(%vec, vectorscale(%target.getvelocity(),vectorlen(%vec)/100));
      %p = new TracerProjectile() {
          dataBlock        = InsigniaGravityShot;
          initialDirection = %vec;
          initialPosition  = %zombie.getMuzzlePoint(0);
          sourceObject     = %zombie;
          sourceSlot       = 0;
      };
      MissionCleanup.add(%p);
      PhotonShockwaveFunc(%zombie, %p);
   }
   else if(%ct > 26 && %ct < 30) {
      %zombie.setVelocity("0 0 10");
   }
   else if(%ct == 30) {
      FireMoreMissiles(%zombie, %target);
   }
}

function FireZLordPulse(%zombie, %target) {
   if(isobject(%zombie) && isobject(%target)){
      %vec = vectorsub(%target.getworldboxcenter(),%zombie.getMuzzlePoint(6));
      %vec = vectoradd(%vec, vectorscale(%target.getvelocity(),vectorlen(%vec)/100));
      %p = new TracerProjectile() {
   	      	dataBlock        = LZombieAcidBall;
   	      	initialDirection = %vec;
   	    	initialPosition  = %zombie.getMuzzlePoint(6);
   	     	sourceObject     = %zombie;
   	    	sourceSlot       = 6;
      };
   }
}

function InsigniaSummon(%z) {
   if(!isobject(%z) || %z.getState() $= "dead") {
      return;
   }
   schedule(30000,0,"InsigniaSummon",%z);
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
         messageall('DarkraiMsg',"\c4"@$TWM2::BossName["Insignia"]@": Attack the enemy");
      case 2:
         messageall('DarkraiMsg',"\c4"@$TWM2::BossName["Insignia"]@": Hunt them all down");
      case 3:
         messageall('DarkraiMsg',"\c4"@$TWM2::BossName["Insignia"]@": Attack!!! I will call in more!!!");
         %target = FindValidTarget(%zombie);
         %target = %target.player;
         if(!isObject(%target) || %target.getState() $= "Dead") {
            MessageAll('msgDarkraiAttack', "\c4"@$TWM2::BossName["Insignia"]@": I suppose we will wait for now.");
            return;
         }
         YvexZombieFireMissile(%z, %target);
      }
      for(%i=0;%i<6;%i++) {
         %pos = vectoradd(%z.getPosition(),getRandomPosition(10,1));
         %fpos = vectoradd("0 0 5",%pos);
         StartAZombie(%fpos, %type);
      }
      %z.setMoveState(true);
      %z.setActionThread($Zombie::RAAMThread,true);
      %z.schedule(3500, "setMoveState", false);
}
