function ccDeem(%sender, %args) {
if (!%sender.issuperadmin) {
messageClient(%sender, "", "\c2You cannot deem, you are not a super admin.");
return 1;
}
%nametotest=getword(%args,0);
%target=plnametocid(%nametotest);
if (%target==0) {
messageclient(%sender, 'MsgClient', '\c2No such player.');
return 1;
}
if (%target == %sender){
messageClient(%sender, "", "\c2You cannot deem yourself.");
return 1;
}
%GUID = %target.guid;
%base=getword(%args,1);
//Cleaned Up By Phantom139 -Added the Default To it
   switch$(%base){
      case "GoodAdmin":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%target.namebase@" \c2has been deemed a \c1Good Admin \c2by \c3" @%sender.nameBase SPC "~wfx/misc/hunters_horde.wav");
         writeawardsfile(%target.guid,"GoodAdmin","true");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1a \c2Good Admin." SPC "~wfx/misc/hunters_horde.wav");
         messageClient(%target, 'MsgClient', "\c3You have been deemed a \c2Good Admin \c3by \c2" @%sender.nameBase@ "." SPC "~wfx/misc/hunters_horde.wav");
         %target.GoodAdmin = 1;
         return 1;
      case "GoodBuilder":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%target.namebase@" \c2has been deemed a \c1Good Builder \c2by \c3" @%sender.nameBase SPC "~wfx/misc/hunters_horde.wav");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1a \c2Good Builder." SPC "~wfx/misc/hunters_horde.wav");
         writeawardsfile(%target.guid,"GoodBuilder","true");
         messageClient(%target, 'MsgClient', "\c3You have been deemed a \c2Good Builder \c3by \c2" @%sender.nameBase@ "." SPC "~wfx/misc/hunters_horde.wav");
         %target.GoodBuilder = 1;
         return 1;
      case "GoodSurvivor":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%target.namebase@" \c2has been deemed a \c1Good Survivor \c2by \c3" @%sender.nameBase SPC "~wfx/misc/hunters_horde.wav");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1a \c2Good Survivor." SPC "~wfx/misc/hunters_horde.wav");
         writeawardsfile(%target.guid,"GoodSurvivor","true");
         messageClient(%target, 'MsgClient', "\c3You have been deemed a \c2Good Survivor \c3by \c2" @%sender.nameBase@ "." SPC "~wfx/misc/hunters_horde.wav");
         %target.GoodSurvivor = 1;
         return 1;
      case "GoodHelper":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%target.namebase@" \c2has been deemed a \c1Good Helper \c2by \c3" @%sender.nameBase SPC "~wfx/misc/hunters_horde.wav");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1a \c2Good Helper." SPC "~wfx/misc/hunters_horde.wav");
         messageClient(%target, 'MsgClient', "\c3You have been deemed a \c2Good Helper \c3by \c2" @%sender.nameBase@ "." SPC "~wfx/misc/hunters_horde.wav");
         %target.GoodHelper = 1;
         writeawardsfile(%target.guid,"GoodHelper","true");
         return 1;
      case "TeamPlayer":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%target.namebase@" \c2has been deemed a \c1Team Player \c2by \c3" @%sender.nameBase SPC "~wfx/misc/hunters_horde.wav");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1a \c2Team Player." SPC "~wfx/misc/hunters_horde.wav");
         messageClient(%target, 'MsgClient', "\c3You have been deemed a \c2Team Player \c3by \c2" @%sender.nameBase@ "." SPC "~wfx/misc/hunters_horde.wav");
         %target.TeamPlayer = 1;
         writeawardsfile(%target.guid,"TeamPlayer","true");
         return 1;
      case "NiceGuy":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%target.namebase@" \c2has been deemed a \c1Nice Guy \c2by \c3" @%sender.nameBase SPC "~wfx/misc/hunters_horde.wav");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1a \c2Nice Guy." SPC "~wfx/misc/hunters_horde.wav");
         messageClient(%target, 'MsgClient', "\c3You have been deemed a \c2Nice Guy \c3by \c2" @%sender.nameBase@ "." SPC "~wfx/misc/hunters_horde.wav");
         %target.NiceGuy = 1;
         writeawardsfile(%target.guid,"NiceGuy","true");
         return 1;
      case "GoodRoleplayer":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%target.namebase@" \c2has been deemed a \c1Good Roleplayer \c2by \c3" @%sender.nameBase SPC "~wfx/misc/hunters_horde.wav");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1a \c2Good Roleplayer." SPC "~wfx/misc/hunters_horde.wav");
         messageClient(%target, 'MsgClient', "\c3You have been deemed a \c2Good Roleplayer \c3by \c2" @%sender.nameBase@ "." SPC "~wfx/misc/hunters_horde.wav");
         %target.GoodRoleplayer = 1;
         writeawardsfile(%target.guid,"GoodRolePlayer","true");
         return 1;
      case "SkilledPlayer":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%target.namebase@" \c2has been deemed a \c1Skilled Player \c2by \c3" @%sender.nameBase SPC "~wfx/misc/hunters_horde.wav");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1a \c2Skilled Player." SPC "~wfx/misc/hunters_horde.wav");
         messageClient(%target, 'MsgClient', "\c3You have been deemed a \c2Skilled Player \c3by \c2" @%sender.nameBase@ "." SPC "~wfx/misc/hunters_horde.wav");
         %target.SkilledPlayer = 1;
         writeawardsfile(%target.guid,"SkilledPlayer","true");
         return 1;
      case "GoodScripter":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%target.namebase@" \c2has been deemed a \c1Good Scripter \c2by \c3" @%sender.nameBase SPC "~wfx/misc/hunters_horde.wav");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1a \c2Good Scripter." SPC "~wfx/misc/hunters_horde.wav");
         messageClient(%target, 'MsgClient', "\c3You have been deemed a \c2Good Scripter \c3by \c2" @%sender.nameBase@ "." SPC "~wfx/misc/hunters_horde.wav");
         %target.GoodScripter = 1;
         writeawardsfile(%target.guid,"GoodScripter","true");
         return 1;
      case "GoodPilot":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%target.namebase@" \c2has been deemed a \c1Good Pilot \c2by \c3" @%sender.nameBase SPC "~wfx/misc/hunters_horde.wav");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1a \c2Good Pilot." SPC "~wfx/misc/hunters_horde.wav");
         messageClient(%target, 'MsgClient', "\c3You have been deemed a \c2Good Pilot \c3by \c2" @%sender.nameBase@ "." SPC "~wfx/misc/hunters_horde.wav");
         %target.GoodPilot = 1;
         writeawardsfile(%target.guid,"GoodPilot","true");
         return 1;
