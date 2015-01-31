using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatTestTask.Data;
using ChatTestTask.Data.Entities;

namespace ChatTestTask.Controllers
{
    public class HomeController : Controller
    {
        private const string DefaultChatName = "TestChat";

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Chat()
        {
            ViewBag.Message = "Your chat page.";

            // Create default chat
            using (var uow = new UnitOfWork())
            {
                if (uow.ChatRepository.GetList().FirstOrDefault(c => c.Name.Equals(DefaultChatName)) == null)
                {
                    uow.ChatRepository.Add(new Chat { Name = DefaultChatName });
                    uow.Commit();
                }
            }

            return View();
        }
    }
}
