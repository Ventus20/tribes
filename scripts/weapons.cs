$HandInvThrowTimeout = 0.8 * 1000; // 1/2 second between throwing grenades or mines

// z0dd - ZOD, 9/13/02. Added global array for serverside weapon reticles and "visible"

$WeaponsHudData[0, bitmapName]   = "gui/hud_targetlaser";
$WeaponsHudData[0, itemDataName] = "TargetingLaser";
$WeaponsHudData[0, reticle] = "gui/hud_ret_targlaser";
$WeaponsHudData[0, visible] = "false";

$WeaponsHudData[1, bitmapName]   = "gui/hud_shocklance";
$WeaponsHudData[1, itemDataName] = "ConstructionTool";
$WeaponsHudData[1, reticle] = "gui/hud_ret_sniper";
$WeaponsHudData[1, visible] = "false";

$WeaponsHudData[2, bitmapName] = "gui/hud_chaingun";
$WeaponsHudData[2, itemDataName] = "SuperChaingun";
$WeaponsHudData[2, reticle] = "gui/ret_chaingun";
$WeaponsHudData[2, visible] = "true";

$WeaponsHudData[3, bitmapName]   = "gui/hud_grenlaunch";
$WeaponsHudData[3, itemDataName] = "TractorGun";
$WeaponsHudData[3, reticle] = "gui/ret_grenade";
$WeaponsHudData[3, visible] = "true";

$WeaponsHudData[4, bitmapName] = "gui/hud_chaingun";
$WeaponsHudData[4, itemDataName] = "RPChaingun";
$WeaponsHudData[4, ammoDataName] = "MGClip";
$WeaponsHudData[4, reticle] = "gui/ret_chaingun";
$WeaponsHudData[4, visible] = "true";

$WeaponsHudData[5, bitmapName] = "gui/hud_sniper";
$WeaponsHudData[5, itemDataName] = "LMissileLauncher";
$WeaponsHudData[5, ammoDataName] = "LMissileLauncherAmmo";
$WeaponsHudData[5, reticle] = "gui/hud_ret_sniper";
$WeaponsHudData[5, visible] = "true";

$WeaponsHudData[6, bitmapName] = "gui/hud_sniper";
$WeaponsHudData[6, itemDataName] = "snipergun";
$WeaponsHudData[6, ammoDataName] = "snipergunAmmo";
$WeaponsHudData[6, reticle] = "gui/hud_ret_sniper";
$WeaponsHudData[6, visible] = "true";

$WeaponsHudData[7, bitmapName] = "gui/hud_missiles";
$WeaponsHudData[7, itemDataName] = "Bazooka";
$WeaponsHudData[7, ammoDataName] = "BazookaAmmo";
$WeaponsHudData[7, reticle] = "gui/ret_missile";
$WeaponsHudData[7, visible] = "true";

$WeaponsHudData[8, bitmapName] = "gui/hud_mortor";
$WeaponsHudData[8, itemDataName] = "BunkerBuster";
$WeaponsHudData[8, reticle] = "gui/ret_mortor";
$WeaponsHudData[8, visible] = "true";

$WeaponsHudData[9, bitmapName] = "gui/hud_chaingun";
$WeaponsHudData[9, itemDataName] = "MG42";
$WeaponsHudData[9, ammoDataName] = "MG42Clip";
$WeaponsHudData[9, reticle] = "gui/ret_chaingun";
$WeaponsHudData[9, visible] = "true";

$WeaponsHudData[10, bitmapName] = "gui/hud_chaingun";
$WeaponsHudData[10, itemDataName] = "Pistol";
$WeaponsHudData[10, reticle] = "gui/ret_chaingun";
$WeaponsHudData[10, visible] = "true";

$WeaponsHudData[11, bitmapName] = "gui/hud_plasma";
$WeaponsHudData[11, itemDataName] = "flamer";
$WeaponsHudData[11, ammoDataName] = "flamerAmmo";
$WeaponsHudData[11, reticle] = "gui/ret_plasma";
$WeaponsHudData[11, visible] = "true";

