using EmployeeRepositoryExample.Models;

namespace EmployeeRepositoryExample.Repository.IRepository
{
	public interface IPositionRepository : IRepository<Position>
	{
		void Update(Position obj);
		
	}
}
