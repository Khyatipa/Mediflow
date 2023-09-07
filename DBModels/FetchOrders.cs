using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mediflow.DBModels
{
    public class FetchOrders
    {
        [Key]
        public int oid { get; set; }
        public int fid { get; set; }
        public int cid { get; set; }

        public double totalpayable { get; set; }
        public DateTime date { get; set; }
        public string deliverytype { get; set; }
        public Boolean credit { get; set; }
        public string shopname { get; set; }

        public string status { get; set; }
    }
}
