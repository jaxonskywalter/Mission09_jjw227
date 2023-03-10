using JeffWho.Models;
using JeffWho.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeffWho.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(string Category, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(p => p.Category == Category || Category == null)
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks =
                        (Category == null
                            ? repo.Books.Count()
                            : repo.Books.Where(x => x.Category == Category).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
