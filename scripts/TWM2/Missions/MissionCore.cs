//MISSIONS
//Phantom139, for TWM2 2.5
//DO you have what it takes to complete them?

//Missions are little tasks that are performed by players.
//Some tasks require multiple players, while some only require one.

//These tasks are timed, and can only be played in the "Construction/FlatlandBig"
//If the task is completed within the given time limit, an additional
//XP Bonus is awarded, If not, oh well =p

//So, without further ado, lets begin
//Mission Vars!
$Mission::VarSet["RainDown", "TaskDetails"] = "Rain Down\tClear The Zombies with the AC130";
$Mission::VarSet["RainDown", "Orders"] = "Using the AC130's Turret, eliminate all zombies, you have 3 minutes.";
$Mission::VarSet["RainDown", "Requirement"] = "Challenge\tGunship3";
$Mission::VarSet["RainDown", "Difficulty"] = "Medium";
$Mission::VarSet["RainDown", "TimeLimit"] = 3 * 60; //3 minutes
$Mission::VarSet["RainDown", "PlayerReq"] = 1;    //1 Person
$Mission::VarSet["RainDown", "PlayerLimit"] = 1;    //1 Person
//
$Mission::VarSet["EnemyAc130Above", "TaskDetails"] = "Enemy AC-130 Above\tEscape or destroy the enemy AC130";
$Mission::VarSet["EnemyAc130Above", "Orders"] = "A enemy AC130 is attacking, escape it, or destroy it, your choice.";
$Mission::VarSet["EnemyAc130Above", "Requirement"] = "Challenge\tGunship3";
$Mission::VarSet["EnemyAc130Above", "Difficulty"] = "Extremely Challenging";
$Mission::VarSet["EnemyAc130Above", "TimeLimit"] = 15 * 60; //15 minutes
$Mission::VarSet["EnemyAc130Above", "PlayerReq"] = 1;    //1 Person
$Mission::VarSet["EnemyAc130Above", "PlayerLimit"] = 3;    //3 People
//
$Mission::VarSet["TheShallowedCity", "TaskDetails"] = "The Shallowed City\tReach the city center in 10 minutes";
$Mission::VarSet["TheShallowedCity", "Orders"] = "Reach the city center, clear enemies in your path, you have 10 minutes.";
$Mission::VarSet["TheShallowedCity", "Requirement"] = "XP\t2750000";
$Mission::VarSet["TheShallowedCity", "Difficulty"] = "Hard";
$Mission::VarSet["TheShallowedCity", "TimeLimit"] = 10 * 60; //10 minutes
$Mission::VarSet["TheShallowedCity", "PlayerReq"] = 2;    //2 People
$Mission::VarSet["TheShallowedCity", "PlayerLimit"] = 4;    //4 People
//
$Mission::VarSet["Surrounded", "TaskDetails"] = "Surrounded!\tHold out against endless amounts of zombies for 5 minutes";
$Mission::VarSet["Surrounded", "Orders"] = "We're SURROUNDED! Survive the onslaught for 5 minutes!";
$Mission::VarSet["Surrounded", "Requirement"] = "XP\t2750000";
$Mission::VarSet["Surrounded", "Difficulty"] = "Hard";
$Mission::VarSet["Surrounded", "TimeLimit"] = 5 * 60; //10 minutes
$Mission::VarSet["Surrounded", "PlayerReq"] = 1;    //1 Person
$Mission::VarSet["Surrounded", "PlayerLimit"] = 6;    //6 People
//
function CheckMissionRequirement(%client, %mission) {
   %req = $Mission::VarSet[%mission, "Requirement"];
   //
   %type = getField(%req, 0);
   %reqName = getField(%req, 1);
   //
   switch$(%type) {
      case "XP":
         %clXP = getCurrentEXP(%client);
         if(%clXP < %reqName) {
            return 0;
         }
         else {
            return 1;
         }
      case "Challenge":
         if(%client.CheckNWChallengeCompletion(%reqName)) {
            return 1;
         }
         else {
            return 0;
         }
   }
}

