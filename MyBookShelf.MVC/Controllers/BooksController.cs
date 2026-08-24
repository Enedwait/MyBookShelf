using Microsoft.AspNetCore.Mvc;
using MyBookShelf.MVC.Constants;
using MyBookShelf.Shared.DataAccess.Repositories;
using MyBookShelf.Shared.Models;

namespace MyBookShelf.MVC.Controllers
{
    public sealed class BooksController : Controller
    {
        #region Fields

        private readonly ILogger<BooksController> _logger;
        private readonly IBookRepository _repository;

        #endregion

        #region Init

        public BooksController(IBookRepository repository, ILogger<BooksController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _repository.GetAllBooksAsync();
            return View(books);
        }

        [HttpGet, ActionName(BooksControllerActionNames.Create)]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddBookAsync(book);
                return RedirectToAction(BooksControllerActionNames.Index);
            }

            return View(book);
        }

        [HttpGet, ActionName(BooksControllerActionNames.BookContents)]
        public async Task<IActionResult> BookContents(int id)
        {
            Book book = await _repository.GetBookByIdAsync(id);
            if (book == null) return NotFound(id);
            return View(book);
        }

        [HttpPost, ActionName(BooksControllerActionNames.BookContents)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookContents(int id, Book book)
        {
            if (id != book.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                bool updated = await _repository.UpdateContentsByBookIdAsync(book.Id, book.Contents);
                if (!updated) return NotFound(id);
                return RedirectToAction(BooksControllerActionNames.Index);
            }
            return View(book);
        }

        [HttpGet, ActionName(BooksControllerActionNames.Edit)]
        public async Task<IActionResult> Edit(int id)
        {
            Book book = await _repository.GetBookByIdAsync(id);
            if (book == null) return NotFound(id);
            return View(book);
        }

        [HttpPost, ActionName(BooksControllerActionNames.Edit)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                bool updated = await _repository.UpdateBookAsync(book);
                if (!updated) return NotFound(id);
                return RedirectToAction(BooksControllerActionNames.Index);
            }
            return View(book);
        }

        [HttpGet, ActionName(BooksControllerActionNames.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            Book book = await _repository.GetBookByIdAsync(id);
            if (book == null) return NotFound(id);
            return View(book);
        }

        [HttpPost, ActionName(BooksControllerActionNames.Delete)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool deleted = await _repository.DeleteBookByIdAsync(id);
            if (!deleted) return NotFound(id);
            return RedirectToAction(BooksControllerActionNames.Index);
        }

        #endregion
    }
}
