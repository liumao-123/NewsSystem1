using NewsSystem1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsSystem1.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            List<News> news = new NewsProvider().Select();
            return View(news);
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult CheckUser()
        {
            string usermane = Request["username"].ToString();
            string password = Request["password"].ToString();
            MemberProvider meme = new MemberProvider();
            var model = meme.Select().FirstOrDefault(t=>t.Name==usermane&&t.Password==password);
            if (model != null)
            {
                return Content("登陆成功");
            }
            else {
                return Content("登陆失败");
            }

        }

        public ActionResult DeleteNews(int id)
        {
            var prosi = new NewsProvider();
            var count = prosi.Select().FirstOrDefault(item =>item.Id ==id);
            if (count != null)
            {
                prosi.Delete(count);
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateNews(int id)
        {
            var prosi = new NewsProvider();
            var count = prosi.Select().FirstOrDefault(item => item.Id == id);
            if (count != null)
            {
                return View(count);
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateAction()
        {
            string id = Request["id"].ToString();
            string title = Request["title"].ToString();
            string desc = Request["desc"].ToString();
            if (id == null || int.TryParse(id, out int result) == false)
            {
                return Content("修改失败");
            }
            else if (string.IsNullOrEmpty(title) == true)
            {
                return Content("修改失败");
            }
            else if (string.IsNullOrEmpty(desc) == true)
            {
                return Content("修改失败");
            }

            var provider= new NewsProvider();
            var model = provider.Select().FirstOrDefault(t => t.Id == result);
            if (model != null)
            {
                model.Title = title;
                model.Text = desc;
                var count = provider.Update(model);
                if (count > 0)
                {
                    return Content("修改成功");
                }
            }
            else
            {
                return Content("修改失败");
            }
            return Content("登录失败");
        }

        public ActionResult AddNews()
        {
            return View();
        }
        public ActionResult AddNewsAction() 
        {
            string title = Request["title"].ToString();
            string desc = Request["desc"].ToString();
            if (string.IsNullOrEmpty(title) == true|| string.IsNullOrEmpty(desc) == true)
            {
                return Content("添加失败");
            }
            var model = new News();
            model.Title = title;
            model.Text = desc;
            model.InsertDate = DateTime.Now;
            model.MemberId = 1;
            model.MemberName = "admin";
            var cunt = new NewsProvider().insert(model);

                if (cunt > 0)
                {
                    return Content("添加成功");
                }
                else
                {
                    return Content("添加成功");
                }

        }
    }
}