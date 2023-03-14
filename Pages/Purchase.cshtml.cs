using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JeffWho.Infrastructure;
using JeffWho.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JeffWho.Pages
{
    public class PurchaseModel : PageModel
    {

        private IBookstoreRepository repo { get; set; }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public PurchaseModel(IBookstoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int BookId, string returnUrl)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == BookId);

            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove (int BookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Books.BookId == BookId).Books);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
