using İstemci.DDService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace İstemci.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string kayit_eposta, string kayit_kullanici_adi, string kayit_parola)
        {

            DDServiceClient servis = new DDServiceClient();

            bool durum = servis.KullaniciKayitEt(kayit_eposta, kayit_kullanici_adi, kayit_parola);

            servis.Close();

            return View();
        }
    }
}