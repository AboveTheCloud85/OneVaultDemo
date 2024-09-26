using OneVault.Demo.App.ViewModels;

namespace OneVault.Demo.App.Pages;

public partial class SecurePage : PageTemplate
{
	public SecurePage(SecureViewModel secureViewModel)
	{
		BindingContext = secureViewModel;
		InitializeComponent();
	}
}