using SqliteDemo.Pages;
using SqliteDemo.Pages.Point;

namespace SqliteDemo;

public partial class MainLayout : Shell
{
    public MainLayout()
    {
        InitializeComponent();
        Routing.RegisterRoute("pointsList", typeof(PointsList));
        Routing.RegisterRoute("pointDetail", typeof(PointDetail));
    }
}
