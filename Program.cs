using System;

namespace ClassesDemo
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n=== МЕНЮ ===");
                Console.WriteLine("1. Клас Address");
                Console.WriteLine("2. Клас Converter");
                Console.WriteLine("3. Клас Employee");
                Console.WriteLine("4. Клас User");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        RunAddress();
                        break;
                    case "2":
                        RunConverter();
                        break;
                    case "3":
                        RunEmployee();
                        break;
                    case "4":
                        RunUser();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір!");
                        break;
                }
            }
        }

        // ===== Завдання 1 =====
        static void RunAddress()
        {
            Address address = new Address
            {
                Index = "02090",
                Country = "Україна",
                City = "Київ",
                Street = "Хрещатик",
                House = "10",
                Apartment = "25"
            };
            address.ShowInfo();
        }

        // ===== Завдання 2 =====
        static void RunConverter()
        {
            Converter converter = new Converter(40.0, 43.0, 9.5);

            Console.Write("Оберіть напрям конвертації (1 - з грн, 2 - у грн): ");
            int type = int.Parse(Console.ReadLine());

            Console.Write("Введіть валюту (USD, EUR, PLN): ");
            string currency = Console.ReadLine();

            Console.Write("Введіть суму: ");
            double amount = double.Parse(Console.ReadLine());

            if (type == 1)
            {
                double result = converter.ConvertToForeign(amount, currency);
                Console.WriteLine($"{amount} грн = {result:F2} {currency}");
            }
            else
            {
                double result = converter.ConvertToUAH(amount, currency);
                Console.WriteLine($"{amount} {currency} = {result:F2} грн");
            }
        }

        // ===== Завдання 3 =====
        static void RunEmployee()
        {
            Console.Write("Введіть ім’я: ");
            string firstName = Console.ReadLine();

            Console.Write("Введіть прізвище: ");
            string lastName = Console.ReadLine();

            Console.Write("Введіть посаду: ");
            string position = Console.ReadLine();

            Console.Write("Введіть стаж (років): ");
            int experience = int.Parse(Console.ReadLine());

            Employee emp = new Employee(firstName, lastName);
            double salary = emp.CalculateSalary(position, experience);
            double tax = emp.CalculateTax(salary);

            Console.WriteLine($"\nПрацівник: {lastName} {firstName}");
            Console.WriteLine($"Посада: {position}");
            Console.WriteLine($"Оклад: {salary:F2} грн");
            Console.WriteLine($"Податок: {tax:F2} грн");
            Console.WriteLine($"Сума до виплати: {salary - tax:F2} грн");
        }

        // ===== Завдання 4 =====
        static void RunUser()
        {
            User user = new User();

            Console.Write("Введіть логін: ");
            user.Login = Console.ReadLine();

            Console.Write("Введіть ім’я: ");
            user.FirstName = Console.ReadLine();

            Console.Write("Введіть прізвище: ");
            user.LastName = Console.ReadLine();

            Console.Write("Введіть вік: ");
            user.Age = int.Parse(Console.ReadLine());

            user.ShowInfo();
        }
    }

    // ===== Клас Address =====
    class Address
    {
        public string Index { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Індекс: {Index}");
            Console.WriteLine($"Країна: {Country}");
            Console.WriteLine($"Місто: {City}");
            Console.WriteLine($"Вулиця: {Street}");
            Console.WriteLine($"Будинок: {House}");
            Console.WriteLine($"Квартира: {Apartment}");
        }
    }

    // ===== Клас Converter =====
    class Converter
    {
        private double usd;
        private double eur;
        private double pln;

        public Converter(double usd, double eur, double pln)
        {
            this.usd = usd;
            this.eur = eur;
            this.pln = pln;
        }

        public double ConvertToForeign(double uah, string currency)
        {
            switch (currency.ToUpper())
            {
                case "USD": return uah / usd;
                case "EUR": return uah / eur;
                case "PLN": return uah / pln;
                default: return 0;
            }
        }

        public double ConvertToUAH(double amount, string currency)
        {
            switch (currency.ToUpper())
            {
                case "USD": return amount * usd;
                case "EUR": return amount * eur;
                case "PLN": return amount * pln;
                default: return 0;
            }
        }
    }

    // ===== Клас Employee =====
    class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public double CalculateSalary(string position, int experience)
        {
            double baseSalary;

            switch (position.ToLower())
            {
                case "менеджер":
                    baseSalary = 15000;
                    break;
                case "інженер":
                    baseSalary = 20000;
                    break;
                case "програміст":
                    baseSalary = 30000;
                    break;
                default:
                    baseSalary = 12000;
                    break;
            }

            double bonus = 1 + (experience * 0.05); // +5% за кожен рік
            return baseSalary * bonus;
        }


        public double CalculateTax(double salary)
        {
            return salary * 0.18;
        }
    }

    // ===== Клас User =====
    class User
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public readonly DateTime RegistrationDate;

        public User()
        {
            RegistrationDate = DateTime.Now;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"\nЛогін: {Login}");
            Console.WriteLine($"Ім’я: {FirstName}");
            Console.WriteLine($"Прізвище: {LastName}");
            Console.WriteLine($"Вік: {Age}");
            Console.WriteLine($"Дата заповнення анкети: {RegistrationDate}");
        }
    }
}
