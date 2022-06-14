namespace Content_Page;

public partial class AppShell : Shell
{
    public AppShell()
    {
        Routing.RegisterRoute("page1", typeof(Page1));
        Routing.RegisterRoute("page2", typeof(Page2));
        InitializeComponent();
    }
}
