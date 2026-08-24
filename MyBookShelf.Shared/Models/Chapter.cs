namespace MyBookShelf.Shared.Models
{
    public sealed class Chapter : IChapter
    {
        #region Properties

        public string Title { get; set; }
        public int Page { get; set; }

        #endregion
    }

    public interface IChapter
    {
        string Title { get; set; }
        int Page { get; set; }
    }
}
