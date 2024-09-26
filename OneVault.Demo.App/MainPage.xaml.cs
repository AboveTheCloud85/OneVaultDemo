using IdentityModel.OidcClient;

namespace OneVault.Demo.App
{
    public partial class MainPage : ContentPage
    {
        private readonly OidcClient _client = default!;

        int count = 0;

        public MainPage(OidcClient client)
        {
            InitializeComponent();

            _client = client;
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            /*count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);*/

            var result = await _client.LoginAsync();

            if (result.IsError)
            {
                //editor.Text = result.Error;
                return;
            }

            var currentAccessToken = result.AccessToken;
        }
    }

}
