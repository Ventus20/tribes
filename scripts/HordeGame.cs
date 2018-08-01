// DisplayName = Horde

//--- GAME RULES BEGIN ---
// hold out 50 waves of zombies
// you cant respawn after death until next wave
// 5 Revives Per Game, 1 Revive Gained Per Wave
// Game ends after wave 50 or all players die
//--- GAME RULES END ---

//Pos - FLBig - 52 0 101
//Pos - Flatdash - 64 265 179
$HordeGame::SpawnGraph["FlatlandBigH"] = "52 0 101";
$HordeGame::SpawnGraph["slapmydashH"] = "-64.7988 -267.13 131.439";
function HordeGame::pickPlayerSpawn(%game, %client, %respawn) {
   if (isobject(%client.spawnpoint)) {
      if (%client.spawnpoint.team == %client.team) {
         if ( (%client.spawnpoint.ispersonal != 1) || (%client==%client.spawnpoint.owner) ) {
            if (%client.spawnpoint.getdatablock().isspawnpoint==1) {
               return vectoradd(%client.spawnpoint.getposition(),"0 0 1.5") SPC "0 0 0 1";
            }
         }
         else {
            messageclient(%client,'',"\c3The spawn point you selected is a personal spawn point, spawning you at default spawn location.");
         }
      }
      else {
         messageclient(%client,'',"\c3The spawn point you selected is not on your team, spawning you at default spawn location.");
      }
   }
   if ( (!isobject(%client.spawnpoint)) && (%client.spawnpoint != 0) && (%client.spawnpoint !$= "") ) {
      messageclient(%client,'',"\c3The spawn point you selected does not exist, spawning you at default spawn location.");
   }

   // place this client on his own team, '%respawn' does not ever seem to be used
   //we no longer care whether it is a respawn since all spawns use same points.
   %loc = $HordeGame::SpawnGraph[$CurrentMission];
   %position = vectorAdd(%loc,VectorAdd(getRandomPosition(20,1), "0 0 10"));
   return %position;//return %game.pickTeamSpawn(%client.team);
}

function MakeReviveString() {
   %string = "";
   %revives = $HordeGame::RevivesLeft;
   for(%i = 1; %i <= 5; %i++) {
     if(%i <= $HordeGame::RevivesLeft) {
        %string = ""@%string@" [R]";
     }
     else {
        %string = ""@%string@" [X]";
     }
   }
   return %string;
}

function HordeGame::AIInit(%game) {
	//call the default AIInit() function
	AIInit();
}

function HordeGame::allowsProtectedStatics(%game) {
	return true;
}

//Score Menu Fix
function HordeGame::updateScoreHud(%game, %client, %tag) {
   ConstructionGame::updateScoreHud(%game, %client, %tag);
}

function HordeGame::processGameLink(%game, %client, %arg1, %arg2, %arg3, %arg4, %arg5){
  ConstructionGame::processGameLink(%game, %client, %arg1, %arg2, %arg3, %arg4, %arg5);
}
//

function HordeServerStatuser() {
   %count = ClientGroup.getCount();
   if(!%count || %count == 0 ||%count $= "") {   //no players..
   HordeServerSetStatus("Standby");
   }
   else {
   HordeServerSetStatus("Active");
   }
   schedule(10000,0,"HordeServerStatuser");
}

function HordeServerSetStatus(%status) {
   if(%status $= "Standby" && $HordeGame::GameStatus $= "Active") {
   $HordeGame::GameStatus = "Standby";
   Echo("Horde: Server switching to STANDBY mode");
   }
   else if(%status $= "Active" && $HordeGame::GameStatus $= "Standby") {
   $HordeGame::GameStatus = "Active";
   Echo("Horde: Server switching to ACTIVE mode");
   }
}

function HordeGame::onClientKilled(%game, %clVictim, %clKiller, %damageType, %implement, %damageLocation) {
   Parent::onClientKilled(%game, %clVictim, %clKiller, %damageType, %implement, %damageLocation);
   if(%clVictim !$= "") { //actual player died
      %clVictim.CantRespawn = 1; //gotta wait until next round / Wave
       CenterPrint(%clVictim, "<color:FF0000>You are out until the next Wave.",2,3);
//       forceObserver( %game, %clVictim, "AdminForce" ); //not needed
       Echo("Horde: "@%clVictim.namebase@" has been killed.");
       HordeCheckForLivingPlayers(%game);
   }
}

