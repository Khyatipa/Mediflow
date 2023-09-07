using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mediflow.DBModels
{
    public class SPCartDetails
    {
        [Key]
        public int Id { get; set; }
        
        public int Oid { get; set; }
        public string Itemname { get; set; }
        public  int Qty { get; set; }
        public int Price { get; set; }
        public byte[] Img { get; set; }
        public int CID { get; set; }
        public double Margin { get; set; }
        public double gstRate { get; set; }
        public double Rate { get; set; }
        public int Code { get; set; }

        public DateTime expiryDate { get; set; }
        public string batchNumber { get; set;}

    }
}
