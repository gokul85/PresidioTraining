namespace EmployeeRequestTrackerAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string? Role { get; set; }

        public virtual ICollection<Request> RequestsRaised { get; set; }
        public virtual ICollection<Request> RequestsClosed { get; set; }
        public virtual ICollection<RequestSolution> SolutionsProvided { get; set; }
        public virtual ICollection<SolutionFeedback> FeedbacksGiven { get; set; }
    }
}
