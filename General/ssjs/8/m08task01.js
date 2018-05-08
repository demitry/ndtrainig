// Task01 - create regular expression which tests for corectness phone numbers.
// Phone number should have 10 digits optionally divided to 3-digit groups by periods ("."), dashes ("-"),
// brackets ("()"), or space symbols (" "). Brackets should be used only at the beginning
// Examples of correct phone numbers:
// (123) 456 7899
// (123).456.7899
// (123)-456-7899
// 123-456-7899
// 123 456 7899
// 1234567899

function task01(testNumber) {
    // TODO: Define your regular expression here, test "testNumber" string and return function result as boolean
    let re = /\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/;
    return re.test(testNumber);
}

task01();

console.log("---- Positive Test: ");
console.log("Test (123) 456 7899: \t" + task01("(123) 456 7899"));
console.log("Test (123).456.7899: \t" + task01("(123).456.7899"));
console.log("Test (123)-456-7899: \t" + task01("(123)-456-7899"));
console.log("Test 123-456-7899: \t" + task01("123-456-7899"));
console.log("Test 123 456 7899: \t" + task01("123 456 7899"));
console.log("Test 1234567899: \t" + task01("1234567899"));

console.log("---- Negative Test: ");

console.log("Test ABD3563533: \t" + task01("ABD3563533"));
console.log("Test ()()(werjwk)): \t" + task01("()()(werjwk))"));
