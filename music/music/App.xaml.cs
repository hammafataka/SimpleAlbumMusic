using music.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace music
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SearchAlbum();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
