datablock ItemData(PlasmaLauncher) {
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_mortar.dts";
   image = PlasmaLauncherImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a Plasma Missile Launcher";

   computeCRC = true;
   emap = true;
};

datablock ItemData(PlasmaLauncherAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_plasma.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some plasma energy cells";
};

datablock ShapeBaseImageData(PlasmaLauncherImage) {
   className = WeaponImage;

   shapeFile = "weapon_mortar.dts";
   item = PlasmaLauncher;
   ammo = PlasmaLauncherAmmo;

   RankReqName = "ETM-XCC98 Plasma Launcher"; //Called By TWMFuncitons.cs & Weapons.cs

   offset = "0 0 0";
   emap = true;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.4;
   stateSequence[0] = "Activate";

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.4;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "recoil";
   stateScript[3] = "onFire";
   stateSound[3] = MortarExplosionSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.7;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
   stateSound[4] = MortarReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = DiscDryFireSound;
   stateTimeoutValue[6]        = 1.2;
   stateTransitionOnTimeout[6] = "NoAmmo";

};

datablock ShapeBaseImageData(PlasmaLauncherImage2) : PlasmaLauncherImage {
stateSound[0]                    = MortarSwitchSound;

shapeFile = "weapon_plasma.dts";
offset = "0 0.0 0.0";
rotation = "0 1 0 60";
};

datablock ShapeBaseImageData(PlasmaLauncherImage3) : PlasmaLauncherImage {
shapeFile = "weapon_plasma.dts";
offset = "0.15 0.0 0.0";
rotation = "0 -1 0 60";
};

datablock ShapeBaseImageData(PlasmaLauncherImage4) : PlasmaLauncherImage {
shapeFile = "weapon_plasma.dts";
offset = "0.0 0.0 -0.1";
rotation = "0 1 0 100";
};

datablock ShapeBaseImageData(PlasmaLauncherImage5) : PlasmaLauncherImage
{
shapeFile = "weapon_plasma.dts";
offset = "0.15 0.0 -0.1";
rotation = "0 -1 0 100";
};

datablock ShapeBaseImageData(PlasmaLauncherImage6) : PlasmaLauncherImage {
shapeFile = "weapon_plasma.dts";
offset = "0.08 0.0 -0.2";
rotation = "0 0 0 0";
};


function PlasmaLauncherImage::onMount(%this,%obj,%slot) {
Parent::onMount(%this, %obj, %slot);
%obj.client.setWeaponsHudActive("MissileLauncher");
%obj.client.setWeaponsHudActive(%this.item);
%obj.mountImage(PlasmaLauncherImage2, 1);
%obj.mountImage(PlasmaLauncherImage3, 4);
%obj.mountImage(PlasmaLauncherImage4, 5);
%obj.mountImage(PlasmaLauncherImage5, 6);
%obj.mountImage(PlasmaLauncherImage6, 7);
}

function PlasmaLauncherImage::onunmount(%this,%obj,%slot) {
Parent::onUnmount(%this, %obj, %slot);
%obj.unmountimage(1);
%obj.unmountimage(4);
%obj.unmountimage(5);
%obj.unmountimage(6);
%obj.unmountimage(7);
}

function PlasmaLauncherImage::onFire(%data,%obj,%slot) {
    %proj = new (linearflareprojectile)() {
		dataBlock        = PhotonMissileProj;
		initialDirection = %obj.getMuzzleVector(%slot);
		initialPosition  = %obj.getMuzzlePoint(%slot);
		sourceObject     = %obj;
		sourceSlot = %obj;
 	};
    MissionCleanup.add(%proj);
	%proj.PhotonMuzVec = %obj.getMuzzleVector(%slot);
	schedule( 100,0, "seekingprojcheck" ,%obj,%Proj,""); //begin check for nearby targ
	schedule( 100,0, "PhotonShockwaveFunc" ,%obj,%Proj); //begin shockwave trail for projectile
    %obj.decInventory(%data.ammo, 1);
}
