using System.Web.Mvc;
using İstemci.DDService;

namespace İstemci.Controllers
{
    public class AppController : Controller
    {
        public ActionResult Index()
        {
            DDServiceClient servis = new DDServiceClient();
            ViewBag.Data = servis.GetData(8);
            return View();
        }
    }
}