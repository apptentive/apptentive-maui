using Microsoft.Extensions.Logging;
using Plugin.Maui.Apptentive;

namespace Plugin.Maui.Apptentive.Sample;

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

		var Configuration = new ApptentiveConfiguration("IOS-XAMARIN-IOS-8f46ccae63c0", "1bb31ba70317f17edcad284047483dfa");
		Configuration.LogLevel = ApptentiveLogLevel.Verbose;
		Configuration.ShouldSanitizeLogMessages = false;
		Apptentive.Default.Register(Configuration, null);

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

