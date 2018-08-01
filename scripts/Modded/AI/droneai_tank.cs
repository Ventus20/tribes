$DTank::ForwardForce = 7000;
$DTank::BackForce = 3000;
$DTank::TurnForce = 2500;

function BattlemasterTankBattle(%pos, %radius, %number, %teamlow, %teamhigh, %maxskill){
   if(%maxskill $= "") {
   %maxskill = 10;
   }
   for(%i = 0; %i < %number; %i++){
	%startpos = vectorAdd(%pos,(getRandom(0, %radius) - (%radius / 2))@" "@(getRandom(0, %radius) - (%radius / 2))@" 0");
	%rotation = "0 0 1 "@getRandom(1,360);
	if(%teamlow != %teamhigh)
	   %team = getRandom(%teamlow,%teamhigh);
	else
	   %team = %teamlow;
	%tank = StartDBattleTank(%startpos,%team,getRandom(1,%maxskill));
    return %tank;
   }
}

function StartDBattleTank(%pos,%team,%skill){
   if(%team $= "")
	%team = 0;
   if(%pos $= "")
	%pos = "0 0 300";
   if(%skill $= "" || %skill < 1)
	%skill = 10;
   else if(%skill > 10)
	%skill = 10;

   %Drone = new HoverVehicle()
   {
      dataBlock    = BattleMaster;
      position     = %pos;
      rotation     = "0 0 1 0";
      team         = %team;
   };
   MissionCleanUp.add(%Drone);

   setTargetSensorGroup(%Drone.getTarget(), %team);

   %Drone.skill = 0.6 + (%skill / 25);

   schedule(100, 0, "DTankScanTargets",%Drone);
   return %Drone;
}

function TankBattle(%pos, %radius, %number, %teamlow, %teamhigh, %maxskill){
   if(%maxskill $= "") {
   %maxskill = 10;
   }
   for(%i = 0; %i < %number; %i++){
	%startpos = vectorAdd(%pos,(getRandom(0, %radius) - (%radius / 2))@" "@(getRandom(0, %radius) - (%radius / 2))@" 0");
	%rotation = "0 0 1 "@getRandom(1,360);
	if(%teamlow != %teamhigh)
	   %team = getRandom(%teamlow,%teamhigh);
	else
	   %team = %teamlow;
	StartDTank(%startpos,%team,getRandom(1,%maxskill));
   }
}

function StartDTank(%pos,%team,%skill){
   if(%team $= "")
	%team = 0;
   if(%pos $= "")
	%pos = "0 0 300";
   if(%skill $= "" || %skill < 1)
	%skill = 10;
   else if(%skill > 10)
	%skill = 10;

   %Drone = new HoverVehicle()
   {
      dataBlock    = HeavyTank;
      position     = %pos;
      rotation     = "0 0 1 0";
      team         = %team;
   };
   MissionCleanUp.add(%Drone); 

   setTargetSensorGroup(%Drone.getTarget(), %team);

   %drone.skill = 0.6 + (%skill / 25);

   schedule(100, 0, "DTankScanTargets",%drone);
}

function DTankScanTargets(%obj){
   if(!isObject(%obj))
	return;
   %pos = %obj.getposition();
   %closestClient = -1;
   %closestDistance = 32767;
   %scandist = 10000 * %obj.skill;
   %airtrgs = "";
   %groundtrgs = "";
   %inftrgs = "";
   InitContainerRadiusSearch(%pos, %scanDist, $TypeMasks::VehicleObjectType | $TypeMasks::PlayerObjectType);
   while ((%searchResult = containerSearchNext()) != 0){
	%objtarget = firstWord(%searchResult);
	if(isObject(%objtarget) && %objTarget !$= %obj && %objtarget.team != %obj.team){
	   %trgtype = %objtarget.getClassName();
	   if(%trgtype $= "FlyingVehicle")
		%airtrgs = %airtrgs SPC %objtarget;
	   else if(%trgtype $= "HoverVehicle")
		%groundtrgs = %groundtrgs SPC %objtarget;
	   else if(%trgtype $= "Player")
		%inftrgs = %inftrgs SPC %objtarget;
      }
   }
   if(%groundtrgs){
	%target = firstWord(%groundtrgs);
	%groundtrgs = getWords(%groundtrgs,1,4);
	DTankGroundCombat(%obj, %target,%groundtrgs);
   }
   else if(%inftrgs){
	%target = firstWord(%inftrgs);
	%inftrgs = getWords(%inftrgs,1,4);
	DTankInfCombat(%obj, %target,%inftrgs);
   }
   else if(%airtrgs){
	%target = firstWord(%airtrgs);
	%airtrgs = getWords(%airtrgs,1,4);
	DTankAACombat(%obj, %target,%airtrgs);
   }
   else{
	schedule(3000, 0, "DTankScanTargets", %obj);
   }
}

