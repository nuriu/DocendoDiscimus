using System.Web.Mvc;
using İstemci.DDService;

namespace İstemci.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DDServiceClient servis = new DDServiceClient();
            ViewBag.Data = servis.GetData(8);
            return View();
        }
    }
}