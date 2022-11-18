using Microsoft.Toolkit.Mvvm.ComponentModel;
using MauiFrontendApp.Models;
using MauiFrontendApp.Services.Interfaces;

namespace MauiFrontendApp.Pages;

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
    //private readonly IPointService _PointService;
    private readonly IRefitServices _RefitServices;
    

    [ObservableProperty] private IEnumerable<PointModel> points;
    public PointsListVM()
    {
        _RefitServices = MauiProgram.ServiceProvider.GetService<IRefitServices>();
    }

    public async Task RefreshPointList()
    {
        Points = await _RefitServices.GetAllPoints();
    }

    public async Task Delete(PointModel point)
    {
            await _RefitServices.DeletePoint(point.Id);
            await RefreshPointList();
    }


}