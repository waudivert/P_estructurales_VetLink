
using Patrones_Estructurales.Composite.Component;

namespace Patrones_Estructurales.Composite.Leaf
{
    public class Archivo : ElementoSistema
    {
        private readonly int tamaño;

        public Archivo(string nombre, int tamaño)
            : base(nombre)
        {
            this.tamaño = tamaño;
        }

        public override int ObtenerTamaño()
        {
            return tamaño;
        }
    }
}
