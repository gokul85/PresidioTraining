namespace RequestTrackerModelLibrary
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public override string ToString()
        {
            return Id + " " + Name + " " + Role;
        }
        public virtual bool PasswordCheck(string password)
        {
            return this.Password == password;
        }
        public virtual ICollection<Request> RequestsRaised { get; set; }
        public virtual ICollection<Request> RequestsClosed { get; set; }
        public virtual ICollection<RequestSolution> SolutionsProvided { get; set; }
        public virtual ICollection<SolutionFeedback> FeedbacksGiven { get; set; }

    }
}
