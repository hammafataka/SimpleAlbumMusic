using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using music.models;

namespace music.ViewModels
{
    public class MusicDetailViewModel:BaseViewModel
    {
         
        private Album selectedAlbum;
        public Album SelectedAlbum
        {
            get => selectedAlbum;
            set { SetProperty(ref selectedAlbum, value); }
        }
        

        public ObservableCollection<Track> tracks { get; }
        public  void LoadTracks()
        {


                foreach (Track track in selectedAlbum.tracks.track)
                {
                    tracks.Add(track);
                }
            

        }
        public MusicDetailViewModel()
        {

            tracks = new ObservableCollection<Track>();




        }
    }

}
