using HospitalManagement.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HospitalManagement.Controllers
{
    public class LoginController : Controller
    {
        private readonly HMContext db;
        //private readonly ISession session;

        public LoginController(HMContext _db /*IHttpContextAccessor httpContextAccessor*/)
        {
            db = _db;
            //session = httpContextAccessor.HttpContext.Session;
        }

        #region AUTOREDIRECT
        public class NoDirectAccessAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var canAcess = false;

                // check the refer
                var referer = filterContext.HttpContext.Request.Headers["Referer"].ToString();
                if (!string.IsNullOrEmpty(referer))
                {
                    var rUri = new System.UriBuilder(referer).Uri;
                    var req = filterContext.HttpContext.Request;
                    if (req.Host.Host == rUri.Host && req.Host.Port == rUri.Port && req.Scheme == rUri.Scheme)
                    {
                        canAcess = true;
                    }
                }

                // ... check other requirements

                if (!canAcess)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index", area = "" }));
                }
            }
        }
        #endregion


        public IActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Admin(Admin r)
        {


            var result = (from i in db.Admins
                          where i.EmailId == r.EmailId && i.Password == r.Password
                          select i).SingleOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("EmailId", result.EmailId);
                return RedirectToAction("Index", "Admin");
            }
            else
                return View();

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Patient()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Patient(PatientRegistration r)
        {
            var result = (from i in db.PatientRegistrations
                          where i.EmailId == r.EmailId && i.Password == r.Password
                          select i).SingleOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("EmailId", result.EmailId);
                return RedirectToAction("Index", "Patient");
            }
            else
                return View();

        }
        public IActionResult PLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Patient", "Login");
        }

        public IActionResult Doctor()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Doctor(DoctorRegistration r)
        {
            var result = (from i in db.DoctorRegistrations
                          where i.EmailId == r.EmailId && i.Password == r.Password
                          select i).SingleOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("EmailId", result.EmailId);
                return RedirectToAction("Index", "Doctor");
            }
            else
                return View();

        }
        public IActionResult DLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Doctor", "Login");
        }
    }
}
