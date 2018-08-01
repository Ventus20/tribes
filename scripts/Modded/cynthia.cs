$host::Cynthiaenabled = 1;
////////////////////////// PHANTOM139's Server Assistant////////////
function CynthiaPerformCommand(%command, %arg1, %arg2, %arg3){
		switch$(%command)
		{
			case "KillPlayerChat":
                    schedule(5,0,"messageall",'MsgAdminForce', "\c4{[TWM]}-Cynthia: "@ %arg1.namebase@" Has been Killed For Chat Violations.");
                    kill(%arg1);

			case "KillPlayer":
                    schedule(5,0,"messageall",'MsgAdminForce', "\c4{[TWM]}-Cynthia: "@ %arg1.namebase@" Has been Killed");
                    kill(%arg1);

			case "controlPlayer":
				    schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: I am now controlling " @ %arg1.namebase @", oops i killed him.");
                    kill(%arg1);

			case "AdminPlayer":
				    schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: Making " @ %arg1.namebase @" Admin.");
                    %arg1.isadmin =1;

			case "SAPlayer":
				    schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: Making " @ %arg1.namebase @" SA.");
                    %arg1.isadmin =1;
                    %arg1.issuperadmin =1;

			case "KickPlayerChat":
				    schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: Kicking " @ %arg1.namebase @" for excess chat violations.");
                    %arg1.setDisconnectReason("Cynthia has kicked you.");
                    %arg1.delete();
               	    BanList::add( 0, %arg1.getAddress(), $Host::KickBanTime );

			case "KickPlayer":
				if(%arg1.isdev || %arg1.issuperadmin)
				{
					schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: I Refuse To Kick "@ %arg1.namebase @".");
					return;
				}
				    schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: Kicking " @ %arg1.namebase @".");
                    kick(%arg1);

			case "BanPlayer":
				if(%arg1.isdev || %arg1.issuperadmin)
				{
					schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: I Refuse To Ban "@ %arg1.namebase @".");
					return;
				}
				    schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: Banning " @ %arg1.namebase @".");
                    Ban(%arg1);

			case "DeletePlayersPieces":
				%count = deployables.getcount();
				for(%i = 0; %i <= %count; %i++)
				{
					%obj = deployables.getobject(%i);
					if(%obj.owner $= %arg1)
					{
						%obj.delete();
					}
				}
				schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: " @ %arg1.namebase @"'s deployables have been deleted.");
		}
      }



















//MAIN SYSTEM
function cynthiaeval(%cl,%message) {
CheckAdminMessages(%cl, %message);
//do this in non-horde games
if(!$TWM::PlayingHorde) {
CheckFuncMessage(%cl, %message); //Contains Recruiting
}
//
CheckCuss(%cl, %message);

%message = stripchars(%message,"/?.>,<\|]}[{=+-_09*7&6^5%4$3#2@1!`~\c0\c1\c2\c3\c4\c5\c6\c7\c8\c9");
%message = strlwr(%message);

if ($Cynthia::Resp[%message, ""] !$="") //Then she should respond.
{
$Cynthia::Resp[%message] = strreplace($Cynthia::Resp[%message],"#w1#",getWord(%message,0));
$Cynthia::Resp[%message] = strreplace($Cynthia::Resp[%message],"#w2#",getWord(%message,1));
$Cynthia::Resp[%message] = strreplace($Cynthia::Resp[%message],"#w3#",getWord(%message,2));
$Cynthia::Resp[%message] = strreplace($Cynthia::Resp[%message],"#w4#",getWord(%message,3));
$Cynthia::Resp[%message] = strreplace($Cynthia::Resp[%message],"#w5#",getWord(%message,4));
$Cynthia::Resp[%message] = strreplace($Cynthia::Resp[%message],"#SENDER#",%cl.namebase);
$Cynthia::Resp[%message] = strreplace($Cynthia::Resp[%message],"#TIME#",""@formattimestring("hh:nn a")@"");
$Cynthia::Resp[%message] = strreplace($Cynthia::Resp[%message],"#DATE#",""@formattimestring("mm-dd-yy")@"");
$Cynthia::Resp[%message] = strreplace($Cynthia::Resp[%message],"#CVCount#",%cl.chatvioCnt);


schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: "@$Cynthia::Resp[%message]@"");
}
}

$Cynthia::Resp["what time is it"] = "The time is #TIME#.";
$Cynthia::Resp["what is my chat violation count"] = "your chat violation count is #CVCount#.";
$Cynthia::Resp["who is phantom"] = "Phantom139 is the leader of {[TWM]}- and developer of this mod.";
$Cynthia::Resp["hello"] = "Greetings, #SENDER#, Welcome to TWM.";
$Cynthia::Resp["hi"] = "Greetings, #SENDER#, Welcome to TWM.";
$Cynthia::Resp["hey"] = "Greetings, #SENDER#, Welcome to TWM.";
$Cynthia::Resp["hy"] = "Greetings, #SENDER#, Welcome to TWM.";
$Cynthia::Resp["hyllo"] = "Greetings, #SENDER#, Welcome to TWM.";

function killplayer(%sender) {
if (!IsObject(%sender.player))
return;

%sender.player.scriptkill(0);
}


function CheckAdminMessages(%cl, %message) {
   //MAKE ADMIN
   if (getSubStr(%message, 0, 13) $= "Cynthia Admin") {
      %check = getWord(%message, 2);
      if(!%cl.isSuperAdmin) {
         schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: You are not Super-Admin "@%cl.namebase@"");
         return;
      }
      else {
         %target = plnametocid(%check);
         if(%target == 0) {
            schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: No Such Player");
            return;
         }
         schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: Admining "@%target.namebase@".");
         %target.isAdmin = 1;
         return;
      }
   }
   //KICK
   if (getSubStr(%message, 0, 12) $= "Cynthia Kick") {
      %check = getWord(%message, 2);
      if(!%cl.isAdmin) {
         schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: You are not Admin "@%cl.namebase@"");
         return;
      }
      else {
         %target = plnametocid(%check);
         if(%target == 0) {
            schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: No Such Player");
            return;
         }
         CynthiaPerformCommand("KickPlayer", %target);
         return;
      }
   }
   //BAN
   if (getSubStr(%message, 0, 11) $= "Cynthia Ban") {
      %check = getWord(%message, 2);
      if(!%cl.isSuperAdmin) {
         schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: You are not Super-Admin "@%cl.namebase@"");
         return;
      }
      else {
         %target = plnametocid(%check);
         if(%target == 0) {
            schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: No Such Player");
            return;
         }
         CynthiaPerformCommand("BanPlayer", %target);
         return;
      }
   }
   //DISABLE / ENABLE
   //BAN
   if(%message $= "Cynthia Shut Down") {
      if(!%cl.isSuperAdmin) {
         schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: You are not Super-Admin "@%cl.namebase@"");
         return;
      }
      else {
         schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: Disabling Cuss Filter.");
         $Host::CynthiaEnabled = 0;
      }
   }

   if(%message $= "Cynthia Turn On") {
      if(!%cl.isSuperAdmin) {
         schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: You are not Super-Admin "@%cl.namebase@"");
         return;
      }
      else {
         schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: Enabling Cuss Filter.");
         $Host::CynthiaEnabled = 1;
      }
   }
}
























