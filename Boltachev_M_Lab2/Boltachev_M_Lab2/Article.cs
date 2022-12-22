using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boltachev_M_Lab2
{
    class Article : IRateAndCopy
    {
        public Person author;
        public string title;
        public double rait;

        public Article()
        {
            this.author = new Person();
            this.rait = 0;
            this.title = "";
        }

        public Article(Person author, string title, double rait)
        {
            this.author = author;
            this.title = title;
            this.rait = rait;
        }

        public override string ToString()
        {
            return "Титул: " + this.title +
                " рейтинг: " + this.rait.ToString() +
                " Инфо автор: " + this.author.ToString();
        }

        double IRateAndCopy.Rating => this.rait;

        object IRateAndCopy.DeepCopy()
        {
            return new Article(this.author.DeepCopy(), this.title, this.rait);
        }

    }
}
