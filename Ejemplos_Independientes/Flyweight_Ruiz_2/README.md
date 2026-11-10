# Flyweight: bosque de árboles (WPF / C#)

Ejemplo independiente del patrón estructural **Flyweight** para Visual Studio 2022 y **.NET 8 Desktop / WPF**.

## Ejecutar
1. Abrir `Flyweight_Ruiz_WPF.sln` en Visual Studio 2022 (Windows).
2. Comprobar que está instalada la carga de trabajo «Desarrollo de escritorio con .NET» y .NET 8.
3. Presionar `Ctrl + F5`.
4. Pulsar **Generar 5 árboles** o **Generar 100 árboles**.

## ¿Dónde se usa Flyweight?
- `TipoArbol.cs`: estado **intrínseco**, compartido (especie, color, forma y pinceles congelados).
- `FabricaArboles.cs`: almacena los tipos en un `Dictionary` y reutiliza los objetos existentes.
- `Arbol.cs`: estado **extrínseco**, coordenadas únicas X/Y; guarda una referencia al tipo compartido y dibuja en `Canvas`.
- `MainWindow.xaml.cs`: solicita tipos, crea 5 o 100 instancias de `Arbol` y comprueba `ReferenceEquals` para verificar reutilización.

**Qué demuestra:** 100 árboles individuales pueden utilizar solo **2 objetos `TipoArbol`**. No se mide ahorro real de RAM: se demuestra reutilización de objetos.

**Nota sobre Git:** sustituye solo la carpeta de tu ejemplo en el repositorio compartido; no borres el historial ni uses `push --force`.
