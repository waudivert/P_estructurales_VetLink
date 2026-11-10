using System.Windows.Media;

namespace Patrones_Estructurales.Flyweight;

// FÁBRICA: crea cada especie una vez y devuelve la referencia guardada.
public sealed class FabricaArboles
{
    private readonly Dictionary<string, TipoArbol> tipos = new();

    public TipoArbol Obtener(string nombre)
    {
        if (!tipos.TryGetValue(nombre, out var tipo))
        {
            tipo = nombre switch
            {
                "Pino" => new TipoArbol("Pino", "Verde oscuro", "Conífera", Color.FromRgb(33, 114, 78)),
                "Roble" => new TipoArbol("Roble", "Verde claro", "Frondoso", Color.FromRgb(113, 174, 102)),
                _ => throw new ArgumentException("Tipo de árbol no reconocido.", nameof(nombre))
            };
            tipos.Add(nombre, tipo);
        }
        return tipo;
    }

    public int CantidadTipos => tipos.Count;
}
