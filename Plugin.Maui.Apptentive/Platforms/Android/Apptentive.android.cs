using ApptentiveSDK;

namespace Plugin.Maui.Apptentive;

partial class ApptentiveImplementation: IApptentive
{
    public void Register(ApptentiveConfiguration Configuration, Action<bool> Completion) {
        // var AndroidConfiguration = new ApptentiveConfiguration();
        // AndroidConfiguration.ApptentiveKey = Configuration.ApptentiveKey;
        // AndroidConfiguration.ApptentiveSignature = Configuration.ApptentiveSignature;
        // AndroidConfiguration.LogLevel = Configuration.LogLevel;
        // ApptentiveSDK.Apptentive.Register(null, configuration);
    }

    public void Engage(string Event) {
        // ApptentiveSDK.Apptentive.Engage(Event);
    }

    public void PresentMessageCenter() {
        // ApptentiveSDK.Apptentive.PresentMessageCenter();
    }
}