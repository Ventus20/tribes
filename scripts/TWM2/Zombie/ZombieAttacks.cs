//************************************************************
//*****************Zomb Attack Stuff**************************
//************************************************************

function ChargeEmitter(%zombie){
   if(!isobject(%zombie))
	return;
   if(%zombie.chargecount >= 2){
   	%charge2 = new ParticleEmissionDummy()
   	{
   	   position = %zombie.getMuzzlePoint(6);
   	   dataBlock = "defaultEmissionDummy";
   	   emitter = "burnEmitter";
      };
	MissionCleanup.add(%charge2);
	%charge2.schedule(100, "delete");
   }
   if(%zombie.chargecount <= 7){
   	%charge = new ParticleEmissionDummy()
   	{
   	   position = %zombie.getMuzzlePoint(5);
   	   dataBlock = "defaultEmissionDummy";
   	   emitter = "burnEmitter";
      };
	MissionCleanup.add(%charge);
	%charge.schedule(100, "delete");
   }
   if(%zombie.chargecount <= 9){
      %zombie.Fire = schedule(100, %zombie, "ChargeEmitter", %zombie);
	%zombie.chargecount++;
   }
   else
	%zombie.chargecount = 0;
}

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

function Llifttarget(%zombie,%closestclient,%count){
   if(%count == 0)
	%zombie.canmove = 0;
   if(%closestclient.getState() $= "dead" || %Zombie.getState() $= "dead"){
	%zombie.canmove = 1;
	return;
   }
   %target = %closestclient;
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
	   %target.damage(0, %target.getposition(), 10.0, $DamageType::ZombieL);
	}
	%count = 0;
	%zombie.canmove = 1;
	return;
   }
   %count++;
   %zombie.killingplayer = schedule(150, %zombie, "Llifttarget", %zombie, %closestclient, %count);
}


function DZombieFire(%zombie,%closestclient){
   %pos = %zombie.getMuzzlePoint(4);
   %tpos = %closestclient.getWorldBoxCenter();
   %tvel = %closestclient.getvelocity();
   %vec = vectorsub(%tpos,%pos);
   %dist = vectorlen(%vec);
   %velpredict = vectorscale(%tvel,(%dist / 50));
   %vector = vectoradd(%vec,%velpredict);
   %ndist = vectorlen(%vector);
   %upvec = "0 0 "@((%ndist / 50) * (%ndist / 50) * 2);
   %vector = vectornormalize(vectoradd(%vector,%upvec));
   if(Game.CheckModifier("ItBurns") == 1) {
      %p = new GrenadeProjectile() {
	      dataBlock        = DemonFlamingFireball;
	      initialDirection = %vector;
	      initialPosition  = %pos;
	      sourceObject     = %zombie;
	      sourceSlot       = 4;
      };
   }
   else {
      %p = new GrenadeProjectile() {
	      dataBlock        = DemonFireball;
	      initialDirection = %vector;
	      initialPosition  = %pos;
	      sourceObject     = %zombie;
	      sourceSlot       = 4;
      };
   }
}

function RkillLoop(%zombie,%target,%count){
   if(!isObject(%zombie)){
	%zombie.iscarrying = 0;
	%target.grabbed = 0;
	return;
   }
   if(!isObject(%target)){
	%zombie.iscarrying = 0;
	%target.grabbed = 0;
	return;
   }
   if (%Zombie.getState() $= "dead"){
	%zombie.iscarrying = 0;
	%target.grabbed = 0;
	return;
   }
   if (%target.getState() $= "dead"){
	%zombie.iscarrying = 0;
	%target.grabbed = 0;
	return;
   }
   if(%count == 50){
	%chance = getRandom(1,3);
	if(%chance == 3)
	   %target.damage(0, %tpos, 10.0, $DamageType::Zombie);
	else{
	   %target.isFTD = 1;
	   if(%target.getMountedImage($Backpackslot) !$= "")
   	      %target.throwPack();
   	   %target.finishingfall = schedule(5000, 0, "stopFTD", %target);
	}
	%zombie.iscarrying = 0;
	return;
   }
   %target.setPosition(vectoradd(%zombie.getPosition(),"0 0 -4"));
   %target.setVelocity(%zombie.getVelocity());
   %count++;
   %zombie.killingplayer = schedule(100, 0, "RkillLoop", %zombie, %target, %count);
}

