using System;
using System.Xml.Linq;

namespace MyBookShelf.Shared.Helpers
{
    public static class XmlHelper
    {
        #region IsValidXml

        public static bool IsValidXml(this string text, out Exception exception)
        {
            exception = null;
            if (string.IsNullOrWhiteSpace(text)) return true;

            try
            {
                XDocument document = XDocument.Parse(text);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        #endregion
    }
}
