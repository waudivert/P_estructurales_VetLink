namespace Patrones_Estructurales.Proxy
{
    // RealSubject: simula un servicio lento (por ejemplo, una API en internet).
    public class ServicioClimaReal : IServicioClima
    {
        public string ObtenerClima(string ciudad)
        {
            Thread.Sleep(1500); // simula la espera de la consulta

            return ciudad switch
            {
                "Lima" => "Lima: 19 °C, nublado",
                "Madrid" => "Madrid: 27 °C, soleado",
                "Tokio" => "Tokio: 22 °C, lluvia ligera",
                _ => ciudad + ": sin datos"
            };
        }
    }
}
