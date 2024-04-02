using ApptentiveSDK;
using ApptentiveLogLevel = Apptentive.Com.Android.Util.LogLevel;

namespace Plugin.Maui.Apptentive;

partial class ApptentiveImplementation : IApptentive
{
  public event EventNotificationHandler? EventEngaged;

  public event AuthenticationFailureHandler? AuthenticationFailed;

  public void Register(ApptentiveConfiguration Configuration, Action<bool> Completion, MauiApplication Application = null)
  {
    var configuration = new ApptentiveSDK.ApptentiveConfiguration(Configuration.ApptentiveKey, Configuration.ApptentiveSignature);
    configuration.LogLevel = (ApptentiveLogLevel)Configuration.LogLevel;
    configuration.DistributionName = Configuration.DistributionName;
    configuration.DistributionVersion = Configuration.DistributionVersion;
    configuration.ShouldSanitizeLogMessages = Configuration.ShouldSanitizeLogMessages;
    ApptentiveSDK.Apptentive.Register(Application, Configuration, Completion);
  }

  public void Engage(string Event, IDictionary<string, Java.Lang.Object> customData = null, Action<bool> onCompletion = null)
  {
    ApptentiveSDK.Apptentive.Engage(Event, customData, new EngagementCallback(onCompletion));
  }

  public void CanShowInteraction(string Event, Action<bool> completion)
  {
    bool canShowInteraction = ApptentiveSDK.Apptentive.QueryCanShowInteraction(eventName);
    completion(canShowInteraction);
  }

  public void PresentMessageCenter()
  {
    ApptentiveSDK.Apptentive.ShowMessageCenter();
  }

  public void CanShowMessageCenter(Action<bool> completion)
  {
    ApptentiveSDK.Apptentive.CanShowMessageCenter(completion);

  }

  public void SetPersonName(string PersonName)
  {
    ApptentiveSDK.Apptentive.SetPersonName(PersonName);
  }

  public void setPersonEmailAddress(string PersonEmailAddress)
  {
    ApptentiveSDK.Apptentive.SetPersonEmail(PersonEmailAddress);
  }

  public void addCustomPersonData(string Key, string Value)
  {
    ApptentiveSDK.Apptentive.AddCustomPersonData(Key, Value);
  }

  public void addCustomPersonData(string Key, double Value)
  {
    int intValue = (int)Value;
    ApptentiveSDK.Apptentive.AddCustomPersonData(Key, (Java.Lang.Number)intValue);
  }

  public void addCustomPersonData(string Key, bool Value)
  {
    ApptentiveSDK.Apptentive.AddCustomPersonData(Key, (Java.Lang.Boolean)Value);
  }

  public void removeCustomPersonData(string Key)
  {
    ApptentiveSDK.Apptentive.RemoveCustomPersonData(Key);
  }

  public void addCustomDeviceData(string Key, string Value)
  {
    ApptentiveSDK.Apptentive.AddCustomDeviceData(Key, Value);
  }

  public void addCustomDeviceData(string Key, double Value)
  {
    int intValue = (int)Value;
    ApptentiveSDK.Apptentive.AddCustomDeviceData(Key, (Java.Lang.Number)intValue)
    }

  public void addCustomDeviceData(string Key, bool Value)
  {
    ApptentiveSDK.Apptentive.AddCustomDeviceData(Key, (Java.Lang.Boolean)Value);
  }

  public void removeCustomDeviceData(string Key)
  {
    ApptentiveSDK.Apptentive.RemoveCustomDeviceData(Key);
  }

  public int UnreadMessageCount
  {
    get
    {
      return ApptentiveSDK.Apptentive.UnreadMessageCount;
    }
  }

  public void sentAttachmentText(string Text)
  {
    ApptentiveSDK.Apptentive.SendAttachmentText(Text);
  }

  public void sendAttachmentImage(System.Drawing.Image image)
  {
    using (MemoryStream memoryStream = new MemoryStream())
    {
      image.Save(memoryStream, ImageFormat.Jpeg);
      byte[] byteArray = memoryStream.ToArray();
      string mimeType = "image/jpeg";
      ApptentiveSDK.Apptentive.SendAttachmentFile(byteArray, mimeType);
    }
  }

  public void sendAttachmentFile(System.IO.Stream File, string MimeType)
  {
    ApptentiveSDK.Apptentive.SendAttachmentFile(File, MimeType);
  }

  public void LogIn(string Token, Action<bool, string?> Completion) { }

  public void LogOut() { }

  public void UpdateToken(string Token, Action<bool>? Completion) { }
}