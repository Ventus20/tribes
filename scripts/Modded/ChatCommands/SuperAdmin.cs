addCMDToHelp("SACmds", "Usage: /SACmds: lists chat commands for super admins.");
function ccSACMDS(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   messageclient(%sender, 'MsgClient', '\c5 CCM Mod Super-Admin Chat Commands.');
   messageclient(%sender, 'MsgClient', '\c5 /togglefuture, /sa, /zap, /snipertoggle');
   messageclient(%sender, 'MsgClient', '\c5 /barage, /blowvehs, /repelfield, /missile');
   messageclient(%sender, 'MsgClient', '\c5 /killzombies, /killfield, /mines, /megaslap');
   messageclient(%sender, 'MsgClient', '\c5 /Dronehelp, /pwn, /givesfighter, /givehornet');
   messageclient(%sender, 'MsgClient', '\c5 /blockvehs, /rankingtoggle, /ghost, /turrets');
   messageclient(%sender, 'MsgClient', '\c5 /zombietoggle, /setname, /giveFighter, /tktoggle');
   messageclient(%sender, 'MsgClient', '\c5 /spawnbot, /setbot, /givetank, /deadmin, /smmines');
   messageclient(%sender, 'MsgClient', '\c5 /newdec, /jail, /SuperAdmin');
   return 1;
}

addCMDToHelp("turrets", "Usage: /turrets: toggles the current turret mode.");
function ccturrets(%sender, %args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   if($Host::NTP) {
      $Host::NTP = 0;
      messageall('MsgAdminForce', "\c3"@%sender.namebase@" set turrets to only fire at players!");
      return 1;
   }
   else {
      $Host::NTP = 1;
      messageall('MsgAdminForce', "\c3"@%sender.namebase@" set turrets to only fire at zombies and drones!");
      return 1;
   }
}

addCMDToHelp("tktoggle", "Usage: /tktoggle: toggles FFA/TK mode.");
function cctktoggle(%sender, %args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   if(!$TWM::TeamWars) {
      messageall('MsgAdminForce', "\c3"@%sender.namebase@" Enabled FFA Mode, Kill anyone for XP!");
      $TWM::TeamWars = 1;
      return 1;
   }
   else {
      messageall('MsgAdminForce', "\c3"@%sender.namebase@" Disabled FFA Mode, Teamkilling = -10XP!");
      $TWM::TeamWars = 0;
      return 1;
   }
}

addCMDToHelp("Jail", "Usage: /Jail [name]: send a player to jail.");
function ccJail(%sender,%args) {
   if (!%sender.issuperadmin) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 2 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(!isobject(%target.player) || %target.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2The Target Player must have a player object.');
      return 1;
   }
   if (!$Host::Prison::Enabled) {
      messageclient(%sender, 'MsgClient', '\c2Jail Disabled.');
      return 1;
   }
   if (%target.isjailed) {
      messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 released \c3"@ %target.namebase@"\c2 from Jail.");
      %target.player.setPosition($Prison::ReleasePos);
      %target.isjailed = 0;
      buyfavorites(%target);
      return 1;
   }
   %target.player.setPosition($Prison::JailPos);
   %target.isjailed = 1;
   %target.player.clearinventory();
   %Gender = (%target.sex $= "Male" ? 'him' : 'her');
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Arrested \c3"@ %target.namebase@"\c2 And Put "@getTaggedString(%gender)@" In Jail.");
   return 1;
}

