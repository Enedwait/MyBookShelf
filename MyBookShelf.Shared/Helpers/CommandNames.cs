namespace MyBookShelf.Shared.Helpers
{
    public static class CommandNames
    {
        public const string ADD_BOOK = "AddBook";
        public const string SHOW_CONTENTS = "ShowContents";
        public const string EDIT_CONTENTS = "EditContents";
        public const string EDIT_BOOK = "EditBook";
        public const string DELETE_BOOK = "DeleteBook";
    }

    public static class GlobalParameters
    {
        public const int MAX_TITLE_LENGTH = 255;
        public const string MAX_TITLE_LENGTH_STR = "255";
        public const int MAX_AUTHOR_LENGTH = 255;
        public const string MAX_AUTHOR_LENGTH_STR ="255";
        public const int MIN_PUBLISH_YEAR = 0;
        public const string MIN_PUBLISH_YEAR_STR = "0";
        public const int MAX_PUBLISH_YEAR = 2222;
        public const string MAX_PUBLISH_YEAR_STR = "2222";
    }
}
