using Microsoft.EntityFrameworkCore;
using PrsTutorialLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrsTutorialLibrary.Controllers {
    public class UserController {
        private AppDbContext context = new AppDbContext();

        public User Login(string username, string password) {
            return context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }

        public IEnumerable<User>GetAll() {
            return context.Users.ToList();
        }
        public User GetByPk(int id) {
            if (id < 1) throw new Exception("Id must be greater than zero");
            return context.Users.Find(id);
        }
        public User Insert(User user) {
            if (user == null) throw new Exception("User cannot be null on Insert");
            //edit checking here
            context.Users.Add(user);
            try {
                context.SaveChanges();
            } catch(DbUpdateException ex) {
                throw new Exception("Username must be Unique", ex);
            } catch (Exception ) {
                throw;
            } return user;
        }
        public bool Update(int id, User user) {
            if (user == null) throw new Exception("User cannot be null");
            if (id != user.Id) throw new Exception("Id and User.Id must match");
            context.Entry(user).State = EntityState.Modified;
            try {
                context.SaveChanges();
            } catch (DbUpdateException) {
                throw new Exception("Username must be unique");
            } catch (Exception ) {
                throw;
            }
            return true;
        }
        public bool Delete (User user) {
            context.Users.Remove(user);
            context.SaveChanges();
            return true;
        }
    }
}
