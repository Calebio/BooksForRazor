using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksForRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksForRazor.Pages.ListOFBooks
{
    public class EditModel : PageModel
    {
        private readonly BooksDbContext _db;

        public EditModel(BooksDbContext db)
        {
            _db = db;

        }
        [BindProperty]
        public Book Book { get; set; }

        public async Task OnGetAsync(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var BookFromDb = await _db.Book.FindAsync(Book.Id);
                BookFromDb.Name = Book.Name;
                BookFromDb.ISBN = Book.ISBN;
                BookFromDb.Author = Book.Author;

                await _db.SaveChangesAsync();

                return RedirectToPage("HomePage");

            }

            return RedirectToPage();
        }
    }
}
