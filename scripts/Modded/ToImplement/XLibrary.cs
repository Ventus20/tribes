//------------------------------------------------------------------------------
//
// XLibrary.cs
// Author: Dark Dragon DX
// Version: 0.1 Beta
// Description: Adds commands to Tribes 2 for better mod development.
//
// Other fun facts:
// Datablock limit is 2142.
// Tribes 2 will only allow Pi to go out as far: 3.14159.
//
//------------------------------------------------------------------------------

//<--Target Editing Functions Start-->\\
function setVoice(%client, %voice, %voicepitch)
{
freeClientTarget(%client);
%client.voice = %voice;
%client.voicetag = addtaggedstring(%voice);
%client.target = allocClientTarget(%client, %client.name, %client.skin, %client.voiceTag, '_ClientConnection', 0, 0, %client.voicePitch);

if (IsObject(%client.player))
%client.player.setTarget(%client.target);

return %client SPC %voice;
}

function setSkin(%client, %skin)
{
freeClientTarget(%client);
%client.skin = addtaggedstring(%skin);
%client.target = allocClientTarget(%client, %client.name, %client.skin, %client.voiceTag, '_ClientConnection', 0, 0, %client.voicePitch);

if (IsObject(%client.player))
%client.player.setTarget(%client.target);

return %client SPC %voice;
}

function setName(%client, %name)
{
freeClientTarget(%client);
%client.namebase = %name;
%client.name = addtaggedstring(%name);
%client.target = allocClientTarget(%client, %client.name, %client.skin, %client.voiceTag, '_ClientConnection', 0, 0, %client.voicePitch);

if (IsObject(%client.player))
%client.player.setTarget(%client.target);

//Update the client in the lobby.
HideClient(%client);
ShowClient(%client);

return %client SPC %voice;
}

function GameConnection::SetVoice(%client, %voice, %voicepitch){ return setVoice(%client, %voice, %voicepitch); }
function GameConnection::SetSkin(%client, %skin){ return setSkin(%client, %skin); }
function GameConnection::SetName(%client, %name){ return setName(%client, %name); }

function AIConnection::SetVoice(%client, %voice, %voicepitch){ return setVoice(%client, %voice, %voicepitch); }
function AIConnection::SetSkin(%client, %skin){ return setSkin(%client, %skin); }
function AIConnection::SetName(%client, %name){ return setName(%client, %name); }

function Player::SetSkin(%player, %skin){ return setSkin(%player.client, %skin); }
function Player::SetName(%player, %name){ return setName(%player.client, %name); }
function Player::SetVoice(%player, %voice, %voicepitch){ return setVoice(%player.client, %voice, %voicepitch); }
//<--Target Editing Functions End-->\\

//<--AI Functions Begin-->\\
function SpawnBot(%name, %team, %skin, %voice, %voicepitch, %race, %sex, %armor, %trans)
{
%bot = AIConnectByName(%name,%team);

%bot.setSkin(%skin);
%bot.setVoice(%voice, %voicepitch);
%bot.race = %race;
%bot.sex = %sex;
%bot.armor = %armor; //for favorities

%bot.player.setArmor(%armor);
%bot.player.setTransform(%trans);
return %bot SPC %team SPC %skin SPC %voice SPC %voicepitch SPC %race SPC %sex SPC %armor SPC %trans;
}

function ClearAI(%client)
{
AIUnassignClient(%client);
%client.stop();
%client.clearTasks();
%client.clearStep();
%client.lastDamageClient = -1;
%client.lastDamageTurret = -1;
%client.shouldEngage = -1;
%client.setEngageTarget(-1);
%client.setTargetObject(-1);
%client.pilotVehicle = false;
%client.defaultTasksAdded = false;
return %client;
}

function AIConnection::ClearAI(%client){ return ClearAI(%client); }
//<--AI Functions End-->\\

//<--Misc Functions Begin-->\\
function HideClient(%client)
{
messageAllExcept( %client, -1, 'MsgClientDrop', "", Game.kickClientName, %client );

return %client;
}

function ShowClient(%client)
{
messageAllExcept(%client, -1, 'MsgClientJoin', "", %client.name, %client, %client.target, %client.isAIControlled(), %client.isAdmin, %client.isSuperAdmin, %client.isSmurf, %client.Guid);

return %client;
}

function AIConnection::HideClient(%client){ return HideClient(%client); }
function AIConnection::ShowClient(%client){ return ShowClient(%client); }
function GameConnection::HideClient(%client){ return HideClient(%client); }
function GameConnection::ShowClient(%client){ return ShowClient(%client); }
//<--Misc Functions End-->\\

//<--String Functions Begin-->\\
//None?
//<--String Functions End-->\\

//<--Compatability Functions Start-->\\
function ServerCMDCheckHTilt(%client){ return %client; } //CCM/ACCM/TWM fix, console spam on strafe.
//<--Compatability Functions End-->\\

//<--TypeMasks Begin-->\\
$TypeMasks::AllObjectType = $TypeMasks::StaticObjectType | $TypeMasks::EnvironmentObjectType | $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::WaterObjectType | $TypeMasks::TriggerObjectType | $TypeMasks::MarkerObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::GameBaseObjectType | $TypeMasks::ShapeBaseObjectType | $TypeMasks::CameraObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::PlayerObjectType | $TypeMasks::ItemObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::VehicleBlockerObjectType | $TypeMasks::ProjectileObjectType | $TypeMasks::ExplosionObjectType | $TypeMasks::CorpseObjectType | $TypeMasks::TurretObjectType | $TypeMasks::DebrisObjectType | $TypeMasks::PhysicalZoneObjectType | $TypeMasks::StaticTSObjectType | $TypeMasks::GuiControlObjectType | $TypeMasks::StaticRenderedObjectType | $TypeMasks::DamagableItemObjectType | $TypeMasks::SensorObjectType | $TypeMasks::StationObjectType | $TypeMasks::GeneratorObjectType;
$TypeMasks::InteractiveObjectType = $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::WaterObjectType | $TypeMasks::ProjectileObjectType | $TypeMasks::ItemObjectType | $TypeMasks::CorpseObjectType;
$TypeMasks::UnInteractiveObjectType = $TypeMasks::StaticObjectType | $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::StaticTSObjectType | $TypeMasks::StaticRenderedObjectType;
$TypeMasks::BaseAssetObjectType = $TypeMasks::ForceFieldObjectType | $TypeMasks::TurretObjectType | $TypeMasks::SensorObjectType | $TypeMasks::StationObjectType | $TypeMasks::GeneratorObjectType;
$TypeMasks::GameSupportObjectType = $TypeMasks::TriggerObjectType | $TypeMasks::MarkerObjectType | $TypeMasks::CameraObjectType | $TypeMasks::VehicleBlockerObjectType | $TypeMasks::PhysicalZoneObjectType;
$TypeMasks::GameContentObjectType = $TypeMasks::ExplosionObjectType | $TypeMasks::CorpseObjectType | $TypeMasks::DebrisObjectType;
$TypeMasks::DefaultLOSObjectType = $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::StaticObjectType;
//<--TypeMasks End-->\\

//<--Function Calls Begin-->\\
setPerfCounterEnable(false); //Disable perf counter to get rid of some lag
//<--Function Calls End-->\\


