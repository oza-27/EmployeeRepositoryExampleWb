using EmployeeRepositoryExample.Models;
using EmployeeRepositoryExample.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRepositoryExample.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> employeeList = _unitOfWork.Employee.GetAll();
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
            _unitOfWork.Employee.Add(emp);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        //Get for Edit
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var employeeGet = _unitOfWork.Employee.GetFirstOrDefault(x => x.Id == id);
            if (employeeGet == null)
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
            _unitOfWork.Employee.Update(emp);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var employeeGet = _unitOfWork.Employee.GetFirstOrDefault(x => x.Id == id);
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
            var obj = _unitOfWork.Employee.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Employee.Remove(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
