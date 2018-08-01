

/////////////////////////////////////////////////////////////////////////////////////////////////
// %1 = Victim's name                                                                          //
// %2 = Victim's gender (value will be either "him" or "her")                                  //
// %3 = Victim's possessive gender	(value will be either "his" or "her")                      //
// %4 = Killer's name                                                                          //
// %5 = Killer's gender (value will be either "him" or "her")                                  //
// %6 = Killer's possessive gender (value will be either "his" or "her")                       //
// %7 = implement that killed the victim (value is the object number of the bullet, disc, etc) //
/////////////////////////////////////////////////////////////////////////////////////////////////

$DeathMessageCampingCount = 1;
$DeathMessageCamping[0] = '\c0%1 was killed for camping near the Nexus.';

 //Out of Bounds deaths
$DeathMessageOOBCount = 1;
$DeathMessageOOB[0] = '\c0%1 was killed for loitering outside the mission area.';

$DeathMessageLavaCount = 4;
$DeathMessageLava[0] = '\c0%1\'s last thought before falling into the lava : \'Oops\'.';
$DeathMessageLava[1] = '\c0%1 makes the supreme sacrifice to the lava gods.';
$DeathMessageLava[2] = '\c0%1 looks surprised by the lava - but only briefly.';
$DeathMessageLava[3] = '\c0%1 wimps out by jumping into the lava and trying to make it look like an accident.';

$DeathMessageLightningCount = 3;
$DeathMessageLightning[0] = '\c0%1 was killed by lightning!';
$DeathMessageLightning[1] = '\c0%1 caught a lightning bolt!';
$DeathMessageLightning[2] = '\c0%1 stuck %3 finger in Mother Nature\'s light socket.';

//these used when a player presses ctrl-k
$DeathMessageSuicideCount = 5;
$DeathMessageSuicide[0] = '\c0%1 blows %3 own head off!';
$DeathMessageSuicide[1] = '\c0%1 ends it all. Cue violin music.';
$DeathMessageSuicide[2] = '\c0%1 kills %2self.';
$DeathMessageSuicide[3] = '\c0%1 goes for the quick and dirty respawn.';
$DeathMessageSuicide[4] = '\c0%1 took the red pill.';

$DeathMessageVehPadCount = 1;
$DeathMessageVehPad[0] = '\c0%1 got caught in a vehicle\'s spawn field.';

$DeathMessageFFPowerupCount = 3;
$DeathMessageFFPowerup[0] = '\c0%1 got caught up in a forcefield during power up.';
$DeathMessageFFPowerup[1] = '\c0%1 finds %2self in a forcefield powering up.';
$DeathMessageFFPowerup[2] = '\c0%1 gets %2self fried in a forcefield.';

$DeathMessageRogueMineCount = 1;
$DeathMessageRogueMine[$DamageType::Mine, 0] = '\c0%1 is all mine.';

//these used when a player kills himself (other than by using ctrl - k)
$DeathMessageSelfKillCount = 5;
$DeathMessageSelfKill[$DamageType::Blaster, 0] = '\c0%1 kills %2self with a blaster.';
$DeathMessageSelfKill[$DamageType::Blaster, 1] = '\c0%1 makes a note to watch out for blaster ricochets.';
$DeathMessageSelfKill[$DamageType::Blaster, 2] = '\c0%1\'s blaster kills its hapless owner.';
$DeathMessageSelfKill[$DamageType::Blaster, 3] = '\c0%1 deftly guns %2self down with %3 own blaster.';
$DeathMessageSelfKill[$DamageType::Blaster, 4] = '\c0%1 has a fatal encounter with %3 own blaster.';

$DeathMessageSelfKill[$DamageType::Plasma, 0] = '\c0%1 kills %2self with fire.';
$DeathMessageSelfKill[$DamageType::Plasma, 1] = '\c0%1, please, dont be so close to your target while shooting flames.';
$DeathMessageSelfKill[$DamageType::Plasma, 2] = '\c0%1 now knows what it feels like to BURN.';
$DeathMessageSelfKill[$DamageType::Plasma, 3] = '\c0%1 got burned... by %2self.';
$DeathMessageSelfKill[$DamageType::Plasma, 4] = '\c0%1 experiences the joy of cooking %2self.';

$DeathMessageSelfKill[$DamageType::Disc, 0] = '\c0%1 kills %2self with a disc.';
$DeathMessageSelfKill[$DamageType::Disc, 1] = '\c0%1 catches %3 own spinfusor disc.';
$DeathMessageSelfKill[$DamageType::Disc, 2] = '\c0%1 heroically falls on %3 own disc.';
$DeathMessageSelfKill[$DamageType::Disc, 3] = '\c0%1 helpfully jumps into %3 own disc\'s explosion.';
$DeathMessageSelfKill[$DamageType::Disc, 4] = '\c0%1 plays Russian roulette with %3 spinfusor.';

$DeathMessageSelfKill[$DamageType::Grenade, 0] = '\c0%1 destroys %2self with a grenade!';   //applies to hand grenades *and* grenade launcher grenades
$DeathMessageSelfKill[$DamageType::Grenade, 1] = '\c0%1 took a bad bounce from %3 own grenade!';
$DeathMessageSelfKill[$DamageType::Grenade, 2] = '\c0%1 pulled the pin a shade early.';
$DeathMessageSelfKill[$DamageType::Grenade, 3] = '\c0%1\'s own grenade turns on %2.';
$DeathMessageSelfKill[$DamageType::Grenade, 4] = '\c0%1 blows %2self up real good.';

$DeathMessageSelfKill[$DamageType::Mortar, 0] = '\c0%1 kills %2self with a mortar!';
$DeathMessageSelfKill[$DamageType::Mortar, 1] = '\c0%1 hugs %3 own big green boomie.';
$DeathMessageSelfKill[$DamageType::Mortar, 2] = '\c0%1 mortars %2self all over the map.';
$DeathMessageSelfKill[$DamageType::Mortar, 3] = '\c0%1 experiences %3 mortar\'s payload up close.';
$DeathMessageSelfKill[$DamageType::Mortar, 4] = '\c0%1 suffered the wrath of %3 own mortar.';

$DeathMessageSelfKill[$DamageType::Missile, 0] = '\c0%1 kills %2self with a missile!';
$DeathMessageSelfKill[$DamageType::Missile, 1] = '\c0%1 runs a missile up %3 own tailpipe.';
$DeathMessageSelfKill[$DamageType::Missile, 2] = '\c0%1 tests the missile\'s shaped charge on %2self.';
$DeathMessageSelfKill[$DamageType::Missile, 3] = '\c0%1 achieved missile lock on %2self.';
$DeathMessageSelfKill[$DamageType::Missile, 4] = '\c0%1 gracefully smoked %2self with a missile!';

$DeathMessageSelfKill[$DamageType::Mine, 0] = '\c0%1 kills %2self with a mine!';
$DeathMessageSelfKill[$DamageType::Mine, 1] = '\c0%1\'s mine violently reminds %2 of its existence.';
$DeathMessageSelfKill[$DamageType::Mine, 2] = '\c0%1 plants a decisive foot on %3 own mine!';
$DeathMessageSelfKill[$DamageType::Mine, 3] = '\c0One small step for %1, and one giant mine suicide for %2self.';
$DeathMessageSelfKill[$DamageType::Mine, 4] = '\c0%1 this isnt BF2, your own mines do kill you.';

$DeathMessageSelfKill[$DamageType::StMine, 0] = '\c0%1 kills %2self with a static mine!';
$DeathMessageSelfKill[$DamageType::StMine, 1] = '\c0%1\'s mine statically reminds %2 of its existence.';
$DeathMessageSelfKill[$DamageType::StMine, 2] = '\c0%1 instantly electrocutes from %3 mine!';
$DeathMessageSelfKill[$DamageType::StMine, 3] = '\c0One small step for %1, and one giant mine electification for %2self.';
$DeathMessageSelfKill[$DamageType::StMine, 4] = '\c0%1, Did you enjoy having that electrical mine seisure?';

$DeathMessageSelfKill[$DamageType::NlMine, 0] = '\c0%1 expeiriences spontanious combustion from %3 mine';
$DeathMessageSelfKill[$DamageType::NlMine, 1] = '\c0%1 combusts instantly from %3 own mine.';
$DeathMessageSelfKill[$DamageType::NlMine, 2] = '\c0%1 steps into the lava, well sort of %3 own nalcidic mine!';
$DeathMessageSelfKill[$DamageType::NlMine, 3] = '\c0One small step for %1, and one giant flammable explosion on %2self.';
$DeathMessageSelfKill[$DamageType::NlMine, 4] = '\c0%1 this isnt BF2, your own mines do kill you, especially nalcidic ones.';

$DeathMessageSelfKill[$DamageType::SatchelCharge, 0] = '\c0%1 goes out with a bang!';  //applies to most explosion types
$DeathMessageSelfKill[$DamageType::SatchelCharge, 1] = '\c0%1 scatters %3self with a satchel.';
$DeathMessageSelfKill[$DamageType::SatchelCharge, 2] = '\c0%1 explodes in that fatal kind of way.';
$DeathMessageSelfKill[$DamageType::SatchelCharge, 3] = '\c0%1 should have put the satchel, just a fe more meters away!';
$DeathMessageSelfKill[$DamageType::SatchelCharge, 4] = '\c0%1 splashes all over the map.';

$DeathMessageSelfKill[$DamageType::Ground, 0] = '\c0%1 lands too hard.';					//100
$DeathMessageSelfKill[$DamageType::Ground, 1] = '\c0%1 finds gravity unforgiving.';
$DeathMessageSelfKill[$DamageType::Ground, 2] = '\c0%1 landed, and broke his legs, then everything else above that aswell.';
$DeathMessageSelfKill[$DamageType::Ground, 3] = '\c0%1 forgot his parachute.';
$DeathMessageSelfKill[$DamageType::Ground, 4] = '\c0%1 loses a game of chicken with the ground.';

$DeathMessageSelfKill[$DamageType::Bazooka, 0] = '\c0Dont worry %1, your not the first dumbass to kill %2self with explosives.';
$DeathMessageSelfKill[$DamageType::Bazooka, 1] = '\c0%1 must have accidently moved the mouse when he fired %3 bazooka.';
$DeathMessageSelfKill[$DamageType::Bazooka, 2] = '\c0%1 says OUCH to %3 bazooka.';
$DeathMessageSelfKill[$DamageType::Bazooka, 3] = '\c0%1 squeezes %3 bazooka shell tightly.';
$DeathMessageSelfKill[$DamageType::Bazooka, 4] = '\c0%1 now knows that bazookas can turn on their owners.';

