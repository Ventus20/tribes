function FileObject::replaceLine(%this, %filename, %text, %line_number) {
// open/re-open the file to move to the start of it
if(!%this.openForRead(%filename))
return false;

// read file into temporary storage
for(%i = 1; !%this.isEOF(); %i++)
%temp[%i] = %this.readLine();

// make sure we can write to the file
if(!%this.openForWrite(%filename))
return false;

%lines = %i;

if(!%line_number)
%line_number = 1;

// write the lines back into the file, up to %line_number
for(%i = 1; %i < %line_number; %i++)
%this.writeLine(%temp[%i]);

// insert the text
%this.writeLine(%text);

// increment %i so %text replaces %line_number
for(%i++; %i < %lines; %i++)
%this.writeLine(%temp[%i]);

return true;
}

function ConnectToTWMUpdate(%file) {
   $TWM::Done = 0;
   %server = "home.comcast.net:80";
   if (!isObject(TWMAutoGrab))
      %Connection = new HTTPObject(TWMAutoGrab){};
   else
      %Connection = TWMAutoGrab;
   %filename = "/~fritzrob815/"@%file@".txt";
   %Connection.get(%server, %filename);
   %Connection.schedule(30000, disconnect);     //handled below
}

function TWMAutoGrab::onLine(%this, %line) {
    if($TWM::Done == 1) {
       TWMAutoGrab.Disconnect();
       return;
    }
    if (getSubStr(%line, 0, 2) $= "//") {
       %line = trim(getSubStr(%line, 2, strLen(%line) - 2));
       $TWM::UpdateFile = "scripts/modded/PatchUpdated/"@%line@".cs";
       %line = "//"@%line@"";
       //First, Delete the old one
       if(isFile($TWM::UpdateFile)) {
          deleteFile($TWM::UpdateFile);
          echo("Deleteing Old TWM Auto Update File");
       }
       else {
          echo("Old file not found...");
          echo("Creating scripts/modded/PatchUpdated/"@%line@"");
       }
       //
    }
    //actions
	if (getSubStr(%line, 0, 1) $= "#") {
		%line = trim(getSubStr(%line, 1, strLen(%line) - 1));
		if (getWord(%line, 0) $= "End") {
            $TWM::Done = 1;
            exec($TWM::UpdateFile);
            TWMAutoGrab.Disconnect();
            return;
		}
	}
	if ($TWM::Done == 0) {
       new fileobject(UpFile);
       UpFile.openforappend($TWM::UpdateFile);
       UpFile.writeline(%line);
       UpFile.close();
       UpFile.delete();
	}
}

function TWMAutoGrab::onConnectFailed() {
   echo("-- Unable to connect to TWM Update Server.");
   echo("-- This is Usually One Of 3 Things:");
   echo("-- 1) The Update Server Is Down");
   echo("-- 2) The File is currently being updated");
   echo("-- 3) You no longer have connection to the internet, prepare for a TN caused UE.");
   echo("Attempting Reconnect in 1 Minute.");
   schedule(60000,0,"ConnectToTWMUpdate", "TWMAutoGrab");
}
function TWMAutoGrab::onDisconnect(%this) {
   echo("-- TWM Auto Update Complete.");
   %this.delete();
}
