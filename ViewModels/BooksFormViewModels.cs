using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CRUDOperations.ViewModels
{
    public class BooksFormViewModels
    {
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Title { get; set; }

        [Required, MaxLength(128)]
        public string Author { get; set; }

        [Required, MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        [Display (Name = "Category")]
        public int CategoryId { get; set; }

      
        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}
