using MyBookShelf.Shared.Models;
using MyBookShelf.WebForms.Pages;
using System;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyBookShelf.WebForms.Helpers;
using MyBookShelf.Shared.Constants;

namespace MyBookShelf.WebForms.Forms
{
    public partial class UpdateBook : AbstractPage
    {
        #region Methods

        protected override void InitControls()
        {
            textTitle.MaxLength = GlobalParameters.MAX_TITLE_LENGTH;

            textAuthor.MaxLength = GlobalParameters.MAX_AUTHOR_LENGTH;

            textPublishYear.MaxLength = GlobalParameters.MIN_PUBLISH_YEAR_STR.Length;
            textPublishYearRangeValidator.MinimumValue = GlobalParameters.MIN_PUBLISH_YEAR.ToString();
            textPublishYearRangeValidator.MaximumValue = GlobalParameters.MAX_PUBLISH_YEAR.ToString();
            textPublishYearRangeValidator.ErrorMessage = GetPublishYearErrorMessage();
        }

        protected void LoadBook(int bookId)
        {
            Page.RegisterAsyncTask(new PageAsyncTask(async () => await LoadBookAsync(bookId)));
        }

        protected async Task LoadBookAsync(int bookId)
        {
            IBook book = await Repository.GetBookByIdAsync(bookId);
            if (book == null)
            {
                Response.NavigateTo(AppPages.Default);
                return;
            }

            hiddenBookId.Value = book.Id.ToString();
            textTitle.Text = book.Title;
            textAuthor.Text = book.Author;
            textPublishYear.Text = book.PublishYear?.ToString();
            textContents.Text = book.Contents;
        }

        protected async Task SaveAsync()
        {
            if (!Page.IsValid)
                return;

            if (!int.TryParse(hiddenBookId.Value, out int bookId))
                return;

            IBook book = new Book
            {
                Id = bookId,
                Title = textTitle.Text.Trim(),
                Author = textAuthor.Text.Trim(),
                PublishYear = ParsePublishYear(textPublishYear.Text.Trim()),
                Contents = textContents.Text.Trim(),
            };

            try
            {
                await Repository.UpdateBookAsync(book);
                Response.NavigateTo(AppPages.Default);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        #endregion

        #region Events Handling

        protected override void OnLoadedFirstTime(object sender, EventArgs e)
        {
            string idParam = Request.QueryString["Id"];
            if (!int.TryParse(idParam, out int bookId))
            {
                Response.NavigateTo(AppPages.Default);
                return;
            }

            LoadBook(bookId);
        }

        protected void buttonSave_Click(object sender, EventArgs e)
        {
            Page.RegisterAsyncTask(new PageAsyncTask(async () =>
            {
                WebControl control = sender as WebControl;
                if (control != null) control.Enabled = false;
                await SaveAsync();
                if (control != null) control.Enabled = true;
            }));
        }

        protected void buttonCancel_Click(object sender, EventArgs e)
        {
            Response.NavigateTo(AppPages.Default);
        }

        #endregion
    }
}