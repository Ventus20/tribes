function ZcreateLoop(%obj)
{
  if($host::nozombs)
  return;
   if(isObject(%obj))
   {
	if(%obj.timedout == 0){
	   if(%obj.numZ <= 2 || %obj.numZ $= ""){
		ZPCreateZombie(%obj);
		if(%obj.numZ $= "")
		   %obj.numZ = 0;
		%obj.numZ++;
		%obj.timedout = 1;
		schedule(10000, %obj, "TimedInF", %obj);
	   }
	}
   	%obj.ZCLoop = schedule(2000, 0, "ZcreateLoop", %obj);
   }
}

function TimedInF(%obj){
   %obj.timedout = 0;
}

//this is for when a ZSpawn spawns a zombie
function ZPCreateZombie(%obj){
  if($host::nozombs) {
     return;
  }
   %Cpos = vectorAdd(%obj.getposition() ,%obj.getUpvector());
   if(%obj.Ztype $= ""){
	%obj.ZType = 1;
   }
   if(%obj.ZType == 1){
   	%Zombie = new player(){
	   Datablock = "ZombieArmor";
   	};
	%Cpos = vectoradd(vectoradd(vectorscale(%obj.getUpvector(),1.15),"0 0 -1.15"),%obj.getposition());
    %zname ="Zombie";
   	%zombie.Typeinfo = 1;
   }
   else if(%obj.ZType == 2){
   	%Zombie = new player(){
	   Datablock = "FZombieArmor";
   	};
	%Cpos = vectoradd(vectoradd(vectorscale(%obj.getUpvector(),1.15),"0 0 -1.15"),%obj.getposition());
    %zname ="Ravenger Zombie";
   	%zombie.Typeinfo = 2;
   }
   else if(%obj.ZType == 3){
   	%Zombie = new player(){
	   Datablock = "LordZombieArmor";
   	};
	%Cpos = vectoradd(vectoradd(vectorscale(%obj.getUpvector(),2.4),"0 0 -2.4"),%obj.getposition());
	%Zombie.mountImage(ZHead, 3);
	%Zombie.mountImage(ZBack, 4);
	%Zombie.mountImage(ZDummyslotImg, 5);
	%Zombie.mountImage(ZDummyslotImg2, 6);
	%zombie.firstFired = 0;
	%zombie.canmove = 1;
    %zname ="Zombie Lord";
    %zombie.Typeinfo = 3;
   }
   else if(%obj.ZType == 4){
	%Zombie = new player(){
	   Datablock = "DemonZombieArmor";
	};
	%zombie.mountImage(ZdummyslotImg, 4);
	%Cpos = vectoradd(vectoradd(vectorscale(%obj.getUpvector(),1.3),"0 0 -1.3"),%obj.getposition());
    %zname ="Demon Zombie";
    %zombie.Typeinfo = 4;
   }
   else if(%obj.ZType == 5){
	%Zombie = new player(){
	   Datablock = "RapierZombieArmor";
	};
	%Zombie.mountImage(ZWingImage, 3);
	%Zombie.mountImage(ZWingImage2, 4);
	%zombie.setActionThread("scoutRoot",true);
	%Cpos = vectoradd(vectoradd(vectorscale(%obj.getUpvector(),1),"0 0 -0.6"),%obj.getposition());
    %zname ="Air Rapier Zombie";
    %zombie.Typeinfo = 5;
   }
   else if(%obj.ZType == 6){
	%Zombie = new player(){
	   Datablock = "DemonZombieArmor";
	};
	%Cpos = vectoradd(vectoradd(vectorscale(%obj.getUpvector(),1.3),"0 0 -1.3"),%obj.getposition());
	%zombie.mountImage(ZSniperImage, 3);
    %zname ="Sniper Zombie";
    %zombie.Typeinfo = 6;
   }
   else if(%obj.ZType == 7){
	%Zombie = new player(){
	   Datablock = "RAAMZombieArmor";
	};
	%Cpos = vectoradd(vectoradd(vectorscale(%obj.getUpvector(),1.3),"0 0 -1.3"),%obj.getposition());
	%zombie.mountImage(ZdummyslotImg, 4);
    //RAAM's Weapon Images
    %zombie.mountImage(ZMG42BaseImage, 5);
    %zombie.mountImage(RAAMSAWImage1, 6);
    %zombie.mountImage(RAAMSAWImage2, 7);
    %zombie.mountImage(RAAMSAWImage3, 8);
    %zname ="General RAAM";
    %zombie.Typeinfo = 8;
    %zombie.shotsfired = 0;
    %zombie.rapiershield = 1;
    %zombie.israam = 1;
    schedule(100,0,"RAAMShieldUpdate",%zombie);
    superRaamSummon(%zombie);
   }
   %zombie.type = %obj.Ztype;
   %Zombie.setTransform(%Cpos);
   %Zombie.team = $zombie::team;
   %zombie.canjump = 1;
   %zombie.HasCP = 1;
   %zombie.canInfect = 1;
   if(%obj.spawnTypeset == 1)
	%obj.numZ = 3;
   else
      %zombie.CP = %obj;
   %zombie.hastarget = 1;
   %zombie.iszombie =1;
   %zombie.target = createTarget(%zombie, %zname, "", "Derm3", '', %zombie.team, PlayerSensor);
   setTargetSensorData(%zombie.target, PlayerSensor);
   setTargetSensorGroup(%zombie.target, 0);
   setTargetName(%zombie.target, addtaggedstring(%zname));
   setTargetSkin(%zombie.target, 'Horde');
   MissionCleanup.add(%Zombie);
   schedule(1000, %zombie, "ZombieLookforTarget", %zombie);
}

