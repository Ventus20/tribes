$ServDate::ExpliDate = 20081225;                // For Future Releases
$ServDate::ActExpliDate = "12-25-2008";         // See Above
//Date System, Informs players when the server first went up.
function DateServer() {
   if(!$ServDate::ServerDated) {
   $ServDate::StartDate = ""@formattimestring("mm-dd-yy")@"";
   $ServDate::ServerDated = 1;
   echo("Server Dated as started on "@$ServDate::StartDate@".");
   }
   else {
   error("Server Dating Completed, Server Started on "@$ServDate::StartDate@"");
   }
   export( "$ServDate::*", "prefs/ServerDate.cs", false );
}

function CheckDate() {
$ServDate::Current = ""@formattimestring("yy mm dd")@"";
%year = getword($ServDate::Current,0);
%month = getword($ServDate::Current,1);
%day = getword($ServDate::Current,2);
$ServDate::CurCheck = ""@%year@""@%month@""@%day@"";
echo($ServDate::CurCheck);
return $ServDate::CurCheck;
}


//NOTE NOTE NOTE NOTE NOTE NOTE
// This function is used to actually evaluate the current date
// To the Expl. Date. Because This Version Has Not Expl. Date
// You do not have to edit anything on this script, thanks
// Phantom139, Enjoy the Mod.

function EvalDate() {
%current = CheckDate();
if(%current > $ServDate::ExpliDate) {
error("You are running TWM");
error("Created By Phantom139, Dark Dragon DX, DarknessofLight, Deadsoldier");
error("This Version Does Not Expire.");
//error("ATTENTION: You are running a server version that has expired");
//error("Please Contact the Developers of the mod or find a newer version");
//destroyServer();
}
else {
error("You are running TWM");
error("Created By Phantom139, Dark Dragon DX, DarknessofLight, Deadsoldier");
error("This Version Does Not Expire.");
}
}

//Now The Fun Stuff, Actually killing the serv
package DateCheck {
function checkMissionStart() {
//Do This STuff!
EvalDate();

Parent::checkMissionStart();
}
};
ActivatePackage(DateCheck);
