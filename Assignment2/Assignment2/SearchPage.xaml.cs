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
    public partial class SearchPage : ContentPage
    {
        String title;
        ObservableCollection<Book> books = new ObservableCollection<Book>();
        NetworkingManager manager = new NetworkingManager();
        DatabaseManager dbManager;
        public SearchPage(DatabaseManager db)
        {
            InitializeComponent();
            dbManager = db;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        async private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var listFromAPI = await manager.getBooks(title);
            foreach (Book b in listFromAPI)
            {
                var imageUrl = "";
                var cover_edition = "";
                string title = "";
                string[] subj;
                string[] authors;
                string yr = "";
                string edition = "";
                string key = "";

                if (b.title != null)
                {
                    title = b.title;
                }
                if (b.author_name != null)
                {
                    authors = b.author_name;
                }
                else
                {
                    authors = new string[0];
                }
                if (b.cover_edition_key != null)
                {
                    imageUrl = "https://covers.openlibrary.org/b/OLID/" + b.cover_edition_key + "-L.jpg";
                    cover_edition = b.cover_edition_key;
                    
                }
                else
                {
                    imageUrl = "https://voice.global/wp-content/plugins/wbb-publications/public/assets/img/placeholder.jpg";
                }
                if (b.subject != null)
                {
                    subj = b.subject;
                }
                else
                {
                    subj = new string[0];
                }
                if (b.first_publish_year != null)
                {
                    yr = b.first_publish_year;
                }
                if (b.edition_count != null)
                {
                    edition = b.edition_count;
                }
                if (b.key != null)
                {
                    key = b.key;
                }
                books.Add(new Book(title, authors, yr, edition, subj, cover_edition, key, imageUrl));

            }
            bookList.ItemsSource = books;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            title = e.NewTextValue;
            books.Clear();
        }

        private void bookList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            Book selectedBook = e.SelectedItem as Book;
            Navigation.PushAsync(new BookDetailPage(selectedBook, dbManager));
        }
    }
}