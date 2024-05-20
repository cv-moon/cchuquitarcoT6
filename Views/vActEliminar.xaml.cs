using cchuquitarcoT6.Models;
using System.Net;

namespace cchuquitarcoT6.Views;

public partial class vActEliminar : ContentPage
{
    string url = "http://192.168.100.109/moviles/wsestudiantes.php";
    public vActEliminar(Estudiante datos)
    {
        InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido;
        txtEdad.Text = datos.edad.ToString();
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);

            cliente.UploadValues($"{url}?codigo={txtCodigo.Text}", "PUT", parametros);
            DisplayAlert("Alerta!", cliente.ToString(), "Cerrar");
            Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta!", ex.Message, "Cerrar");
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            //parametros.Add("codigo", txtCodigo.Text);

            cliente.UploadValues($"{url}?codigo={txtCodigo.Text}", "DELETE", parametros);
            Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta!", ex.Message, "Cerrar");
        }
    }
}