namespace Plugin.Maui.Apptentive;

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
