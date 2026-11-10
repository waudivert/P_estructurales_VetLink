using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flyweight_Ruiz_WPF;

// CONTEXTO: cada árbol tiene una posición propia y referencia un TipoArbol compartido.
public sealed class Arbol
{
    public double X { get; }
    public double Y { get; }
    public TipoArbol Tipo { get; }

    public Arbol(double x, double y, TipoArbol tipo)
    {
        X = x;
        Y = y;
        Tipo = tipo;
    }

    public void Dibujar(Canvas canvas, double escala)
    {
        // El objeto compartido decide los pinceles y la forma; cada árbol aporta X e Y.
        var tronco = new Rectangle { Width = 8 * escala, Height = 22 * escala, Fill = Tipo.Tronco, RadiusX = 2, RadiusY = 2 };
        Canvas.SetLeft(tronco, X - 4 * escala);
        Canvas.SetTop(tronco, Y - 20 * escala);
        canvas.Children.Add(tronco);

        if (Tipo.Nombre == "Pino")
        {
            var copa = new Polygon
            {
                Points = new PointCollection
                {
                    new(X, Y - 62 * escala),
                    new(X - 21 * escala, Y - 9 * escala),
                    new(X + 21 * escala, Y - 9 * escala)
                },
                Fill = Tipo.Copa
            };
            canvas.Children.Add(copa);
        }
        else
        {
            var copa = new Ellipse { Width = 46 * escala, Height = 38 * escala, Fill = Tipo.Copa };
            Canvas.SetLeft(copa, X - 23 * escala);
            Canvas.SetTop(copa, Y - 53 * escala);
            canvas.Children.Add(copa);
        }
    }
}
