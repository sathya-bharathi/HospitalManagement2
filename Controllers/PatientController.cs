using HospitalManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalManagement.Controllers
{
    public class PatientController : Controller
    {
        private readonly HMContext _context;

        public PatientController(HMContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AppointmentSelectDoctor()
        {
            var DoctorList = new SelectList(from i in _context.DoctorRegistrations
                                            select i.DoctorName).ToList();
            ViewBag.DoctorName = DoctorList;

            return View();
        }
        [HttpPost]
        public IActionResult AppointmentSelectDoctor(AppointmentBooking a)
        {
            DoctorRegistration doctor = (from i in _context.DoctorRegistrations.Where(d => d.DoctorName == a.DoctorName) select i).SingleOrDefault();
            List<string> AvailableSlots = new();
            IEnumerable<string> enumerable = AvailableSlots;
            DateTime starttime = (DateTime)doctor.StartTime;
            DateTime endtime = (DateTime)doctor.EndTime;
            while (starttime < endtime)
            {
                DateTime timeinterval1, timeinterval2;
                timeinterval1 = starttime;

                starttime = starttime.AddMinutes(30);

                timeinterval2 = starttime;

                if (starttime < endtime)
                {
                    AvailableSlots.Add(timeinterval1.ToString("hh.mm") + " to " + timeinterval2.ToString("hh.mm"));
                }
                else
                {
                    AvailableSlots.Add(timeinterval1.ToString("hh.mm") + " to " + endtime.ToString("hh.mm"));
                }

            }
            ViewBag.AvailableSlots = enumerable;

            return View();
        }

    }
}
