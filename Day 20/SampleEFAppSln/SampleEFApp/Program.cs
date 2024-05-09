using SampleEFApp.Model;

namespace SampleEFApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dbEmployeeTrackerContext context = new dbEmployeeTrackerContext();

            //Area area = new Area();
            //area.Area1 = "HYHY";
            //area.Zipcode = "4433";
            //context.Areas.Add(area);
            //context.SaveChanges();

            //var areas = context.Areas.ToList();
            //foreach (var area in areas)
            //{
            //    Console.WriteLine(area.Area1 + " " + area.Zipcode);
            //}


            var areas = context.Areas.ToList();
            var area = areas.SingleOrDefault(a => a.Area1 == "TTTT");
            area.Zipcode = "00000";
            context.Areas.Update(area);
            context.SaveChanges();

            area = areas.SingleOrDefault(a => a.Area1 == "HYHY");
            context.Areas.Remove(area);
            context.SaveChanges();
            foreach (var a in areas)
            {
                Console.WriteLine(a.Area1 + " " + a.Zipcode);
            }
        }
    }
    //C1RBBX3\SQLEXPRESS

    //Data Source=;Integrated Security=true;Initial Catalog=dbEmployeeTracker

    //Scaffold-DbContext "Data Source=C1RBBX3\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbEmployeeTracker" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model
}