$DeathMessageSelfKill[$DamageType::RPG, 0] = '\c0%1 succesfully RPGs %2self.';
$DeathMessageSelfKill[$DamageType::RPG, 1] = '\c0%1 tried to throw a nade while using a RPG SMG and ... well the rest is history, just like %2.';
$DeathMessageSelfKill[$DamageType::RPG, 2] = '\c0%1 had the wrong instinct, and RPGs %2self.';
$DeathMessageSelfKill[$DamageType::RPG, 3] = '\c0%1 ... ummm yea, oh well.';
$DeathMessageSelfKill[$DamageType::RPG, 4] = '\c0%1 kills %2self again *Sigh*.';

$DeathMessageSelfKill[$DamageType::nuke, 0] = '\c0%1 stood a little to close to %2 bunker Buster.';
$DeathMessageSelfKill[$DamageType::nuke, 1] = '\c0%1 blew %2self up and everything around %2.';
$DeathMessageSelfKill[$DamageType::nuke, 2] = '\c0%1 never felt a thing.';
$DeathMessageSelfKill[$DamageType::nuke, 3] = '\c0%1 vaporised %2self.';
$DeathMessageSelfKill[$DamageType::nuke, 4] = '\c0%1 fired a bunker Buster then wondered why %2 life ended.';

$DeathMessageSelfKill[$DamageType::Phaser, 0] = '\c0%1 pulled a few hot bolts into %2self.';
$DeathMessageSelfKill[$DamageType::Phaser, 1] = '\c0%1 phased away.';
$DeathMessageSelfKill[$DamageType::Phaser, 2] = '\c0%1 Pulled out a phaser and Blam!.';
$DeathMessageSelfKill[$DamageType::Phaser, 3] = '\c0%1 phased %2self.';
$DeathMessageSelfKill[$DamageType::Phaser, 4] = '\c0%1 phased %3 head and doing that killed himself.';

$DeathMessageSelfKill[$DamageType::PhotonLaser, 0] = '\c0%1 Held still while the laser crisped %2.';
$DeathMessageSelfKill[$DamageType::PhotonLaser, 1] = '\c0%1 trys new laser therapy, unfortunatly it was the fatal type.';
$DeathMessageSelfKill[$DamageType::PhotonLaser, 2] = '\c0%1 Pulled out a photon laser and crisped away.';
$DeathMessageSelfKill[$DamageType::PhotonLaser, 3] = '\c0%1 photonified %2self.';
$DeathMessageSelfKill[$DamageType::PhotonLaser, 4] = '\c0%1 melts when %3 laser malfunctioned on %3 face.';

$DeathMessageSelfKill[$DamageType::LaserRifle, 0] = '\c0%1 Inversed %3 laser against %2.';
$DeathMessageSelfKill[$DamageType::LaserRifle, 1] = '\c0%1 Inversed %3 laser against %2.';
$DeathMessageSelfKill[$DamageType::LaserRifle, 2] = '\c0%1 Inversed %3 laser against %2.';
$DeathMessageSelfKill[$DamageType::LaserRifle, 3] = '\c0%1 Inversed %3 laser against %2.';
$DeathMessageSelfKill[$DamageType::LaserRifle, 4] = '\c0%1 Inversed %3 laser against %2.';

$DeathMessageSelfKill[$DamageType::BRifle, 0] = '\c0%1 Oddly enough, Had Serious Battle Rifle Issues.';
$DeathMessageSelfKill[$DamageType::BRifle, 1] = '\c0%1 Oddly enough, Had Serious Battle Rifle Issues.';
$DeathMessageSelfKill[$DamageType::BRifle, 2] = '\c0%1 Oddly enough, Had Serious Battle Rifle Issues.';
$DeathMessageSelfKill[$DamageType::BRifle, 3] = '\c0%1 Oddly enough, Had Serious Battle Rifle Issues.';
$DeathMessageSelfKill[$DamageType::BRifle, 4] = '\c0%1 Oddly enough, Had Serious Battle Rifle Issues.';

$DeathMessageSelfKill[$DamageType::Spiker, 0] = '\c0%1 Spiked %2self to death.. *pain*.';
$DeathMessageSelfKill[$DamageType::Spiker, 1] = '\c0%1 Spiked %2self to death.. *pain*.';
$DeathMessageSelfKill[$DamageType::Spiker, 2] = '\c0%1 Spiked %2self to death.. *pain*.';
$DeathMessageSelfKill[$DamageType::Spiker, 3] = '\c0%1 Spiked %2self to death.. *pain*.';
$DeathMessageSelfKill[$DamageType::Spiker, 4] = '\c0%1 Spiked %2self to death.. *pain*.';

$DeathMessageSelfKill[$DamageType::HelicopterCGMount, 0] = '\c0%1 Blasted %2self with a Very Large Chaingun.';
$DeathMessageSelfKill[$DamageType::HelicopterCGMount, 1] = '\c0%1 Pointed the barrles of death upon %2self.';
$DeathMessageSelfKill[$DamageType::HelicopterCGMount, 2] = '\c0%1 had no idea what %3 new helicopter CG could do.';
$DeathMessageSelfKill[$DamageType::HelicopterCGMount, 3] = '\c0%1 played russian roulette with %2self with a Very Large Chaingun.';
$DeathMessageSelfKill[$DamageType::HelicopterCGMount, 4] = '\c0%1 was wrong about the power of %3 Chaingun.';

$DeathMessageSelfKill[$DamageType::BazookaII, 0] = '\c0%1 Obliterated %2self.... Literaly';
$DeathMessageSelfKill[$DamageType::BazookaII, 1] = '\c0TOO BAD %1!! You blasted Yourself there.';
$DeathMessageSelfKill[$DamageType::BazookaII, 2] = '\c0%1 says OUCH to %3 Enemia Rocket Launcher.';
$DeathMessageSelfKill[$DamageType::BazookaII, 3] = '\c0%1 squeezes %3 Enemia shell tightly.';
$DeathMessageSelfKill[$DamageType::BazookaII, 4] = '\c0%1 Blows %3 name all over the map.';

$DeathMessageSelfKill[$DamageType::PGC, 0] = '\c0%1 took gauss cannons too seriously.';
$DeathMessageSelfKill[$DamageType::PGC, 1] = '\c0%1 pounds %3 face into the ground with a gauss cannon';
$DeathMessageSelfKill[$DamageType::PGC, 2] = '\c0%1 says OUCH to %3 Gauss Cannon.';
$DeathMessageSelfKill[$DamageType::PGC, 3] = '\c0%1 obviously didnt see the word Explosive on the Gauss Shell.';
$DeathMessageSelfKill[$DamageType::PGC, 4] = '\c0%1 Blows %3 name all over the map with a gauss cannon.';

$DeathMessageSelfKill[$DamageType::VoltGun, 0] = '\c0%1 is now one with electrical weaponry.';
$DeathMessageSelfKill[$DamageType::VoltGun, 1] = '\c0%1 fired the voltage Cannon too close.';
$DeathMessageSelfKill[$DamageType::VoltGun, 2] = '\c0%1 gets zapped with 10000 Volts of %3 Voltage Cannon.';
$DeathMessageSelfKill[$DamageType::VoltGun, 3] = '\c0%1 Unleashed an electrical storm... upon %2self.';
$DeathMessageSelfKill[$DamageType::VoltGun, 4] = '\c0%1 was simply electrocuted... by %3 own gun.';

//used when a player is killed by a teammate
$DeathMessageTeamKillCount = 1;
$DeathMessageTeamKill[$DamageType::Blaster, 0] = '\c0%4 TEAMKILLED %1 with a blaster!';
$DeathMessageTeamKill[$DamageType::Plasma, 0] = '\c0%4 TEAMKILLED %1 with a Flame thrower!';
$DeathMessageTeamKill[$DamageType::Bullet, 0] = '\c0%4 TEAMKILLED %1 with a chaingun!';
$DeathMessageTeamKill[$DamageType::Disc, 0] = '\c0%4 TEAMKILLED %1 with a spinfusor!';
$DeathMessageTeamKill[$DamageType::Grenade, 0] = '\c0%4 TEAMKILLED %1 with a grenade!';
$DeathMessageTeamKill[$DamageType::Laser, 0] = '\c0%4 TEAMKILLED %1 with a laser rifle!';
$DeathMessageTeamKill[$DamageType::Elf, 0] = '\c0%4 TEAMKILLED %1 with an ELF projector!';
$DeathMessageTeamKill[$DamageType::Mortar, 0] = '\c0%4 TEAMKILLED %1 with a mortar!';
$DeathMessageTeamKill[$DamageType::Missile, 0] = '\c0%4 TEAMKILLED %1 with a missile!';
$DeathMessageTeamKill[$DamageType::Shocklance, 0] = '\c0%4 TEAMKILLED %1 with a shocklance!';
$DeathMessageTeamKill[$DamageType::Mine, 0] = '\c0%4 TEAMKILLED %1 with a mine!';
$DeathMessageTeamKill[$DamageType::SatchelCharge, 0] = '\c0%4 blew up TEAMMATE %1!';
$DeathMessageTeamKill[$DamageType::Impact, 0] = '\c0%4 runs down TEAMMATE %1!';
$DeathMessageTeamKill[$DamageType::SuperChaingun, 0] = '\c0%4 TEAMKILLED %1 with a super chaingun!';
$DeathMessageTeamKill[$DamageType::Sniper, 0] = '\c0%4 sniped TEAMMATE %1!';
$DeathMessageTeamKill[$DamageType::MG, 0] = '\c0%4 mows down TEAMMATE %1!';
$DeathMessageTeamKill[$DamageType::Bazooka, 0] = '\c0%4 blew up TEAMMATE %1!';
$DeathMessageTeamKill[$DamageType::MG42, 0] = '\c0%4 PCTed TEAMMATE %1!';
$DeathMessageTeamKill[$DamageType::Pistol, 0] = '\c0%4 imbarases his TEAMMATE %1 with a pistol!';
$DeathMessageTeamKill[$DamageType::nuke, 0] = '\c0%4 blew up TEAMMATE %1 with a bunker Buster!';
$DeathMessageTeamKill[$DamageType::melee, 0] = '\c0%4 Hit TEAMMATE %1 over the head with his weapon butt to many times!';
$DeathMessageTeamKill[$DamageType::rifle, 0] = '\c0%4 just outright shot TEAMMATE %1 with a Rifle!';
$DeathMessageTeamKill[$DamageType::shotgun, 0] = '\c0%4 blew TEAMMATE %1 in half with a shotgun!';
$DeathMessageTeamKill[$DamageType::AT4, 0] = '\c0%4 blasted TEAMMATE %1 with an AT4!';
$DeathMessageTeamKill[$DamageType::RPG, 0] = '\c0%4 is so dumb he tested his RPG on TEAMMATE %1!';
$DeathMessageTeamKill[$DamageType::Shotdown, 0] = '\c0%4 shots down TEAMMATE %1!';
$DeathMessageTeamKill[$DamageType::MP5, 0] = '\c0%4 rapidly guns down TEAMMATE %1!';
$DeathMessageTeamKill[$DamageType::PBC, 0] = '\c0%4 shocks TEAMMATE %1 with %6 new prototype weapon!';
$DeathMessageTeamKill[$DamageType::SRifle, 0] = '\c0%4 shot TEAMMATE %1 with a RX-12 Rifle.';
$DeathMessageTeamKill[$DamageType::Phaser, 0] = '\c0%4 Phased TEAMMATE %1 with his ES-73.';
$DeathMessageTeamKill[$DamageType::PhotonLaser, 0] = '\c0%4 crisped TEAMMATE %1 with a photon laser.';
$DeathMessageTeamKill[$DamageType::LaserRifle, 0] = '\c0%4 Blasted TEAMMATE %1 with red hot lasers.';
$DeathMessageTeamKill[$DamageType::BazookaII, 0] = '\c0%4 Blasted TEAMMATE %1!';
$DeathMessageTeamKill[$DamageType::HArtil, 0] = '\c0%4 Paved TEAMMATE %1 with a artillery shell!';
$DeathMessageTeamKill[$DamageType::BRifle, 0] = '\c0%4 Forgot that the Battle Rifle Shot 3 Bullets and hit TEAMMATE %1!';
$DeathMessageTeamKill[$DamageType::Spiker, 0] = '\c0%4 Unleashed Spiker Fury Upon TEAMMATE %1!';
$DeathMessageTeamKill[$DamageType::deserteagle, 0] = '\c0%4 TEAMKILLED %1 with a desert eagle pistol!';
$DeathMessageTeamKill[$DamageType::HelicopterCGMount, 0] = '\c0%4 TEAMKILLED %1 with very powerful chaingun!';
$DeathMessageTeamKill[$DamageType::PGC, 0] = '\c0%4 Obliterates TEAMMATE %1 with a gauss cannon!';
$DeathMessageTeamKill[$DamageType::VoltGun, 0] = '\c0%4 Unleashes %6 voltage cannon upon TEAMMATE %1!';
$DeathMessageTeamKill[$DamageType::ALSWP, 0] = '\c0%4 TEAMKILLED %1 with rapid sniper shots!';
$DeathMessageTeamKill[$DamageType::Photon, 0] = '\c0%1 was teamkilled by Seeker Plasma from %4!';
$DeathMessageTeamKill[$DamageType::StMine, 0] = '\c0%4 TEAMKILLED %1 with a static mine!';
$DeathMessageTeamKill[$DamageType::NlMine, 0] = '\c0%4 TEAMKILLED %1 with a nalcidic mine!';

