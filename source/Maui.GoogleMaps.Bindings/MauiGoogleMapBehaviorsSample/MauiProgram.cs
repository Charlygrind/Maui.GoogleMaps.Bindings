using Maui.GoogleMaps.Hosting;
using MauiGoogleMapBehaviorsSample.Pages;
using MauiGoogleMapBehaviorsSample.ViewModels;

namespace MauiGoogleMapBehaviorsSample
{
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
                }).Services

            //ViewModels
            .AddSingleton<HomeViewModel>()
            //Pages
            .AddSingleton<HomePage>();

#if ANDROID
        builder.UseGoogleMaps();
#elif IOS
            builder.UseGoogleMaps("YOUR-API-KEY");
#endif

            return builder.Build();
        }
    }
}