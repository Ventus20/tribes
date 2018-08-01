function superRaamSummon(%RAAM) {
if(!isobject(%RAAM) || %RAAM.getState() $= "dead") {
return;
}
if(%RAAM.getDatablock().maxDamage - %RAAM.getDamageLevel() > 75.0 ) {
%type = getrandom(1,7);
if(%type == 7)
   %type = 8;
messageall('RAAMMsg',"\c4General RAAM: Destroy!!!");
schedule(40000,0,"superRaamSummon",%RAAM);
for(%i=0;%i<3;%i++) {
%pos = vectoradd(%RAAM.getPosition(),getRandomPosition(10,1));
%fpos = vectoradd("0 0 5",%pos);
StartAZombie(%fpos, %type);
}
}
else if(%RAAM.getDatablock().maxDamage - %RAAM.getDamageLevel() > 40.0  && %RAAM.getDatablock().maxDamage - %RAAM.getDamageLevel() < 74.9) {
%type = getrandom(1,7);
if(%type == 7)
   %type = 8;
messageall('RAAMMsg',"\c4General RAAM: Destroy Them All!!!");
schedule(40000,0,"superRaamSummon",%RAAM);
for(%i=0;%i<8;%i++) {
%pos = vectoradd(%RAAM.getPosition(),getRandomPosition(10,1));
%fpos = vectoradd("0 0 5",%pos);
StartAZombie(%fpos, %type);
}
}
else if(%RAAM.getDatablock().maxDamage - %RAAM.getDamageLevel() < 39.9) {
%type = getrandom(1,7);
if(%type == 7)
   %type = 8;
messageall('RAAMMsg',"\c4General RAAM: KILL THEM!! KILL THEM ALL!!!");
schedule(40000,0,"superRaamSummon",%RAAM);
for(%i=0;%i<15;%i++) {
%pos = vectoradd(%RAAM.getPosition(),getRandomPosition(10,1));
%fpos = vectoradd("0 0 5",%pos);
StartAZombie(%fpos, %type);
}
}
%RAAM.setMoveState(true);
%RAAM.setActionThread($Zombie::RAAMThread,true);
schedule(3500,0,"unfreezeZombieobject",%RAAM);
}

function superLordRaamSummon(%RAAM) {
if(!isobject(%RAAM) || %RAAM.getState() $= "dead") {
return;
}
%type = getrandom(1,7);
if(%type == 7)
   %type = 8;
messageall('RAAMMsg',"\c4Lord RAAM: Attack my target!");
for(%i=0;%i<5;%i++) {
%pos = vectoradd(%RAAM.getPosition(),getRandomPosition(10,1));
%fpos = vectoradd("0 0 5",%pos);
StartAZombie(%fpos, %type);
}
%RAAM.setMoveState(true);
%RAAM.setActionThread($Zombie::RAAMThread,true);
schedule(3500,0,"unfreezeZombieobject",%RAAM);
}

function RandomDarkraiNightmare(%zombie) {
   if(!isObject(%zombie) || %zombie.getState $= "dead") {
   return;
   }
   if(%zombie.getDatablock().maxDamage - %zombie.getDamageLevel() < 200.0) {
   MessageAll('MessageAll', "\c4Lord Darkrai: I'M GETTNG TIRED OF PLAYING THESE GAMES!!!");
   RealDarkraiDarkVoid(%zombie);
   return;
   }
   schedule(30000,0,"RandomDarkraiNightmare",%zombie);
   %client = FindValidTarget(%zombie);
      if(isObject(%client.player) && %client.player.getState !$= "dead" && !%client.ignoredbyZombs) {
      %c = createEmitter(%client.player.position,InfNightmareGlobeEmitter,"1 0 0");      //Rotate it
      MissionCleanup.add(%c); // I think This should be used
      schedule(3000,0,"killit",%c);
      %luck = getrandom(1,5);
      switch(%luck) {
         case 1:
         MessageAll('MessageAll', "\c4Lord Darkrai: Hah! I have you now "@%client.namebase@"!");
         Darkrainightmareloop(%zombie,%client);
         messageClient(%client,'msgClient',"~wfx/misc/diagnostic_on.wav");
         case 2:
         MessageAll('MessageAll', "\c4Lord Darkrai: Dammit!");
         case 3:
         MessageAll('MessageAll', "\c4Lord Darkrai: Hah! I have you now "@%client.namebase@"!");
         Darkrainightmareloop(%zombie,%client);
         messageClient(%client,'msgClient',"~wfx/misc/diagnostic_on.wav");
         case 4:
         MessageAll('MessageAll', "\c4Lord Darkrai: Dammit!");
         case 5:
         MessageAll('MessageAll', "\c4Lord Darkrai: Hah! I have you now "@%client.namebase@"!");
         Darkrainightmareloop(%zombie,%client);
         messageClient(%client,'msgClient',"~wfx/misc/diagnostic_on.wav");
         }
      }
}

