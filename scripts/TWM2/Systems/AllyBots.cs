//AllyBots.cs
//Phantom139

//The Return of TWM1's "assistant" bots

function detectMessage(%client, %message) {
   //pitch the message over to the respective area
   checkSpawnAlly(%client, %message);
   checkBotCommands(%client, %message);
}

function checkSpawnAlly(%client, %message) {
   //check to see if it's a spawn message
   if(strlwr(getWord(%message, 0)) $= "recruit" && strlwr(getWord(%message, 1)) $= "member") {
      %name = getWords(%message, 2);
      //construction game mode?
      if($CurrentMissionType !$= "Construction") {
         schedule(500, 0, "messageClient", %client, 'msgFail', "\c3From Command: Negative, must be in the construction game mode.");
         return;
      }
      if(!$TWM2::AllyBotsOn) {
         schedule(500, 0, "messageClient", %client, 'msgFail', "\c3From Command: Negative, allies are currently unavaliable.");
         return;
      }
      //do I already have an ally?
      if(isObject(%client.allyPlayer) && %client.allyPlayer.getState() !$= "dead") {
         schedule(500, 0, "messageClient", %client, 'msgFail', "\c3From Command: Negative, you already have an ally, please 'disband ally' before attempting to spawn another.");
         return;
      }
      //all above passed, proceed to ally checks
      switch$(%name) {
         case "Yvex":
            if(!%client.CheckNWChallengeCompletion("Yvex3")) {
               schedule(500, 0, "messageClient", %client, 'msgFail', "\c3From Lord Yvex: You do not have my honored trust just yet....");
               return;
            }
            spawnAllyBot(%client, "Yvex");
         case "Rog":
            if(!%client.CheckNWChallengeCompletion("LRog3")) {
               schedule(500, 0, "messageClient", %client, 'msgFail', "\c3From Lord Rog: No, you will not have my sword today...");
               return;
            }
            spawnAllyBot(%client, "Rog");
         case "Vegenor":
            if(!%client.CheckNWChallengeCompletion("Veg3")) {
               schedule(500, 0, "messageClient", %client, 'msgFail', "\c3From General Vegenor: I'm not taking orders from you.");
               return;
            }
            spawnAllyBot(%client, "Vegenor");
         case "Insignia":
            if(!%client.CheckNWChallengeCompletion("Ins3")) {
               schedule(500, 0, "messageClient", %client, 'msgFail', "\c3From Major Insignia: I'm not going into combat for you...");
               return;
            }
            spawnAllyBot(%client, "Insignia");
         case "Vardison":
            if(!%client.CheckNWChallengeCompletion("Vard3")) {
               schedule(500, 0, "messageClient", %client, 'msgFail', "\c3From Lord Vardison: Hell no.");
               return;
            }
            spawnAllyBot(%client, "Vardison");
         default:
            schedule(500, 0, "messageClient", %client, 'msgFail', "\c3From Command: Requested ally not in list, type 'recruit list' for ally list.");
      }
   }
   else if(strlwr(getWord(%message, 0)) $= "recruit" && strlwr(getWord(%message, 1)) $= "list") {
      if($CurrentMissionType !$= "Construction") {
         schedule(500, 0, "messageClient", %client, 'msgFail', "\c3From Command: Negative, must be in the construction game mode.");
         return;
      }
      if(!$TWM2::AllyBotsOn) {
         schedule(500, 0, "messageClient", %client, 'msgFail', "\c3From Command: Negative, allies are currently unavaliable.");
         return;
      }
      schedule(500, 0, "messageClient", %client, 'msgSuccess', "\c3From Command: Allies: Yvex, Rog, Vegenor, Insignia, Vardison.");
      schedule(500, 0, "messageClient", %client, 'msgSuccess', "\c3From Command: Type Recruit Member [name] to spawn.");
   }
   else if(strlwr(getWord(%message, 0)) $= "disband" && strlwr(getWord(%message, 1)) $= "ally") {
      //boom, kill the bot...
      %client.allyPlayer.disbanded = 1;
      %client.allyPlayer.blowup();
      %client.allyPlayer.scriptKill();
   }
}

