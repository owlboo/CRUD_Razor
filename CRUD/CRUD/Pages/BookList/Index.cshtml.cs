using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Pages.BookList
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDBContext _db;
        [TempData]
        public string Message { get; set; }
        public IEnumerable<Book> Book { get; set; }


        public IndexModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            Book = await _db.Books.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Books.FindAsync(id);
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();

            Message = "Book deleted successfully !!";

            return RedirectToPage("Index");
        }

    }
}