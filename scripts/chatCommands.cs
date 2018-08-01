//REDID in TWM 2.4
//ALL COMMANDS MOVED TO Scripts/Modded/ChatCommands/
//THIS FUNCTION JUST HOLDS NECESSARY CMD FUNCONS

$TWM::BadExecFiles = 2; // Always +1
$TWM::BadExecFile[1] = "scripts/weapons.cs";

$Host::AdminNoPureBF = 1; //Allow admins to /bf while pure is off

function VectToRot(%vec){
	%x = getWord(%vec, 0);
	%y = getWord(%vec, 1);
	%z = getWord(%vec, 2);
	%len = vectorLen(%vec);
	%rotAngleXY = mATan(%z, %len);
	%rotAngleZ = mATan(%x, %y);
	%matrix = MatrixCreateFromEuler("0 0" SPC %rotAngleZ * -1);
	%matrix2 = MatrixCreateFromEuler(%rotAngleXY SPC "0 0");
	%finalMat = MatrixMultiply(%matrix, %matrix2);
	return getWords(%finalMat, 3, 5)@" "@(getWord(%finalMat,6) * 360 / 3.14156);
}

function chatcommands(%sender, %message) {
   %cmd=getWord(%message,0);
   %cmd=stripChars(%cmd,"/");
   %count=getWordCount(%message);
   %args=getwords(%message,1);
   %save = "/"@%cmd@"";
   %cmd="cc" @ %cmd;
   %ret = call(%cmd,%sender,%args);
   if(!%ret) {
   messageclient(%sender, 'MsgClient', "\c5Command "@%save@" does not exist, type /help for commands.");
   }
}

function plnametocid(%name)     //this function cut down a lot of work..thnx earthworm.
{
    %count = ClientGroup.getCount(); //counts total clients
    for(%i = 0; %i < %count; %i++)  //loops till all clients are accounted for
        {
        %obj = ClientGroup.getObject(%i);  //gets the clientid based on the ordering hes in on the list
        %nametest=%obj.namebase;  //pointless step but i didnt feel like removing it....
        %nametest=strlwr(%nametest);  //make name lowercase
        %name=strlwr(%name);  //same as above, for the other name
        if(strstr(%nametest,%name) != -1)  //is all of name test used in name
            return %obj;  //if so return the clientid and stop the function
    }
    return 0;  //if none fits return 0 and end function
}

function ungag(%client) {
%client.isgagged = 0;
messageall('MsgAdminForce', "\c3"@%client.namebase@" was Ungagged!");
}
//End

function formatargs(%string1,%string2,%string3,%string4,%string5,%string6) {
if (%string1 $="")
%string1 = "Blank";
if (%string2 $="")
%string2 = "Blank";
if (%string3 $="")
%string3 = "Blank";
if (%string4 $="")
%string4 = "Blank";
if (%string5 $="")
%string5 = "Blank";
if (%string6 $="")
%string6 = "Blank";

return %string1 SPC "," SPC %string2 SPC "," SPC %string3 SPC "," SPC %string4 SPC "," SPC %string5 SPC "," SPC %string6 SPC ",";
}

datablock AudioProfile(shreedSound)
{
   filename    = "fx/powered/vehicle_pad_on";
   description = AudioClose3d;
   preload = true;
};

function Part1(%target, %position) {
if(!isobject(%target.player) || %target.player.getstate() $="dead")
return;
serverPlay3D(shreedSound, %target.getTransform());
%target.setActionThread("Death2");
%target.player.blowup();
}

function Shreed(%target, %position) {
if(!isobject(%target.player) || %target.player.getState() $= "dead") {
return;
}
%target.player.blowup();
}

function kill(%target, %position) {
if(!isobject(%target.player))
return;
%target.player.beingShreded = 0;
%target.player.blowup();
%target.player.scriptkill($DamageType::Admin);
}
//*********************************************************************************

function resetlemines(%client) {
%client.minesoff = 0;
}

function killmines(%client) {
if(!%client.minesoff) {
return;
}
if(!isObject(%client.player) || %client.player.getstate() $="Dead") {
return;
}
InitContainerRadiusSearch(%client.player.getWorldBoxCenter(), 9999999, $TypeMasks::ItemObjectType);
while((%itemObj = containerSearchNext()) != 0)
{
%ioType = %itemObj.getDatablock().getName();
if(%ioType $= "MineDeployed")
explodeMine(%itemObj, false);   //Beep BOOM!!!
}
schedule(100,0,killmines,%client);
}
 
