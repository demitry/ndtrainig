window.addEventListener("load", init, false);

function init () {   
   red.addEventListener("click", getHandler("red", "capturing"), true);
   green.addEventListener("click", getHandler("green", "capturing"), true);
   blue.addEventListener("click", getHandler("blue", "capturing"), true);
   
   red.addEventListener("click", getHandler("red", "bubbling"), false);
   green.addEventListener("click", getHandler("green", "bubbling"), false);
   blue.addEventListener("click", getHandler("blue", "bubbling"), false);


   red2.addEventListener("click", task01(), true);
   green2.addEventListener("click", task01(), true);
   blue2.addEventListener("click", task01(), true);
   
   red2.addEventListener("click", task01(), false);
   green2.addEventListener("click", task01(), false);
   blue2.addEventListener("click", task01(), false);

}

function getHandler (el, phase) {
   return function (e) {
       action(el, phase, e);
   };
}

function action (el, phase, e) {
    var answer, message, stop = false;
	
	message = "[Phase: " + phase + "]\nEvent now in " + el + " element";
	answer = confirm(message);
	
	if(answer === stop) {
	    e.stopPropagation();
	}
}

function task01() {
    // TODO: Define your object here   
    return function (e) {
        e = e || window.event;
        e.stopPropagation();
        alert("Event Propagation is stopped");
    };
}

function action2 (el, phase, e) {
    //var answer, message, stop = false;
	
	message = "[Phase: " + phase + "]\nEvent now in " + el + " element";
	answer = confirm(message);
	
	if(answer === stop) {
	    e.stopPropagation();
	}
}