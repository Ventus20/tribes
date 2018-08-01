datablock ItemData(HookerTool)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_elf.dts";
   image        = HookerToolImage;
   mass         = 1;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
	pickUpName = "a roping tool";

   computeCRC = true;

};

datablock ShapeBaseImageData(HookerToolImage)
{
   className = WeaponImage;
   shapeFile = "weapon_elf.dts";
   item = HookerTool;

   projectile = BasicTargeter;
   projectileType = TargetProjectile;
   deleteLastProjectile = true;

	usesEnergy = true;
	minEnergy = 3;

   stateName[0]                     = "Activate";
   stateSequence[0]                 = "Activate";
	stateSound[0]                    = TargetingLaserSwitchSound;
   stateTimeoutValue[0]             = 0.5;
   stateTransitionOnTimeout[0]      = "ActivateReady";

   stateName[1]                     = "ActivateReady";
   stateTransitionOnAmmo[1]         = "Ready";
   stateTransitionOnNoAmmo[1]       = "NoAmmo";

   stateName[2]                     = "Ready";
   stateTransitionOnNoAmmo[2]       = "NoAmmo";
   stateTransitionOnTriggerDown[2]  = "Fire";

   stateName[3]                     = "Fire";
	stateEnergyDrain[3]              = 0;
   stateFire[3]                     = true;
   stateAllowImageChange[3]         = false;
   stateScript[3]                   = "onFire";
   stateTransitionOnTriggerUp[3]    = "Deconstruction";
   stateTransitionOnNoAmmo[3]       = "Deconstruction";
   stateSound[3]                    = TargetingLaserPaintSound;

   stateName[4]                     = "NoAmmo";
   stateTransitionOnAmmo[4]         = "Ready";

   stateName[5]                     = "Deconstruction";
   stateScript[5]                   = "deconstruct";
   stateTransitionOnTimeout[5]      = "Ready";
};

function HookerToolImage::onmount(%this,%obj,%slot){
   Parent::onMount(%this, %obj, %slot);
   %obj.usingHooker = true;
   bottomPrint(%obj.client, "Using Roping Tool.",2,1);
}

function HookerToolImage::onunmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %obj.usingHooker = false;
}

function HookerToolImage::onfire(%data,%obj,%slot){
   %pos = %obj.getMuzzlePoint($WeaponSlot);
   %vec = %obj.getMuzzleVector($WeaponSlot);
   %targetpos = VectorAdd(%pos, VectorScale(%vec, 100));
   if(%obj.HookerMode == 2)
	%mask = $TypeMasks::VehicleObjectType | $TypeMasks::PlayerObjectType;
   else
	%mask = $TypeMasks::VehicleObjectType | $TypeMasks::PlayerObjectType | $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::StaticShapeObjectType;
   %piece = containerRaycast(%pos, %targetpos, %mask, %obj);
   if(%piece){
	%pieceobj = getword(%piece,0);
	if(%obj.HookerMode == 2 && isobject(%obj.lastHTpiece) && %obj.lastHTpiece != %pieceobj){
	   if(%pieceobj.hooked)
		bottomPrint(%obj.client,"Object already roped",2,1);
	   else{
		%maxdist = vectordist(%pieceobj.getWorldBoxCenter(),%obj.lastHTpiece.getWorldBoxCenter()) + 1;
		%pieceobj.hooked = true;
		%obj.lastHTpiece.hooked = true;
		HWRopeLoop(%pieceobj,%obj.lastHTpiece,%maxdist);
		%obj.lastHTpiece = "";
		bottomPrint(%obj.client,"Objects Roped Togethor",2,1);
	   }
	}
	else if(%obj.HookerMode == 2){
	   if(%pieceobj.hooked)
		bottomPrint(%obj.client,"Object already roped",2,1);
	   else{
	   	%obj.lastHTpiece = %pieceobj;
		%pieceobj.hooked = true;
	   	bottomPrint(%obj.client,"First Object Selected",2,1);
	   }
	}
	else if(%obj.HookerMode == 1){
	   if(%obj.hooked){
		%obj.hooked = false;
		bottomPrint(%obj.client,"Grapple Released",2,1);
	   }
	   else {
		if(%pieceobj.getType() & $TypeMasks::PlayerObjectType || %pieceObj.getType() & $TypeMasks::VehicleObjectType){
		   if(%pieceobj.hooked)
			bottomPrint(%obj.client,"Object already roped",2,1);
		   else{
			%obj.hooked = true;
			%pieceobj.hooked = true;
			%maxdist = vectordist(%obj.getWorldBoxCenter(),%pieceobj.getWorldBoxCenter()) + 1;
			HWRopeLoop(%obj,%pieceobj,%maxdist);
			bottomPrint(%obj.client,"Grapple Object Selected",2,1);
		   }
		}
		else{
		   %obj.hooked = true;
		   %obj.hookedlen = vectordist(%obj.getworldboxcenter(),posFromRaycast(%piece));
		   HTAttachedLoop(%obj,posFromRaycast(%piece));
		   bottomPrint(%obj.client,"Grapple Point Set",2,1);
		}
	   }
	}
   }
   else if(%obj.hooked){
	if(%obj.Hookermode == 1){
	   %obj.hooked = false;
	   bottomPrint(%obj.client,"Grapple Released",2,1);
	}
   }
   %p = Parent::onFire(%data, %obj, %slot);
}

