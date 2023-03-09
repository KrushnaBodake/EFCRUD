using WebApplication2.Data;

namespace WebApplication2.Models
{
    public class ProductsDal
    {
        private readonly ApplicationDbContext db;
        public ProductsDal(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Products> GetAllProducts()
        {
           
             return db.Products.ToList();
        }
        public Products GetProductsById(int id)
        {
            var prod = db.Products.Find(id);
            return prod;

        }
        public int AddProducts(Products prod)
        {
            db.Products.Add(prod);
            int result = db.SaveChanges();

            return result;

        }
        public int UpdateProducts(Products prod)
        {
            // p contains old data
            int result = 0;
            var p = db.Products.Where(x => x.Id == prod.Id).FirstOrDefault();
            if (p != null)
            {
                p.Pname = prod.Pname;
                p.Price = prod.Price;
                result = db.SaveChanges();
            }
            return result;

        }
        public int DeleteProducts(int id)
        {
            int result = 0;
            var p = db.Products.Where(x => x.Id == id).FirstOrDefault();
            if (p != null)
            {
                db.Products.Remove(p);
                result = db.SaveChanges();
            }
            return result;

        }
    }
}
