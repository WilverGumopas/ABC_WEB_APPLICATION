using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABC_WEB.Models;
using System.Net.Http;

namespace ABC_WEB.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index(FormCollection formCollection)
        {
            return View("Index");
        }

        public ActionResult Upload(FormCollection formCollection)
        {
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["UploadedFile"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                    var PaymentList = new List<RequestPayment>();

                    // If you use EPPlus in a noncommercial context
                    // according to the Polyform Noncommercial license:
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;

                        for (int rowIterator = 1; rowIterator <= noOfRow; rowIterator++)
                        {

                            var RequestPayment = new RequestPayment();
                            RequestPayment.Merchant = workSheet.Cells[rowIterator, 1].Value.ToString();
                            RequestPayment.Acc_No = workSheet.Cells[rowIterator, 2].Value.ToString();
                            RequestPayment.Account_Name = workSheet.Cells[rowIterator, 3].Value.ToString();
                            RequestPayment.Ref_No = workSheet.Cells[rowIterator, 4].Value.ToString();
                            RequestPayment.Other_detail = workSheet.Cells[rowIterator, 5].Value.ToString();
                            RequestPayment.Amount = Decimal.Parse(workSheet.Cells[rowIterator, 6].Value.ToString());
                            RequestPayment.Transaction_Date = DateTime.Now;
                            RequestPayment.BalanceID = (int)Session["userID"];

                            HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("RequestPayments", RequestPayment).Result;
                        }


                    }
                }
            }

            return RedirectToAction("Index", "RequestPayment");
        }
    }
    

}