function LoadRanksBase() {
   echo("Loading The Ranking System Base");
   if(!isFile(""@$TWM::RanksDirectory@"/Main.TWMSave")) {
      error("*Base File Not Located, If this is the first run this is expected");
      error("*If not, contact the mod developers.");
      error("*Creating it now*");
      new fileobject(BaseToLoad);
      BaseToLoad.openforWrite(""@$TWM::RanksDirectory@"/Main.TWMSave");
      BaseToLoad.writeLine("$Rank::numplayers = 0;");
      BaseToLoad.close();
      BaseToLoad.delete();
      exec(""@$TWM::RanksDirectory@"/Main.TWMSave");
   }
   else {
      exec(""@$TWM::RanksDirectory@"/Main.TWMSave");
   }
   echo("Checking For Top Ranks");
   if(!isFile(""@$TWM::RanksDirectory@"/TopRanks.TWMSave")) {
      echo("Not Located, Doing It Now");
      findTopRanks();
   }
   else {
      echo("Located, Attempting Execute");
      exec(""@$TWM::RanksDirectory@"/TopRanks.TWMSave");
   }
}

function CreateClientRankFile(%client) {
   if($Rank::numplayers $= "")
      $Rank::numplayers = 0;
   $Rank::numplayers++;
   echo("Updating Base File");
   new fileobject(BaseToLoad);
   BaseToLoad.openforAppend(""@$TWM::RanksDirectory@"/Main.TWMSave");
   BaseToLoad.replaceLine(""@$TWM::RanksDirectory@"/Main.TWMSave", "$Rank::numplayers = "@$Rank::numplayers@";", 1);
   BaseToLoad.writeline("$Rank::AssignedGUID["@$Rank::numplayers@"] = "@%client.guid@";");
   BaseToLoad.close();
   BaseToLoad.delete();
   exec(""@$TWM::RanksDirectory@"/Main.TWMSave");
   //Rank
   new fileobject(RankFile);
   RankFile.openforWrite(""@$TWM::RanksDirectory@"/"@%client.guid@"/Saved.TWMSave");
   RankFile.WriteLine("//Ranks File For GUID "@%client.guid@"");
   RankFile.WriteLine("//Created On "@formattimestring("yy-mm-dd")@"");
   RankFile.WriteLine("$Rank::Name["@%client.guid@"] = \""@$Rank::Name[%client.GUID]@"\";");
   RankFile.WriteLine("$Rank::Rank["@%client.guid@"] = \""@$Rank::Rank[%client.GUID]@"\";");
   RankFile.WriteLine("$Rank::Num["@%client.guid@"] = "@$Rank::Num[%client.GUID]@";");
   RankFile.WriteLine("$Rank::XP["@%client.guid@"] = "@$Rank::XP[%client.GUID]@";");
   RankFile.WriteLine("$Rank::TopPlPosition["@%client.guid@"] = "@$Rank::TopPlPosition[%client.GUID]@";");
   RankFile.WriteLine("$Rank::Phrase["@%client.guid@"] = \""@$Rank::Phrase[%client.GUID]@"\";");
   RankFile.WriteLine("$Rank::SP["@%client.guid@"] = "@$Rank::SP[%client.GUID]@";");
   RankFile.close();
   RankFile.delete();
   echo("Ranks File For "@%client.namebase@" created");
   exec(""@$TWM::RanksDirectory@"/"@%client.guid@"/Saved.TWMSave");
   MessageAll('WelcomeTheNoob',"\c4Cynthia: Welcome To Total Warfare Mod For The First Time "@%client.namebase@".");
   MessageAll('WelcomeTheNoob',"\c4Cynthia: You are player Number "@$Rank::numplayers@" To Join This Server.");
}

function UpdateRankFile(%client) {
   echo("Updating "@%client.namebase@"'s Rank File");
   %file = ""@$TWM::RanksDirectory@"/"@%client.guid@"/Saved.TWMSave";
   new fileobject(ClientRank);
   ClientRank.replaceLine(%file, "$Rank::Rank["@%client.guid@"] = \""@$Rank::Rank[%client.GUID]@"\";", 4);
   ClientRank.replaceLine(%file, "$Rank::Num["@%client.guid@"] = "@$Rank::Num[%client.GUID]@";", 5);
   ClientRank.replaceLine(%file, "$Rank::XP["@%client.guid@"] = "@$Rank::XP[%client.GUID]@";", 6);
   ClientRank.replaceLine(%file, "$Rank::TopPlPosition["@%client.guid@"] = "@$Rank::TopPlPosition[%client.GUID]@";", 7);
   ClientRank.replaceLine(%file, "$Rank::Phrase["@%client.guid@"] = \""@$Rank::Phrase[%client.GUID]@"\";", 8);
   ClientRank.replaceLine(%file, "$Rank::SP["@%client.guid@"] = "@$Rank::SP[%client.GUID]@";", 9);
   ClientRank.close();
   ClientRank.delete();
   echo("Update complete");
   exec(%file);
}

