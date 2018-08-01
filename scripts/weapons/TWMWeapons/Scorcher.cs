datablock AudioProfile(ScorcherSwitchSound)
{
   filename    = "fx/weapons/chaingun_start.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(ScorcherFireSound)
{
   filename    = "fx/weapons/Mortar_Explode_UW.wav";
   description = AudioClose3d;
   preload = true;
   effect = SniperRifleFireEffect;
};

datablock TracerProjectileData(ScorcherShot)
{
   doDynamicClientHits = true;

   directDamage        = 0.07;
   directDamageType    = $DamageType::Plasma;   //Fiah!!!
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;
   HeadMultiplier      = 1.2;
   LegsMultiplier      = 0.75;

   longRangeMultiplier  = 0.75;
   kickBackStrength  = 0.0;
   sound 				= ChaingunProjectile;

   dryVelocity       = 1500.0;
   wetVelocity       = 1000.0;
   velInheritFactor  = 0.0;
   fizzleTimeMS      = 1000;
   lifetimeMS        = 1000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 5.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.09;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = ChaingunDecal1;
   decalData[1] = ChaingunDecal2;
   decalData[2] = ChaingunDecal3;
   decalData[3] = ChaingunDecal4;
   decalData[4] = ChaingunDecal5;
   decalData[5] = ChaingunDecal6;
};

datablock ItemData(ScorcherAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_grenade.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "Scorcher Ammo, You shouldn't be getting this";
};

datablock ItemData(Scorcher)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_ELF.dts";
   image = ScorcherImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a Scorcher";
};

datablock ShapeBaseImageData(ScorcherImage)
{
   className = WeaponImage;
   shapeFile = "weapon_ELF.dts";
   item = Scorcher;
   offset = "0 0 0";
   emap = true;

   usesEnergy = false;
   ammo = "ScorcherAmmo";

   projectile = ScorcherShot;
   projectileType = TracerProjectile;
   RankReqName = "Scorcher Cannon"; //Called By TWMFuncitons.cs & Weapons.cs

   projectileSpread = 15.0 / 1000.0;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = ScorcherSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Charge";

   stateName[3] = "Charge";
   stateTransitionOnNoAmmo[3] = "NoAmmo";
   stateTransitionOnTimeout[3] = "Charge";
   stateTimeoutValue[3] = 1;    //charge 1 every second now
   stateScript[3] = "onCharge";
   stateTransitionOnTriggerUp[3] = "CheckWet";

   stateName[4] = "Fire";
   stateTransitionOnTimeout[4] = "Reload";
   stateTimeoutValue[4] = 0.1;
   stateFire[4] = true;
   stateRecoil[4] = LightRecoil;
   stateAllowImageChange[4] = false;
   stateScript[4] = "onFire";
   stateSound[4] = ScorcherFireSound;

   stateName[5] = "Reload";
   stateTransitionOnNoAmmo[5] = "NoAmmo";
   stateTimeoutValue[4] = 2.1;
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
datablock ShapeBaseImageData(ScorcherImage2) : Scorcher
{
    shapeFile = "weapon_grenade_launcher.dts";
    offset = "0.04 0.3 0.08";
    rotation = "0 0 0 0";

};

datablock ShapeBaseImageData(ScorcherImage3) : Scorcher
{
    shapeFile = "weapon_mortar.dts";
    offset = "-0.03 0 0";
    rotation = "0 0 0 0";

};

datablock ShapeBaseImageData(ScorcherImage4) : Scorcher
{
    shapeFile = "weapon_sniper.dts";
    offset = "0.03 0 -0.04";
    rotation = "0 0 0 0";

};

function ScorcherImage::onmount(%this, %obj, %slot)
{
   Parent::onMount(%this,%obj,%slot);

   %obj.setInventory(ScorcherAmmo, 1);

   %obj.mountImage(ScorcherImage2, 4);
   %obj.mountImage(ScorcherImage3, 5);
   %obj.mountImage(ScorcherImage4, 6);
}

function ScorcherImage::onUnmount(%this, %obj, %slot)
{
   Parent::onUnMount(%this,%obj,%slot);

   %obj.setInventory(ScorcherAmmo, 1); //1 so we can mount again...

   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
}

function ScorcherImage::onFire(%data, %obj, %slot) {
   if(%obj.overHeated) {
      commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Armor Heat Systems Locked.. Cooling<spop>", 1, 1);
      return;
   }
   if($Medals::FireExtinguisher[%obj.client.GUID] $= true) {
      if($Host::RankSystem == 1 && $Rank::XP[%obj.client.ranknum] < $TWM::WeaponRequirement["Scorcher"] ) {
         commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Your Rank Is Too Low To Use This Weapon \n You need "@$TWM::WeaponRequirement["Scorcher"]@" EXP<spop>", 5, 2);
         return;
      }
      else {
         //Fire Code
         %vector = %obj.getMuzzleVector(%slot);
         %mp = %obj.getMuzzlePoint(%slot);

	     for (%i=0; %i < %obj.inv[ScorcherAmmo]; %i++) {
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
         }
         //Overcharge & Reset
         if(%obj.OverCharged) {
            OverHeatLoop(%obj);
         }
         %obj.OverCharged = false;
         %obj.setInventory(ScorcherAmmo, 1, true);
      }
   }
   else {
      commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>You do not have the required medal to use this weapon \n You need the Fire Extinguisher Medal<spop>", 5, 2);
   }
}

function ScorcherImage::onCharge(%data, %obj, %slot) {
   //We need to cool down the weapon...
   if(%obj.overHeated) {
      commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Armor Heat Systems Locked.. Cooling<spop>", 1, 1);
      return;
   }
   //
   if(%obj.inv[ScorcherAmmo] < 7) { //Max Ammo Reduced To 7
      %obj.setInventory(ScorcherAmmo, %obj.inv[ScorcherAmmo] + 1, true);
      %obj.OverCharged = false;
   }
   else {
      commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>WARNING: OVERCHARGE<spop>", 1, 1);
      %obj.OverCharged = true;
   }
}

function OverHeatLoop(%obj) {
   if(!isObject(%obj) || %obj.getState() $= "dead") {
      return;
   }
   %obj.overHeated = true;
   %obj.overHeatCount++;
   commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Armor Overheat... Cooling<spop>", 1, 1);
   %obj.setEnergyLevel(0); //no jets 4 you
   %obj.setRechargeRate(0); //no jet RECHARGE 4 you
   if(%obj.overHeatCount > 19) { //20 second cooldown
      %obj.overHeated = false;
      %obj.overHeatCount = 0;
      %obj.setRechargeRate(0.456);
      commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Armor Cooling Complete<spop>", 1, 1);
      return;
   }
   schedule(1000,0,"OverHeatLoop", %obj);
}

//used in multiple scripts
function CreateScorch(%g, %pos) {
   if(!isObject(%g) || %g.getState() $= "dead") {
      return;
   }
   %p = new TracerProjectile() {
	   	dataBlock        = napalmSubExplosion;
	   	initialDirection = "0 0 -10";
	   	initialPosition  = %pos;
	   	sourceObject     = %g;
   	   	sourceSlot       = 5;
   };
   %p.vector = "0 0 -10";
   %p.count = 5;
}

function ScorcherShot::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal) {
   %source = %projectile.SourceObject;
   Parent::OnCollision(%data, %projectile, %targetObject, %modifier, %position, %normal);
   CreateScorch(%source, %position);
}

