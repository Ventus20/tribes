//---------------------------------------------------------
// Deployable Telepad
//---------------------------------------------------------

datablock ShapeBaseImageData(TelePadDeployableImage) {
	mass = 15;
	emap = true;
	shapeFile = "stackable1s.dts";
	item = TelePadPack;
	mountPoint = 1;
	offset = "0 0 0";
	deployed = TelePadDeployedBase;
	heatSignature = 0;

	stateName[0] = "Idle";
	stateTransitionOnTriggerDown[0] = "Activate";

	stateName[1] = "Activate";
	stateScript[1] = "onActivate";
	stateTransitionOnTriggerUp[1] = "Idle";

	isLarge = true;
	maxDepSlope = 360;
	deploySound = StationDeploySound;

	minDeployDis = 0.5;
	maxDeployDis = 5.0;
};

datablock ItemData(TelePadPack) {
	className = Pack;
	catagory = "Deployables";
	shapeFile = "stackable1s.dts";
	mass = 3.0;
	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 1;
	rotate = false;
	image = "TelePadDeployableImage";
	pickUpName = "a teleport pad pack";
	heatSignature = 0;
        joint = "2 2 2";
	computeCRC = true;
	emap = true;
};

datablock SensorData(TelePadBaseSensorObj) {
	detects = true;
	detectsUsingLOS = true;
	detectsPassiveJammed = false;
	detectsActiveJammed = false;
	detectsCloaked = false;
	detectionPings = true;
	detectRadius = 10;
};

datablock StaticShapeData(TelePadDeployedBase) : StaticShapeDamageProfile {
	className = "teleport";
	shapeFile = "nexuscap.dts";

	maxDamage = 2.00;
	destroyedLevel = 2.00;
	disabledLevel = 1.35;

	isShielded = true;
	energyPerDamagePoint = 250;
	maxEnergy = 100;
	rechargeRate = 1;

	explosion = ShapeExplosion; // DeployablesExplosion;
	expDmgRadius = 18.0;
	expDamage = 0.1;
	expImpulse = 200.0;

	dynamicType = $TypeMasks::StationObjectType;
	deployedObject = true;
	cmdCategory = "DSupport";
	cmdIcon = CMDSwitchIcon;
	cmdMiniIconName = "commander/MiniIcons/com_switch_grey";
	targetNameTag = 'Deployed';
	targetTypeTag = 'Teleport Pad';

	debrisShapeName = "debris_generic.dts";
	debris = DeployableDebris;

	heatSignature = 0;
	needsPower = true;

	humSound = SensorHumSound;
	pausePowerThread = true;
	sensorData = TelePadBaseSensorObj;
	sensorRadius = TelePadBaseSensorObj.detectRadius;
	sensorColor = "0 212 45";
	firstPersonOnly = true;

	lightType = "PulsingLight";
	lightColor = "0 1 0 1";
	lightTime = 1200;
	lightRadius = 6;
};

