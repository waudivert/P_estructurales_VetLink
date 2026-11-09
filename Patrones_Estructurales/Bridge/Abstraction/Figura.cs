using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Shapes;


namespace Patrones_Estructurales.Bridge.Abstraction
{
    public abstract class Figura
    {
        protected readonly IDibujador dibujador;

        protected Figura(IDibujador dibujador)
        {
            this.dibujador = dibujador;
        }

        public abstract string Nombre { get; }

        public string Color => dibujador.NombreColor;

        public abstract Shape Dibujar();
    }
}