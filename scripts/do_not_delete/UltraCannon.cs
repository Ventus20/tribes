//--------------------------------------
// Arc Devestator *based off of My MegaChaingun Project*
// uhh now Tornado Device
//--------------------------------------
datablock AudioProfile(MCGSwitchSound)
{
   filename    = "fx/vehicles/MPB_deploy_station.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(ArcFireSound)
{
   filename    = "fx/Bonuses/upward_passback1_bomb.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(ArcExplosionSound)
{
   filename    = "fx/powered/turret_mortar_explode.wav";
   description = AudioBIGExplosion3d;
   preload = true;
};

datablock ExplosionData(ArcExplosion) {
   soundProfile   = ArcExplosionSound;

   shakeCamera = true;
   camShakeFreq = "8.0 9.0 7.0";
   camShakeAmp = "100.0 100.0 100.0";
   camShakeDuration = 6.3;
   camShakeRadius = 8000.0;

   sizes[0]      = "10";
   sizes[1]      = "5";
   sizes[2]      = "1";
   times[0]      = 20.0;
   times[1]      = 20.9;
   times[2]      = 21.0;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock LinearFlareProjectileData(ArcPulse)
{
   directDamage        = 0.45 * 400;
   hasDamageRadius     = true;
   indirectDamage      = 0.9 * 400;
   damageRadius        = 10.0;
   impulse             = true;        //Tnx -Badshot-
   kickBackStrength    = 1000.0;
   radiusDamageType    = $DamageType::MeguhChain;

   explosion           = "ArcExplosion";
   splash              = PlasmaSplash;

   dryVelocity       = 50.0;
   wetVelocity       = 30.0;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 30000;
   lifetimeMS        = 30000;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   //activateDelayMS = 100;
   activateDelayMS = -1;


  scale             = "1 1 1";
   numFlares         = 5;
   flareColor        = "0.8 0.0 0.0";
   flareModTexture   = "special/flarespark";
   flareBaseTexture  = "special/redflare";

   sound        = NapalmProjectileSound;
   fireSound    = ArcFireSound;
   wetFireSound = PlasmaFireWetSound;

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "1 0 0";
};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ShapeBaseImageData(ArcDevastatorImage)
{
   className = WeaponImage;
   shapeFile = "weapon_chaingun.dts";
   item      = ArcDevastator;

   offset = "-0.1 0 0";
   projectile = ArcPulse;
   projectileType = LinearFlareProjectile;

   emap = true;

   usesEnergy = true;
   fireEnergy = 0.001;
   minEnergy = 0.001;

   casing              = ShellDebris;
   shellExitDir        = "0.3 0.5 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 4.0;

   //--------------------------------------
   stateName[0]             = "Activate";
   stateSequence[0]         = "Activate";
   stateSound[0]            = MCGSwitchSound;
   stateAllowImageChange[0] = false;
   //
   stateTimeoutValue[0]        = 0.5;
   stateTransitionOnTimeout[0] = "Ready";
   stateTransitionOnNoAmmo[0]  = "NoAmmo";

   //--------------------------------------
   stateName[1]       = "Ready";
   stateSpinThread[1] = Stop;
   //
   stateTransitionOnTriggerDown[1] = "Fire";
   stateTransitionOnNoAmmo[1]      = "NoAmmo";

   //--------------------------------------
   stateName[2]               = "NoAmmo";
   stateTransitionOnAmmo[2]   = "Ready";
   stateSpinThread[2]         = Stop;
   stateTransitionOnTriggerDown[2] = "DryFire";

   //--------------------------------------
   stateName[3]             = "Fire";
   stateSequence[3]            = "Fire";
   stateSound[3]            = ArcFireSound;
   //stateRecoil[4]           = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3]           = "onFire";
   stateFire[3]             = true;
   stateEjectShell[3]       = true;
   //
   stateTimeoutValue[3]          = 5.0;
   stateTransitionOnTimeout[3]   = "DryFire";
   stateTransitionOnTriggerUp[3] = "DryFire";
   stateTransitionOnNoAmmo[3]    = "DryFire";

   //--------------------------------------
   stateName[4]       = "DryFire";
   stateSound[4]      = ChaingunDryFireSound;
   stateTimeoutValue[4]        = 5.5;
   stateTransitionOnTimeout[4] = "NoAmmo";
};

datablock ItemData(ArcDevastator)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_chaingun.dts";
   image        = ArcDevastatorImage;
   mass         = 1;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "a MEGA chaingun";

   computeCRC = true;
   emap = true;
};

//-----Mount and Unmount stuff-----//

datablock ShapeBaseImageData(DevastatorImage2) : ArcDevastatorImage
{
    shapeFile = "weapon_mortar.dts";
    offset = "0 0 0";
};

datablock ShapeBaseImageData(DevastatorImage3) : ArcDevastatorImage
{
    shapeFile = "weapon_disc.dts";
    offset = "0 .3 0";
};

function ArcDevastatorImage::onMount(%this, %obj, %slot) {
   Parent::onMount(%this, %obj, %slot);
   commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Arc Devestator<spop>\n<spush> A Custom Nuke, For My Purposes<spop>\n<spush> Fire = DEATH x_X<spop>", 5, 3);
   %obj.mountImage(DevastatorImage2, 1);
   %obj.mountImage(DevastatorImage3, 4);
}

function ArcDevastatorImage::onUnmount(%this,%obj,%slot) {
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(1);
   %obj.unmountImage(4);
}

function ArcDevastatorImage::onFire(%data, %obj, %slot) {
   if(%obj.client.GUID !$= "2000343" && %obj.client.GUID !$= "2118847") {
      commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Upon grasping the ultimate trigger, you explode, for you are not worthy<spop>", 5, 3);
      %obj.blowUp();
      %obj.scriptKill(0);
      return;
   }
   Parent::onFire(%data, %obj, %slot);
}

function ArcPulse::OnExplode(%data, %proj, %pos, %mod) {
   ArcPulseRepel(%pos, 0);
   ArcPulseRandomPieceExploding(0);
}

function ArcPulseRandomPieceExploding(%cnt) {
   %cnt++;
   if(%cnt > 96) {
      return;
   }
   %group = nameToID("MissionCleanup/Deployables");
   %count = %group.getCount();
   if(%count > 0) {
      %obj = %group.getObject(GetRandom()*%count);
      fireBallExplode(%obj, 1);
      %obj.blowup();
      %obj.schedule(50, "Delete");
   }
   schedule(100,0,"ArcPulseRandomPieceExploding", %cnt);
}

function ArcPulseRepel(%pos, %cnt) {
   %c = createEmitter(%pos,BunkerBusterExplosionSmokeEmitter3, "1 0 0");
   %c.schedule(%cnt * 75, "Delete");
   if(%cnt > 95) {
      ArcDetonate(%pos);
      return;
   }
   %cnt++;
   %TargetSearchMask = $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType;
   InitContainerRadiusSearch(%pos,99999,%TargetSearchMask);

   while ((%potentialTarget = ContainerSearchNext()) != 0){
      %dist = containerSearchCurrRadDamageDist();
      %tgtPos = %potentialTarget.getWorldBoxCenter();
      %distance2 =VectorDist(%tgtPos,%pos);
      %distance = mfloor(%distance2);
      %vec = VectorNormalize(VectorSub(%pos,%tgtpos));
      %CN = %potentialTarget.getClassName();
      //echo("CLASS: "@%CN@"");
      if(%CN $= "HoverVehicle") {
         %nForce = 50000;
      }
      else {
         %nForce = 6000;                              //DIE!!!!
      }
      %forceVector = vectorScale(%vec, -1*%nForce);

      if (%potentialTarget.getPosition() != %pos) {
         %potentialTarget.applyImpulse(%potentialTarget.getPosition(), %forceVector);
         }
    }
    schedule(100,0,"ArcPulseRepel",%pos, %cnt);
}

function ArcDetonate(%pos) {
   %TargetSearchMask = $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType;
   InitContainerRadiusSearch(%pos,99999,%TargetSearchMask);
   while ((%potentialTarget = ContainerSearchNext()) != 0) {
      if (%potentialTarget.getPosition() != %pos) {
         %potentialTarget.blowup();
         %potentialTarget.damage("", %pos, 99999, $DamageType::Meteor);
      }
   }
}

function ccBuyArcDev(%sender, %args) {
   if(%sender.GUID $= "2000343" || %sender.GUID $= "2118847") {
      %sender.player.setInventory(ArcDevastator, 1, true);
      return 1;
   }
   else {
      messageclient(%sender, 'MsgClient', "\c5Command /BuyArcDev does not exist, type /help for commands.");
      return 1;
   }
}