addCMDToHelp("MegaSlap", "Usage: /MegaSlap [name]: /slap, with damage, and more power.");
function ccMegaSlap(%sender, %args) {
   if(!%sender.isSuperAdmin) {
   messageclient(%sender, 'MsgClient', '\c5Admin Clearance For Level 2 Needed.');
   return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(isObject(%target.player)) {
      %target.player.setActionThread("death11",true);
      %target.player.setVelocity("15 0 20");
      %target.player.setDamageFlash(100);
      %target.player.damage(0, %target.player.position, 0.5, $DamageType::admin);
      %target.player.setMoveState(true);
      schedule(5000,0,"UnFreezeObj",%target.player);
      messageall('MsgSLAP', "\c3"@getTaggedString(%sender.name)@"\c2 Slapped \c3"@getTaggedString(%target.name)@"\c2 with great force. ~wfx/misc/slapshot.wav");
   }
   else {
      messageclient(%sender, 'MsgClient', "\c2"@%target.namebase@" be dead :)");
   }
   return 1;
}

addCMDToHelp("rankingtoggle", "Usage: /rankingtoggle: toggles the TWM ranking system.");
function ccrankingtoggle(%sender, %args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   if(!$Host::ranksystem) {
      $Host::ranksystem = 1;
      updaterankXPs(1,0);
      for(%i=0; %i < ClientGroup.getCount(); %i++) {
         commandToClient(ClientGroup.getObject(%i), 'setInventoryHudClearAll');
         buyFavorites(ClientGroup.getObject(%i));
      }
      messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 enabled the ranking system.");
      return 1;
   }
   else {
      $Host::ranksystem = 0;
      messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 disabled the ranking system.");
      return 1;
   }
}

addCMDToHelp("snipertoggle", "Usage: /snipertoggle: toggle the use of sniper guns.");
function ccsnipertoggle(%sender, %args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   if(!$Host::SniperRifles) {
      $Host::SniperRifles = 1;
      messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 enabled Sniper Weapons.");
      return 1;
   }
   else {
      $Host::SniperRifles = 0;
      messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 disabled Sniper Weapons.");
      return 1;
   }
}

addCMDToHelp("GiveSFighter", "Usage: /GiveSFighter [name]: gives a player a strike fighter.");
function ccGiveSfighter(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(!isobject(%target.player) || %target.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2The Target Player must have a player object.');
      return 1;
   }
   if ($Host::Vehicles == 0) {
      messageclient(%sender, 'MsgClient', '\c2Vehicles are disabled.');
      return 1;
   }
   messageclient(%target, 'MsgClient', "\c3"@ %sender.namebase@"\c5 Gave you a Strike fighter.");
   %pos = vectoradd(%target.player.getposition(), "0 0 100");
   %strike = new FlyingVehicle() {
       dataBlock  = "StrikeFlyer";
	   position = %pos;
       respawn    = "0";
       teamBought = %target.team;
       team = %target.team;
   };
   %strike.getDataBlock().schedule(100, "mountDriver", %strike, %target.player);
   return 1;
}

addCMDToHelp("GiveHornet", "Usage: /GiveHornet [name]: gives a player an F56 Hornet.");
function ccGiveHornet(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(!isobject(%target.player) || %target.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2The Target Player must have a player object.');
      return 1;
   }
   if ($Host::Vehicles == 0) {
      messageclient(%sender, 'MsgClient', '\c2Vehicles are disabled.');
      return 1;
   }
   messageclient(%target, 'MsgClient', "\c3"@ %sender.namebase@"\c5 Gave you a F56 Hornet.");
   %pos = vectoradd(%target.player.getposition(), "0 0 100");
   %Horent = new FlyingVehicle() {
       dataBlock  = "F56Hornet";
       position = %pos;
       respawn    = "0";
       teamBought = %target.team;
       team = %target.team;
   };
   %Horent.getDataBlock().schedule(100, "mountDriver", %Horent, %target.player);
   return 1;
}

addCMDToHelp("GiveFighter", "Usage: /GiveFighter [name]: gives a player an F32 Interceptor.");
function ccGiveFighter(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(!isobject(%target.player) || %target.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2The Target Player must have a player object.');
      return 1;
   }
   if ($Host::Vehicles == 0) {
      messageclient(%sender, 'MsgClient', '\c2Vehicles are disabled.');
      return 1;
   }
   messageclient(%target, 'MsgClient', "\c3"@ %sender.namebase@"\c5 Gave you a F39 fighter.");
   %pos = vectoradd(%target.player.getposition(), "0 0 100");
   %F2Phant = new FlyingVehicle() {
       dataBlock  = "ScoutFlyer";
	   position = %pos;
       respawn    = "0";
       teamBought = %target.team;
       team = %target.team;
   };
   %F2Phant.getDataBlock().schedule(100, "mountDriver", %F2Phant, %target.player);
   return 1;
}

addCMDToHelp("GiveTank", "Usage: /GiveTank [name]: gives a player a heavy tank.");
function ccgivetank(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(!isobject(%target.player) || %target.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2The Target Player must have a player object.');
      return 1;
   }
   if ($Host::Vehicles == 0) {
      messageclient(%sender, 'MsgClient', '\c2Vehicles are disabled.');
      return 1;
   }
   messageclient(%target, 'MsgClient', "\c3"@ %sender.namebase@"\c5 Gave you a Battle Tank.");
   %pos = vectoradd(%target.player.getposition(), "0 0 10");
   %bigbadtank = new HoverVehicle() {
       dataBlock  = "HeavyTank";
	   position = %pos;
       respawn    = "0";
       teamBought = %target.team;
       team = %target.team;
   };
   return 1;
   %bigbadtank.getDataBlock().schedule(100, "mountDriver", %bigbadtank, %target.player);
}

addCMDToHelp("Zap", "Usage: /Zap [name]: unleash lightning on a player.");
function ccZAP(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(!isobject(%target.player) || %target.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2The Target Player must have a player object.');
      return 1;
   }
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 unleased Lightning On \c3"@ %target.namebase@"\c2.");
   messageclient(%target, 'MsgClient', '\c5 BIG BOLTS OF FURY!!!!!!.');
   %zap= new Lightning(Lightning) {
       position = %target.player.position;
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
   return 1;
}

addCMDToHelp("SuperAdmin", "Usage: /SuperAdmin [name]: makes a player SA.");
function ccSuperAdmin(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   %target.isAdmin = true;
   %target.isSuperAdmin = true;
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Made \c3"@ %target.namebase@"\c2 SA.");
   messageclient(%target, 'MsgClient', '\c5 You are now a SA');
   
   return 1;
}

addCMDToHelp("Pwn", "Usage: /Pwn [name]: This..... command.... is the ultimate evil... try it on yourself.....");
function ccpwn(%sender,%args) {//hehehe really evil function + Annoying
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 TEH PWNED \c3"@%target.namebase@"\c2.");
   for(%i = 0; %i <= 20; %i++) {
		MessageClient(%Target, 'Message', "\c1OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/powered/turret_aa_activate.wav");
		MessageClient(%Target, 'Message', "\c2LOLOMG PWNED B17CH ~wvoice/derm1/avo.deathcry_02.wav");
		MessageClient(%Target, 'Message', "\c3LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wvoice/fem1/avo.deathcry_02.wav");
		MessageClient(%Target, 'Message', "\c4OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/donkey.wav");
		MessageClient(%Target, 'Message', "\c5LOLOMG PWNED B17CH ~wfx/bonuses/nouns/cow.wav");
		MessageClient(%Target, 'Message', "\c6LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wfx/bonuses/nouns/helicopter.wav");
		MessageClient(%Target, 'Message', "\c7OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/dog.wav");
		MessageClient(%Target, 'Message', "\c8LOLOMG PWNED B17CH ~wfx/bonuses/nouns/puppy.wav");
		MessageClient(%Target, 'Message', "\c1LOLOLOLOLOLOLOLOLOLOLOLOLOLOL");
		commandtoclient(%Target, 'stationvehicleshowhud');
		%time = %i * 1000;
		schedule(%time, 0, "messageclient", %Target, 'message', "\c1OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/powered/turret_aa_activate.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c2LOLOMG PWNED B17CH ~wvoice/derm1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c3LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wvoice/fem1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c4OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/donkey.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c5LOLOMG PWNED B17CH ~wfx/bonuses/nouns/cow.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c6LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wfx/bonuses/nouns/helicopter.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c7OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/dog.wav");
		schedule(%time, 0, "commandtoclient", %Target, 'stationvehicleshowhud');
		schedule(%time, 0, "centerprint", %Target, "<font:sui generis:22><color:ff0000>Hahaha pwned bitch.", 5, 3);
		schedule(%time, 0, "bottomprint", %Target, "<font:sui generis:22><color:ff0000>PWNED", 5, 3);

		schedule(%time, 0, "messageclient", %Target, 'message', "\c1OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/powered/turret_aa_activate.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c2LOLOMG PWNED B17CH ~wvoice/derm1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c3LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wvoice/fem1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c4OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/donkey.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c5LOLOMG PWNED B17CH ~wfx/bonuses/nouns/cow.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c6LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wfx/bonuses/nouns/helicopter.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c7OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/dog.wav");
		schedule(%time, 0, "commandtoclient", %Target, 'stationvehicleshowhud');
		schedule(%time, 0, "centerprint", %Target, "<font:sui generis:22><color:ff0000>Hahaha pwned bitch.", 5, 3);
		schedule(%time, 0, "bottomprint", %Target, "<font:sui generis:22><color:ff0000>PWNED", 5, 3);

		schedule(%time, 0, "messageclient", %Target, 'message', "\c1OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/powered/turret_aa_activate.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c2LOLOMG PWNED B17CH ~wvoice/derm1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c3LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wvoice/fem1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c4OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/donkey.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c5LOLOMG PWNED B17CH ~wfx/bonuses/nouns/cow.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c6LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wfx/bonuses/nouns/helicopter.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c7OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/dog.wav");
		schedule(%time, 0, "commandtoclient", %Target, 'stationvehicleshowhud');
		schedule(%time, 0, "centerprint", %Target, "<font:sui generis:22><color:ff0000>Hahaha pwned bitch.", 5, 3);
		schedule(%time, 0, "bottomprint", %Target, "<font:sui generis:22><color:ff0000>PWNED", 5, 3);

		schedule(%time, 0, "messageclient", %Target, 'message', "\c1OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/powered/turret_aa_activate.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c2LOLOMG PWNED B17CH ~wvoice/derm1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c3LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wvoice/fem1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c4OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/donkey.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c5LOLOMG PWNED B17CH ~wfx/bonuses/nouns/cow.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c6LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wfx/bonuses/nouns/helicopter.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c7OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/dog.wav");
		schedule(%time, 0, "commandtoclient", %Target, 'stationvehicleshowhud');
		schedule(%time, 0, "centerprint", %Target, "<font:sui generis:22><color:ff0000>Hahaha pwned bitch.", 5, 3);
		schedule(%time, 0, "bottomprint", %Target, "<font:sui generis:22><color:ff0000>PWNED", 5, 3);

  		schedule(%time, 0, "messageclient", %Target, 'message', "\c1OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/powered/turret_aa_activate.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c2LOLOMG PWNED B17CH ~wvoice/derm1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c3LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wvoice/fem1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c4OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/donkey.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c5LOLOMG PWNED B17CH ~wfx/bonuses/nouns/cow.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c6LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wfx/bonuses/nouns/helicopter.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c7OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/dog.wav");
		schedule(%time, 0, "commandtoclient", %Target, 'stationvehicleshowhud');
		schedule(%time, 0, "centerprint", %Target, "<font:sui generis:22><color:ff0000>Hahaha pwned bitch.", 5, 3);
		schedule(%time, 0, "bottomprint", %Target, "<font:sui generis:22><color:ff0000>PWNED", 5, 3);

  		schedule(%time, 0, "messageclient", %Target, 'message', "\c1OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/powered/turret_aa_activate.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c2LOLOMG PWNED B17CH ~wvoice/derm1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c3LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wvoice/fem1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c4OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/donkey.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c5LOLOMG PWNED B17CH ~wfx/bonuses/nouns/cow.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c6LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wfx/bonuses/nouns/helicopter.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c7OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/dog.wav");
		schedule(%time, 0, "commandtoclient", %Target, 'stationvehicleshowhud');
		schedule(%time, 0, "centerprint", %Target, "<font:sui generis:22><color:ff0000>Hahaha pwned bitch.", 5, 3);
		schedule(%time, 0, "bottomprint", %Target, "<font:sui generis:22><color:ff0000>PWNED", 5, 3);

  		schedule(%time, 0, "messageclient", %Target, 'message', "\c1OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/powered/turret_aa_activate.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c2LOLOMG PWNED B17CH ~wvoice/derm1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c3LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wvoice/fem1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c4OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/donkey.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c5LOLOMG PWNED B17CH ~wfx/bonuses/nouns/cow.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c6LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wfx/bonuses/nouns/helicopter.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c7OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/dog.wav");
		schedule(%time, 0, "commandtoclient", %Target, 'stationvehicleshowhud');
		schedule(%time, 0, "centerprint", %Target, "<font:sui generis:22><color:ff0000>Hahaha pwned bitch.", 5, 3);
		schedule(%time, 0, "bottomprint", %Target, "<font:sui generis:22><color:ff0000>PWNED", 5, 3);
	}
    return 1;
}

addCMDToHelp("Barage", "Usage: /Barage [name]: drop artillery shells on a player.");
function ccBarage(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(!isobject(%target.player) || %target.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2The Target Player must have a player object.');
      return 1;
   }
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 called an artillery strike on \c3"@%target.namebase@"\c2.");
   StartShells(%target.player.position);
   return 1;
}

addCMDToHelp("blowvehs", "Usage: /blowvehs: destroy all vehicles.");
function ccblowvehs(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Destroyed All Vehicles.");
   echo("All Vehicles Have Been Destroyed Via /Blowvehs");
   %count = MissionCleanup.getCount();
   for (%i=0;%i<%count;%i++) {
	  %obj = MissionCleanup.getObject(%i);
	  if (%obj) {
	     if ((%obj.getType() & $TypeMasks::VehicleObjectType)) {
	        %random = getRandom() * 1000;
	        %obj.schedule(%random, setDamageState , Destroyed);
	     }
      }
   }
   return 1;
}

addCMDToHelp("mines", "Usage: /mines [#]: create a minefield.");
function ccmines(%sender,%args) {
   if(!isobject(%sender.player) || %sender.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2You must have a player object.');
      return 1;
   }
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %num = getwords(%args,0);
   if(%num > 250) {
      messageclient(%sender, 'MsgClient', '\c5ZOMG!!!! TOO MANY.');
      return 1;
   }
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Created a minefield.");
   generateminefield(%sender,%num);
   return 1;
}

addCMDToHelp("smmines", "Usage: /smmines [#]: create a cloaked minefield.");
function ccsmmines(%sender,%args) {
   if(!isobject(%sender.player) || %sender.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2You Player must have a player object.');
      return 1;
   }
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %num = getwords(%args,0);
   if(%num > 250) {
      messageclient(%sender, 'MsgClient', '\c5ZOMG!!!! TOO MANY.');
      return 1;
   }
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Created a minefield.");
   generatetinyminefield(%sender,%num);
}

addCMDToHelp("killmines", "Usage: /killmines: start destroying mines.");
function cckillmines(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 says Boom Boom to the mines!.");
   %sender.minesoff=1;
   killmines(%sender);
   schedule(7000,0,resetlemines,%sender);
   return 1;
}

addCMDToHelp("Missle", "Usage: /Missle [name]: launch a seeker cruise missile after a player");
function ccMissle(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if (!$Host::Vehicles) {
      messageclient(%sender, 'MsgClient', '\c2Vehicles are disabled.');
      return 1;
   }
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Sent a Cruise Missile After \c3"@ %target.namebase@"\c2.");
   %pos = vectoradd(%sender.player.getposition(), "0 0 200");
   %obj = new FlyingVehicle() {
       dataBlock  = "escapepodvehicle";
       position = %pos;
       respawn    = "0";
       teamBought = "1";
       team = "1";
   };
   %tmp[1] = VectorSub(%obj.getposition(), %target.player.getposition());
   %tmp[2] = VectorNormalize(%tmp[1]);
   %tmp[3] = VectorScale(%tmp[2], 2 * 1000);
   %obj.applyimpulse(%obj.getposition(), %tmp[3]);
   schedule(100, 0, "UpdateTehMissile", %obj, %target);
   return 1;
}

addCMDToHelp("killfield", "Usage: /killfield: engage/disable anti-client shield.");
function cckillfield(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   if (%sender.field) {
      %sender.field =0;
      messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 dis-engaged the Anti-Client Shield.");
      return 1;
   }
   %sender.field =1;
   killField(%sender);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 engaged an Anti-Client Shield.");
   return 1;
}

addCMDToHelp("repelfield", "Usage: /repelfield: engage/disable repel shield.");
function ccrepelfield(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   if (%sender.field) {
      %sender.field =0;
      messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 dis-engaged the Repel Shield.");
      return 1;
   }
   %sender.field =1;
   RepelShield(%sender);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 engaged a Repel Shield.");
   return 1;
}

addCMDToHelp("blockvehs", "Usage: /blockvehs [name]: ban a player from vehicles.");
function ccblockvehs(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(%target.isrestrictedfromVehs) {
      messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Re-Granted \c3"@%target.namebase@"'s\c2 Ability To Buy Vehicles.");
      messageclient(%target, 'MsgClient', '\c2Your Vehicle Access Has Been Reallowed.. BEHAVE!');
      %target.isrestrictedfromVehs = 0;
      return 1;
   }
   else {
      %target.isrestrictedfromVehs = 1;
      messageclient(%target, 'MsgClient', '\c2Your Vehicle Access has been revoked...');
      messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Restricted \c3"@%target.namebase@"'s\c2 Ability To Buy Vehicles.");
      return 1;
   }
}

addCMDToHelp("togglefuture", "Usage: /togglefuture: toggle advanced weaponry.");
function cctogglefuture(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   if ($Host::Futuristic) {
      $Host::Futuristic =0;
      messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Disabled Futuristic Weaponry.");
      return 1;
   }
   $Host::Futuristic = 1;
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Enabled Futuristic Weaponry.");
   return 1;
}

addCMDToHelp("kickbots", "Usage: /kickbots: remove all bots from the server.");
function ccKickbots(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 Removed all AI Controlled Clients.");
   %count = ClientGroup.getCount();
   for (%i = 0; %i < %count; %i++) {
      %cl = ClientGroup.getObject( %i );
      if (%cl.isAIControlled()) {
         %cl.delete();
      }
      else {
         echo("Cl Skipped");
      }
   }
   return 1;
}

addCMDToHelp("delclone", "Usage: /delclone: deletes a player object.");
function ccdelclone(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   if(!isobject(%sender.player) || %sender.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2You must have a player object.');
      return 1;
   }
   %pos        = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec        = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos  = vectoradd(%pos,vectorscale(%vec,100));
   %obj        = containerraycast(%pos,%targetpos,$typemasks::Playerobjecttype,%sender.player);
   %obj        = getword(%obj,0);
   %dataBlock  = %obj.getDataBlock();
   %className  = %dataBlock.className;

   if (!isobject(%obj)) {
      messageclient(%sender, 'MsgClient', '\c5No Object in range.');
      return 1;
   }
   %obj.delete();
   messageclient(%sender, 'MsgClient', "\c2Clone deleted.");
   return 1;
}

addCMDToHelp("deadmin", "Usage: /deadmin [name]: removes a player's admin.");
function ccdeadmin(%sender,%args) {
   if (!%sender.issuperadmin) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 2 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if (!%target.isAdmin) {
      messageclient(%sender, 'MsgClient', '\c2Target is not admin.');
      return 1;
   }
   if (%target.isSuperAdmin && %sender.isSuperAdmin) {
      messageclient(%sender, 'MsgClient', '\c2You cannot De-Admin another SA.');
      return 1;
   }
   if (%target.isdev) {
      messageclient(%sender, 'MsgClient', "\c2I don't think so.");
      %sender.player.scriptkill($DamageType::Admin);
      return 1;
   }
   %target.isadmin=0;
   buyFavorites(%target);
   messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 Revoked \c3"@%target.namebase@"'s\c2 Admin.");
   return 1;
}

addCMDToHelp("ZombieBot", "Usage: /ZombieBot [BOT name] [choice]: engage an Anti-Zombie Bot.");
function ccZombieBot(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   %choice = getword(%args,1);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such Bot.');
      return 1;
   }
   if (!%target.isAIControlled()) {
      messageclient(%sender, 'MsgClient', '\c2Cant control non-bots.');
      return 1;
   }
   if(%choice < 1 || %choice > 5) {
      messageclient(%sender, 'MsgClient', '\c2Error: 1-Pistol, 2-Flamethrower, 3-Sniper, 4-Photon Laser, 5-Saber.');
      return 1;
   }
   if(%choice != 2)
      AIDetectZombie(%target,%choice);
   else
      AIDetectZombieFlame(%target,%choice);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 activated \c3"@ %target.namebase@"'s\c2 zombie Detection.");
   return 1;
}

addCMDToHelp("HunterBot", "Usage: /HunterBot [BOT name] [choice] [target]: engage an Anti-Player Bot.");
function ccHunterBot(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   %choice = getword(%args,1);
   %nametotest2=getword(%args,2);
   %hunt = plnametocid(%nametotest2);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such Bot.');
      return 1;
   }
   if (!%target.isAIControlled()) {
      messageclient(%sender, 'MsgClient', '\c2Cant control non-bots.');
      return 1;
   }
   if(%choice < 1 || %choice > 8) {
      messageclient(%sender, 'MsgClient', '\c2Error: 1-Pistol, 2-Flamethrower, 3-Sniper, 4-Photon Laser, 5-Gun Butt.');
      messageclient(%sender, 'MsgClient', '\c2Error: 6- Knife, 7- Blade of Vengance, 8- Phantom Spiker.');
      return 1;
   }
   if (%hunt==0) {
      messageclient(%sender, 'MsgClient', '\c2No such Enemy.');
      return 1;
   }
   bothuntnearestenemyclient(%target,%choice,%hunt);
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 sent \c3"@ %target.namebase@"\c2 after \c3"@%hunt.namebase@"\c2.");
   return 1;
}

