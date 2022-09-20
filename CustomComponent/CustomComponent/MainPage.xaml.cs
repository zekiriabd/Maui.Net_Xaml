using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CustomComponent.Models;

namespace CustomComponent;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        var labelM = ApplicationState.GetInstance().LabelMessage;
        labelM.MText = Entry1.Text;
        labelM.MColor = Colors.Red;
    }

    //private void Button_Clicked(object sender, EventArgs e)
    //{
    //	LabelM labelM = new() { MText = Entry1.Text, MColor = Colors.Red };
    //  MessagingCenter.Send<Page, LabelM>(this, "MyMessage", labelM);
    //}
}