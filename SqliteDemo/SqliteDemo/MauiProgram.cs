using SqliteDemo.Pages;
using SqliteDemo.Pages.Point;
using SqliteDemo.Services;
using SqliteDemo.Services.Interfaces;

namespace SqliteDemo;

public static class MauiProgram
{
    public static IServiceProvider ServiceProvider;
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

        builder.Services.AddSingleton<PointDetailVM>();
        builder.Services.AddSingleton<PointsListVM>();
        builder.Services.AddSingleton<IPointService, PointService>();

        var app = builder.Build();
        ServiceProvider = app.Services;
        return app;
    }
}
