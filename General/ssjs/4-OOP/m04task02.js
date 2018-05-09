// Task02 - Create constructor Cat reproducing it objects
// constructor should set 2 parameters - name and color
// and  use it as an object attributes 

function task02(color, name) {
    return new Cat(color, name); // don't change this code
}

// TODO: Define your constructor here 
function Cat(color, name) {
    this.color = color;
    this.name = name;
}

console.log(task02("white", "Bobby"));