//ANTI-CURSE
function JailPL(%cl) {
   if(%cl.isJailed) {
      %cl.player.setPosition($Prison::ReleasePos);
      %cl.player.setPosition("0 0 105");
      %cl.isjailed = 0;
      buyfavorites(%cl);
      schedule(5,0,"messageall",'MsgAdminForce', "\c4{[TWM]}-Cynthia: "@ %cl.namebase@" Has been released.");
      return;
   }
   else {
      %cl.player.setPosition($Prison::JailPos);
      %cl.isjailed = 1;
      %cl.player.clearinventory();
      schedule(5,0,"messageall",'MsgAdminForce', "\c4{[TWM]}-Cynthia: "@ %cl.namebase@" Has been jailed.");
      return;
   }
}

$cursewords="asshole bs bastard bullshit fatass cocksucking fucked fucking whore fuck fucker asshole";
function CheckCuss(%sender, %message) {
%message=strreplace(%message,"!"," "); //replacing characters so people wont do stuff like fuck* and get away with it
%message=strreplace(%message,"?"," ");
%message=strreplace(%message,".","");
%message=strreplace(%message,","," ");
%message=strreplace(%message,"-","");
%message=strreplace(%message,"\""," ");
%message=strreplace(%message,"@","a");
%message=strreplace(%message,"$","s");
%message=strreplace(%message,"5","s");
%message=strreplace(%message,"3","e");
%message=strreplace(%message,"(_)","u");
%message=strreplace(%message,")_(","u");
%message=strreplace(%message,"("," ");
%message=strreplace(%message,")"," ");
%message=strreplace(%message,"§","s");
%message=strreplace(%message,"1","i");
%message=strreplace(%message,"0","o");
%message=strreplace(%message,"|{","k");
%message=strreplace(%message,"|_|","u");
%message=strreplace(%message,"|","i");
%message=strreplace(%message,"\_/","u");
%message=strreplace(%message,"[_]","u");
%message=strreplace(%message,"*","");
%message=trim(%message); //get rid of spaces
%count=getwordcount(%message); //counts total words in curse wordbank
for (%i=0;%i<%count;%i++) { //check each word against the message
%checkword=getword(%message, %i);
%cwcount=getwordcount($cursewords);
for (%c=0;%c<%cwcount;%c++) {
%cwcheckword=getword($cursewords,%c);
if (%checkword $= %cwcheckword)
%cursecount++;
}
}
if (%cursecount !$= "" && %cursecount != 0 && $host::Cynthiaenabled == 1) { //if one or more of the words check out punish
%sender.chatvioCnt++;
Schedule(300000,0,"ReduceVioCount",%sender); // Reduce
if(%sender.chatvioCnt == 1) {
schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: I Do Not Tolerate Cussing. This is Your First Warning.");
CynthiaPerformCommand(KillPlayerChat, %sender);
error("Cynthia -> Console: "@%sender.namebase@" chat vio count Increased To "@%sender.chatvioCnt@".");
}
else if(%sender.chatvioCnt == 2) {
schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: I Do Not Tolerate Cussing. This is Your Second Warning.");
CynthiaPerformCommand(KillPlayerChat, %sender);
error("Cynthia -> Console: "@%sender.namebase@" chat vio count Increased To "@%sender.chatvioCnt@".");
}
else if(%sender.chatvioCnt == 3) {
schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: I Do Not Tolerate Cussing. This is Your Third Warning.");
CynthiaPerformCommand(KillPlayerChat, %sender);
Cynthiagag(%sender);
error("Cynthia -> Console: "@%sender.namebase@" chat vio count Increased To "@%sender.chatvioCnt@".");
Schedule(60000,0,"CynthiaUngag",%sender);
}
else if(%sender.chatvioCnt == 4) {
schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: I Do Not Tolerate Cussing. This is Your Fourth Warning.");
schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: Enjoy your time in solitary Confinement.");
Cynthiagag(%sender);
%sender.isjailed = 0; //Ensure Jailing Works
JailPL(%sender);
error("Cynthia -> Console: "@%sender.namebase@" chat vio count Increased To "@%sender.chatvioCnt@".");
Schedule(120000,0,"JailPL",%sender);
Schedule(120000,0,"CynthiaUngag",%sender);
}
else if(%sender.chatvioCnt == 5) {
Cynthiagag(%sender);
%sender.isjailed = 0; //Ensure Jailing Works
JailPL(%sender);
Schedule(180000,0,"JailPL",%sender);
Schedule(180000,0,"CynthiaUngag",%sender);
error("Cynthia -> Console: "@%sender.namebase@" chat vio count Increased To "@%sender.chatvioCnt@".");
schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: I Do Not Tolerate Cussing. This is Your final warning.");
schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: Enjoy your time in solitary Confinement.... Again.");
}
else if(%sender.chatvioCnt > 5) {
schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: You have been warned enough, begone!");
error("Cynthia -> Console: "@%sender.namebase@" chat vio count exceeds 5("@%sender.chatvioCnt@") Kicking.");
schedule(3000,0,"CynthiaPerformCommand",KickPlayerChat, %sender);
return;
}
}
}

function ReduceVioCount(%cl) {
%cl.chatvioCnt--;
error("Cynthia -> Console: "@%cl.namebase@" chat vio count Reduced To "@%cl.chatvioCnt@".");
}

function CynthiaGag(%cl) {
   %cl.isGagged = 1;
}

function CynthiaUnGag(%cl) {
   %cl.isGagged = 0;
}

















































































