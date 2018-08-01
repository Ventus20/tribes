// ------------------------------------------------------------------
// Flamer Ammo Pack

datablock ShapeBaseImageData(FlamerAmmoPackImage)
{
   shapeFile = "ammo_plasma.dts";
   item = FlamerAmmoPack;
   mountPoint = 1;
   offset = "0 0 -0.4";
   mass = 32;
};

datablock ItemData(FlamerAmmoPack)
{
   className = Pack;
   catagory = "Packs";
   shapeFile = "ammo_plasma.dts";
   offset = "0 -0.2 -0.55";
   mass = 18.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   rotate = true;
   image = "FlamerAmmoPackImage";
	pickUpName = "an flamer ammo pack";

   computeCRC = true;


//   lightType = "PulsingLight";
//   lightColor = "0.2 0.4 0.0 1.0";
//   lightTime = "1200";
//   lightRadius = "1.0";

	max[FlamerAmmo] = 60;
};

function FlamerAmmoPack::onPickup(%this,%pack,%player,%amount)
{
    %player.hasFlamerAmmopack = 1;
	// %this = AmmoPack datablock
	// %pack = AmmoPack object number
	// %player = player
	// %amount = 1

    %player.incInventory(FlamerAmmo, 60);
}

function FlamerAmmoPack::onThrow(%this,%pack,%player)
{
    %player.hasFlamerAmmopack = 0;
	// %this = AmmoPack datablock
	// %pack = AmmoPack object number
	// %player = player

	%player.throwflamerAmmoPack = 1;
	dropFlamerAmmoPack(%pack, %player);
	// do the normal ItemData::onThrow stuff -- sound and schedule deletion
   serverPlay3D(ItemThrowSound, %player.getTransform());
   %pack.schedulePop();
}

function FlamerAmmoPack::onInventory(%this,%player,%value)
{
    %player.hasFlamerAmmopack = 1;
	// %this = AmmoPack
	// %player = player
	// %value = 1 if gaining a pack, 0 if losing a pack

	// the below test is necessary because this function is called everytime the ammo
	// pack gains or loses an item
	if(%player.getClassName() $= "Player")
	{
		if(!%value)
			if(%player.throwflamerAmmoPack == 1)
			{
				%player.throwflamerAmmoPack = 0;
			}
			else
			{
				dropflamerAmmoPack(-1, %player);
			}
	}
   Pack::onInventory(%this,%player,%value);
}

function dropFlamerAmmoPack(%packObj, %player)
{
    %player.hasFlamerAmmopack = 0;
	// %packObj = Ammo Pack object number if pack is being thrown, -1 if sold at inv station
	// %player = player object

	for(%i = 0; %i < $numAmmoItems; %i++)
	{
		%ammo = $AmmoItem[%i];
		%pAmmo = %player.getInventory(%ammo);
		%pMax = %player.getDatablock().max[%ammo];
		if(%pAmmo > %pMax)
		{
			if(%packObj > 0)
			{
				%packObj.setInventory(%ammo, %pAmmo - %pMax);
			}
			%player.setInventory(%ammo, %pMax);
		}
		else
		{
			if(%packObj > 0)
			{
				%packObj.inv[%ammo] = -1;
			}
		}
	}
}
