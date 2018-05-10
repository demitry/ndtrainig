// Task01 - create a function with name task01
// function pass three numbers and multiples those that less than zero
// if all numbers are positive function should return undefined
// for example: 
// if function take 3, -2 and -5 it should return 10

// TODO: Define your function here

function task01(first, second, third) {
    var lessThanZeroArray = [];
    var result = 1;
    for (let index = 0; index < arguments.length; index++) {
        const element = arguments[index];
        if (element < 0) {
            lessThanZeroArray.push(element);
        }
    }
    for (let index = 0; index < lessThanZeroArray.length; index++) {
        const element = lessThanZeroArray[index];
        result *= element;
    }

    return result;
}

function task01b(first, second, third) {
    // or could be solved with filter and reduce:
    return Array.from(arguments).filter(item => item < 0).reduce(function(a, b) { return a * b; });
}


console.log(task01(2, -2, -5));
console.log(task01b(2, -2, -5));