function HTAttachedLoop(%obj,%swingpos){
   if(!isobject(%obj))
	return;
   if(%obj.hooked){
   %pos = %obj.getworldboxcenter();
   %vector = vectorsub(%swingpos,%pos);
   %vector2 = vectorsub(%pos,%swingpos);
   %dist = vectorlen(%vector);
   if(%dist >= %obj.hookedlen){
	%overdist = %dist - %obj.hookedlen;
	%obj.applyimpulse(%pos,vectorscale(vectornormalize(%vector),(%obj.getdatablock().mass * 2 * (%overdist + 1))));
   }
   %obj.rope = new TargetProjectile(){
      dataBlock = HCCRopeBeam;
      initialDirection = vectornormalize(vectorsub(%pos,%swingpos));
      initialPosition  = %swingpos;
      sourceSlot       = 0;
   }; 
   MissionCleanup.add(%obj.rope); 
   %obj.rope.schedule(49, "delete");
   schedule(50, 0, "HTAttachedLoop", %obj, %swingpos);
   }
}

function HWRopeLoop(%obj, %obj2, %maxdist){
  if(%obj.hooked && %obj2.hooked){
   if(isobject(%obj) && isobject(%obj2)){
	%target = %obj2;
	%pos2 = %obj.getworldboxcenter();
	%tpos2 = %target.getWorldBoxCenter();
	%dist = vectordist(%pos2,%tpos2);
	if(%dist >= %maxdist){
	   if(%dist >= (%maxdist * 3)){
		HTbreakbind(%obj, %obj2);
		return;
	   }
	   %pos = %obj.getposition();
	   %tpos = %target.getposition();
	   %mass = %obj.getdatablock().mass;
	   %tmass = %target.getdatablock().mass;
	   %vel = %obj.getvelocity();
	   %tvel = %target.getvelocity();
	   %velF = vectorscale(%vel,%mass);
	   %tvelF = vectorscale(%tvel,%tmass);
	   %vecdif = vectorscale(vectoradd(%velF,%tvelF),(1 / (%mass + %tmass)));
	   %impvec = vectorsub(%vecdif,%vel);
	   %timpvec = vectorsub(%vecdif,%tvel);
	   %mult = ((%dist - %maxdist) / 3) + 1;
	   %obj.applyimpulse(%pos, vectorscale(%impvec,(%mass * %mult))); 
	   %target.applyimpulse(%tpos, vectorscale(%timpvec,(%tmass * %mult))); 
	}
      %obj.rope = new TargetProjectile(){
         dataBlock = HCCRopeBeam;
         initialDirection = vectornormalize(vectorsub(%tpos2,%pos2));
         initialPosition  = %pos2;
         sourceSlot       = 0;
      }; 
      MissionCleanup.add(%obj.rope); 
   	%obj.rope.schedule(249, "delete");
      %obj.pullloop = schedule(250, 0, "HWRopeloop", %obj, %obj2, %maxdist);
   }
   else 
	HTbreakbind(%obj,%obj2);
  }
  else{
     HTbreakbind(%obj,%obj2);
  }
}

function HTbreakbind(%obj,%obj2){
   if(isobject(%obj))
	%obj.hooked = false;
   if(isobject(%obj2))
	%obj2.hooked = false;
}