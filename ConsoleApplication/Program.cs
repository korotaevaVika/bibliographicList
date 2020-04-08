using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("s", "ss");
            List<int> lst = new List<int> { 2, 3, 2, 3 };
            List<Person> pp = new List<Person> { p };

            Person p1 = new Person("Федотов", "Юрий", "Владимирович");
            Person p2 = new Person("Волков", "Дмитрий", "Леонидович");
            Person p3 = new Person("Максимов", "Антон", "Потапович");
            Person p4 = new Person("Романов", "Максим", "Натанович");
            Person p5 = new Person("Шекова", "Екатерина", "Леонидовна");
            
            IEdition book1 = new Book
            {
                Title = "Методы и модели построения эмпирических производственных",
                PublishingHouseName = "Изд - во СПбГУ",
                City = "СПб.",
                PublishedYear = 1997,
                Authors = new List<Person> { p1 },
                NumPages = 220,
                Language = LanguageEnum.Russian
            };

            
            IEdition book2 = new Book
            {
                Title = "Экономика и финансы недвижимости",
                PublishingHouseName = "Изд - во СПбГУ",
                City = "СПб.",
                PublishedYear = 1999,
                Authors = new List<Person> { p2, p3, p4, p1 },
                NumPages = 186,
                Language = LanguageEnum.Russian
            };
            
            IEdition disser1 = new Dissertation
            {
                Title = "Совершенствование механизма управления некоммерческими организациями культуры в условиях переходной экономики",
                City = "СПб.",
                PublishedYear = 2002,
                Authors = new List<Person> { p5 },
                NumPages = 192,
                University = "С.-Петербург.гос.ун-т",
                Degree = "канд.экон.наук",
                SpecialityCode = "08.00.05"
            };

            List<IEdition> lst1 = new List<IEdition>
            {
                book1,
                book2,
                disser1
            };
              
            Console.OutputEncoding = Encoding.UTF8;

            lst1.ForEach(x => Console.WriteLine(x.GetStandartName()));
            
            Console.ReadKey();

        }
    }
}
