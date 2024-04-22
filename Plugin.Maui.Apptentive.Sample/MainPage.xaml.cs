using System.Security.Principal;
using Plugin.Maui.Apptentive;


namespace Plugin.Maui.Apptentive.Sample;

#nullable enable

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnEngageClicked(object sender, EventArgs e)
	{
		Console.Write("Clicked engage button with");
		Console.WriteLine(EngageEntry.Text);

		Apptentive.Default.Engage(EngageEntry.Text);
    }

	private void OnMessageCenterClicked(object sender, EventArgs e)
	{
		Apptentive.Default.PresentMessageCenter();
	}

	private void OnPersonNameSetClicked(object sender, EventArgs e)
	{
		Apptentive.Default.SetPersonName(PersonName.Text);
	}

	private void OnPersonEmailAddressSetClicked(object sender, EventArgs e)
	{
		Apptentive.Default.setPersonEmailAddress(PersonEmailAddress.Text);
	}

	private void OnPersonCustomStringAddClicked(object sender, EventArgs e) 
	{
		var key = PersonCustomStringKey.Text;
		var value = PersonCustomStringValue.Text;

		if (!String.IsNullOrEmpty(key) && !String.IsNullOrEmpty(value)) {
			Apptentive.Default.addCustomPersonData(key, value);
			return;
		}

		Console.WriteLine("Missing key and/or value");
	}

	private void OnPersonCustomNumberAddClicked(object sender, EventArgs e) 
	{
		var key = PersonCustomNumberKey.Text;
		var value = PersonCustomNumberValue.Text;

		if (!String.IsNullOrEmpty(key) && !String.IsNullOrEmpty(value)) {
			try {
				var numericValue = Double.Parse(value);

				Apptentive.Default.addCustomPersonData(key, numericValue);
				return;
			}
			catch (Exception exc)
			{
				Console.Write(exc);
			}
		}

		Console.WriteLine("Missing or invalid key and/or value");
	}

	private void OnPersonCustomBoolAddClicked(object sender, EventArgs e) 
	{
		var key = PersonCustomBoolKey.Text;
		var value = PersonCustomBoolValue.IsToggled;

		if (!String.IsNullOrEmpty(key)) {
			Apptentive.Default.addCustomPersonData(key, value);
			return;
		}
		
		Console.WriteLine("Missing key");		
	}

	private void OnPersonCustomDataRemoveClicked(object sender, EventArgs e)
	{
		var key = PersonCustomDataRemoveKey.Text;

		if (!String.IsNullOrEmpty(key)) {
			Apptentive.Default.removeCustomPersonData(key);
			return;
		}

		Console.WriteLine("Missing key");		
	}

	private void OnDeviceCustomStringAddClicked(object sender, EventArgs e) 
	{
		var key = DeviceCustomStringKey.Text;
		var value = DeviceCustomStringValue.Text;

		if (!String.IsNullOrEmpty(key) && !String.IsNullOrEmpty(value)) {
			Apptentive.Default.addCustomDeviceData(key, value);
			return;
		}

		Console.WriteLine("Missing key and/or value");

	}

	private void OnDeviceCustomNumberAddClicked(object sender, EventArgs e) 
	{
		var key = DeviceCustomNumberKey.Text;
		var value = DeviceCustomNumberValue.Text;

		if (!String.IsNullOrEmpty(key) && !String.IsNullOrEmpty(value)) {
			try {
				var numericValue = Double.Parse(value);

				Apptentive.Default.addCustomDeviceData(key, numericValue);
				return;
			}
			catch (Exception exc)
			{
				Console.Write(exc);
			}
		}

		Console.WriteLine("Missing or invalid key and/or value");
	}

	private void OnDeviceCustomBoolAddClicked(object sender, EventArgs e) 
	{
		var key = DeviceCustomBoolKey.Text;
		var value = DeviceCustomBoolValue.IsToggled;

		if (!String.IsNullOrEmpty(key)) {
			Apptentive.Default.addCustomDeviceData(key, value);
			return;
		}
		
		Console.WriteLine("Missing key");		
	}

	private void OnDeviceCustomDataRemoveClicked(object sender, EventArgs e)
	{
		var key = DeviceCustomDataRemoveKey.Text;

		if (!String.IsNullOrEmpty(key)) {
			Apptentive.Default.removeCustomDeviceData(key);
			return;
		}

		Console.WriteLine("Missing key");		
	}

	private void OnLoginClicked(object sender, EventArgs e)
	{
		var token = LoginToken.Text;

		Action<bool, string?> completionHandler = (success, error) => {
			Console.Write("Login ");
			Console.Write(success ? "Did " : "Did not ");
			Console.WriteLine("Complete.");
		};

		if (!String.IsNullOrEmpty(token)) {
			Apptentive.Default.LogIn(token, completionHandler);
			return;
		}

		Console.WriteLine("Missing JWT token");
	}

	private void OnLogoutClicked(object sender, EventArgs e)
	{
		Apptentive.Default.LogOut();
	}
}