function CreateTWM2Mission(%client, %mission) {
   %group = NameToID("TWM2Mission");
   if(%group.inProgress) {
      messageClient(%client, 'msgNope', "\c5MISSION: A mission has been ordered or is in progress.");
      return;
   }
   if(!isObject(%client.player) || %client.player.getState() $= "Dead") {
      messageClient(%client, 'msgNope', "\c5MISSION: Dead people cannot order missions.");
      return;
   }
   if(getCurrentEXP(%client) < $Ranks::MinPoints[59] && %client.TWM2Core.officer < 1) {
      messageClient(%client, 'msgNope', "\c5MISSION: You must be a Commanding Officer (or Higher) to order missions.");
      return;
   }
   if($CurrentMissionType !$= "Construction") {
      error("TWM2 Mission: Must be in construction, aborted.");
      return;
   }
   if($CurrentMission !$= "FlatlandBig") {
      error("TWM2 Mission: Must be in FLBig, aborted.");
      return;
   }
   %timeleft = $Mission::VarSet[%mission, "TimeLimit"];
   %playerlimit = $Mission::VarSet[%mission, "PlayerLimit"];
   %playerreq = $Mission::VarSet[%mission, "PlayerReq"];
   %missionname = GetField($Mission::VarSet[%mission, "TaskDetails"], 0);
   %group = new ScriptObject(TWM2Mission) {
      mission = %mission;
      MissionName = %missionname;
      Status = "Failed";  //start here, we change it if you win
      timer = %timeleft;
      playerRequire = %playerreq;
      playerLimit = %playerlimit;
      timeToBegin = 30; //30 seconds
      Participant[1] = %client;
      ParticipantAlive[1] = true;
      Participants = 1;
      InProgress = 2;
   };
   new SimGroup(TWM2MissionAspectsGroup) {
      //this group holds our mission aspects
   };
   schedule(%group.timeToBegin * 1000, 0, "StartTWM2MissionTimer", %group);
   messageAll('msgMission', "\c5MISSION: "@%client.namebase@" has ordered a mission, press [F2] -> Mission to join in.");
   CompleteNWChallenge(%client, "SimonSays");
}

function AddClientToMission(%client) {
   %group = nameToID("TWM2Mission");
   if(%group.InProgress == 0) {
      messageClient(%client, 'msgFailed', "\c5MISSION: There is no mission to join.");
      return;
   }
   if(%group.InProgress == 1) {
      messageClient(%client, 'msgFailed', "\c5MISSION: You cannot join a mission in progress.");
      return;
   }
   if(!isObject(%client.player) || %client.player.getState() $= "Dead") {
      messageClient(%client, 'msgNope', "\c5MISSION: Dead people cannot join missions.");
      return;
   }
   //add them
   if(%group.Participants >= %group.playerLimit) {
      messageClient(%client, 'msgFailed', "\c5MISSION: This mission cannot take any more soldiers.");
      return;
   }
   //last check, for lulz
   for(%i = 1; %i <= %group.Participants; %i++) {
      if(%client == %group.Participant[%i]) {
         messageClient(%client, 'msgFailed', "\c5MISSION: Trying to join twice eh?");
         return;
      }
   }
   //
   %group.Participants++;
   %group.Participant[%group.Participants] = %client;
   %group.ParticipantAlive[%group.Participants] = true;
   messageClient(%client, 'msgFailed', "\c5MISSION: Added to the mission squad, prepare for orders.");
   CompleteNWChallenge(%client, "FromTheTop");
}

