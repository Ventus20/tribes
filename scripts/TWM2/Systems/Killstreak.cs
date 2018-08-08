$KillstreakCount = 16;
//Format: "Name\tPlayer Kills\tZombie Kills\tStreak Description"
$Killstreak[1] = "UAV\t"@$Killstreak::Kills["UAV", 0]@"\t"@$Killstreak::Kills["UAV", 1]@"\tCall in a UAV Recon to scout the enemy position";
$Killstreak[2] = "Airstrike\t"@$Killstreak::Kills["Airstrike", 0]@"\t"@$Killstreak::Kills["Airstrike", 1]@"\tCall in 4 Thundersword bombers to carbet bomb an area";
$Killstreak[3] = "UAMS\t"@$Killstreak::Kills["UAMS", 0]@"\t"@$Killstreak::Kills["UAMS", 1]@"\tCall in a UAMS to launch 3 hornet missiles and a guided missile";
$Killstreak[4] = "Helicopter\t"@$Killstreak::Kills["Heli", 0]@"\t"@$Killstreak::Kills["Heli", 1]@"\tCall in an combat helicopter for one minute";
$Killstreak[5] = "Harrier Airstrike\t"@$Killstreak::Kills["Harrier", 0]@"\t"@$Killstreak::Kills["Harrier", 1]@"\tAirstrike with a hovering plasma harrier.";
$Killstreak[6] = "Satellite Strike\t"@$Killstreak::Kills["SatBomb", 0]@"\t"@$Killstreak::Kills["SatBomb", 1]@"\tObliterate a large area with an orbital laser strike.";
$Killstreak[7] = "Gunship Helicopter\t"@$Killstreak::Kills["Gunship", 0]@"\t"@$Killstreak::Kills["Gunship", 1]@"\tCalls in a heavily armed helicopter.";
$Killstreak[8] = "Stealth Bomber\t"@$Killstreak::Kills["SlthBomb", 0]@"\t"@$Killstreak::Kills["SlthBomb", 1]@"\tCalls in a stealth bomber to carpet bomb an area.";
$Killstreak[9] = "Harbinger's Wrath\t"@$Killstreak::Kills["Harbins", 0]@"\t"@$Killstreak::Kills["Harbins", 1]@"\tBe the gunner of a harbinger gunship";
$Killstreak[10] = "Apache Gunner\t"@$Killstreak::Kills["ChopperGunner", 0]@"\t"@$Killstreak::Kills["ChopperGunner", 1]@"\tBe the gunner of an apache helicopter";
$Killstreak[11] = "AC-130 Gunner\t"@$Killstreak::Kills["AC130", 0]@"\t"@$Killstreak::Kills["AC130", 1]@"\tBe the gunner of an AC-130";
$Killstreak[12] = "Centaur Bombardment\t"@$Killstreak::Kills["Artillery", 0]@"\t"@$Killstreak::Kills["Artillery", 1]@"\tCall in a proton collider bombardment";
$Killstreak[13] = "Mass EMP\t"@$Killstreak::Kills["MassEMP", 0]@"\t"@$Killstreak::Kills["MassEMP", 1]@"\tEMP the entire enemy team for 3 minutes.";
$Killstreak[14] = "Arrow IV Nuke Strike\t"@$Killstreak::Kills["Nuke", 0]@"\t"@$Killstreak::Kills["Nuke", 1]@"\t350M Tactical Nuke.";
$Killstreak[15] = "Z-Bomb\t-1\t"@$Killstreak::Kills["ZBomb", 1]@"\tWipe out all zombies (not bosses) in a flash.";
$Killstreak[16] = "Fission Bomb\t"@$Killstreak::Kills["Fission", 0]@"\t-1\t(Matches) End the game with an explosive bang.";

function GetStreakDescrip(%val) {
   %desc = getField($Killstreak[%val], 3);
   return %desc;
}

function StreakValToName(%val) {
   %name = getField($Killstreak[%val], 0);
   return %name;
}

function GetRequiredKills(%client, %streakVal, %plZ) {
   if(!%client) {
      return;
   }
   if(%plZ == 1) {     //zombie
      %streakStr = $Killstreak[%streakVal];
      %ZKills = getField(%streakStr, 2);
      if(%ZKills < 0) {
         return 0;
      }
      else {
         if(%client.IsActivePerk("Hardline")) {
            %ZKills--;
         }
         return %ZKills;
      }
   }
   else {
      %streakStr = $Killstreak[%streakVal];
      %PlKills = getField(%streakStr, 1);
      if(%PlKills < 0) {
         return 0;
      }
      else {
         if(%client.IsActivePerk("Hardline")) {
            %PlKills--;
         }
         return %PlKills;
      }
   }
}

function GameConnection::OnUseKillstreak(%client, %ID) {
   recordAction(%client, "KSCC", %ID@"\t1");
}

