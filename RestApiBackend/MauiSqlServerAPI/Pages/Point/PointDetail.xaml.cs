using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MauiFrontendApp.Models;
using MauiFrontendApp.Services.Interfaces;
using System.Windows.Input;

namespace MauiFrontendApp.Pages.Point;

public partial class PointDetail : ContentPage
{
    private readonly PointDetailVM pointDetailVM;
    public PointDetail()
	{
		InitializeComponent();
        pointDetailVM  = MauiProgram.ServiceProvider.GetService<PointDetailVM>();
        BindingContext = pointDetailVM;
    }
}






[QueryProperty(nameof(PointId), "PointId")]
public partial class PointDetailVM : ObservableObject
{

    public string PointId { set => RefreshPoint(int.Parse(value)); }

    //private readonly IPointService _PointService;
    private readonly IRefitServices _RefitServices;

    [ObservableProperty] private PointModel point;    
    [ObservableProperty] private ICommand titleValidatorCommand;
    [ObservableProperty] private bool titleValid;
    [ObservableProperty] private ICommand pointValidatorCommand;
    [ObservableProperty] private bool pointValid;

    public PointDetailVM()
    {
        //_PointService = MauiProgram.ServiceProvider.GetService<IPointService>();
        _RefitServices = MauiProgram.ServiceProvider.GetService<IRefitServices>();
    }

    private async Task RefreshPoint(int id)
    {
        Point = (id == 0) ? new PointModel() { Id = 0 } :
                            await _RefitServices.GetPointById(id);
    }

    [ICommand]
    public async Task Save()
    {
        titleValidatorCommand?.Execute(null);
        pointValidatorCommand?.Execute(null);
        if (titleValid && pointValid)
        {
            if (Point.Id > 0)
            {
                await _RefitServices.UpdatePoint(Point);
            }
            else
            {
                await _RefitServices.InsertPoint(Point);
            }
            await Shell.Current.GoToAsync("pointsList");
        }
    }
}