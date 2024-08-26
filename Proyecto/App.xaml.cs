using Proyecto.Views;

namespace Proyecto
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();

            //MainPage = new LoginView();

            MainPage = new NavigationPage(new LoginView());
        }
    }
}
