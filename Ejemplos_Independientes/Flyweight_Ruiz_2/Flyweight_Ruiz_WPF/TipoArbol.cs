using System.Windows.Media;

namespace Flyweight_Ruiz_WPF;

// FLYWEIGHT: datos compartidos de cada especie. No guarda posiciones.
public sealed class TipoArbol
{
    public string Nombre { get; }
    public string Color { get; }
    public string Apariencia { get; }
    public Brush Copa { get; }
    public Brush Tronco { get; }

    public TipoArbol(string nombre, string color, string apariencia, Color colorCopa)
    {
        Nombre = nombre;
        Color = color;
        Apariencia = apariencia;
        var copa = new SolidColorBrush(colorCopa);
        copa.Freeze(); // Se reutiliza el mismo pincel para todos los árboles del tipo.
        Copa = copa;
        var tronco = new SolidColorBrush(System.Windows.Media.Color.FromRgb(116, 78, 53));
        tronco.Freeze();
        Tronco = tronco;
    }
}
