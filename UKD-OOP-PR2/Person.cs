using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKD_OOP_PR2
{
    public class Person
    {
        public string name;
        public DateTime creationDate;
        public List<Language> languages = new();
        public List<Hobby> hobbies = new();
        public Contacts contactInfo;  
        public Finance financialInfo = new();


        public Person(string _name, List<Language> _languages, List<Hobby> _hobbies, Contacts _contactInfo)
        {
            name = _name;
            creationDate = DateTime.Today;
            languages = _languages;
            hobbies = _hobbies;
            contactInfo = _contactInfo;
        }
    }
}
