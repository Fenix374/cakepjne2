using System;
using System.Collections.Generic;
using System.IO;

// Класс для представления заказа торта
class ЗаказТорта
{
    // Перечисление для формы торта
    public enum ФормаТорта
    {
        Круглый,
        Квадратный,
        ВСердечко
    }

    public enum ВкусТорта
    {
        Шоколадный,
        Ванильный,
        Клубничный
    }

    public enum ГлазурьТорта
    {
        Шоколадная,
        Ванильная,
        Сливочная
    }

    public enum ДекорТорта
    {
        Конфетти,
        Фрукты,
        Орехи
    }


    public class ПунктМенюФормыТорта
    {
        public ФормаТорта Форма { get; set; }
        public string Описание { get; set; }
        public decimal Цена { get; set; }

        public ПунктМенюФормыТорта(ФормаТорта форма, string описание, decimal цена)
        {
            Форма = форма;
            Описание = описание;
            Цена = цена;
        }
    }

    public class ПунктМенюВкусаТорта
    {
        public ВкусТорта Вкус { get; set; }
        public string Описание { get; set; }
        public decimal Цена { get; set; }

        public ПунктМенюВкусаТорта(ВкусТорта вкус, string описание, decimal цена)
        {
            Вкус = вкус;
            Описание = описание;
            Цена = цена;
        }
    }

    public class ПунктМенюГлазуриТорта
    {
        public ГлазурьТорта Глазурь { get; set; }
        public string Описание { get; set; }
        public decimal Цена { get; set; }

        public ПунктМенюГлазуриТорта(ГлазурьТорта глазурь, string описание, decimal цена)
        {
            Глазурь = глазурь;
            Описание = описание;
            Цена = цена;
        }
    }

    public class ПунктМенюДекораТорта
    {
        public ДекорТорта Декор { get; set; }
        public string Описание { get; set; }
        public decimal Цена { get; set; }

        public ПунктМенюДекораТорта(ДекорТорта декор, string описание, decimal цена)
        {
            Декор = декор;
            Описание = описание;
            Цена = цена;
        }
    }

