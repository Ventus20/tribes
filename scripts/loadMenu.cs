//-------------------------------------------
// Mod information load screen - ZOD. z0ddm0d
// and Modified later by the T2CC
//-------------------------------------------

package loadmodinfo
{

   function GetTipMessage() {
   %r = getRandom(1,28);
   switch(%r) {
      case 1:
      %tip = "The Dual Weapons Come with great advantage.. Twice the Bullet Load.";
      case 2:
      %tip = "Check your ammo! People with limited ammo on their primary weapons are more likely to be killed";
      case 3:
      %tip = "Use /help to view commands. /Checkstats to view your Stats, and the [F2] Menu to check other info";
      case 4:
      %tip = "To level up, Kill enemies and zombies. Killing teammates holds a harsh penalty! Use /checkstats to see your info";
      case 5:
      %tip = "The easiest way to deal with a zombie lord is to deliver a head shot with a sniper rifle. or use the Desert Eagle";
      case 6:
      %tip = "To check what weapons you can use. Open up your [F2] Menu and select weapons information";
      case 7:
      %tip = "Beware Sniper Zombies! They are quick, decisive, and are armed with a pulse sniper rifle";
      case 8:
      %tip = "Prioritize your tasks! Focus on the greatest threats to you first";
      case 9:
      %tip = "Stormrider has seeker plasmas, throw flare grenades if you see these coming at you";
      case 10:
      %tip = "What weapons will work best for you? check out the Weapons information in your [F2] Menu";
      case 11:
      %tip = "Nalcidics Beware, there is a new weapon known as the photon launcher which will end your flying";
      case 12:
      %tip = "set up your personal phrase today! use /myphrase to set your phrase";
      case 13:
      %tip = "Ultra Drones, Killers of the SKY. To kill them, stay out of the sky, hit them with SAM's";
      case 14:
      %tip = "The Tank turret can fire a multitude of weapons. Press jet for a CG, on the main cannon, use your mine key to switch cannons";
      case 15:
      %tip = "Infected? use your health kit, it comes preloaded with an infection cure";
      case 16:
      %tip = "XP Points are earned differently by killing players. Once their XP is greater than 2000, you will earn more";
      case 17:
      %tip = "When do I get a certian weapon? use the /ranks command and the [F2] Menu to find that out";
      case 18:
      %tip = "Tanks assaulting you too often? use the Portible Guass Cannon to make short work of them";
      case 19:
      %tip = "To view the Current time, use /time.";
      case 20:
      %tip = "Portible Chaingun Turrets can be deployed into stationary turrets by pressing Your Jet Key, When in Stationary mode, you have unlimited ammo, but you cannot move.";
      case 21:
      %tip = "Zombie General RAAM giving you troubles? To defeat him, stay at a distance and use powerful weapons ONLY when his shield is down.";
      case 22:
      %tip = "Zombie Leader Darkrai giving you troubles? To defeat him, DO NOT GO NEAR HIM, Avoid the pulses of energy and his abilities, use any weapons availible.";
      case 23:
      %tip = "Fighting Lord RAAM? Avoid his Static Discharge Power, he has more abilities this time, and he is stronger, you may need a tank.. or More.";
      case 24:
      %tip = "Know your Colors! Red - Enemy Player, Green - Ally Player, Purple - Enemy Zombie, Yellow - Ally Zombie, White - Observer";
      case 25:
      %tip = "Want a quick kill? the shocklance is availible for all armors at any rank and is nasty deadly from behind";
      case 26:
      %tip = "Drone Boss Stormlord Giving you Pain? Focus on one target, do not let it leave your sights, oh and avoid the chaingun bullets, AND ZE MISSILES";
      case 27:
      %tip = "Are the RAAM's Shields annoying You? Do You have a Photon Laser? Great News, The Photon Laser Can Burst That Little Bubble of a shield";
      case 28:
      %tip = "The ghost of fire holds an oppresive attack known as FlameCano which is almost unavoidable, beware.";
      }
      return %tip;
   }

   function sendLoadInfoToClient( %client ) {
	Parent::sendLoadInfoToClient(%client);
	schedule(1000, 0, "sendLoadscreen", %client);
   }

   function sendLoadscreen(%client){
	messageClient( %client, 'MsgGameOver', "");
    messageClient( %client, 'MsgClearDebrief', "" );

    messageClient(%client, 'MsgDebriefResult', "", "<Font:Arial Bold:18><Just:CENTER>"@$Host::GameName);
    messageClient(%client, 'MsgDebriefResult', "", "<Font:Arial Bold:14><Just:CENTER>Total Warfare Mod: Version "@$TWM::Version@"");

    %Credits = "\n<Font:Arial:16>TWM Developer: Phantom139, aka: [ShadowForce]" @
               "\n<Font:Arial:14>TWM Co-Devs: DarknessOfLight, Dark Dragon DX, Deadsoldier"@
               "\n<Font:Arial:14>Thanks: Thyth, -Linker-, Cons Mod Devs"@
               "\n";

    // this callback adds content to the bulk of the gui
    messageClient(%client, 'MsgDebriefAddLine', "", %Credits);
    
    %MoreCredits = "\n<Font:Arial:16>CCM Developer: Dondelium_X" @
               "\n<Font:Arial:14>CCM Co-Devs: FalconBlade, Ur_A_Dum"@
               "\n";

    messageClient(%client, 'MsgDebriefAddLine', "", %MoreCredits);

    %TopRanks = "\n<Font:Arial:14>Top 5 Ranks" @
               "\n<Font:Arial:12>First: "@$Rank::Top[1]@", "@$Rank::TopRank[1]@" ,"@$Rank::TopXP[1]@"XP"@
               "\nSecond: "@$Rank::Top[2]@", "@$Rank::TopRank[2]@" ,"@$Rank::TopXP[2]@"XP"@
               "\nThird: "@$Rank::Top[3]@", "@$Rank::TopRank[3]@" ,"@$Rank::TopXP[3]@"XP";

    messageClient(%client, 'MsgDebriefAddLine', "", %TopRanks);
    //It cuts off sometimes, so this prevents that from happening
    %TopRanks2 = "<Font:Arial:12>Fourth: "@$Rank::Top[4]@", "@$Rank::TopRank[4]@" ,"@$Rank::TopXP[4]@"XP"@
                 "\nFifth: "@$Rank::Top[5]@", "@$Rank::TopRank[5]@" ,"@$Rank::TopXP[5]@"XP"@
                 "\n";

    messageClient(%client, 'MsgDebriefAddLine', "", %TopRanks2);
    
    %tip = GetTipMessage();
    %tipMsg = "\n<Font:Arial:14>Heres a tip for you:" @
               "\n<Font:Arial:12>"@%tip@"."@
               "\n";
    messageClient(%client, 'MsgDebriefAddLine', "", %tipMsg);
    
    %MOTDMsg = "\n<Font:Arial:14>Message Of The Day:" @
               "\n<Font:Arial:12>"@$Server::MOTD@"."@
               "\n\n\n";
    messageClient(%client, 'MsgDebriefAddLine', "", %MOTDMsg);
    
    %TC = "\n<just:Center><Font:Arial:14>TWM proudly supports:" @
               "\n<bitmap:TC_logo1>"@
               "\n";
    messageClient(%client, 'MsgDebriefAddLine', "", %TC);

   }
};

activatepackage(loadmodinfo);
