//TRAITOR ZOMBIES
//Allies
function StartAAllyZombie(%pos, %type){
   if(%Type == 1){
   	%Zombie = new player(){
	   Datablock = "ZombieArmor";
   	};
    %zname ="[A]Zombie";
    %zombie.Typeinfo = 1;
   }
   if(%Type == 2){
   	%Zombie = new player(){
	   Datablock = "FZombieArmor";
   	};
    %zname ="[A]Ravenger Zombie";
    %zombie.Typeinfo = 2;
   }
   if(%Type == 3){
   	%Zombie = new player(){
	   Datablock = "LordZombieArmor";
   	};
	%zombie.client = $zombie::Lclient;
	%Zombie.mountImage(ZHead, 3);
	%Zombie.mountImage(ZBack, 4);
	%Zombie.mountImage(ZDummyslotImg, 5);
	%Zombie.mountImage(ZDummyslotImg2, 6);
	%zombie.firstFired = 0;
	%zombie.canmove = 1;
    %zname ="[A]Zombie Lord";
    %zombie.Typeinfo = 3;
   }
   if(%type == 4){
	%Zombie = new player(){
	   Datablock = "DemonZombieArmor";
	};
	%zombie.mountImage(ZdummyslotImg, 4);
    %zname ="[A]Demon Zombie";
    %zombie.Typeinfo = 4;
   }
   if(%type == 5){
	%Zombie = new player(){
	   Datablock = "RapierZombieArmor";
	};
	%Zombie.mountImage(ZWingImage, 3);
	%Zombie.mountImage(ZWingImage2, 4);
	%zombie.setActionThread("scoutRoot",true);
    %zname ="[A]Air Rapier Zombie";
    %zombie.Typeinfo = 5;
   }
   if(%type == 6){
	%Zombie = new player(){
	   Datablock = "DemonZombieArmor";
	};
    %zname ="[A]Sniper Zombie";
	%zombie.mountImage(ZSniperImage, 3);
    %zombie.Typeinfo = 6;
   }
   if(%type == 7){
	%Zombie = new player(){
	   Datablock = "RAAMZombieArmor";
	};
	%zombie.mountImage(ZdummyslotImg, 4);
    //RAAM's Weapon Images
    %zombie.mountImage(ZMG42BaseImage, 5);
    %zombie.mountImage(RAAMSAWImage1, 6);
    %zombie.mountImage(RAAMSAWImage2, 7);
    %zombie.mountImage(RAAMSAWImage3, 8);
    %zname ="[A]General RAAM";
    %zombie.Typeinfo = 8;
    %zombie.shotsfired = 0;
    %zombie.rapiershield = 1;
    %zombie.israam = 1;
    schedule(100,0,"RAAMShieldUpdate",%zombie);
   }
   if(%type == 8){
	%Zombie = new player(){
	   Datablock = "DarkraiZombieArmor";
	};
    %zname ="[A]Lord Darkrai";
    %zombie.Typeinfo = 10;
    %zombie.sfireticks = 0;
    %zombie.usedlifeup = 0;
    %zombie.damage(0, %target.getposition(), 1.0, $DamageType::admin);
   }
   if(%type == 9){   //fake darkrai
	%Zombie = new player(){
	   Datablock = "DarkraiZombieArmor";
	};
    %zname ="[A]Lord Darkrai";
    %zombie.Typeinfo = 11;
    %zombie.sfireticks = 0;
    %zombie.usedlifeup = 1;
//    RandomDarkraiNightmare(%zombie);
    %zombie.damage(0, %target.getposition(), 450.0, $DamageType::admin);
   }
   if(%type == 10){
	%Zombie = new player(){
	   Datablock = "CynthiaArmor";
	};
    %zname ="[A]Cynthia";
   }
   if(%type == 11){
	%Zombie = new player(){
	   Datablock = "LordRAAMZombieArmor";
	};
    %zname ="[A]Lord RAAM";
    %zombie.Typeinfo = 12;
    %zombie.shotsfired = 0;
    %zombie.rapiershield = 1;
    %zombie.isLraam = 1;
    schedule(100,0,"RAAMShieldUpdate",%zombie);
   }
   %zombie.type = %type;
   %Zombie.setTransform(%pos);
   %Zombie.team = $zombie::Traitorteam;
   %zombie.canjump = 1;
   %zombie.hastarget = 1;
   MissionCleanup.add(%Zombie);
   %zombie.iszombie = 0;
   %zombie.isTraitorZombie = 1;
   %zombie.target = createTarget(%zombie, %zname, "", "Derm3", '', %zombie.team, PlayerSensor);
   setTargetSkin(%zombie.target, 'Horde');
   setTargetSensorData(%zombie.target, PlayerSensor);
   setTargetSensorGroup(%zombie.target, $zombie::Traitorteam);
   setTargetName(%zombie.target, addtaggedstring(%zname));
   return %zombie;
}

