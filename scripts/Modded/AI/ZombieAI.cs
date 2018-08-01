function ZombieLookforTarget(%zombie) {
   if(!isObject(%zombie))
	return;
   if(%Zombie.getState() $= "dead")
	return;
   %pos = %zombie.getposition();
   %wbpos = %zombie.getworldboxcenter();
   %count = ClientGroup.getCount();
   %closestClient = -1;
   %closestDistance = 32767;
   for(%i = 0; %i < %count; %i++)
   {
	%cl = ClientGroup.getObject(%i);
	if(isObject(%cl.player) && !%cl.ignoredbyZombs){
	   %testPos = %cl.player.getWorldBoxCenter();
	   %distance = vectorDist(%wbpos, %testPos);
	   if (%distance > 0 && %distance < %closestDistance && %cl.player.isFTD != 1 && %cl.player.iszombie != 1)
	   {
	   	%closestClient = %cl;
	   	%closestDistance = %distance;
	   }
	}
   }
   if(%closestClient){
	if (%zombie.type == 1)
         Zombiemovetotarget(%zombie,%closestClient,%closestDistance);
	else if (%zombie.type == 2)
         FZombiemovetotarget(%zombie,%closestClient,%closestDistance);
	else if (%zombie.type == 3)
         LZombiemovetotarget(%zombie,%closestClient,%closestDistance);
	else if (%zombie.type == 4)
	   DZombiemovetotarget(%zombie,%closestClient,%closestDistance);
	else if (%zombie.type == 5)
	   RZombiemovetotarget(%zombie,%closestClient,%closestDistance);
	else if (%zombie.type == 6)
	   SniperZombiemovetotarget(%zombie,%closestClient,%closestDistance);
	else if (%zombie.type == 8)
	   SlashZombiemovetotarget(%zombie,%closestClient,%closestDistance);
	else if (%zombie.type == 9 || %zombie.Typeinfo == 8)
	   RAAMmovetotarget(%zombie,%closestClient,%closestDistance);
	else if (%zombie.type == 10 || %zombie.type == 11)
	   Darkraimovetotarget(%zombie,%closestClient,%closestDistance);
    else if (%zombie.type == 12)
       LordRAAMmovetotarget(%zombie,%closestClient,%closestDistance);
   }
   %zombie.ZombieTargeting = schedule(500, %zombie, "ZombieLookForTarget", %zombie);
}

function Zombiemovetotarget(%zombie,%closestClient,%closestDistance){
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %closestClient = %closestClient.Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.hastarget != 1){
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   ZDoMoan(%zombie);

	%clpos = %closestClient.getPosition();
      %vector = vectorNormalize(vectorSub(%clpos, %pos));
	%v1 = getword(%vector, 0);
	%v2 = getword(%vector, 1);
	%nv1 = %v2;
	%nv2 = (%v1 * -1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));

	%fmultiplier = $Zombie::ForwardSpeed;
	if(%closestDistance <= $zombie::lungDist && %zombie.canjump == 1)
	   %fmultiplier = (%fmultiplier * 4);
	%vector = vectorscale(%vector, %Fmultiplier);
	%upvec = "150";
	if(%closestDistance <= $zombie::lungDist && %zombie.canjump == 1){
	   %upvec = %upvec * 2;
	   %zombie.canjump = 0;
	   schedule(1500, %zombie, "Zsetjump", %zombie);
	}
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= 600)
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
}