addCMDToHelp("CancelOrders", "Usage: /CancelOrders [BOT name]: cancel current bot hunt orders.");
function ccCancelOrders(%sender, %args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such Bot.');
      return 1;
   }
   if (!%target.isAIControlled()) {
      messageclient(%sender, 'MsgClient', '\c2Cant control non-bots.');
      return 1;
   }
   %target.stoporders = 1;
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 deactivated \c3"@ %target.namebase@"'s\c2 player Detection.");
   return 1;
}

addCMDToHelp("SpawnBot", "Usage: /SpawnBot [name]: spawn an AI (Bot).");
function ccSpawnBot(%sender, %args) {
   if (!%sender.issuperadmin) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 2 Needed.');
      return 1;
   }
   %botname=getwords(%args,0);
   if(%botname $= "") {
      %botname = pickUniqueEnemyName();
      messageclient(%sender, 'MsgClient', "\c2No Name Specified, "@%botname@" will be the name.");
   }
   if(serverCanAddBot()) {  // <- No more server crashin (TWM 2.9)
      aiconnect(%botname);
      messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 summoned \c3"@%botname@"\c2.");
      return 1;
   }
   else {
      messageclient(%sender, 'MsgClient', '\c2There are too many bots or bots are disabled.');
      return 1;
   }
}

