var clicks;

window.addEventListener("load", init, false);

function init () {
   clicks = 0;
   test.addEventListener("click", action, false);
}

function action () {
   clicks++;
   result.innerHTML = "Button was clicked " + clicks + " times";
}