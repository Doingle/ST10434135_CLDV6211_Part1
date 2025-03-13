using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ST10434135_CLDV6211_Part1.Models
{
    public class Bookings
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingID { get; set; }

        public int EventID { get; set; }

        public int VenueID { get; set; }

        public DateTime BookingDate { get; set; } // Changed to DateTime for better type safety

        public int SpecialistID { get; set; } // Changed to int for consistency

    }
}
