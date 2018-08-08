//************************************************************
//*******************MISC Zomb Functions**********************
//************************************************************

function ZSetRandomMove(%zombie){
   if (!isobject(%zombie))
	return;
   %RX = getrandom(-10, 10);
   %RY = getrandom(-10, 10);
   %RZ = "0";
   %vector = %RX@" "@%RY@" "@%RZ;
   %zombie.direction = vectornormalize(%vector);
   %zombie.Mnum = getrandom(1, 20);
   %zombie.zombieRmove = schedule(500, %zombie, "ZrandommoveLoop", %zombie);
}

function ZrandommoveLoop(%zombie){
   if (!isobject(%zombie))
	return;
   if (%Zombie.getState() $= "dead")
	return;
   if (%zombie.hastarget == 1){
	%zombie.direction = "";
	return;
   }
   if (%zombie.Mnum >= 1){
	%X = getword(%zombie.direction, 1);
	%Y = (getword(%zombie.direction, 0) * -1);
	%none = 0;
	%vector = %X@" "@%Y@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector));
	if(%zombie.type == 1)
	   %speed = ($zombie::forwardspeed);
	else if(%zombie.type == 2)
	   %speed = ($zombie::Fforwardspeed * 0.6);
	else if(%zombie.type == 4)
	   %speed = ($zombie::Dforwardspeed * 0.75);
	else if(%zombie.type == 3)
	   %speed = ($zombie::Lforwardspeed * 0.8);
	%vector = vectorscale(%zombie.direction, %speed);
	%zombie.applyimpulse(%zombie.getposition(), %vector);
	%zombie.Mnum = (%zombie.Mnum - 1);
	%zombie.zombieRmove = schedule(500, %zombie, "ZrandommoveLoop", %zombie);
   }
   else if(%zombie.Mnum == 0)
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
}

function zombieSpawnLoop(%pos, %radius, %freq){
   if(%freq > 10)
	%freq = 10;
   if(%freq < 1)
	%freq = 1;
   %chance = getRandom(1,50);
   if(%chance <= %freq && $numspawnedzombies < (%freq * 5)){
	%spawnPos = vectorAdd(%pos,(getRandom(0,%radius) - (%radius / 2))@" "@(getRandom(0,%radius) - (%radius / 2))@" getRandom(0,15)");
	%search = containerRayCast(%spawnPos, vectorAdd(%spawnPos,"0 0 -1000"), $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType);
	if(%search)
	   %spawnPos = getWord(%search,1)@" "@getWord(%search,2)@" "@getWord(%search,3);
	%chance = getRandom(1,(60 + %freq));
      if(%chance <= 25){
   	   %Zombie = new player(){
	      Datablock = "ZombieArmor";
   	   };
	   %Ztype = 1;
	   %command = "Zombiemovetotarget";
	}
      else if(%chance <= 35){
   	   %Zombie = new player(){
	      Datablock = "FZombieArmor";
   	   };
	   %Ztype = 2;
	   %command = "FZombiemovetotarget";
	}
      else if(%chance <= 50){
   	   %Zombie = new player(){
	      Datablock = "DemonZombieArmor";
   	   };
	   %zombie.mountImage(ZdummyslotImg, 4);
	   %Ztype = 4;
	   %command = "DZombiemovetotarget";
	}
      else if(%chance <= 60){
   	   %Zombie = new player(){
	      Datablock = "RapierZombieArmor";
   	   };
	   %Zombie.mountImage(ZWingImage, 3);
	   %Zombie.mountImage(ZWingImage2, 4);
	   %zombie.setActionThread("scoutRoot",true);
	   %Ztype = 5;
	   %command = "RZombiemovetotarget";
	}
      else if(%chance <= 66){
   	   %Zombie = new player(){
	      Datablock = "LordZombieArmor";
   	   };
	   %Zombie.mountImage(ZHead, 3);
	   %Zombie.mountImage(ZBack, 4);
	   %Zombie.mountImage(ZDummyslotImg, 5);
	   %Zombie.mountImage(ZDummyslotImg2, 6);
	   %zombie.firstFired = 0;
	   %zombie.canmove = 1;
	   %Ztype = 3;
	   %command = "LZombiemovetotarget";
	}
      if(%chance > 66)
	   DemonMotherCreate(%spawnpos);
	else {
         %zombie.type = %Ztype;
         %Zombie.setTransform(%spawnPos);
         %Zombie.team = 0;
         %zombie.canjump = 1;
         %zombie.hastarget = 1;
	   %zombie.randspawnerstarted = 1;
         MissionCleanup.add(%Zombie);
         schedule(1000, %zombie, %command, %zombie);
	   $numspawnedzombies++;
	}
   }
   $zombieloop = schedule(500, 0, "zombieSpawnLoop", %pos, %radius, %freq);
}

function InfectLoop(%obj){
   if($TWM::PlayingHellJump) {
      return;
   }
   if (%obj.getState() $= "dead") {
	  return;
   }
   if(!%obj.infected || %obj.isboss) {
      return;
   }
   if(%obj.client !$= "") {
      if(%obj.client.isActivePerk("No-Infect Armor")) {
         %obj.playShieldEffect("1 1 1");
         %obj.infected = 0;
         return;
      }
   }
   if(isObject(%obj)){
	if(%obj.beats $= "")
	   zombieAttackImpulse(%obj,0);
	if(%obj.beats < 15)
         %obj.setWhiteOut(%obj.beats * 0.05);
	else
	   %obj.setDamageFlash(1);
	if(%obj.beats == 15){
	   %obj.canZkill = 1;
	}
	if(%obj.beats >=15)
	   serverPlay3d("ZombieMoan",%obj.getWorldBoxCenter());
	else if (%obj.beats >= 10)
	   playDeathCry(%obj);
	else
	   playPain(%obj);
	if(%obj.beats == 20){
	   if($host::canZombie $= "")
		$host::canZombie = 0;
	   if($host::canZombie == 1)
	      makePersonZombie(%obj.getTransform(),%obj.client);
	   else
		%obj.damage(0, %obj.getposition(), 10.0, $DamageType::Zombie);
	   return;
	}
      %obj.beats++;
	%obj.infectedDamage = schedule(2000, %obj, "InfectLoop", %obj);
   }
}

function TimedInF(%obj){
   %obj.timedout = 0;
}
function stopFTD(%target){
   %target.isFTD = 0;
   %target.grabbed = 0;
}
function StopZombieSpawnLoop(){
   cancel($zombieloop);
}
function ZDoMoan(%zombie){
   %chance = (getRandom() * 12);
   if(%chance <= 11)
	serverPlay3d("ZombieMoan",%zombie.getWorldBoxCenter());
   else
	serverPlay3d("ZombieHOWL",%zombie.getWorldBoxCenter());
}
function LZDoMoan(%zombie){
   serverPlay3d("ZombieMoan",%zombie.getWorldBoxCenter());
}
function LZDoYell(%zombie){
   serverPlay3d("ZombieHOWL",%zombie.getWorldBoxCenter());
}
function Zsetjump(%zombie){
   %zombie.canjump = 1;
}

function ResetShift(%zombie) {
   %zombie.RecentShift = 0;
}
