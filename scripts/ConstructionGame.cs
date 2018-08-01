// DisplayName = Construction

//--- GAME RULES BEGIN ---
// Build
// Battle
// And Zombies, The All in one Game Mode
//--- GAME RULES END ---

// spam fix
function ConstructionGame::AIInit(%game) {
	//call the default AIInit() function
	AIInit();
}

function ConstructionGame::allowsProtectedStatics(%game) {
	return true;
}

function ConstructionGame::clientMissionDropReady(%game, %client) {
    messageClient(%client, 'MsgClientReady',"", "SinglePlayerGame");
    messageClient(%client, 'MsgSPCurrentObjective1' ,"", $TWM::Ticker[1]);
    messageClient(%client, 'MsgSPCurrentObjective2' ,"", $TWM::Ticker[2]);
    %cl.TickerLoop = PlayNewsTicker(%client, $TWM::Ticker[1], $TWM::Ticker[2]);
    %cl.tickerCount = 2; //we are on 2
	messageClient(%client, 'MsgMissionDropInfo', '\c0You are in mission %1 (%2).', $MissionDisplayName, $MissionTypeDisplayName, $ServerName );
	DefaultGame::clientMissionDropReady(%game, %client);
}

function PlayNewsTicker(%cl, %m1, %m2) {
   messageClient(%cl, 'MsgSPCurrentObjective1' ,"", %m1);
   messageClient(%cl, 'MsgSPCurrentObjective2' ,"", %m2);
   if(%cl.tickerCount > $TWM::Ticks) {
      %cl.tickerCount = 1;
   }
   else {
      %cl.tickerCount++;
   }
   %next = $TWM::Ticker[%cl.tickerCount];
   %cl.TickerLoop = schedule(5000,0,"PlayNewsTicker", %cl, %m2, %next);
}

function EndNewsTicker(%cl) {
   cancel(%cl.TickerLoop);
}

