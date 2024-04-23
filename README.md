# Apptentive Maui Plugin

## Register Apptentive

Register the Apptentive plugin in your implementation of the CreateMauiApp() method. You will need to copy the App Key and App Signature from your dashboard for each platform (iOS and/or Android) that your app supports and initialize a `Configuration` object with them.

```C#
using Plugin.Maui.Apptentive;

...

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        ...

		Action<bool> completionHandler = (success) => {
			Console.Write("Registration ");
			Console.Write(success ? "did " : "did not ");
			Console.WriteLine("succeed.");
		};

#if __IOS__
		var configuration = new Configuration("Your Apptentive iOS App Key", "Your Apptentive iOS App Signature");
#elif __ANDROID__
		var configuration = new Configuration("Your Apptentive Android App Key", "Your Apptentive Android App Signature");
#endif

#if DEBUG
		configuration.LogLevel = ApptentiveLogLevel.Verbose;
		configuration.ShouldSanitizeLogMessages = false;
#endif

#if __IOS__
		Apptentive.Default.Register(configuration, completionHandler);
#elif __ANDROID__
		Apptentive.Default.Register(configuration, completionHandler, MainApplication.Current);
#endif

        ...
	}
}

```

## Events

Events record user interaction. You can use them to determine if and when an Interaction will be shown to your customer. You will use these Events later to target Interactions, and to determine whether an Interaction can be shown. You trigger an Event with the `Engage()` method. This will record the Event, and then check to see if any Interactions targeted to that Event are allowed to be displayed, based on the logic you set up in the Apptentive Dashboard.
  
```C#
private void OnButtonClicked(object sender, EventArgs e)
{
    Apptentive.Default.Engage("button_clicked");
}

```

## Message Center

See: [How to Use Message Center](https://learn.apptentive.com/knowledge-base/how-to-use-message-center/)

### Showing Message Center

With the Apptentive Message Center your customers can send feedback, and you can reply, all without making them leave the app. Handling support inside the app will increase the number of support messages received and ensure a better customer experience.

Message Center lets customers see all the messages they have send you, read all of your replies, and even send screenshots that may help debug issues.

Add [Message Center](http://learn.apptentive.com/knowledge-base/apptentive-android-sdk-features/#message-center) to talk to your customers.

Find a place in your app where you can add a button that opens Message Center. Your setings page is a good place.

```C#
private void OnMessageCenterButtonClicked(object sender, EventArgs e)
{
    Apptentive.Default.PresentMessageCenter();
}
```
