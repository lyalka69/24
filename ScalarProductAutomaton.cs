using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24
{
    public class ScalarProductAutomaton : SynchronousAutomaton
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public ScalarProductAutomaton(double x, double y, double z, double a, double b, double c) : base()
        {
            X = x; Y = y; Z = z;
            A = a; B = b; C = c;
        }

        public double CalculateScalarProduct() => (X * A) + (Y * B) + (Z * C);

        public override void PrintInfo()
        {
            Console.WriteLine("=== Информация об автомате со скалярным произведением (Потомок) ===");
            Console.WriteLine($"Текущее состояние после обработки: {currentState}");
            Console.WriteLine("Таблица переходов (унаследована): (тек. сост, вход) -> (след. сост, выход)");
            foreach (var item in transitions)
            {
                Console.WriteLine($"({item.Key.Item1}, '{item.Key.Item2}') -> ({item.Value.Item1}, \"{item.Value.Item2}\")");
            }
            Console.WriteLine("--- Дополнительная информация ---");
            Console.WriteLine($"Набор 1 (X,Y,Z): ({X}, {Y}, {Z})");
            Console.WriteLine($"Набор 2 (A,B,C): ({A}, {B}, {C})");
            Console.WriteLine($"Скалярное произведение: {CalculateScalarProduct()}");
        }
    }
}
