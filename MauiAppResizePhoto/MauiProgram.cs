using CommunityToolkit.Maui;
using MauiAppResizePhoto.ViewModels;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;

namespace MauiAppResizePhoto;

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
			})
            .UseMauiCommunityToolkit();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainPageViewModel>();	

		return builder.Build();

    }



}
