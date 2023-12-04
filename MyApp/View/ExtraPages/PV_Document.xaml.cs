namespace MyApp;

public partial class PV_Document : ContentPage
{
	public PV_Document()
	{
		InitializeComponent();

        SectionB.IsVisible = false;

        // Attach event handlers to the buttons
        SignButton.Clicked += OnSignButtonClicked;
        DownloadButton.Clicked += OnDownloadButtonClicked;
    }

    private void OnSignButtonClicked(object sender, EventArgs e)
    {
        // Show section A and hide section B
        SectionA.IsVisible = true;
        SectionB.IsVisible = false;
    }

    private void OnDownloadButtonClicked(object sender, EventArgs e)
    {
        // Show section B and hide section A
        SectionA.IsVisible = false;
        SectionB.IsVisible = true;
    }
}