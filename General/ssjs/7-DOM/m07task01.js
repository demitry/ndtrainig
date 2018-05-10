// Task01 
// Using JavaScript and DOM hide first paragraph 
// of target HTML document, all other elements should be visible

function m07task01() {
  // TODO: place your code here
  try{
    var ourElement = document.getElementById("test");
    if(ourElement !== undefined)
    {
      ourElement.style.visibility = "hidden";
    }
  }
  catch(err)
  {
    console.warn("Cannot hide our element: " + err.message);
  }
}