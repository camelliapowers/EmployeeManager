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
    public class EmployeeManagerController : Controller
    {
        // GET: /<controller>/
        public IActionResult List()
        {
            var model = db.Employees
                .OrderBy(x => x.EmployeeID)
                .Select(x => new SelectListItem
                {
                    Text = x.EmployeeID.ToString()
                })
                .ToList();
            return View(model);

        }
        //public IActionResult List()
        //{
        //    List<Employee> model = (from e in db.Employees
        //                            orderby e.EmployeeID
        //                            select e).ToList();
        //    return View(model);
        //}

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

            //List<SelectListItem> countries =  
            //(from c in db.Countries
            // orderby c.Name ascending
            // select new SelectListItem()
            // {
            //     Text = c.Name,
            //     Value = c.Name
            // }).ToList();
            ViewBag.Countries = countries;
        }


    }
}