function RaamAttackTarget(%zombie, %targ) {
   if(!isObject(%zombie) || %zombie.getState() $= "dead") {
   return;
   }
   if(!isObject(%targ.player) || %targ.player.getState() $= "dead") {
   %zombie.iszombie = 0; //disables sword
   schedule(5,0,"messageall",'Message', "\c4General RAAM: The Infidel, "@getTaggedString(%targ.name)@" exists NO MORE!");
   return;
   }
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %closestClient = %targ.Player;
	if(%zombie.hastarget != 1){
	   RAAMFire(%zombie,%closestclient);
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	if(%zombie.hastarget != 1){
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   LZDoMoan(%zombie);

	%clpos = %closestClient.getPosition();
      %vector = vectorNormalize(vectorSub(%clpos, %pos));
	%v1 = getword(%vector, 0);
	%v2 = getword(%vector, 1);
	%nv1 = %v2;
	%nv2 = (%v1 * -1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));

	if (%zombie.canjump == 1){
	   RAAMFire(%zombie,%closestclient);
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	   return;
	}
	%vector = vectorscale(%vector, $Zombie::DForwardSpeed);
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= ($Zombie::DForwardSpeed / 3 * 2))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
   %zombie.attackloop = schedule(500,0,"RaamAttackTarget",%zombie,%targ);
}

function DarkraiAttackTarget(%zombie,%targ){
   if(!isObject(%zombie) || %zombie.getState() $= "dead") {
   return;
   }
   %zombie.sfireticks++;
   %zposition = %zombie.getPosition();
   %pos = %zombie.getworldboxcenter();
   %testPos = %targ.player.getWorldBoxCenter();
   %distance = vectorDist(%pos, %testPos);
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   if(!isObject(%targ.player) || %targ.player.getState() $= "dead") {
   %zombie.iszombie = 0; //disables touch/die
   schedule(5,0,"messageall",'Message', "\c4Lord Darkrai: "@getTaggedString(%targ.name)@", now lives in a nightmare.. My work is done.");
   return;
   }
   %closestClient = %targ.Player;
	if(%zombie.hastarget != 1){
       if(%zombie.sfireticks > 70) {
	   DarkraiZombieFire(%zombie,%closestclient);
       %Zombie.sfireticks = 0;
       }
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	if(%zombie.hastarget != 1){
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   LZDoMoan(%zombie);

	%clpos = %closestClient.getPosition();
      %vector = vectorNormalize(vectorSub(%clpos, %pos));
	%v1 = getword(%vector, 0);
	%v2 = getword(%vector, 1);
	%nv1 = %v2;
	%nv2 = (%v1 * -1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));

	if (%zombie.canjump == 1){
       if(%zombie.sfireticks > 70) {
	   DarkraiZombieFire(%zombie,%closestclient);
       %Zombie.sfireticks = 0;
       }
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	   return;
	}
	%vector = vectorscale(%vector, $Zombie::DForwardSpeed);
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= ($Zombie::DForwardSpeed / 3 * 2))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
   %zombie.attackloop = schedule(200,0,"DarkraiAttackTarget",%zombie,%targ);
}

function ZombieMoveToAlly(%zombie,%ally){
   if(!isObject(%zombie) || %zombie.getState() $= "dead") {
   return;
   }
   %closestClient = %ally.Player;
   if(!isObject(%closestClient) || %closestClient.getState() $= "dead") {
   %zombie.iszombie = 0; //disables touch/die
      if(%zombie.name $= "Lord Darkrai")
      schedule(5,0,"messageall",'Message', "\c4Lord Darkrai: oh dear, "@getTaggedString(%ally.name)@" you seemed to have died.");
      else if(%zombie.name $= "General RAAM")
      schedule(5,0,"messageall",'Message', "\c4General RAAM: Lord "@getTaggedString(%ally.name)@", HELLO...... he's dead.");
      else if(%zombie.name $= "Lord RAAM")
      schedule(5,0,"messageall",'Message', "\c4Lord RAAM: Eghad.... "@getTaggedString(%ally.name)@" died....");
   return;
   }
   %zposition = %zombie.getPosition();
   %pos = %zombie.getworldboxcenter();
   %testPos = %closestClient.getWorldBoxCenter();
   %distance = vectorDist(%pos, %testPos);
   %Zzaxis = getword(%zposition,2);
   if(%distance < 10) {
   %zombie.moveloop = schedule(500,0,"ZombieMoveToAlly",%zombie,%ally);
   return;
   }
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
	if(%zombie.hastarget != 1){
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	if(%zombie.hastarget != 1){
	   %zombie.hastarget = 1;
	}

	%clpos = %closestClient.getPosition();
      %vector = vectorNormalize(vectorSub(%clpos, %pos));
	%v1 = getword(%vector, 0);
	%v2 = getword(%vector, 1);
	%nv1 = %v2;
	%nv2 = (%v1 * -1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));

	if (%zombie.canjump == 1){
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	   return;
	}
	%vector = vectorscale(%vector, $Zombie::DForwardSpeed );
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= ($Zombie::DForwardSpeed / 3 * 2))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
   %zombie.moveloop = schedule(200,0,"ZombieMoveToAlly",%zombie,%ally);
}

