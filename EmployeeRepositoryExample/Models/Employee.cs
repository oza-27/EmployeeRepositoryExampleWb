using System.ComponentModel.DataAnnotations;

namespace EmployeeRepositoryExample.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Technology { get; set; }
    }
}
