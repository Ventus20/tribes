//****************************************\\
//****************************************\\
//****************************************\\
//************ EDITOR GUN ****************\\
//********* By: Phantom139 ***************\\
//****************************************\\
//****************************************\\
//****************************************\\
//*****************************************
//TOOL VARS
$EditorGun::MaxEditDistance = 50;
//
//
//This 'Tool' will allow users to modify pieces without hassle of using
//chat commands such as /Scale and /ObjMove. It is really user friendly
//in the way that you do not need to know any knowledge of the game's
//coordinate system. Just fire at a piece, and then you can scale it
//and move it according to the selected mode. For the more advanced
//players, the piece's coordinates are displayed. Also, when you select
//a pice, a 'Ghost' Piece appears to show what changes will be made

//This Weapon Has Two Modes: Scale and Move
//While Editing, Grenade Cancels, Mine Toggles Axis Snap,
//and Fire Saves Changes

//TERMS OF USE
//1. You will realize the creator of this tool as Phantom139
//2. You will not remove my name on the gun nor will you change it
//3. Using this gun in other mods is prohibited without my permission
//4. Any changes you make to the gun must be forthtold to Phantom139
//5. You must recive content from Phantom139 to use any functions from this gun


datablock ItemData(EditorGun)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_energy.dts";
   image = EditorGunImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a Editing Tool";
};

datablock ShapeBaseImageData(EditorGunImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy.dts";
   item = EditorGun;
   offset = "0 0 0";
   emap = true;
   usesEnergy = true;
   minEnergy = 0.01;

   projectile = EditorBolt; //this really doesn't matter

   RankReqName = "NoRequire"; //Called By TWMFuncitons.cs & Weapons.cs
   projectileType = LinearFlareProjectile;


   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = MortarReloadSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.2;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateSound[3] = DiscFireSound;
   stateScript[3] = "onFire";

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateSound[4] = DiscReloadSound;
   stateEjectShell[4]       = true;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateTimeoutValue[6] = 0.3;
   stateSound[6] = ChaingunDryFireSound;
   stateTransitionOnTimeout[6] = "Ready";
};

function GetEditingMode(%obj) {
   %mode = %obj.EditingGunMode;
   if(%mode == 0) {
      commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Editor Gun - Phantom139 \n <font:Tempus Sans ITC:16>[Scale] Move<spop>", 5, 3);
   }
   else {
      commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Editor Gun - Phantom139 \n <font:Tempus Sans ITC:16>Scale [Move]<spop>", 5, 3);
   }
}

//For Auto Select
function SetEditingSnap(%obj, %Axis) {
   if(%obj.EditingGunMode == 1) {
      if(%Axis $= "") {
         %obj.EditingGunSnap = 0;
      }
      if(%Axis $= "X") {
         %obj.EditingGunSnap = 1;
      }
      if(%Axis $= "Y") {
         %obj.EditingGunSnap = 2;
      }
      if(%Axis $= "Z") {
         %obj.EditingGunSnap = 3;
      }
   }
   else {
      if(%Axis $= "X") {
         %obj.EditingGunSnap = 0;
      }
      else if(%Axis $= "Y") {
         %obj.EditingGunSnap = 1;
      }
      else if(%Axis $= "Z") {
         %obj.EditingGunSnap = 2;
      }
      else {
         %obj.EditingGunSnap = 0;
         error("EditorGun: Invalid Snap Option");
      }
   }
}

function GetEditingSnap(%obj) {
   %mode = %obj.EditingGunSnap;
   if(%obj.EditingGunMode == 1) {
      if(%mode == 0) {
         return "No Snap";
      }
      else if(%mode == 1) {
         return "X Only";
      }
      else if(%mode == 2) {
         return "Y Only";
      }
      else {
         return "Z Only";
      }
   }
   else {
      if(%mode == 0) {
         return "X Axis";
      }
      else if(%mode == 1) {
         return "Y Axis";
      }
      else {
         return "Z Axis";
      }
   }
}


function EditorGunImage::onMount(%this, %obj, %slot) {
Parent::onMount(%this, %obj, %slot);
GetEditingMode(%obj);
%obj.UsingEditorGun = true;
%obj.client.ManipulatingPiece = 0;
%obj.client.PieceEditing.BeingEdited = 0;
%obj.client.PieceEditing = "";
%obj.GhostPiece = "";
}

function EditorGunImage::onunmount(%this,%obj,%slot) {
Parent::onUnmount(%this, %obj, %slot);
%obj.UsingEditorGun = false;
%obj.client.ManipulatingPiece = 0;
%obj.client.PieceEditing.BeingEdited = 0;
%obj.client.PieceEditing = "";
%obj.GhostPiece = "";
}

