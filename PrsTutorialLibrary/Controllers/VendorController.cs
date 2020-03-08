using Microsoft.EntityFrameworkCore;
using PrsTutorialLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrsTutorialLibrary.Controllers {
    public class VendorController {

        private AppDbContext context = new AppDbContext();
        public IEnumerable<Vendor> GetAll() {
            return context.Vendors.ToList();
        }
        public Vendor GetByPk(int id) {
            if (id < 1) throw new Exception("Id must be greater than zero");
            return context.Vendors.Find(id);
        }
        public Vendor Insert(Vendor vendor) {
            if (vendor == null) throw new Exception("Vendor cannot be null on Insert");
            //edit checking here
            context.Vendors.Add(vendor);
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("Code must be Unique", ex);
            } catch (Exception ) {
                throw;
            }
            return vendor;
        }
        public bool Update(int id, Vendor vendor) {
            if (vendor == null) throw new Exception("Vendor cannot be null");
            if (id != vendor.Id) throw new Exception("Id and Vendor.Id must match");
            context.Entry(vendor).State = EntityState.Modified;
            try {
                context.SaveChanges();
            } catch (DbUpdateException) {
                throw new Exception("Code must be unique");
            } catch (Exception ) {
                throw;
            }
            return true;
        }
        public bool Delete(Vendor vendor) {
            context.Vendors.Remove(vendor);
            context.SaveChanges();
            return true;
        }
    }
}
