using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Patrones_Estructurales.Facade
{
    public partial class VistaFacade : UserControl
    {
        private readonly Sesion sesion = new();
        private readonly Granjas granjas = new();

        public VistaFacade()
        {
            InitializeComponent();
        }

        private async void BtnIniciar_Click(object sender, RoutedEventArgs e)
        {
            BtnIniciar.IsEnabled = false;
            TxtMensaje.Text = "";

            // 1. Login llama a Iniciar() con correo y clave.
            string? error = await sesion.Iniciar(TxtCorreo.Text, TxtClave.Password);

            BtnIniciar.IsEnabled = true;

            // 5. Login entra o muestra el mensaje.
            if (error != null)
            {
                TxtMensaje.Text = error;
                return;
            }

            PanelLogin.Visibility = Visibility.Collapsed;
            PanelGranja.Visibility = Visibility.Visible;
            TxtBienvenida.Text = "Sesión iniciada como " + TxtCorreo.Text.Trim();

            await CargarResumen();
        }

        private async Task CargarResumen()
        {
            TxtTiempo.Text = "Cargando resumen...";

            Stopwatch reloj = Stopwatch.StartNew();
            ResumenGranja resumen = await granjas.Resumen();
            reloj.Stop();

            TxtAnimales.Text = resumen.Animales.ToString();
            TxtAvisos.Text = resumen.Avisos.ToString();
            TxtMiembros.Text = resumen.Miembros.ToString();
            TxtTiempo.Text = "4 consultas en paralelo, listas en " + reloj.ElapsedMilliseconds + " ms";
        }
    }
}
