//CENTAUR DUAL
datablock ItemData(DualpistolAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some .23mm bullets";

   computeCRC = true;

};

datablock ItemData(Dualpistol)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_energy_vehicle.dts";
   image = DualpistolImage;
   mass = 2;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "Centaur Dual Pistols";
};

datablock ShapeBaseImageData(DualPistolImage) {
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item = Dualpistol;

   offset = "0 0 0";
   rotation = "0 1 0 180";
   mass = 4;

   ammo = DualpistolAmmo;

   projectile = coltbullet;
   projectileType = tracerProjectile;
   projectileSpread = 7.0 / 1000.0;
   
   //ClipStuff
   ClipName = "CentaurClip";
   ClipPickupName["CentaurClip"] = "Some .23MM Clips";
   ShowsClipInHud = 0;
   ClipReloadTime = 6;
   ClipReturn = 20;
   InitialClips = 950;
   //
   //Challenges
   HasChallenges = 1;
   ChallengeCt = 5;
   Challenge[1] = "Centaur Rookie\t25\t100\tNone";
   Challenge[2] = "Centaur Novice\t50\t150\tNone";
   Challenge[3] = "Centaur Expert\t100\t250\tNone";
   Challenge[4] = "Centaur Master\t250\t500\tGrip";
   Challenge[5] = "Centaur Extremist\t500\t1000\tMini Shotguns";
   Upgrade[1] = "Grip";
   Upgrade[2] = "Mini Shotguns";
   GunName = "Centaur Dual Pistol";
   //
   
   RankRequire = $TWM2::RankRequire["Centaur"];

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = PlasmaSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.1;
   stateFire[3] = true;
   stateEmitter[3] = "GunFireEffectEmitter";
   stateEmitterNode[3] = "muzzlepoint1";
   stateEmitterTime[3] = 1;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = PistolFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.1;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = ChaingunDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

datablock ShapeBaseImageData(DualPistolImage2) : DualPistolImage {
   offset = "-0.5 0 0";
};

function DualPistolImage::onMount(%this,%obj,%slot) {
   %obj.mountImage(DualPistolImage2, 5);
   Parent::onMount(%this, %obj, %slot);
}

function DualPistolImage::onUnMount(%this,%obj,%slot) {
   %obj.unmountImage(5);
   Parent::onUnMount(%this, %obj, %slot);
}

function DualPistolImage::onFire(%data, %obj, %slot) {
   FirePistolShot(%data, %obj, %slot);
   schedule(200,0,"FirePistolShot", %data, %obj, 5);
}

function FirePistolShot(%data, %obj, %slot) {
   %obj.decInventory(%data.Ammo, 1);
   serverPlay3d("PistolFireSound", %obj.getPosition());

   %vector = %obj.getMuzzleVector(%slot);
   %mp = %obj.getMuzzlePoint(%slot);

   %x = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
   %y = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
   %z = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
   %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
   %newvector = MatrixMulVector(%mat, %vector);

   %p = new (%data.projectileType)() {
      dataBlock        = %data.projectile;
      initialDirection = %newvector;
      initialPosition  = %mp;
      sourceObject     = %obj;
      damageFactor	 = 1;
      sourceSlot       = %slot;
   };
   if(%obj.inv[%data.ammo] == 0) { //Added Phantom139, TWM2
      AttemptReload(%data, %obj, %slot);
   }
}
