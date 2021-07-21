using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITCREWS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITCREWS.Controllers
{
    public class LoginController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(string url)
        {
            ViewBag.RedirectURL = url;

            return View();
        }

        public IActionResult Join(string url)
        {
            ViewBag.RedirectURL = url;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckLogin(string url, LoginModel lm)
        {
            //if 만약 로그인 성공시
            return Redirect(url);
        }

        [HttpPost]
        public async Task<IActionResult> Join(string url, LoginModel lm)
        {
            //if 만약 로그인 성공시
            return Redirect(url);
        }
    }
}
