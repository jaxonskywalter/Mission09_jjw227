﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeffWho.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }
       
        public int BooksPerPage { get; set; }
        
        public int CurrentPage { get; set; }
       
        public int TotalPages => (int) Math.Ceiling((double) TotalNumBooks / BooksPerPage);
    }
}
