using Android.App;
using Android.Runtime;
using Plugin.Maui.Apptentive;

namespace Plugin.Maui.Apptentive.Sample;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