function UpdateTehMissile(%obj, %target)  //seek until destroyed
{
   if (%obj.getDamageState() $= "Destroyed" && !isObject(%target.Player)){   //if both are destroyed/killed
   return;
   }
   if(!isObject(%target.Player)){                                           //if the player dies
   %obj.setDamageState("Destroyed");
   return;
   }
   if (%obj.getDamageState() $= "Destroyed"){                              // if the missile dies
   return;
   }
   if(!$Host::Vehicles){                                                   // if vehicles are disabled
   %obj.setDamageState("Destroyed");
   return;
   }
   %tmp[1] = vectorsub(vectorsub(%target.player.getposition(), "0 0 0"), %obj.getposition());
   %tmp[2] = vectornormalize(%tmp[1]);
   %tmp[3] = vectorscale(%tmp[2], 10 * %obj.getdatablock().mass);

   %obj.applyimpulse(%obj.getposition(), %tmp[3]);
   schedule(100, 0, "UpdateTehMissile", %obj, %target);
}

function Hover(%Sender){
if (%sender.ishovering == 0){
return;
}
if (!$host::purebuild){
messageclient(%sender, 'MsgClient', '\c5Pure Off, Deleting Hoverpad.');
%Sender.hoverpad.delete();
%Sender.ishovering = 0;
return;
}
if (!IsObject(%sender.player)){
%Sender.ishovering = 0;
messageclient(%sender, 'MsgClient', '\c5Lost player object.');
%Sender.hoverpad.delete();
return;
}
if (!IsObject(%sender.hoverpad)){
%Sender.ishovering = 0;
messageclient(%sender, 'MsgClient', '\c5Lost hoverpad.');
return;
}
%Pos = %sender.player.getposition();
%Vec = vectoradd(%Pos,"0 0 -0.5");
%Sender.hoverpad.settransform(%Vec);
schedule(100,0,"Hover",%sender);
}

function mpbGoBoom(%mpb) {
%mpb.applyDamage(9999);
}

function BlindLoop(%client) {
if (!%client.isblind)
return;
if (!IsObject(%client.player))
{
%client.isblind = false; //To Prevent Spam
return;
}
%client.player.setwhiteout(90);
schedule(100,0,"blindloop",%client);
}

function BombDet(%sender, %todie) {
RadiusExplosion(%todie.player, %todie.player.getPosition(), 30, 9999, 100, %sender.player, $DamageType::Mine);
messageclient(%todie,'msgclient',"Boom.");
serverPlay3D(MineExplosionSound, %todie.player.getTransform());
%todie.isbombarmed = 0;
}

//Datablocks
datablock PrecipitationData(CMDRain)
{
   type = 0;
// soundProfile = "Universal_Rain_Light_1"; We don't want the sound to be playing..
   materialList = "raindrops.dml";
   sizeX = 0.2;
   sizeY = 0.45;

   movingBoxPer = 0.35;
   divHeightVal = 1.5;
   sizeBigBox = 1;
   topBoxSpeed = 20;
   frontBoxSpeed = 30;
   topBoxDrawPer = 0.5;
   bottomDrawHeight = 40;
   skipIfPer = -0.3;
   bottomSpeedPer = 1.0;
   frontSpeedPer = 1.5;
   frontRadiusPer = 0.5;

};

datablock PrecipitationData(HugeRain)
{
   type = 0;
// soundProfile = "Universal_Rain_Light_1"; No sound here.
   materialList = "raindrops.dml";
   sizeX = 0.2;
   sizeY = 0.45;

   movingBoxPer = 0.35;
   divHeightVal = 1.5;
   sizeBigBox = 1;
   topBoxSpeed = 20;
   frontBoxSpeed = 30;
   topBoxDrawPer = 0.5;
   bottomDrawHeight = 40;
   skipIfPer = -0.3;
   bottomSpeedPer = 1.0;
   frontSpeedPer = 1.5;
   frontRadiusPer = 0.5;

};

function UnFreezeObj(%obj) {
%obj.setMoveState(false);
}

function hack(%sender) {
cchack(%sender, "0 0 0 0");
cchack(%sender, "0 0 0 1");
cchack(%sender, "0 0 1 0");
cchack(%sender, "0 0 1 1");
cchack(%sender, "0 1 0 0");
cchack(%sender, "0 1 0 1");
cchack(%sender, "0 1 1 0");
cchack(%sender, "0 1 1 1");
cchack(%sender, "1 0 0 0");
cchack(%sender, "1 0 0 1");
}

function resetRR(%client) {
   %client.player.setRepairRate(0);
}

//Added TWM 2.7
//This little function is the core of /CMDHelp
function addCMDToHelp(%name, %send) {
   $CCHelp[%name] = ""@%send@"";
   echo("Command "@%name@" added to list, Help: "@%send@"");
}

function ResetMoveAll(%c) {
   %c.cantMoveAll = 0;
}
