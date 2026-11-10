using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Patrones_Estructurales.Proxy
{
    public partial class VistaProxy : UserControl
    {
        private readonly ServicioClimaProxy servicio = new();

        public VistaProxy()
        {
            InitializeComponent();
        }

        private async void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            string ciudad = (CmbCiudad.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "";

            BtnConsultar.IsEnabled = false;
            TxtResultado.Text = "Consultando...";
            TxtOrigen.Text = "";

            Stopwatch reloj = Stopwatch.StartNew();
            string clima = await Task.Run(() => servicio.ObtenerClima(ciudad));
            reloj.Stop();

            TxtResultado.Text = clima;
            TxtOrigen.Text = (servicio.UltimaDesdeCache
                                 ? "Respondido por el proxy (caché)"
                                 : "Respondido por el servicio real")
                             + " en " + reloj.ElapsedMilliseconds + " ms";

            BtnConsultar.IsEnabled = true;
        }
    }
}
