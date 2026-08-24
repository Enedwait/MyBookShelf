using MyBookShelf.Shared.Attributes;
using MyBookShelf.Shared.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyBookShelf.Shared.Models
{
    public sealed class Book : IBook
    {
        #region Properties
        
        public int Id { get; set; }

        [Required(ErrorMessage = "The 'Title' is mandatory!")]
        [MaxLength(GlobalParameters.MAX_TITLE_LENGTH, ErrorMessage = "The 'Title' should not exceed " + GlobalParameters.MAX_TITLE_LENGTH_STR + " characters!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The 'Author' is mandatory!")]
        [MaxLength(GlobalParameters.MAX_AUTHOR_LENGTH, ErrorMessage = "The 'Author' should not exceed" + GlobalParameters.MAX_AUTHOR_LENGTH_STR + " characters!")]
        public string Author { get; set; }

        [DisplayName("Publish Year")]
        [Range(GlobalParameters.MIN_PUBLISH_YEAR, GlobalParameters.MAX_PUBLISH_YEAR, ErrorMessage = "The publish year must be in [" + GlobalParameters.MIN_PUBLISH_YEAR_STR + "," + GlobalParameters.MAX_PUBLISH_YEAR_STR + "]!")]
        public short? PublishYear { get; set; }

        [ValidXMLString(ErrorMessage = "Contents must be a valid XML string or null!")]
        public string Contents { get; set; }

        #endregion

        #region Methods

        public override string ToString() => 
            $"{Id}: {Title}, {Author}";

        public bool Equals(IBook other)
        {
            if (other == null) return false;
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj) =>
            obj is IBook other && Equals(other);

        public override int GetHashCode() => 
            Id.GetHashCode();

        #endregion
    }
}
