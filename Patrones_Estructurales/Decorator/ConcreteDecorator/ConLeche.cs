
using Patrones_Estructurales.Decorator.Component;
using Patrones_Estructurales.Decorator.DecoratorBase;

namespace Patrones_Estructurales.Decorator.ConcreteDecorator
{
    public class ConLeche : BebidaDecorator
    {
        public ConLeche(Bebida bebida)
            : base(bebida)
        {
        }

        public override string ObtenerDescripcion()
        {
            return bebida.ObtenerDescripcion() + " + Leche";
        }

        public override decimal CalcularPrecio()
        {
            return bebida.CalcularPrecio() + 3;
        }
    }
}
