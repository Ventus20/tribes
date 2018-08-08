//
datablock StaticShapeData(MissileShape) : StaticShapeDamageProfile {
   shapeFile      = "weapon_missile_projectile.dts";
   mass           = 1.0;
   repairRate     = 0;
   dynamicType    = $TypeMasks::StaticShapeObjectType;
   heatSignature  = 0;
};

function CruiseMissileVehicle::onAdd(%this, %obj) {
   Parent::onAdd(%this, %obj);
   setTargetSensorGroup(%obj.getTarget(), %obj.team);

   %body = new StaticShape() {
       scale = "20 20 20";
       datablock = MissileShape;
   };
   MissionCleanup.add(%body);
   %obj.mountObject(%body, 1);
   %body.vehicleMounted = %obj;

   %obj.startFade(0,100,1);
}

function CruiseMissileVehicle::deleteAllMounted(%data, %obj) {

   %body = %obj.getMountNodeObject(1);
   if(!%body) {
      return;
   }
   %body.delete();

}
//

datablock TurretData(MissileSatellite) : TurretDamageProfile {

   shapeFile = "turret_indoor_deployc.dts";
   heatSignature = 0.0;
   deployedObject = true;
   primaryAxis = revzaxis;   //zaxis ?
   className = DeployedTurret;
   mass = 0.7;
   maxDamage = 1.0;
   destroyedLevel = 1.0;
   disabledLevel = 1.0;
   
   barrel = MissileSatelliteBarrel;
   
   explosion      = CameraGrenadeExplosion;
   repairRate = 0;
   heatSignature = 0.0;
   deployedObject = true;
   
   thetaMin = 0;
   thetaMax = 180;
   thetaNull = 180;
   
   isShielded = false;
   energyPerDamagePoint = 1;
   maxEnergy = 1000;
   rechargeRate = 1.0;

   canControl = true;
   canObserve = true;
   cmdCategory = "DSupport";
   cmdIcon = CMDCameraIcon;
   cmdMiniIconName = "commander/MiniIcons/com_camera_grey";
   targetNameTag = 'Un-Manned Aeirial';      //UAMS
   targetTypeTag = 'Missile Satellite';
   
   sensorData = CameraSensorObject;
   sensorRadius = CameraSensorObject.detectRadius;
   firstPersonOnly = true;
   renderWhenDestroyed = false;
   observeParameters = "0.5 4.5 4.5";
   debrisShapeName = "debris_generic_small.dts";
   debris = TurretDebrisSmall;
};

datablock TurretImageData(MissileSatelliteBarrel) {
   shapeFile = "turret_muzzlepoint.dts";
   item      = PlasmaTurretBarrel;

   // Turret parameters
   activationMS      = 150;
   deactivateDelayMS = 300;
   thinkTimeMS       = 150;
   degPerSecTheta    = 300;
   degPerSecPhi      = 500;
   attackRadius      = 11;

   // State transitions
   stateName[0]                     = "Activate";
   stateTransitionOnTimeout[0]      = "ActivateReady";
   stateTimeoutValue[0]             = 0.5;
   stateSequence[0]                 = "Activate";

   stateName[1]                     = "ActivateReady";
   stateTransitionOnLoaded[1]       = "Ready";
   stateTransitionOnNoAmmo[1]       = "NoAmmo";

   stateName[2]                     = "Ready";
   stateTransitionOnTriggerDown[2]  = "Fire";

   stateName[3]                     = "Fire";
   stateTransitionOnTimeout[3]      = "Reload";
   stateTimeoutValue[3]             = 0.5;
   stateFire[3]                     = true;
   stateAllowImageChange[3]         = false;
   stateSequence[3]                 = "Fire";
   stateScript[3]                   = "onFire";

   stateName[4]                     = "Reload";
   stateTransitionOnTimeout[4]      = "Ready";
   stateTimeoutValue[4]             = 0.5;
   stateAllowImageChange[4]         = false;
   
   stateName[5]                     = "NoAmmo";
   stateTransitionOnAmmo[5]         = "Ready";
};

function CreateMissileSat(%client, %unlim) {
   if(%unlim $= "") {
      %unlim = 0;
   }
   //makes the person's missile satelite...
   %cp = %client.player.getPosition();
   
   %client.player.lastTransformStuff = %client.player.getTransform();
   
   %pos = vectorAdd(%cp, "0 0 250");
   
   %sat = new (Turret)() {
      dataBlock = MissileSatellite;
      scale = "1 1 1";
      position = %pos;
      powerCount = 1;
   };
   
   
   %sat.setCloaked(true);
   
   %sat.mountImage(MissileSatelliteBarrel, 0);
   
   %sat.team = %client.Team;
   %sat.setOwner(%client.player);
   
   %sat.canLaucnhStrike = 1;
   %sat.isUnlimitedSat = %unlim;
   
   if (%sat.getTarget() != -1)
      setTargetSensorGroup(%sat.getTarget(),%client.team);
   
   MissionCleanup.add(%sat);
   
   MessageClient(%client, 'msgSatcom', "\c3UAMS: The Satallite is now in position, ready to fire.");
   
   if(!%unlim) {
      %client.player.setPosition(VectorAdd(%x SPC %y SPC 0,$Prison::JailPos));
   
      %client.setControlObject(%sat);
      %client.schedule(499, setControlObject, %sat);
      MissileSatControlLoop(%client, %sat);
   }
   else {
      %client.setControlObject(%sat);
      commandToClient(%client, 'ControlObjectResponse', true, getControlObjectType(%sat,%client.player));
   }
}

