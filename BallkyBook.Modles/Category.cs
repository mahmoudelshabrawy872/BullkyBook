using System.ComponentModel.DataAnnotations;

namespace BallkyBook.Modles
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(80)]
        public string name { get; set; } = string.Empty;
    }
}