function HordeCheckForLivingPlayers(%game) {
   $HordeGame::LivingCount = 0;
   %count = ClientGroup.getCount();
   if(%count == 0) {   //no players, this fixed the constant game over stuff
      return;
   }
   for (%i = 0; %i < %count; %i++) {
   %cl = ClientGroup.getObject( %i );
      if(!isObject(%cl.player) || %cl.player.getstate() $= "dead") {
      //Do nothing
      }
      else {
      $HordeGame::LivingCount++;
      }
   }
   %s = MakeReviveString();
   messageAll('MsgSPCurrentObjective2' ,"", "Players Alive: "@$HordeGame::LivingCount@" | "@%s@"");
   if($HordeGame::LivingCount <= 0) {
   //Everyone is Dead, or nobody is in the server, game over
      %game.gameOver();
      cycleMissions();
   }
}

function HordeKillAllZombies() {
   Echo("Horde: Cleaning Zombies");
   %count = MissionCleanup.getCount();
   for(%i = 0; %i < %count; %i++) {
      %obj = MissionCleanup.getObject(%i);
      if(isObject(%obj)) {
         if(%obj.iszombie) {
            %obj.scriptkill($DamageType::admin);  //They all went on crack and died XD
         }
         else {
            continue;
         }
      }
   }
}

function HordeAllowAllRespawn() {
   Echo("Horde: Players Can now respawn.");
   %count = ClientGroup.getCount();
   for (%i = 0; %i < %count; %i++) {
   %cl = ClientGroup.getObject( %i );
   %cl.CantRespawn = 0;
   CenterPrint(%cl, "<color:FF0000>You can now respawn, but hurry, you have 15 seconds.",2,3);
   }
   messageAll('MsgSPCurrentObjective2' ,"", "You Can Now Spawn");
}

function LockOutCLsFromRespawn(%game) {
   Echo("Horde: Players Can no longer respawn.");
   %count = ClientGroup.getCount();
   for (%i = 0; %i < %count; %i++) {
   %cl = ClientGroup.getObject( %i );
   %cl.CantRespawn = 1;
   bottomPrint(%cl, "<color:FF0000>The respawn timer has exipred.",2,3);
   }
   HordeCheckForLivingPlayers(%game); // Do this to see if anyone exists.
}

function HordeShowWaveBegin() {
   %count = ClientGroup.getCount();
   for (%i = 0; %i < %count; %i++) {
   %cl = ClientGroup.getObject( %i );
   messageClient(%cl, 'MsgClient', "~wfx/misc/lightning_impact.wav");
   BottomPrint(%cl, "<color:FF0000>Horde \n Wave "@$HordeGame::CurrentWave@" \n Begins",5,3);
   }
}

function HordeGame::spawnPlayer( %game, %client, %respawn ) {
    if(%client.CantRespawn) {
       CenterPrint(%client, "<color:FF0000>You are out until the next Wave.",2,3);
//       forceObserver( %game, %client, "AdminForce" ); //Eh, for now
       return;
    }
	Parent::spawnPlayer( %game, %client, %respawn );
    HordeCheckForLivingPlayers(%game);
}

function HordeGame::clientJoinTeam( %game, %client, %team, %respawn )
{
	// for multi-team games played with a single team
	if (Game.numTeams == 1) {
		%game.assignClientTeam( %client );
		// Spawn the player:
		%game.spawnPlayer( %client, %respawn );
		return;
	}

//error("DefaultGame::clientJoinTeam");
   if ( %team < 1 || %team > %game.numTeams )
      return;

   if( %respawn $= "" )
      %respawn = 1;

   %client.team = %team;
   %client.lastTeam = %team;
   setTargetSkin( %client.target, %game.getTeamSkin(%team) );
   setTargetSensorGroup( %client.target, %team );
   %client.setSensorGroup( %team );

   // Spawn the player:
   %game.spawnPlayer( %client, %respawn );

//   messageAllExcept( %client, -1, 'MsgClientJoinTeam', '\c1%1 joined %2.', %client.name, %game.getTeamName(%team), %client, %team );
//   messageClient( %client, 'MsgClientJoinTeam', '\c1You joined the %2 team.', $client.name, %game.getTeamName(%client.team), %client, %client.team );

   updateCanListenState( %client );

   logEcho(%client.nameBase@" (cl "@%client@") joined team "@%client.team);
	if ($Host::Prison::Enabled == true) {
		if (%client.isJailed)
			// If player should manage to get out of jail, re-spawn and re-start sentence time
			jailPlayer(%client,false,mAbs(%cl.jailTime));
	}
}

