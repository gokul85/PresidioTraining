using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerAPI.Models
{
    public class SolutionFeedback
    {
        public int FeedbackId { get; set; }
        public float Rating { get; set; }
        public string? Remarks { get; set; }
        public int SolutionId { get; set; }
        public virtual RequestSolution Solution { get; set; }
        public int FeedbackBy { get; set; }
        public virtual Employee FeedbackByEmployee { get; set; }
        public DateTime FeedbackDate { get; set; }
    }
}
