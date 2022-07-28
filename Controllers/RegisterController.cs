using HospitalManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    public class RegisterController : Controller
    {
        private readonly HMContext _context;

        public RegisterController(HMContext context)
        {
            _context = context;
        }

        public IActionResult PatientRegistration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PatientRegistration(PatientRegistration obj)
        {
            _context.PatientRegistrations.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Patient", "Login");
        }
    }
}
