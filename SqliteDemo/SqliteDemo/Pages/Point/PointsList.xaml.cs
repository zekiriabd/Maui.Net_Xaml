using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using SqliteDemo.Models;
using SqliteDemo.Services.Interfaces;


namespace SqliteDemo.Pages;

public partial class PointsList : ContentPage
{
    private readonly PointsListVM _PointsListVM;
    public PointsList()
    {
        InitializeComponent();
        _PointsListVM = MauiProgram.ServiceProvider.GetService<PointsListVM>();
        BindingContext = _PointsListVM;
        
    }

    private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Shell.Current.GoToAsync($"pointDetail?PointId={((PointModel)e.Item).Id}");
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"pointDetail?PointId=0");
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _PointsListVM.RefreshPointList();
    }
}


public partial class PointsListVM : ObservableObject
{
    private readonly IPointService _PointService;
    
    [ObservableProperty] private List<PointModel> points;
    public PointsListVM()
    {
        _PointService = MauiProgram.ServiceProvider.GetService<IPointService>();
    }

    public async Task RefreshPointList()
    {
        Points = await _PointService.GetAllPoints();
    }

    public async Task Delete(PointModel point)
    {
        await _PointService.DeletePoint(point);
        await RefreshPointList();
    }
}