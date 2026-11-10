namespace Patrones_Estructurales.Facade.Supabase
{
    // Subsistema: simula Supabase Auth (solo para el ejemplo).
    public class SupabaseAuth
    {
        private const string CorreoDemo = "demo@vetlink.com";
        private const string ClaveDemo = "1234";

        public async Task IniciarSesion(string correo, string clave)
        {
            await Task.Delay(400); // simula la llamada a internet

            if (correo != CorreoDemo || clave != ClaveDemo)
            {
                throw new InvalidOperationException("Invalid login credentials");
            }
        }
    }
}