function DTankGroundCombat(%obj, %target, %Trglist){
   if(!isObject(%obj))
	return;
   if(!isObject(%target)){
	%obj.turretobject.setImageTrigger(4,false);
	%obj.firing = "";
	if(%TrgList){
	   %target = firstWord(%Trglist);
	   %trglist = getWords(%trglist,1,4);
	}
	else{
	   DTankScanTargets(%obj);
	   return;
	}
   }
   %pos = %obj.getPosition();
   %tpos = %target.getPosition();
   %frdvec = vectorNormalize(getWords(%obj.getForwardVector(),0,1) SPC "0");
   %chkvec = vectorSub(%tpos,%pos);
   %chkvec = vectorNormalize(getWords(%chkvec,0,1) SPC "0");
   %turnvec = vectorsub(%chkvec,%frdvec);
   %vecdif = vectorlen(%turnvec);
   if(vectorDist(%pos,%tpos) > 2000){
	if(%obj.firing){
	   %obj.firing = "";
	   %obj.turret.setImageTrigger(4,false);
	}
	%target = "";
   }
   else if(vectorDist(%pos,%tpos) > 500){
	if(%vecdif >= "0.1"){
	   %vec = vectorCross(%turnvec, %frdvec);
	   %vec = vectorNormalize(vectorCross(%obj.getForwardVector(), %vec));
	   %Imppos = vectorAdd(%pos,%obj.getForwardVector());
	   %obj.applyImpulse(%Imppos,vectorScale(%vec,$DTank::TurnForce * %obj.skill));
	}
   }
   else{
	if(!%obj.firing){
	   %obj.firing = 1;
	   %obj.turretobject.firetype = 2;
	   %obj.turretobject.setTargetObject(%Target);
	   %obj.turretobject.aquireTime = getSimTime();
	   %obj.turretobject.setImageTrigger(4,true);
	}
	if(%vecdif < "1.2" || %vecdif >= "1.6"){
	   %Tvec1 = vectorNormalize(vectorcross(%chkvec,"0 0 1"));
	   %Tvec2 = vectorScale(%Tvec1,-1);
	   if(vectordist(%frdvec,%Tvec1) < vectorDist(%frdvec,%Tvec2))
		%tovec = vectorSub(%Tvec1,%frdvec);
	   else
		%tovec = vectorSub(%Tvec2,%frdvec);
	   %vec = vectorCross(%Tvec2, %frdvec);
	   %vec = vectorNormalize(vectorCross(%obj.getForwardVector(), %vec));
	   %Imppos = vectorAdd(%pos,%obj.getForwardVector());
	   %obj.applyImpulse(%Imppos,vectorScale(%vec,$DTank::TurnForce * %obj.skill));
	}
   }
   %obj.applyImpulse(%pos,vectorScale(%obj.getForwardVector(),$DTank::ForwardForce));
   schedule(100, 0, "DTankGroundCombat",%obj,%target,%Trglist);
}

