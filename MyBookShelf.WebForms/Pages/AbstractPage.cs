using MyBookShelf.Shared.DataAccess.Repositories;
using System;
using System.Web.UI.WebControls;
using MyBookShelf.Shared.Helpers;
using MyBookShelf.Shared.Constants;

namespace MyBookShelf.WebForms.Pages
{
    public abstract class AbstractPage : System.Web.UI.Page
    {
        #region Properties

        public IBookRepository Repository { get; set; }
        public IBookContentsReader Reader { get; set; }

        #endregion

        #region Methods

        protected abstract void InitControls();

        public virtual void ShowError(Exception exception)
        {
            Response.Write(exception);
        }

        protected short? ParsePublishYear(string text)
        {
            if (short.TryParse(text, out short value)) return value;
            return null;
        }

        protected virtual string GetPublishYearErrorMessage() =>
            $"The publish year must be in [{GlobalParameters.MIN_PUBLISH_YEAR_STR},{GlobalParameters.MAX_PUBLISH_YEAR_STR}]";

        #endregion

        #region Events Handling

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                OnPostBack(sender, e);
                return;
            }
            
            OnLoadedFirstTime(sender, e);
            InitControls();
        }

        protected virtual void OnLoadedFirstTime(object sender, EventArgs e) { }

        protected virtual void OnPostBack(object sender, EventArgs e){ }

        protected virtual void OnValidateXMLContents(object source, ServerValidateEventArgs args)
        {
            if (!args.Value.IsValidXml(out Exception exception))
            {
                args.IsValid = false;
                return;
            }

            args.IsValid = true;
        }

        #endregion
    }

    

    
}