using System.Web.Mvc;
using İstemci.DDService;

namespace İstemci.Controllers
{
    public class AppController : Controller
    {
        public ActionResult Anasayfa()
        {
            if (Request.Cookies["KullaniciKimligi"] != null)
            {
                return View();
            }
            return RedirectToAction("Anasayfa", "Home");
        }

        public ActionResult Profil()
        {
            if (Request.Cookies["KullaniciKimligi"] != null)
            {
                return View();
            }
            return RedirectToAction("Anasayfa", "Home");
        }
    }
}