function UpdateRankFileGUID(%guid) {
   echo("Updating GUID: "@%guid@" Rank File");
   %file = ""@$TWM::RanksDirectory@"/"@%guid@"/Saved.TWMSave";
   exec(%file);
   new fileobject(ClientRank);
   ClientRank.replaceLine(%file, "$Rank::Rank["@%guid@"] = \""@$Rank::Rank[%GUID]@"\";", 4);
   ClientRank.replaceLine(%file, "$Rank::Num["@%guid@"] = "@$Rank::Num[%GUID]@";", 5);
   ClientRank.replaceLine(%file, "$Rank::XP["@%guid@"] = "@$Rank::XP[%GUID]@";", 6);
   ClientRank.replaceLine(%file, "$Rank::TopPlPosition["@%guid@"] = "@$Rank::TopPlPosition[%GUID]@";", 7);
   ClientRank.replaceLine(%file, "$Rank::Phrase["@%guid@"] = \""@$Rank::Phrase[%GUID]@"\";", 8);
   ClientRank.replaceLine(%file, "$Rank::SP["@%guid@"] = "@$Rank::SP[%GUID]@";", 9);
   ClientRank.close();
   ClientRank.delete();
   echo("Update complete");
   exec(%file);
}

function LoadClientRankfile(%client) {
   echo("Attempting To Load "@%client.namebase@"'s Ranks File");
   %file = ""@$TWM::RanksDirectory@"/"@%client.guid@"/Saved.TWMSave";
   if(!isFile(%file)) {
      echo(""@%client.namebase@" does not have a save file, creating one.");
      CreateClientRankFile(%client);
      schedule(5000,0,"UpdateRankFile", %client);
   }
   else {
      echo("File Located, Attempting To Execute...");
      exec(%file);
      schedule(5000,0,"UpdateRankFile", %client);
      echo("File Load Complete");
   }
}

function UpdateClientRank(%client) {
    %name = %client.namebase;
    $Rank::XP[%client.guid] = $Rank::XP[%client.guid] + (%client.XP - %client.lastXP);
	$Rank::SP[%client.guid] = $Rank::SP[%client.guid] + (%client.SP - %client.lastSP);
	%stat = $Rank::XP[%client.guid];
	%client.lastXP = %client.XP;
	%client.lastSP = %client.SP;
	for(%j = 49; %j > 0; %j--){        //check all ranks
	   if($Rank::XP[%client.guid] >= $Ranks::MinPoints[%j]){
		  if($Rank::Rank[%client.guid] !$= $Ranks::NewRank[%j]){
		     $Rank::Rank[%client.guid] = $Ranks::NewRank[%j];
		     $Rank::Num[%client.guid] = $Ranks::Number[%j];
		     messageAll('msgclient',"\c2"@%name@" has become a "@$Ranks::NewRank[%j]@" with a XP of "@$Rank::XP[%client.guid]@"!");
	         messageclient(%client, 'Msgclient', "\c2New Usable Items: "@$Ranks::NewItems[%j]@"");
		     bottomPrint(%client, "Congradulations "@%name@" you have been promoted to the rank of: "@$Ranks::NewRank[%j]@"!", 5, 2 );
             echo("Promotion: "@%name@" to Rank "@$Ranks::NewRank[%j]@", XP: "@$Rank::XP[%client.guid]@".");
             UpdateRankFile(%client);
		  }
		  %j = 1;
	   }
	}
   // Awards
   if($Rank::XP[%client.guid] !$= "" && %client.isReady) {
      if($Rank::XP[%client.guid] >= 200) {
         Awardclient(%client,14); //wewt
      }
      if($Rank::XP[%client.guid] >= 1000) {
         Awardclient(%client,15); //wewt
      }
      if($Rank::XP[%client.guid] >= 10000) {
         Awardclient(%client,3); //wewt
      }
      if($Rank::XP[%client.guid] >= 100000) {
         Awardclient(%client,4); //wewter
      }
      if($Rank::XP[%client.guid] >= $Ranks::MinPoints[43]) {
         Awardclient(%client,11);
         Awardclient(%client,12);
      }
      if($Rank::XP[%client.guid] >= 1000000) {
         Awardclient(%client,5); //W0000T
      }
      if($Rank::XP[%client.guid] >= $Ranks::MinPoints[48]) {
         Awardclient(%client,6);
      }
      if($Rank::XP[%client.guid] >= $Ranks::MinPoints[49]) {
         Awardclient(%client,10);
         Awardclient(%client,16);
      }
   }
}
