//Погудин Павел 2 исп
//Практическая работа №17
using System;
using System.Xml.Linq;

namespace PR_17
{
    class SportsSection
    {
        private string name;
        private string coach;
        private int numberOfParticipants;
        private int level = 1000;
        public SportsSectionpublic SportsSection(int numberOfParticipants, string coach, string name)
        {
            this.numberOfParticipants = numberOfParticipants;
            this.coach = coach;
            this.name = name;
            Output();
        }
        {
            this.numberOfParticipants = numberOfParticipants;
            this.coach = coach;
            this.name = name;
            Output();
        }
        protected void Output()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\tНазвание спортивной секции: " + name);
            Console.WriteLine("\tИмя тренера: " + coach);
            Console.WriteLine("\tКоличество участников: " + numberOfParticipants);
            Console.ForegroundColor = ConsoleColor.White;
            Work();
        }
        protected void Work()
        {
            if (numberOfParticipants >= level)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tЭта секция уже vip");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\tосталось ");
                Console.Write(level - numberOfParticipants);
                Console.WriteLine(" человек");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("\tЗдравствуйте!");
            bool stop1 = false;
            while (!stop1)
            {
                int numberOfParticipants = 0;
                bool stop = false;
                while (!stop)
                {
                    try
                    {
                        Console.Write("Введите количество участников: ");
                        numberOfParticipants = Convert.ToInt32(Console.ReadLine());
                        stop = true;
                    }
                    catch
                    {
                        stop = false;
                    }
                }
                Console.Write("Введите название спортивной секции: ");
                string name = Console.ReadLine();
                Console.Write("Введите имя тренера: ");
                string coach = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("\tЗдравствуйте!");
                Console.Title = "Практическая работа №17";
                SportsSection section = new SportsSection(numberOfParticipants, coach, name);
                Console.WriteLine("Если хотите закончить нажмите Y");
                string String = Console.ReadLine();
                if (String == "Y")
                    stop = true;
            }
        }
    }
}
/*ввод
 * 100
 * ель
 * иван
 * ответ
 * Здравствуйте!
 *       Название спортивной секции: ель
 *       Имя тренера: иван
 *       Количество участников: 100
 *       осталось 900 человек
 * ввод
 * Y
 */