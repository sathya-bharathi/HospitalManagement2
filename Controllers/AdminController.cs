using HospitalManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Net.Mail;

namespace HospitalManagement.Controllers
{
    public class AdminController : Controller
    {
        private readonly HMContext _context;

        public AdminController(HMContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DoctorRegistration()
        {
            var result = new SelectList(from i in _context.Specializations
                                        select i.SpecializationId).ToList();
            ViewBag.SpecializationId = result;
            var res = new SelectList(from i in _context.Specializations
                                     select i.SpecilizationName).ToList();
            ViewBag.SpecilizationName = res;

            return View();
        }

        [HttpPost]
        public IActionResult DoctorRegistration(DoctorRegistration obj)
        {
            _context.DoctorRegistrations.Add(obj);
            _context.SaveChanges();

            var senderEmail = new MailAddress("librarymanagement13@gmail.com", "Sathya");
            var receiverEmail = new MailAddress(obj.EmailId, "Receiver");
            var password = "kigksgbmzemtqrax";
            var sub = "Hello" + obj.DoctorName + "Request Quote";
            var body = "Hello" + obj.DoctorName + " Your User Id is " + obj.EmailId + " Your Password is " + obj.Password + " Use these Credentials to Login";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using (var mess = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = sub,
                Body = body
            })
            {
                smtp.Send(mess);
            }

            return RedirectToAction("Index", "Admin");
        }
    }
}
