using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    [Table("Employees")]
    public class Employee
    {
        //[Column("EmployeeID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Employee ID is required")]
        [Display(Name = "Employee ID")]
        public int EmployeeID { get; set; }

        [Display(Name = "Frist Name")]
        [Required(ErrorMessage = "Frist Name is required")]
        [StringLength(20, ErrorMessage = "Frist Name must be lass than 20 charactors")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20, ErrorMessage = "Last Name must be lass than 20 charactors")]
        public string LastName { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required")]
        [StringLength(20, ErrorMessage = "Title must be lass than 20 charactors")]
        public string Title { get; set; }

        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "Birth Date is required")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Hire Date")]
        [Required(ErrorMessage = "is required")]
        public DateTime HireDate { get; set; }

        [Display(Name = "Conutry")]
        [Required(ErrorMessage = "Conutry is required")]
        [StringLength(20, ErrorMessage = "Conutry must be lass than 20 charactors")]
        public string Country { get; set; }

        [Display(Name = "Notes")]
        [StringLength(500, ErrorMessage = "Notes must be lass than 500 charactors")]
        public string Notes { get; set; }



    }
}
