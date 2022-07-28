using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SalesWebMvc.Models
{
    public class Departament
    {
        public int id { get; set; }
        public string  name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();


        public Departament(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Departament()
        {
        }

        public void addSeller(Seller seller) {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final) {
            return Sellers.Sum(seller => seller.totalSales(initial, final));
        }
    }
}
