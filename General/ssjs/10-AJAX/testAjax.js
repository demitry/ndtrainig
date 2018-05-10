
$(document).ready(function(){
  var form = document.getElementById("dataForm");
  
  document.getElementById("submitform").addEventListener("click", function () {
  //form.submit();
    $.ajax({
      type: "POST",
      url: "getdata",
      data: $("#dataForm").serialize(),
      dataType: "html",
      success: function (data) {
          var jqObj = jQuery(data);
          jqObj.find("li:last").remove();
          $("#target").empty().append(jqObj);
      }
  });
});
});

function test(targetURL) {
  // TODO: place your code here
  //https://reqres.in/
  var xhr = createXHRobj();
  xhr.open("GET", "https://reqres.in/api/products/3", true);
  xhr.onreadystatechange = function(){
    if (xhr.readyState === 4)  // request completed
    {
      if (xhr.status === 200) 
      {
        console.log(xhr.responseText);
      }
    }
  }
  xhr.send();
}



//VM286:6 Mixed Content: The page at 'https://www.google.com.ua/_/chrome/newtab?ie=UTF-8' was loaded over HTTPS, but requested an insecure XMLHttpRequest endpoint 'http://reqres.in/api/products/3,%20true'. This request has been blocked; the content must be served over HTTPS.

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

function asyncGet() {
  var req = createXHRobj()

  function request(url) {
    req.onreadystatechange = callbackFunction
    req.open("GET", url, true)
    // 3rd param specifies asynchronous request (browser does not wait/block)
    req.send("")
  }
}

function callbackFunction() {
  if (req.readyState === 4)  // request completed
    if (req.status === 200)  // HTTP response code (200 == OK)
      response = req.responseText
    // and anything else you might need to do
    else {
      // error reporting code
    }
}

function syncGet() {
  req = createXHRobj()
  req.open("GET", url, false)
  req.send(null)
  alert(req.responseText)
}


//Sending via POST - req.send()
function submitform(url) {
  req = createXHRobj()

  // DO NOT EVER use the same names for javascript variables and
  // HTML element ids, they share the same namespace under IE and
  // may also cause problems in other browsers.
  namevar = encodeURIComponent(document.getElementById('Sender_Name').value)
  emailvar = encodeURIComponent(document.getElementById('Sender_Email').value)

  req.open("POST", url, false)
  // req.setRequestHeader() must come AFTER req.open()
  req.setRequestHeader("Content-Type", "application/x-www-form-urlencoded")

  req.send("name=" + namevar + "&email=" + emailvar)
  alert(req.responseText)
}

// we do away with HTML form submit to simplify things
/*
<form>
  <input type="text" id="Sender_Name"  />  // long descriptive names that will not be used as
  <input type="text" id="Sender_Email" />  // javascript variable names are a good habit here...
  <input type="button" value="send" onclick="javascript:submitform('processform.php')"/>
</form> 
*/


//Wrapper code for Asynchronous requests
function wrapperAsuncRequest() {
  var req1 = createXHRobj()
  var req2 = createXHRobj()

  function asynXHR(url, reqobj, action) {
    reqobj.onreadystatechange = action
    reqobj.open("GET", url, true)
    reqobj.send("")
  }

  function responseIsReady(reqobj) {
    if (reqobj.readyState == 4)
      if (reqobj.status == 200) return true
      else {
        alert("ERROR: STATUS RESPONSE " + reqobj.status)
        return true // let the call proceed so we know which
        // call the status error occurred in
      }
    else return false
  }


  // each callback function must use its own request object
  var req1, req2

  function showstock() {
    if (responseIsReady(req1)) alert("stock price: $" + req1.responseText)

    /* IE can't reuse the XHR object, you are required to clean up and create a new one */
    req1 = null
    req1 = createXHRobj()
  }

  function showtemp() {
    if (responseIsReady(req2)) alert("It's " + req2.responseText + " celsius")

    /* IE can't reuse the XHR object, you are required to clean up and create a new one */
    req2 = null
    req2 = createXHRobj()
  }

  asynXHR("price.php?stock=GOOG", req1, showstock)
  asynXHR("temperature.php?city=Singapore", req2, showtemp)

}


function testFormPost(){
  $.ajax({
      type: "POST",
      url: "getdata",
      data: $("#dataForm").serialize(),
      dataType: "html",
      success: function (data) {
          var jqObj = jQuery(data);
          jqObj.find("li:last").remove();
          $("#target").empty().append(jqObj);
      }
  });
    
}