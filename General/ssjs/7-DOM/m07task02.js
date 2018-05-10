// Task02
// Using JavaScript and DOM hide hide second and third paragraphs 
// of target HTML document, all other elements should be visible

function m07task02() {
  // TODO: place your code here
  try{
    var ourElements = document.getElementsByClassName("test");
    
    for (let index = 0; index < ourElements.length; index++) {
      var element = ourElements[index];
      element.style.visibility = "hidden";
    }
  }
  catch(err)
  {
    console.warn("Cannot hide our elements: " + err.message);
  }

}