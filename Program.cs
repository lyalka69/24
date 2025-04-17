using System;
using System.Collections.Generic;
using System.Globalization; // Для использования NumberFormatInfo.InvariantInfo при парсинге double
using System.Text; // Для установки кодировки консоли

// Используем одно пространство имен для всех классов в этом проекте
namespace _24
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                DisplayMenu();

                Console.Write("Введите номер задания (0 для выхода): ");
                string choiceInput = Console.ReadLine();

                if (int.TryParse(choiceInput, out int choice))
                {
                    Console.Clear();

                    switch (choice)
                    {
                        case 1:
                            RunTask1_BaseAutomatonDemo();
                            break;
                        case 2:
                            RunTask2_DerivedAutomatonDemo();
                            break;
                        case 3:
                            RunTask3_AntennaDemo(); // Вызываем новую задачу
                            break;
                        case 4:
                            RunTask4_Placeholder();
                            break;
                        case 0:
                            Console.WriteLine("Завершение программы.");
                            return;
                        default:
                            Console.WriteLine("Неверный номер задания. Пожалуйста, выберите номер из меню.");
                            break;
                    }

                    Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                }
            }
        }

        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("========== Главное Меню ==========");
            Console.WriteLine("Выберите задание для демонстрации:");
            Console.WriteLine("1. Демонстрация Базового Автомата");
            Console.WriteLine("2. Демонстрация Автомата (Скалярное произведение)");
            Console.WriteLine("3. Демонстрация классов Антенн (Наследование)"); // Обновлен пункт 3
            Console.WriteLine("4. Задание 4 (Заглушка - Не реализовано)");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("0. Выход из программы");
            Console.WriteLine("===================================");
        }

   
        static void RunTask1_BaseAutomatonDemo()
        {
            Console.WriteLine("--- Задание 1: Демонстрация Базового Автомата ---");
            SynchronousAutomaton baseAutomaton = new SynchronousAutomaton();
            Console.Write("Введите входную строку для базового автомата (например, 0101): ");
            string baseInput = Console.ReadLine() ?? "0101";
            string baseOutput = baseAutomaton.ProcessInput(baseInput);
            Console.WriteLine($"Выходная строка базового автомата: {baseOutput}");
            Console.WriteLine();
            baseAutomaton.PrintInfo();
        }

    
        static void RunTask2_DerivedAutomatonDemo()
        {
            Console.WriteLine("--- Задание 2: Демонстрация Автомата с Наследованием (Скалярное произведение) ---");
            Console.WriteLine("Введите три вещественных числа для первого набора (x, y, z):");
            double x = ReadDouble("x (например, 1.5): ");
            double y = ReadDouble("y (например, 2.0): ");
            double z = ReadDouble("z (например, -0.5): ");
            Console.WriteLine("\nВведите три вещественных числа для второго набора (a, b, c):");
            double a = ReadDouble("a (например, 3.1): ");
            double b = ReadDouble("b (например, -1.0): ");
            double c = ReadDouble("c (например, 4.2): ");
            ScalarProductAutomaton derivedAutomaton = new ScalarProductAutomaton(x, y, z, a, b, c);
            Console.Write("\nВведите входную строку для автомата-потомка (например, 1010): ");
            string derivedInput = Console.ReadLine() ?? "1010";
            string derivedOutput = derivedAutomaton.ProcessInput(derivedInput);
            Console.WriteLine($"Выходная строка автомата-потомка: {derivedOutput}");
            Console.WriteLine();
            derivedAutomaton.PrintInfo();
        }

        static void RunTask3_AntennaDemo()
        {
            Console.WriteLine("--- Задание 3: Демонстрация классов Антенн ---");

            // --- Базовая Антенна ---
            Console.WriteLine("\nСоздание объекта Базовой Антенны (Antenna):");
            Console.Write("Введите название базовой антенны: ");
            string name1 = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name1)) name1 = "Базовая Антенна 1"; // Имя по умолчанию

            double power1 = ReadDouble("Введите мощность базовой антенны: ");
            double height1 = ReadDouble("Введите высоту установки базовой антенны (м): ");

            // Создаем объект базового класса
            Antenna antenna1 = new Antenna(name1, power1, height1);
            // Выводим информацию с помощью его метода DisplayInfo()
            antenna1.DisplayInfo();

            // --- Продвинутая Антенна ---
            Console.WriteLine("\nСоздание объекта Продвинутой Антенны (AdvancedAntenna):");
            Console.Write("Введите название продвинутой антенны: ");
            string name2 = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name2)) name2 = "Продвинутая Антенна 2"; // Имя по умолчанию

            double power2 = ReadDouble("Введите мощность продвинутой антенны: ");
            double height2 = ReadDouble("Введите высоту установки продвинутой антенны (м): ");
            double pValue = ReadDouble("Введите коэффициент излучения (P) для продвинутой антенны: ");

            AdvancedAntenna antenna2 = new AdvancedAntenna(name2, power2, height2, pValue);

            antenna2.DisplayInfo();
        }


        static void RunTask4_Placeholder()
        {
            Console.WriteLine("--- Задание 4 (Не реализовано) ---");
            Console.WriteLine("Здесь могла бы быть реализация другой задачи.");
            // TODO: Добавить реализацию Задания 4, если необходимо.
        }


        /// <summary>
        /// Вспомогательный метод для безопасного чтения вещественного числа с консоли.
        /// </summary>
        static double ReadDouble(string prompt)
        {
            double value;
            string input;
            // Устанавливаем стиль, разрешающий точку и запятую как разделитель,
            // а также знак минуса. Используем инвариантную культуру для предсказуемости.
            NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign | NumberStyles.AllowThousands; // Разрешаем и запятую как разделитель групп
            CultureInfo culture = CultureInfo.InvariantCulture; // Предпочитаем точку как разделитель

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                // Пытаемся сначала с инвариантной культурой (точка)
                if (double.TryParse(input, style, culture, out value))
                {
                    break; // Успешно спарсили
                }
                // Если не вышло, пробуем с текущей культурой системы (может быть запятая)
                else if (double.TryParse(input, style, CultureInfo.CurrentCulture, out value))
                {
                    break; // Успешно спарсили
                }
                else
                {
                    Console.WriteLine(" Ошибка: Введите корректное вещественное число (например, 123.45 или -10).");
                }

            } while (true); // Повторяем, пока не получим корректное значение
            return value;
        }
    }
}