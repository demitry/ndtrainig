// Task02 - create a function with name task02
// function pass array and replace each negative number on 0 and other numbers on 1
// for example: 
// if function take array [-1, 8, -3, 0, 7] it should return [0, 1, 0, 1, 1]

// TODO: Define your function here
function task02(array) {

    for (let index = 0; index < array.length; index++) {
        array[index] = array[index] < 0 ? 0 : 1;
    }
    console.log(array);
    return array;
}

var array = [6, 6, 3, 4, -1, 0, -123, -13];
task02(array);