//Handles Player Based Killstreaks
function DoKillstreakChecks(%client) {
   %player = %client.player;
   %UAVkills = GetRequiredKills(%client, 1, 0);
   if(%UAVkills) {
      if(%player.killsinarow == GetRequiredKills(%client, 1, 0)) {
         %client.AwardKillstreak(1, 0);
      }
   }
   %Airkills = GetRequiredKills(%client, 2, 0);
   if(%AirKills) {
      if(%player.killsinarow == GetRequiredKills(%client, 2, 0)) {
         %client.AwardKillstreak(2, 0);
      }
   }
   %GMkills = GetRequiredKills(%client, 3, 0);
   if(%GMkills) {
      if(%player.killsinarow == GetRequiredKills(%client, 3, 0)) {
         %client.AwardKillstreak(3, 0);
      }
   }
   %Helikills = GetRequiredKills(%client, 4, 0);
   if(%Helikills) {
      if(%player.killsinarow == GetRequiredKills(%client, 4, 0)) {
         %client.AwardKillstreak(4, 0);
      }
   }
   %Harrierkills = GetRequiredKills(%client, 5, 0);
   if(%Harrierkills) {
      if(%player.killsinarow == GetRequiredKills(%client, 5, 0)) {
         %client.AwardKillstreak(5, 0);
      }
   }
   %OLSkills = GetRequiredKills(%client, 6, 0);
   if(%OLSkills) {
      if(%player.killsinarow == GetRequiredKills(%client, 6, 0)) {
         %client.AwardKillstreak(6, 0);
      }
   }
   %GunHelikills = GetRequiredKills(%client, 7, 0);
   if(%GunHelikills) {
      if(%player.killsinarow == GetRequiredKills(%client, 7, 0)) {
         %client.AwardKillstreak(7, 0);
      }
   }
   %SlthBombkills = GetRequiredKills(%client, 8, 0);
   if(%SlthBombkills) {
      if(%player.killsinarow == GetRequiredKills(%client, 8, 0)) {
         %client.AwardKillstreak(8, 0);
      }
   }
   %Gunshipkills = GetRequiredKills(%client, 9, 0);
   if(%Gunshipkills) {
      if(%player.killsinarow == GetRequiredKills(%client, 9, 0)) {
         %client.AwardKillstreak(9, 0);
      }
   }
   %Helokills = GetRequiredKills(%client, 10, 0);
   if(%Helokills) {
      if(%player.killsinarow == GetRequiredKills(%client, 10, 0)) {
         %client.AwardKillstreak(10, 0);
      }
   }
   %ACKills = GetRequiredKills(%client, 11, 0);
   if(%ACKills) {
      if(%player.killsinarow == GetRequiredKills(%client, 11, 0)) {
         %client.AwardKillstreak(11, 0);
      }
   }
   %Artillerykills = GetRequiredKills(%client, 12, 0);
   if(%Artillerykills) {
      if(%player.killsinarow == GetRequiredKills(%client, 12, 0)) {
         %client.AwardKillstreak(12, 0);
      }
   }
   %MassEMPkills = GetRequiredKills(%client, 13, 0);
   if(%MassEMPkills) {
      if(%player.killsinarow == GetRequiredKills(%client, 13, 0)) {
         %client.AwardKillstreak(13, 0);
      }
   }
   %Nukekills = GetRequiredKills(%client, 14, 0);
   if(%Nukekills) {
      if(%player.killsinarow == GetRequiredKills(%client, 14, 0)) {
         %client.AwardKillstreak(14, 0);
      }
   }
   //Ignore Z-Bomb
   %Fissionkills = GetRequiredKills(%client, 16, 0);
   if(%Fissionkills) {
      if(%player.killsinarow == GetRequiredKills(%client, 16, 0)) {
         %client.AwardKillstreak(16, 0);
      }
   }
}

