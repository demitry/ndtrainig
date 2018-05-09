 var i, base, power, result;

 base = 2; 
 power = 3; 

 pow();
 console.log("2^3 = " + result);

 base = 3; 
 power = 4; 

 pow();
 console.log("3^4 = " + result);

 base = 5; 
 power = 2; 
 
 pow();
 console.log("5^2 = " + result);

 /* you first function :) */
 function pow () {
    result = 1; 
    for(i = 0; i < power; i++) {
        result *= base;
    }
 }
 