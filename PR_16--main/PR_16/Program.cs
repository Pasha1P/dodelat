//Погудин Павел Денисович 2исп
//практическая работа №16
using System;
using System.IO;
class Program
{
    struct Errors
    {
        public void DirectoryNotFoundException(string dnfe)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("не удается найти часть файла или каталога.  Ошибка " + dnfe);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void OverflowException(string oe)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("переполнение памяти.  Ошибка " + oe);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void UnauthorizedAccessException(string uae)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ошибка ввода-вывода или особого типа ошибки безопасности.  Ошибка " + uae);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ArgumentOutOfRangeException(string aoore)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ошибка ввода-вывода или особого типа ошибки безопасности.  Ошибка " + aoore);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ArgumentException(string ae)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ошибка ввода-вывода или особого типа ошибки безопасности.  Ошибка " + ae);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void FormatException(string fe)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ошибка ввода-вывода или особого типа ошибки безопасности.  Ошибка " + fe);
            Console.ForegroundColor = ConsoleColor.White;
        }        
    }
    struct Files
    {
        public void WriteLine(uint count, string name)
        {
            Errors errors = new Errors();
            try
            {
                FileStream F = new FileStream(name, FileMode.Create);//создание файлового потока
                StreamWriter Writer = new StreamWriter(F);//создание переменной потока StreamWriter и связывание её с файловым потоком
                Random rnd = new Random();
                for (int i = 0; i < count; i++)
                {
                    Writer.Write("\t");
                    Writer.WriteLine(rnd.NextDouble() * (4 + 7) - 7); //Записываем случайные числа в наш файл
                }
                Writer.Close();
            }
            catch (DirectoryNotFoundException dnfe)//Исключение, которое создается, когда не удается найти часть файла или каталога.
            {
               errors.DirectoryNotFoundException(dnfe.Message);
            }
            catch (OverflowException oe)//выполнение арифметической операции, операции приведения к типу или преобразования в проверяемом контексте приводит к переполнению
            {
                errors.OverflowException(oe.Message);
            }
            catch (UnauthorizedAccessException uae)//Исключение, возникающее в случае запрета доступа операционной системой из-за ошибки ввода-вывода или особого типа ошибки безопасности.
            {
                errors.UnauthorizedAccessException(uae.Message);
            }
            catch (ArgumentException ae)//Это исключение выбрасывается, если один из передаваемых методу аргументов является недопустимым
            {
                errors.ArgumentException(ae.Message);
            }
        }
        public void ReadLine(string x)
        {
            try
            {
                Console.WriteLine("получилось такое содержимое файла:");
                StreamReader Reader = new StreamReader(x);//создание переменной потока StreamReader и связывание её с файловым потоком
                Console.Write(Reader.ReadToEnd());
                Reader.Close();
            }
            catch (UnauthorizedAccessException) { }
            catch (DirectoryNotFoundException) { }
            catch (ArgumentException) { }
        }
        public void Arithmetic_mean(string x)
        {
            try
            {
                // Вычисляем среднее арифметическое элементов на четных позициях
                double sum = 0;
                int count = 0;
                StreamReader Reader = new StreamReader(x);//создание переменной потока StreamReader и связывание её с файловым потоком
                {
                    int lineNumber = 1;
                    string line;
                    while ((line = Reader.ReadLine()) != null)
                    {
                        if (lineNumber % 2 == 0)
                        {
                            double number = double.Parse(line);
                            sum += number;
                            count++;
                        }
                        lineNumber++;
                    }
                }
                Reader.Close();
                double average = sum / count;
                // Выводим среднее арифметическое на четных позициях
                Console.WriteLine("Среднее арифметическое элементов на четных позициях: " + average);
            }
            catch (UnauthorizedAccessException) { }
            catch (DirectoryNotFoundException) { }
            catch (ArgumentException) { }
        }
    }
    static void Main()
    {
        Errors errors = new Errors();
        uint count = 1;
        bool stop = true;
        bool stop1 = true;
        Console.WriteLine("Здравствуйте!");
        while (stop1)
        {
            while (stop)
            {
                Console.Clear();
                Console.Write("/tЗдравствуйте!");
                try
                {
                    Console.Write("ведите количество чисел ");
                    count = Convert.ToUInt32(Console.ReadLine());
                    stop = false;
                }
                catch (ArgumentOutOfRangeException aoore)//значение аргумента не соответствует допустимому диапазону значений, установленному вызванным методом.
                {
                    errors.ArgumentOutOfRangeException(aoore.Message);
                }
                catch (OverflowException oe)//выполнение арифметической операции, операции приведения к типу или преобразования в проверяемом контексте приводит к переполнению
                {
                    errors.OverflowException(oe.Message);
                }
                catch (ArgumentException ae)//Это исключение выбрасывается, если один из передаваемых методу аргументов является недопустимым
                {
                    errors.ArgumentException(ae.Message);
                }
                catch (FormatException fe)//Исключение, которое возникает в случае, если формат аргумента недопустим или строка составного формата построена неправильно.
                {
                    errors.FormatException(fe.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("ведите ПОЛОЖИТЕЛЬНОЕ ЧИСЛО");
                    stop = true;
                }
            }
            stop = true;
            Console.Write("ведите полное имя файла ");
            string name = Console.ReadLine();
            Files F = new Files();
            F.WriteLine(count, name);
            F.ReadLine(name);
            F.Arithmetic_mean(name);
            Console.Write("если хотите закончить нажмите Y ");
            string String = Console.ReadLine();
            if (String == "Y")
                stop1 = false;
        }
    }
}
/*ввод
 * 9
 * D:\Users\1213-14\Documents\2-ИСП\Основы программирования\Погудин\PR_16--main\1234567890987654321txt.txt
 * ответ
 * получилось такое содержимое файла:
 *       -0,271338529079845
 *       -0,253397538444678
 *       -4,00390377873737
 *       -2,39487634803861
 *       0,0871521262857842
 *       -4,35063288842823
 *       0,657402308032569
 *       3,62211561045708
 *       1,73059296176331
 *Среднее арифметическое элементов на четных позициях: -0,844197791113609
 *ввод
 *Y
 */