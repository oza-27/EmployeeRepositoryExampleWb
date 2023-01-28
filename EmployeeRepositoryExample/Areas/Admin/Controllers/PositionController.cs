using EmployeeRepositoryExample.Models;
using EmployeeRepositoryExample.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRepositoryExample.Areas.Admin.Controllers
{
    public class PositionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PositionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Position> positionList = _unitOfWork.Position.GetAll();
            return View(positionList);
        }

        // Get Action method
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Position pos)
        {
            _unitOfWork.Position.Add(pos);
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
            var employeeGet = _unitOfWork.Position.GetFirstOrDefault(x => x.Id == id);
            if (employeeGet == null)
            {
                return NotFound();
            }
            return View(employeeGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //POSt for Edit
        public IActionResult Edit(Position pos)
        {
            //var employeeEdit = _db.Employees.Where(x=>x.)
            _unitOfWork.Position.Update(pos);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var employeeGet = _unitOfWork.Position.GetFirstOrDefault(x => x.Id == id);
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
            var obj = _unitOfWork.Position.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Position.Remove(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
