using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ConsoleApp1;

namespace Bebric
{
    class Programm
    {
        private static CarHandler carHandler = new();
        private static UserHandler userHandler = new();
        private static OrderHandler orderHandler = new();
        private static void ShowCarList()
        {
            foreach (Car car in carHandler.cars.Values)
            {
                Console.WriteLine($"{car.Id}|{car.Driver}|{car.Mark}|{car.Model}|{car.Notes}");
            }
        }
        private static void ShowUserList()
        {
            foreach (User user in userHandler.users.Values)
            {
                Console.WriteLine($"{user.Id}|{user.PhoneNumber}");
            }
        }

        private static void ShowOrderList()
        {
            foreach (Order order in orderHandler.orders.Values)
            {
                Console.WriteLine($"{order.Id}|{order.DateTime}|{order.Destinaion}|{order.Duration}|{order.Price}|{order.UserId}|{order.CarId}");
            }
        }
        private static void EditCar()
        {
            Console.WriteLine("Введите 1, чтобы удалить машину\nВведите другое значение для изменения данных");
            int input_1 = InputInt();
            if (input_1 == 1)
            {
                foreach (Car car in carHandler.cars.Values)
                {
                    Console.WriteLine($"{car.Id}|{car.Driver}|{car.Mark}|{car.Model}|{car.Notes}");
                }
                Console.WriteLine("Выберите id машины, которую хотите удалить");
                int removed = TryGetContains<Car>(carHandler.cars);
                carHandler.cars.Remove(removed);
            }
            else
            {
                int change;
                foreach (Car car in carHandler.cars.Values)
                {
                    Console.WriteLine($"{car.Id}|{car.Driver}|{car.Mark}|{car.Model}|{car.Notes}");
                }
                Console.WriteLine("Введите id записи, которую вы хотите изменить");
                change = TryGetContains<Car>(carHandler.cars);
                string DriverName, Marka, Modelb, Note;
                Console.WriteLine("Введите имя водителя: ");
                DriverName = InputString();
                Console.WriteLine("Введите марку автомобиля: ");
                Marka = InputString();
                Console.WriteLine("Введите модель автомобиля: ");
                Modelb = InputString();
                Console.WriteLine("Введите примечания к автомобилю: ");
                Note = InputString();
                carHandler.cars[change] = new Car(change, DriverName, Marka, Modelb, Note);
            }
        }
        private static void EditOrder()
        {
            Console.WriteLine("Введите 1, чтобы удалить заявку\nВведите другое значение для изменения данных");
            int input_3 = InputInt();
            if (input_3 == 1)
            {
                foreach (Order order in orderHandler.orders.Values)
                {
                    Console.WriteLine($"{order.Id}|{order.DateTime}|{order.Destinaion}|{order.Duration}|{order.Price}|{order.UserId}|{order.CarId}");
                }
                Console.WriteLine("Выберите id заявки, которую хотите удалить");
                int removed = TryGetContains<Order>(orderHandler.orders);
                orderHandler.orders.Remove(removed);
            }
            else
            {
                int change;
                foreach (Order order in orderHandler.orders.Values)
                {
                    Console.WriteLine($"{order.Id}|{order.DateTime}|{order.Destinaion}|{order.Duration}|{order.Price}|{order.UserId}|{order.CarId}");
                }
                string Destination;
                double Price;
                int Duration, CarId, UserId;
                Console.WriteLine("Введите id записи, которую вы хотите изменить");
                change = TryGetContains<Order>(orderHandler.orders);
                Console.WriteLine("Время поступления заявки:");
                Console.WriteLine(DateTime.Now);
                Console.WriteLine("Введите пункт назначения: ");
                Destination = InputString();
                Console.WriteLine("Введите продолжительность поездки (В минутах): ");
                Duration = InputInt();
                Console.WriteLine("Введите стоимость проезда(в рублях): ");
                Price = InputDouble();
                foreach (Car car in carHandler.cars.Values)
                {
                    Console.WriteLine($"{car.Id}|{car.Driver}|{car.Mark}|{car.Model}|{car.Notes}");
                }
                Console.WriteLine("Введите id машины, которую вы выбираете");
                CarId = TryGetContains<Car>(carHandler.cars);
                foreach (User user in userHandler.users.Values)
                {
                    Console.WriteLine($"{user.Id}|{user.PhoneNumber}");
                }
                Console.WriteLine("Введите id заказчика");
                UserId = TryGetContains<User>(userHandler.users);
                orderHandler.orders[change] = new Order(change, DateTime.Now, Destination, Duration, Price, CarId, UserId);
            }
        }
        private static void EditUser()
        {
            Console.WriteLine("Введите 1, чтобы удалить заказчика\nВведите другое значение для изменения данных");
            int input_2 = InputInt();
            if (input_2 == 1)
            {
                foreach (User user in userHandler.users.Values)
                {
                    Console.WriteLine($"{user.Id}|{user.PhoneNumber}");
                }
                Console.WriteLine("Выберите id заказчика, которого хотите удалить");
                int removed = TryGetContains<User>(userHandler.users);
                userHandler.users.Remove(removed);
            }
            else
            {
                foreach (User user in userHandler.users.Values)
                {
                    Console.WriteLine($"{user.Id}|{user.PhoneNumber}");
                }
                Console.WriteLine("Введите id записи, которую вы хотите изменить");
                int change = TryGetContains<User>(userHandler.users);
                string PhoneNumber;
                Console.WriteLine("Введите номер телефона заказчика: ");
                PhoneNumber = InputNumber();
                userHandler.users[change] = new User(change, PhoneNumber);
                Console.WriteLine("Нет записи с таким id");
            }
        }
        private static int TryGetContains<T>(Dictionary<int, T> dict)
        {
            while (true)
            {
                var input = InputInt();
                if (!dict.ContainsKey(input))
                {
                    Console.WriteLine("Нет записи с таким id");
                }
                else
                {
                    return input;
                }
            }
        }
        public static string trimIt(string s)
        {
            if (s == null)
                return string.Empty;

            int count = Math.Min(s.Length, 250);
            return s.Substring(0, count);
        }
        public static string InputNumber()
        {
            string result = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Backspace:
                        if (result.Length > 0)
                        {
                            result = result.Remove(result.Length - 1, 1);
                            Console.Write(key.KeyChar + " " + key.KeyChar);
                        }
                    break;
                    case ConsoleKey.Enter:
                        Console.WriteLine();
                            try
                            {
                                if (result.Length > 11 || result.Length < 11)
                                {
                                    throw new Exception("Вы допустили ошибку при вводе номера телефона!");
                                }
                                return result;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        break;
                    default:
                        if (char.IsDigit(key.KeyChar))
                        {
                            Console.Write(key.KeyChar);
                            result += key.KeyChar;
                        }
                        break;
                }
            }
        }
        public static int InputInt()
        {
            while (true)
            {
                try
                {
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Вы ввели неверное значение, повторите попытку");
                }
            }
        }
        public static double InputDouble()
        {
            while (true)
            {
                try
                {
                    return Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Вы ввели неверное значение, повторите попытку");
                }
            }
        }
        public static string InputString()
        {
            string s;
            while (true)
            {
                try
                {
                    s = Console.ReadLine().Trim();
                    if (s == "")
                    {
                        throw new Exception("Нельзя ввсети пустое значение!");
                    }
                    return s;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void Main(string[] args)
        {
            carHandler.Load();
            userHandler.Load();
            orderHandler.Load();
            bool isComplete = true;
            while (isComplete)
            {
                Console.WriteLine("Введите цифру 1, чтобы добавить автомобиль\nВведите цифру 2, чтобы добавить заказчика\nВведите цифру 3, чтобы добавить заявку\nВведите цифру 4, чтобы посмотреть список машин\nВведите цифру 5, чтобы посмотреть список заказчиков\nВведите цифру 6, чтобы посмотреть список заявок\nВведите цифру 7, чтобы редактировать список машин\nВведите цифру 8, чтобы редактировать список заказчиков\nВведите цифру 9, чтобы редактировать список заявок\nВведите цифру 0, чтобы закрыть приложение\n");
                switch (InputInt())
                {
                    case 0:
                        isComplete = false;
                        carHandler.Save();
                        orderHandler.Save();
                        userHandler.Save();
                        break;
                    case 1:
                        carHandler.Add();
                        break;
                    case 2:
                        userHandler.Add();
                        break;
                    case 3:
                        orderHandler.Add(userHandler.users, carHandler.cars);
                        break;
                    case 4:
                        ShowCarList();
                        break;
                    case 5:
                        ShowUserList();
                        break;
                    case 6:
                        ShowOrderList();
                        break;
                    case 7:
                        EditCar();
                        break;
                    case 8:
                        EditUser();
                        break;
                    case 9:
                        EditOrder();
                        break;
                    default:
                        Console.WriteLine("Введено неправильное число!");
                        break;
                }
            }
            carHandler.Save();
            userHandler.Save();
            orderHandler.Save();
        }
    }
}
