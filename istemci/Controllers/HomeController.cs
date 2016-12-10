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
        public ActionResult Index()
        {
            if (Request.Cookies["KullaniciKimligi"] != null)
            {
                return RedirectToAction("Index", "App");
            }

            return View();
        }

        public JsonResult Kayit(string ePosta, string kullaniciAdi, string parola)
        {
            DDServiceClient servis = new DDServiceClient();

            bool durum = servis.KullaniciKayitEt(ePosta, kullaniciAdi, parola);

            if (durum)
            {
                return Json("Kayıt başarılı.");
            }
            else
            {
                return Json("Kayıt başarısız.");
            }
        }


        public JsonResult Giris(string kullaniciAdi, string parola)
        {
            DDServiceClient servis = new DDServiceClient();

            int kullaniciKimligi = servis.KullaniciGirisiYap(kullaniciAdi, parola);

            if (kullaniciKimligi != 0)
            {
                Response.Cookies["KullaniciKimligi"].Value = kullaniciKimligi.ToString();
                Response.Cookies["KullaniciKimligi"].Expires = DateTime.Now.AddDays(1);

                HttpCookie sonZiyaret = new HttpCookie("SonZiyaret", DateTime.Now.ToString());
                sonZiyaret.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(sonZiyaret);

                return Json("Giriş başarılı.");
            }
            else
            {
                return Json("Giriş başarısız.");
            }
        }
    }
}