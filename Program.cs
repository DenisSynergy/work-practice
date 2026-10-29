using System; // Подключение базовых типов
using System.Collections.Generic; // Необходимо для List<T>

namespace SynWorkApp // "связывает" файлы Program.cs, Worker.cs, InputHelper.cs
{
    internal class Program // Класс, содержащий точку входа
    {
        static void Main(string [] args) // Точка входа
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Кодировка UTF8 (для кирилицы в консоль)

            try // Любое исключение ниже перехватит catch
            {
                List<Worker> workers = new List<Worker>(); // Главный список

                int count = InputHelper.ReadInt("Введите количество сотрудников для ввода: ", 0, 1000); // Переменная count типа Int принимает текущее значение через вызов метода ReadInt из InputHelper


                for (int i = 0; i < count; i++) // Цикл (перебор для внесения данных по каждому из сотрудников)
                {
                    Console.WriteLine(); // Пустая строка-разделитель перед каждым сотрудником
                    Console.WriteLine($"Сотрудник #{i + 1}"); // Подсказка по порядковому номеру сотрудника для удобства ввода данных

                    string fio = InputHelper.ReadString("Ф.И.О.сотрудника (пример: Иванов И.И.): "); // Переменная fio типа String принимает текущее значение через вызов метода ReadString из InputHelper
                    string post = InputHelper.ReadString("Должность сотрудника (пример: Преподаватель): "); // Переменная post типа String принимает текущее значение через вызов метода ReadString из InputHelper
                    decimal pay = InputHelper.ReadDecimal("Зарплата сотрудника (руб., пример: 70000): ", 0m, 1000000m); // Переменная pay типа decimal принимает текущее значение через вызов метода ReadDecimal из InputHelper
                    int year = InputHelper.ReadInt("Принят на должность (год, пример: 1999): ", 1950, DateTime.Now.Year); // Переменная year типа Int принимает текущее значение (учитывая текущий год) через вызов метода ReadInt из InputHelper

                    Worker workman = new Worker(fio, post, pay, year); // память в куче → инициализаторы → конструктор → 4 сеттера
                    workers.Add(workman); // в список уходит АДРЕС объекта
                }

                int minExp = InputHelper.ReadInt("Ввод значения для поиска сотрудников, чей стаж работы в организации превышает это значение (в годах): ", 0, 100); // Порог стажа
                int curYear = DateTime.Now.Year; // Текущий год вычисляем
                List<Worker> matched = new List<Worker>(); // Второй список для найденных сотрудников

                foreach (var workman in workers) // Список по очереди отдаёт элементы

                {
                    if (workman.HasExperienceGreaterThan(minExp, curYear)) // true — стаж превышает порог
                        matched.Add(workman); // Добавление по второму списку
                }

                Console.WriteLine();
                if (matched.Count == 0)
                {
                    Console.WriteLine("Сотрудников со стажем, превышающим введенное значение, нет."); // Вывод при пустом результате
                }
                else
                {
                    Console.WriteLine($"Сотрудники со стажем больше {minExp} лет(года) (на {curYear} год):"); // Заголовок с подставленными числами
                    foreach (var workman in matched) // Обход второго списка — только найденные
                    {
                        Console.WriteLine(workman.GetFio()); // Печатаем Ф.И.О. каждого найденного сотрудника по условию порога стажа
                    }
                }
            }
            catch (Exception ex) // try... catch (Обработка исключений)
            {
                Console.ForegroundColor = ConsoleColor.Red; // Делает текст красным
                Console.WriteLine($"Произошла ошибка: {ex.Message}"); // Сообщение об ошибке
                Console.ResetColor(); // Возвращает обычный цвет текста
            }

            Console.WriteLine(); // Пустая строка-разделитель
            Console.WriteLine("Нажмите любую клавишу для выхода..."); // Подсказка, чтобы окно не закрылось для пользователя без его участия
            Console.ReadKey(); // Ждёт нажатия любой клавиши
        }
    }
}