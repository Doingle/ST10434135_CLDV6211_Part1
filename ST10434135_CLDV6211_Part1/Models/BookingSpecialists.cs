using System.ComponentModel.DataAnnotations;

namespace ST10434135_CLDV6211_Part1.Models
{
    public class BookingSpecialists
    {

        [Key]
        public int SpecialistID { get; set; }

        public string SpecialistName { get; set; }

        public string SpecialistEmail { get; set; }

        public string SpecialistPhoneNumber { get; set; }

    }
}
