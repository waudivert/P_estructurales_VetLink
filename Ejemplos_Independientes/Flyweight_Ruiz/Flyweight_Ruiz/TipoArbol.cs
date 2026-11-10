namespace Flyweight_Ruiz;

// Flyweight: almacena características que comparten varios árboles.
internal sealed class TipoArbol
{
    private readonly string nombre;
    private readonly string color;
    private readonly string apariencia;

    public TipoArbol(string nombre, string color, string apariencia)
    {
        this.nombre = nombre;
        this.color = color;
        this.apariencia = apariencia;
    }

    public void Dibujar(int x, int y)
    {
        Console.WriteLine($"{nombre} ({color}, {apariencia}) en ({x}, {y})");
    }
}
