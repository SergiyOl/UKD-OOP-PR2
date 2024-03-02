using System;
using System.Collections.Generic;

namespace UKD_OOP_PR2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Створення бази даних
            PersonDataBase dataBase = new();

            //Створення анкет
            dataBase.AddPerson(new Person("Oleg", //Ім'я
                                          new List<Language> {new Language("English", "B1", "in progres")}, //Мови
                                          new List<Hobby> {new Hobby("Learning english", 30, 5)}, //Хоббі
                                          new Contacts(new List<string> {"olegmail@gmail.com"}, //Пошти
                                                       new List<Phone> {new Phone("+0999673914", "Vodaphone", 140), 
                                                                        new Phone("+0659283091", "Kyivstar", 150)}) //Телефони
                                          ));
            dataBase.AddPerson(new Person("Josh", //Ім'я
                                          new List<Language> {new Language("Ukrainian", "C2", "done"),
                                                              new Language("English", "B2", "in progres")}, //Мови
                                          new List<Hobby> {new Hobby("Playing games", 60, 1), 
                                                           new Hobby("Stydying IT", 120, 5)}, //Хоббі
                                          new Contacts(new List<string> { "joshmail@gmail.com" }, //Пошти
                                                       new List<Phone> { new Phone("+0996782364", "Vodaphone", 120) }) //Телефони
                                          ));
            dataBase.AddPerson(new Person("Vasil", //Ім'я
                                          new List<Language> {new Language("English", "B1", "in progres"), 
                                                              new Language("Spanish", "A2", "paused")}, //Мови
                                          new List<Hobby> { new Hobby("Reading books", 45, 2), 
                                                            new Hobby("Learning spanish", 60, 2)}, //Хоббі
                                          new Contacts(new List<string> { "vasilmail@gmail.com" }, //Пошти
                                                       new List<Phone> { new Phone("+0651396513", "Kyivstar", 145) }) //Телефони
                                          ));

            //Запис фінансів
            dataBase.allPerson.Find(x => x.name == "Oleg").financialInfo.addFinancialArticle("Programing courses", 1200, new DateTime(2024, 3, 4));
            dataBase.allPerson.Find(x => x.name == "Oleg").financialInfo.addFinancialArticle("Games", 270.40, new DateTime(2024, 3, 15));
            dataBase.allPerson.Find(x => x.name == "Oleg").financialInfo.addFinancialArticle("English courses", 1200, new DateTime(2024, 4, 1));
            dataBase.allPerson.Find(x => x.name == "Oleg").financialInfo.addFinancialArticle("Bus ticket", 65, new DateTime(2024, 4, 5));

            //Тестування
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
            /*Console.WriteLine(dataBase.allPerson.Find(x => x.name == "Oleg").contactInfo.MinMaxPhoneCost(true));*/

            foreach (var item in dataBase.MinMaxMultiplePersonPhoneCost(2, true))
            {
                Console.WriteLine(item.name);
            }
            Console.WriteLine(dataBase.allPerson.Find(x => x.name == "Oleg").financialInfo.CalculateSpentMoneyPerMonth(3, 2024));

            Console.ReadLine();
        }
    }
}
