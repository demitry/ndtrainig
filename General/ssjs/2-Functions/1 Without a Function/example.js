 var i, base, power, result;

 base = 2; 
 power = 3; 
 result = 1; 

 for(i = 0; i < power; i++) {
     result *= base;
 }
 console.log("2^3 = " + result);

 base = 3; 
 power = 4; 
 result = 1; 

 for(i = 0; i < power; i++) {
     result *= base;
 }
 console.log("3^4 = " + result);

 base = 5; 
 power = 2; 
 result = 1; 

 for(i = 0; i < power; i++) {
     result *= base;
 }
 console.log("5^2 = " + result);
