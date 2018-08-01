// DisplayName = Combat Construction

//--- GAME RULES BEGIN ---
// This is a PvP Game Mode
// Two Teams Build Bases
// Then they battle it out
//--- GAME RULES END ---

// spam fix
function CombatConstructionGame::AIInit(%game) {
	//call the default AIInit() function
	AIInit();
}

function CombatConstructionGame::allowsProtectedStatics(%game) {
	return true;
}

//Score Menu Fix
function CombatConstructionGame::updateScoreHud(%game, %client, %tag) {
   ConstructionGame::updateScoreHud(%game, %client, %tag);
}

function CombatConstructionGame::processGameLink(%game, %client, %arg1, %arg2, %arg3, %arg4, %arg5){
  ConstructionGame::processGameLink(%game, %client, %arg1, %arg2, %arg3, %arg4, %arg5);
}
//

function CombatConstructionGame::clientMissionDropReady(%game, %client) {
    messageClient(%client, 'MsgClientReady',"", "SinglePlayerGame");
	messageClient(%client, 'MsgMissionDropInfo', '\c0You are in mission %1 (%2).', $MissionDisplayName, $MissionTypeDisplayName, $ServerName );
	DefaultGame::clientMissionDropReady(%game, %client);
}

function CombatConstructionGame::onAIRespawn(%game, %client)
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

function CombatConstructionGame::updateKillScores(%game, %clVictim, %clKiller, %damageType, %implement) {
	if (%game.testKill(%clVictim, %clKiller)) { //verify victim was an enemy
		%game.awardScoreKill(%clKiller);
		%game.awardScoreDeath(%clVictim);
	}
	else if (%game.testSuicide(%clVictim, %clKiller, %damageType))  //otherwise test for suicide
		%game.awardScoreSuicide(%clVictim);
}

function CombatConstructionGame::timeLimitReached(%game) {
	logEcho("game over (timelimit)");
	%game.gameOver();
	cycleMissions();
}

function CombatConstructionGame::scoreLimitReached(%game) {
	logEcho("game over (scorelimit)");
	%game.gameOver();
	cycleMissions();
}

function CombatConstructionGame::startMatch(%game) {
   DefaultGame::startMatch(%game);
   $TWM::combCons = 1; //sets the specific GameType
   $TWM::twoteams = true;
   setsensorgroupcount(3);
   %game.numteams = 2;
}


function CombatConstructionGame::gameOver(%game) {
	//call the default
	DefaultGame::gameOver(%game);
    $TWM::combCons = 0; //Ends the specific GameType

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
	}
	for(%j = 1; %j <= %game.numTeams; %j++)
		$TeamScore[%j] = 0;
}

function CombatConstructionGame::vehicleDestroyed(%game, %vehicle, %destroyer) {
}

function CombatConstructionGame::awardScoreVehicleDestroyed(%game, %client, %vehicleType, %mult, %passengers)  //added
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

