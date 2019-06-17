﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public EditModel(ApplicationDBContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }

        [TempData]
        public string Message { get; set; }



        public void OnGet(int id)
        {
            Book = _db.Books.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = _db.Books.Find(Book.Id);
                BookFromDb.Name = Book.Name;
                BookFromDb.ISBN = Book.ISBN;
                BookFromDb.Author = Book.Author;

                //_db.Books.Update(BookFromDb);
                await _db.SaveChangesAsync();
                Message = "Book has been updated successful !!";

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}