$Host::NuclearWeapons = 1; //Default On
$nuke::quietlaunch = 0;
//////////////////////////////
//  O.L.B                  ///
// By: Phantom139          ///
//////////////////////////////
datablock EffectProfile(OLBBoomEffect)
{
   effectname = "Weapons/OLB_Explosion";
   minDistance = 5.0;
   maxDistance = 250.0;
};

datablock AudioProfile(OLBExplosionSound)
{
   filename    = "fx/vehicles/bomber_bomb_reload.wav";
   description = AudioBIGExplosion3d;
   preload = true;
   effect = OLBBoomEffect;
};

datablock ParticleData(OLBParticle) {
	dragCoeffiecient     = 0.0;
	gravityCoefficient   = 0;
	inheritedVelFactor   = 0.0;

	lifetimeMS           = 2000;
	lifetimeVarianceMS   = 0;

	textureName          = "particleTest";

	useInvAlpha = false;
	spinRandomMin = -160.0;
	spinRandomMax = 160.0;

    textureName  = "flarebase";

	colors[0]     = "1 0 0";
	colors[1]     = "1 0 0";
	colors[2]     = "1 0 0";
	colors[3]     = "1 0 0";
	sizes[0]      = 10;
	sizes[1]      = 20;
	sizes[2]      = 30;
    sizes[3]      = 30;
	times[0]      = 0.0;
	times[1]      = 0.01;
	times[2]      = 0.02;
    times[3]      = 1;
};

datablock ParticleEmitterData(OLBEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;

   ejectionVelocity = 0;
   velocityVariance = 0;
   ejectionOffset   = 0;
   thetaMin         = 0;
   thetaMax         = 0;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   spinRandomMin   = "200";
   spinRandomMax   = "-200";
   overrideAdvances = false;
   particles = "OLBParticle";
};

datablock ShockwaveData(OLBExplosionShockwave)
{
   width = 6.0;
   numSegments = 32;
   numVertSegments = 6;
   velocity = 1;
   acceleration = 400;
   lifetimeMS = 1500;
   height = 10.0;
   verticalCurve = 0.5;
   is2D = false;

   texture[0] = "special/shockwave4";
   texture[1] = "special/gradient";
   texWrap = 6.0;

   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;

   colors[0] = "0.4 1.0 0.4 0.50";
   colors[1] = "0.4 1.0 0.4 0.25";
   colors[2] = "0.4 1.0 0.4 0.0";

   mapToTerrain = true;
   orientToNormal = false;
   renderBottom = false;
};

datablock ExplosionData(OLBExplosion)
{
   soundProfile   = OLBExplosionSound;

   shockwave = OLBExplosionShockwave;
   shockwaveOnTerrain = false;

   explosionShape = "effect_plasma_explosion.dts";
   faceViewer     = true;
   delayMS = 160;

   offset = 0;

   playSpeed = 0.45;

   sizes  = "40 60 40";

   shakeCamera = true;
   camShakeFreq = "2 2 0";
   camShakeAmp = "20.0 20.0 0.0";
   camShakeDuration = 1.0;
   camShakeRadius = 1000.0;

};

datablock LinearFlareProjectileData(OLBLaser)
{
   projectileShapeName = "plasmabolt.dts";
   scale               = "0.5 0.5 0.5";
   faceViewer          = true;
   directDamage        = 1.0; //die.
   hasDamageRadius     = true;
   indirectDamage      = 0.4;
   damageRadius        = 20;
   kickBackStrength    = 150.0;
   radiusDamageType    = $DamageType::Plasma; //Cause Ze Burn

   explosion           = "OLBExplosion";
   splash              = "";
   baseEmitter         = OLBEmitter;
   dryVelocity       = 1000.0;
   wetVelocity       = 1000.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 17000;
   lifetimeMS        = 17000;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 0;

   activateDelayMS = -1;

   size[0]           = 0.01;
   size[1]           = 0.01;
   size[2]           = 0.01;

   numFlares         = 1;
   flareColor        = "1 0 0";
   flareModTexture   = "special/stationglow";//"special/sniper00";//"special/stationglow";//"flaremod";
   flareBaseTexture  = "special/lightFalloffMono";//"flarebase";

   hasLight    = false;
   lightRadius = 1.0;
   lightColor  = "1 0 1";

};

