alert('Hello World!')
alert(9+5 * 3)
alert(window.innerWidth)
alert(window.scrollY)
alert(window.location.href)
window.alert('OMG')
alert(['What', 'is', 'up'])
alert([2 + 5, 'samurai', true])

var my_things = [2 + 5, 'samurai', true];
alert(my_things);

var my_things = [2 + 5, 'samurai', true];
alert(my_things[1]);

var my_things = [2 + 5, 'samurai', true];
alert(my_things.length);

var my_things = [2 + 5, 'samurai', true];
alert(my_things);
my_things = [2 + 5, 'samurai', true, 'LOVE'];
alert(my_things);

var my_things = [2 + 5, 'samurai', true];
alert(my_things);
my_things.push('The Button');
alert(my_things);

var my_things = [2 + 5, 'samurai', true];
alert(my_things.includes('ninja'));
alert(my_things.includes('samurai'));

if (window.location.hostname == 'jgthms.com') {
  alert('Welcome on my domain! 🤗')
}

if (window.location.hostname != 'jgthms.com') {
  alert('Please come back soon! 😉')
}

if (window.location.hostname == 'jgthms.com') {
  alert('Welcome on my domain! 🤗')
} else {
  alert('Please come back soon! 😉')
}

if (window.innerWidth > 2000) {
  alert('Big screen! 🔥')
} else if (window.innerWidth < 600) {
  alert('Probably a mobile phone 📱')
} else {
  alert('Decent size 👍')
}

for (var i = 0; i < 3; i++) {
  alert(i);
}

var my_things = [2 + 5, 'samurai', true];
for (var i = 0; i < my_things.length; i++) {
  alert(my_things[i]);
}

//Arrays actually have a method called forEach(), which allows to perform a task for each item in the array:

var my_things = [2 + 5, 'samurai', true];
my_things.forEach(function(item) {
  alert(item);
});

//Note a few improvements:
// - There is no i variable involved
// - We don't need to access the array's length
// - We don't need to use the index with my_thing[i] to access the item

/*
If you look carefully, you can see that forEach() has the exact same syntax! It's forEach(parameter) but where the parameter happens to be a function that spans 3 lines.

So far, we've used a few functions and methods:

the alert() function (or window method)
the push() array method
the includes() array method
the forEach() array method

*/

/*
Creating a custom function info
The power of programming languages is the ability to create your own functions, that fit your needs.
Remember the keyword/parentheses combination that we used for if/else and for? Well, guess what: it's almost the same pattern here!
I'm saying "almost" because the only difference is that a function needs a name!
Let's create a function called greet(), with 1 parameter called name, and then immediately call it:
*/

function greet(name) {
    var message = 'Hey there ' + name;
    alert(message);
}

greet('Alex');
