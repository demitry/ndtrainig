// Task02 - you are given a string which contains multiple numbers (integer and floating points).
// Your task is to extract all numbers from a string and return them in an array in such order as they are met in a string.
// Dot (".") is used as a separator between integer and decimal portion of the nubmer.
// Numbers that are used as part of a word should also be extracted (like 2nd or 3rd).
// Return 'null' if string has no numbers
// Sample:
// inputString: "Hello 2.15 digital World 5,3"
// Result array of 3 elements: [2.15, 5, 3]

function task02(inputString) {
    // TODO: Write your code here
    let numberPattern = /[+-]?([0-9]*[.])?([0-9]+(st|nd|rd){0,1})/gm;
    return inputString.match( numberPattern );
}

console.log(task02("Hello 2.15 digital World 5,3"));
console.log(" Test \"Hello 2.15 digital World 5,3\":\t\t " + task02("Hello 2.15 digital World 5,3"));
console.log(" Test \"1st, 2nd, 3rd:\"\t\t" + task02("1st, 2nd, 3rd"));
console.log(" Test \"adsfasdfasdfasdfa\"\t\t" + task02("adsfasdfasdfasdfa"));
