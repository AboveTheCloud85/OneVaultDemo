namespace OneVault.Demo.App.Pages;

public partial class QrScanPage : ContentPage
{
	public QrScanPage()
	{
		InitializeComponent();

        qrCodeScanner.Options = new ZXing.Net.Maui.BarcodeReaderOptions
        {
            Formats = ZXing.Net.Maui.BarcodeFormat.QrCode,
            Multiple = false
        };
    }

    private void qrCodeScanner_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        MainThread.InvokeOnMainThreadAsync(async () =>
        {
            await DisplayAlert("QR Code detected", e.Results[0].Value, "OK");
        });
    }
}