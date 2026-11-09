
using Patrones_Estructurales.Adapterr.Modelos;
using Patrones_Estructurales.Adapterr.Modelos.Patrones_Estructurales.Adapterr.Modelos;

namespace Patrones_Estructurales.Adapterr.Target
{
    public interface IConsultaAnimal
    {
        AnimalVetLink ObtenerAnimal(string codigo);
    }
}
