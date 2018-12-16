using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using VideoGameMusicApp.ViewModels;

namespace VideoGameMusicApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaListaCanciones : ContentPage
    {
        CancionesViewModel vm;

        public PaginaListaCanciones()
        {
            InitializeComponent();

            vm = new CancionesViewModel();
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.ObtenerCanciones();
        }
    }
}