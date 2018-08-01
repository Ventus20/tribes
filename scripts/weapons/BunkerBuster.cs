//--------------------------------------
// Mortar
//--------------------------------------

datablock EffectProfile(BunkerBusterExplosionEffect)
{
   effectname = "explosions/explosion.xpl03";
   minDistance = 400;
   maxDistance = 500;
};

datablock AudioProfile(BunkerBusterExplosionSound)
{
   filename    = "fx/weapons/mortar_explode.wav";
   description = AudioBIGExplosion3d;
   preload = true;
   effect = BunkerBusterExplosionEffect;
};

//---------------------------------------------------------------------------
// Nuke Shockwave
//---------------------------------------------------------------------------

//PROTON COLLIDER STUFF
datablock ShockwaveData(ColliderWave) {
	className = "ShockwaveData";
	scale = "1 1 1";
	delayMS = "0";
	delayVariance = "0";
	lifetimeMS = "2700";
	lifetimeVariance = "0";
	width = "1";
	numSegments = "60";
	numVertSegments = "30";
	velocity = "10";
	height = "20";
	verticalCurve = "5";
	acceleration = "9";
	times[0] = "0";
	times[1] = "0.25";
	times[2] = "0.9";
	times[3] = "1";
	colors[0] = "1.000000 0.600000 0.200000 1.000000"; //1.0 0.9 0.9
	colors[1] = "1.000000 0.600000 0.200000 1.000000"; //0.6 0.6 0.6
	colors[2] = "1.000000 0.600000 0.200000 1.000000"; //0.6 0.6 0.6
	colors[3] = "1.000000 0.600000 0.200000 0.000000";
	texture[0] = "terraintiles/molten1";
	texture[1] = "special/shockwave4"; //gradient";
    texWrap = "1";
	is2D = "0";
	mapToTerrain = "0";
	orientToNormal = "1";
	renderBottom = "1";
	renderSquare = "0";
};

datablock ParticleData(ColliderExpandersPaticle)
{
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.0;

   lifetimeMS           = 10000;
   lifetimeVarianceMS   = 0;
   constantAcceleration = 0.1;

   spinRandomMin = -30.0;
   spinRandomMax = 30.0;
   windcoefficient = 0;
   textureName          = "flarebase";

   colors[0] = "255 127 0 1";
   colors[1] = "255 127 0 1";
   colors[2] = "255 127 0 1";
   colors[3] = "0.8 1 0.2 0";

   sizes[0]      = 1;
   sizes[1]      = 2;
   sizes[2]      = 4;
   sizes[3]      = 5;

   times[0] = "0";
   times[1] = "0.25";
   times[2] = "0.9";
   times[3] = "1";

};

datablock ParticleEmitterData(ColliderExpandersEmitter)
{
   lifetimeMS        = 1000;
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionVelocity = 10;
   velocityVariance = 0;
   ejectionoffset   = 5;
   thetaMin         = 0.0;
   thetaMax         = 180.0;

   phiReferenceVel = "0";
   phiVariance = "360";
   orientParticles  = false;
   orientOnVelocity = false;

   particles = "ColliderExpandersPaticle";
};

datablock ExplosionData(ProtonColliderExplosion) {
   shakeCamera = true;
   camShakeFreq = "20.0 18.0 17.0";
   camShakeAmp = "140.0 140.0 140.0";
   camShakeDuration = 1.3;
   camShakeRadius = 300;

   emitter[0] = "ColliderExpandersEmitter";
   Shockwave = "ColliderWave";
};

