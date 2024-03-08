using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

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
                                          new List<Language> {new Language("Ukrainian", "C2", "done"), 
                                                              new Language("English", "B1", "in progres")}, //Мови
                                          new List<Hobby> {new Hobby("Learning english", 60, 5), 
                                                           new Hobby("Playing board games", 40, 1)}, //Хоббі
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
            //Показ всіх анкет
            Console.WriteLine("Всі анкети");
            foreach (Person item in dataBase.allPerson)
            {
                Console.WriteLine(item.name);
            }
            //Показ повної анкети
            Console.WriteLine("");
            Console.WriteLine("Анкета студента Oleg");
            Person questionnare = dataBase.allPerson.Find(x => x.name == "Oleg");
            Console.WriteLine($"Ім'я студента: {questionnare.name}");
            Console.WriteLine($"Дата створення анкети: {questionnare.creationDate}");
            Console.WriteLine("Вивчені мови:");
            foreach (var item in questionnare.languages)
            {
                Console.WriteLine($"Мова: {item.lang}");
                Console.WriteLine($"Рівень: {item.level}");
                Console.WriteLine($"Статус: {item.status}");
            }
            Console.WriteLine("Всі захоплення:");
            foreach (var item in questionnare.hobbies)
            {
                Console.WriteLine($"Захоплення: {item.activity}");
                Console.WriteLine($"Затрачений час (хв): {item.timeTaken}");
                Console.WriteLine($"Цінність для IT (від 1 до 5): {item.usefullnessForIT}");
            }
            Console.WriteLine("Контактна інформація:");
            Console.WriteLine("Електронні пошти:");
            foreach (var item in questionnare.contactInfo.emailAdresses)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine("Номери телефонів:");
            foreach (var item in questionnare.contactInfo.phoneNumbers)
            {
                Console.WriteLine($"Номер: {item.number}");
                Console.WriteLine($"Мобільний оператор: {item.mobileOperator}");
                Console.WriteLine($"Плата за місяць (грн): {item.costPerMonth}");
            }
            Console.WriteLine("Фінансова інформація:");
            Console.WriteLine("Всі виттрати:");
            foreach (var item in questionnare.financialInfo.financialArticles)
            {
                Console.WriteLine($"Назва: {item.name}");
                Console.WriteLine($"Використані кошти (грн): {item.cost}");
                Console.WriteLine($"Дата витрати: {item.creationDate}");
            }
            //Тестування методів
            Console.WriteLine("");
            Console.WriteLine("Тестування методів");

            Console.WriteLine("AllUsedLanguages:");
            foreach (var lang in dataBase.AllUsedLanguages())
            {
                Console.WriteLine(lang);
            }

            Console.WriteLine("SpecificLanguageUsage (English):");
            Console.WriteLine(dataBase.SpecificLanguageUsage("English"));
            Console.WriteLine("SpecificLanguageUsage (Japanese):");
            Console.WriteLine(dataBase.SpecificLanguageUsage("Japanese"));

            Console.WriteLine("SpecificLanguageLevelUsage (English, B1):");
            Console.WriteLine(dataBase.SpecificLanguageLevelUsage("English", "B1"));
            Console.WriteLine("SpecificLanguageLevelUsage (Japanese, B1):");
            Console.WriteLine(dataBase.SpecificLanguageLevelUsage("Japanese", "B1"));

            Console.WriteLine("PersonPhoneCost (Oleg) (isMax = true):");
            Console.WriteLine(dataBase.allPerson.Find(x => x.name == "Oleg").contactInfo.SummaryPhoneCost());

            Console.WriteLine("MinMaxMultiplePersonPhoneCost (2, true):");
            foreach (var item in dataBase.MinMaxMultiplePersonPhoneCost(2, true))
            {
                Console.WriteLine(item.name);
            }
            Console.WriteLine("MinMaxMultiplePersonPhoneCost (2, false):");
            foreach (var item in dataBase.MinMaxMultiplePersonPhoneCost(2, false))
            {
                Console.WriteLine(item.name);
            }
            Console.WriteLine("MinMaxMultiplePersonPhoneCost (0, true):");
            foreach (var item in dataBase.MinMaxMultiplePersonPhoneCost(0, true))
            {
                Console.WriteLine(item.name);
            }

            Console.WriteLine("CalculateSpentMoneyPerMonth (3, 2024):");
            Console.WriteLine(dataBase.allPerson.Find(x => x.name == "Oleg").financialInfo.CalculateSpentMoneyPerMonth(3, 2024));
            Console.WriteLine("CalculateSpentMoneyPerMonth (4, 2024):");
            Console.WriteLine(dataBase.allPerson.Find(x => x.name == "Oleg").financialInfo.CalculateSpentMoneyPerMonth(4, 2024));
            Console.WriteLine("CalculateSpentMoneyPerMonth (5, 2024):");
            Console.WriteLine(dataBase.allPerson.Find(x => x.name == "Oleg").financialInfo.CalculateSpentMoneyPerMonth(5, 2024));

            //Присвоєння студентам курсовиі роботи
            dataBase.RandomAssignCouseWork(@"..\..\..\AllCourseWork.txt");
            foreach (var item in dataBase.allPerson)
            {
                Console.WriteLine(item.name);
                Console.WriteLine(item.assignedCourseWork);
            }

            dataBase.CreateTxtFileWithCouseWorkAssignments(@"..\..\..\AssignedCourseWork.txt");

            Console.ReadLine();
        }
    }
}
