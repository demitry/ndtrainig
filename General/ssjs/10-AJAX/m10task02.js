// Task02
// Create a function that returns ZIP code of any area code using 
// Yahoo! service: https://developer.yahoo.com/yql/
// Note: function should make JSONP request and may use jQuery
// See examples to this module for reference

// Arguments:
// Function accepts one argument, a string with area code

// Return result:
// Function should not return any data, it should replace inner 
// contents of an element with id "target" on a file "target.html"

// Sample:
// argument value: SFO
// return result written: 94128 

function m10task02(code) {
    $.getJSON("https://query.yahooapis.com/v1/public/yql?callback=?",
    { q: "SELECT * from geo.places WHERE text='"+ code+ "'", format: "json" },
    function(response) {
        console.log("Name: " + response.query.results.place.name);
        console.log("ZIP code:" + response.query.results.place.postal.content);
        document.getElementById("target").innerHTML =   "<p>" + "Name: " + response.query.results.place.name + "</p>" +
                                                        "<p>" + "ZIP code:" + response.query.results.place.postal.content + "</p>";
    });

}