$ScoreHudMaxVisible = 16; //maybe 16 for low end people?
function ConstructionGame::updateScoreHud(%game, %client, %tag){
if (%client.SCMPage $= "") %client.SCMPage = 1;
if (%client.SCMPage $= "SM") return;
$TagToUseForScoreMenu = %tag;
messageClient( %client, 'ClearHud', "", %tag, 0 );
messageClient( %client, 'SetScoreHudHeader', "", "" );
messageClient( %client, 'SetScoreHudHeader', "", "<a:gamelink\tGTP\t1>E.V.A.</a><rmargin:600><just:right><a:gamelink\tNAC\t1>Close</a>" );
messageClient( %client, 'SetScoreHudSubheader', "", "Main Command Hud" );
scoreCmdMainMenu(%game,%client,%tag,%client.SCMPage);
}

function ConstructionGame::processGameLink(%game, %client, %arg1, %arg2, %arg3, %arg4, %arg5){
%tag = $TagToUseForScoreMenu;
messageClient( %client, 'ClearHud', "", %tag, 1 );
//Stuff
if(%arg1 $= "")
%arg1 = "Null";
if(%arg2 $= "")
%arg2 = "Null";
if(%arg3 $= "")
%arg3 = "Null";
if(%arg4 $= "")
%arg4 = "Null";
if(%arg5 $= "")
%arg5 = "Null";
//end
echo("[F2] "@%client.namebase@": "@%arg1@", "@%arg2@", "@%arg3@", "@%arg4@", "@%arg5@".");
switch$ (%arg1)
{
        case "GTP":
             scoreCmdMainMenu(%game,%client,$TagToUseForScoreMenu,%arg2);
             %client.SCMPage = %arg2;
             return;

        case "TSSF":
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "TWM : The Story So Far" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Welcome to 2009, Or shall I say, Welcome to the year it ended. The Zombies");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "have come, and they are killing us off. We had no choice but to flee. We have");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "learned so far that they are coming from gates of another dimmension and that");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "a mysterious ruler named Lord Darkrai is behind these gates, And the invasion.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Ever since these gates have opened, The People of our glorious country have split");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "into many factions that are warring with eachother while the zombies war with us.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Finally after many years, it's 2013, A Commander Named Phantom Ended The");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "war between the factions. Each faction agreed to a 'Blacklist' to determine the");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "best of all. However Now the People are scared, and a full scale war has erupted.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Welcome, To Total Warfare.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tJournal\t1>Go to My Journal</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             return;
             
        case "Journal":
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "TWM : My Journal" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Well, I'm happy today. I was finally enlisted. Its time, My Time. I have come");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "to wipe those zombies off the face of the planet. But, It won't be easy.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             if($Medals::NoMoreNewbie[%client.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Alright! I'm no longer a private! Now I can use some better weapons.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             }
             if($Medals::TheFirstK[%client.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "I'm almost a sergant now, However, I feel as if the dark is coming.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             }
             if($Rank::XP[%client.GUID] > 1150) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Attack on Wisconsin? The army there was overrun by a Lord Darkrai? Who is he?");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "I did meet someone though today, Cmdr. Alex, He will be guiding me now.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             }
             if($Medals::RAAMKiller[%client.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "General RAAM, The ruthless zombie general, Heh, He can enjoy his fall down that");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "pipe shaft, However what scared me today is after I killed him, I suddenly fell.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "I couldn't move, All I heard was a wisper saying 'Your Next "@%client.namebase@"'.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "When we headed back to our base, We noticed smoke, So we ran. I was thinking");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "about What happened earlier. When we got there a wounded soldier told us that it");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "was not A zombie attack, But an attack from the Aeronaught Army, A Rival Faction.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             }
             if($Medals::WhosTank[%client.GUID] $= true) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Lieutenant Alister, She had a sweet ride, Too bad her tank was one of the");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "attackers from the aeronaught army. The last thing she told me before she died");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "was one word: 'Stormrider'.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             }
             if($Medals::StormEnder[%client.GUID] $= true) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "And the end of the Aeronaught Army has come. When Stormrider went down");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "We felt good. Suddenly I fell to the ground, Alex Noticed this time and he ");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "called for help, A shadowy figure walked up and started to laugh, evily.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "All he said was, I told you, You were next. Alex turned back towards the");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "figure, shouted Darkrai, and sent flames his way, He vanished into air.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Alex told me everything about Darkrai that day. And what he does to humans.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             }
             if($Medals::DarkraiKiller[%client.GUID] $= true) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "After Meeting Darkrai, I knew who to look for, But now he had his plan.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "We were headed home when we saw a large invasion force moving towards");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "there.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "We boarded the massive tank unit and started to kill everything on it.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "After destroying the tank we looked north, and saw a huge gate, A Grand.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Gate, We knew what we had to do.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "we entered a rift portal, and saw the zombie homeworld, So advanced.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Fighting through the gateway of zombies until we reached the pinical");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Alex smashed the crystal and we returned. Darkrai attacked us the");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "instant we escaped. We fought him off, and then he ran to a wierd");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Building, We had no choice but to stop him here.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Upon reaching the dark core, Darkrai Stopped all of his minions");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "from slaughtering us, his downfall. We killed him there after a");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Long and Harsh Battle, Before he died, he said, this is only...");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "The Beginning... Of This... War....");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             }
             if($Medals::LordRaamDestroyer[%client.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Of course, Darkrai was right. And it seems RAAM Did not die.. He became");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "The new ruler of the zombie army when darkrai died. His plan, Well We");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Definately noticed it upon exiting the core. A huge Airship.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "We did not see any way of getting in, Suddenly two air rapiers, demons");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "and a sniper zombie came, They said they would help us be rid of RAAM.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "With their help, we got onboard the massive airship.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Alex, Such a brave warrior. Died to our enemy... RAAM was smart, but not.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "When he shot at alex to kill him he exposed his weak point, And I Shot");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "At RAAM with the one pistol shot I had Left. The War Was Over.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Although the war is over now, I have a new dream, Become the Top on");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "The blacklist, And Retain Alex's Good Name. The Sniper zombie Asked me to");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "take the crown of the zombies, I said no, And told him to keep it. He did");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "He promissed me that a great alliance between our races would develop.");
             %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             return;

        case "BF":
             if (isobject(%client.player)) {
                if($Host::Purebuild == 1)
   	               buyFavorites(%client);
                else if(!$host::purebuild && %client.issuperadmin)
                   buyFavorites(%client);
                else
                   messageclient(%client, 'MsgClient', "\c5Purebuild Is Off");
             }

        case "TWM":
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "TWM Information" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Website Needed, DL at TC Forums");
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             return;
             
        case "ContSave":
             %client.SCMPage = "SM";
             //PIECE COUNT
             %counter=deployables.getcount();
             for (%n=0;%n<%counter;%n++) {
                 %obj = deployables.getObject(%n);
                 %totalPC++;
             }
             //END
             messageClient( %client, 'SetScoreHudSubheader', "", "Content Saving System (V2.0)" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, 'Created By Phantom139');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, 'To Rename Slots: /NameSlot [Slot #] [New Name]');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<color:FF0000>[RED] - Not Possible Or Shouldn't Be Done");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<color:FFFF66>[YELLOW] - Warning");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<color:33FF00>[GREEN] - Possible");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             for(%i = 1; %i < 6; %i++) {
                if($SaveFile::SlotName[%client.guid,%i] $= "") {
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<color:003300>SLOT "@%i@" : "@RunSaveCheck(%client, %i)@"<color:003300>  -  "@RunLoadCheck(%client, %i, %totalPC)@"<color:003300>  -  "@RunDeleteCheck(%client, %i)@"<color:003300>  -  "@CheckSlotStatus(%client,%i)@"");
                %index++;
                }
                else {
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<color:003300>"@$SaveFile::SlotName[%client.guid,%i]@" : "@RunSaveCheck(%client, %i)@"<color:003300>  -  "@RunLoadCheck(%client, %i, %totalPC)@"<color:003300>  -  "@RunDeleteCheck(%client, %i)@"<color:003300>  -  "@CheckSlotStatus(%client,%i)@"");
                %index++;
                }
             }
             if(%client.isadmin) {
                for(%i = 6; %i < 11; %i++) {
                   if($SaveFile::SlotName[%client.guid,%i] $= "") {
                   messageClient( %client, 'SetLineHud', "", %tag, %index, "<color:003300>SLOT "@%i@" : "@RunSaveCheck(%client, %i)@"<color:003300>  -  "@RunLoadCheck(%client, %i, %totalPC)@"<color:003300>  -  "@RunDeleteCheck(%client, %i)@"<color:003300>  -  "@CheckSlotStatus(%client,%i)@"");
                   %index++;
                   }
                   else {
                   messageClient( %client, 'SetLineHud', "", %tag, %index, "<color:003300>"@$SaveFile::SlotName[%client.guid,%i]@" : "@RunSaveCheck(%client, %i)@"<color:003300>  -  "@RunLoadCheck(%client, %i, %totalPC)@"<color:003300>  -  "@RunDeleteCheck(%client, %i)@"  -  "@CheckSlotStatus(%client,%i)@"");
                   %index++;
                   }
                }
             }
             if(%client.issuperadmin) {
                for(%i = 11; %i < 16; %i++) {
                   if($SaveFile::SlotName[%client.guid,%i] $= "") {
                   messageClient( %client, 'SetLineHud', "", %tag, %index, "<color:003300>SLOT "@%i@" : "@RunSaveCheck(%client, %i)@"<color:003300>  -  "@RunLoadCheck(%client, %i, %totalPC)@"<color:003300>  -  "@RunDeleteCheck(%client, %i)@"<color:003300>  -  "@CheckSlotStatus(%client,%i)@"");
                   %index++;
                   }
                   else {
                   messageClient( %client, 'SetLineHud', "", %tag, %index, "<color:003300>"@$SaveFile::SlotName[%client.guid,%i]@" : "@RunSaveCheck(%client, %i)@"<color:003300>  -  "@RunLoadCheck(%client, %i, %totalPC)@"<color:003300>  -  "@RunDeleteCheck(%client, %i)@"<color:003300>  -  "@CheckSlotStatus(%client,%i)@"");
                   %index++;
                   }
                }
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             return;

        case "Save":
             if(!%client.guid) {
             MessageClient(%client,'Deny',"\c1From Cynthia: Error: You do not have a Registered GUID, please /Auth In.");
             closescorehudfserv(%client);
             return;
             }
             if(%client.cantSave) {
             %x = MFloor($SaveTime::TimeLeft[%client.guid, "Save"] / 60);
             %y = $SaveTime::TimeLeft[%client.guid, "Save"] % 60;
             if(%x > 0) {
             MessageClient(%client,'Deny',"\c1From Cynthia: You have only recently saved a building, please wait "@%x@" Minutes and "@%y@" Seconds.");
             }
             else {
             MessageClient(%client,'Deny',"\c1From Cynthia: You have only recently saved a building, please wait "@%y@" Seconds.");
             }
             closescorehudfserv(%client);
             return;
             }
             if(!$Phantom::CSSEnabled && !%client.issuperadmin) {
             MessageClient(%client,'Deny',"\c1From Cynthia: Content Saving Is Disabled on This Server, Please Contact a server admin.");
             closescorehudfserv(%client);
             return;
             }
             %slot = %arg2;
             $SaveFile::Save[%client.guid,%slot] = PersonalsaveBuilding(%client,99999999,""@%client.guid@"/"@%slot@"",0);
             $SaveFile::PieceCT[%client.guid,%slot] = $SaveBuilding::Saved[$SaveFile::Save[%client.guid,%slot]];  //How many pieces?
             $SaveTime::TimeLeft[%client.guid, "Save"] = 60 * $TWM::CSSTimeSave; //5 mins
             %client.cantSave = 1;
             schedule(1,0,"ResetSave",%client);
             %Gender = (%client.sex $= "Male" ? 'his' : 'her');
             messageall('MsgAdminForce', "\c3"@ %client.namebase@"\c2 saved "@getTaggedString(%gender)@" pieces.");
             MessageClient(%client,'Success',"\c1From Cynthia: Building Saved To Content Save Slot "@%slot@".");
             export( "$SaveFile::*", "prefs/ContentSave.cs", false );
             closescorehudfserv(%client);
             return;

        case "Load":
             if(!%client.guid) {
             MessageClient(%client,'Deny',"\c1From Cynthia: Error: You do not have a Registered GUID, please /Auth In.");
             closescorehudfserv(%client);
             return;
             }
             if(%client.cantLoad) {
             %x = MFloor($SaveTime::TimeLeft[%client.guid, "Load"] / 60);
             %y = $SaveTime::TimeLeft[%client.guid, "Load"] % 60;
             if(%x > 0) {
             MessageClient(%client,'Deny',"\c1From Cynthia: You have only recently loaded a building, please wait "@%x@" Minutes and "@%y@" Seconds.");
             }
             else {
             MessageClient(%client,'Deny',"\c1From Cynthia: You have only recently loaded a building, please wait "@%y@" Seconds.");
             }
             closescorehudfserv(%client);
             return;
             }
             %slot = %arg2;
             PERSloadBuilding($SaveFile::Save[%client.guid,%slot]);
             $SaveTime::TimeLeft[%client.guid, "Load"] = 60 * $TWM::CSSTimeLoad; //5 mins
             %client.cantLoad = 1;
             schedule(1,0,"ResetLoad",%client);
             messageall('MsgAdminForce', "\c3"@ %client.namebase@"\c2 is loading a building, evaluating power and removing duplicate deployables.");
             MessageClient(%client,'Success',"\c1From Cynthia: Loading Building In Content Save Slot "@%slot@".");
             closescorehudfserv(%client);
             return;

        case "SaveWarn":
             %slot = %arg2;
             if($SaveFile::Save[%client.guid,%slot] !$= "") {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<color:FF0000>WARNING, PIECES DETECTED, SAVE OVER THE SLOT?");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<color:FF0000>WARNING, BUILDINGS CANNOT BE RECOVERED IF SAVED OVER");
             %index++;
             }
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Content Saving System" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Save Pieces?   <a:gamelink\tSave\t"@%slot@">Yes</a>     <a:gamelink\tContSave\t1>No</a>");
             %index++;
             return;

        case "DeleteWarn":
             %slot = %arg2;
             if($SaveFile::Save[%client.guid,%slot] $= "") {
             MessageClient(%client,'Deny',"\c1From Cynthia: Error: No pieces in this slot to delete.");
             closescorehudfserv(%client);
             return;
             }
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Content Saving System" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<color:FF0000>WARNING, BUILDINGS CANNOT BE RECOVERED IF DELETED");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Continue?   <a:gamelink\tDelYes\t"@%slot@">Yes</a> <a:gamelink\tContSave\t1>No</a>");
             %index++;
             return;

        case "DelYes":
             %slot = %arg2;
             %file = $SaveFile::Save[%client.guid,%slot];
             new fileObject("Building");
             Building.openForWrite(%file);
             Building.delete();
             $SaveFile::PieceCT[%client.guid,%slot] = 0;
             $SaveFile::Save[%client.guid,%slot] = "";
             $SaveFile::SlotName[%client.guid,%slot] = "SLOT "@%slot@"";
             MessageClient(%client,'Success',"\c1From Cynthia: Pieces in slot "@%slot@" have been deleted.");
             closescorehudfserv(%client);
             return;

        case "Ranks":
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Player Information Listings" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Select A Client");
             %index++;
             %count=clientgroup.getcount();
             for (%i = 0; %i < %count; %i++){
             %cid = ClientGroup.getObject( %i );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<a:gamelink\tRanksSM\t"@%cid@">"@%cid.namebase@"</a>");
             %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Personal Settings:");
             %index++;
             if($Medals::BossMaster[%client.GUID] $= true) {
                messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tPhantomPage>Phantom Armor Settings</a>');
                %index++;
             }
             else {
                messageClient( %client, 'SetLineHud', "", %tag, %index, "---Section Locked---");
                %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             messageClient( %client, 'ClearHud', "", %tag, %index );
             return;
             
        case "RanksSM":
             messageClient( %client, 'SetScoreHudSubheader', "", ""@%arg2.namebase@"'s Stats Card" );
             %client.SCMPage = "SM";
             //Specs
             %rank = $Rank::Rank[%arg2.GUID];
             %XP = $Rank::XP[%arg2.GUID];
             %sp = $Rank::SP[%arg2.GUID];
             %phrs = $Rank::Phrase[%arg2.GUID];
             if(%sp $="")
             %sp = 0;
             if(%phrs $="")
             %phrs = "I dont Have A Phrase.";
             %arg2.bossKills = 0; //start at 0
             //Card
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Rank: "@%rank@", XP Points: "@%XP@", Ranked "@$Rank::TopPlPosition[%arg2.GUID]@" / "@$Rank::numplayers@".");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Spendable Points: "@%sp@"");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Personal Phrase: "@%phrs@"");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "My Dishonors / Punishments:");
             %index++;
             if($Medals::PublicEnemy[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Public Enemy : Killed 10 Teammates in one match, I guess I though FFA was on.");
             %index++;
             }
             if($Medals::RAAMsPal[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "RAAM's Pal : I got Sliced by General / Lord RAAM 5 Times in one Match.");
             %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "My Medals / Awards:");
             %index++;
             if($Medals::NoMoreNewbie[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "No More Newbie : No Longer a Private.");
             %index++;
             }
             if($Medals::TheFirstK[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "The First K : Get 1,000 Experience Points (XP).");
             %index++;
             }
             if($Medals::HonorsAward1[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Honors Award Class A : Get 10,000 Experience Points (XP).");
             %index++;
             }
             if($Medals::HonorsAward2[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Honors Award Class B : Get 100,000 Experience Points (XP).");
             %index++;
             }
             if($Medals::HonorsAward3[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Honors Award Class C : Get 1,000,000 Experience Points (XP).");
             %index++;
             }
             if($Medals::TheHonorableSoldier[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "The Honorable Soldier : Reach the Commander In Chief Rank.");
             %index++;
             }
             if($Medals::EntryLogger[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Entry Logger : Unlock all normal weapon entries for E.V.A.");
             %index++;
             }
             if($Medals::MathWiz[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Math Wiz : ACE Phantom139's Math quiz.");
             %index++;
             }
             if($Medals::ArmorUnlocker[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Armor Specialist : Unlock all Armor Classes.");
             %index++;
             }
             if($Medals::WeaponsOwner[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Weapons Owner : Unlock all weapons and weapon modes.");
             %index++;
             }
             if($Medals::PistolUnlocker[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Pistol Specialist : Unlock all pistols.");
             %index++;
             }
             if($Medals::DemonSlayer[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Demon Slayer : Kill 50 Demon Zombies in one match.");
             %index++;
             }
             if($Medals::SniperHunter[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Sniper Hunter : Kill 30 Sniper Zombies in one match.");
             %index++;
             }
             if($Medals::BigGameHunter[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Big Game Hunter : Kill 25 Zombie Lords in one match.");
             %index++;
             }
             if($Medals::NoAir4You[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "No Air 4 You: Destroy 15 Ultra Drone Fighters.");
             %index++;
             }
             if($Medals::InTheBlacklist[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "In The List : Have a position in the Blacklist 15.");
             %index++;
             }
             if($Medals::TopOfThePack[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Top Of The Pack : Secure Position 1 in the Blacklist 15.");
             %index++;
             }
             if($Medals::HalfWayThere[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Half Way There: Complete 25 Waves Of Horde.");
             %index++;
             }
             if($Medals::Completionist[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Completionist: Defeat all 50 waves of horde.");
             %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "> > > BOSS MEDALS < < <");
             %index++;
             if($Medals::RAAMKiller[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "RAAM Killer : Defeat General RAAM, the Zombie Army Leader.");
             %arg2.bossKills++;
              %index++;
             }
             if($Medals::DarkraiKiller[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Darkrai Slayer : Defeat Lord Darkrai, Ruler of the Zombie Nations in combat.");
             %arg2.bossKills++;
             %index++;
             }
             if($Medals::LordRaamDestroyer[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Lord Raam Destroyer : Defeat Lord RAAM, and end the zombie war.");
             %arg2.bossKills++;
             %index++;
             }
             if($Medals::StormEnder[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Storm Ender : Defeat Stormrider, the ultra drone leader.");
             %arg2.bossKills++;
             %index++;
             }
             if($Medals::WhosTank[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Who's Tank? : Defeat Lieutenant Alister.");
             %arg2.bossKills++;
             %index++;
             }
             if($Medals::FireExtinguisher[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Fire Extinguisher : Defeat The Evil Ghost Of Fire.");
             %arg2.bossKills++;
             %index++;
             }
             if(%arg2.bossKills > 2 ) {
                awardClient(%arg2,22);
             }
             if(%arg2.bossKills > 5) {
                awardClient(%arg2,23);
             }
             if($Medals::BossHunter[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Boss Hunter : Defeat Three TWM Bosses.");
             %index++;
             }
             if($Medals::BossMaster[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Boss Master : Defeat All Six TWM Bosses.");
             %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "> > > WEAPON MEDALS < < <");
             %index++;
             if($Medals::ShieldBuster[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Shield Buster: Disable General/Lord RAAM's Shield 5 Times.");
             %index++;
             }
             if($Medals::TheAssassin[%arg2.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "The Assassin: Assassinate 5 Players with the shocklance.");
             %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tRanks>Back to P.I.L.</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             return;

        case "SetFlag":
             %flag = %arg2;
             if(%flag $= "PhantHordeComplete") {
                if($Medals::Completionist[%client.GUID]) {
                   messageClient( %client, 'SetLineHud', "", %tag, %index, "Flag Set To: Red Flag (Horde Complete)");
                   %index++;
                }
                else {
                   messageClient( %client, 'SetLineHud', "", %tag, %index, "Nice Try "@%client.namebase@", But Even YOU need to earn the medal.");
                   %index++;
                   echo("SERVER HACK ALERT: "@%client.namebase@", "@%client.getAddress()@" attempted to Hack into a Phantom Flag");
                   %flag = "";
                }
             }
             else if(%flag $= "PhantWeapons") {
                if($Medals::WeaponsOwner[%client.GUID]) {
                   messageClient( %client, 'SetLineHud', "", %tag, %index, "Flag Set To: Blue Flag (Weapons Owner)");
                   %index++;
                }
                else {
                   messageClient( %client, 'SetLineHud', "", %tag, %index, "Nice Try "@%client.namebase@", But Even YOU need to earn the medal.");
                   %index++;
                   %flag = "";
                   echo("SERVER HACK ALERT: "@%client.namebase@", "@%client.getAddress()@" attempted to Hack into a Phantom Flag");
                }
             }
             else if(%flag $= "PhantAllMedals") {
                if($Medals::TopOfThePack[%client.GUID]) {
                   messageClient( %client, 'SetLineHud', "", %tag, %index, "Flag Set To: Gold Flag (Top Player)");
                   %index++;
                }
                else {
                   messageClient( %client, 'SetLineHud', "", %tag, %index, "Nice Try "@%client.namebase@", But Even YOU need to earn the medal.");
                   %index++;
                   %flag = "";
                   echo("SERVER HACK ALERT: "@%client.namebase@", "@%client.getAddress()@" attempted to Hack into a Phantom Flag");
                }
             }
             else {
                messageClient( %client, 'SetLineHud', "", %tag, %index, "Flag Set To: Silver Flag (Default)");
                %index++;
                %flag = "";
             }
             %client.flagType = %flag;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tPhantomPage>Back To Phantom Armor Settings</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             return;

        case "SetArmorSkin":
             %skin = %arg2;
             if(%skin $= "Silver") {
                messageClient( %client, 'SetLineHud', "", %tag, %index, "Armor Skin To: Silver (Default)");
                %index++;
             }
             else if(%skin $= "Red") {
                if($Medals::Completionist[%client.GUID]) {
                   messageClient( %client, 'SetLineHud', "", %tag, %index, "Armor Skin To: Red (Horde Complete)");
                   %index++;
                }
                else {
                   messageClient( %client, 'SetLineHud', "", %tag, %index, "Nice Try "@%client.namebase@", But Even YOU need to earn the medal.");
                   %index++;
                   echo("SERVER HACK ALERT: "@%client.namebase@", "@%client.getAddress()@" attempted to Hack into a Phantom Armor Skin");
                   %skin = "Silver";
                }
             }
             else if(%skin $= "Gold") {
                if($Medals::TopOfThePack[%client.GUID]) {
                   messageClient( %client, 'SetLineHud', "", %tag, %index, "Armor Skin To: Gold (Top Rank)");
                   %index++;
                }
                else {
                   messageClient( %client, 'SetLineHud', "", %tag, %index, "Nice Try "@%client.namebase@", But Even YOU need to earn the medal.");
                   %index++;
                   echo("SERVER HACK ALERT: "@%client.namebase@", "@%client.getAddress()@" attempted to Hack into a Phantom Armor Skin");
                   %skin = "Silver";
                }
             }
             %client.SkinType = %skin;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tPhantomPage>Back To Phantom Armor Settings</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             return;

        case "PhantomPage":
             messageClient( %client, 'SetScoreHudSubheader', "", "Phantom Armor Settings" );
             %client.SCMPage = "SM";
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<font:Arial Bold:18>Select Armor Flag");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "   <a:gamelink\tSetFlag\t0>Silver Flag</a>");
             %index++;
             if($Medals::Completionist[%client.GUID]) {
                messageClient( %client, 'SetLineHud', "", %tag, %index, "   <a:gamelink\tSetFlag\tPhantHordeComplete>Red Flag</a>");
                %index++;
             }
             else {
                messageClient( %client, 'SetLineHud', "", %tag, %index, "   ---Locked---");
                %index++;
             }
             if($Medals::WeaponsOwner[%client.GUID]) {
                messageClient( %client, 'SetLineHud', "", %tag, %index, "   <a:gamelink\tSetFlag\tPhantWeapons>Blue Flag</a>");
                %index++;
             }
             else {
                messageClient( %client, 'SetLineHud', "", %tag, %index, "   ---Locked---");
                %index++;
             }
             if($Medals::TopOfThePack[%client.GUID]) {
                messageClient( %client, 'SetLineHud', "", %tag, %index, "   <a:gamelink\tSetFlag\tPhantAllMedals>Gold Flag</a>");
                %index++;
             }
             else {
                messageClient( %client, 'SetLineHud', "", %tag, %index, "   ---Locked---");
                %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<font:Arial Bold:18>Select Armor Skin");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "   <a:gamelink\tSetArmorSkin\tSilver>Silver Armor</a>");
             %index++;
             if($Medals::Completionist[%client.GUID]) {
                messageClient( %client, 'SetLineHud', "", %tag, %index, "   <a:gamelink\tSetArmorSkin\tRed>Red Armor</a>");
                %index++;
             }
             else {
                messageClient( %client, 'SetLineHud', "", %tag, %index, "   ---Locked---");
                %index++;
             }
             if($Medals::TopOfThePack[%client.GUID]) {
                messageClient( %client, 'SetLineHud', "", %tag, %index, "   <a:gamelink\tSetArmorSkin\tGold>Gold Armor *Biatch*</a>");
                %index++;
             }
             else {
                messageClient( %client, 'SetLineHud', "", %tag, %index, "   ---Locked---");
                %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             return;

        case "BL15":
             messageClient( %client, 'SetScoreHudSubheader', "", "The Blacklist 15" );
             %client.SCMPage = "SM";
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Top 15 Ranks");
             %index++;
             for(%i = 1; %i < 16; %i++) {
                if(%client.namebase $= $Rank::Top[1]) {
                awardClient(%client,27); //Wewt
                }
                if(%client.namebase $= $Rank::Top[%i]) {
                awardClient(%client,26); //Wewt
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<color:33FF00>"@%i@". "@$Rank::Top[%i]@" - "@$Rank::TopRank[%i]@" - "@$Rank::TopXP[%i]@"XP");
                %index++;
                }
                else {
                messageClient( %client, 'SetLineHud', "", %tag, %index, ""@%i@". "@$Rank::Top[%i]@" - "@$Rank::TopRank[%i]@" - "@$Rank::TopXP[%i]@"XP");
                %index++;
                }
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             return;
             
        case "DL15":
             messageClient( %client, 'SetScoreHudSubheader', "", "The Darklist 15" );
             %client.SCMPage = "SM";
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Top 15 Non-Player Ranks");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "1. Lord RAAM - Zombie Supreme Grade III - 10,000,000XP");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "2. Lord Darkrai - Zombie Supreme Grade II - 9,000,000XP");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "3. General Stormforce - Aviator General Grade III - 8,950,000XP");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "4. Stormrider - Aviator General Grade I - 7,750,000XP");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "5. General RAAM - Zombie General Grade IV - 7,500,000XP");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "6. Colonel Windshear - Aviator Brigadier Grade V - 7,000,000XP");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "7. Commander Phantom - Strike Commander Grade V - 6,500,000XP");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "8. Commander Cynthia - Strike Commander Grade III - 5,700,000XP");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "9. Regimine Sniper - Zombie Brigadier Grade I - 5,500,000XP");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "10. Lieutenant Alister - Commander In Chief - 4,900,000XP");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "11. General Valon - Commander In Chief - 3,550,000XP");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "12. Zombie Lord XL45T - Zombie Lieutenant Grade II - 3,400,000XP");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "13. General Raphael - General 5 Stars - 2,900,000XP");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "14. Overlord Twinstar - First Aviator - 1,400,000XP");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "15. General Jacob - General - 600,000XP");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             return;
                                                           
        case "PC":
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Piece Count" );
             %count=clientgroup.getcount();
             %counter=deployables.getcount();
             for (%n=0;%n<%counter;%n++) {
                 %obj = deployables.getObject(%n);
                 %totalPC++;
                 %piececount[%obj.ownerguid]++;
                 if(!%obj.ownerguid)
                 %orphPC++;
                 }
             %count=clientgroup.getcount();
             for (%i = 0; %i < %count; %i++){
                 %cid = ClientGroup.getObject( %i );
                 if(%cid.isAIControlled()) {
                 messageClient( %client, 'SetLineHud', "", $TagToUseForScoreMenu, %index, '<tab:25>\t<clip:195>%1</clip><rmargin:260><just:right>%2',
                 %cid.namebase,'AI' );
                 %index++;
                 }
                 if(!%cid.isAIControlled()) {
                 messageClient( %client, 'SetLineHud', "", $TagToUseForScoreMenu, %index, '<tab:25>\t<clip:195>%1</clip><rmargin:260><just:right>%2',
                 %cid.namebase,%piececount[%cid.guid] );
                 %index++;
                 }
                 }
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Orphanned Pieces : "@%orphPC@"");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Total Pieces Used: "@%totalPC@"");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Pieces Left (Apprx) : "@1080 - %totalPC@"");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             messageClient( %client, 'ClearHud', "", %tag, %index );
             return;

        case "WeaponsInfo":
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Weapons Information - Main Page" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Select a Category");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGuns\t1>Combat Weapons</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tVehs\t1>Vehicles</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tArmor\t1>Armor</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             return;

        case "Vehs":
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Weapons Information - Vehicle Systems" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial Bold:18>=Vehicle=   =Info=");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<color:990099><Font:Arial Bold:16>Fighter Class Vehicles");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "F39 Interceptor - Armed with CG, Missiles, and Bombs.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "F41 Strike Fighter - Armed with Explosive CG, Missiles, and Napalm Bombs.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "F56 Hornet - Armed with Shredder CG, and Sytex Missile Pods, Able to Sustain");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "it's height without moving.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<color:990099><Font:Arial Bold:16>Heavy Air Class Vehicles");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "B-34 Bomber - Bombs Targets, has an underside mountable turret.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "AWACS - Heavy Transport, can refuel and rearm aircraft in mid air.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "AC-290 Gunship - Seige Weapon, armed with heavy weaponry and CGs.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<color:CC6600>AC-130 Gunship - Seige Weapon, Unpilotable, Armed with Degauss Cannons.");
             %index++;
             if($Medals::StormEnder[%client.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Storm Seige Drone - Armed with CG, Missiles, Bombs and a Automated turret.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Unknown Vehicle, Unlock the Storm Ender Medal.");
             %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<color:990099><Font:Arial Bold:16>Helicopter Class Vehicles");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tWeaponsInfo\t1>Back To Category Selection</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             messageClient( %client, 'ClearHud', "", %tag, %index );
         return;

        case "Armor":
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Weapons Information - Armor Systems" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial Bold:18>=Armor=   =Info=");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial Bold:16>Player Armor Classes");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Tech - Building Armor, Uses Tools [3 Tools], 66HP.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Scout - Basic Armor, Uses Light Weaponry [1 Slot], 66HP.");
             %index++;
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[8]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Commando - Medium Armor, Uses Medium Weaponry [2 Slots], 110HP.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Armor Class, Reach Rank 8 ("@$Ranks::MinPoints[8]@"XP) Need: "@($Ranks::MinPoints[8] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[13]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Support - Heavy Armor, Uses Assault Weaponry [3 Slots], 132HP.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Armor Class, Reach Rank 13 ("@$Ranks::MinPoints[13]@"XP) Need: "@($Ranks::MinPoints[13] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[31]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Nalcidic Armor - Flame Armor, has Jump Jets [3 Slots], 150HP.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Armor Class, Reach Rank 31 ("@$Ranks::MinPoints[31]@"XP) Need: "@($Ranks::MinPoints[31] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[32]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Spec Ops - Medium Armor, Uses Special Weaponry [2 Slots], 80HP.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Armor Class, Reach Rank 32 ("@$Ranks::MinPoints[32]@"XP) Need: "@($Ranks::MinPoints[32] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[43]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>RSA Scout - Futuristic Seige Armor, Uses Advanced Weaponry [2 Slots], 280HP.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Armor Class, Reach Rank 43 ("@$Ranks::MinPoints[43]@"XP) Need: "@($Ranks::MinPoints[43] - %stats)@"XP.");
             %index++;
             }
             if($Medals::DarkraiKiller[%client.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Darkrai - Darkrai, Uses Special Weaponry [2 Slots], 250HP.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Special Armor, Get the Darkrai Slayer Medal.");
             %index++;
             }
             if($Medals::LordRaamDestroyer[%client.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>RAAM - RAAM, Uses Heavy Weapons [3 Slots], 300HP.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Special Armor, Get the Lord RAAM Destroyer Medal.");
             %index++;
             }
             if($Medals::BossMaster[%client.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Phantom - A Supreme Armor for a war hero, Uses Many Weapons [3 Slots], 450HP, Hero Flag.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Special Armor, Defeat all TWM Bosses.");
             %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial Bold:16>Zombie Armor Classes.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Zombie - Basic Zombie Armor, 280HP.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Ravenger Zombie - Shark Like Zombie, 100HP.");
             %index++;
             if($Medals::BigGameHunter[%client.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Zombie Lord - Seige Zombie, armed with Infection Gliver, 1800HP.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Zombie Armor, Get the Big Game Hunter Medal.");
             %index++;
             }
             if($Medals::DemonSlayer[%client.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Demon Zombie - Assault Zombie, armed with Firebomb Launcher, 400HP.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Zombie Armor, Get the Demon Slayer Medal.");
             %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Air Rapier Zombie - Flying Zombie, Air-Bombs Ground Units, 100HP.");
             %index++;
             if($Medals::SniperHunter[%client.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Sniper Zombie - Pinpointer Zombie, armed with a Pulse Sniper, 400HP.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Zombie Armor, Get the Sniper Hunter Medal.");
             %index++;
             }
             if($Medals::RAAMKiller[%client.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>General RAAM - Zombie General, Can Summon zombies, Armed with a Modified");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>PCT and a Vengance Sword, Shielded while not doing an attack, 10000HP.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Zombie Armor, Get the RAAM Killer Medal.");
             %index++;
             }
             if($Medals::DarkraiKiller[%client.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Lord Darkrai - Zombie Ruler, Can Summon zombies, inflicts Nightmares, fires a Nightmare Pulse, Can Teleport at any time, 50000HP.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Zombie Armor, Get the Darkrai Slayer Medal.");
             %index++;
             }
             if($Medals::LordRaamDestroyer[%client.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Lord RAAM - Took over for Lord Darkrai when he was defeated in combat, has many different attacks, and he is not shielded this time, 100000HP.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Zombie Armor, Get the Lord RAAM Destroyer Medal.");
             %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tWeaponsInfo\t1>Back To Category Selection</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             messageClient( %client, 'ClearHud', "", %tag, %index );
         return;
             
        case "Guns":
             %client.SCMPage = "SM";
             //XP Check
             %Stats = $Rank::XP[%client.GUID];
             //
             messageClient( %client, 'SetScoreHudSubheader', "", "Weapons Information - Combat Weapons" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial Bold:18>=Weapon/Category=  =Info=");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial Bold:16>Pistols - Light Weapons For Troops");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "---------------");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>USP-45 - Early Combat Weapon, Strong vs. Scouts");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>X-36 Shocklance - Early Combat Weapon, Strong vs. Rear");
             %index++;
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[15]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Centaur Dual Pistols - Pistol Pair, Strong Vs. Groups of Targets");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 15 ("@$Ranks::MinPoints[15]@"XP) Need: "@($Ranks::MinPoints[15] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[35]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Silenced USP-45 - Light Combat Pistol, Strong vs. Scouts, Commandos, SpecOps");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 35 ("@$Ranks::MinPoints[35]@"XP) Need: "@($Ranks::MinPoints[35] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[39]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>ES-73 Pulse Phaser - High Tech Pistol, Strong vs. Scouts, Commandos, SpecOps, Light Vehicles");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 39 ("@$Ranks::MinPoints[39]@"XP) Need: "@($Ranks::MinPoints[39] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[43]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Desert Eagle - Most Powerful Pistol, Strong vs. Any Soldier Class");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 43 ("@$Ranks::MinPoints[43]@"XP) Need: "@($Ranks::MinPoints[43] - %stats)@"XP.");
             %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, "---------------");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial Bold:16>Melee - Go it in nice, painfuly, swiftly, and CLOSE");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "---------------");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Gun Butt - Basic Melee Item, Give em a nice beating, across the face");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Combat Knife - You need to be just a little closer, but it is alot more quick, and painful.");
             %index++;
             if($Medals::RAAMKiller[%client.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Blade of Vengance - Used By RAAM, Easy Kill, and regenerates a little of your health.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Uknown Weapon, Defeat General RAAM.");
             %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, "---------------");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial Bold:16>Combat Weaponry - We Are Armed For War!! (Organized By Needed Rank)");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "---------------");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Krieg Rifle - Basic Rifle, Strong vs. Scouts, SpecOps");
             %index++;
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[4]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>MP12 Sub Machine Gun - Light SMG, Strong vs. Scouts, SpecOps");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 4 ("@$Ranks::MinPoints[4]@"XP) Need: "@($Ranks::MinPoints[4] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[7]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Dual MP12 Uzis - Light SMG Pair, Strong vs. Scouts, Commandos, SpecOps");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 7 ("@$Ranks::MinPoints[7]@"XP) Need: "@($Ranks::MinPoints[7] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[10]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Flame Thrower - Basic Flame Weaponry, Strong at Medium Range, Deadly At Close Range");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 10 ("@$Ranks::MinPoints[10]@"XP) Need: "@($Ranks::MinPoints[10] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[11]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Bazooka - Light Rocket Weaponry, Strong vs. Ground Vehicles");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 11 ("@$Ranks::MinPoints[11]@"XP) Need: "@($Ranks::MinPoints[11] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[12]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Shot Gun - Close Combat Weaponry, Damage Decreases with Increasing Distance");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 12 ("@$Ranks::MinPoints[12]@"XP) Need: "@($Ranks::MinPoints[12] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[17]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Sniper Rifle - Scoped Rifle, Strong vs. Any Soldier Class");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 17 ("@$Ranks::MinPoints[17]@"XP) Need: "@($Ranks::MinPoints[17] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[18]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Anti-Vehicle Missile Launcher - Missile Weaponry, Strong vs. Vehicles");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 18 ("@$Ranks::MinPoints[18]@"XP) Need: "@($Ranks::MinPoints[18] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[23]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>M32 - Medium SMG, Strong vs. Scouts, Commandos, SpecOps");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 23 ("@$Ranks::MinPoints[23]@"XP) Need: "@($Ranks::MinPoints[23] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[25]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>M32 w/ RPG - Medium SMG, Medium Rocket, Strong vs. Any Soldier Class, Light Vehicles");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 25 ("@$Ranks::MinPoints[25]@"XP) Need: "@($Ranks::MinPoints[25] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[28]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Portible Chaingun Turret - Heavy Machine Gun, Strong vs. Any Soldier Class, Aierial Vehicles");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 28 ("@$Ranks::MinPoints[28]@"XP) Need: "@($Ranks::MinPoints[28] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[29]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Rotary Shot Gun - Strong Close Combat Weapon, Damage Decreases with Increasing Distance");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 29 ("@$Ranks::MinPoints[29]@"XP) Need: "@($Ranks::MinPoints[29] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[31]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>ZH7C8 Napalm Cannon - A Very strong Fire Based Weapon, Strong vs. All Armor Classes, Light Vehicles.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 31 ("@$Ranks::MinPoints[31]@"XP) Need: "@($Ranks::MinPoints[31] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[32]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>RX-12 (Shot Gun) - Advanced Rifle, Strong vs. Scouts, Commandos, SpecOps, RSA Scouts, Close Range Targets");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 32 ("@$Ranks::MinPoints[32]@"XP) Need: "@($Ranks::MinPoints[32] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[32]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Portible Gauss Cannon - Advanced Weapon, Strong vs. Everything");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 32 ("@$Ranks::MinPoints[32]@"XP) Need: "@($Ranks::MinPoints[32] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[33]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>RX-12 (RPG) - Advanced Rifle, Strong vs. Any Soldier Class, Light Vehicles");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 33 ("@$Ranks::MinPoints[33]@"XP) Need: "@($Ranks::MinPoints[33] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[34]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Targeting Beacon - Advanced Weapon, Has Multiple Modes Unlocked By Rank, Gives No XP");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 34 ("@$Ranks::MinPoints[34]@"XP) Need: "@($Ranks::MinPoints[34] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[36]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>AT6 Rocket Launcher - Heavy Rocket, Strong vs. Everything, Advanced Targeting Enabled");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 36 ("@$Ranks::MinPoints[36]@"XP) Need: "@($Ranks::MinPoints[36] - %stats)@"XP.");
             %index++;
             }
             if($Medals::FireExtinguisher[%client.GUID] $= true){
                if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[39]) {
                   messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Scorcher - Charged Weapon, The more energy charged, the more flames emitited");
                   %index++;
                }
                else {
                   messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 39 ("@$Ranks::MinPoints[39]@"XP) Need: "@($Ranks::MinPoints[39] - %stats)@"XP.");
                   %index++;
                }
             }
             else {
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Defeat The Ghost Of Fire.");
                %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[40]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Blitz Rifle - Advanced Rifle, Strong vs. All Armor Classes, Fires A Tripple Burst");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 40 ("@$Ranks::MinPoints[40]@"XP) Need: "@($Ranks::MinPoints[40] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[41]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Phantom Spiker - Advanced SMG, Strong vs. All Armor Classes, A Strange Weapon From Unknown Origins");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 41 ("@$Ranks::MinPoints[41]@"XP) Need: "@($Ranks::MinPoints[41] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[42]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>EX-73 Pulse Chaingun - Advanced SMG, Strong vs. All Armor Classes");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 42 ("@$Ranks::MinPoints[42]@"XP) Need: "@($Ranks::MinPoints[42] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[44]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>RTM-85C Photon Laser - Advanced Sniper Weapon, Strong vs. Everything");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 44 ("@$Ranks::MinPoints[44]@"XP) Need: "@($Ranks::MinPoints[44] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[45]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>RSA Laser Rifle - Advanced Rifle, Strong vs. All Soldier Classes");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 45 ("@$Ranks::MinPoints[45]@"XP) Need: "@($Ranks::MinPoints[45] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[46]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Plasma Beam Cannon - Advanced Sniper Weapon, Strong vs. Everything");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 46 ("@$Ranks::MinPoints[46]@"XP) Need: "@($Ranks::MinPoints[46] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[46]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Enemia Rocket Launcher - Heavy Rocket, Strong vs. Everything");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 46 ("@$Ranks::MinPoints[46]@"XP) Need: "@($Ranks::MinPoints[46] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[47]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>ETM-XCC98 Plasma Launcher - Nicknamed The Anti-Nalcidic, this RSA Weapon Seeks Nearby Targets");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 47 ("@$Ranks::MinPoints[47]@"XP) Need: "@($Ranks::MinPoints[47] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[48]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Tesla Voltage Cannon - Strong Electrical Weapon, causes voltage effect.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 48 ("@$Ranks::MinPoints[48]@"XP) Need: "@($Ranks::MinPoints[48] - %stats)@"XP.");
             %index++;
             }
             if ($Rank::XP[%client.GUID] >= $Ranks::MinPoints[49]) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>ALSWP - Rapid fire sniper weapon, Very deadly.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Reach Rank 49 ("@$Ranks::MinPoints[49]@"XP) Need: "@($Ranks::MinPoints[49] - %stats)@"XP.");
             %index++;
             }
             if (%client.isadmin) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial Bold:14>[A]<Font:Arial:14>Super Chaingun - Powerful Machine Gun, Equipped with pulses");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Need Admin Level 1");
             %index++;
             }
             if (%client.issuperadmin) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial Bold:14>[SA]<Font:Arial:14>Bunker Buster - Advanced Mortar Weapon, Arcs a powerful explosive.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Need Admin Level 2");
             %index++;
             }
             if (%client.issuperadmin) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial Bold:14>[SA]<Font:Arial:14>Vaccume Bomb - Disrupts Gravity to one point, and then Unleashes power.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Need Admin Level 2");
             %index++;
             }
             if (%client.issuperadmin) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial Bold:14>[SA]<Font:Arial:14>Meteor Launcher - Unleashes a meteor sized missile that has a similar effect.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Need Admin Level 2");
             %index++;
             }
             if (%client.issuperadmin) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial Bold:14>[SA]<Font:Arial:14>Guided Cruise Missile - Advanced Missile Weapon, Launches a Remote Controlled Cruise Missile.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Need Admin Level 2");
             %index++;
             }
             if (%client.isdev) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial Bold:14>[DEV]<Font:Arial:14>Phantom Railgun - The Most Powerful weapon ever built, Penetrates Anything.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unidentified Weapon, Known to be able to destroy anything in one hit.");
             %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, "---------------");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial Bold:16>Weapons Of The Zombie Horde - Danger Close!!");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "---------------");
             %index++;
             if($Medals::BigGameHunter[%client.GUID] $= true) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Infection Gliver - Used By Zombie Lords, fires two infection pulses.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Kill 25 Zombie Lords.");
             %index++;
             }
             if($Medals::DemonSlayer[%client.GUID] $= true) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>FireBomb Launcher - Used By Demon Zombies, arcs a firebomb.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Kill 50 Demon Zombies.");
             %index++;
             }
             if($Medals::SniperHunter[%client.GUID] $= true) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Pulse Sniper - Used By Sniper Zombies, shoots an energy blast over large distances.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Kill 30 Sniper Zombies.");
             %index++;
             }
             if($Medals::RAAMKiller[%client.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Modified PCT - RAAM's Weapon Of Choice, Fires Spikes instead of bullets.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Defeat General RAAM.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Defeat General RAAM.");
             %index++;
             }
             if($Medals::DarkraiKiller[%client.GUID] $= true){
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Nightmare Pulse - A Dark energy stream that locks people in a nightmare.");
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Unknown Weapon, Defeat Lord Darkrai.");
             %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, "");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tWeaponsInfo\t1>Back To Category Selection</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             messageClient( %client, 'ClearHud', "", %tag, %index );
         return;

        case "F2Help":
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "E.V.A. Help" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Welcome To E.V.A. -Electro Video Assistant-");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "This Menu Provides All information on how to use E.V.A.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Each Primary is accessed via the Main Menu. Select 'EVA' on the");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "top of this menu to go to the main menu, the Close option is also");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "accessed from this top header bar.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Sections are menus within a Primary. Sections with [*] are not");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "complete, broken, or cannot be accessed by your user at the time,");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "they will mostly link you back to the Main Menu.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             messageClient( %client, 'ClearHud', "", %tag, %index );
             return;
         
        case "HelpDesk":
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Help Center" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Select which topic of command you want info on.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tPlayerCMDHelp\t1>Player Commands</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tObjectCMDHelp\t1>Object Commands</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tRankingCMDHelp\t1>Ranking Commands</a>');
             %index++;
             if(%client.isadmin) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tAdminCMDHelp\t1>Admin Commands</a>');
             %index++;
             }
             else {
             messageClient( %client, 'SetLineHud', "", %tag, %index, "The screen shows, 'Need Level 1 Administration Access'");
             %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tServerCent\t1>Back to server center</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             return;

        case "AdminCMDHelp":
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Level 1 Admin Commands" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/summon [name] - sends a player to your location");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/goto [name] - teleport to another player");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/murder [name] - it simply kills a player.. thats it");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/shred [name] - stuffs a player down the person shreder");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/boom [name] - blows a player into tiny pieces");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/remove [name] - deletes the deployables of a player");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/giveorphans [name] - gives all orphaned deployables to a player");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/savebuilding [radius] [name] - saves a building file, .cs tag not needed");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/loadbuilding [name] - loads a building file, .cs tag not needed");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/invinc - makes an object invincible to all damage");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/stalk [name] - be evil and creepy by stalking a player");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/stopstalk - end your stalky ways");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<a:gamelink\tgiveguninfo\t1>/givegun</a> [name] [weapon code] - Give a weapon to a player ");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/twoteams [*] - add/remove a second team");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/myname [name] - change your clients name");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/setname [name] [new name] - change another players name");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/cancelvote - cancel a vote if one is in progress");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/achat [message] - send a message that only admins can view");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/moveme [X] [Y] [Z] - move your player any direction");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/moveto [X] [Y] [Z] - move your player to any position");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/getpos - get your players current position");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tHelpDesk\t1>Back to help center</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tServerCent\t1>Back to server center</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             return;

        case "giveguninfo":
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Weapon Codes for /givegun" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "M32 - M32 SMG");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Sniper - Sniper Rifle");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Bazooka - Bazooka");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "PCT - Portible Chaingun Turret");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "FT - Flamethrower (No Pack Needed)");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "VD - Vehicle Destroyer Rocket Launcher");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Krieg - Krieg Rifle");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Napalm - Napalm Cannon");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Shotgun - Shotgun");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "RSGun - Rotary Quad Barreled Shotgun");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "AT6 - Anti-Personal Hornet Launcher");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "M32R - M32 SMG with RPG Attachment");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "MP12 - MP12 Light Combat SMG");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "PBC - Plasma Beam Cannon");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "RXSG - RX-12 Rifle with Shotgun Attachment");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "RXGL - RX-12 Rifle with RPG Attachment");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "PLaser - Photon Laser Cannon");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "TBeac - Targeting Beacon");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "PCGun - Pulse Chaingun");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Laser - RSA Combat Laser Rifle");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "enemia - Enemia Heavy Bazooka");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Vlt - Tesla Voltage cannon");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "BR - Tri-Shotted Combat Blitz Rifle");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "spike - Phantom Spiker");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "PGC - Portible Gauss Cannon");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "ALSWP - ALSWP Rapid Sniper Rifle");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "USP - USP-45 Basic Combat Pistol");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "SUSP - USP-45 with Silencer Attachment");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "DEagle - Desert Eagle Pistol");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "PPhaser - Pulse Phaser");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "SL - Shocklance");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tAdminCMDHelp\t1>Back to admin commands</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tHelpDesk\t1>Back to help center</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tServerCent\t1>Back to server center</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             return;
             
        case "PlayerCMDHelp":
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Player Based Commands" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/bf - gives you your current selected loadout, wont work with pure off");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/music [track] - plays any T2 Music of your choice");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/hackhelp, /hack [code] - Hack enemy teleport pads for your use");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/listspawns, /choosespawn [number] - Select your spawnpoint");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/pm [name] [message] - Send private messages to other clients");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/power [number] - Set your current power frequency");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/hover - create a hoverpad to stay airborne, useful for deploying");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/viewzkill - display information on zombies you kill");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/me - /me5 [message] - Displays an action message");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/r [message] - use radio chat");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/myphrase [message] - sets your personal phrase");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/time - Use this to display the current time");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tHelpDesk\t1>Back to help center</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tServerCent\t1>Back to server center</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             return;

        case "RankingCMDHelp":
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Rank Based Commands" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/checkstats [name] - View the stats of players, leave blank to see your stats");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/top5 - check the top 5 ranked players in this server");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/top10 - check the top 10 ranked players in this server");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/createsquad [name] - Creates a squad");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/join [Squad name] - Join a squad");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/leavesquad - leave the squad you are in");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/invite [name] - invite a player to join your squad");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/S - view squad information for every client in the server");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/ListSquads - lists all of the squads availible");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/RequestInvite [Squad name] - Sends a recruitment message to a squad leader");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/O [Order] [Squad Name] - Issue orders to a squad");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/Force [Order] [Squad Name] [Player] - Force a player to join or leave a squad");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/SOL - Sets it so you spawn by your squad leader");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/Ranks [number] - view information on a certian rank");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/Training [topic] - learn about TWM, and its ranking system");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tHelpDesk\t1>Back to help center</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tServerCent\t1>Back to server center</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             return;

        case "ObjectCMDHelp":
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Object Based Commands" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/opendoor [password] - Opens a NORMAL or a TOGGLE door");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/setdoorpass [password] - sets a password on NORMAL and TOGGLE doors");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/name [name] - sets the name tags on objects");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/radius [number] - sets the switching radius of SWITCHES and TRIPWIRES");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/delmypieces - deletes all of your deployed objects");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/scale [X] [Y] [Z] - sets the scale of deployed objects");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/objmove [X] [Y] [Z] - moves any deployed object");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/del - deletes objects that belong to you");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/givepieces [name] - Gives your pieces to another client");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, "/getsize - gets the size of an object");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tHelpDesk\t1>Back to help center</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tServerCent\t1>Back to server center</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             return;
             
        case "forcekill":
        messageall('MsgAdminForce', "\c3"@%client.namebase@" used the force and killed "@%arg2.namebase@".");
        KillClientByType(%arg2,1);
        closescorehudfserv(%client);
        return;
        
        case "forcelightningkill":
        messageall('MsgAdminForce', "\c3"@%client.namebase@" used force lightning on "@%arg2.namebase@".");
        KillClientByType(%arg2,4);
        closescorehudfserv(%client);
        return;
        
        case "forceChoke":
           if(%arg2.beingChoked == 0) {
           %arg2.beingChoked = 1;
           %arg2.chokecnt = 1;
           %client.cantChoke = 1;
           ForceChokeLoop(%client, %arg2);
           messageall('MsgAdminForce', "\c3"@%client.namebase@" is using the force to choke "@%arg2.namebase@".");
           closescorehudfserv(%client);
           }
           else {
           %arg2.beingChoked = 0;
           %arg2.chokecnt = 1;
           %client.cantChoke = 0;
           messageall('MsgAdminForce', "\c3"@%client.namebase@" released his choke on "@%arg2.namebase@".");
           closescorehudfserv(%client);
           }
        return;

        case "force":
             if(!%client.issuperadmin) {
             commandToClient( %client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>You cannot use the force my friend...<spop>", 5, 2);
             closescorehudfserv(%client);
             return;
             }
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "The Force" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Select a force power.");
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tforcekillMenu\t1>Force Kill</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tforcechokeMenu\t1>Force Choke</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tforceStormMenu\t1>Force Lightning</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             messageClient( %client, 'ClearHud', "", %tag, %index );
             return;

        case "forcechokeMenu":
             if(!%client.issuperadmin) {
             commandToClient( %client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>You cannot use the force my friend...<spop>", 5, 2);
             closescorehudfserv(%client);
             return;
             }
             if(%client.cantChoke == 1) {
             commandToClient( %client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>You cannot choke multiple players<spop>", 5, 2);
             closescorehudfserv(%client);
             return;
             }
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Force Choke" );
             %count=clientgroup.getcount();
             for (%i = 0; %i < %count; %i++){
             %cid = ClientGroup.getObject( %i );
                if(%cid != %client) {
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<a:gamelink\tforceChoke\t"@%cid@">Use the force on "@%cid.namebase@"</a>");
                %index++;
                }
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tforce\t1>Choose A Different Power</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             messageClient( %client, 'ClearHud', "", %tag, %index );
             return;

        case "forceStormMenu":
             if(!%client.issuperadmin) {
             commandToClient( %client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>You cannot use the force my friend...<spop>", 5, 2);
             closescorehudfserv(%client);
             return;
             }
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Force Lightning" );
             %count=clientgroup.getcount();
             for (%i = 0; %i < %count; %i++){
             %cid = ClientGroup.getObject( %i );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<a:gamelink\tforcelightningkill\t"@%cid@">Use the force on "@%cid.namebase@"</a>");
             %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tforce\t1>Choose A Different Power</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             messageClient( %client, 'ClearHud', "", %tag, %index );
             return;

        case "forcekillMenu":
             if(!%client.issuperadmin) {
             commandToClient( %client, 'BottomPrint', "<spush><font:Tempus Sans ITC:22><color:ff3300>You cannot use the force my friend...<spop>", 5, 2);
             closescorehudfserv(%client);
             return;
             }
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Force Kill" );
             %count=clientgroup.getcount();
             for (%i = 0; %i < %count; %i++){
             %cid = ClientGroup.getObject( %i );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<a:gamelink\tforcekill\t"@%cid@">Use the force on "@%cid.namebase@"</a>");
             %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tforce\t1>Choose A Different Power</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             messageClient( %client, 'ClearHud', "", %tag, %index );
             return;

        case "ServerCent":
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Server Center" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "Select An Option");
             %index++;
             //FUN STUFF
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tforce\t1>Use The Force</a>');
             %index++;
             //END
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tHelpDesk\t1>Help Center</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tF2Help\t1>E.V.A. Help</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tCustomizeBot\t1>Customize Bots [SA]</a>');
             %index++;
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             messageClient( %client, 'ClearHud', "", %tag, %index );
             return;
             
        // BOT CUSTOMIZER
        // Ported from Pcon 2.2
        case "CustomizeBot":
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Customize A Bot" );
             if(!%client.isSuperAdmin) {
             messageClient( %client, 'SetLineHud', "", %tag, %index, 'Not SA, <a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Select A Bot");
             %index++;
             %count=clientgroup.getcount();
             for (%i = 0; %i < %count; %i++){
             %cid = ClientGroup.getObject( %i );
                if(%cid.isAIControlled()) {
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep2\t"@%cid@">"@%cid.namebase@"</a>");
                %index++;
                }
             }
             messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
             %index++;
             messageClient( %client, 'ClearHud', "", %tag, %index );
             return;

        case "Customizep2":
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Customize A Bot" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Select A Race");
             %index++;
             %client.bottarget = %arg2;
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep3\tHuman>Human</a>");
                %index++;
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep3\tBioderm>Bioderm</a>");
                %index++;
                messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
                %index++;
            return;

        case "Customizep3":
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Customize A Bot" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Select A Gender");
             %index++;
             %client.setrace = %arg2;
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep4\tMale>Male</a>");
                %index++;
                if(%client.setrace $= "Human") {
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep4\tFemale>Female</a>");
                %index++;
                }
                messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
                %index++;
            return;

        case "Customizep4":
             %client.SCMPage = "SM";
             messageClient( %client, 'SetScoreHudSubheader', "", "Customize A Bot" );
             messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Select A Voice");
             %index++;
             %client.setgender = %arg2;
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep5\tBot1>Bot</a>");
                %index++;
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep5\tDerm1>Bioderm Warrior</a>");
                %index++;
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep5\tDerm2>Bioderm Monster</a>");
                %index++;
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep5\tDerm3>Bioderm Predator</a>");
                %index++;
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep5\tMale1>Hero</a>");
                %index++;
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep5\tMale2>Iceman</a>");
                %index++;
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep5\tMale3>Rouge</a>");
                %index++;
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep5\tMale4>Hardcase</a>");
                %index++;
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep5\tMale5>Psycho</a>");
                %index++;
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep5\tFem1>Heroine</a>");
                %index++;
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep5\tFem2>Professional</a>");
                %index++;
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep5\tFem3>Cadet</a>");
                %index++;
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep5\tFem4>Veteran</a>");
                %index++;
                messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep5\tFem5>Amazon</a>");
                %index++;
                messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t1>Back to main menu</a>');
                %index++;
            return;

        case "Customizep5":
        %client.SCMPage = "SM";
        %client.bottarget.voice = %arg2;
        %client.bottarget.voiceTag = addTaggedString(%arg2);
        messageClient( %client, 'SetScoreHudSubheader', "", "Customize A Bot" );
        messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14>Select A Skin");
        %index++;
        messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep6\tBEagle>Blood Eagle</a>");
        %index++;
        messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep6\tCOTP>Inferno</a>");
        %index++;
        messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep6\tDSword>Diamond Sword</a>");
        %index++;
        messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep6\tSwolf>Starwolf</a>");
        %index++;
        messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep6\tBaseB>Base Skin 1</a>");
        %index++;
        messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep6\tBase>Base Skin 2</a>");
        %index++;
        if(%client.setgender $= "Male" && %client.setrace !$= "Bioderm") {
        messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep6\tbasebbot>Bot Skin 1</a>");
        %index++;
        messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep6\tbasebot>Bot Skin 2</a>");
        %index++;
        }
        else if(%client.setgender $= "Female") {
        messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep6\tTR2-1>Female Skin 1</a>");
        %index++;
        messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep6\tTR2-2>Female Skin 2</a>");
        %index++;
        }
        else if(%client.setrace $= "Bioderm") {
        messageClient( %client, 'SetLineHud', "", %tag, %index, "<Font:Arial:14><a:gamelink\tCustomizep6\thorde>Horde Skin</a>");
        %index++;
        }
        return;

        case "Customizep6":
        setTargetRace(%client.bottarget.target, %client.setrace);
        SetSkin(%client.bottarget,%arg2);
        customizebot(%client.bottarget,%client.setrace,%client.setgender,%client.bottarget.name,%arg2,%client.bottarget.voiceTag,%client.bottarget.voicepitch);
        closescorehudfserv(%client);
        return;
             
             
             
             
             
             
        //-------------
             
        default:
        }
        closeScoreHudFSERV(%client);
}

//Skin & bot set
function SetSkin(%client,%newskin) {
if (!IsObject(%client))
return "Invalid client!";

FreeClientTarget(%client);
%client.skin = addtaggedstring(%newskin);
%client.target = allocClientTarget(%client, %client.name, %client.skin, %client.voiceTag, '_ClientConnection', %client.team, 0, %client.voicePitch);

if (IsObject(%client.player))
%client.player.setTarget(%client.target);

return %client SPC %newskin;
}

function customizebot(%bot,%race,%sex,%name,%skin,%voicetag,%pitch)
{
    %bot.race = %race;
    %bot.sex = %sex;
    %bot.voice = addtaggedstring(%voicetag);
    freeclienttarget(%bot);
   %bot.target = allocClientTarget(%bot, %bot.name, %bot.skin, %bot.voiceTag, '_ClientConnection', 0, 0, %bot.voicePitch);
}
//End

function closeScoreHudFSERV(%client) {
serverCmdHideHud(%client, 'scoreScreen');
//ResetQuiz(%client, $TagToUseForScoreMenu, "ALL", 1);
commandToClient(%client, 'setHudMode', 'Standard', "", 0);
%client.SCMPage = 1;
}

function scoreCmdMainMenu(%game,%client,%tag,%page) {
messageClient( %client, 'ClearHud', "", %tag, 1 );
if (!isobject(cmdobject)) generateCMDObj();
   messageClient( %client, 'SetScoreHudSubheader', "", "Main Menu Page " @ %page);
if (%page > 1) {
   %pgToGo = %page - 1;
   messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t%1>Previous Page</a>',%pgToGo);
   %index++;
   }
%cmdsToDisp = 15 * %page;
%start = (%page - 1) * 15;
for (%i=%start; %i < %cmdsToDisp;%i++) {
    %line = CmdObject.cmd[%i];
    if (%line !$= "") {
       messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\t%1>%2</a>',getword(%line,0),getwords(%line,1));
       %index++;
    }
}
if (%cmdsToDisp < (CmdObject.commands + 1)) {
   %pgToGo = %page + 1;
   messageClient( %client, 'SetLineHud', "", %tag, %index, '<a:gamelink\tGTP\t%1>Next Page</a>',%pgToGo);
   %index++;
   }
if (%page > 1) {
   messageClient( %client, 'SetLineHud', "", %tag, %index, "<a:gamelink\tGTP\t1>First Page</a>");
   %index++;
   }
messageClient( %client, 'ClearHud', "", %tag, %index );
}


//format
//CMD indentifier displayname
//CMDHELP identifier help message for cmd gonna implement it
//after noobs get their hands on the base script first

function GenerateCMDObj() {
new fileobject("fIn");
fIn.openforread("scripts/modded/cmddisplaylist.txt");
if (isobject(cmdobject)) cmdobject.delete();
   new scriptObject("CmdObject") {commands=0;};
while (!fIn.iseof()) {
      %line = fIn.readline();
      if (getword(%line,0) $= "CMD") {
         CmdObject.cmd[CmdObject.commands] = getwords(%line,1);
         CmdObject.commands++;
      }
}

fIn.close();
fIn.delete();
}

// CONTENT SAVING
function CheckSlotStatus(%cl,%slot) {
   if($SaveFile::Save[%cl.guid,%slot] $= "") {
      %Stat = "This Slot Is Empty";
   }
   else {
      %Stat = "This Slot Has "@$SaveFile::PieceCT[%cl.guid,%slot]@" Saved Pieces";
   }
   return %Stat;
}

//Checks to see if the file CAN, or Should be loaded
function RunLoadCheck(%cl, %slot, %PC) {
   if(%cl.cantLoad || $SaveFile::PieceCT[%client.guid,%slot] > %PC) {
   %str = "<color:FF0000><a:gamelink\tLoad\t"@%slot@">Load</a>"; //Return the Red Link
   return %str;
   }
   else {
   %str = "<color:33FF00><a:gamelink\tLoad\t"@%slot@">Load</a>"; //Return the Green Link
   return %str;
   }
}

function RunSaveCheck(%cl, %slot) {
   if(%cl.cantSave) {
   %str = "<color:FF0000><a:gamelink\tSaveWarn\t"@%slot@">Save</a>"; //Return the Red Link
   return %str;
   }
   else if($SaveFile::Save[%cl.guid,%slot] $= "" && !%cl.cantSave && $Phantom::CSSEnabled) {
   %str = "<color:33FF00><a:gamelink\tSaveWarn\t"@%slot@">Save</a>"; //Return the Green Link
   return %str;
   }
   else {
   %str = "<color:FFFF66><a:gamelink\tSaveWarn\t"@%slot@">Save</a>"; //Return the Yellow Link
   return %str;
   }
}

function RunDeleteCheck(%cl, %slot) {
   if($SaveFile::Save[%cl.guid,%slot] $= "") {
   %str = "<color:FF0000><a:gamelink\tDeleteWarn\t"@%slot@">Delete</a>"; //Return the Red Link
   return %str;
   }
   else {
   %str = "<color:FFFF66><a:gamelink\tDeleteWarn\t"@%slot@">Delete</a>"; //Return the Yellow Link
   return %str;
   }
}
