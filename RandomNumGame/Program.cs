using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int difficult, num = 0, hardcoreCounter = 0;
            bool hardcore = false, cheating = false;
            int maxValue = 0, minValue = 0;

            Random rnd = new Random();

            do
            {
                Console.Write("Выберите сложность\n 1 - Лёгкая\n 2 - Нормальная\n 3 - Сложная \n 4 - Хардкор\n>>>");
                difficult = int.Parse(Console.ReadLine());
                switch (difficult)
                {
                    case 1: num = rnd.Next(1, 100); Console.WriteLine("я загадал число от 1 до 100."); maxValue = 100; minValue = 1; break;
                    case 2: num = rnd.Next(1, 500); Console.WriteLine("я загадал число от 1 до 500."); maxValue = 500; minValue = 1; break;
                    case 3: num = rnd.Next(1, 1000); Console.WriteLine("я загадал число от 1 до 1000."); maxValue = 1000; minValue = 1; break;
                    case 4: num = rnd.Next(1, 1000); hardcoreCounter = 15; hardcore = true; Console.WriteLine("я загадал число от 1 до 1000 и у тебя есть 15 попыток чтобы угадать."); maxValue = 1000; minValue = 1; break;
                    default: Console.WriteLine("Такой сложности не существует."); break;
                }

            } while (difficult < 0 || difficult > 4);



            int enteredNum;
            bool winner = false;

            while (true)
            {
                Console.Write("Вводи число:");
                enteredNum = int.Parse(Console.ReadLine());

                if (enteredNum == -1488)
                {
                    Console.WriteLine($"Пасхалка: загаданное число {num}");
                    cheating = true;
                    continue;
                }

                if (enteredNum == num)
                {
                    Console.WriteLine("Ты угадал! Поздравляю!");
                    winner = true;
                    break;
                }
                else if (enteredNum < num)
                {

                    Console.WriteLine("Моё число больше твоего");
                    minValue = enteredNum;
                }
                else if (enteredNum > num)
                {
                    Console.WriteLine("Моё число меньше твоего");
                    maxValue = enteredNum;
                }
                if (hardcore)
                {
                    hardcoreCounter--;
                    Console.WriteLine($"Загаданное число в промежутке от {minValue} до {maxValue}. Осталось {hardcoreCounter} попыток.");
                    if (hardcoreCounter == 0)
                    {
                        Console.WriteLine("");
                        break;
                    }
                }
            }
            if (winner)
            {
                if (hardcore)
                {
                    if (cheating)
                    {
                        Console.WriteLine("Читерить плохо!");
                    }
                    else if (hardcoreCounter == 15)
                    {
                        Console.WriteLine("Твой титул: Везунчик.");
                    }
                    else if (hardcoreCounter > 10)
                    {
                        Console.WriteLine("Твой титул: Безумец.");
                    }
                    else if (hardcoreCounter > 5 && hardcoreCounter < 10)
                    {
                        Console.WriteLine("Твой титул: Гений.");
                    }
                    else if (hardcoreCounter > 1 && hardcoreCounter < 5)
                    {
                        Console.WriteLine("Твой титул: Новичёк.");
                    }
                }
            }
            
            Console.ReadKey();
        }
    }
}
