using Microsoft.EntityFrameworkCore;
using PrsTutorialLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrsTutorialLibrary.Controllers {
    public class RequestLineController {

        private AppDbContext context = new AppDbContext();

        private void RecalcRequestTotal(int requestId) {
            var request = context.Requests.Find(requestId);
            request.Total = request.RequestLines.Sum(x => x.Quantity * x.Product.Price);
            context.SaveChanges();
        }

        public IEnumerable<RequestLine> GetAll() {
            return context.RequestLines.ToList();
        }
        public RequestLine GetByPk(int id) {
            if (id < 1) throw new Exception("Id must be greater than zero");
            return context.RequestLines.Find(id);
        }
        public RequestLine Insert(RequestLine requestLine) {
            if (requestLine == null) throw new Exception("RequestLine cannot be null on Insert");
            //edit checking here
            context.RequestLines.Add(requestLine);
            try {
                context.SaveChanges();
                RecalcRequestTotal(requestLine.RequestId);
            } catch (DbUpdateException ex) {
                throw new Exception("Username must be Unique", ex);
            } catch (Exception ) {
                throw;
            }
            return requestLine;
        }
        public bool Update(int id, RequestLine requestLine) {
            if (requestLine == null) throw new Exception("RequestLine cannot be null");
            if (id != requestLine.Id) throw new Exception("Id and requestLine.Id must match");
            context.Entry(requestLine).State = EntityState.Modified;
            try {
                context.SaveChanges();
                RecalcRequestTotal(requestLine.RequestId);
            } catch (DbUpdateException) {
                throw new Exception("Username must be unique");
            } catch (Exception ) {
                throw;
            }
            return true;
        }
        public bool Delete(RequestLine requestLine) {
            context.RequestLines.Remove(requestLine);
            context.SaveChanges();
            RecalcRequestTotal(requestLine.RequestId);
            return true;
        }
    }
}
