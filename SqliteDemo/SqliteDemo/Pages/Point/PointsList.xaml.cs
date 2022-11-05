using Microsoft.Toolkit.Mvvm.ComponentModel;
using SqliteDemo.Models;
using SqliteDemo.Services;
using SqliteDemo.Services.Interfaces;

namespace SqliteDemo.Pages;

public partial class PointsList : ContentPage
{
    public PointsList(PointsListVM pointsListVM)
	{
		InitializeComponent();
        BindingContext = pointsListVM;
    }
}
public partial class PointsListVM : ObservableObject
{
    private readonly IPointService _PointService;
    
    [ObservableProperty] private List<PointModel> points;
    public PointsListVM(PointService pointService)
    {
        _PointService = pointService;
        RefreshPointList();
    }
    public async Task RefreshPointList()
    {
        Points = await _PointService.GetAllPoints();
    }

    

}