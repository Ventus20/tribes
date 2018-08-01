//--------------------------------------------------------------------------
//
// Plasma barrel pack
//
//--------------------------------------------------------------------------

datablock ShapeBaseImageData(PBCBarrelPackImage)
{
   mass = 10; // z0dd - ZOD, 7/17/02. Lower mass due to higher gravity. Was 15.

   shapeFile  = "pack_barrel_fusion.dts";
   item       = PBCBarrelPack;
   mountPoint = 1;
   offset     = "0 0 0";
	turretBarrel = "PBCBarrelLarge";

	stateName[0] = "Idle";
	stateTransitionOnTriggerDown[0] = "Activate";

	stateName[1] = "Activate";
	stateScript[1] = "onActivate";
	stateTransitionOnTriggerUp[1] = "Deactivate";

	stateName[2] = "Deactivate";
	stateScript[2] = "onDeactivate";
	stateTransitionOnTimeOut[2] = "Idle";

	isLarge = true;
};

datablock ItemData(PBCBarrelPack)
{
   className    = Pack;
   catagory     = "Packs";
   shapeFile    = "pack_barrel_fusion.dts";
   mass         = 1;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   rotate       = true;
   image        = "PBCBarrelPackImage";
	pickUpName = "a PBC Turret Barrel";

   computeCRC = true;

};

function PBCBarrelPackImage::onActivate(%data, %obj, %slot)
{
	checkTurretMount(%data, %obj, %slot);
}

function PBCBarrelPackImage::onDeactivate(%data, %obj, %slot)
{
	%obj.setImageTrigger($BackpackSlot, false);
}

function PBCBarrelPack::onPickup(%this, %obj, %shape, %amount)
{
	// created to prevent console errors
}