//This is for creation of a zombie at a location using the console
function StartAZombie(%pos, %type){
  if($host::nozombs)
  return;
   if(%Type == 1){
   	%Zombie = new player(){
	   Datablock = "ZombieArmor";
   	};
    %zname ="Zombie";
    %zombie.Typeinfo = 1;
   }
   else if(%Type == 2){
   	%Zombie = new player(){
	   Datablock = "FZombieArmor";
   	};
    %zname ="Ravenger Zombie";
    %zombie.Typeinfo = 2;
   }
   else if(%Type == 3){
   	%Zombie = new player(){
	   Datablock = "LordZombieArmor";
   	};
	%Zombie.mountImage(ZHead, 3);
	%Zombie.mountImage(ZBack, 4);
	%Zombie.mountImage(ZDummyslotImg, 5);
	%Zombie.mountImage(ZDummyslotImg2, 6);
	%zombie.firstFired = 0;
	%zombie.canmove = 1;
    %zname ="Zombie Lord";
    %zombie.Typeinfo = 3;
   }
   else if(%type == 4){
	%Zombie = new player(){
	   Datablock = "DemonZombieArmor";
	};
	%zombie.mountImage(ZdummyslotImg, 4);
    %zname ="Demon Zombie";
    %zombie.Typeinfo = 4;
   }
   else if(%type == 5){
	%Zombie = new player(){
	   Datablock = "RapierZombieArmor";
	};
	%Zombie.mountImage(ZWingImage, 3);
	%Zombie.mountImage(ZWingImage2, 4);
	%zombie.setActionThread("scoutRoot",true);
    %zname ="Air Rapier Zombie";
    %zombie.Typeinfo = 5;
   }
   else if(%type == 6){
	%Zombie = new player(){
	   Datablock = "DemonZombieArmor";
	};
    %zname ="Sniper Zombie";
	%zombie.mountImage(ZSniperImage, 3);
    %zombie.Typeinfo = 6;
   }
   else if(%type == 7){
	%zombie = new player(){
	   Datablock = "DemonZombieArmor";
	};
    %zname ="Assasin Sniper Zombie";
    %zombie.isspecific = 1;
	%zombie.mountImage(ZSniperImage, 3);
    %zombie.Typeinfo = 6;
   }
   else if(%type == 8){
   	%Zombie = new player(){
	   Datablock = "SlasherZombieArmor";
   	};
    %zname ="Slasher Zombie";
    %zombie.typeinfo = 20;
   }
   else if(%type == 9){
	%Zombie = new player(){
	   Datablock = "RAAMZombieArmor";
	};
	%zombie.mountImage(ZdummyslotImg, 4);
    //RAAM's Weapon Images
    %zombie.mountImage(ZMG42BaseImage, 5);
    %zombie.mountImage(RAAMSAWImage1, 6);
    %zombie.mountImage(RAAMSAWImage2, 7);
    %zombie.mountImage(RAAMSAWImage3, 8);
    %zname ="General RAAM";
    %zombie.Typeinfo = 8;
    %zombie.shotsfired = 0;
    %zombie.rapiershield = 1;
    %zombie.israam = 1;
    superRaamSummon(%zombie);
    schedule(100,0,"RAAMShieldUpdate",%zombie);
    schedule(500,0,"StartBossMusic","Raam", %zombie); //Starts a little later so the check runs
   }
   else if(%type == 10){
	%Zombie = new player(){
	   Datablock = "DarkraiZombieArmor";
	};
    %zname ="Lord Darkrai";
    %zombie.Typeinfo = 10;
    %zombie.sfireticks = 0;
    %zombie.usedlifeup = 0;
    superDarkraisummon(%zombie);
    RandomDarkraiNightmare(%zombie);
    schedule(500,0,"StartBossMusic","Darkrai", %zombie);
    %zombie.damage(0, %target.getposition(), 1.0, $DamageType::admin);
   }
   else if(%type == 11){   //fake darkrai
	%Zombie = new player(){
	   Datablock = "DarkraiZombieArmor";
	};
    %zname ="Lord Darkrai";
    %zombie.Typeinfo = 11;
    %zombie.sfireticks = 0;
    %zombie.usedlifeup = 1;
//    RandomDarkraiNightmare(%zombie);
    %zombie.damage(0, %target.getposition(), 450.0, $DamageType::admin);
   }
   else if(%type == 12){
	%Zombie = new player(){
	   Datablock = "LordRAAMZombieArmor";
	};
	%zombie.mountImage(ZdummyslotImg, 4);
    %zname ="Lord RAAM";
    %zombie.Typeinfo = 12;
    %zombie.rapiershield = 1;
    %zombie.isLraam = 1;
    %zombie.iszombie = 1;
    StartLRAbilities(%zombie);
    schedule(100,0,"RAAMShieldUpdate",%zombie);
    schedule(500,0,"StartBossMusic","LordRaam", %zombie);
   }
   %zombie.type = %type;
   %Zombie.setTransform(%pos);
   %Zombie.team = $zombie::team;
   %zombie.canjump = 1;
   %zombie.hastarget = 1;
   %zombie.canInfect = 1;
   MissionCleanup.add(%Zombie);
   %zombie.iszombie =1;
   %zombie.target = createTarget(%zombie, %zname, "", "Derm3", '', %zombie.team, PlayerSensor);
   setTargetSensorData(%zombie.target, PlayerSensor);
   setTargetSensorGroup(%zombie.target, 0);
   setTargetName(%zombie.target, addtaggedstring(%zname));
   setTargetSkin(%zombie.target, 'Horde');
   
//   %zombie.client = new ScriptObject() {
//      Player = %zombie;
//   };
   
   if(!%zombie.isspecific)
   schedule(1000, 0, "ZombieLookforTarget", %zombie);
}

