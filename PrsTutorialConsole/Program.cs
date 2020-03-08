using PrsTutorialLibrary;
using System;
using System.Linq;

namespace PrsTutorialConsole {
    class Program {
        static void Main(string[] args) {

            static void AddRequestLine(AppDbContext context) {
                var Request1 = context.Requests.SingleOrDefault(r => r.Description == "Request 1").Id;
                var Request2 = context.Requests.SingleOrDefault(r => r.Description == "Request 2").Id;
                var Request3 = context.Requests.SingleOrDefault(r => r.Description == "Request 3").Id;
                var Request4 = context.Requests.SingleOrDefault(r => r.Description == "Request 4").Id;
                var Request5 = context.Requests.SingleOrDefault(r => r.Description == "Request 5").Id;

                var echo = context.Products.SingleOrDefault(p => p.PartNbr == "ECHO").Id;
                var echodot = context.Products.SingleOrDefault(P => P.PartNbr == "ECHODOT").Id;
                var kindlefire = context.Products.SingleOrDefault(p => p.PartNbr == "KINDLEFIRE").Id;
                var firestick = context.Products.SingleOrDefault(p => p.PartNbr == "FIRESTICK").Id;
                var paperwhite = context.Products.SingleOrDefault(p => p.PartNbr == "PAPERWHITE").Id;

            }
        
        }
    }
}
