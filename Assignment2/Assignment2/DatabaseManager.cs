using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SQLite;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Assignment2
{
    public class DatabaseManager
    {
        SQLiteAsyncConnection connection;
        public ObservableCollection<Book> allBooks;
        public DatabaseManager()
        {
            connection = DependencyService.Get<SQLiteDBInterface>().createSQLiteDB();
        }

        public async Task<ObservableCollection<Book>> CreateTable()
        {
            await connection.CreateTableAsync<Book>();
            var bookFromDB = await connection.Table<Book>().ToListAsync();
            allBooks = new ObservableCollection<Book>(bookFromDB);
            return allBooks;

        }

        public ObservableCollection<Book> GetAllBooks()
        {
            return allBooks;
        }
        public async void InsertNewFavBook(Book newBook)
        {
            await connection.InsertAsync(newBook);
        }

        public async void DeleteBook(Book deleteBook)
        {
            await connection.DeleteAsync(deleteBook);
            
        }
    }
}