//Handles Zombie Based Killstreaks
function DoZKillstreakChecks(%client) {
   if($TWM::PlayingHellJump) {
      %player = %client.player;
      //Special Case Killstreaks, ignored by system
      if(%player.zombiekillsinarow == 10) {
         %client.AwardKillstreak(2);
      }
      if(%player.zombiekillsinarow == 15) {
         %client.AwardKillstreak(3);
      }
      if(%player.zombiekillsinarow == 25) {
         %client.AwardKillstreak(4);
      }
      if(%player.zombiekillsinarow == 30) {
         MessageClient(%client, 'MsgZKill', "\c5TWM2: Ammo Drop Standing by.");
         %client.HasAmmoDrop = 1; //heh, now we can use it if we die
         %player.setInventory(AmmoDropCaller, 1, true);
      }
      if(%player.zombiekillsinarow == 45) {
         MessageClient(%client, 'MsgZKill', "\c5TWM2: Full Team Respawn now available for your use.");
         %client.HasFullTeamRespawn = 1; //heh, now we can use it if we die
         %player.setInventory(FullTeamRespawnCaller, 1, true);
         %player.zombiekillsinarow = 0;
      }
      return;
   }
   %player = %client.player;
   //echo("DEBUG: "@%client@" - kills: "@%player.zombiekillsinarow@" - need: "@GetRequiredKills(%client, 2, 1)@"");
   %UAVkills = GetRequiredKills(%client, 1, 1);
   if(%UAVkills) {
      if(%player.zombiekillsinarow == GetRequiredKills(%client, 1, 1)) {
         %client.AwardKillstreak(1, 1);
      }
   }
   %Airkills = GetRequiredKills(%client, 2, 1);
   if(%AirKills) {
      if(%player.zombiekillsinarow == GetRequiredKills(%client, 2, 1)) {
         %client.AwardKillstreak(2, 1);
      }
   }
   %GMkills = GetRequiredKills(%client, 3, 1);
   if(%GMkills) {
      if(%player.zombiekillsinarow == GetRequiredKills(%client, 3, 1)) {
         %client.AwardKillstreak(3, 1);
      }
   }
   %Helikills = GetRequiredKills(%client, 4, 1);
   if(%Helikills) {
      if(%player.zombiekillsinarow == GetRequiredKills(%client, 4, 1)) {
         %client.AwardKillstreak(4, 1);
      }
   }
   %Harrierkills = GetRequiredKills(%client, 5, 1);
   if(%Harrierkills) {
      if(%player.zombiekillsinarow == GetRequiredKills(%client, 5, 1)) {
         %client.AwardKillstreak(5, 1);
      }
   }
   %OLSkills = GetRequiredKills(%client, 6, 1);
   if(%OLSkills) {
      if(%player.zombiekillsinarow == GetRequiredKills(%client, 6, 1)) {
         %client.AwardKillstreak(6, 1);
      }
   }
   %GunHelikills = GetRequiredKills(%client, 7, 1);
   if(%GunHelikills) {
      if(%player.killsinarow == GetRequiredKills(%client, 7, 1)) {
         %client.AwardKillstreak(7, 1);
      }
   }
   %SlthBombkills = GetRequiredKills(%client, 8, 1);
   if(%SlthBombkills) {
      if(%player.zombiekillsinarow == GetRequiredKills(%client, 8, 1)) {
         %client.AwardKillstreak(8, 1);
      }
   }
   %Gunshipkills = GetRequiredKills(%client, 9, 1);
   if(%Gunshipkills) {
      if(%player.zombiekillsinarow == GetRequiredKills(%client, 9, 1)) {
         %client.AwardKillstreak(9, 1);
      }
   }
   %Helokills = GetRequiredKills(%client, 10, 1);
   if(%Helokills) {
      if(%player.zombiekillsinarow == GetRequiredKills(%client, 10, 1)) {
         %client.AwardKillstreak(10, 1);
      }
   }
   %ACkills = GetRequiredKills(%client, 11, 1);
   if(%ACkills) {
      if(%player.zombiekillsinarow == GetRequiredKills(%client, 11, 1)) {
         %client.AwardKillstreak(11, 1);
      }
   }
   %Artillerykills = GetRequiredKills(%client, 12, 1);
   if(%Artillerykills) {
      if(%player.zombiekillsinarow == GetRequiredKills(%client, 12, 1)) {
         %client.AwardKillstreak(12, 1);
      }
   }
   %MassEMPkills = GetRequiredKills(%client, 13, 1);
   if(%MassEMPkills) {
      if(%player.killsinarow == GetRequiredKills(%client, 13, 1)) {
         %client.AwardKillstreak(13, 1);
      }
   }
   %Nukekills = GetRequiredKills(%client, 14, 1);
   if(%Nukekills) {
      if(%player.zombiekillsinarow == GetRequiredKills(%client, 14, 1)) {
         %client.AwardKillstreak(14, 1);
      }
   }
   %Zbombkills = GetRequiredKills(%client, 15, 1);
   if(%Zbombkills) {
      if(%player.zombiekillsinarow == GetRequiredKills(%client, 15, 1)) {
         %client.AwardKillstreak(15, 1);
      }
   }
   //Ignore fission bomb
}

function GameConnection::HasKillstreak(%client, %streakVal) {
   //checks
   switch(%streakVal) {
      case 1 or 2 or 4 or 13: //the default 3
         //UAV
         //Airstrike
         //Heli
         //Mass EMP - Added 2.6
         return 1;
      case 3:
         //UAMS
         if(%client.hasMedal(3) == 1) {
            return 1;
         }
         else {
            return 0;
         }
      case 5:
         //Harriers
         if(%client.hasMedal(12) == 1) {
            return 1;
         }
         else {
            return 0;
         }
      case 6:
         //Satellite Bombardment
         if(%client.hasMedal(13) == 1) {
            return 1;
         }
         else {
            return 0;
         }
      case 7:
         //Gunship Heli
         if(%client.hasMedal(1) == 1) {
            return 1;
         }
         else {
            return 0;
         }
      case 8:
         //Stealth Bomber
         if(%client.hasMedal(9) == 1) {
            return 1;
         }
         else {
            return 0;
         }
      case 9:
         //Harbinger's Wrath
         if(%client.hasMedal(20) == 1) {
            return 1;
         }
         else {
            return 0;
         }
      case 10:
         //Apache Gunner
         if(%client.hasMedal(8) == 1) {
            return 1;
         }
         else {
            return 0;
         }
      case 11:
         //AC130 Gunner
         if(%client.hasMedal(26) == 1) {
            return 1;
         }
         else {
            return 0;
         }
      case 12:
         //Centaur Bombardment
         if(%client.hasMedal(15) == 1) {
            return 1;
         }
         else {
            return 0;
         }
      case 14:
         //Nuke
         if(%client.hasMedal(4) == 1) {
            return 1;
         }
         else {
            return 0;
         }
      case 15:
         //ZBomb
         if(%client.CheckNWChallengeCompletion("Nuke3") == 1) {
            return 1;
         }
         else {
            return 0;
         }
      case 16:
         //Fission Bomb
         if(%client.TWM2Core.officer >= 1) {
            return 1;
         }
         else {
            return 0;
         }
      default:
         error("Invalid streak passed to GameConnection::HasKillstreak");
         return 0;
   }
}

