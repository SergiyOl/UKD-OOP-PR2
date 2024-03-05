using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKD_OOP_PR2
{
    public class PersonDataBase
    {
        public List<Person> allPerson = new();
        public DateTime creationDate;

        public PersonDataBase() 
        {
            creationDate = DateTime.Today;
        }

        public void AddPerson(Person _person)
        {
            allPerson.Add(_person);
        }

        public List<string> AllUsedLanguages()
        {
            List<string> langList = new();
            foreach (var person in allPerson)
            {
                foreach (var lang in person.languages)
                {
                    if (langList.Find(x => x == lang.lang) == null)
                    {
                        langList.Add(lang.lang);
                    }
                }
            }
            return langList;
        }

        public int SpecificLanguageUsage(string searchedLang)
        {
            int langUsage = 0;
            foreach (var person in allPerson)
            {
                foreach (var lang in person.languages)
                {
                    if (lang.lang == searchedLang)
                    {
                        langUsage++;
                    }
                }
            }
            return langUsage;
        }

        public int SpecificLanguageLevelUsage(string searchedLang, string searhedLevel)
        {
            int langLevelUsage = 0;
            foreach (var person in allPerson)
            {
                foreach (var lang in person.languages)
                {
                    if (lang.lang == searchedLang && lang.level == searhedLevel)
                    {
                        langLevelUsage++;
                    }
                }
            }
            return langLevelUsage;
        }

        public List<int> PersonPhoneCost(string searchedPerson)
        {
            var person = allPerson.Find(x => x.name == searchedPerson);
            if (person != null)
            {
                List<int> phoneCostList = new();
                foreach (var phone in person.contactInfo.phoneNumbers)
                {
                    phoneCostList.Add(phone.costPerMonth);
                }
                return phoneCostList;
            }
            else
            {
                Console.WriteLine("Person is not found");
                return null;
            }
        }

        public List<Person> MinMaxMultiplePersonPhoneCost(int personAmount, bool isMax)
        {
            List<Person> sortedPersonList;
            if (isMax)
                sortedPersonList = allPerson.OrderByDescending(x => x.contactInfo.SummaryPhoneCost()).ToList();
            else
                sortedPersonList = allPerson.OrderBy(x => x.contactInfo.SummaryPhoneCost()).ToList();

            if (sortedPersonList.Count > personAmount)
            {
                sortedPersonList.RemoveRange(personAmount, sortedPersonList.Count - personAmount);
            }
            return sortedPersonList; 
        }
    }
}
