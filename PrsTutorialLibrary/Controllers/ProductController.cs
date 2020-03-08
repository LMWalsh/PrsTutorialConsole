using Microsoft.EntityFrameworkCore;
using PrsTutorialLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrsTutorialLibrary.Controllers {
    class ProductController {

        private AppDbContext context = new AppDbContext();
        public IEnumerable<Product> GetAll() {
            return context.Products.ToList();
        }
        public Product GetByPk(int id) {
            if (id < 1) throw new Exception("Id must be greater than zero");
            return context.Products.Find(id);
        }
        public Product Insert(Product product) {
            if (product == null) throw new Exception("Product cannot be null on Insert");
            //edit checking here
            context.Products.Add(product);
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("PartNbr must be Unique", ex);
            } catch (Exception ) {
                throw;
            }
            return product;
        }
        public bool Update(int id, Product product) {
            if (product == null) throw new Exception("Name cannot be null");
            if (id != product.Id) throw new Exception("Id and Product.Id must match");
            context.Entry(product).State = EntityState.Modified;
            try {
                context.SaveChanges();
            } catch (DbUpdateException) {
                throw new Exception("PartNbr must be unique");
            } catch (Exception ) {
                throw;
            }
            return true;
        }
        public bool Delete(Product product) {
            context.Products.Remove(product);
            context.SaveChanges();
            return true;
        }
    }
}
