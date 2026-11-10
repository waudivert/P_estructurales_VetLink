namespace Flyweight_Ruiz;

internal static class Program
{
    private static void Main()
    {
        var fabrica = new FabricaArboles();

        TipoArbol pino = fabrica.Obtener("Pino", "verde", "conífera");
        TipoArbol roble = fabrica.Obtener("Roble", "verde", "frondoso");

        Arbol[] bosque =
        {
            new Arbol(2, 5, pino),
            new Arbol(8, 3, pino),
            new Arbol(4, 9, roble),
            new Arbol(12, 6, pino),
            new Arbol(10, 11, roble)
        };

        foreach (Arbol arbol in bosque)
        {
            arbol.Dibujar();
        }

        Console.WriteLine($"Tipos de árbol guardados en memoria: {fabrica.CantidadDeTiposCompartidos()}");

        // Comprobamos que pedir nuevamente un pino devuelve el mismo objeto.
        TipoArbol otroPino = fabrica.Obtener("Pino", "verde", "conífera");
        Console.WriteLine($"¿Se reutiliza el mismo pino? {ReferenceEquals(pino, otroPino).ToString().ToLowerInvariant()}");
        Console.WriteLine($"Tipos compartidos después de solicitar otro pino: {fabrica.CantidadDeTiposCompartidos()}");
    }
}
