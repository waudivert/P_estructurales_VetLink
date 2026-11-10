
using System.Windows;
using System.Windows.Controls;

using Patrones_Estructurales.Decorator.Component;
using Patrones_Estructurales.Decorator.ConcreteComponent;
using Patrones_Estructurales.Decorator.ConcreteDecorator;

namespace Patrones_Estructurales.Decorator
{
    public partial class VistaDecorator : UserControl
    {
        public VistaDecorator()
        {
            InitializeComponent();
        }

        private void BtnPreparar_Click(
            object sender,
            RoutedEventArgs e)
        {
            // Crear la bebida original
            Bebida cafe = new CafeSimple();

            // Agregar decorador de leche
            if (ChkLeche.IsChecked == true)
            {
                cafe = new ConLeche(cafe);
            }

            // Agregar decorador de chocolate
            if (ChkChocolate.IsChecked == true)
            {
                cafe = new ConChocolate(cafe);
            }

            // Mostrar el resultado
            TxtDescripcion.Text =
                cafe.ObtenerDescripcion();

            TxtPrecio.Text =
                $"Bs {cafe.CalcularPrecio():0.00}";
        }
    }
}