function spawnaroundarea(%pos,%type,%am) {
for(%i=0;%i<%am;%i++) {
%time = %i * 1000;
%fpos = vectoradd(%pos,GetRandomPosition(100,1));
schedule(%time,0,"StartAZombie",%fpos,%type);
}
}

function spawnaroundclient(%cl,%type,%am) {
for(%i=0;%i<%am;%i++) {
%time = %i * 1000;
%fpos = vectoradd(%cl.player.getposition(),GetRandomPosition(100,1));
schedule(%time,0,"StartAZombie",%fpos,%type);
}
}

//This is for when someone is killed by a zombie and spawns a new one
function CreateZombie(%obj) {
  //TWM 2.9 Horde Rogue Zombie Fix
  if($host::nozombs || $TWM::PlayingHorde || $TWM::PlayingInfection) {
     return;
  }
   %Cpos = %obj.getposition();
   %Zombie = new player(){
	Datablock = "ZombieArmor";
   };
   %Zombie.setTransform(%Cpos);
   %zombie.type = 1;
   %Zombie.team = 29;
   %zombie.canjump = 1;
   %zombie.hastarget = 1;
   %zname ="Zombie";
   %zombie.iszombie =1;
   %zombie.canInfect = 1;
   MissionCleanup.add(%Zombie);
   %zombie.target = createTarget(%zombie, %zname, "", "Derm3", '', %zombie.team, PlayerSensor);
   setTargetSensorData(%zombie.target, PlayerSensor);
   setTargetSensorGroup(%zombie.target, 0);
   setTargetName(%zombie.target, addtaggedstring(%zname));
   setTargetSkin(%zombie.target, 'Horde');
   schedule(1000, %zombie, "ZombieLookforTarget", %zombie);
}