function EditorGunImage::onFire(%data, %obj, %slot) {
    %vector = %obj.getMuzzleVector(%slot);
    %mp = %obj.getMuzzlePoint(%slot);
    %targetpos   = vectoradd(%mp,vectorscale(%vector,$EditorGun::MaxEditDistance));
    %targ         = containerraycast(%mp,%targetpos,$typemasks::staticshapeobjecttype,%obj);
    %targ         = getword(%targ, 0);
    if(%targ == 0 && !%obj.client.ManipulatingPiece) {
       BottomPrint(%obj.client, "No Object Found", 2, 2);
       return;
    }
    if (!Deployables.isMember(%targ) && !%obj.client.ManipulatingPiece) {
       messageclient(%obj.client, 'MsgClient', "\c2Editor: Error, Map Object Selected.");
       return;
    }
    if(!%obj.client.ManipulatingPiece) {
       %cn = %targ.getDatablock().ClassName;
       if(strstr(%cn, "Vehicle") != -1) {
          BottomPrint(%obj.client, "Cannot Edit Vehicles", 2, 2);
          return;
       }
    }
    EditorGunModifyPiece(%targ, %obj);
}

function EditorGunModifyPiece(%tobj, %plyr) {
   //If We Are Currently Editing.. Save Positon
   if(%plyr.client.ManipulatingPiece) {
      SaveNewPiece(%tobj, %plyr);
      commandToClient( %plyr.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Editor Gun\n <font:Tempus Sans ITC:16>Piece Locked And Edited<spop>", 1, 3);
      return;
   }
   //
   %cl=%plyr.client;
   if ( %tobj.ownerGUID != %cl.guid){
      if (!%cl.isadmin && !%cl.issuperadmin){
         if (%tobj.ownerGUID !$=""){
            messageclient(%cl, 'MsgClient', "\c2Editor: Error, You Do Not Own This Piece.");
            return;
         }
      }
   }
   if (%tobj.squaresize !$="") { //check if terain was selected
      messageclient(%cl, 'MsgClient', "\c2Editor: Error, Unknown Object Selected.");
      return;
   }
   if (%tobj.BeingEdited) { //check if this piece can be edited
      messageclient(%cl, 'MsgClient', "\c2Editor: Error, This piece is being edited.");
      return;
   }
   //All is Good
   %plyr.client.PieceEditing = %tobj;
   %plyr.client.PieceEditing.BeingEdited = 1;
   %tobj.setCloaked(true);
   %tobj.schedule(500, "setCloaked" ,false);
   //
   %mode = %plyr.EditingGunMode;
   %plyr.client.ManipulatingPiece = 1;
   %plyr.EditPieceDist = VectorDist(%plyr.getPosition(), %tobj.GetPosition()); //this will be the distance we keep
   //Pick The Axis
   %axis = getAxis(%plyr, %tobj);
   SetEditingSnap(%plyr, %axis);
   //
   CreateEditorGhost(%tobj, %plyr, %mode);
}

function CreateEditorGhost(%tobj, %plyr, %mode) {
   if(!isObject(%plyr) || %plyr.getState() $= "dead") {
      %plyr.client.GhostPiece.delete();
      %plyr.client.PieceEditing = "";
      %plyr.client.PieceEditing.BeingEdited = 0;
      %plyr.client.ManipulatingPiece = 0;
   }
   if(%plyr.client.ManipulatingPiece) {
      //
      %classname= %tobj.getDataBlock().classname;
      %objscale = %tobj.scale;
      %grounded = %tobj.grounded;
      %pwr      = %tobj.powerFreq;
      %trs      = %tobj.getTransform();
      if(%mode == 1) {
         if(!isObject(%plyr.client.GhostPiece)) {
            %scale = %tobj.GetRealSize();
            %plyr.client.GhostPiece = new ("StaticShape")() {
	           dataBlock = %tobj.getDatablock().getName();
            };
            %deplObj = %plyr.client.GhostPiece;
            %deplObj.SetRealSize(%scale);
            %deplObj.setTransform(%trs);
            addDSurface(%item.surface,%deplObj);
	        %deplObj.grounded = %grounded;
	        %deplObj.needsFit = 1;
	        %deplObj.team = %team;
	        %deplObj.Ownerguid=%ownerGUID;
            %deplObj.Owner=%owner;
	        %deplObj.powerFreq = %pwr;
            %deplObj.OriginalPos = %tobj.OriginalPos;
            if (%deplObj.getTarget() != -1)
               setTargetSensorGroup(%deplObj.getTarget(), %plyr.client.team);
            addToDeployGroup(%deplObj);
            AIDeployObject(%plyr.client, %deplObj);
            %deplObj.deploy();
            checkPowerObject(%deplObj);
            %plyr.client.GhostPiece.setCloaked(true);
            zapObject(%plyr.client.GhostPiece);
            %plyr.client.GhostPiece.BeingEdited = 1;
         }
         else {
            %eyeVec   = %plyr.getMuzzleVector(0);
            %eyeTrans = %plyr.getMuzzlePoint(0);
            %eyePos = posFromTransform(%eyeTrans);
            %nEyeVec = VectorNormalize(%eyeVec);
            %scEyeVec = VectorScale(%nEyeVec, %plyr.EditPieceDist);
            %eyeEnd = VectorAdd(%eyePos, %scEyeVec);
            %PosEnd = %plyr.client.GhostPiece.getPosition();
            //SNAPS: 0- none, 1- x, 2- y, 3- z
            %xEye = getWord(%eyeEnd, 0);
            %yEye = getWord(%eyeEnd, 1);
            %zEye = getWord(%eyeEnd, 2);
            %xPiece = getWord(%PosEnd, 0);
            %yPiece = getWord(%PosEnd, 1);
            %zPiece = getWord(%PosEnd, 2);
            %snapSet = %plyr.EditingGunSnap;
            if(%snapset == 0) {
               %plyr.client.GhostPiece.setTransform(%eyeEnd);
            }
            else if(%snapset == 1) {
               %plyr.client.GhostPiece.setTransform(""@%xEye@" "@%yPiece@" "@%zPiece@"");
            }
            else if(%snapset == 2) {
               %plyr.client.GhostPiece.setTransform(""@%xPiece@" "@%yEye@" "@%zPiece@"");
            }
            else if(%snapset == 3) {
               %plyr.client.GhostPiece.setTransform(""@%xPiece@" "@%yPiece@" "@%zEye@"");
            }
            %snap = GetEditingSnap(%plyr);
            commandToClient( %plyr.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Editing "@%tobj.getDatablock().getName()@" \n <font:Tempus Sans ITC:16>[Fire] To Set, [Grenade] To Cancel, [Mine] To Axis Snap : "@%snap@" \n Ghost Position: "@%plyr.client.GhostPiece.getPosition()@"<spop>", 1, 3);
         }
      }
      else {
         if(!isObject(%plyr.client.GhostPiece)) {
            %scale = %tobj.GetRealSize();
            %plyr.client.GhostPiece = new ("StaticShape")() {
	           dataBlock = %tobj.getDatablock().getName();
            };
            %deplObj = %plyr.client.GhostPiece;
            %deplObj.SetRealSize(%scale);
            %deplObj.setTransform(%trs);
            addDSurface(%item.surface,%deplObj);
	        %deplObj.grounded = %grounded;
	        %deplObj.needsFit = 1;
	        %deplObj.team = %team;
	        %deplObj.Ownerguid=%ownerGUID;
            %deplObj.Owner=%owner;
	        %deplObj.powerFreq = %pwr;
            %deplObj.OriginalPos = %tobj.OriginalPos;
            if (%deplObj.getTarget() != -1)
               setTargetSensorGroup(%deplObj.getTarget(), %plyr.client.team);
            addToDeployGroup(%deplObj);
            AIDeployObject(%plyr.client, %deplObj);
            %deplObj.deploy();
            checkPowerObject(%deplObj);
            %plyr.client.GhostPiece.setCloaked(true);
            zapObject(%plyr.client.GhostPiece);
            %plyr.client.GhostPiece.BeingEdited = 1;
            //Save the original 'Look At' Vector
            %plyr.client.SAVEeyeVec   = %plyr.getMuzzleVector(0);
            %plyr.client.SAVEeyeTrans = %plyr.getMuzzlePoint(0);
            %plyr.client.SAVEeyePos = posFromTransform(%plyr.client.SAVEeyeTrans);
            %plyr.client.SAVEnEyeVec = VectorNormalize(%plyr.client.SAVEeyeVec);
            %plyr.client.SAVEscEyeVec = VectorScale(%plyr.client.SAVEnEyeVec, %plyr.EditPieceDist);
            %plyr.client.SAVEeyeEnd = VectorAdd(%plyr.client.SAVEeyePos, %plyr.client.SAVEscEyeVec);
            //
         }
         else {
            %eyeVec   = %plyr.getMuzzleVector(0);
            %eyeTrans = %plyr.getMuzzlePoint(0);
            %eyePos = posFromTransform(%eyeTrans);
            %nEyeVec = VectorNormalize(%eyeVec);
            %scEyeVec = VectorScale(%nEyeVec, %plyr.EditPieceDist);
            %eyeEnd = VectorAdd(%eyePos, %scEyeVec);
            //take the saved to the current for distance change
            %distChange = vectorDist(%plyr.client.SAVEeyeEnd, %eyeEnd);
            %currentScale = %plyr.client.PieceEditing.getRealSize();
            %xPiece = getWord(%currentScale, 0);
            %yPiece = getWord(%currentScale, 1);
            %zPiece = getWord(%currentScale, 2);
            %snapSet = %plyr.EditingGunSnap;
            if(%snapset == 0) {
               %plyr.client.GhostPiece.SetRealSize(""@%distChange@" "@%yPiece@" "@%zPiece@"");
            }
            else if(%snapset == 1) {
               %plyr.client.GhostPiece.SetRealSize(""@%xPiece@" "@%distChange@" "@%zPiece@"");
            }
            else if(%snapset == 2) {
               %plyr.client.GhostPiece.SetRealSize(""@%xPiece@" "@%yPiece@" "@%distChange@"");
            }
            %snap = GetEditingSnap(%plyr);
            commandToClient( %plyr.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Editing "@%tobj.getDatablock().getName()@" \n <font:Tempus Sans ITC:16>[Fire] To Set, [Grenade] To Cancel, [Mine] To Axis Snap : "@%snap@" \n Ghost Scale: "@%plyr.client.GhostPiece.getRealSize()@"<spop>", 1, 3);
         }
      }
      //
      schedule(150,0,"CreateEditorGhost" ,%tobj, %plyr, %mode);
   }
   else {
      if(isObject(%plyr.client.GhostPiece)) {
         %plyr.client.GhostPiece.delete();
         %plyr.client.PieceEditing.BeingEdited = 0;
         %plyr.client.PieceEditing = "";
      }
      //do nothing
   }
}

function SaveNewPiece(%tobj, %plyr) {
   //what mode are we in?
   %mode = %plyr.EditingGunMode;
   if(%mode == 1) {
      %plyr.client.PieceEditing.setTransform(%plyr.client.GhostPiece.getTransform());
      adjustTrigger(%plyr.client.PieceEditing);
   }
   else {
      %scale = %plyr.client.GhostPiece.getRealSize();
      //FAIL SAFE
      //Prevent Ub3r Small Scales
      %ScalarX = getWord(%scale, 0);
      %ScalarY = getWord(%scale, 1);
      %ScalarZ = getWord(%scale, 2);
      if(%ScalarX < 0.1) {
         %ScalarX = 0.1;
      }
      if(%ScalarY < 0.1) {
         %ScalarY = 0.1;
      }
      if(%ScalarZ < 0.1) {
         %ScalarZ = 0.1;
      }
      %newScale = ""@%ScalarX@" "@%ScalarY@" "@%ScalarZ@"";
      //
      %plyr.client.PieceEditing.SetRealSize(%newScale);
   }
   //and lastly, delete the original
   %plyr.client.PieceEditing.BeingEdited = 0;
   %plyr.client.GhostPiece.delete();
   %plyr.client.GhostPiece = "";
   %plyr.client.PieceEditing = "";
   %plyr.client.ManipulatingPiece = 0;
}

//This function is for Auto Axis Select
function getAxis(%plyr, %TObj) {
    //Scan to see where we are looking at
    %point = getEyeRaycastPt(%plyr, $EditorGun::MaxEditDistance + 5);  //Max edit distance + 5
    %ObjCenter = %TObj.getEdge("0 0 0");
     
    %smallest = 999999;
    //Thanks for showing me how to use getEdge Krash
	%PAxis[0] = %TObj.getEdge("1 0 0");   //Positive X
	%PAxis[1] = %TObj.getEdge("-1 0 0");  //Negative X
	%PAxis[2] = %TObj.getEdge("0 1 0");   //Positive Y
	%PAxis[3] = %TObj.getEdge("0 -1 0");  //Negative Y
	%PAxis[4] = %TObj.getEdge("0 0 1");   //Positive Z
	%PAxis[5] = %TObj.getEdge("0 0 -1");  //Negative Z
 
	for (%i = 0; %i < 6; %i++) { //6 Axis' To Scan
       %dist[%i] = vectorDist(%PAxis[%i], %point);
       %fdist[%i] = vectorDist(%dist[%i], %ObjCenter);
	   if (%fdist[%i] < %smallest) {
          %smallest = %fdist[%i];
	      %EdgeToUse = %i;
       }
    }
    //Now Set That Edge As The Axis
    if(%EdgeToUse == 0 || %EdgeToUse == 1) {
       %Axis = "X";
    }
    else if(%EdgeToUse == 2 || %EdgeToUse == 3) {
       %Axis = "Y";
    }
    else if(%EdgeToUse == 4 || %EdgeToUse == 5) {
       %Axis = "Z";
    }
    else {
       %Axis = ""; //We Can Have Potential Errors, No Chances Taken
       Error("EditorGun: getAxis: Unable To Pull An Axis");
    }
    return %Axis;
}
