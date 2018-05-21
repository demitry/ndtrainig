# Xamarin Tutorial

## /Properties/AndroidManifest.xml

All Android Apps have a manifest file commonly referred to as AndroidManifest.xml. The manifest file contains everything about the Android platform that an App needs in order to run successfully.

Here, we have listed down some of the important functions of a manifest file ?

It declares the minimum API level required by the application.

It declares the permissions required by the application, e.g., camera, location, etc.

It gives permissions to hardware and software features used or required by the application.

It lists the libraries that the application must be linked.

**Application name** - It refers to the title of your App

**Package name** - It is an unique name used to identify your App.

**Application Icon** - It is the icon displayed on the Android home screen for your App.

**Version Number** - It is a single number that is used to show one version of your App is more recent than another.

```xml
<manifest xmlns:android="http://schemas.android.com/apk/res/android" 
   android:versionCode="1">
```

**Version Name** - It is a user-friendly version string for your App that users will see on your App settings and on the Google PlayStore. The following code shows an example of a version name.

```xml
<manifest xmlns:android="http://schemas.android.com/apk/res/android"
   android:versionName="1.0.0">
```

**Minimum Android Version** - It is the lowest Android version platform which your application supports.

```xml
<uses-sdk android:minSdkVersion="16" />
```

In the above example, our minimum Android version is API Level 16, commonly referred to as JELLY BEAN.

**Target Android Version** - It is the Android version on which your App is compiled against.

## Android Resources

When a new Android project is created, there are some files that are added to the project, by default. We call these default project files and folders as Android Resources.


The default Android resources include the following −

AndroidManifest.xml file − It contains information about your Android applications, e.g., the application name, permissions, etc.

Resources folder − Resources can be images, layouts, strings, etc. that can be loaded via Android’s resource system.

Resources/drawable folder − It stores all the images that you are going to use in your application.

Resources/layout folder − It contains all the Android XML files (.axml) that Android uses to build user interfaces.

The Resources/values folder − It contains XML files to declare key-value pairs for strings (and other types) throughout an application. This is how localization for multiple languages is normally set up on Android.

Resources.designer.cs − This file is created automatically when the Android projected is created and it contains unique identifiers that reference the Android resources.

MainActivity.cs file − This is the first activity of your Android application and from where the main application actions are launched from.

Resource files can be accessed programmatically through a unique ID which is stored in the resources.designer.cs file. The ID is contained under a class called Resource. Any resource added to the project is automatically generated inside the resource class.


