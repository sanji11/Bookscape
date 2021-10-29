using Foundation;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(Assignment2.iOS.SQLiteDB))]
namespace Assignment2.iOS
{
    public class SQLiteDB : SQLiteDBInterface
    {
        public SQLiteAsyncConnection createSQLiteDB()
        {
            var document_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(document_path, "todoDB.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}