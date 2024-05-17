using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerAPI.Models
{
    public class Request
    {
        [Key]
        public int RequestNumber { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; } = System.DateTime.Now;
        public DateTime? ClosedDate { get; set; } = null;
        public string RequestStatus { get; set; }


        public int RequestRaisedBy { get; set; }

        public virtual Employee RaisedByEmployee { get; set; }

        public int? RequestClosedBy { get; set; }


        public virtual Employee RequestClosedByEmployee { get; set; }

        public virtual ICollection<RequestSolution> RequestSolutions { get; set; }
    }
}
