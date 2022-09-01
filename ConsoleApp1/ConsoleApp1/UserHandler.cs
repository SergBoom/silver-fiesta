using System;
using Bebric;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class UserHandler
    {
        public Dictionary<int, User> users = new Dictionary<int, User>();
        private int LastId = 0;
        public void Load()
        {
            if (File.Exists("users.txt"))
            {
                try
                {
                    using (StreamReader reader = new StreamReader("users.txt"))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] userData = line.Split(new char[] { '|' });
                            users.Add(Convert.ToInt32(userData[0]), new User(Convert.ToInt32(userData[0]), (userData[1])));
                            if (LastId < Convert.ToInt32(userData[0]))
                            {
                                LastId = Convert.ToInt32(userData[0]);
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
                string PhoneNumber;
                Console.WriteLine("Введите номер телефона заказчика: ");
                PhoneNumber = Programm.InputNumber();
                users.Add(i, new User(i, PhoneNumber));
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
                using (StreamWriter writer = new StreamWriter("users.txt", false))
                {
                    foreach (User user in users.Values)
                    {
                        writer.WriteLine($"{user.Id}|{user.PhoneNumber}");
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
