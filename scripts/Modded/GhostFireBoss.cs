function StartGhostFire(%pos) {
	%Ghost = new player(){
	   Datablock = "GhostFireArmor";
	};
   %Ghost.setTransform(%pos);
   %Ghost.team = $zombie::team;
   %Ghost.hastarget = 1;
   %Ghost.isGOF = 1;
   MissionCleanup.add(%Ghost);
   %Ghost.target = createTarget(%Ghost, "The Ghost Of Fire", "", "Male3", '', %Ghost.team, PlayerSensor);
   setTargetSensorData(%Ghost.target, PlayerSensor);
   setTargetSensorGroup(%Ghost.target, 0);
   setTargetName(%Ghost.target, addtaggedstring("\c7The Ghost Of Fire"));
   GOFConsiderFlamethrowerAttack(%Ghost);
   GOFDoRandomAttacks(%ghost);
   schedule(1,0,"StartBossMusic","GOF", %Ghost);
   schedule(500,0,"GOFLookforTarget", %Ghost);
}

function GOFLookforTarget(%Ghost) {
   if(!isObject(%Ghost))
	return;
   if(%Ghost.getState() $= "dead")
	return;
   %pos = %Ghost.getposition();
   %wbpos = %Ghost.getworldboxcenter();
   %count = ClientGroup.getCount();
   %closestClient = -1;
   %closestDistance = 32767;
   for(%i = 0; %i < %count; %i++) {
	%cl = ClientGroup.getObject(%i);
	if(isObject(%cl.player)){
	   %testPos = %cl.player.getWorldBoxCenter();
	   %distance = vectorDist(%wbpos, %testPos);
	   if (%distance > 0 && %distance < %closestDistance) {
	   	%closestClient = %cl;
	   	%closestDistance = %distance;
	   }
	}
   }
   if(%closestClient) {
       GOFPerformMove(%Ghost,%closestClient,%closestDistance);
   }
   %Ghost.Targeting = schedule(500, %Ghost, "GOFLookforTarget", %Ghost);
}

function GOFPerformMove(%ghost,%closestClient,%closestDistance) {
   %ghost.TargetCL = %closestClient;
   %ghost.DistToTarg = %closestDistance;
   %zposition = %ghost.getPosition();
   %Zzaxis = getword(%zposition,2);
   if(%Zzaxis < $zombie::falldieheight) {
   %ghost.scriptkill($DamageType::Suicide);
   }
   %pos = %ghost.getworldboxcenter();
   %closestClient = %closestClient.Player;
   if(%closestDistance <= $zombie::detectDist){
	if(%ghost.hastarget != 1){
	   %ghost.hastarget = 1;
	}
 
    //target is coming in for an easy kill, lets tele
    if(%closestDistance < 15) {
       BurnTeleport(%ghost);
    }

	%clpos = %closestClient.getPosition();
      %vector = vectorNormalize(vectorSub(%clpos, %pos));
	%v1 = getword(%vector, 0);
	%v2 = getword(%vector, 1);
	%nv1 = %v2;
	%nv2 = (%v1 * -1);
	%none = 0;
	%vector2 = %nv1@" "@%nv2@" "@%none;
	%ghost.setRotation(fullrot("0 0 0",%vector2));

	%fmultiplier = $Zombie::ForwardSpeed;
	%vector = vectorscale(%vector, %Fmultiplier);
	%upvec = "150";

	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= 600)
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%ghost.applyImpulse(%pos, %vector);
   }
}


//ATTACKS
function GOFConsiderFlamethrowerAttack(%g) {
   if(!isObject(%g) || %g.getState() $= "dead") {
      return;
   }
   %target = %g.TargetCL;
   %distance = %g.DistToTarg;
   if(isObject(%target.player) && %target.player.getState() !$= "dead") {
      //We have a target, time to scan distance
      if(%distance <= 35) {
         //The idiot is in range, crisp em :)
         %vec = vectorsub(%target.player.getworldboxcenter(),vectorAdd(%g.getPosition(), "0 0 1"));
         %vec = vectoradd(%vec, vectorscale(%target.player.getvelocity(),vectorlen(%vec)/100));
         %p = new LinearFlareProjectile() {
             dataBlock        = FlameboltMain; //burn :)
             initialDirection = %vec;
             initialPosition  = vectorAdd(%g.getPosition(), "0 0 1");
             sourceObject     = %g;
             sourceSlot       = 0;
         };
         schedule(200,0,"GOFConsiderFlamethrowerAttack",%g);
      }
      else {
         schedule(750,0,"GOFConsiderFlamethrowerAttack",%g);
      }
   }
   //no target, lets use a longer loop
   else {
      schedule(750,0,"GOFConsiderFlamethrowerAttack",%g);
   }
}