function OrbitalLaserBombardment(%position) {
   %mainUpPos = vectoradd(%position, "0 0 2000");// main pos
   for(%i=0;%i<24;%i++) {
   %mainUpPos = vectoradd(%mainUpPos, "0 0 2000");   //increment by 300 each time
   %final = vectoradd(%mainUpPos,GetRandomPosition(30,1));
      %Shell1 = new LinearFlareProjectile()
      {
           dataBlock        = OLBLaser;
           initialPosition  = %final;
           initialDirection = "0 0 -5";   // this will hit first
      };
   }
}

//////////////////////////////
//  Artillery Caller       ///
// By: Phantom139          ///
//////////////////////////////

datablock GrenadeProjectileData(ArtilleryShell)
{
   projectileShapeName = "grenade_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 4.25;
   damageRadius        = 25.0;
   radiusDamageType    = $DamageType::Artillery;
   kickBackStrength    = 3000;

   explosion           = "artillerybarrelexplosion";
   velInheritFactor    = 0.0;
   splash              = GrenadeSplash;

   baseEmitter         = GrenadeSmokeEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;

   grenadeElasticity = 0.25;
   grenadeFriction   = 0.3;
   armingDelayMS     = 500;
   gravityMod        = 0.8;
   muzzleVelocity    = 65.0;
   drag              = 0.1;

   sound			 = MortarTurretProjectileSound;

   hasLight    = true;
   lightRadius = 3;
   lightColor  = "0.05 0.2 0.05";
};

//thanks to The_Force for help with these 2 functions
function ArtilleryBarrage(%pos)
{
   %mainUpPos = vectoradd(%pos, "0 0 500");// start shells at 500M
   schedule(1 * 100, 0, StartShells, %mainUpPos);
}

function StartShells(%pos)
{
   %mainUpPos = vectoradd(%pos, "0 0 500");// main pos
   %mainUpPos2 = vectoradd(%pos, "30 20 650");
   %mainUpPos3 = vectoradd(%pos, "-30 20 800");
   %mainUpPos4 = vectoradd(%pos, "-30 -20 950");
   %mainUpPos5 = vectoradd(%pos, "0 0 1050");
   %mainUpPos6 = vectoradd(%pos, "30 20 1200");
   %mainUpPos7 = vectoradd(%pos, "-30 20 1350");
   %mainUpPos8 = vectoradd(%pos, "-30 -20 1500");

   %Shell1 = new GrenadeProjectile()
   {
        dataBlock        = ArtilleryShell;
        initialPosition  = %mainUpPos;
        initialDirection = "0 0 -5";   // this will hit first
   };
   MissionCleanup.add(%Shell1);
   %Shell2 = new GrenadeProjectile()
   {
        dataBlock        = ArtilleryShell;
        initialPosition  = %mainUpPos2;
        initialDirection = "0 0 -5";
   };
   MissionCleanup.add(%Shell2);
   %Shell3 = new GrenadeProjectile()
   {
        dataBlock        = ArtilleryShell;
        initialPosition  = %mainUpPos3;
        initialDirection = "0 0 -5";
   };
   MissionCleanup.add(%Shell3);
   %Shell4 = new GrenadeProjectile()
   {
        dataBlock        = ArtilleryShell;
        initialPosition  = %mainUpPos4;
        initialDirection = "0 0 -5";
   };
   MissionCleanup.add(%Shell4);
   %Shell5 = new GrenadeProjectile()
   {
        dataBlock        = ArtilleryShell;
        initialPosition  = %mainUpPos5;
        initialDirection = "0 0 -5";   // this will hit first
   };
   MissionCleanup.add(%Shell5);
   %Shell6 = new GrenadeProjectile()
   {
        dataBlock        = ArtilleryShell;
        initialPosition  = %mainUpPos6;
        initialDirection = "0 0 -5";
   };
   MissionCleanup.add(%Shell6);
   %Shell7 = new GrenadeProjectile()
   {
        dataBlock        = ArtilleryShell;
        initialPosition  = %mainUpPos7;
        initialDirection = "0 0 -5";
   };
   MissionCleanup.add(%Shell7);
   %Shell8 = new GrenadeProjectile()
   {
        dataBlock        = ArtilleryShell;
        initialPosition  = %mainUpPos8;
        initialDirection = "0 0 -5";
   };
   MissionCleanup.add(%Shell8);
}

