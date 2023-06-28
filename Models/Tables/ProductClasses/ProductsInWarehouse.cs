using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Models.Tables.ProductClasses
{
    public class ProductsInWarehouse
    {
        public ProductsInWarehouse()
        {
        
        }
        public virtual Product Product { get; set; }
        public int CountProducts { get; set; }
    }
}
