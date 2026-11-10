
using System.Windows;
using System.Windows.Controls;

using Patrones_Estructurales.Composite.Component;
using Patrones_Estructurales.Composite.Leaf;
using Patrones_Estructurales.Composite.Compuesto;

namespace Patrones_Estructurales.Composite
{
    public partial class VistaComposite : UserControl
    {
        private ElementoSistema? seleccionado;

        public VistaComposite()
        {
            InitializeComponent();
            CargarArchivos();
        }

        private void CargarArchivos()
        {
            Carpeta documentos = new Carpeta("Documentos");

            documentos.Agregar(
                new Archivo("Informe.pdf", 200));

            documentos.Agregar(
                new Archivo("Tarea.docx", 100));

            Carpeta imagenes = new Carpeta("Imágenes");

            imagenes.Agregar(
                new Archivo("Foto.png", 500));

            Carpeta principal = new Carpeta("Mi PC");

            principal.Agregar(documentos);
            principal.Agregar(imagenes);

            ArbolArchivos.Items.Add(CrearNodo(principal));
        }

        private TreeViewItem CrearNodo(ElementoSistema elemento)
        {
            TreeViewItem nodo = new TreeViewItem
            {
                Header = elemento.Nombre,
                Tag = elemento,
                IsExpanded = true
            };

            if (elemento is Carpeta carpeta)
            {
                foreach (ElementoSistema hijo in carpeta.Elementos)
                {
                    nodo.Items.Add(CrearNodo(hijo));
                }
            }

            return nodo;
        }


        private void ArbolArchivos_SelectedItemChanged(
            object sender,
            RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is TreeViewItem nodo &&
                nodo.Tag is ElementoSistema elemento)
            {
                seleccionado = elemento;

                TxtSeleccion.Text =
                    "Elemento: " + elemento.Nombre;

                TxtTamaño.Text = "0 KB";
            }
        }

        private void BtnCalcular_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (seleccionado == null)
            {
                MessageBox.Show(
                    "Primero selecciona un archivo o carpeta.",
                    "Composite");

                return;
            }

            int tamaño = seleccionado.ObtenerTamaño();

            TxtTamaño.Text = tamaño + " KB";

            MessageBox.Show(
                seleccionado.Nombre + ": " + tamaño + " KB",
                "Resultado del cálculo");
        }

    }
}
