using Android.App;
using Android.Content.PM;
using Android.OS;
using ApptentiveSDK;
using Plugin.Maui.Apptentive;

namespace Plugin.Maui.Apptentive.Sample;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity, IApptentiveActivityInfo
{

    protected override void OnResume()
    {
        base.OnResume();
        ApptentiveSDK.Apptentive.RegisterApptentiveActivityInfoCallback(this);
    }

    public Activity ApptentiveActivityInfo {
        get {
            return this;
        }
    }

    public Activity GetApptentiveActivityInfo() {
        return this;
    }
}

