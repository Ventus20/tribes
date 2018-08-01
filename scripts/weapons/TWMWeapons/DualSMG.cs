//--------------------------------------
// Dual Uzis
//--------------------------------------

//--------------------------------------------------------------------------
// Ammo
//--------------------------------------

datablock ItemData(DualLSMGAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some MP12 ammo";

   computeCRC = true;
};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ShapeBaseImageData(DualLSMGImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item      = DualLSMG;
   ammo 	 = DualLSMGAmmo;
   projectile = LSMGBullet;
   projectileType = TracerProjectile;
   emap = true;
   offset = "0.15 0.5 0";  // L/R - F/B - T/B
   rotation = "0 1 0 180";
   mass = 11;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   RankReqName = "Dual MP12 Uzis"; //Called By TWMFuncitons.cs & Weapons.cs
   projectileSpread = 2 / 1000.0;
   maxSpread = 12 / 1000;

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
   stateSound[3]        = ChaingunSpinupSound;
   //
   stateTimeoutValue[3]          = 0.01;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   //--------------------------------------
   stateName[4]             = "Fire";
   stateSequence[4]            = "Fire";
   stateSequenceRandomFlash[4] = true;
   stateSpinThread[4]       = FullSpeed;
   stateSound[4]            = ChaingunFireSound;
   stateRecoil[4]           = LightRecoil;
   stateEmitter[4] = "GunFireEffectEmitter";
   stateEmitterNode[4] = "muzzlepoint1";
   stateEmitterTime[4] = 1;
   stateAllowImageChange[4] = false;
   stateScript[4]           = "onFire";
   stateFire[4]             = true;
   stateEjectShell[4]       = true;
   //
   stateTimeoutValue[4]          = 0.05;
   stateTransitionOnTimeout[4]   = "Fire";
   stateTransitionOnTriggerUp[4] = "Spindown";
   stateTransitionOnNoAmmo[4]    = "EmptySpindown";

   //--------------------------------------
   stateName[5]       = "Spindown";
   stateSound[5]      = ChaingunSpinDownSound;
   stateSpinThread[5] = SpinDown;
   //
   stateTimeoutValue[5]            = 0.05;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[5]     = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   //--------------------------------------
   stateName[6]       = "EmptySpindown";
   stateSound[6]      = ChaingunSpinDownSound;
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

datablock ItemData(DualLSMG)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_energy_vehicle.dts";
   image        = DualLSMGImage;
   mass         = 1.0;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "Dual MP12 SMGs";

   computeCRC = true;
   emap = true;
};

datablock ItemData(DualLSMGClip)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "some 6mm clips";

   computeCRC = true;
};

datablock ShapeBaseImageData(DualLSMGmain)
{
   ammo = DualLSMGAmmo;
   shapeFile = "weapon_targeting.dts";
   offset = "0.15 0.0 0.0";
   emap = true;
};

datablock ShapeBaseImageData(DualLSMGClipImage)
{
   shapeFile = "grenade.dts";
   ammo = DualLSMGAmmo;
   offset = "0.15 0.64 -0.2";
   emap = true;
};

function DualLSMGImage::onMount(%this,%obj,%slot) {
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(DualLSMGClipImage, 3);
   %obj.mountImage(DualLSMGmain, 4);
   //Second
   %obj.mountImage(DualLSMG2Image, 5);
   %obj.mountImage(DualLSMG2ClipImage, 6);
   %obj.mountImage(DualLSMG2main, 7);
   //End
   %obj.clipReloading = false;
   if (%obj.inv[DualLSMGAmmo] == 0)
      %obj.DualLSMGcheckclip = schedule(10, 0, "DualLSMGCheckforclip", %obj);
}

function DualLSMGImage::onUnmount(%this,%obj,%slot) {
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(3);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   %obj.unmountImage(7);
   if (%obj.clipReloading != false) {
	  Cancel(%obj.DualLSMGClipAdd);
	  %obj.clipReloading = false;
   }
}

