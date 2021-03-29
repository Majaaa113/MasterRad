using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterRadMM.Models
{
    public class Courier
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required] public string Firstname { get; set; }
        [Required] public string Lastname { get; set; }
    }
}
