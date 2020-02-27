using System;
using System.Collections.Generic;
using System.Text;

namespace PrsTutorialLibrary.Models {
    public class Request {

        public int Id { get; set; }
        public string Description { get; set; }
        public string Justification { get; set; }
        public string RejectionReason { get; set; }
        public string DeliveryMode { get; set; } = "Pickup";
        public string Status { get; set; } = "NEW";
        public decimal Total { get; set; } = 0;
        public int UserId { get; set; }

        public Request() { }

    }
}