$WeaponsHudData[12, bitmapName] = "gui/hud_shocklance";
$WeaponsHudData[12, itemDataName] = "KriegRifle";
$WeaponsHudData[12, ammoDataName] = "RifleClip";
$WeaponsHudData[12, reticle] = "gui/hud_ret_shocklance";
$WeaponsHudData[12, visible] = "true";

$WeaponsHudData[13, bitmapName] = "gui/hud_missiles";
$WeaponsHudData[13, itemDataName] = "AALauncher";
$WeaponsHudData[13, ammoDataName] = "AALauncherAmmo";
$WeaponsHudData[13, reticle] = "gui/ret_missile";
$WeaponsHudData[13, visible] = "true";

$WeaponsHudData[14, bitmapName] = "gui/hud_plasma";
$WeaponsHudData[14, itemDataName] = "melee";
$WeaponsHudData[14, reticle] = "gui/ret_plasma";
$WeaponsHudData[14, visible] = "true";

$WeaponsHudData[15, bitmapName] = "gui/hud_chaingun";
$WeaponsHudData[15, itemDataName] = "SPistol";
$WeaponsHudData[15, reticle] = "gui/ret_chaingun";
$WeaponsHudData[15, visible] = "true";

$WeaponsHudData[16, bitmapName] = "gui/hud_plasma";
$WeaponsHudData[16, itemDataName] = "SOmelee";
$WeaponsHudData[16, reticle] = "gui/ret_plasma";
$WeaponsHudData[16, visible] = "true";

$WeaponsHudData[17, bitmapName] = "gui/hud_chaingun";
$WeaponsHudData[17, itemDataName] = "Shotgun";
$WeaponsHudData[17, ammoDataName] = "ShotgunClip";
$WeaponsHudData[17, reticle] = "gui/ret_chaingun";
$WeaponsHudData[17, visible] = "true";

$WeaponsHudData[18, bitmapName] = "gui/hud_chaingun";
$WeaponsHudData[18, itemDataName] = "RShotgun";
$WeaponsHudData[18, ammoDataName] = "RShotgunClip";
$WeaponsHudData[18, reticle] = "gui/ret_chaingun";
$WeaponsHudData[18, visible] = "true";

$WeaponsHudData[19, bitmapName] = "gui/hud_chaingun";
$WeaponsHudData[19, itemDataName] = "HRPChaingun";
$WeaponsHudData[19, ammoDataName] = "MGClip";
$WeaponsHudData[19, reticle] = "gui/ret_chaingun";
$WeaponsHudData[19, visible] = "true";

$WeaponsHudData[20, bitmapName] = "gui/hud_chaingun";
$WeaponsHudData[20, itemDataName] = "LSMG";
$WeaponsHudData[20, ammoDataName] = "LSMGClip";
$WeaponsHudData[20, reticle] = "gui/ret_chaingun";
$WeaponsHudData[20, visible] = "true";

$WeaponsHudData[21, bitmapName]   = "gui/hud_shocklance";
$WeaponsHudData[21, itemDataName] = "MergeTool";
$WeaponsHudData[21, reticle] = "gui/hud_ret_sniper";
$WeaponsHudData[21, visible] = "false";

$WeaponsHudData[22, bitmapName]   = "gui/hud_shocklance";
$WeaponsHudData[22, itemDataName] = "HookerTool";
$WeaponsHudData[22, reticle] = "gui/hud_ret_sniper";
$WeaponsHudData[22, visible] = "false";

$WeaponsHudData[23, bitmapName] = "gui/hud_sniper";
$WeaponsHudData[23, itemDataName] = "PBC";
$WeaponsHudData[23, ammoDataName] = "PBCAmmo";
$WeaponsHudData[23, reticle] = "gui/hud_ret_sniper";
$WeaponsHudData[23, visible] = "true";