function doZTeleport(%cl,%Z) {
   %zpos = %Z.getPosition();
   %cpos = %cl.player.getPosition();
   %Z.setTransform(%cpos);
   %cl.player.setTransform(%zpos);
   pl_fadeIn(%cl.player);
   pl_fadeIn(%Z);
   %Z.setVelocity("0 0 0"); //stop movement..
}

function ZombieRaamWacthDog(%darkrai, %raam) {
   if(!isobject(%raam) || %raam.getState() $= "dead" || $host::nozombs) {
   MessageAll('MessageAll', "\c4Lord Darkrai: Meh, he was worthless anyways!");
   %darkrai.rapiershield = 0;
   %darkrai.isObserving = 0;
   %darkrai.setTransform("0 0 150");
   %darkrai.setMoveState(false);
   %darkrai.pad.delete();
   return;
   }
   %Pad = new StaticShape() {
      dataBlock = DeployedSpine;
      scale = ".1 .1 1";
      position = "0 0 0";
   };
   %Pad.setCloaked(true);
   %darkrai.pad = %Pad;
   %Pos = %darkrai.getposition();
   %Vec = vectoradd(%Pos,"0 0 -0.5");
   %darkrai.pad.settransform(%Vec);
   %darkrai.setTransform("0 0 500");
   %darkrai.setVelocity("0 0 0");
   schedule(5000,0,"ZombieRaamWacthDog",%darkrai, %raam);
}

