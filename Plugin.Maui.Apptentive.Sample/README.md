# Plugin.Maui.Apptentive Sample App

This app is intended for testing and development of the Plugin.Maui.Apptentive plugin. 

## Environment Setup

Because Visual Studio for Mac is being sunsetted (as of early 2024), the
environment you use to build and run this app is somewhat in flux.

This app uses the .NET framework version 10.0 (tested with 10.0.103). You can 
[download it here](https://dotnet.microsoft.com/en-us/download/dotnet/10.0).

After installing the .NET framework, You will need to install the following workloads
(`dotnet workload install <workload>`):

- `maui-ios`
- `maui-android`
- `maui-mobile`
- `maui`

by running:

`sudo dotnet workload install <workload>`

## Build and Run

First, copy the `appsettings-template.Secret.json` file to `appsettings.Secret.json` and 
add your iOS and Android credentials from the Alchemer Digital dashboard.

If re-building after making C# source changes, you may have to clean and build
before running:

`dotnet clean`
`dotnet run -f:net10.0-ios` and/or `dotnet run -f:net10.0-android`

### ios

`dotnet build -f:net10.0-ios -t:run`

You can also supply a device UDID (`xcrun simctl list` to show simulators):

`dotnet build -f:net10.0-ios -t:run /p:_DeviceName=:v2:udid=<UDID>`

### android

debug: 
`dotnet build -t:run -f:net10.0-android`

with device
`dotnet build -t:run -f:net10.0-android -t:Run /p:_DeviceName=<DEVICE NAME>`

where the device name would be found by running `adb devices` in the command line and all the active connected devices would be listed

release: 
`dotnet build -c Release -t:run -f:net10.0-android`