$WeaponsHudData[24, bitmapName] = "gui/hud_shocklance";
$WeaponsHudData[24, itemDataName] = "SRifleSG";
$WeaponsHudData[24, ammoDataName] = "MGClip";
$WeaponsHudData[24, reticle] = "gui/hud_ret_shocklance";
$WeaponsHudData[24, visible] = "true";

$WeaponsHudData[25, bitmapName] = "gui/hud_shocklance";
$WeaponsHudData[25, itemDataName] = "SRifleGL";
$WeaponsHudData[25, ammoDataName] = "MGClip";
$WeaponsHudData[25, reticle] = "gui/hud_ret_shocklance";
$WeaponsHudData[25, visible] = "true";

$WeaponsHudData[26, bitmapName]   = "gui/hud_blaster";
$WeaponsHudData[26, itemDataName] = "PulsePhaser";
$WeaponsHudData[26, reticle] = "gui/ret_blaster";
$WeaponsHudData[26, visible] = "true";

$WeaponsHudData[27, bitmapName] = "gui/hud_shocklance";
$WeaponsHudData[27, itemDataName] = "PhotonLaser";
$WeaponsHudData[27, reticle] = "gui/hud_ret_shocklance";
$WeaponsHudData[27, visible] = "true";

$WeaponsHudData[28, bitmapName] = "gui/hud_missiles";
$WeaponsHudData[28, itemDataName] = "Targeter";
$WeaponsHudData[28, reticle] = "gui/ret_missile";
$WeaponsHudData[28, visible] = "true";

$WeaponsHudData[29, bitmapName] = "gui/hud_missiles";
$WeaponsHudData[29, itemDataName] = "PulseChaingun";
$WeaponsHudData[29, ammoDataName] = "PulseChaingunAmmo";
$WeaponsHudData[29, reticle] = "gui/ret_missile";
$WeaponsHudData[29, visible] = "true";

$WeaponsHudData[30, bitmapName] = "gui/hud_blaster";
$WeaponsHudData[30, itemDataName] = "lasergun";
$WeaponsHudData[30, ammoDataName] = "lasergunAmmo";
$WeaponsHudData[30, reticle] = "gui/ret_blaster";
$WeaponsHudData[30, visible] = "true";

$WeaponsHudData[31, bitmapName] = "gui/hud_missiles";
$WeaponsHudData[31, itemDataName] = "BazookaII";
$WeaponsHudData[31, ammoDataName] = "BazookaIIAmmo";
$WeaponsHudData[31, reticle] = "gui/ret_missile";
$WeaponsHudData[31, visible] = "true";

$WeaponsHudData[32, bitmapName] = "gui/hud_chaingun";
$WeaponsHudData[32, itemDataName] = "BattleRifle";
$WeaponsHudData[32, ammoDataName] = "BattleAmmo";
$WeaponsHudData[32, reticle] = "gui/hud_ret_sniper";
$WeaponsHudData[32, visible] = "true";

$WeaponsHudData[33, bitmapName] = "gui/hud_chaingun";
$WeaponsHudData[33, itemDataName] = "spiker";
$WeaponsHudData[33, reticle] = "gui/ret_chaingun";
$WeaponsHudData[33, visible] = "true";

$WeaponsHudData[34, bitmapName] = "gui/hud_missiles";
$WeaponsHudData[34, itemDataName] = "portibleGauss";
$WeaponsHudData[34, ammoDataName] = "portibleGaussAmmo";
$WeaponsHudData[34, reticle] = "gui/hud_ret_sniper";
$WeaponsHudData[34, visible] = "true";

$WeaponsHudData[35, bitmapName] = "gui/hud_chaingun";
$WeaponsHudData[35, itemDataName] = "Deagle";
$WeaponsHudData[35, reticle] = "gui/hud_ret_sniper";
$WeaponsHudData[35, visible] = "true";

