using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Boltachev_M_Lab1
{
    enum Frequency
    {

        Weekly,
        Monthly,
        Yearly

    };

        class Article
        {
            public Person author;
            public string nameA;
            public double rating;

            public Article(Person author, string nameA, double rating)
            {

                this.author = author;
                this.nameA = nameA;
                this.rating = rating;

            }


            public Article()
            {

                this.author = new Person();
                this.rating = 0;
                this.nameA = "";

            }


            public override string ToString()
            {

                return "Статья: " + this.nameA + " Рейтинг: " + this.rating.ToString() + " Информация об авторе: " + this.author.ToString();

            }
        }
    }
