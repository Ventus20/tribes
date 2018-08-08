// DisplayName = TWM Infection

//--- GAME RULES BEGIN ---
// Humans vs. Zombies
// 15 Seconds into the Game, A Human becomes a zombie
// The Zombie Tries To Infect all the humans
// Humans Killed By The Zombie, Become Zombies
// Zombies Can Choose What Zombie To Use (Normal, Demon, Lord)
//--- GAME RULES END ---

$InvBanList[Infection, "GrappleHook"] = 1;

$InfectionGame::Min2Alphas = 7;
$InfectionGame::Min3Alphas = 10;
$InfectionGame::Rounds = 5;

// spam fix
function InfectionGame::AIInit(%game) {
	//call the default AIInit() function
	AIInit();
}

function InfectionGame::allowsProtectedStatics(%game) {
	return true;
}

function InfectionGame::pickTeamSpawn(%game, %team) {
   %pos = vectorAdd($InfectionGame::SpawnLocation[$CurrentMission], GetRandomPosition(5,1));
   %pos = vectorAdd(%pos,"0 0 5");
   return %pos;
}


function InfectionGame::clientMissionDropReady(%game, %client) {
    $InfectionGame::Score[%client] = 0;
    $InfectionGame::ClientZombie[%client] = "Norm";
    messageClient(%client, 'MsgClientReady',"", "SinglePlayerGame");
	DefaultGame::clientMissionDropReady(%game, %client);
}

function InfectionGame::onAIRespawn(%game, %client)
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

function InfectionGame::updateKillScores(%game, %clVictim, %clKiller, %damageType, %implement) {
	if (%game.testKill(%clVictim, %clKiller)) { //verify victim was an enemy
		%game.awardScoreKill(%clKiller);
		%game.awardScoreDeath(%clVictim);
	}
	else if (%game.testSuicide(%clVictim, %clKiller, %damageType))  //otherwise test for suicide
		%game.awardScoreSuicide(%clVictim);
}

function InfectionGame::timeLimitReached(%game) {
	logEcho("game over (timelimit)");
	%game.gameOver();
	cycleMissions();
}

function InfectionGame::scoreLimitReached(%game) {
	logEcho("game over (scorelimit)");
	%game.gameOver();
	cycleMissions();
}

function InfectionGame::startMatch(%game) {
    activatePackage(InfectionGamePackage);
    $TWM::PlayingInfection = 1;
    $TWM::TeamWars = 1;
    $Host::RankSystem = 0;
    $InfectionGame::TimeTilInfect = 15;
    $InfectionGame::RoundNumber = 1;
    messageAll('MsgSPCurrentObjective1', "Selecting Alpha Zombie");
    messageAll('MsgSPCurrentObjective2', "Alpha Zombie Selected In: "@$InfectionGame::TimeTilInfect@" Seconds.");
    %game.StartTimeUntilInfect($InfectionGame::TimeTilInfect);
    DefaultGame::StartMatch(%game);
    Game.NumTeams = 1;
    //Disable Killstreaks and Perks
    for(%i = 0; %i < ClientGroup.getCount(); %i++) {
       %client = ClientGroup.getObject(%i);
       DisableAllPerkGroup(%client, 1);
       DisableAllPerkGroup(%client, 2);
       DisableAllPerkGroup(%client, 3);
       %client.DisableAllKillstreaks();
       messageClient(%client, 'msgOffline', "\c5INFECTION: All Killstreaks and Perks Disabled.");
    }
}

function InfectionGame::TryInfectAnother(%game) {
   %selected = ClientGroup.getObject(GetRandom()*ClientGroup.getCount());
   if($InfectionGame::IsAlpha[%selected] || %selected.team == 0) {
      //do not pick observers or already infected
      return %game.TryInfectAnother();
   }
   return %selected;
}

