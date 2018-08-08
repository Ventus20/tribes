//This sets up the drone and the functions needed to start the drone.
function StartWindshear(%pos){
	%team = 6;
	%rotation = "1 0 0 0";
    %skill = 10;
    
   %Drone = new FlyingVehicle() {
      dataBlock    = WindshearPlatform;
      position     = %pos;
      rotation     = %rotation;
      team         = %team;
   };
   MissionCleanUp.add(%Drone);

   setTargetSensorGroup(%Drone.getTarget(), %team);

   %Drone.isdrone = 1;
   %drone.dodgeGround = 0;

   %drone.isace = 1;

   %drone.skill = 0.2 + (%skill / 12.5);

   schedule(100, 0, "WSForwardImpulse", %drone); //special impulse
   schedule(101, 0, "DronefindTarget", %drone);
   schedule(102, 0, "WSScanGround", %drone);

   InitiateBoss(%drone, "CnlWindshear");
   
   //Helpers
   %pos2 = vectoradd(%pos, "15 0 0");
   %pos3 = vectoradd(%pos, "-15 0 0");
   %d2 = StartAIGunship(%pos2, "", 6, "ace", 0);
   %d3 = StartAIGunship(%pos3, "", 6, "ace", 0);
   %d2.isUltrally = 1;
   %d3.isUltrally = 1;
   //
   
   WindshearAttacks(%drone);

   return %drone;
}

function WSForwardImpulse(%obj){
   if(!isObject(%obj)) {
	  return;
   }
   if(vectorLen(%obj.getVelocity()) < 500) {
      %obj.applyImpulse(%obj.getPosition(),vectorScale(%obj.getForwardVector(),$Drone::FrdImpulse));
   }
   schedule(100, 0, "WSForwardImpulse", %obj);
}

function WSScanGround(%obj){
   if(!isObject(%obj))
	return;
   %vec = %obj.getForwardVector();
   %vector = vectorAdd(%obj.getPosition(),"0 0 -350");
   %searchResult = containerRayCast(%obj.getWorldBoxCenter(), %vector, $TypeMasks::TerrainObjectType, %obj);
   if(%searchResult){
	%z = getWord(%vec,2);
      %height = vectorDist(%obj.getPosition(),posFromRaycast(%searchresult));
	if(%z < 0){
	   if(%height <= (200 + ((%z * -1) * 300))){
		%obj.dodgeground = 1;
		schedule(100, 0, "WSDodgeGround", %obj);
		return;
	   }
	}
   }
   schedule(100, 0, "WSScanGround", %obj);
}

function WSDodgeGround(%obj){
   if(!isObject(%obj))
	return;
   %vec = %obj.getForwardVector();
   %z = getWord(%vec,2);
   if(%z > 0){
	%obj.dodgeground = 0;
	schedule(100, 0, "DronefindTarget", %obj);
	schedule(101, 0, "WSScanGround", %obj);
	return;
   }
   %pos = vectorAdd(%obj.getPosition(),%vec);
   %obj.applyImpulse(%pos,vectorScale("0 0 1",$Drone::TurnImpulse * %obj.skill));
   schedule(100, 0, "WSDodgeGround", %obj);
}

function FireanotherSidewinder(%d, %t, %TTL) { // Syntax: (Drone, target Obj, Time Til Live (Seconds))
   if(!isObject(%d) || !isObject(%t) || %t.getState() $= "dead") {
      return;
   }
   %SPos = vectorAdd(%d.getPosition(),"0 0 3");
   %p1 = new SeekerProjectile() {
       dataBlock        = BossMissiles;
       initialDirection = "0 0 10";
       initialPosition  = %SPos;
   	   sourceObject     = %d;
   	   sourceSlot       = 6;
   };
   MissionCleanup.add(%p1);
   schedule(%TTL * 1000,0,"MissileDrop",%p1, %t);
}

function FireFlares(%d) {
   if(!isObject(%d)) {
      return;
   }
   %SPos = vectorAdd(%d.getPosition(),"0 0 0");
   %p1 = new FlareProjectile() {
       dataBlock        = FlareGrenadeProj;
       initialDirection = "5 0 -3";
       initialPosition  = %SPos;
   	   sourceObject     = %d;
   	   sourceSlot       = 6;
   };
   %p2 = new FlareProjectile() {
   	   dataBlock        = FlareGrenadeProj;
       initialDirection = "-5 0 -3";
       initialPosition  = %SPos;
   	   sourceObject     = %d;
   	   sourceSlot       = 6;
   };
   FlareSet.add(%p1);
   FlareSet.add(%p2);
   MissionCleanup.add(%p1);
   MissionCleanup.add(%p2);
}

function DroneFindNearestPilot(%radius, %drone) {
   %pos = %drone.getposition();
   %wbpos = %drone.getworldboxcenter();
   %count = ClientGroup.getCount();
   %closestClient = -1;
   %closestDistance = %radius;
   for(%i = 0; %i < %count; %i++)
   {
	%cl = ClientGroup.getObject(%i);
	if(isObject(%cl.player)){
	   %testPos = %cl.player.getWorldBoxCenter();
	   %distance = vectorDist(%wbpos, %testPos);
	   if (%distance > 0 && %distance < %closestDistance)
	   {
	   	%closestClient = %cl;
	   	%closestDistance = %distance;
	   }
	}
   }
   return %closestClient;
}


