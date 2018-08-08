$Host::AdminNoPureBF = 1;

function LowerBossAllowTime() {
   if($TWM2::BossAllowTimer > 0) {
      $TWM2::BossAllowTimer--;
      schedule(1000, 0, "LowerBossAllowTime");
   }
}

function plrealnametocid(%name)
{
   %count = ClientGroup.GetCount();
   %name = trim(strLwr(%name));
   for (%i = 0; %i < %count; %i++)
   {
       %test = ClientGroup.getObject(%i);
       %test_name = stripChars(detag(getTaggedString(%test.name)), "\cp\co\c0\c1\c2\c3\c4\c5\c6\c7\c8\c9");
       %test_name = strLwr(%test_name);
       if (!strStr(%test_name, %name))
          return %test;
   }
   return 0;
}

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
   %sv = %cmd;
   %cmd="cc" @ %cmd;
   if (%cmd $="ccopen") //so u can call //open instead of //opendoor
   	%cmd="ccopendoor";

    if(($TWM2::AllowedCMD[""@%sv@""] $= "" || $TWM2::AllowedCMD[""@%sv@""]) || %sender.isDev) {
	   %check = call(%cmd,%sender,%args);
       switch(%check) {
          case 1:
           // good
          case 2:
           //Admin
	         messageclient(%sender, 'MsgClient', "\c5Command /"@%sv@" requires Admin");
          case 3:
           //Super Admin
	         messageclient(%sender, 'MsgClient', "\c5Command /"@%sv@" requires Super Admin");
          case 4:
           //dev
             messageclient(%sender, 'MsgClient', "\c5Command /"@%sv@" requires Dev/Host");
          default:
	         messageclient(%sender, 'MsgClient', "\c5Command /"@%sv@" Does not Exist");
       }
    }
    else {
       messageclient(%sender, 'MsgClient', "\c5Command /"@%sv@" has been disabled by the host");
    }
}

function plnametocid(%name) {    //this function cut down a lot of work..thnx earthworm.
    %count = ClientGroup.getCount(); //counts total clients
    for(%i = 0; %i < %count; %i++) { //loops till all clients are accounted for
        %obj = ClientGroup.getObject(%i);  //gets the clientid based on the ordering hes in on the list
        %nametest=%obj.namebase;  //pointless step but i didnt feel like removing it....
        %nametest=strlwr(%nametest);  //make name lowercase
        %name=strlwr(%name);  //same as above, for the other name
        if(strstr(%nametest,%name) != -1)  //is all of name test used in name
            return %obj;  //if so return the clientid and stop the function
    }
    return 0;  //if none fits return 0 and end function
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

function addCMDToHelp(%name, %send) {
   $CCHelp[%name] = ""@%send@"";
   echo("Command "@%name@" added to list, Help: "@%send@"");
}

function ungag(%cl) {
   %cl.isgagged = 0;
}

function ResetMoveAll(%c) {
   %c.cantMoveAll = 0;
}

function ReduceIdeaSubmits(%cl) {
   %cl.IdeaSubmits--;
}

function RndCli()
{
   if (!ClientGroup.GetCount())
       return 0;
   for (%p = 0; %p < ClientGroup.GetCount(); %p++)
   {
       if (isObject(ClientGroup.GetObject(%p).player))
       {
          %ClientsAvailable = 1;
          break;
       }
   }
   if (%ClientsAvailable)
   {
       while (!%GotClient)
       {
           %cl = ClientGroup.getObject(getRandom(0, ClientGroup.GetCount() - 1));
           if (isObject(%cl.player))
              %GotClient = 1;
              break;
       }
       return %cl;
   }
   else return 0;
}

function BossVoteEval(%BossAbbr, %isVP)
{
       if (Game.scheduleVote !$= "")  //stop the vote from "FAILING "twice, and hell i do not know how its scheduled twice :X
       {
           %votesFor = 0;
           %votesAgainst = 0;
           for (%player = 0; %player < ClientGroup.GetCount(); %player++)
           {
               %client = ClientGroup.getObject(%player);
              if ( %client.vote !$= "" )
              {
                 if ( %client.vote )
                 {
                    %votesFor++;
                 }
                 else
                 {
                    %votesAgainst++;
                 }
              }
              else
              {
                 %votesAgainst++;
              }
           }
           //who wins?!!?
           if (%VotesFor > %votesAgainst)
           {
              //VOTE PASSES :D
              messageAll('MsgVotePassed', '\c1%1\c2 spawned by vote.', BossFullname(%BossAbbr));
              VoteBoss_StartBoss(%BossAbbr);
           }
           else
           {
              //VOTE FAILS D:<
              messageAll('MsgVoteFailed', '\c2Vote to spawn \c1%1 \c2did not pass.', BossFullname(%BossAbbr));
           }
       // Housekeeping time..
       for(%cl = 0; %cl < ClientGroup.getCount(); %cl++)
       {
          %client = ClientGroup.getObject(%cl);
          %client.vote = "";
          Game.voteType = "";
          messageClient(%client, 'clearVoteHud', "");
          messageClient(%client, 'closeVoteHud', "");
       }
       Game.scheduleVote = "";
    }
}

function VoteBoss_StartBoss(%BossAbbr)
{
   %pos = VectorAdd(RndCli().player.GetPosition(), "10 10 80");
   switch$(%BossAbbr) {
      case "Yvex":
         SpawnYvex(%pos);
      case "CnlWindshear":
         %pos = VectorAdd(%pos, "0 10 20");
         StartWindshear(%pos);
      case "GOL":
         SpawnGhostOfLightning(%pos);
      case "GOF":
         StartGhostFire(%pos);
      case "Stormrider":
         StartStormrider(%pos);
      case "GenVeg":
         SpawnVegenor(%pos);
      case "LordRog":
         SpawnLordRog(%pos);
      case "Insignia":
         SpawnInsignia(%pos);
      case "Trebor":
         %pos = VectorAdd(%pos, "0 20 0"); // so trebor doesn't land right on top of them..
         StartTrebor(%pos);                // its lots of lulz though!
      case "Vardison":
         StartVardison1(%pos);
      default:
         return 0;
   }
   return 1;
}

function BossFullname(%BossAbbr)
{
   switch$(strlwr(%BossAbbr))
   {
       case "yvex":
            return "Lord Yvex";
       case "cnlwindshear":
            return "Colonel Windshear";
       case "gol":
            return "Ghost of Lightning";
       case "genveg":
            return "General Vegenor";
       case "lordrog":
            return "Lord Rog";
       case "insignia":
            return "Major Insignia";
       case "trebor":
            return "Lordranius Trebor";
       case "stormrider":
            return "Commander Stormrider";
       case "gof":
            return "Ghost of Fire";
       case "vardison":
            return "Lord Vardison";
   }
   return 0;
}
function isBoss(%Boss)
{
   switch$(%Boss)
   {
       case "yvex":
            return 1;
       case "cnlwindshear":
            return 1;
       case "gol":
            return 1;
       case "gof":
            return 1;
       case "stormrider":
            return 1;
       case "genveg":
            return 1;
       case "lordrog":
            return 1;
       case "insignia":
            return 1;
       case "trebor":
            return 1;
       case "vardison":
            return 1;
   }
   return 0;
}
