using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRepositoryExample.Models
{
	public class Details
	{
		[Key]
		public int Id { get; set; }
		
		[Required]
		[Display(Name ="Company Name")]
		[ValidateNever]
		public string Name { get; set; }
		
		
		[ValidateNever]
		public string Address { get; set; }
		
		[Required]
		[Display(Name ="Package Range")]
		public double Range { get; set; }
		[Required]
		
		public int EmployeeId { get; set; }
		[ForeignKey("EmployeeId")]
		[ValidateNever]
		public Employee Employee { get; set; }
		[Required]
		
		public int PositionId { get; set; }
		[ForeignKey("PositionId")]
		[ValidateNever]
		public Position Position { get; set; }
	}
}