function ConstructionGame::onAIRespawn(%game, %client)
{
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

function ConstructionGame::updateKillScores(%game, %clVictim, %clKiller, %damageType, %implement) {
	if (%game.testKill(%clVictim, %clKiller)) { //verify victim was an enemy
		%game.awardScoreKill(%clKiller);
		%game.awardScoreDeath(%clVictim);
	}
	else if (%game.testSuicide(%clVictim, %clKiller, %damageType))  //otherwise test for suicide
		%game.awardScoreSuicide(%clVictim);
}

function ConstructionGame::timeLimitReached(%game) {
	logEcho("game over (timelimit)");
	%game.gameOver();
	cycleMissions();
}

function ConstructionGame::scoreLimitReached(%game) {
	logEcho("game over (scorelimit)");
	%game.gameOver();
	cycleMissions();
}

function ConstructionGame::gameOver(%game) {
	//call the default
	DefaultGame::gameOver(%game);

	//send the winner message
	%winner = "";
	if ($teamScore[1] > $teamScore[2])
		%winner = %game.getTeamName(1);
	else if ($teamScore[2] > $teamScore[1])
		%winner = %game.getTeamName(2);

	if (%winner $= 'Storm')
		messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.stowins.wav" );
	else if (%winner $= 'Inferno')
		messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.infwins.wav" );
	else if (%winner $= 'Starwolf')
		messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.swwin.wav" );
	else if (%winner $= 'Blood Eagle')
		messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.bewin.wav" );
	else if (%winner $= 'Diamond Sword')
		messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.dswin.wav" );
	else if (%winner $= 'Phoenix')
		messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.pxwin.wav" );
	else
		messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.gameover.wav" );

	messageAll('MsgClearObjHud', "");
	for(%i = 0; %i < ClientGroup.getCount(); %i ++) {
		%client = ClientGroup.getObject(%i);
		%game.resetScore(%client);
        EndNewsTicker(%client);
	}
	for(%j = 1; %j <= %game.numTeams; %j++)
		$TeamScore[%j] = 0;
}

function ConstructionGame::vehicleDestroyed(%game, %vehicle, %destroyer) {
}

function ConstructionGame::awardScoreVehicleDestroyed(%game, %client, %vehicleType, %mult, %passengers)  //added
{
    if(isDemo())
        return 0;

    if(%vehicleType $= "Interceptor") {
        %base = %game.SCORE_PER_DESTROY_SHRIKE;
        %XPForVKill = 10;
        }
    else if(%vehicleType $= "Fighter") {
        %base = %game.SCORE_PER_DESTROY_STRIKEFIGHTER;
        %XPForVKill = 20;
        }
    else if(%vehicleType $= "Assault Chopper") {
        %base = %game.SCORE_PER_DESTROY_HELICOPTER;
        %XPForVKill = 5;
        }
    else if(%vehicleType $= "AWACS") {
        %base = %game.SCORE_PER_DESTROY_AWACS;
        %XPForVKill = 50;
        }
    else if(%vehicleType $= "Bomber") {
        %base = %game.SCORE_PER_DESTROY_BOMBER;
        %XPForVKill = 25;
        }
    else if(%vehicleType $= "Gunship") {
        %base = %game.SCORE_PER_DESTROY_GUNSHIP;
        %XPForVKill = 30;
        }
    else if(%vehicleType $= "Transport Chopper") {
        %base = %game.SCORE_PER_DESTROY_HEAVYHELICOPTER;
        %XPForVKill = 20;
        }
    else if(%vehicleType $= "Heavy Transport") {
        %base = %game.SCORE_PER_DESTROY_TRANSPORT;
        %XPForVKill = 30;
        }
    else if(%vehicleType $= "Grav Cycle") {
        %base = %game.SCORE_PER_DESTROY_WILDCAT;
        %XPForVKill = 5;
        }
    else if(%vehicleType $= "Light Tank") {
        %base = %game.SCORE_PER_DESTROY_TANK;
        %XPForVKill = 25;
        }
    else if(%vehicleType $= "Assault Tank") {
        %base = %game.SCORE_PER_DESTROY_HEAVYTANK;
        %XPForVKill = 30;
        }
    else if(%vehicleType $= "chaingun tank") {
        %base = %game.SCORE_PER_DESTROY_CGTANK;
        %XPForVKill = 25;
        }
    else if(%vehicleType $= "APC") {
        %base = %game.SCORE_PER_DESTROY_FFTRANSPORT;
        %XPForVKill = 20;
        }
    else if(%vehicleType $= "Heavy Artillery") {
        %base = %game.SCORE_PER_DESTROY_ARTILLERY;
        %XPForVKill = 50;
        }
    else if(%vehicleType $= "MPB") {
        %base = %game.SCORE_PER_DESTROY_MPB;
        %XPForVKill = 25;
        }
    else if(%vehicleType $= "Boat") {
        %base = %game.SCORE_PER_DESTROY_TRANSBOAT;
        %XPForVKill = 10;
        }
    else if(%vehicleType $= "Submarine") {
        %base = %game.SCORE_PER_DESTROY_SUB;
        %XPForVKill = 50;
        }
    else if(%vehicleType $= "GunBoat") {
        %base = %game.SCORE_PER_DESTROY_BOAT;
        %XPForVKill = 100;
        }

    %total = ( %base * %mult ) + ( %passengers * %game.SCORE_PER_PASSENGER );

    %client.vehicleScore += %total;
    %client.XP = %client.XP + %XPForVKill;

     messageClient(%client, 'msgVehicleScore', '\c0You received a %1 point bonus for destroying an enemy %2.', %total, %vehicleType);
     messageClient(%client, 'msgVehicleScore', '\c0You received %1XP for destroying an enemy %2.', %XPForVKill, %vehicleType);
   %game.recalcScore(%client);
    return %total;
}