//these used when a player is killed by an enemy
$DeathMessageCount = 5;
$DeathMessage[$DamageType::Blaster, 0] = '\c0%4 kills %1 with a blaster.';
$DeathMessage[$DamageType::Blaster, 1] = '\c0%4 pings %1 to death.';
$DeathMessage[$DamageType::Blaster, 2] = '\c0%1 gets a pointer in blaster use from %4.';
$DeathMessage[$DamageType::Blaster, 3] = '\c0%4 fatally embarrasses %1 with %6 pea shooter.';
$DeathMessage[$DamageType::Blaster, 4] = '\c0%4 unleashes a terminal blaster barrage into %1.';

$DeathMessage[$DamageType::Plasma, 0] = '\c0%4 wanted a little %1 cooked 3rd degree.';
$DeathMessage[$DamageType::Plasma, 1] = '\c0%1 got burned by %4.';
$DeathMessage[$DamageType::Plasma, 2] = '\c0%4 entices %1 to try a faceful of Fire.';
$DeathMessage[$DamageType::Plasma, 3] = '\c0%4 introduces %1 to the flamer immolation dance.';
$DeathMessage[$DamageType::Plasma, 4] = '\c0%4 slaps The Hot Kiss of Death on %1.';

$DeathMessage[$DamageType::Bullet, 0] = '\c0%4 rips %1 up with the chaingun.';
$DeathMessage[$DamageType::Bullet, 1] = '\c0%4 happily chews %1 into pieces with %6 chaingun.';
$DeathMessage[$DamageType::Bullet, 2] = '\c0%4 administers a dose of Vitamin Lead to %1.';
$DeathMessage[$DamageType::Bullet, 3] = '\c0%1 suffers a serious hosing from %4\'s chaingun.';
$DeathMessage[$DamageType::Bullet, 4] = '\c0%4 bestows the blessings of %6 chaingun on %1.';

$DeathMessage[$DamageType::Disc, 0] = '\c0%4 demolishes %1 with the spinfusor.';
$DeathMessage[$DamageType::Disc, 1] = '\c0%4 serves %1 a blue plate special.';
$DeathMessage[$DamageType::Disc, 2] = '\c0%4 shares a little blue friend with %1.';
$DeathMessage[$DamageType::Disc, 3] = '\c0%4 puts a little spin into %1.';
$DeathMessage[$DamageType::Disc, 4] = '\c0%1 becomes one of %4\'s greatest hits.';

$DeathMessage[$DamageType::Grenade, 0] = '\c0%4 eliminates %1 with a grenade.';   //applies to hand grenades *and* grenade launcher grenades
$DeathMessage[$DamageType::Grenade, 1] = '\c0%4 blows up %1 real good!';
$DeathMessage[$DamageType::Grenade, 2] = '\c0%1 gets annihilated by %4\'s grenade.';
$DeathMessage[$DamageType::Grenade, 3] = '\c0%1 receives a kaboom lesson from %4.';
$DeathMessage[$DamageType::Grenade, 4] = '\c0%4 turns %1 into grenade salad.';

$DeathMessage[$DamageType::Laser, 0] = '\c0%1 becomes %4\'s latest pincushion.';
$DeathMessage[$DamageType::Laser, 1] = '\c0%4 picks off %1 with %6 laser rifle.';
$DeathMessage[$DamageType::Laser, 2] = '\c0%4 uses %1 as the targeting dummy in a sniping demonstration.';
$DeathMessage[$DamageType::Laser, 3] = '\c0%4 pokes a shiny new hole in %1 with %6 laser rifle.';
$DeathMessage[$DamageType::Laser, 4] = '\c0%4 caresses %1 with a couple hundred megajoules of laser.';

$DeathMessage[$DamageType::Elf, 0] = '\c0%4 fries %1 with the ELF projector.';
$DeathMessage[$DamageType::Elf, 1] = '\c0%4 bug zaps %1 with %6 ELF.';
$DeathMessage[$DamageType::Elf, 2] = '\c0%1 learns the shocking truth about %4\'s ELF skills.';
$DeathMessage[$DamageType::Elf, 3] = '\c0%4 electrocutes %1 without a sponge.';
$DeathMessage[$DamageType::Elf, 4] = '\c0%4\'s ELF projector leaves %1 a crispy critter.';

$DeathMessage[$DamageType::Mortar, 0] = '\c0%4 obliterates %1 with the mortar.';				//200
$DeathMessage[$DamageType::Mortar, 1] = '\c0%4 drops a mortar round right in %1\'s lap.';
$DeathMessage[$DamageType::Mortar, 2] = '\c0%4 delivers a mortar payload straight to %1.';
$DeathMessage[$DamageType::Mortar, 3] = '\c0%4 offers a little "heavy love" to %1.';
$DeathMessage[$DamageType::Mortar, 4] = '\c0%1 stumbles into %4\'s mortar reticle.';

$DeathMessage[$DamageType::Missile, 0] = '\c0%4 intercepts %1 with a missile.';
$DeathMessage[$DamageType::Missile, 1] = '\c0%4 watches %6 missile touch %1 and go boom.';
$DeathMessage[$DamageType::Missile, 2] = '\c0%4 got sweet tone on %1.';
$DeathMessage[$DamageType::Missile, 3] = '\c0By now, %1 has realized %4\'s missile killed %2.';
$DeathMessage[$DamageType::Missile, 4] = '\c0%4\'s missile rains little pieces of %1 all over the ground.';

$DeathMessage[$DamageType::Shocklance, 0] = '\c0%4 reaps a harvest of %1 with the shocklance.';
$DeathMessage[$DamageType::Shocklance, 1] = '\c0%4 feeds %1 the business end of %6 shocklance.';
$DeathMessage[$DamageType::Shocklance, 2] = '\c0%4 stops %1 dead with the shocklance.';
$DeathMessage[$DamageType::Shocklance, 3] = '\c0%4 eliminates %1 in close combat.';
$DeathMessage[$DamageType::Shocklance, 4] = '\c0%4 ruins %1\'s day with one zap of a shocklance.';

$DeathMessage[$DamageType::Photon, 0] = '\c0%1 is vaporized by closely following plasma.';
$DeathMessage[$DamageType::Photon, 1] = '\c0%1 explodes the instant that seeker plasma hit.';
$DeathMessage[$DamageType::Photon, 2] = '\c0%1, when you see a green blob following you, RUN!';
$DeathMessage[$DamageType::Photon, 3] = '\c0%1 couldnt out-run the seeking plasma, and died.';
$DeathMessage[$DamageType::Photon, 4] = '\c0%1 now feels the excess heat of plasma burns.';

$DeathMessage[$DamageType::Mine, 0] = '\c0%4 kills %1 with a mine.';
$DeathMessage[$DamageType::Mine, 1] = '\c0%1 doesn\'t see %4\'s mine in time.';
$DeathMessage[$DamageType::Mine, 2] = '\c0%4 gets a sapper kill on %1.';
$DeathMessage[$DamageType::Mine, 3] = '\c0%1 puts his foot on %4\'s mine.';
$DeathMessage[$DamageType::Mine, 4] = '\c0One small step for %1, one giant mine kill for %4.';

$DeathMessage[$DamageType::SatchelCharge, 0] = '\c0%4 buys %1 a ticket to the moon.';  //satchel charge only
$DeathMessage[$DamageType::SatchelCharge, 1] = '\c0%4 blows %1 into low orbit.';
$DeathMessage[$DamageType::SatchelCharge, 2] = '\c0%4 makes %1 a hugely explosive offer.';
$DeathMessage[$DamageType::SatchelCharge, 3] = '\c0%4 turns %1 into a cloud of satchel-vaporized armor.';
$DeathMessage[$DamageType::SatchelCharge, 4] = '\c0%4\'s satchel charge leaves %1 nothin\' but smokin\' boots.';

