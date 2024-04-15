namespace DoctorClass.Models
{
    class Doctor
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Exp { get; set; }
        public string Qualification { get; set; }
        public string Speciality { get; set; }

        public Doctor(int id)
        {
            Id = id;
        }

        public Doctor()
        {
            Id = 0;
            Name = string.Empty;
            Age = 0;
            Exp = 0;
            Qualification = string.Empty;
            Speciality = string.Empty;

        }

        public Doctor(int id, string name, int age, int exp, string qualification, string speciality)
        {
            Id = id;
            Name = name;
            Age = age;
            Exp = exp;
            Qualification = qualification;
            Speciality = speciality;
        }

        public void PrintDoctorDetails()
        {
            Console.WriteLine($"Doctor Id\t:\t{Id}");
            Console.WriteLine($"Doctor name\t:\t{Name}");
            Console.WriteLine($"Doctor age\t:\t{Age}");
            Console.WriteLine($"Doctor Experience\t:\t{Exp}");
            Console.WriteLine($"Doctor Qualification\t:\t{Qualification}");
            Console.WriteLine($"Doctor Speciality\t:\t{Speciality}");
        }
    }

}

