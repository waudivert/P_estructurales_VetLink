
using Patrones_Estructurales.Decorator.Component;
using Patrones_Estructurales.Decorator.DecoratorBase;

namespace Patrones_Estructurales.Decorator.ConcreteDecorator
{
    public class ConChocolate : BebidaDecorator
    {
        public ConChocolate(Bebida bebida)
            : base(bebida)
        {
        }

        public override string ObtenerDescripcion()
        {
            return bebida.ObtenerDescripcion() + " + Chocolate";
        }

        public override decimal CalcularPrecio()
        {
            return bebida.CalcularPrecio() + 5;
        }
    }
}
