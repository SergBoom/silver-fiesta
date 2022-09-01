using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bebric
{
    public class Car
    {
        public readonly int Id;
        public string Driver { get; private set; }
        public string Mark { get; private set; }
        public string Model { get; private set; }
        public string Notes { get; private set; }
        public Car(int id, string driver, string mark, string model, string notes)
        {
            Id = id;
            Driver = driver;
            Mark = mark;
            Model = model;
            Notes = notes;
        }
        public Car(int id, string driver, string mark, string model)
        {
            Id = id;
            Driver = driver;
            Mark = mark;
            Model = model;
        }

    }

}