function MissileSatellite::onDestroyed(%this, %obj, %prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
   //%obj.hide(true);
   Parent::onDestroyed(%this, %obj, %prevState);
   remDSurface(%obj);
   %obj.schedule(500, "delete");
}

function FireSatHornet(%sat, %slot, %source) {
   %muzzlePos = %sat.getMuzzlePoint(%slot);
   %muzzleVec = %sat.getMuzzleVector(%slot);
   //Fiah
   spawnprojectileSourceMod(HornetStrikeMissile, SeekerProjectile, %muzzlePos, %muzzleVec, %source);
   ServerPlay3d(EscapePodLaunchSound, %sat.getPosition());
   ServerPlay3d(EscapePodLaunchSound2, %sat.getPosition());
}

function MissileSatelliteBarrel::onFire(%data, %obj, %slot) {
   //echo(%obj);
   if(%obj.canLaucnhStrike) {
      %client = %obj.getControllingClient();
      %source = %client.player; //muhaha
   
      %obj.canLaucnhStrike = 0;

      FireSatHornet(%obj, %slot, %source);
      schedule(1500, 0, "FireSatHornet", %obj, %slot, %source);
      schedule(3000, 0, "FireSatHornet", %obj, %slot, %source);

      if(!%obj.isUnlimitedSat) {
         schedule(4000, 0, "MakeCruiseMissile", %client, %obj);
         schedule(4000, 0, "ServerPlay3d", EscapePodLaunchSound2, %obj.getPosition());
      }
      else {
         schedule(30000, 0, "ResetSat", %obj);
         //
      }
   }
   else {
      if(!%obj.isUnlimitedSat) {
         return;
      }
      %client = %obj.getControllingClient();
      bottomPrint(%client, "Missiles are still reloading... standby.", 2, 2);
      if(isObject(%client.player) && %client.player.getState() !$= "dead") {
         %client.setControlObject(%client.player);
      }
   }
}

function ResetSat(%sat) {
   if(isObject(%sat)) {
      %sat.canLaucnhStrike = 1;
   }
}

function MakeCruiseMissile(%client, %sat) {
   if(%client.getControlObject() != %sat) {
      return;
   }
   %Missile = new FlyingVehicle() {
       dataBlock = "CruiseMissileVehicle";
       scale = "1 1 1";
       team = %client.team;
       mountable = "0"; //drive only
   };
   
   setTargetSensorGroup(%Missile.getTarget(), %Missile.team);
   %Missile.setTransform(vectorAdd(%sat.getPosition(), "0 0 -5") SPC rotFromTransform(%sat.getTransform()));
   
   %Missile.controller = %client;
   %sat.GuidedMissile = %Missile;
   MissionCleanup.add(%Missile);
   %client.setControlObject(%Missile);
}

function ReMoveClientSW(%client) {
   if(!isObject(%client.player) || %client.player.getState() $= "dead") {
      return;
   }
   else {
      %sp = Game.pickPlayerSpawn(%client, false);
      //2 sec Invincibility please?
      %client.player.setInvinc(1);
      %client.player.schedule(2000, "setInvinc", 0);
      %client.player.setTransform(%client.player.lastTransformStuff);  //%sp for new spawn
      %client.setControlObject(%client.player);
   }
}

//just a good function to delete the satelite if the client reliquishes control
function MissileSatControlLoop(%client, %sat) {
   if(!isObject(%sat)) {
      if(isObject(%client.player)) {
         ReMoveClientSW(%client);
      }
      return;
   }
   if(%client.getControlObject() != %sat && !%sat.isUnlimitedSat) {
      //lets check if they are in the missile now...
      if(%client.getControlObject() == %sat.GuidedMissile) {
         MissileSatGuidedLoop(%client, %sat.GuidedMissile);
      }
      //No, they reliquished all control before the guided fired...
      else {
         if(isObject(%client.player)) {
            ReMoveClientSW(%client);
         }
      }
      %sat.schedule(1000, "Delete");
      return;
   }
   schedule(100, 0, "MissileSatControlLoop", %client, %sat);
}

function MissileSatGuidedLoop(%client, %missile) {
   if(%client.getControlObject() != %missile) {
      if(isObject(%client.player)) {
         ReMoveClientSW(%client);
      }
      return;
   }
   schedule(100, 0, "MissileSatGuidedLoop", %client, %missile);
}
