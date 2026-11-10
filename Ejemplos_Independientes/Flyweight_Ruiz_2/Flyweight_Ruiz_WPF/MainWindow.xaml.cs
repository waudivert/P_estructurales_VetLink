using System.Windows;

namespace Flyweight_Ruiz_WPF;

public partial class MainWindow : Window
{
    private readonly FabricaArboles fabrica = new();
    private readonly List<Arbol> arboles = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void GenerarCinco_Click(object sender, RoutedEventArgs e) => Generar(5);
    private void GenerarCien_Click(object sender, RoutedEventArgs e) => Generar(100);

    private void Generar(int cantidad)
    {
        arboles.Clear();
        // Pedir el mismo tipo dos veces demuestra que NO se crea otra instancia.
        var pino = fabrica.Obtener("Pino");
        var roble = fabrica.Obtener("Roble");
        var pinoRepetido = fabrica.Obtener("Pino");

        var ancho = Math.Max(550, BosqueCanvas.ActualWidth);
        var alto = Math.Max(250, BosqueCanvas.ActualHeight);
        var random = new Random(42); // Posiciones repetibles para una exposición.

        for (int i = 0; i < cantidad; i++)
        {
            var tipo = i % 2 == 0 ? pino : roble;
            var x = 32 + random.NextDouble() * Math.Max(1, ancho - 64);
            var y = 72 + random.NextDouble() * Math.Max(1, alto - 100);
            arboles.Add(new Arbol(x, y, tipo));
        }

        ConteoArboles.Text = arboles.Count.ToString();
        ConteoTipos.Text = fabrica.CantidadTipos.ToString();
        ResultadoReutilizacion.Text = ReferenceEquals(pino, pinoRepetido) ? "SÍ" : "NO";
        Mensaje.Text = $"{cantidad} árboles dibujados con solo {fabrica.CantidadTipos} tipos compartidos. Cada árbol tiene coordenadas propias.";
        DibujarBosque();
    }

    private void DibujarBosque()
    {
        BosqueCanvas.Children.Clear();
        var escala = arboles.Count > 50 ? 0.53 : 1.0;
        foreach (var arbol in arboles)
            arbol.Dibujar(BosqueCanvas, escala);
    }

    private void Limpiar_Click(object sender, RoutedEventArgs e)
    {
        arboles.Clear();
        BosqueCanvas.Children.Clear();
        ConteoArboles.Text = "0";
        ConteoTipos.Text = fabrica.CantidadTipos.ToString();
        ResultadoReutilizacion.Text = "—";
        Mensaje.Text = "Bosque limpiado. La fábrica conserva los tipos que ya creó para reutilizarlos.";
    }

    private void BosqueCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        // Volver a generar solo si se desea; al cambiar tamaño se conserva el bosque actual.
        if (arboles.Count > 0) DibujarBosque();
    }
}