function DualLSMGImage::onFire(%data,%obj,%slot) {
   %obj.decInventory(%data.ammo,1);

   if(%obj.spread $= "" || %obj.spread < %data.projectileSpread)
	%obj.spread = %data.projectileSpread;
   else
      %obj.spread = %obj.spread + (1.5 / 1000);

   if(%obj.lowSpreadLoop $= "")
	%obj.lowSpreadLoop = schedule(250, 0, "RiflelowerSpread", %data, %obj);
   if(%obj.spread > %data.maxspread)
	%obj.spread = %data.maxspread;

    %vector = %obj.getMuzzleVector(%slot);
    %mp = %obj.getMuzzlePoint(%slot);

      %x = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
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
      
      //
      %obj.decInventory(%data.ammo,1);
    %vector2 = %obj.getMuzzleVector(6);
    %mp2 = vectoradd(%obj.getMuzzlePoint(6), "-0.65 0 0");

      %x = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
      %newvector2 = MatrixMulVector(%mat, %vector2);
      %p = new (%data.projectileType)()
	   {
            dataBlock        = %data.projectile;
            initialDirection = %newvector2;
            initialPosition  = %mp2;
            sourceObject     = %obj;
		    damageFactor	 = 1;
            sourceSlot       = 6;
      };
      
      if (%obj.inv[DualLSMGAmmo] == 0)
         %obj.DualLSMGcheckclip = schedule(10, 0, "DualLSMGCheckforclip", %obj);
}

function DualLSMGCheckforclip(%obj) {
   if (%obj.inv[DualLSMGclip] > 0)
   {
	%obj.clipReloading = true;
      %obj.DualLSMGClipAdd = schedule(1500, 0, "DualLSMGReloadClip", %obj);
   }
}

function DualLSMGReloadClip(%obj) {
   %obj.clipReloading = false;
   %obj.decInventory(DualLSMGClip, 1);
   %obj.setInventory(DualLSMGAmmo, 90); //double the original
}


//SECOND
datablock ShapeBaseImageData(DualLSMG2Image) : DualLSMGImage {

   offset = "-0.65 0.5 0";  // L/R - F/B - T/B

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
   stateSound[3]        = ChaingunSpinupSound;
   //
   stateTimeoutValue[3]          = 0.01;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   //--------------------------------------
   stateName[4]             = "Fire";
   stateSequence[4]            = "Fire";
   stateSequenceRandomFlash[4] = true;
   stateSpinThread[4]       = FullSpeed;
   stateSound[4]            = ChaingunFireSound;
   stateRecoil[4]           = LightRecoil;
   stateEmitter[4] = "GunFireEffectEmitter";
   stateEmitterNode[4] = "muzzlepoint1";
   stateEmitterTime[4] = 1;
   stateAllowImageChange[4] = false;
   stateScript[4]           = "onFire";
   stateFire[4]             = true;
   stateEjectShell[4]       = true;
   //
   stateTimeoutValue[4]          = 0.05;
   stateTransitionOnTimeout[4]   = "Fire";
   stateTransitionOnTriggerUp[4] = "Spindown";
   stateTransitionOnNoAmmo[4]    = "EmptySpindown";

   //--------------------------------------
   stateName[5]       = "Spindown";
   stateSound[5]      = ChaingunSpinDownSound;
   stateSpinThread[5] = SpinDown;
   //
   stateTimeoutValue[5]            = 0.05;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[5]     = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   //--------------------------------------
   stateName[6]       = "EmptySpindown";
   stateSound[6]      = ChaingunSpinDownSound;
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

datablock ShapeBaseImageData(DualLSMG2main) : DualLSMGmain
{
   ammo = DualLSMGAmmo;
   shapeFile = "weapon_targeting.dts";
   offset = "-0.65 0.0 0.0";
   emap = true;
};

datablock ShapeBaseImageData(DualLSMG2ClipImage) : DualLSMGClipImage
{
   shapeFile = "grenade.dts";
   ammo = DualLSMGAmmo;
   offset = "-0.65 0.64 -0.2";
   emap = true;
};

function DualLSMGImage::onSpindown(%this,%obj,%slot) {
   %obj.setImageTrigger(5, false);
}

function DualLSMGImage::onSpinup(%this,%obj,%slot) {
   %obj.setImageTrigger(5, true);
}

