$Medals[1] = "Srysly";                $MedalName[1] = "Seriously!?!";           //
$Medals[2] = "HonorsA";               $MedalName[2] = "Honors Award Class A";   //
$Medals[3] = "HonorsB";               $MedalName[3] = "Honors Award Class B";   //
$Medals[4] = "HonorsC";               $MedalName[4] = "Honors Award Class C";   //
$Medals[5] = "AboutDamnTime";         $MedalName[5] = "About Damn Time";        //
$Medals[6] = "GamerExcuisite";        $MedalName[6] = "Gamer Excuisite";        //
$Medals[7] = "InvatationAccepted";    $MedalName[7] = "Invatation Accepted";    //
$Medals[8] = "Harbiend";              $MedalName[8] = "Harbi-End";              //
$Medals[9] = "ThundaStruk";           $MedalName[9] = "Thunda-Struck";          //
$Medals[10] = "TheNewGeneral";        $MedalName[10] = "The New General";       //
$Medals[11] = "RevengeAvoidedAgain";  $MedalName[11] = "Revenge Avoided Again"; //
$Medals[12] = "InsigniaDefeated";     $MedalName[12] = "Insignia Defeated";     //
$Medals[13] = "TheSourceOfAllEvil";   $MedalName[13] = "The Source Of All Evil";//
$Medals[14] = "SerialKiller";         $MedalName[14] = "Serial Killer";         //
//new medals 1.6
$Medals[15] = "LordraniussFall";      $MedalName[15] = "Lordranius's Fall";     //
$Medals[16] = "TheUltimateHeadshot";  $MedalName[16] = "The Ultimate Headshot"; //
$Medals[17] = "AGreatCommando";       $MedalName[17] = "A Great Commando";      //
$Medals[18] = "DownWithTheHarbingers";$MedalName[18] = "Down With The Harbingers"; //
$Medals[19] = "RoyalSmackdown";       $MedalName[19] = "Royal Smackdown";       //
$Medals[20] = "Hazing";               $MedalName[20] = "Hazing";                //
$Medals[21] = "GloriousFire";         $MedalName[21] = "Glorious Fire";         //
//new medals 1.9
$Medals[24] = "NuclearDawn";          $MedalName[24] = "Nuclear Dawn";          //
$Medals[25] = "HarbingersWhoa";       $MedalName[25] = "Harbinger's... whoa";   //
$Medals[26] = "HazingAC130";          $MedalName[26] = "Hazing AC130 Style";    //
$Medals[27] = "BurningNightmare";     $MedalName[27] = "Burning Nightmare";     //
$Medals[28] = "SkyFront";             $MedalName[28] = "Sky Front";             //
$Medals[29] = "DailyMax";             $MedalName[29] = "Daily Max";             //

function AwardClient(%client, %medal) {
   %type = $Medals[%medal];
   %scriptController = %client.TWM2Core;
   %file = ""@$TWM::RanksDirectory@"/"@%client.guid@"/Saved.TWMSave";
   if(!isSet(%type) || %type $= "") {
      error("Crash Block: Medal sent to writeHonorFile was blank");
      return;
   }
   if(%scriptController.hasMedal[%type]){
      return; //I have it already
   }
   %scriptController.hasMedal[%type] = 1;
   echo("Awarding Medal to Client "@%client@": "@%Type@"");
   messageClient(%client, 'msgClient', "\c5You have unlocked a new medal: "@$MedalName[%medal]@".");
   //%scriptController.save(%file);
   SaveClientFile(%client);
   return;
}

function GameConnection::hasMedal(%client, %medal) {
   %type = $Medals[%medal];
   %scriptController = %client.TWM2Core;  
   return %scriptController.hasMedal[%type] == 1 ? true : false;
}

