using Foundation;
using UIKit;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Plugin.Maui.Apptentive;

namespace Plugin.Maui.Apptentive.Sample;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
	{
		Action<bool> completionHandler = (success) => {
			Console.Write("Registration ");
			Console.Write(success ? "did " : "did not ");
			Console.WriteLine("succeed.");
		};
		
		var configuration = new Configuration("IOS-XAMARIN-IOS-8f46ccae63c0", "1bb31ba70317f17edcad284047483dfa");
		configuration.LogLevel = ApptentiveLogLevel.Verbose;
		configuration.ShouldSanitizeLogMessages = false;
		Apptentive.Default.Register(configuration, completionHandler);


		return base.FinishedLaunching(application, launchOptions);
	}
}

