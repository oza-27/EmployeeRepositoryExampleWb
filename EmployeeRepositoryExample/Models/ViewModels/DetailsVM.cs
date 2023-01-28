using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeRepositoryExample.Models.ViewModels
{
	public class DetailsVM
	{
		public Details details { get; set; }
		public IEnumerable<SelectListItem> EmployeeList { get; set; }
		public IEnumerable<SelectListItem> PositionList { get; set; }
	}
}
