using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoGYSD.Business.Views.Missa.Setups
{
    public class GradeView
    {
        public int Id { get; set; }
        public string Code { get; set; }       
        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedByName { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedByName { get; set; }
    }
}
