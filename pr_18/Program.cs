//Погудин Павел 2 исп
//Практическая работа №18
using System;
using System.Xml.Linq;

namespace PR_18
{
    class SportsSection
    {
        protected string name;
        protected string coach;
        protected int numberOfParticipants;
        private int level = 1000;
        public SportsSection(int numberOfParticipants, string coach, string name)
        {
            this.numberOfParticipants = numberOfParticipants;
            this.coach = coach;
            this.name = name;
        }
    }
    class SportsSection_one: SportsSection
    {
        public SportsSection_one(int numberOfParticipants, string coach, string name):base(numberOfParticipants, coach, name)
        { }
        ~SportsSection_one();
    }
    class SportsSection_two : SportsSection
    {
        public SportsSection_two(int numberOfParticipants, string coach, string name) : base(numberOfParticipants, coach, name)
        { }
        ~SportsSection_two() { }
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
                SportsSection_one section = new SportsSection_one(numberOfParticipants, coach, name);
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