//FUNCTIONAL MESSAGING
function WatchAlly(%cl, %ally) {
   if(!%cl) {
   %ally.blowup();
   %ally.damage(0, %ally.position, 900000, $DamageType::Admin);
   echo("deleting Left Player's Ally");
   return;
   }
   if(%ally.disbanded) {
   return;
   }
   if(!isobject(%ally) || %ally.getState() $= "dead") {
   schedule(5,0,"messageclient",%cl, 'MsgClient', "\c1From Cynthia: Oh Dear "@getTaggedString(%cl.name)@", it seems "@%ally.name@" has fallen!");
   if(%ally.name $= "General RAAM") {
      if(%cl.gotshield) {
      %cl.player.rapiershield = 0;
      %cl.gotshield = 0;
      }
   }
   %cl.ally = 0;
   %cl.hasteammember = 0;
   return;
   }
   %cl.hasteammember = 1;
   schedule(5000,0,"WatchAlly",%cl, %ally);
}

function CheckFuncMessage(%sender, %message) {
%w1 = getword(%message,0);
%w2 = getword(%message,1);
%w3 = getword(%message,2);
%rcname = getwords(%message, 2);
if(%w1 $= "recruit" && %w2 $= "list") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: These are the people who can be recruited:");
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: 'General RAAM', 'Lord Darkrai', 'Dolosus', 'Cynthia', 'Lord Raam'");
}
else if(%w1 $= "disband" && %w2 $= "member") {
   if(%sender.ally) {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: "@getTaggedString(%sender.name)@", I will have it done.");
      if(%sender.allyobj.name $= "Lord Darkrai") {
      schedule(1000,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: Just Ring me if you need me again "@getTaggedString(%sender.name)@".");
      }
      else if(%sender.allyobj.name $= "Lord RAAM") {
      schedule(1000,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Raam: ok, im gone "@getTaggedString(%sender.name)@".");
      }
      else if(%sender.allyobj.name $= "General RAAM") {
      schedule(1000,0,"messageclient",%sender, 'MsgClient', "\c1From General Raam: Remember "@getTaggedString(%sender.name)@", the great warrior always prevails stronger!! And Whatever you do, call me before you start killing!!!!!");
         %sender.player.rapiershield = 0;
         %sender.gotshield = 0;
      }
      else if(%sender.ally.namebase $= "Cynthia") { //A return here due to a bot being used.
         schedule(1000,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: Ok then "@getTaggedString(%sender.name)@", I will be in the Command Satelite!");
         %sender.ally.player.blowUp();
         kick(%sender.ally);
         %sender.ally = false;
         %sender.hasteammember = false;
         return;
      }
      else if(%sender.ally.namebase $= "Dolosus") { //A return here due to a bot being used.
         schedule(1000,0,"messageclient",%sender, 'MsgClient', "\c1From Dolosus: I'll be back when you need me, "@%sender.namebase@".");
         %sender.ally.player.blowUp();
         %sender.ally.disbanded = true;
         kick(%sender.ally);
         %sender.ally = false;
         %sender.hasteammember = false;
         return;
      }
   %sender.allyobj.rapiershield = 0;
   %sender.allyobj.disbanded = 1;
   %sender.allyobj.blowup();
   %sender.allyobj.damage(0, %sender.allyobj.position, 900000, $DamageType::Admin);
   %sender.ally = 0;
   %sender.hasteammember = 0;
   }
   else {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: You don't have any team members assigned "@getTaggedString(%sender.name)@".");
   return;
   }
}
else if(%w1 $= "Wake") {
   if(%sender.allyobj.name !$= "Lord Darkrai") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: Lord Darkrai is not your team mate "@getTaggedString(%sender.name)@".");
   return;
   }
   if(%w2 $= "me") {
   %sender.nightmareticks = 31;
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: Hold on, "@getTaggedString(%sender.name)@".");
   }
   else {
      %targ = plnametocid(%w2);
      if(%targ == 0) {
      schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: come again, "@getTaggedString(%sender.name)@"?");
      return;
      }
      if(%targ == %sender) {
      %sender.nightmareticks = 31;
      schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: Hold on, "@getTaggedString(%sender.name)@".");
      return;
      }
      if(!isobject(%targ.player) || %targ.player.getState() $= "dead") {
      schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: apparently he is dead, "@getTaggedString(%sender.name)@".");
      return;
      }
      %targ.nightmareticks = 31;
      schedule(5,0,"messageclient",%targ, 'MsgClient', "\c1From Lord Darkrai: Hang on "@getTaggedString(%targ.name)@", "@getTaggedString(%sender.name)@" has requested this.");
   }
}
else if(%w1 $= "Cynthia" && %w2 $= "stop") {
   if(%sender.ally.namebase !$= "Cynthia") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: I am not your team mate "@getTaggedString(%sender.name)@".");
   return;
   }
   %sender.ally.isfollowing = false;
   %sender.ally.stepEscort(-1);
   %sender.ally.clearTasks();

   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: ok, "@getTaggedString(%sender.name)@".");
}
else if(%w1 $= "Dolosus" && %w2 $= "stop") {
   if(%sender.ally.namebase !$= "Dolosus") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Dolosus: You didn't recruit me!");
   return;
   }
   %sender.ally.isfollowing = false;
   %sender.ally.stepEscort(-1);
   %sender.ally.clearTasks();

   %sender.ally.stepEngage(-1);
   %sender.ally.attacking = false;
   %sender.ally.attackclient = false;
   %sender.ally.hunting = false;

   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Dolosus: I shall stop.");
}
else if(%w1 $= "Darkrai" && %w2 $= "stop") {
   if(%sender.allyobj.name !$= "Lord Darkrai") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: Lord Darkrai is not your team mate "@getTaggedString(%sender.name)@".");
   return;
   }
   if(%sender.allyobj.attackloop) {
   cancel(%sender.allyobj.attackloop);
   }
   if(%sender.allyobj.moveloop) {
   cancel(%sender.allyobj.moveloop);
   }
   %sender.allyobj.iszombie = 0; //allows Sword
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: ceasing actions, "@getTaggedString(%sender.name)@".");
}
else if(%w1 $= "LRaam" && %w2 $= "stop") {
   if(%sender.allyobj.name !$= "Lord RAAM") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: Lord RAAM is not your team mate "@getTaggedString(%sender.name)@".");
   return;
   }
   if(%sender.allyobj.moveloop) {
   cancel(%sender.allyobj.moveloop);
   }
   %sender.allyobj.iszombie = 0; //allows Sword
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord RAAM: yeah, i'll do that "@getTaggedString(%sender.name)@".");
}
else if(%w1 $= "Raam" && %w2 $= "stop") {
   if(%sender.allyobj.name !$= "General RAAM") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: General RAAM is not your team mate "@getTaggedString(%sender.name)@".");
   return;
   }
   if(%sender.allyobj.attackloop) {
   cancel(%sender.allyobj.attackloop);
   }
   if(%sender.allyobj.moveloop) {
   cancel(%sender.allyobj.moveloop);
   }
   %sender.allyobj.iszombie = 0; //allows Sword
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From General RAAM: yes my lord "@getTaggedString(%sender.name)@"!");
}
else if(%w1 $= "Follow") {
   if(%sender.allyobj.attackloop) {
   cancel(%sender.allyobj.attackloop);
   }
   if(%w2 $= "Me") {
      if(%sender.allyobj.name $= "General RAAM") {
         schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From General RAAM: im coming, lord "@getTaggedString(%sender.name)@"!");
      }
      else if(%sender.allyobj.name $= "Lord Darkrai") {
         schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: be patient "@getTaggedString(%sender.name)@", im coming.");
      }
      else if(%sender.allyobj.name $= "Lord Raam") {
         schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Raam: i'm coming "@getTaggedString(%sender.name)@", i'm coming.");
      }
      else if(%sender.ally.namebase $= "Cynthia") {  //Return here due to use of bots.
         schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: I will escort you "@getTaggedString(%sender.name)@".");
         %sender.ally.isfollowing = true;
         %sender.ally.stepEscort(%sender);
         return;
      }
      else if(%sender.ally.namebase $= "Dolosus") {  //Return here due to use of bots.
         schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Dolosus: I will escort you "@getTaggedString(%sender.name)@".");
         %sender.ally.isfollowing = true;
         %sender.ally.stepEscort(%sender);
         return;
      }
      %sender.allyobj.iszombie = 0; //allows Sword
      ZombieMoveToAlly(%sender.allyobj,%sender);
   }
   else {
      %targ = plnametocid(%w2);
      if(%targ == 0) {
         if(%sender.allyobj.name $= "General RAAM") {
            schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From General RAAM: I cannot find "@%w2@", my lord!");
         }
         else if(%sender.allyobj.name $= "Lord Darkrai") {
            schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: "@%w2@"? I can't seem to find him.");
         }
         else if(%sender.allyobj.name $= "Lord Raam") {
            schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Raam: "@%w2@" is not a valid person...");
         }
         else if(%sender.ally.name $= "Cynthia") {  //Return here due to use of bots.
            schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: No, "@%w2@" isn't here.");
         }
         return;
      }
      else {
         if(%sender.allyobj.name $= "General RAAM") {
            schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From General RAAM: sure thing, lord, following "@getTaggedString(%targ.name)@"!");
            schedule(5,0,"messageclient",%targ, 'MsgClient', "\c1From General RAAM: Lord "@getTaggedString(%sender.name)@", requested I follow you!");
         }
         else if(%sender.allyobj.name $= "Lord Darkrai") {
            schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: be patient, I'll follow "@getTaggedString(%targ.name)@".");
            schedule(5,0,"messageclient",%targ, 'MsgClient', "\c1From Lord Darkrai: "@getTaggedString(%sender.name)@" has ordered me to follow you.");
         }
         else if(%sender.allyobj.name $= "Lord Raam") {
           schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Raam: On It, Following "@getTaggedString(%targ.name)@".");
           schedule(5,0,"messageclient",%targ, 'MsgClient', "\c1From Lord Raam: "@getTaggedString(%sender.name)@" has sent me to follow you.");
         }
         else if(%sender.ally.namebase $= "Cynthia") {  //Return here due to use of bots.
           schedule(5,0,"messageclient",%targ, 'MsgClient', "\c1From Cynthia: I will escort you "@getTaggedString(%targ.name)@", "@getTaggedString(%sender.name)@" has asked of this.");
           %sender.ally.isfollowing = true;
           %sender.ally.stepEscort(%targ);
           return;
         }
         %sender.allyobj.iszombie = 0; //allows Sword
         ZombieMoveToAlly(%sender.allyobj,%targ);
      }
   }
}
else if(%w1 $= "teleport" && %w2 $= "to") {
   if(%sender.allyobj.name !$= "Lord Darkrai") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: Lord Darkrai is not your team mate "@getTaggedString(%sender.name)@".");
   return;
   }
   if(%w3 $= "you") {
   tp_emitter(%sender.player);
   pl_fadeOut(%sender.player);
   %cpos = %sender.allyobj.getPosition();
   %sender.player.setTransform(vectoradd(%cpos,"0 0 10"));
   pl_fadeIn(%sender.player);
   %sender.player.setVelocity("0 0 0"); //stop movement..
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: alright "@getTaggedString(%sender.name)@", im bringing you to me.");
   return;
   }
   %targ = plnametocid(%w3);
   if(%targ == 0) {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: come again, "@getTaggedString(%sender.name)@"?");
   return;
   }
   if(%targ == %sender) {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: I'm sorry, "@getTaggedString(%sender.name)@", I can't teleport you to yourself");
   return;
   }
   if(!isobject(%targ.player) || %targ.player.getState() $= "dead") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: apparently he is dead, "@getTaggedString(%sender.name)@". Perhaps we should wait?");
   return;
   }
   tp_emitter(%sender.player);
   pl_fadeOut(%sender.player);
   %cpos = %targ.player.getPosition();
   %sender.player.setTransform(vectoradd(%cpos,"0 0 10"));
   pl_fadeIn(%sender.player);
   %sender.player.setVelocity("0 0 0"); //stop movement..
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: alright "@getTaggedString(%sender.name)@", teleporting you to "@getTaggedString(%targ.name)@"");
}
else if(%w1 $= "bring" && %w2 $= "me") {
   if(%sender.allyobj.name !$= "Lord Darkrai") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: Lord Darkrai is not your team mate "@getTaggedString(%sender.name)@".");
   return;
   }
   if(%w3 $= "you") {
   tp_emitter(%sender.allyobj);
   pl_fadeOut(%sender.allyobj);
   %cpos = %sender.player.getPosition();
   %sender.allyobj.setTransform(vectoradd(%cpos,"0 0 10"));
   pl_fadeIn(%sender.allyobj);
   %sender.allyobj.setVelocity("0 0 0"); //stop movement..
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: alright "@getTaggedString(%sender.name)@", im coming.");
   return;
   }
   %targ = plnametocid(%w3);
   if(%targ == 0) {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: come again, "@getTaggedString(%sender.name)@"?");
   return;
   }
   if(%targ == %sender) {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: I'm sorry, "@getTaggedString(%sender.name)@", I can't teleport you to yourself");
   return;
   }
   if(!isobject(%targ.player) || %targ.player.getState() $= "dead") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: apparently he is dead, "@getTaggedString(%sender.name)@". Perhaps we should wait?");
   return;
   }
   tp_emitter(%targ.player);
   pl_fadeOut(%targ.player);
   %cpos = %sender.player.getPosition();
   %targ.player.setTransform(vectoradd(%cpos,"0 0 10"));
   pl_fadeIn(%targ.player);
   %targ.player.setVelocity("0 0 0"); //stop movement..
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: alright "@getTaggedString(%sender.name)@", bringing "@getTaggedString(%targ.name)@" to you.");
   schedule(5,0,"messageclient",%targ, 'MsgClient', "\c1From Lord Darkrai: Hello, "@getTaggedString(%targ.name)@", My Master, "@getTaggedString(%sender.name)@" has requested your presence!");
}
else if(%w1 $= "darkrai" && %w2 $= "attack") {
   if(%sender.allyobj.name !$= "Lord Darkrai") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: Lord Darkrai is not your team mate "@getTaggedString(%sender.name)@".");
   return;
   }
   %targ = plnametocid(%w3);
   if(%targ == 0) {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: come again, "@getTaggedString(%sender.name)@"?");
   return;
   }
   if(%targ == %sender) {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: I'm sorry, "@getTaggedString(%sender.name)@", but we settled our troubles ages ago, I won't attack you.");
   return;
   }
   if(!isobject(%targ.player) || %targ.player.getState() $= "dead") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: apparently he is dead, "@getTaggedString(%sender.name)@". Perhaps we should wait?");
   return;
   }
   %zomb = %sender.allyobj;
   if(%zomb.moveloop) {
   cancel(%zomb.moveloop);
   }
   %zomb.attackloop = DarkraiAttackTarget(%zomb,%targ);
   %sender.allyobj.iszombie = 1; //allows Sword
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: I'm on it "@getTaggedString(%sender.name)@"!");
   schedule(5,0,"messageall",'Message', "\c4Lord Darkrai: The Nightmares Begin for you, "@getTaggedString(%targ.name)@"!");
}
else if(%w1 $= "Call" && %w2 $= "artillery") {
   if(%sender.ally.namebase !$= "Cynthia") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: I am not your team mate "@getTaggedString(%sender.name)@".");
   return;
   }
   %targ = plnametocid(%w3);
   if(%targ == 0) {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: that target is not valid, "@getTaggedString(%sender.name)@".");
   return;
   }
   if(%targ == %sender) {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: wouldn't that be painful, "@getTaggedString(%sender.name)@"?");
   return;
   }
   if(!isobject(%targ.player) || %targ.player.getState() $= "dead") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: Dead targets would be a waste of shells "@getTaggedString(%sender.name)@".");
   return;
   }

   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: Artillery strike confirmed on "@getTaggedString(%targ.name)@"!");
   schedule(5,0,"messageall",'Message', "\c4Cynthia: Command, I need an artillery strike at "@%targ.player.getPosition()@" Now!");
   schedule(5000,0,"messageall",'Message', "\c4Command: Standby...... FIRE!");
   schedule(7500,0,"StartShells",%targ.player.position);
}
else if(%w1 $= "Raam" && %w2 $= "attack") {
   if(%sender.allyobj.name !$= "General RAAM") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: General RAAM is not your team mate "@getTaggedString(%sender.name)@".");
   return;
   }
   %targ = plnametocid(%w3);
   if(%targ == 0) {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From General RAAM: The hunt cannot begin until I have a valid target, "@getTaggedString(%sender.name)@".");
   return;
   }
   if(%targ == %sender) {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From General RAAM: HA! Like i'm going to fall for that one lord "@getTaggedString(%sender.name)@".");
   return;
   }
   if(!isobject(%targ.player) || %targ.player.getState() $= "dead") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From General RAAM: It seems that he is dead lord "@getTaggedString(%sender.name)@", Shall I loot his corpse?");
   return;
   }
   %zomb = %sender.allyobj;
   if(%zomb.moveloop) {
   cancel(%zomb.moveloop);
   }
   %zomb.attackloop = RaamAttackTarget(%zomb,%targ);
   %sender.allyobj.iszombie = 1; //allows Sword
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From General RAAM: It shall be done lord "@getTaggedString(%sender.name)@"!");
   schedule(5,0,"messageall",'Message', "\c4General RAAM: PREPARE TO DIE, "@getTaggedString(%targ.name)@"!");
}
else if(%w1 $= "Barrage") {
   if(%sender.allyobj.name !$= "Lord RAAM") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: Lord RAAM is not your team mate "@getTaggedString(%sender.name)@".");
   return;
   }
   %targ = plnametocid(%w2);
   if(%targ == 0) {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord RAAM: that is an invalid target, "@getTaggedString(%sender.name)@".");
   return;
   }
   if(%targ == %sender) {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord RAAM: uh.. no, "@getTaggedString(%sender.name)@".");
   return;
   }
   if(!isobject(%targ.player) || %targ.player.getState() $= "dead") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord RAAM: It seems that he is dead, "@getTaggedString(%sender.name)@".");
   return;
   }
   %zomb = %sender.allyobj;
   %targp = %targ.player;
   %zomb.rapiershield = 0;
   schedule(15000,0,"ResetRaamField",%zomb);
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord RAAM: Beginning Missile Strike on "@getTaggedString(%targ.name)@", "@getTaggedString(%sender.name)@"!");
   FireMoreMissiles(%zomb, %targp);
}
else if(%w1 $= "Nightmare") {
   if(%sender.allyobj.name !$= "Lord Darkrai") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: Lord Darkrai is not your team mate "@getTaggedString(%sender.name)@".");
   return;
   }
   %targ = plnametocid(%w2);
   if(%targ == 0) {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: that not a target, "@getTaggedString(%sender.name)@".");
   return;
   }
   if(%targ == %sender) {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: It's not your sleeptime, "@getTaggedString(%sender.name)@".");
   return;
   }
   if(!isobject(%targ.player) || %targ.player.getState() $= "dead") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: It seems that he is dead, "@getTaggedString(%sender.name)@".");
   return;
   }
   %zomb = %sender.allyobj;
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: Nightmaring "@getTaggedString(%targ.name)@"!");
   messageClient(%targ,'msgClient',"~wfx/misc/diagnostic_on.wav");
   Darkrainightmareloop(%zomb,%targ);
}
else if(%w1 $= "Laser" && %w2 $= "Storm") {
   if(%sender.allyobj.name !$= "Lord RAAM") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: Lord RAAM is not your team mate "@getTaggedString(%sender.name)@".");
   return;
   }
   %targ = plnametocid(%w3);
   if(%sender.allyobj.Storming) {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord RAAM: I can't fire at multiple targets, "@getTaggedString(%sender.name)@".");
   return;
   }
   if(%targ == 0) {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord RAAM: that is an invalid target, "@getTaggedString(%sender.name)@".");
   return;
   }
   if(%targ == %sender) {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord RAAM: uh.. no, "@getTaggedString(%sender.name)@".");
   return;
   }
   if(!isobject(%targ.player) || %targ.player.getState() $= "dead") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord RAAM: It seems that he is dead, "@getTaggedString(%sender.name)@".");
   return;
   }
   %zomb = %sender.allyobj;
   %targp = %targ.player;
   %zomb.rapiershield = 0;
   schedule(15000,0,"ResetRaamField",%zomb);
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord RAAM: Beginning Laser Storm on "@getTaggedString(%targ.name)@", "@getTaggedString(%sender.name)@"!");
   %zomb.Storming = 1;
   %zomb.laserStormSount = 0;
   LRLaserStorm(%zomb, %targp);
   schedule(4000,0,"resetLRLaserStorm",%zomb);
}
else if(%w1 $= "Raam" && %w2 $= "services") {
   if(%sender.allyobj.name !$= "General RAAM") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: General RAAM is not your team mate "@getTaggedString(%sender.name)@".");
   return;
   }
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From General RAAM: These are my availible Services Lord, "@getTaggedString(%sender.name)@".");
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1'raam attack [name]', 'raam stop', 'follow [name]', 'follow me', 'borrow shield'.");
}
else if(%w1 $= "LRaam" && %w2 $= "services") {
   if(%sender.allyobj.name !$= "Lord RAAM") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: Lord RAAM is not your team mate "@getTaggedString(%sender.name)@".");
   return;
   }
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord RAAM: These are my availible Services, "@getTaggedString(%sender.name)@".");
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1'lraam stop', 'follow me', 'follow [name]', 'barrage [name]', 'Laser Storm [name]'.");
}
else if(%w1 $= "Borrow" && %w2 $= "Shield") {
   if(%sender.allyobj.name !$= "General RAAM") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: General RAAM is not your team mate "@getTaggedString(%sender.name)@".");
   return;
   }
   if(!%sender.gotshield) {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From General RAAM: here you go Lord, "@getTaggedString(%sender.name)@".");
   %sender.allyobj.rapiershield = 0;
   %sender.player.rapiershield = 1;
   %sender.gotshield = 1;
   %sender.allyobj.cantRestore = 1;
   RAAMShieldUpdate(%sender.player);
   return;
   }
   else {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From General RAAM: You must be done with it lord, "@getTaggedString(%sender.name)@"?");
   %sender.allyobj.rapiershield = 1;
   %sender.player.rapiershield = 0;
   %sender.gotshield = 0;
   %sender.allyobj.cantRestore = 0;
   schedule(100,0,"RAAMShieldUpdate",%sender.allyobj);
   return;
   }
}
else if(%w1 $= "darkrai" && %w2 $= "services") {
   if(%sender.allyobj.name !$= "Lord Darkrai") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: Lord Darkrai is not your team mate "@getTaggedString(%sender.name)@".");
   return;
   }
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: This is what I can do for you "@getTaggedString(%sender.name)@".");
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1'darkrai attack [name]', 'darkrai stop', 'follow [name]', 'follow me', 'teleport to [name]', 'bring me [name]', 'wake me', 'wake [name]', 'nightmare [name]'.");
}
else if(%w1 $= "Cynthia" && %w2 $= "services") {
   if(%sender.allyobj.name !$= "Cynthia") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: I am not your team mate "@getTaggedString(%sender.name)@".");
   return;
   }
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: Glad you asked, "@getTaggedString(%sender.name)@", this is what I can do.");
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1'cynthia stop', 'cynthia attack [name]', 'follow me', 'follow [name]', 'call artillery [name]'.");
}
else if(%w1 $= "Dolosus" && %w2 $= "services") {
   if(%sender.ally.namebase !$= "Dolosus") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Dolosus: I am not your team mate "@getTaggedString(%sender.name)@".");
   return;
   }
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Dolosus: My commands --");
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1'dolosus stop', 'dolosus attack [name]', 'dolosus hunt' and 'follow me'");
}
else if(%w1 $= "dolosus" && %w2 $= "attack") {
   if(%sender.ally.namebase !$= "Dolosus") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Dolosus: I won't listen to you!");
   return;
   }

   if (!PlNameToCid(%w3))
   {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Dolosus: That person doesn't seem to exist..");
   return;
   }
   %targ = PlNameTocid(%w3);
   if (%targ == %sender)
   {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Dolosus: I cannot attack my own master..!");
   return;
   }
   if (!IsObject(%targ.player) || %targ.player.getState() $= "dead")
   {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Dolosus: I can't attack the dead.");
   return;
   }

   %sender.ally.stepEngage(%targ);
   %sender.ally.attacking = true;
   %sender.ally.attackclient = %targ;
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Dolosus: I shall do my best.");
   schedule(5,0,"messageclient",%targ, 'MsgClient', "\c1From Dolosus: I smell lunch, it's you!");
   messageAll('msgall','\c4Dolosus: Time to die, %1!',%cl.ally.attackclient.namebase);
   return;
   }
   else if(%w1 $= "cynthia" && %w2 $= "attack") {
   if(%sender.ally.namebase !$= "Cynthia") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: I won't listen to you!");
   return;
   }

   if (!PlNameToCid(%w3))
   {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: That person doesn't seem to exist..");
   return;
   }
   %targ = PlNameTocid(%w3);
   if (%targ == %sender)
   {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: I cannot attack my own master..!");
   return;
   }
   if (!IsObject(%targ.player) || %targ.player.getState() $= "dead")
   {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: I can't attack the dead.");
   return;
   }

   %sender.ally.stepEngage(%targ);
   %sender.ally.attacking = true;
   %sender.ally.attackclient = %targ;
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: I shall do my best.");
   schedule(5,0,"messageclient",%targ, 'MsgClient', "\c1From Cynthia: You are in my targeting sights!!!");
   messageAll('msgall','\c4Cynthia: Time to die, %1!',%cl.ally.attackclient.namebase);
   return;
   }
   else if(%w1 $= "dolosus" && %w2 $= "hunt") {
   if(%sender.ally.namebase !$= "Dolosus") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Dolosus: I won't listen to you!");
   return;
   }

   %sender.ally.attacking = true;
   %sender.ally.attackclient = %targ;
   %sender.ally.hunting = true;
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Dolosus: Burn zombies...");
   return;
   }
