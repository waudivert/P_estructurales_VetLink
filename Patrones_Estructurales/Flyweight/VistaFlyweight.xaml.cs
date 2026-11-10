
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Patrones_Estructurales.Flyweight
{
    public partial class VistaFlyweight : UserControl
    {
        // La fábrica conserva los tipos compartidos.
        private readonly FabricaArboles fabrica = new();

        // Cada árbol conserva su propia posición.
        private readonly List<Arbol> arboles = new();

        public VistaFlyweight()
        {
            InitializeComponent();
            GenerarBosque(5);
        }

        private void BtnCinco_Click(object sender, RoutedEventArgs e)
        {
            GenerarBosque(5);
        }

        private void BtnCien_Click(object sender, RoutedEventArgs e)
        {
            GenerarBosque(100);
        }

        private void GenerarBosque(int cantidad)
        {
            arboles.Clear();
            BosqueCanvas.Children.Clear();

            // Se obtienen los tipos compartidos.
            TipoArbol pino = fabrica.Obtener("Pino");
            TipoArbol roble = fabrica.Obtener("Roble");

            // Pedir Pino nuevamente devuelve el mismo objeto.
            TipoArbol otroPino = fabrica.Obtener("Pino");
            bool reutilizado = ReferenceEquals(pino, otroPino);

            Random random = new Random(42);

            for (int i = 0; i < cantidad; i++)
            {
                TipoArbol tipo = i % 2 == 0 ? pino : roble;

                double x = 35 + random.NextDouble() * 680;
                double y = 75 + random.NextDouble() * 245;

                Arbol arbol = new Arbol(x, y, tipo);
                arboles.Add(arbol);
            }

            double escala = cantidad >= 100 ? 0.55 : 1.0;

            foreach (Arbol arbol in arboles)
            {
                arbol.Dibujar(BosqueCanvas, escala);
            }

            TxtArboles.Text = arboles.Count.ToString();
            TxtTipos.Text = fabrica.CantidadTipos.ToString();
            TxtReutilizacion.Text = reutilizado ? "Sí" : "No";

            TxtExplicacion.Text =
                $"Se dibujaron {cantidad} árboles utilizando " +
                $"solo {fabrica.CantidadTipos} tipos compartidos. " +
                "Cada árbol mantiene sus propias coordenadas X e Y.";
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            arboles.Clear();
            BosqueCanvas.Children.Clear();

            TxtArboles.Text = "0";
            TxtTipos.Text = fabrica.CantidadTipos.ToString();
            TxtReutilizacion.Text = "Sin prueba";

            TxtExplicacion.Text =
                "El bosque se limpió, pero la fábrica conserva " +
                "los tipos compartidos para reutilizarlos.";
        }
    }
}
