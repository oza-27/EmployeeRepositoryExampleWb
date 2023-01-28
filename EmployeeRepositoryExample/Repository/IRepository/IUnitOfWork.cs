namespace EmployeeRepositoryExample.Repository.IRepository
{
	public interface IUnitOfWork
	{
		IEmployeesRepository Employees { get; }
		void Save();
	}
}
