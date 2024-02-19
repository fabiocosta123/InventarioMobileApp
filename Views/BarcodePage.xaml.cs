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
       
        foreach (var barcode in e.Results)
        {
            //cameraBarcodeReaderView.IsDetecting = false;
            Console.WriteLine($"Barcodes: {barcode.Format} -> {barcode.Value}");
            WeakReferenceMessenger.Default.Send<string>(barcode.Value);
           
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        cameraBarcodeReaderView.IsDetecting = true;
        cameraBarcodeReaderView.Options = new ZXing.Net.Maui.BarcodeReaderOptions
        {
            Formats = ZXing.Net.Maui.BarcodeFormat.Ean13
            | ZXing.Net.Maui.BarcodeFormat.Ean8
            | ZXing.Net.Maui.BarcodeFormat.QrCode,
            AutoRotate = true,
            Multiple = false,

        };

    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        cameraBarcodeReaderView.IsDetecting = false;
    }
}