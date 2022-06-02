using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ7
{
    struct Employee
    {

        public Employee(int Id,  DateTime DataRegistration, string Name, int Age, int Heigh, DateTime Birthday, string PlaceBith)
        {
            this.id = Id;
            this.name = Name;
            this.age = Age;
            this.heigh = Heigh;
            this.birthday = Birthday;
            this.placeBith = PlaceBith;
            this.dataRegistration = DataRegistration;

        }

        private int id;
        private DateTime dataRegistration;
        private string name;
        private int age;
        private int heigh;
        private DateTime birthday;
        private string placeBith;

        public int Id { get { return this.id; } }

        public DateTime DataRegistration { get { return this.dataRegistration; } set { this.dataRegistration = value; } }

        public string Name { get { return this.name; } set { this.name = value; } }

        public int Age { get { return this.age; } set { this.age = value; } }

        public int Heigh { get { return this.heigh; } set { this.heigh = value; } }

        public DateTime Birthday { get { return this.birthday; } set { this.birthday = value; } }

        public string PlaceBith { get { return this.placeBith; } set { this.placeBith = value; } }


     



        public string Print()
        {
            
            return $"{this.id,2} {this.dataRegistration,10} {this.name,10} {this.age,5} {this.heigh,5} {this.birthday,15} {this.placeBith,10}";
        }

    }
}
