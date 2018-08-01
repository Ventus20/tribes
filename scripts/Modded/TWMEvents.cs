//TWM EVENTS
//Event Vars
$TWM::EXPMultiplier = 1.0; //This can change how much EXP you get per kill
$TWM::SPMultiplier = 1.0; //This can change how much SP you get per kill
$TWM::TKEXPLoss = 10; //This changes the Teamkill XP Loss Multiplier
$TWM::EventActive = 0;
$TWM::EventName = "There Are Currently No Active Events";
$TWM::EventStuff = "Nothing Is Changed";

function StartEvent(%eventTagNumber) {
   if($TWM::EventActive) {
   $TWM::EXPMultiplier = 1.0;
   $TWM::SPMultiplier = 1.0;
   $TWM::TKEXPLoss = 10;
   $TWM::EventActive = 0;
   $TWM::EventName = "There Are Currently No Active Events";
   $TWM::EventStuff = "Nothing Is Changed";
   Echo("All Current TWM Events Disabled");
   ShowCurrentEventInfo();
   return;
   }
   else {
      switch(%eventTagNumber) {
         case 001:
            $TWM::EXPMultiplier = 2.0;
            $TWM::SPMultiplier = 1.0;
            $TWM::TKEXPLoss = 10;
            $TWM::EventActive = 1;
            $TWM::EventName = "Christmas Brawl";
            $TWM::EventStuff = "Double EXP Gain";
            Echo("TWM Event "@%eventTagNumber@" : "@$TWM::EventName@" activated.");
         case 002:
            $TWM::EXPMultiplier = 2.0;
            $TWM::SPMultiplier = 2.0;
            $TWM::TKEXPLoss = 20;
            $TWM::EventActive = 1;
            $TWM::EventName = "Christmas Eve Battlegrounds";
            $TWM::EventStuff = "Double SP and EXP Gain, 20 EXP Loss for TK";
            Echo("TWM Event "@%eventTagNumber@" : "@$TWM::EventName@" activated.");
         case 003:
            $TWM::EXPMultiplier = 2.0;
            $TWM::SPMultiplier = 2.0;
            $TWM::TKEXPLoss = 10;
            $TWM::EventActive = 1;
            $TWM::EventName = "Christmas Day Smackdown";
            $TWM::EventStuff = "Double SP and EXP Gain";
            Echo("TWM Event "@%eventTagNumber@" : "@$TWM::EventName@" activated.");
         case 004:
            $TWM::EXPMultiplier = 1.0;
            $TWM::SPMultiplier = 2.0;
            $TWM::TKEXPLoss = 10;
            $TWM::EventActive = 1;
            $TWM::EventName = "New Years Fireworks";
            $TWM::EventStuff = "Double SP Gain";
            Echo("TWM Event "@%eventTagNumber@" : "@$TWM::EventName@" activated.");
         case 005:
            $TWM::EXPMultiplier = 2.0;
            $TWM::SPMultiplier = 2.0;
            $TWM::TKEXPLoss = 20;
            $TWM::EventActive = 1;
            $TWM::EventName = "New 'Wars' Eve";
            $TWM::EventStuff = "Double SP and EXP Gain, 20 EXP Loss for TK";
            Echo("TWM Event "@%eventTagNumber@" : "@$TWM::EventName@" activated.");
         case 006:
            $TWM::EXPMultiplier = 2.0;
            $TWM::SPMultiplier = 2.0;
            $TWM::TKEXPLoss = 10;
            $TWM::EventActive = 1;
            $TWM::EventName = "Welcome in The New Years War";
            $TWM::EventStuff = "Double SP and EXP Gain";
            Echo("TWM Event "@%eventTagNumber@" : "@$TWM::EventName@" activated.");
         case 007:
            $TWM::EXPMultiplier = 1.0;
            $TWM::SPMultiplier = 1.0;
            $TWM::TKEXPLoss = 10;
            $TWM::EventActive = 1;
            $Host::ranksystem = 0;
            $TWM::EventName = "The Day Without Ranking";
            $TWM::EventStuff = "Ranking system off all day, Enjoy";
            Echo("TWM Event "@%eventTagNumber@" : "@$TWM::EventName@" activated.");
         case 008:
            $TWM::EXPMultiplier = 3.0;
            $TWM::SPMultiplier = 0.0;
            $TWM::TKEXPLoss = 30;
            $TWM::EventActive = 1;
            $TWM::EventName = "Fourth Of July - Bombs Bursting In The Air";
            $TWM::EventStuff = "Tripple EXP Gain, 30 EXP Loss for TK";
            Echo("TWM Event "@%eventTagNumber@" : "@$TWM::EventName@" activated.");

      }
   ShowCurrentEventInfo();
   }
}

function ShowCurrentEventInfo() {
   %count = ClientGroup.getCount();
   for (%i = 0; %i < %count; %i++) {
   %cl = ClientGroup.getObject( %i );
   CenterPrint(%cl, "<color:FF0000>TWM Event Info \n "@$TWM::EventName@" \n "@$TWM::EventStuff@" ",5,3);
   }
}

function ShowCurrentEventToCL(%client) {
   CenterPrint(%client, "<color:FF0000>TWM Event Info \n "@$TWM::EventName@" \n "@$TWM::EventStuff@" ",5,3);
}
