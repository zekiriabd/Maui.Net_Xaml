using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls.StyleSheets;

namespace Stylesheet;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        string IsDarktheme = SecureStorage.Default.GetAsync("IsDarktheme").Result;
        if (!string.IsNullOrEmpty(IsDarktheme))
        {
            Switch1.IsToggled = Convert.ToBoolean(IsDarktheme);
        }
    }

	private void Switch1_Toggled(object sender, ToggledEventArgs e)
	{
		if (e.Value)
		{
			Application.Current.UserAppTheme = AppTheme.Dark;
		}
		else
		{
			Application.Current.UserAppTheme = AppTheme.Light;
		}
        SecureStorage.Default.SetAsync("IsDarktheme", e.Value.ToString());
    }
}

