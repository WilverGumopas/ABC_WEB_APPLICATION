//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ABC_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RequestPaymentList
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
