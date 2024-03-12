# Plugin.Maui.Apptentive Sample App

This app is intended for testing and development of the Plugin.Maui.Apptentive plugin. 

## Environment Setup

Because Visual Studio for Mac is being sunsetted (as of early 2024), the
environment you use to build and run this app is somewhat in flux.

This app uses the .NET framework version 8.0 (tested with 8.0.101). You can 
[download it here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

After installing the .NET framework, You will need to install the following workloads
(`dotnet workload install <workload>`):

- maui-ios    
- maui-android
- maui-mobile 
- maui

## Build and Run

To build the app, move to the (inner) Plugin.Maui.Apptentive.Sample
subdirectory (two levels down from the root of the repo) and run the
following:

`dotnet build -f:net8.0-ios -t:Run`

You can also supply a device UDID (`xcrun simctl list` to show simulators):

`dotnet build -f:net8.0-ios -t:Run /p:_DeviceName=:v2:udid=<UDID>`
