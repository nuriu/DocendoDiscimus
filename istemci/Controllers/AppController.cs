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
                ViewBag.Cevaplar = servis.SorununCevaplariniGetir(id);
                ViewBag.FS = servis.SoruFavorilerdeMi(int.Parse(Request.Cookies["KullaniciKimligi"].Value), id);

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

        public JsonResult CevapVer(string soruKimligi, string cevap)
        {
            bool durum = servis.CevapEkle(int.Parse(soruKimligi), int.Parse(Request.Cookies["KullaniciKimligi"].Value), cevap);

            if (durum)
            {
                return Json("Cevap ekleme başarılı.");
            }
            else
            {
                return Json("Cevap ekleme başarısız.");
            }
        }

        public JsonResult Yorumla(string cevapKimligi, string yorum)
        {
            bool durum = servis.YorumEkle(int.Parse(cevapKimligi), int.Parse(Request.Cookies["KullaniciKimligi"].Value), yorum);

            if (durum)
            {
                return Json("Yorum ekleme başarılı.");
            }
            else
            {
                return Json("Yorum ekleme başarısız.");
            }
        }

        public JsonResult SoruyuFavorilereEkle(string soruKimligi)
        {
            bool durum = servis.SoruyuFavorilereEkle(int.Parse(Request.Cookies["KullaniciKimligi"].Value), int.Parse(soruKimligi));

            if (durum)
            {
                return Json("Soruyu ekleme başarılı.");
            }
            else
            {
                return Json("Soruyu ekleme başarısız.");
            }
        }

        public JsonResult SoruyuFavorilerdenCikar(string soruKimligi)
        {
            bool durum = servis.SoruyuFavorilerdenKaldir(int.Parse(Request.Cookies["KullaniciKimligi"].Value), int.Parse(soruKimligi));

            if (durum)
            {
                return Json("Soruyu cikarma başarılı.");
            }
            else
            {
                return Json("Soruyu cikarma başarısız.");
            }
        }
        public JsonResult CevabiFavorilereEkle(string cevapKimligi)
        {
            bool durum = servis.CevabiFavorilereEkle(int.Parse(Request.Cookies["KullaniciKimligi"].Value), int.Parse(cevapKimligi));

            if (durum)
            {
                return Json("Cevabi ekleme başarılı.");
            }
            else
            {
                return Json("Cevabi ekleme başarısız.");
            }
        }

        public JsonResult CevabiFavorilerdenCikar(string cevapKimligi)
        {
            bool durum = servis.CevabiFavorilerdenKaldir(int.Parse(Request.Cookies["KullaniciKimligi"].Value), int.Parse(cevapKimligi));

            if (durum)
            {
                return Json("Cevabi cikarma başarılı.");
            }
            else
            {
                return Json("Cevabi cikarma başarısız.");
            }
        }

        public JsonResult CevabiOnayla(string cevapKimligi)
        {
            bool durum = servis.CevabiOna(int.Parse(cevapKimligi));

            if (durum)
            {
                return Json("Cevabi onama başarılı.");
            }
            else
            {
                return Json("Cevabi onama başarısız.");
            }
        }

        public JsonResult CevabinOnayiniKaldir(string cevapKimligi)
        {

            bool durum = servis.CevapOnayiniKaldir(int.Parse(cevapKimligi));

            if (durum)
            {
                return Json("Cevabi cikarma başarılı.");
            }
            else
            {
                return Json("Cevabi cikarma başarısız.");
            }
        }
    }
}