$WeaponsHudData[36, bitmapName] = "gui/hud_chaingun";
$WeaponsHudData[36, itemDataName] = "EditTool";
$WeaponsHudData[36, reticle] = "gui/ret_chaingun";
$WeaponsHudData[36, visible] = "true";

$WeaponsHudData[37, bitmapName] = "gui/hud_missiles";
$WeaponsHudData[37, itemDataName] = "Napalm";
$WeaponsHudData[37, ammoDataName] = "NapalmAmmo";
$WeaponsHudData[37, reticle] = "gui/ret_missile";
$WeaponsHudData[37, visible] = "true";

$WeaponsHudData[38, bitmapName] = "gui/hud_shocklance";
$WeaponsHudData[38, itemDataName] = "VoltageCannon";
$WeaponsHudData[38, ammoDataName] = "VoltageCannonAmmo";
$WeaponsHudData[38, reticle] = "gui/hud_ret_shocklance";
$WeaponsHudData[38, visible] = "true";

$WeaponsHudData[39, bitmapName] = "gui/hud_shocklance";
$WeaponsHudData[39, itemDataName] = "ShockLance";
$WeaponsHudData[39, reticle] = "gui/hud_ret_shocklance";
$WeaponsHudData[39, visible] = "true";

$WeaponsHudData[40, bitmapName] = "gui/hud_shocklance";
$WeaponsHudData[40, itemDataName] = "ALSWP";
$WeaponsHudData[40, ammoDataName] = "ALSWPAmmo";
$WeaponsHudData[40, reticle] = "gui/hud_ret_shocklance";
$WeaponsHudData[40, visible] = "true";

$WeaponsHudData[41, bitmapName] = "gui/hud_shocklance";
$WeaponsHudData[41, itemDataName] = "RCMissile";
$WeaponsHudData[41, reticle] = "gui/hud_ret_shocklance";
$WeaponsHudData[41, visible] = "true";

$WeaponsHudData[42, bitmapName] = "gui/hud_shocklance";
$WeaponsHudData[42, itemDataName] = "Scorcher";
$WeaponsHudData[42, ammoDataName] = "ScorcherAmmo";
$WeaponsHudData[42, reticle] = "gui/hud_ret_shocklance";
$WeaponsHudData[42, visible] = "true";

$WeaponsHudData[43, bitmapName] = "gui/hud_shocklance";
$WeaponsHudData[43, itemDataName] = "EditorGun";
$WeaponsHudData[43, reticle] = "gui/hud_ret_shocklance";
$WeaponsHudData[43, visible] = "true";

$WeaponsHudData[44, bitmapName] = "gui/hud_chaingun";
$WeaponsHudData[44, itemDataName] = "DualLSMG";
$WeaponsHudData[44, ammoDataName] = "DualLSMGClip";
$WeaponsHudData[44, reticle] = "gui/ret_chaingun";
$WeaponsHudData[44, visible] = "true";

$WeaponsHudData[45, bitmapName] = "gui/hud_chaingun";
$WeaponsHudData[45, itemDataName] = "Dualpistol";
$WeaponsHudData[45, reticle] = "gui/hud_ret_shocklance";
$WeaponsHudData[45, visible] = "true";

$WeaponsHudData[46, bitmapName] = "gui/hud_missiles";
$WeaponsHudData[46, itemDataName] = "PlasmaLauncher";
$WeaponsHudData[46, ammoDataName] = "PlasmaLauncherAmmo";
$WeaponsHudData[46, reticle] = "gui/ret_missile";
$WeaponsHudData[46, visible] = "true";

$WeaponsHudCount = 47;
//[most]

$AmmoIncrement[PlasmaAmmo]          = 10;
$AmmoIncrement[ChaingunAmmo]        = 500;
$AmmoIncrement[DiscAmmo]            = 5;
$AmmoIncrement[GrenadeLauncherAmmo] = 5;
$AmmoIncrement[MortarAmmo]          = 5;
$AmmoIncrement[MissileLauncherAmmo] = 2;
$AmmoIncrement[Mine]                = 3;
$AmmoIncrement[Grenade]             = 5;
$AmmoIncrement[IncindinaryGrenade]             = 5;
$AmmoIncrement[FlashGrenade]        = 5;
$AmmoIncrement[FlareGrenade]        = 5;
$AmmoIncrement[ConcussionGrenade]   = 5;
$AmmoIncrement[RepairKit]           = 1;

