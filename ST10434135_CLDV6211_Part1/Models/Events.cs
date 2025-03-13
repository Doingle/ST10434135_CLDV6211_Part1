using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ST10434135_CLDV6211_Part1.Models
{
    public class Events
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventID { get; set; }

        public string EventName { get; set; }

        public DateTime EventDate { get; set; } // Changed to DateTime for better type safety

        public string Description { get; set; }

        public int VenueID { get; set; }


    }
}
