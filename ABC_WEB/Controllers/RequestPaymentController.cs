using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ABC_WEB.Models;
using PagedList.Mvc;
using PagedList;


namespace ABC_WEB.Controllers
{
    public class RequestPaymentController : Controller
    {
        public int ClientID;
        public decimal intRemainingBalance;
        // GET: RequestPayment
        public ActionResult Index(int ? i)
        {
            

            using (ABC_DBEntities1 db = new ABC_DBEntities1())
            {
                int BalanceModel = Int32.Parse(Session["userID"].ToString());                   
                var BalanceDetail = db.Balances.Where(x => x.Client_ID == BalanceModel).FirstOrDefault();
                intRemainingBalance = BalanceDetail.Balance1;
                ClientID = BalanceDetail.Balance_ID;

            }

            ViewBag.UserID = Session["FullName"];
            ViewBag.Balance = intRemainingBalance.ToString();
            IEnumerable<RequestPList> ReqList;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("RequestPLists").Result;
            ReqList = response.Content.ReadAsAsync<IEnumerable<RequestPList>>().Result;
            return View(ReqList.ToPagedList(i ?? 1,10));
        }
        public ActionResult AddRequestPayment(int id = 0)
        {
            
            return View(new RequestPayment());

        }
        [HttpPost]
        public ActionResult AddRequestPayment(RequestPayment ReqPay)
        {
            ReqPay.Transaction_Date = DateTime.Now;
            ReqPay.BalanceID = (int)Session["userID"];
            HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("RequestPayments", ReqPay).Result;
            return RedirectToAction("Index");
           
        }
    }
}