function FZombiemovetotarget(%zombie,%closestClient,%closestDistance){
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %closestClient = %closestClient.Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.hastarget != 1){
	   %zombie.hastarget = 1;
	}
	%zombie.setActionThread("scoutRoot",true);
	%upvec = "250";
	%fmultiplier = $Zombie::FForwardSpeed;

	//moanStuff
	%chance = (getrandom() * 50);
   	if(%chance >= 49)
	   ZDoMoan(%zombie);

	//Rotation stuff
	%clpos = %closestClient.getPosition();
      %vector = vectorNormalize(vectorSub(%clpos, %pos));
	%v1 = getword(%vector, 0);
	%v2 = getword(%vector, 1);
	%nv1 = %v2;
	%nv2 = (%v1 * -1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));

	//Move Stuff
	if(%closestDistance <= $zombie::lungDist && %zombie.canjump == 1 && getword(%vector, 2) <= "0.8" ){
	   %zombie.setvelocity("0 0 0");
	   %fmultiplier = (%fmultiplier * 2);
	   %upvec = (%upvec * 3.5);
	   %zombie.canjump = 0;
	   schedule(2000, %zombie, "Zsetjump", %zombie);
	}
	%vector = vectorscale(%vector, %Fmultiplier);
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= "1200" && %zombie.canjump == 1){
	   %zombie.setvelocity("0 0 0");
	   %upvec = (%upvec * 8);
	   %x = (%x * 0.5);
	   %y = (%y * 0.5);
	   %zombie.canjump = 0;
	   schedule(2500, %zombie, "Zsetjump", %zombie);
	}

	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   	%zombie.setActionThread("ski",true);
   }
}

function LZombiemovetotarget(%zombie,%closestClient,%closestDistance){
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %closestClient = %closestClient.Player;
   if(%closestDistance <= $zombie::detectDist && %zombie.canmove != 0){
	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   LZDoMoan(%zombie);

	%clpos = %closestClient.getPosition();
      %vector = vectorNormalize(vectorSub(%clpos, %pos));
	%nv2 = (getword(%vector, 0) * -1);
	%nv1 = getword(%vector, 1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));
	if(%zombie.ATCount >= 20){
	   %zombie.ATCount = 0;
	   %zombie.nomove = 1;
   	   %zombie.Fire = schedule(1250, %zombie, "ZFire", %zombie, %closestClient);
	   %zombie.Charge = schedule(500, %zombie, "ChargeEmitter", %zombie);
	   %zombie.chargecount = 0;
	}
	if(%zombie.nomove != 1) {
	%fmultiplier = $Zombie::LForwardSpeed;
	%upvec = "150";
	if(%closestDistance <= $zombie::LKillDist && %zombie.canjump == 1){
	   %vec = vectoradd(%pos,vectorScale(%vector,($zombie::LkillDist - 1.6)));
	   %mask = $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::TerrainObjectType | $TypeMasks::PlayerObjectType;
	   %searchResult = containerRayCast(vectoradd(%pos,vectorScale(%vector,1.6)), %vec, %mask, %zombie);
	   if(%searchResult){
		%searchObj = getWord(%searchResult,0);
		if(%searchObj $= %closestClient){
		   %chance = getrandom(1,5);
		   if(%chance == 1){
			%dir = %zombie.getEyeVector();
			%dir = vectornormalize(getword(%dir,0)@" "@getword(%dir,1)@" 0");
			%dir = vectoradd(vectorscale(%dir,7500),"0 0 1000");
			%closestclient.applyimpulse(%clpos,%dir);
			%closestclient.damage(0, %clpos, 0.8, $DamageType::ZombieL);
		   }
		   else{
	   		%zombie.setvelocity("0 0 0");
	   		%zombie.canjump = 0;
	   		schedule(1000, %zombie, "Zsetjump", %zombie);
	   		Llifttarget(%zombie,%closestclient,0);
			return;
		   }
		}
	   }
	}
	else if(%closestDistance <= ($zombie::LKillDist + $zombie::lungDist)){
	   %zombie.setvelocity("0 0 0");
	   %fmultiplier = (%fmultiplier * 2.5);
	}
	%vector = vectorscale(%vector, %Fmultiplier);
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= 4000)
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
	%zombie.ATCount++;
	}
   }
   else if(%zombie.hastarget == 1 && %zombie.canmove != 0){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
}

