using Microsoft.Extensions.Logging;

namespace TrivialGeografico
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
                    fonts.AddFont("consola.ttf", "Consola");
                    fonts.AddFont("consolab.ttf", "Consola Bold");
                    fonts.AddFont("consolai.ttf", "Consola Italic");
                    fonts.AddFont("consolaz.ttf", "Consola Bold Italic");
                    fonts.AddFont("vgasys.fon", "System");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
