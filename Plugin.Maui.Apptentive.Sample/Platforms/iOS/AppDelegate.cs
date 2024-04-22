using Foundation;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace Plugin.Maui.Apptentive.Sample;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

