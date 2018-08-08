//SANDBOX TOOL V.001
//PHANTOM139 FOR TWM2

//QUICK TOOL DESCRIPTION
//The Sandbox tool was an initial thought by me back in TWM 2.8-2.9a
//but the DB count was too high to be able to implement a tool of this
//kind. So, I decided to use TWM2 instead.

//The sandbox tool ultimately improves construction by allowing normal players
//to tap into some functions that were originally to be kept with the server
//These relate to direct object creation mostly, and allows players to spawn
//interior objects freely, then using a special function I found, it relights
//all clients to make it an official interior. It also contains the square
//drill mode which allows underground interiors to work just as well.

//MODES

//-Primary
//--Secondary

//- Create Object
//-- Vehicles
//- Create Interior
//-- Storm
//-- Inferno
//-- Starwolf
//-- Pheonix
//- Square Drill
//-- Drill Single
//- Square Patch
//-- Fill Single
//- Delete Object
//-- Delete
//- Delete Interior
//-- Delete
//- Set Tool Create Range
//-- 20m
//-- 50m
//-- 100m

//THE GUN
//Datablocks

datablock ItemData(SandboxTool) {
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "stackable2s.dts";
   image        = SandboxToolImage;
   mass         = 1;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
	pickUpName = "a Sandbox Tool";

   computeCRC = true;

};

datablock ShapeBaseImageData(SandboxToolImage) {
	className = WeaponImage;
   shapeFile = "stackable2s.dts";
   item = SandboxTool;

	usesEnergy = true;
	minEnergy = 1;

   stateName[0]                     = "Activate";
   stateTransitionOnTimeout[0]      = "ActivateReady";
   stateSound[0]                    = ChaingunSwitchSound;
   stateTimeoutValue[0]             = 0.5;
   stateSequence[0]                 = "Activate";

   stateName[1]                     = "ActivateReady";
   stateTransitionOnLoaded[1]       = "Ready";
   stateTransitionOnNoAmmo[1]       = "NoAmmo";

   stateName[2]                     = "Ready";
   stateTransitionOnNoAmmo[2]       = "NoAmmo";
   stateTransitionOnTriggerDown[2]  = "CheckWet";

   stateName[3]                     = "Fire";
   stateTransitionOnTimeout[3]      = "Reload";
   stateTimeoutValue[3]             = 0.5;
   stateFire[3]                     = true;
   stateAllowImageChange[3]         = false;
   stateSequence[3]                 = "Fire";
   stateScript[3]                   = "onFire";

   stateName[4]                     = "Reload";
   stateTransitionOnTimeout[4]      = "Ready";
   stateTimeoutValue[4]             = 1.0;
   stateAllowImageChange[4]         = false;

   stateName[5]                     = "CheckWet";
   stateTransitionOnWet[5]          = "DryFire";
   stateTransitionOnNotWet[5]       = "Fire";

   stateName[6]                     = "NoAmmo";
   stateTransitionOnAmmo[6]         = "Reload";
   stateTransitionOnTriggerDown[6]  = "DryFire";
   stateSequence[6]                 = "NoAmmo";

   stateName[7]                     = "DryFire";
   stateSound[7]                    = ChaingunDryFireSound;
   stateTimeoutValue[7]             = 0.5;
   stateTransitionOnTimeout[7]      = "Ready";
};

function SandboxToolImage::onMount(%this,%obj,%slot) {
   if(!%obj.client.isDev) {
      BottomPrint(%obj.Client, "This tool is for the host only", 3, 3);
      %obj.throwWeapon(1);
      %obj.throwWeapon(0);
   }
   Parent::onMount(%this, %obj, %slot);
   %obj.SandboxTool["Use"] = 1;
   ChangeSandboxGunMode(%obj, 1, 1);
   DispSandboxToolInfo(%obj);
}

function SandboxToolImage::onUnmount(%this,%obj,%slot) {
   ChangeSandboxGunMode(%obj, 1, 1);
   Parent::onUnmount(%data, %obj, %slot);
   if(isObject(%obj.VGhost)) {
      %obj.VGhost.delete();
   }
   %obj.SandboxTool["Use"] = 0;
}
//Script

//NOTE: Script To Be Made Later
function SetToolRange(%plyr, %range) {
   %plyr.client.SandboxTool["Range"] = %range;
   MessageClient(%plyr.client, 'msgSandbox', "\c5Sandbox: Creation Range set To "@%range@".");
}

function ChangeSandboxGunMode(%this, %data, %PriSec) {  //This Is Easier To use
   if(%PriSec == 1) {    //Primary
      if (!(getSimTime() > (%this.mineModeTime + 100))) {
         return;
      }
      %this.mineModeTime = getSimTime();
      %this.SandboxTool["PrimaryMode"]++;
      %this.SandboxTool["SecondaryMode"] = 0;    //Reset Secondary Mode TO Prevent Errors
      if (%this.SandboxTool["PrimaryMode"] > 1) { //SET LATER
         %this.SandboxTool["PrimaryMode"] = 0;
      }
      //
      if (%this.SandboxTool["PrimaryMode"] == 0) {
         if(isObject(%this.VGhost)) {
            %this.VGhost.delete();
         }
         CreateVehicleGhost(%this, 0);
      }
      //
      DispSandboxToolInfo(%this);
      return;
   }
   else {            //Secondary
      if (!(getSimTime() > (%this.grenadeModeTime + 100))) {
         return;
      }
      %this.grenadeModeTime = getSimTime();
      %this.SandboxTool["SecondaryMode"]++;
      //Check Primaries
      if(%this.SandboxTool["PrimaryMode"] == 0) {
         if(isObject(%this.VGhost)) {
            %this.VGhost.delete();
         }
         CreateVehicleGhost(%this, %this.SandboxTool["SecondaryMode"]);
         if(%this.SandboxTool["SecondaryMode"] > 3) {
            %this.SandboxTool["SecondaryMode"] = 0;
         }
      }
      else if(%this.SandboxTool["PrimaryMode"] == 1 && %this.SandboxTool["SecondaryMode"] > 2) {
         %this.SandboxTool["SecondaryMode"] = 0;
      }
      DispSandboxToolInfo(%this);
      return;
   }
}

