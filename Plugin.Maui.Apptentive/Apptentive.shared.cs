using ApptentiveKit.iOS;
namespace Plugin.Maui.Apptentive;

public delegate void EventNotificationHandler(string? EventName, string? InteractionType, string? InteractionID, string? EventSource);

public delegate void AuthenticationFailureHandler(ApptentiveAuthenticationFailureReason reason, string? error);

public static class Apptentive
{
	static IApptentive? defaultImplementation;

	/// <summary>
	/// Provides the default implementation for static usage of this API.
	/// </summary>
	public static IApptentive Default =>
		defaultImplementation ??= new ApptentiveImplementation();

	internal static void SetDefault(IApptentive? implementation) =>
		defaultImplementation = implementation;
}