// -------------------------------------------------------------------
// z0dd - ZOD, 4/17/02. Addition. Ammo pickup fix, these were missing.
$AmmoIncrement[CameraGrenade]       = 2;
$AmmoIncrement[Beacon]              = 1;

$AmmoIncrement[NerfBallLauncherAmmo]= 5;
$AmmoIncrement[SuperChaingunAmmo]   = 250;
$AmmoIncrement[RPChaingunAmmo] = 30;
$AmmoIncrement[MGClip] = 1;
$AmmoIncrement[snipergunAmmo] = 10;
$AmmoIncrement[BazookaAmmo] = 5;
$AmmoIncrement[MG42Ammo] = 200;
$AmmoIncrement[MG42Clip] = 1;
$AmmoIncrement[flamerAmmo] = 25;
$AmmoIncrement[AALauncherAmmo] = 1;
$AmmoIncrement[KriegAmmo] = 5;
$AmmoIncrement[RifleClip] = 1;
$AmmoIncrement[ShotgunAmmo] = 8;
$AmmoIncrement[ShotgunClip] = 1;
$AmmoIncrement[RShotgunAmmo] = 25;
$AmmoIncrement[RShotgunClip] = 1;
$AmmoIncrement[LMissileLauncherAmmo] = 1;
$AmmoIncrement[RPGAmmo] = 1;
$AmmoIncrement[SmokeGrenade]= 5;
$AmmoIncrement[BeaconSmokeGrenade]= 2;
$AmmoIncrement[LSMGAmmo] = 20;
$AmmoIncrement[LSMGClip] = 1;
$AmmoIncrement[PBCAmmo] = 1;
$AmmoIncrement[SRifleAmmo] = 15;

//----------------------------------------------------------------------------
// Weapons scripts
//--------------------------------------

// --- Mounting weapons
exec("scripts/weapons/allweapons.cs");
exec("scripts/weapons/Spiker.cs");         //Phantom Spiker
exec("scripts/weapons/missileLauncher.cs");
exec("scripts/weapons/targetingLaser.cs");
exec("scripts/weapons/shockLance.cs");
//UE FIX
compile("scripts/weapons/constructiontool.cs");
exec("scripts/weapons/constructionTool.cs");
//-----
exec("scripts/weapons/nerfGun.cs");
exec("scripts/weapons/nerfBallLauncher.cs");
exec("scripts/weapons/superChaingun.cs");
exec("scripts/weapons/RPChaingun.cs");
exec("scripts/weapons/snipergun.cs");
exec("scripts/weapons/bazooka.cs");
exec("scripts/weapons/BunkerBuster.cs");
exec("scripts/weapons/MG42.cs");
exec("scripts/weapons/Pistol.cs");
exec("scripts/weapons/flamethrower.cs");
exec("scripts/weapons/rocketLauncher.cs");
exec("scripts/weapons/melee.cs");
exec("scripts/weapons/Krieg.cs");
exec("scripts/weapons/Shotgun.cs");
exec("scripts/weapons/LightMachineGun.cs");
exec("scripts/weapons/modifiertool.cs");
//exec("scripts/weapons/Hooker.cs");
exec("scripts/weapons/PBC.cs");
exec("scripts/weapons/SRifle.cs");
exec("scripts/weapons/shocklance.cs");

// --- Throwing weapons
exec("scripts/weapons/mine.cs");
exec("scripts/weapons/grenade.cs");
exec("scripts/weapons/Incindinarygrenade.cs");
exec("scripts/weapons/Smokegrenade.cs");
exec("scripts/weapons/flashGrenade.cs");
exec("scripts/weapons/flareGrenade.cs");
exec("scripts/weapons/concussionGrenade.cs");
exec("scripts/weapons/cameraGrenade.cs");

