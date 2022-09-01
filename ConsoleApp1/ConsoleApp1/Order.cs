using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bebric
{
    public class Order
    {
        public readonly int Id;
        public double Price { get; private set; }
        public string Destinaion { get; private set; }
        public DateTime DateTime { get; private set; }
        public int Duration { get; private set; }
        public int CarId { get; private set; }
        public int UserId { get; private set; }
        public Order(int id, DateTime dateTime, string destinaion, int duration , double price, int carId, int userId)
        {
            Id = id;
            DateTime = dateTime;
            Destinaion = destinaion;
            Duration = duration;
            Price = price;
            CarId = carId;
            UserId = userId;
        }
    }
}
