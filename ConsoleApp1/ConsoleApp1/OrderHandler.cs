using System;
using Bebric;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class OrderHandler
    {
        public Dictionary<int, Order> orders = new Dictionary<int, Order>();
        private int LastId = 0;
        public void Load()
        {
            if (File.Exists("orders.txt"))
            {
                try
                {
                    using (StreamReader reader = new StreamReader("orders.txt"))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] data = line.Split(new char[] { '|' });
                            orders.Add(Convert.ToInt32(data[0]), new Order(Convert.ToInt32(data[0]), Convert.ToDateTime(data[1]), data[2], Convert.ToInt32(data[3]), Convert.ToDouble(data[4]), Convert.ToInt32(data[5]), Convert.ToInt32(data[6])));
                            if (LastId < Convert.ToInt32(data[0]))
                            {
                                LastId = Convert.ToInt32(data[0]);
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
        public void Add(Dictionary<int, User> users, Dictionary<int, Car> cars)
        {
            for (int i = LastId + 1; i < i + 1; i++)
            {
                string Destination;
                double Price;
                int Duration, CarId, UserId;
                Console.WriteLine("Время поступления заявки:");
                Console.WriteLine(DateTime.Now);
                Console.WriteLine("Введите пункт назначения: ");
                Destination = Programm.InputString();
                Console.WriteLine("Введите продолжительность поездки (В минутах): ");
                Duration = Programm.InputInt();
                Console.WriteLine("Введите стоимость проезда(в рублях): ");
                Price = Programm.InputDouble();
                foreach (Car car in cars.Values)
                {
                    Console.WriteLine($"{car.Id}|{car.Driver}|{car.Mark}|{car.Model}|{car.Notes}");
                }
                Console.WriteLine("Введите id машины, которую вы выбираете");
                CarId = Programm.InputInt();
                foreach (User user in users.Values)
                {
                    Console.WriteLine($"{user.Id}|{user.PhoneNumber}");
                }
                Console.WriteLine("Введите id заказчика");
                UserId = Programm.InputInt();
                orders.Add(i, new Order(i, DateTime.Now, Destination, Duration, Price, CarId, UserId));
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
                using (StreamWriter writer = new StreamWriter("orders.txt", false))
                {
                    foreach (Order order in orders.Values)
                    {
                        writer.WriteLine($"{order.Id}|{order.DateTime}|{order.Destinaion}|{order.Duration}|{order.Price}|{order.UserId}|{order.CarId}");
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
