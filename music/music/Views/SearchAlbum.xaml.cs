using music.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace music.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchAlbum : ContentPage
    {
        MusicListViewModel vm;
        public SearchAlbum()
        {
            InitializeComponent();
            searchBar.TextColor = RadialGradientBrush.DarkGray.Color;
            vm = new MusicListViewModel();
            BindingContext = vm;
            
        }
        

        private void searchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            searchBar.TextColor = RadialGradientBrush.DarkGray.Color;

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (vm.albums.Count == 0)
            {
                await Task.Run(() => vm.LoadDataCommad.Execute(null));
            }
            else
            {
                vm.SelectedAlbum = null;
            }
            
        }


    }
}