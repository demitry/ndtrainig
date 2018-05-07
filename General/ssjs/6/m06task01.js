// Task01 
// Your task is to check if arument is undefined and if it is true, 
// throw an exception of type Error with message 'missing parameter'

function m06task01(arg) {
  // TODO: write your solution here
  if(arg === undefined)
  {
    throw new Error('missing parameter');
  }
}

function test() {
  try{
    m06task01();
  }
  catch(err)
  {
    console.warn("Error: " + err.message);
  }
}

test();