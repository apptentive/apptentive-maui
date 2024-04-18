namespace Plugin.Maui.Apptentive;

public enum AuthenticationFailureReason : long
{
	Unknown = 0,
	InvalidAlgorithm = 1,
	MalformedToken = 2,
	InvalidToken = 3,
	MissingSubClaim = 4,
	MismatchedSubClaim = 5,
	InvalidSubClaim = 6,
	ExpiredToken = 7,
	RevokedToken = 8,
	MissingAppKey = 9,
	MissingAppSignature = 10,
	InvalidKeySignaturePair = 11
}

public delegate void EventNotificationHandler(string? EventName, string? InteractionType, string? InteractionID, string? EventSource);

public delegate void AuthenticationFailureHandler(AuthenticationFailureReason reason, string? error);

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
