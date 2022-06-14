namespace Content_Page;

public partial class Page2 : ContentPage
{
	public Page2()
	{
		InitializeComponent();
	}

    private void CounterBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("page1");
    }
}