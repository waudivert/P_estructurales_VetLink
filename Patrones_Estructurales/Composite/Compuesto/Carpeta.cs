
using System.Collections.Generic;
using Patrones_Estructurales.Composite.Component;

namespace Patrones_Estructurales.Composite.Compuesto
{
    public class Carpeta : ElementoSistema
    {
        public List<ElementoSistema> Elementos { get; }
            = new List<ElementoSistema>();

        public Carpeta(string nombre)
            : base(nombre)
        {
        }

        public void Agregar(ElementoSistema elemento)
        {
            Elementos.Add(elemento);
        }

        public override int ObtenerTamaño()
        {
            int total = 0;

            foreach (ElementoSistema elemento in Elementos)
            {
                total += elemento.ObtenerTamaño();
            }

            return total;
        }
    }
}
