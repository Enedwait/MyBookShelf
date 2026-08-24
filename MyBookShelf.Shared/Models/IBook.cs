using System;

namespace MyBookShelf.Shared.Models
{
    public interface IBook : IEquatable<IBook>
    {
        int Id { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        short? PublishYear { get; set; }
        string Contents { get; set; }
    }
}
