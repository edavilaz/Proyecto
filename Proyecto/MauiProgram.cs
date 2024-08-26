using Microsoft.Extensions.Logging;
using Proyecto.Data;

namespace Proyecto
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
                    fonts.AddFont("ROBOTO-LIGHT", "light");
                    fonts.AddFont("ROBOTO-MEDIUM", "medium");
                    fonts.AddFont("ROBOTO-REGULAR", "regular");
                    fonts.AddFont("Font Awesome 6 Duotone-Solid-900.otf", "AwesomeSolid");
                });

            string dbPath = FileAccessHelper.GetLocalFilePath("userdb.db3");

            builder.Services.AddSingleton<UserDatabase>
                (s => ActivatorUtilities.CreateInstance<UserDatabase>(s, dbPath));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
