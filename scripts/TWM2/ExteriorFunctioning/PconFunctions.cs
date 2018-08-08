////////////////////////////////////////////////////////////////////////////////
////////////////// PCON FUNCTIONS V.1.7 (Phantatron)                         ///
////////////////// Yep, same functions from pcon                             ///
////////////////// Script By: Phantom139                                     ///
////////////////////////////////////////////////////////////////////////////////

$host::Nobots = 1;         //hosts can disable this option to spawn bots

//returns a date integer in this format: yyyymmdd
function ServerReturnMonthDate() {
   %Current = ""@formattimestring("mm dd")@"";
   %Month = getWord(%Current, 0);
   %Day = getWord(%Current, 1);
   %IntVal = ""@%Month@""@%Day@"";
//   echo(%IntVal);
   return %IntVal;
}

function ServerReturnDate() {
   %Current = ""@formattimestring("yy mm dd")@"";
   %year = getWord(%Current, 0);
   %Month = getWord(%Current, 1);
   %Day = getWord(%Current, 2);
   %IntVal = ""@%year@""@%Month@""@%Day@"";
//   echo(%IntVal);
   return %IntVal;
}

function DownloadBanList() {
   if($Host::UseGlobalBanList) {
      $Phantom::BanCount = 0;
      %server = "www.phantomdev.net:80";
      if (!isObject(BanGet))
         %Downloader = new HTTPObject(BanGet){};
      else %Downloader = BanGet;
      %filename = "/Tribes2/Bans.txt";
      %Downloader.get(%server, %filename);
      Error("SERVER: Downloading Global Ban List From PGD.com");
   }
   else {
      Error("$Host::UseGlobalBanList is 0, G-Ban List Off");
   }
}

function BanGet::onLine(%this, %line) {
   AddToGlobalBanList(%line);
}