function ThrowFireBall(%g, %t) {
   if(!isObject(%t) || %t.getState() $= "dead") {
      return;
   }
   if(!isObject(%g) || %g.getState() $= "dead") {
      return;
   }
   %vec = vectorsub(%t.getworldboxcenter(),%g.getMuzzlePoint(0));
   %vec = vectoradd(%vec, vectorscale(%t.getvelocity(),vectorlen(%vec)/100));
   %p = new LinearProjectile() {
       dataBlock        = NapalmShot; //burn :)
       initialDirection = %vec;
       initialPosition  = %g.getMuzzlePoint(0);
       sourceObject     = %g;
       sourceSlot       = 0;
   };
}

function CreateFireBlast(%g, %pos) {
   if(!isObject(%g) || %g.getState() $= "dead") {
      return;
   }
   %p = new TracerProjectile() {
	   	dataBlock        = napalmSubExplosion;
	   	initialDirection = "0 0 -10";
	   	initialPosition  = %pos;
	   	sourceObject     = %g;
   	   	sourceSlot       = 5;
   };
   %p.vector = "0 0 -10";
   %p.count = 1;
}

function BurnTeleport(%g) {
   if(!isObject(%g) || %g.getState() $= "dead") {
      return;
   }
   %cP = %g.getPosition();
   %nP = getRandomPosition(55,0);
   %nP2 = vectorAdd(%np, "0 0 100");
   %fP = vectorAdd(%cP, %nP2);
   CreateFireBlast(%g, %cP);
   %g.setTransform(%fP);
   messageall('TheFireMsg',"\c4The Ghost Of Fire: ehehehehe.. Burn out...");
}

function GOFDoFlameCano(%g, %target) {
   if(!isObject(%g) || %g.getState() $= "dead") {
      return;
   }
   %g.setPosition(VectorAdd(%target.player.getPosition(), "0 0 70"));
   %Pad = new StaticShape() {
      dataBlock = DeployedSpine;
      scale = ".1 .1 1";
      position = VectorAdd(%target.player.getPosition(), "0 0 69");
   };
   %g.setMoveState(true);
   %Pad.setCloaked(true);
   %Pad.schedule(3000, "setPosition", vectorSub(%Pad.getPosition(), "0 0 10"));
   %Pad.schedule(4000, "setPosition", vectorSub(%Pad.getPosition(), "0 0 20"));
   %Pad.schedule(5000, "setPosition", vectorSub(%Pad.getPosition(), "0 0 30"));
   %Pad.schedule(6000, "setPosition", vectorSub(%Pad.getPosition(), "0 0 40"));
   %g.schedule(6500, "SetMoveState", false);
   %pad.schedule(6500, "Delete");
   //The Vector Crap
   schedule(2500,0,"DropFlameCano", %g, %target);
}

function DropFlameCano(%g, %target) {
   if(!isObject(%g) || %g.getState() $= "dead") {
      return;
   }
   //First, Specify All Directions
   %vec[1] = vectorscale(vectornormalize("1 0 0"), 24);  // +X 0Y
   %vec[2] = vectorscale(vectornormalize("1 1 0"), 24);  // +X +Y
   %vec[3] = vectorscale(vectornormalize("1 -1 0"), 24); // +X -Y
   %vec[4] = vectorscale(vectornormalize("-1 0 0"), 24); // -X 0Y
   %vec[5] = vectorscale(vectornormalize("-1 1 0"), 24); // -X +Y
   %vec[6] = vectorscale(vectornormalize("-1 -1 0"), 24); //-X -Y
   %vec[7] = vectorscale(vectornormalize("0 1 0"), 24);  // 0X +Y
   %vec[8] = vectorscale(vectornormalize("0 -1 0"), 24); // 0X -Y
   //Oh.. long crap
   for(%i = 1; %i <= 8; %i++) {
      %p = new TracerProjectile() {
	      	dataBlock        = napalmSubExplosion;
	    	initialDirection = "0 0 -30";
	    	initialPosition  = vectorAdd(%g.getPosition(), "0 0 -3");
	    	sourceObject     = %g;
   	    	sourceSlot       = 5;
      };
      %p.vector = %vec[%i];
      %p.count = 1;
   }
}

