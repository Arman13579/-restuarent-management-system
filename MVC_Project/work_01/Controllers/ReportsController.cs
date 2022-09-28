using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace work_01.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RestuarentReport()
        {
            try
            {
                string str = @"Data Source=.;Initial Catalog=MVC_Project2(second);Integrated Security=True";
                SqlConnection con = new SqlConnection(str);
                SqlDataAdapter ada = new SqlDataAdapter();
                SqlCommand command = con.CreateCommand();
                command.CommandText = "select * from Items i join ItemCategories c on i.Category = c.ItemCategoryId";
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds, "Items");
                ReportDocument rd = new ReportDocument();
                string rptPath = System.Web.HttpContext.Current.Server.MapPath("~/Report/RestuarentReport.rpt");
                rd.Load(rptPath);
                rd.SetDataSource(ds);
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Flush();
                rd.Close();
                rd.Dispose();
                return File(stream, System.Net.Mime.MediaTypeNames.Application.Pdf);

               

            }
            catch (Exception ex)
            {
                return Content("<h2>Error:" + ex.Message + "</h2>", "text/html");
            }
        }
    }
}