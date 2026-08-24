using MyBookShelf.WebForms.Constants;
using MyBookShelf.WebForms.Helpers;
using MyBookShelf.WebForms.Pages;
using System;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyBookShelf.Shared.Helpers;

namespace MyBookShelf.WebForms
{
    public partial class Home : AbstractPage
    {
        #region Methods

        protected override void InitControls()
        { }

        private void LoadBooks()
        {
            Page.RegisterAsyncTask(new PageAsyncTask(async () => await LoadBooksAsync()));
        }

        private async Task LoadBooksAsync()
        {
            var books = await Repository.GetAllBooksAsync();
            var viewModels = await Reader.GetBookListItemsAsync(books);

            gridViewBooks.DataSource = viewModels;
            gridViewBooks.DataBind();
        }

        private void AddBook()
        {
            Response.NavigateTo(AppPages.AddBook);
        }

        private void ShowContents(int bookId)
        {
            Response.NavigateTo(AppPages.BookContents, $"id={bookId}");
        }

        private void EditBook(int bookId)
        {
            Response.NavigateTo(AppPages.UpdateBook, $"id={bookId}");
        }

        private void DeleteBook(int bookId)
        {
            Page.RegisterAsyncTask(new PageAsyncTask(async () => await DeleteBookAsync(bookId)));
        }

        private async Task DeleteBookAsync(int bookId)
        {
            try
            {
                await Repository.DeleteBookByIdAsync(bookId);
                await LoadBooksAsync();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        #endregion

        #region Events Handling

        protected override void OnLoadedFirstTime(object sender, EventArgs e) => LoadBooks();
        protected void buttonAddBook_OnClick(object sender, EventArgs e) => AddBook();

        protected void gridViewBooks_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (!int.TryParse(e.CommandArgument.ToString(), out int bookId))
                return;

            switch (e.CommandName)
            {
                case CommandNames.SHOW_CONTENTS: ShowContents(bookId); break;
                case CommandNames.EDIT_BOOK: EditBook(bookId); break;
                case CommandNames.DELETE_BOOK: DeleteBook(bookId); break;
            }
        }

        #endregion
    }
}