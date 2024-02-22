using Plugin.Maui.Apptentive;

namespace Plugin.Maui.Apptentive.Sample;

public partial class MainPage : ContentPage
{
	int count = 0;

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
}


