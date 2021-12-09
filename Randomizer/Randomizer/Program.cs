using System;
using System.Linq;
using System.IO;

namespace Randomizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string writePath = @"C:\Users\User\Documents\GitHub\Randomizer\log.txt";
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Программа запущена");
                }
           

            Random rnd = new Random();
            Console.WriteLine("Введите кол-во боченков");
            int N;
            back:
            try                                                      // првоерка на корректность ввода
            {
                N = Convert.ToInt32(Console.ReadLine());

            }
            catch
            {
                Console.WriteLine("Неверный ввод попробуйте снова");
                goto back;
            }
            
            int[] a = new int[N];                                       // создание массива и его заполнене числами по порядку
            for (int i = 0; i < N; i++) 
            {
                a[i] = i;
            }

            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine("Число боченков - " + N);
            }

            a = a.OrderBy(x => rnd.Next()).ToArray();                // перемешивание массива

            Console.WriteLine("Нажимайте любую клавишу, чтобы вытащить следующий боченок");
            for (int i = 0; i < N; i++)                            //вывод массива
            {
                Console.ReadKey();
                Console.WriteLine(a[i]);
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Число " + i + " - " + a[i]);
                }
            }

            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine("Программа завершила работу");
            }
        }
    }
}
