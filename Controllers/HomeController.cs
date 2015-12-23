using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tx_insertTableDropDown.Models;

namespace tx_insertTableDropDown.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // this method inserts a new table to a temporary
        // ServerTextControl and returns the complete table
        [HttpPost]
        public string GetTableFromController(Table model)
        {
            byte[] data;

            using (TXTextControl.ServerTextControl tx =
                new TXTextControl.ServerTextControl())
            {
                tx.Create();
                tx.Tables.Add(model.Rows, model.Columns);

                tx.Save(out data, TXTextControl.BinaryStreamType.InternalUnicodeFormat);
            }

            return Convert.ToBase64String(data);
        }
    }
}