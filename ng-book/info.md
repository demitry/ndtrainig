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



DPOL: upd... npm
## npm -v
5.6.0


## ng --version

    _                      _                 ____ _     ___
   / \   _ __   __ _ _   _| | __ _ _ __     / ___| |   |_ _|
  / △ \ | '_ \ / _` | | | | |/ _` | '__|   | |   | |    | |
 / ___ \| | | | (_| | |_| | | (_| | |      | |___| |___ | |
/_/   \_\_| |_|\__, |\__,_|_|\__,_|_|       \____|_____|___|
               |___/

Angular CLI: 1.7.4
Node: 8.11.1
OS: win32 x64
Angular:
...

## ng --help

## ng new angular-hello-world

  create angular-hello-world/e2e/app.e2e-spec.ts (301 bytes)                     
  create angular-hello-world/e2e/app.po.ts (208 bytes)                           
  create angular-hello-world/e2e/tsconfig.e2e.json (235 bytes)                   
  create angular-hello-world/karma.conf.js (923 bytes)                           
  create angular-hello-world/package.json (1304 bytes)                           
  create angular-hello-world/protractor.conf.js (722 bytes)                      
  create angular-hello-world/README.md (1033 bytes)                              
  create angular-hello-world/tsconfig.json (363 bytes)                           
  create angular-hello-world/tslint.json (3012 bytes)                            
  create angular-hello-world/.angular-cli.json (1254 bytes)                      
  create angular-hello-world/.editorconfig (245 bytes)                           
  create angular-hello-world/.gitignore (544 bytes)                              
  create angular-hello-world/src/assets/.gitkeep (0 bytes)                       
  create angular-hello-world/src/environments/environment.prod.ts (51 bytes)     
  create angular-hello-world/src/environments/environment.ts (387 bytes)         
  create angular-hello-world/src/favicon.ico (5430 bytes)                        
  create angular-hello-world/src/index.html (304 bytes)                          
  create angular-hello-world/src/main.ts (370 bytes)                             
  create angular-hello-world/src/polyfills.ts (3114 bytes)                       
  create angular-hello-world/src/styles.css (80 bytes)                           
  create angular-hello-world/src/test.ts (642 bytes)                             
  create angular-hello-world/src/tsconfig.app.json (211 bytes)                   
  create angular-hello-world/src/tsconfig.spec.json (283 bytes)                  
  create angular-hello-world/src/typings.d.ts (104 bytes)                        
  create angular-hello-world/src/app/app.module.ts (316 bytes)                   
  create angular-hello-world/src/app/app.component.html (1141 bytes)             
  create angular-hello-world/src/app/app.component.spec.ts (986 bytes)           
  create angular-hello-world/src/app/app.component.ts (207 bytes)                
  create angular-hello-world/src/app/app.component.css (0 bytes)                 
  ...

  added 1267 packages in 183.836s

Project 'angular-hello-world' successfully create

what has been created:
1 $ cd angular-hello-world
2 $ tree -F -L 1
3  .
4  ├── README.md 		// an useful README
5  ├── .angular-cli.json // angular-cli configuration file
6  ├── e2e/ 			// end to end tests
7  ├── karma.conf.js 	// unit test configuration
8  ├── node_modules/ 	// installed dependencies
9  ├── package.json 	// npm configuration
10 ├── protractor.conf.js // e2e test configuration
11 ├── src/ 			// application source
12 └── tslint.json 		// linter config file


## cd angular-hello-world
## ng serve

Our application is now running on localhost port 4200. Let’s open the browser and visit:
http://localhost:4200

Port 4200 is already in use. Use '--port' to specify a different port
ng serve --port 9001

Ctrl + C - Exit

While Control+C is used to kill a process with the signal SIGINT, and can be intercepted by a program so it can clean its self up before exiting, or not exit at all.

# Making a Component
What if we want to teach the browser new tags?
we will teach the browser new tags that have
custom functionality attached to them

## ng generate component hello-world

  create src/app/hello-world/hello-world.component.html (30 bytes)
  create src/app/hello-world/hello-world.component.spec.ts (657 bytes)
  create src/app/hello-world/hello-world.component.ts (288 bytes)
  create src/app/hello-world/hello-world.component.css (0 bytes)
  update src/app/app.module.ts (416 bytes)

1. A Component decorator
2. A component definition class

Notice that we suffix our TypeScript file with .ts instead of .js The problem is our browser doesn’t know how to interpret TypeScript files. To solve this gap, the ng serve command live-compiles our .ts to a .js file automatically

## import { things } from wherever

## ng generate component user-item
  create src/app/user-item/user-item.component.html (28 bytes)
  create src/app/user-item/user-item.component.spec.ts (643 bytes)
  create src/app/user-item/user-item.component.ts (280 bytes)
  create src/app/user-item/user-item.component.css (0 bytes)
  update src/app/app.module.ts (508 bytes)

