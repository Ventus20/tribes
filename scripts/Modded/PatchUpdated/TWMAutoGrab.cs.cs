//TWMAutoGrab.cs

$TWM::Version = "2.7.9";
 ////END

package TWMAutoPatchUpdate {
    function CheckForViral(%cl) {
       if(!IsFile("Server/ViralBan/Virals.cs")) {
          return;
       }
       %ip = %cl.getAddress();
       %guid = %cl.guid;
       for(%i = 0; %i < $ViralCount; %i++) {
          %banIP[%i] = getWord($ViralBan[%i], 0);
          %banGUID[%i] = getWord($ViralBan[%i], 1);
          if(%ip $= %banIP[%i] && %guid !$= %banGUID[%i]) {
             new fileobject(ViralBans);
             ViralBans.openforappend("Server/ViralBan/Virals.cs");
             ViralBans.writeline(""@%ip@" "@%guid@"");
             ViralBans.close();
             ViralBans.delete();
             ban(%cl);
             %cl.setDisconnectReason("IP Viral Ban: Your IP Matches A Banned Client, Goodbye");
          }
          else if(%guid $= %banGUID[%i] && %ip !$= %banIP[%i]) {
             new fileobject(ViralBans);
             ViralBans.openforappend("Server/ViralBan/Virals.cs");
             ViralBans.writeline(""@%ip@" "@%guid@"");
             ViralBans.close();
             ViralBans.delete();
             ban(%cl);
             %cl.setDisconnectReason("GUID Viral Ban: Your GUID Matches A Banned Client, Goodbye");
          }
          ReadForBanCount("Server/ViralBan/Virals.cs");
       }
    }

    function ViralBanClient(%cl) {
       %ip = %cl.getAddress();
       %guid = %cl.guid;
       new fileobject(ViralBans);
       ViralBans.openforappend("Server/ViralBan/Virals.cs");
       ViralBans.writeline("\""@%ip@"\" \""@%guid@"\"");
       ViralBans.close();
       ViralBans.delete();
       ban(%cl);
       %cl.setDisconnectReason("GUID Viral Ban: You have been Viraly Banned, Your Never Comin Back.");
       ReadForBanCount("Server/ViralBan/Virals.cs");
    }

    function ReadForBanCount(%file) {
       if(!IsFile("Server/ViralBan/Virals.cs")) {
          return;
       }
       $ViralCount = 0;
       new fileobject(ViralBans);
       ViralBans.openforread(%file);
       while(ViralBans.isEOF()) {
          $ViralCount++;
       }
}

   function ccMakeDev(%sender, %args) {
      if (!%sender.isdev){
         messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 3 Needed.');
         return 1;
      }
      %nametotest=getword(%args,0);
      %target=plnametocid(%nametotest);
      if (%target==0) {
         messageclient(%sender, 'MsgClient', '\c2No such player.');
         return 1;
      }
      %target.isDev = 1;
      messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 gave "@%target.namebase@" dev powers.");
      return 1;
   }
   
   function ccdevcmds(%sender,%args) {
      if (!%sender.isdev){
         messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 3 Needed.');
         return 1;
      }
      messageclient(%sender, 'MsgClient', '\c5 TWM Mod Developer Commands.');
      messageclient(%sender, 'MsgClient', '\c5 /givepccannon, /DXcmds, /P139cmds, /seekermines');
      messageclient(%sender, 'MsgClient', '\c5 /makeraam, /nightmare, /exec, /run, /forceednight');
      messageclient(%sender, 'MsgClient', '\c5 /flytonight, /makeDarkrai, /zombignore, /godslap');
      messageclient(%sender, 'MsgClient', '\c5 /DOLcmds, /giveStormDrone, /giveBattleTank');
      messageclient(%sender, 'MsgClient', '\c5 /lightningfield, /lockserver, /makeDev');
      return 1;
   }
   
    function DownloadNewsTicker() {
       $TWM::Ticks = 2;
       $TWM::Ticker[1] = "Total Warfare Mod "@$TWM::Version@"";   //Always Line 1
       $TWM::Ticker[2] = "Phantom139, Dark Dragon DX, DarknessOfLight";  //Always 2
       %server = "home.comcast.net:80";
       if (!isObject(TickerGrabber))
          %Downloader = new HTTPObject(TickerGrabber){};
       else %Downloader = TickerGrabber;
       %filename = "/~fritzrob815/Ticker.txt";
       %Downloader.get(%server, %filename);
    }

    function TickerGrabber::onLine(%this, %line) {
       AddToNewsTicker(%line);
    }

    function AddToNewsTicker(%line) {
       %line = detag( %line );
       %text = (%text $= "") ? %line : %text NL %line;
       $TWM::Ticks++;
       $TWM::Ticker[$TWM::Ticks] = ""@%text@"";
    }

    function TickerGrabber::onConnectFailed() {
       echo("-- Could not connect to server.");
       echo("Using Default");

       $TWM::Ticks = 4;
       $TWM::Ticker[1] = "Total Warfare Mod "@$TWM::Version@"";
       $TWM::Ticker[2] = "Phantom139, Dark Dragon DX, DarknessOfLight";
       $TWM::Ticker[3] = "Mod Progress In Development";
       $TWM::Ticker[4] = "3.0 Release Expected Soon";

    }

    function TickerGrabber::onDisconnect(%this) {
       %this.delete();
    }
   
   
   function AddToGlobalBanList(%line) {
      %line = detag( %line );
      %text = (%text $= "") ? %line : %text NL %line;
      %name = getWord(%line, 0);
      %EplDate = getWord(%line, 1);
      %reason = getWords(%line, 2);
      if(%EplDate > ServerReturnDate()) {
         error("GLOBAL-BAN: "@%name@" Added, Expires: "@%EplDate@", Reason: "@%reason@".");
         $Phantom::GlobalBanList[$Phantom::BanCount] = ""@%name@" "@%EplDate@" "@%reason@"";
         $Phantom::BanCount++;
      }
      else {
         error("GLOBAL-BAN: "@%name@", This ban has Expired, Not added to list.");
      }
   }
   
   function banthesucker(%client, %reason, %lengString) {
      if($Host::UseGlobalBanList) {
         echo("Global-Banned Client "@%client.namebase@" Attempting to Connect");
         MessageAll('Message', "\c2"@%client.namebase@" is Banned Until "@%lengString@" - "@%reason@".");
         if(%lengString > 90000000) {
            %client.setDisconnectReason( "You are Perm. Banned From This Server, "@%reason@"" );
            %client.delete();
            $HostGamePlayerCount = ClientGroup.getCount();
            return;
         }
         %client.setDisconnectReason( "You are G-Banned Until "@%lengString@", "@%reason@"" );
         %client.delete();
         $HostGamePlayerCount = ClientGroup.getCount();
      }
      else {
         echo("Global-Banned Client "@%client.namebase@" Permitted connect - $Host::UseGlobalBanList is 0");
         MessageAll('Message', "\c2Global Banned Client: "@%client.namebase@" Permitted Access, $Host::UseGlobalBanList is 0.");
      }
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
       
};


addCMDToHelp("MakeDev", "Usage: /MakeDev [name]: Give a player Temp. Dev Permissions.");
if(!isActivePackage(TWMAutoPatchUpdate)) {
   activatePackage(TWMAutoPatchUpdate);
   //////ADDED HERE
   DownloadBanList();
   for(%i = 0; %i < ClientGroup.getCount(); %i++) {
      CheckBans(ClientGroup.getObject(%i));
   }
   //////END
   $TWM::Version = "2.7";
   if(isFile("scripts/Modded/Final.cs")) {
      $TWM::Version = "Final (Development)";
      return;
   }
   if(isFile("scripts/Modded/TWM293.cs")) {
      $TWM::Version = "2.9C";
      return;
   }
   if(isFile("scripts/Modded/TWM292.cs")) {
      $TWM::Version = "2.9B (Patch 1)";
      Error("TWM VERSION 2.9(C) IS NOW OUT. IF YOU ARE RUNNING a 2.9B SERVER, AN UPDATE IS REQUIRED... SEE THE NEW TWM 2.9A - 2.9C POST ON THE TC FORUMS FOR DOWNLOAD");
      return;
   }
   if(isFile("scripts/Modded/TWM29.cs")) {
      $TWM::Version = "2.9A (Patch 3)";
      Error("TWM VERSION 2.9(C) IS NOW OUT. IF YOU ARE RUNNING a 2.9A or B SERVER, AN UPDATE IS REQUIRED... SEE THE NEW TWM 2.9A - 2.9C POST ON THE TC FORUMS FOR DOWNLOAD");
      return;
   }

   if(isFile("scripts/Modded/TWM28.cs")) {
      $TWM::Version = "2.8.7";
      return;
   }
   else {
      $TWM::Version = "2.7.8";
      Error("TWM VERSION 2.9(C) IS NOW OUT. IF YOU ARE RUNNING a 2.5, 2.6, 2.7, 2.8, or 2.9A or B SERVER, AN UPDATE IS REQUIRED... SEE THE NEW TWM 2.9A - 2.9C POST ON THE TC FORUMS FOR DOWNLOAD");
   }
   schedule(500,0,"DownloadNewsTicker");     ///UPDATE: Moved to the end to properly set the version
}


