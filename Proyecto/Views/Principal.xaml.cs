namespace Proyecto.Views;

public partial class Principal : ContentPage
{
    public Principal()
    {
        InitializeComponent();
    }

    private async void Menu_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.Menu());
    }

    private async void Talleres_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.Talleres());
    }

    private async void Servicios_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.Servicios());
    }

    private async void Contacto_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.Nosotros());
    }
}