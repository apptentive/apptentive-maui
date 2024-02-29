using System.IO;

namespace Plugin.Maui.Apptentive;

public interface IApptentive {
    void Register(ApptentiveConfiguration configuration, Action<bool> completion);

    void Engage(string Event);

    void CanShowInteraction(string Event, Action<bool> completion);

    void PresentMessageCenter();

    void CanShowMessageCenter(Action<bool> completion);

    void SetPersonName(string PersonName);

    void setPersonEmailAddress(string PersonEmailAddress);

    void addCustomPersonData(string Key, string Value);

    void addCustomPersonData(string Key, double Value);

    void addCustomPersonData(string Key, bool Value);

    void removeCustomPersonData(string Key);

    void addCustomDeviceData(string Key, string Value);

    void addCustomDeviceData(string Key, double Value);

    void addCustomDeviceData(string Key, bool Value);

    void removeCustomDeviceData(string Key);

    // TODO: Push notification integration
    // This should maybe be platform-specific, where they `using` the native module. 

    int UnreadMessageCount { get; }

    void sentAttachmentText(string Text);

// FIXME: This is probably a heavier lift than we want to sign up for. 
//    void sendAttachmentImage(System.Drawing.Image image);

    void sendAttachmentFile(System.IO.Stream file, string MimeType);

    void LogIn(string Token, Action<bool, string?> completion);

    void LogOut();

    void UpdateToken(string Token);

    // TODO: Listener for internal events
}