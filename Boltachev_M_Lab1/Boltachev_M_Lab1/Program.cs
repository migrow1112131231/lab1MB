using System;
using System.Collections.Generic; 
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;



namespace Boltachev_M_Lab1
{


    internal class Program 
    {
        public static void Main() 

        {
            Magazine magazine = new Magazine(
                "PlayBoy",
                Frequency.Monthly,
                new System.DateTime(2022, 10, 10),
                1111

            );


            magazine.AddArticles(
                new Article[2] { // добавляем авторов
                    new Article (new Person("Аркадий", "Паровозов", new System.DateTime(1989, 1, 11)), "Аркадий Паровозов спешит на помощь!", 4.8),
                    new Article (new Person("Михаил", "Болтачев", new System.DateTime(2003, 11, 05)), "Кто не падал - тот не падал", 4.4)
                });


            Console.WriteLine(magazine.ToString() + '\n');


            int a, b;
            Console.Write(", или . для разделения чисел: ");
            string[] input = Console.ReadLine().Split(new char[] { ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            a = Int32.Parse(input[0]);
            b = Int32.Parse(input[1]);


            Article[] first = new Article[a * b]; 
            for (int i = 0; i < a * b; ++i)
                first[i] = new Article();

            int start = Environment.TickCount; // расчитывается время на выполнение
            for (int i = 0; i < a * b; ++i)
                first[i].rating = 5;

            Console.WriteLine("1: " + (Environment.TickCount - start).ToString());

            Article[,] second = new Article[a, b];
            for (int i = 0; i < a; ++i)
                for (int j = 0; j < b; ++j)
                    second[i, j] = new Article();

            start = Environment.TickCount;
            for (int i = 0; i < a; ++i)
                for (int j = 0; j < b; ++j)
                    second[i, j].rating = 5;
            Console.WriteLine("2: " + (Environment.TickCount - start).ToString());

            int c = 1, count = a * b;

            while (count > c)
            {
                count -= c;
                c++;
            }

            Article[][] third = new Article[c][];

            for (int i = 0; i < c - 1; ++i)
            {
                third[i] = new Article[i + 1];
            }

            third[c - 1] = new Article[count];

            for (int i = 0; i < third.Length; ++i)
                for (int j = 0; j < third[i].Length; ++j)
                    third[i][j] = new Article();

            start = Environment.TickCount;
            for (int i = 0; i < third.Length; ++i)
                for (int j = 0; j < third[i].Length; ++j)
                    third[i][j].rating = 5;

            Console.WriteLine("3: " + (Environment.TickCount - start).ToString());
            Console.ReadLine();
        }
    }
}
