using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Console;
using static System.String;

namespace GameMenu
{
    internal class Program
    {
        static void Quiz()
        {
            string[] questions =
            {
                "\nКто назвал настольный теннис пинпонгом? ",
                "\nКак называется ручное орудие для рыхления \nземли, известное еще с каменного века?",
                "\nСоком какого растения был отравлен отец Гамлета?",
                "\nЧто надо добавить в томатный сок, чтобы \nполучился коктейль \"Кровавая Мэри\"?",
                "\nУ кого из этих поэтов есть стихотворение \"Няне Пушкина\"?"
            };
            string[] answer_options =
            {
                "Англичане              Вьетнамцы   \nКитайцы               Лаосцы ",
                "Лопата                 Мотыга      \nПлуг                  Борона ",
                "Дурман                 Беладонна   \nБелена                Цикута ",
                "Ром                    Водка       \nДжин                  Виски",
                "П.А.Вяземский          Н.М.Языков  \nА.А.Дельвиг           В.К.Кюхельбекер"
            };
            string[] correct_answer =
            {
                "Англичане",
                "Мотыга",
                "Белена",
                "Водка",
                "Н.М.Языков"
            };
            string answer = "";
            do
            {
                ForegroundColor = ConsoleColor.Magenta;
                WriteLine("\n             Викторина");
                ResetColor();
                WriteLine("Ответьте на вопросы и получите максимальный балл");
                string user_answer;
                int check = 0;
                for (int i = 0; i < 5; i++)
                {
                    WriteLine(questions[i] + "\n");
                    WriteLine(answer_options[i] + "\n");
                    Write("Ответ: ");
                    user_answer = ReadLine();
                    if (correct_answer[i] == user_answer)
                    {
                        check++;
                        ForegroundColor = ConsoleColor.Green;
                        WriteLine("Правильно\n");
                        ResetColor();
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("Не правильно\n");
                        ResetColor();
                    }
                }
                WriteLine("Правильных ответов: " + check + "\n");
                WriteLine("Продолжить играть? (да или нет)");
                answer = ReadLine();
            } while (answer == "да");
            WriteLine("=============================================================");
        }
        static void GuessNumber()
        {
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine("\n             Угадай число");
            ResetColor();
            Random rand = new Random();
            int magicNumber = rand.Next(0, 100);
            int userNumber = 0;
            int exit = -1;
            int count = 0;
            string answer = "";
            do
            {
                do
                {
                    WriteLine("Введи число: ");

                    userNumber = Int32.Parse(ReadLine());
                    if (userNumber == exit)
                    {
                        return;
                    }
                    else
                    {
                        count++;
                        if (userNumber < magicNumber)
                        {
                            WriteLine("Введенное число меньше загаданного!");
                        }
                        else if (userNumber > magicNumber)
                        {
                            WriteLine("Введенное число больше загаданного!");
                        }
                        else if (userNumber == magicNumber)
                        {
                            ForegroundColor = ConsoleColor.Green;
                            Write("Верно!");
                            ForegroundColor = ConsoleColor.White;
                            WriteLine(" Загаданное число " + magicNumber);
                            WriteLine($"Тебе понадобилось {count} попыток");
                            break;
                        }
                    }
                } while (userNumber != magicNumber);
                WriteLine("Продолжить играть? (да или нет)");
                answer = ReadLine();
            } while (answer == "да");
            WriteLine("=============================================================");
        }
        static void GameMenu()
        {
            string answer = "";
            do
            {
                ForegroundColor = ConsoleColor.Magenta;
                WriteLine("\n             Меню игр\n");
                ForegroundColor = ConsoleColor.White;
                WriteLine("Выбирите, в какую игру будем играть\n");
                WriteLine("Викторина               Угадай число");
                Write("Выбор: ");
              
                string str = ReadLine();
                switch (str)
                {
                    case "Викторина":
                        WriteLine("-------------------------------------------------------------");
                        Quiz();
                        break;
                    case "Угадай число":
                        WriteLine("-------------------------------------------------------------");
                        GuessNumber();
                        break;
                }   
                WriteLine("Выйти из меню? (да или нет)");
                answer = ReadLine();
            } while (answer == "нет");
            WriteLine("-------------------------------------------------------------");
        }
        static void Main(string[] args)
        {
            GameMenu();
        }
    }
}