function GameConnection::GetActiveStreakCount(%client) {
   %ct = 0;
   for(%i = 1; %i <= $KillstreakCount; %i++) {
      if(%client.isActiveStreak(%i)) {
         %ct++;
      }
   }
   return %ct;
}

function GameConnection::getMaxActiveStreaks(%client) {
   if($Killstreak::Setting == 1) {
      return 3 + %client.TWM2Core.officer;
   }
   else if($Killstreak::Setting == 2) {
      return 0; //Menu does not show
   }
   else if($Killstreak::Setting == 3) {
      return $Killstreak::StreaksPerPlayer;
   }
   else if($Killstreak::Setting == 4) {
      return 0; //Menu does not show
   }
}

function GameConnection::setStreakStatus(%client, %val, %stat) {
   if(!%client.HasKillstreak(%val)) {
      messageClient(%client, 'msgTooMany', "\c5TWM2: You cannot use this kill streak.");
      return;
   }
   if(%stat == 1) {    //Activate streak
      if(%client.GetActiveStreakCount() == %client.getMaxActiveStreaks()) {
         messageClient(%client, 'msgTooMany', "\c5TWM2: You already have all "@%client.getMaxActiveStreaks()@" Killstreaks active.");
         return;
      }
      else {
         %client.KillstreakOn[%val] = 1;
         messageClient(%client, 'msgKSOn', "\c5TWM2: Killstreak "@StreakValToName(%val)@" activated ("@%client.GetActiveStreakCount()@"/"@%client.getMaxActiveStreaks()@").");
      }
   }
   else {              //De-activate streak
      %client.KillstreakOn[%val] = 0;
      messageClient(%client, 'msgKSOff', "\c5TWM2: Killstreak "@StreakValToName(%val)@" deactivated ("@%client.GetActiveStreakCount()@"/"@%client.getMaxActiveStreaks()@").");
   }
}

function GameConnection::isActiveStreak(%client, %val) {
   //anti-hack
   if(!%client.HasKillstreak(%val)) {
      return 0;
   }
   //------
   if(%client.KillstreakOn[%val] == 1) {
      return 1;
   }
   else {
      return 0;
   }
}

function GiveTWM2Weapons(%client) {
    if(%client.HasUAV) {
       %client.player.setInventory(UAVCaller, 1, true);
    }
    if(%client.HasAirstrike) {
       %client.player.setInventory(AirstrikeCaller, 1, true);
    }
    if(%client.HasHeli) {
       %client.player.setInventory(HeliCaller, 1, true);
    }
    if(%client.HasAmmoDrop) {
       %client.player.setInventory(AmmoDropCaller, 1, true);
    }
    if(%client.HasGM) {
       %client.player.setInventory(GMCaller, 1, true);
    }
    if(%client.HasHarbinsWrath) {
       %client.player.setInventory(HarbinsWrathCaller, 1, true);
    }
    if(%client.HasChopperGunner) {
       %client.player.setInventory(ChopperGunnerCaller, 1, true);
    }
    if(%client.HasSlthAirstrike) {
       %client.player.setInventory(StealthAirstrikeCaller, 1, true);
    }
    if(%client.HasArtillery) {
       %client.player.setInventory(ArtilleryCaller, 1, true);
    }
    if(%client.HasAcGunner) {
       %client.player.setInventory(AC130Caller, 1, true);
    }
    if(%client.HasNuke) {
       %client.player.setInventory(NukeCaller, 1, true);
    }
    if(%client.HasOLS) {
       %client.player.setInventory(OLSCaller, 1, true);
    }
    if(%client.HasZBomb) {
       %client.player.setInventory(ZBombCaller, 1, true);
    }
    if(%client.HasGunshipHeli) {
       %client.player.setInventory(GunshipHeliCaller, 1, true);
    }
    if(%client.HasHarrier) {
       %client.player.setInventory(HarrierAirstrikeCaller, 1, true);
    }
    if(%client.HasFission) {
       %client.player.setInventory(FissionBombCaller, 1, true);
    }
    if(%client.HasFullTeamRespawn) {
       %client.player.setInventory(FullTeamRespawnCaller, 1, true);
    }
    if(%client.HasMassEMP) {
       %client.player.setInventory(MassEMPCaller, 1, true);
    }
    if(!%client.isconfiscated) {
	   if (%client.isAdmin) {
          %client.player.setInventory(SuperChaingun,1,true);
	   }
    }
}

