using Android.App;
using Android.Runtime;
using ApptentiveSDK;

namespace Plugin.Maui.Apptentive.Sample;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
		 var configuration = new ApptentiveSDK.ApptentiveConfiguration("ANDROID-XOLOFAX-cdfb1ae00eeb", "2c1883d1d22686f4588ad9126f037cd7");
            ApptentiveSDK.Apptentive.Register(this,configuration);
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

