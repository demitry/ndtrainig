// Task03 - create a function with name task03
// function pass array and retun hash with min amd max values from array
// for example: 
// if function take [-1, 8, -3, 0, 7] it should return {min: -3, max: 8}

// TODO: Define your function here
function task03(array) {
    var minimum = Math.min.apply(null, array);
    var maximum = Math.max.apply(null, array);
    return { "min": minimum, "max": maximum };
}

var array = [12, 53, 12, -67, -84, 234, 644, 64, -22, 32, 2];
console.log(task03(array));