//Torque Script Math Library
//Phantom139

//Feel free to use this wherever you need it, I really don't mind

//Vector Mathematics
function VectorComponent(%initialPoint, %terminalPoint) {
   if(getWordCount(%initialPoint) != getWordCount(%terminalPoint)) {
      error("VectorComponent: Invalid point lineup, Initial count != terminal count");
   }
   for(%i = 0; %i < getWordCount(%initialPoint); %i++) {
      %initial[%i] = getWord(%initialPoint, %i);
      %terminal[%i] = getWord(%terminalPoint, %i);
      //
      if(%i == 0) {
         %vector = (%terminal[%i] - %initial[%i]);
      }
      else {
         %vector = %vector SPC (%terminal[%i] - %initial[%i]);
      }
   }
   return %vector;
}

//3D Graph Solution
//Draws 3D curves based on "z"

function attenuateMathFunc(%equation) {
   //pattern search
   %equation = strReplace(%equation, "sin*", "msin");
   %equation = strReplace(%equation, "cos*", "mcos");
   %equation = strReplace(%equation, "tan*", "mtan");
   %equation = strReplace(%equation, "asin*", "masin");
   %equation = strReplace(%equation, "acos*", "macos");
   %equation = strReplace(%equation, "atan*", "matan");
   %equation = strReplace(%equation, "sqrt*", "msqrt");
   %equation = strReplace(%equation, "abs*", "mabs");
   //
   return %equation;
}

//Solver3d solves the 3d equation at the given points
function Solver3d(%zEquation, %x, %y) {
   strReplace(%zEquation, " ", "");
   strReplace(%zEquation, "z=", "");
   //
   //echo(%zEquation);
   //read the Z-Equation
   %eLength = strlen(%zEquation);
   for(%i = 0; %i < %eLength; %i++) {
      %char[%i] = getSubStr(%zEquation, %i, 1);
      if(strcmp(%char[%i], "(") == 0 && strcmp(%char[%i-1], "*") != 0) {
         %char[%i] = "*(";
         %eLength++;
      }
      //if(strcmp(%char[%i], ")") == 0) {
      //   %char[%i] = " ";
      //}
      //echo(%char[%i]);
   }
   //
   for(%r = 0; %r < %eLength; %r++) {
      //operators
      if(strcmp(%char[%r], "^") == 0) {
         %char[%r] = "mpow("@%char[%r-1]@", "@%char[%r+1]@")";
         %char[%r-1] = " ";
         %char[%r+1] = " ";
      }
      if(strcmp(%char[%r], "x") == 0) {
         //echo(%i@" -> x replace");
         %char[%r] = 1*%x; // replace with the operation
      }
      //
      else if(strcmp(%char[%r], "y") == 0) {
         //echo(%i@" -> y replace");
         %char[%r] = 1*%y; // replace with the operation
      }
   }
   //rewrite the solution
   %solution = "";
   %store = "";        //prevent scope error if eval fails to compile
   %rewrt = 0;
   while(isSet(%char[%rewrt])) {
      %solution = %solution@%char[%rewrt];
      %rewrt++;
   }
   %solution = attenuateMathFunc(%solution);
   echo(%solution);
   //eval
   eval("%store = "@%solution@";");
   return %store;
}

//think of this as an xMax x yMax grid
function Graph3D(%client, %equation, %xMax, %yMax) {
   MessageAll('msgAdminForce', "\c3Graphing 3D Equation: "@%client.namebase@" -> "@%xMax@"x"@%yMax@" GRID : "@%equation@"");
   %player = %client.player;
   if(!isAlive(%player)) {
      echo("specified player is dead");
      return;
   }
   %position = %player.getPosition();
   %position = vectorAdd(%position, "0 0 50");
   //
   for(%x = -1*(%xMax); %x < %xMax; %x++) {
      for(%y = -1*(%yMax); %y < %yMax; %y++) {
         %solution = Solver3d(%equation, %x, %y);
         //draw our little piece
         %xPiece = getWord(%position, 0) + %x;
         %yPiece = getWord(%position, 1) + %y;
         %zPiece = getWord(%position, 2) + %solution;
         echo(%solution TAB (%solution+%zPiece));
         %Pad = new StaticShape() {
             dataBlock = DeployedSpine;
             scale = ".3 .3 .3";
             position = %xPiece SPC %yPiece SPC %zPiece;
         };
         %pad.setOwner(%client);
         Deployables.add(%Pad);
         echo(%position @"   "@ %Pad.getPosition() TAB %xPiece SPC %yPiece SPC %zPiece);
         //
         %pad.setPosition(%xPiece SPC %yPiece SPC %zPiece);
      }
   }
}
