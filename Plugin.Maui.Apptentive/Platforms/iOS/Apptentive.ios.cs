using ApptentiveKit.iOS;
using Foundation;

namespace Plugin.Maui.Apptentive;

partial class ApptentiveImplementation: IApptentive
{
    public event EventNotificationHandler? EventEngaged;

    public event AuthenticationFailureHandler? AuthenticationFailed;

    public void Register(ApptentiveConfiguration Configuration, Action<bool> Completion) {
        NSNotificationCenter.DefaultCenter.AddObserver(new NSString("com.apptentive.apptentiveEventEngaged"), HandleEventEngaged, null);
        ApptentiveIOS.Shared.AuthenticationFailureCallback = HandleAuthenticationFailed;

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

    public void CanShowInteraction(string Event, Action<bool> completion) {
        ApptentiveIOS.Shared.QueryCanShowInteraction(Event, (bool result) => completion(result));
    }

    public void PresentMessageCenter() {
        ApptentiveIOS.Shared.PresentMessageCenter(null);
    }

    public void CanShowMessageCenter(Action<bool> completion) {
        ApptentiveIOS.Shared.QueryCanShowMessageCenter((bool result) => completion(result));
    }

    public void SetPersonName(string PersonName) {
        ApptentiveIOS.Shared.PersonName = PersonName;
    }

    public void setPersonEmailAddress(string PersonEmailAddress) {
        ApptentiveIOS.Shared.PersonEmailAddress = PersonEmailAddress;
    }

    public void addCustomPersonData(string Key, string Value) {
        ApptentiveIOS.Shared.AddCustomPersonData(Value, Key);
    }

    public void addCustomPersonData(string Key, double Value) {
        ApptentiveIOS.Shared.AddCustomPersonData(new NSNumber(Value), Key);
    }

    // TODO: Add overloads for int, float, etc.?

    public void addCustomPersonData(string Key, bool Value) {
        ApptentiveIOS.Shared.AddCustomPersonData(Value, Key);
    }

    public void removeCustomPersonData(string Key) {
        ApptentiveIOS.Shared.RemoveCustomPersonData(Key);
    }

    public void addCustomDeviceData(string Key, string Value) {
        ApptentiveIOS.Shared.AddCustomDeviceData(Value, Key);
    }

    public void addCustomDeviceData(string Key, double Value) {
        ApptentiveIOS.Shared.AddCustomDeviceData(new NSNumber(Value), Key);
    }

    // TODO: Add overloads for int, float, etc.?

    public void addCustomDeviceData(string Key, bool Value) {
        ApptentiveIOS.Shared.AddCustomDeviceData(Value, Key);

    }

    public void removeCustomDeviceData(string Key) {
        ApptentiveIOS.Shared.RemoveCustomDeviceData(Key);
    }

    // TODO: Push notification integration
    // This should maybe be platform-specific, where they `using` the native module. 

    public int UnreadMessageCount { get {
        return (int)ApptentiveIOS.Shared.UnreadMessageCount;
    }}

    public void sentAttachmentText(string Text) {
        ApptentiveIOS.Shared.SendAttachment(Text);
    }

    //public void sendAttachmentImage(System.Drawing.Image image) {
        // FIXME: Not clear how to turn System.Drawing.Image into UIImage. 
        //ApptentiveIOS.Shared.sendAttachment()
    //}

    public void sendAttachmentFile(System.IO.Stream File, string MimeType) {
        var Data = NSData.FromStream(File);

        if (Data != null) {
            ApptentiveIOS.Shared.SendAttachment(Data, MimeType);
        } else {
            // FIXME: log an error?
        }
    }

    public void LogIn(string Token, Action<bool, string?> Completion) {
        ApptentiveIOS.Shared.LogIn(Token, (bool Success, NSError Error) => Completion(Success, Error.LocalizedDescription) );
    }

    public void LogOut() {
        ApptentiveIOS.Shared.LogOut();
    }

    public void UpdateToken(string Token, Action<bool>? Completion) {
        ApptentiveIOS.Shared.UpdateToken(Token, Completion);
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
        AuthenticationFailed?.Invoke(reason, error);
    }
}