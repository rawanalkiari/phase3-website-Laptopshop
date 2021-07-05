using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project_phase3Claptopshop.Models;


namespace project_phase3Claptopshop.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult AddOrEdit(int id =0)
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public ActionResult AddOrEdit(User user)
        {
            using  (UserDBEntities1 db=new UserDBEntities1())
            {
                if (db.User.Any(x => x.UserName == user.UserName))
                {
                    ViewBag.DuplicateMessage = "User Name Already Exist.";
                    return View("AddOrEdit", user);
                }
                else
                {
                    db.User.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.SuccessMessage = "saved successfuly.";
                return View("AddOrEdit", new User());
            }
        }
    }
}