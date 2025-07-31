using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoGYSD.ViewModels.Missa.Setups
{
    public class BankViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bank name is required.")]
        [StringLength(100, ErrorMessage = "Bank name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "Bank description cannot exceed 250 characters.")]
        public string BankDescription { get; set; }
    }
}
