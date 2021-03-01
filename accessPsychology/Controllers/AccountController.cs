using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using accessPsychology.Models;
using Model;
using BLL;

namespace accessPsychology.Controllers
{
    public class AccountController : Controller
    {
        LinxinaccessEntities db = new LinxinaccessEntities();
        UserManager userManager = new UserManager();
        // GET: Account
        public ActionResult LogOff()
        {
            Session["UserName"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewBag.judgeVerificationCode = "true";
            ViewBag.judgeUser = "false";
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string ValidateCode = Request["ValidateCode"];
                if (ValidateCode != Session["CAPTCHA_Contact"].ToString())
                {
                    return Content("<script>alert('验证码输入错误,请重新输入!')</script>");            
                }
                LinxinaccessEntities db = new LinxinaccessEntities();
                var chk_name = userManager.GetUsersByName(model.user_name);
                Users user = new Users();
                if (chk_name != null)
                {
                    return Content("<script>alert('用户已存在!')</script>");
                }
                try
                {
                    if (file != null)
                    {
                        string filePath = file.FileName;
                        string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                        string serverpath = Server.MapPath(@"\images\users\") + filename;
                        string relativepath = @"/images/users/" + filename;
                        file.SaveAs(serverpath);
                        user.head_img = relativepath;
                    }
                    else
                    {
                        return Content("<script>;alert('请先上传图片！');history.go(-1)</script>");
                    }
                    user.user_name = model.user_name;
                    user.password = model.Password;
                    user.sex = model.sex;
                    user.user_type = model.identity;
                    user.tel_phone = model.tel_phone;
                    user.introduce = model.introduce;
                    user.creat_time = DateTime.Now.ToString();
                    userManager.AddUser(user);
                    return Content("<script>;alert('注册成功！');history.go(-1)</script>");
                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users user,string returnurl)
        {
            string ValidateCode = Request["txtVerifcode1"];
            if (ValidateCode != Session["CAPTCHA_Contact"].ToString())
            {
                return Content("<script>;alert('验证码错误！');history.go(-1)</script>");
            }
            try
            {
                var users = db.Users.Where(o => o.user_name == user.user_name).FirstOrDefault();
                if (users != null)
                {
/*                    if (users.password != user.password)
                    {
                        return Content("<script>;alert('密码错误，请从新输入！');history.go(-1)</script>");
                    }*/
                    HttpContext.Session["User_id"] = users.id;
                    HttpContext.Session["UserName"] = users.user_name;
                    HttpContext.Session["UserPhoto"] = users.head_img;

                    return Content("<script>;alert('登录成功!返回首页!');window.location.href='/Home/Index'</script>");
                }else
                {
                    return Content("<script>;alert('该账号不存在!');history.go(-1)</script>");
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login1()
        {
            string user_name = Request["user_name1"];
            string password = Request["password1"];
            string identity = Request["identity1"];
            if (user_name == null)
            {
                return Content("<script>;alert('用户名不能为空!');history.go(-1)</script>");
            }
            if (password == null)
            {
                return Content("<script>;alert('密码不能为空!');history.go(-1)</script>");
            }
            if (identity == null)
            {
                return Content("<script>;alert('验证码不能为空!');history.go(-1)</script>");
            }
            if(identity != Session["CAPTCHA_Contact"].ToString())
            {
                return Content("<script>;alert('验证码错误！');history.go(-1)</script>");
            }
            try
            {
                var users = db.Users.Where(o => o.user_name == user_name).FirstOrDefault();
                if (users != null)
                {
                    if (users.password.ToString().Trim() != password)
                    {
                        return Content("<script>;alert('密码错误，请从新输入！');history.go(-1)</script>");
                    }
                    HttpContext.Session["User_id"] = users.id;
                    HttpContext.Session["UserName"] = users.user_name;
                    HttpContext.Session["UserPhoto"] = users.head_img;

                    return Content("<script>;alert('登录成功!返回首页!');window.location.href='/Home/Index'</script>");
                }
                else
                {
                    return Content("<script>;alert('该账号不存在!');history.go(-1)</script>");
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}