using MauiFrontendApp.Pages;
using MauiFrontendApp.Pages.Point;

namespace MauiFrontendApp;

public partial class MainLayout : Shell
{
    public MainLayout()
    {
        InitializeComponent();
        Routing.RegisterRoute("pointsList", typeof(PointsList));
        Routing.RegisterRoute("pointDetail", typeof(PointDetail));
    }
}