function StartTWM2MissionTimer(%group) {
   %counter = %group.Participants;
   //cleanup check
   for(%i = 0; %i < clientGroup.getCount(); %i++) {
      %cl = clientGroup.getObject(%i);
      for(%r = 1; %r <= %counter; %r++) {
         if(%cl == %group.Participant[%r]) {
            if(!isObject(%cl.player) || %cl.player.getState() $= "Dead") {
               messageClient(%cl, 'msgNope', "\c5MISSION: You have been released from the mission for being dead.");
               %cl.missionReady = false;
            }
            else {
               messageClient(%cl, 'msgNope', "\c5MISSION: Standby.... Relaying orders....");
               %cl.missionReady = true;
            }
         }
      }
   }
   //echo("checking");
   for(%r2 = 1; %r2 <= %counter; %r2++) {
      if(%group.Participant[%r2].missionReady) {
         %group.Participant[%r2].missionReady = ""; //clear the storage var
      }
      //missing clientz0r :P
      else {
         %group.Participant[%r2] = "";
         %group.ParticipantAlive[%r2] = "";
         %group.Participants--;
      }
   }
   //
   //echo("checking 2");
   if(%group.Participants < %req) {
      for(%lol = 1; %lol <= %group.Participants; %lol++) {
         messageClient(%group.Participant[%lol], 'msgFailed', "\c5MISSION: Not enough participants, Aborted.");
      }
      EndTWM2Mission(%group);
      //echo("NaP");
      return;
   }
   else {
      %group.Participants = %counter; //reset this so we don't miss out on clients.
   }
   //
   //echo("Starting");
   StartTWM2Mission(%group);
}

function AddMissionTime(%group, %time) {
   if(nameToID("TWM2Mission") == -1) {
      return;
   }
   %group.timer += %time;
}

function TWM2MissionTimerLoop(%group) {
   if(nameToID("TWM2Mission") == -1) {
      return;
   }
   //
   if(%group.timer > 0) {
      %group.timer--;
   }
   else {
      if(%group.mission !$= "") {
         schedule(1, 0, "OnTimeZero"@%group.mission@"", %group);
      }
   }
   //
   %min = getField(FormatTWM2Time(%group.timer), 0);
   %sec = getField(FormatTWM2Time(%group.timer), 1);
   //
   for(%i = 1; %i <= %group.Participants; %i++) {
      if(%group.ParticipantAlive[%i]) {
         messageClient(%group.Participant[%i], 'MsgSPCurrentObjective1', "", ""@%group.MissionName@" - "@%min@":"@%sec@"");
      }
      else {
         messageClient(%group.Participant[%i], 'MsgSPCurrentObjective1', "", ""@%group.MissionName@" - DEAD");
      }
   }
   //
   schedule(1000, 0, "TWM2MissionTimerLoop", %group);
}

function EndTWM2Mission(%group) {
   if(%group.Status $= "Failed") {
      for(%i = 1; %i <= %group.Participants; %i++) {
         messageClient(%group.Participant[%i], 'msgFailed', "\c5MISSION: You have failed the mission, work harder next time!~wfx/misc/flag_lost.wav");
         messageClient(%group.Participant[%i], 'MsgSPCurrentObjective1', "", ""@%group.MissionName@" - Mission Failed");
         schedule(5000, 0, messageClient, %group.Participant[%i], 'MsgSPCurrentObjective1' ,"", "Welcome to TWM2!");
         CompleteNWChallenge(%group.Participant[%i], "EpicFailure");
      }
   }
   else {
      if(%group.timer > 0) {
         for(%i = 1; %i <= %group.Participants; %i++) {
            messageClient(%group.Participant[%i], 'msgFailed', "\c5MISSION: Mission Acomplished! And in the time limit! Excellent work soldiers!~wfx/misc/hunters_horde.wav");
            GainExperience(%group.Participant[%i], 2500, "Mission Accomplished, Bonus EXP Recieved ");
            messageClient(%group.Participant[%i], 'MsgSPCurrentObjective1', "", ""@%group.MissionName@" - Mission Accomplished (Time!)");
            schedule(5000, 0, messageClient, %group.Participant[%i], 'MsgSPCurrentObjective1' ,"", "Welcome to TWM2!");
            CompleteNWChallenge(%group.Participant[%i], "GoldStar");
         }
      }
      else {
         for(%i = 1; %i <= %group.Participants; %i++) {
            messageClient(%group.Participant[%i], 'msgFailed', "\c5MISSION: Mission Acomplished! You need to speed it up a bit however.~wfx/misc/flag_capture.wav");
            messageClient(%group.Participant[%i], 'MsgSPCurrentObjective1', "", ""@%group.MissionName@" - Mission Accomplished");
            schedule(5000, 0, messageClient, %group.Participant[%i], 'MsgSPCurrentObjective1' ,"", "Welcome to TWM2!");
            CompleteNWChallenge(%group.Participant[%i], "Faster");
         }
      }
   }
   //
   CleanGroupAspects(NameToID("TWM2MissionAspectsGroup"));
   for(%i = 1; %i <= %group.Participants; %i++) {
      %group.Participant[%i] = "";
      %group.ParticipantAlive[%i] = "";
   }
   %group.Participants = 0;
   %group.inProgress = 0;
   %group.delete();
}

