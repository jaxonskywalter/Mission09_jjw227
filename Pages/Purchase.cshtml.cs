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

        public PurchaseModel(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int BookId, string returnUrl)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == BookId);

            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(b, 1);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
