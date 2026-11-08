# VetLink | Plantilla para patrones estructurales

Proyecto WPF en C# basado en el archivo de clase `Patrones_Estructurales-master.zip`.
La plantilla conserva las siete carpetas principales: `Adapterr`, `Bridge`, `Composite`, `Decorator`, `FACADE`, `Proxy` y `Flyweight`.

## Qué se modificó
- Se eliminaron todos los ejercicios de demostración, sus clases, vistas y datos de ejemplo.
- Se preparó una vista vacía en cada carpeta, conectada a la navegación lateral.
- La paleta pasó a los verdes de VetLink; los botones se redondearon.
- Se eliminaron las dependencias NuGet de los ejemplos, ya innecesarias.
- Se mantuvo el `TargetFramework` original (`net10.0-windows`).

## Para continuar
1. Abrir `Patrones_Estructurales.slnx` con Visual Studio compatible con .NET 10 (o el `.sln` alternativo).
2. Añadir a la carpeta de cada patrón las interfaces, clases y servicios del ejemplo elegido.
3. Modificar `Vista[Patron].xaml` y su `.xaml.cs` para conectar la demostración.
4. Ejecutar y verificar la navegación desde el menú izquierdo.

La plantilla aún no contiene implementaciones de patrones: está intencionalmente vacía.
