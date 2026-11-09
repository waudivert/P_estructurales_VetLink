
using System.Windows.Media;
using System.Windows.Shapes;

namespace Patrones_Estructurales.Bridge.ConcreteImplementor
{
    public class DibujadorAzul : IDibujador
    {
        public string NombreColor => "Azul";

        public Shape DibujarCirculo()
        {
            return new Ellipse
            {
                Width = 150,
                Height = 150,
                Fill = Brushes.SteelBlue,
                Stroke = Brushes.DarkBlue,
                StrokeThickness = 3
            };
        }

        public Shape DibujarRectangulo()
        {
            return new Rectangle
            {
                Width = 200,
                Height = 120,
                Fill = Brushes.SteelBlue,
                Stroke = Brushes.DarkBlue,
                StrokeThickness = 3,
                RadiusX = 6,
                RadiusY = 6
            };
        }
    }
}