$DeathMessage[$DamageType::MG, 0] = '\c0%4 Mows down %1.';
$DeathMessage[$DamageType::MG, 1] = '\c0%4 makes %1 a victom of War *M32*.';
$DeathMessage[$DamageType::MG, 2] = '\c0%4 Happly feeds %1 some War lead.';
$DeathMessage[$DamageType::MG, 3] = '\c0%4 puts nice new holes in %1 armor.';
$DeathMessage[$DamageType::MG, 4] = '\c0%4 quickly guns down %1.';

$DeathMessage[$DamageType::Bazooka, 0] = '\c0%4 Blasts %1.';
$DeathMessage[$DamageType::Bazooka, 1] = '\c0%4 makes %1 a victom of War *bazooka*.';
$DeathMessage[$DamageType::Bazooka, 2] = '\c0%4 makes %1 explodes on impact.';
$DeathMessage[$DamageType::Bazooka, 3] = '\c0%4 leaves a gapping hole in %1\'s armor.';
$DeathMessage[$DamageType::Bazooka, 4] = '\c0%4 gives %1 rocket-phobia.';

$DeathMessage[$DamageType::Sniper, 0] = '\c0%4 sniped %1.';
$DeathMessage[$DamageType::Sniper, 1] = '\c0%4 blew %1s brains out with %3 sniper rifle.';
$DeathMessage[$DamageType::Sniper, 2] = '\c0%4 Makes %1 a victom of War *sniper gun*.';
$DeathMessage[$DamageType::Sniper, 3] = '\c0%4 found that one, perfect, shot, and splattered %1\'s insides all over the ground.';
$DeathMessage[$DamageType::Sniper, 4] = '\c0%4 smiles as he snipes %1.';

$DeathMessage[$DamageType::MG42, 0] = '\c0%4 Took Chaingun Turrets to the extreme on %1.';
$DeathMessage[$DamageType::MG42, 1] = '\c0%4 Definatly Out-Gunned %1 with a PCT.';
$DeathMessage[$DamageType::MG42, 2] = '\c0%4 Destroys %1 with a PCT.';
$DeathMessage[$DamageType::MG42, 3] = '\c0%4 makes %1 a very holy person, if you know what I Mean.';
$DeathMessage[$DamageType::MG42, 4] = '\c0%4 injects lethal amounts of lead into %1 .';

$DeathMessage[$DamageType::Pistol, 0] = '\c0%4 shoots %1 with a USP Pistol.';
$DeathMessage[$DamageType::Pistol, 1] = '\c0%4 Took out the pistol and killed %1.';
$DeathMessage[$DamageType::Pistol, 2] = '\c0%4 Makes %1 a victom of War *USP-45*.';
$DeathMessage[$DamageType::Pistol, 3] = '\c0%4 Takes out %6 USP-45 and fires at %1.';
$DeathMessage[$DamageType::Pistol, 4] = '\c0%4 totally out skills %1 by killing him with a USP-45.';

$DeathMessage[$DamageType::deserteagle, 0] = '\c0%4 shoots %1 with a Desert Eagle.';
$DeathMessage[$DamageType::deserteagle, 1] = '\c0%4 takes pistol warfare to the extreme on %1.';
$DeathMessage[$DamageType::deserteagle, 2] = '\c0%4 Blasts %1 with a Desert Eagle.';
$DeathMessage[$DamageType::deserteagle, 3] = '\c0%4 Takes out %6 Desert Eagle and fires at %1.';
$DeathMessage[$DamageType::deserteagle, 4] = '\c0%4 Blows %1 to pieces with %6 Desert Eagle.';

$DeathMessage[$DamageType::nuke, 0] = '\c0%4 vaporised %1.';
$DeathMessage[$DamageType::nuke, 1] = '\c0%1 never felt a thing from %4\'s bunker Buster.';
$DeathMessage[$DamageType::nuke, 2] = '\c0%4 Makes %1 a victom of War *bunker Buster*.';
$DeathMessage[$DamageType::nuke, 3] = '\c0%4 the super admin, cheaply bunker Bustered %1.';
$DeathMessage[$DamageType::nuke, 4] = '\c0%4 sends his blast radius weapon from hell at %1.';

$DeathMessage[$DamageType::melee, 0] = '\c0%4 got in close with %1.';
$DeathMessage[$DamageType::melee, 1] = '\c0%4 finally knocked some sense into %1.';
$DeathMessage[$DamageType::melee, 2] = '\c0%4 slaps %1 with a gun butt.';
$DeathMessage[$DamageType::melee, 3] = '\c0%4 just beats the living s**t out of %1.';
$DeathMessage[$DamageType::melee, 4] = '\c0%4 outclassed %1 in close range.';

$DeathMessage[$DamageType::Rifle, 0] = '\c0%4 shot %1.';
$DeathMessage[$DamageType::Rifle, 1] = '\c0%4 got %5self some accuracy marks, thanks to %1.';
$DeathMessage[$DamageType::Rifle, 2] = '\c0%4 called out the Krieg and went after %1.';
$DeathMessage[$DamageType::Rifle, 3] = '\c0%1 was thinking "how much wood could a wo" and then %4 killed %3.';
$DeathMessage[$DamageType::Rifle, 4] = '\c0%4 makes %1 a victom of War *Rifle*.';

$DeathMessage[$DamageType::Shotgun, 0] = '\c0%4 literally pumped %1 full of lead.';
$DeathMessage[$DamageType::Shotgun, 1] = '\c0%1 gets shot in half by %4.';
$DeathMessage[$DamageType::Shotgun, 2] = '\c0%4 shotguns %1.';
$DeathMessage[$DamageType::Shotgun, 3] = '\c0%4 trys to count the number of pellets in %1\'s dead body but cant find them all.';
$DeathMessage[$DamageType::Shotgun, 4] = '\c0%4 makes %1 a victom of War *Shotgun*.';

$DeathMessage[$DamageType::AT4, 0] = '\c0%4 Blasts %1.';
$DeathMessage[$DamageType::AT4, 1] = '\c0%4 makes %1 a victom of War *At6*.';
$DeathMessage[$DamageType::AT4, 2] = '\c0%4 gives %1 a few little FATAL burns.';
$DeathMessage[$DamageType::AT4, 3] = '\c0%4\'s AT6 Rocket hits %1\'s armor and goes BOOM.';
$DeathMessage[$DamageType::AT4, 4] = '\c0%4 Launches a really fast rocket at %1.';

$DeathMessage[$DamageType::RPG, 0] = '\c0%4 Gives a little package of explosive joy to %1.';
$DeathMessage[$DamageType::RPG, 1] = '\c0%4 makes %1 a victom of War *RPG*.';
$DeathMessage[$DamageType::RPG, 2] = '\c0%4 gives %1 an explosive lunch with a side of RPG.';
$DeathMessage[$DamageType::RPG, 3] = '\c0%4\'s RPG hits around %1\'s armor who was last seen in mid air.';
$DeathMessage[$DamageType::RPG, 4] = '\c0%4 he ... well he just Pwned %1 with a RPG.';

$DeathMessage[$DamageType::MP5, 0] = '\c0%4 rapidly, as in very rapidly guns down %1.';
$DeathMessage[$DamageType::MP5, 1] = '\c0%4 makes %1 a victom of War *MP12*.';
$DeathMessage[$DamageType::MP5, 2] = '\c0%4 shoots warning shots by %1 which accidentaly hit.';
$DeathMessage[$DamageType::MP5, 3] = '\c0%4 puts nice new holes in %1 armor.';
$DeathMessage[$DamageType::MP5, 4] = '\c0%4 introduces %1 to a nice hot home made of lead, and %1 just died in excitement.';

$DeathMessage[$DamageType::PBC, 0] = '\c0%1 when a big green Targeting Laser comes up on you, run or %4 might kill you in 2 seconds.';
$DeathMessage[$DamageType::PBC, 1] = '\c0%4 makes %1 a victom of War *EG3 PBC*.';
$DeathMessage[$DamageType::PBC, 2] = '\c0%1 shockingly takes %4\'s piece of advice and dies.';
$DeathMessage[$DamageType::PBC, 3] = '\c0%1 does the electric slide and %4\'s the DJ.';
$DeathMessage[$DamageType::PBC, 4] = '\c0%4 gives %1 some loving shock theropy.';

$DeathMessage[$DamageType::SRifle, 0] = '\c0%4 shot %1 with a RX-12.';
$DeathMessage[$DamageType::SRifle, 1] = '\c0%1 has holes by the threes. %4.';
$DeathMessage[$DamageType::SRifle, 2] = '\c0%4 put a couple bursts of 5.56 ammuntion into %1.';
$DeathMessage[$DamageType::SRifle, 3] = '\c0%4 smacks %1 down with a RX-12.';
$DeathMessage[$DamageType::SRifle, 4] = '\c0%4 makes %1 a victom of War *RX-12*.';


$DeathMessageHeadshotCount = 3;
$DeathMessageHeadshot[$DamageType::Laser, 0] = '\c0%4 drills right through %1\'s braincase with %6 laser.';
$DeathMessageHeadshot[$DamageType::Laser, 1] = '\c0%4 pops %1\'s head like a cheap balloon.';
$DeathMessageHeadshot[$DamageType::Laser, 2] = '\c0%1 loses %3 head over %4\'s laser skill.';

$DeathMessageHeadshot[$DamageType::Sniper, 0] = '\c0%4 drills right through %1\'s braincase with %6 sniperrifle.';
$DeathMessageHeadshot[$DamageType::Sniper, 1] = '\c0%4 pops %1\'s head like a cheap balloon.';
$DeathMessageHeadshot[$DamageType::Sniper, 2] = '\c0%1 loses %3 head over %4\'s sniper skill.';


//These used when a player is run over by a vehicle
$DeathMessageVehicleCount = 5;
$DeathMessageVehicle[0] = '\c0%4 runs down %1 then throws it in reverse just to make sure.';
$DeathMessageVehicle[1] = '\c0%1 isnt feeling to much nowadays %4.';
$DeathMessageVehicle[2] = '\c0%4 turns %1 into tribal roadkill.';
$DeathMessageVehicle[3] = '\c0%1 tried to get that speck of dirt off of %4\'s front bumper.';
$DeathMessageVehicle[4] = '\c0%1\'s messy death leaves a mark on %4\'s vehicle finish.';

