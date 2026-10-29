using System; // Подключение базовых типов

namespace SynWorkApp // "связывает" файлы Program.cs, Worker.cs, InputHelper.cs
{
    public class Worker
    {
        private string _fio = "Нет данных"; // Инициализация поля 
        private string _post = "Нет данных"; // Инициализация поля
        private decimal _pay = 0m; // Инициализация поля 
        private int _year = DateTime.Now.Year; // Инициализация поля

        public Worker() { } // Пустой конструктор для случая отсутствия "реальных данных"

        public Worker(string fio, string post, decimal pay, int year) // Полный конструктор: 4 параметра
        {
            SetFio(fio);
            SetPost(post);
            SetPay(pay);
            SetYear(year);
        }

        public void SetFio(string value) // Сеттер Ф.И.О
        {
            if (string.IsNullOrWhiteSpace(value)) // Проверка: null / пустая строка / только пробелы?
                throw new ArgumentException("Ошибка в графе (Ф.И.О.сотрудника): Пустой ввод.", nameof(value)); 
            _fio = value.Trim(); // Обрезка краевых пробелов после проверки
        }

        public void SetPost(string value) // Сеттер должности
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ошибка в графе (Должность сотрудника): Пустой ввод.", nameof(value)); 
            _post = value.Trim(); // Обрезка краевых пробелов после проверки
        }

        public void SetPay(decimal value) // Сеттер зарплаты
        {
            if (value < 0m)
                throw new ArgumentOutOfRangeException(nameof(value), "Ошибка в графе (Зарплата сотрудника): значение не может быть отрицательным."); 
            _pay = value;
        }

        public void SetYear(int value) // Сеттер года приёма
        {
            int curYear = DateTime.Now.Year;
            if (value < 1900 || value > curYear)
                throw new ArgumentOutOfRangeException(nameof(value), $"Ошибка в графе (Принят на должность): Значение должно быть в диапазоне 1900–{curYear}.");
            _year = value;
        }

        public string GetFio() => _fio; // Возвращают значения
        public string GetPost() => _post; // Возвращают значения
        public decimal GetPay() => _pay; // Возвращают значения
        public int GetYear() => _year; // Возвращают значения
        public int GetExpYears(int curYear) // Стаж в годах: разница текущего года и года приёма
        {
            if (curYear < _year)
                throw new ArgumentException("Ошибка: Значение текущего года не может быть меньше года поступления.", nameof(curYear));
            return curYear - _year;
        }

        public bool HasExperienceGreaterThan(int minYears, int curYear) // Порог стажа: главный метод для поиска
        {
            if (minYears < 0)
                throw new ArgumentOutOfRangeException(nameof(minYears), "Ошибка: Значение порога стажа не может быть отрицательным.");
            return GetExpYears(curYear) > minYears;
        }

        public override string ToString() // Переопределение: объект представит себя строкой
        {
            return $"Ф.И.О. сотрудника: {_fio}, Должность сотрудника: {_post}, Зарплата сотрудника: {_pay} руб., Год поступления сотрудника: {_year}";
        }

        public void Display() // Вывод карточки сотрудника в консоль одной командой
        {
            Console.WriteLine(ToString());
        }
    }
}