using Patrones_Estructurales.Facade.Supabase;

namespace Patrones_Estructurales.Facade
{
    // Facade: la pantalla de Login solo llama a Iniciar(); no sabe nada de Supabase Auth.
    public class Sesion
    {
        private readonly SupabaseAuth auth = new();

        // Devuelve null si entra, o un mensaje de error para mostrar.
        public async Task<string?> Iniciar(string correo, string clave)
        {
            if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(clave))
            {
                return "Ingresa tu correo y tu clave.";
            }

            try
            {
                await auth.IniciarSesion(correo.Trim(), clave);
                return null;
            }
            catch (InvalidOperationException)
            {
                return "Correo o clave incorrectos.";
            }
        }
    }
}