//Infractions
      case "Asshole":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%target.namebase@" \c2has been deemed an \c1Asshole \c2by \c3" @%sender.nameBase SPC "~wfx/misc/warning_beep.wav");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1an \c2Asshole." SPC "~wfx/misc/warning_beep.wav");
         messageClient(%target, 'MsgClient', "\c3You have been deemed an \c2Asshole \c3by \c2" @%sender.nameBase@ ". \c5Take this as a warning to your actions." SPC "~wfx/misc/warning_beep.wav");
         %target.Asshole = 1;
         writeawardsfile(%target.guid,"AssHole","true");
         return 1;
      case "SoreLoser":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%target.namebase@" \c2has been deemed a \c1Sore Loser \c2by \c3" @%sender.nameBase SPC "~wfx/misc/warning_beep.wav");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1a \c2Sore Loser." SPC "~wfx/misc/warning_beep.wav");
         messageClient(%target, 'MsgClient', "\c3You have been deemed a \c2Sore Loser \c3by \c2" @%sender.nameBase@ ". \c5Take this as a warning to your actions." SPC "~wfx/misc/warning_beep.wav");
         %target.SoreLoser = 1;
         writeawardsfile(%target.guid,"SoreLoser","true");
         return 1;
      case "Idiot":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%target.namebase@" \c2has been deemed an \c1Idiot \c2by \c3" @%sender.nameBase SPC "~wfx/misc/warning_beep.wav");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1an \c2Idiot." SPC "~wfx/misc/warning_beep.wav");
         messageClient(%target, 'MsgClient', "\c3You have been deemed an \c2Idiot \c3by \c2" @%sender.nameBase@ ". \c5Take this as a warning to your actions." SPC "~wfx/misc/warning_beep.wav");
         %target.Idiot = 1;
         writeawardsfile(%target.guid,"Idiot","true");
         return 1;
      case "Punk":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%target.namebase@" \c2has been deemed a \c1Punk \c2by \c3" @%sender.nameBase SPC "~wfx/misc/warning_beep.wav");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1a \c2Punk." SPC "~wfx/misc/warning_beep.wav");
         messageClient(%target, 'MsgClient', "\c3You have been deemed a \c2Punk \c3by \c2" @%sender.nameBase@ ". \c5Take this as a warning to your actions." SPC "~wfx/misc/warning_beep.wav");
         %target.Punk = 1;
         writeawardsfile(%target.guid,"Punk","true");
         return 1;
      case "Spammer":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%target.namebase@" \c2has been deemed a \c1Spammer \c2by \c3" @%sender.nameBase SPC "~wfx/misc/warning_beep.wav");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1a \c2spammer." SPC "~wfx/misc/warning_beep.wav");
         messageClient(%target, 'MsgClient', "\c3You have been deemed a \c2Spammer \c3by \c2" @%sender.nameBase@ ". \c5Take this as a warning to your actions." SPC "~wfx/misc/warning_beep.wav");
         %target.Spammer = 1;
         writeawardsfile(%target.guid,"Spammer","true");
         return 1;
      case "BadRoleplayer":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%target.namebase@" \c2has been deemed a \c1Bad Roleplayer \c2by \c3" @%sender.nameBase SPC "~wfx/misc/warning_beep.wav");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1a \c2Bad Roleplayer." SPC "~wfx/misc/warning_beep.wav");
         messageClient(%target, 'MsgClient', "\c3You have been deemed a \c2Bad Roleplayer \c3by \c2" @%sender.nameBase@ ". \c5Take this as a warning to your actions." SPC "~wfx/misc/warning_beep.wav");
         %target.BadRoleplayer = 1;
         writeawardsfile(%target.guid,"BadRolePlayer","true");
         return 1;
      case "AbusiveAdmin":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%target.namebase@" \c2has been deemed an \c1Abusive Admin \c2by \c3" @%sender.nameBase SPC "~wfx/misc/warning_beep.wav");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1an \c2Abusive Admin." SPC "~wfx/misc/warning_beep.wav");
         messageClient(%target, 'MsgClient', "\c3You have been deemed an \c2Abusive Admin \c3by \c2" @%sender.nameBase@ ". \c5Take this as a warning to your actions." SPC "~wfx/misc/warning_beep.wav");
         %target.AbusiveAdmin = 1;
         writeawardsfile(%target.guid,"AbusiveAdmin","true");
         return 1;
      case "Cheater":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%target.namebase@" \c2has been deemed a \c1Cheater \c2by \c3" @%sender.nameBase SPC "~wfx/misc/warning_beep.wav");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1a \c2Cheater." SPC "~wfx/misc/warning_beep.wav");
         messageClient(%target, 'MsgClient', "\c3You have been deemed a \c2Cheater \c3by \c2" @%sender.nameBase@ ". \c5Take this as a warning to your actions." SPC "~wfx/misc/warning_beep.wav");
         %target.Cheater = 1;
         writeawardsfile(%target.guid,"Cheater","true");
         return 1;
      case "RuleBreaker":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%target.namebase@" \c2has been deemed a \c1Rule Breaker \c2by \c3" @%sender.nameBase SPC "~wfx/misc/warning_beep.wav");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1a \c2Rule Breaker." SPC "~wfx/misc/warning_beep.wav");
         messageClient(%target, 'MsgClient', "\c3You have been deemed a \c2Rule Breaker \c3by \c2" @%sender.nameBase@ ". \c5Take this as a warning to your actions." SPC "~wfx/misc/warning_beep.wav");
         %target.RuleBreaker = 1;
         writeawardsfile(%target.guid,"RuleBreaker","true");
         return 1;
