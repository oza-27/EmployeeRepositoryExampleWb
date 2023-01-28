using EmployeeRepositoryExample.Models;
using EmployeeRepositoryExample.Repository.IRepository;

namespace EmployeeRepositoryExample.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext _db;
		public UnitOfWork(ApplicationDbContext db)
		{
			_db= db;
			Employees = new EmployeeRepository(_db);
		}
		public IEmployeesRepository Employees { get; private set; }

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
