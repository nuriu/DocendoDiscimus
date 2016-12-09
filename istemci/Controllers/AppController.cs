using System.Web.Mvc;
using İstemci.DDService;

namespace İstemci.Controllers
{
    public class AppController : Controller
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

            bool a = servis.KullaniciKayitEt(kayit_eposta, kayit_kullanici_adi, kayit_parola);

            servis.Close();

            return View();
        }
    }
}