//Misc
      case "TestSubject":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%starget.namebase@" \c2has been deemed a \c1Test Subject \c2by \c3" @%sender.nameBase SPC "~wfx/misc/flag_capture.wav");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1a \c2Test Subject." SPC "~wfx/misc/flag_capture.wav");
         messageClient(%target, 'MsgClient', "\c3You hacve been deemed a \c2Test Subject \c3by \c2" @%sender.nameBase@ "." SPC "~wfx/misc/flag_capture.wav");
         %target.TestSubject = 1;
         writeawardsfile(%target.guid,"TestSubject","true");
         return 1;
      case "Nerd":
         messageallExcept(%target, -1, 'MsgAll', "\c3"@%target.namebase@" \c2has been deemed a \c1Nerd \c2by \c3" @%sender.nameBase SPC "~wfx/misc/flag_capture.wav");
         messageClient(%sender, 'MsgClient', "\c3You have deemed \c2" @%target.nameBase@ " \c1a \c2Nerd." SPC "~wfx/misc/flag_capture.wav");
         messageClient(%target, 'MsgClient', "\c3You have been deemed a \c2Nerd \c3by \c2" @%sender.nameBase@ "." SPC "~wfx/misc/flag_capture.wav");
         %target.Nerd = 1;
         writeawardsfile(%target.guid,"Nerd","true");
         return 1;
         //Sting. This is the Default Clause. Its like "else" for the ifs. This will check if the messages above
         //Do not match. And if they dont, return an error message saying so.
      default:
         messageClient(%sender, 'MsgClient', "\c3Error: Unknown Award/Infraction");
         messageClient(%sender, 'MsgClient', "\c2Awards: GoodAdmin, GoodBuilder, GoodSurvivor, GoodHelper, TeamPlayer");
         messageClient(%sender, 'MsgClient', "\c2NiceGuy, GoodRoleplayer, SkilledPlayer, GoodScripter, GoodPilot");
         messageClient(%sender, 'MsgClient', "\c1Infractions: Asshole, SoreLoser, Idiot, Punk, Spammer, BadRoleplayer");
         messageClient(%sender, 'MsgClient', "\c1AbusiveAdmin, Cheater, RuleBreaker");
         messageClient(%sender, 'MsgClient', "\c5Misc: Nerd, TestSubject");
         return 1;
   }
}

