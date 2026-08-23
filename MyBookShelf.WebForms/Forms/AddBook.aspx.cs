using MyBookShelf.Shared.Helpers;
using MyBookShelf.Shared.Models;
using MyBookShelf.WebForms.Pages;
using System;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyBookShelf.WebForms.Forms
{
    public partial class AddBook : AbstractPage
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

        protected async Task SaveAsync()
        {
            if (!Page.IsValid)
                return;

            Book book = new Book
            {
                Title = textTitle.Text.Trim(),
                Author = textAuthor.Text.Trim(),
                PublishYear = ParsePublishYear(textPublishYear.Text.Trim()),
                Contents = textContents.Text.Trim(),
            };

            try
            {
                await Repository.AddBookAsync(book);
                Response.NavigateTo(Pages.Pages.Default);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        #endregion

        #region Events Handling

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
            Response.NavigateTo(Pages.Pages.Default);
        }

        #endregion
    }
}