function GameConnection::AwardKillstreak(%client, %streakVal, %plz) {
   if(%plz $= "") {
      %plz = 1;
   }
   //the switchith
   if($Killstreak::Setting == 4) {
      return;
   }
   if(!%client.isActiveStreak(%streakVal) && ($Killstreak::Setting != 2) && !$TWM::PlayingHelljump) {
      return;
   }
   switch(%streakVal) {
      case 1:
         MessageClient(%client, 'MsgZKill', "\c5TWM2: UAV Recon at Your Disposal.");
         %client.HasUAV = 1; //heh, now we can use it if we die
         %client.player.setInventory(UAVCaller, 1, true);
      case 2:
         MessageClient(%client, 'MsgZKill', "\c5TWM2: Airstrike Standing By.");
         %client.HasAirstrike = 1; //heh, now we can use it if we die
         %client.player.setInventory(AirstrikeCaller, 1, true);
      case 3:
         MessageClient(%client, 'MsgZKill', "\c5TWM2: Guided Missile Strike Standing By.");
         %client.HasGM = 1; //heh, now we can use it if we die
         %client.player.setInventory(GMCaller, 1, true);
      case 4:
         MessageClient(%client, 'MsgZKill', "\c5TWM2: Helicopter at your disposal.");
         %client.HasHeli = 1; //heh, now we can use it if we die
         %client.player.setInventory(HeliCaller, 1, true);
      case 5:
         MessageClient(%client, 'MsgZKill', "\c5TWM2: Plasma Harrier Strike at your disposal.");
         %client.HasHarrier = 1; //heh, now we can use it if we die
         %client.player.setInventory(HarrierAirstrikeCaller, 1, true);
      case 6:
         MessageClient(%client, 'MsgZKill', "\c5TWM2: Satellite Strike at your disposal.");
         %client.HasOLS = 1; //heh, now we can use it if we die
         %client.player.setInventory(OLSCaller, 1, true);
      case 7:
         MessageClient(%client, 'MsgZKill', "\c5TWM2: Gunship Helicopter at your disposal.");
         %client.HasGunshipHeli = 1; //heh, now we can use it if we die
         %client.player.setInventory(GunshipHeliCaller, 1, true);
      case 8:
         MessageClient(%client, 'MsgZKill', "\c5TWM2: Stealth Bomber at your disposal.");
         %client.HasSlthAirstrike = 1; //heh, now we can use it if we die
         %client.player.setInventory(StealthAirstrikeCaller, 1, true);
      case 9:
         MessageClient(%client, 'MsgZKill', "\c5TWM2: Harbinger's Wrath Standing By.");
         %client.HasHarbinsWrath = 1; //heh, now we can use it if we die
         %client.player.setInventory(HarbinsWrathCaller, 1, true);
      case 10:
         MessageClient(%client, 'MsgZKill', "\c5TWM2: Apache Gunner Standing By.");
         %client.HasChopperGunner = 1; //heh, now we can use it if we die
         %client.player.setInventory(ChopperGunnerCaller, 1, true);
      case 11:
         MessageClient(%client, 'MsgZKill', "\c5TWM2: AC-130 Gunner Standing By.");
         %client.HasAcGunner = 1; //heh, now we can use it if we die
         %client.player.setInventory(AC130Caller, 1, true);
      case 12:
         MessageClient(%client, 'MsgZKill', "\c5TWM2: Centaur Bombardment Standing By.");
         %client.HasArtillery = 1; //heh, now we can use it if we die
         %client.player.setInventory(ArtilleryCaller, 1, true);
      case 13:
         MessageClient(%client, 'MsgZKill', "\c5TWM2: Mass EMP Standing By.");
         %client.HasMassEMP = 1; //heh, now we can use it if we die
         %client.player.setInventory(MassEMPCaller, 1, true);
      case 14:
         MessageClient(%client, 'MsgZKill', "\c5TWM2: Nuclear Strike Standing By.");
         %client.HasNuke = 1; //heh, now we can use it if we die
         %client.player.setInventory(NukeCaller, 1, true);
      case 15:
         MessageClient(%client, 'MsgZKill', "\c5TWM2: Zombie Bomb Standing By... wait... holy fuck, you got "@$Killstreak::Kills["ZBomb", 1]@" zombie kills without dying!?!?");
         %client.HasZBomb = 1; //heh, now we can use it if we die
         %client.player.setInventory(ZBombCaller, 1, true);
      case 16:
         MessageClient(%client, 'MsgZKill', "\c5TWM2: Fission Bomb Ready... Obliterate everyone!!!");
         %client.HasFission = 1; //heh, now we can use it if we die
         %client.player.setInventory(FissionBombCaller, 1, true);
   }
   if(%plz == 0) {
      if(%client.IsHighestPLStreak(%streakVal)) {
         %client.player.killsinarow = 0; //reset for moar killstreaks!
      }
   }
   else {
      if(!$TWM::PlayingHellJump) {
         if(%client.IsHighestZStreak(%streakVal)) {
            %client.player.zombiekillsinarow = 0; //reset for moar killstreaks!
         }
      }
   }
}