function makePersonHumanFZomb(%trans, %client){
   %client.player.delete();
   %player = new Player() {
      dataBlock = "LightMaleHumanArmor";
   };

   %player.setTransform( %trans );
   MissionCleanup.add(%player);

   // setup some info
   %player.setOwnerClient(%client);
   %player.team = 1;
   %client.outOfBounds = false;
   %player.setEnergyLevel(0);
   %client.player = %player;

   // updates client's target info for this player
   %player.setTarget(%client.target);
   setTargetDataBlock(%client.target, %player.getDatablock());
   setTargetSensorData(%client.target, PlayerSensor);
   setTargetSensorGroup(%client.target, 1);
   %client.setSensorGroup(1);

   %client.setControlObject(%player);
   %player.client.clearBackpackIcon();
   buyFavorites(%client);

   %player.iszombie = 0;
}

function makePersonZombie(%trans, %client){
   %client.player.delete();

   %player = new Player() {
      dataBlock = "ZombieArmor";
   };

   %player.setTransform( %trans );
   MissionCleanup.add(%player);

   // setup some info
   %player.setOwnerClient(%client);
   %player.team = 2;
   %client.outOfBounds = false;
   %player.setEnergyLevel(0);
   %client.player = %player;
   %player.iszombie =1;
   %player.canInfect = 1;

   // updates client's target info for this player
   %player.setTarget(%client.target);
   setTargetDataBlock(%client.target, %player.getDatablock());
   setTargetSensorData(%client.target, PlayerSensor);
   setTargetSensorGroup(%client.target, 2);
   %client.setSensorGroup(2);

   %client.setControlObject(%player);
   %player.client.clearBackpackIcon();

   %player.iszombie = 1;

   ZombieBloodLust(%player,0);
   zombieAttackImpulse(%player,80);
}

function makePersonDemonZombie(%trans, %client){
   %client.player.delete();

   %player = new Player() {
      dataBlock = "DemonZombieArmor";
   };

   %player.setTransform( %trans );
   MissionCleanup.add(%player);

   // setup some info
   %player.setOwnerClient(%client);
   %player.team = 2;
   %client.outOfBounds = false;
   %player.setEnergyLevel(0);
   %client.player = %player;
   %player.iszombie =1;
   %player.canInfect = 1;

   // updates client's target info for this player
   %player.setTarget(%client.target);
   setTargetDataBlock(%client.target, %player.getDatablock());
   setTargetSensorData(%client.target, PlayerSensor);
   setTargetSensorGroup(%client.target, 2);
   %client.setSensorGroup(2);

   %client.setControlObject(%player);
   %player.client.clearBackpackIcon();

   %player.iszombie = 1;

   ZombieBloodLust(%player,0);
   zombieAttackImpulse(%player,80);
}

function makePersonZombieLord(%trans, %client){
   %client.player.delete();

   %player = new Player() {
      dataBlock = "LordZombieArmor";
   };

	%player.mountImage(ZHead, 3);   //Mount Zombie Lord Images
	%player.mountImage(ZBack, 4);
	%player.mountImage(ZDummyslotImg, 5);
	%player.mountImage(ZDummyslotImg2, 6);

   %player.setTransform( %trans );
   MissionCleanup.add(%player);

   // setup some info
   %player.setOwnerClient(%client);
   %player.team = 2;
   %client.outOfBounds = false;
   %player.setEnergyLevel(0);
   %client.player = %player;
   %player.iszombie =1;
   %player.setInventory(ZombGun,1,true);
   %player.canInfect = 1;

   // updates client's target info for this player
   %player.setTarget(%client.target);
   setTargetDataBlock(%client.target, %player.getDatablock());
   setTargetSensorData(%client.target, PlayerSensor);
   setTargetSensorGroup(%client.target, 2);
   %client.setSensorGroup(2);

   %client.setControlObject(%player);
   %player.client.clearBackpackIcon();

   %player.iszombie = 1;

   ZombieBloodLust(%player,0);
   zombieAttackImpulse(%player,80);
}