function InfectionGame::StartTimeUntilInfect(%game, %time) {
   %time--;
   if(%time <= 0) {
      if (ClientGroup.getCount() <= 1) {
         MessageAll('MsgError',"\c5Insufficient Players, Need At Least 2");
         $InfectionGame::TimeTilInfect = 15;
         %time = 15;
         %game.schedule(1000, "StartTimeUntilInfect", %time);
         return;
      }
      %ZString = "";
      if(ClientGroup.getCount() >= $InfectionGame::Min3Alphas) {
         for(%x = 0; %x < 3; %x++) {
            %selected = ClientGroup.getObject(GetRandom()*ClientGroup.getCount());
            if($InfectionGame::IsAlpha[%selected]) {   //If this one is selected
               %selected = %game.TryInfectAnother();   //grab a different client
            }
            $InfectionGame::Infected[%selected] = 1;
            $InfectionGame::IsAlpha[%selected] = 1;
      //      Game.clientChangeTeam( %selected, 2, 0 );
            $InfectionGame::ClientZombie[%selected] = "Demon"; //we start them as demonz :)
            if(isObject(%selected.player)) {
               %targetlastpos = %selected.player.getworldboxcenter();
               makePersonZombie(%targetlastpos, %selected, 4);
            }
            %ZString = ""@%ZString@" "@%selected.namebase@"";
         }
         for(%i = 0; %i < ClientGroup.getCount(); %i ++) {
		    %client = ClientGroup.getObject(%i);
            messageClient(%client, 'MsgSPCurrentObjective1' ,"", "Alpha Zombies:"@%ZString@"");
            messageClient(%client, 'MsgSPCurrentObjective2' ,"", "Score: "@$InfectionGame::Score[%client]@".");
         }
         return;
      }
      else if(ClientGroup.getCount() >= $InfectionGame::Min2Alphas && ClientGroup.getCount() < $InfectionGame::Min3Alphas) {
         for(%x = 0; %x < 2; %x++) {
            %selected = ClientGroup.getObject(GetRandom()*ClientGroup.getCount());
            if($InfectionGame::IsAlpha[%selected]) {   //If this one is selected
               %selected = %game.TryInfectAnother();   //grab a different client
            }
            $InfectionGame::Infected[%selected] = 1;
            $InfectionGame::IsAlpha[%selected] = 1;
      //      Game.clientChangeTeam( %selected, 2, 0 );
            $InfectionGame::ClientZombie[%selected] = "Demon"; //we start them as demonz :)
            if(isObject(%selected.player)) {
               %targetlastpos = %selected.player.getworldboxcenter();
               makePersonZombie(%targetlastpos, %selected, 4);
            }
            %ZString = ""@%ZString@" "@%selected.namebase@"";
         }
         for(%i = 0; %i < ClientGroup.getCount(); %i ++) {
		    %client = ClientGroup.getObject(%i);
            messageClient(%client, 'MsgSPCurrentObjective1' ,"", "Alpha Zombies:"@%ZString@"");
            messageClient(%client, 'MsgSPCurrentObjective2' ,"", "Score: "@$InfectionGame::Score[%client]@".");
         }
         return;
      }
      else {
         %selected = ClientGroup.getObject(GetRandom()*ClientGroup.getCount());
         $InfectionGame::Infected[%selected] = 1;
         $InfectionGame::IsAlpha[%selected] = 1;
   //      Game.clientChangeTeam( %selected, 2, 0 );
         $InfectionGame::ClientZombie[%selected] = "Demon"; //we start them as demonz :)
         if(isObject(%selected.player)) {
            %targetlastpos = %selected.player.getworldboxcenter();
            makePersonZombie(%targetlastpos, %selected, 4);
         }
         for(%i = 0; %i < ClientGroup.getCount(); %i ++) {
		    %client = ClientGroup.getObject(%i);
            messageClient(%client, 'MsgSPCurrentObjective1' ,"", "Alpha Zombie: "@%selected.namebase@"");
            messageClient(%client, 'MsgSPCurrentObjective2' ,"", "Score: "@$InfectionGame::Score[%client]@".");
         }
         messageClient(%selected, 'MsgSPCurrentObjective1' ,"", "You are The Alpha Zombie");
         return;
      }
   }
   %game.schedule(1000, "StartTimeUntilInfect", %time);
}

function InfectionGame::CheckPlayersAndLMS(%game) {
   %living = 0;
   %count = ClientGroup.getCount();
   for(%i = 0; %i < %count; %i++) {
      %client = ClientGroup.getObject(%i);
      if(!$InfectionGame::Infected[%client]) {
         if(%client.team != 0)
            %living++;
      }
   }
   if(%living == 0) {
      if($InfectionGame::RoundNumber >= $InfectionGame::Rounds) {
         %game.gameOver();
         CycleMissions();
      }
      else {
         $InfectionGame::RoundNumber++;
         %game.Intermission();
      }
   }
}

