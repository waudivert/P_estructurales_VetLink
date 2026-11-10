
using Patrones_Estructurales.Decorator.Component;

namespace Patrones_Estructurales.Decorator.ConcreteComponent
{
    public class CafeSimple : Bebida
    {
        public override string ObtenerDescripcion()
        {
            return "Café básico";
        }

        public override decimal CalcularPrecio()
        {
            return 10;
        }
    }
}
