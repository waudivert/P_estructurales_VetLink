using Patrones_Estructurales.Facade.Supabase;

namespace Patrones_Estructurales.Facade
{
    public record ResumenGranja(int Animales, int Avisos, int Miembros);

    // Facade: la pantalla Mi granja solo llama a Resumen(); no sabe qué tablas existen.
    public class Granjas
    {
        private readonly SupabaseTablas tablas = new();

        public async Task<ResumenGranja> Resumen()
        {
            // Lanza las 4 consultas a la vez.
            Task<int> animales = tablas.Contar("fichas_bovinas");
            Task<int> avisos = tablas.Contar("prevenciones");
            Task<int> vinculados = tablas.Contar("vinculaciones");
            Task<int> invitados = tablas.Contar("invitaciones");

            await Task.WhenAll(animales, avisos, vinculados, invitados);

            // Las junta en 3 números para la pantalla.
            return new ResumenGranja(
                animales.Result,
                avisos.Result,
                vinculados.Result + invitados.Result);
        }
    }
}
