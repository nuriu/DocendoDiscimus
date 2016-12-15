using System.Web.Mvc;
using istemci.DDService;
using System.Net;

namespace istemci.Controllers
{
    public class AppController : Controller
    {
        private readonly DDServiceClient servis = new DDServiceClient();

        public ActionResult Anasayfa()
        {
            if (Request.Cookies["KullaniciKimligi"] != null)
            {
                ViewBag.Title = "Anasayfa";
                ViewBag.Kullanici = servis.KullaniciBilgileriniGetir(int.Parse(Request.Cookies["KullaniciKimligi"].Value));
                ViewBag.Sorular = servis.SorulariGetir();

                return View();
            }
            return RedirectToAction("Anasayfa", "Home");
        }

        public ActionResult Profil()
        {
            if (Request.Cookies["KullaniciKimligi"] != null)
            {
                ViewBag.Title = "Profil";
                ViewBag.Kullanici = servis.KullaniciBilgileriniGetir(int.Parse(Request.Cookies["KullaniciKimligi"].Value));

                return View();
            }
            return RedirectToAction("Anasayfa", "Home");
        }

        public ActionResult Sor()
        {
            if (Request.Cookies["KullaniciKimligi"] != null)
            {
                ViewBag.Title = "Soru Sor";
                ViewBag.Kullanici = servis.KullaniciBilgileriniGetir(int.Parse(Request.Cookies["KullaniciKimligi"].Value));

                return View();
            }
            return RedirectToAction("Anasayfa", "Home");
        }

        public ActionResult Soru(int id)
        {
            if (Request.Cookies["KullaniciKimligi"] != null)
            {
                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ViewBag.Soru = servis.SoruBilgileriniGetir(id);
                ViewBag.Sorucu = servis.KullaniciBilgileriniGetir(ViewBag.Soru.Soran_Kimlik);

                if (ViewBag.Soru == null)
                {
                    return HttpNotFound();
                }

                ViewBag.Title = "Soru";
                ViewBag.Kullanici = servis.KullaniciBilgileriniGetir(int.Parse(Request.Cookies["KullaniciKimligi"].Value));

                return View();
            }
            return RedirectToAction("Anasayfa", "Home");
        }

        public JsonResult KullaniciBilgileriniGuncelle(string isim, string soyisim, string eposta, string parola, string avatarLink)
        {
            bool durum = servis.KullaniciBilgileriniGuncelle(int.Parse(Request.Cookies["KullaniciKimligi"].Value), eposta, isim, soyisim, parola, avatarLink);

            if (durum)
            {
                return Json("Güncelleme başarılı.");
            }
            else
            {
                return Json("Güncelleme başarısız.");
            }
        }

        public JsonResult SoruSor(string baslik, string icerik)
        {
            bool durum = servis.SoruEkle(int.Parse(Request.Cookies["KullaniciKimligi"].Value), baslik, icerik);

            if (durum)
            {
                return Json("Soru ekleme başarılı.");
            }
            else
            {
                return Json("Soru ekleme başarısız.");
            }
        }
    }
}