using System;
using System.IO;

namespace Person1
{
    class Person
    {
        string name;
        int birth_year;
        double pay;

        // Конструктор без параметрів
        public Person()
        {
            name = "Anonymous";
            birth_year = 0;
            pay = 0;
        }

        // Конструктор з параметром
        public Person(string s)
        {
            // Розбиття рядка на слова
            string[] parts = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Перевірка коректності розбиття
            if (parts.Length < 3)
            {
                throw new FormatException("Некоректний формат даних.");
            }

            // Прізвище та ініціали (всі слова до року народження)
            name = string.Join(" ", parts, 0, parts.Length - 2);

            // Рік народження
            birth_year = Convert.ToInt32(parts[parts.Length - 2]);

            // Оклад (з заміною коми на крапку для коректної обробки)
            pay = Convert.ToDouble(parts[parts.Length - 1].Replace(',', '.'));

            // Перевірки на коректність
            if (birth_year < 1900 || birth_year > DateTime.Now.Year)
                throw new FormatException("Некоректний рік народження.");
            if (pay < 0) throw new FormatException("Некоректний оклад.");
        }

        public override string ToString()
        {
            return string.Format("Name: {0,-30} Birth Year: {1} Salary: {2:F2}", name, birth_year, pay);
        }

        public int Compare(string name)
        {
            return string.Compare(this.name, name, StringComparison.OrdinalIgnoreCase);
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int BirthYear
        {
            get { return birth_year; }
            set
            {
                if (value > 0) birth_year = value;
                else throw new FormatException("Некоректний рік народження.");
            }
        }

        public double Pay
        {
            get { return pay; }
            set
            {
                if (value >= 0) pay = value;
                else throw new FormatException("Некоректний оклад.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person[] dbase = new Person[100];
            int n = 0;

            try
            {
                using (StreamReader f = new StreamReader("d:\\Persons.txt", System.Text.Encoding.UTF8))
                {
                    string s;
                    int i = 0;

                    while ((s = f.ReadLine()) != null)
                    {
                        dbase[i] = new Person(s);  // Використовуємо новий конструктор
                        Console.WriteLine(dbase[i]);
                        ++i;
                    }
                    n = i;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Перевірте правильність імені і шляху до файлу!");
                return;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Дуже великий файл!");
                return;
            }
            catch (FormatException e)
            {
                Console.WriteLine("Неприпустимий формат: " + e.Message);
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine("Помилка: " + e.Message);
                return;
            }

            int n_pers = 0;
            double mean_pay = 0;
            Console.WriteLine("Введіть прізвище співробітника:");
            string name;

            while ((name = Console.ReadLine()) != "")
            {
                bool not_found = true;
                for (int k = 0; k < n; ++k)
                {
                    Person pers = dbase[k];
                    if (pers.Compare(name) == 0)
                    {
                        Console.WriteLine(pers);
                        ++n_pers;
                        mean_pay += pers.Pay;
                        not_found = false;
                    }
                }
                if (not_found) Console.WriteLine("Такого співробітника немає.");
                Console.WriteLine("Введіть прізвище співробітника або Enter для завершення:");
            }

            if (n_pers > 0)
                Console.WriteLine("Середній оклад: {0:F2}", mean_pay / n_pers);

            Console.ReadKey();
        }
    }
}
