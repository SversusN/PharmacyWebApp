using Microsoft.EntityFrameworkCore;
using PharmacyWebApp.Models.Tables;
using PharmacyWebApp.Models.Tables.ProductClasses;

namespace PharmacyWebApp.Models
{
    public class PharmacyDB : DbContext
    {
        
        public PharmacyDB(DbContextOptions<PharmacyDB> options) : base(options)
        {
            
        }
        DbSet<Party> Parties { get; set; }
        DbSet<Pharmacy> Pharmacies { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Warehouse> Warehouses { get; set; }

        public List<Pharmacy> GetPharmacies()
        { 
            return Pharmacies.ToList();
        }

        public List<ProductsInPharmacy> GetProductsInPharmacies(int id)
        {
            return Pharmacies.ToList().Find(c => c.Id == id).ProductsInPharmacies;
        }

        public Warehouse GetWarehouse(int id)
        {
            return Warehouses.ToList().Find(c => c.Id == id);
        }

        public List<Product> GetProducts()
        { 
            return Products.ToList();
        }
        public void RemovePharmacy(int id)
        {
            Pharmacy pharmacy = Pharmacies.ToList().Find(x => x.Id == id);
            if (pharmacy != null)
            {
                foreach (var warehouse in pharmacy.Warehouses)
                {
                    RemoveWarehouse(warehouse.Id);
                }

                Pharmacies.Remove(pharmacy);
            }
        }

        public void RemoveParty(int id)
        {
            Party party = Parties.ToList().Find(c => c.Id == id);
            if (party != null)
            {
                Parties.Remove(party);
                SaveChanges();
            }
        }

        public void RemoveWarehouse(int id) 
        {
            Warehouse warehouse = Warehouses.ToList().Find(c => c.Id == id);
            if(warehouse.Parties != null)
            foreach (var item in warehouse.Parties)
            {
                RemoveParty(item.Id);
            }
            Warehouses.Remove(warehouse);
            SaveChanges();
        }
        public void RemoveProduct(int id)
        {
            Product product = Products.ToList().Find(p=> p.Id == id);
            if(product.Parties != null)
            foreach (var party in product.Parties)
            {
                RemoveParty(party.Id);
            }
            Products.Remove(product);
            SaveChanges();
        }

        public void AddProduct(Product product)
        { 
            Products.Add(product);
            SaveChanges();
        }
        public void AddPharmacy(Pharmacy pharmacy, out Pharmacy newpharmacy)
        {
            newpharmacy = Pharmacies.Add(pharmacy).Entity;
            SaveChanges();
        }

        public void AddParty(Party party, out Party newParty)
        {
            newParty = Parties.Add(party).Entity;
            SaveChanges();
        }

        public void AddProduct(Product product, out Product newProduct)
        {
            newProduct = Products.Add(product).Entity;
            SaveChanges();
        }

        public void AddWarehouse(Warehouse warehouse, int pharmacyId, out Warehouse newWarehouse)
        { 
            newWarehouse = Warehouses.Add(warehouse).Entity;
            newWarehouse.Pharmacy = Pharmacies.ToList().Find(c => c.Id == pharmacyId);
            SaveChanges();
        }
    }
}