function HordeGame::assignClientTeam(%game, %client, %respawn )
{
//error("DefaultGame::assignClientTeam");
   // this function is overwritten in non-team mission types (e.g. DM)
   // so these lines won't do anything
   //if(!%game.numTeams)
   //{
   //   setTargetSkin(%client.target, %client.skin);
   //   return;
   //}

   //  camera is responsible for creating a player
   //  - counts the number of players per team
   //  - puts this player on the least player count team
   //  - sets the client's skin to the servers default

   %numPlayers = ClientGroup.getCount();
   for(%i = 0; %i <= %game.numTeams; %i++)
      %numTeamPlayers[%i] = 0;

   for(%i = 0; %i < %numPlayers; %i = %i + 1)
   {
      %cl = ClientGroup.getObject(%i);
      if(%cl != %client)
	 %numTeamPlayers[%cl.team]++;
   }
   %leastPlayers = %numTeamPlayers[1];
   %leastTeam = 1;
   for(%i = 2; %i <= %game.numTeams; %i++)
   {
      if( (%numTeamPlayers[%i] < %leastPlayers) ||
	 ( (%numTeamPlayers[%i] == %leastPlayers) &&
	 ($teamScore[%i] < $teamScore[%leastTeam] ) ))
      {
	 %leastTeam = %i;
	 %leastPlayers = %numTeamPlayers[%i];
      }
   }

   %client.team = %leastTeam;
   %client.lastTeam = %team;

   // Assign the team skin:
   if ( %client.isAIControlled() )
   {
      if ( %leastTeam & 1 )
      {
	 %client.skin = addTaggedString( "basebot" );
	 setTargetSkin( %client.target, 'basebot' );
      }
      else
      {
	 %client.skin = addTaggedString( "basebbot" );
	 setTargetSkin( %client.target, 'basebbot' );
      }
   }
   else
      setTargetSkin( %client.target, %game.getTeamSkin(%client.team) );
      //setTargetSkin( %client.target, %client.skin );

   // might as well standardize the messages
   //messageAllExcept( %client, -1, 'MsgClientJoinTeam', '\c1%1 joined %2.', %client.name, $teamName[%leastTeam], %client, %leastTeam );
   //messageClient( %client, 'MsgClientJoinTeam', '\c1You joined the %2 team.', $client.name, $teamName[%client.team], %client, %client.team );
//   messageAllExcept( %client, -1, 'MsgClientJoinTeam', '\c1%1 joined %2.', %client.name, %game.getTeamName(%client.team), %client, %client.team );
//   messageClient( %client, 'MsgClientJoinTeam', '\c1You joined the %2 team.', %client.name, %game.getTeamName(%client.team), %client, %client.team );

   updateCanListenState( %client );

   logEcho(%client.nameBase@" (cl "@%client@") joined team "@%client.team);
}