function SniperZombieFire(%zombie,%closestclient){
   %num = getRandom(250, 1000);
   %vec = vectorsub(VectorAdd(%closestclient.getPosition(), "0 0 2.2"),%zombie.getMuzzlePoint(4));
   %accuracy = (vectorlen(%vec) / %num);
   %vec = vectoradd(%vec, vectorscale(%closestclient.getvelocity(), %accuracy));
   %p = new TracerProjectile() { //TWM2 Sniper zombies use ALSWP Snipers :P
	dataBlock        = ALSWPBullet;
	initialDirection = %vec;
	initialPosition  = %zombie.getMuzzlePoint(4);
	sourceObject     = %zombie;
	sourceSlot       = 4;
   };
   ServerPlay3D(ALSWPFireSound, %zombie.getPosition());
}

//slingshot fire
function SlingshotFire(%zombie, %target) {
   if(isobject(%zombie) && isobject(%target)){ //Must be a living pilot
      if(%Zombie.firstFired == 1){
         %vec = vectorsub(vectorAdd(%target.getworldboxcenter(), "0 0 1"),%zombie.getMuzzlePoint(4));
         %vec = vectoradd(%vec, vectorscale(%target.getvelocity(),vectorlen(%vec)/1000));
         %zombie.firstFired = 2;
   	     %p = new TracerProjectile() {
   	   	    dataBlock        = SSZombieAcidBall;
   	   	    initialDirection = %vec;
   	   	    initialPosition  = %zombie.getMuzzlePoint(4);
   	   	    sourceObject     = %zombie;
   	   	    sourceSlot       = 6;
   	     };
         %zombie.Fire = schedule(250, %zombie, "SlingshotFire", %zombie, %target);
      }
      else if(%Zombie.firstFired == 2){
         %vec = vectorsub(vectorAdd(%target.getworldboxcenter(), "0 0 1"),%zombie.getMuzzlePoint(5));
	     %vec = vectoradd(%vec, vectorscale(%target.getvelocity(),vectorlen(%vec)/1000));
         %zombie.firstFired = 3;
   	     %p = new TracerProjectile() {
   	   	    dataBlock        = SSZombieAcidBall;
   	   	    initialDirection = %vec;
   	   	    initialPosition  = %zombie.getMuzzlePoint(5);
   	   	    sourceObject     = %zombie;
   	   	    sourceSlot       = 6;
   	     };
         %zombie.Fire = schedule(250, %zombie, "SlingshotFire", %zombie, %target);
      }
      else if(%Zombie.firstFired == 3){
         %vec = vectorsub(vectorAdd(%target.getworldboxcenter(), "0 0 1"),%zombie.getMuzzlePoint(5));
	     %vec = vectoradd(%vec, vectorscale(%target.getvelocity(),vectorlen(%vec)/1000));
         %zombie.firstFired = 0;
         %zombie.nomove = 0;
   	     %p = new TracerProjectile() {
   	   	    dataBlock        = SSZombieAcidBall;
   	   	    initialDirection = %vec;
   	   	    initialPosition  = %zombie.getMuzzlePoint(5);
   	   	    sourceObject     = %zombie;
   	   	    sourceSlot       = 6;
   	     };
      }
   	  else {
         %vec = vectorsub(vectorAdd(%target.getworldboxcenter(), "0 0 1"),%zombie.getMuzzlePoint(5));
	     %vec = vectoradd(%vec, vectorscale(%target.getvelocity(),vectorlen(%vec)/1000));
   	     %p = new TracerProjectile() {
   	   	    dataBlock        = SSZombieAcidBall;
   	   	    initialDirection = %vec;
   	   	    initialPosition  = %zombie.getMuzzlePoint(5);
   	   	    sourceObject     = %zombie;
   	   	    sourceSlot       = 5;
         };
	     %zombie.firstFired = 1;
   	     %zombie.Fire = schedule(250, %zombie, "SlingshotFire", %zombie, %target);
      }
   }
   else {
      %zombie.firstFired = 0;
	  %zombie.nomove = 0;
   }
}
