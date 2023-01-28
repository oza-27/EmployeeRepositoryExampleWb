using System.ComponentModel.DataAnnotations;

namespace EmployeeRepositoryExample.Models
{
	public class Position
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Designation { get; set; }
	}
}
