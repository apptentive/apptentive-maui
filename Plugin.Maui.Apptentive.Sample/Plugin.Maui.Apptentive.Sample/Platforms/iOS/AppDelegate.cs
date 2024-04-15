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
		
		var configuration = new Configuration("<#Your Apptentive Key#>", "<#Your Apptentive Secret#>");
		configuration.LogLevel = ApptentiveLogLevel.Verbose;
		configuration.ShouldSanitizeLogMessages = false;
		Apptentive.Default.Register(configuration, completionHandler);


		return base.FinishedLaunching(application, launchOptions);
	}
}