function InfectionGame::Intermission(%game) {
   MessageAll('MsgComplete',"\c5Intermission, Beginning Round "@$InfectionGame::RoundNumber@" of "@$InfectionGame::Rounds@" in 30 Seconds.");
   %count = ClientGroup.getCount();
   for(%i = 0; %i < %count; %i++) {
      %client = ClientGroup.getObject(%i);
      $InfectionGame::Infected[%client] = 0;
      $InfectionGame::IsAlpha[%client] = 0;
      $InfectionGame::ClientZombie[%client] = "Norm";

//      Game.clientChangeTeam( %client, 1, 0 );

      messageClient(%client, 'MsgSPCurrentObjective1' ,"", "Intermission");
      if(isObject(%client.player)) {
         %client.player.scriptKill(0); // no damage type = no infect :)
      }
   }
   $InfectionGame::TimeTilInfect = 30;
   %game.StartTimeUntilInfect($InfectionGame::TimeTilInfect);
}

function InfectionGame::onClientKilled(%game, %clVictim, %clKiller, %damageType, %implement, %damageLocation) {
   Parent::onClientKilled(%game, %clVictim, %clKiller, %damageType, %implement, %damageLocation);
   if(%clVictim !$= "") {
      if($InfectionGame::Infected[%clKiller] || (%damageType $= $DamageType::Zombie || %damageType $= $DamageType::Suicide || %damageType $= $DamageType::FellOff)) {
         if(!$InfectionGame::Infected[%clVictim]) {
            $InfectionGame::Infected[%clVictim] = 1;
            $InfectionGame::ClientZombie[%clVictim] = "Norm";
//            Game.clientChangeTeam( %client, 2, 0 );
            CenterPrint(%clVictim, "<color:FF0000>You have been infected.",2,3);
            Echo("Infection: "@%clVictim.namebase@" has been infected.");
            $InfectionGame::Score[%clKiller] += 10;
            messageClient(%clKiller, 'MsgSPCurrentObjective2' ,"", "Score: "@$InfectionGame::Score[%clKiller]@"");
         }
         else {
            CenterPrint(%clKiller, "<color:FF0000>Blargh, Don't kill your brothers!!! \n -5 Points",2,3);
            $InfectionGame::Score[%clKiller] -= 5;
            messageClient(%clKiller, 'MsgSPCurrentObjective2' ,"", "Score: "@$InfectionGame::Score[%clKiller]@"");
         }
      }
      else {
         if($InfectionGame::Infected[%clVictim]) {
            $InfectionGame::Score[%clKiller]++;
            messageClient(%clKiller, 'MsgSPCurrentObjective2' ,"", "Score: "@$InfectionGame::Score[%clKiller]@"");
         }
         else {
            CenterPrint(%clKiller, "<color:FF0000>Don't Kill The Living!!! \n -5 Points",2,3);
            $InfectionGame::Score[%clKiller] -= 5;
            messageClient(%clKiller, 'MsgSPCurrentObjective2' ,"", "Score: "@$InfectionGame::Score[%clKiller]@"");
         }
      }
      %game.CheckPlayersAndLMS();
   }
}

function InfectionArmors(%client, %armorList) {
   if ( %client.favorites[0] !$= "Scout") {
      %armorList = %armorList TAB "Scout";
   }
   return %armorList;
}

function InfectionGame::forceObserver( %game, %client, %reason ) {
   if($InfectionGame::IsAlpha[%client]) {
      %game.Intermission();
   }
   DefaultGame::forceObserver( %game, %client, %reason );
}

function InfectionGame::gameOver(%game) {
	//call the default
    deactivatePackage(InfectionGamePackage);
    $TWM::PlayingInfection = 0;
    $TWM::TeamWars = 0;
    $Host::RankSystem = 1;
	DefaultGame::gameOver(%game);

	//send the winner message
	%winner = "";
	messageAll('MsgClearObjHud', "");
 
	for(%i = 0; %i < ClientGroup.getCount(); %i ++) {
		%client = ClientGroup.getObject(%i);
        //reset all vars
        $InfectionGame::Infected[%client] = 0;
        $InfectionGame::IsAlpha[%client] = 0;
        $InfectionGame::Score[%client] = 0;
  
		%game.resetScore(%client);
	}
}

function InfectionGame::leaveMissionArea(%game, %playerData, %player) {
   if(%player.getState() $= "Dead")
      return;

   %player.client.outOfBounds = true;
   %player.OutsideKill = schedule(7500,0,"KillOutside", %player);
   messageClient(%player.client, 'LeaveMissionArea', '\c1You left the mission area, Return or be killed.~wfx/misc/warning_beep.wav');

}

