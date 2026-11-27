using System;
using System.Diagnostics;
namespace Pro
{
    class Programа
    {
        private static double ConsReadNum()
        {
            double rez = 0;
            while (!double.TryParse(Console.ReadLine(), out rez))
            {
                Console.WriteLine("Вы ввели некоректное значение. Попробуйте снова");
            }
            return rez;
        }
        private static double NumMenu()
        {
            Console.Write("Введите номер желаемоемого действия:\n1.Отгадай ответ\n2.Об авторе\n3.Сортировка массива\n4.Выход\n");
            double o = ConsReadNum();
            return o;
        }
        private static double MathFun()
        {
            double rez = 0;
            Console.Write("Введите число a (градус угла):");
            double r = 0.0;
            bool bi = false;
            do
            {
                r = ConsReadNum();
                double j = r * (Math.PI / 180);
                double test = Math.Cos(j);
                if (Math.Round(Math.Cos(j), 2) == 0)
                {
                    Console.WriteLine("Тригонометрические функции не существуют в данной. Попробуйте снова");
                    bi = true;
                }
                else
                    bi = false;
            } while (bi);
            double a = r * (Math.PI / 180);
            double e = Math.Sqrt(Math.Log(Math.Exp(2), 3));
            double x = Math.Sin(a) + Math.Tan(2 * a);
            rez = Math.Round(x / e, 2);
            return rez;
        }
        private static void Game()
        {
            double rez = MathFun();
            Console.Write("Напишите ответ с точностью до двух знаков после запятой:");
            int iterator = 0;
            bool isCancel = false;
            while (iterator < 3 && !isCancel)
            {
                double z=ConsReadNum();
                if (z == rez)
                {
                    Console.WriteLine("Верно! Вы молодец!");
                    isCancel = true;
                }
                else
                {
                    Console.WriteLine("Неверно. Попробуйте снова. У Вас осталось попыток:" + (3 - iterator - 1));
                    iterator++;
                }
                if (iterator == 3)
                {
                    Console.WriteLine("Вы исчерпали количество попыток. Верный ответ: " + rez);
                }
            }
        }
        private static void Inform()
        {
            Console.WriteLine("Подушкина Валерия Павловна, группа - 6104");
        }
        private static int[] BubbleSort(int[] mas1)
        {
            int f = mas1.Length;
            for (int ogr = 0; ogr < f - 1; ogr++)
            {
                    for (int i = 0; i < f - ogr - 1; i++)
                    {
                        if (mas1[i] > mas1[i + 1])
                        {
                            int n = mas1[i];
                            mas1[i] = mas1[i + 1];
                            mas1[i + 1] = n;
                        }
                    }
            }
            return mas1;
        }
        private static void ChoiceSort(int[] mas2)
        {
            int f = mas2.Length;
            for (int i = 0; i < f - 1; i++)
            {
                int min = i;
                for (int schet = i + 1; schet < f; schet++)
                {
                    if (mas2[schet] < mas2[min])
                    {
                        min = schet;
                    }
                }
                if (min != i)
                {
                    int ind = mas2[i];
                    mas2[i] = mas2[min];
                    mas2[min] = ind;
                }
            }
        }
        private static bool Exit(bool ex)
        {
            Console.WriteLine("Вы уверены что хотите выйти?\nВведите д(да) или н(нет)");
            char m = 'д';
            char l = 'н';
            char str;
            bool prav = false;
            do
            {
                while (!char.TryParse(Console.ReadLine(), out str))
                {
                    Console.WriteLine("Требуется ввести символ");
                }
                if (!(str == m || str == l))
                {
                    Console.WriteLine("Неверный символ. Попробуйте снова");
                    prav = false;
                }
                else
                { 
                    prav = true;
                }
            } while (prav == false);
            switch (str)
            {
                case 'д': { ex = true; break; }
                case 'н': { ex = false; break; }
            }
            return ex;
        }
        private static uint CheckMass()
        {
            uint n = 0;
            bool Ure = false;
            do
            {
                while (!uint.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Вы ввели некоректное значение. Попробуйте снова");
                }
                if (n > 10)
                {
                    Console.WriteLine("Массивы не могут быть выведены на экран, так как длина массива больше 10. Попробуйте снова.");
                    Ure = false;
                }
                else
                    Ure = true;
            } while (Ure == false);
            return n;
        }
        private static int[] CreateMass(uint n, int[]mass)
        {
            mass = new int[n];
            Random bn = new Random();
            for (int kl = 0; kl < n; kl++)
            {
                mass[kl] = bn.Next(-25,26);
            }
            return mass;
        }
        private static int[] CopyMass(int[] mass)
        {
            int[]masscopy = new int[mass.Length];
            Array.Copy(mass, masscopy, mass.Length);
            return masscopy;
        }
        private static void WriteMass(int[]mass)
        {
            Console.Write("Исходный массив: ");
            for (int con1 = 0; con1 < mass.Length; con1++)
            {
                if (con1 < mass.Length - 1)
                {
                    Console.Write(mass[con1] + ", ");
                }
                else
                {
                    Console.WriteLine(mass[con1]);
                }
            }
        }
        private static void SortMass()
        {
            Console.Write("Введите размер массива n: ");
            uint n = CheckMass();
            int[] mass = new int[n];
            mass = CreateMass(n, mass);
            int[] masscopy=CopyMass(mass);
            WriteMass(mass);
            var sw1 = Stopwatch.StartNew();
            int[] sortb = BubbleSort(mass);
            sw1.Stop();
            double time1 = sw1.ElapsedTicks * (1_000_000.0 / Stopwatch.Frequency);
            Console.WriteLine("Тики: "+ time1+";"+" мкс:"+sw1.Elapsed.TotalMilliseconds);
            Console.Write("Отсортированный пузырьковым методом массив: ");
            for (int con2 = 0; con2 < n; con2++)
            {
                if (con2 < n - 1)
                {
                    Console.Write(sortb[con2] + ", ");
                }
                else
                {
                    Console.WriteLine(sortb[con2]);
                }
            }
            var sw2 = Stopwatch.StartNew();
            ChoiceSort(masscopy);
            sw2.Stop();
            double time2 = sw2.ElapsedTicks * (1_000_000.0 / Stopwatch.Frequency);
            Console.Write("Отсортированный методом выбора массив: ");
            for (int con3 = 0; con3 < n; con3++)
            {
                if (con3 < n - 1)
                {
                    Console.Write(masscopy[con3] + ", ");
                }
                else
                {
                    Console.WriteLine(masscopy[con3]);
                }
            }
            if (time1 > time2)
            {
                double endtime1 = time1 - time2;
                Console.WriteLine("Сортировка выбором прошла на " + endtime1 + " микросекунд быстрее");
            }
            else
            {
                double endtime2 = time2 - time1;
                Console.WriteLine("Пузырьковая сортировка прошла на " + endtime2 + " микросекунд быстрее");
            }
        }
        static void Main()
        {
            bool t = false;
            do
            {
                double o = NumMenu();
                switch (o)
                {
                    case 1:
                        {
                            Game();
                            break;
                        }
                    case 2:
                        {
                            Inform();
                            break;
                        }
                    case 3:
                        {
                            SortMass();
                            break;
                        }
                    case 4:
                        {
                            bool ex = false;
                            t = Exit(ex);
                            break;
                        }
                    default:
                        Console.Write("Вы ввели некоретное значение. Попробуйте снова\n");
                        break;
                }
                Console.Write("Нажмите Enter");
                Console.ReadKey();
                Console.Clear();
            } while (!t);
        }
    }
}