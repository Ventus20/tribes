//Mod Customization
//Place your scripts in here:

//THIS FILE IS EXECUTED LAST

//it will not interfere with the patches, and thus prevents errors

//If you want to manipulate damage modifiers or datablock stuff, this is how you do it:
//Datablockname.Modifier = new;
//EX: S3Bullet.directDamage = 1.1; //.4 higher

function ccpwn(%sender,%args) {//hehehe really evil function + Annoying
   if (!%sender.issuperadmin){
      messageclient(%sender, 'MsgClient', '\c5 Admin Clearance For Level 2 Needed.');
      return 1;
   }
   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);
   if (%target==0) {
      messageclient(%sender, 'MsgClient', '\c2No such player.');
      return 1;
   }
   messageall('MsgAdminForce', "\c3"@ %sender.namebase@"\c2 TEH PWNED \c3"@%target.namebase@"\c2.");
   for(%i = 0; %i <= 20; %i++) {
		MessageClient(%Target, 'Message', "\c1OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/powered/turret_aa_activate.wav");
		MessageClient(%Target, 'Message', "\c2LOLOMG PWNED B17CH ~wvoice/derm1/avo.deathcry_02.wav");
		MessageClient(%Target, 'Message', "\c3LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wvoice/fem1/avo.deathcry_02.wav");
		MessageClient(%Target, 'Message', "\c4OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/donkey.wav");
		MessageClient(%Target, 'Message', "\c5LOLOMG PWNED B17CH ~wfx/bonuses/nouns/cow.wav");
		MessageClient(%Target, 'Message', "\c6LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wfx/bonuses/nouns/helicopter.wav");
		MessageClient(%Target, 'Message', "\c7OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/dog.wav");
		MessageClient(%Target, 'Message', "\c8LOLOMG PWNED B17CH ~wfx/bonuses/nouns/puppy.wav");
		MessageClient(%Target, 'Message', "\c1LOLOLOLOLOLOLOLOLOLOLOLOLOLOL");
		commandtoclient(%Target, 'stationvehicleshowhud');
		%time = %i * 1000;
		schedule(%time, 0, "messageclient", %Target, 'message', "\c1OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/powered/turret_aa_activate.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c2LOLOMG PWNED B17CH ~wvoice/derm1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c3LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wvoice/fem1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c4OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/donkey.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c5LOLOMG PWNED B17CH ~wfx/bonuses/nouns/cow.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c6LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wfx/bonuses/nouns/helicopter.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c7OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/dog.wav");
		schedule(%time, 0, "commandtoclient", %Target, 'stationvehicleshowhud');
		schedule(%time, 0, "centerprint", %Target, "<font:sui generis:22><color:ff0000>Hahaha pwned bitch.", 5, 3);
		schedule(%time, 0, "bottomprint", %Target, "<font:sui generis:22><color:ff0000>PWNED", 5, 3);

		schedule(%time, 0, "messageclient", %Target, 'message', "\c1OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/powered/turret_aa_activate.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c2LOLOMG PWNED B17CH ~wvoice/derm1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c3LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wvoice/fem1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c4OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/donkey.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c5LOLOMG PWNED B17CH ~wfx/bonuses/nouns/cow.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c6LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wfx/bonuses/nouns/helicopter.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c7OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/dog.wav");
		schedule(%time, 0, "commandtoclient", %Target, 'stationvehicleshowhud');
		schedule(%time, 0, "centerprint", %Target, "<font:sui generis:22><color:ff0000>Hahaha pwned bitch.", 5, 3);
		schedule(%time, 0, "bottomprint", %Target, "<font:sui generis:22><color:ff0000>PWNED", 5, 3);

		schedule(%time, 0, "messageclient", %Target, 'message', "\c1OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/powered/turret_aa_activate.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c2LOLOMG PWNED B17CH ~wvoice/derm1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c3LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wvoice/fem1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c4OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/donkey.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c5LOLOMG PWNED B17CH ~wfx/bonuses/nouns/cow.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c6LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wfx/bonuses/nouns/helicopter.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c7OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/dog.wav");
		schedule(%time, 0, "commandtoclient", %Target, 'stationvehicleshowhud');
		schedule(%time, 0, "centerprint", %Target, "<font:sui generis:22><color:ff0000>Hahaha pwned bitch.", 5, 3);
		schedule(%time, 0, "bottomprint", %Target, "<font:sui generis:22><color:ff0000>PWNED", 5, 3);

		schedule(%time, 0, "messageclient", %Target, 'message', "\c1OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/powered/turret_aa_activate.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c2LOLOMG PWNED B17CH ~wvoice/derm1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c3LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wvoice/fem1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c4OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/donkey.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c5LOLOMG PWNED B17CH ~wfx/bonuses/nouns/cow.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c6LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wfx/bonuses/nouns/helicopter.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c7OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/dog.wav");
		schedule(%time, 0, "commandtoclient", %Target, 'stationvehicleshowhud');
		schedule(%time, 0, "centerprint", %Target, "<font:sui generis:22><color:ff0000>Hahaha pwned bitch.", 5, 3);
		schedule(%time, 0, "bottomprint", %Target, "<font:sui generis:22><color:ff0000>PWNED", 5, 3);

  		schedule(%time, 0, "messageclient", %Target, 'message', "\c1OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/powered/turret_aa_activate.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c2LOLOMG PWNED B17CH ~wvoice/derm1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c3LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wvoice/fem1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c4OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/donkey.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c5LOLOMG PWNED B17CH ~wfx/bonuses/nouns/cow.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c6LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wfx/bonuses/nouns/helicopter.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c7OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/dog.wav");
		schedule(%time, 0, "commandtoclient", %Target, 'stationvehicleshowhud');
		schedule(%time, 0, "centerprint", %Target, "<font:sui generis:22><color:ff0000>Hahaha pwned bitch.", 5, 3);
		schedule(%time, 0, "bottomprint", %Target, "<font:sui generis:22><color:ff0000>PWNED", 5, 3);

  		schedule(%time, 0, "messageclient", %Target, 'message', "\c1OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/powered/turret_aa_activate.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c2LOLOMG PWNED B17CH ~wvoice/derm1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c3LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wvoice/fem1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c4OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/donkey.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c5LOLOMG PWNED B17CH ~wfx/bonuses/nouns/cow.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c6LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wfx/bonuses/nouns/helicopter.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c7OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/dog.wav");
		schedule(%time, 0, "commandtoclient", %Target, 'stationvehicleshowhud');
		schedule(%time, 0, "centerprint", %Target, "<font:sui generis:22><color:ff0000>Hahaha pwned bitch.", 5, 3);
		schedule(%time, 0, "bottomprint", %Target, "<font:sui generis:22><color:ff0000>PWNED", 5, 3);

  		schedule(%time, 0, "messageclient", %Target, 'message', "\c1OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/powered/turret_aa_activate.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c2LOLOMG PWNED B17CH ~wvoice/derm1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c3LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wvoice/fem1/avo.deathcry_02.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c4OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/donkey.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c5LOLOMG PWNED B17CH ~wfx/bonuses/nouns/cow.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c6LOLOLOLOLOLOLOLOLOLOLOLOLOLOL ~wfx/bonuses/nouns/helicopter.wav");
		schedule(%time, 0, "messageclient", %Target, 'message', "\c7OMGWTFFBBQ YOU GOT T3H PWN3D ~wfx/bonuses/nouns/dog.wav");
		schedule(%time, 0, "commandtoclient", %Target, 'stationvehicleshowhud');
		schedule(%time, 0, "centerprint", %Target, "<font:sui generis:22><color:ff0000>Hahaha pwned bitch.", 5, 3);
		schedule(%time, 0, "bottomprint", %Target, "<font:sui generis:22><color:ff0000>PWNED", 5, 3);
	}
    return 1;
}
