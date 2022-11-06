using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using SqliteDemo.Models;
using SqliteDemo.Services.Interfaces;

namespace SqliteDemo.Pages.Point;

public partial class PointDetail : ContentPage
{
	public PointDetail()
	{
		InitializeComponent();
        BindingContext = MauiProgram.ServiceProvider.GetService<PointDetailVM>();
    }
}

[QueryProperty(nameof(PointId), "PointId")]
public partial class PointDetailVM : ObservableObject
{

    public string PointId { set => RefreshPoint(int.Parse(value)); }

    private readonly IPointService _PointService;
    [ObservableProperty] private PointModel point;

    public PointDetailVM()
    {
        _PointService = MauiProgram.ServiceProvider.GetService<IPointService>();
    }

    private async Task RefreshPoint(int id)
    {
        Point = (id == 0) ? new PointModel() { Id = 0 } :
                            await _PointService.GetPointById(id);
    }

    [ICommand]
    public async Task Save()
    {
        if (Point.Id > 0)
        {
            await _PointService.UpdatePoint(Point);
        }
        else
        {
            await _PointService.InsertPoint(Point);
        }
        await Shell.Current.GoToAsync("pointsList");
    }
}