using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdentityModel.OidcClient;

namespace OneVault.Demo.App.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly OidcClient _client;
        private string _username;
        private string _password;

        [ObservableProperty]
        private string _loginError;

        public LoginViewModel(OidcClient client)
        {
            _client = client;
        }

        public bool CanExecuteSubmit => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password) && !IsLoading;

        public string Username
        {
            get => _username;
            set
            {
                SetProperty(ref _username, value);
                LoginCommand.NotifyCanExecuteChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);
                LoginCommand.NotifyCanExecuteChanged();
            }
        }

        [RelayCommand(CanExecute = nameof(CanExecuteSubmit))]
        private async Task Login()
        {
            IsLoading = true;

            try
            {
                var result = await _client.LoginAsync();

                if (result.IsError)
                {
                    LoginError = result.Error;
                    return;
                }

                await Shell.Current.GoToAsync(AppRoutes.SecureRoute, new Dictionary<string, object> { { "AccessToken", result.AccessToken } });

                Username = string.Empty;
                Password = string.Empty;
            }
            catch (Exception ex)
            {
                //Log exception
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