//----------------------------------------------------------------------------

function Weapon::onUse(%data, %obj)
{
   if(Game.weaponOnUse(%data, %obj))
      if (%obj.getDataBlock().className $= Armor)
         %obj.mountImage(%data.image, $WeaponSlot);
}

function WeaponImage::onMount(%this,%obj,%slot) {
   //MES -- is call below useful at all?
   //Parent::onMount(%this, %obj, %slot);
   if(%obj.getClassName() !$= "Player")
      return;

   %name = %this.RankReqName;
   if($Host::RankSystem == 1) {
      if(!isObject(%obj)) {
         return;
      }
      if(!%obj.client.isaicontrolled()) {
         if(%name !$= "NoRequire") { //so we can use the 'NoRequire' Flag -2.9C
            if($Rank::XP[%obj.client.GUID] < $TWM::WeaponRequirement[%name]) {
               commandToClient( %obj.client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>Your Rank Is Too Low To Use This Weapon \n You need "@$TWM::WeaponRequirement[%name]@" EXP<spop>", 5, 2);
               %obj.setInventory(%this.Item, 0, true);
               //This works.. for now
               %obj.UnmountImage(2);
               %obj.UnmountImage(3);
               %obj.UnmountImage(4);
               %obj.UnmountImage(5);
               %obj.UnmountImage(6);
               %obj.UnmountImage(7);
               %obj.UnmountImage(8);
               %obj.UnmountImage(9);
               %obj.UnmountImage(10);
               //
            }
         }
      }
   }
   //messageClient(%obj.client, 'MsgWeaponMount', "", %this, %obj, %slot);
   // Looks arm position
   if (%this.armthread $= "")
   {
      %obj.setArmThread(look);
   }
   else
   {
      %obj.setArmThread(%this.armThread);
   }
   // Initial ammo state
   if(%obj.getMountedImage($WeaponSlot).ammo !$= "")
      if (%obj.getInventory(%this.ammo))
         %obj.setImageAmmo(%slot,true);

   %obj.client.setWeaponsHudActive(%this.item);
   if(%obj.getMountedImage($WeaponSlot).ammo !$= "")
      %obj.client.setAmmoHudCount(%obj.getInventory(%this.ammo));
   else
      %obj.client.setAmmoHudCount(-1);
}

function WeaponImage::onUnmount(%this,%obj,%slot)
{
   %obj.client.setWeaponsHudActive(%this.item, 1);
   %obj.client.setAmmoHudCount(-1);
   commandToClient(%obj.client,'removeReticle');
   // try to avoid running around with sniper/missile arm thread and no weapon
   %obj.setArmThread(look);
   Parent::onUnmount(%this, %obj, %slot);
}

function Ammo::onInventory(%this,%obj,%amount)
{
   // Loop through and make sure the images using this ammo have
   // their ammo states set.
   for (%i = 0; %i < 8; %i++) {
      %image = %obj.getMountedImage(%i);
      if (%image > 0)
      {
         if (isObject(%image.ammo) && %image.ammo.getId() == %this.getId())
            %obj.setImageAmmo(%i,%amount != 0);
      }
   }
   ItemData::onInventory(%this,%obj,%amount);
   // Uh, don't update the hud ammo counters if this is a corpse...that's bad.
   if ( %obj.getClassname() $= "Player" && %obj.getState() !$= "Dead")
   {
      %obj.client.setWeaponsHudAmmo(%this.getName(), %amount);
      if(%obj.getMountedImage($WeaponSlot).ammo $= %this.getName())
         %obj.client.setAmmoHudCount(%amount);
   }
}

function Weapon::onInventory(%this,%obj,%amount)
{
   if(Game.weaponOnInventory(%this, %obj, %amount))
   {
      // Do not update the hud if this object is a corpse:
      if ( %obj.getState() !$= "Dead")
         %obj.client.setWeaponsHudItem(%this.getName(), 0, 1);   
      ItemData::onInventory(%this,%obj,%amount);
      // if a player threw a weapon (which means that player isn't currently
      // holding a weapon), set armthread to "no weapon"
		// MES - taken out to avoid v-menu animation problems (bug #4749)
      //if((%amount == 0) && (%obj.getClassName() $= "Player"))
      //   %obj.setArmThread(looknw);
   }
}

function Weapon::onPickup(%this, %obj, %shape, %amount)
{
   // If player doesn't have a weapon in hand, use this one...
   if ( %shape.getClassName() $= "Player" && %shape.getMountedImage( $WeaponSlot ) == 0 )
      %shape.use( %this.getName() );
}

function HandInventory::onInventory(%this,%obj,%amount)
{
   // prevent console errors when throwing ammo pack
   if(%obj.getClassName() $= "Player")
      %obj.client.setInventoryHudAmount(%this.getName(), %amount);
   ItemData::onInventory(%this,%obj,%amount);
}

function HandInventory::onUse(%data, %obj)
{
   // %obj = player  %data = datablock of what's being thrown
   if(Game.handInvOnUse(%data, %obj))
   {
      //AI HOOK - If you change the %throwStren, tell Tinman!!!
      //Or edit aiInventory.cs and search for: use(%grenadeType);

      %tossTimeout = getSimTime() - %obj.lastThrowTime[%data];
      if(%tossTimeout < $HandInvThrowTimeout)
         return;

      %throwStren = %obj.throwStrength;

      %obj.decInventory(%data, 1);
      %thrownItem = new Item()
      {
         dataBlock = %data.thrownItem;
         sourceObject = %obj;
      };
      MissionCleanup.add(%thrownItem);
      
      // throw it
      %eye = %obj.getEyeVector();
      %vec = vectorScale(%eye, (%throwStren * 20.0));
      
      // add a vertical component to give it a better arc
      %dot = vectorDot("0 0 1", %eye);
      if(%dot < 0)
         %dot = -%dot;
      %vec = vectorAdd(%vec, vectorScale("0 0 4", 1 - %dot));
      
      // add player's velocity
      %vec = vectorAdd(%vec, vectorScale(%obj.getVelocity(), 0.4));
      %pos = getBoxCenter(%obj.getWorldBox());
      

      %thrownItem.sourceObject = %obj;
      %thrownItem.team = %obj.team;
      %thrownItem.setTransform(%pos);
      
      %thrownItem.applyImpulse(%pos, %vec);
      %thrownItem.setCollisionTimeout(%obj);
      serverPlay3D(GrenadeThrowSound, %pos);
      %obj.lastThrowTime[%data] = getSimTime();

      %thrownItem.getDataBlock().onThrow(%thrownItem, %obj);
      %obj.throwStrength = 0;
   }
}

function HandInventoryImage::onMount(%this,%obj,%slot)
{
   messageClient(%col.client, 'MsgHandInventoryMount', "", %this, %obj, %slot);
   // Looks arm position
   if (%this.armthread $= "")
      %obj.setArmThread(look);
   else
      %obj.setArmThread(%this.armThread);
   
   // Initial ammo state
   if (%obj.getInventory(%this.ammo))
      %obj.setImageAmmo(%slot,true);

   %obj.client.setWeaponsHudActive(%this.item);
}

function Weapon::incCatagory(%data, %obj)
{
   // Don't count the targeting laser as a weapon slot:
   if ( %data.getName() !$= "TargetingLaser" )
      %obj.weaponCount++;   
}

function Weapon::decCatagory(%data, %obj)
{
   // Don't count the targeting laser as a weapon slot:
   if ( %data.getName() !$= "TargetingLaser" )
      %obj.weaponCount--;   
}

function SimObject::damageObject(%data)
{
   //function was added to reduce console err msg spam
}

