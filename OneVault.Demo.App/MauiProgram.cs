using Microsoft.Extensions.Logging;
using OneVault.Demo.App.Extentions;

namespace OneVault.Demo.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            return builder
                .Configure()
                .Build();
        }
    }
}