function HordeGame::clientChangeTeam(%game, %client, %team, %fromObs) {
   if(%client.CantRespawn) {
      if(!%fromObs) {    //:D they tried to change teams
         CenterPrint(%client, "<color:FF0000>You are out until the next Wave. \n Although that was a good try :D",2,3);
          return;
      }
      else {
         CenterPrint(%client, "<color:FF0000>You are out until the next Wave.",2,3);
         return;
      }
   }
   %game.removeFromTeamRankArray(%client);

   %pl = %client.player;
   if(isObject(%pl))
   {
      if(%pl.isMounted())
	 %pl.getDataBlock().doDismount(%pl);
      %pl.scriptKill(0);
   }

   // reset the client's targets and tasks only
   clientResetTargets(%client, true);

   // give this client a new handle to disassociate ownership of deployed objects
   if( %team $= "" && (%team > 0 && %team <= %game.numTeams))
   {
      if( %client.team == 1 )
	 %client.team = 2;
      else
	 %client.team = 1;
   }
   else
      %client.team = %team;

   // Set the client's skin:
   if (!%client.isAIControlled())
      setTargetSkin( %client.target, %game.getTeamSkin(%client.team) );
   setTargetSensorGroup( %client.target, %client.team );
   %client.setSensorGroup( %client.team );

   // Spawn the player:
   %client.lastSpawnPoint = %game.pickPlayerSpawn( %client );

   %game.createPlayer( %client, %client.lastSpawnPoint, $MatchStarted );

   if($MatchStarted)
      %client.setControlObject(%client.player);
   else
   {
      %client.camera.getDataBlock().setMode(%client.camera, "pre-game", %client.player);
      %client.setControlObject(%client.camera);
   }
   %game.onClientEnterObserverMode(%client);
   updateCanListenState( %client );

   // MES - switch objective hud lines when client switches teams
   messageClient(%client, 'MsgCheckTeamLines', "", %client.team);
   logEcho(%client.nameBase@" (cl "@%client@") switched to team "@%client.team);

}

function HordeRepairAndRearm(%cl) {
   if(isObject(%cl.player)) {
   buyfavorites(%cl);
   %cl.player.ApplyRepair(20.0);
   }
}

function HordeGame::clientMissionDropReady(%game, %client) {
   %count = ClientGroup.getCount();
   if($MatchStarted && $CountdownStarted && %count == 1) //Game started, first player is in
   {
      messageClient(%client, 'MsgClient', "\c5Welcome To Horde, You are the first player, BEGIN!");
      %client.CantRespawn = 0; //they will get the first life
      $HordeGame::GameStatus = "Active"; //Force the server into Active Mode
   }
   else if($MatchStarted && $CountdownStarted && %count > 1) // Game in progress, multiple players
   {
      HordeCheckForLivingPlayers(%game); //we may have to restart the game
      messageClient(%client, 'MsgClient', "\c5Welcome To Horde, Please wait for the next wave to begin.");
      %client.CantRespawn = 1;
   }
   messageClient(%client, 'MsgClientReady',"", "SinglePlayerGame");
   defaultGame::clientMissionDropReady(%game, %client);
}

function HordeGame::onAIRespawn(%game, %client) {
   //add the default task
	if (! %client.defaultTasksAdded)
	{
		%client.defaultTasksAdded = true;
	   %client.addTask(AIPickupItemTask);
	   %client.addTask(AIUseInventoryTask);
	   %client.addTask(AITauntCorpseTask);
		%client.addTask(AIEngageTurretTask);
		%client.addTask(AIDetectMineTask);
		%client.addTask(AIBountyPatrolTask);
		%client.bountyTask = %client.addTask(AIBountyEngageTask);
	}

   //set the inv flag
   %client.spawnUseInv = true;
}

function HordeGame::updateKillScores(%game, %clVictim, %clKiller, %damageType, %implement) {
	if (%game.testKill(%clVictim, %clKiller)) { //verify victim was an enemy
		%game.awardScoreKill(%clKiller);
		%game.awardScoreDeath(%clVictim);
	}
	else if (%game.testSuicide(%clVictim, %clKiller, %damageType))  //otherwise test for suicide
		%game.awardScoreSuicide(%clVictim);
}

function HordeGame::timeLimitReached(%game) {
    $TWM::HordeCalled = 1; //The Host Will Cycle
	logEcho("game over (timelimit)");
	%game.gameOver();
	cycleMissions();
}

