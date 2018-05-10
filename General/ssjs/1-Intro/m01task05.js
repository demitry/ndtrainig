// Task05 - Write a code that take 3 digits and create string - 
// -- first and second should be add and it sum concatenate with third digit as a string
// Use coma (",") as a separator
// For example: 
// Inputed value are 2, 5 and 7
// You should return a next string - "7,7"

function task05(first, second, third) {
    return (first + second).toString() + "," + third.toString();
}