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
    public partial class AuthorsListPage : ContentPage
    {
        ObservableCollection<string> authors;
        DatabaseManager dbManager;
        public AuthorsListPage(ObservableCollection<string> a, DatabaseManager db)
        {
            InitializeComponent();
            dbManager = db;
            authors = a;
            authorsList.ItemsSource = a;
        }

        private void authorsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new BooksByAuthor(e.SelectedItem as string, dbManager));
        }
    }
}