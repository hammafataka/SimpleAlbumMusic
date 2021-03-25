using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;

using Xamarin.Forms;

using music.models;
using music.Services;
using music.Views;
using System.Threading.Tasks;

namespace music.ViewModels
{
    public class MusicListViewModel : BaseViewModel
    {
        private string sName;
        public string SName
        {
            get => sName;
            set { SetProperty(ref sName, value); }
        }
        private string aName;
        public string AName
        {
            get => aName;
            set { SetProperty(ref aName, value); }
        }
        public ObservableCollection<Album> albums { get; }
        public ObservableCollection<Track> tracks { get; }

        private Album selectedAlbum;
        public Album SelectedAlbum
        {
            get => selectedAlbum;
            set { SetProperty(ref selectedAlbum, value); }

        }

        public ICommand LoadDataCommad{ private set; get; }
        public ICommand LoadMoreCommad { private set; get; }
        public ICommand GotDetailCommad { private set; get; }
        public ICommand RefreshDataCommand { private set; get; }
        public ICommand LoadTracksCommand { private set; get; }


        int page = 0;
        int pageSize = 10;
        private List<Album> AlbumList;
        private List<Track> trackList; 
        private bool isRefreshing;

        public  void LoadData()
        {
            IsBusy = true;
        }

        private void Loadmore()
        {
            if (!isRefreshing)
            {
                page++;
                LoadAlbums();
            }
        }

        private async Task Refreshdata()
        {
            isRefreshing = true;
            page = 0;
            await CallApiService();
            LoadAlbums();
            isRefreshing = false;
        }

        private async Task CallApiService()
        {
            albums.Clear();
            AlbumList = await MusicService.GetAlbums(SName);

            IsBusy = false;
        }
        private async Task CallDetailApiService()
        {
            albums.Clear();
            AlbumList = await MusicDetailService.GetDetails(SName);

            IsBusy = false;
        }
        private void LoadAlbums()
        {
            int totalpages = AlbumList.Count / pageSize + 1;
            if (page<totalpages)
            {
                IEnumerable<Album> albumset = AlbumList.Skip(page * pageSize).Take(pageSize);
                foreach (Album album in albumset)
                {
                    album.imageUrl = album.image.First(x => x.size == "extralarge").Text;
                        //"https://lastfm.freetls.fastly.net/i/u/174s/dcf5cf4b9da64e979719a102acd222cc.png";
                    albums.Add(album);
                }
            }


        }
        private void LoadTracks()
        {
            int totalpages = trackList.Count / pageSize + 1;
            if (page < totalpages)
            {
                IEnumerable<Track> trackset = trackList.Skip(page * pageSize).Take(pageSize);
                foreach (Track track  in trackset)
                {
                    track.name = track.name;
                    //"https://lastfm.freetls.fastly.net/i/u/174s/dcf5cf4b9da64e979719a102acd222cc.png";
                    tracks.Add(track);
                }
            }

        }
        private async Task GoToDetail()
        {
            if (selectedAlbum != null)
            {
                MusicDetailViewModel viewModel = new MusicDetailViewModel();
                viewModel.SelectedAlbum = selectedAlbum;

                MusicDetailView view = new MusicDetailView
                {
                    BindingContext = viewModel
                };

                await App.Current.MainPage.Navigation.PushModalAsync(view);
            }
        }

        public MusicListViewModel()
        {
            AlbumList = new List<Album>();
            albums = new ObservableCollection<Album>();
            page = 0;

            LoadDataCommad = new Command(LoadData);
            LoadMoreCommad = new Command(Loadmore);
            LoadTracksCommand = new Command(LoadTracks);
            GotDetailCommad = new Command(async () => await GoToDetail());
            RefreshDataCommand = new Command(async () => await Refreshdata());
        }




    }
}
