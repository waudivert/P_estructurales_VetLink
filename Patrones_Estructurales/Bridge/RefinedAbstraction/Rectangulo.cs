
using System.Windows.Shapes;
using Patrones_Estructurales.Bridge.Abstraction;

namespace Patrones_Estructurales.Bridge.RefinedAbstraction
{
    public class Rectangulo : Figura
    {
        public Rectangulo(IDibujador dibujador)
            : base(dibujador)
        {
        }

        public override string Nombre => "Rectángulo";

        public override Shape Dibujar()
        {
            return dibujador.DibujarRectangulo();
        }
    }
}
