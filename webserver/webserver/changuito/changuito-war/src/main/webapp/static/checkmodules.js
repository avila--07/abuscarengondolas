
function checkmp() {
var checkboxMp = document.getElementById("modpago");
var checkboxMv = document.getElementById("modvuelto");

   if(checkboxMp.checked==false){
       checkboxMv.checked=false;
         };
};


function checkmv() {
var checkboxMp = document.getElementById("modpago");
var checkboxMv = document.getElementById("modvuelto");

   if(checkboxMv.checked==true){
       checkboxMp.checked=true;
         };
};