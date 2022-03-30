using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PaymentAPI.Controllers
{
    [ApiController]
    [Route("/")]

    
    public class BiodataController : ControllerBase
    {   

        public class BiodataDetails
        {
            public string nama {get;set;}
            public string kodePeserta {get;set;}
            public string linkGithub {get;set;}

        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("[controller]")]
        [HttpGet]
        public ActionResult GetBiodata (){

            BiodataDetails res = new BiodataDetails{
                nama = "Deah Nisa Azizah",
                kodePeserta = "FSDO003ONL003",
                linkGithub = "https://github.com/DN-98/ocbc_csharp_batch3.git"
            };
            
            return Ok(res);
        }
    }
}