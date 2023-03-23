using Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Source.Controllers
{
    public class LogInController : Controller
    {
        private dataDataContext context = new dataDataContext();
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        public static bool isEmail(string inputEmail)
        {
            inputEmail = inputEmail ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection Dangnhap)
        {
            string tk = Dangnhap["User"].ToString();
            string mk = Dangnhap["Pass"].ToString();
            if(tk == "")
            {
                ViewBag.Fail = "Tên đăng nhập trống";
                return View("Dangnhap");
            }
            else if (!isEmail(tk))
            {
                ViewBag.Fail = "Định dạng tên đăng nhập không hợp lệ";
                return View("Dangnhap");
            }
            else if (mk == "")
            {
                ViewBag.Fail = "Mật khẩu trống";
                return View("Dangnhap");
            }

            var check = context.TKs.SingleOrDefault(p => p.User.Equals(tk));

            if(check == null)
            {
                ViewBag.Fail = "Tài khoản không tồn tại";
                return View("Dangnhap");
            }
            else if (!check.Pass.Equals(mk))
            {
                ViewBag.Fail = "Mật khẩu sai";
                return View("Dangnhap");
            }
            else if (check.IsAllow == 0)
            {
                ViewBag.Fail = "Tài khoản bị vô hiệu hóa";
                return View("Dangnhap");
            }

            ViewBag.Success = "Đăng nhập thành công";
            return View("Dangnhap");
        }
    }
}