function DoTWM2MissionChecks(%client) {
   %group = nameToID("TWM2Mission");
   if(%group == -1) {
      return;
   }
   %plyr = %client.player;
   if(!isObject(%plyr) || %plyr.getState() $= "dead") {
      for(%i = 1; %i <= %group.Participants; %i++) {
         if(%group.Participant[%i] == %client) {
            %group.ParticipantAlive[%i] = false;
            CheckMissionFailure(%group);
         }
      }
   }
}

function CheckMissionFailure(%group) {
   %living = 0;
   for(%i = 1; %i <= %group.Participants; %i++) {
      if(!%group.ParticipantAlive[%i]) {

      }
      else {
         %living++;
      }
   }
   //
   if(!%living) {
      %group.Status = "Failed";
      EndTWM2Mission(%group);
   }
}

function CompleteMission(%group) {
   %group = nameToID("TWM2Mission");
   if(%group == -1) {
      return;
   }
   %group.Status = "Success";
   EndTWM2Mission(%group);
}

function StartTWM2Mission(%group) {
   if(nameToID("TWM2Mission") == -1) {
      return;
   }
   if(%group.mission !$= "") {
      echo("Mission start: "@%group@"("@%group.getName()@")");
      RelayMissionOrders(%group);
      TWM2MissionTimerLoop(%group);

      schedule(1, 0, "StartTWM2Mis"@%group.mission@"", %group);

      %group.InProgress = 1;
   }
}

function RelayMissionOrders(%group) {
   for(%i = 1; %i <= %group.Participants; %i++) {
      messageClient(%group.Participant[%i], 'msgFailed', "\c5MISSION: "@%group.MissionName@", Your Orders are to: "@$Mission::VarSet[%group.mission, "Orders"]@".");
   }
}

function MessageMissionGroup(%group, %message) {
   for(%i = 1; %i <= %group.Participants; %i++) {
      messageClient(%group.Participant[%i], 'msgGroup', ""@collapseEscape(%message)@"");
   }
}

function CleanGroupAspects(%group) {
   //kill all zombies part of the mission
   %count = MissionCleanup.getCount();
   for(%i = 0; %i < %count; %i++) {
      %obj = MissionCleanup.getObject(%i);
      if(isObject(%obj)) {
         if(%obj.iszombie) {
            if(%obj.isInTheMission) {
               %obj.scriptkill($DamageType::admin);
            }
         }
         else {
            continue;
         }
      }
   }
   //
   for(%i = 0; %i < %group.getCount(); %i++) {
      %obj = %group.getObject(%i);
      if(%obj.isPlayer()) {
         %obj.scriptKill(0); //DIE!
         %obj.delete();
      }
      else {
         %obj.delete();
      }
   }
   %group.delete();
}


//OnTimeZeroMissionName
//StartTWM2MisMissionName







//MISSION EXEC
function LoadMissions() {
   %search = "scripts/twm2/missions/*.cs";
   for(%file = findFirstFile(%search); %file !$= ""; %file = findNextFile(%search)) {
      %type = fileBase(%file); // get the name of the script
      if(%type !$= "MissionCore") {
         exec("scripts/twm2/missions/" @ %type @ ".cs");
      }
   }
}
LoadMissions();