function DZombiemovetotarget(%zombie,%closestClient,%closestDistance){
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %closestClient = %closestClient.Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.hastarget != 1 && %closestdistance >= 10 && %closestdistance <= 150){
	   DzombieFire(%zombie,%closestclient);
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	}
	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
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

	if (%closestdistance >= 10 && %closestdistance <= 150 && %zombie.canjump == 1){
	   DzombieFire(%zombie,%closestclient);
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
}

function RAAMmovetotarget(%zombie,%closestClient,%closestDistance){
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %closestClient = %closestClient.Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.hastarget != 1 && %closestdistance >= 10 && %closestdistance <= 500){
	   RAAMFire(%zombie,%closestclient);
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	}
	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
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

	if (%closestdistance >= 10 && %closestdistance <= 500 && %zombie.canjump == 1){
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
}

function RZombiemovetotarget(%zombie,%closestClient,%closestDistance){
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %zombie.setActionThread("scoutRoot",true);
   %closestClient = %closestClient.Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.wingset == 1){
	   %zombie.wingset = 0;
	   %Zombie.mountImage(ZWingImage, 3);
	   %Zombie.mountImage(ZWingImage2, 4);
	}
	else{
	   %zombie.wingset = 1;
	   %Zombie.mountImage(ZWingaltImage, 3);
	   %Zombie.mountImage(ZWingaltImage2, 4);
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   ZDoMoan(%zombie);
	if(%zombie.iscarrying == 1){
	   %vector = vectorscale(%zombie.getForwardVector(),($Zombie::RForwardSpeed / 2));
	   %vector = getword(%vector, 0)@" "@getword(%vector, 1)@" "@($zombie::Rupvec * 1.5);
	   %zombie.applyImpulse(%zombie.getposition(), %vector);
	   return;
	}

	%clpos = %closestClient.getWorldBoxCenter();
      %vector = vectorNormalize(vectorSub(%clpos, %pos));
	%v1 = getword(%vector, 0);
	%v2 = getword(%vector, 1);
	%nv1 = %v2;
	%nv2 = (%v1 * -1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));

	%z = Getword(%vector,2);
	%spd = vectorLen(%zombie.getVelocity());
	%fallpoint = 0.05 - (%spd / 630);
	if(%closestdistance <= 15 || %z > (0.25 + %fallpoint) || %z < (-1 * (0.25 + %fallpoint))){
	   if(%z < 0)
	      %upvec = ($zombie::Rupvec * (%z - (%spd / 130)));
	   if(%z >= 0)
		%upvec = ($zombie::Rupvec * (%z + 1));
	   if(%spd <= 5)
		%vector = vectorScale(%vector,3);
	}
	else{
	   %upvec = $zombie::Rupvec * (%z + 1.2);
	   %spdmod = 1;
	}
	if(%z < 0)
	   %z = %z * -1;

	%Zz = getWord(%zombie.getVelocity(),2);
	if(%Zz <= -40){
         %result = containerRayCast(%pos, vectoradd(%pos,vectorScale("0 0 1",%Zz * 2)), $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType, %zombie);
	   if(%result)
		%upvec = $zombie::Rupvec * 5;
	}

	%vector = vectorscale(%vector, ($Zombie::RForwardSpeed * (1 - %z)));
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
  }

function SniperZombiemovetotarget(%zombie,%closestClient,%closestDistance){
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %closestClient = %closestClient.Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.hastarget != 1 && %closestdistance >= 10 && %closestdistance <= $zombie::sniperrange){
	   SZombieFire(%zombie,%closestclient);
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	}
	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
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

	if (%closestdistance >= 10 && %closestdistance <= $zombie::sniperrange && %zombie.canjump == 1){
	   SZombieFire(%zombie,%closestclient);
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
}

