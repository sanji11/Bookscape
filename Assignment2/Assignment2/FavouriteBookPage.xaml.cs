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
    public partial class FavouriteBookPage : ContentPage
    {
        public ObservableCollection<Book> favBooks = new ObservableCollection<Book>();
        DatabaseManager dbManager = new DatabaseManager();
        public FavouriteBookPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            favBooks = await dbManager.CreateTable();
            favBookList.ItemsSource = favBooks;
            base.OnAppearing();
        }
        private void SearchIcon_Clicked(object sender, EventArgs e)
        {
            //Redirect to SearchPage
            Navigation.PushAsync(new SearchPage(dbManager));
        }

        private void DeleteMenuItem_Clicked(object sender, EventArgs e)
        {
            Book b = (sender as MenuItem).CommandParameter as Book;
            dbManager.DeleteBook(b);

        }

        private void RefreshData()
        {
            favBookList.ItemsSource = null;
            favBookList.ItemsSource = favBooks;

        }

        private void favBookList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Book selectedFavBook = e.SelectedItem as Book;
            Navigation.PushAsync(new BookDetailPage(selectedFavBook, dbManager));
        }
    }
}