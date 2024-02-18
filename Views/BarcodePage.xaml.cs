using CommunityToolkit.Mvvm.Messaging;

namespace InventarioMobileApp.Views;

public partial class BarcodePage : ContentPage
{
    public BarcodePage(BarcodeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void cameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        cameraBarcodeReaderView.IsDetecting = false;
        foreach (var barcode in e.Results)
        {
            Console.WriteLine($"Barcodes: {barcode.Format} -> {barcode.Value}");
            WeakReferenceMessenger.Default.Send<string>(barcode.Value);
            Shell.Current.GoToAsync("..");
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        cameraBarcodeReaderView.Options = new ZXing.Net.Maui.BarcodeReaderOptions
        {
            Formats = ZXing.Net.Maui.BarcodeFormat.Ean13
            | ZXing.Net.Maui.BarcodeFormat.Ean8
            | ZXing.Net.Maui.BarcodeFormat.QrCode,
            AutoRotate = true,
            Multiple = false,

        };

    }
}