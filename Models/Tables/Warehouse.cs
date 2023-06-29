using PharmacyWebApp.Models.Tables.ProductClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PharmacyWebApp.Models.Tables
{
    [Table("Warehouse")]
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
        [JsonIgnore]
        public virtual ICollection<Party> Parties { get; set; }

        [NotMapped]
        [JsonIgnore]
        public List<ProductsInWarehouse> ProductsInWarehouses 
        {
            get
            {
                return Parties.GroupBy(c => c.Product)
                    .Select(v => new ProductsInWarehouse {  Product = v.Key, CountProducts = v.Sum(s => s.CountProducts) })
                    .ToList();
            }
        }
    }
}
