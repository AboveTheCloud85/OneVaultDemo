using Android.App;
using Android.Content.PM;

namespace OneVault.Demo.App.Platforms
{
    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
    [IntentFilter([Android.Content.Intent.ActionView],
              Categories = [Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable],
              DataScheme = "onevaultdemo")]
    public class WebAuthenticationCallbackActivity : WebAuthenticatorCallbackActivity
    {

    }
}