//Modified 12-17-09 to take into consideration of hosts changing the kill values
function GameConnection::IsHighestPLStreak(%client, %streakVal) {
   %highest = 0;
   for(%i = $KillstreakCount; %i > 0; %i--) {
      %needed = GetRequiredKills(%client, %i, 0);
      if(%client.isActiveStreak(%i)) {
         if(%needed >= %highest) {
            %highest = %needed;
            %highestStr = %i;
         }
      }
   }
   //
   if(%streakVal == %highestStr) {
      return 1;
   }
   else {
      return 0;
   }
}

//Modified 12-17-09 to take into consideration of hosts changing the kill values
function GameConnection::IsHighestZStreak(%client, %streakVal) {
   %highest = 0;
   for(%i = $KillstreakCount; %i > 0; %i--) {
      %needed = GetRequiredKills(%client, %i, 1);
      if(%client.isActiveStreak(%i)) {
         if(%needed >= %highest) {
            %highest = %needed;
            %highestStr = %i;
         }
      }
   }
   //
   if(%streakVal == %highestStr) {
      echo("Streaks Reset for "@%client@" at "@%streakVal@"");
      return 1;
   }
   else {
      return 0;
   }
}
//And now the opposite of it :P
//This function isn't being used.... yet.
function GameConnection::IsLowestStreak(%client, %streakVal) {
   for(%i = 1; %i <= $KillstreakCount; %i++) {
      if(%client.isActiveStreak(%i)) {
         %lowest = %i;   //<-- This is the curent lowest active streak
         if(%lowest == %streakVal) {   //if this is the one we are checking
            return 1;   //it must be the lowest
         }
         else {
            return 0;  //otherwise, it is a higher one
         }
      }
   }
}

function GameConnection::GatherActiveStreaks(%client) {
   %count = 0;
   %str = "";
   //first part gathers the active streaks
   for(%i = 1; %i <= $KillstreakCount; %i++) {
      if(%client.isActiveStreak(%i)) {
         %count++;
         %streak[%count] = %i;
      }
   }
   //second part outputs the proper amount of string values
   for(%x = 1; %x <= %count; %x++) {
      %str = ""@%str@""@%streak[%x]@"\t";
   }
   return %str;
}

function GameConnection::DisableAllKillstreaks(%client) {
   //first part gathers the active streaks
   for(%i = 1; %i <= $KillstreakCount; %i++) {
      if(%client.isActiveStreak(%i)) {
         %client.setStreakStatus(%i, 0);
      }
   }
}




//now the menu
function GenerateKillstreakMenu(%client, %tag, %index) {
   if($Killstreak::Setting == 2) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "Streak settings are on TWM2 1.8 and below.");
      %index++;
      messageClient( %client, 'SetLineHud', "", %tag, %index, "All streaks will be earned if unlocked.");
      %index++;
      messageClient( %client, 'SetLineHud', "", %tag, %index, "Streaks You Will Get:");
      %index++;
      for(%i = 1; %i <= $KillstreakCount; %i++) {
         if(%client.HasKillstreak(%i)) {
            if(%i == 15) {
               messageClient( %client, 'SetLineHud', "", %tag, %index, ""@StreakValToName(%i)@", "@GetRequiredKills(%client, %i, 1)@" Zombie Kills: "@GetStreakDescrip(%i)@"");
               %index++;
            }
            else {
               messageClient( %client, 'SetLineHud', "", %tag, %index, ""@StreakValToName(%i)@", "@GetRequiredKills(%client, %i, 0)@" Kills: "@GetStreakDescrip(%i)@"");
               %index++;
            }
         }
         else {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "**Streak Locked**");
            %index++;
         }
      }
   }
   else if($Killstreak::Setting == 4) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "The server host has disabled killstreaks.");
      %index++;
   }
   else {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "Active Killstreaks");
      %index++;
      for(%i = 1; %i <= $KillstreakCount; %i++) {
         if(%client.isActiveStreak(%i)) {
            if(%i == 15) {
               messageClient( %client, 'SetLineHud', "", %tag, %index, ""@StreakValToName(%i)@", "@GetRequiredKills(%client, %i, 1)@" Zombie Kills: "@GetStreakDescrip(%i)@"");
               %index++;
            }
            else {
               messageClient( %client, 'SetLineHud', "", %tag, %index, ""@StreakValToName(%i)@", "@GetRequiredKills(%client, %i, 0)@" Kills: "@GetStreakDescrip(%i)@"");
               %index++;
            }
         }
      }
      //
      messageClient( %client, 'SetLineHud', "", %tag, %index, "");
      %index++;
      messageClient( %client, 'SetLineHud', "", %tag, %index, "Activate/Deactivate Streaks");
      %index++;
      for(%i = 1; %i <= $KillstreakCount; %i++) {
         if(%client.isActiveStreak(%i)) {
            if(%i == 15) {
               messageClient( %client, 'SetLineHud', "", %tag, %index, ""@StreakValToName(%i)@", "@GetRequiredKills(%client, %i, 1)@" Zombie Kills: <a:gamelink\tSetStreakStat\t"@%i@"\t0>[DEACTIVATE]</a>");
               %index++;
            }
            else {
               messageClient( %client, 'SetLineHud', "", %tag, %index, ""@StreakValToName(%i)@", "@GetRequiredKills(%client, %i, 0)@" Kills: <a:gamelink\tSetStreakStat\t"@%i@"\t0>[DEACTIVATE]</a>");
               %index++;
            }
         }
         else {
            if(%client.HasKillstreak(%i)) {
               if(%client.GetActiveStreakCount() >= %client.getMaxActiveStreaks()) {
                  if(%i == 15) {
                     messageClient( %client, 'SetLineHud', "", %tag, %index, ""@StreakValToName(%i)@", "@GetRequiredKills(%client, %i, 1)@" Zombie Kills: [MAX STREAKS ACTIVE]");
                     %index++;
                  }
                  else {
                     messageClient( %client, 'SetLineHud', "", %tag, %index, ""@StreakValToName(%i)@", "@GetRequiredKills(%client, %i, 0)@" Kills: [MAX STREAKS ACTIVE]");
                     %index++;
                  }
               }
               else {
                  if(%i == 15) {
                     messageClient( %client, 'SetLineHud', "", %tag, %index, ""@StreakValToName(%i)@", "@GetRequiredKills(%client, %i, 1)@" Zombie Kills: <a:gamelink\tSetStreakStat\t"@%i@"\t1>[ACTIVATE]</a>");
                     %index++;
                  }
                  else {
                     messageClient( %client, 'SetLineHud', "", %tag, %index, ""@StreakValToName(%i)@", "@GetRequiredKills(%client, %i, 0)@" Kills: <a:gamelink\tSetStreakStat\t"@%i@"\t1>[ACTIVATE]</a>");
                     %index++;
                  }
               }
            }
            else {
               messageClient( %client, 'SetLineHud', "", %tag, %index, "**Streak Locked**");
               %index++;
            }
         }
      }
   }
   return %index;
}

