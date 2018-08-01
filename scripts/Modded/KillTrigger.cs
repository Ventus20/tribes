datablock TriggerData(deathTrigger) {
   tickPeriodMS = 1000;
};

function deathTrigger::onEnterTrigger(%data, %obj, %colObj) {
   if(!isObject(%colObj) || %colObj.getState() $= "dead") {
      return;
   }
   %colObj.scriptkill($DamageType::FellOff);
}
function deathTrigger::onLeaveTrigger(%data, %obj, %colObj) {
//Nothing
}

function deathTrigger::onTickTrigger(%data, %obj, %colObj) {
//Nothing
}
