using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksForRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksForRazor.Pages.ListOFBooks
{
    public class CreateModel : PageModel
    {
        private readonly BooksDbContext _db;

        public CreateModel(BooksDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult>OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync();
                return Redirect("HomePage");

            }
            else
            {
                return Page();
            }
        }
    }
}