datablock SeekerProjectileData(BossMissiles)
{
   casingShapeName     = "weapon_missile_casement.dts";
   projectileShapeName = "weapon_missile_projectile.dts";
   hasDamageRadius     = true;
   indirectDamage      = 0.1;
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




function WindshearAttacks(%drone) {
   if(!isObject(%drone)) {
      return;
   }
   schedule(30000, 0, "WindshearAttacks", %drone);
   %rand = getRandom(1, 4);
   switch(%rand) {
      case 1:
          schedule(700,0,"FireFlares",%drone);
          schedule(1400,0,"FireFlares",%drone);
          schedule(2100,0,"FireFlares",%drone);
          schedule(2800,0,"FireFlares",%drone);
          schedule(3500,0,"FireFlares",%drone);
          schedule(4200,0,"FireFlares",%drone);
          schedule(4900,0,"FireFlares",%drone);
          schedule(5600,0,"FireFlares",%drone);
          schedule(6300,0,"FireFlares",%drone);
          schedule(7000,0,"FireFlares",%drone);
          // Quick Shots
          schedule(8000,0,"FireFlares",%drone);
          schedule(8100,0,"FireFlares",%drone);
          schedule(8200,0,"FireFlares",%drone);
          schedule(8300,0,"FireFlares",%drone);
          MessageAll('MessageAll', "\c4"@$TWM2::BossName["Windshear"]@": Did you actually think, your fucking missiles could hit me?");
      case 2:
         %target = DroneFindNearestPilot(2000,%drone);
         if(%target.player) {
            FireanotherSidewinder(%drone, %target.player, 3);
            schedule(700,0,"FireanotherSidewinder",%drone, %target.player, 3);
            schedule(1400,0,"FireanotherSidewinder",%drone, %target.player, 3);
            schedule(2100,0,"FireanotherSidewinder",%drone, %target.player, 3);
            schedule(2800,0,"FireanotherSidewinder",%drone, %target.player, 3);
            schedule(3500,0,"FireanotherSidewinder",%drone, %target.player, 3);
            schedule(4200,0,"FireanotherSidewinder",%drone, %target.player, 3);
            schedule(4900,0,"FireanotherSidewinder",%drone, %target.player, 3);
            schedule(5600,0,"FireanotherSidewinder",%drone, %target.player, 3);
            schedule(6300,0,"FireanotherSidewinder",%drone, %target.player, 3);
            schedule(7000,0,"FireanotherSidewinder",%drone, %target.player, 3);
            // Quick Shots
            schedule(8000,0,"FireanotherSidewinder",%drone, %target.player, 1);
            schedule(8100,0,"FireanotherSidewinder",%drone, %target.player, 1);
            schedule(8200,0,"FireanotherSidewinder",%drone, %target.player, 1);
            schedule(8300,0,"FireanotherSidewinder",%drone, %target.player, 1);
            MessageAll('MessageAll', "\c4"@$TWM2::BossName["Windshear"]@": You fuckin' Chasing me "@getTaggedString(%target.name)@"!?!? WATCH THIS BITCH!!!");
         }
         else {
            MessageAll('MessageAll', "\c4"@$TWM2::BossName["Windshear"]@": FUCK, My missile strike was ready.");
         }
      case 3:
         %target = DroneFindNearestPilot(2000,%drone);
         if(%target.player) {
            schedule(700,0,"FireFlares",%drone);
            schedule(1400,0,"FireFlares",%drone);
            schedule(2100,0,"FireFlares",%drone);
            schedule(2800,0,"FireFlares",%drone);
            FireanotherSidewinder(%drone, %target.player, 3);
            // Quick Shots
            schedule(1000,0,"FireanotherSidewinder",%drone, %target.player, 1);
            schedule(1100,0,"FireanotherSidewinder",%drone, %target.player, 1);
            schedule(1200,0,"FireanotherSidewinder",%drone, %target.player, 1);
            schedule(1300,0,"FireanotherSidewinder",%drone, %target.player, 1);
            schedule(1400,0,"FireanotherSidewinder",%drone, %target.player, 1);
            MessageAll('MessageAll', "\c4"@$TWM2::BossName["Windshear"]@": I'ma kill me a fuckin' "@getTaggedString(%target.name)@"!");
         }
         else {
            schedule(700,0,"FireFlares",%drone);
            schedule(1400,0,"FireFlares",%drone);
            schedule(2100,0,"FireFlares",%drone);
            schedule(2800,0,"FireFlares",%drone);
            MessageAll('MessageAll', "\c4"@$TWM2::BossName["Windshear"]@": FUCK!!! Oh well, Flares will fucking do...");
         }
      default:
            schedule(700,0,"FireFlares",%drone);
            schedule(1400,0,"FireFlares",%drone);
            schedule(2100,0,"FireFlares",%drone);
            schedule(2800,0,"FireFlares",%drone);
            MessageAll('MessageAll', "\c4"@$TWM2::BossName["Windshear"]@": FUCK!!! Oh well, Flares will fucking do...");
   }
}

function MissileDrop(%m, %t) {
   %t.setHeat(100);
   %m.setObjectTarget(%t);
   HeatLoop(%t,0);
}

function HeatLoop(%t, %val) {
   if(!isObject(%t) || %t.getState() $= "dead") {
   return;
   }
   if(%val > 200) {
   return;
   }
   %val++;
   %t.setHeat(100);
   schedule(100,0,"HeatLoop", %t, %val);
}

//AI

