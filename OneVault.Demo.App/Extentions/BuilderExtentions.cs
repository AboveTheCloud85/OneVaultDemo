using CommunityToolkit.Maui;
using IdentityModel.OidcClient;
using Microsoft.Extensions.Logging;
using OneVault.Demo.App.Pages;
using OneVault.Demo.App.ViewModels;
using ZXing.Net.Maui.Controls;

namespace OneVault.Demo.App.Extentions
{
    internal static class BuilderExtentions
    {
        public static MauiAppBuilder Configure(this MauiAppBuilder builder)
        {
            builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseBarcodeReader()
            .RegisterServices()
            .RegisterViewModels()
            .RegisterPages()
            .ConfigureAppRouting()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder;
        }

        private static MauiAppBuilder ConfigureAppRouting(this MauiAppBuilder builder)
        {
            Routing.RegisterRoute(AppRoutes.AppShellRoute, typeof(AppShell));
            Routing.RegisterRoute(AppRoutes.LoginRoute, typeof(LoginPage));
            Routing.RegisterRoute(AppRoutes.SecureRoute, typeof(SecurePage));
            Routing.RegisterRoute(AppRoutes.QrScanRoute, typeof(QrScanPage));

            return builder;
        }

        private static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
        {
            builder
                .Services
                    .AddTransient<AppShell>()
                    .AddTransient<LoginPage>()
                    .AddTransient<SecurePage>()
                    .AddTransient<QrScanPage>();
            return builder;
        }

        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder
                .Services
                .AddTransient<LoginViewModel>()
                .AddTransient<SecureViewModel>();

            return builder;
        }

        private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton(new OidcClient(new()
            {
                Authority = "https://demo.duendesoftware.com",
                ClientId = "interactive.public",
                Scope = "openid profile api",
                RedirectUri = "onevaultdemo://",
                Browser = new MauiAuthenticationBrowser()
            }));

            return builder;
        }
    }
}