$DeathMessageVehicleCrashCount = 5;
$DeathMessageVehicleCrash[ $DamageType::Crash, 0 ] = '\c0%1 fails to eject in time.';
$DeathMessageVehicleCrash[ $DamageType::Crash, 1 ] = '\c0%1 becomes one with his vehicle dashboard.';
$DeathMessageVehicleCrash[ $DamageType::Crash, 2 ] = '\c0%1 drives under the influence of death.';
$DeathMessageVehicleCrash[ $DamageType::Crash, 3 ] = '\c0%1 makes a perfect three hundred point landing.';
$DeathMessageVehicleCrash[ $DamageType::Crash, 4 ] = '\c0%1 heroically pilots his vehicle into something really, really hard.';

$DeathMessageVehicleFriendlyCount = 3;
$DeathMessageVehicleFriendly[0] = '\c0%1 gets in the way of a friendly vehicle.';
$DeathMessageVehicleFriendly[1] = '\c0Sadly, a friendly vehicle turns %1 into roadkill.';
$DeathMessageVehicleFriendly[2] = '\c0%1 becomes an unsightly ornament on a team vehicle\'s hood.';

$DeathMessageVehicleUnmannedCount = 3;
$DeathMessageVehicleUnmanned[0] = '\c0%1 gets in the way of a runaway vehicle.';
$DeathMessageVehicleUnmanned[1] = '\c0An unmanned vehicle kills the pathetic %1.';
$DeathMessageVehicleUnmanned[2] = '\c0%1 is struck down by an empty vehicle.';

//These used when a player is killed by a nearby equipment explosion
$DeathMessageExplosionCount = 3;
$DeathMessageExplosion[0] = '\c0%1 was killed by exploding equipment!';
$DeathMessageExplosion[1] = '\c0%1 stood a little too close to the action!';
$DeathMessageExplosion[2] = '\c0%1 learns how to be collateral damage.';

//These used when an automated turret kills an  enemy player
$DeathMessageTurretKillCount = 3;
$DeathMessageTurretKill[$DamageType::PlasmaTurret, 0] = '\c0%1 is killed by a chaingun turret.';
$DeathMessageTurretKill[$DamageType::PlasmaTurret, 1] = '\c0%1 is shredded by a chaingun battery.';
$DeathMessageTurretKill[$DamageType::PlasmaTurret, 2] = '\c0%1 is completely perforated by a chaingun turret.';

$DeathMessageTurretKill[$DamageType::PBCTurret, 0] = '\c0%1 gets shocked like crazy by a PBC Turret.';
$DeathMessageTurretKill[$DamageType::PBCTurret, 1] = '\c0%1 Becomes Electrified and glows bright blue by a PBC Turret.';
$DeathMessageTurretKill[$DamageType::PBCTurret, 2] = '\c0%1 Enjoys The PBC Turret Electric Dance.';

$DeathMessageTurretKill[$DamageType::Vulcan, 0] = '\c0%1 Gets 1,000,000 Bullets Per Second By A Vulcan Turret.';
$DeathMessageTurretKill[$DamageType::Vulcan, 1] = '\c0%1 Gets all of the Vulcans attention.';
$DeathMessageTurretKill[$DamageType::Vulcan, 2] = '\c0%1 is litterally shredded by a vulcan turret.';

$DeathMessageTurretKill[$DamageType::AATurret, 0] = '\c0%1 is killed by an AA turret.';
$DeathMessageTurretKill[$DamageType::AATurret, 1] = '\c0%1 is shot down by an AA turret.';
$DeathMessageTurretKill[$DamageType::AATurret, 2] = '\c0%1 takes fatal flak from an AA turret.';

$DeathMessageTurretKill[$DamageType::ElfTurret, 0] = '\c0%1 is killed by an ELF turret.';
$DeathMessageTurretKill[$DamageType::ElfTurret, 1] = '\c0%1 is zapped by an ELF turret.';
$DeathMessageTurretKill[$DamageType::ElfTurret, 2] = '\c0%1 is short-circuited by an ELF turret.';

$DeathMessageTurretKill[$DamageType::MortarTurret, 0] = '\c0%1 is killed by a mortar turret.';
$DeathMessageTurretKill[$DamageType::MortarTurret, 1] = '\c0%1 enjoys a mortar turret\'s attention.';
$DeathMessageTurretKill[$DamageType::MortarTurret, 2] = '\c0%1 is blown to kibble by a mortar turret.';

$DeathMessageTurretKill[$DamageType::MissileTurret, 0] = '\c0%1 is killed by a missile turret.';
$DeathMessageTurretKill[$DamageType::MissileTurret, 1] = '\c0%1 is shot down by a missile turret.';
$DeathMessageTurretKill[$DamageType::MissileTurret, 2] = '\c0%1 is blown away by a missile turret.';

$DeathMessageTurretKill[$DamageType::IndoorDepTurret, 0] = '\c0%1 is killed by a clamp turret.';
$DeathMessageTurretKill[$DamageType::IndoorDepTurret, 1] = '\c0%1 gets burned by a clamp turret.';
$DeathMessageTurretKill[$DamageType::IndoorDepTurret, 2] = '\c0A clamp turret eliminates %1.';

$DeathMessageTurretKill[$DamageType::OutdoorDepTurret, 0] = '\c0A spike turret neatly drills %1.';
$DeathMessageTurretKill[$DamageType::OutdoorDepTurret, 1] = '\c0%1 gets taken out by a spike turret.';
$DeathMessageTurretKill[$DamageType::OutdoorDepTurret, 2] = '\c0%1 dies under a spike turret\'s love.';

$DeathMessageTurretKill[$DamageType::SentryTurret, 0] = '\c0%1 didn\'t see that Sentry turret, but it saw %2...';
$DeathMessageTurretKill[$DamageType::SentryTurret, 1] = '\c0%1 needs to watch for Sentry turrets.';
$DeathMessageTurretKill[$DamageType::SentryTurret, 2] = '\c0%1 now understands how Sentry turrets work.';

$DeathMessageTurretKill[$DamageType::Flak, 0] = '\c0%1 got flanked by a flak.';
$DeathMessageTurretKill[$DamageType::Flak, 1] = '\c0%1 sees blasts in the ski but figures they wont hurt him... WRONG.'; 
$DeathMessageTurretKill[$DamageType::Flak, 2] = '\c0%1 has a fit and so does the flak turret that saw him.';

$DeathMessageTurretKill[$DamageType::Artillery, 0] = '\c0%1 got lucky and the artillery turret was accurate this time or is that unlucky?.';
$DeathMessageTurretKill[$DamageType::Artillery, 1] = '\c0The Artillery turret couldnt stand %1\'s face so it blew it up.'; 
$DeathMessageTurretKill[$DamageType::Artillery, 2] = '\c0%1 is going to have a message sent home to his mother.';

$DeathMessageTurretKill[$DamageType::ShotDown, 0] = '\c0%4 Shots down %1 with a turret.';
$DeathMessageTurretKill[$DamageType::ShotDown, 1] = '\c0%1 crashes and burns because %4\'s turret.';
$DeathMessageTurretKill[$DamageType::ShotDown, 2] = '\c0%4\'s turret gains %6 some anti vehicle points thanks to %1.';



//used when a player is killed by a teammate controlling a turret
$DeathMessageCTurretTeamKillCount = 1;
$DeathMessageCTurretTeamKill[$DamageType::PlasmaTurret, 0] = '\c0%4 TEAMKILLED %1 with a gauss turret!';

$DeathMessageCTurretTeamKill[$DamageType::PBCTurret, 0] = '\c0%4 TEAMKILLED %1 with a PBC turret!';

$DeathMessageCTurretTeamKill[$DamageType::AATurret, 0] = '\c0%4 TEAMKILLED %1 with an AA turret!';

$DeathMessageCTurretTeamKill[$DamageType::ELFTurret, 0] = '\c0%4 TEAMKILLED %1 with an ELF turret!';

$DeathMessageCTurretTeamKill[$DamageType::MortarTurret, 0] = '\c0%4 TEAMKILLED %1 with a mortar turret!';

$DeathMessageCTurretTeamKill[$DamageType::MissileTurret, 0] = '\c0%4 TEAMKILLED %1 with a missile turret!';

$DeathMessageCTurretTeamKill[$DamageType::IndoorDepTurret, 0] = '\c0%4 TEAMKILLED %1 with a clamp turret!';

$DeathMessageCTurretTeamKill[$DamageType::OutdoorDepTurret, 0] = '\c0%4 TEAMKILLED %1 with a spike turret!';

$DeathMessageCTurretTeamKill[$DamageType::SentryTurret, 0] = '\c0%4 TEAMKILLED %1 with a sentry turret!';

$DeathMessageCTurretTeamKill[$DamageType::BomberBombs, 0] = '\c0%4 TEAMKILLED %1 in a bombastic explosion of raining death.';

$DeathMessageCTurretTeamKill[$DamageType::BellyTurret, 0] = '\c0%4 TEAMKILLED %1 by annihilating him from a belly turret.';

$DeathMessageCTurretTeamKill[$DamageType::TankChainGun, 0] = '\c0%4 TEAMKILLED %1 with his tank\'s chaingun.';

$DeathMessageCTurretTeamKill[$DamageType::TankChainGunH, 0] = '\c0%4 TEAMKILLED %1 with his tank\'s heavy chaingun.';

$DeathMessageCTurretTeamKill[$DamageType::TankMortar, 0] = '\c0%4 TEAMKILLED %1 by lobbing the BIG green death from a tank.';

$DeathMessageCTurretTeamKill[$DamageType::ShrikeBlaster, 0] = '\c0%4 TEAMKILLED %1 by strafing from a Shrike.';

$DeathMessageCTurretTeamKill[$DamageType::MPBMissile, 0] = '\c0%4 TEAMKILLED %1 when the MPB locked onto him.';

$DeathMessageCTurretTeamKill[$DamageType::Flak, 0] = '\c0%4 TEAMKILLS %1 with a extra friendly flak explosion.';

$DeathMessageCTurretTeamKill[$DamageType::Artillery, 0] = '\c0%4 TEAMKILLED %1 because he hated him.';

$DeathMessageCTurretTeamKill[$DamageType::Shotdown, 0] = '\c0%4 shots down TEAMMATE %1.';

$DeathMessageCTurretTeamKill[$DamageType::Vulcan, 0] = '\c0%4 TEAMKILLED %1 with a vulcan turret.';

$DeathMessageCTurretTeamKill[$DamageType::ACCG, 0] = '\c0%4 uses a Assault Chopper CG on TEAMMATE %1.';

$DeathMessageCTurretTeamKill[$DamageType::Bullet, 0] = '\c0%4 CGs down TEAMMATE %1 ... vehically.';

$DeathMessageCTurretTeamKill[$DamageType::MG, 0] = '\c0%4 CGs down TEAMMATE %1 ... vehically.';

$DeathMessageCTurretTeamKill[$DamageType::Plasma, 0] = '\c0%4 napalms TEAMMATE %1 to a good fried chicken level of crisp.';

