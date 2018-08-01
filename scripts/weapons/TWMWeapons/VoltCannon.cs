datablock TracerProjectileData(VoltageCannonMainProj)
{
   doDynamicClientHits = true;

   directDamage        = 1.2;
   explosion           = "PBCexplosion";
   splash              = ChaingunSplash;

   directDamageType    = $DamageType::VoltGun;
   hasDamageRadius     = true;
   indirectDamage      = 0.6;
   damageRadius        = 8.0;
   kickBackStrength    = 0.0;
   radiusDamageType    = $DamageType::VoltGun;


   sound = ShrikeBlasterProjectileSound;

   dryVelocity       = 5000.0;
   wetVelocity       = 0.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 200;
   lifetimeMS        = 200;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 45.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = "0.1 1.0 0.1 1.0";
	tracerTex[0]  	 = "special/shrikeBolt";
	tracerTex[1]  	 = "special/shrikeBoltCross";
	tracerWidth     = 1.4;
   crossSize       = 0.99;
   crossViewAng    = 0.990;
   renderCross     = true;
};

datablock ItemData(VoltageCannon)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_ELF.dts";
   image        = VoltageCannonImage;
   mass         = 1;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
	pickUpName = "a Voltage Cannon";

   computeCRC = true;

};

datablock ItemData(VoltageCannonAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_plasma.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "A Voltage Container";

   computeCRC = true;

};

datablock ShapeBaseImageData(VoltageCannonImage)
{
   className = WeaponImage;
   shapeFile = "weapon_ELF.dts";
   item = VoltageCannon;
   projectile = VoltageCannonMainProj;
   projectileType = TracerProjectile;
   ammo 	 = VoltageCannonAmmo;
   armThread = looksn;

   RankReqName = "Tesla Volatge Cannon"; //Called By TWMFuncitons.cs & Weapons.cs
   usesEnergy = false;

   //--------------------------------------
   stateName[0]             = "Activate";
   stateSequence[0]         = "Activate";
   stateSound[0]            = ShocklanceSwitchSound;
   stateAllowImageChange[0] = false;
   stateTimeoutValue[0]        = 1.0;
   stateTransitionOnTimeout[0] = "Ready";
   stateTransitionOnNoAmmo[0]  = "NoAmmo";

   //--------------------------------------
   stateName[1]       = "Ready";
   stateScript[1]	    = "onReady";
   stateSpinThread[1] = Stop;
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
   stateSound[3]        = ElfFireWetSound;
   stateScript[3]           = "onSpinup";
   stateTimeoutValue[3]          = 2;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   //--------------------------------------
   stateName[4]             = "Fire";
   stateSequence[4]            = "Fire";
   stateSpinThread[4]       = FullSpeed;

   stateEmitter[4] 	    = "PBCShootEmitter";
   stateEmitterNode[4]      = "muzzlepoint1";
   stateEmitterTime[4]      = 0.1;
   stateRecoil[4]           = LightRecoil;
   stateAllowImageChange[4] = false;

   stateScript[4]           = "onFire";
   stateFire[4]             = true;
   stateEjectShell[4]       = true;
   stateTimeoutValue[4]          = 1.0;
   stateTransitionOnTimeout[4]   = "Spindown";
   stateTransitionOnTriggerUp[4] = "Spindown";
   stateTransitionOnNoAmmo[4]    = "EmptySpindown";

   //--------------------------------------
   stateName[5]       = "Spindown";
   stateSpinThread[5] = SpinDown;
   stateScript[5]           = "onSpindown";
   stateTimeoutValue[5]            = 1.5;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[5]     = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   //--------------------------------------
   stateName[6]       = "EmptySpindown";
   stateSpinThread[6] = SpinDown;
   stateScript[6]           = "onSpindown";
   stateTimeoutValue[5]            = 1.5;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[6] = "NoAmmo";

   //--------------------------------------
   stateName[7]       = "DryFire";
   stateSound[7]      = ChaingunDryFireSound;
   stateTimeoutValue[7]        = 0.5;
   stateTransitionOnTimeout[7] = "NoAmmo";
};

function VoltageCannonImage::onFire(%data,%obj,%slot){
serverPlay3d("ShockLanceDryFireSound",%obj.getmuzzlepoint(0));
%p = Parent::onFire(%data, %obj, %slot);
}

function Voltageloop(%obj){
   if(!isobject(%obj))
	return;
   if(%obj.Shocked == 0) {
   return;
   }
   if(%obj.VoltCnt >= %obj.maxVoltCnt){
	%obj.VoltCnt = "";
	%obj.maxVoltCnt = 0;
	%obj.Shocked = 0;
    return;
   }
   else {
	%obj.damage(0, %obj.getposition(), 0.02, $DamageType::Zappy);
   	%zap = new ParticleEmissionDummy(){
   	   position = vectoradd(%obj.getPosition(),"0 0 0.5");
   	   dataBlock = "defaultEmissionDummy";
   	   emitter = "PBCChargeEmitter";   //eh this works
      };
	MissionCleanup.add(%zap);
	%zap.schedule(100, "delete");
	%obj.VoltCnt++;
	schedule(100, %obj, "Voltageloop", %obj);
   }
}
