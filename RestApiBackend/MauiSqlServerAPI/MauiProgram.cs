using CommunityToolkit.Maui;
using MauiFrontendApp.Pages;
using MauiFrontendApp.Pages.Point;
using MauiFrontendApp.Services;
using MauiFrontendApp.Services.Interfaces;
using Refit;

namespace MauiFrontendApp;

public static class MauiProgram
{
    public static IServiceProvider ServiceProvider;
    public static MauiApp CreateMauiApp()
	{
        var builder = MauiApp.CreateBuilder();
		builder.UseMauiApp<App>()
                .UseMauiApp<App>().UseMauiCommunityToolkit()
			    .ConfigureFonts(fonts =>
			    {
				    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			    });

        builder.Services.AddRefitClient<IRefitServices>().ConfigureHttpClient(
            c => c.BaseAddress = new Uri("http://localhost:5067"));

        builder.Services.AddSingleton<PointDetailVM>();
        builder.Services.AddSingleton<PointsListVM>();

        var app = builder.Build();
        ServiceProvider = app.Services;
        return app;
    }
}
