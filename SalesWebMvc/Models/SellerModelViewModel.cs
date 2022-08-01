using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class SellerModelViewModel
    {
        public Seller Seller { get; set; }
        public ICollection <Departament> Departaments { get; set; }

    }
}