function HordeNextWave(%game, %wave) {
   if($HordeGame::RevivesLeft < 5) {
      $HordeGame::RevivesLeft++;
   }
   $HordeGame::CurrentWave = %wave;
   HordeKillAllZombies(); //Cleans up the server
   if($HordeGame::CurrentWave == 51) { //Victory
      for (%i = 0; %i < ClientGroup.getCount(); %i++) {
         %cl = ClientGroup.getObject(%i);
         AwardClient(%cl, 31);
      }
  	  %game.gameOver();
      cycleMissions();
      return;
   }
   else if($HordeGame::CurrentWave == 25) {
      for (%i = 0; %i < ClientGroup.getCount(); %i++) {
         %cl = ClientGroup.getObject(%i);
         AwardClient(%cl, 30);
      }
   }
   %count = ClientGroup.getCount();
   for (%i = 0; %i < %count; %i++) {
   %cl = ClientGroup.getObject( %i );
   HordeRepairAndRearm(%cl);
   }
   Echo("Horde: Players Moving into Wave "@%wave@".");
   HordeShowWaveBegin();
   HordeAllowAllRespawn(); // Go!
   schedule(15000,0,"LockOutCLsFromRespawn", %game);
   schedule(30000,0,"StartHordeZombies", $CurrentMission, %wave);
   $HordeGame::Zombiecount = 0;
   $HordeGame::NextWave = %wave + 1;
   $HordeGame::CanSpawnZombies = 1;
   messageAll('MsgSPCurrentObjective1' ,"", "Wave "@$HordeGame::CurrentWave@" | Zombies Left: "@$HordeGame::Zombiecount@"");
}

function HordeGame::startMatch(%game) {
   $Host::nozombs = 0; //Allow Zombs
   $HordeGame::GameStatus = "Standby"; //Always Start In Standby
   $HordeGame::CanSpawnZombies = 1;
   $HordeGame::CurrentWave = 1;
   $HordeGame::NextWave = 2;
   $HordeGame::Zombiecount = 0; //Start at 0              `
   $HordeGame::LivingCount = 0; //Start at 0
   $HordeGame::RevivesLeft = 5; //Start With 5


   $TWM::PlayingHorde = 1;
   $TWM::HordeCalled = 1; //The Host Will Cycle
   $HordeGame::Game = %game; //This allows us to expand into other functions
   DefaultGame::startMatch(%game);
   HordeServerStatuser();
   messageAll('MsgSPCurrentObjective1' ,"", "Preparing Game");
   messageAll('MsgSPCurrentObjective2' ,"", "You Can Now Spawn");

   setSensorGroupCount(31);

   schedule(10000,0, "HordeNextWave", %game, 1); //Give us a nice 10 Second Warm Up
}

function HordeGame::scoreLimitReached(%game) {
    $TWM::HordeCalled = 1; //The Host Will Cycle
	logEcho("game over (scorelimit)");
	%game.gameOver();
	cycleMissions();
}

function HordeGame::gameOver(%game) {
    //Dont end in standby, nobody is alive
    if($HordeGame::GameStatus $= "Standby") {
      return;
    }
	//call the default
    HordeAllowAllRespawn();
	DefaultGame::gameOver(%game);
 
//	cycleMissions();

	//send the winner message
	%winner = "";
    if($HordeGame::Zombiecount >= 1) {
       %winner = "Zombies";
    }
    else {
       %winner = "Humans";
    }

	if (%winner $= "Zombies")
		messageAll('MsgGameOver', "The Zombies have overrun the humans.~wvoice/announcer/ann.stowins.wav" );
    else
		messageAll('MsgGameOver', "The Humans have Survived the horde.~wvoice/announcer/ann.gameover.wav" );

    Echo("Horde: Game over, Winners : "@%winner@" on Wave "@$HordeGame::CurrentWave@".");

	messageAll('MsgClearObjHud', "");

    //Reset the Vars
    $TWM::PlayingHorde = 0;
    $TWM::HordeCalled = 1; //The Host Will Cycle
    $HordeGame::CurrentWave = 1;
    $HordeGame::NextWave = 2;
    $HordeGame::Zombiecount = 0;
    $HordeGame::LivingCount = 0;
    $HordeGame::CanSpawnZombies = 1;

	for(%i = 0; %i < ClientGroup.getCount(); %i ++) {
		%client = ClientGroup.getObject(%i);
		%game.resetScore(%client);
	}
	for(%j = 1; %j <= %game.numTeams; %j++)
		$TeamScore[%j] = 0;
}


