using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Example.BLL;
using Example.Model;

namespace Example.Web.Controllers
{
    public class IndexController : Controller
    {
        private SysUserBLL _BLL = null;
         public SysUserBLL BLL
        {
            get
            {
                if (_BLL == null) _BLL = new SysUserBLL();
                return _BLL;
            }
        }

        // GET: Index
        public ActionResult Index()
        {
            ViewBag.FirstUser = BLL.GetUserById(1);
            return View();
        }
    }
}
