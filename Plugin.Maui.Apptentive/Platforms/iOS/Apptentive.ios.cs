using ApptentiveKit.iOS;

namespace Plugin.Maui.Apptentive;

partial class ApptentiveImplementation: IApptentive
{
    public void Register(ApptentiveConfiguration Configuration, Action<bool> Completion) {
        ApptentiveIOSConfiguration IOSConfiguration = new ApptentiveIOSConfiguration(Configuration.ApptentiveKey, Configuration.ApptentiveSignature);
        IOSConfiguration.LogLevel = (ApptentiveKit.iOS.ApptentiveLogLevel)Configuration.LogLevel;
        IOSConfiguration.ShouldSanitizeLogMessages = Configuration.ShouldSanitizeLogMessages;
        IOSConfiguration.DistributionName = Configuration.DistributionName;
        IOSConfiguration.DistributionVersion = Configuration.DistributionVersion;

		ApptentiveIOS.Shared.Register(IOSConfiguration, Completion);
    }

    public void Engage(string Event) {
        ApptentiveIOS.Shared.Engage(Event, null);
    }

    public void PresentMessageCenter() {
        ApptentiveIOS.Shared.PresentMessageCenter(null);
    }
}