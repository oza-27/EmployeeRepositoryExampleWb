namespace EmployeeRepositoryExample.Repository.IRepository
{
	public interface IUnitOfWork
	{
		IEmployeesRepository Employee { get; }
		IPositionRepository Position { get; }
		IDetailsRepository Details { get; }
		void Save();
	}
}
