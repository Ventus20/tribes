$HarbingerNames[0] = "James Lucas";
$HarbingerNames[1] = "Taylor Huntley";
$HarbingerNames[2] = "Jacob Miller";
$HarbingerNames[3] = "Randall Tillwall";

//Harbinger Soldiers
//fun and evil

//basic function to start one
function StartHarb(%team) {
   if(%team $= "") {
      %team = 2; //default Harbinger Clan Team #
   }
   %name = getRandom(0, 3);
   SpawnSoldier($HarbingerNames[%name], %team);
}

function SpawnSoldier(%name, %team) {
   if(!isObject("PlayerListGroup")) {
      %newGroup = new SimGroup("PlayerListGroup");
		ClientConnectionGroup.add(%newGroup);
   }
   
   %player = new Player() {
      Datablock = "MediumMaleHumanArmor";  //they are commandoes!
   };
   MissionCleanup.add(%player);
   
   %position = Game.pickTeamSpawn(%team);
   %player.setPosition(%position);

   %client = new ScriptObject() {
      className = "PlayerRep";
      name = detag(%name);
      teamId = 0; // start unassigned
      score = 0;
      ping = 0;
      packetLoss = 0;
      chatMuted = false;
      canListen = false;
      voiceEnabled = false;
      isListening = false;
      isBot = true;
   };
   PlayerListGroup.add(%client);
   
   %player.client = %client;
   %client.player = %player;
   
   %client.isHarb = 1;
   
   %client.team = %team;
   %player.target = createTarget(%player, %name, "", "Male3", '', %client.team, PlayerSensor);
   setTargetSensorData(%player.target, PlayerSensor);
   setTargetSensorGroup(%player.target, %client.team);
   setTargetName(%player.target, addtaggedstring(%name));
   setTargetSkin(%player.target, 'BEagle');
   
   %client.style = getRandom(1, 3); //determine a combat style
   
   ArmHarbingerSoldier(%client, %player);
   HarbingerSoldierAICore(%client, %player);
   HarbingerSoldierDeathLoop(%client, %player);
}

function ArmHarbingerSoldier(%client, %player) {
   //First off, lets get some details about our current situation
   //For starters. our combat style for needed guns
   switch(%client.style) {
      case 1:
         //Close Combat (SCD343 Shotgun, PG700 SMG, Colt Pistol)
         %player.setInventory(SCD343, 1, true);
         %player.setInventory(SCD343Ammo, 1, true);
         %player.ClipCount[SCD343Image.ClipName] = SCD343Image.InitialClips;
         %player.setInventory(Pg700, 1, true);
         %player.setInventory(Pg700Ammo, 45, true);
         %player.ClipCount[Pg700Image.ClipName] = SCD343Image.InitialClips;
         %player.setInventory(pistol, 1, true);
         %player.setInventory(pistolAmmo, 10, true);
         %player.ClipCount[pistolImage.ClipName] = pistolImage.InitialClips;
         %player.schedule(100, use, SCD343);
      case 2:
         //Mixed (SCD343 Shotgun, S3S Rifle, Colt Pistol)
         %player.setInventory(SCD343, 1, true);
         %player.setInventory(SCD343Ammo, 1, true);
         %player.ClipCount[SCD343Image.ClipName] = SCD343Image.InitialClips;
         %player.setInventory(S3S, 1, true);
         %player.setInventory(S3SAmmo, 30, true);
         %player.ClipCount[S3SImage.ClipName] = S3SImage.InitialClips;
         %player.setInventory(pistol, 1, true);
         %player.setInventory(pistolAmmo, 10, true);
         %player.ClipCount[pistolImage.ClipName] = pistolImage.InitialClips;
         %player.schedule(100, use, SCD343);
      case 3:
         //Long Range Combat (S3S Rifle, M1 Sniper, Desert Eagle Pistol)
         %player.setInventory(M1Sniper, 1, true);
         %player.setInventory(M1SniperAmmo, 5, true);
         %player.ClipCount[M1SniperImage.ClipName] = M1SniperImage.InitialClips;
         %player.setInventory(S3S, 1, true);
         %player.setInventory(S3SAmmo, 30, true);
         %player.ClipCount[S3SImage.ClipName] = S3SImage.InitialClips;
         %player.setInventory(DEagle, 1, true);
         %player.setInventory(DEagleAmmo, 7, true);
         %player.ClipCount[DEagleImage.ClipName] = DEagleImage.InitialClips;
         %player.schedule(100, use, DEagle);
   }
}

function HarbingerSoldierDeathLoop(%client, %player) {
   if(!isObject(%player) || %player.getState() $= "dead") {
      playDeathCry( %player ); //:p
      %client.delete();
      freeclienttarget(%player);
      return;
   }
   schedule(100, 0, "HarbingerSoldierDeathLoop", %client, %player);
}

function HarbingerSoldierAICore(%client, %player) {
   %team = %client.team;
   if(!isObject(%player) || %player.getState() $= "dead") {
      return;
   }
   if(!%client) {
      return;
   }
   //First off, lets get some details about our current situation
   //For starters. our combat style for needed guns
   switch(%client.style) {
      case 1:
         //Close Combat (SCD343 Shotgun, PG700 SMG, Colt Pistol)
      case 2:
         //Mixed (SCD343 Shotgun, S3S Rifle, Colt Pistol)
      case 3:
         //Long Range Combat (S3S Rifle, M1 Sniper, Desert Eagle Pistol)
   }
}
