using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Models
{
    public partial class AppointmentBooking
    {
        public int AppointmentId { get; set; }
        public string? DoctorId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? AppointmentDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime? AppointmentTime { get; set; }
        [NotMapped]
        public string? DoctorName { get; set; }
        public virtual DoctorRegistration? Doctor { get; set; }
    }
}