datablock AudioProfile(TelePadAccessDeniedSound) {
	filename = "gui/vote_nopass.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(TelePadBeamSound) {
	filename = "fx/vehicles/inventory_pad_on.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(TelePadPowerUpSound) {
	filename = "fx/powered/turret_heavy_activate.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(TelePadPowerDownSound) {
	filename = "fx/powered/inv_pad_off.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock ParticleData(TelePadTeleportParticle)
{
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.0;

   lifetimeMS           = 1200;
   lifetimeVarianceMS   = 400;

   textureName          = "special/lightFalloffMono";

   useInvAlpha =  false;
   spinRandomMin = -200.0;
   spinRandomMax =  200.0;

   colors[0]     = "0.5 0.8 0.2 1.0";
   colors[1]     = "0.6 0.9 0.3 1.0";
   colors[2]     = "0.7 1.0 0.4 1.0";
   sizes[0]      = 0.2;
   sizes[1]      = 0.1;
   sizes[2]      = 0.05;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(TelePadTeleportEmitter)
{
   ejectionPeriodMS = 1;
   ejectionOffset   = 7.0;
   periodVarianceMS = 0.0;
   ejectionVelocity = 2.0;
   velocityVariance = 2.0;
   thetaMin         = 0.0;
   thetaMax         = 10.0;
   lifetimeMS       = 0;

   particles = "TelePadTeleportParticle";
};

function TelePadDeployedBase::onDestroyed(%this,%obj,%prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this,%obj,%prevState);
	$TeamDeployedCount[%obj.team,TelePadPack]--;
	%obj.isRemoved = true;
	remDSurface(%obj);
	%obj.schedule(500,"delete");
}

function TelePadDeployedBase::disassemble(%data,%plyr,%obj) {
	%obj.isRemoved = true;
	disassemble(%data,%plyr,%obj);
}

function TelePadDeployedBase::onGainPowerEnabled(%data,%obj) {
	if (shouldChangePowerState(%obj,true)) {
		tp_fadeIn(%obj,true);
		%obj.playThread($AmbientThread,"ambient");
		%obj.setThreadDir($AmbientThread,true);

		%obj.playThread($ActivateThread,"transition");
		%obj.setThreadDir($ActivateThread,false);

		%obj.play3D(TelePadPowerUpSound);
	}
	Parent::onGainPowerEnabled(%data,%obj);
}

function TelePadDeployedBase::onLosePowerDisabled(%data,%obj) {
	if (shouldChangePowerState(%obj,false)) {
		tp_fadeOut(%obj,true);
		%obj.stopThread($AmbientThread);

		%obj.playThread($ActivateThread,"transition");
		%obj.setThreadDir($ActivateThread,true);

		%obj.play3D(TelePadPowerDownSound);
	}
	Parent::onLosePowerDisabled(%data,%obj);
}

function TelePadDeployedBase::onCollision(%data,%obj,%col) {
	if (%col.justTeleported || %obj.isRemoved)
		return;

	// verify pad.team is team associated and is on player's team
	if (%obj.team != %col.team && %obj.teleMode != 1 && %obj.frequency > 0 && %obj.ishacked != 1) {
		%obj.play3D(TelePadAccessDeniedSound);
           if(%col.client)
           messageClient(%col.client,'msgClient','\c2Access Denied -- Wrong team use, /hack help , to hack this teleport.');
		%col.justTeleported = true;
		schedule(2000,0,"unTeleport",%col);
		return;
	}

	// verify that pad can transmit
	if (%obj.teleMode == 3) {
		%obj.play3D(TelePadAccessDeniedSound);
		messageClient(%col.client,'msgClient','\c2Error : This Telepad is Recieve Only.');
		%col.justTeleported = true;
		schedule(2000,0,"unTeleport",%col);
		return;
	}

	// Discover next pad to teleport to
	%dgroup = nameToID(Deployables);
	%destPad = 0;
	%firstPad = 0;
	for(%depIndex = 0; %depIndex < %dgroup.getCount(); %depIndex++) {
		%dep = %dgroup.getObject(%depIndex);
		if (%dep.getDataBlock().className $= "teleport") {
			if (%dep != %obj && %dep.frequency == %obj.frequency && %dep.team == %obj.team && %dep.teleMode != 2) {
				if (%dep.isPowered() && %dep.isEnabled() && !(%dep.getEnergyLevel() < %dep.getDataBlock().maxEnergy)) {
					if (!%firstPad || %dep < %firstPad)
						%firstPad = %dep;
					if (%dep > %obj && (!%destPad || %dep < %destPad)) {
						%destPad = %dep;
					}
				}
				else
					%notEnabled = true;
			}
		}
	}
	if (!%destPad)
		%destPad = %firstPad;

	if (!%obj.isPowered() || !%obj.isEnabled()) {
		%obj.play3D(TelePadAccessDeniedSound);
		if (!%obj.isPowered() && !%obj.isEnabled())
			messageClient(%col.client,'msgClient','\c2The Target Telepad is Damaged and is not Powered.');
		else if (!%obj.isEnabled())
			messageClient(%col.client,'msgClient','\c2The Target Telepad is Damaged.');
		else if (!%obj.isPowered())
			messageClient(%col.client,'msgClient','\c2The Target Telepad is currently offline.');
		else
			messageClient(%col.client,'msgClient','\c2Telepad Malfunction, Unable to teleport.');
		%col.justTeleported = true;
		schedule(2000,0,"unTeleport",%col);
		return;
	}

	if (!%destPad) {
		%obj.play3D(TelePadAccessDeniedSound);
		if (%notEnabled)
			messageClient(%col.client,'msgClient','\c2Error : Destination Damaged or has no power.');
		else
			messageClient(%col.client,'msgClient','\c2Error : No other telepads detected.');
		%col.justTeleported = true;
		schedule(2000,0,"unTeleport",%col);
		return;
	}

	if (tp_isBlocked(%destPad,%col)) {
		%obj.play3D(TelePadAccessDeniedSound);
		messageClient(%col.client,'msgClient','\c2Target Error : Destination Blocked.');
		%col.justTeleported = true;
		schedule(2000,0,"unTeleport",%col);
		return;
	}

	if (%obj.getEnergyLevel() < %obj.getDataBlock().maxEnergy) {
		%obj.play3D(TelePadAccessDeniedSound);
		messageClient(%col.client,'msgClient','\c2Telepad recharging, Please return in a few seconds.');
		%col.justTeleported = true;
		schedule(2000,0,"unTeleport",%col);
		return;
	}

	// center player on pad
	if (!tp_isBlocked(%obj,%col))
		tp_adjustPlayer(%obj,%col);

	// fade out player
	%col.disableMove(true);
	pl_fadeOut(%col);

	// pad power up effect
	tp_fadePadIn(%obj);
	tp_fadePadIn(%destPad);

	// pad power down effect
	schedule(1500,0,"tp_fadePadOut",%obj);
	schedule(1550,0,"tp_fadePadOut",%destPad);

	// Zap energy
	%obj.setEnergyLevel(0);
	%destPad.setEnergyLevel(0);

	%col.justTeleported = true;

	messageClient(%col.client,'msgClient',"~wfx/misc/diagnostic_on.wav");
	schedule(500,0,"teleport",%col,%destPad,%obj); // schedule their teleportation
	tp_emitter(%obj);
}

function tp_isBlocked(%pad,%obj) {
	%padPos = %pad.getPosition();
	%telePos = vectorAdd(%padPos,vectorScale(realVec(%pad,"0 0 1"),-2.5));
	if (containerRayCast(%padPos,%telePos,-1,%pad))
		%blocked = true;
	if (!$Host::AllowUnderground) {
		%terrain = getTerrainHeight2(%telePos);
		if (getWord(%telePos,2) < getWord(%terrain,2) || %terrain $= "")
			%blocked = true;
	}
	if (isObject(%obj)) {
		%adjust = vectorAdd(vectorScale(vectorNormalize(realVec(%pad,"0 0 1")),-1.35),vectorSub(%obj.getPosition(),%obj.getWorldBoxCenter()));
		%pos = vectorAdd(%padPos,%adjust);
		if (!$Host::AllowUnderground) {
			%terrain = getTerrainHeight2(%pos);
			if (getWord(%pos,2) < getWord(%terrain,2) || %terrain $= "")
				%blocked = true;
		}
		if (containerRayCast(%telePos,%pos,-1,%obj))
			%blocked = true;
	}
	return %blocked;
}

// player
function pl_fadeIn(%obj) {
	%obj.startFade(500,0,false);
    if(%obj.client)
	messageClient(%obj.client,'msgClient',"~wfx/misc/diagnostic_on.wav");
}

function pl_fadeOut(%obj) {
	%obj.startFade(500,0,true);
    if(%obj.client)
	messageClient(%obj.client,'msgClient',"~wfx/misc/diagnostic_on.wav");
}

// beam and sound
function tp_fadeIn(%obj,%silent) {
	if (%obj.isPowered() && %obj.isEnabled()) {
		if (!%silent)
			%obj.play3D(DiscReloadSound);
//		%obj.beam.startFade(100,0,false);
	}
}

function tp_fadeOut(%obj,%silent) {
	if (!%silent)
		%obj.play3D(TelePadBeamSound);
//	%obj.beam.startFade(100,0,true);
}

// pad
function tp_fadePadIn(%obj) {
	%obj.playThread($ActivateThread,"transition");
	%obj.setThreadDir($ActivateThread,true);
}

function tp_fadePadOut(%obj) {
	%obj.playThread($ActivateThread,"transition");
	%obj.setThreadDir($ActivateThread,false);
}

// fancy emitter
function tp_emitter(%obj) {
	%em = new ParticleEmissionDummy() {
		scale = "1 1 1";
		dataBlock = "defaultEmissionDummy";
		emitter = "TelePadTeleportEmitter";
		velocity = "1";
	};
	%adjust = vectorScale(realVec(%obj,"0 0 1"),7);
	%em.setTransform(vectorAdd(%obj.getPosition(),%adjust) SPC rotAdd(%obj.getRotation(),"1 0 0" SPC $Pi));
	MissionCleanup.add(%em);
	%em.schedule(1000,"delete");
}

function unTeleport(%pl) {
	if (isObject(%pl))
		%pl.justTeleported = false;
}

function teleport(%pl,%destPad,%src) {
	%pl.setVelocity("0 0 0"); //slow me down, ive been falling :)
	%pl.schedule(500,disableMove,false);
	pl_fadeIn(%pl);
	schedule(2650,0,"unTeleport",%pl);

	if (!isObject(%destPad)) {// lost the destination
		messageClient(%pl.client,'msgClient','\c2Target Error : The Destination has been lost');
		tp_adjustPlayer(%src,%pl);
	}
	else {
		if (%pl.team == %src.team)
			messageClient(%pl.client,'msgClient','\c2Teleporting on frequency %1.',%src.frequency);
		else
			messageClient(%pl.client,'msgClient','\c2Teleporting on ENEMY frequency %1!',%src.frequency);
		tp_adjustPlayer(%destPad,%pl);
		tp_emitter(%destPad);
	}
}

function tp_adjustPlayer(%pad,%obj) {
	%adjust = vectorAdd(vectorScale(vectorNormalize(realVec(%pad,"0 0 1")),-1.35),vectorSub(%obj.getPosition(),%obj.getWorldBoxCenter()));
	%rot =  %obj.getRotation();
	%obj.setTransform(vectorAdd(%pad.getPosition(),%adjust) SPC %rot);
}

//function tp_adjustBeam(%pad) {
//	%rot =  rotAdd(%pad.getRotation(),"1 0 0" SPC $Pi);
//	%pad.beam.setTransform(%pad.getPosition() SPC %rot);
//}

function TelePadDeployableImage::onDeploy(%item,%plyr,%slot) {
	%className = "StaticShape";

	%item.surfacePt = vectorAdd(%item.surfacePt,vectorScale(%item.surfaceNrm,0.4));

	%playerVector = vectorNormalize(getWord(%plyr.getEyeVector(),1) SPC -1 * getWord(%plyr.getEyeVector(),0) SPC "0");
	%item.surfaceNrm2 = %playerVector;

	if (vAbs(floorVec(%item.surfaceNrm,100)) $= "0 0 1")
		%item.surfaceNrm2 = vectorScale(%playerVector,-1);
	else
		%item.surfaceNrm2 = vectorNormalize(vectorCross(%item.surfaceNrm,"0 0 1"));

	%rot = fullRot(vectorScale(%item.surfaceNrm,-1),%item.surfaceNrm2);

	%deplObj = new (%className)() {
		dataBlock = TelePadDeployedBase;
		scale = "1 1 1";
		deployed = true;
		teleMode = %plyr.expertSet;
	};

	// set orientation
	%deplObj.setTransform(%item.surfacePt SPC %rot);

	// set team, owner, and handle
	%deplObj.team = %plyr.client.team;
	%deplObj.setOwner(%plyr);

	// set power frequency
	%deplObj.powerFreq = %plyr.powerFreq;

	// set the sensor group if it needs one
	if (%deplObj.getTarget() != -1)
		setTargetSensorGroup(%deplObj.getTarget(),%plyr.client.team);

	// set frequency
	%frequency = %plyr.packSet;
	if (!%frequency)
		%frequency = 1;
	%deplObj.frequency = %frequency;
	setTargetName(%deplObj.target,addTaggedString("Frequency" SPC %frequency));

	// place the deployable in the MissionCleanup/Deployables group (AI reasons)
	addToDeployGroup(%deplObj);

	//let the AI know as well...
	AIDeployObject(%plyr.client,%deplObj);

	// play the deploy sound
	serverPlay3D(%item.deploySound,%deplObj.getTransform());

	// increment the team count for this deployed object
	$TeamDeployedCount[%plyr.team,%item.item]++;

	addDSurface(%item.surface,%deplObj);

	// Power object
	checkPowerObject(%deplObj);

	teleresethack(%deplObj);

	return %deplObj;
}

function TelePadDeployableImage::onMount(%data,%obj,%node) {
	%obj.hasTele = true; // set for telecheck
	%obj.packSet = 1;
	%obj.expertSet = 0;
	displayPowerFreq(%obj);
}

function TelePadDeployableImage::onUnmount(%data,%obj,%node) {
	%obj.hasTele = "";
	%obj.packSet = 0;
	%obj.expertSet = 0;
}
