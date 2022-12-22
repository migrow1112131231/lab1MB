using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Boltachev_M_Lab1
{
    internal class Person
    {

        private string first_name;
        private string last_name;
        private System.DateTime birthday;


        public Person(string name1, string name2, DateTime b)
        {
            this.first_name = name1;
            this.last_name = name2;
            this.birthday = b;
        }


        public Person()
        {
            this.first_name = "";
            this.last_name = "";
            this.birthday = new System.DateTime(0);
        }


        public string FirstName
        {

            get { return this.first_name; }
            set { this.first_name = value; }

        }


        public string SecondName
        {

            get { return this.last_name; }
            set { this.last_name = value; }

        }


        public DateTime Birthd
        {

            get { return this.birthday; }
            set {this.birthday = value;}

        }

        public int BirthdayInt
        {

            get { return (int)this.birthday.Ticks; }
            set { this.birthday = new DateTime(value); }

        }


        public override string ToString()
        {

            return "Имя: " + this.first_name + " Фамилия: " + this.last_name +" Дата рождения: " + this.birthday.ToString();

        }


        public virtual string ToShortString()
        {

            return "Имя: " + this.first_name + " Фамилия: " + this.last_name;

        }
    }
}
