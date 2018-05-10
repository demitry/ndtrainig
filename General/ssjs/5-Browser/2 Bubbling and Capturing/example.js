window.addEventListener("load", init, false);

function init() {
    red.addEventListener("click", getHandler("red", "capturing"), true);
    green.addEventListener("click", getHandler("green", "capturing"), true);
    blue.addEventListener("click", getHandler("blue", "capturing"), true);

    red.addEventListener("click", getHandler("red", "bubbling"), false);
    green.addEventListener("click", getHandler("green", "bubbling"), false);
    blue.addEventListener("click", getHandler("blue", "bubbling"), false);
}

function getHandler(el, phase) {
    return function () {
        action(el, phase);
    };
}

function action (el, phase) {
  var message = "[Phase: " + phase + "]\nEvent now in " + el + " element";
  alert(message);
}
