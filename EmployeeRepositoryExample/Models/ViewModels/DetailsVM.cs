using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeRepositoryExample.Models.ViewModels
{
	public class DetailsVM
	{
		public Details details { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> EmployeeList { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> PositionList { get; set; }
	}
}