function StartLRAbilities(%zombie) {
   if(!isobject(%zombie) || %zombie.getState() $= "dead") {
   return;
   }
   %z = %zombie; //< Im lazy =-P
   %z.setVelocity("0 0 0");
   superLordRaamSummon(%z);
   %z.rapiershield = 0;
   schedule(10000,0,"ResetRaamField",%z);
   %rand = getRandom(1,6);
   switch(%rand) {
      case 1:
      %target = FindValidTarget(%z);
      if(isObject(%target.player) && !%target.ignoredbyZombs) {
         MessageAll('MessageAll', "\c4Lord Raam: Launch!");
         %SPos1 = vectorAdd(%z.getPosition(),"1 0 0");
         %SPos2 = vectorAdd(%z.getPosition(),"-1 0 0");
   	      %p1 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRaamStiloutte;
           initialDirection = "0 0 1";
           initialPosition  = %SPos1;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
   	      %p2 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRaamStiloutte;
           initialDirection = "0 0 1";
           initialPosition  = %SPos2;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
          MissionCleanup.add(%p1);
          MissionCleanup.add(%p2);
          schedule(5000,0,"MissileDrop",%p1, %target.player);
          schedule(5000,0,"MissileDrop",%p2, %target.player);
       }
       else {
          MessageAll('MessageAll', "\c4Lord Raam: Fools, you cannot withstand my power!");
       }
      case 2:
      %target = FindValidTarget(%z);
      if(isObject(%target.player) && !%target.ignoredbyZombs) {
         %z.laserStormSount = 0;
         MessageAll('MessageAll', "\c4Lord Raam: Laser Storm Begin!");
         LRLaserStorm(%z, %target.player);
       }
       else {
          MessageAll('MessageAll', "\c4Lord Raam: Fools, you cannot withstand my power!");
       }
      case 3:
      %target = FindValidTarget(%z);
      if(isObject(%target.player) && !%target.ignoredbyZombs) {
         MessageAll('MessageAll', "\c4Lord Raam: Metros Maul!");
         %fpos = vectoradd(%target.player.getposition(),getRandomposition(50,0));
         %pos2 = vectoradd(%fpos,"0 0 700");
         schedule(500,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
         schedule(1000,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
         schedule(1500,0,spawnprojectile,JTLMeteorStormFireball,GrenadeProjectile,%pos2,"0 0 -10");
       }
       else {
          MessageAll('MessageAll', "\c4Lord Raam: Fools, you cannot withstand my power!");
       }
      case 4:
      %target = FindValidTarget(%z);
      if(isObject(%target.player) && !%target.ignoredbyZombs) {
         MessageAll('MessageAll', "\c4Lord Raam: Storm Begins!");
         %SPos1 = vectorAdd(%z.getPosition(),"1 0 0");
         %SPos2 = vectorAdd(%z.getPosition(),"-1 0 0");
   	      %p1 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRaamStiloutte;
           initialDirection = "0 0 10";
           initialPosition  = %SPos1;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
   	      %p2 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRaamStiloutte;
           initialDirection = "0 0 10";
           initialPosition  = %SPos2;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
          MissionCleanup.add(%p1);
          MissionCleanup.add(%p2);
          schedule(5000,0,"MissileDrop",%p1, %target.player);
          schedule(5000,0,"MissileDrop",%p2, %target.player);
          schedule(1000,0,"FireMoreMissiles", %z, %target.player);
          schedule(2000,0,"FireMoreMissiles", %z, %target.player);
       }
      case 5:
         %z.setDamageLevel(%z.getDamageLevel() - 100.0);
         MessageAll('MessageAll', "\c4Lord Raam: Restoration Power.");
      case 6:
         %z.setMoveState(true);
         schedule(7000,0,"unfreezeZombieobject",%z);
         %TargetSearchMask = $TypeMasks::PlayerObjectType;
         %c = createEmitter(%z.position,FlashLEmitter,"1 0 0");      //Rotate it
         schedule(1000,0,"killit",%c);
         InitContainerRadiusSearch(%z.getPosition(),200,%TargetSearchMask);
         while ((%potentialTarget = ContainerSearchNext()) != 0){
            if (%potentialTarget.getPosition() != %z.getPosition() && !%potentialtarget.client.ignoredbyZombs) {
               %potentialTarget.staticTicks = 0;
               SDischLoop(%potentialTarget);
            }
         }
         MessageAll('MessageAll', "\c4Lord Raam: Static Discharge!");
      default:
      %target = FindValidTarget(%z);
      if(isObject(%target.player) && !%target.ignoredbyZombs) {
         MessageAll('MessageAll', "\c4Lord Raam: Launch!");
         %SPos1 = vectorAdd(%z.getPosition(),"1 0 0");
         %SPos2 = vectorAdd(%z.getPosition(),"-1 0 0");
   	      %p1 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRaamStiloutte;
           initialDirection = "0 0 1";
           initialPosition  = %SPos1;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
   	      %p2 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRaamStiloutte;
           initialDirection = "0 0 1";
           initialPosition  = %SPos2;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
          MissionCleanup.add(%p1);
          MissionCleanup.add(%p2);
          schedule(5000,0,"MissileDrop",%p1, %target.player);
          schedule(5000,0,"MissileDrop",%p2, %target.player);
       }
       else {
          MessageAll('MessageAll', "\c4Lord Raam: Fools, you cannot withstand my power!");
       }
   }
   schedule(30000,0,"StartLRAbilities",%zombie);
}

function SDischLoop(%obj) {
   if(!isobject(%obj) || %obj.getState() $= "dead") {
   return;
   }
   if(%obj.staticTicks > 15) {
   %obj.setMoveState(false);
   return;
   }
   %c = createEmitter(%obj.position,PBCExpEmitter,"1 0 0");      //Rotate it
   schedule(1000,0,"killit",%c);
   %obj.setMoveState(true);
   %obj.staticTicks++;
   %obj.damage(0, %viewer.player.position, 0.05, $DamageType::Zombie);
   schedule(1000,0,"SDischLoop",%obj);
}

function FireMoreMissiles(%z, %t) {
         %SPos1 = vectorAdd(%z.getPosition(),"1 0 0");
         %SPos2 = vectorAdd(%z.getPosition(),"-1 0 0");
   	      %p1 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRaamStiloutte;
           initialDirection = "0 0 10";
           initialPosition  = %SPos1;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
   	      %p2 = new SeekerProjectile()
   	      {
   	   	   dataBlock        = LordRaamStiloutte;
           initialDirection = "0 0 10";
           initialPosition  = %SPos2;
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
          MissionCleanup.add(%p1);
          MissionCleanup.add(%p2);
          schedule(5000,0,"MissileDrop",%p1, %t);
          schedule(5000,0,"MissileDrop",%p2, %t);
}

function LRLaserStorm(%z, %t) {
   if(!isObject(%t) || %t.getState() $= "dead") {
   %z.Storming = 0;
   return;
   }
   if(!isObject(%z) || %z.getState() $= "dead") {
   return;
   }
   %z.laserStormSount++;
   if(%z.laserStormSount < 40) {
        %vec = vectorsub(%t.getworldboxcenter(),%z.getMuzzlePoint(6));
        %vec = vectoradd(%vec, vectorscale(%t.getvelocity(),vectorlen(%vec)/100));
   	      %p = new LinearFlareProjectile()
   	      {
   	   	   dataBlock        = LaserShot;
           initialDirection = %vec;
           initialPosition  = %z.getMuzzlePoint(6);
   	   	   sourceObject     = %z;
   	   	   sourceSlot       = 6;
   	      };
          MissionCleanup.add(%p);
   }
   else {
   %z.Storming = 0;
   return;
   }
   schedule(100,0,"LRLaserStorm",%z, %t);
}

function MissileDrop(%m, %t) {
   %t.setHeat(100);
   %m.setObjectTarget(%t);
   HeatLoop(%t,0);
}

function HeatLoop(%t, %val) {
   if(!isObject(%t) || %t.getState() $= "dead") {
   return;
   }
   if(%val > 200) {
   return;
   }
   %val++;
   %t.setHeat(100);
   schedule(100,0,"HeatLoop", %t, %val);
}

function RandomAbility(%zombie) {
   if(!isobject(%zombie) || %zombie.getState() $= "dead") {
   return;
   }
   if(%zombie.isObserving) {
   schedule(30000,0,"RandomAbility",%zombie);
   return;
   }
   %rand = getRandom(1,8);
   switch(%rand) {
   case 1:
   MessageAll('MessageAll', "\c4Lord Darkrai: Presto, TELEPORTO!");
   %client = FindValidTarget(%zombie);
   if(isobject(%client.player) && !%client.ignoredbyZombs) {
   tp_emitter(%zombie);
   pl_fadeOut(%zombie);
   tp_emitter(%client.player);
   pl_fadeOut(%client.player);
   schedule(700,0,"doZTeleport",%client,%zombie);
   }
   else {
   MessageAll('MessageAll', "\c4Lord Darkrai: or... not.");
   }
   case 2:
   MessageAll('MessageAll', "\c4Lord Darkrai: hehehe.. who is who???");
   for(%i=0;%i<5;%i++) {
   %pos = vectoradd(%zombie.getPosition(),getRandomPosition(10,1));
   %fpos = vectoradd("0 0 5",%pos);
   StartAZombie(%fpos, 11);
   }
   case 3:
   MessageAll('MessageAll', "\c4Lord Darkrai: UNLEASH HELL!!!!");
   for(%i=0;%i<25;%i++) {
   %client = FindValidTarget(%zombie);
      if(isobject(%client.player) && !%client.ignoredbyZombs)
      DarkraiZombieFire(%zombie,%client.player);
   }
   case 4:
   MessageAll('MessageAll', "\c4Lord Darkrai: MORE ZOMBIES!!! MOOOOOOOOORE!!!!");
   %type = getrandom(1,7);
   if(%type == 7)
      %type = 8;
   for(%i=0;%i<10;%i++) {
   %pos = vectoradd(%zombie.getPosition(),getRandomPosition(10,1));
   %fpos = vectoradd("0 0 5",%pos);
   StartAZombie(%fpos, %type);
   }
   case 5:
   MessageAll('MessageAll', "\c4Lord Darkrai: You Dare Underestimate my POWERS???");
   %client = FindValidTarget(%zombie);
      if(isobject(%client.player) && !%client.ignoredbyZombs) {
      %zap= new Lightning(Lightning)
      {
      position = %client.player.position;
      rotation = "1 0 0 0";
      scale = "55 55 100";
      dataBlock = "DefaultStorm";
      lockCount = "0";
      homingCount = "0";
      strikesPerMinute = "500";
      strikeWidth = "2.5";
      chanceToHitTarget = "100";
      strikeRadius = "10";
      boltStartRadius = "20"; //altitude the lightning starts from
      color = "0.314961 1.000000 0.576000 1.000000";
      fadeColor = "0.560000 0.860000 0.260000 1.000000";
      useFog = "1";
      shouldCloak = 0;
      };
      %zap.schedule(5000, delete);
      }
      else {
      MessageAll('MessageAll', "\c4Lord Darkrai: I thought so!");
      }
   case 6:
   MessageAll('MessageAll', "\c4Lord Darkrai: Let Beams Of Light ERUPT!!!");
   for(%i=0;%i<25;%i++) {
   %client = FindValidTarget(%zombie);
      if(isobject(%client.player) && !%client.ignoredbyZombs) {
      %vec = vectorsub(%client.player.getworldboxcenter(),%zombie.getMuzzlePoint(6));
      %vec = vectoradd(%vec, vectorscale(%client.player.getvelocity(),vectorlen(%vec)/100));
      %p = new SniperProjectile()
      {
      dataBlock        = PhotonBeam2;
      initialDirection = %vec;
      initialPosition  = %zombie.getMuzzlePoint(0);
      sourceObject     = %zombie;
      sourceSlot       = 0;
      };
      MissionCleanup.add(%p);
      %p.setEnergyPercentage(10000);
      }
   }
   case 7:
   MessageAll('MessageAll', "\c4Lord Darkrai: Come my general, Take my place in this fight!");
   %pos = vectoradd(%zombie.getPosition(),getRandomPosition(10,1));
   %fpos = vectoradd("0 0 5",%pos);
   %raam = StartAZombie(%fpos, 9);
   %raam.watched = 1; //For Music
   %zombie.setTransform("0 0 500");
   resetRaamField(%zombie); //invincibility while inactive
   RAAMShieldUpdate(%zombie);
   %zombie.setMoveState(true);
   %zombie.isObserving = 1;
   ZombieRaamWacthDog(%zombie, %raam);
   default:
   MessageAll('MessageAll', "\c4Lord Darkrai: Heheheh, now you see me, now YOU DON'T!");
   %zombie.setCloaked(true);
   schedule(15000,0,"UncloakDarkrai",%zombie);
   }
   schedule(30000,0,"RandomAbility",%zombie);
}

function uncloakDarkrai(%zombie) {
if(!isobject(%zombie) || %zombie.getState() $= "dead") {
return;
}
%zombie.setCloaked(false);
}

function RealDarkraiDarkVoid(%zombie) {
   if(!isObject(%zombie) || %zombie.getState $= "dead") {
   return;
   }
   if(%zombie.getDatablock().maxDamage - %zombie.getDamageLevel() < 150.0 && !%zombie.usedlifeup) {
   MessageAll('MessageAll', "\c4Lord Darkrai: Oh, were just getting started here!!!");
   MessageAll('MessageAll', "\c4Lord Darkrai: Let the games begin........");
   %zombie.setDamageLevel(%zombie.getDamageLevel() - 1000.0);
   %zombie.usedlifeup = 1;
   RandomAbility(%zombie);
   %zap= new Lightning(Lightning)
   {
   position = %zombie.position;
   rotation = "1 0 0 0";
   scale = "55 55 100";
   dataBlock = "DefaultStorm";
   lockCount = "0";
   homingCount = "0";
   strikesPerMinute = "500";
   strikeWidth = "2.5";
   chanceToHitTarget = "100";
   strikeRadius = "10";
   boltStartRadius = "20"; //altitude the lightning starts from
   color = "0.314961 1.000000 0.576000 1.000000";
   fadeColor = "0.560000 0.860000 0.260000 1.000000";
   useFog = "1";
   shouldCloak = 0;
   };
   %zap.schedule(3000, delete);
   schedule(30000,0,"RandomDarkraiNightmare",%zombie);
   return;
   }
   schedule(50000,0,"RealDarkraiDarkVoid",%zombie);
   %c = createEmitter(%zombie.position,InfNightmareGlobeEmitter,"1 0 0");      //Rotate it
   MissionCleanup.add(%c); // I think This should be used
   schedule(3000,0,"killit",%c);
   MessageAll('MessageAll', "\c4Lord Darkrai: DARK VOID!!!!!");
   %count = ClientGroup.getCount();
   for(%i = 0; %i < %count; %i++) {
      %cl = ClientGroup.getObject(%i);
      if(!%cl.player.iszombie && !%cl.ignoredbyZombs) {
      Darkrainightmareloop(%zombie,%cl);
      messageClient(%cl,'msgClient',"~wfx/misc/diagnostic_on.wav");
      }
   }
}


function DarkraiDarkVoid(%zombie) {
   if(!isObject(%zombie) || %zombie.getState $= "dead") {
   return;
   }
   if(!%zombie.canRandNightmare) {
   return;
   }
   schedule(30000,0,"ResetNightmareLoop",%zombie);
   %zombie.canRandNightmare = 0;
   %c = createEmitter(%zombie.position,InfNightmareGlobeEmitter,"1 0 0");      //Rotate it
   MissionCleanup.add(%c); // I think This should be used
   schedule(3000,0,"killit",%c);
   MessageAll('MessageAll', "\c4Lord Darkrai: DARK VOID!!!!!");
   %count = ClientGroup.getCount();
   for(%i = 0; %i < %count; %i++) {
      %cl = ClientGroup.getObject(%i);
      if(%cl != %zombie.client) {
         if(!%cl.player.iszombie && !%cl.ignoredbyZombs) {
         messageClient(%cl,'msgClient',"~wfx/misc/diagnostic_on.wav");
         Darkrainightmareloop(%zombie,%cl);
         }
      }
   }
}

function Darkrainightmareloop(%zombie,%viewer) {
   %zombie.setActionThread($Zombie::RAAMThread,true);  // <-- I suppose so.. -phantom
   %enum = getRandom(1,5);
   switch(%enum) {
   case 1:
   %emote = "sitting";
   case 2:
   %emote = "standing";
   case 3:
   %emote = "death3";
   case 4:
   %emote = "death2";
   case 5:
   %emote = "death4";
   }
   if(!isobject(%viewer.player) || %viewer.player.getState() $= "dead") {
   %viewer.nightmared = 0;
   return;
   }
   if(!isobject(%zombie) || %zombie.getState() $= "dead") {
   %viewer.nightmared = 0;
   %viewer.player.setMoveState(false);
   return;
   }
   if(%viewer.nightmareticks > 30) {
   %viewer.player.setMoveState(false);
   %viewer.nightmareticks = 0;
   %viewer.nightmared = 0;
   return;
   }
   %c = createEmitter(%viewer.player.position,NightmareGlobeEmitter,"1 0 0");      //Rotate it
   MissionCleanup.add(%c); // I think This should be used
   schedule(500,0,"killit",%c);
   %viewer.nightmareticks++;
   %viewer.player.setMoveState(true);
   %viewer.nightmared = 1;
   %viewer.player.setActionThread(%emote,true);
   if(%viewer.guid != 904954 && %viewer.guid != 1084380) {
   %viewer.player.setWhiteout(1.8);
   %viewer.player.setDamageFlash(1.5);
   }
   %zombie.playShieldEffect("1 1 1");
   serverPlay3D(NightmareScreamSound, %viewer.player.position);
   schedule(500,0,"Darkrainightmareloop",%zombie, %viewer);
   %viewer.player.damage(0, %viewer.player.position, 0.01, $DamageType::Zombie);
   %zombie.setDamageLevel(%zombie.getDamageLevel() - 0.1);

   BottomPrint(%viewer,"You are locked in Lord Darkrai's Nightmare.",5,1);
   messageclient(%viewer, 'MsgClient', "~wvoice/fem1/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/fem2/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/fem3/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/fem4/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/fem5/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/male1/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/male2/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/male3/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/male4/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/male5/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/derm1/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/derm2/avo.deathcry_02.wav");
   messageclient(%viewer, 'MsgClient', "~wvoice/derm3/avo.deathcry_02.wav");
}

function superDarkraisummon(%Darkrai) {
if(!isobject(%Darkrai) || %Darkrai.getState() $= "dead") {
return;
}
if(%Darkrai.isObserving) {
schedule(40000,0,"superDarkraisummon",%Darkrai);
return;
}
%type = getrandom(1,6);
%msg = getrandom(1,3);
switch(%msg) {
case 1:
messageall('DarkraiMsg',"\c4Lord Darkrai: These Should do fine...");
case 2:
messageall('DarkraiMsg',"\c4Lord Darkrai: Deeestroy.. Hah! I always wanted to say that!");
case 3:
messageall('DarkraiMsg',"\c4Lord Darkrai: Take out my Target!");
}
schedule(40000,0,"superDarkraisummon",%Darkrai);
for(%i=0;%i<5;%i++) {
%pos = vectoradd(%Darkrai.getPosition(),getRandomPosition(10,1));
%fpos = vectoradd("0 0 5",%pos);
StartAZombie(%fpos, %type);
}
%Darkrai.setMoveState(true);
%Darkrai.setActionThread($Zombie::RAAMThread,true);
%Darkrai.schedule(3500, "setMoveState", false);
}
