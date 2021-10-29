using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int ID { set; get; }
        public string title { set; get; }

        [Ignore]
        public string[] author_name { set; get; }
        public string authors { set; get; }
        public string first_publish_year { set; get; }
        
        public string edition_count { set; get; }

        [Ignore]
        public string[] subject { set; get; }
        public string subjects { set; get; }
        public string cover_edition_key { set; get; }
        public string key { set; get; }
        public string cover_image { set; get; }

        public Book()
        {

        }

        public Book(string t, string[] authorArr, string year, string edition, string[] tag, string openLibID, string worksID, string cover)
        {
            title = t;
            author_name = authorArr;
            authors = string.Join(", ", author_name);
            first_publish_year = year;
            edition_count = edition;
            subject = tag;
            subjects = string.Join(", ", subject);
            cover_edition_key = openLibID;
            key = worksID;
            cover_image = cover;
        }
        

    }

    
}
