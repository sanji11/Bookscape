using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenresListPage : ContentPage
    {
        public ObservableCollection<string> genres;
        public GenresListPage(ObservableCollection<string> g)
        {
            InitializeComponent();
            genres = g;
            genresList.ItemsSource = genres;
        }

    }
}