    private static int ShowArrowMenu(List<string> menuItems)
    {
        ConsoleKeyInfo key;
        int selectedItemIndex = 0;

        do
        {
            Console.Clear();

            for (int i = 0; i < menuItems.Count; i++)
            {
                if (i == selectedItemIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(">");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(menuItems[i]);
                Console.ResetColor();
            }

            key = Console.ReadKey();

            if (key.Key == ConsoleKey.UpArrow)
            {
                selectedItemIndex = (selectedItemIndex == 0) ? menuItems.Count - 1 : selectedItemIndex - 1;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                selectedItemIndex = (selectedItemIndex == menuItems.Count - 1) ? 0 : selectedItemIndex + 1;
            }
        } while (key.Key != ConsoleKey.Enter);

        return selectedItemIndex;
    }

    // Метод для выбора пункта формы торта
    private static void ВыбратьФормуТорта()
    {
        List<ПунктМенюФормыТорта> пунктыМеню = new List<ПунктМенюФормыТорта>
        {
            new ПунктМенюФормыТорта(ФормаТорта.Круглый, "Круглый", 10.00m),
            new ПунктМенюФормыТорта(ФормаТорта.Квадратный, "Квадратный", 12.00m),
            new ПунктМенюФормыТорта(ФормаТорта.ВСердечко, "В Сердечко", 15.00m)
        };

        int выбранныйИндекс = ShowArrowMenu(пунктыМеню.ConvertAll(item => item.Описание));

        ПунктМенюФормыТорта выбранныйПункт = пунктыМеню[выбранныйИндекс];

        Console.WriteLine($"Выбрана форма торта: {выбранныйПункт.Описание}");
        Console.WriteLine($"Цена: {выбранныйПункт.Цена:C}");
    }

    // Метод для выбора пункта вкуса торта
    private static void ВыбратьВкусТорта()
    {
        List<ПунктМенюВкусаТорта> пунктыМеню = new List<ПунктМенюВкусаТорта>
        {
            new ПунктМенюВкусаТорта(ВкусТорта.Шоколадный, "Шоколадный", 5.00m),
            new ПунктМенюВкусаТорта(ВкусТорта.Ванильный, "Ванильный", 4.00m),
            new ПунктМенюВкусаТорта(ВкусТорта.Клубничный, "Клубничный", 4.50m)
        };

        int выбранныйИндекс = ShowArrowMenu(пунктыМеню.ConvertAll(item => item.Описание));

        ПунктМенюВкусаТорта выбранныйПункт = пунктыМеню[выбранныйИндекс];

        Console.WriteLine($"Выбран вкус торта: {выбранныйПункт.Описание}");
        Console.WriteLine($"Цена: {выбранныйПункт.Цена:C}");
    }

    // Метод для выбора пункта глазури торта
    private static void ВыбратьГлазурьТорта()
    {
        List<ПунктМенюГлазуриТорта> пунктыМеню = new List<ПунктМенюГлазуриТорта>
        {
            new ПунктМенюГлазуриТорта(ГлазурьТорта.Шоколадная, "Шоколадная", 2.00m),
            new ПунктМенюГлазуриТорта(ГлазурьТорта.Ванильная, "Ванильная", 1.50m),
            new ПунктМенюГлазуриТорта(ГлазурьТорта.Сливочная, "Сливочная", 1.80m)
        };

        int выбранныйИндекс = ShowArrowMenu(пунктыМеню.ConvertAll(item => item.Описание));

        ПунктМенюГлазуриТорта выбранныйПункт = пунктыМеню[выбранныйИндекс];

        Console.WriteLine($"Выбрана глазурь торта: {выбранныйПункт.Описание}");
        Console.WriteLine($"Цена: {выбранныйПункт.Цена:C}");
    }

    // Метод для выбора пункта декора торта
    private static void ВыбратьДекорТорта()
    {
        List<ПунктМенюДекораТорта> пунктыМеню = new List<ПунктМенюДекораТорта>
        {
            new ПунктМенюДекораТорта(ДекорТорта.Конфетти, "Конфетти", 0.50m),
            new ПунктМенюДекораТорта(ДекорТорта.Фрукты, "Фрукты", 1.00m),
            new ПунктМенюДекораТорта(ДекорТорта.Орехи, "Орехи", 0.80m)
        };

        int выбранныйИндекс = ShowArrowMenu(пунктыМеню.ConvertAll(item => item.Описание));

        ПунктМенюДекораТорта выбранныйПункт = пунктыМеню[выбранныйИндекс];

        Console.WriteLine($"Выбран декор торта: {выбранныйПункт.Описание}");
        Console.WriteLine($"Цена: {выбранныйПункт.Цена:C}");
    }

    // Метод для сохранения заказа в файл
    private static void СохранитьЗаказ(decimal общаяСтоимость)
    {
        string путьКФайлу = "ИсторияЗаказов.txt";

        using (StreamWriter sw = File.AppendText(путьКФайлу))
        {
            sw.WriteLine($"Заказ: {DateTime.Now}");
            sw.WriteLine($"Общая стоимость: {общаяСтоимость:C}");
            sw.WriteLine();
        }

        Console.WriteLine("Заказ успешно сохранен!");
    }

    // Метод для оформления заказа
    public static void ОформитьЗаказ()
    {
        decimal общаяСтоимость = 0.0m;

        bool выход = false;

        do
        {
            Console.Clear();
            Console.WriteLine("Меню заказа торта:");
            Console.WriteLine("1. Выбрать форму торта");
            Console.WriteLine("2. Выбрать вкус торта");
            Console.WriteLine("3. Выбрать глазурь торта");
            Console.WriteLine("4. Выбрать декор торта");
            Console.WriteLine("5. Завершить заказ и сохранить");
            Console.WriteLine("6. Отменить заказ");

            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Clear();
                    ВыбратьФормуТорта();
                    Console.ReadKey();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.Clear();
                    ВыбратьВкусТорта();
                    Console.ReadKey();
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Console.Clear();
                    ВыбратьГлазурьТорта();
                    Console.ReadKey();
                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Console.Clear();
                    ВыбратьДекорТорта();
                    Console.ReadKey();
                    break;

                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    Console.Clear();
                    СохранитьЗаказ(общаяСтоимость);
                    выход = true;
                    break;

                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    Console.Clear();
                    выход = true;
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Некорректный ввод! Попробуйте еще раз.");
                    Console.ReadKey();
                    break;
            }
        } while (!выход);
    }
}

// Главный класс программы
class Программа
{
    static void Main()
    {
        bool продолжитьЗаказ = true;

        do
        {
            Console.Clear();
            ЗаказТорта.ОформитьЗаказ();

            Console.WriteLine();
            Console.WriteLine("Хотите оформить еще один заказ? (Д/Н)");

            char выбор = Char.ToUpper(Console.ReadKey().KeyChar);
            продолжитьЗаказ = (выбор == 'Д');
        } while (продолжитьЗаказ);
    }
}
