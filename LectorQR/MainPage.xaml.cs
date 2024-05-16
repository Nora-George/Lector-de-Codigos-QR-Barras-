using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace LectorQR
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnScanClicked(object sender, EventArgs e)
        {
            var options = new ZXing.Mobile.MobileBarcodeScanningOptions();
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();

            var result = await scanner.Scan(options);

            if (result != null)
            {
               
                await DisplayAlert("Resultado", result.Text, "OK");
            }
        }

        private void OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (result != null && !string.IsNullOrEmpty(result.Text))
                {
                
                    await DisplayAlert("Resultado", result.Text, "OK");
                }
            });
        }
    }
}
