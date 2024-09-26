using OneVault.Demo.App.ViewModels;

namespace OneVault.Demo.App.Pages
{
    public abstract class ContentPageBase : ContentPage
    {
        public ContentPageBase()
        {
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var vm = BindingContext as BaseViewModel;
            
            if (vm is null)
                return;

            if (!vm.IsInitialized)
            {
                vm.IsInitialized = true;
                await vm.InitializeAsync().ConfigureAwait(false);
            }
        }
    }
}
