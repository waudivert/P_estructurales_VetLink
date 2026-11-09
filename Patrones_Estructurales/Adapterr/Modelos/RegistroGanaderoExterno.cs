using System;
using System.Collections.Generic;
using System.Text;

namespace Patrones_Estructurales.Adapterr.Modelos
{
    public class RegistroGanaderoExterno
    {
        public int IdGanado { get; set; }

        public string CodigoCaravana { get; set; } = "";

        public string NombreGanado { get; set; } = "";

        public string Categoria { get; set; } = "";

        public string RazaCodigo { get; set; } = "";

        public string FechaNac { get; set; } = "";

        public string EstadoReproductivoCodigo { get; set; } = "";
    }
}
