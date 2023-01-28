using EmployeeRepositoryExample.Models;
using EmployeeRepositoryExample.Models.ViewModels;
using EmployeeRepositoryExample.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeRepositoryExample.Areas.Admin.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Details> detailsList = _unitOfWork.Details.GetAll();
            return View(detailsList);
        }

       //Get for Edit
        public IActionResult Upsert(int? id)
        {
            DetailsVM detailsVM = new()
            {
                details = new(),
                EmployeeList = _unitOfWork.Employee.GetAll().Select(e => new SelectListItem
                {
                    Text = e.Name,
                    Value = e.Id.ToString()
                }),
                PositionList = _unitOfWork.Position.GetAll().Select(e=>new SelectListItem
                {
                    Text = e.Designation,
                    Value = e.Id.ToString()
                })
            };

			if (id == 0 || id == null)
            {
                //ViewBag.EmployeeList = EmployeeList; 
                //ViewBag.PositionList = PositionList;
				// create details
				return View(detailsVM);
            }
            else
            {
                // update details
            }
            return View(detailsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //POSt for Edit
        public IActionResult Upsert(Details deta)
        {
            //var employeeEdit = _db.Employees.Where(x=>x.)
            _unitOfWork.Details.Update(deta);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var employeeGet = _unitOfWork.Details.GetFirstOrDefault(x => x.Id == id);
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
            var obj = _unitOfWork.Details.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Details.Remove(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
