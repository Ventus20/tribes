function DroneMissionPatrol1Start(%client){
   if(!isObject(%client.player))
	return;

   %veh = new FlyingVehicle()
   {
      dataBlock    = ScoutFlyer;
      position     = "0 0 1000";
      rotation     = "0 0 1 0";
      team         = %client.team;
   };
   MissionCleanUp.add(%veh); 
   setTargetSensorGroup(%veh.getTarget(), %client.team);
   commandToClient(%client,'SetDefaultVehicleKeys', true);
   commandToClient(%client,'SetPilotVehicleKeys', true);
   %veh.mountObject(%client.player,0);
   %veh.playAudio(0, MountVehicleSound);
   %client.player.mVehicle = %col;
   %datablock = "scoutFlyer";
   %datablock.playerMounted(%veh,%client.player, 0);

   $Drone::paths = 9;
   for(%i = 1;%i <= $Drone::paths;%i++){
	for(%j = 1;$Drone::path[%i,%j] !$= "";%j++){
	   $Drone::path[%i,%j] = "";
	}
   }
   $Drone::path[1,1] = "-480 15100 2100";
   $Drone::path[2,1] = "-520 15100 2100";
   $Drone::path[3,1] = "-450 15040 2100";
   $Drone::path[4,1] = "-550 15040 2100";

   %drone1 = startDrone("20 100 1000","0 0 1 0",%client.team,5);
   %drone1.path = 1;
   %drone2 = startDrone("-20 100 1000","0 0 1 0",%client.team,5);
   %drone2.path = 2;
   %drone3 = startDrone("50 40 1000","0 0 1 0",%client.team,3);
   %drone3.path = 3;
   %drone4 = startDrone("-50 40 1000","0 0 1 0",%client.team,3);
   %drone4.path = 4;

   $userPlane = %veh;
   $friendly[1] = %drone1;
   $friendly[2] = %drone2;
   $friendly[3] = %drone3;
   $friendly[4] = %drone4;

   messageClient(%client, 'MsgClient', "\c2Pilot, your orders are to follow your wingmates on patrol to the North and then head west over a suspected enemy hot spot.");
   messageClient(%client, 'MsgClient', "\c2There have been sightings of multiple enemy planes, so be on your guard, command out.");

   schedule(1000, 0, "DroneMissionPatrol1control", %client,1,%client.player);
}

