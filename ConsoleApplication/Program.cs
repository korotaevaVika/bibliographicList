using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string output;
            List<IEdition> inputEditions = new List<IEdition>();
            IEdition edition;

            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                if (inputEditions.Count > 0)
                {
                    Console.WriteLine("Текущий список изданий: ");
                    foreach (IEdition x in inputEditions)
                    {
                        Console.WriteLine(x.GetStandartName() + "\n");
                    }
                }
                else
                {
                    Console.WriteLine("Текущий список изданий пуст");
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Введите\n\t1 - чтобы завести книгу"
                    + "\n\t2 - чтобы завести диссертацию"
                    + "\n\tq - чтобы выйти из программы\n");
                Console.ForegroundColor = ConsoleColor.White;

                output = Console.ReadLine();
                if (output == "q")
                    break;
                Console.Clear();

                switch (output)
                {
                    case "1":
                        edition = null;
                        while (edition == null)
                        {
                            try { edition = CreateBook(); }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка!\n"
                                    + ex.Message + "\n");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }

                        inputEditions.Add(edition);
                        Console.Clear();
                        Console.WriteLine("Книга создана!\n\n");
                        break;

                    case "2":
                        edition = null;
                        while (edition == null)
                        {
                            try { edition = CreateDissertation(); }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка!\n"
                                    + ex.Message + "\n");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }

                        inputEditions.Add(edition);
                        Console.Clear();
                        Console.WriteLine("Диссертация создана!\n\n");
                        break;

                    default: Console.WriteLine("Неверный символ"); break;
                }
            }
        }

        private static Dissertation CreateDissertation()
        {
            Console.WriteLine("Создание диссертации\n");

            Person author = CreateAuthor();
            Console.WriteLine();

            Dissertation disser = null;
            while (disser == null)
            {
                disser = new Dissertation
                {
                    Title = GetUserInput("заголовок диссертации"),
                    Year =
                        Convert.ToInt16(GetUserInput("год публикации")),
                    NumPages =
                        Convert.ToInt16(GetUserInput("кол-во страниц")),
                    University = GetUserInput("название вуза"),
                    Degree = GetUserInput("ученую степень"),
                    SpecialityCode = GetUserInput("код специальности"),
                    City = GetUserInput("город"),
                    Authors = new List<Person> { author }
                };
            }
            return disser;
        }

        private static Person CreateAuthor()
        {
            Person p = null;
            while (p == null)
            {
                Console.WriteLine("Создание автора: ");
                p = new Person
                {
                    SecondName = GetUserInput("фамилию"),
                    FirstName = GetUserInput("имя"),
                    Patronymic = GetUserInput("отчество")
                };
            }
            return p;
        }

        private static Book CreateBook()
        {
            List<Person> authors = new List<Person>();
            Person author;
            int authorsCount;

            Console.WriteLine("Создание книги\n");

            authorsCount =
                Convert.ToInt16(GetUserInput("количество авторов"));

            while (authorsCount > 0)
            {
                Console.WriteLine();
                author = CreateAuthor();
                authors.Add(author);
                authorsCount--;
            }
            Console.WriteLine();

            Book book = null;
            while (book == null)
            {
                try
                {
                    book = new Book
                    {
                        Title = GetUserInput("название"),
                        PublishingHouse = GetUserInput("название издательства"),
                        City = GetUserInput("город"),
                        Year = Convert.ToInt16(GetUserInput("год публикации")),
                        Authors = authors,
                        NumPages = Convert.ToInt16(GetUserInput("кол-во страниц")),
                        Language = (LanguageMode)Convert.ToInt16(
                          GetUserInput("0, если язык русский, иначе 1"))
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка!\n" + ex.Message + "\n");
                    return null;
                }
            }
            return book;

        }
        private static string GetUserInput(string name)
        {
            Console.Write("Введите {0}: ", name);
            return Console.ReadLine();
        }
    }
}
