using SqliteDemo.Pages;
using SqliteDemo.Services;
using SqliteDemo.Services.Interfaces;

namespace SqliteDemo;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<IPointService, PointService>();

        builder.Services.AddSingleton<PointsListVM>();

        builder.Services.AddSingleton<PointsList>();        

        return builder.Build();
    }
}
