namespace Patrones_Estructurales.Facade.Supabase
{
    // Subsistema: simula las tablas de Supabase (solo para el ejemplo).
    public class SupabaseTablas
    {
        private readonly Dictionary<string, int> filas = new()
        {
            ["fichas_bovinas"] = 42,
            ["prevenciones"] = 5,
            ["vinculaciones"] = 3,
            ["invitaciones"] = 2
        };

        public async Task<int> Contar(string tabla)
        {
            await Task.Delay(500); // simula la consulta

            return filas.TryGetValue(tabla, out int total) ? total : 0;
        }
    }
}