// Working on this
function HordeGame::sendDebriefing( %game, %client ) {
   messageClient( %client, 'MsgDebriefResult', "", "<just:center>Game Over at wave "@$HordeGame::CurrentWave@"." );
   if($HordeGame::LivingCount > 0) {
      messageClient( %client, 'MsgDebriefResult', "", '<just:center>The humans have defeated the horde.' );
   }
   else {
      messageClient( %client, 'MsgDebriefResult', "", '<just:center>The zombie horde has overrun the humans.' );
   }
}

function HordeGame::vehicleDestroyed(%game, %vehicle, %destroyer) {
}

//Useful
function CheckLegitHordeMission(%mission) {
   if(%mission $= "FlatlandBigH") {
      return 1;
   }
   else if(%mission $= "slapmydashH") {  //flatdash
      return 1;
   }
   else {
      return 0;
   }
}


//ZOMBIE SPAWNING
//VARS (By mission)

//UPDATE!
//This system is now universal for any map
//Just pop in the mission name into these vars:
//$HordeGame::ZombiePtCnts["name"] = Spawn Positions; <- ammount of spawns
//$HordeGame::ZombieStartPt["name", Spawn position] = "X Y Z"; <- Coordinates of a spawn area
//After you make those entires, add an else if statement to the check
//function above to allow horde to be played on that map
// -Phantom139

