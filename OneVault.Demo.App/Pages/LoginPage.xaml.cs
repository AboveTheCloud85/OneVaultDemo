using OneVault.Demo.App.ViewModels;

namespace OneVault.Demo.App.Pages;

public partial class LoginPage : PageTemplate
{
	public LoginPage(LoginViewModel loginViewModel)
	{
		BindingContext = loginViewModel;
		InitializeComponent();
	}
}