function SniperZombiemovetospectarget(%zombie,%target){
   if(!isobject(%zombie) || %zombie.getstate() $= "dead")
   return;
   if(!isobject(%target.player) || %target.player.getstate() $= "dead") {
   schedule(500,0,"SniperZombiemovetospectarget",%zombie,%target);
   return;
   }
   %zombie.sfireticks++;
   %pos = %zombie.getworldboxcenter();
   %testPos = %target.player.getWorldBoxCenter();
   %closestDistance = vectorDist(%wbpos, %testPos);
   %closestClient = %target.Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.hastarget != 1 && %closestdistance >= 50 && %zombie.sfireticks >= 20){      //Fire At Distances Larger Than 50M
	   SzombieFire(%zombie,%closestclient);
	}
	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
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

	if (%closestdistance >= 50 && %zombie.sfireticks >= 20){
	   SzombieFire(%zombie,%closestclient);
       schedule(100,0,"SniperZombiemovetospectarget",%zombie,%target);
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
   schedule(100,0,"SniperZombiemovetospectarget",%zombie,%target);
}

function Darkraimovetotarget(%zombie,%closestClient,%closestDistance){
   %zombie.sfireticks++;
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %closestClient = %closestClient.Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.hastarget != 1 && %closestdistance >= 10 && %closestdistance <= $zombie::sniperrange){
       if(%zombie.sfireticks > 70) {
	   DarkraiZombieFire(%zombie,%closestclient);
       %Zombie.sfireticks = 0;
       }
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	}
	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
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

	if (%closestdistance >= 10 && %closestdistance <= $zombie::sniperrange && %zombie.canjump == 1){
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
}

function LordRAAMmovetotarget(%zombie,%closestClient,%closestDistance){
   %zombie.setVelocity("0 0 0");
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %closestClient = %closestClient.Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.hastarget != 1 && %closestdistance >= 10 && %closestdistance <= 500){
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	}
	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
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

	if (%closestdistance >= 10 && %closestdistance <= 500 && %zombie.canjump == 1){
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	   return;
	}
	%vector = vectorscale(%vector, $Zombie::ForwardSpeed);
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= ($Zombie::ForwardSpeed / 3 * 2))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
}

function SlashZombiemovetotarget(%zombie,%closestClient,%closestDistance){
   %zombie.setVelocity("0 0 0");
   %zposition = %zombie.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
      %zombie.scriptkill($DamageType::Suicide);
   }
   %pos = %zombie.getworldboxcenter();
   %closestClient = %closestClient.Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.hastarget != 1){
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   ZDoMoan(%zombie);

	%clpos = %closestClient.getPosition();
      %vector = vectorNormalize(vectorSub(%clpos, %pos));
	%v1 = getword(%vector, 0);
	%v2 = getword(%vector, 1);
	%nv1 = %v2;
	%nv2 = (%v1 * -1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%zombie.setRotation(fullrot("0 0 0",%vector2));

	%fmultiplier = $Zombie::LForwardSpeed * 3;
	if(%closestDistance <= $zombie::lungDist && %zombie.canjump == 1)
	   %fmultiplier = (%fmultiplier * 4);
	%vector = vectorscale(%vector, %Fmultiplier);
	%upvec = "150";
	if(%closestDistance <= $zombie::lungDist && %zombie.canjump == 1){
	   %upvec = %upvec * 2;
	   %zombie.canjump = 0;
	   schedule(1500, %zombie, "Zsetjump", %zombie);
	}
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= 600)
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
}