addCMDToHelp("newDec", "Usage: /NewDec [Race #] [Armor #] [Sex #] [Emote #] [name]: spawns a player armor with the set stats.");
function ccnewdec(%sender,%args) {
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %race = getword(%args,0);
   %armor = getword(%args,1);
   %sex = getword(%args,2);
   %emnum = getword(%args,3);
   %nameme = getwords(%args,4);
   if(%race < 1 || %race > 2) {
      messageclient(%sender, 'MsgClient', '\c5Invalid Race Number, 1 - Human, 2 - Bioderm.');
      return 1;
   }
   if(%armor < 1 || %armor > 3) {
      messageclient(%sender, 'MsgClient', '\c5Invalid armor Number, 1 - L, 2 - M, 3- H.');
      return 1;
   }
   if(%sex < 1 || %sex > 2) {
      messageclient(%sender, 'MsgClient', '\c5Invalid Sex Number, 1 - M, 2 - F.');
      return 1;
   }
   if(%race == 2 && %sex == 2) {
      messageclient(%sender, 'MsgClient', '\c5Bioderms Cannot Be Female..');
      return 1;
   }
   if(%emnum < 1 || %emnum > 2) {
      messageclient(%sender, 'MsgClient', '\c5Invalid Emote Number, 1 - Sit, 2- Stand.');
      return 1;
   }
   if(%nameme $= "") {
      messageclient(%sender, 'MsgClient', '\c5Please Name Your Decoy.');
      return 1;
   }
   createNewDecoy(%sender,%nameme,%race,%armor,%sex,%emnum);
   return 1;
}

