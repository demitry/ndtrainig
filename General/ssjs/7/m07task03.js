// Task03 
// Using JavaScript and DOM create click event handler for Button that 
// replaces content of a paragraph 4 with a number 42

function m07task03() {
  // TODO: place your code here
  var ourButton = document.getElementById("testButton");
  if(ourButton !== undefined)
  {
    ourButton.onclick = function () {
      var ourLastParagraph = document.getElementById("last");
      if(ourLastParagraph !== undefined)
      {
        ourLastParagraph.innerHTML = 42;
      }
    }
  }
}