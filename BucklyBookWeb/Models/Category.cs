using System.ComponentModel.DataAnnotations;

namespace BucklyBookWeb.Models
{
    public class Category
    {

        [Key ]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string email { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
         




    }
}
