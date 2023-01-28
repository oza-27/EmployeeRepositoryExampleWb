using EmployeeRepositoryExample.Models;
using EmployeeRepositoryExample.Repository.IRepository;

namespace EmployeeRepositoryExample.Repository
{
	public class PositionRepository : Repository<Position>, IPositionRepository
	{
		private ApplicationDbContext _db;
		public PositionRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Position obj)
		{
			_db.positions.Update(obj);
		}
	}
}
