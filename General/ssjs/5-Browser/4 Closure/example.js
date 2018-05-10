var pi = getPi();

window.addEventListener("load", init, false);

function init () {   
   test.addEventListener("click", action, true);   
}

function action () {
    var s, r, message;
    
	r = input.value;
	
 	s = pi()*r*r;
	
	message = "Suare is " + s;
	output.innerHTML = message;
}

function getPi () {
    var value = 3.14;
    
	return function () {
	     return value;
    };
}
