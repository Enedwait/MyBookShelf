using MyBookShelf.WebForms.Forms;
using System.Web;

namespace MyBookShelf.WebForms.Helpers
{
    internal enum AppPages { Default, AddBook, UpdateBook, BookContents }

    internal static class NavigationHelper
    {
        #region NavigateTo

        public static void NavigateTo(this HttpResponse response, AppPages appPage, string query = null)
        {
            string addedQuery = string.IsNullOrWhiteSpace(query) ? string.Empty : $"?{query}";

            switch (appPage)
            {
                case AppPages.Default: response.Redirect($"/{nameof(Home)}.aspx" + addedQuery); break;
                case AppPages.AddBook: response.Redirect($"/Forms/{nameof(AddBook)}.aspx" + addedQuery); break;
                case AppPages.UpdateBook: response.Redirect($"/Forms/{nameof(UpdateBook)}.aspx" + addedQuery); break;
                case AppPages.BookContents: response.Redirect($"/Forms/{nameof(BookContents)}.aspx" + addedQuery); break;
            }
        }

        #endregion
    }
}