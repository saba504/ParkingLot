using Microsoft.EntityFrameworkCore;
using ParkingLot;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new ParkingDbContext();

           

            //var car = context.Car.Include(b => b.CarAuthor).ThenInclude(ba => ba.Author).FirstOrDefault(d => d.Id == 2);
            //if (car != null)
            //{
            //    Console.WriteLine($"Car title: {car.Title}");
            //    foreach (var ba in car.CarAuthor)
            //    {
            //        Console.WriteLine($"Author name: {ba.Author.Name}");
            //    }
            //}

            

            var author = new Author { Name = "Saba Tiginashvili" };
            var car1 = new Car { Title = "KIA", CarAuthor = new List<CarAuthor> { new CarAuthor { Author = author } } };
            context.Car.Add(car1);
            context.SaveChanges();

        }
    }
}