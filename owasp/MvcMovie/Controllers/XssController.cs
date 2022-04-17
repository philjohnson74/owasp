using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnASPNETCoreMVC5.Controllers
{
    [Route("xss")]
    public class XssController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("textsubmitted")]
        [HttpPost]
        public IActionResult TextSubmitted(string inputtext)
        {
            HttpContext.Session.SetString("inputtext", inputtext);
            
            Response.Cookies.Append(
                "xssCookie",
                "Cookie value that hacker shouldn't be able to see!",
                new Microsoft.AspNetCore.Http.CookieOptions()
                {
                    Path = "/",
                    //HttpOnly = true,
                    //Secure = true
                }
            );
            
            return View("SubmittedText");
        }
    }
}