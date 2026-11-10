namespace Flyweight_Ruiz;

// Cada árbol tiene su propia posición, pero comparte un TipoArbol.
internal sealed class Arbol
{
    private readonly int x;
    private readonly int y;
    private readonly TipoArbol tipo;

    public Arbol(int x, int y, TipoArbol tipo)
    {
        this.x = x;
        this.y = y;
        this.tipo = tipo;
    }

    public void Dibujar() => tipo.Dibujar(x, y);
}