function AddToGlobalBanList(%line) {
   %line = detag( %line );
   %text = (%text $= "") ? %line : %text NL %line;
   %name = getWord(%line, 0);
   %EplDate = ""@getWord(%line, 1)@"";
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

function BanGet::onConnectFailed() {
   echo("-- Could not connect to PGD.");
   echo("Please Call DownloadBanList(); To Protect your server");
}

function BanGet::onDisconnect(%this) {
   %this.delete();
}

function CheckBans(%client) {
   for(%i= 0; %i < $Phantom::BanCount; %i++) {
      %nametotest = getWord($Phantom::GlobalBanList[%i], 0);
      %target = plnametocid(%nametotest);
      if(%target != 0) {
         %EplDate = getWord($Phantom::GlobalBanList[%i], 1);
         if(%EplDate > ServerReturnDate()) {
            %reason = getWords($Phantom::GlobalBanList[%i], 2);
            banthesucker(%target, %reason, %EplDate);
         }
         else {
           echo(""@getTaggedString(%client.name)@" is on the ban list, but the duration has expired");
         }
      }
      else {
         //Do Nothing
      }
   }
}

   function banthesucker(%client, %reason, %lengString) {
      if($Host::UseGlobalBanList) {
         echo("Global-Banned Client "@%client.namebase@" Attempting to Connect");
         MessageAll('Message', "\c2"@%client.namebase@" is Banned Until "@%lengString@" - "@%reason@".");
         if(%lengString > 90000000) {
            ban(%client);
            %client.setDisconnectReason( "You are Perm. Banned From This Server, "@%reason@"" );
            $HostGamePlayerCount = ClientGroup.getCount();
            return;
         }
         ban(%client);
         %client.setDisconnectReason( "You are G-Banned Until "@%lengString@", "@%reason@"" );
         $HostGamePlayerCount = ClientGroup.getCount();
      }
      else {
         echo("Global-Banned Client "@%client.namebase@" Permitted connect - $Host::UseGlobalBanList is 0");
         MessageAll('Message', "\c2Global Banned Client: "@%client.namebase@" Permitted Access, $Host::UseGlobalBanList is 0.");
      }
   }

DownloadBanList(); //download the list
package ServerRunFunctioning {
   function GameConnection::onConnect(%client, %name, %raceGender, %skin, %voice, %voicePitch) {
      parent::onConnect(%client, %name, %raceGender, %skin, %voice, %voicePitch);
      checkBans(%client);
   }
};
activatePackage(ServerRunFunctioning);
//////////

function spawnprojectile(%proj,%type,%pos,%direction,%src) {
if(%src $= "" || !%src) {
   %src = "";
}
%p = new (%type)() {
dataBlock        = %proj;
initialDirection = %direction;
initialPosition  = %pos;
damageFactor     = 1;
sourceObject     = %src;
};
MissionCleanup.add(%p);
//%p.sourceObject = %src;  //fun fun
return %p;
}

function spawnprojectileSourceMod(%proj,%type,%pos,%direction,%src) {
if(%src $= "" || !%src) {
   %src = "";
}
%p = new (%type)() {
dataBlock        = %proj;
initialDirection = %direction;
initialPosition  = %pos;
damageFactor     = 1;
//sourceObject     = %src;
};
MissionCleanup.add(%p);
%p.sourceObject = %src;  //fun fun
return %p;
}

///-------------------------------------------------------------------------------
///-------------------------------------------------------------------------------
//--- Object Commanding
function RenameObject(%Obj)
{
if (%className $= "Generator" || %className $= "Switch"){
   %obj.nametag = %args;
   %freq = %obj.powerfreq;
   setTargetName(%obj.target,addTaggedString("\c8"@%args@"\c6 Frequency "@%freq));
   return;
}

else if (%className $= "teleport"){
   %freq = %obj.Frequency;
   %obj.nametag = %args;
   setTargetName(%obj.target,addTaggedString("\c8"@%args@"\c6 Frequency "@%freq));
   return;
   }
else if (%className $= "waypoint"){
%obj.wp.schedule(10, "delete");
     %waypoint = new  (WayPoint)(){
         dataBlock        = WayPointMarker;
         position         = %obj.getPosition();
         name             = %args;
         scale            = "0.1 0.1 0.1";
         team             = getRandom(0,2);
       };
      MissionCleanup.add(%waypoint);
   %obj.wp=%waypoint;
   return;
   }
else
    setTargetName(%obj.target,addTaggedString("\c8"@%args@"\c6"));
}

//--- Various Kill Commands and Kill Functions in The Mod
function KillClientByType(%client,%type)
{
if(%type==1){  //Kill Client
%client.player.scriptkill($DamageType::Admin);
}
else if(%type==2){ //Blow Up Client
%client.player.blowup();
%client.player.scriptkill($DamageType::Admin);
}
else if(%type==3){ //Nuke Client
BunkerBusterball::onExplode("" ,"",%client.player.position);
}
else if(%type==4){ //3 Second Storm
%zap= new Lightning(Lightning)
   {
   position = %client.player.position;
   rotation = "1 0 0 0";
   scale = "55 55 100";
   dataBlock = "DefaultStorm";
   lockCount = "0";
   homingCount = "0";
   strikesPerMinute = "500";
   strikeWidth = "2.5";
   chanceToHitTarget = "100";
   strikeRadius = "10";
   boltStartRadius = "20"; //altitude the lightning starts from
   color = "0.314961 1.000000 0.576000 1.000000";
   fadeColor = "0.560000 0.860000 0.260000 1.000000";
   useFog = "1";
   shouldCloak = 0;
   };
%zap.schedule(3000, delete);
}
else if(%type==5){ //1 Second Violent Shock
%shock= new Lightning(Lightning)
   {
   position = %target.player.position;
   rotation = "1 0 0 0";
   scale = "55 55 4";
   dataBlock = "DefaultStorm";
   lockCount = "0";
   homingCount = "0";
   strikesPerMinute = "10000";
   strikeWidth = "2.5";
   chanceToHitTarget = "100";
   strikeRadius = "10";
   boltStartRadius = "1"; //altitude the lightning starts from
   color = "0.314961 1.000000 0.576000 1.000000";
   fadeColor = "0.560000 0.860000 0.260000 1.000000";
   useFog = "1";
   shouldCloak = 0;
   };
%shock.schedule(1000, delete);
}
}

//////////////////////////Defaultgame.cs - Need to fix this
//          if (%missionTypeId $= "LoadBuildingConf") {
//          %file = stripChars(%missionDisplayName,":\\/");
//            %dir = "Buildings/" @ $Phantom::LoadFolder;
//            if (%file $= "")
//            return;
//            else {
//            if (strStr(%file,"..") != -1)
//            return;
//            }
//            %file = %dir @ %file;
//            if (isFile(%file) && getSubStr(%file,strLen(%file)-3,3) $= ".cs") {
//            // Message is sent first, so clients know what happened in case server crashes
//    messageAll('MsgAdminForce', '\c2The Admin has loaded a building file. \c3(%1)', %file);
//    compile(%file);
//    exec(%file);
//   }
//   return;
//  }
// }

function createNewDecoy(%client,%name,%race,%armor,%sex,%enum) {
%gun = %client.givingto;
if(%enum == 1)
%emote = "sitting";
else if(%enum == 2)
%emote = "standing";
//armor
if(%race == 1 && %armor == 1 && %sex == 1)
%mountimage = LightMaleHumanArmor;
else if(%race == 1 && %armor == 2 && %sex == 1)
%mountimage = MediumMaleHumanArmor;
else if(%race == 1 && %armor == 3 && %sex == 1)
%mountimage = HeavyMaleHumanArmor;
else if(%race == 1 && %armor == 1 && %sex == 2)
%mountimage = LightFemaleHumanArmor;
else if(%race == 1 && %armor == 2 && %sex == 2)
%mountimage = MediumFemaleHumanArmor;
else if(%race == 1 && %armor == 3 && %sex == 2)
%mountimage = HeavyFemaleHumanArmor;
else if(%race == 2 && %armor == 1 && %sex == 1)
%mountimage = LightMaleBiodermArmor;
else if(%race == 2 && %armor == 2 && %sex == 1)
%mountimage = MediumMaleBiodermArmor;
else if(%race == 2 && %armor == 3 && %sex == 1)
%mountimage = HeavyMaleBiodermArmor;
     %objdecoy = new Player()
     {
      dataBlock = %mountimage;
      Position = %client.player.getPosition();
      };
   %objdecoy.target = createTarget(%objdecoy, %name, "", "Male1", '', 0, PlayerSensor);
   setTargetDataBlock(%objdecoy.target, %objdecoy.getDatablock());
   setTargetSensorData(%objdecoy.target, PlayerSensor);
   setTargetSensorGroup(%objdecoy.target, 0);
   setTargetName(%objdecoy.target, addtaggedstring(%name));
   %objdecoy.setActionThread(%emote,true);
   %objdecoy.isStatic = true;
   %client.player.decoy = %objdecoy;
   %objdecoy.isDecodic = 1;
   %objdecoy.setTransform(VectorAdd(%client.player.getPosition(),"0 0 0") SPC rot(%client.player));
   %objdecoy.disableMove(true);
}

function gougeloop(%client) {
if(!%client.blinded){
return;
}
else {
%client.player.setDamageFlash(1);
}
schedule(100,0,"gougeloop",%client);
}

//Scream Sound
datablock AudioProfile(NightmareScreamSound)
{
   filename    = "voice/male1/avo.deathcry_02.wav";
   description = AudioClose3d;
   preload = true;
};

function nightmareloop(%causer,%viewer,%type) {
if(%type == 1) {       //slow drain to death
   %enum = getRandom(1,5);
   switch(%enum) {
   case 1:
   %emote = "sitting";
   case 2:
   %emote = "standing";
   case 3:
   %emote = "death3";
   case 4:
   %emote = "death2";
   case 5:
   %emote = "death4";
   }
   if(!isobject(%viewer.player) || %viewer.player.getState() $= "dead") {
   %viewer.nightmared = 0;
   return;
   }
   if(!isobject(%causer.player) || %causer.player.getState() $= "dead") {
   %viewer.nightmared = 0;
   %viewer.player.setMoveState(false);
   messageclient(%sender, 'MsgClient', '\c2The source of your nightmare has been destroyed.');
   return;
   }
   %viewer.player.setMoveState(true);
   %viewer.nightmared = 1;
   %viewer.player.setActionThread(%emote,true);
   %viewer.player.setWhiteout(1.8);
   %viewer.player.setDamageFlash(1.5);
   %causer.player.playShieldEffect("1 1 1");
   serverPlay3D(NightmareScreamSound, %viewer.player.position);
   schedule(500,0,"nightmareloop",%causer, %viewer, %type);
   %viewer.player.damage(0, %viewer.player.position, 0.01, $DamageType::admin);
   %causer.player.applyRepair(0.01);
   BottomPrint(%viewer,""@%causer.namebase@"'s Nightmare Is Draining your will to live.",5,1);
   BottomPrint(%causer,"Your life is being replenished by sucking "@%viewer.namebase@"'s Dream Energy.",5,1);
   messageclient(%viewer, 'MsgClient', "~wvoice/fem1/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/fem2/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/fem3/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/fem4/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/fem5/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/male1/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/male2/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/male3/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/male4/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/male5/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/derm1/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/derm2/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/derm3/avo.deathcry_02.wav");
   }
else if(%type == 2) {        // Sleep = death
   if(!isobject(%viewer.player) || %viewer.player.getState() $= "dead") {
   %viewer.tirednightmared = 0;
   return;
   }
   if(!%viewer.tirednightmared) {
   %viewer.Nightmareticks = 0;
   return;
   }
   if(%viewer.nightmareticks $= "") {
   %viewer.nightmareticks = 0;
   }
   %viewer.Nightmareticks++;
   schedule(500,0,"nightmareloop",%causer, %viewer, %type);
      if(%viewer.Nightmareticks < 20) {
      %viewer.player.setWhiteout(0.3);
      BottomPrint(%viewer,"Something is happening, you suddenly feel tired.",5,1);
      }
      else if(%viewer.Nightmareticks >= 20 && %viewer.Nightmareticks < 70) {
      %viewer.player.setWhiteout(0.5);
      %viewer.player.damage(0, %viewer.player.position, 0.01, $DamageType::admin);   //Maybe they will understand...
      BottomPrint(%viewer,"You feel really fatigued, and are slowly drifting to sleep.",5,1);
      }
      else if(%viewer.Nightmareticks >= 70 && %viewer.Nightmareticks < 100) {
      %viewer.player.setWhiteout(0.8);
      %viewer.player.damage(0, %viewer.player.position, 0.02, $DamageType::admin);   //Maybe they will understand...
      CenterPrint(%viewer,"HURRY GET TO THE INVENTORY STATION!!!",5,1);
      BottomPrint(%viewer,"YOU UNDERSTAND NOW, THIS NIGHTMARE IS GOING TO KILL YOU",5,1);
      }
      else if(%viewer.Nightmareticks >= 100) {
      %viewer.player.setWhiteout(1.8);
      %viewer.player.damage(0, %viewer.player.position, 100.0, $DamageType::admin);
      BottomPrint(%viewer,"You fell asleep, and the nightmare killed you.",10,1);
      }
   }
else if(%type == 3) {   //I believe I can fly, I DONT belive in GRAVITY!!!
   if(!isobject(%viewer.player) || %viewer.player.getState() $= "dead") {
   %viewer.flynightmared = 0;
   return;
   }
   if(!%viewer.flynightmared) {
   %viewer.Nightmareticks = 0;
   return;
   }
   if(%viewer.nightmareticks $= "") {
   %viewer.nightmareticks = 0;
   }
   %viewer.Nightmareticks++;
   schedule(500,0,"nightmareloop",%causer, %viewer, %type);
      if(%viewer.nightmareticks < 25) {
      %viewer.player.setVelocity("0 0 300");
      BottomPrint(%viewer,"WOOOOOOOOOOHOOOOOOO FLYING",5,1);
      }
      else if(%viewer.nightmareticks >= 25 && %viewer.nightmareticks < 27) {
      %viewer.player.setVelocity("0 0 -300");
      BottomPrint(%viewer,"Oh s***!!!!!",5,1);
      }
      else if(%viewer.nightmareticks > 27) {
      CenterPrint(%viewer,"Only now you realized that even Nightmares... Are Real.",10,1);
      %viewer.flynightmared = 0;
      }
   }
}

function LockCLLoop(%client) {
   if(!%client.cllock) {
      %client.notReady = false;
      %client.camera.getDataBlock().setMode( %client.camera, "observer", %client.player );
      %client.setControlObject( %client.player );
      return;
   }
   %client.notReady = true;
   %client.camera.getDataBlock().setMode( %client.camera, "pre-game", %client.player );
   %client.setControlObject( %client.camera );
   CenterPrint(%client,"Your Soul is gone, Please Press Alt+F4 To Exit the game.",1,1);
   schedule(1000,0,"LockCLLoop",%client);
}
