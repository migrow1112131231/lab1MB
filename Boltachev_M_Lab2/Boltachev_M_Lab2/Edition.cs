using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boltachev_M_Lab2
{
    class Edition
    {
        protected string name;
        protected System.DateTime release_time;
        protected int circulation;

        public Edition()
        {
            this.name = "";
            this.release_time = new System.DateTime(0);
            this.circulation = 0;
        }

        public Edition(string name, System.DateTime release_time, int circulation)
        {
            this.name = name;
            this.release_time = release_time;
            this.circulation = circulation;
        }

        public virtual Edition DeepCopy()
        {
            return new Edition(this.name, this.release_time, this.circulation);
        }

        public override string ToString()
        {
            return (
                "Название издания: " + this.name +
                " тираж: " + this.circulation.ToString() +
                " дата издания: " + this.release_time.ToString()
            );
        }

        public override int GetHashCode()
        {
            return (
                Shifter.ShiftAndWrap(this.release_time.GetHashCode(), 4) ^
                Shifter.ShiftAndWrap(this.circulation.GetHashCode(), 2) ^
                this.name.GetHashCode()
            );
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Edition))
                return false;
            Edition edition = (Edition)obj;
            return (
                this.name.Equals(edition.name) &&
                this.circulation.Equals(edition.circulation) &&
                this.release_time.Equals(edition.release_time)
            );
        }

        public static bool operator ==(Edition edition1, Edition edition2)
        {
            return (
                edition1.ReleaseTime == edition2.ReleaseTime &&
                edition1.Circulation == edition2.Circulation &&
                edition1.Name == edition2.Name
           );
        }

        public static bool operator !=(Edition edition1, Edition edition2)
        {
            return !(edition1 == edition2);
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public System.DateTime ReleaseTime
        {
            get { return this.release_time; }
            set { this.release_time = value; }
        }

        public int Circulation
        {
            get { return this.circulation; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value >= 0");
                this.circulation = value;
            }
        }
    }
}
