# Proxy

Ejemplo sencillo: consulta del clima con caché.

- `IServicioClima`: interfaz común (Subject).
- `ServicioClimaReal`: servicio lento que simula una consulta a internet (RealSubject).
- `ServicioClimaProxy`: guarda las respuestas y no vuelve a llamar al servicio real para la misma ciudad (Proxy).
- `VistaProxy.xaml`: vista para probar el ejemplo; muestra si la respuesta vino del servicio real o de la caché.
