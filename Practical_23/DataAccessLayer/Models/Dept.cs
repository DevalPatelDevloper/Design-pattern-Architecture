using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class Dept
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Dept_Name { get; set; }
    }
}
