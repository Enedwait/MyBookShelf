using Ganss.Xss;

namespace MyBookShelf.Shared.Helpers
{
    public static class HtmlSanitizerHelper
    {
        #region SanitizeText

        public static string SanitizeText(this string rawText)
        {
            if (string.IsNullOrWhiteSpace(rawText))
                return rawText;

            var sanitizer = new HtmlSanitizer();
            sanitizer.AddAllowedTags();
            string sanitizedText = sanitizer.Sanitize(rawText.Trim());
            return sanitizedText;
        }

        #endregion

        #region AddAllowedTags

        public static void AddAllowedTags(this HtmlSanitizer sanitizer)
        {
            // Здесь в качестве примера добавлены разрешённые xml-тэги для простоты

            sanitizer.AllowedTags.Add("BookContents");
            sanitizer.AllowedTags.Add("Header");
            sanitizer.AllowedTags.Add("Book");
            sanitizer.AllowedTags.Add("Caption");
            sanitizer.AllowedTags.Add("Pages");
            sanitizer.AllowedTags.Add("Contents");
            sanitizer.AllowedTags.Add("Part");
            sanitizer.AllowedTags.Add("Section");
            sanitizer.AllowedTags.Add("Chapter");
            sanitizer.AllowedTags.Add("Paragraph");
        }

        #endregion
    }
}
