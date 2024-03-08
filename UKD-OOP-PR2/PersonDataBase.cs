using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public void RandomAssignCouseWork(string filePath)
        {
            Random rnd = new Random();
            List<string> courseWorkList = File.ReadAllLines(filePath).ToList();
            List<string> personList = new();
            foreach (var item in allPerson)
            {
                personList.Add(item.name);
            }
            Console.WriteLine("Введіть символ + щоб присвоїти випадкову курсову роботу випадковому студенту (введіть - щоб припинити присвоєння)");
            while (courseWorkList.Count != 0 && personList.Count != 0)
            {
                string input = Console.ReadLine();
                if (input == "+")
                {
                    int rndPersonId = rnd.Next(0, personList.Count);
                    int rndConrseWorkId = rnd.Next(0, courseWorkList.Count);
                    allPerson.Find(x => x.name == personList[rndPersonId]).assignedCourseWork = courseWorkList[rndConrseWorkId];
                    Console.WriteLine($"Студенту {personList[rndPersonId]} присвоєна курсова робота {courseWorkList[rndConrseWorkId]}, залишилось кусових робіт: {courseWorkList.Count - 1}, та студентів: {personList.Count - 1}");
                    personList.RemoveAt(rndPersonId);
                    courseWorkList.RemoveAt(rndConrseWorkId);
                }
                else if (input == "-")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Введено неправилний символ");
                }
            }
            if (personList.Count != 0)
            {
                string message = $"Даним студентам не була присвоєна курсова робота: ({personList.Count}) ";
                foreach (var item in personList)
                {
                    if (personList.First() == item)
                    {
                        message += item;
                    }
                    else
                    {
                        message += $", {item}";
                    }
                }
                Console.WriteLine(message);
            }
        }
        
        public void CreateTxtFileWithCouseWorkAssignments(string filePath)
        {
            string text = "Студенти яким присвоєні курсові роботи:\n";
            List<string> notAssigned = new();
            foreach(var item in allPerson)
            {
                if (item.assignedCourseWork == null)
                {
                    notAssigned.Add(item.name);
                }
                else
                {
                    text += $"{item.name} => {item.assignedCourseWork}\n";
                }
            }
            if (notAssigned.Count != 0)
            {
                text += "\nСтуденти яким не було присвоєно робіт:\n";
                foreach (var item in notAssigned)
                {
                    text += $"{item}\n";
                }
            }
            File.WriteAllText(filePath, text);
            Console.WriteLine("Файл створено");
        }
    }
}
