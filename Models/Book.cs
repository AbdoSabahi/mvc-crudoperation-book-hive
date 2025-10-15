using System.ComponentModel.DataAnnotations;

namespace CRUDOperations.Models
{
    public class Book
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
      

        [Required]
        [MaxLength(128)]
        public string Author { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public DateTime AddedOn { get; set; }

        public Book()
        {
            AddedOn= DateTime.Now;
        }
    }
}
