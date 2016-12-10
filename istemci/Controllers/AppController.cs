using System.Web.Mvc;
using İstemci.DDService;

namespace İstemci.Controllers
{
    public class AppController : Controller
    {
        public ActionResult Index()
        {
            if (Request.Cookies["KullaniciKimligi"] != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}