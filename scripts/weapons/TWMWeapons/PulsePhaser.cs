// Pulse Phaser Weapon
datablock AudioProfile(PPWFireSound)
{
   filename    = "fx/powered/turret_indoor_fire.wav";
   description = AudioDefault3d;
   preload = true;
   effect = IBLFireEffect;
};

datablock LinearFlareProjectileData(phaserBolt)
{
   directDamage        = 0.45;
   directDamageType    = $DamageType::Phaser;
   explosion           = "BlasterExplosion";
   kickBackStrength  = 0.0;

   dryVelocity       = 120.0;
   wetVelocity       = 40.0;
   velInheritFactor  = 0.5;
   fizzleTimeMS      = 2000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   numFlares         = 20;
   size              = 0.10;
   flareColor        = "1 1 1";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   sound = BlasterProjectileSound;

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "1 1 1";
};

datablock ShapeBaseImageData(PulsePhaserImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy.dts";
   item = PulsePhaser;
   projectile = phaserBolt;
   projectileType = LinearFlareProjectile;

   RankReqName = "ES-73 Pulse Phaser"; //Called By TWMFuncitons.cs & Weapons.cs
   usesEnergy = true;
   fireEnergy = 4;
   minEnergy = 4;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = BlasterSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.3;
   stateFire[3] = true;
   stateRecoil[3] = NoRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateSound[3] = PPWFireSound;
   stateScript[3] = "onFire";

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateTimeoutValue[6] = 0.3;
   stateSound[6] = BlasterDryFireSound;
   stateTransitionOnTimeout[6] = "Ready";
};

datablock ItemData(PulsePhaser)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_energy.dts";
   image = PulsePhaserImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a Pulse Phaser";
};

datablock ShapeBaseImageData(Phaser2Image) : PulsePhaserImage
{
    shapeFile = "weapon_ELF.dts";
    offset = "0 0.3 0.2";
    rotation = "0 1 0 180";
};

datablock ShapeBaseImageData(Phaser3Image) : PulsePhaserImage
{
    shapeFile = "weapon_ELF.dts";
    offset = "0 .5 0";
};

function PulsePhaserImage::onMount(%this, %obj, %slot)
{
Parent::onMount(%this, %obj, %slot);
%obj.mountImage(Phaser2Image, 5);
%obj.mountImage(Phaser3Image, 6);
}

function PulsePhaserImage::onUnmount(%this,%obj,%slot)
{
Parent::onUnmount(%this, %obj, %slot);
%obj.unmountImage(5);
%obj.unmountImage(6);
}

function ResetReloadPuls(%cl) {
%cl.reloadingPuls = 0;
}

function PulsePhaserImage::onFire(%data,%obj,%slot) {
if(%obj.client.reloadingPuls) {
commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Recharging<spop>", 5, 2);
return;
}
%vector = %obj.getMuzzleVector(%slot);
%mp = %obj.getMuzzlePoint(%slot);
if($Host::RankSystem == 1 && $Rank::XP[%obj.client.ranknum] < $TWM::WeaponRequirement["PulsePhaser"]) {
   commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Your Rank Is Too Low To Use This Weapon \n You need "@$TWM::WeaponRequirement["PulsePhaser"]@" EXP<spop>", 5, 2);
}
else {
   if(%obj.client.TPUon) {
      for(%t=0;%t<3;%t++) {
      %obj.client.reloadingPuls = 1;
      %ttimer = %t * 200;
      schedule(%ttimer,0,spawnprojectile,phaserBolt,LinearFlareProjectile,%mp,%vector,%obj);
      schedule(2000,0,"ResetReloadPuls",%obj.client);
      }
   }
   else if(%obj.client.PSGon) {
      %obj.client.reloadingPuls = 1;
      %PulseSGSpread = 11.0 / 1000.0;
      for (%i=0; %i < 5; %i++)
      {
         %x = (getRandom() - 0.5) * 2 * 3.1415926 * %PulseSGSpread;
         %y = (getRandom() - 0.5) * 2 * 3.1415926 * %PulseSGSpread;
         %z = (getRandom() - 0.5) * 2 * 3.1415926 * %PulseSGSpread;
         %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
         %newvector = MatrixMulVector(%mat, %vector);
         %p = new (%data.projectileType)()
         {
            dataBlock        = %data.projectile;
            initialDirection = %newvector;
            initialPosition  = %mp;
            sourceObject     = %obj;
            damageFactor	 = 1;
            sourceSlot       = %slot;
         };
      }
      schedule(3000,0,"ResetReloadPuls",%obj.client);
   }
   else {
   %p = Parent::OnFire(%data,%obj,%slot);
   }
}
}
