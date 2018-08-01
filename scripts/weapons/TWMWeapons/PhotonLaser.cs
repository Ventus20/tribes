datablock AudioProfile(PlaserSwitchSound)
{
   filename    = "fx/weapons/mortar_reload.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(PlaserFireSound)
{
   filename    = "fx/weapons/plasma_rifle_projectile_die.wav";
   description = AudioClose3d;
   preload = true;
   effect = SniperRifleFireEffect;
};

datablock ParticleData(ChargingPlaserParticleNew)    //A New Cool Looking Emmiter
{
   dragCoefficient      = 4;
   gravityCoefficient   = 0.3;
   inheritedVelFactor   = 0.7;
   constantAcceleration = 4.8;
   lifetimeMS           = 1200;
   lifetimeVarianceMS   = 550;
   textureName          = "special/crescent3";
   useInvAlpha          =  false;
   colors[0]     = "1 0.1 0.1 1.0";
   colors[1]     = "0.9 0.1 0.1 1.0";
   colors[2]     = "0.9 0.1 0.1";
   sizes[0]      = 1.001;
   sizes[1]      = 1.001;
   sizes[2]      = 1.001;
   times[0]      = 0.0;
   times[1]      = 0.2;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(PLaserChargeEmitter)
{
   ejectionPeriodMS = 3;
   periodVarianceMS = 1;

   ejectionVelocity = 3.7;  // A little oomph at the back end
   velocityVariance = 0.0;
   ejectionoffset = 2;
   thetaMin         = 0.0;
   thetaMax         = 180.0;
   phiReferenceVel = "0";
   phiVariance = "360";
   particles = "ChargingPlaserParticleNew";
};

datablock SniperProjectileData(PhotonBeam2)
{
   directDamage        = 3.0;   //boom
   hasDamageRadius     = true;
   indirectDamage      = 4.0;
   damageRadius        = 10.0;
   velInheritFactor    = 0.0;
   kickBackStrength    = 0;
   sound 				  = SniperRifleProjectileSound;
   explosion           = "BlasterExplosion";
   splash              = SniperSplash;
   directDamageType    = $DamageType::PhotonLaser;

   maxRifleRange       = 1000;
   rifleHeadMultiplier = 1.3;
   beamColor           = "1 0 0";
   fadeTime            = 0.9;

   startBeamWidth		  = 0.2;
   endBeamWidth 	     = 0.2;
   pulseBeamWidth 	  = 0.15;
   beamFlareAngle 	  = 3.0;
   minFlareSize        = 0.0;
   maxFlareSize        = 400.0;
   pulseSpeed          = 90.0;
   pulseLength         = 0.150;

   lightRadius         = 1.0;
   lightColor          = "0 1 0";

   useInvAlpha =  false;
   textureName[0]      = "special/flare";
   textureName[1]      = "special/nonlingradient";
   textureName[2]      = "special/shieldenvmap";
   textureName[3]      = "special/shieldenvmap";
   textureName[4]      = "special/shieldenvmap";
   textureName[5]      = "special/shieldenvmap";
   textureName[6]      = "special/shieldenvmap";
   textureName[7]      = "special/shieldenvmap";
   textureName[8]      = "special/shieldenvmap";
   textureName[9]      = "special/shieldenvmap";
   textureName[10]     = "special/shieldenvmap";
   textureName[11]     = "special/shieldenvmap";
};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ItemData(PhotonLaser)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_plasma.dts";
   image = PhotonLaserImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a Photon Laser";
};

datablock ShapeBaseImageData(PhotonLaserImage)
{
   className = WeaponImage;
   shapeFile = "weapon_plasma.dts";
   item = PhotonLaser;
   offset = "0 0 0";
   armThread = lookms;
   emap = true;

   usesEnergy = true; //wow
   fireEnergy = 10;
   minEnergy = 10;

   RankReqName = "RTM-85C Photon Laser"; //Called By TWMFuncitons.cs & Weapons.cs
   projectile = PhotonBeam2;
   projectileType = SniperProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = PlaserSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Charge";

   stateName[3] = "Charge";
   stateTransitionOnNoAmmo[3] = "NoAmmo";
   stateTransitionOnTimeout[3] = "Charge";
   stateTimeoutValue[3] = 0.1;
   stateScript[3] = "onCharge";
   stateTransitionOnTriggerUp[3] = "CheckWet";

   stateName[4] = "Fire";
   stateTransitionOnTimeout[4] = "Reload";
   stateTimeoutValue[4] = 0.1;
   stateFire[4] = true;
   stateRecoil[4] = LightRecoil;
   stateAllowImageChange[4] = false;
   stateScript[4] = "onFire";
   stateSound[4] = PlaserFireSound;
   
   stateName[5] = "Reload";
   stateTransitionOnNoAmmo[5] = "NoAmmo";
   stateTransitionOnTimeout[5] = "Ready";
   stateAllowImageChange[5] = false;
   stateSequence[5] = "Reload";

   stateName[6] = "NoAmmo";
   stateTransitionOnAmmo[6] = "Reload";
   stateSequence[6] = "NoAmmo";
   stateTransitionOnTriggerDown[6] = "DryFire";

   stateName[7] = "DryFire";
   stateTimeoutValue[7] = 0.3;
   stateSound[7] = BlasterDryFireSound;
   stateTransitionOnTimeout[7] = "Ready";

   stateName[8]       = "WetFire";
   stateSound[8]      = PlasmaCannonFireWetSound;
   stateTimeoutValue[8]        = 1.5;
   stateTransitionOnTimeout[8] = "Ready";

   stateName[9]               = "CheckWet";
   stateTransitionOnWet[9]    = "WetFire";
   stateTransitionOnNotWet[9] = "Fire";
};

///IMAGES
datablock ShapeBaseImageData(PhotonLaserImage2) : PhotonLaser
{
    shapeFile = "ammo_grenade.dts";
    offset = "0.04 0.3 0.08";
    rotation = "0 0 0 0";

};

datablock ShapeBaseImageData(PhotonLaserImage3) : PhotonLaser
{
    shapeFile = "weapon_mortar.dts";
    offset = "-0.03 0 0";
    rotation = "0 0 0 0";

};

datablock ShapeBaseImageData(PhotonLaserImage4) : PhotonLaser
{
    shapeFile = "weapon_sniper.dts";
    offset = "0.03 0 -0.04";
    rotation = "0 0 0 0";

};

function PhotonLaserImage::onmount(%this, %obj, %slot)
{
   Parent::onMount(%this,%obj,%slot);

   %obj.cannonfire = 0;
   %obj.cannoncount = 2;

   %obj.mountImage(PhotonLaserImage2, 4);
   %obj.mountImage(PhotonLaserImage3, 5);
   %obj.mountImage(PhotonLaserImage4, 6);
}

function PhotonLaserImage::onUnmount(%this, %obj, %slot)
{
   Parent::onUnMount(%this,%obj,%slot);

   %obj.cannonfire = 0;
   %obj.cannoncount = 2;

  %obj.unmountImage(4);
  %obj.unmountImage(5);
  %obj.unmountImage(6);
}

function PhotonLaserImage::onFire(%data, %obj, %slot) {
if($Host::RankSystem == 1 && $Rank::XP[%obj.client.ranknum] < $TWM::WeaponRequirement["PhotonLaser"] && !%obj.client.isaicontrolled()) {
   commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Your Rank Is Too Low To Use This Weapon \n You need "@$TWM::WeaponRequirement["PhotonLaser"]@" EXP<spop>", 5, 2);
   }
      else if(!$Host::SniperRifles) {
      commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Sniper Weapons Are Disabled<spop>", 5, 2);
      return;
      }
      else {
         if(%obj.cannonFire < 99) {
         clearBottomPrint(%obj.client);
         commandToClient(%obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Photon Energy Charge too Low<spop>", 2, 2);
         %obj.cannonfire = 0;
         return;
         }
         else {
            FireDalaser(%data, %obj, %slot);
         }
      }
}

function PhotonLaserImage::onCharge(%data, %obj, %slot) {
   %c = createEmitter(%obj.getMuzzlePoint(0),PLaserChargeEmitter,"0 0 0");      //Rotate it
   MissionCleanup.add(%c);
   schedule(1000,0,"killit",%c);

   if (%obj.cannonfire == 0)
      %obj.cannonfire = 2;
   else
      %obj.cannonfire += 5;

   if (%obj.cannoncount $= "")
      %obj.cannoncount = 2;
   %obj.cannoncount += 1;
   if (%obj.cannoncount > 10)
      %obj.cannoncount = 1;

   if ((%obj.cannonfire > 10 && %obj.cannonfire <= 20) && (%obj.cannoncount == 1)) {
   commandToClient(%obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:33FF00> = <color:FF0000>= = = = = = = = = <spop>", 2, 2);
   }
   else if ((%obj.cannonfire > 20 && %obj.cannonfire <= 30) && (%obj.cannoncount == 1)) {
   commandToClient(%obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:33FF00> = = <color:FF0000>= = = = = = = = <spop>", 2, 2);
   }
   else if ((%obj.cannonfire > 30 && %obj.cannonfire <= 40) && (%obj.cannoncount == 1)) {
   commandToClient(%obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:33FF00> = = = <color:FF0000>= = = = = = = <spop>", 2, 2);
   }
   else if ((%obj.cannonfire > 40 && %obj.cannonfire <= 50) && (%obj.cannoncount == 1)) {
   commandToClient(%obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:33FF00> = = = = <color:FF0000>= = = = = = <spop>", 2, 2);
   }
   else if ((%obj.cannonfire > 50 && %obj.cannonfire <= 60) && (%obj.cannoncount == 1)) {
   commandToClient(%obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:33FF00> = = = = = <color:FF0000>= = = = = <spop>", 2, 2);
   }
   else if ((%obj.cannonfire > 60 && %obj.cannonfire <= 70) && (%obj.cannoncount == 1)) {
   commandToClient(%obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:33FF00> = = = = = = <color:FF0000>= = = = <spop>", 2, 2);
   }
   else if ((%obj.cannonfire > 70 && %obj.cannonfire <= 80) && (%obj.cannoncount == 1)) {
   commandToClient(%obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:33FF00> = = = = = = = <color:FF0000>= = = <spop>", 2, 2);
   }
   else if ((%obj.cannonfire > 80 && %obj.cannonfire <= 90) && (%obj.cannoncount == 1)) {
   commandToClient(%obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:33FF00> = = = = = = = = <color:FF0000>= = <spop>", 2, 2);
   }
   else if ((%obj.cannonfire > 90 && %obj.cannonfire <= 100) && (%obj.cannoncount == 1)) {
   commandToClient(%obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:33FF00> = = = = = = = = = <color:FF0000>= <spop>", 2, 2);
   }
   else if (%obj.cannoncount == 1) {
   commandToClient(%obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:33FF00> = = =R=E=A=D=Y= = = <spop>", 2, 2);
   }
}


function FireDalaser(%data, %obj, %slot) {
   %obj.cannonfire = 0;
   %obj.cannoncount = 2;
    %vector = %obj.getMuzzleVector(%slot);
    %mp = %obj.getMuzzlePoint(%slot);
    %p = new (SniperProjectile)() {
    dataBlock        = PhotonBeam2;
    initialDirection = %vector;
    initialPosition  = %mp;
    sourceObject     = %obj;
    damageFactor     = 1;
    sourceSlot       = %slot;
};
MissionCleanup.add(%p);
%p.setEnergyPercentage(10000);
}

// KNOWN TO CAUSE UEs
function PhotonBeam2::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal) {
   %FireCl = %projectile.SourceObject.Client;
   Parent::OnCollision(%data, %projectile, %targetObject, %modifier, %position, %normal);
   if(%targetObject.getDataBlock().getClassName() $= "PlayerData") {
      if(%targetObject.iszombie && %targetObject.rapiershield) {
         %targetObject.rapiershield = 0;
         schedule(7500,0,"ResetRaamField",%targetObject);
         %FireCl.ShieldBusts++;
         if(%FireCl.ShieldBusts > 4) {
         awardClient(%FireCl,24);
         }
      }
   }
}

