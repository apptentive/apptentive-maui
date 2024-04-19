using ApptentiveKit.iOS;
using Foundation;
using System.IO;

namespace Plugin.Maui.Apptentive;

public partial interface IApptentive {
    void Register(Configuration Configuration, Action<bool> completion);
}

partial class ApptentiveImplementation: IApptentive
{
    public event EventNotificationHandler? EventEngaged;

    public event AuthenticationFailureHandler? AuthenticationFailed;

    public void Register(Configuration Configuration, Action<bool> completion)
    {
        NSNotificationCenter.DefaultCenter.AddObserver(new NSString("com.apptentive.apptentiveEventEngaged"), HandleEventEngaged, null);
        ApptentiveKit.iOS.Apptentive.Shared.AuthenticationFailureCallback = HandleAuthenticationFailed;

        ApptentiveConfiguration iosConfiguration = new ApptentiveConfiguration(Configuration.ApptentiveKey, Configuration.ApptentiveSignature);
        iosConfiguration.LogLevel = (ApptentiveKit.iOS.ApptentiveLogLevel)Configuration.LogLevel;
        iosConfiguration.ShouldSanitizeLogMessages = Configuration.ShouldSanitizeLogMessages;
        iosConfiguration.DistributionName = Configuration.DistributionName;
        iosConfiguration.DistributionVersion = Configuration.DistributionVersion;

        ApptentiveKit.iOS.Apptentive.Shared.Theme = UITheme.None;

		ApptentiveKit.iOS.Apptentive.Shared.Register(iosConfiguration, completion);
    }

    public void Engage(string Event, Action<bool> completion = null) {
        ApptentiveKit.iOS.Apptentive.Shared.Engage(Event, null, completion);
    }

    public void CanShowInteraction(string Event, Action<bool> completion = null) {
        ApptentiveKit.iOS.Apptentive.Shared.QueryCanShowInteraction(Event, (bool result) => completion(result));
    }

    public void PresentMessageCenter() {
        ApptentiveKit.iOS.Apptentive.Shared.PresentMessageCenter(null);
    }

    public void CanShowMessageCenter(Action<bool> completion) {
        ApptentiveKit.iOS.Apptentive.Shared.QueryCanShowMessageCenter((bool result) => completion(result));
    }

    public void SetPersonName(string PersonName) {
        ApptentiveKit.iOS.Apptentive.Shared.PersonName = PersonName;
    }

    public void setPersonEmailAddress(string PersonEmailAddress) {
        ApptentiveKit.iOS.Apptentive.Shared.PersonEmailAddress = PersonEmailAddress;
    }

    public void addCustomPersonData(string Key, string Value) {
        ApptentiveKit.iOS.Apptentive.Shared.AddCustomPersonData(Value, Key);
    }

    public void addCustomPersonData(string Key, double Value) {
        ApptentiveKit.iOS.Apptentive.Shared.AddCustomPersonData(new NSNumber(Value), Key);
    }

    // TODO: Add overloads for int, float, etc.?

    public void addCustomPersonData(string Key, bool Value) {
        ApptentiveKit.iOS.Apptentive.Shared.AddCustomPersonData(Value, Key);
    }

    public void removeCustomPersonData(string Key) {
        ApptentiveKit.iOS.Apptentive.Shared.RemoveCustomPersonData(Key);
    }

    public void addCustomDeviceData(string Key, string Value) {
        ApptentiveKit.iOS.Apptentive.Shared.AddCustomDeviceData(Value, Key);
    }

    public void addCustomDeviceData(string Key, double Value) {
        ApptentiveKit.iOS.Apptentive.Shared.AddCustomDeviceData(new NSNumber(Value), Key);
    }

    // TODO: Add overloads for int, float, etc.?

    public void addCustomDeviceData(string Key, bool Value) {
        ApptentiveKit.iOS.Apptentive.Shared.AddCustomDeviceData(Value, Key);

    }

    public void removeCustomDeviceData(string Key) {
        ApptentiveKit.iOS.Apptentive.Shared.RemoveCustomDeviceData(Key);
    }

    // TODO: Push notification integration
    // This should maybe be platform-specific, where they `using` the native module. 

    public int UnreadMessageCount { get {
        return (int)ApptentiveKit.iOS.Apptentive.Shared.UnreadMessageCount;
    }}

    public void sentAttachmentText(string Text) {
        ApptentiveKit.iOS.Apptentive.Shared.SendAttachment(Text);
    }

    //public void sendAttachmentImage(System.Drawing.Image image) {
        // FIXME: Not clear how to turn System.Drawing.Image into UIImage. 
        //ApptentiveKit.iOS.Apptentive.Shared.sendAttachment()
    //}

    public void sendAttachmentFile(System.IO.Stream File, string MimeType) {
        var Data = NSData.FromStream(File);

        if (Data != null) {
            ApptentiveKit.iOS.Apptentive.Shared.SendAttachment(Data, MimeType);
        } else {
            // FIXME: log an error?
        }
    }

    public void LogIn(string Token, Action<bool, string?> Completion) {
        ApptentiveKit.iOS.Apptentive.Shared.LogIn(Token, (bool Success, NSError Error) => Completion(Success, Error?.LocalizedDescription) );
    }

    public void LogOut() {
        ApptentiveKit.iOS.Apptentive.Shared.LogOut();
    }

    public void UpdateToken(string Token, Action<bool>? Completion) {
        ApptentiveKit.iOS.Apptentive.Shared.UpdateToken(Token, Completion);
    }

    private void HandleEventEngaged(NSNotification notification)
    {
        if (EventEngaged != null) {
            string? name = notification.UserInfo.ValueForKey(new NSString("eventType"))?.ToString();
            string? type = notification.UserInfo.ValueForKey(new NSString("interactionType"))?.ToString();
            string? id = notification.UserInfo.ValueForKey(new NSString("interactionID"))?.ToString();
            string? source = notification.UserInfo.ValueForKey(new NSString("eventSource"))?.ToString();

            EventEngaged?.Invoke(name, type, id, source);
        }   
    }

    private void HandleAuthenticationFailed(ApptentiveAuthenticationFailureReason reason, string? error)
    {        
        AuthenticationFailed?.Invoke((AuthenticationFailureReason)reason, error);
    }
}