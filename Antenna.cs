using _24;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _24
{
    public class Antenna
    {
        public string Name { get; set; }
        public double Power { get; set; } // Мощность
        public double Height { get; set; } // Высота в метрах

        /// <summary>
        /// Конструктор для инициализации полей базового класса
        /// </summary>
        public Antenna(string name, double power, double height)
        {
            Name = name;
            Power = power;
            Height = height;
        }

        /// <summary>
        /// Виртуальный метод для определения "качества" антенны (Q).
        /// </summary>
        public virtual double CalculateQuality()
        {
            // Формула: Q = мощность + 0.5 * высота
            return Power + 0.5 * Height;
        }

        /// <summary>
        /// Виртуальный метод для вывода информации об объекте.
        /// </summary>
        public virtual void DisplayInfo()
        {
            Console.WriteLine("--- Информация об антенне (Уровень 1) ---");
            Console.WriteLine($"Название: {Name}");
            Console.WriteLine($"Мощность: {Power}");
            Console.WriteLine($"Высота: {Height} м");
            // Используем F2 для форматирования вывода double с 2 знаками после запятой
            Console.WriteLine($"Качество (Q): {CalculateQuality():F2}");
            Console.WriteLine("----------------------------------------");
        }
    }
}


