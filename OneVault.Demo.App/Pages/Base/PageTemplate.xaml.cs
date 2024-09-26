namespace OneVault.Demo.App.Pages;

public partial class PageTemplate : ContentPageBase
{
	public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create(
		propertyName: nameof(IsLoading),
		returnType: typeof(bool),
		declaringType: typeof(PageTemplate),
		defaultValue: null);

	public PageTemplate()
	{
		InitializeComponent();
	}

	public bool IsLoading
	{
		get => (bool)GetValue(IsLoadingProperty);
		set => SetValue(IsLoadingProperty, value);
	}
}