using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Assignment2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void FindFavBookButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FavouriteBookPage());
        }
    }
}
