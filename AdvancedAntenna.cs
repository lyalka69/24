using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24
{
    public class AdvancedAntenna : Antenna
    {
        // Дополнительное поле P (коэффициент излучения)
        public double P { get; set; }

        /// <summary>
        /// Конструктор для инициализации всех полей (базовых и дополнительных)
        /// </summary>
        public AdvancedAntenna(string name, double power, double height, double p)
            : base(name, power, height) // Вызов конструктора базового класса
        {
            P = p; // Инициализация дополнительного поля
        }

        /// <summary>
        /// Переопределенный метод для определения "качества" антенны (Qp).
        /// </summary>
        public override double CalculateQuality()
        {
            // Получаем базовое значение Q, вызвав реализацию метода из базового класса
            double baseQ = base.CalculateQuality();
            // Формула: Qp = Q - 0.1 * P
            return baseQ - 0.1 * P;
        }

        /// <summary>
        /// Переопределенный метод для вывода информации об объекте 2-го уровня.
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine("--- Информация об антенне (Уровень 2) ---");
            Console.WriteLine($"Название: {Name}");      // Унаследованное свойство
            Console.WriteLine($"Мощность: {Power}");      // Унаследованное свойство
            Console.WriteLine($"Высота: {Height} м");   // Унаследованное свойство
            Console.WriteLine($"Коэффициент излучения (P): {P}"); // Новое свойство
                                                                  // Вызываем переопределенный метод CalculateQuality() для получения Qp
            Console.WriteLine($"Качество (Qp): {CalculateQuality():F2}");
            Console.WriteLine("----------------------------------------");
        }
    }
}
