using Microsoft.AspNetCore.Components.WebView.Maui;

using TeachingEvaluationSystem.DB;
using TeachingEvaluationSystem.Service;
using TeachingEvaluationSystem.Service.Framework;
using TeachingEvaluationSystem.Service.Global;

namespace TeachingEvaluationSystem;

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
            });

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif
        builder.Services.AddTES();
        builder.Services.AddTDesign();
        return builder.Build();
    }
}