function barrage2(%position) {
   %mainUpPos = vectoradd(%position, "0 0 400");// main pos
   for(%i=0;%i<16;%i++) {
   %mainUpPos = vectoradd(%mainUpPos, "0 0 100");   //increment by 100 each time
   %final = vectoradd(%mainUpPos,GetRandomPosition(30,1));
   %Shell1 = new GrenadeProjectile()
   {
        dataBlock        = ArtilleryShell;
        initialPosition  = %final;
        initialDirection = "0 0 -5";   // this will hit first
   };
   }
}

function barrage3(%position) {
   %mainUpPos = vectoradd(%position, "0 0 400");// main pos
   for(%i=0;%i<24;%i++) {
   %mainUpPos = vectoradd(%mainUpPos, "0 0 100");   //increment by 100 each time
   %final = vectoradd(%mainUpPos,GetRandomPosition(30,1));
   %Shell1 = new GrenadeProjectile()
   {
        dataBlock        = ArtilleryShell;
        initialPosition  = %final;
        initialDirection = "0 0 -5";   // this will hit first
   };
   }
}

//////////////////////////////
//Nuclear Missile Targeter ///
// By: Phantom139          ///
//////////////////////////////

datablock AudioProfile(NukeTargeterFireSound)
{
   filename    = "fx/vehicles/tank_mortar_fire.wav";
   description = AudioClosest3d;
};

datablock AudioProfile(NukeTargeterReloadSound)
{
   filename    = "fx/vehicles/bomber_turret_activate.wav";
   description = AudioClosest3d;
};
datablock AudioProfile(NukeTargeterSwitchSound)
{
   filename    = "fx/misc/cannonstart.wav";
   description = AudioBIGExplosion3d;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock TargetProjectileData(NukeTargeterTargeterBeam)
{
   directDamage        	= 0.0;
   hasDamageRadius     	= false;
   indirectDamage      	= 0.0;
   damageRadius        	= 0.0;
   velInheritFactor    	= 1.0;

   maxRifleRange       	= 1000;
   beamColor           	= "1 0 0";

   startBeamWidth			= 0.20;
   pulseBeamWidth 	   = 0.15;
   beamFlareAngle 	   = 3.0;
   minFlareSize        	= 0.0;
   maxFlareSize        	= 400.0;
   pulseSpeed          	= 6.0;
   pulseLength         	= 0.150;

   textureName[0]      	= "special/nonlingradient";
   textureName[1]      	= "special/flare";
   textureName[2]      	= "special/pulse";
   textureName[3]      	= "special/expFlare";
   beacon               = true;
};

datablock LinearFlareProjectileData(TargeterShot)
{
   scale               = "0.1 0.1 0.1";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.01;
   damageRadius        = 0.01;
   radiusDamageType    = $DamageType::Plasma;
   kickBackStrength    = 0;

   explosion           = "SniperExplosion";
   splash              = PlasmaSplash;


   dryVelocity       = 5095.0;
   wetVelocity       = -1;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 29000;
   lifetimeMS        = 30000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   //activateDelayMS = 100;
   activateDelayMS = -1;

   size[0]           = 0.2;
   size[1]           = 0.5;
   size[2]           = 0.1;


   numFlares         = 35;
   flareColor        = "0 0 0";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

	sound        = PlasmaProjectileSound;
   fireSound    = PlasmaFireSound;
   wetFireSound = PlasmaFireWetSound;

   hasLight    = false;
};

//--------------------------------------------------------------------------
// Ammo
//--------------------------------------


//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ItemData(Targeter)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_mortar.dts";
   image = TargeterImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a Targeter";

   computeCRC = true;
   emap = true;
};