function ZSetRandomMove(%zombie){
   if (!isobject(%zombie))
	return;
   %RX = getrandom(-10, 10);
   %RY = getrandom(-10, 10);
   %RZ = getrandom();
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
	else if(%zombie.type == 6 || %zombie.type == 10)
	   %speed = ($zombie::Dforwardspeed);
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




////////////
//SHOOTING//
////////////




function ZFire(%zombie, %target){
   if(isobject(%zombie) && isobject(%target)){
   	if(%Zombie.firstFired == 1){
         %vec = vectorsub(%target.getworldboxcenter(),%zombie.getMuzzlePoint(6));
	   %vec = vectoradd(%vec, vectorscale(%target.getvelocity(),vectorlen(%vec)/100));
	   %zombie.firstFired = 0;
   	   %zombie.nomove = 0;
   	   %p = new TracerProjectile()
   	   {
   	   	dataBlock        = LZombieAcidBall;
   	   	initialDirection = %vec;
   	   	initialPosition  = %zombie.getMuzzlePoint(6);
   	   	sourceObject     = %zombie;
   	   	sourceSlot       = 6;
   	   };
   	}
   	else{
         %vec = vectorsub(%target.getworldboxcenter(),%zombie.getMuzzlePoint(5));
	   %vec = vectoradd(%vec, vectorscale(%target.getvelocity(),vectorlen(%vec)/100));
   	   %p = new TracerProjectile()
   	   {
   	   	dataBlock        = LZombieAcidBall;
   	   	initialDirection = %vec;
   	   	initialPosition  = %zombie.getMuzzlePoint(5);
   	   	sourceObject     = %zombie;
   	   	sourceSlot       = 5;
   	   };
	   %zombie.firstFired = 1;
   	   %zombie.Fire = schedule(250, %zombie, "ZFire", %zombie, %target);
      }
   }
   else{
	%zombie.firstFired = 0;
	%zombie.nomove = 0;
   }
}

function Llifttarget(%zombie,%target,%count){
   if(%count == 0)
	%zombie.canmove = 0;
   if(%target.getState() $= "dead" || %Zombie.getState() $= "dead"){
	%zombie.canmove = 1;
	return;
   }
   if(!isobject(%target)){
	%zombie.canmove = 1;
	return;
   }
   %pos = %zombie.getworldboxcenter();
   %Tpos = %target.getworldboxcenter();
   %ZtoT = vectorsub(%tpos,%pos);
   if (%count <= 12){
	%newpos = vectoradd(%ZtoT,vectoradd(%pos,"0 0 -0.6"));
	%target.setTransform(%newpos);
	%target.setvelocity("0 0 0");
   }
   else {
	%killtype = getrandom(1,2);
	if(%killtype == 1){
	   %closestwall = 20;
	   %nv2 = (getword(%ZtoT, 0) * -1);
	   %nv1 = getword(%ZtoT, 1);
	   %vector1 = vectorscale(vectornormalize(%nv1@" "@%nv2@" 0"),20);
	   %nvector1 = vectoradd(%tpos,%vector1);
	   %nv2 = getword(%ZtoT, 0);
	   %nv1 = (getword(%ZtoT, 1) * -1);
	   %vector2 = vectorscale(vectornormalize(%nv1@" "@%nv2@" 0"),20);
	   %nvector2 = vectoradd(%tpos,%vector2);
	   %searchresultR = containerRayCast(%tpos, %nvector1, $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::VehicleObjectType);
	   %searchresultL = containerRayCast(%tpos, %nvector2, $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::VehicleObjectType);
	   if(%searchresultR){
		%Hpos = getword(%searchresultR,1)@" "@getword(%searchresultR,2)@" "@getword(%searchresultR,3);
		%distance = vectordist(%Tpos, %Hpos);
		if(%distance <= %closestwall){
		   %closestwall = %distance;
		   %vector = vectoradd(vectorscale(%vector1,1500),"0 0 100");
		}
	   }
	   if(%searchresultL){
		%Hpos = getword(%searchresultL,1)@" "@getword(%searchresultL,2)@" "@getword(%searchresultL,3);
		%distance = vectordist(%Tpos, %Hpos);
		if(%distance <= %closestwall){
		   %closestwall = %distance;
		   %vector = vectoradd(vectorscale(%vector2,1500),"0 0 100");
		}
	   }
	   if(%closestwall == 20){
	   	%x = getword(%ZtoT, 0);
	   	%y = getword(%ZtoT, 1);
		%outvec = vectorscale(vectornormalize(%x@" "@%y@" 0"),50);
		%vector = vectoradd("0 0 -15000",%outvec);
	   }
	   %target.applyimpulse(%target.getposition(),%vector);
	}
	else if(%killtype == 2){
	   %target.infected = 1;
	   %target.damage(%zombie, %target.getposition(), 10.0, $DamageType::ZombieL);
	}
	%count = 0;
	%zombie.canmove = 1;
	return;
   }
   %count++;
   %zombie.killingplayer = schedule(150, %zombie, "Llifttarget", %zombie, %target, %count);
}


function DZombieFire(%zombie,%target){
   %pos = %zombie.getMuzzlePoint(4);
   %tpos = %target.getWorldBoxCenter();
   %tvel = %target.getvelocity();
   %vec = vectorsub(%tpos,%pos);
   %dist = vectorlen(%vec);
   %velpredict = vectorscale(%tvel,(%dist / 50));
   %vector = vectoradd(%vec,%velpredict);
   %ndist = vectorlen(%vector);
   %upvec = "0 0 "@((%ndist / 50) * (%ndist / 50) * 2);
   %vector = vectornormalize(vectoradd(%vector,%upvec));
   %p = new GrenadeProjectile()
   {
	dataBlock        = DemonFireball;
	initialDirection = %vector;
	initialPosition  = %pos;
	sourceObject     = %zombie;
	sourceSlot       = 4;
   };
}

function RAAMFire(%zombie,%target) {
   if(!isobject(%zombie) || %zombie.getState() $= "dead")
   return;
   if(!isobject(%target) || %target.getState() $= "dead") {
   %zombie.shotsfired = 100;
   %zombie.setMoveState(false); //unfreeze him
   schedule(7500,0,"ResetRaamField",%zombie);
   schedule(10000,0,"RAAMReset",%zombie);
   return;
   }
   if(%zombie.shotsfired >= 100) {
   %zombie.setMoveState(false); //unfreeze him
   %zombie.rapiershield = 1;
   return;
   }
   %zombie.rapiershield = 0;
   %zombie.setMoveState(true); //freeze him
   %pos = %zombie.getMuzzlePoint(5);
   %vec = vectorsub(%target.getworldboxcenter(),%zombie.getMuzzlePoint(5));
   %vec = vectoradd(%vec, vectorscale(%target.getvelocity(),vectorlen(%vec)/100));

   %x = (getRandom() - 0.5) * 2 * 3.1415926 * (6/1000);
   %y = (getRandom() - 0.5) * 2 * 3.1415926 * (6/1000);
   %z = (getRandom() - 0.5) * 2 * 3.1415926 * (6/1000);
   %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
   %nvec = MatrixMulVector(%mat, %vec);

   %zombie.shotsfired++;
   %p = new LinearFlareProjectile()
   {
	dataBlock        = RAAMCGProjectile;
	initialDirection = %nvec;
	initialPosition  = %pos;
	sourceObject     = %zombie;
	sourceSlot       = 5;
   };
   schedule(50,0,"RAAMFire",%zombie,%target);
   if(%zombie.shotsfired == 1) {
   schedule(15000,0,"RAAMReset",%zombie);
   }
}

function DarkraiZombieFire(%zombie,%target){
   %vec = vectorsub(%target.getworldboxcenter(),%zombie.getMuzzlePoint(6));
   %vec = vectoradd(%vec, vectorscale(%target.getvelocity(),vectorlen(%vec)/100));
   %p = new LinearFlareProjectile() {
       dataBlock        = DarkraiSniperShot;
       initialDirection = %vec;
       initialPosition  = %zombie.getMuzzlePoint(0);
       sourceObject     = %zombie;
       sourceSlot       = 0;
   };
}

function SZombieFire(%zombie,%target){
   %zombie.sfireticks = 0;
   %vec = vectorsub(%target.getworldboxcenter(),%zombie.getMuzzlePoint(6));
   %vec = vectoradd(%vec, vectorscale(%target.getvelocity(),vectorlen(%vec)/100));
   %p = new LinearFlareProjectile() {
       dataBlock        = SniperShot;
       initialDirection = %vec;
       initialPosition  = %zombie.getMuzzlePoint(6);
       sourceObject     = %zombie;
       sourceSlot       = 6;
   };
}

