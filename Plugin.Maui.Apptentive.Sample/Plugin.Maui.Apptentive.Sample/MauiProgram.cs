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

		var Configuration = new ApptentiveConfiguration("<#Your Apptentive Key#>", "<#Your Apptentive Secret#>");
		Configuration.LogLevel = ApptentiveLogLevel.Verbose;
		Configuration.ShouldSanitizeLogMessages = false;
		Apptentive.Default.Register(Configuration, null);

		return builder.Build();
	}
}