datablock TracerProjectileData(ProtonColliderBolt) {
   doDynamicClientHits = true;

   directDamage        = 1.9; // z0dd - ZOD, 9-27-02. Was 0.0825
   directDamageType    = $DamageType::GunTurret;
   hasDamageRadius     = true;
   indirectDamage      = 1.9;
   damageRadius        = 55.5;
   radiusDamageType    = $DamageType::GunTurret;
   explosion           = "ProtonColliderExplosion";
   splash              = ChaingunSplash;

   kickBackStrength  = 1500.0;
   sound 				= ChaingunProjectile;

   //dryVelocity       = 425.0;
   dryVelocity       = 1250.0; // z0dd - ZOD, 8-12-02. Was 425.0
   wetVelocity       = 1000.0;
   velInheritFactor  = 0.0;
   fizzleTimeMS      = 30000;
   lifetimeMS        = 30000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 25.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 2.25;
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

datablock ShockwaveData(BunkerBusterShockwave)
{
   width = 20.0;
   numSegments = 32;
   numVertSegments = 6;
   velocity = 1000;
   acceleration = 20.0;
   lifetimeMS = 1000;
   height = 30.0;
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


//--------------------------------------------------------------------------
// Mortar Explosion Particle effects
//--------------------------------------

datablock ParticleData(BunkerBusterExplosionSmoke)
{
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = 0.1;   // rises slowly
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 5000;
   lifetimeVarianceMS   = 250;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -100.0;
   spinRandomMax =  100.0;

   textureName = "special/Smoke/bigSmoke";

   colors[0]     = "0.4 0.4 0.4 1.0";
   colors[1]     = "0.4 0.4 0.4 0.5";
   colors[2]     = "0.3 0.3 0.3 0.75";
   colors[3]     = "0.1 0.1 0.1 0.0";
   sizes[0]      = 20.0;
   sizes[1]      = 24.0;
   sizes[2]      = 40.0;
   sizes[3]      = 48.0;
   times[0]      = 0.0;
   times[1]      = 0.333;
   times[2]      = 0.666;
   times[3]      = 1.0;

};

datablock ParticleData(BunkerBusterExplosionSmokeRisers)
{
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = 0.75;   // rises
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 10000;
   lifetimeVarianceMS   = 250;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -100.0;
   spinRandomMax =  100.0;

   textureName = "special/Smoke/bigSmoke";

   colors[0]     = "0.4 0.4 0.4 1.0";
   colors[1]     = "0.4 0.4 0.4 0.5";
   colors[2]     = "0.3 0.3 0.3 0.75";
   colors[3]     = "0.1 0.1 0.1 0.0";
   sizes[0]      = 20.0;
   sizes[1]      = 24.0;
   sizes[2]      = 40.0;
   sizes[3]      = 48.0;
   times[0]      = 0.0;
   times[1]      = 0.333;
   times[2]      = 0.666;
   times[3]      = 1.0;
};

datablock ParticleData(BunkerBusterExplosionSmokeFallers)
{
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = -4.0;   // falls
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 20000;
   lifetimeVarianceMS   = 250;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -100.0;
   spinRandomMax =  100.0;

   textureName = "special/Smoke/bigSmoke";

   colors[0]     = "0.4 0.4 0.4 1.0";
   colors[1]     = "0.4 0.4 0.4 0.5";
   colors[2]     = "0.3 0.3 0.3 0.75";
   colors[3]     = "0.1 0.1 0.1 0.0";
   sizes[0]      = 20.0;
   sizes[1]      = 24.0;
   sizes[2]      = 40.0;
   sizes[3]      = 48.0;
   times[0]      = 0.0;
   times[1]      = 0.333;
   times[2]      = 0.666;
   times[3]      = 1.0;

};

datablock ParticleEmitterData(BunkerBusterExplosionSmokeEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionOffset = 250.0;

   ejectionVelocity = 0.0;
   velocityVariance = 0.0;

   thetaMin         = 89.0;
   thetaMax         = 90.0;

   lifetimeMS       = 1000;

   particles = "BunkerBusterExplosionSmoke";

};

datablock ParticleEmitterData(BunkerBusterExplosionSmokeEmitter2)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;

   ejectionOffset = 15.0;

   ejectionVelocity = 200.0;
   velocityVariance = 10.0;

   thetaMin         = 0.0;
   thetaMax         = 90.0;

   lifetimeMS       = 2000;

   particles = "BunkerBusterExplosionSmoke";

};

datablock ParticleEmitterData(BunkerBusterExplosionSmokeEmitter3)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionOffset = 10.0;

   ejectionVelocity = 40.0;
   velocityVariance = 10.0;

   thetaMin         = 60.0;
   thetaMax         = 90.0;

   lifetimeMS       = 750;

   particles = "BunkerBusterExplosionSmokeRisers";

};

datablock ParticleEmitterData(BunkerBusterExplosionSmokeEmitter4)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionOffset = 0.0;

   ejectionVelocity = 40.0;
   velocityVariance = 10.0;

   thetaMin         = 0.0;
   thetaMax         = 60.0;

   lifetimeMS       = 750;

   particles = "BunkerBusterExplosionSmokeRisers";

};

datablock ParticleEmitterData(BunkerBusterExplosionSmokeEmitter5)
{
   ejectionPeriodMS = 25;
   periodVarianceMS = 0;

   ejectionOffset = 12.0;


   ejectionVelocity = 125.0;
   velocityVariance = 10.0;

   thetaMin         = 0.0;
   thetaMax         = 45.0;

   lifetimeMS       = 5000;

   particles = "BunkerBusterExplosionSmokeFallers";

};

