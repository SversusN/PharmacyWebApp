using System.Linq;
using System.Net;

namespace PharmacyWebApp.Models.Tables.ProductClasses
{
    public class ProductsInPharmacy
    {
        public virtual Product Product { get; set; }
        public int CountProducts { get; set; }

        public ProductsInPharmacy()
        {
            
        }
    }
}