$DeathMessageCTurretTeamKill[$DamageType::Missile, 0] = '\c0%4 TEAMKILLED %1 with a missile!';

$DeathMessageCTurretTeamKill[$DamageType::TankShell, 0] = '\c0%4 TEAMKILLED %1 by planting a shell in %3 face!';

//used when a player is killed by an uncontrolled, friendly turret
$DeathMessageCTurretAccdtlKillCount = 1;
$DeathMessageCTurretAccdtlKill[$DamageType::Vulcan, 0] = '\c0%1 got in the way of a vulcan turret!';

$DeathMessageCTurretAccdtlKill[$DamageType::AATurret, 0] = '\c0%1 got in the way of an AA turret!';

$DeathMessageCTurretAccdtlKill[$DamageType::ELFTurret, 0] = '\c0%1 got in the way of an ELF turret!';

$DeathMessageCTurretAccdtlKill[$DamageType::MortarTurret, 0] = '\c0%1 got in the way of a mortar turret!';

$DeathMessageCTurretAccdtlKill[$DamageType::MissileTurret, 0] = '\c0%1 got in the way of a missile turret!';

$DeathMessageCTurretAccdtlKill[$DamageType::IndoorDepTurret, 0] = '\c0%1 got in the way of a clamp turret!';

$DeathMessageCTurretAccdtlKill[$DamageType::OutdoorDepTurret, 0] = '\c0%1 got in the way of a spike turret!';

$DeathMessageCTurretAccdtlKill[$DamageType::OutdoorDepTurret, 0] = '\c0%1 got in the way of a vulcan turret!';

$DeathMessageCTurretAccdtlKill[$DamageType::SentryTurret, 0] = '\c0%1 got in the way of a Sentry turret!';

$DeathMessageCTurretAccdtlKill[$DamageType::Flak, 0] = '\c0%1 wonders how the flak turret killed him if it was shooting in the air.';

$DeathMessageCTurretAccdtlKill[$DamageType::Artillery, 0] = '\c0%1 dosent know how turrets work so he stepped in front of a artillery turret!';


//these messages for owned or controlled turrets
$DeathMessageCTurretKillCount = 3;
$DeathMessageCTurretKill[$DamageType::PlasmaTurret, 0] = '\c0%4 Pounds %1 with a gauss turret!';
$DeathMessageCTurretKill[$DamageType::PlasmaTurret, 1] = '\c0%4 Blows %1 to the ground with a gauss turret!';
$DeathMessageCTurretKill[$DamageType::PlasmaTurret, 2] = '\c0%4 lights up %1 with a gauss turret!';

$DeathMessageCTurretKill[$DamageType::AATurret, 0] = '\c0%4 shoots down %1 with an AA turret.';
$DeathMessageCTurretKill[$DamageType::AATurret, 1] = '\c0%1 gets shot down by %1\'s AA turret.';
$DeathMessageCTurretKill[$DamageType::AATurret, 2] = '\c0%4 takes out %1 with an AA turret.';

$DeathMessageCTurretKill[$DamageType::ElfTurret, 0] = '\c0%1 gets zapped by ELF gunner %4.';
$DeathMessageCTurretKill[$DamageType::ElfTurret, 1] = '\c0%1 gets barbecued by ELF gunner %4.';
$DeathMessageCTurretKill[$DamageType::ElfTurret, 2] = '\c0%1 gets shocked by ELF gunner %4.';

$DeathMessageCTurretKill[$DamageType::MortarTurret, 0] = '\c0%1 is annihilated by %4\'s mortar turret.';
$DeathMessageCTurretKill[$DamageType::MortarTurret, 1] = '\c0%1 is blown away by %4\'s mortar turret.';
$DeathMessageCTurretKill[$DamageType::MortarTurret, 2] = '\c0%1 is pureed by %4\'s mortar turret.';

$DeathMessageCTurretKill[$DamageType::MissileTurret, 0] = '\c0%4 gently places a missile into %1\'s face.';
$DeathMessageCTurretKill[$DamageType::MissileTurret, 1] = '\c0%4 pops %1 with a missile turret.';
$DeathMessageCTurretKill[$DamageType::MissileTurret, 2] = '\c0%4\'s missile turret lights up %1\'s, uh, ex-life.';

$DeathMessageCTurretKill[$DamageType::IndoorDepTurret, 0] = '\c0%1 is chewed up and spat out by %4\'s Emplacement.';
$DeathMessageCTurretKill[$DamageType::IndoorDepTurret, 1] = '\c0%1 is shredded by %4\'s Emplacement.';
$DeathMessageCTurretKill[$DamageType::IndoorDepTurret, 2] = '\c0%4\'s clamp turret drills %1 nicely.';

$DeathMessageCTurretKill[$DamageType::OutdoorDepTurret, 0] = '\c0%1 is chewed up by %4\'s spike turret.';
$DeathMessageCTurretKill[$DamageType::OutdoorDepTurret, 1] = '\c0%1 feels the burn from %4\'s spike turret.';
$DeathMessageCTurretKill[$DamageType::OutdoorDepTurret, 2] = '\c0%1 is nailed by %4\'s spike turret.';

$DeathMessageCTurretKill[$DamageType::SentryTurret, 0] = '\c0%4 caught %1 by surprise with a turret.';
$DeathMessageCTurretKill[$DamageType::SentryTurret, 1] = '\c0%4\'s turret took out %1.';
$DeathMessageCTurretKill[$DamageType::SentryTurret, 2] = '\c0%4 blasted %1 with a turret.';

$DeathMessageCTurretKill[$DamageType::BomberBombs, 0] = '\c0%1 catches %4\'s bomb in both teeth.';
$DeathMessageCTurretKill[$DamageType::BomberBombs, 1] = '\c0%4 leaves %1 a smoking bomb crater.';
$DeathMessageCTurretKill[$DamageType::BomberBombs, 2] = '\c0%4 bombs %1 back to the 20th century.';

$DeathMessageCTurretKill[$DamageType::BellyTurret, 0] = '\c0%1 eats a big helping of %4\'s belly turret bolt.';
$DeathMessageCTurretKill[$DamageType::BellyTurret, 1] = '\c0%4 plants a belly turret bolt in %1\'s belly.';
$DeathMessageCTurretKill[$DamageType::BellyTurret, 2] = '\c0%1 fails to evade %4\'s deft bomber strafing.';

$DeathMessageCTurretKill[$DamageType::TankChainGun, 0] = '\c0%1 enjoys the rich, metallic taste of %4\'s tank slug.';
$DeathMessageCTurretKill[$DamageType::TankChainGun, 1] = '\c0%4\'s tank chaingun plays sweet music all over %1.';
$DeathMessageCTurretKill[$DamageType::TankChainGun, 2] = '\c0%1 receives a stellar exit wound from %4\'s tank slug.';

$DeathMessageCTurretKill[$DamageType::TankChainGunH, 0] = '\c0%1 enjoys the rich, metallic taste of %4\'s tank slug.';
$DeathMessageCTurretKill[$DamageType::TankChainGunH, 1] = '\c0%1\'s song, la la la la la SPLAT %4\'s tank CG killed me.';
$DeathMessageCTurretKill[$DamageType::TankChainGunH, 2] = '\c0%4 opens a can of whoop ass on %1 with his tank slug.';

$DeathMessageCTurretKill[$DamageType::TankMortar, 0] = '\c0Whoops! %1 + %4\'s tank mortar = Dead %1.';
$DeathMessageCTurretKill[$DamageType::TankMortar, 1] = '\c0%1 learns the happy explosion dance from %4\'s tank mortar.';
$DeathMessageCTurretKill[$DamageType::TankMortar, 2] = '\c0%4\'s tank mortar has a blast with %1.';

$DeathMessageCTurretKill[$DamageType::ShrikeBlaster, 0] = '\c0%1 dines on a Shrike blaster sandwich, courtesy of %4.';
$DeathMessageCTurretKill[$DamageType::ShrikeBlaster, 1] = '\c0The blaster of %4\'s Shrike turns %1 into finely shredded meat.';
$DeathMessageCTurretKill[$DamageType::ShrikeBlaster, 2] = '\c0%1 gets drilled big-time by the blaster of %4\'s Shrike.';

$DeathMessageCTurretKill[$DamageType::MPBMissile, 0] = '\c0%1 intersects nicely with %4\'s MPB Missile.';
$DeathMessageCTurretKill[$DamageType::MPBMissile, 1] = '\c0%4\'s MPB Missile makes armored chowder out of %1.';
$DeathMessageCTurretKill[$DamageType::MPBMissile, 2] = '\c0%1 has a brief, explosive fling with %4\'s MPB Missile.';

$DeathMessageCTurretKill[$DamageType::Flak, 0] = '\c0%1 Gets Flanked by %4\'s Flak Turret.';
$DeathMessageCTurretKill[$DamageType::Flak, 1] = '\c0%4\'s Flak turret makes %1 cry then die.';
$DeathMessageCTurretKill[$DamageType::Flak, 2] = '\c0%1 jets to much and %4\'s Flak turret blasts him.';

$DeathMessageCTurretKill[$DamageType::Artillery, 0] = '\c0%1 gets blasted by %4\'s Artillery Turret.';
$DeathMessageCTurretKill[$DamageType::Artillery, 1] = '\c0%4 smiles as the finger from %1\'s body lands nearby.';
$DeathMessageCTurretKill[$DamageType::Artillery, 2] = '\c0%1 goes for the long pass from %4\'s Artillery Turret and CATCHES it!';

$DeathMessageCTurretKill[$DamageType::ShotDown, 0] = '\c0%4 Shots down %1.';
$DeathMessageCTurretKill[$DamageType::ShotDown, 1] = '\c0%1 crashes and burns because %4.';
$DeathMessageCTurretKill[$DamageType::ShotDown, 2] = '\c0%4 gains some anti vehicle points thanks to %1.';

$DeathMessageCTurretKill[$DamageType::ACCG, 0] = '\c0%4 CGs the shit out of %1 with an explosive CG.';
$DeathMessageCTurretKill[$DamageType::ACCG, 1] = '\c0%1 screams and runs in pansyness then %4 killed him with a supped up Chain Gun.';
$DeathMessageCTurretKill[$DamageType::ACCG, 2] = '\c0%4 lights up %1.';

$DeathMessageCTurretKill[$DamageType::PBCTurret, 0] = '\c0%4 Makes %1 bright with a PBC Turret.';
$DeathMessageCTurretKill[$DamageType::PBCTurret, 1] = '\c0%1 Gets 1,000,000 Volts From %4s PBC turret.';
$DeathMessageCTurretKill[$DamageType::PBCTurret, 2] = '\c0%4 Shocks the crap out of %1.';

