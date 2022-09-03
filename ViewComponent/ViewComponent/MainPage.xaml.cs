using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

namespace ViewComponent;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
}

public partial class MainPageViewModel : ObservableObject
{
    public MainPageViewModel()
    {
        NumList = new List<string> { "A", "B", "C", "D" };
    }
    [ObservableProperty]
    private List<string> numList;
}







