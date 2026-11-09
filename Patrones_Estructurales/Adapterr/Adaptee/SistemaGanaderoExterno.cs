using Patrones_Estructurales.Adapterr.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patrones_Estructurales.Adapterr.Adaptee
{
    public class SistemaGanaderoExterno
    {
        public RegistroGanaderoExterno BuscarGanado(
            string caravana)
        {
            if (caravana == "BOV-025")
            {
                return new RegistroGanaderoExterno
                {
                    IdGanado = 25,
                    CodigoCaravana = "BOV-025",
                    NombreGanado = "Estrella",
                    Categoria = "VAC",
                    RazaCodigo = "HOL",
                    FechaNac = "2021-05-12",
                    EstadoReproductivoCodigo = "PC"
                };
            }

            if (caravana == "BOV-031")
            {
                return new RegistroGanaderoExterno
                {
                    IdGanado = 31,
                    CodigoCaravana = "BOV-031",
                    NombreGanado = "Luna",
                    Categoria = "VAQ",
                    RazaCodigo = "JER",
                    FechaNac = "2024-03-15",
                    EstadoReproductivoCodigo = "ND"
                };
            }

            if (caravana == "BOV-042")
            {
                return new RegistroGanaderoExterno
                {
                    IdGanado = 42,
                    CodigoCaravana = "BOV-042",
                    NombreGanado = "Margarita",
                    Categoria = "TER",
                    RazaCodigo = "HOL",
                    FechaNac = "2026-08-10",
                    EstadoReproductivoCodigo = "SE"
                };
            }

            throw new ArgumentException(
                "Animal no encontrado.");
        }
    }
}
