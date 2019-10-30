<<<<<<< Updated upstream
﻿da sua

=======
﻿
>>>>>>> Stashed changes

namespace WebBanQuanAo.Controllers
{
    public class TinTucController : Controller
    {
        //
        // GET: /TinTuc/
        BanQuanAoEntities2 db = new BanQuanAoEntities2();
        public ActionResult Index()
        {
            return View("TinTuc", db.TinTucs.OrderBy(n => n.IdTinTuc));
        }
        public ActionResult TinTuc(int? id)
        {
            return View(db.TinTucs.Where(n => n.IdTinTuc == id));
        }
        public ActionResult NoiDung(int? id)
        {
            return View(db.TinTucs.SingleOrDefault(n => n.IdTinTuc == id));
        }
	}
}