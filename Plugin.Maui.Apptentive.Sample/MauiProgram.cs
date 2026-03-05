using System.ComponentModel;
using Microsoft.Extensions.Logging;
using Plugin.Maui.Apptentive;
using Microsoft.Extensions.Configuration;

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

		builder.Services.AddSingleton<IApptentive>(Plugin.Maui.Apptentive.Apptentive.Default);

		Action<bool> completionHandler = (success) => {
			Console.Write("Registration ");
			Console.Write(success ? "did " : "did not ");
			Console.WriteLine("succeed.");
		};

		// Get Alchemer credentials from secrets settings file
		// (Copy/rename the template file and add your credentials to the copy)
		var assembly = typeof(MauiProgram).Assembly;
		using var stream = assembly.GetManifestResourceStream("Plugin.Maui.Apptentive.Sample.appsettings.Secret.json");
		var secrets = new ConfigurationBuilder()
    		.AddJsonStream(stream!)
    		.Build();

#if __IOS__
    	var configuration = new Configuration(secrets["Apptentive:iOSKey"]!, secrets["Apptentive:iOSSignature"]!);
#elif __ANDROID__
    	var configuration = new Configuration(secrets["Apptentive:AndroidKey"]!, secrets["Apptentive:AndroidSignature"]!);
#endif

		// Uncomment to set region and/or testing API base URL for lower environments.
		// configuration.Region = "eu";
		// configuration.OverrideBaseUrl = "https://api.apptentive.com/";

#if DEBUG
		configuration.LogLevel = ApptentiveLogLevel.Verbose;
		configuration.ShouldSanitizeLogMessages = false;
#endif

#if __IOS__
<<<<<<< HEAD
		Plugin.Maui.Apptentive.Apptentive.Default.Register(configuration, completionHandler);
=======
		Apptentive.Default.Register(configuration, completionHandler);
		
		// Uncomment to set font name for iOS interactions.
        // ApptentiveKit.iOS.Apptentive.FontName = "AmericanTypewriter";
>>>>>>> bdafdb6 (Move credentials to separate file)
#elif __ANDROID__
		Plugin.Maui.Apptentive.Apptentive.Default.Register(configuration, completionHandler, MainApplication.Current);
#endif

		Plugin.Maui.Apptentive.Apptentive.Default.EventEngaged += OnEventEngaged;

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

