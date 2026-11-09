
using System.Windows.Shapes;
using Patrones_Estructurales.Bridge.Abstraction;

namespace Patrones_Estructurales.Bridge.RefinedAbstraction
{
    public class Circulo : Figura
    {
        public Circulo(IDibujador dibujador)
            : base(dibujador)
        {
        }

        public override string Nombre => "Círculo";

        public override Shape Dibujar()
        {
            return dibujador.DibujarCirculo();
        }
    }
}
