# Facade

Las pantallas de VetLink no hablan directamente con Supabase: todo pasa por dos fachadas.

- `Sesion`: `Iniciar(correo, clave)` pide el ingreso a Supabase Auth y devuelve `null` si entra o un mensaje de error.
- `Granjas`: `Resumen()` lanza 4 consultas a la vez (`fichas_bovinas`, `prevenciones`, `vinculaciones`, `invitaciones`) y devuelve 3 números: animales, avisos y miembros.
- `Supabase/`: subsistemas simulados en memoria (`SupabaseAuth`, `SupabaseTablas`).
- `VistaFacade.xaml`: Login y Mi granja usando solo las fachadas. Usuario de prueba: `demo@vetlink.com` / `1234`.
