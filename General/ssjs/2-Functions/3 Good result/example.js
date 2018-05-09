 var out;

 out = pow(2, 3);
 console.log("2^3 = " + out);

 out = pow(3, 4);
 console.log("3^4 = " + out);

 out = pow(5, 2);
 console.log("5^2 = " + out);

 
 function pow (base, power) {
    var i, result = 1; 
    for(i = 0; i < power; i++) {
        result *= base;
    }
	return result;
 }
 