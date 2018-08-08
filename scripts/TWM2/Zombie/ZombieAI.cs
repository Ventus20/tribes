$zombie::detectDist = 9999;
$zombie::FallDieHeight = -500;
//************************************************************
//*******************Zomb AI Stuff****************************
//************************************************************

function Zombiemovetotarget(%zombie){
   if(!isobject(%Zombie))
	return;
   if(%Zombie.getState() $= "dead")
	return;
   %pos = %zombie.getworldboxcenter();
   %closestClient = ZombieLookForTarget(%zombie);
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.hastarget != 1){
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   ZDoMoan(%zombie);

      %vector = ZgetFacingDirection(%zombie,%closestClient,%pos);

	%fmultiplier = $Zombie::ForwardSpeed;
    if(Game.CheckModifier("SuperLunge") == 1) {
       %ld = $zombie::lungDist * 5;
    }
    else {
       %ld = $zombie::lungDist;
    }
	if(%closestDistance <= %ld && %zombie.canjump == 1)
	   %fmultiplier = (%fmultiplier * 4);
	%vector = vectorscale(%vector, %Fmultiplier);
	%upvec = "150";
	if(%closestDistance <= %ld && %zombie.canjump == 1){
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
   %zombie.moveloop = schedule(500, %zombie, "Zombiemovetotarget", %zombie);
}

function FZombiemovetotarget(%zombie){
   if(!isobject(%Zombie))
	return;
   if(%Zombie.getState() $= "dead")
	return;
   %pos = %zombie.getworldboxcenter();
   %closestClient = ZombieLookForTarget(%zombie);
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;
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

      %vector = ZgetFacingDirection(%zombie,%closestClient,%pos);

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
   %zombie.moveloop = schedule(500, %zombie, "FZombiemovetotarget", %zombie);
}

function LZombiemovetotarget(%zombie){
   if(!isobject(%Zombie))
	return;
   if(%Zombie.getState() $= "dead") {
      %zombie.throwweapon(1);
	  return;
   }
   %pos = %zombie.getworldboxcenter();
   %closestClient = ZombieLookForTarget(%zombie);
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;
   if(%closestDistance <= $zombie::detectDist && %zombie.canmove != 0){
	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   LZDoMoan(%zombie);

      %vector = ZgetFacingDirection(%zombie,%closestClient,%pos);
	if(%zombie.ATCount >= 20){
	   %zombie.ATCount = 0;
	   %zombie.nomove = 1;
   	   %zombie.Fire = schedule(1250, %zombie, "ZFire", %zombie, %closestClient);
       if(Game.CheckModifier("OhLordy") == 1) {
          %zombie.Fire = schedule(1750, %zombie, "ZFire", %zombie, %closestClient);
       }
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
   %zombie.moveloop = schedule(500, %zombie, "LZombiemovetotarget", %zombie);
}

function DZombiemovetotarget(%zombie){
   if(!isobject(%zombie))
	return;
   if(%zombie.getState() $= "dead")
	return;
   %pos = %zombie.getworldboxcenter();
   %closestClient = ZombieLookForTarget(%zombie);
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;
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

      %vector = ZgetFacingDirection(%zombie,%closestClient,%pos);

	if (%closestdistance >= 10 && %closestdistance <= 150 && %zombie.canjump == 1){
	   DzombieFire(%zombie,%closestclient);
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
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
   %zombie.moveloop = schedule(500, %zombie, "DZombiemovetotarget", %zombie);
}

function RZombiemovetotarget(%zombie){
   if(!isobject(%Zombie))
	return;
   if(%Zombie.getState() $= "dead")
	return;
 
   %zombie.setHeat(999);
 
   %pos = %zombie.getworldboxcenter();
   %zombie.setActionThread("scoutRoot",true);
   %closestClient = ZombieLookForTarget(%zombie);
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;
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
	if(%zombie.iscarrying == 1) {
	   %vector = vectorscale(%zombie.getForwardVector(),($Zombie::RForwardSpeed / 2));
	   %vector = getword(%vector, 0)@" "@getword(%vector, 1)@" "@($zombie::Rupvec * 1.5);
	   %zombie.applyImpulse(%zombie.getposition(), %vector);
	}
    else {

    %vector = ZgetFacingDirection(%zombie, %closestClient, %pos);

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
   %zombie.moveloop = schedule(500, %zombie, "RZombiemovetotarget", %zombie);
}

function ShifterZombiemovetotarget(%zombie){
   if(!isobject(%Zombie))
	return;
   if(%Zombie.getState() $= "dead")
	return;
   %pos = %zombie.getworldboxcenter();
   %closestClient = ZombieLookForTarget(%zombie);
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.hastarget != 1){
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   ZDoMoan(%zombie);

      %vector = ZgetFacingDirection(%zombie,%closestClient,%pos);

	%fmultiplier = $Zombie::ForwardSpeed;
	if(%closestDistance <= $zombie::lungDist && %zombie.canjump == 1)
	   %fmultiplier = (%fmultiplier * 4);
	%vector = vectorscale(%vector, %Fmultiplier);
	%upvec = "150";
 
    //tis shift timez :)
    if(%closestDistance > 200 || (%zombie.getVelocity() == 0 && !%zombie.RecentShift)) {
        %zombie.setVelocity("0 0 10");
       	%zombie.startFade(500, 0, true);
        %zombie.schedule(600, "SetPosition", VectorAdd(%closestClient.getPosition(), "0 0 3"));
        %zombie.startFade(750, 0, false);
        %zombie.RecentShift = 1;
        Schedule(3500, 0, "ResetShift", %zombie);
    }
 
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
   %zombie.moveloop = schedule(500, %zombie, "ShifterZombiemovetotarget", %zombie);
}

function SummonerZombiemovetotarget(%zombie){
   if(!isobject(%Zombie))
	return;
   if(%Zombie.getState() $= "dead")
	return;
   %pos = %zombie.getworldboxcenter();
   %closestClient = ZombieLookForTarget(%zombie);
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.hastarget != 1){
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   ZDoMoan(%zombie);

    if(%zombie.SumTicks $= "") {
       %zombie.SumTicks = 19; //summon right away Pl0x
    }
    %zombie.SumTicks++;
    if(%zombie.SumTicks > 20) {
       %zombie.SumTicks = 0;
       %Ct = GetRandom(1,3);
       %type = GetRandom(1, 8);
       if(%type > 5) {
          %type += 3;
          if(%type == 10) { //summoners don;t summon more summoners
             %type = 12;
          }
       }
       %SumPos = vectorAdd(VectorAdd(GetRandomPosition(20, 1), "0 0 7"), %zombie.getPosition());
       %c = CreateEmitter(%SumPos, NightmareGlobeEmitter, "0 0 1");
       %c.schedule(((%Ct * 1000) + 500), "delete");
       for(%i = 1; %i <= %ct; %i++) {
          %time = %i * 1000;
          schedule(%time, 0, "StartAZombie", %SumPos, %type);
       }
    }

      %vector = ZgetFacingDirection(%zombie,%closestClient,%pos);

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
   %zombie.moveloop = schedule(500, %zombie, "SummonerZombiemovetotarget", %zombie);
}

function SniperZombiemovetotarget(%zombie){
   if(!isobject(%zombie))
	return;
   if(%zombie.getState() $= "dead")
	return;
   %pos = %zombie.getworldboxcenter();
   %closestClient = ZombieLookForTarget(%zombie);
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;
   if(%closestDistance <= $zombie::detectDist){
   
    if(%closestDistance < 50) {    //runz0rs
       %TPos = %closestClient.getPosition();
       %tvel = %closestclient.getvelocity();
       %vec = vectorsub(%tpos,%pos);
       %dist = vectorlen(%vec);
       %velpredict = vectorscale(%tvel,(%dist / 50));
       %vector = vectoradd(%vec,%velpredict);
       %vector = vectornormalize(%vector);
       %x = getWord(%vector, 0);
       %y = getWord(%vector, 1);
       %finX = %x * -1;
       %finY = %y * -1;
       %finalVec = %finX SPC %finY SPC 0;
       %finalVec = VectorScale(%finalVec, $Zombie::DForwardSpeed * 3);
       //Z is unimportant
       %zombie.applyImpulse(%pos, %finalVec);
    }
    else {
	   if(%zombie.hastarget != 1 && %closestdistance >= 50){
	      SniperZombieFire(%zombie,%closestclient);
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

       %vector = ZgetFacingDirection(%zombie,%closestClient,%pos);

       if (%closestdistance >= 50 && %zombie.canjump == 1){
	      SniperZombieFire(%zombie,%closestclient);
	      %zombie.canjump = 0;
	      schedule(4000, %zombie, "Zsetjump", %zombie);
	   }
       if(%closestdistance > 175) {    //only move toward my foe, if he is too
	      %vector = vectorscale(%vector, $Zombie::DForwardSpeed); //far away
	      %upvec = "150";
	      %x = Getword(%vector,0);
    	  %y = Getword(%vector,1);
	      %z = Getword(%vector,2);
	      if(%z >= ($Zombie::DForwardSpeed / 3 * 2))
	         %upvec = (%upvec * 5);
          %vector = %x@" "@%y@" "@%upvec;
	      %zombie.applyImpulse(%pos, %vector);
       }
      }
   }
   else if(%zombie.hastarget == 1){
      %zombie.hastarget = 0;
      %zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
   %zombie.moveloop = schedule(500, %zombie, "SniperZombiemovetotarget", %zombie);
}

function UDemonZombiemovetotarget(%zombie){
   if(!isobject(%zombie))
	return;
   if(%zombie.getState() $= "dead")
	return;
   %pos = %zombie.getworldboxcenter();
   %closestClient = ZombieLookForTarget(%zombie);
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.hastarget != 1 && %closestdistance >= 10 && %closestdistance <= 150){
	   DzombieFire(%zombie,%closestclient);
	   %zombie.canjump = 0;
	   schedule(1700, %zombie, "Zsetjump", %zombie);
	}
	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   LZDoMoan(%zombie);

      %vector = ZgetFacingDirection(%zombie,%closestClient,%pos);

	if (%closestdistance >= 10 && %closestdistance <= 150 && %zombie.canjump == 1){
	   DzombieFire(%zombie,%closestclient);
	   %zombie.canjump = 0;
	   schedule(1700, %zombie, "Zsetjump", %zombie);
	}
	%vector = vectorscale(%vector, $Zombie::DForwardSpeed*2.4);
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= ($Zombie::DForwardSpeed / 3 * 2))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
    createBiodermProjection(%zombie);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
   %zombie.moveloop = schedule(500, %zombie, "UDemonZombiemovetotarget", %zombie);
}

function VRavZombiemovetotarget(%zombie){
   if(!isobject(%Zombie))
	return;
   if(%Zombie.getState() $= "dead")
	return;
   %pos = %zombie.getworldboxcenter();
   %closestClient = ZombieLookForTarget(%zombie);
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%zombie.hastarget != 1){
	   %zombie.hastarget = 1;
	}
	%zombie.setActionThread("scoutRoot",true);
	%upvec = "250";
    if(Game.CheckModifier("Kamakazi") == 1) {
	   %fmultiplier = $Zombie::FForwardSpeed * 0.5 * 5;
    }
    else {
       %fmultiplier = $Zombie::FForwardSpeed * 0.5;
    }
 
    //ka-booma :)
    if(%closestDistance < 9) {
       if(%zombie.isAlive()) {
          if(Game.CheckModifier("TheDestiny") == 1) {
             ServerPlay3D("SatchelChargeExplosionSound", %zombie.getPosition());
             %c4 = new Item() {
                datablock = SatchelChargeThrown;
                position = %zombie.getPosition();
                scale = ".1 .1 .1";
             };
             MissionCleanup.add(%c4);
             schedule(770, 0, "C4GoBoom", %c4);
             return;
          }
          else {
             ServerPlay3D("SatchelChargeExplosionSound", %zombie.getPosition());
             %c4 = new Item() {
                datablock = C4Deployed;
                position = %zombie.getPosition();
                scale = ".1 .1 .1";
             };
             MissionCleanup.add(%c4);
             schedule(770, 0, "C4GoBoom", %c4);
             return;
          }
       }
    }

	//moanStuff
	%chance = (getrandom() * 50);
   	if(%chance >= 49)
	   ZDoMoan(%zombie);

      %vector = ZgetFacingDirection(%zombie,%closestClient,%pos);

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
   %zombie.moveloop = schedule(500, %zombie, "VRavZombiemovetotarget", %zombie);
}

//
function SSZombiemovetotarget(%zombie){
   if(!isobject(%zombie))
	return;
   if(%zombie.getState() $= "dead")
	return;
   %pos = %zombie.getworldboxcenter();
   %closestClient = ZombieLookForTarget(%zombie);
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;
   if(%closestDistance <= $zombie::detectDist){

    if(%closestDistance < 50) {    //runz0rs
       %TPos = %closestClient.getPosition();
       %tvel = %closestclient.getvelocity();
       %vec = vectorsub(%tpos,%pos);
       %dist = vectorlen(%vec);
       %velpredict = vectorscale(%tvel,(%dist / 50));
       %vector = vectoradd(%vec,%velpredict);
       %vector = vectornormalize(%vector);
       %x = getWord(%vector, 0);
       %y = getWord(%vector, 1);
       %finX = %x * -1;
       %finY = %y * -1;
       %finalVec = %finX SPC %finY SPC 0;
       %finalVec = VectorScale(%finalVec, $Zombie::DForwardSpeed * 3.5);
       //Z is unimportant
       %zombie.applyImpulse(%pos, %finalVec);
    }
    else {
	   if(%zombie.hastarget != 1 && %closestdistance >= 50){
	      SlingshotFire(%zombie,%closestclient);
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

       %vector = ZgetFacingDirection(%zombie,%closestClient,%pos);

       if (%closestdistance >= 50 && %zombie.canjump == 1){
	      SlingshotFire(%zombie,%closestclient);
	      %zombie.canjump = 0;
	      schedule(4000, %zombie, "Zsetjump", %zombie);
	   }
       if(%closestdistance > 275) {    //only move toward my foe, if he is too
	      %vector = vectorscale(%vector, $Zombie::DForwardSpeed); //far away
	      %upvec = "150";
	      %x = Getword(%vector,0);
    	  %y = Getword(%vector,1);
	      %z = Getword(%vector,2);
	      if(%z >= ($Zombie::DForwardSpeed / 3 * 2))
	         %upvec = (%upvec * 5);
          %vector = %x@" "@%y@" "@%upvec;
	      %zombie.applyImpulse(%pos, %vector);
       }
      }
   }
   else if(%zombie.hastarget == 1){
      %zombie.hastarget = 0;
      %zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
   %zombie.moveloop = schedule(500, %zombie, "SSZombiemovetotarget", %zombie);
}








//ASSET AI FUNCTIONS
function ZombieLookforTarget(%zombie){
   %wbpos = %zombie.getworldboxcenter();
   %z = getWord(%wbpos, 2);
   if(%z < $zombie::FallDieHeight) {
      %zombie.scriptKill(0);
   }
   %count = ClientGroup.getCount();
   %closestClient = -1;
   %closestDistance = 32767;
   for(%i = 0; %i < %count; %i++)
   {
	%cl = ClientGroup.getObject(%i);
	if(isObject(%cl.player)){
	   %testPos = %cl.player.getWorldBoxCenter();
	   %distance = vectorDist(%wbpos, %testPos);
	   if (%distance > 0 && %distance < %closestDistance && canAttackPlayer(%cl))
	   {
	   	%closestClient = %cl;
	   	%closestDistance = %distance;
	   }
	}
   }
   return %closestClient SPC %closestDistance;
}

//conditionals, verifies that the zombies can attack this specific player
function canAttackPlayer(%client) {
   if(!%client.player.isFTD && !%client.player.iszombie && !%client.player.stealthed) {
      return true;
   }
   else {
      return false;
   }
}

function ZgetFacingDirection(%zombie,%closestClient,%pos){
   %clpos = %closestClient.getPosition();
   %vector = vectorNormalize(vectorSub(%clpos, %pos));
   %v1 = getword(%vector, 0);
   %v2 = getword(%vector, 1);
   %nv1 = %v2;
   %nv2 = (%v1 * -1);
   %none = 0;
   %vector2 = %nv1@" "@%nv2@" "@%none;
   %zombie.setRotation(fullrot("0 0 0",%vector2));

   return %vector;
}





























//WRAITH ZOMBIE AI.
function StartWraithAI(%zombie) {
   if(!isobject(%zombie)) {
      return;
   }
   if(%zombie.getState() $= "dead") {
	  return;
   }
   //split into sectored if's
   // * Are My Shields Low, or Down?
   if(%zombie.getShieldPercent() <= 25) {
      schedule(500, 0, "StartWraithAI", %zombie);
      WraithZombieAI_Retreat(%zombie);
      return;
   }
   // * Is There Enemies?
   %closestClient = ZombieLookForTarget(%zombie);
   if(isSet(getWord(%closestClient, 0))) {
      //   ** Do I attack?
      if(getWord(%closestClient, 1) < 60) {
         //determine short range attack style
         //all of them have their own offset of AI, so this function is temporarily halted
         %style = getRandom(1, 3);
         switch(%style) {
            case 1:
               //1: Spiker Assault
               WraithAttack_SpikerAssault(%zombie);
               return;
            case 2:
               //2: Rush Based
               WraithAttack_RushBased(%zombie);
               return;
            case 3:
               //3: Steady
               WraithAttack_Steady(%zombie);
               return;
         }
      }
      else {
         //move into range (< 80)
         WraithMoveIntoRange(%zombie, %closestClient);
      }
   //
   }
   //fast AI updates, all handled from this core, attack styles are the exception
   schedule(500, 0, "StartWraithAI", %zombie);
}

function WraithZombieAI_Retreat(%zombie) {
   //nearest player...
   if(!isobject(%zombie))
	return;
   if(%zombie.getState() $= "dead")
	return;
   %pos = %zombie.getworldboxcenter();
   %closestClient = ZombieLookForTarget(%zombie);
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;

   if(%closestDistance < 250) {    //runz0rs
      %TPos = %closestClient.getPosition();
      %tvel = %closestclient.getvelocity();
      %vec = vectorsub(%tpos,%pos);
      %dist = vectorlen(%vec);
      %velpredict = vectorscale(%tvel,(%dist / 50));
      %vector = vectoradd(%vec,%velpredict);
      %vector = vectornormalize(%vector);
      %x = getWord(%vector, 0);
      %y = getWord(%vector, 1);
      %finX = %x;
      %finY = %y * -1;
      %finalVec1 = %finX SPC %finY SPC 0;
      %finalVec = VectorScale(%finalVec1, $Zombie::DForwardSpeed*2);
      %zombie.setRotation(fullrot("0 0 0",%finalVec1));
      //Z is unimportant
      %zombie.applyImpulse(%pos, %finalVec);
   }
}

function WraithMoveIntoRange(%zombie, %closestClient) {
   if(!isobject(%zombie))
	return;
   if(%zombie.getState() $= "dead")
	return;
   %pos = %zombie.getworldboxcenter();
   %closestClient = ZombieLookForTarget(%zombie);
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;
   if(%closestDistance <= $zombie::detectDist && %closestDistance > 60){

	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   LZDoMoan(%zombie);

      %vector = ZgetFacingDirection(%zombie,%closestClient,%pos);
      
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
}

//Spiker Assault
//My weapon.... will ensure they die..
//Basically, spams a shitload of spiker spikes, while slowly moving to the nearest enemy
function WraithAttack_SpikerAssault(%zombie) {
   if(!isobject(%zombie)) {
      return;
   }
   if(%zombie.getState() $= "dead") {
	  return;
   }
   if(%zombie.getShieldPercent() <= 25) {
      //Oh dammit, this isn't working, RUN! and re-consider!
      WraithZombieAI_Retreat(%zombie);
      StartWraithAI(%zombie);
      return;
   }
   //***************************************************
   %pos = %zombie.getworldboxcenter();
   %closestClient = ZombieLookForTarget(%zombie);
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;
   if(%closestDistance <= $zombie::detectDist){
    if(%closestdistance > 65) {
       //too far away, reconsider now
       StartWraithAI(%zombie);
       return;
    }
	if(%zombie.hastarget != 1 && %closestdistance >= 10 && %closestdistance <= 50){
       %zombie.setImageTrigger(0, true);
	}
	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   LZDoMoan(%zombie);

      %vector = ZgetFacingDirection(%zombie,%closestClient,%pos);

	if (%closestdistance >= 10 && %closestdistance <= 50) {
       %zombie.setImageTrigger(0, true); //FIRE!!!!
	}
	%vector = vectorscale(%vector, $Zombie::DForwardSpeed/7);
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= (($Zombie::DForwardSpeed / 3 * 2)))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
   //
   schedule(100, %zombie, "WraithAttack_SpikerAssault", %zombie);
   //
}

//Rush Based
//I join the ranks of my fellow soldiers... and we shall overcome
//Zombie prefers smash attack over using it's spiker
function WraithAttack_RushBased(%zombie) {
   if(!isobject(%zombie)) {
      return;
   }
   if(%zombie.getState() $= "dead") {
	  return;
   }
   if(%zombie.getShieldPercent() <= 25) {
      //Oh dammit, this isn't working, RUN! and re-consider!
      WraithZombieAI_Retreat(%zombie);
      StartWraithAI(%zombie);
      return;
   }
   //***************************************************
   %pos = %zombie.getworldboxcenter();
   %closestClient = ZombieLookForTarget(%zombie);
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;
   if(%closestDistance <= $zombie::detectDist){
    if(%closestdistance > 120) {
       //too far away, reconsider now
       StartWraithAI(%zombie);
       return;
    }
	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   LZDoMoan(%zombie);

      %vector = ZgetFacingDirection(%zombie,%closestClient,%pos);

	%vector = vectorscale(%vector, $Zombie::DForwardSpeed/5);
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= (($Zombie::DForwardSpeed / 3 * 2)))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
   //
   schedule(100, %zombie, "WraithAttack_RushBased", %zombie);
   //
}

//Steady
//It's like I'm a statue, but only worse, because I fire at hostiles who go by
//Prefers to stay behind, but in range of hostiles, and shoot at them, will go aggreesive if approached
function WraithAttack_Steady(%zombie) {
   if(!isobject(%zombie)) {
      return;
   }
   if(%zombie.getState() $= "dead") {
	  return;
   }
   if(%zombie.getShieldPercent() <= 25) {
      //Oh dammit, this isn't working, RUN! and re-consider!
      WraithZombieAI_Retreat(%zombie);
      StartWraithAI(%zombie);
      return;
   }
   //***************************************************
   %pos = %zombie.getworldboxcenter();
   %closestClient = ZombieLookForTarget(%zombie);
   %closestDistance = getWord(%closestClient,1);
   %closestClient = getWord(%closestClient,0).Player;
   if(%closestDistance <= $zombie::detectDist){
    if(%closestdistance > 65) {
       //too far away, reconsider now
       StartWraithAI(%zombie);
       return;
    }
	if(%zombie.hastarget != 1 && %closestdistance > 25 && %closestdistance <= 65){
       %zombie.setImageTrigger(0, true);
	}
	if(%zombie.hastarget != 1){
	   LZDoYell(%zombie);
	   %zombie.hastarget = 1;
	}
	%chance = (getrandom() * 20);
   	if(%chance >= 19)
	   LZDoMoan(%zombie);

      %vector = ZgetFacingDirection(%zombie,%closestClient,%pos);

	if (%closestdistance > 25 && %closestdistance <= 65) {
       %zombie.setImageTrigger(0, true); //FIRE!!!!
	}
    //
    if(%closestDistance <= 25) {
	   %vector = vectorscale(%vector, $Zombie::DForwardSpeed/7);
	   %upvec = "150";
	   %x = Getword(%vector,0);
	   %y = Getword(%vector,1);
	   %z = Getword(%vector,2);
	   if(%z >= (($Zombie::DForwardSpeed / 3 * 2)))
	      %upvec = (%upvec * 5);
	   %vector = %x@" "@%y@" "@%upvec;
	   %zombie.applyImpulse(%pos, %vector);
    }
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
   //
   schedule(100, %zombie, "WraithAttack_Steady", %zombie);
   //
}
