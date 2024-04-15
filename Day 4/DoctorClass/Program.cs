using System.Numerics;
using DoctorClass.Models;

namespace DoctorClass
{
    class Program
    {

        Doctor CreateDoctorsByTakingInputFromConsole(int id,int n)
        {
            Doctor doctor = new Doctor(id);

            Console.WriteLine($"Please enter the {n+1} Doctor name");
            doctor.Name = Console.ReadLine();

            Console.WriteLine("Please enter the Doctor Age");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid entry. Please try again.");
            }
            doctor.Age = age;

            Console.WriteLine("Please enter the Doctor Experience");
            int exp;
            while (!int.TryParse(Console.ReadLine(), out exp))
            {
                Console.WriteLine("Invalid entry. Please try again.");
            }
            doctor.Exp = exp;

            Console.WriteLine("Please enter the Doctor Qualification");
            doctor.Qualification = Console.ReadLine();

            Console.WriteLine("Please enter the Doctor Speciality");
            doctor.Speciality = Console.ReadLine();

            return doctor;
        }
        static void Main(string[] args)
        {

            Program program = new Program();
            Doctor[] doctors = new Doctor[3];
            for (int i = 0; i < doctors.Length; i++)
            {

                doctors[i] = program.CreateDoctorsByTakingInputFromConsole(301 + i,i);
            }

            for (int i = 0; i < doctors.Length; i++)
            {
                doctors[i].PrintDoctorDetails();
            }

            Console.WriteLine("Please Give the speciality to print the doctor details");
            string specialityInputFromConsole= Console.ReadLine();

            for(int i = 0; i < doctors.Length; i++)
            {
               if (doctors[i].Speciality == specialityInputFromConsole)
              {
                 doctors[i].PrintDoctorDetails();
             }
            }

            Console.WriteLine("Please enter the 16 digit card numbers");
            long cardNumber;
            while (!long.TryParse(Console.ReadLine(), out cardNumber))
            {
                Console.WriteLine("Invalid entry. Please try again.");
            }

            CardProblem cardProblem = new CardProblem();
            Console.WriteLine(cardProblem.IsValid(cardNumber));

        }
    }
}