$DeathMessageCTurretKill[$DamageType::TankShell, 0] = '\c0%4 Plants a Tank Shell in %1s Face.';
$DeathMessageCTurretKill[$DamageType::TankShell, 1] = '\c0%1 Enjoys Explosive Attention from %4s Tank.';
$DeathMessageCTurretKill[$DamageType::TankShell, 2] = '\c0%4 Blows %1 up with a Tank.';

$DeathMessageCTurretKill[$DamageType::Vulcan, 0] = '\c0%4 unleashes all of %6 vulcan bullets on %1.';
$DeathMessageCTurretKill[$DamageType::Vulcan, 1] = '\c0%1 gets bullets aplenty from %4.';
$DeathMessageCTurretKill[$DamageType::Vulcan, 2] = '\c0%4 shreds %1 with a vulcan cannon.';

// These Go Together
$DeathMessageCTurretKill[$DamageType::Shreder, 0] = '\c0%4 Blows %1 to pieces with a Shreder Chaingun.';
$DeathMessageCTurretKill[$DamageType::Shreder, 1] = '\c0%1 Doesnt Exist anymore... literaly thanks to %4.';
$DeathMessageCTurretKill[$DamageType::Shreder, 2] = '\c0%4 Brightly lights up %1.';
$DeathMessageCTurretKill[$DamageType::ShrederScap, 0] = '\c0%1 got hit by %4s shreder scapenel.';
$DeathMessageCTurretKill[$DamageType::ShrederScap, 1] = '\c0%1 screams and dies after being hit by %4s Shreder Scapenel.';
$DeathMessageCTurretKill[$DamageType::ShrederScap, 2] = '\c0%4 scored a range explosives kill on %1.';

$DeathMessageCTurretKill[$DamageType::bullet, 0] = '\c0%4 CGs the shit out of %1.';
$DeathMessageCTurretKill[$DamageType::bullet, 1] = '\c0%1 is put down by %4 quickly.';
$DeathMessageCTurretKill[$DamageType::bullet, 2] = '\c0%4 seriously wounds %1 ... fatally.';

$DeathMessageCTurretKill[$DamageType::MG, 0] = '\c0%4 CGs the shit out of %1.';
$DeathMessageCTurretKill[$DamageType::MG, 1] = '\c0%1 is put down by %4 quickly.';
$DeathMessageCTurretKill[$DamageType::MG, 2] = '\c0%4 seriously wounds %1 ... fatally.';

$DeathMessageCTurretKill[$DamageType::plasma, 0] = '\c0%4 napalms %1.';
$DeathMessageCTurretKill[$DamageType::plasma, 1] = '\c0%1 is cripy fried chicken thanks to our chef %4.';
$DeathMessageCTurretKill[$DamageType::plasma, 2] = '\c0%4 gives some napalm loving to %1.';

$DeathMessageCTurretKill[$DamageType::Missile, 0] = '\c0%4 gently places a missile into %1\'s face.';
$DeathMessageCTurretKill[$DamageType::Missile, 1] = '\c0%4 pops %1 with a missile.';
$DeathMessageCTurretKill[$DamageType::Missile, 2] = '\c0%4\'s missile lights up %1\'s, uh, ex-life.';

$DeathMessageTurretSelfKillCount = 3;
$DeathMessageTurretSelfKill[0] = '\c0%1 somehow kills %2self with a turret.';
$DeathMessageTurretSelfKill[1] = '\c0%1 got drunk and played with a turret.';
$DeathMessageTurretSelfKill[2] = '\c0%1 couldnt take the pressures of this bloody war.';

$DeathMessageMeteorCount = 6;
$DeathMessageMeteor[0] = '\c0%1 was killed by a meteor!';
$DeathMessageMeteor[1] = '\c0%1 caught a meteor!';
$DeathMessageMeteor[2] = '\c0%1 gets a facefull of molten meteor.';
$DeathMessageMeteor[3] = '\c0%1 gets smeared by a red hot meteor.';
$DeathMessageMeteor[4] = '\c0%1 is left a smoking crater by a meteor.';
$DeathMessageMeteor[5] = '\c0%1 learns to seek shelter when there\'s hot rock falling from the sky.';

$DeathMessageCursingCount = 2;
$DeathMessageCursing[0] = '\c0%1 was killed for saying mean nasty things.';
$DeathMessageCursing[1] = '\c0%1\'s mouth gets %2 killed again.';

$DeathMessageIdiocyCount = 2;
$DeathMessageIdiocy[0] = '\c0%1 was killed for being dumb.';
$DeathMessageIdiocy[1] = '\c0%1\'s own stupidity stops %2 cold in %3 tracks.';

$DeathMessageKillerFogCount = 4;
$DeathMessageKillerFog[0] = '\c0%1 got lost in the great beyond.';
$DeathMessageKillerFog[1] = '\c0%1 slipped and fell, never to be seen again.';
$DeathMessageKillerFog[2] = '\c0The fog of death engulfs %1.';
$DeathMessageKillerFog[3] = '\c0%1 got lost in the fog.';

$DeathMessage[$DamageType::IllegalPack, 0] = '\c0%1 tried to use an illegal pack.';
$DeathMessage[$DamageType::IllegalPack, 1] = '\c0%1 tried to use an illegal pack.';
$DeathMessage[$DamageType::IllegalPack, 2] = '\c0%1 tried to use an illegal pack.';
$DeathMessage[$DamageType::IllegalPack, 3] = '\c0%1 tried to use an illegal pack.';
$DeathMessage[$DamageType::IllegalPack, 4] = '\c0%1 tried to use an illegal pack.';

$DeathMessage[$DamageType::Drown, 0] = '\c0%1 learns people cant stay under water forever';
$DeathMessage[$DamageType::Drown, 1] = '\c0%1 drowns... embarasing right?';
$DeathMessage[$DamageType::Drown, 2] = '\c0%1 didnt know how dangerous water could be to %2';
$DeathMessage[$DamageType::Drown, 3] = '\c0%1\'s corpse is now floating on water';
$DeathMessage[$DamageType::Drown, 4] = '\c0%1 now sleeps with the fishes';

$DeathMessage[$DamageType::Zombie, 0] = '\c0%1 got sliced and diced by a zombie';
$DeathMessage[$DamageType::Zombie, 1] = '\c0%1 when attacked by something run next time';
$DeathMessage[$DamageType::Zombie, 2] = '\c0%1 wishes %2 hadnt gone to that errie town';
$DeathMessage[$DamageType::Zombie, 3] = '\c0%1\'s buddys are going to wonder what happened to %2';
$DeathMessage[$DamageType::Zombie, 4] = '\c0%1 now is in the ranks of the undead';

$DeathMessage[$DamageType::Infected, 0] = '\c0%1 is a dead soon-to-be zombie';
$DeathMessage[$DamageType::Infected, 1] = '\c0count it down 15 seconds until %1 is a zombie';
$DeathMessage[$DamageType::Infected, 2] = '\c0%1\'s life flashed before %2 eyes, but little does %2 know its not over';
$DeathMessage[$DamageType::Infected, 3] = '\c0%1\'s corpse begins to change';
$DeathMessage[$DamageType::Infected, 4] = '\c0%1 if you wondered what it was like to be undead here\'s your chance';

$DeathMessage[$DamageType::ZombieL, 0] = '\c0%1 got crushed by a Zombie Lord';
$DeathMessage[$DamageType::ZombieL, 1] = '\c0%1 Really should have hide';
$DeathMessage[$DamageType::ZombieL, 2] = '\c0%1 wishes %2 hadnt walked into the church';
$DeathMessage[$DamageType::ZombieL, 3] = '\c0%1\'s buddys are going to wonder what happened to %2';
$DeathMessage[$DamageType::ZombieL, 4] = '\c0%1 got plain out pulverised by a Zombie Lord';

$DeathMessage[$DamageType::ZAcid, 0] = '\c0%1 got crushed by a Zombie Lord';
$DeathMessage[$DamageType::ZAcid, 1] = '\c0%1 Really should have hide';
$DeathMessage[$DamageType::ZAcid, 2] = '\c0%1 wishes %2 hadnt walked into the church';
$DeathMessage[$DamageType::ZAcid, 3] = '\c0%1\'s buddys are going to wonder what happened to %2';
$DeathMessage[$DamageType::ZAcid, 4] = '\c0%1 got plain out pulverised by a Zombie Lord';

$DeathMessage[$DamageType::Burn, 0] = '\c0%1 got burned';
$DeathMessage[$DamageType::Burn, 1] = '\c0%1 thought being a marshmellow would be fun, god was he wrong.';
$DeathMessage[$DamageType::Burn, 2] = '\c0%1 ran into the burning house, sadly, he forgot his suit';
$DeathMessage[$DamageType::Burn, 3] = '\c0%1 if you were planing on being cremated. Theres no need now.';
$DeathMessage[$DamageType::Burn, 4] = '\c0%1 is to the 3rd degree';

$DeathMessage[$DamageType::ShotDown, 0] = '\c0%4 shot down %1';
$DeathMessage[$DamageType::ShotDown, 1] = '\c0%1 goes down in flames thanks to %4';
$DeathMessage[$DamageType::ShotDown, 2] = '\c0%4 causes %1\'s team to lose a valuable vehicle';
$DeathMessage[$DamageType::ShotDown, 3] = '\c0If theres a true meaning to pwn, %4 showed it to %1.';
$DeathMessage[$DamageType::ShotDown, 4] = '\c0%1 died a painful pilots death, %4';

$DeathMessage[$DamageType::SuperChaingun, 0] = '\c0%4 rips %1 up with the super chaingun.';
$DeathMessage[$DamageType::SuperChaingun, 1] = '\c0%4 happily chews %1 into pieces with %6 super chaingun.';
$DeathMessage[$DamageType::SuperChaingun, 2] = '\c0%4 administers a dose of Admin Lead to %1.';
$DeathMessage[$DamageType::SuperChaingun, 3] = '\c0%1 suffers a serious hosing from %4\'s super chaingun.';
$DeathMessage[$DamageType::SuperChaingun, 4] = '\c0%4 bestows the blessings of %6 super chaingun on %1.';

$DeathMessage[$DamageType::Phaser, 0] = '\c0%4 Burnt The Shit out of %1.';
$DeathMessage[$DamageType::Phaser, 1] = '\c0%4 Phased the crap outta %1 with his ES Phaser.';
$DeathMessage[$DamageType::Phaser, 2] = '\c0%4 administers a dose of hot plasmic energy to %1.';
$DeathMessage[$DamageType::Phaser, 3] = '\c0%1 suffers a serious burn from %4\'s phaser.';
$DeathMessage[$DamageType::Phaser, 4] = '\c0%4 unleases hot hell on %1.';

