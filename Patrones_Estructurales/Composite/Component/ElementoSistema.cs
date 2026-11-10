
namespace Patrones_Estructurales.Composite.Component
{
    public abstract class ElementoSistema
    {
        public string Nombre { get; }

        protected ElementoSistema(string nombre)
        {
            Nombre = nombre;
        }

        public abstract int ObtenerTamaño();
    }
}
