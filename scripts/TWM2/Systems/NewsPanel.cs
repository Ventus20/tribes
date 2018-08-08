function DownloadNewsPage() {
   $TWM::Ticks = 0;
   %server = "www.public.phantomdev.net:80"; //
   if (!isObject(PageGrabber))
      %Downloader = new HTTPObject(PageGrabber){};
   else %Downloader = PageGrabber;
   %filename = "/SMF/index.php/topic,422.0.html"; //File Location
   %Downloader.get(%server, %filename);
}

function PageGrabber::onLine(%this, %line) {
   %line = StrReplace(%line, "<br />", "");
   if (strstr(%line, "*Start") != -1) {
      AffixNews(%line);
   }
}

function AffixNews(%text) {
   //
   %moduPosition = strPos(%text, "%"); //gets first occurance
   %text = getSubStr(%text, %moduPosition+1, (strlen(%text)));
   %moduPosition = strPos(%text, "%"); //gets first occurance
   %i = 0;
   while(%moduPosition != -1) {
      %text[%i] = getSubStr(%text, 0, %moduPosition);
      %text = getSubStr(%text, %moduPosition+1, (strlen(%text)));
      %moduPosition = strPos(%text, "%"); //gets first occurance
      //
      %i++;
   }
   %text = StrReplace(%text, "%", "");
   %x = 0;
   while(isSet(%text[%x])) {
      echo(%text[%x]);
      AddToNewsPage(%text[%x]);
      %x++;
   }
}

function AddToNewsPage(%line) {
   %line = detag( %line );
   %text = (%text $= "") ? %line : %text NL %line;
   $TWM::Ticks++;
   $TWM::Page[$TWM::Ticks] = ""@%text@"";
}

function PageGrabber::onConnectFailed() {
   echo("-- Could not connect to server.");
   echo("Using Page Specified In NewsPanel.cs");

   $TWM::Ticks = 2;
   $TWM::Page[1] = "Welcome To "@$Host::GameName@"";
   $TWM::Page[2] = "Total Warfare Mod 2 V"@$TWM::Version@"";

}

function PageGrabber::onDisconnect(%this) {
   %this.delete();
}

