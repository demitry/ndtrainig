 function someFunction () {
     console.log("You never see this text in console!" );
 }
 
 var someFunction = function () {
             console.log("You should see this text in console \nIf you don't see this text somebody dead in the forest :)\n" );
         };
 
 someFunction();
 
 console.warn("Pay attention that expression way of function creation rewrite function created by declaration way!");
 