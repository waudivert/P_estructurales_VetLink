
using Patrones_Estructurales.Decorator.Component;

namespace Patrones_Estructurales.Decorator.DecoratorBase
{
    public abstract class BebidaDecorator : Bebida
    {
        protected readonly Bebida bebida;

        protected BebidaDecorator(Bebida bebida)
        {
            this.bebida = bebida;
        }

        public override string ObtenerDescripcion()
        {
            return bebida.ObtenerDescripcion();
        }

        public override decimal CalcularPrecio()
        {
            return bebida.CalcularPrecio();
        }
    }
}
