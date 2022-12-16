using System;
using System.Linq.Expressions;
using System.Xml.Linq;
using static System.Console;

namespace Program
{
    class Bills
    {
        public string? id;
        string? name;
        string? nominal;
        string? place;
        string? type;
        double addAnalyt;
        double remain;
        DateTime date;
        public Bills()
        {

        }

        public Bills(string? id, string? name, string? nominal, string? place, string? type, double addAnalyt, double remain, DateTime date)
        {
            this.id = id;
            this.name = name;
            this.nominal = nominal;
            this.place = place;
            this.type = type;
            this.addAnalyt = addAnalyt;
            this.remain = remain;
            this.date = date;
        }
        public void Show()
        {
            Console.WriteLine(id + " " + name + " " + nominal + " " + place + " " + type + " " + " " + addAnalyt + " " + remain + " " + date.ToString("d"));
            Console.WriteLine();
        }
        public void change()
        {
            Console.Clear();
            string? command;
            Console.WriteLine("Що хочете змінити?"
                + "\n1)ідентифікатор"
                + "\n2)назву"
                + "\n3)номінал"
                + "\n4)заклад"
                + "\n5)тип рахунку"
                + "\n6)додаткову аналітику"
                + "\n7)остачу"
                + "\n8)дату");
            command = Console.ReadLine();

            switch (command)
            { 
                case "1":
                    Console.WriteLine("Введіть новий ідентифікатор");
                    command = Console.ReadLine();
                    id = command;
                    break;
                case "2":
                    Console.WriteLine("Введіть нове ім'я");
                    command = Console.ReadLine();
                    name = command;
                    break;
                case "3":
                    Console.WriteLine("Введіть новий номінал");
                    command = Console.ReadLine();
                    nominal = command;
                    break;
                case "4":
                    Console.WriteLine("Введіть новий заклад");
                    command = Console.ReadLine();
                    place = command;
                    break;
                case "5":
                    Console.WriteLine("Введіть новий тип рахунку");
                    command = Console.ReadLine();
                    if (type != "кредитний")type = command;
                    else
                    {
                        Console.WriteLine($"Минулий тип був кредитом, тому цей рахунок стане дорівнювати 0(наразі там{remain}), ви впевнені?(YES,NO) ");
                        if (Console.ReadLine() == "YES")
                        {
                            type = command;
                            break;
                        }
                        else break;
                    }
                    type = command;
                    break;
                case "6":
                    Console.WriteLine("Введіть нову додаткову аналітику");
                    command = Console.ReadLine();
                    try
                    {
                        addAnalyt = Convert.ToDouble(command);
                    }
                    catch
                    {
                        Console.WriteLine("Недійсне значення");
                    }
                    break;
                case "7":
                    Console.WriteLine("Введіть нову остачу");
                    command = Console.ReadLine();
                    try
                    {
                        addAnalyt = Convert.ToDouble(command);
                    }
                    catch
                    {
                        Console.WriteLine("Недійсне значення");
                    }
                    break;
                case "8":
                    int plusm;
                    Console.WriteLine("Введіть нову дату");
                    Console.Write("Термін на скільки часу(спочатку роки): ");
                    plusm = Convert.ToInt32(Console.ReadLine()) * 12;
                    Console.Write("Термін на скільки часу(тепер місяці): ");
                    plusm += Convert.ToInt32(Console.ReadLine());
                    date = DateTime.Today;
                    date = date.AddMonths(plusm);
                    break;

            }


        }

    }

    class program
    {
        static Bills add()
        {
           
            string? id = ""; string? name = ""; 
            string? nominal = ""; string? place = "";
            string? type = ""; double addAnalyt = 0; 
            double remain = 0; DateTime date = DateTime.Today;
            int plusm = 0;
            Bills bills = new Bills();
                Console.Write("ідентифікатор: ");
                id = Console.ReadLine();
                Console.Write("Назва: ");
                name = Console.ReadLine();
                Console.Write("Номінал: ");
                nominal = Console.ReadLine();
                Console.Write("Заклад: ");
                place = Console.ReadLine();
                Console.Write("Тип рахунку(поточний, картковий, депозитний, кредитний, інший): ");
                type = Console.ReadLine();
                Console.Write("Додаткова аналітика: ");
                addAnalyt = Convert.ToDouble(Console.ReadLine());
                Console.Write("Остача: ");
                while (type != "кредитний" && remain < 0) remain = Convert.ToDouble(Console.ReadLine());
                Console.Write("Термін на скільки часу(спочатку роки): ");
                plusm = Convert.ToInt32(Console.ReadLine()) * 12;
                Console.Write("Термін на скільки часу(тепер місяці): ");
                plusm += Convert.ToInt32(Console.ReadLine());
            date = date.AddMonths(plusm);
            Console.WriteLine(date.ToString("d"));

            bills = new Bills(id, name, nominal, place, type, addAnalyt, remain, date);
            return bills;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("\t\tРахунки");

            string? command;
            List<Bills> bills = new List<Bills>();

            while (true)
            {
                Console.WriteLine("0 - зупинити програму\n" + "1 - додати рахунок");
                Console.WriteLine("2 - переглянути усі рахунки\n" + "3 - змінити рахунок");
                command = Console.ReadLine();
                Console.Clear();

                switch(command)
                {
                    case "0":
                        return;
                    case "1":
                        bills.Add(add());
                        break;
                    case "2":
                        Console.WriteLine("Ідентифікатор, назва, номінал, заклад, тип рахунку, додаткова аналітика, остача, дата завершення");
                        foreach (Bills b in bills)
                        {
                            b.Show();   
                        }

                        break;
                    case "3":
                        command = "";
                        Console.WriteLine("Введіть id рахунку ");
                        command = Console.ReadLine();
                        foreach (var item in bills)
                        {
                            if (item.id == command)
                            {
                                item.change();
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Невідома команда");
                        break;
                }

                Console.WriteLine("Натисніть enter для продовження...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

}
