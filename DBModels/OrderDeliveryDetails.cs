using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mediflow.DBModels
{
    public partial class OrderDeliveryDetails
    {
        public int DeliveryId { get; set; }
        public int? FinalOrderId { get; set; }
        public int? ChemistId { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public string Telephone { get; set; }
        public string EmailChemist { get; set; }
    }
}
