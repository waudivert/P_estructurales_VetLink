
using Patrones_Estructurales.Adapterr.Adaptee;
using Patrones_Estructurales.Adapterr.Modelos;
using Patrones_Estructurales.Adapterr.Modelos.Patrones_Estructurales.Adapterr.Modelos;
using Patrones_Estructurales.Adapterr.Target;

namespace Patrones_Estructurales.Adapterr.Adapter
{
    public class AnimalAdapter : IConsultaAnimal
    {
        private readonly SistemaGanaderoExterno sistemaExterno;

        public AnimalAdapter(
            SistemaGanaderoExterno sistemaExterno)
        {
            this.sistemaExterno = sistemaExterno;
        }

        public AnimalVetLink ObtenerAnimal(string codigo)
        {
            RegistroGanaderoExterno registro =
                sistemaExterno.BuscarGanado(codigo);

            return new AnimalVetLink
            {
                Id = registro.IdGanado,
                Arete = registro.CodigoCaravana,
                Nombre = registro.NombreGanado,
                Etapa = ConvertirEtapa(registro.Categoria),
                Raza = ConvertirRaza(registro.RazaCodigo),
                FechaNacimiento = registro.FechaNac,
                EstadoReproductivo = ConvertirEstadoReproductivo(
                    registro.EstadoReproductivoCodigo)
            };
        }

        private string ConvertirEtapa(string codigo)
        {
            switch (codigo)
            {
                case "TER":
                    return "Ternera";

                case "VAQ":
                    return "Vaquilla";

                case "VAC":
                    return "Vaca";

                default:
                    return "No determinada";
            }
        }

        private string ConvertirRaza(string codigo)
        {
            switch (codigo)
            {
                case "HOL":
                    return "Holstein";

                case "JER":
                    return "Jersey";

                default:
                    return "No especificada";
            }
        }

        private string ConvertirEstadoReproductivo(string codigo)
        {
            switch (codigo)
            {
                case "PC":
                    return "Preñez confirmada";

                case "ND":
                    return "No determinada";

                case "SE":
                    return "Sin evaluar";

                default:
                    return "No determinada";
            }
        }
    }
}
