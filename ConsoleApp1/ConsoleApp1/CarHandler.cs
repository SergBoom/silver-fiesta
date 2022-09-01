using Bebric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class CarHandler
    {
        public Dictionary<int, Car> cars = new Dictionary<int, Car>();
        private int LastId = 0;
        public void Load()
        {
            if (File.Exists("cars.txt"))
            {
                try
                {
                    using (StreamReader reader = new StreamReader("cars.txt"))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] carData = line.Split(new char[] { '|' });
                            cars.Add(Convert.ToInt32(carData[0]), new Car(Convert.ToInt32(carData[0]), carData[1], carData[2], carData[3], carData[4]));
                            if (LastId < Convert.ToInt32(carData[0]))
                            {
                                LastId = Convert.ToInt32(carData[0]);
                            }
                        }
                    }
                }
                catch 
                {
                    Console.WriteLine("Файлу пизда");
                }
            }
            else
            {
                Console.WriteLine("Файла нет");
            }
        }
        public void Add()
        {
            for (int i = LastId + 1; i < i + 1; i++)
            {
                string DriverName, Marka, Modelb, Note;
                Console.WriteLine("Введите имя водителя: ");
                DriverName = Programm.InputString();
                Console.WriteLine("Введите марку автомобиля: ");
                Marka = Programm.InputString();
                Console.WriteLine("Введите модель автомобиля: ");
                Modelb = Programm.InputString();
                Console.WriteLine("Введите примечания к автомобилю: ");
                Note = Programm.InputString();
                cars.Add(i, new Car(i, DriverName, Marka, Modelb, Note));
                LastId = i;
                string j;
                Console.WriteLine("Введите 1 если ввели все данные, либо другую кнопку для ввода новых данных");
                j = Console.ReadLine();
                if (j == "1")
                {
                    break;
                }
            }
        }
        public void Save()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("cars.txt", false))
                {
                    foreach (Car car in cars.Values)
                    {
                        writer.WriteLine($"{car.Id}|{car.Driver}|{car.Mark}|{car.Model}|{car.Notes}");
                    }
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Я хз как мы к этому пришли");
            }
        }
    }
}
