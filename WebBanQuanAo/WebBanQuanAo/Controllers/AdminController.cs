

namespace WebBanQuanAo.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        BanQuanAoEntities2 db = new BanQuanAoEntities2();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult XemChiTiet()
        {
            return View(db.KhachHangs.OrderBy(n => n.IdKH));
        }
        [HttpPost]
        public ActionResult LoginAdmin(FormCollection collection)
        {
            string TaiKhoan = collection["txtUser"].ToString();
            string MatKhau = collection["txtPass"].ToString();
            ThanhVien thanhvien = db.ThanhViens.SingleOrDefault(n => n.TaiKhoan == TaiKhoan && n.MatKhau == MatKhau);
            if (thanhvien != null)
            {
                Session["user"] = thanhvien;
                return RedirectToAction("XemChiTiet");

            }
            return Content("Tài khoản hoặc mật khẩu không đúng!");
        }
	}
}
