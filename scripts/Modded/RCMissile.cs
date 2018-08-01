//--------------------------------------
// RC Cruise Launcher
//--------------------------------------

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ItemData(RCMissile)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_missile.dts";
   image = RCMissileImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a missile launcher";

   computeCRC = true;
   emap = true;
};

datablock ShapeBaseImageData(RCMissileImage)
{
   className = WeaponImage;
   shapeFile = "weapon_missile.dts";
   item = RCMissile;
   offset = "0 0 0";
   armThread = lookms;
   emap = true;

   projectile = Bazookashot;    //doesn't matter
   projectileType = GrenadeProjectile;
   
   usesEnergy = true;
//   fireEnergy = 4;
//   minEnergy = 4;

   
   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = MissileSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "CheckWet";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.1;
   stateFire[3] = true;
   stateEmitter[3] = "BazookaFireEffectEmitter";
   stateEmitterNode[3] = "muzzlepoint1";
   stateEmitterTime[3] = 1;
   stateRecoil[3] = HeavyRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateScript[3] = "onFire";
   stateSound[3] = MissileFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 4.0;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
   stateSound[4] = MissileReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = MissileDryFireSound;
   stateTimeoutValue[6]        = 1.0;
   stateTransitionOnTimeout[6] = "NoAmmo";

   stateName[7]               = "CheckWet";
   stateTransitionOnWet[7]    = "WetFire";
   stateTransitionOnNotWet[7] = "Fire";

   stateName[8]       = "WetFire";
   stateSound[8]      = MissileDryFireSound;
   stateTimeoutValue[8]        = 1.0;
   stateTransitionOnTimeout[8] = "Ready";
};

function RCMissileImage::onMount(%this,%obj,%slot) {
   Parent::onMount(%this, %obj, %slot);
commandToClient(%obj.client, 'BottomPrint', "<spush><font:Arial Black:20><color:ff3300>Guided Cruise Missile\n<spush><font:Arial:14><color:ffcc00>Instead of putting yourself in danger, lets put others in danger!!! With this fun weapon.", 3, 3);
}

function RCMissileImage::OnFire(%data, %obj, %slot) {
   %epod = new FlyingVehicle() {
       dataBlock = "EscapePodVehicle";
       scale = "1 1 1";
       team = %obj.team;
       mountable = "0"; //drive only
       selfpower = "1";
   };
   setTargetSensorGroup(%epod.getTarget(),%epod.team);
   %epod.setTransform(vectorAdd(%obj.getPosition(), "0 0 5") SPC rotFromTransform(%Obj.getTransform()));
   %epod.launchedByRC = 1;
   %epod.controllerofRC = %obj.client;
   MissionCleanup.add(%epod);
   %obj.client.setControlObject(%epod);
   ForwardImpulseofRC(%obj, %epod);
   
   %obj.client.RCUnit = %epod;
   echo(""@%obj.client@".RCUnit = "@%epod@"");
   
   %epod.payLoad = 1; //Regular
   DisplayMissileInfo(%epod, %obj.client);
   
}

//this also does the Player Check
function ForwardImpulseofRC(%fireing, %obj) {
   if(%fireing.getState() $= "dead" || !isObject(%fireing)) {
      %obj.damage(0, %obj.position, 99999999, $DamageType::admin);
      return;
   }
   if(%obj.getDamageState() $= "Destroyed" || !IsObject(%obj)) {
      return;
   }
   if(vectorLen(%obj.getVelocity()) < 700)
	%obj.applyImpulse(%obj.getPosition(),vectorScale(%obj.getForwardVector(), 500));
   schedule(100,0,"ForwardImpulseofRC",%fireing, %obj);
}

function DisplayMissileInfo(%RC, %client) {
   if(!isObject(%RC)) {
      return;
   }
   switch(%RC.payLoad) {
      case 1:
         %name = "Cruise Missile";
      case 2:
         %name = "Incindinary Burst";
      case 3:
         %name = "Bunker Storm";
      default:
         %name = "No Blast";
   }
   CommandToClient(%client, 'BottomPrint', "<spush><font:Sui Generis:14>>>>RC Missile<<<<spop>\n<spush><font:Arial:14>PAYLOAD: "@%name@"<spop>\n<spush>Press Mine To Toggle Payload, Grenade To Detonate<spop>", 1, 3 );
   schedule(1000,0, "DisplayMissileInfo", %RC, %client);
}

//TRIGGER
function escapepodvehicle::onTrigger(%data, %obj, %trigger, %state) {
   // data = ScoutFlyer datablock
   // obj = ScoutFlyer object number
   // trigger = 0 for "fire", 1 for "jump", 3 for "thrust"
   // state = 1 for firing, 0 for not firing
   if(%trigger == 0) {

   }
   //RC Only
   else if(%trigger == 4) {
      if(%state) {
         if(%obj.launchedByRC) {
            %obj.damage(0, %obj.position, 99999999, $DamageType::admin);
         }
      }
      return;
   }
   else if(%trigger == 5) {
      if(%obj.launchedByRC) {
         if(%state) {
            if(%obj.payLoad > 2) {
               %obj.payLoad = 0;
            }
            %obj.payLoad++;
         }
      }
      return;
   }
}

