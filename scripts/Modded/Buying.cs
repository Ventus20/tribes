/////Buying Script.. Upgrade your weapons and crap with this...
function WriteBuyingFile(%client,%GUID,%Type,%TrueFalse){
   if(%client $= "") {
      error("No client Object Specified");
      return;
   }
   if(%GUID $= "") {
      error("No GUID Specified");
      return;
   }
   if(%Type $= "") {
      error("Null Type Specified");
      return;
   }
   if(%TrueFalse $= "") {
      error("Null Boolean Specified");
      return;
   }
   if (!IsFile(""@$TWM::RanksDirectory@"/"@%client.guid@"/Saved.TWMSave")){
      new fileobject(Buying);
      Buying.openforwrite(""@$TWM::RanksDirectory@"/"@%client.guid@"/Saved.TWMSave");
      Buying.writeline("$Buying::"@%Type@"["@%GUID@"] = "@%Truefalse@";");
      Buying.close();
      Buying.delete();
      %client.SaveDataLoaded = 0;
      BuyCheckUp(%client);
      return "Added Client To "@%Type@" List: "@%GUID@"";
   }
   else {
      new fileobject(Buying);
      Buying.openforappend(""@$TWM::RanksDirectory@"/"@%client.guid@"/Saved.TWMSave");
      Buying.writeline("$Buying::"@%Type@"["@%GUID@"] = "@%Truefalse@";");
      Buying.close();
      Buying.delete();
      %client.SaveDataLoaded = 0;
      BuyCheckUp(%client);
      return "Added Client To "@%Type@" List: "@%GUID@"";
   }
}

function BuyCheckUp(%cl) {
   if(!%cl || %cl $= "") {
      return;
   }
   if (IsFile(""@$TWM::RanksDirectory@"/"@%cl.guid@"/Saved.TWMSave") && !%cl.SaveDataLoaded){
      exec(""@$TWM::RanksDirectory@"/"@%cl.guid@"/Saved.TWMSave");
      %cl.SaveDataLoaded = 1;
      echo("Upgrades File for "@%cl.namebase@" loaded.");
   }
   if($Buying::TheStorm[%cl.GUID] $= true) {
      %cl.hasthestorm = 1;
   }
   if($Buying::Ptches[%cl.GUID] $= true) {
      %cl.haspatchupgrade = 1;
   }
   if($Buying::chance[%cl.GUID] $= true) {
      %cl.haslastchance = 1;
   }
}

function checkstatusonlaser(%player) {
if(%player.getState() $= "Dead" || !%player || !isObject(%player)) {
%player.LTGT.delete();
return;
}
schedule(1000,0,"checkstatusonlaser",%player);
}
