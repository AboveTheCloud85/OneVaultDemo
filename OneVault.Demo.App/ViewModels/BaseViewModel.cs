using CommunityToolkit.Mvvm.ComponentModel;

namespace OneVault.Demo.App.ViewModels
{
    public abstract partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isLoading;

        [ObservableProperty]
        private string _loadingMessage;

        public bool IsInitialized { get; set; }

        public BaseViewModel() { }

        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
