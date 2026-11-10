namespace Patrones_Estructurales.Proxy
{
    // Proxy: guarda en caché las respuestas para no repetir consultas lentas.
    public class ServicioClimaProxy : IServicioClima
    {
        private readonly ServicioClimaReal servicioReal = new();
        private readonly Dictionary<string, string> cache = new();

        public bool UltimaDesdeCache { get; private set; }

        public string ObtenerClima(string ciudad)
        {
            if (cache.TryGetValue(ciudad, out string? guardado))
            {
                UltimaDesdeCache = true;
                return guardado;
            }

            UltimaDesdeCache = false;
            string resultado = servicioReal.ObtenerClima(ciudad);
            cache[ciudad] = resultado;
            return resultado;
        }
    }
}
