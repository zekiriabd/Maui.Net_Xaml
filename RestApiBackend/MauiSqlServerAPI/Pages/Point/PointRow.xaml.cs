using MauiFrontendApp.Models;

namespace MauiFrontendApp.Pages;

public partial class PointRow : ViewCell
{

    public PointRow()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        ((PointsListVM)Parent.BindingContext).Delete((PointModel)BindingContext);
    }
}