function GhostlyFireAttack(%obj, %Proj, %reptarg) {
   %projpos = %proj.position;

   %projdir = %proj.initialdirection;

   %type = %reptarg.getClassName();

   if(!isobject(%proj)) {
      return;
   }
   if(isobject(%proj)) {
	  %proj.delete();
   }
   if(!isobject(%obj)) {
      return;
   }
   if(!isobject(%reptarg)) {
      return;
   }
   if(%type $= "Player") {
      if(%reptarg.getState() $= "Dead") {
         return;
      }
   }

   //( ... )the projs now have a max turn angle like real missile ub3r l33t;;;; nm wtf afasdf
   %test = getWord(%projdir, 0);
   %test2 = getWord(%projdir, 1);
   %test3 = getWord(%projdir, 2);

   %projdir = vectornormalize(vectorsub(%reptarg.position,%projpos));
   %testa = getWord(%projdir, 0);
   %testa2 = getWord(%projdir, 1);
   %testa3 = getWord(%projdir, 2);

   // now it's time for my mad math skills..... i used microsoft calculator to figure this one out =0... was a brainbuster for me to think of how this would work
   %testthing = %test - %testa; //oh u can rename all this test stuff but make sure u get it right =/ dont break plz
   %testfin = %testthing / 8;  //!!!!!!!!!! OK HERE!!!! is where the max angle thing is... increase for lower turn angle and reduce for a higher turn angle
   %testfinal = %testfin * -1;   //^^^^^ *side note for the one above this* dont div by zero unless yer dumb (...) div by i think 1 if you want it to seek with a 360 max turn angle angle... kinda gay though if u do that
   %testfinale = %testfinal + %test;

   %testthing2 = %test2 - %testa2;
   %testfin2 = %testthing2 / 10; //change here too .. this is for the y axis  btw it's best if u leave my setting of 10 on ... it's the most balanced well nm change it to what u want but you really should leave it around this number like 9ish
   %testfinal2 = %testfin2 * -1;
   %testfinale2 = %testfinal2 + %test2;

   %testthing3 = %test3 - %testa3;
   %testfin3 = %testthing3 / 10; //z- axis this one is for i think.. mmm idea... you try playing with dif max angles for xyz for maybe like a sidewinder effect =?
   %testfinal3 = %testfin3 * -1;
   %testfinale3 = %testfinal3 + %test3;

   %haxordir = %testfinale SPC %testfinale2 SPC %testfinale3; //final dir.. .....

   %proj = new (linearflareprojectile)() {
       dataBlock        = GhostFlameboltMain;
       initialDirection = %haxordir;
       initialPosition  = %projpos;
       sourceslot = %obj;
   };
   %proj.sourceobject = %obj;
   MissionCleanup.add(%proj);

   %searchmask = $TypeMasks::ProjectileObjectType;

   InitContainerRadiusSearch(%projpos, 12, %searchmask);
   while ((%target = containerSearchNext())) {
      if(%target.getdatablock().getname() $= "FlareGrenadeProj") { //btw u can add other projs that will cancel out seeking linear flare
	     %target.delete();
	     return;
      }
   }

   %proj.seeksched = schedule( 80,0, "GhostlyFireAttack" ,%obj, %Proj, %reptarg);
}

