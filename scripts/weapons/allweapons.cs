//------------------------------------------------------------------------------
// Weapon Sound Effects
//------------------------------------------------------------------------------
datablock EffectProfile(PlasmaSwitchEffect)
{
   effectname = "weapons/plasma_rifle_activate";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(PlasmaFireEffect)
{
   effectname = "weapons/plasma_fire";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(PlasmaDryFireEffect)
{
   effectname = "weapons/plasma_dryfire";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(PlasmaIdleEffect)
{
   effectname = "weapons/plasma_rifle_idle";
   minDistance = 2.5;
};

datablock EffectProfile(PlasmaReloadEffect)
{
   effectname = "weapons/plasma_rifle_reload";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(PlasmaExpEffect)
{
   effectname = "explosions/explosion.xpl10";
   minDistance = 10;
   maxDistance = 25;
};

//--------------------------------------------------------------------------
// Sounds
//--------------------------------------
datablock AudioProfile(PlasmaSwitchSound)
{
   filename    = "fx/weapons/plasma_rifle_activate.wav";
   description = AudioClosest3d;
   preload = true;
   effect = PlasmaSwitchEffect;
};

datablock AudioProfile(PlasmaFireSound)
{
   filename    = "fx/weapons/plasma_rifle_fire.wav";
   description = AudioDefault3d;
   preload = true;
   effect = PlasmaFireEffect;
};

datablock AudioProfile(PlasmaIdleSound)
{
   filename    = "fx/weapons/plasma_rifle_idle.wav";
   description = ClosestLooping3d;
   preload = true;
   //effect = PlasmaIdleEffect;
};

datablock AudioProfile(PlasmaReloadSound)
{
   filename    = "fx/weapons/plasma_rifle_reload.wav";
   description = Audioclosest3d;
   preload = true;
   effect = PlasmaReloadEffect;
};

datablock AudioProfile(plasmaExpSound)
{
   filename    = "fx/explosions/explosion.xpl10.wav";
   description = AudioExplosion3d;
   effect = PlasmaExpEffect;
};

datablock AudioProfile(PlasmaProjectileSound)
{
   filename    = "fx/weapons/plasma_rifle_projectile.WAV";
   description = ProjectileLooping3d;
   preload = true;
};

datablock AudioProfile(PlasmaDryFireSound)
{
   filename    = "fx/weapons/plasma_dryfire.wav";
   description = AudioClose3d;
   preload = true;
   effect = PlasmaDryFireEffect;
};

datablock AudioProfile(PlasmaFireWetSound)
{
   filename    = "fx/weapons/plasma_fizzle.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(BlasterSwitchSound)
{
   filename    = "fx/weapons/blaster_activate.wav";
   description = AudioClosest3d;
   preload = true;
   effect = BlasterSwitchEffect;
};

datablock AudioProfile(BlasterFireSound)
{
   filename    = "fx/weapons/blaster_fire.WAV";
   description = AudioDefault3d;
   preload = true;
   effect = BlasterFireEffect;
};

datablock AudioProfile(BlasterProjectileSound)
{
   filename    = "fx/weapons/blaster_projectile.WAV";
   description = ProjectileLooping3d;
   preload = true;
};

datablock AudioProfile(blasterExpSound)
{
   filename    = "fx/weapons/blaster_impact.WAV";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(BlasterDryFireSound)
{
   filename    = "fx/weapons/chaingun_dryfire.wav";
   description = AudioClose3d;
   preload = true;
};

datablock EffectProfile(BlasterSwitchEffect)
{
   effectname = "weapons/blaster_activate";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(BlasterFireEffect)
{
   effectname = "weapons/blaster_fire";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(ELFGunSwitchEffect)
{
   effectname = "weapons/generic_switch";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(ELFGunFireEffect)
{
   effectname = "weapons/ELF_fire";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(ELFGunFireWetEffect)
{
   effectname = "weapons/ELF_underwater";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock AudioProfile(ELFGunSwitchSound)
{
   filename    = "fx/weapons/generic_switch.wav";
   description = AudioClosest3d;
   preload = true;
   effect = ELFGunSwitchEffect;
};

datablock AudioProfile(ELFGunFireSound)
{
   filename    = "fx/weapons/ELF_fire.wav";
   description = CloseLooping3d;
   preload = true;
   effect = ELFGunFireEffect;
};

datablock AudioProfile(ElfFireWetSound)
{
   filename    = "fx/weapons/ELF_underwater.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(ELFHitTargetSound)
{
   filename    = "fx/weapons/ELF_hit.wav";
   description = CloseLooping3d;
   preload = true;
   effect = ELFGunFireEffect;
};

datablock EffectProfile(GenericSwitchEffect)
{
   effectname = "weapons/generic_switch";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(BasicSwitchEffect)
{
   effectname = "weapons/blaster_activate";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(HeavyFireEffect)
{
   effectname = "weapons/plasma_fire";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(EditorToolFireEffect)
{
   effectname = "weapons/plasma_fire_projectile_hit";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(MergeToolFireEffect)
{
   effectname = "weapons/spinfusor_reload";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(GenericExplosionEffect)
{
   effectname = "explosions/explosion.xpl10";
   minDistance = 10;
   maxDistance = 25;
};

datablock EffectProfile(ChaingunSwitchEffect)
{
   effectname = "weapons/chaingun_activate";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(ChaingunFireEffect)
{
   effectname = "weapons/chaingun_fire";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(ChaingunSpinUpEffect)
{
   effectname = "weapons/chaingun_spinup";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(ChaingunSpinDownEffect)
{
   effectname = "weapons/chaingun_spindown";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(ChaingunDryFire)
{
   effectname = "weapons/chaingun_dryfire";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(GrenadeSwitchEffect)
{
   effectname = "weapons/generic_switch";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(GrenadeFireEffect)
{
   effectname = "weapons/grenadelauncher_fire";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(GrenadeDryFireEffect)
{
   effectname = "weapons/grenadelauncher_dryfire";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(MortarSwitchEffect)
{
   effectname = "weapons/mortar_activate";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(MortarReloadEffect)
{
   effectname = "weapons/mortar_reload";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(MortarDryFireEffect)
{
   effectname = "weapons/mortar_dryfire";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(MortarExplosionEffect)
{
   effectname = "explosions/explosion.xpl03";
   minDistance = 30;
   maxDistance = 65;
};

datablock EffectProfile(MortarFireEffect)
{
   effectname = "weapons/mortar_fire";
   minDistance = 2.5;
   maxDistance = 5.5;
};

//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Weapon Sounds
//------------------------------------------------------------------------------

datablock AudioProfile(GenericSwitchSound)
{
   filename    = "fx/weapons/generic_switch.wav";
   description = AudioClosest3d;
   preload = true;
   effect = GenericSwitchEffect;
};

datablock AudioProfile(BasicSwitchSound)
{
   filename    = "fx/weapons/blaster_activate.wav";
   description = AudioClosest3d;
   preload = true;
   effect = BasicSwitchEffect;
};

datablock AudioProfile(GenericExplosionSound)
{
   filename    = "fx/explosions/explosion.xpl10.wav";
   description = AudioExplosion3d;
   effect = GenericExplosionEffect;
};

datablock AudioProfile(HeavyFireSound)
{
   filename    = "fx/weapons/plasma_rifle_fire.wav";
   description = AudioDefault3d;
   preload = true;
   effect = HeavyFireEffect;
};

datablock AudioProfile(EditorToolFireSound)
{
   filename    = "fx/weapons/plasma_rifle_projectile_hit.wav";
   description = AudioDefault3d;
   preload = true;
   effect = EditorToolFireEffect;
};

datablock AudioProfile(MergeToolFireSound)
{
   filename    = "fx/weapons/spinfusor_reload.wav";
   description = AudioDefault3d;
   preload = true;
   effect = MergeToolFireEffect;
};

datablock AudioProfile(PlasmaProjectileSound)
{
   filename    = "fx/weapons/plasma_rifle_projectile.wav";
   description = ProjectileLooping3d;
   preload = true;
};

datablock AudioProfile(ChaingunSwitchSound)
{
   filename    = "fx/weapons/chaingun_activate.wav";
   description = AudioClosest3d;
   preload = true;
   effect = ChaingunSwitchEffect;
};

datablock AudioProfile(ChaingunFireSound)
{
   filename    = "fx/weapons/chaingun_fire.wav";
   description = AudioDefaultLooping3d;
   preload = true;
   effect = ChaingunFireEffect;
};

datablock AudioProfile(ChaingunProjectile)
{
   filename    = "fx/weapons/chaingun_projectile.wav";
   description = ProjectileLooping3d;
   preload = true;
};

datablock AudioProfile(ChaingunImpact)
{
   filename    = "fx/weapons/chaingun_impact.WAV";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(ChaingunSpinDownSound)
{
   filename    = "fx/weapons/chaingun_spindown.wav";
   description = AudioClosest3d;
   preload = true;
   effect = ChaingunSpinDownEffect;
};

datablock AudioProfile(ChaingunSpinUpSound)
{
   filename    = "fx/weapons/chaingun_spinup.wav";
   description = AudioClosest3d;
   preload = true;
   effect = ChaingunSpinUpEffect;
};

datablock AudioProfile(ChaingunDryFireSound)
{
   filename    = "fx/weapons/chaingun_dryfire.wav";
   description = AudioClose3d;
   preload = true;
   effect = ChaingunDryFire;
};

datablock AudioProfile(GrenadeFireSound)
{
   filename    = "fx/weapons/grenadelauncher_fire.wav";
   description = AudioDefault3d;
   preload = true;
   effect = GrenadeFireEffect;
};

datablock AudioProfile(GrenadeProjectileSound)
{
   filename    = "fx/weapons/grenadelauncher_projectile.wav";
   description = ProjectileLooping3d;
   preload = true;
};

datablock AudioProfile(GrenadeExplosionSound)
{
   filename    = "fx/weapons/grenade_explode.wav";
   description = AudioExplosion3d;
   preload = true;
   effect = GrenadeExplosionEffect;
};

datablock AudioProfile(GrenadeDryFireSound)
{
   filename    = "fx/weapons/grenadelauncher_dryfire.wav";
   description = AudioClose3d;
   preload = true;
   effect = GrenadeDryFireEffect;
};

datablock AudioProfile(MortarSwitchSound)
{
   filename    = "fx/weapons/mortar_activate.wav";
   description = AudioClosest3d;
   preload = true;
   effect = MortarSwitchEffect;
};

datablock AudioProfile(MortarReloadSound)
{
   filename    = "fx/weapons/mortar_reload.wav";
   description = AudioClosest3d;
   preload = true;
   effect = MortarReloadEffect;
};

datablock AudioProfile(MortarProjectileSound)
{
   filename    = "fx/weapons/mortar_projectile.wav";
   description = ProjectileLooping3d;
   preload = true;
};

datablock AudioProfile(MortarExplosionSound)
{
   filename    = "fx/weapons/mortar_explode.wav";
   description = AudioBIGExplosion3d;
   preload = true;
   effect = MortarExplosionEffect;
};

datablock AudioProfile(MortarDryFireSound)
{
   filename    = "fx/weapons/mortar_dryfire.wav";
   description = AudioClose3d;
   preload = true;
   effect = MortarDryFireEffect;
};

datablock AudioProfile(MortarFireSound)
{
   filename    = "fx/weapons/mortar_fire.wav";
   description = AudioDefault3d;
   preload = true;
   effect = MortarFireEffect;
};

//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Weapon Splash Particles
//------------------------------------------------------------------------------
datablock ParticleData(ELFSparks)
{
   dragCoefficient      = 1;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 200;
   lifetimeVarianceMS   = 0;
   textureName          = "special/blueSpark";
   colors[0]     = "0.8 0.8 1.0 1.0";
   colors[1]     = "0.8 0.8 1.0 1.0";
   colors[2]     = "0.8 0.8 1.0 0.0";
   sizes[0]      = 0.35;
   sizes[1]      = 0.15;
   sizes[2]      = 0.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(ELFSparksEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;
   ejectionVelocity = 4;
   velocityVariance = 2;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 180;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
//   lifetimeMS       = 100;
   particles = "ELFSparks";
};

datablock ParticleData( BlasterSplashParticle )
{
   dragCoefficient      = 1;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = -1.4;
   lifetimeMS           = 300;
   lifetimeVarianceMS   = 0;
   textureName          = "special/droplet";
   colors[0]     = "0.7 0.8 1.0 1.0";
   colors[1]     = "0.7 0.8 1.0 0.5";
   colors[2]     = "0.7 0.8 1.0 0.0";
   sizes[0]      = 0.05;
   sizes[1]      = 0.2;
   sizes[2]      = 0.2;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData( BlasterSplashEmitter )
{
   ejectionPeriodMS = 4;
   periodVarianceMS = 0;
   ejectionVelocity = 4;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 50;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 100;
   particles = "BlasterSplashParticle";
};

datablock SplashData(BlasterSplash)
{
   numSegments = 15;
   ejectionFreq = 15;
   ejectionAngle = 40;
   ringLifetime = 0.35;
   lifetimeMS = 300;
   velocity = 3.0;
   startRadius = 0.0;
   acceleration = -3.0;
   texWrap = 5.0;

   texture = "special/water2";

   emitter[0] = BlasterSplashEmitter;

   colors[0] = "0.7 0.8 1.0 1.0";
   colors[1] = "0.7 0.8 1.0 1.0";
   colors[2] = "0.7 0.8 1.0 0.0";
   colors[3] = "0.7 0.8 1.0 0.0";
   times[0] = 0.0;
   times[1] = 0.4;
   times[2] = 0.8;
   times[3] = 1.0;
};

datablock ParticleData( ChaingunSplashParticle )
{
   dragCoefficient      = 1;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = -1.4;
   lifetimeMS           = 300;
   lifetimeVarianceMS   = 0;
   textureName          = "special/droplet";
   colors[0]     = "0.7 0.8 1.0 1.0";
   colors[1]     = "0.7 0.8 1.0 0.5";
   colors[2]     = "0.7 0.8 1.0 0.0";
   sizes[0]      = 0.05;
   sizes[1]      = 0.2;
   sizes[2]      = 0.2;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData( ChaingunSplashEmitter )
{
   ejectionPeriodMS = 4;
   periodVarianceMS = 0;
   ejectionVelocity = 3;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 50;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 100;
   particles = "ChaingunSplashParticle";
};


datablock SplashData(ChaingunSplash)
{
   numSegments = 10;
   ejectionFreq = 10;
   ejectionAngle = 20;
   ringLifetime = 0.4;
   lifetimeMS = 400;
   velocity = 3.0;
   startRadius = 0.0;
   acceleration = -3.0;
   texWrap = 5.0;

   texture = "special/water2";

   emitter[0] = ChaingunSplashEmitter;

   colors[0] = "0.7 0.8 1.0 0.0";
   colors[1] = "0.7 0.8 1.0 1.0";
   colors[2] = "0.7 0.8 1.0 0.0";
   colors[3] = "0.7 0.8 1.0 0.0";
   times[0] = 0.0;
   times[1] = 0.4;
   times[2] = 0.8;
   times[3] = 1.0;
};

//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Explosion Data
//------------------------------------------------------------------------------

datablock ExplosionData(PlasmaBoltExplosion)
{
   explosionShape = "effect_plasma_explosion.dts";
   soundProfile   = GenericExplosionSound;
   particleDensity = 150;
   particleRadius = 0.02;
   faceViewer = true;

   sizes[0] = "0.5 0.5 0.5";
   sizes[1] = "1.0 1.0 1.0";
   times[0] = 0.0;
   times[1] = 1.5;
};

datablock ParticleData(ChaingunExplosionParticle1)
{
   dragCoefficient      = 0.65;
   gravityCoefficient   = 0.3;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 500;
   lifetimeVarianceMS   = 150;
   textureName          = "particleTest";
   colors[0]     = "0.56 0.36 0.26 1.0";
   colors[1]     = "0.56 0.36 0.26 0.0";
   sizes[0]      = 0.0625;
   sizes[1]      = 0.2;
};

datablock ParticleEmitterData(ChaingunExplosionEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;
   ejectionVelocity = 0.75;
   velocityVariance = 0.25;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 60;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "ChaingunExplosionParticle1";
};

datablock ParticleData(ChaingunImpactSmokeParticle)
{
   dragCoefficient      = 0.0;
   gravityCoefficient   = -0.2;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 1000;
   lifetimeVarianceMS   = 200;
   useInvAlpha          = true;
   spinRandomMin        = -90.0;
   spinRandomMax        = 90.0;
   textureName          = "particleTest";
   colors[0]     = "0.7 0.7 0.7 0.0";
   colors[1]     = "0.7 0.7 0.7 0.4";
   colors[2]     = "0.7 0.7 0.7 0.0";
   sizes[0]      = 0.5;
   sizes[1]      = 0.5;
   sizes[2]      = 1.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(ChaingunImpactSmoke)
{
   ejectionPeriodMS = 8;
   periodVarianceMS = 1;
   ejectionVelocity = 1.0;
   velocityVariance = 0.5;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 35;
   overrideAdvances = false;
   particles = "ChaingunImpactSmokeParticle";
   lifetimeMS       = 50;
};


datablock ParticleData(ChaingunSparks)
{
   dragCoefficient      = 1;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 300;
   lifetimeVarianceMS   = 0;
   textureName          = "special/spark00";
   colors[0]     = "0.56 0.36 0.26 1.0";
   colors[1]     = "0.56 0.36 0.26 1.0";
   colors[2]     = "1.0 0.36 0.26 0.0";
   sizes[0]      = 0.6;
   sizes[1]      = 0.2;
   sizes[2]      = 0.05;
   times[0]      = 0.0;
   times[1]      = 0.2;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(ChaingunSparkEmitter)
{
   ejectionPeriodMS = 4;
   periodVarianceMS = 0;
   ejectionVelocity = 4;
   velocityVariance = 2.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 50;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 100;
   particles = "ChaingunSparks";
};


datablock ExplosionData(ChaingunExplosion)
{
   soundProfile   = ChaingunImpact;

   emitter[0] = ChaingunImpactSmoke;
   emitter[1] = ChaingunSparkEmitter;

   faceViewer           = false;
};

//--------------------------------------------------------------------------
//MISC
//--------------------------------------------------------------------------

datablock ParticleData(PlasmaRifleParticle)
{
   dragCoefficient      = 2.75;
   gravityCoefficient   = 0.1;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 550;
   lifetimeVarianceMS   = 0;
   textureName          = "particleTest";
   colors[0]     = "0.46 0.36 0.26 1.0";
   colors[1]     = "0.46 0.36 0.26 0.0";
   sizes[0]      = 0.25;
   sizes[1]      = 0.20;
};

datablock ParticleEmitterData(PlasmaRifleEmitter)
{
   ejectionPeriodMS = 3;
   periodVarianceMS = 0;
   ejectionVelocity = 10;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 12;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvance  = true;
   particles = "PlasmaRifleParticle";
};

datablock ParticleData(ChaingunFireParticle)
{
   dragCoefficient      = 2.75;
   gravityCoefficient   = 0.1;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 550;
   lifetimeVarianceMS   = 0;
   textureName          = "particleTest";
   colors[0]     = "0.46 0.36 0.26 1.0";
   colors[1]     = "0.46 0.36 0.26 0.0";
   sizes[0]      = 0.25;
   sizes[1]      = 0.20;
};

datablock ParticleEmitterData(ChaingunFireEmitter)
{
   ejectionPeriodMS = 6;
   periodVarianceMS = 0;
   ejectionVelocity = 10;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 12;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvance  = true;
   particles = "ChaingunFireParticle";
};

datablock ExplosionData(DiscExplosion)
{
   explosionShape = "disc_explosion.dts";
   soundProfile   = discExpSound;

   faceViewer     = true;
   explosionScale = "1 1 1";

   shakeCamera = true;
   camShakeFreq = "10.0 11.0 10.0";
   camShakeAmp = "20.0 20.0 20.0";
   camShakeDuration = 0.5;
   camShakeRadius = 10.0;

   sizes[0] = "1.0 1.0 1.0";
   sizes[1] = "1.0 1.0 1.0";
   times[0] = 0.0;
   times[1] = 1.0;
};

datablock ParticleData(GrenadeExplosionBubbleParticle)
{
   dragCoefficient      = 0.0;
   gravityCoefficient   = -0.25;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 1500;
   lifetimeVarianceMS   = 600;
   useInvAlpha          = false;
   textureName          = "special/bubbles";

   spinRandomMin        = -100.0;
   spinRandomMax        =  100.0;

   colors[0]     = "0.7 0.8 1.0 0.0";
   colors[1]     = "0.7 0.8 1.0 0.4";
   colors[2]     = "0.7 0.8 1.0 0.0";
   sizes[0]      = 1.0;
   sizes[1]      = 1.0;
   sizes[2]      = 1.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(GrenadeExplosionBubbleEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;
   ejectionVelocity = 1.0;
   ejectionOffset   = 3.0;
   velocityVariance = 0.5;
   thetaMin         = 0;
   thetaMax         = 80;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "GrenadeExplosionBubbleParticle";
};

datablock ParticleData(UnderwaterGrenadeDust)
{
   dragCoefficient      = 1.0;
   gravityCoefficient   = -0.01;
   inheritedVelFactor   = 0.0;
   constantAcceleration = -1.1;
   lifetimeMS           = 1000;
   lifetimeVarianceMS   = 100;
   useInvAlpha          = false;
   spinRandomMin        = -90.0;
   spinRandomMax        = 500.0;
   textureName          = "particleTest";
   colors[0]     = "0.6 0.6 1.0 0.5";
   colors[1]     = "0.6 0.6 1.0 0.5";
   colors[2]     = "0.6 0.6 1.0 0.0";
   sizes[0]      = 3.0;
   sizes[1]      = 3.0;
   sizes[2]      = 3.0;
   times[0]      = 0.0;
   times[1]      = 0.7;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(UnderwaterGrenadeDustEmitter)
{
   ejectionPeriodMS = 15;
   periodVarianceMS = 0;
   ejectionVelocity = 15.0;
   velocityVariance = 0.0;
   ejectionOffset   = 0.0;
   thetaMin         = 70;
   thetaMax         = 70;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   lifetimeMS       = 250;
   particles = "UnderwaterGrenadeDust";
};

datablock ParticleData(UnderwaterGrenadeExplosionSmoke)
{
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = -0.25;   // rises slowly
   inheritedVelFactor   = 0.025;
   constantAcceleration = -1.1;

   lifetimeMS           = 1250;
   lifetimeVarianceMS   = 0;

   textureName          = "particleTest";

   useInvAlpha =  false;
   spinRandomMin = -200.0;
   spinRandomMax =  200.0;

   textureName = "special/Smoke/smoke_001";

   colors[0]     = "0.1 0.1 1.0 1.0";
   colors[1]     = "0.4 0.4 1.0 1.0";
   colors[2]     = "0.4 0.4 1.0 0.0";
   sizes[0]      = 2.0;
   sizes[1]      = 6.0;
   sizes[2]      = 2.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(UnderwaterGExplosionSmokeEmitter)
{
   ejectionPeriodMS = 15;
   periodVarianceMS = 0;

   ejectionVelocity = 6.25;
   velocityVariance = 0.25;

   thetaMin         = 0.0;
   thetaMax         = 90.0;

   lifetimeMS       = 250;

   particles = "UnderwaterGrenadeExplosionSmoke";
};

datablock ParticleData(UnderwaterGrenadeSparks)
{
   dragCoefficient      = 1;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 500;
   lifetimeVarianceMS   = 350;
   textureName          = "special/underwaterSpark";
   colors[0]     = "0.6 0.6 1.0 1.0";
   colors[1]     = "0.6 0.6 1.0 1.0";
   colors[2]     = "0.6 0.6 1.0 0.0";
   sizes[0]      = 0.5;
   sizes[1]      = 0.5;
   sizes[2]      = 0.75;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(UnderwaterGrenadeSparksEmitter)
{
   ejectionPeriodMS = 2;
   periodVarianceMS = 0;
   ejectionVelocity = 12;
   velocityVariance = 6.75;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 60;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 100;
   particles = "UnderwaterGrenadeSparks";
};

datablock ExplosionData(UnderwaterGrenadeExplosion)
{
   soundProfile   = UnderwaterGrenadeExplosionSound;

   faceViewer           = true;
   explosionScale = "0.8 0.8 0.8";

   emitter[0] = UnderwaterGrenadeDustEmitter;
   emitter[1] = UnderwaterGExplosionSmokeEmitter;
   emitter[2] = UnderwaterGrenadeSparksEmitter;
   emitter[3] = GrenadeExplosionBubbleEmitter;
   
   shakeCamera = true;
   camShakeFreq = "10.0 6.0 9.0";
   camShakeAmp = "20.0 20.0 20.0";
   camShakeDuration = 0.5;
   camShakeRadius = 20.0;
};

datablock ParticleData(GrenadeBubbleParticle)
{
   dragCoefficient      = 0.0;
   gravityCoefficient   = -0.25;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 1500;
   lifetimeVarianceMS   = 600;
   useInvAlpha          = false;
   textureName          = "special/bubbles";

   spinRandomMin        = -100.0;
   spinRandomMax        =  100.0;

   colors[0]     = "0.7 0.8 1.0 0.4";
   colors[1]     = "0.7 0.8 1.0 0.4";
   colors[2]     = "0.7 0.8 1.0 0.0";
   sizes[0]      = 0.5;
   sizes[1]      = 0.5;
   sizes[2]      = 0.5;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(GrenadeBubbleEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;
   ejectionVelocity = 1.0;
   ejectionOffset   = 0.1;
   velocityVariance = 0.5;
   thetaMin         = 0;
   thetaMax         = 80;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "GrenadeBubbleParticle";
};

datablock ParticleData( GDebrisSmokeParticle )
{
   dragCoeffiecient     = 1.0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;

   lifetimeMS           = 1000;  
   lifetimeVarianceMS   = 100;

   textureName          = "particleTest";

   useInvAlpha =     true;

   spinRandomMin = -60.0;
   spinRandomMax = 60.0;

   colors[0]     = "0.4 0.4 0.4 1.0";
   colors[1]     = "0.3 0.3 0.3 0.5";
   colors[2]     = "0.0 0.0 0.0 0.0";
   sizes[0]      = 0.0;
   sizes[1]      = 1.0;
   sizes[2]      = 1.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData( GDebrisSmokeEmitter )
{
   ejectionPeriodMS = 7;
   periodVarianceMS = 1;

   ejectionVelocity = 1.0;
   velocityVariance = 0.2;

   thetaMin         = 0.0;
   thetaMax         = 40.0;

   particles = "GDebrisSmokeParticle";
};


datablock DebrisData( GrenadeDebris )
{
   emitters[0] = GDebrisSmokeEmitter;

   explodeOnMaxBounce = true;

   elasticity = 0.4;
   friction = 0.2;

   lifetime = 0.3;
   lifetimeVariance = 0.02;

   numBounces = 1;
};             

datablock ParticleData( GrenadeSplashParticle )
{
   dragCoefficient      = 1;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = -1.4;
   lifetimeMS           = 300;
   lifetimeVarianceMS   = 0;
   textureName          = "special/droplet";
   colors[0]     = "0.7 0.8 1.0 1.0";
   colors[1]     = "0.7 0.8 1.0 0.5";
   colors[2]     = "0.7 0.8 1.0 0.0";
   sizes[0]      = 0.05;
   sizes[1]      = 0.2;
   sizes[2]      = 0.2;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData( GrenadeSplashEmitter )
{
   ejectionPeriodMS = 4;
   periodVarianceMS = 0;
   ejectionVelocity = 4;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 50;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 100;
   particles = "BlasterSplashParticle";
};


datablock SplashData(GrenadeSplash)
{
   numSegments = 15;
   ejectionFreq = 15;
   ejectionAngle = 40;
   ringLifetime = 0.35;
   lifetimeMS = 300;
   velocity = 3.0;
   startRadius = 0.0;
   acceleration = -3.0;
   texWrap = 5.0;

   texture = "special/water2";

   emitter[0] = BlasterSplashEmitter;

   colors[0] = "0.7 0.8 1.0 1.0";
   colors[1] = "0.7 0.8 1.0 1.0";
   colors[2] = "0.7 0.8 1.0 1.0";
   colors[3] = "0.7 0.8 1.0 1.0";
   times[0] = 0.0;
   times[1] = 0.4;
   times[2] = 0.8;
   times[3] = 1.0;
};

datablock ParticleData(GrenadeSmokeParticle)
{
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = -0.2;   // rises slowly
   inheritedVelFactor   = 0.00;

   lifetimeMS           = 700;  // lasts 2 second
   lifetimeVarianceMS   = 150;   // ...more or less

   textureName          = "particleTest";

   useInvAlpha = true;
   spinRandomMin = -30.0;
   spinRandomMax = 30.0;

   colors[0]     = "0.9 0.9 0.9 1.0";
   colors[1]     = "0.6 0.6 0.6 1.0";
   colors[2]     = "0.4 0.4 0.4 0.0";

   sizes[0]      = 0.25;
   sizes[1]      = 1.0;
   sizes[2]      = 3.0;

   times[0]      = 0.0;
   times[1]      = 0.2;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(GrenadeSmokeEmitter)
{
   ejectionPeriodMS = 15;
   periodVarianceMS = 5;

   ejectionVelocity = 1.25;
   velocityVariance = 0.50;

   thetaMin         = 0.0;
   thetaMax         = 90.0;  

   particles = "GrenadeSmokeParticle";
};

datablock ParticleData(GrenadeDust)
{
   dragCoefficient      = 1.0;
   gravityCoefficient   = -0.01;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 1000;
   lifetimeVarianceMS   = 100;
   useInvAlpha          = true;
   spinRandomMin        = -90.0;
   spinRandomMax        = 500.0;
   textureName          = "particleTest";
   colors[0]     = "0.3 0.3 0.3 0.5";
   colors[1]     = "0.3 0.3 0.3 0.5";
   colors[2]     = "0.3 0.3 0.3 0.0";
   sizes[0]      = 3.2;
   sizes[1]      = 4.6;
   sizes[2]      = 5.0;
   times[0]      = 0.0;
   times[1]      = 0.7;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(GrenadeDustEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;
   ejectionVelocity = 15.0;
   velocityVariance = 0.0;
   ejectionOffset   = 0.0;
   thetaMin         = 85;
   thetaMax         = 85;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   lifetimeMS       = 250;
   particles = "GrenadeDust";
};


datablock ParticleData(GrenadeExplosionSmoke)
{
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = -0.5;
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 1250;
   lifetimeVarianceMS   = 0;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -200.0;
   spinRandomMax =  200.0;

   textureName = "special/Smoke/smoke_001";

   colors[0]     = "0.7 0.7 0.7 1.0";
   colors[1]     = "0.2 0.2 0.2 1.0";
   colors[2]     = "0.1 0.1 0.1 0.0";
   sizes[0]      = 2.0;
   sizes[1]      = 6.0;
   sizes[2]      = 2.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(GExplosionSmokeEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;

   ejectionVelocity = 6.25;
   velocityVariance = 0.25;

   thetaMin         = 0.0;
   thetaMax         = 90.0;

   lifetimeMS       = 250;

   particles = "GrenadeExplosionSmoke";
};

datablock ParticleData(GrenadeSparks)
{
   dragCoefficient      = 1;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 500;
   lifetimeVarianceMS   = 350;
   textureName          = "special/bigspark";
   colors[0]     = "0.56 0.36 0.26 1.0";
   colors[1]     = "0.56 0.36 0.26 1.0";
   colors[2]     = "1.0 0.36 0.26 0.0";
   sizes[0]      = 0.5;
   sizes[1]      = 0.5;
   sizes[2]      = 0.75;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(GrenadeSparksEmitter)
{
   ejectionPeriodMS = 2;
   periodVarianceMS = 0;
   ejectionVelocity = 12;
   velocityVariance = 6.75;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 60;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 100;
   particles = "GrenadeSparks";
};

datablock ExplosionData(GrenadeExplosion)
{
   soundProfile   = GrenadeExplosionSound;

   faceViewer           = true;
   explosionScale = "0.8 0.8 0.8";

   debris = GrenadeDebris;
   debrisThetaMin = 10;
   debrisThetaMax = 50;
   debrisNum = 8;
   debrisVelocity = 26.0;
   debrisVelocityVariance = 7.0;

   emitter[0] = GrenadeDustEmitter;
   emitter[1] = GExplosionSmokeEmitter;
   emitter[2] = GrenadeSparksEmitter;

   shakeCamera = true;
   camShakeFreq = "10.0 6.0 9.0";
   camShakeAmp = "20.0 20.0 20.0";
   camShakeDuration = 0.5;
   camShakeRadius = 20.0;
};

datablock ParticleData(MortarBubbleParticle)
{
   dragCoefficient      = 0.0;
   gravityCoefficient   = -0.25;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 1500;
   lifetimeVarianceMS   = 600;
   useInvAlpha          = false;
   textureName          = "special/bubbles";

   spinRandomMin        = -100.0;
   spinRandomMax        =  100.0;

   colors[0]     = "0.7 0.8 1.0 0.4";
   colors[1]     = "0.7 0.8 1.0 0.4";
   colors[2]     = "0.7 0.8 1.0 0.0";
   sizes[0]      = 0.8;
   sizes[1]      = 0.8;
   sizes[2]      = 0.8;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(MortarBubbleEmitter)
{
   ejectionPeriodMS = 9;
   periodVarianceMS = 0;
   ejectionVelocity = 1.0;
   ejectionOffset   = 0.1;
   velocityVariance = 0.5;
   thetaMin         = 0;
   thetaMax         = 80;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "MortarBubbleParticle";
};

datablock ParticleData( MortarSplashParticle )
{
   dragCoefficient      = 1;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = -1.4;
   lifetimeMS           = 300;
   lifetimeVarianceMS   = 0;
   textureName          = "special/droplet";
   colors[0]     = "0.7 0.8 1.0 1.0";
   colors[1]     = "0.7 0.8 1.0 0.5";
   colors[2]     = "0.7 0.8 1.0 0.0";
   sizes[0]      = 0.05;
   sizes[1]      = 0.2;
   sizes[2]      = 0.2;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData( MortarSplashEmitter )
{
   ejectionPeriodMS = 4;
   periodVarianceMS = 0;
   ejectionVelocity = 3;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 50;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 100;
   particles = "MortarSplashParticle";
};


datablock SplashData(MortarSplash)
{
   numSegments = 10;
   ejectionFreq = 10;
   ejectionAngle = 20;
   ringLifetime = 0.4;
   lifetimeMS = 400;
   velocity = 3.0;
   startRadius = 0.0;
   acceleration = -3.0;
   texWrap = 5.0;

   texture = "special/water2";

   emitter[0] = MortarSplashEmitter;

   colors[0] = "0.7 0.8 1.0 0.0";
   colors[1] = "0.7 0.8 1.0 1.0";
   colors[2] = "0.7 0.8 1.0 0.0";
   colors[3] = "0.7 0.8 1.0 0.0";
   times[0] = 0.0;
   times[1] = 0.4;
   times[2] = 0.8;
   times[3] = 1.0;
};

datablock ShockwaveData(UnderwaterMortarShockwave)
{
   width = 6.0;
   numSegments = 32;
   numVertSegments = 6;
   velocity = 10;
   acceleration = 20.0;
   lifetimeMS = 900;
   height = 1.0;
   verticalCurve = 0.5;
   is2D = false;

   texture[0] = "special/shockwave4";
   texture[1] = "special/gradient";
   texWrap = 6.0;

   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;

   colors[0] = "0.4 0.4 1.0 0.50";
   colors[1] = "0.4 0.4 1.0 0.25";
   colors[2] = "0.4 0.4 1.0 0.0";

   mapToTerrain = true;
   orientToNormal = false;
   renderBottom = false;
};

datablock ShockwaveData(MortarShockwave)
{
   width = 6.0;
   numSegments = 32;
   numVertSegments = 6;
   velocity = 15;
   acceleration = 20.0;
   lifetimeMS = 500;
   height = 1.0;
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

datablock ParticleData( MortarCrescentParticle )
{
   dragCoefficient      = 2;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = -0.0;
   lifetimeMS           = 600;
   lifetimeVarianceMS   = 000;
   textureName          = "special/crescent3";
   colors[0]     = "0.7 1.0 0.7 1.0";
   colors[1]     = "0.7 1.0 0.7 0.5";
   colors[2]     = "0.7 1.0 0.7 0.0";
   sizes[0]      = 4.0;
   sizes[1]      = 8.0;
   sizes[2]      = 9.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData( MortarCrescentEmitter )
{
   ejectionPeriodMS = 25;
   periodVarianceMS = 0;
   ejectionVelocity = 40;
   velocityVariance = 5.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 80;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 200;
   particles = "MortarCrescentParticle";
};


datablock ParticleData(MortarExplosionSmoke)
{
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = -0.30;   // rises slowly
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 1250;
   lifetimeVarianceMS   = 500;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -100.0;
   spinRandomMax =  100.0;

   textureName = "special/Smoke/bigSmoke";

   colors[0]     = "0.7 0.7 0.7 0.0";
   colors[1]     = "0.4 0.4 0.4 0.5";
   colors[2]     = "0.4 0.4 0.4 0.5";
   colors[3]     = "0.4 0.4 0.4 0.0";
   sizes[0]      = 5.0;
   sizes[1]      = 6.0;
   sizes[2]      = 10.0;
   sizes[3]      = 12.0;
   times[0]      = 0.0;
   times[1]      = 0.333;
   times[2]      = 0.666;
   times[3]      = 1.0;

};

datablock ParticleEmitterData(MortarExplosionSmokeEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;

   ejectionOffset = 8.0;


   ejectionVelocity = 1.25;
   velocityVariance = 1.2;

   thetaMin         = 0.0;
   thetaMax         = 90.0;

   lifetimeMS       = 500;

   particles = "MortarExplosionSmoke";

};

datablock ParticleData(UnderwaterExplosionSparks)
{
   dragCoefficient      = 0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 500;
   lifetimeVarianceMS   = 350;
   textureName          = "special/crescent3";
   colors[0]     = "0.4 0.4 1.0 1.0";
   colors[1]     = "0.4 0.4 1.0 1.0";
   colors[2]     = "0.4 0.4 1.0 0.0";
   sizes[0]      = 3.5;
   sizes[1]      = 3.5;
   sizes[2]      = 3.5;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(UnderwaterExplosionSparksEmitter)
{
   ejectionPeriodMS = 2;
   periodVarianceMS = 0;
   ejectionVelocity = 17;
   velocityVariance = 4;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 60;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 100;
   particles = "UnderwaterExplosionSparks";
};

datablock ParticleData(MortarExplosionBubbleParticle)
{
   dragCoefficient      = 0.0;
   gravityCoefficient   = -0.25;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 1500;
   lifetimeVarianceMS   = 600;
   useInvAlpha          = false;
   textureName          = "special/bubbles";

   spinRandomMin        = -100.0;
   spinRandomMax        =  100.0;

   colors[0]     = "0.7 0.8 1.0 0.0";
   colors[1]     = "0.7 0.8 1.0 0.4";
   colors[2]     = "0.7 0.8 1.0 0.0";
   sizes[0]      = 2.0;
   sizes[1]      = 2.0;
   sizes[2]      = 2.0;
   times[0]      = 0.0;
   times[1]      = 0.8;
   times[2]      = 1.0;
};
datablock ParticleEmitterData(MortarExplosionBubbleEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;
   ejectionVelocity = 1.0;
   ejectionOffset   = 7.0;
   velocityVariance = 0.5;
   thetaMin         = 0;
   thetaMax         = 80;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "MortarExplosionBubbleParticle";
};

datablock DebrisData( UnderwaterMortarDebris )
{
   emitters[0] = MortarExplosionBubbleEmitter;

   explodeOnMaxBounce = true;

   elasticity = 0.4;
   friction = 0.2;

   lifetime = 1.5;
   lifetimeVariance = 0.2;

   numBounces = 1;
};

datablock ExplosionData(UnderwaterMortarSubExplosion1)
{
   explosionShape = "disc_explosion.dts";
   faceViewer           = true;
   delayMS = 100;
   offset = 3.0;
   playSpeed = 1.5;

   sizes[0] = "0.75 0.75 0.75";
   sizes[1] = "1.0  1.0  1.0";
   sizes[2] = "0.5 0.5 0.5";
   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;

};

datablock ExplosionData(UnderwaterMortarSubExplosion2)
{
   explosionShape = "disc_explosion.dts";
   faceViewer           = true;
   delayMS = 50;
   offset = 3.0;
   playSpeed = 0.75;

   sizes[0] = "1.5 1.5 1.5";
   sizes[1] = "1.5 1.5 1.5";
   sizes[2] = "1.0 1.0 1.0";
   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;
};

datablock ExplosionData(UnderwaterMortarSubExplosion3)
{
   explosionShape = "disc_explosion.dts";
   faceViewer           = true;
   delayMS = 0;
   offset = 0.0;
   playSpeed = 0.5;

   sizes[0] = "1.0 1.0 1.0";
   sizes[1] = "2.0 2.0 2.0";
   sizes[2] = "1.5 1.5 1.5";
   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;

};

datablock ExplosionData(UnderwaterMortarExplosion)
{
   soundProfile   = UnderwaterMortarExplosionSound;

   shockwave = UnderwaterMortarShockwave;
   shockwaveOnTerrain = true;

   subExplosion[0] = UnderwaterMortarSubExplosion1;
   subExplosion[1] = UnderwaterMortarSubExplosion2;
   subExplosion[2] = UnderwaterMortarSubExplosion3;

   emitter[0] = MortarExplosionBubbleEmitter;
   emitter[1] = UnderwaterExplosionSparksEmitter;

   shakeCamera = true;
   camShakeFreq = "8.0 9.0 7.0";
   camShakeAmp = "100.0 100.0 100.0";
   camShakeDuration = 1.3;
   camShakeRadius = 25.0;
};

datablock ExplosionData(MortarSubExplosion1)
{
   explosionShape = "mortar_explosion.dts";
   faceViewer           = true;

   delayMS = 100;

   offset = 5.0;

   playSpeed = 1.5;

   sizes[0] = "0.5 0.5 0.5";
   sizes[1] = "0.5 0.5 0.5";
   times[0] = 0.0;
   times[1] = 1.0;

};

datablock ExplosionData(MortarSubExplosion2)
{
   explosionShape = "mortar_explosion.dts";
   faceViewer           = true;

   delayMS = 50;

   offset = 5.0;

   playSpeed = 1.0;

   sizes[0] = "1.0 1.0 1.0";
   sizes[1] = "1.0 1.0 1.0";
   times[0] = 0.0;
   times[1] = 1.0;
};

datablock ExplosionData(MortarSubExplosion3)
{
   explosionShape = "mortar_explosion.dts";
   faceViewer           = true;
   delayMS = 0;
   offset = 0.0;
   playSpeed = 0.7;

   sizes[0] = "1.0 1.0 1.0";
   sizes[1] = "2.0 2.0 2.0";
   times[0] = 0.0;
   times[1] = 1.0;

};

datablock ExplosionData(MortarExplosion)
{
   soundProfile   = MortarExplosionSound;

   shockwave = MortarShockwave;
   shockwaveOnTerrain = true;

   subExplosion[0] = MortarSubExplosion1;
   subExplosion[1] = MortarSubExplosion2;
   subExplosion[2] = MortarSubExplosion3;

   emitter[0] = MortarExplosionSmokeEmitter;
   emitter[1] = MortarCrescentEmitter;

   shakeCamera = true;
   camShakeFreq = "8.0 9.0 7.0";
   camShakeAmp = "100.0 100.0 100.0";
   camShakeDuration = 1.3;
   camShakeRadius = 25.0;
};

datablock ParticleData(MortarSmokeParticle)
{
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = -0.3;   // rises slowly
   inheritedVelFactor   = 0.125;

   lifetimeMS           =  1200;
   lifetimeVarianceMS   =  200;
   useInvAlpha          =  true;
   spinRandomMin        = -100.0;
   spinRandomMax        =  100.0;

   animateTexture = false;

   textureName = "special/Smoke/bigSmoke";

   colors[0]     = "0.7 1.0 0.7 0.5";
   colors[1]     = "0.3 0.7 0.3 0.8";
   colors[2]     = "0.0 0.0 0.0 0.0";
   sizes[0]      = 1.0;
   sizes[1]      = 2.0;
   sizes[2]      = 4.5;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(MortarSmokeEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 3;

   ejectionVelocity = 2.25;
   velocityVariance = 0.55;

   thetaMin         = 0.0;
   thetaMax         = 40.0;

   particles = "MortarSmokeParticle";
};

//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Projectile Data
//------------------------------------------------------------------------------

datablock TracerProjectileData(ChaingunBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.0825;
   directDamageType    = $DamageType::Bullet;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;

   kickBackStrength  = 0.0;
   sound 				= ChaingunProjectile;

   dryVelocity       = 425.0;
   wetVelocity       = 100.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 15.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.10;
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

datablock GrenadeProjectileData(BasicGrenade)
{
   projectileShapeName = "grenade_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.40;
   damageRadius        = 15.0;
   radiusDamageType    = $DamageType::Grenade;
   kickBackStrength    = 1500;
   bubbleEmitTime      = 1.0;

   sound               = GrenadeProjectileSound;
   explosion           = "GrenadeExplosion";
   underwaterExplosion = "UnderwaterGrenadeExplosion";
   velInheritFactor    = 0.5;
   splash              = GrenadeSplash;

   baseEmitter         = GrenadeSmokeEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;

   grenadeElasticity = 0.35;
   grenadeFriction   = 0.2;
   armingDelayMS     = 1000;
   muzzleVelocity    = 47.00;
   drag = 0.1;
};

//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Ammo Data
//------------------------------------------------------------------------------

datablock ItemData(PlasmaAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_plasma.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some plasma gun ammo";
};

datablock ItemData(ChaingunAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some chaingun ammo";

   computeCRC = true;

};

datablock ItemData(DiscAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_disc.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "some spinfusor discs";
};

datablock ItemData(GrenadeLauncherAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_grenade.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "some grenade launcher ammo";

   computeCRC = true;
   emap = true;
};

datablock ItemData(MortarAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_mortar.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "some mortar ammo";

   computeCRC = true;
};

datablock DebrisData( ShellDebris )
{
   shapeName = "weapon_chaingun_ammocasing.dts";

   lifetime = 10.0;

   minSpinSpeed = 200.0;
   maxSpinSpeed = 800.0;

   elasticity = 0.5;
   friction = 0.2;

   numBounces = 4;

   fade = true;
   staticOnMaxBounce = true;
   snapOnMaxBounce = true;
};

datablock DecalData(ChaingunDecal1)
{
   sizeX       = 0.05;
   sizeY       = 0.05;
   textureName = "special/bullethole1";
};

datablock DecalData(ChaingunDecal2)
{
   sizeX       = 0.05;
   sizeY       = 0.05;
   textureName = "special/bullethole2";
};

datablock DecalData(ChaingunDecal3)
{
   sizeX       = 0.05;
   sizeY       = 0.05;
   textureName = "special/bullethole3";
};

datablock DecalData(ChaingunDecal4)
{
   sizeX       = 0.05;
   sizeY       = 0.05;
   textureName = "special/bullethole4";
};

datablock DecalData(ChaingunDecal5)
{
   sizeX       = 0.05;
   sizeY       = 0.05;
   textureName = "special/bullethole5";
};

datablock DecalData(ChaingunDecal6)
{
   sizeX       = 0.05;
   sizeY       = 0.05;
   textureName = "special/bullethole6";
};
