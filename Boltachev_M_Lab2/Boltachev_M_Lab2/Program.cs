using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Boltachev_M_Lab2
{
    interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
    }
    enum Frequency { Weekly, Monthly, Yearly };

    public static class Shifter
    {
        public static int ShiftAndWrap(int value, int positions)
        {
            positions &= 0x1F;
            uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
            uint wrapped = number >> (32 - positions);
            return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
        }

    }


    static class Program
    {
        static void Main()
        {
            PrintPoint(1);
            Edition edition = new Edition();
            Edition edition1 = new Edition();
            Console.WriteLine(
                "Данные равны: " + (edition == edition1).ToString() +
                " Ссылка равна " + ReferenceEquals(edition, edition1).ToString() +
                "\nПервый хэш: " + edition.GetHashCode().ToString() +
                " Второй хэш: " + edition1.GetHashCode().ToString()
            );
            PrintPoint(2);
            try
            {
                edition.Circulation = -2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            PrintPoint(3);
            Magazine m = new Magazine();
            m.AddArticles(
                new Article[2] {
                    new Article (new Person("Аркадий", "Паровозов", new System.DateTime(1989, 1, 11)), "Аркадий Паровозов спешит на помощь!", 4.8),
                    new Article (new Person("Михаил", "Болтачев", new System.DateTime(2003, 11, 05)), "Кто не падал - тот не падал", 4.4)
                }
            );
            m.AddEditors(
                new Person[2] {
                    new Person("Александр", "Карпов", new System.DateTime(2003, 8, 18)),
                    new Person("Орандужэк", "Навонов", new System.DateTime(1987, 1, 11))
                }
            );
            Console.WriteLine(m.ToString());
            PrintPoint(4);
            Console.WriteLine(m.Edition.ToString());
            PrintPoint(5);
            Magazine m1 = m.DeepCopy();
            ((Article)m1.Articles[0]).title = "Изм.";
            m1.AddEditors(
                new Person[1] {
                    new Person("Иван", "Лукин", new System.DateTime(2004, 11, 1))
                }
            );
            m1.Circulation = 10;
            Console.WriteLine(m.ToString());
            Console.WriteLine(m1.ToString());
            PrintPoint(6);
            foreach (Article article in m1.GetArticlesWithRaiting(3))
                Console.WriteLine(article.ToString());
            PrintPoint(7);
            foreach (Article article in m1)
                Console.WriteLine(article.ToString());
            Console.ReadKey();
        }
        static void PrintPoint(int point)
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------\nPoint " + point.ToString() + '\n');
        }
    }
}