function spawnAllyBot(%client, %bot) {
   if(isObject(%client.allyPlayer) && %client.allyPlayer.getState() !$= "dead") {
      error("Dual Ally spawn....");
      return;
   }
   if(!$TWM2::AllyBotsOn || $CurrentMissionType !$= "Construction") {
      return;
   }
   //
   if(!%client.player.isAlive()) {
      %z = getTerrainHeight("0 0 0");
      %spawnPosition = "0 0 "@%z@"";
   }
   else {
      %spawnPosition = vectorAdd(%client.player.getPosition(), "0 0 10");
   }
   switch$(%bot) {
      case "Yvex":
	     %botObject = new player(){
	        Datablock = "YvexZombieArmor";
         };
         %name = "[ALLY] "@$TWM2::ZombieName[7];
         %skin = 'Horde';
         schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Yvex: Good day, I'm here to assist you today.");
         schedule(2000, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Yvex: My services are listed here: 'Yvex Commands'.");
      case "Rog":
	     %botObject = new player(){
	        Datablock = "LordRogZombieArmor";
         };
         %name = "[ALLY] "@$TWM2::ZombieName[8];
         %skin = 'Horde';
         schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Rog: Greetings... I am prepared for combat and will take orders.");
         schedule(2000, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Rog: My services are listed here: 'Rog Commands'.");
      case "Vegenor":
	     %botObject = new player(){
	        Datablock = "VegenorZombieArmor";
         };
         %name = "[ALLY] "@$TWM2::BossName["Vegenor"];
         %skin = 'Horde';
         schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From General Vegenor: Hello, I have been ordred to assist you in your combat op.");
         schedule(2000, 0, "messageClient", %client, 'msgSpawn', "\c3From General Vegenor: My services are listed here: 'Vegenor Commands'.");
      case "Insignia":
	     %botObject = new player(){
	        Datablock = "InsigniaZombieArmor";
         };
         %name = "[ALLY] "@$TWM2::BossName["Insignia"];
         %skin = 'Horde';
         schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Major Insignia: Hello sir, I am ready for your orders....");
         schedule(2000, 0, "messageClient", %client, 'msgSpawn', "\c3From Major Insignia: My services are listed here: 'Insignia Commands'.");
      case "Vardison":
	     %botObject = new player(){
	        Datablock = "VardisonStage1Armor";
         };
         %name = "[ALLY] "@$TWM2::BossName["Vardison"];
         %skin = 'Storm';
         schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: Differences aside now, lets do this!");
         schedule(2000, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: My powers ar ready: 'Vardison Commands'.");

   }
   //clean up and prep...
   %botObject.team = %client.team;
   %botObject.target = createTarget(%botObject, %name, "", "Derm3", '', %botObject.team, PlayerSensor);
   setTargetSensorData(%botObject.target, PlayerSensor);
   setTargetSensorGroup(%botObject.target, %client.team);
   setTargetName(%botObject.target, addtaggedstring(%name));
   setTargetSkin(%botObject.target, %skin);
   %botObject.name = %bot;
   //
   %botObject.setTransform(%spawnPosition);
   MissionCleanup.add(%botObject);
   %botObject.isAllyBot = 1;
   //Salute our owner if he/she exists :D
   schedule(2000, 0, "SalutePlayer", %client, %botObject);
   //
   %client.allyPlayer = %botObject;
   %client.allyName = %bot;
   ClientAllyCheckLoop(%client, %botObject);
}

function SalutePlayer(%target, %source) {
   if(!isObject(%target.player) || %target.player.getState() $= "dead") {
      return;
   }
   if(!isObject(%source) || %source.getState() $= "dead") {
      return;
   }
   //have the bot look at the player, then perform the salue animation.
   ZgetFacingDirection(%source, %target.player, %source.getPosition());
   %source.setMoveState(true);
   %source.schedule(500, setActionThread, "cel1", true);
   %source.schedule(3500, "SetMoveState", false);
}

function ClientAllyCheckLoop(%client, %bot) {
   if(!ClientGroup.isMember(%client)) {
      //player was kicked, remove ally
      echo("* Ally Object removed");
      %bot.blowup();
      %bot.scriptKill(0);
      return;
   }
   //
   if(!isObject(%bot) || %bot.getState() $= "dead") {
      if(%bot.disbanded) {
         switch$(%client.allyName) {
            case "Yvex":
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Yvex: Just ring again if you need my services.");
            case "Rog":
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Rog: Fine day serving with you, call again, I'm ready for more kills!");
            case "Insignia":
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Major Insignia: It was an honor serving, call again if needed!");
            case "Vegenor":
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From General Vegenor: Thanks for the honor of that day, call back if needed!");
            case "Vardison":
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: I shall be waiting in the darkness for your call.");
         }
      }
      else {
         switch$(%client.allyName) {
            case "Yvex":
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Yvex: Dammit! Defeated... retreating...");
            case "Rog":
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Rog: Grah! These fools dare defeat me... you must call me back into action!!!");
            case "Insignia":
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Major Insignia: No! I have been defeated!!!");
            case "Vegenor":
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From General Vegenor: Gah! I've been overpowered, retreating for now!");
            case "Vardison":
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: NO! This is NOT happening!!!");
         }
      }
      //
      %client.allyPlayer = "";
      %client.allyName = "";
      //yikes, lost my bot!
      return;
   }
   schedule(500, 0, "ClientAllyCheckLoop", %client, %client.allyPlayer);
}

function checkBotCommands(%client, %message) {
   if(!%client.player.isAlive()) {
      return;
   }
   //universal commands
   %m = strlwr(%message);
   if(getWord(%m, 0) $= "follow") {
      if(getWord(%m, 1) $= "me") {
         if(!isObject(%client.allyPlayer) || %client.allyPlayer.getState() $= "dead") {
            schedule(500, 0, "messageClient", %client, 'msgFail', "\c3From Command: You don't seem to have an active ally.");
            return;
         }
         switch$(%client.allyName) {
            case "Yvex":
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Yvex: Alright, following you.");
            case "Rog":
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Rog: Right behind you!");
            case "Insignia":
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Major Insignia: Following you!");
            case "Vegenor":
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From General Vegenor: I'm on it!");
            case "Vardison":
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: Following...");
         }
         ZombieMoveToAlly(%client.allyPlayer, %client);
      }
      else {
         %targ = plnametocid(getWord(%m, 1));
         if(%targ == 0 || (!isObject(%targ.player) || %targ.player.getState() $= "dead")) {
            switch$(%client.allyName) {
               case "Yvex":
                  schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Yvex: Can't seem to find this person.");
               case "Rog":
                  schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Rog: Can't follow ghosts sir, give me a real person.");
               case "Insignia":
                  schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Major Insignia: Nope, don't see anyone by that name!");
               case "Vegenor":
                  schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From General Vegenor: Errr... this person... does he exist?");
               case "Vardison":
                  schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: No such.... individual.");
            }
         }
         else {
            switch$(%client.allyName) {
               case "Yvex":
                  schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Yvex: I shall follow "@%targ.namebase@".");
                  schedule(500, 0, "messageClient", %targ, 'msgSpawn', "\c3From Lord Yvex: "@%client.namebase@" has requested that I follow you.");
               case "Rog":
                  schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Rog: following "@%targ.namebase@".");
                  schedule(500, 0, "messageClient", %targ, 'msgSpawn', "\c3From Lord Rog: "@%client.namebase@" has requested that I follow you.");
               case "Insignia":
                  schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Major Insignia: Yes... I shall follow "@%targ.namebase@".");
                  schedule(500, 0, "messageClient", %targ, 'msgSpawn', "\c3From Major Insignia: "@%client.namebase@" has requested that I follow you.");
               case "Vegenor":
                  schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From General Vegenor: On it... I shall follow "@%targ.namebase@".");
                  schedule(500, 0, "messageClient", %targ, 'msgSpawn', "\c3From General Vegenor: "@%client.namebase@" has requested that I follow you.");
               case "Vardison":
                  schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: I shall follow "@%targ.namebase@" at once.");
                  schedule(500, 0, "messageClient", %targ, 'msgSpawn', "\c3From Lord Vardison: "@%client.namebase@" has requested that I follow you.");
            }
            ZombieMoveToAlly(%client.allyPlayer, %targ);
         }
      }
   }
   //
   if(getWord(%m, 0) $= "stop") {
      if(!isObject(%client.allyPlayer) || %client.allyPlayer.getState() $= "dead") {
         schedule(500, 0, "messageClient", %client, 'msgFail', "\c3From Command: You don't seem to have an active ally.");
         return;
      }
      switch$(%client.allyName) {
         case "Yvex":
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Yvex: Stopping current operation.");
         case "Rog":
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Rog: Stopping.....");
         case "Insignia":
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Major Insignia: Alright!");
         case "Vegenor":
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From General Vegenor: Stopping current task!");
         case "Vardison":
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: Certainly...");
      }
      if(%client.allyPlayer.moveloop) {
         cancel(%client.allyPlayer.moveloop);
      }
   }
   //
   //ally specific, fork on over!
   //
   switch$(%client.allyName) {
      case "Yvex":
         YvexCommands(%client, %m);
      case "Rog":
         RogCommands(%client, %m);
      case "Vegenor":
         VegenorCommands(%client, %m);
      case "Insignia":
         InsigniaCommands(%client, %m);
      case "Vardison":
         VardisonCommands(%client, %m);
   }
}

function YvexCommands(%client, %m) {
   if(%m $= "yvex commands") {
      schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Yvex: Glad you asked, here is what I can do: ");
      schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3stop, follow [me/name], teleport to [name/you], bring me [name/you].");
   }
   //
   %trg = getword(%m, 1);
   %targ = plnametocid(%trg);
   switch$(getWord(%m, 0)) {
      case "teleport":
         if(getWord(%m, 1) $= "to") {
            if(getWord(%m, 2) $= "you") {
               tp_emitter(%client.player);
               pl_fadeOut(%client.player);
               %cpos = %client.allyPlayer.getPosition();
               %client.player.setTransform(vectoradd(%cpos,"0 0 10"));
               pl_fadeIn(%client.player);
               %client.player.setVelocity("0 0 0"); //stop movement..
               schedule(500, 0,"messageclient",%client, 'MsgClient', "\c1From Lord Yvex: alright "@getTaggedString(%client.name)@", I'm bringing you to me.");
               return;
            }
            else {
               %trg = getwords(%m, 2);
               %targ = plnametocid(%trg);
               if(%targ == 0) {
                  schedule(500, 0,"messageclient",%client, 'MsgClient', "\c1From Lord Yvex: No such target.");
                  return;
               }
               else {
                  if(!%targ.player.isAlive()) {
                     schedule(500, 0,"messageclient",%client, 'MsgClient', "\c1From Lord Yvex: Requested target is currently dead.");
                     return;
                  }
                  else {
                     tp_emitter(%client.player);
                     pl_fadeOut(%client.player);
                     %cpos = %targ.player.getPosition();
                     %client.player.setTransform(vectoradd(%cpos,"0 0 10"));
                     pl_fadeIn(%client.player);
                     %client.player.setVelocity("0 0 0"); //stop movement..
                     schedule(500, 0,"messageclient",%client, 'MsgClient', "\c1From Lord Yvex: Teleporting you to "@%targ.namebase@" now.");
                     return;
                  }
               }
            }
         }
      case "bring":
         if(getWord(%m, 1) $= "me") {
            if(getWord(%m, 2) $= "you") {
               tp_emitter(%client.AllyPlayer);
               pl_fadeOut(%client.AllyPlayer);
               %cpos = %client.player.getPosition();
               %client.AllyPlayer.setTransform(vectoradd(%cpos,"0 0 10"));
               pl_fadeIn(%client.AllyPlayer);
               %client.AllyPlayer.setVelocity("0 0 0"); //stop movement..
               schedule(500, 0,"messageclient",%client, 'MsgClient', "\c1From Lord Yvex: alright "@getTaggedString(%client.name)@", I'm coming to you.");
               return;
            }
            else {
               %trg = getwords(%m, 2);
               %targ = plnametocid(%trg);
               if(%targ == 0) {
                  schedule(500, 0,"messageclient",%client, 'MsgClient', "\c1From Lord Yvex: No such target.");
                  return;
               }
               else {
                  if(!%targ.player.isAlive()) {
                     schedule(500, 0,"messageclient",%client, 'MsgClient', "\c1From Lord Yvex: Requested target is currently dead.");
                     return;
                  }
                  else {
                     tp_emitter(%targ.player);
                     pl_fadeOut(%targ.player);
                     %cpos = %client.player.getPosition();
                     %targ.player.setTransform(vectoradd(%cpos,"0 0 10"));
                     pl_fadeIn(%targ.player);
                     %targ.player.setVelocity("0 0 0"); //stop movement..
                     schedule(500, 0,"messageclient",%client, 'MsgClient', "\c1From Lord Yvex: Bringing you "@%targ.namebase@".");
                     schedule(500, 0,"messageclient",%targ, 'MsgClient', "\c1From Lord Yvex: Your presense is requested by "@%client.namebase@".");
                     return;
                  }
               }
            }
         }
   }
}

function RogCommands(%client, %m) {
   if(%m $= "rog commands") {
      schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Rog: I am ready to perform these tasks: ");
      schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3stop, follow [me/name], attack [name], meteor [name], laze [name], missile [name].");
   }
   //
   %trg = getword(%m, 1);
   %targ = plnametocid(%trg);
   switch$(getWord(%m, 0)) {
      case "attack":
         if(%targ == 0) {
            schedule(500, 0, "messageclient", %client, 'MsgClient', "\c1From Lord Rog: that is an invalid target, "@getTaggedString(%client.name)@".");
            return;
         }
         if(%targ == %client) {
            schedule(500, 0, "messageclient", %client, 'MsgClient', "\c1From Lord Rog: I'm not going to attack you, "@getTaggedString(%client.name)@".");
            return;
         }
         if(!isobject(%targ.player) || %targ.player.getState() $= "dead") {
            schedule(500, 0, "messageclient", %client, 'MsgClient', "\c1From Lord Rog: It seems that he is dead, "@getTaggedString(%client.name)@".");
            return;
         }
         AllyRogAttack(%client.allyPlayer, %targ.player);
      case "meteor":
         if(%targ == 0) {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Rog: No such target there.");
            return;
         }
         if(%targ == %client) {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Rog: Not today pal.");
            return;
         }
         schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Rog: Brigning down a meteor upon "@%targ.namebase@".");
         %fpos = vectoradd(%targ.player.getposition(), getRandomposition(50,0));
         %pos2 = vectoradd(%fpos,"0 0 700");
         schedule(500, 0, spawnprojectile, JTLMeteorStormFireball, GrenadeProjectile, %pos2, "0 0 -10");
      case "missile":
         if(%targ == 0) {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Rog: No such target there.");
            return;
         }
         if(%targ == %client) {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Rog: Not today pal.");
            return;
         }
         schedule(500, 0, "messageclient", %client, 'MsgClient', "\c1From Lord Rog: Beginning Missile Strike on "@getTaggedString(%targ.name)@", "@getTaggedString(%client.name)@"!");
         FireMoreMissiles(%client.allyPlayer, %targ.player);
      case "laze":
         if(%client.allyPlayer.Storming) {
            schedule(500, 0, "messageclient", %client, 'MsgClient', "\c1From Lord Rog: I can't fire at multiple targets, "@getTaggedString(%client.name)@".");
            return;
         }
         if(%targ == 0) {
            schedule(500, 0, "messageclient", %client, 'MsgClient', "\c1From Lord Rog: that is an invalid target, "@getTaggedString(%client.name)@".");
            return;
         }
         if(%targ == %client) {
            schedule(500, 0, "messageclient", %client, 'MsgClient', "\c1From Lord Rog: uh.. no, "@getTaggedString(%client.name)@".");
            return;
         }
         if(!isobject(%targ.player) || %targ.player.getState() $= "dead") {
            schedule(500, 0, "messageclient", %client, 'MsgClient', "\c1From Lord Rog: It seems that he is dead, "@getTaggedString(%client.name)@".");
            return;
         }
         %zomb = %client.allyPlayer;
         %targp = %targ.player;
         schedule(500, 0, "messageclient", %client, 'MsgClient', "\c1From Lord Rog: Beginning Laser Storm on "@getTaggedString(%targ.name)@", "@getTaggedString(%client.name)@"!");
         %zomb.Storming = 1;
         %zomb.laserStormSount = 0;
         LRLaserStorm(%zomb, %targp);
         schedule(4000, 0, "resetLRLaserStorm", %zomb);
   }
}

function VegenorCommands(%client, %m) {
   if(%m $= "vegenor commands") {
      schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From General Vegenor: I'm ready to go, just give the word: ");
      schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3stop, follow [me/name], firebomb [name], missile [name].");
   }
   %trg = getwords(%m, 1);
   %targ = plnametocid(%trg);
   switch$(getWord(%m, 0)) {
      case "firebomb":
         if(%targ == 0) {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From General Vegenor: No such target there.");
            return;
         }
         if(%targ == %client) {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From General Vegenor: No thanks.");
            return;
         }
         schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From General Vegenor: Brigning down a meteor upon "@%targ.namebase@".");
         %fpos = vectoradd(%targ.player.getposition(), getRandomposition(50,0));
         %pos2 = vectoradd(%fpos,"0 0 700");
         schedule(500, 0, spawnprojectile, VegenorFireMeteor, GrenadeProjectile, %pos2, "0 0 -10");
      case "missile":
         if(%targ == 0) {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From General Vegenor: No such target there.");
            return;
         }
         if(%targ == %client) {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From General Vegenor: No thanks.");
            return;
         }
         if(isObject(%targ.player) && %targ.player.getState() !$= "Dead") {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From General Vegenor: Fire missile away!");
            %Tobj = %targ.player;
            %z = %client.allyPlayer;
	        %vec = vectorNormalize(vectorSub(%Tobj.getPosition(), %z.getPosition()));
   	        %p = new SeekerProjectile() {
	             dataBlock        = VegenorFireMissile;
	             initialDirection = %vec;
	             initialPosition  = %z.getMuzzlePoint(4);
	             sourceObject     = %z;
	             sourceSlot       = 4;
            };
   	        %beacon = new BeaconObject() {
                 dataBlock = "SubBeacon";
                 beaconType = "vehicle";
                 position = %Tobj.getWorldBoxCenter();
            };
   	        %beacon.team = 0;
   	        %beacon.setTarget(0);
   	        MissionCleanup.add(%beacon);
            %p.setObjectTarget(%beacon);
	        DemonMotherMissileFollow(%Tobj,%beacon,%p);
         }
         else {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From General Vegenor: Target is currently dead.");
         }
   }
}

function InsigniaCommands(%client, %m) {
   if(%m $= "insignia commands") {
      schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Major Insignia: I wait for your command: ");
      schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3stop, follow [me/name], acid storm [name], thrust to [name].");
   }
   %trg = getwords(%m, 2);
   %targ = plnametocid(%trg);
   switch$(getWord(%m, 0)) {
      case "acid":
         if(getWord(%m, 1) $= "storm") {
            if(%client.allyPlayer.storming) {
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Major Insignia: I cannot use this attack on multiple targets at once... please wait.");
               return;
            }
            if(%targ == 0) {
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Major Insignia: No such target there.");
               return;
            }
            if(%targ == %client) {
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Major Insignia: No thanks.");
               return;
            }
            if(isObject(%targ.player) && %targ.player.getState() !$= "Dead") {
               %client.allyPlayer.storming = 1;
               schedule(5000, 0, "ResetInsigniaStorm", %client.allyPlayer);
               for(%i = 0; %i < 40; %i++) {
                  schedule(%i * 100, 0, "FireZLordPulse", %client.allyPlayer, %targ.player);
               }
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Major Insignia: Storming "@%targ.namebase@"!");
            }
            else {
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Major Insignia: Target is dead.");
               return;
            }
         }
      case "thrust":
         if(getWord(%m, 1) $= "to") {
            if(%client.player.flight) {
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Major Insignia: Hold on, you're still in flight boost.");
               return;
            }
            if(%targ == 0) {
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Major Insignia: No such target there.");
               return;
            }
            if(%targ == %client) {
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Major Insignia: You can't boost to yourself.");
               return;
            }
            //
            if(!%targ.player.isAlive()) {
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Major Insignia: This target is currently in-active.");
               return;
            }
            else {
               schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Major Insignia: Away you go!");
               GravShot(%client.player, "0 0 200");
               %vec = vectorsub(%targ.player.getworldboxcenter(), %client.player.getMuzzlePoint(0));
               %vec = vectoradd(%vec, vectorscale(%targ.player.getvelocity(),vectorlen(%vec)/100));
               schedule(1000,0, "GravShot", %client.player, %vec);
            }
         }
   }
}

function VardisonCommands(%client, %m) {
   if(%m $= "vardison commands") {
      schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: My powers await your command: ");
      schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3stop, follow [me/name], NMM [name], obliterate [name].");
      schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3mass [name], laser [name], shadow [name].");
   }
   switch$(getWord(%m, 0)) {
      case "nmm":
         %trg = getWords(%m, 1);
         %targ = plnametocid(%trg);
         if(%targ == 0) {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: Negative, no such individual.");
            return;
         }
         if(%targ == %client) {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: I'll pass.");
            return;
         }
         if(isObject(%targ.player) && %targ.player.getState() !$= "Dead") {
            %target = %targ.player;
	        %vec = vectorNormalize(vectorSub(%target.getPosition(),%client.allyPlayer.getPosition()));
   	        %p = new SeekerProjectile() {
               dataBlock        = VardisonNightmareMissile;
	           initialDirection = %vec;
	           initialPosition  = %client.allyPlayer.getPosition();
	           sourceObject     = %client.allyPlayer;
	           sourceSlot       = 4;
   	        };
   	        %beacon = new BeaconObject() {
               dataBlock = "SubBeacon";
               beaconType = "vehicle";
               position = %target.getWorldBoxCenter();
            };
   	        %beacon.team = 0;
   	        %beacon.setTarget(0);
   	        MissionCleanup.add(%beacon);
            %p.setObjectTarget(%beacon);
            DemonMotherMissileFollow(%target,%beacon,%p);
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: Launching nightmare missile at "@%targ.namebase@".");
         }
         else {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: That individual is currently one with the dead.");
            return;
         }
      case "obliterate":
         %trg = getWords(%m, 1);
         %targ = plnametocid(%trg);
         if(%client.allyPlayer.storming) {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: Rechargine this attack, standby.");
            return;
         }
         if(%targ == 0) {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: Negative, no such individual.");
            return;
         }
         if(%targ == %client) {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: I'll pass.");
            return;
         }
         if(isObject(%targ.player) && %targ.player.getState() !$= "Dead") {
            %client.allyPlayer.storming = 1;
            schedule(10000, 0, "ResetInsigniaStorm", %client.allyPlayer);
            %target = %targ.player;
            MessageAll('MsgVardison', "\c4"@$TWM2::BossName["Vardison"]@": BLAAAAHAAHAHAHAAHA!!!");
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: Destroying "@%targ.namebase@".");
            for(%i = 0; %i < 25; %i++) {
               schedule(50+(%i*150), 0, "UnleashLaser", %client.allyPlayer, %target);
            }
         }
         else {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: That individual is currently one with the dead.");
            return;
         }
      case "mass":
         %trg = getWords(%m, 1);
         %targ = plnametocid(%trg);
         if(%targ == 0) {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: Negative, no such individual.");
            return;
         }
         if(%targ == %client) {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: I'll pass.");
            return;
         }
         if(isObject(%targ.player) && %targ.player.getState() !$= "Dead") {
            %target = %targ.player;
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: Launching mass driver at "@%targ.namebase@".");
	        %vec = vectorNormalize(vectorSub(%target.getPosition(),%client.allyPlayer.getPosition()));
   	        %p = new LinearFlareProjectile() {
               dataBlock        = ShadowBomb;
	           initialDirection = %vec;
	           initialPosition  = %client.allyPlayer.getPosition();
	           sourceObject     = %client.allyPlayer;
	           sourceSlot       = 4;
   	        };
            %p.maxExplode = 4;
         }
         else {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: That individual is currently one with the dead.");
            return;
         }
      case "laser":
         %trg = getWords(%m, 1);
         %targ = plnametocid(%trg);
         if(%targ == 0) {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: Negative, no such individual.");
            return;
         }
         if(%targ == %client) {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: I'll pass.");
            return;
         }
         if(isObject(%targ.player) && %targ.player.getState() !$= "Dead") {
            %target = %targ.player;
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: Ending "@%targ.namebase@", with a laser strike.");
   	        %p = new LinearFlareProjectile() {
               dataBlock        = HyperDevestatorBeam;
	           initialDirection = "0 0 -10";
	           initialPosition  = vectoradd(%target.getPosition(), "0 0 500");
	           sourceObject     = %client.allyPlayer;
	           sourceSlot       = 4;
   	        };
         }
         else {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: That individual is currently one with the dead.");
            return;
         }
      case "shadow":
         %trg = getWords(%m, 1);
         %targ = plnametocid(%trg);
         if(%targ == 0) {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: Negative, no such individual.");
            return;
         }
         if(%targ == %client) {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: I'll pass.");
            return;
         }
         if(isObject(%targ.player) && %targ.player.getState() !$= "Dead") {
            %target = %targ.player;
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: Engaging multi-various shadow explosive upon "@%targ.namebase@".");
            GOVDoFlameCano(%client.allyPlayer, %target);
         }
         else {
            schedule(500, 0, "messageClient", %client, 'msgSpawn', "\c3From Lord Vardison: That individual is currently one with the dead.");
            return;
         }
   }
}






























//ally functions
function ResetInsigniaStorm(%obj) {
   %obj.storming = 0;
}

function ZombieMoveToAlly(%zombie, %ally){
   if(!isObject(%zombie) || %zombie.getState() $= "dead") {
      return;
   }
   %closestClient = %ally.Player;
   if(!isObject(%closestClient) || %closestClient.getState() $= "dead") {
      if(%zombie.name $= "Yvex")
         schedule(5,0,"messageall",'Message', "\c4Lord Yvex: oh dear, "@getTaggedString(%ally.name)@" you seemed to have died.");
      else if(%zombie.name $= "Rog")
         schedule(5,0,"messageall",'Message', "\c4Lord Rog: "@getTaggedString(%ally.name)@", HELLO...... he's dead.");
      else if(%zombie.name $= "Insignia")
         schedule(5,0,"messageall",'Message', "\c4Major Insignia: Eghad.... "@getTaggedString(%ally.name)@" died....");
      else if(%zombie.name $= "Vegenor")
         schedule(5,0,"messageall",'Message', "\c4General Vegenor: Sir...... "@getTaggedString(%ally.name)@"... he's dead....");
      return;
   }
   %zposition = %zombie.getPosition();
   %pos = %zombie.getworldboxcenter();
   %testPos = %closestClient.getWorldBoxCenter();
   %distance = vectorDist(%pos, %testPos);
   %Zzaxis = getword(%zposition,2);
   if(%distance < 10) {
      %zombie.moveloop = schedule(500,0,"ZombieMoveToAlly",%zombie,%ally);
      return;
   }
   if(%Zzaxis < $zombie::falldieheight) {
      %zombie.scriptkill($DamageType::Suicide);
   }
   if(%zombie.hastarget != 1){
      %zombie.canjump = 0;
   schedule(4000, %zombie, "Zsetjump", %zombie);
   if(%zombie.hastarget != 1){
      %zombie.hastarget = 1;
   }

   %vector = ZgetFacingDirection(%zombie, %ally.player, %zombie.getPosition());

	if (%zombie.canjump == 1){
	   %zombie.canjump = 0;
	   schedule(4000, %zombie, "Zsetjump", %zombie);
	   return;
	}
	%vector = vectorscale(%vector, $Zombie::DForwardSpeed );
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= ($Zombie::DForwardSpeed / 3 * 2))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   else if(%zombie.hastarget == 1){
	%zombie.hastarget = 0;
	%zombie.zombieRmove = schedule(100, %zombie, "ZSetRandomMove", %zombie);
   }
   %zombie.moveloop = schedule(200,0,"ZombieMoveToAlly",%zombie,%ally);
}

function AllyRogAttack(%zombie, %target){
   if(!isobject(%zombie))
	return;
   if(%zombie.getState() $= "dead")
	return;
   if(!%target.isAlive()) {
      schedule(500, 0, MessageAll, 'msgKill', "\c4"@$TWM2::ZombieName[8]@": The Infidel "@%target.client.namebase@" has been destroyed!");
      %zombie.isAttacking = 0;
      %zombie.unMountImage(7);
      %zombie.ImageMounted = 0;
      return;
   }
   %pos = %zombie.getworldboxcenter();
   %z = getWord(%pos, 2);
   if(%z < -300) {
      %zombie.startFade(400, 0, true);
      %zombie.startFade(1000, 0, false);
      %zombie.setPosition(vectorAdd(vectoradd(%target.getPosition(), "0 0 20"), getRandomPosition(25, 1)));
      %zombie.setVelocity("0 0 0");
      MessageAll('msgDarkraiAttack', "\c4"@$TWM2::ZombieName[8]@": You think I will fall to my death!?!?");
   }
   %closestDistance = vectorDist(%target.getPosition(), %zombie.getPosition());
   if(%closestDistance <= $zombie::detectDist){

       //Sword Mount / Unmount
       if(%closestDistance < 12) {
          if(!%zombie.ImageMounted) {
             %zombie.ImageMounted = 1;
             %zombie.mountImage(BoVSwing, 7);
             ServerPlay3D(BlasterSwitchSound, %zombie.getPosition());
          }
       }
       else {
          %zombie.unMountImage(7);
          %zombie.ImageMounted = 0;
       }

	   if(%zombie.hastarget != 1){
	      LZDoYell(%zombie);
	      %zombie.hastarget = 1;
       }
       %chance = (getrandom() * 20);
   	   if(%chance >= 19)
	      LZDoMoan(%zombie);

       %vector = ZgetFacingDirection(%zombie,%target,%pos);

    %zombie.isAttacking = 1;

	%vector = vectorscale(%vector, $Zombie::DForwardSpeed);
	%upvec = "150";
	%x = Getword(%vector,0);
	%y = Getword(%vector,1);
	%z = Getword(%vector,2);
	if(%z >= ($Zombie::DForwardSpeed))
	   %upvec = (%upvec * 5);
	%vector = %x@" "@%y@" "@%upvec;
	%zombie.applyImpulse(%pos, %vector);
   }
   %zombie.moveloop = schedule(500, %zombie, "AllyRogAttack", %zombie, %target);
}
