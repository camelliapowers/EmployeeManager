using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManager.Controllers
{

    //[Route("/EmployeeManager")]
    public class EmployeeManagerController : Controller
    {
        // GET: /<controller>/
        public IActionResult List()
        {
            var model = db.Employees
                .OrderBy(x => x.EmployeeID)
                .ToList();
            return View(model);
        }
       
        private AppDbContext db = null;

        public EmployeeManagerController(AppDbContext db)
        {
            this.db = db;
        }


        private void FillCountries()
        {
            var countries = db.Countries
                .OrderBy(c => c.Name)
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Name
                })
                .ToList();
            ViewBag.Countries = countries;
        }

        public IActionResult Insert() 
        {
            FillCountries();
            return View();
        }
        
        [HttpPost]
        public IActionResult Insert(Employee model)
        {
            FillCountries();
            if (ModelState.IsValid)
            {
                db.Employees.Add(model);
                db.SaveChanges();
                ViewBag.Message = "Employee successfully added";
            }
            return RedirectToAction("List");
        }



        public IActionResult Update(int id)
        {
            FillCountries();
            Employee model = db.Employees.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Employee model)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Update(model);
                db.SaveChanges();
                ViewBag.Message = "Employee  successfully updated";
            }
            //return View(model);
            return RedirectToAction("List");
        }

        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            Employee model = db.Employees.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int employeeID)
        {
            Employee model = db.Employees.Find(employeeID);
            db.Employees.Remove(model);
            db.SaveChanges();
            TempData["Message"] = "Employee successfully deleted";
            return RedirectToAction("List");

        }

    }
}
