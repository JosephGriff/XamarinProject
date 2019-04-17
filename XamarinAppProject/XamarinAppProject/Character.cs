using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinAppProject
{
    public class Character
    {
        //defining data that will be used by the SQlite database
        //Each in put needs an id that the database can use, thus we set id to the primary key and autoincrement it.
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Class { get; set; }
        
    }
}
