using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABC_WEB.Models
{
    public class RequestPList
    {
        public int Transaction_ID { get; set; }
        public Nullable<System.DateTime> Transaction_Date { get; set; }
        public string Ref_No { get; set; }
        public string Merchant { get; set; }
        public string Acc_No { get; set; }
        public string Account_Name { get; set; }
        public string Other_detail { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> Service_Fee { get; set; }
        public string PP_Remarks { get; set; }
        public Nullable<int> Trans_ID { get; set; }
        public string ABC_TransactionID { get; set; }
        public string Status { get; set; }
        public byte[] Attachment { get; set; }
    }
}