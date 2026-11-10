namespace Patrones_Estructurales.Proxy
{
    // Subject: interfaz común para el servicio real y el proxy.
    public interface IServicioClima
    {
        string ObtenerClima(string ciudad);
    }
}
