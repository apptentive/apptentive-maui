using Foundation;
using UIKit;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Plugin.Maui.Apptentive;

namespace Plugin.Maui.Apptentive.Sample;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

