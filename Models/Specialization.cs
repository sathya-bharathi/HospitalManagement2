namespace HospitalManagement.Models
{
    public partial class Specialization
    {
        public Specialization()
        {
            DoctorRegistrations = new HashSet<DoctorRegistration>();
        }

        public int SpecializationId { get; set; }
        public string? SpecilizationName { get; set; }

        public virtual ICollection<DoctorRegistration> DoctorRegistrations { get; set; }
    }
}
