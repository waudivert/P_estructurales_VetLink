namespace Flyweight_Ruiz;

// Reutiliza un TipoArbol si ya se creó con las mismas características.
internal sealed class FabricaArboles
{
    private readonly Dictionary<(string Nombre, string Color, string Apariencia), TipoArbol> tipos = new();

    public TipoArbol Obtener(string nombre, string color, string apariencia)
    {
        var clave = (nombre, color, apariencia);
        if (!tipos.TryGetValue(clave, out TipoArbol? tipo))
        {
            tipo = new TipoArbol(nombre, color, apariencia);
            tipos.Add(clave, tipo);
        }

        return tipo;
    }

    public int CantidadDeTiposCompartidos() => tipos.Count;
}
