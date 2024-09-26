using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdentityModel.Client;
using IdentityModel.OidcClient;
using System.Text.Json;

namespace OneVault.Demo.App.ViewModels
{
    public partial class SecureViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly OidcClient _client;
        private string _accessToken;

        [ObservableProperty]
        private string _apiOutput;

        public SecureViewModel(OidcClient client)
        {
            _client = client;
        }

        public bool CanExecute => !IsLoading;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            _accessToken = query["AccessToken"] as string;
        }

        [RelayCommand(CanExecute = nameof(CanExecute))]
        private async Task ApiTest()
        {
            IsLoading = true;
            ApiTestCommand.NotifyCanExecuteChanged();

            try
            {
                if (_accessToken is null)
                    return;

                var client = new HttpClient();
                client.SetBearerToken(_accessToken);

                var response = await client.GetAsync(Constants.ApiTestURL);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var doc = JsonDocument.Parse(content).RootElement;
                    ApiOutput = JsonSerializer.Serialize(doc, new JsonSerializerOptions { WriteIndented = true });
                }
                else
                {
                    ApiOutput  = response.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                //Log exception
            }
            finally
            {
                IsLoading = false;
                ApiTestCommand.NotifyCanExecuteChanged();
            }
        }

        [RelayCommand(CanExecute = nameof(CanExecute))]
        private async Task QrScan()
        {
            IsLoading = true;
            QrScanCommand.NotifyCanExecuteChanged();

            try
            {
                await Shell.Current.GoToAsync(AppRoutes.QrScanRoute);
            }
            catch (Exception ex)
            {
                //Log exception
            }
            finally
            {
                IsLoading = false;
                QrScanCommand.NotifyCanExecuteChanged();
            }
        }

        [RelayCommand]
        private async Task Logout()
        {
            IsLoading = true;

            try
            {
                await _client.LogoutAsync();
            }
            catch (Exception ex)
            {
                //Log exception
            }
            finally
            {
                await Shell.Current.Navigation.PopAsync(true);
                IsLoading = false;
            }
        }
    }
}