function DispSandboxToolInfo(%obj) {
   switch(%obj.SandboxTool["PrimaryMode"]) {
      case 0:
         switch(%obj.SandboxTool["SecondaryMode"]) {
            case 0:
               commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Sandbox Tool - Phantom139 \n <font:Tempus Sans ITC:16>Create Vehicle \n F39 Interceptor<spop>", 5, 3);
            case 1:
               commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Sandbox Tool - Phantom139 \n <font:Tempus Sans ITC:16>Create Vehicle \n Assault Tank<spop>", 5, 3);
            case 2:
               commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Sandbox Tool - Phantom139 \n <font:Tempus Sans ITC:16>Create Vehicle \n Bomber Flyer<spop>", 5, 3);
            case 3:
               commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Sandbox Tool - Phantom139 \n <font:Tempus Sans ITC:16>Create Vehicle \n Mobile Point Base (MPB)<spop>", 5, 3);
         }
      case 1:
         switch(%obj.SandboxTool["SecondaryMode"]) {
            case 0:
               commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Sandbox Tool - Phantom139 \n <font:Tempus Sans ITC:16>Set Tool Range \n 20 Meters<spop>", 5, 3);
            case 1:
               commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Sandbox Tool - Phantom139 \n <font:Tempus Sans ITC:16>Set Tool Range \n 50 Meters<spop>", 5, 3);
            case 2:
               commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Sandbox Tool - Phantom139 \n <font:Tempus Sans ITC:16>Set Tool Range \n 100 Meters<spop>", 5, 3);
         }
   }
}

function SandboxToolImage::onFire(%data, %obj, %slot) {
   %pri = %obj.SandboxTool["PrimaryMode"];
   %sec = %obj.SandboxTool["SecondaryMode"];
   switch(%pri) {
      case 0:
         if(isObject(%obj.VGhost)) {
            MakeRealVeh(%obj, %obj.VGhost);
         }
         else {
            CreateVehicleGhost(%obj, %obj.SandboxTool["SecondaryMode"]);
         }
      case 1:
         switch(%sec) {
            case 0:
               %rng = 20;
            case 1:
               %rng = 50;
            case 2:
               %rng = 100;
         }
         SetToolRange(%obj, %rng);
   }
}

function CreateVehicleGhost(%obj, %secMode) {
   if(%obj.getState() $= "dead" || !isObject(%obj)) {
      return;
   }
   %range = %obj.client.SandboxTool["Range"];
   %pos = VectorAdd(%obj.getMuzzlePoint(0), VectorScale(%obj.getMuzzleVector(0), %range));
   switch(%secMode) {
      case 0:
         %v = "ScoutFlyer\tFlyingVehicle";
      case 1:
         %v = "AssaultVehicle\tHoverVehicle";
      case 2:
         %v = "BomberFlyer\tFlyingVehicle";
      case 3:
         %v = "MobileBaseVehicle\tWheeledVehicle";
      default:
         %v = "ScoutFlyer\tFlyingVehicle";
   }
   %vehName = GetField(%v, 0);
   %vehType = GetField(%v, 1);
   if(%vehType $= "FlyingVehicle") {
      %veh = new FlyingVehicle() {
         datablock = %vehName;
         position = %pos;
         team = %obj.team;
         teamBought = %obj.team;
      };
   }
   else if(%vehType $= "HoverVehicle") {
      %veh = new HoverVehicle() {
         datablock = %vehName;
         position = %pos;
         team = %obj.team;
         teamBought = %obj.team;
      };
   }
   else if(%vehType $= "WheeledVehicle") {
      %veh = new WheeledVehicle() {
         datablock = %vehName;
         position = %pos;
         team = %obj.team;
         teamBought = %obj.team;
      };
   }
   MissionCleanup.add(%veh);
   %veh.setCloaked(true);
   %obj.VGhost = %veh;
   %veh.ghostLoop = VehGhostMoveLoop(%obj, %veh);
}

function VehGhostMoveLoop(%obj, %vehicle) {
   if(%obj.getState() $= "dead" || !isObject(%obj)) {
      %vehicle.delete();
      return;
   }
   if(!isObject(%vehicle)) {
      return;
   }
   %range = %obj.client.SandboxTool["Range"];
   %pos = VectorAdd(%obj.getMuzzlePoint(0), VectorScale(%obj.getMuzzleVector(0), %range));
   %vehicle.setfrozenstate(true);
   %vehicle.setPosition(%pos);
   %vehicle.ghostLoop = schedule(100, 0, "VehGhostMoveLoop", %obj, %vehicle);
}

function MakeRealVeh(%obj, %veh) {
   cancel(%veh.ghostLoop);
   %obj.VGhost = "";
   %veh.setCloaked(false);
   %veh.setfrozenstate(false);
}