//FL Big
$HordeGame::ZombiePtCnts["FlatlandBigH"] = 4;
$HordeGame::ZombieStartPt["FlatlandBigH", 1] = "0 150 110";
$HordeGame::ZombieStartPt["FlatlandBigH", 2] = "0 -150 110";
$HordeGame::ZombieStartPt["FlatlandBigH", 3] = "150 0 110";
$HordeGame::ZombieStartPt["FlatlandBigH", 4] = "-150 0 110";
//Flatdash
$HordeGame::ZombiePtCnts["slapmydashH"] = 4;
$HordeGame::ZombieStartPt["slapmydashH", 1] = "-39 101 208";
$HordeGame::ZombieStartPt["slapmydashH", 2] = "213 -325 140";
$HordeGame::ZombieStartPt["slapmydashH", 3] = "-72 -528 138";
$HordeGame::ZombieStartPt["slapmydashH", 4] = "-342 -272 138";
//
function StartHordeZombies(%mission, %wave) {
   //Prevent zombies from spawning in Standby Mode
   //Note: Whats the point, noone is in here.
   if(!$TWM::PlayingHorde) {
      return;
   }
   if($HordeGame::GameStatus $= "Standby") {
   Echo("Horde: Not Spawning Zombies, Server in StandBy Mode, Trying again in 60 Seconds");
   schedule(60000,0,"StartHordeZombies", %mission, %wave);
   return;
   }
   //Block multiple waves from spawning.
   if(!$HordeGame::CanSpawnZombies) {
   return;
   }
   if(CheckLegitHordeMission(%mission) == 1) {
      switch(%wave) {
         case 1:
            for(%i = 0; %i < 20; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,1);
            }
         case 2:
            for(%i = 0; %i < 25; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,1);
            }
         case 3:
            for(%i = 0; %i < 30; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,1);
            }
         case 4:
            for(%i = 0; %i < 35; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,1);
            }
         case 5:
            for(%i = 0; %i < 40; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,1);
            }
         case 6:
            for(%i = 0; %i < 20; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,2);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 7:
            for(%i = 0; %i < 25; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,2);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 8:
            for(%i = 0; %i < 30; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,2);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 9:
            for(%i = 0; %i < 35; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,2);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 10:
            for(%i = 0; %i < 40; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,2);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 11:
            for(%i = 0; %i < 20; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,3);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 12:
            for(%i = 0; %i < 25; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,3);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 13:
            for(%i = 0; %i < 30; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,3);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 14:
            for(%i = 0; %i < 35; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,3);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 15:
            for(%i = 0; %i < 40; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,3);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 16:
            for(%i = 0; %i < 20; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,4);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 17:
            for(%i = 0; %i < 25; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,4);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 18:
            for(%i = 0; %i < 30; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,4);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 19:
            for(%i = 0; %i < 35; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,4);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 20:
            for(%i = 0; %i < 40; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,4);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 21:
            for(%i = 0; %i < 20; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,5);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 22:
            for(%i = 0; %i < 25; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,5);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 23:
            for(%i = 0; %i < 30; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,5);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 24:
            for(%i = 0; %i < 35; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,5);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         //The Rapier wave :D
         case 25:
            for(%i = 0; %i < 25; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,5);
            }
         case 26:
            for(%i = 0; %i < 30; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,5);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 27:
            for(%i = 0; %i < 35; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,5);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 28:
            for(%i = 0; %i < 40; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,5);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 29:
            for(%i = 0; %i < 45; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,5);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 30:
            for(%i = 0; %i < 50; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,5);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 31:
            for(%i = 0; %i < 20; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,6);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 32:
            for(%i = 0; %i < 25; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,6);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 33:
            for(%i = 0; %i < 30; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,6);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 34:
            for(%i = 0; %i < 35; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,6);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 35:
            for(%i = 0; %i < 40; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,6);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,%type);
            }
         case 36:
            for(%i = 0; %i < 25; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,7);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               if(%type == 7)
                  %type = 8; //slasher zombies
               StartAZombie(%final,%type);
            }
         case 37:
            for(%i = 0; %i < 30; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,7);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               if(%type == 7)
                  %type = 8; //slasher zombies
               StartAZombie(%final,%type);
            }
         case 38:
            for(%i = 0; %i < 35; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,7);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               if(%type == 7)
                  %type = 8; //slasher zombies
               StartAZombie(%final,%type);
            }
         case 39:
            for(%i = 0; %i < 40; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,7);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               if(%type == 7)
                  %type = 8; //slasher zombies
               StartAZombie(%final,%type);
            }
         case 40:
            for(%i = 0; %i < 40; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,7);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               if(%type == 7)
                  %type = 8; //slasher zombies
               StartAZombie(%final,%type);
            }
         //The Lord wave :D
         case 41:
            for(%i = 0; %i < 25; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,3);
            }
         //The Lord wave, 2.0 :D
         case 42:
            for(%i = 0; %i < 40; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,3);
            }
         //Slasher Wave
         case 43:
            for(%i = 0; %i < 40; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final, 8);
            }
         case 44:
            for(%i = 0; %i < 40; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,7);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               if(%type == 7)
                  %type = 8; //slasher zombies
               StartAZombie(%final,%type);
            }
         case 45:
            for(%i = 0; %i < 40; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,7);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               if(%type == 7)
                  %type = 8; //slasher zombies
               StartAZombie(%final,%type);
            }
         case 46:
            for(%i = 0; %i < 45; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,7);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               if(%type == 7)
                  %type = 8; //slasher zombies
               StartAZombie(%final,%type);
            }
         case 47:
            for(%i = 0; %i < 50; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %type = getRandom(1,7);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               if(%type == 7)
                  %type = 8; //slasher zombies
               StartAZombie(%final,%type);
            }
         //The sniper wave :p
         case 48:
            for(%i = 0; %i < 30; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,6);
            }
         //The ravie wave, V2.0 :p
         case 49:
            for(%i = 0; %i < 45; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,2);
            }
         //ZOMG!!!! 15 DARKRAIS
         case 50:
            for(%i = 0; %i < 15; %i++) {
               %pt = getRandom(1,$HordeGame::ZombiePtCnts[%mission]);
               %final = vectoradd($HordeGame::ZombieStartPt[%mission, %pt], GetRandomPosition(10,1));
               $HordeGame::Zombiecount++;
               StartAZombie(%final,11);
            }
         default:
         error("Horde: Wave Error, Wave "@%wave@" is unknown on "@%mission@"");
      }
   }
   else {
      error("Horde: Map Error, Wave "@%wave@" is unknown on "@%mission@"");
      error("Horde: Check function CheckLegitHordeMission, map "@%mission@" is not specified");
   }
   $HordeGame::CanSpawnZombies = 0;
   messageAll('MsgSPCurrentObjective1' ,"", "Wave "@$HordeGame::CurrentWave@" | Zombies Left: "@$HordeGame::Zombiecount@"");
   echo("Horde: Spawn Zombies Called, "@$HordeGame::Zombiecount@" Spawned");
}

