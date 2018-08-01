
datablock ParticleData(IncindinaryGroundBurnParticle)
{
   dragCoefficient      = 2;
   gravityCoefficient   = -0.4;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 3000;
   lifetimeVarianceMS   = 0;
   textureName          = "special/cloudflash3.png";
   colors[0]     = "1 0.18 0.03 0.6";
   colors[1]     = "1 0.18 0.03 0.0";
   sizes[0]      = 6;
   sizes[1]      = 6.75;
};

datablock ParticleEmitterData(IncindinaryGroundBurnEmitter)
{
   ejectionPeriodMS = 4;
   periodVarianceMS = 0;
   ejectionOffset = 0.0;
   ejectionVelocity = 10.0;
   velocityVariance = 10.0;
   thetaMin         = 87.0;
   thetaMax         = 88.0;
   lifetimeMS       = 10000;

   particles = "IncindinaryGroundBurnParticle";
};

datablock ExplosionData(IncindinaryExplosion)
{
   soundProfile   = GrenadeExplosionSound;
   emitter[0] = IncindinaryGroundBurnEmitter;

   explosionShape = "effect_plasma_explosion.dts";
   faceViewer = true;
   lifetimeMS = 10000;
   playSpeed = 0.7;

   sizes[0] = "7.0 7.0 7.0";
   sizes[1] = "7.0 7.0 7.0";
   times[0] = 0.0;
   times[1] = 1.0;
};

datablock ItemData(IncindinaryGrenadeThrown)
{
	className = Weapon;
	shapeFile = "grenade.dts";
	mass = 0.6;
	elasticity = 0.3;
   friction = 1;
   pickupRadius = 2;
   maxDamage = 0.5;
	explosion = IncindinaryExplosion;
	underwaterExplosion = IncindinaryExplosion;
   indirectDamage      = 2.0;
   damageRadius        = 12.0;
   radiusDamageType    = $DamageType::Plasma;
   kickBackStrength    = 3500;

   computeCRC = true;
};

datablock ItemData(IncindinaryGrenade)
{
	className = HandInventory;
	catagory = "Handheld";
	shapeFile = "grenade.dts";
	mass = 1;
	elasticity = 0.5;
   friction = 1;
   pickupRadius = 2;
   thrownItem = IncindinaryGrenadeThrown;
	pickUpName = "some incindinary grenades";
	isGrenade = true;

   computeCRC = true;

};

function IncindinaryGrenadeThrown::onThrow(%this, %gren) {
   if($Rank::XP[%gren.SourceObect.client.ranknum] < $Ranks::MinPoints[30]) {
   commandToClient( %gren.SourceObect.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Your Rank Is Too Low To Use This Grenade<spop>", 5, 2);
   %gren.rankdenied = 1;
   }
   %gren.rankdenied = 0;
   AIGrenadeThrown(%gren);
   %gren.detThread = schedule(1500, %gren, "detonateIncindGrenade", %gren);
}

function IncindinaryGrenadeThrown::onCollision(%data, %obj, %col)
{
   // nothing you can do now...
}

function detonateIncindGrenade(%obj) {
if(%obj.rankdenied) {
return;
}
   %obj.setDamageState(Destroyed);
   %data = %obj.getDataBlock();
   RadiusExplosion( %obj, %obj.getPosition(), %data.damageRadius, %data.indirectDamage,
                   %data.kickBackStrength, %obj.sourceObject, %data.radiusDamageType);
   %obj.schedule(500,"delete");
}

