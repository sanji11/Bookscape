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
    public partial class BookDetailPage : ContentPage
    {
        public Book bookDetails;
        ObservableCollection<String> genres;
        ObservableCollection<String> authors;
        DatabaseManager databaseManager;
        public BookDetailPage(Book b, DatabaseManager db)
        {
            InitializeComponent();
            databaseManager = db;
            bookDetails = b;
            coverImage.Source = b.cover_image;
            titleText.Text = "Title: " + b.title;
            authorText.Text = "Author Name(s): " + b.authors;
            publishYearText.Text = "First published at " + b.first_publish_year;
            editionKeyText.Text = "Cover Edition Key: " + b.cover_edition_key;
            keyText.Text = "Work ID: " + b.key;
            string[] genreArray= b.subjects.Split(',');
            genres = new ObservableCollection<string>(genreArray);
            string[] authorArray = b.authors.Split(',');
            authors = new ObservableCollection<string>(authorArray);

        }

        private void GenresButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GenresListPage(genres));
        }

        private void AuthorButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AuthorsListPage(authors, databaseManager));
        }

        private async void AddFavouriteButton_Clicked(object sender, EventArgs e)
        {
            var books = databaseManager.GetAllBooks();
            Book selectedBook = books.FirstOrDefault(b => b.ID.Equals(bookDetails.ID));
            if (selectedBook == null)
            {
                bool response = await DisplayAlert("Save Favourite Book", "Do you want to save " + bookDetails.title + " to your favourite list?", "Yes", "No");
                if (response)
                {
                    databaseManager.InsertNewFavBook(bookDetails);
                    await DisplayAlert("Success", "The book is added to your favourite!", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Error", "The book is already added to your favourite!", "Ok");

            } 

        }
    }
}