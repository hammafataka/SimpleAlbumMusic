using System;
using System.Collections.Generic;
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
    }
}
