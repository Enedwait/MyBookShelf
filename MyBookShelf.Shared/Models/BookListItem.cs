using System.Collections.Generic;
using System.ComponentModel;

namespace MyBookShelf.Shared.Models
{
    public class BookListItem
    {
        #region Properties

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        [DisplayName("Publish Year")]
        public short? PublishYear { get; set; }
        public string Contents { get; set; }

        [DisplayName("Total Pages")]
        public int? TotalPages { get; set; }

        [DisplayName("Chapter Count")]
        public int? ChapterCount { get; set; }

        [DisplayName("Chapters")]
        public IEnumerable<IChapter> Chapters { get; set; }

        #endregion

        #region Init

        protected BookListItem()
        { }

        public BookListItem(IBook book)
        {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
            PublishYear = book.PublishYear;
            Contents = book.Contents;
        }

        public BookListItem(IBook book, int? totalPages, int? chapterCount, IEnumerable<IChapter> chapters)
            : this(book)
        {
            TotalPages = totalPages;
            ChapterCount = chapterCount;
            Chapters = chapters;
        }

        #endregion
    }
}