function GOFDoRandomAttacks(%g) {
   if(!isObject(%g) || %g.getState() $= "dead") {
      return;
   }
   %rand = getRandom(1,7);
   %target = FindValidTarget(%g);
   switch(%rand) {
      case 1:
         if(isObject(%target.player)) {
         CreateFireBlast(%g, %target.player.getPosition());
         messageall('TheFireMsg',"\c4The Ghost Of Fire: Time to heat things up "@getTaggedString(%target.name)@".");
         }
         else {
         messageall('TheFireMsg',"\c4The Ghost Of Fire: Frightened of my fire? Good.");
         }
      case 2:
         if(isObject(%target.player)) {
         ThrowFireBall(%g, %target.player);
         messageall('TheFireMsg',"\c4The Ghost Of Fire: Lets see how you dodge this, "@getTaggedString(%target.name)@".");
         }
         else {
         messageall('TheFireMsg',"\c4The Ghost Of Fire: Frightened of this? Good.");
         }
      case 3:
         if(isObject(%target.player)) {
         ThrowFireBall(%g, %target.player);
         schedule(400,0,"ThrowFireBall", %g, %target.player);
         schedule(800,0,"ThrowFireBall", %g, %target.player);
         schedule(1200,0,"ThrowFireBall", %g, %target.player);
         schedule(1600,0,"ThrowFireBall", %g, %target.player);
         messageall('TheFireMsg',"\c4The Ghost Of Fire: Flame Storm "@getTaggedString(%target.name)@", cooked up nicely for you.");
         }
         else {
         messageall('TheFireMsg',"\c4The Ghost Of Fire: I love Fire.. it's Good your scared.");
         }
      case 4:
         if(isObject(%target.player)) {
         CreateFireBlast(%g, vectorAdd(%target.player.getPosition(), "0 0 25"));
         schedule(400,0,"CreateFireBlast", %g, vectorAdd(%target.player.getPosition(), "0 0 30"));
         schedule(800,0,"CreateFireBlast", %g, vectorAdd(%target.player.getPosition(), "0 0 35"));
         schedule(1200,0,"CreateFireBlast", %g, vectorAdd(%target.player.getPosition(), "0 0 40"));
         schedule(1600,0,"CreateFireBlast", %g, vectorAdd(%target.player.getPosition(), "0 0 45"));
         messageall('TheFireMsg',"\c4The Ghost Of Fire: Engage Dictator Strike!!!");
         }
         else {
         messageall('TheFireMsg',"\c4The Ghost Of Fire: Frightened Of Fire? Good.");
         }
      case 5:
         if(isObject(%target.player)) {
         GOFDoFlameCano(%g, %target);
         messageall('TheFireMsg',"\c4The Ghost Of Fire: I Intend Every Moment... FLAMECANO!");
         }
         else {
         messageall('TheFireMsg',"\c4The Ghost Of Fire: Oh Well, The Volcanic Explosion Can Wait.");
         }
      case 6:
         if(isObject(%target.player)) {
         %p1 = spawnprojectile("GhostFlameboltMain","LinearFlareProjectile",VectorAdd(%g.getPosition(), "0 0 5"), "0 0 1", %g);
         GhostlyFireAttack(%g, %p1, %target.player);
         %p2 = spawnprojectile("GhostFlameboltMain","LinearFlareProjectile",VectorAdd(%g.getPosition(), "0 0 5"), "0 0 1", %g);
         schedule(1500,0,"GhostlyFireAttack", %g, %p2, %target.player);
         %p3 = spawnprojectile("GhostFlameboltMain","LinearFlareProjectile",VectorAdd(%g.getPosition(), "0 0 5"), "0 0 1", %g);
         schedule(3000,0,"GhostlyFireAttack", %g, %p3, %target.player);
         messageall('TheFireMsg',"\c4The Ghost Of Fire: Clensic Flames Will Persue You "@%target.namebase@"!");
         }
         else {
         messageall('TheFireMsg',"\c4The Ghost Of Fire: Darn, I Love Cursed Fire.");
         }
      case 7:
         if(isObject(%target.player)) {
         %p1 = spawnprojectile("GhostFlameboltMain","LinearFlareProjectile",VectorAdd(%g.getPosition(), "0 0 5"), "0 0 1", %g);
         GhostlyFireAttack(%g, %p1, %target.player);
         %p2 = spawnprojectile("GhostFlameboltMain","LinearFlareProjectile",VectorAdd(%g.getPosition(), "0 0 5"), "0 0 1", %g);
         schedule(1500,0,"GhostlyFireAttack", %g, %p2, %target.player);
         %p3 = spawnprojectile("GhostFlameboltMain","LinearFlareProjectile",VectorAdd(%g.getPosition(), "0 0 5"), "0 0 1", %g);
         schedule(3000,0,"GhostlyFireAttack", %g, %p3, %target.player);
         %p4 = spawnprojectile("GhostFlameboltMain","LinearFlareProjectile",VectorAdd(%g.getPosition(), "0 0 5"), "0 0 1", %g);
         schedule(1500,0,"GhostlyFireAttack", %g, %p4, %target.player);
         %p5 = spawnprojectile("GhostFlameboltMain","LinearFlareProjectile",VectorAdd(%g.getPosition(), "0 0 5"), "0 0 1", %g);
         schedule(3000,0,"GhostlyFireAttack", %g, %p5, %target.player);

         messageall('TheFireMsg',"\c4The Ghost Of Fire: Clensic Flames Will Persue You "@%target.namebase@", MANY FLAMES!");
         }
         else {
         messageall('TheFireMsg',"\c4The Ghost Of Fire: Darn, I Love Mega Cursed Fire.");
         }
      default:
         if(isObject(%target.player)) {
         CreateFireBlast(%g, %target.player.getPosition());
         messageall('TheFireMsg',"\c4The Ghost Of Fire: Time to heat things up "@getTaggedString(%target.name)@".");
         }
         else {
         messageall('TheFireMsg',"\c4The Ghost Of Fire: Frightened? Good.");
         }
   }
   schedule(25000,0,"GOFDoRandomAttacks", %g);
}
