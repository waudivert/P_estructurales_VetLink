using Patrones_Estructurales.Adapterr.Adaptee;
using Patrones_Estructurales.Adapterr.Adapter;
using Patrones_Estructurales.Adapterr.Modelos;
using Patrones_Estructurales.Adapterr.Modelos.Patrones_Estructurales.Adapterr.Modelos;
using Patrones_Estructurales.Adapterr.Target;
using System.Windows;
using System.Windows.Controls;

namespace Patrones_Estructurales.Adapterr
{
    public partial class VistaAdapter : UserControl
    {
        private readonly SistemaGanaderoExterno sistemaExterno;

        private readonly IConsultaAnimal consultaAnimal;

        public VistaAdapter()
        {
            InitializeComponent();

            sistemaExterno = new SistemaGanaderoExterno();

            consultaAnimal = new AnimalAdapter(sistemaExterno);

            CargarAnimales();

            CmbAnimales.SelectionChanged += CambiarAnimal;
        }

        private void CargarAnimales()
        {
            CmbAnimales.ItemsSource = new[]
            {
                new
                {
                    Codigo = "BOV-025",
                    Etiqueta = "BOV-025 - Estrella (Vaca)"
                },

                new
                {
                    Codigo = "BOV-031",
                    Etiqueta = "BOV-031 - Luna (Vaquilla)"
                },

                new
                {
                    Codigo = "BOV-042",
                    Etiqueta = "BOV-042 - Margarita (Ternera)"
                }
            };

            CmbAnimales.SelectedIndex = 0;
        }

        private void CambiarAnimal(
            object sender,
            SelectionChangedEventArgs e)
        {
            PanelResultados.Visibility = Visibility.Collapsed;

            TxtEstadoInicial.Visibility = Visibility.Visible;
        }

        private void BtnAdaptar_Click(
            object sender,
            RoutedEventArgs e)
        {
            string? codigo =
                CmbAnimales.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show(
                    "Seleccione un animal.",
                    "VetLink");

                return;
            }

            try
            {
                RegistroGanaderoExterno externo =
                    sistemaExterno.BuscarGanado(codigo);

                AnimalVetLink animal =
                    consultaAnimal.ObtenerAnimal(codigo);

                MostrarDatosExternos(externo);

                MostrarDatosAdaptados(animal);

                PanelResultados.Visibility = Visibility.Visible;

                TxtEstadoInicial.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al adaptar datos");
            }
        }

        private void MostrarDatosExternos(
            RegistroGanaderoExterno registro)
        {
            TxtDatosExternos.Text =
                "id_ganado: " + registro.IdGanado + "\n" +
                "cod_caravana: " + registro.CodigoCaravana + "\n" +
                "nombre_ganado: " + registro.NombreGanado + "\n" +
                "categoria: " + registro.Categoria + "\n" +
                "raza_codigo: " + registro.RazaCodigo + "\n" +
                "fecha_nac: " + registro.FechaNac + "\n" +
                "estado_repr: " +
                    registro.EstadoReproductivoCodigo;
        }

        private void MostrarDatosAdaptados(
            AnimalVetLink animal)
        {
            TxtDatosVetLink.Text =
                "ID: " + animal.Id + "\n" +
                "Arete: " + animal.Arete + "\n" +
                "Nombre: " + animal.Nombre + "\n" +
                "Etapa: " + animal.Etapa + "\n" +
                "Raza: " + animal.Raza + "\n" +
                "Nacimiento: " + animal.FechaNacimiento + "\n" +
                "Estado reproductivo: " +
                    animal.EstadoReproductivo;

            TxtResultado.Text =
                "Datos de " + animal.Nombre +
                " adaptados correctamente a VetLink.";
        }
    }
}
