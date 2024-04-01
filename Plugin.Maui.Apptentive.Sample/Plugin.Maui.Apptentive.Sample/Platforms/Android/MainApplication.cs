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
		//TODO: Create ApptentiveConfiguration and all Register.
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