function makepersonAirRapier(%trans, %client){
   %client.player.delete();

   %player = new Player() {
      dataBlock = "RapierZombieArmor";
   };

   %player.setTransform( %trans );
   MissionCleanup.add(%player);

   // setup some info
   %player.setOwnerClient(%client);
   %player.team = $zombie::team;
   %client.outOfBounds = false;
   %player.setEnergyLevel(0);
   %client.player = %player;
   %player.iszombie =1;

   // updates client's target info for this player
   %player.setTarget(%client.target);
   setTargetDataBlock(%client.target, %player.getDatablock());
   setTargetSensorData(%client.target, PlayerSensor);
   setTargetSensorGroup(%client.target, 2);
   %client.setSensorGroup(2);

   %client.setControlObject(%player);
   %player.client.clearBackpackIcon();
   %player.canInfect = 1;

   %player.mountImage(ZWingImage, 3);
   %player.mountImage(ZWingImage2, 4);
   %player.iszombie = 1;

   RapierForwardImpulse(%player);
   ZombieBloodLust(%player,0);
}

function makePersonRavengerZombie(%trans, %client){
   %client.player.delete();

   %player = new Player() {
      dataBlock = "FZombieArmor";
   };

   %player.setTransform( %trans );
   MissionCleanup.add(%player);

   // setup some info
   %player.setOwnerClient(%client);
   %player.team = $zombie::team;
   %client.outOfBounds = false;
   %player.setEnergyLevel(0);
   %client.player = %player;
   %player.iszombie =1;

   // updates client's target info for this player
   %player.setTarget(%client.target);
   setTargetDataBlock(%client.target, %player.getDatablock());
   setTargetSensorData(%client.target, PlayerSensor);
   setTargetSensorGroup(%client.target, 2);
   %client.setSensorGroup(2);

   %client.setControlObject(%player);
   %player.client.clearBackpackIcon();
   %player.canInfect = 1;

   %player.iszombie = 1;

   RavengerForwardImpulse(%player);
   ZombieBloodLust(%player,0);
}

function makePersonRAAM(%trans, %client){
   %client.player.delete();

   %player = new Player() {
      dataBlock = "RAAMZombieArmor";
   };

   %player.setTransform( %trans );
   MissionCleanup.add(%player);

   // setup some info
   %player.setOwnerClient(%client);
   %player.team = $zombie::team;
   %client.outOfBounds = false;
   %player.setEnergyLevel(0);
   %client.player = %player;
   %player.iszombie =1;
   %player.mountImage(ZMG42BaseImage, 5);
   %player.mountImage(RAAMSAWImage1, 6);
   %player.mountImage(RAAMSAWImage2, 7);
   %player.mountImage(RAAMSAWImage3, 8);
   %player.shotsfired = 0;
   %player.rapiershield = 1;
   %player.israam = 1;
   %player.cansummon = 1;
   %player.canInfect = 1;
   schedule(100,0,"RAAMShieldUpdate",%player);

   // updates client's target info for this player
   %player.setTarget(%client.target);
   setTargetDataBlock(%client.target, %player.getDatablock());
   setTargetSensorData(%client.target, PlayerSensor);
   setTargetSensorGroup(%client.target, 2);
   %client.setSensorGroup(2);

   %client.setControlObject(%player);
   %player.client.clearBackpackIcon();

   %player.iszombie = 1;
//   ZombieBloodLust(%player,0);
}

function makePersonDarkrai(%trans, %client){
   %client.player.delete();

   %player = new Player() {
      dataBlock = "DarkraiZombieArmor";
   };

   %player.setTransform( %trans );
   MissionCleanup.add(%player);

   // setup some info
   %player.setOwnerClient(%client);
   %player.team = $zombie::team;
   %client.outOfBounds = false;
   %player.setEnergyLevel(0);
   %client.player = %player;
   %player.iszombie =1;
   %player.sfireticks = 300;
   %player.cansummon = 1;
   %player.canRandNightmare = 1;
   %player.isplayerDark = 1;
   %player.canInfect = 1;

   // updates client's target info for this player
   %player.setTarget(%client.target);
   setTargetDataBlock(%client.target, %player.getDatablock());
   setTargetSensorData(%client.target, PlayerSensor);
   setTargetSensorGroup(%client.target, 2);
   %client.setSensorGroup(2);

   %client.setControlObject(%player);
   %player.client.clearBackpackIcon();

   %player.iszombie = 1;
   PlayerFireTicksLoop(%player); //Get their weapons ready
//   ZombieBloodLust(%player,0);
}
