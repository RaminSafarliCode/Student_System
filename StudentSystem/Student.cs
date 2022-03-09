using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem
{
    public class Student
    {
        static int counter = 0;
        public Student()
        {
            this.Id = ++counter;
        }
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirhtDate { get; set; }
        public int GroupId { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Name} {Surname} {BirhtDate : dd.MM.yyyy} Group ID: {GroupId}";
        }
    }
}
