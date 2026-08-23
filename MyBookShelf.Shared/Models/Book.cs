using System;
using System.ComponentModel.DataAnnotations;

namespace MyBookShelf.Shared.Models
{
    public sealed class Book : IEquatable<Book>
    {
        #region Properties

        public int Id { get; set; }

        [Required(ErrorMessage = "The 'Title' is mandatory!")]
        [MaxLength(255, ErrorMessage = "The 'Title' should not exceed 255 characters!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The 'Author' is mandatory!")]
        [MaxLength(255, ErrorMessage = "The 'Author' should not exceed 255 characters!")]
        public string Author { get; set; }

        [Range(0, 2222, ErrorMessage = "The publish year should be larger than zero and not in a too distant future!")]
        public short? PublishYear { get; set; }

        public string Contents { get; set; }

        #endregion

        #region Methods

        public override string ToString() => 
            $"{Id}: {Title}, {Author}";

        public bool Equals(Book other)
        {
            if (other == null) return false;
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj) =>
            obj is Book other && Equals(other);

        public override int GetHashCode() => 
            Id.GetHashCode();

        #endregion
    }
}
