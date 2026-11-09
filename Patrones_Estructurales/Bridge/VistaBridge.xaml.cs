using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

using Patrones_Estructurales.Bridge.Abstraction;
using Patrones_Estructurales.Bridge.ConcreteImplementor;
using Patrones_Estructurales.Bridge.RefinedAbstraction;

namespace Patrones_Estructurales.Bridge
{
    public partial class VistaBridge : UserControl
    {
        public VistaBridge()
        {
            InitializeComponent();

            CmbFiguras.SelectedIndex = 0;
            CmbColores.SelectedIndex = 0;
        }

        private void BtnDibujar_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (CmbFiguras.SelectedIndex < 0 ||
                CmbColores.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Selecciona una figura y un color.",
                    "Bridge");

                return;
            }

            // 1. Elegir la implementación
            IDibujador dibujador;

            if (CmbColores.SelectedIndex == 0)
            {
                dibujador = new DibujadorRojo();
            }
            else
            {
                dibujador = new DibujadorAzul();
            }

            // 2. Elegir la abstracción
            Figura figura;

            if (CmbFiguras.SelectedIndex == 0)
            {
                figura = new Circulo(dibujador);
            }
            else
            {
                figura = new Rectangulo(dibujador);
            }

            // 3. Construir la figura
            Shape elemento = figura.Dibujar();

            // 4. Mostrar el resultado
            MostrarFigura(elemento);

            TxtResultado.Text =
                "Se dibujó un " +
                figura.Nombre.ToLower() +
                " de color " +
                figura.Color.ToLower() +
                " utilizando Bridge.";
        }

        private void MostrarFigura(Shape elemento)
        {
            Lienzo.Children.Clear();

            double anchoLienzo = Lienzo.ActualWidth;

            if (anchoLienzo <= 0)
            {
                anchoLienzo = 350;
            }

            double posicionX =
                (anchoLienzo - elemento.Width) / 2;

            double posicionY =
                (Lienzo.Height - elemento.Height) / 2;

            Canvas.SetLeft(
                elemento,
                System.Math.Max(0, posicionX));

            Canvas.SetTop(
                elemento,
                System.Math.Max(0, posicionY));

            Lienzo.Children.Add(elemento);
        }
    }
}
