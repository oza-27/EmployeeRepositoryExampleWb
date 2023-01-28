using EmployeeRepositoryExample.Models;

namespace EmployeeRepositoryExample.Repository.IRepository
{
	public interface IEmployeesRepository : IRepository<Employee>
	{
		void Update(Employee obj);
		
	}
}
