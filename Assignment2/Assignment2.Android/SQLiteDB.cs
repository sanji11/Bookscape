using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(Assignment2.Droid.SQLiteDB))]
namespace Assignment2.Droid
{
    public class SQLiteDB : SQLiteDBInterface
    {
        public SQLiteAsyncConnection createSQLiteDB()
        {
            var document_path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(document_path, "todoDB.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}