//Now the cool part about TWM 2's Medals
//Remember that spammy old scoremenucmds in TWM 1
//this function cuts all of that out from scoremenucmds.cs
function GetClientMedals(%client, %target, %tag, %index) {
   messageClient( %client, 'SetLineHud', "", %tag, %index, "***Rank Medals***");
   %index++;
   if(%target.hasMedal(2)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*Honors Award Class A: Obtain 2,500 Total EXP");
      %index++;
   }
   if(%target.hasMedal(3)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*Honors Award Class B: Obtain 25,000 Total EXP");
      %index++;
   }
   if(%target.hasMedal(4)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*Honors Award Class C: Obtain 250,000 Total EXP");
      %index++;
   }
   if(%target.hasMedal(5)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*About Damn Time: Reach the Final Rank (3,000,000 EXP)");
      %index++;
   }
   if(%target.hasMedal(29)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*Daily Max: Earn the maximum amount of EXP for a given day");
      %index++;
   }
   messageClient( %client, 'SetLineHud', "", %tag, %index, "***Boss Medals***");
   %index++;
   if(%target.hasMedal(1)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*He Fell Again: Defeat Lord Yvex once again in the TWM Timeline");
      %index++;
   }
   if(%target.hasMedal(8)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*Harbi-End: Defeat Colonel Windshear, and end the harbinger clan's plot");
      %index++;
   }
   if(%target.hasMedal(9)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*Thunda-Struck: Defeat the ghost of lightning, and end the ghostly wrath");
      %index++;
   }
   if(%target.hasMedal(10)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*The New General: Defeat Vengenor, Yvex's new general");
      %index++;
   }
   if(%target.hasMedal(11)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*Revenge Avoided Again: Defeat Lord Rog again, Avoiding yet another revenge");
      %index++;
   }
   if(%target.hasMedal(12)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*Insignia Defeated: Defeat Major Insignia, ending the FoV's Leadership");
      %index++;
   }
   if(%target.hasMedal(28)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*Sky Front: Defeat The Classic TWM Boss, Commander Stormrider");
      %index++;
   }
   if(%target.hasMedal(15)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*Lordranius's Fall: Defeat Lordranius Trevor, the leader of the harbinger clan");
      %index++;
   }
   if(%target.hasMedal(27)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*Burning Nightmare: Defeat The Classic TWM Boss, The Ghost Of Fire");
      %index++;
   }
   if(%target.hasMedal(13)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*The Source Of All Evil: Defeat Lord Vardison, and end the second war");
      %index++;
   }
   messageClient( %client, 'SetLineHud', "", %tag, %index, "***Weapon Medals***");
   %index++;
   if(%target.hasMedal(16)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*The Ultimate Headshot: Scored a ravie headshot");
      %index++;
   }
   if(%target.hasMedal(18)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*Down With The Harbingers: Shoot down 3 enemy harbinger gunships in one match");
      %index++;
   }
   if(%target.hasMedal(25)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*Harbingers W...hoa: Shoot down someone's harbinger's wrath gunship");
      %index++;
   }
   if(%target.hasMedal(19)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*Royal Smackdown: Kill 5 Demon Lord Zombies with a centaur artillery");
      %index++;
   }
   if(%target.hasMedal(20)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*Hazing: accumulate 250 kills with the Harbinger Gunship");
      %index++;
   }
   if(%target.hasMedal(26)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*AC130 Hazing: accumulate 250 kills with the AC-130 Gunship");
      %index++;
   }
   if(%target.hasMedal(21)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*Glorious Fire: accumulate 250 kills with the A|V|X Flamethrower");
      %index++;
   }
   messageClient( %client, 'SetLineHud', "", %tag, %index, "***Other Medals***");
   %index++;
   if(%target.hasMedal(6)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*Gamer Excuisite: Play TWM 2 for a total of 24 Hours");
      %index++;
   }
   if(%target.hasMedal(7)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*Invatation Accepted: Connect your account to PGD");
      %index++;
   }
   if(%target.hasMedal(14)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*Serial Killer: Go on a kill streak of 10");
      %index++;
   }
   if(%target.hasMedal(24)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*Nuclear Dawn: Launched a nuke");
      %index++;
   }
   if(%target.hasMedal(17)) {
      messageClient( %client, 'SetLineHud', "", %tag, %index, "*A Great Commando: Scored sololy over 1000 points in a hell jump match");
      %index++;
   }
   return %index;

}