else if(%w1 $= "recruit" && %w2 $= "member") {
   if(%sender.ally) {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: I can't assign you two members at once "@getTaggedString(%sender.name)@".");
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: Please type 'disband member' or wait for your member to die before assigning a new one.");
   return;
   }
   if(!isobject(%sender.player) || %sender.player.getState() $= "dead") {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: you need a player object.");
   return;
   }
   if(%rcname $= "Lord Darkrai") {
      if(!$Medals::DarkraiKiller[%sender.GUID]) {
      schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: Definately!");
      schedule(3000,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: NOT!");
      }
      else {
      schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: Patience "@getTaggedString(%sender.name)@", i'm coming!");
      schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord Darkrai: If you want to see what I can to, type 'darkrai services'.");
      %dark = StartAAllyZombie(vectorAdd(%sender.player.getPosition(),"0 0 10"), 8);
      %dark.name = "Lord Darkrai";
      %dark.team = %sender.team;
      %sender.allyobj = %dark;
      %sender.ally = 1;
      %sender.hasteammember = 1;
      %sender.ally.watchloop = schedule(5000,0,"WatchAlly",%sender, %dark);
      }
      return;
   }
   else if(%rcname $= "General RAAM") {
      if(!$Medals::RAAMKiller[%sender.GUID]) {
      schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From General RAAM: I will slaughter you before I EVER join you.");
      }
      else {
      schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From General RAAM: Hail Great Champion "@getTaggedString(%sender.name)@", Do not start the killing without Me!");
      schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From General RAAM: My Services are availible for you, type 'raam services' and I will gladly tell you them!");
      %dark = StartAAllyZombie(vectorAdd(%sender.player.getPosition(),"0 0 10"), 7);
      %dark.name = "General RAAM";
      %dark.team = %sender.team;
      %sender.allyobj = %dark;
      %sender.ally = 1;
      %sender.hasteammember = 1;
      %sender.ally.watchloop = schedule(5000,0,"WatchAlly",%sender, %dark);
      }
      return;
   }
   else if(%rcname $= "Lord RAAM") {
      if(!$Medals::LordRaamDestroyer[%sender.GUID]) {
      schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord RAAM: HAHAHAHAHAHAHAAHAHA NO WAY HAHAHAHHA.");
      }
      else {
      schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord RAAM: Ah "@getTaggedString(%sender.name)@", I am ready for action!");
      schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Lord RAAM: need assistance? 'Lraam services' is definately for you!");
      %dark = StartAAllyZombie(vectorAdd(%sender.player.getPosition(),"0 0 10"), 11);
      %dark.name = "Lord RAAM";
      %dark.team = %sender.team;
      %sender.allyobj = %dark;
      %sender.ally = 1;
      %sender.hasteammember = 1;
      %sender.ally.watchloop = schedule(5000,0,"WatchAlly",%sender, %dark);
      }
      return;
   }
   else if(%rcname $= "Cynthia") {
      if(!$Medals::HonorsAward2[%sender.GUID]) {
      schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: I can't "@getTaggedString(%sender.name)@", You need some more Experience.");
      }
      else {
      schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: Alright then "@getTaggedString(%sender.name)@", Im coming.");
      schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: I can do some things for you, type 'cynthia services' to see those.");
      %cyn = aiconnectbyname("Cynthia",%sender.team);
      %cyn.sex = "Female";
      %cyn.player.setarmor("RSAScout");
      %cyn.player.setInventory("LaserGun", 1, true);
      %cyn.player.setInventory("LaserGunAmmo", 999, true);
      %cyn.player.use(LaserGun);

      SetSkin(%cyn,"SWolf");
      SetVoice(%cyn,"Fem3",1);
      %cyn.clearTasks();

      %pos = %sender.player.getPosition();
      %cyn.player.setTransform(vectoradd(%pos,"0 0 5"));

      //Set up the sender now
      %sender.ally = %cyn;
      %sender.hasteammember = true;
      %sender.allyobj = %cyn.player;
      %sender.allyCyn = true;

      %sender.allyobj.name = "Cynthia";

      %sender.ally.watchloop = schedule(5000,0,"WatchAllyB",%sender, %bot);
      }
      return;
   }
    else if(%rcname $= "Dolosus") {
      if(!$Medals::FireExtinguisher[%sender.guid]) {
      schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Dolosus: Beat the Ghost Of Fire first to earn my loyalty.");
      }
      else {
      schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Dolosus: I see my presence is requested, "@%sender.namebase@".");
      schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Dolosus: For a list of commands, type 'dolosus serverices'.");
      %dolo = aiconnectbyname("Dolosus",%sender.team);
      %dolo.sex = "Male";
      %dolo.race = "Bioderm";
      %dolo.player.setarmor("Flame");
      //Add Weapons
      %dolo.player.setInventory("flamerammo",60,true);
      %dolo.player.setInventory("flamer",1,true);
      %dolo.player.setInventory("flamerammopack",1,true);
      %dolo.player.hasFlamerAmmopack = true;
      %dolo.player.setInventory("NapalmAmmo",7,true);
      %dolo.player.setInventory("Napalm",1,true);
      %dolo.player.setInventory("RepairKit",2,true);
      %dolo.player.setInventory("CrispMine",5,true);
      %dolo.player.setInventory("IncindinaryGrenade",7,true);
      %dolo.player.use("flamer");

      SetSkin(%dolo,"Horde");
      SetVoice(%dolo,"Derm3",1);
      %dolo.setSkillLevel(20);
      %dolo.clearTasks();

      %pos = %sender.player.getPosition();
      %dolo.player.setTransform(vectoradd(%pos,"0 0 5"));

      //Set up the sender now
      %sender.ally = %dolo;
      %sender.hasteammember = true;
      %sender.allyobj = %dolo.player;
      %sender.allyCyn = true;

      %sender.allyobj.name = "Dolosus";

      %sender.ally.watchloop = schedule(5000,0,"WatchAllyD",%sender, %dolo);
      }
      return;
   }
   else {
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: I'm sorry "@getTaggedString(%sender.name)@", "@%rcname@" is not on your recruit list.");
   schedule(5,0,"messageclient",%sender, 'MsgClient', "\c1From Cynthia: Type 'Recruit List' to see who you can recruit.");
   }
}
if(%message $= "Who is Darkrai?") {
schedule(5,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: well, "@getTaggedString(%sender.name)@". From what I know, Darkrai is the leader of the zombie army.");
schedule(3500,0,"messageall",'Message', "\c4Lord Darkrai: hehehe, you definately have that one right.");
schedule(6000,0,"messageall",'Message', "\c4Lord Darkrai: oh a newbie! I will be seeing you very soon "@getTaggedString(%sender.name)@", very soon...");
schedule(9500,0,"messageall",'Message', "\c4General RAAM: Bah! Newbies are worthless scums that are slaughtered easily.");
schedule(12000,0,"messageall",'Message', "\c4Lord Darkrai: Patience my General, the plan must not be revealed... yet.");
schedule(17500,0,"messageall",'Message', "\c4{[TWM]}-Cynthia: What could those two possibly be scheming now "@getTaggedString(%sender.name)@"?");
}
}

function CynthiaFinish(%bot,%sender) {
%bot.player.setposition(%sender.player.getposition());
%sender.allyobj = %bot.player;
//Remove her AI
AIUnassignClient(%bot);
%bot.clearTasks();
%bot.clearStep();
//Set the armor
//%bot.player.setarmor(RSAScout);
%bot.player.name = "Cynthia";
}

function WatchAllyB(%cl, %ally) {
   if(!%cl) {
   %ally.player.blowup();
   kick(%ally);
   return;
   }
   if(%ally.player.disbanded)
   return;

   if (!IsObject(%cl.ally.player))
   {
   %rnd = GetRandom(0,1);

   if(%rnd)
   schedule(5,0,"messageclient",%cl, 'MsgClient', "\c1From Cynthia: Oh Dear, I seem to have died. ~wvoice/Fem5/avo.deathcry_01.wav");
   else
   schedule(5,0,"messageclient",%cl, 'MsgClient', "\c1From Cynthia: Oh Dear, I seem to have died. ~wvoice/Fem5/avo.deathcry_02.wav");

   kick(%cl.ally);

   %cl.ally = 0;
   %cl.hasteammember = 0;
   return;
   }

   if(%cl.player.getState() $= "dead")
   {
   schedule(5,0,"messageclient",%cl, 'MsgClient', "\c1From Cynthia: Oh Dear "@getTaggedString(%cl.name)@", it seems "@%ally.player.name@" has fallen!");
   %cl.ally.isfollowing = false;
   %cl.ally.stepEscort(-1);
   }

   schedule(1000,0,"WatchAllyB",%cl, %ally);
}

function WatchAllyD(%cl, %ally) {
   if(!%cl) {
      %ally.player.blowup();
      kick(%ally);
      return;
   }
   if(%ally.player.disbanded)
      return;

   if (%cl.ally.attacking) {
      if (!%cl.ally.hunting) {
         if (!IsObject(%cl.ally.attackclient.player) || %cl.ally.attackclient.player.getState() $= "Dead") {
            %cl.ally.attacking = false;
            messageAll('msgall','\c4Dolosus: %1 has been hunted.',%cl.ally.attackclient.namebase);
         }
      }
   }
   else {
      InitContainerRadiusSearch(%cl.ally.player.getPosition(), 7000, $TypeMasks::PlayerObjectType);
      while ((%searchResult = containerSearchNext()) != 0) {
         %objtarget = firstWord(%searchResult);
         if (%objTarget.isZombie && %objTarget != %cl.ally.curZombie) {
            %cl.ally.setEngageTarget(%objtarget);
            %cl.ally.setTargetObject(%objTarget);
            %cl.ally.curZombie = %objTarget;
         }
      }
   }
   if (!IsObject(%cl.ally.player) && !%cl.ally.disbanded) {
   %rnd = GetRandom(0,1);

   if(%rnd)
   schedule(5,0,"messageclient",%cl, 'MsgClient', "\c1From Dolosus: I've taken too much damage...! I'm retreating! ~wvoice/Derm3/avo.deathcry_01.wav");
   else
   schedule(5,0,"messageclient",%cl, 'MsgClient', "\c1From Dolosus: Arghhh! I'm retreating! ~wvoice/Derm3/avo.deathcry_02.wav");

   kick(%cl.ally);

   %cl.ally = 0;
   %cl.hasteammember = 0;
   return;
   }

   if(%cl.player.getState() $= "dead")
   {
   schedule(5,0,"messageall",'msgall','\c4Dolosus: %1? You still alive?',%cl.namebase);
   %cl.ally.isfollowing = false;
   %cl.ally.stepEscort(-1);
   }

   schedule(1000,0,"WatchAllyD",%cl, %ally);
}

//function ResetRepMessage(%cl) {
//$LastMessage[%cl] = "";
//}

function setSkin(%cl,%skin)
{

FreeclientTarget(%cl);
%cl.skin = addtaggedstring(%skin);
%cl.target = allocClientTarget(%cl, %cl.name, %cl.skin, %cl.voiceTag, '_ClientConnection', %cl.team, %cl.team, %cl.voicePitch);

if (IsObject(%cl.player))
%cl.player.setTarget(%cl.target);
}

function setVoice(%cl,%voice,%pitch)
{

FreeClientTarget(%cl);
%cl.voice = %voice;
%cl.voicetag = addtaggedstring(%voice);
%cl.voicePitch = %pitch;

%cl.target = allocClientTarget(%cl, %cl.name, %cl.skin, %cl.voiceTag, '_ClientConnection', %cl.team, %cl.team, %cl.voicePitch);

if (IsObject(%cl.player))
%cl.player.setTarget(%cl.target);
}

