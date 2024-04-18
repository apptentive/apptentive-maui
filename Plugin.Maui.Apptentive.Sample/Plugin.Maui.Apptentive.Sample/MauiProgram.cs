using Microsoft.Extensions.Logging;
using Plugin.Maui.Apptentive;

namespace Plugin.Maui.Apptentive.Sample;

#nullable enable

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<IApptentive>(Apptentive.Default);

		Action<bool> completionHandler = (success) => {
			Console.Write("Registration ");
			Console.Write(success ? "did " : "did not ");
			Console.WriteLine("succeed.");
		};

#if __IOS__
		var configuration = new Configuration("Your Apptentive iOS App Key", "Your Apptentive iOS App Signature");
#elif __ANDROID__
		var configuration = new Configuration("Your Apptentive Android App Key", "Your Apptentive Android App Signature");
#endif

#if DEBUG
		configuration.LogLevel = ApptentiveLogLevel.Verbose;
		configuration.ShouldSanitizeLogMessages = false;
#endif

#if __IOS__
		Apptentive.Default.Register(configuration, completionHandler);
#elif __ANDROID__
		Apptentive.Default.Register(configuration, completionHandler, MainApplication.Current);
#endif

		Apptentive.Default.EventEngaged += OnEventEngaged;

		return builder.Build();
	}

	private static void OnEventEngaged(string? name, string? interaction, string? id, string? source) {
		Console.Write("Notified of event engagement: ");
		Console.Write(source);
		Console.Write("#");
		Console.Write(interaction ?? "app");
		Console.Write("#");
		Console.WriteLine(name);
	}
}

