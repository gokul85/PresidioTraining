namespace GovtRuleLib
{
    public class Company
    {
        public int EmpId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department {  get; set; } = string.Empty;
        public string Designation { get ; set; } = string.Empty;
        public double BasicSalary { get; set; }
        public string Type { get; set; }

        public int ServiceCompleted;
        public DateTime doj;
        public DateTime DOJ
        {
            get => doj;
            set
            {
                doj = value;
                ServiceCompleted = ((DateTime.Today - doj).Days) / 365;
            }
        }
        public Company() { }
        public Company(int id, string name, string dept, string desg, double basicSalary, DateTime doj)
        {
            Console.WriteLine("Employee class prameterized constructor");
            EmpId = id;
            Name = name;
            Department = dept;
            Designation = desg;
            BasicSalary = basicSalary;
            DOJ = doj;
        }
    }
}
