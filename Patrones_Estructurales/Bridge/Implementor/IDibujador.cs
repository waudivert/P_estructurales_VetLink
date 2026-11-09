using System.Windows.Shapes;

public interface IDibujador
{
    string NombreColor { get; }

    Shape DibujarCirculo();

    Shape DibujarRectangulo();
}