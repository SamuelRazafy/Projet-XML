using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TPMvcEva.Models;

namespace TPMvcEva.Controllers
{
    public class FirstController : Controller
    {
        MySqlConnection conn = new MySqlConnection();

        MySqlCommand comm = new MySqlCommand();
        
        // GET: First
        public ActionResult Index()
        {
            return View();
        }

        public void ClassConn()
        {
            conn.ConnectionString = "datasource=localhost;port=3308;database=rh;username=root;password=";
        }

       [HttpPost]

              public ContentResult Verifier(Info po)
               {
                   ClassConn();
                   conn.Open();
                   String query = "SELECT * FROM `demandeconge` WHERE  `N° matricule`='" + po.matricule + "'";
                   MySqlCommand cmd = new MySqlCommand(query, conn);
                   MySqlDataReader reader = cmd.ExecuteReader();
                   if (reader.Read())
                   {
                       po.departement = reader.GetString("Departement");
                       po.service = reader.GetString("Service");
                      string text = string.Format("departement={0}, service={0}", po.departement, po.service);
                      return Content(text, "text/plain", Encoding.UTF8);
            /*     return View("Ato", po);*/
                       
                   }
                   else
                   {
                       po.departement = string.Empty;
                       po.service = string.Empty;
                     string text = string.Format("departement={0}, service={0}", po.departement, po.service);
                     return Content(text, "text/plain", Encoding.UTF8);
                  //       return View("Ato", po);
            }
                 
              
        }

    }
}