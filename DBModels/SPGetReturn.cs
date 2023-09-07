using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Mediflow.DBModels
{
    public class SPGetReturn
    {
        [Key]
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Rdlno { get; set; }
        public string GstNo { get; set; }
        public string Email { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zcode { get; set; }
        public string Status { get; set; }
        public bool? IsCredit { get; set; }
        public int RMaster_Id { get; set; }
        public int? RM_finalOrder_Id { get; set; }
        public DateTime? RM_date { get; set; }
        public double? RM_valuePrice { get; set; }
        public double? RM_gstCharge { get; set; }
        public double? RM_finalPayable { get; set; }
        public bool? RM_istypeExpiry { get; set; }
        public bool? RM_isNewRecord { get; set; }
        public int? RM_Cid { get; set; }
    }
}
