using DBClassLib.GenericRepositoryClasses;
using System.Linq;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult Index()
        {
            var model = unitOfWork.ProductRepository.ReadRecords();

            return View(model.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}