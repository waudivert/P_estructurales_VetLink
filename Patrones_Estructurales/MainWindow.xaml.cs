using System.Windows;
using System.Windows.Controls;

namespace Patrones_Estructurales
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MostrarInicio();
        }

        private void MostrarInicio()
        {
            ContenedorContenido.Content = new TextBlock
            {
                Text = "Selecciona un patrón del menú para comenzar.",
                FontSize = 18,
                Margin = new Thickness(15),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
        }

        private void BtnAdapter_Click(object sender, RoutedEventArgs e)
        {
            ContenedorContenido.Content = new Adapterr.VistaAdapter();
        }

        private void BtnBridge_Click(object sender, RoutedEventArgs e)
        {
            ContenedorContenido.Content = new Bridge.VistaBridge();
        }

        private void BtnComposite_Click(object sender, RoutedEventArgs e)
        {
            ContenedorContenido.Content = new Composite.VistaComposite();
        }

        private void BtnDecorator_Click(object sender, RoutedEventArgs e)
        {
            ContenedorContenido.Content = new Decorator.VistaDecorator();
        }

        private void BtnFacade_Click(object sender, RoutedEventArgs e)
        {
            ContenedorContenido.Content = new Facade.VistaFacade();
        }

        private void BtnProxy_Click(object sender, RoutedEventArgs e)
        {
            ContenedorContenido.Content = new Proxy.VistaProxy();
        }

        private void BtnFlyweight_Click(object sender, RoutedEventArgs e)
        {
            ContenedorContenido.Content = new Flyweight.VistaFlyweight();
        }
    }
}
