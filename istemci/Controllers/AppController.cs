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
        public ActionResult Index(string kullanici_adi, string parola)
        {
            DDServiceClient servis = new DDServiceClient();

            bool durum = servis.KullaniciGirisiYap(kullanici_adi, parola);

            servis.Close();

            if (durum)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}