datablock ParticleEmitterData(BunkerBusterExplosionSmokeEmitter6)
{
   ejectionPeriodMS = 25;
   periodVarianceMS = 0;

   ejectionOffset = 5.0;


   ejectionVelocity = 150.0;
   velocityVariance = 1.0;

   thetaMin         = 45.0;
   thetaMax         = 90.0;

   lifetimeMS       = 5000;

   particles = "BunkerBusterExplosionSmokeFallers";

};

//---------------------------------------------------------------------------
// Explosion
//---------------------------------------------------------------------------

datablock ExplosionData(BunkerBusterSubExplosion1)
{
   explosionShape = "mortar_explosion.dts";
   faceViewer           = true;

   delayMS = 500;

   offset = 0.0;

   playSpeed = 0.5;

   sizes[0] = "500.0 500.0 500.0";
   sizes[1] = "500.0 500.0 500.0";
   times[0] = 0.0;
   times[1] = 1.0;
};

datablock ExplosionData(BunkerBusterSubExplosion2)
{
   explosionShape = "mortar_explosion.dts";
   faceViewer           = true;

   delayMS = 250;

   offset = 0.0;

   playSpeed = 0.25;

   sizes[0] = "200.0 200.0 200.0";
   sizes[1] = "200.0 200.0 200.0";
   times[0] = 0.0;
   times[1] = 1.0;
};

datablock ExplosionData(BunkerBusterSubExplosion3)
{
   explosionShape = "effect_plasma_explosion.dts";
   faceViewer           = true;
   delayMS = 0;
   offset = 0.0;
   playSpeed = 0.15;

   sizes[0] = "50.0 50.0 50.0";
   sizes[1] = "50.0 50.0 50.0";
   times[0] = 0.0;
   times[1] = 1.0;
};

datablock ExplosionData(BunkerBusterExplosion)
{
   soundProfile   = BunkerBusterExplosionSound;

   shockwave = BunkerBusterShockwave;
   shockwaveOnTerrain = false;

   subExplosion[0] = BunkerBusterSubExplosion1;
   subExplosion[1] = BunkerBusterSubExplosion2;
   subExplosion[2] = BunkerBusterSubExplosion3;

   emitter[0] = BunkerBusterExplosionSmokeEmitter;
   emitter[1] = BunkerBusterExplosionSmokeEmitter2;
   emitter[2] = BunkerBusterExplosionSmokeEmitter3;
   emitter[3] = BunkerBusterExplosionSmokeEmitter4;
   emitter[4] = BunkerBusterExplosionSmokeEmitter5;
   emitter[5] = BunkerBusterExplosionSmokeEmitter6;

   shakeCamera = true;
   camShakeFreq = "24.0 27.0 21.0";
   camShakeAmp = "100.0 100.0 100.0";
   camShakeDuration = 4.0;
   camShakeRadius = 500.0;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------
datablock GrenadeProjectileData(BunkerBusterball)
{
   projectileShapeName = "mortar_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 21.0;
   damageRadius        = 250.0; // z0dd - ZOD, 8/13/02. Was 20.0
   radiusDamageType    = $DamageType::nuke;
   kickBackStrength    = 5000;

   explosion           = "BunkerBusterExplosion";
   underwaterExplosion = "BunkerBusterExplosion";
   velInheritFactor    = 0.5;
   splash              = MortarSplash;
   depthTolerance      = 10.0; // depth at which it uses underwater explosion

   baseEmitter         = MortarSmokeEmitter;
   bubbleEmitter       = MortarBubbleEmitter;

   grenadeElasticity = 0.15;
   grenadeFriction   = 0.4;
   armingDelayMS     = 6000; // z0dd - ZOD, 4/14/02. Was 2000

   gravityMod        = 1.3;  // z0dd - ZOD, 5/18/02. Make mortar projectile heavier, less floaty
   muzzleVelocity    = 70.0; // z0dd - ZOD, 8/13/02. More velocity to compensate for higher gravity. Was 63.7
   drag              = 0.1;
   sound	     = MortarProjectileSound;

   hasLight    = true;
   lightRadius = 4;
   lightColor  = "0.05 0.2 0.05";

   hasLightUnderwaterColor = true;
   underWaterLightColor = "0.05 0.075 0.2";
};

datablock GrenadeProjectileData(VaccumeDrop)
{
   projectileShapeName = "mortar_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.1;
   damageRadius        = 250.0; // z0dd - ZOD, 8/13/02. Was 20.0
   radiusDamageType    = $DamageType::nuke;
   kickBackStrength    = 5000;

   explosion           = "BlasterExplosion";
   underwaterExplosion = "BlasterExplosion";
   velInheritFactor    = 0.5;
   splash              = MortarSplash;
   depthTolerance      = 10.0; // depth at which it uses underwater explosion

   baseEmitter         = MortarSmokeEmitter;
   bubbleEmitter       = MortarBubbleEmitter;

   grenadeElasticity = 0.15;
   grenadeFriction   = 0.4;
   armingDelayMS     = 1000; // z0dd - ZOD, 4/14/02. Was 2000

   gravityMod        = 1.3;  // z0dd - ZOD, 5/18/02. Make mortar projectile heavier, less floaty
   muzzleVelocity    = 70.0; // z0dd - ZOD, 8/13/02. More velocity to compensate for higher gravity. Was 63.7
   drag              = 0.1;
   sound	     = MortarProjectileSound;

   hasLight    = true;
   lightRadius = 4;
   lightColor  = "0.05 0.2 0.05";

   hasLightUnderwaterColor = true;
   underWaterLightColor = "0.05 0.075 0.2";
};
//--------------------------------------------------------------------------
// Ammo
//--------------------------------------


//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ItemData(BunkerBuster)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_mortar.dts";
   image = BunkerBusterImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "abunker buster nuke";

   computeCRC = true;
   emap = true;
};


