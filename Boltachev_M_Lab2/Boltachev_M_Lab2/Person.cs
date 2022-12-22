using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boltachev_M_Lab2
{
    internal class Person
    {
        private string first_name;
        private string last_name;
        private System.DateTime birthday;

        public Person()
        {
            this.first_name = "";
            this.last_name = "";
            this.birthday = new System.DateTime(0);
        }

        public Person(string name1, string name2, DateTime b)
        {
            this.first_name = name1;
            this.last_name = name2;
            this.birthday = b;
        }

        public Person DeepCopy()
        {
            return new Person(this.first_name, this.last_name, this.birthday);
        }

        public override int GetHashCode()
        {
            return (
                Shifter.ShiftAndWrap(this.birthday.GetHashCode(), 4) ^
                Shifter.ShiftAndWrap(this.last_name.GetHashCode(), 2) ^
                this.first_name.GetHashCode()
            );
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Person))
                return false;
            Person person = (Person)obj;
            return (
                this.first_name.Equals(person.Name) &&
                this.last_name.Equals(person.SecondName) &&
                this.birthday.Equals(person.Dr)
            );
        }

        public static bool operator ==(Person first, Person second)
        {
            return first.Name == second.Name && first.SecondName == second.SecondName && first.Dr == second.Dr;
        }

        public static bool operator !=(Person first, Person second)
        {
            return !(first == second);
        }

        public string Name
        {
            get { return this.first_name; }
            set { this.first_name = value; }
        }

        public string SecondName
        {
            get { return this.last_name; }
            set { this.last_name = value; }
        }

        public DateTime Dr
        {
            get { return this.birthday; }
            set { this.birthday = value; }
        }

        public int DrInt
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
