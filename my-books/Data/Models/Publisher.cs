﻿using System.Collections.Generic;

namespace my_books.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Navigation properites
        public List<Book> Books { get; set; }
    }
}
