﻿using ApptentiveSDK;
using AndroidLogLevel = Apptentive.Com.Android.Util.LogLevel;

namespace Plugin.Maui.Apptentive;

public partial interface IApptentive {
    void Register(Configuration Configuration, Action<bool> completion, MauiApplication Application);
}

partial class ApptentiveImplementation : IApptentive
{
  public event EventNotificationHandler? EventEngaged;

  public event AuthenticationFailureHandler? AuthenticationFailed;

  public void Register(Configuration Configuration, Action<bool> Completion, MauiApplication Application)
  {
    var androidConfiguration = new ApptentiveSDK.ApptentiveConfiguration(Configuration.ApptentiveKey, Configuration.ApptentiveSignature);
     androidConfiguration.DistributionVersion = Configuration.DistributionVersion;
     androidConfiguration.DistributionName = Configuration.DistributionName;
     androidConfiguration.ShouldSanitizeLogMessages = Configuration.ShouldSanitizeLogMessages;
     androidConfiguration.ShouldInheritAppTheme = Configuration.ShouldInheritAppTheme;
     androidConfiguration.CustomAppStoreURL = Configuration.CustomAppStoreURL;
     //TODO: Log Level is not reliably accessible.
     ApptentiveSDK.Apptentive.Register(Application, androidConfiguration, Completion);
  }

  public void Engage(string Event, Action<bool> onCompletion = null)
  {
    ApptentiveSDK.Apptentive.Engage(Event, null, new EngagementCallback(onCompletion));
  }

  public void CanShowInteraction(string Event, Action<bool> completion)
  {
    bool canShowInteraction = ApptentiveSDK.Apptentive.QueryCanShowInteraction(Event);
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
    ApptentiveSDK.Apptentive.PersonName = PersonName;
  }

  public void setPersonEmailAddress(string PersonEmailAddress)
  {
    ApptentiveSDK.Apptentive.PersonEmail = PersonEmailAddress;
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
    ApptentiveSDK.Apptentive.AddCustomDeviceData(Key, (Java.Lang.Number)intValue);
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

  // public void sendAttachmentImage(Image image)
  // {
  //     Bitmap? bitmap = null;
  //   using (MemoryStream memoryStream = new MemoryStream())
  //   {
  //     image.Save(memoryStream, Microsoft.Maui.Graphics.ImageFormat.Png);
  //     byte[] byteArray = memoryStream.ToArray();
  //     string mimeType = "image/png";
  //     ApptentiveSDK.Apptentive.SendAttachmentFile(byteArray, mimeType);
  //   }
  // }


  public void sendAttachmentFile(System.IO.Stream File, string MimeType)
  {
    ApptentiveSDK.Apptentive.SendAttachmentFile(File, MimeType);
  }

  public void LogIn(string Token, Action<bool, string?> Completion) { }

  public void LogOut() { }

  public void UpdateToken(string Token, Action<bool>? Completion) { }

}