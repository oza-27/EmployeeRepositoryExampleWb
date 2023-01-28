using EmployeeRepositoryExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRepositoryExample.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> employeeList = _db.Employees;
            return View(employeeList);
        }

        // Get Action method
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            _db.Employees.Add(emp);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get for Edit
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var employeeGet = _db.Employees.FirstOrDefault(x=>x.Id==id);
            if(employeeGet == null)
            {
                return NotFound();
            }
            return View(employeeGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //POSt for Edit
        public IActionResult Edit(Employee emp)
        {
            //var employeeEdit = _db.Employees.Where(x=>x.)
            _db.Employees.Update(emp);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var employeeGet = _db.Employees.FirstOrDefault(x => x.Id == id);
            if (employeeGet == null)
            {
                return NotFound();
            }
            return View(employeeGet);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int? id)
        {
            var obj = _db.Employees.FirstOrDefault(x=>x.Id==id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Employees.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
