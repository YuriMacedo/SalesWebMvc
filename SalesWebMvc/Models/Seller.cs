using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength =3,ErrorMessage = "Name must have at least 3 characters or less than 60 characters")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email.")]
        public string Email { get; set; }
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be between {1} and {2}")]
        public double BaseSalary { get; set; }
        public int DepartamentId { get; set; }
        public Departament Departament { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
       
        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Departament departament)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        public void addSales(SalesRecord sr) {
            Sales.Add(sr);
        }

        public void removeSales(SalesRecord sr) {
            Sales.Remove(sr);
        }

        public double totalSales(DateTime initial, DateTime final) {

            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
