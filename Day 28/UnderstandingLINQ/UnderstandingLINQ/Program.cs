using UnderstandingLINQ.Model;

namespace UnderstandingLINQ
{
    internal class Program
    {
        void PrintTitlesBasedOnSales()
        {
            pubsContext context = new pubsContext();
            var sales = context.Sales.GroupBy(s => s.TitleId).Select(g => new
            {
                TitleId = g.Key,
                Sales = g.Select(s => new {s.Qty, s.OrdNum})
            });
            foreach (var item in sales)
            {
                Console.WriteLine($"TitleId: {item.TitleId}");
                foreach (var sale in item.Sales)
                {
                    Console.WriteLine($"  Quantity: {sale.Qty}, Order ID: {sale.OrdNum}");
                }
            }
        }
        void PrintTheBooksPulisherwise()
        {
            pubsContext context = new pubsContext();
            var books = context.Titles
                        .GroupBy(t => t.PubId, t => t, (pid, title) => new { Key = pid, TitleCount = title.Count(), TitleNames = title.ToList() });

            foreach (var book in books)
            {
                Console.Write(book.Key);
                Console.WriteLine(" - " + book.TitleCount);
                Console.WriteLine("BookNames");
                foreach (var title in book.TitleNames)
                {
                    Console.WriteLine(title.Title1);
                }
            }
        }
        //void PrintTheBooksPulisherwise()
        //{
        //    pubsContext context = new pubsContext();
        //    var books = context.Titles
        //                .GroupBy(t => t.PubId)
        //                .Select(t => new {
        //                    PublisherId = t.Key,
        //                    TitleCount = t.Count(),
        //                    Titles = t.Select(t => new
        //                    {
        //                        BookName = t.Title1,
        //                        BookPrice = t.Price
        //                    })
        //                });

        //    foreach (var book in books)
        //    {
        //        Console.Write(book.PublisherId);
        //        Console.WriteLine(" - " + book.TitleCount);
        //        foreach (var title in book.Titles)
        //        {
        //            Console.WriteLine("\t"+ title.BookName+" "+title.BookPrice);
        //        }
        //    }
        //}
        void PrintNumberOfBooksFromType(string type)
        {
            pubsContext context = new pubsContext();
            var bookCount = context.Titles.Where(t => t.Type == type).Count();
            Console.WriteLine($"There are {bookCount} in the type {type}");
        }
        void PrintAuthorNames()
        {
            pubsContext context = new pubsContext();
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine(author.AuFname + " " + author.AuLname);
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            //program.PrintAuthorNames();
            //program.PrintNumberOfBooksFromType("mod_cook");
            //program.PrintTheBooksPulisherwise();
            program.PrintTitlesBasedOnSales();
        }
    }
}
