using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Models
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string Salary { get; set; }
        public int DeptId { get; set; }
        [ForeignKey("DeptId")]
        public Dept Dept { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Joing_date { get; set; }
        [Required]
        public bool Status { get; set; }

    }
}