function InfectionGame::enterMissionArea(%game, %playerData, %player) {
   if(%player.getState() $= "Dead")
      return;

   cancel(%player.OutsideKill);
   %player.client.outOfBounds = false;
   messageClient(%player.client, 'EnterMissionArea', '\c1You are back in the mission area.');
}

function KillOutside(%p) {
   if(isObject(%p) && %p.getState() !$= "dead") {
   %p.scriptKill(0);
   messageClient(%p.client, 'die', '\c1You were killed for being outside of the mission area.');
   MessageAll('Dead',"\c0"@%p.client.namebase@" was killed for leaving the mission area for too long.");
   }
}

function InfectionGame::ResetScore(%client) {

}

package InfectionGamePackage {
   function GameConnection::onDrop(%client, %reason) { //no changes made
      if($InfectionGame::IsAlpha[%client]) {
         Game.Intermission();
      }
      parent::onDrop(%client, %reason);
   }
};


//Score Hud
$ScoreHudMaxVisible = 19;
function InfectionGame::updateScoreHud(%game, %client, %tag) {
   messageClient( %client, 'SetScoreHudHeader', "", "" );
   messageClient( %client, 'SetScoreHudHeader', "", "<a:gamelink\tGTP\t1>Infection - Command Hud</a><rmargin:600><just:right><a:gamelink\tNAC\t1>Close</a>" );
   messageClient( %client, 'SetScoreHudSubheader', "", "Infection Player Settings" );
   //The Menu
   messageClient( %client, 'SetLineHud', "", %tag, %index, "Settings:");
   %index++;
   messageClient( %client, 'SetLineHud', "", %tag, %index, "Zombie Armor");
   %index++;
      messageClient( %client, 'SetLineHud', "", %tag, %index, "<a:gamelink\tSetZArmor\tNorm\t1>Normal Zombie</a> - Ability: Jet Key To Lunge");
      %index++;
      messageClient( %client, 'SetLineHud', "", %tag, %index, "<a:gamelink\tSetZArmor\tDemon\t1>Demon Zombie</a> - Ability: Jet Key To Throw Fireball");
      %index++;
   if($InfectionGame::IsAlpha[%client]) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "<a:gamelink\tSetZArmor\tLord\t1>Zombie Lord</a> - Abilities: Jet Key To Shoot Gliver, Mine Key To Lift Targets");
      %index++;
   }
   //end
   messageClient( %client, 'ClearHud', "", %tag, %index );
}

function InfectionGame::processGameLink(%game, %client, %arg1, %arg2, %arg3, %arg4, %arg5){
%tag = $TagToUseForScoreMenu;
messageClient( %client, 'ClearHud', "", %tag, 1 );
//Stuff
if(%arg1 $= "")
%arg1 = "Null";
if(%arg2 $= "")
%arg2 = "Null";
if(%arg3 $= "")
%arg3 = "Null";
if(%arg4 $= "")
%arg4 = "Null";
if(%arg5 $= "")
%arg5 = "Null";

echo("[F2] "@%client.namebase@": "@%arg1@", "@%arg2@", "@%arg3@", "@%arg4@", "@%arg5@".");
    switch$ (%arg1){
        case "NULL":
             echo("Null Arg");
             return;
   
        case "GTP":
             %game.updateScoreHud(%client, %tag); //Infection Calls This
             %client.SCMPage = %arg2;
             return;

        case "NAC":
             closeScoreHudFSERV(%client);
             return;
             
        case "SetZArmor":
             echo("Set Z Armor");
             %armor = %arg2;
             if(%armor $= "Lord" && !$InfectionGame::IsAlpha[%client]) {
                $InfectionGame::ClientZombie[%client] = "Norm";
                closeScoreHudFSERV(%client);
                MessageClient(%client, 'MsgNo', "\c5INFECTON: Only The Alpha Zombie Can Be a Zombie Lord");
                return;
             }
             $InfectionGame::ClientZombie[%client] = %armor;
             MessageClient(%client, 'MsgNo', "\c5INFECTON: Zombie Armor Set To "@%armor@"");
             %game.updateScoreHud(%client, %tag); //Infection Calls This
             return;
   }
}





























$InfectionGame::SpawnLocation["EngelamHimmel"] = "126.7 14.7 181";
$InfectionGame::SpawnLocation["DerGott"] = "0.0299911 -3.61698 155";
$InfectionGame::SpawnLocation["Strikers2"] = "-9.76935 149.965 105";
