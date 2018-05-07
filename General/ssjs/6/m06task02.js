// Task02
// Your task is to create function that returns square number of an argument
// Function should check if argument is incorrect and return two different
// exceptions as instances of Error object:
// 'missing parameter' if argument is not initializated
// 'parameter is not a number' if argument is Nan

function m06task02(arg) {
  // TODO: write your solution here
  if(arg === undefined) 
  {
    throw new Error('missing parameter');
  }

  if(isNaN(arg))
  {
    throw new Error('parameter is not a number');
  }
  return arg*arg;
}


function test()
{
  try
  {
    m06task02()
  }
  catch(err)
  {
    console.warn("Error: " + err.message);
  }

  try
  {
    m06task02(NaN)
  }
  catch(err)
  {
    console.warn("Error: " + err.message);
  }

}

test();