datablock ShapeBaseImageData(TargeterImage)
{
   className = WeaponImage;
   shapeFile = "weapon_mortar.dts";
   item = Targeter;
   offset = "0 0 0";
   emap = true;
   UsesEnergy = true;

   RankReqName = "Targeting Beacon"; //Called By TWMFuncitons.cs & Weapons.cs
   projectile = TargeterShot;
   projectileType = LinearFlareProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = NukeTargeterSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";
   //stateSound[2] = MortarIdleSound;

   stateName[3] = "Fire";
   stateSequence[3] = "Recoil";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.8;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateSound[3] = NukeTargeterFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 2.0;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
   stateSound[4] = NukeTargeterReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = MortarDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

function TargeterImage::onMount(%data, %obj, %node)
{
   Parent::onMount(%data, %obj, %node);
   %p = new TargetProjectile(){
                        dataBlock        = NukeTargeterTargeterBeam;
                        initialDirection = %obj.getMuzzleVector(%slot);
                        initialPosition  = %obj.getMuzzlePoint(%slot);
                        sourceObject     = %obj;
                        sourceSlot       = %slot;
                        vehicleObject    = %vehicle;
                     };
   MissionCleanup.add(%p);
   %p.setTarget(%obj.team);
   %obj.NukeBeaTargBeam = %p;
   %obj.usingBeaconer = 1;
   displaytargetingstatus(%obj);
   Parent::onMount(%this, %obj, %slot);
}

function TargeterImage::onUnmount(%data, %obj, %node)
{
   if(isObject(%obj.NukeBeaTargBeam))
      %obj.NukeBeaTargBeam.delete();
   %obj.usingBeaconer = 0;
   Parent::onUnmount(%data, %obj, %node);
}

function MissileStormTarget(%pos)
{
   %goPos = vectoradd(%pos, "0 0 500");

   for(%m=0;%m<20;%m++) {
   %mainUpPos = vectoradd(%goPos,getRandomPosition(20,0));
   %timer = %m * 500;
   %timer2 = %m * 1250;
   schedule(%timer2,0,spawnprojectile,AAMissile,SeekerProjectile,%mainUpPos,"0 0 -5");
   schedule(%timer,0,messageAll,'',"~wfx/Bonuses/high-level4-blazing.wav");
   }
   centerPrintAll("Missile Storm Detected!!!!", 2, 2);
}

function startgunship(%pos,%client) {
   %vpos = vectoradd(%pos, "0 -172 504");
      %gunship = new FlyingVehicle()
      {
         dataBlock  = "gunship";
	     position = %vpos;
         respawn    = "0";
         teamBought = %client.team;
         team = %client.team;
      };
   GunshipForwardImpulse(%gunship);
   %gunship.isspawnedAIShip = 1;
   schedule(5000,0,"SpawnGunshipLocator",%gunship,%pos,%client);
}

function SpawnGunshipLocator(%obj,%pos,%client) {
   messageall('MsgAirstrikeConfirmed', "\c4AC-130 Gunner: Gun Ready!");
   %mainUpPos = vectoradd(%pos, "0 0 500");// start shells at 500M
   schedule(11000,0,"flyaway",%obj);
   for(%i=0;%i <= 10;%i++) {
      if(!isobject(%obj)) {
      flyaway(%obj);
      return;
      }
   %timer = %i * 1000;
   schedule(%timer,0,"LaunchACGunshipoperations",%obj,%mainUpPos);
   }
}

function GunshipForwardImpulse(%obj){
   if(!isObject(%obj))
	  return;
   if(vectorLen(%obj.getVelocity()) < 300)
      %obj.applyImpulse(%obj.getPosition(),vectorScale(%obj.getForwardVector(),$Drone::FrdImpulse));
   schedule(100, 0, "DroneForwardImpulse", %obj);
}


function flyaway(%obj) {
if(!isobject(%obj)) {
sendservermessage("AC-130 Pilot: NO... NOOOO.. GOING DOWN!!!");
return;
}
sendservermessage("AC-130 Pilot: Bombardment Complete, Returning to base to refuel and rearm.");
%obj.setfrozenstate(false);
DroneForwardImpulse(%obj);
%obj.schedule(10000, delete);  //delete after ten seconds
}


function LaunchACGunshipoperations(%obj,%pos)
{
      if(!isobject(%obj)) {
      flyaway(%obj);
      return;
      }
      %vector = "0 0 -10";
      %mat = GetRandomPosition(20,1);
      %Fpos = vectoradd(%mat, %pos);
      %Shell1 = new TracerProjectile() {
        dataBlock        = GaussWeaponProjectile;
        initialPosition  = %Fpos;
        initialDirection = %vector;   // this will hit first
        SourceObject     = %obj;
      };
      MissionCleanup.add(%Shell1);
}

//Firing Functioning
function displaytargetingstatus(%obj) {
	if (%obj.TMode == 1)
commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Beaconing Laser : Artillery Strike<spop>", 5, 2);
	else if (%obj.TMode == 2)
commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Beaconing Laser : Missile Storm<spop>", 5, 2);
	else if (%obj.TMode == 3)
commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Beaconing Laser : Orbital Laser Bombardment<spop>", 5, 2);
	else
commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Beaconing Laser : AC-130 Spectre Operations<spop>", 5, 2);
}

function TargeterImage::onFire(%data, %obj, %slot) {    //34 AC, 46 MS, 47 ART, 48 NUKE
   if(%obj.TMode == 0) {
      %p = Parent::onFire(%data,%obj,%slot);
   }
   else if(%obj.TMode == 1) {
      if($Host::RankSystem && $Rank::XP[%obj.client.GUID] < $TWM::ARTRequirement["TBeac(Artillery)"]) {
         commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Your Rank Is Too Low To Use This Weapon \n You need "@$TWM::ARTRequirement["TBeac(Artillery)"]@" EXP<spop>", 5, 2);
         return;
      }
      else {
         %p = Parent::onFire(%data,%obj,%slot);
      }
   }
   else if(%obj.TMode == 2) {
      if($Host::RankSystem && $Rank::XP[%obj.client.GUID] < $TWM::ARTRequirement["TBeac(Missiles)"]) {
         commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Your Rank Is Too Low To Use This Weapon \n You need "@$TWM::ARTRequirement["TBeac(Missiles)"]@" EXP<spop>", 5, 2);
         return;
      }
      else {
         %p = Parent::onFire(%data,%obj,%slot);
      }
   }
   else if(%obj.TMode == 3) {
      if($Host::RankSystem && $Rank::XP[%obj.client.GUID] < $TWM::ARTRequirement["TBeac(LStorm)"]) {
         commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Your Rank Is Too Low To Use This Weapon \n You need "@$TWM::ARTRequirement["TBeac(LStorm)"]@" EXP<spop>", 5, 2);
         return;
      }
      else {
         %p = Parent::onFire(%data,%obj,%slot);
      }
   }
}

//RECHARGE
function TimerLoop(%team, %type) {
   if($Targeters::Timer[%type,%team] == 0) {
      if(%type $= "Artillery") {
         $Targeters::ArtilleryOnline[%team] = 1;
      }
      else if(%type $= "AC130") {
         $Targeters::AC130Online[%team] = 1;
      }
      else if(%type $= "MissileStorm") {
         $Targeters::MissileStormOnline[%team] = 1;
      }
      else if(%type $= "OrbitalLaserBombardment") {
         $Targeters::OrbitalLaserOnline[%team] = 1;
      }
   MessageTeamReady(%team, %type);
   return;
   }
   else {
   $Targeters::Timer[%type,%team]--;
   schedule(1000,0,"TimerLoop",%team, %type);
   }
}

function OpenAllTeamsArtillery() {
// <- EVIL
   echo("All Teams Open On T. Beacon");
   for(%i = 0; %i < 32; %i++) {
      $Targeters::Timer["Artillery",%i] = 1;
      $Targeters::Timer["MissileStorm",%i] = 1;
      $Targeters::Timer["OrbitalLaserBombardment",%i] = 1;
      $Targeters::Timer["AC130",%i] = 1;
      schedule(1000,0,"TimerLoop",%i, "Artillery");
      schedule(1000,0,"TimerLoop",%i, "MissileStorm");
      schedule(1000,0,"TimerLoop",%i, "OrbitalLaserBombardment");
      schedule(1000,0,"TimerLoop",%i, "AC130");
   }
}

function MessageTeamReady(%team, %type) {
    %count = ClientGroup.getCount();
    for(%i = 0; %i < %count; %i++) {
       %cl = ClientGroup.getObject(%i);
       if(%cl.team == %team) {
          if(%type $= "Artillery") {
             BottomPrint(%cl,"Artillery Online \n Awaiting Target Location",3,4);
          }
          else if(%type $= "AC130") {
             BottomPrint(%cl,"AC-130 In The Sky \n Coordinate Attack Location",3,4);
          }
          else if(%type $= "MissileStorm") {
             BottomPrint(%cl,"Missile Storm Silo Reloaded \n Send Target Coordinates",3,4);
          }
          else if(%type $= "OrbitalLaserBombardment") {
             BottomPrint(%cl,"Orbital Laser Satelite Recharged and Online \n Specify Target Location",3,4);
          }
       }
    }
}
//


function TargeterShot::onExplode(%data, %proj, %pos, %mod)
{
    %cl = %proj.sourceObject.client;
    if(%proj.sourceObject.TMode == 1)     //Artillery
    {
       if($Targeters::ArtilleryOnline[%cl.team]) {
          if(!$Buying::Art2[%cl.GUID] && !$Buying::Art3[%cl.GUID]) {
          ArtilleryBarrage(%pos);
          }
          else if($Buying::Art2[%cl.GUID] && !$Buying::Art3[%cl.GUID]) {
          barrage2(%pos);
          }
          else if($Buying::Art2[%cl.GUID] && $Buying::Art3[%cl.GUID]) {
          barrage3(%pos);
          }
          $Targeters::ArtilleryOnline[%cl.team] = 0;
          $Targeters::Timer["Artillery",%cl.team] = 180;
          schedule(1000,0,"timerLoop",%cl.team,"Artillery");
       }
       else {
          %mins = MFloor($Targeters::Timer["Artillery",%cl.team] / 60);
          %secs = $Targeters::Timer["Artillery",%cl.team] % 60;
          BottomPrint(%cl,"Artillery Unavailable \n Please wait "@%mins@" Minutes and "@%secs@" Seconds",3,4);
       }
    }
    else if(%proj.sourceObject.TMode == 2)  //Missile Storm
    {
       if($Targeters::MissileStormOnline[%cl.team]) {
          MissileStormTarget(%pos);
          $Targeters::MissileStormOnline[%cl.team] = 0;
          $Targeters::Timer["MissileStorm",%cl.team] = 120;
          schedule(1000,0,"timerLoop",%cl.team,"MissileStorm");
       }
       else {
          %mins = MFloor($Targeters::Timer["MissileStorm",%cl.team] / 60);
          %secs = $Targeters::Timer["MissileStorm",%cl.team] % 60;
          BottomPrint(%cl,"Our Missile Storm Silo Is Reloading \n Please wait "@%mins@" Minutes and "@%secs@" Seconds",3,4);
       }
    }
    else if(%proj.sourceObject.TMode == 3)  //Orbital Laser Bombardment
    {
       if($Targeters::OrbitalLaserOnline[%cl.team]) {
          OrbitalLaserBombardment(%pos);
          $Targeters::OrbitalLaserOnline[%cl.team] = 0;
          $Targeters::Timer["OrbitalLaserBombardment",%cl.team] = 270;
          schedule(1000,0,"timerLoop",%cl.team,"OrbitalLaserBombardment");
       }
       else {
          %mins = MFloor($Targeters::Timer["OrbitalLaserBombardment",%cl.team] / 60);
          %secs = $Targeters::Timer["OrbitalLaserBombardment",%cl.team] % 60;
          BottomPrint(%cl,"Orbital Laser Satelite Is Offline \n Please wait "@%mins@" Minutes and "@%secs@" Seconds",3,4);
       }
    }
    else                                   //Spectre Gunship
    {
       if($Targeters::AC130Online[%cl.team]) {
          schedule(3000,0,"startgunship",%pos,%proj.sourceObject.client);
          messageall('MsgAirstrikeConfirmed', "\c4AC-130 Pilot: Target Confirmed, Prepare for airstrike.");
          $Targeters::AC130Online[%cl.team] = 0;
          $Targeters::Timer["AC130",%cl.team] = 150;
          schedule(1000,0,"timerLoop",%cl.team,"AC130");
       }
       else {
          %mins = MFloor($Targeters::Timer["AC130",%cl.team] / 60);
          %secs = $Targeters::Timer["AC130",%cl.team] % 60;
          BottomPrint(%cl,"Our AC-130 Strike is Unavailable \n Please wait "@%mins@" Minutes and "@%secs@" Seconds",3,4);
       }
    }
}
