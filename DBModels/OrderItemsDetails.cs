using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mediflow.DBModels
{
    public class OrderItemsDetails
    {
        [Key]
        public int Item_Id { get; set; }
        public string Item_Name { get; set; }
        public string Mfg_By_Name { get; set; }
        public string Market_By_Name { get; set; }
       
        public string Medicine_Type { get; set; }
       
        public int? Mrp { get; set; }
        public double? Rate { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Volume { get; set; }
        public string Unit { get; set; }
        public byte[] Image { get; set; }
        public int? HsnCode { get; set; }
        public string ProductCategory { get; set; }
        public double? GstPercent { get; set; }
        public double? MarginPercent { get; set; }
        public int OrderDetail_Id { get; set; }
        public int FinalOrder_Id { get; set; }
        public int? Chemist_Id { get; set; }

        public int? Oitem_Id { get; set; }
        public int? Item_Qty { get; set; }
        public string OBatch_No { get; set; }
        public DateTime? OExpiry_Dt { get; set; }
        public bool? OItemReturn_Status { get; set; }
    }
}
