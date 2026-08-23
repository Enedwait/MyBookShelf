using MyBookShelf.Shared.Models;
using MyBookShelf.WebForms.Pages;
using System;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyBookShelf.Shared.Helpers;
using MyBookShelf.WebForms.Helpers;

namespace MyBookShelf.WebForms.Forms
{
    public partial class BookContents : AbstractPage
    {
        #region Methods

        protected override void InitControls()
        { }

        protected void LoadBook(int bookId)
        {
            Page.RegisterAsyncTask(new PageAsyncTask(async () => await LoadBookAsync(bookId)));
        }

        protected async Task LoadBookAsync(int bookId)
        {
            Book book = await Repository.GetBookByIdAsync(bookId);
            if (book == null)
            {
                Response.NavigateTo(AppPages.Default);
                return;
            }
            
            hiddenBookId.Value = book.Id.ToString();
            textContents.Text = book.Contents;
        }

        protected void Save()
        {
            Page.RegisterAsyncTask(new PageAsyncTask(async () => await SaveAsync()));
        }

        protected async Task SaveAsync()
        {
            if (!Page.IsValid)
                return;

            if (!int.TryParse(hiddenBookId.Value, out int bookId))
                return;

            if (!textContents.Text.IsValidXml(out Exception exception))
            {
                ShowError(exception);
                return;
            }

            try
            {
                await Repository.UpdateContentsByBookIdAsync(bookId, textContents.Text);
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
            WebControl control = sender as WebControl;
            if (control != null) control.Enabled = false;
            Save();
            if (control != null) control.Enabled = true;
        }

        protected void buttonCancel_Click(object sender, EventArgs e)
        {
            Response.NavigateTo(AppPages.Default);
        }

        #endregion
    }
}