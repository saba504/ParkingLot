using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    internal class ParkingLot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }

    internal class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
    }

    public class Car
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CarNumber { get; set; }
        public ICollection<CarAuthor> CarAuthor { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CarAuthor> CarAuthor { get; set; }
    }

    public class CarAuthor
    {
        public int BookId { get; set; }
        public Car Car { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }

}
