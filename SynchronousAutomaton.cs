
using System.Collections.Generic;
using System;

public class SynchronousAutomaton
{
    public enum State
    {
        A, B, C
    }

    protected State currentState;
        protected Dictionary<(State, char), (State, string)> transitions;

        public SynchronousAutomaton()
        {
            currentState = State.A;
            transitions = new Dictionary<(State, char), (State, string)>()
            {
                {(State.A, '0'), (State.B, "011")}, {(State.A, '1'), (State.C, "101")},
                {(State.B, '0'), (State.A, "110")}, {(State.B, '1'), (State.C, "001")},
                {(State.C, '0'), (State.B, "111")}, {(State.C, '1'), (State.A, "000")}
            };
        }

        public virtual string ProcessInput(string input)
        {
            currentState = State.A;
            string output = "";
            foreach (char symbol in input)
            {
                if (transitions.TryGetValue((currentState, symbol), out var trans))
                {
                    output += trans.Item2;
                    currentState = trans.Item1;
                }
                else
                {
                    output += "???";
                    Console.WriteLine($"Предупреждение: Не найден переход для состояния {currentState} и символа '{symbol}'. Обработка прервана.");
                    break;
                }
            }
            return output;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine("=== Информация о базовом синхронном автомате ===");
            Console.WriteLine($"Текущее состояние после обработки: {currentState}");
            Console.WriteLine("Таблица переходов: (тек. сост, вход) -> (след. сост, выход)");
            foreach (var item in transitions)
            {
                Console.WriteLine($"({item.Key.Item1}, '{item.Key.Item2}') -> ({item.Value.Item1}, \"{item.Value.Item2}\")");
            }
        }
}