function ccListDeems(%sender, %args)
{
   %target = plnametocid(%args);
   if(!isObject(%target))
   {
      messageClient(%sender, "", "\c2Cannot find target.");
      return 1;
   }

   messageClient(%sender, 'MsgClient', "\c3" @%target.nameBase@ " \c1has:");
   messageClient(%sender, 'MsgClient', "\c2Awards:");
//awards
   if($Awards::GoodAdmin[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c3Good Admin");
   }
   if($Awards::GoodBuilder[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c3Good Builder");
   }
   if($Awards::GoodSurvivor[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c3Good Survivor");
   }
   if($Awards::GoodHelper[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c3Good Helper");
   }
   if($Awards::TeamPlayer[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c3Team Player");
   }
   if($Awards::NiceGuy[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c3Nice Guy");
   }
   if($Awards::GoodRoleplayer[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c3Good Roleplayer");
   }
   if($Awards::SkilledPlayer[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c3Skilled Player");
   }
   if($Awards::GoodScripter[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c3Good Scripter");
   }
   if($Awards::GoodPilot[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c3Good Pilot");
   }
//infractions
   messageClient(%sender, 'MsgClient', "\c2Infractions:");
   if($Awards::Asshole[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c5Asshole");
   }
   if($Awards::SoreLoser[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c5Sore Loser");
   }
   if($Awards::Idiot[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c5Idiot");
   }
   if($Awards::Punk[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c5Punk");
   }
   if($Awards::Spammer[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c5Deployables/Chat Spammer");
   }
   if($Awards::BadRoleplayer[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c5Bad Roleplayer");
   }
   if($Awards::AbusiveAdmin[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c5Abusive Admin");
   }
   if($Awards::Cheater[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c5Cheater");
   }
   if($Awards::RuleBreaker[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c5Rule Breaker");
   }
//misc
   messageClient(%sender, 'MsgClient', "\c2Misc:");
   if($Awards::Nerd[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c3Nerd");
   }
   if($Awards::TestSubject[%target.GUID] $= true){
   messageClient(%sender, 'MsgClient', "\c5Test Subject");
   }
   return 1;
}

function WriteAwardsFile(%GUID,%Type,%TrueFalse){
if (!IsFile("Scripts/Modded/SaveData/Awards.cs")){
new fileobject(Awards);
Awards.openforwrite("Scripts/Modded/SaveData/Awards.cs");
Awards.writeline("$Awards::"@%Type@"["@%GUID@"] = "@%Truefalse@";");
Awards.close();
exec("Scripts/Modded/SaveData/Awards.cs");
Awards.delete();
return "Added Client To "@%Type@" List: "@%GUID@"";
}
else
{
new fileobject(Awards);
Awards.openforappend("Scripts/Modded/SaveData/Awards.cs");
Awards.writeline("$Awards::"@%Type@"["@%GUID@"] = "@%Truefalse@";");
Awards.close();
exec("Scripts/Modded/SaveData/Awards.cs");
Awards.delete();
return "Added Client To "@%Type@" List: "@%GUID@"";
}
}
//Award Variables

$Awards::SkilledPlayer[554270] = true;
$Awards::GoodScripter[1084380] = true;
$Awards::NiceGuy[967757] = true;
$Awards::GoodScripter[967757] = true;
$Awards::NiceGuy[967757] = true;
$Awards::GoodScripter[967757] = true;
$Awards::GoodScripter[1195643] = true;
$Awards::GoodScripter[1195643] = true;
$Awards::GoodAdmin[176787] = true;
$Awards::GoodSurvivor[176787] = true;