datablock ShapeBaseImageData(BunkerBusterImage)
{
   className = WeaponImage;
   shapeFile = "weapon_mortar.dts";
   item = BunkerBuster;
   offset = "0 0 0";
   emap = true;

   usesEnergy = true;
   fireEnergy = 4;
   minEnergy = 4;

   RankReqName = "NoRequire"; //Called By TWMFuncitons.cs & Weapons.cs

   projectile = BunkerBusterball;
   projectileType = GrenadeProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = MortarSwitchSound;

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
   stateSound[3] = MortarFireSound;
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
   stateSound[6] = MortarDryFireSound;
   stateTransitionOnTimeout[6] = "Ready";
};

function BunkerBusterImage::onMount(%this,%obj,%slot)
{
     Parent::onMount(%data,%obj,%slot);
     CommandToClient(%obj.client, 'BottomPrint', "<spush><font:Sui Generis:14>>>>Bunker Buster Cannon<<<<spop>\n<spush><font:Arial:14>Created By: Dondelium_X<spop>", 3, 3 );
     %obj.UsingBunkerBuster = true;
}

function BunkerBusterImage::onunmount(%this,%obj,%slot)
{
     Parent::onUnmount(%this, %obj, %slot);
     %obj.UsingBunkerBuster = false;
}

    function ChangeBBBombMode(%this, %data) {  //This Is Easier To use
    if (!(getSimTime() > (%this.mineModeTime + 100)))
    return;
    %this.mineModeTime = getSimTime();
    %this.BunbkerBustMode++;
    if (%this.BunbkerBustMode > 3) {
    %this.BunbkerBustMode = 0;
    }
    DisplayBunkerBombInfo(%this);
    return;
    }

    function DisplayBunkerBombInfo(%obj) {
       switch(%obj.BunbkerBustMode) {
       case 0:
       CommandToClient(%obj.client, 'BottomPrint', "<spush><font:Sui Generis:14>>>>Bunker Buster Cannon<<<<spop>\n<spush><font:Arial:14>Bunker Buster Bombs<spop>", 3, 3 );
       case 1:
       CommandToClient(%obj.client, 'BottomPrint', "<spush><font:Sui Generis:14>>>>Bunker Buster Cannon<<<<spop>\n<spush><font:Arial:14>Vaccume Bomb<spop>", 3, 3 );
       case 2:
       CommandToClient(%obj.client, 'BottomPrint', "<spush><font:Sui Generis:14>>>>Bunker Buster Cannon<<<<spop>\n<spush><font:Arial:14>Meteor Launcher<spop>", 3, 3 );
       case 3:
       CommandToClient(%obj.client, 'BottomPrint', "<spush><font:Sui Generis:14>>>>Bunker Buster Cannon<<<<spop>\n<spush><font:Arial:14>Proton Collider Bolt<spop>", 3, 3 );
       }
    }

    function BunkerBusterImage::onFire(%data,%obj,%slot){
        if(%obj.Reload) {
        CommandToClient(%obj.client, 'BottomPrint', "<spush><font:Sui Generis:14>>>>Bunker Buster Cannon<<<<spop>\n<spush><font:Arial:14>RECHARGING<spop>", 3, 3 );
        return;
        }
        %vector = %obj.getMuzzleVector(%slot);
        %mp = %obj.getMuzzlePoint(%slot);
        if (%obj.BunbkerBustMode ==  1)
        {
        %obj.Reload = 1;
        schedule(20000,0,"ResetReload", %obj);
        %p = new (GrenadeProjectile)() {
        dataBlock        = VaccumeDrop;
        initialDirection = %vector;
        initialPosition  = %mp;
        sourceObject     = %obj;
        damageFactor     = 1;
        sourceSlot       = %slot;
        };
        MissionCleanup.add(%p);
        }
        else if(%obj.BunbkerBustMode ==  2) {
        %vectorf = vectorScale(%vector, 5);
        %p = new (GrenadeProjectile)() {
        dataBlock        = JTLMeteorStormFireball;
        initialDirection = %vectorf;
        initialPosition  = %mp;
        sourceObject     = %obj;
        damageFactor     = 1;
        sourceSlot       = %slot;
        };
        MissionCleanup.add(%p);
        }
        else if(%obj.BunbkerBustMode ==  3) {
          %p = new (TracerProjectile)() {
             dataBlock = ProtonColliderBolt;
             initialDirection = %obj.getMuzzleVector(%slot);
             initialPosition = %obj.getMuzzlePoint(%slot);
             sourceSlot = %obj.sourceslot;
             sourceobject = %obj;
          };
        }
        else
        %p = Parent::onFire(%data, %obj, %slot);
    }

