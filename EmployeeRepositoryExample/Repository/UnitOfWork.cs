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
			Employee = new EmployeeRepository(_db);
			Position = new PositionRepository(_db);
			Details = new DetailsRepository(_db);
		}
		public IEmployeesRepository Employee { get; private set; }
		public IPositionRepository Position { get; private set; }
		public IDetailsRepository Details { get; private set; }
		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
