using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MasterRadMM.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required] public string Firstname { get; set; }
        [Required] public string Lastname { get; set; }
        [Required] public int PostalCode { get; set; }
        [Required] public string City { get; set; }
        [Required] public string Country { get; set; }
        [Required] public string Street { get; set; }
        [Required] public string AccountNo { get; set; }
        [Required] public string IdentityCard { get; set; }
        [Required] public double Available { get; set; }
    }
}
