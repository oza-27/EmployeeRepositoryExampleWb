using EmployeeRepositoryExample.Models;

namespace EmployeeRepositoryExample.Repository.IRepository
{
	public interface IDetailsRepository : IRepository<Details>
	{
		void Update(Details obj);
		
	}
}
