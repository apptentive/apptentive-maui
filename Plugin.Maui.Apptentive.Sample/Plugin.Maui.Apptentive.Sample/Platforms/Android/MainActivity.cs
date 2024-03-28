using Android.App;
using Android.Content.PM;
using Android.OS;
using ApptentiveSDK;
using ApptentiveCore;

namespace Plugin.Maui.Apptentive.Sample;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
     ApptentiveSDK.Apptentive.Engage("test");
}

