﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanQuanAo.Models;
using System.Data.SqlClient;
using System.Net.Mail;

namespace WebBanQuanAo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        BanQuanAoEntities2 db = new BanQuanAoEntities2();
        public ActionResult Index()
        {
            //tạo ra các Viewbag để load ra sản phẩm
            // tạo list đồng hồ mới
            var lstQAM = db.SanPhams.Where(n => n.IdLoaiSanPham == 1 && n.DaXoa == false).ToList().OrderBy(n => n.DonGia);
            //gán vào viewbang
            ViewBag.lstQAM = lstQAM;
            // list trang sức mới
            var lstMPM = db.SanPhams.Where(n => n.IdLoaiSanPham == 2 && n.DaXoa == false).ToList().OrderBy(n => n.DonGia);
            //gán vào viewbang
            ViewBag.lstMPM = lstMPM;
            // list trang sức mới
            var lstPKM = db.SanPhams.Where(n => n.IdLoaiSanPham == 3 && n.DaXoa == false).ToList().OrderBy(n => n.DonGia);
            //gán vào viewbang
            ViewBag.lstPKM = lstPKM;
            return View();
        }
        public ActionResult MenuPartial()
        {
            // truy vấn list sản phẩm
            var lstSanPham = db.SanPhams;
            return PartialView(lstSanPham);
        }
        public ActionResult LienHe()
        {
            ViewBag.Success = false;
            return View(new LienHe());
        }
        [HttpPost]
        public ActionResult LienHe(LienHe contact)
        {
            ViewBag.Success = false;
            if (ModelState.IsValid)
            {
                // Collect additional data
                contact.SentDate = DateTime.Now;
                contact.IP = Request.UserHostAddress;


                SmtpClient smtpClient = new SmtpClient();
                smtpClient.EnableSsl = true;
                MailMessage m = new MailMessage(
                    "traitimcuagiotv19@gmail.com", // From
                    "nhutthanh.nina@gmail.com", // To
                    "Someone is contacting you through your website!", // Subject
                    contact.BuildMessage()); // Body
                ViewBag.Success = true;
                smtpClient.Send(m);
            }

            return View();
        }
	}
}