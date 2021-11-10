# Bookscape
BookScape is a **cross-platform** application to browse through books by title and author names, see the book details including genres and add the book to the favourite book list. 

## Structure
The app has 1 model class called *Book* which is used to store the data in **SQLiteDB**.

The app has total 7 pages which are following:
- Mainapge
- FavouriteBookPage
- SearchPage
- BookDetailPage
- AuthorListPage
- BooksByAuthor
- GenreListPage

The app has 2 manager classes,1 interface and 1 resource extension class.
- DatabaseManager: CreateTable – to create the table, GetAllBooks – to get all the books, InsertNewFavBook – insert a new book, DeleteBook – delete a book from the database 
- NetworkManager: getBooks – for the search by title api, GetBooksByAuthor – for search by author name api
- SQLiteDBInterface
- ImageResourceExtension

## Description 
The first page, **MainPage**, is the landing page of the app. It has an image, the name of the app and a button, *“Find Your Favourite Books”*, to take the user to the next page. 

When one clicks the button, it takes them to the second page which is **FavouriteBookPage**. On that page, it has a listview with the list of favourite books with the title, cover image and the author name(s). This page receives the data from the stored database in **SQLite DB**. 
It also has a toolbar with Search Icon. This page can take to two different pages:
-	**BookDetailPage**: When the user clicks a cell from the listView, it goes to the *BookDetailPage*. On *BookDetailPage*, I used Grid to organize the data. It displays the cover image, the title, the author names, publish year, cover_edition_key and key of the book. It also has three buttons which leads to 3 other pages:
    - *Add Books to Favourites Button*: It checks if the book is already stored in the local database in SQLite. If yes, it shows a dialog with message saying that the book is already added and prevents the user to add the same book. If no, it adds the book to the local database in SQLite which can be seen when the user goes back to the FavouriteBookPage. It also shows a successful message upon inserting the new book to the database.
    - *View Genres Button*: It takes the user to **GenreListPage**. On that page, it lists all the genres the book is from in a listView. I wanted to add another page called BooksByGenres which is similar to BooksByAuthor page. However, the response from the API was not consistent.
    - *View other Books By The Author(s)*: It takes the user to **AuthorListPage**. On that page, it lists all the authors of the book in a listView. When the user selects an author from the listView, it takes the user to the **BooksByAuthor** page.
       - **BooksByAuthorPage**: It shows other books written by the same author in a listView. I used Search API: search by Author API to collect books written by author name.If the user clicks any book from the list, it displays the book details in BookDetailsPage. The user can add that book to the favourite book and the cycle continues. 
-	**SearchPage**:  I used the SearchBar to search books by title. I used Search API: Search by title API to collect the data. If the user clicks any book, it takes to the **BookDetailPage**. 

For the coverImage of the book, I used https://covers.openlibrary.org/b/OLID/$cover_edition_key-L.jpg API. Before displaying the books in the listView, I checked if all the field is available. For books with no cover image, I used a generic image to display no cover image available. 


## Web service
The webservices I used is https://openlibrary.org/developers/api . From this API, I used the Search API: Search by title API and search by Author API. For cover image of the book, I used https://covers.openlibrary.org/b/OLID/$cover_edition_key-L.jpg API

## Tools and Language
Visual Studio, Xamarin, Objective-C, Xaml
