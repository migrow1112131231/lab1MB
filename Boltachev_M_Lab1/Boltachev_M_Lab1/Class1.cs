using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;



namespace Boltachev_M_Lab1
{

    class Magazine
    {

        private string name;
        private Frequency frequency;
        private System.DateTime release_date;
        private int circul;
        private Article[] articles;
     

        public Magazine(
            string name,
            Frequency frequency,
            DateTime release_date,
            int circul
        )
        {
            this.name = name;
            this.frequency = frequency;
            this.release_date = release_date;
            this.circul = circul;
            this.articles = new Article[0];
        }

        public Magazine()
        {
            this.name = "";
            this.frequency = Frequency.Weekly;
            this.release_date = new System.DateTime(0);
            this.circul = 0;
            this.articles = new Article[0];
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public Frequency Frequency
        {
            get { return this.frequency; }
            set { this.frequency = value; }
        }
        public DateTime ReleaseTime
        {
            get { return this.release_date; }
            set
            {
                this.release_date = value;
            }
        }
        public int Circulation
        {
            get { return this.circul; }
            set { this.circul = value; }
        }
        public Article[] Articles
        {
            get { return this.articles; }
            set { this.articles = value; }
        }
        public double MeanRaiting
        {
            get
            {
                if (this.Articles.Length == 0)
                    return 0;
                return this.Articles.Sum(a => a.rating) / this.Articles.Length;}
        }
        public bool CheckFrequency(Frequency value)
        {
            return value == this.frequency;
        }

        public void AddArticles(Article[] new_articles)
        {
            int len = this.articles.Length;
            Array.Resize(ref this.articles, this.articles.Length + new_articles.Length);
            for (int i = 0; i < new_articles.Length; ++i)
            {
                this.articles[len + i] = new_articles[i];
            }
        }
        public override string ToString()
        {
            string result = ("Имя: " + this.name + " frequency: " + this.frequency.ToString() + " Дата выхода: " + this.release_date.ToString() + " Тираж: " + this.circul.ToString() + " Статьи:\n");
            if (this.articles.Length == 0)
                result += "Нет статей";
            else
                foreach (Article article in this.articles)
                {
                    result += article.ToString() + '\n';
                }
            return result;
        }
        public virtual string ToShortString()
        {
            return "Имя: " + this.name + " frequency: " + this.frequency.ToString() + " Дата выхода: " + this.release_date.ToString() + " Тираж: " + this.circul.ToString() + " Рейтинг: " + this.MeanRaiting.ToString();
        }
    }
}
