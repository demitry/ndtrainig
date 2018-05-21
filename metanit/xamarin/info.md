# Xamarin Tutorial

<!-- TOC -->

- [Xamarin Tutorial](#xamarin-tutorial)
    - [/Properties/AndroidManifest.xml](#propertiesandroidmanifestxml)
    - [Android Resources](#android-resources)
    - [Android Activity Lifecycle](#android-activity-lifecycle)
    - [Permissions](#permissions)
        - [Access Checkin Properties](#access-checkin-properties)
    - [GUI](#gui)

<!-- /TOC -->

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

## Android Activity Lifecycle

            When a user navigates through an Android App, a series of events occurs. For example, when a user launches an app, e.g., the Facebook App, it starts and becomes visible on the foreground to the user, onCreate() → onStart() → onResume().

            If another activity starts, e.g., a phone call comes in, then the Facebook app will go to the background and the call comes to the foreground. We now have two processes running.

            onPause()  --- > onStop()
            When the phone call ends, the Facebook app returns to the foreground. Three methods are called.

            onRestart() --- > onStart() --- > onResume()

            There are 7 lifecycle processes in an Android activity. They include −

            onCreate − It is called when the activity is first created.

            onStart − It is called when the activity starts and becomes visible to the user.

            onResume − It is called when the activity starts interacting with the user. User input takes place at this stage.

            onPause − It is called when the activity runs in the background but has not yet been killed.

            onStop − It is called when the activity is no longer visible to the user.

            onRestart − It is called after the activity has stopped, before starting again. It is normally called when a user goes back to a previous activity that had been stopped.

            onDestroy − This is the final call before the activity is removed from the memory.


## Permissions

In Android, by default, no application has permissions to perform any operations that would have an effect on the user or the operating system. In order for an App to perform a task, it must declare the permissions. The App cannot perform the task until the permission are granted by the Android system. This mechanism of permissions stops applications from doing as they wish without the user’s consent.

Permissions are to be recorded in AndroidManifest.xml file. To add permissions, we double-click on properties, then go to Android ManRequired permissions will appear. Check the appropriate permissions you wish to add.

### Access Checkin Properties

**Camera** − It provides permission to access the device’s camera.

```xml
<uses-permission android:name="android.permission.CAMERA" />
```

**Internet** − It provides access to network resources.

```xml
<uses-permission android:name="android.permission.INTERNET" /> 
```

**ReadContacts** − It provides access to read the contacts on your device.

```xml
<uses-permission android:name="android.permission.READ_CONTACTS" />
```

**ReadExternalStorage** − It provides access to read and store data on an external storage.

```xml
<uses-permission android:name="android.permission.READ_EXTERNAL_STORAGE" /> 
```

**Calendars** − It allows an app access to the calendar on the user device and events. This permission can be dangerous, as it grants an app the ability to send emails to guests without the owner’s awareness. The syntax for adding this permission is as shown below −

```xml
<uses-permission android:name="android.permission-group.CALENADAR" /> 
```

**SMS** − An app with this permission has the ability to use the devices messaging services. It includes reading, writing, and editing SMS and MMS messages. Its syntax is as shown below.

```xml
<uses-permission android:name="android.permission-group.SMS" />
```

**Location** − An app with this permission can access the device’s location using the GPS network.

```xml
<uses-permission android:name="android.permission-group.LOCATION" /> 
```

**Bluetooth** − An app with this permission can exchange data files with other Bluetooth enabled devices wirelessly.

```xml
<uses-permission android:name="android.permission.BLUETOOTH" />
```

## GUI

**FindViewById** - This method finds the ID of a view that was identified. It searches for the id in the .axml layout file.
