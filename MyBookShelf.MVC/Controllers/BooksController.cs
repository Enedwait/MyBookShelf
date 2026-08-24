using Microsoft.AspNetCore.Mvc;
using MyBookShelf.MVC.Constants;
using MyBookShelf.Shared.DataAccess.Repositories;
using MyBookShelf.Shared.Helpers;
using MyBookShelf.Shared.Models;

namespace MyBookShelf.MVC.Controllers
{
    public sealed class BooksController : Controller
    {
        #region Fields

        private readonly ILogger<BooksController> _logger;
        private readonly IBookRepository _repository;
        private readonly IBookContentsReader _contentsReader;

        #endregion

        #region Init

        public BooksController(IBookRepository repository, IBookContentsReader contentsReader, ILogger<BooksController> logger)
        {
            this._repository = repository;
            this._logger = logger;
            this._contentsReader = contentsReader;
        }

        #endregion

        #region Index

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _repository.GetAllBooksAsync();
            var viewModels = await _contentsReader.GetBookListItemsAsync(books);
            return View(viewModels);
        }

        #endregion

        #region Create

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

        #endregion

        #region BookContents

        [HttpGet, ActionName(BooksControllerActionNames.BookContents)]
        public async Task<IActionResult> BookContents(int id)
        {
            IBook book = await _repository.GetBookByIdAsync(id);
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

        #endregion

        #region Edit

        [HttpGet, ActionName(BooksControllerActionNames.Edit)]
        public async Task<IActionResult> Edit(int id)
        {
            IBook book = await _repository.GetBookByIdAsync(id);
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

        #endregion

        #region Delete

        [HttpGet, ActionName(BooksControllerActionNames.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            IBook book = await _repository.GetBookByIdAsync(id);
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
