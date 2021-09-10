using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnASPNETCoreMVC5.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View();
        }
        
        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }
        
        [Route("login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            /*
            if (Cutoff())
            {
                return View("TooManyInvalidLoginAttempts");
            }
            */
            
            if (username != null && password != null && username.Equals("phil") && password.Equals("Password1!"))
            {
                //ClearBackoff();

                HttpContext.Session.SetString("username", username);
                return View("Success");
            }
            else
            {
                //Backoff();

                ViewBag.error = "Invalid Account";
                return View("Index");
            }
        }

        private void ClearBackoff()
        {
            HttpContext.Session.SetString("backoff", "0");
        }

        private void Backoff()
        {
            int backoff = 25;
            if (HttpContext.Session.GetInt32("backoff") != null)
            {
                backoff = (int) HttpContext.Session.GetInt32("backoff");
                Console.WriteLine($"backoff={backoff}");
            }

            bool delayed = Delay(backoff).Result;

            HttpContext.Session.SetInt32("backoff", backoff * 2);
        }

        async Task<bool> Delay(int milliseconds)
        {
            await Task.Delay(milliseconds);
            return true;
        }
        
        private bool Cutoff()
        {
            if (HttpContext.Session.GetInt32("backoff") != null)
            {
                int backoff = (int) HttpContext.Session.GetInt32("backoff");
                if (backoff > 500)
                {
                    return true;
                }
            }

            return false;
        }
    }
}