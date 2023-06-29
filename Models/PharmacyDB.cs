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
        public DbSet<Party> Parties { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        public void RemovePharmacy(int id)
        {
            Pharmacy pharmacy = Pharmacies.Find(id);
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
            Party party = Parties.Find(id);
            if (party != null)
            {
                Parties.Remove(party);
                SaveChanges();
            }
        }

        public void RemoveWarehouse(int id) 
        {
            Warehouse warehouse = Warehouses.Find(id);
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
            Product product = Products.Find(id);
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

        public void AddWarehouse(Warehouse warehouse, out Warehouse newWarehouse)
        { 
            newWarehouse = Warehouses.Add(warehouse).Entity;
            SaveChanges();
        }
    }
}
