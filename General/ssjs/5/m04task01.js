// Task01 - Create a simple function that will be used as event handler. 
// function should cancel event bubbling

function task01() {
    // TODO: Define your object here   
    return function (e) {
        e = e || window.event;
        e.stopPropagation();
        alert("Event Propagation is stopped, bubbling and capturing is disabled");
    };
}