#npm

1 npm install
2 npm start


# Angular CLI 
every project in this book was built on Angular CLI
to run an example you can run ng serve
For most projects you can compile them to JavaScript with ng build 
And you can run end-to-end tests with ng e2e, etc.
Angular CLI is not a requirement for using Angular. It’s simply a wrapper around Webpack 
https://github.com/angular/angular-cli

Angular, "-" JS, "+" TypeScript
"the old-style JavaScript Angular" - "AngularJS 1.x"

The first few chapters provide the foundation you need to get up and running with Angular. You’ll
create your first apps, use the built-in components, and start creating your components.
Next we’ll move into intermediate concepts such as using forms, using APIs, routing to different
pages, and using Dependency Injection to organize our code.
After that, we’ll move into more advanced concepts. We spend a good part of the book talking
about data architectures. Managing state in client/server applications is hard and we dive deep into
two popular approaches: using RxJS Observables and using Redux. 

After that, we’ll discuss how to write complex, advanced components using Angular’s most
powerful features. Then we talk about how to write tests for our app and how we can upgrade
our Angular 1 apps to Angular. Finally, we close with a chapter on writing native mobile apps
with Angular using NativeScript.


## npm -v
Your npm version should be 3.0.0 or higher.

## npm install -g typescript
C:\Users\user\AppData\Roaming\npm\tsc -> C:\Users\user\AppData\Roaming\npm\node_modules\typescript\bin\tsc
C:\Users\user\AppData\Roaming\npm\tsserver -> C:\Users\user\AppData\Roaming\npm\node_modules\typescript\bin\tsserver
C:\Users\user\AppData\Roaming\npm
-- typescript@2.8.1

Do I have to use TypeScript? No, you don’t have to use TypeScript to use Angular, but you
probably should. Angular does have an ES5 API, but Angular is written in TypeScript and
generally that’s what everyone is using. We’re going to use TypeScript in this book because
it’s great and it makes working with Angular easier. 


## npm install -g @angular/cli

C:\Users\user\AppData\Roaming\npm\ng -> C:\Users\user\AppData\Roaming\npm\node_modules\@angular\cli\bin\ng

> node-sass@4.8.3 install C:\Users\user\AppData\Roaming\npm\node_modules\@angular\cli\node_modules\node-sass
> node scripts/install.js

Downloading binary from https://github.com/sass/node-sass/releases/download/v4.8.3/win32-x64-48_binding.node
Download complete..] - :
Binary saved to C:\Users\user\AppData\Roaming\npm\node_modules\@angular\cli\node_modules\node-sass\vendor\win32-x64-48\binding.node
Caching binary to C:\Users\user\AppData\Roaming\npm-cache\node-sass\4.8.3\win32-x64-48_binding.node

> uglifyjs-webpack-plugin@0.4.6 postinstall C:\Users\user\AppData\Roaming\npm\node_modules\@angular\cli\node_modules\webpack\node_modules\uglifyjs-webpack-plugin
> node lib/post_install.js


> node-sass@4.8.3 postinstall C:\Users\user\AppData\Roaming\npm\node_modules\@angular\cli\node_modules\node-sass
> node scripts/build.js

Binary found at C:\Users\user\AppData\Roaming\npm\node_modules\@angular\cli\node_modules\node-sass\vendor\win32-x64-48\binding.node
Testing binary
Binary is fine
C:\Users\user\AppData\Roaming\npm
-- @angular/cli@1.7.4
  +-- @angular-devkit/build-optimizer@0.3.2

## ng --version
You are running version 6.3.1 of Node, which will not be supported in future
versions of the CLI. The official Node version that will be supported is 6.9 and greater.

To disable this warning use "ng set --global warnings.nodeDeprecation=false".
    _                      _                 ____ _     ___
   / \   _ __   __ _ _   _| | __ _ _ __     / ___| |   |_ _|
  / △ \ | '_ \ / _` | | | | |/ _` | '__|   | |   | |    | |
 / ___ \| | | | (_| | |_| | | (_| | |      | |___| |___ | |
/_/   \_\_| |_|\__, |\__,_|_|\__,_|_|       \____|_____|___|
               |___/

Angular CLI: 1.7.4
Node: 6.3.1
OS: win32 x64
Angular:
...




