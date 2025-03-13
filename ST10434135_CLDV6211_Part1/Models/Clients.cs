using System.ComponentModel.DataAnnotations;

namespace ST10434135_CLDV6211_Part1.Models
{
    public class Clients
    {

        [Key]
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhoneNumber { get; set; }


    }
}
