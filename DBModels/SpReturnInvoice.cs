using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Mediflow.DBModels
{
    public class SpReturnInvoice
    {
        [Key]
        public int Item_Id { get; set; }
        public string Item_name { get; set; }
        public string Mfg_by_name { get; set; }
        public string Market_by_name { get; set; }
        public string Medicine_Type { get; set; }
        public int? Mrp { get; set; }
        public double? Rate { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Volume { get; set; }
        public string Unit { get; set; }
        public byte[] Image { get; set; }
        public byte[] Image1 { get; set; }
        public byte[] Image2 { get; set; }
        public int? HsnCode { get; set; }
        public string ProductCategory { get; set; }
        public double? gstPercent { get; set; }
        public double? marginPercent { get; set; }

        public int Return_Id { get; set; }
        public int? RM_Id { get; set; }
        public int? RFinalOrder_Id { get; set; }
        public int? Ritem_id { get; set; }
        public int? RChemist_id { get; set; }
        public string Rbatch_no { get; set; }
        public int? Ritem_qty { get; set; }
        public DateTime? Ritem_expiry { get; set; }
        public string Rpayment_type { get; set; }
        public DateTime? Rinitiate_date { get; set; }
        public bool? R_istypeExpiry { get; set; }
    }
}
