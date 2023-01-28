using EmployeeRepositoryExample.Models;
using EmployeeRepositoryExample.Repository.IRepository;

namespace EmployeeRepositoryExample.Repository
{
	public class DetailsRepository : Repository<Details>, IDetailsRepository
	{
		private ApplicationDbContext _db;
		public DetailsRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Details obj)
		{
			var objFromDb = _db.company_details.FirstOrDefault(u=>u.Id == obj.Id);
			if(objFromDb != null)
			{
				objFromDb.Name= obj.Name;
				objFromDb.Address= obj.Address;
				objFromDb.Range = obj.Range;
				objFromDb.EmployeeId = obj.EmployeeId;
				objFromDb.PositionId = obj.PositionId;
			}
		}
	}
}