$DeathMessage[$DamageType::PhotonLaser, 0] = '\c0%4 Unleased Hot Laser Fury Upon %1.';
$DeathMessage[$DamageType::PhotonLaser, 1] = '\c0%4 gave %1 the lesson of crisping.';
$DeathMessage[$DamageType::PhotonLaser, 2] = '\c0%4 Crisped %1 to laser perfection.';
$DeathMessage[$DamageType::PhotonLaser, 3] = '\c0%1 suffers a fatal burn from %4\'s laser.';
$DeathMessage[$DamageType::PhotonLaser, 4] = '\c0%4 decided he hated %1 so he crisped him with a laser.';

$DeathMessage[$DamageType::LaserRifle, 0] = '\c0%4 hits %1 with rapid laser fire.';
$DeathMessage[$DamageType::LaserRifle, 1] = '\c0%4 gave %1 the storm of lasers.';
$DeathMessage[$DamageType::LaserRifle, 2] = '\c0%4 shot down %1 with a laser rifle.';
$DeathMessage[$DamageType::LaserRifle, 3] = '\c0%4 lazed %1, ouch....';
$DeathMessage[$DamageType::LaserRifle, 4] = '\c0%4 burned nice holes in %1 with a laser rifle.';

$DeathMessage[$DamageType::BazookaII, 0] = '\c0%4 Blasts %1 with a Enemia Rocket Launcher.';
$DeathMessage[$DamageType::BazookaII, 1] = '\c0%4 Blows up %1 with deadly explosive force.';
$DeathMessage[$DamageType::BazookaII, 2] = '\c0%4 Enemias %1 with the rocket.';
$DeathMessage[$DamageType::BazookaII, 3] = '\c0%1, if you see someone holding a rocket towards you, Run, or %4 will nail you again.';
$DeathMessage[$DamageType::BazookaII, 4] = '\c0%4 decided that %1 would be better vaporized.';

$DeathMessage[$DamageType::HArtil, 0] = '\c0%4 Blasts %1 with a Artillery shell.';
$DeathMessage[$DamageType::HArtil, 1] = '\c0%4 Bombards %1 with explosive force.';
$DeathMessage[$DamageType::HArtil, 2] = '\c0%4 Sends %1 into the pavement... Hard.';
$DeathMessage[$DamageType::HArtil, 3] = '\c0%1, When you see shells flying, Take cover or %4 will artillery you again.';
$DeathMessage[$DamageType::HArtil, 4] = '\c0%4 Paved %1 with a Artillery shell.';

$DeathMessage[$DamageType::HelicopterCGMount, 0] = '\c0%4 Blasts %1 with a hail of chaingun shells.';
$DeathMessage[$DamageType::HelicopterCGMount, 1] = '\c0%4 used a helicopter chaingun on %1.';
$DeathMessage[$DamageType::HelicopterCGMount, 2] = '\c0%4 Unleashed the power of %6 Helicopter chingun on %1.';
$DeathMessage[$DamageType::HelicopterCGMount, 3] = '\c0%1, When you see a BIG Chaingun, run or %4 will maul you again.';
$DeathMessage[$DamageType::HelicopterCGMount, 4] = '\c0%4 revved up %6 chaingun of doom upon %1.';

$DeathMessage[$DamageType::BRifle, 0] = '\c0%4 Makes %1 a Tripple Shot Offer %2 Could not Refuse.';
$DeathMessage[$DamageType::BRifle, 1] = '\c0%4 Tripples The rifle Firepower on %1.';
$DeathMessage[$DamageType::BRifle, 2] = '\c0%4 hits three holes in %1.';
$DeathMessage[$DamageType::BRifle, 3] = '\c0%1, if you thought the kerig was bad, %4 Purchased a new Battle Rifle.';
$DeathMessage[$DamageType::BRifle, 4] = '\c0%4 decided that %1 would look cooler with three holes.';

$DeathMessage[$DamageType::NukeWind, 0] = '\c0%1 was blown away by nuclear wind.';
$DeathMessage[$DamageType::NukeWind, 1] = '\c0%1 was blown away by nuclear wind.';
$DeathMessage[$DamageType::NukeWind, 2] = '\c0%1 was blown away by nuclear wind.';
$DeathMessage[$DamageType::NukeWind, 3] = '\c0%1 was blown away by nuclear wind.';
$DeathMessage[$DamageType::NukeWind, 4] = '\c0%1 was blown away by nuclear wind.';

$DeathMessage[$DamageType::Radiation, 0] = '\c0%1 Melts from Radiation Poisoning.';
$DeathMessage[$DamageType::Radiation, 1] = '\c0%1 Melts from Radiation Poisoning.';
$DeathMessage[$DamageType::Radiation, 2] = '\c0%1 Melts from Radiation Poisoning.';
$DeathMessage[$DamageType::Radiation, 3] = '\c0%1 Melts from Radiation Poisoning.';
$DeathMessage[$DamageType::Radiation, 4] = '\c0%1 Melts from Radiation Poisoning.';

$DeathMessage[$DamageType::Spiker, 0] = '\c0%4 Inserts Deadly Needles into %1.';
$DeathMessage[$DamageType::Spiker, 1] = '\c0%4 Likes the idea of "Thumb Tacking" %1.';
$DeathMessage[$DamageType::Spiker, 2] = '\c0%4 hits holes through %1, little ones.';
$DeathMessage[$DamageType::Spiker, 3] = '\c0%1, if you thought SMGs are bad, %4 just got a spiker!.';
$DeathMessage[$DamageType::Spiker, 4] = '\c0%4 decided that %1 would look cooler with spikes in him.';

$DeathMessage[$DamageType::PGC, 0] = '\c0%4 Blasts %1 with 20mm gauss shells.';
$DeathMessage[$DamageType::PGC, 1] = '\c0%4 paves %1 into the concrete with a gauss cannon.';
$DeathMessage[$DamageType::PGC, 2] = '\c0%4 Nailed a 20mm shell into %1.';
$DeathMessage[$DamageType::PGC, 3] = '\c0%1, Next time run when %4 is holding a cannon!.';
$DeathMessage[$DamageType::PGC, 4] = '\c0%4 decided that %1 would look cooler in fragments.';

$DeathMessage[$DamageType::Zappy, 0] = '\c0%1 Was slowly electrocuted to death';
$DeathMessage[$DamageType::Zappy, 1] = '\c0%1 thought glowing would be awesome, it didnt turn out that well.';
$DeathMessage[$DamageType::Zappy, 2] = '\c0%1 is now golden fried and has little static charges coming off.';
$DeathMessage[$DamageType::Zappy, 3] = '\c0%1 is on the ground.. having the IM BEING SHOCKED seisure.';
$DeathMessage[$DamageType::Zappy, 4] = '\c0%1 is to the 10000th volt';

$DeathMessage[$DamageType::VoltGun, 0] = '\c0%4 sends 10000 volts of electrical doom at %1.';
$DeathMessage[$DamageType::VoltGun, 1] = '\c0%4 unleases %6 lightning weapon of death on %1.';
$DeathMessage[$DamageType::VoltGun, 2] = '\c0%4 Electrocutes %1 with %6 Voltage Cannon.';
$DeathMessage[$DamageType::VoltGun, 3] = '\c0%4 Unleashes a violent discharge onto %1';
$DeathMessage[$DamageType::VoltGun, 4] = '\c0%4 decided that %1 would look cooler... glowing.';

$DeathMessage[$DamageType::ALSWP, 0] = '\c0%1 Dodged the first sniper shot. %4 sent 5.';
$DeathMessage[$DamageType::ALSWP, 1] = '\c0%4 hit %1 from long range, then did it again to show off.';
$DeathMessage[$DamageType::ALSWP, 2] = '\c0%4 nails %1 with %6 very quick sniper shots.';
$DeathMessage[$DamageType::ALSWP, 3] = '\c0%4 Unleashes a hail of sniper shots at %1';
$DeathMessage[$DamageType::ALSWP, 4] = '\c0%4 decided that %1 would look cooler, perforated.';

$DeathMessage[$DamageType::StMine, 0] = '\c0%4 kills %1 with a voltified mine.';
$DeathMessage[$DamageType::StMine, 1] = '\c0%1 explodes in tesla from %4\'s mine.';
$DeathMessage[$DamageType::StMine, 2] = '\c0%4 gets a voltage mine kill on %1.';
$DeathMessage[$DamageType::StMine, 3] = '\c0%1 puts his foot on %4\'s Electrical mine.';
$DeathMessage[$DamageType::StMine, 4] = '\c0One small step for %1, one giant seisure from %4.';

$DeathMessage[$DamageType::NlMine, 0] = '\c0%4 kills %1 with a flammable mine.';
$DeathMessage[$DamageType::NlMine, 1] = '\c0%1 goes up in a flammable KABOOM from %4.';
$DeathMessage[$DamageType::NlMine, 2] = '\c0%4 gets a burning sapper kill on %1.';
$DeathMessage[$DamageType::NlMine, 3] = '\c0%1 puts his foot down, then gets burnt from %4\'s mine.';
$DeathMessage[$DamageType::NlMine, 4] = '\c0One small step for %1, one giant burining explosion from %4.';

// TODO - create these
$DeathMessageSelfKill[$DamageType::SuperChaingun, 0] = '\c0%1 kills %2self with a super chaingun.';
$DeathMessageSelfKill[$DamageType::SuperChaingun, 1] = '\c0%1 catches the blast of %3 own super chaingun bullet.';
$DeathMessageSelfKill[$DamageType::SuperChaingun, 2] = '\c0%1 kills %2self with a super chaingun.';
$DeathMessageSelfKill[$DamageType::SuperChaingun, 3] = '\c0%1 catches the blast of %3 own super chaingun bullet.';
$DeathMessageSelfKill[$DamageType::SuperChaingun, 4] = '\c0%1 plays Russian roulette with %3 super chaingun.';

$DeathMessage[$DamageType::FellOff, 0] = '\c0%1 began %3 high flying sky diving career a little too close to the ground.';//
$DeathMessage[$DamageType::FellOff, 1] = '\c0%1 must have thougt staying close to the edge was a great idea.';//
$DeathMessage[$DamageType::FellOff, 2] = '\c0%1 now realizes that gravity is the law, and everyone must obey it.';//
$DeathMessage[$DamageType::FellOff, 3] = '\c0%1 has sacrificed %3 life to help fertilize the ground with %3 spinal fluid.';//
$DeathMessage[$DamageType::FellOff, 4] = '\c0%1 takes a nice long trip down the edge.';//
