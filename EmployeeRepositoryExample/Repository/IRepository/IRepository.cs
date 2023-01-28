using System.Linq.Expressions;

namespace EmployeeRepositoryExample.Repository.IRepository
{
	public interface IRepository<T> where T:class
	{
		// T-employee name
		T GetFirstOrDefault(Expression<Func<T, bool>> filter);
		IEnumerable<T> GetAll(); // retrieving all the names of employees
		void Add(T entity); // Adding employees
		void Remove(T entity); // removing one row
		void RemoveRange(IEnumerable<T> entity); // removing multiple rows
	}
}