function DroneMissionPatrol1control(%client,%stage,%player){
   if(!isObject(%player) || %player.getState() $= "Dead"){
   messageClient(%client, 'MsgClient', "\c2Mission Failed.");
	for(%i = 1;%i <= 4;%i++){
	   if(isObject($friendly[%i])){
		$friendly[%i].damage(0, $Friendly[%i].getPosition(), 5, $DamageType::TankChaingun);
		$friendly[%i] = "";
	   }
	}
	for(%i = 1;%i <= 8;%i++){
	   if(isObject($enemy[%i])){
		$enemy[%i].damage(0, $enemy[%i].getPosition(), 5, $DamageType::TankChaingun);
		$enemy[%i] = "";
	   }
	}
	return;
   }
   if(%stage == 4) {
      if(!isObject($AceDrone)) {
	   messageClient(%client, 'MsgClient', "\c2HAH! Now thats how its done, Great Work, Return to base.");
	   messageClient(%client, 'MsgClient', "\c210000 XP Gained.");
       %client.xp = %client.xp + 10000;
      return;
      }
   }
   else if(%stage==3){
    %allies = false;
	for(%i = 1;%i <= 4;%i++){
	   if(isObject($friendly[%i]))
		%allies = true;
	}
	%hostiles = false;
	for(%i = 4;%i < 9;%i++){
	   if(isObject($enemy[%i]))
		%hostiles = true;
	}
	if(!%hostiles){
	   messageClient(%client, 'MsgClient', "\c2Excellent job pilot, mission complete, return home.");
	   messageClient(%client, 'MsgClient', "\c21000 XP Gained.");
       %client.xp = %client.xp + 1000;
       schedule(5000,0,"messageClient",%client, 'MsgOhNoes', "\c2Wait.. we have word of an incoming enemy.");
       schedule(7500,0,"messageClient",%client, 'MsgOhNoes', "\c2Incoming Ace Fighter.");
       schedule(10000,0,"messageClient",%client, 'MsgOhNoes', "\c2He's All yours Pilot! Destroy that fighter!");
   	   $AceDrone = startDrone(vectorAdd(%client.player.getPosition(), "0 1000 0"),"0 0 1 0",99,"ace");
       schedule(10000,0,"StartObjBossMusic", "ADrone", %drone);
       %stage = 4;
	}
	if(!%allies){
	   messageClient(%client, 'MsgClient', "\c2You lost your wingmates, Mission Failed.");
	for(%i = 1;%i <= 4;%i++){
	   if(isObject($friendly[%i])){
		$friendly[%i].damage(0, $Friendly[%i].getPosition(), 5, $DamageType::TankChaingun);
		$friendly[%i] = "";
	   }
	}
	for(%i = 1;%i <= 8;%i++){
	   if(isObject($enemy[%i])){
		$enemy[%i].damage(0, $enemy[%i].getPosition(), 5, $DamageType::TankChaingun);
		$enemy[%i] = "";
	   }
	}
	return;
	}
	$friendly[1].path = 5;
	$friendly[2].path = 6;
	$friendly[3].path = 7;
	$friendly[4].path = 8;

	$enemy[4].path = 5;
	$enemy[5].path = 6;
	$enemy[6].path = 7;
	$enemy[7].path = 8;
	$enemy[8].path = 9;
   }
   else if(%stage==2){
	%hostiles = false;
	for(%i = 1;%i < 4;%i++){
	   if(isObject($enemy[%i]))
		%hostiles = true;
	}
	if(!%hostiles){
	   $drone::path[5,1] = "14100 14950 4000";
	   $drone::path[6,1] = "14100 15050 4000";
	   $drone::path[7,1] = "14040 14900 4050";
	   $drone::path[8,1] = "14040 15100 4050";
	   $drone::path[9,1] = "14000 15000 4000";

	   for(%i = 1;%i <= 4;%i++){
		if(isObject($friendly[%i])){
		   $friendly[%i].dodgeground = 1;
		   $friendly[%i].path = (%i + 4);
		   DroneDodgeGround($friendly[%i]);
		}
	   }

	   %drone1 = startDrone("14100 0 5000","0 0 1 0",0,2);
	   %drone1.path = 5;
	   %drone2 = startDrone("13900 0 5000","0 0 1 0",0,2);
	   %drone2.path = 6;
	   %drone3 = startDrone("14100 -50 5000","0 0 1 0",0,3);
	   %drone3.path = 7;
	   %drone2 = startDrone("13900 -50 5000","0 0 1 0",0,3);
	   %drone2.path = 8;
	   %drone3 = startDrone("14000 50 5000","0 0 1 0",0,5);
	   %drone3.path = 9;

	   $enemy[4] = %drone1;
	   $enemy[5] = %drone2;
	   $enemy[6] = %drone3;
	   $enemy[7] = %drone2;
	   $enemy[8] = %drone3;

	   $friendly[1].path = 5;
	   $friendly[2].path = 6;
	   $friendly[3].path = 7;
	   $friendly[4].path = 8;

	   %stage = 3;
	} else {
	   $friendly[1].path = 1;
	   $friendly[2].path = 2;
	   $friendly[3].path = 3;
	   $friendly[4].path = 4;

	   $enemy[1].path = 2;
	   $enemy[2].path = 3;
	   $enemy[3].path = 4;
	}
   }
   else if(%stage==1){
	if(vectordist($friendly[1].getPosition(),"-500 15000 1200") <= 10000){
	   %drone1 = startDrone("2900 20000 2000","0 0 1 0",0,3);
	   %drone1.path = 2;
	   %drone2 = startDrone("3000 20100 2000","0 0 1 0",0,2);
	   %drone2.path = 3;
	   %drone3 = startDrone("3100 20000 2000","0 0 1 0",0,2);
	   %drone3.path = 4;

	   $enemy[1] = %drone1;
	   $enemy[2] = %drone2;
	   $enemy[3] = %drone3;

	   %stage = 2;
	}
	$friendly[1].path = 1;
	$friendly[2].path = 2;
	$friendly[3].path = 3;
	$friendly[4].path = 4;
   }
   schedule(1000, 0, "DroneMissionPatrol1control", %client,%stage,%player);
}