function ResetReload(%obj) {
   %obj.Reload = 0;
}



datablock ParticleData(VaccumeSuckingParticle)    //A New Cool Looking Emmiter
{
   dragCoefficient      = 4;
   gravityCoefficient   = -0.3;
   inheritedVelFactor   = 0.7;
   constantAcceleration = -4.8;
   lifetimeMS           = 1200;
   lifetimeVarianceMS   = 550;
   textureName          = "special/ELFLightning";
   useInvAlpha          =  false;
   colors[0]     = "1 0.1 0.1 1.0";
   colors[1]     = "0.9 0.1 0.1 1.0";
   colors[2]     = "0.9 0.1 0.1";
   sizes[0]      = 35;
   sizes[1]      = 25;
   sizes[2]      = 15;
   times[0]      = 1.2;
   times[1]      = 1.2;
   times[2]      = 1.2;

};

datablock ParticleEmitterData(VaccumeSuckingEmitter)
{
   lifetimeMS        = 9000;
   ejectionPeriodMS = 3;
   periodVarianceMS = 1;

   ejectionVelocity = 0.1;
   velocityVariance = 0	;
   ejectionoffset = 400;
   phiReferenceVel = "0";
   phiVariance = "360";
   thetaMin         = 0.0;
   thetaMax         = 180.0;
   spinRandomMin = "0";
   spinRandomMax = "0";

   orientParticles  = true;
   orientOnVelocity = true;
   particles = "VaccumeSuckingParticle";
};

function VaccumeDrop::onExplode(%data, %proj, %pos, %mod) {
   %fpos = vectorAdd(%pos,"0 0 100");
   StartSucking(%fpos,0);
   %c = createEmitter(%pos,VaccumeSuckingEmitter,"1 0 0");
   schedule(10000,0,"VacExplode",%proj, %fpos, %c);
}

function VacExplode(%proj, %pos, %e) {
   %c = createEmitter(%pos,BunkerBusterExplosionSmokeEmitter3, "1 0 0");
   %c.schedule(7500, "Delete");
   RadiusExplosion(%proj, %pos, 250, 9000, 1000, %proj.sourceObject, $DamageType::BunkerBuster);
   %e.delete();
}

function StartSucking(%pos, %cnt) {
 if(%cnt > 95) {
 VacExplode(%pos);
 return;
 }
 %cnt ++;
 %TargetSearchMask = $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType;
 InitContainerRadiusSearch(%pos,250,%TargetSearchMask);

   while ((%potentialTarget = ContainerSearchNext()) != 0){
      %dist = containerSearchCurrRadDamageDist();
      %tgtPos = %potentialTarget.getWorldBoxCenter();
      %distance2 =VectorDist(%tgtPos,%pos);
      %distance = mfloor(%distance2);
      %vec = VectorNormalize(VectorSub(%pos,%tgtpos));
      %CN = %potentialTarget.getClassName();
      //echo("CLASS: "@%CN@"");
      if(%CN $= "HoverVehicle") {
         %nForce = -50000;
      }
      else {
         %nForce = -6000;                              //come here =-D
      }
      %forceVector = vectorScale(%vec, -1*%nForce);

      if (%potentialTarget.getPosition() != %pos) {
         %potentialTarget.applyImpulse(%potentialTarget.getPosition(), %forceVector);
         }
    }
    schedule(100,0,"StartSucking",%pos, %cnt);
}
