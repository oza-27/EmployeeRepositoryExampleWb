using EmployeeRepositoryExample.Models;
using EmployeeRepositoryExample.Repository.IRepository;

namespace EmployeeRepositoryExample.Repository
{
	public class EmployeeRepository : Repository<Employee>, IEmployeesRepository
	{
		private ApplicationDbContext _db;
		public EmployeeRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Employee obj)
		{
			_db.Employees.Update(obj);
		}
	}
}