function DTankAACombat(%obj, %target, %Trglist){
   if(!isObject(%obj))
	return;
   if(!isObject(%target)){
	%obj.turretobject.setImageTrigger(2,false);
	%obj.firing = "";
	if(%TrgList){
	   %target = firstWord(%Trglist);
	   %trglist = getWords(%trglist,1,4);
	}
	else{
	   DTankScanTargets(%obj);
	   return;
	}
   }
   %pos = %obj.getPosition();
   %tpos = %target.getPosition();
   if(vectorDist(%pos,%tpos) < 750){
	if(!%obj.firing){
	   %obj.firing = 1;
	   %obj.turretobject.setTargetObject(%Target);
	   %obj.turretobject.aquireTime = getSimTime();
	   %obj.turretobject.setImageTrigger(2,true);
	}
   }
   else if(vectorDist(%pos,%tpos) > 2000){
	if(%obj.firing){
	   %obj.firing = "";
	   %obj.turretobject.setImageTrigger(2,false);
	}
	%target = "";
   }
   schedule(100, 0, "DTankAACombat",%obj,%target,%Trglist);
}

function DTankInfCombat(%obj, %target, %Trglist){
   if(!isObject(%obj))
	return;
   if(!isObject(%target) || %target.getState() $= "dead"){
	%obj.turretobject.setImageTrigger(3,false);
	%obj.firing = "";
	if(%TrgList){
	   %target = firstWord(%Trglist);
	   %trglist = getWords(%trglist,1,4);
	}
	else{
	   DTankScanTargets(%obj);
	   return;
	}
   }
   %pos = %obj.getPosition();
   %tpos = %target.getPosition();
   %frdvec = vectorNormalize(getWords(%obj.getForwardVector(),0,1) SPC "0");
   %chkvec = vectorSub(%tpos,%pos);
   %chkvec = vectorNormalize(getWords(%chkvec,0,1) SPC "0");
   %turnvec = vectorsub(%chkvec,%frdvec);
   %vecdif = vectorlen(%turnvec);
   if(vectorDist(%pos,%tpos) > 2000){
	if(%obj.firing){
	   %obj.firing = "";
	   %obj.turret.setImageTrigger(3,false);
	}
	%target = "";
   }
   else if(vectorDist(%pos,%tpos) > 300){
	if(%vecdif >= "0.1"){
	   %vec = vectorCross(%turnvec, %frdvec);
	   %vec = vectorNormalize(vectorCross(%obj.getForwardVector(), %vec));
	   %Imppos = vectorAdd(%pos,%obj.getForwardVector());
	   %obj.applyImpulse(%Imppos,vectorScale(%vec,$DTank::TurnForce * %obj.skill));
	}
   }
   else{
	if(!%obj.firing){
	   %obj.firing = 1;
	   %obj.turretobject.firetype = 1;
	   %obj.turretobject.setTargetObject(%Target);
	   %obj.turretobject.aquireTime = getSimTime();
	   %obj.turretobject.setImageTrigger(3,true);
	}
	if(vectorDist(%pos,%tpos) < 100){
	   if(%vecdif <= "1.6"){
	      %vec = vectorCross(%turnvec, %frdvec);
	      %vec = vectorNormalize(vectorCross(%obj.getForwardVector(), %vec));
	      %Imppos = vectorAdd(%pos,%obj.getForwardVector());
	      %obj.applyImpulse(%Imppos,vectorScale(%vec,$DTank::TurnForce * %obj.skill * "-1"));
	   }
	}
	else {
	   if(%vecdif < "1.2" || %vecdif >= "1.6"){
	      %Tvec1 = vectorNormalize(vectorcross(%chkvec,"0 0 1"));
	      %Tvec2 = vectorScale(%Tvec1,-1);
	      if(vectordist(%frdvec,%Tvec1) < vectorDist(%frdvec,%Tvec2))
		   %tovec = vectorSub(%Tvec1,%frdvec);
	      else
		   %tovec = vectorSub(%Tvec2,%frdvec);
	      %vec = vectorCross(%Tvec2, %frdvec);
	      %vec = vectorNormalize(vectorCross(%obj.getForwardVector(), %vec));
	      %Imppos = vectorAdd(%pos,%obj.getForwardVector());
	      %obj.applyImpulse(%Imppos,vectorScale(%vec,$DTank::TurnForce * %obj.skill));
	   }
	}
   }
   %obj.applyImpulse(%pos,vectorScale(%obj.getForwardVector(),$DTank::ForwardForce));
   schedule(100, 0, "DTankInfCombat",%obj,%target,%Trglist);
}
