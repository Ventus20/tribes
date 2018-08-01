//pulse phaser chaingun
datablock EffectProfile(PulseCGunFireEffect)
{
   effectname = "weapons/PulseCgun_Fire";
   minDistance = 15.5;
   maxDistance = 20.5;
};

datablock AudioProfile(PPCFireSound)
{
   filename    = "fx/weapons/cg_soft3.wav";
   description = AudioDefault3d;
   preload = true;
   effect = PulseCGunFireEffect;
};

//--------------------------------------------------------------------------
// Ammo
//--------------------------------------

datablock ItemData(PulseChaingunAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some pulse chaingun ammo";

   computeCRC = true;

};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ShapeBaseImageData(PulseChaingunImage)
{
   className = WeaponImage;
   shapeFile = "weapon_chaingun.dts";
   item      = PulseChaingun;
   ammo 	 = PulseChaingunAmmo;
   projectile = phaserBolt;
   projectileType = LinearFlareProjectile;
   emap = true;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   RankReqName = "EX-73 Pulse Chaingun"; //Called By TWMFuncitons.cs & Weapons.cs
   projectileSpread = 2.0 / 1000.0; // z0dd - ZOD, 8/6/02. Was: 8.0 / 1000.0

   //--------------------------------------
   stateName[0]             = "Activate";
   stateSequence[0]         = "Activate";
   stateSound[0]            = ChaingunSwitchSound;
   stateAllowImageChange[0] = false;
   //
   stateTimeoutValue[0]        = 0.5;
   stateTransitionOnTimeout[0] = "Ready";
   stateTransitionOnNoAmmo[0]  = "NoAmmo";

   //--------------------------------------
   stateName[1]       = "Ready";
   stateSpinThread[1] = Stop;
   //
   stateTransitionOnTriggerDown[1] = "Spinup";
   stateTransitionOnNoAmmo[1]      = "NoAmmo";

   //--------------------------------------
   stateName[2]               = "NoAmmo";
   stateTransitionOnAmmo[2]   = "Ready";
   stateSpinThread[2]         = Stop;
   stateTransitionOnTriggerDown[2] = "DryFire";

   //--------------------------------------
   stateName[3]         = "Spinup";
   stateSpinThread[3]   = SpinUp;
//   stateSound[3]        = ChaingunSpinupSound;
   //
   stateTimeoutValue[3]          = 0.5;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   //--------------------------------------
   stateName[4]             = "Fire";
   stateSequence[4]            = "Fire";
   stateSequenceRandomFlash[4] = true;
   stateSpinThread[4]       = FullSpeed;
   stateSound[4]            = PPCFireSound;
   //stateRecoil[4]           = LightRecoil;
   stateAllowImageChange[4] = false;
   stateScript[4]           = "onFire";
   stateFire[4]             = true;
   stateEjectShell[4]       = true;
   //
   stateTimeoutValue[4]          = 0.15;
   stateTransitionOnTimeout[4]   = "Fire";
   stateTransitionOnTriggerUp[4] = "Spindown";
   stateTransitionOnNoAmmo[4]    = "EmptySpindown";

   //--------------------------------------
   stateName[5]       = "Spindown";
//   stateSound[5]      = ChaingunSpinDownSound;
   stateSpinThread[5] = SpinDown;
   //
   stateTimeoutValue[5]            = 1.0;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[5]     = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   //--------------------------------------
   stateName[6]       = "EmptySpindown";
//   stateSound[6]      = ChaingunSpinDownSound;
   stateSpinThread[6] = SpinDown;
   //
   stateTimeoutValue[6]        = 0.5;
   stateTransitionOnTimeout[6] = "NoAmmo";

   //--------------------------------------
   stateName[7]       = "DryFire";
   stateSound[7]      = ChaingunDryFireSound;
   stateTimeoutValue[7]        = 0.5;
   stateTransitionOnTimeout[7] = "NoAmmo";
};

datablock ItemData(PulseChaingun)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_chaingun.dts";
   image        = PulseChaingunImage;
   mass         = 1;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "a pulse chaingun";

   computeCRC = true;
   emap = true;
};

datablock ShapeBaseImageData(PhaserC2Image) : PulseChaingunImage
{
    shapeFile = "weapon_ELF.dts";
    offset = "0 0.3 0.2";
    rotation = "0 1 0 180";
};

datablock ShapeBaseImageData(PhaserC3Image) : PulseChaingunImage
{
    shapeFile = "weapon_ELF.dts";
    offset = "0 1.2 0";
};

function PulseChaingunImage::onMount(%this, %obj, %slot)
{
Parent::onMount(%this, %obj, %slot);
%obj.mountImage(PhaserC2Image, 5);
%obj.mountImage(PhaserC3Image, 6);
}

function PulseChaingunImage::onUnmount(%this,%obj,%slot)
{
Parent::onUnmount(%this, %obj, %slot);
%obj.unmountImage(5);
%obj.unmountImage(6);
}

function PulseChaingunImage::onFire(%data,%obj,%slot) {
   %p = Parent::onFire(%data, %obj, %slot);
}
