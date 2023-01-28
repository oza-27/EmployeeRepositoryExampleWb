using System.ComponentModel.DataAnnotations;

namespace EmployeeRepositoryExample.Models
{
	public class Position
	{
		[Key]
		public int Id { get; set; }

		[Display(Name ="Position Designation")]
		[Required]
		[MaxLength(50)]
		public string Designation { get; set; }
	}
}
