namespace Content_Page;

public partial class Page1 : ContentPage
{
	public Page1()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync("page2");
    }
}

