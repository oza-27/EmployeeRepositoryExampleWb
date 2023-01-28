using EmployeeRepositoryExample.Models;
using EmployeeRepositoryExample.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeRepositoryExample.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _db;
		internal DbSet<T> values;

		public Repository(ApplicationDbContext db)
		{
			_db = db;
			this.values = _db.Set<T>();
		}

		public void Add(T entity)
		{
			values.Add(entity);
		}

		public IEnumerable<T> GetAll()
		{
			IQueryable<T> query = values;
			return query.ToList();
		}

		public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> query = values;
			query = query.Where(filter);
			return query.FirstOrDefault();
		}

		public void Remove(T entity)
		{
			values.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entity)
		{
			values.RemoveRange(entity);
		}
	}
}