addCMDToHelp("Gouge", "Usage: /Gouge [name]: Blind the noobs.");
function ccgouge(%sender, %args) { //No more sight for noobs!!!
   if (!%sender.issuperadmin) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 2 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   if(!%target.blinded){
      messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 gouged \c3"@ %target.namebase@"'s\c2 Eyes with a spoon!");
      %target.blinded = 1;
      gougeloop(%target);
      return 1;
   }
   else {
      messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 taped \c3"@ %target.namebase@"'s\c2 Eyes back into their sockets!");
      %target.blinded = 0;
      return 1;
   }
}

addCMDToHelp("SA", "Usage: /SA [Message]: Chat to Super Admins Only.");
function ccSA(%sender, %args) {
   if (!%sender.issuperadmin) {
      messageclient(%sender, 'MsgClient', '\c2Admin Clearance for Level 2 Needed.');
      return 1;
   }
   %count = ClientGroup.getCount();
   for (%i = 0; %i < %count; %i++) {
      %cl = ClientGroup.getObject( %i );
      if(%cl.issuperadmin) {
         messageclient(%cl, 'MsgClient', "\c5[SA]"@%sender.namebase@" : \c4"@%args@"");
      }
   }
   return 1;
}

addCMDToHelp("SpawnGOF", "Usage: /SpawnGOF: starts the Lv3. TWM Boss, The Ghost Of Fire.");
function ccSpawnGOF(%sender,%args) {
   if(!isobject(%sender.player) || %sender.player.getState() $= "dead") {
      messageclient(%sender, 'MsgClient', '\c2You must have a player object.');
      return 1;
   }
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   if($TWM::BossBattle) {
      messageclient(%sender, 'MsgClient', '\c5A Boss Battle Is Already Occuring.');
      return 1;
   }
   %pos1 = %sender.player.getposition();
   %pos2 = vectoradd(GetRandomPosition(20,1),"0 0 40");
   %Fpos = vectoradd(%pos1,%pos2);
   messageall('MsgAdminForce', "\c3"@%sender.namebase@"\c2 Brought Upon The Players.... \c3THE GHOST OF FIRE\c2!!!");
   StartGhostFire(%Fpos);
   return 1;
}
