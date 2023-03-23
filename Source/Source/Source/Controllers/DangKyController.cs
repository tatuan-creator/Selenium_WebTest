using Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Source.Controllers
{
    public class DangKyController : Controller
    {
        private dataDataContext context = new dataDataContext();
        // GET: DangKy
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
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
        public bool hasUpperCase(string str)
        {
            return str.Any(p => char.IsUpper(p));
        }
        public bool IsNumber(char pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*.?[0-9]+$");
            return regex.IsMatch(pText.ToString());
        }
        public int DemSo(string str)
        {
            int temp = 0;
            foreach(char x in str)
            {
                if(IsNumber(x)) temp++;
            }
            return temp;
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection Dangky)
        {
            string tk = Dangky["User"].ToString().Trim();
            string mk = Dangky["Pass"].ToString().Trim();
            string pn = Dangky["PhoneNumber"].ToString().Trim();
            if (tk == "")
            {
                ViewBag.Fail = "Tên đăng nhập trống";
                return View("DangKy");
            }
            else if (!isEmail(tk))
            {
                ViewBag.Fail = "Định dạng tên đăng nhập không hợp lệ";
                return View("DangKy");
            }
            else if (mk == "")
            {
                ViewBag.Fail = "Mật khẩu trống";
                return View("DangKy");
            }
            else if(mk.Length <8)
            {
                ViewBag.Fail = "Mật khẩu phải đủ 8 ký tự";
                return View("DangKy");
            }
            else if (!hasUpperCase(mk) || DemSo(mk) == 0 || DemSo(mk) == mk.Length)
            {
                ViewBag.Fail = "Mật khẩu phải có chữ hoa và chữ thường và số";
                return View("DangKy");
            }
            else if (IsNumber(mk[0]))
            {
                ViewBag.Fail = "Mật khẩu không bắt đầu bằng số";
                return View("DangKy");
            }
            else if(pn == "")
            {
                ViewBag.Fail = "Số điện thoại không được để trống";
                return View("DangKy");
            }
            else if (pn.Length != 10)
            {
                ViewBag.Fail = "Số điện thoại phải 10 chữ số";
                return View("DangKy");
            }
            else if (DemSo(pn) != pn.Length)
            {
                ViewBag.Fail = "Số điện thoại chỉ được điền số từ 0 tới 9";
                return View("DangKy");
            }

            var check = context.TKs.SingleOrDefault(p => p.User.Equals(tk));

            if (check != null)
            {
                ViewBag.Fail = "Tài khoản đã tồn tại, vui lòng chọn tài khoản khác";
                return View("DangKy");
            }
            else
            {
                TK taikhoan = new TK();
                taikhoan.User= tk;
                taikhoan.Pass = mk;
                taikhoan.PhoneNumber = pn;
                taikhoan.IsAllow = 1;

                context.TKs.InsertOnSubmit(taikhoan);
                context.SubmitChanges();
            }

            ViewBag.Success = "Đăng ký thành công";
            return View("DangKy");
        }
    }
}