/////////////////////
function GenerateStreakChallengeMenu(%client, %tag, %index) {
   if(%client.CheckNWChallengeCompletion("UAV1")) {
      if(%client.CheckNWChallengeCompletion("UAV2")) {
         if(%client.CheckNWChallengeCompletion("UAV3")) {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "UAV Expert III - Done");
            %index++;
         }
         else {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "UAV Expert III - Call in 150 UAV Recon Satellites");
            %index++;
         }
      }
      else {
         messageClient( %client, 'SetLineHud', "", %tag, %index, "UAV Expert II - Call in 75 UAV Recon Satellites");
         %index++;
      }
   }
   else {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "UAV Expert I - Call in 30 UAV Recon Satellites");
      %index++;
   }
   //
   if(%client.CheckNWChallengeCompletion("Airstrike1")) {
      if(%client.CheckNWChallengeCompletion("Airstrike2")) {
         if(%client.CheckNWChallengeCompletion("Airstrike3")) {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "Airstrike Expert III - Done");
            %index++;
         }
         else {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "Airstrike Expert III - Call in 125 Airstrikes");
            %index++;
         }
      }
      else {
         messageClient( %client, 'SetLineHud', "", %tag, %index, "Airstrike Expert II - Call in 65 Airstrikes");
         %index++;
      }
   }
   else {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "Airstrike Expert I - Call in 25 Airstrikes");
      %index++;
   }
   //
   if(%client.CheckNWChallengeCompletion("UAMS1")) {
      if(%client.CheckNWChallengeCompletion("UAMS2")) {
         if(%client.CheckNWChallengeCompletion("UAMS3")) {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "UAMS Expert III - Done");
            %index++;
         }
         else {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "UAMS Expert III - Call in 125 Missile Strikes");
            %index++;
         }
      }
      else {
         messageClient( %client, 'SetLineHud', "", %tag, %index, "UAMS Expert II - Call in 65 Missile Strikes");
         %index++;
      }
   }
   else {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "UAMS Expert I - Call in 25 Missile Strikes");
      %index++;
   }
   //
   if(%client.CheckNWChallengeCompletion("Helicopter1")) {
      if(%client.CheckNWChallengeCompletion("Helicopter2")) {
         if(%client.CheckNWChallengeCompletion("Helicopter3")) {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "Helicopter Expert III - Done");
            %index++;
         }
         else {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "Helicopter Expert III - Call in 125 Combat Helicopters");
            %index++;
         }
      }
      else {
         messageClient( %client, 'SetLineHud', "", %tag, %index, "Helicopter Expert II - Call in 65 Combat Helicopters");
         %index++;
      }
   }
   else {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "Helicopter Expert I - Call in 25 Combat Helicopters");
      %index++;
   }
   //
   if(%client.CheckNWChallengeCompletion("Harrier1")) {
      if(%client.CheckNWChallengeCompletion("Harrier2")) {
         if(%client.CheckNWChallengeCompletion("Harrier3")) {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "Harrier Expert III - Done");
            %index++;
         }
         else {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "Harrier Expert III - Call in 110 Plasma Harrier Airstrikes");
            %index++;
         }
      }
      else {
         messageClient( %client, 'SetLineHud', "", %tag, %index, "Harrier Expert II - Call in 55 Plasma Harrier Airstrikes");
         %index++;
      }
   }
   else {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "Harrier Expert I - Call in 20 Plasma Harrier Airstrikes");
      %index++;
   }
   //
   if(%client.CheckNWChallengeCompletion("GunHeli1")) {
      if(%client.CheckNWChallengeCompletion("GunHeli2")) {
         if(%client.CheckNWChallengeCompletion("GunHeli3")) {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "Gunship Helicopter Expert III - Done");
            %index++;
         }
         else {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "Gunship Helicopter Expert III - Call in 110 Gunship Helicopters");
            %index++;
         }
      }
      else {
         messageClient( %client, 'SetLineHud', "", %tag, %index, "Gunship Helicopter Expert II - Call in 55 Gunship Helicopters");
         %index++;
      }
   }
   else {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "Gunship Helicopter Expert I - Call in 20 Gunship Helicopters");
      %index++;
   }
   //
   if(%client.CheckNWChallengeCompletion("SBomber1")) {
      if(%client.CheckNWChallengeCompletion("SBomber2")) {
         if(%client.CheckNWChallengeCompletion("SBomber3")) {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "Stealth Bomber Expert III - Done");
            %index++;
         }
         else {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "Stealth Bomber Expert III - Call in 100 Stealth Bombers");
            %index++;
         }
      }
      else {
         messageClient( %client, 'SetLineHud', "", %tag, %index, "Stealth Bomber Expert II - Call in 50 Stealth Bombers");
         %index++;
      }
   }
   else {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "Stealth Bomber Expert I - Call in 20 Stealth Bombers");
      %index++;
   }
   //
   if(%client.CheckNWChallengeCompletion("Gunship1")) {
      if(%client.CheckNWChallengeCompletion("Gunship2")) {
         if(%client.CheckNWChallengeCompletion("Gunship3")) {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "Gunship Expert III - Done");
            %index++;
         }
         else {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "Gunship Expert III - Call in 75 Harbinger Gunships");
            %index++;
         }
      }
      else {
         messageClient( %client, 'SetLineHud', "", %tag, %index, "Gunship Expert II - Call in 35 Harbinger Gunships");
         %index++;
      }
   }
   else {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "Gunship Expert I - Call in 15 Harbinger Gunships");
      %index++;
   }
   //
   if(%client.CheckNWChallengeCompletion("Apache1")) {
      if(%client.CheckNWChallengeCompletion("Apache2")) {
         if(%client.CheckNWChallengeCompletion("Apache3")) {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "Apache Expert III - Done");
            %index++;
         }
         else {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "Apache Expert III - Call in 75 Apache Gunners");
            %index++;
         }
      }
      else {
         messageClient( %client, 'SetLineHud', "", %tag, %index, "Apache Expert II - Call in 35 Apache Gunners");
         %index++;
      }
   }
   else {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "Apache Expert I - Call in 15 Apache Gunners");
      %index++;
   }
   //
   if(%client.CheckNWChallengeCompletion("Gunship3")) {
      if(%client.CheckNWChallengeCompletion("ACGunship1")) {
         if(%client.CheckNWChallengeCompletion("ACGunship2")) {
            if(%client.CheckNWChallengeCompletion("ACGunship3")) {
               messageClient( %client, 'SetLineHud', "", %tag, %index, "AC-130 Expert III - Done");
               %index++;
            }
            else {
               messageClient( %client, 'SetLineHud', "", %tag, %index, "AC-130 Expert III - Call in 75 AC130's");
               %index++;
            }
         }
         else {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "AC-130 Expert II - Call in 35 AC130's");
            %index++;
         }
      }
      else {
         messageClient( %client, 'SetLineHud', "", %tag, %index, "AC-130 Expert I - Call in 15 AC130's");
         %index++;
      }
   }
   else {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "Locked - Requires Harbinger's Wrath Expert III.");
      %index++;
   }
   //
   if(%client.CheckNWChallengeCompletion("Centaur1")) {
      if(%client.CheckNWChallengeCompletion("Centaur2")) {
         if(%client.CheckNWChallengeCompletion("Centaur3")) {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "Centaur Artillery Expert III - Done");
            %index++;
         }
         else {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "Centaur Artillery Expert III - Call in 50 Artillery Strikes");
            %index++;
         }
      }
      else {
         messageClient( %client, 'SetLineHud', "", %tag, %index, "Centaur Artillery Expert II - Call in 25 Artillery Strikes");
         %index++;
      }
   }
   else {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "Centaur Artillery Expert I - Call in 10 Artillery Strikes");
      %index++;
   }
   //
   if(%client.CheckNWChallengeCompletion("Nuke1")) {
      if(%client.CheckNWChallengeCompletion("Nuke2")) {
         if(%client.CheckNWChallengeCompletion("Nuke3")) {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "Nuke Expert III - Done");
            %index++;
         }
         else {
            messageClient( %client, 'SetLineHud', "", %tag, %index, "Nuke Expert III - Call in 25 Nukes");
            %index++;
         }
      }
      else {
         messageClient( %client, 'SetLineHud', "", %tag, %index, "Nuke Expert II - Call in 10 Nukes");
         %index++;
      }
   }
   else {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "Nuke Expert I - Call in 5 Nukes");
      %index++;
   }
   //
   return %index;
}
