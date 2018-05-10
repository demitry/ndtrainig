// Task01 
// Create a function that makes Ajax request to URL passed as parameter
// Server returns data in JSON format, ready property "name" of data file
// and write it to span with ID "target" of a document "target.html"
// Note: function may use jQuery

// Arguments:
// Function accepts one argument, a string with URL to request

// Return result:
// Function should not return any data, it should write to span element 
// with ID "target"

function m10task01(targetURL) {
    //1.
    /*
    var xhr = createXHRobj();
    xhr.open("GET", targetURL, true);
    xhr.onreadystatechange = function(){
      if (xhr.readyState === 4)  // request completed
      {
        if (xhr.status === 200) 
        {
          console.log(xhr.responseText);
          var object = JSON.parse( xhr.responseText );
          console.log(object);
          document.getElementById("target").innerHTML =
            "<p>" + "Our Object Name:" + object.data.name + "</p>" + 
            "<p>" + "Our Object ID:" + object.data.id + "</p>" + 
            "<p>" + "Our Object Year:" + object.data.year + "</p>" + 
            "<p>" + "Our Object Color:" + object.data.color + "</p>" + 
            "<p>" + "Our Object pantone_value:" + object.data.pantone_value + "</p>";
        }
      }
    }
    xhr.send();
    */

    //2.
    $.ajax({
        url: targetURL,
        type: "GET",
        success: function(response){
            console.log(response);
            document.getElementById("target").innerHTML =
            "<p>" + "Our Object Name:" + response.data.name + "</p>" + 
            "<p>" + "Our Object ID:" + response.data.id + "</p>" + 
            "<p>" + "Our Object Year:" + response.data.year + "</p>" + 
            "<p>" + "Our Object Color:" + response.data.color + "</p>" + 
            "<p>" + "Our Object pantone_value:" + response.data.pantone_value + "</p>";
        }
    });
}

function createXHRobj() {
    req = null
    if (window.XMLHttpRequest)
      req = new XMLHttpRequest()  // browsers besides IE
    else if (window.ActiveXObject)
      req = new ActiveXObject("Microsoft.XMLHTTP")  // IE
    else
      alert("Could not create XHR obj!")
    return req
  }
