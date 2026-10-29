using System; // Подключение базовых типов

namespace SynWorkApp // "связывает" файлы Program.cs, Worker.cs, InputHelper.cs
{
    public static class InputHelper
    {
        public static string ReadString(string prompt) // Возвращает значение типа string
        {
            while (true) // Бесконечный цикл для получения валидного значения
            {
                Console.Write(prompt); // Вывод подсказки
                string? input = Console.ReadLine(); // Ввод значения

                if (!string.IsNullOrWhiteSpace(input)) // Условие проверки на пустое значение
                    return input.Trim(); // убрать лишние пробелы с краев

                Console.WriteLine("Ошибка: Пустой ввод. Введите ещё раз."); // Вывод при ошибке ввода
            }
        }

        public static int ReadInt(string prompt, int min, int max) // Возвращает целое число
        {
            while (true) // Бесконечный цикл для получения валидного значения
            {
                Console.Write(prompt); // Вывод подсказки
                string? input = Console.ReadLine();  // Ввод значения

                if (string.IsNullOrWhiteSpace(input)) // Условие проверки на пустое значение
                {
                    Console.WriteLine("Пустой ввод. Введите ещё раз."); // Вывод при ошибке ввода
                    continue;
                }

                bool ok = int.TryParse(input, out int value); // Способ превратить строку в число

                if (!ok) // Условие проверки на число
                {
                    Console.WriteLine("Не целое число. введите ещё раз."); // Вывод при ошибке 
                    continue;
                }

                if (value < min || value > max) // Условие проверки на диапазон
                {
                    Console.WriteLine($"Значение должно быть от {min} до {max}. Введите ещё раз."); // Вывод при ошибке 
                    continue;
                }

                return value; // Успешный возврат
            }
        }

        public static decimal ReadDecimal(string prompt, decimal min, decimal max) // Возвращает значение типа decimal (метод умеет работать с дробными числами и диапазонами)
        {
            while (true)
            {
                Console.Write(prompt); // Вывод подсказки
                string? input = Console.ReadLine(); // Ввод значения

                if (decimal.TryParse(input, out decimal value) && value >= min && value <= max) // Условие проверки на валидность
                    return value;

                Console.WriteLine($"Ошибка: Значение должно быть в диапазоне [{min}, {max}]."); // Вывод при ошибке ввода
            }
        }
    }
}