using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VideoGameMusicApp.Models;
using VideoGameMusicApp.Services;

namespace VideoGameMusicApp.ViewModels
{
    public class CancionesViewModel : BaseViewModel
    {
        private ObservableCollection<Cancion> canciones;

        public ObservableCollection<Cancion> Canciones
        {
            get { return canciones; }
            set
            {
                canciones = value;
                OnPropertyChanged();
            }
        }

        public CancionesViewModel()
        {
        }

        public async Task ObtenerCanciones()
        {
            IsLoading = true;
            Canciones = new ObservableCollection<Cancion>(await ServicioCanciones.ObtenerCanciones());
            IsLoading = false;
        }
    }
}