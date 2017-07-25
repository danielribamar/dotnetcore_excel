using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using VolvoCleaner.Web.Frontend.Business;

namespace VolvoCleaner.Web.Frontend.Controllers
{
    public class PersonalizationController : Controller
    {
        [Route("personalization")]
        public async Task<IActionResult> Index()
        {
            var files = await FilesManager.Get();
            var type = FileTypesManager.Get(p => p.Name.Equals("personalization")).SingleOrDefault();
            return View(files.Where(p => p.TypeId == type.Id).OrderByDescending(p=>p.CreatedDate).ToList());
        }


        [Route("/upload")]
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }
    }
}