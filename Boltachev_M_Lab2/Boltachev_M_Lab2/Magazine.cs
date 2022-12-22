using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Boltachev_M_Lab2
{
    class Magazine : Edition, IRateAndCopy, IEnumerable
    {
        private Frequency frequency;
        private ArrayList articles;
        protected ArrayList editors;
        public Magazine(
            string name,
            Frequency frequency,
            DateTime release_time,
            int circulation
        ) : base(name, release_time, circulation)
        {
            this.frequency = frequency;
            this.articles = new ArrayList();
            editors = new ArrayList();
        }

        public Magazine() : base()
        {
            this.frequency = Frequency.Weekly;
            this.articles = new ArrayList();
            editors = new ArrayList();
        }

        public Edition Edition
        {
            get { return new Edition(name, release_time, circulation); }
            set
            {
                this.name = value.Name;
                this.release_time = value.ReleaseTime;
                this.circulation = value.Circulation;
            }
        }
        public double MeanRaiting
        {
            get
            {
                if (this.Articles.Count == 0)
                    return 0;
                double sum = 0;
                foreach (Article article in this.Articles)
                    sum += article.rait;
                return sum / this.Articles.Count;
            }
        }
        public bool CheckFrequency(Frequency value)
        {
            return value == this.frequency;
        }

        public void AddArticles(Object[] new_articles)
        {
            this.Articles.AddRange(new_articles);
        }
        public void AddEditors(Object[] new_redactors)
        {
            this.editors.AddRange(new_redactors);
        }
        public new Magazine DeepCopy()
        {
            Magazine magazine = new Magazine(this.name, this.frequency, this.release_time, this.circulation);
            magazine.AddArticles(this.articles.ToArray().Select(a => ((IRateAndCopy)a).DeepCopy()).ToArray());
            magazine.AddEditors(this.editors.ToArray().Select(a => ((Person)a).DeepCopy()).ToArray());
            return magazine;
        }
        object IRateAndCopy.DeepCopy()
        {
            Magazine magazine = new Magazine(this.name, this.frequency, this.release_time, this.circulation);
            magazine.AddArticles(this.articles.ToArray().Select(a => ((IRateAndCopy)a).DeepCopy()).ToArray());
            magazine.AddEditors(this.editors.ToArray().Select(a => ((Person)a).DeepCopy()).ToArray());
            return magazine;
        }
        double IRateAndCopy.Rating => this.MeanRaiting;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public MagazineEnumerator GetEnumerator()
        {
            return new MagazineEnumerator(this.editors, this.articles);
        }

        public IEnumerable<Article> GetArticlesWithRaiting(double raiting)
        {
            foreach (Article article in this.articles)
            {
                if (article.rait > raiting)
                    yield return article;
            }
        }
        public IEnumerable<Article> GetArticlesWithStr(string str)
        {
            foreach (Article article in this.articles)
            {
                if (article.title.Contains(str))
                    yield return article;
            }
        }
        public IEnumerable<Article> GetArticlesWithAuthorIsEditor()
        {
            foreach (Article article in this.articles)
                if (this.editors.Contains(article.author))
                    yield return article;
        }

        public IEnumerable<Person> GetEditorIsNotAuthors()
        {
            foreach (Person person in this.editors)
                foreach (Article article in this.articles)
                    if (article.author == person)
                        yield return person;
        }

        public virtual string ToShortString()
        {
            return "Имя: " + this.name +
                    " frequency: " + this.frequency.ToString() +
                    " Дата выхода: " + this.release_time.ToString() +
                    " тираж: " + this.circulation.ToString() +
                    " рейтинг: " + this.MeanRaiting.ToString();
        }

        public override string ToString()
        {
            string res = (
                "Имя: " + this.name +
                " frequency: " + this.frequency.ToString() +
                " Дата выхода: " + this.release_time.ToString() +
                " тираж: " + this.circulation.ToString() +
                "\nСтатьи:\n"
            );
            if (this.articles.Count == 0)
                res += "Нет статей";
            else
                foreach (Article article in this.articles)
                {
                    res += article.ToString() + '\n';
                }
            res += "Редакторы:\n";
            if (this.editors.Count == 0)
                res += "Нет редакторов";
            else
                foreach (Person redactor in this.editors)
                {
                    res += redactor.ToString() + '\n';
                }
            return res;
        }

        public Frequency Frequency
        {
            get { return this.frequency; }
            set { this.frequency = value; }
        }

        public ArrayList Articles
        {
            get { return this.articles; }
            set { this.articles = value; }
        }
    }
    class MagazineEnumerator : IEnumerator
    {
        public List<Article> people;
        private int position = -1;

        public MagazineEnumerator(ArrayList editors, ArrayList articles)
        {
            this.people = new List<Article>();
            foreach (Article article in articles)
            {
                if (!editors.Contains(article.author))
                    this.people.Add(article);
            }
        }

        public object Current
        {
            get
            {
                try
                {
                    return people[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < people.Count);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
