///DARPG AI SYSTEM
//By Phantom139
$Phantom::NoBots = 0;
$Phantom::LoopBots = 1;

function CrBot(%type) {
SpawnDARPGBot(%type);
}

function SpawnDARPGBot(%type) {
   //this line checks the bot
   switch(%type) {
      case 1:
         %r = getrandom(3)+1;
         switch(%r) {
         case 1:
         %name = "Fox";
         case 2:
         %name = "Bear";
         case 3:
         %name = "Wolf";
         case 4:
         %name = "Shadow";
         }
      case 2:
         %r = getrandom(3)+1;
         switch(%r) {
         case 1:
         %name = "Slayuh";
         case 2:
         %name = "Slasher";
         case 3:
         %name = "The Brute";
         case 4:
         %name = "Guardian";
         }
      default:
      echo("Error, Invalid Type Selected");
      return;
   }
   %bot = AIConnect(%name);
   %bot.RPGType = %type;
   botfindnearest(%bot);
   AICheckDeath(%bot);
   switch(%bot.type) {
   case 1:
   %bot.istheif = true;
   case 2:
   %bot.isguard = true;
   }
   echo("Spawning DARPG Bot");
}

function AICheckDeath(%Bot) {
if(!%bot) {
return;
}
if (!Isobject(%Bot.player)){
%Bot.Delete(); //Remove the bot
if($Phantom::LoopBots) {
%type = getrandom(1)+1;
SpawnDARPGBot(%type);
}
return;
}
schedule(100,0,"AICheckDeath",%Bot);
}

function botfindnearest(%bot) {
if($Phantom::NoBots){
return;
}
if(!isObject(%bot.Player)){
schedule(500, 0, "botfindnearest", %bot);
return;
}
%pos = %bot.player.getposition();
%wbpos = %bot.player.getworldboxcenter();
%count = ClientGroup.getCount();
%closestClient = -1;
%closestDistance = 32767;
for(%i = 0; %i < %count; %i++)
{
%cl = ClientGroup.getObject(%i);
if(%closestclient == %bot.client)
{
schedule(500, 0, "bothuntnearestclient", %bot);
return;
}
if(isObject(%cl.player)){
%testPos = %cl.player.getWorldBoxCenter();
%distance = vectorDist(%wbpos, %testPos);
if (%distance > 0 && %distance < %closestDistance)
{
%closestClient = %cl;
%closestDistance = %distance;
}
}
}
if(!isObject(%closestClient.Player)){
schedule(500, 0, "botfindnearest", %bot);
return;
}
if(%closestClient)
bothuntnearestclient(%bot,%closestClient);
}

function bothuntnearestclient(%bot,%closest) {
if($Phantom::NoBots){
return;
}
if(!isObject(%closest.Player)){
schedule(500, 0, "botfindnearest", %bot);
return;
}
if(!isObject(%bot.Player)){
schedule(500, 0, "botfindnearest", %bot);
return;
}
givebotinventory(%bot);
AIUnassignclient(%bot);
%bot.cleartasks();
%bot.stepMove(%closest.player.getposition(),4.0);
%bot.AimAt(%closest.player.getposition(),2000);
%bot.setengagetarget(%closest);
//%bot.stepengage(%target);
schedule(400, 0, "bothuntnearestclient", %bot, %closest);
}

function givebotinventory(%bot) {
   switch(%bot.RPGType)
   {
      //Assasin / Theif
      case 1:
         %rand = getrandom(1) + 1;
         switch(%rand) {
            case 1:
            %bot.player.setInventory(Shocklance,1,true);
            %bot.player.use(Shocklance);
            case 2:
            %bot.player.setInventory(Bow,1,true);
            %bot.player.setInventory(BowAmmo,999,true);
            %bot.player.use(Bow);
            %bot.player.setimagetrigger(0,true);   //fire!
         }
      //Guard
      case 2:
         %rand = getrandom(1) + 1;
         switch(%rand) {
            case 1:
            %bot.player.setInventory(melee,1,true);
            %bot.player.use(meele);
            %bot.player.setimagetrigger(0,true);   //fire!
            case 2:
            %bot.player.setInventory(Bow,1,true);
            %bot.player.setInventory(BowAmmo,999,true);
            %bot.player.use(Bow);
            %bot.player.setimagetrigger(0,true);   //fire!
         }
   }
}
