using System;
using System.Collections.Generic;

namespace UKD_OOP_PR2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> o = new();
            o.Add("hi");
            Console.WriteLine(o.Find(x => x == "hi"));
            Console.WriteLine(o.Find(x => x == "hi") == null);
            Console.WriteLine(o.Find(x => x == "hello") == null);

            //Створення бази даних
            PersonDataBase dataBase = new();
            //Запис мов
            List<Language> olegLang = new();
            olegLang.Add(new Language("English", "B1", "in progres"));
            List<Language> joshLang = new();
            joshLang.Add(new Language("Ukrainian", "C2", "done"));
            joshLang.Add(new Language("English", "B2", "in progres"));
            List<Language> vasilLang = new();
            vasilLang.Add(new Language("English", "B1", "in progres"));
            vasilLang.Add(new Language("Spanish", "A2", "paused"));
            //Запис хоббі
            List<Hobby> olegHobby = new();
            olegHobby.Add(new Hobby("Learning english", 30, 5));
            List<Hobby> joshHobby = new();
            joshHobby.Add(new Hobby("Playing games", 60, 1));
            joshHobby.Add(new Hobby("Stydying IT", 120, 5));
            List<Hobby> vasilHobby = new();
            vasilHobby.Add(new Hobby("Reading books", 45, 2));
            vasilHobby.Add(new Hobby("Learning spanish", 60, 2));
            //Запис пошт
            List<string> olegEmails = new();
            List<string> joshEmails = new();
            List<string> vasilEmails = new();
            //Запис телефонів
            List<Phone> olegPhones = new();
            olegPhones.Add(new Phone("+0999673914", "Vodaphone", 140));
            List<Phone> joshPhones = new();
            joshPhones.Add(new Phone("+0996782364", "Vodaphone", 120));
            List<Phone> vasilPhones = new();
            vasilPhones.Add(new Phone("+0651396513", "Kyivstar", 150));
            //Запис фінансів

            //Створення анкет
            dataBase.AddPerson(new Person("Oleg", olegLang, olegHobby, new Contacts(olegEmails, olegPhones)));
            dataBase.AddPerson(new Person("Josh", joshLang, joshHobby, new Contacts(joshEmails, joshPhones)));
            dataBase.AddPerson(new Person("Vasil", vasilLang, vasilHobby, new Contacts(vasilEmails, vasilPhones)));
            //Виведення в консоль
            foreach (Person item in dataBase.allPerson)
            {
                Console.WriteLine(item.name);
            }
            foreach (var lang in dataBase.AllUsedLanguages())
            {
                Console.WriteLine(lang);
            }
            Console.WriteLine(dataBase.SpecificLanguageUsage("English"));
            Console.WriteLine(dataBase.SpecificLanguageLevelUsage("English", "B1"));
            /* Console.WriteLine(dataBase.allPerson.Find(x => x.name == "Oleg").contactInfo.MinMaxPhoneCost(true));*/

            foreach (var item in dataBase.MinMaxMultiplePersonPhoneCost(2, true))
            {
                Console.WriteLine(item.name);
            }

            Console.ReadLine();
        }
    }
}
