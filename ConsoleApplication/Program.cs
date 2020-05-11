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
					ShowInfo("Текущий список изданий: ",
						ConsoleColor.Cyan);

					foreach (IEdition x in inputEditions)
					{
						Console.WriteLine(x.StandartName + "\n");
					}
				}
				else
				{
					ShowInfo("Текущий список изданий пуст",
						ConsoleColor.Cyan);
				}

				ShowInfo("Введите\n\t1 - чтобы завести книгу"
					+ "\n\t2 - чтобы завести диссертацию"
					+ "\n\tq - чтобы выйти из программы\n");

				output = Console.ReadLine();
				if (output == "q")
					break;
				Console.Clear();

				switch (output)
				{
					case "1":
						edition = CreateBook();
						inputEditions.Add(edition);
						Console.Clear();
						ShowInfo("Книга создана!\n\n",
							ConsoleColor.Green);
						break;

					case "2":
						edition = CreateDissertation();
						inputEditions.Add(edition);
						Console.Clear();
						ShowInfo("Диссертация создана!\n\n",
							ConsoleColor.Green);
						break;

					default:
						ShowInfo("Неверный символ", ConsoleColor.Red);
						break;
				}
			}
		}

		/// <summary>
		/// Используется для создания диссертации
		/// </summary>
		/// <returns>Созданная диссертация</returns>
		private static Dissertation CreateDissertation()
		{
			Dissertation disser = new Dissertation();
			bool successEnterProperty;

			ShowInfo("Создание диссертации\n");

			Person author = CreateAuthor();
			disser.Authors = new List<Person> { author };
			Console.WriteLine();

			successEnterProperty = false;
			while (successEnterProperty == false)
			{
				try
				{
					disser.Title = GetUserInput("заголовок диссертации");
					successEnterProperty = true;
				}
				catch (Exception ex)
				{
					ShowException(ex);
				}
			}

			successEnterProperty = false;
			while (successEnterProperty == false)
			{
				try
				{
					disser.Year =
						Convert.ToInt16(GetUserInput("год публикации"));
					successEnterProperty = true;
				}
				catch (Exception ex)
				{
					ShowException(ex);
				}
			}

			successEnterProperty = false;
			while (successEnterProperty == false)
			{
				try
				{
					disser.NumPages =
						Convert.ToInt16(GetUserInput("кол-во страниц"));
					successEnterProperty = true;
				}
				catch (Exception ex)
				{
					ShowException(ex);
				}
			}

			successEnterProperty = false;
			while (successEnterProperty == false)
			{
				try
				{
					disser.University = GetUserInput("название вуза");
					successEnterProperty = true;
				}
				catch (Exception ex)
				{
					ShowException(ex);
				}
			}

			successEnterProperty = false;
			while (successEnterProperty == false)
			{
				try
				{
					disser.Degree = GetUserInput("ученую степень");
					successEnterProperty = true;
				}
				catch (Exception ex)
				{
					ShowException(ex);
				}
			}

			successEnterProperty = false;
			while (successEnterProperty == false)
			{
				try
				{
					disser.SpecialityCode =
						GetUserInput("код специальности");
					successEnterProperty = true;
				}
				catch (Exception ex)
				{
					ShowException(ex);
				}
			}

			successEnterProperty = false;
			while (successEnterProperty == false)
			{
				try
				{
					disser.City = GetUserInput("город");
					successEnterProperty = true;
				}
				catch (Exception ex)
				{
					ShowException(ex);
				}
			}

			return disser;
		}

		/// <summary>
		/// Используется для создания автора издания
		/// </summary>
		/// <returns>Автор издания</returns>
		private static Person CreateAuthor()
		{
			Person p = null;
			bool successEnterProperty;

			ShowInfo("Создание автора");
			p = new Person();

			successEnterProperty = false;
			while (successEnterProperty == false)
			{
				try
				{
					p.SecondName = GetUserInput("фамилию");
					successEnterProperty = true;
				}
				catch (Exception ex)
				{
					ShowException(ex);
				}
			}

			successEnterProperty = false;
			while (successEnterProperty == false)
			{
				try
				{
					p.FirstName = GetUserInput("имя");
					successEnterProperty = true;
				}
				catch (Exception ex)
				{
					ShowException(ex);
				}
			}

			p.Patronymic = GetUserInput("отчество");

			return p;
		}

		/// <summary>
		/// Используется для создания книжного издания
		/// </summary>
		/// <returns>Созданное издание типа "Книга"</returns>
		private static Book CreateBook()
		{
			List<Person> authors = new List<Person>();
			Person author;
			int authorsCount = 0;
			bool successEnterProperty;

			ShowInfo("Создание книги\n");
			Book book = new Book();

			successEnterProperty = false;
			while (successEnterProperty == false)
			{
				try
				{
					authorsCount =
						Convert.ToInt16(
							GetUserInput("количество авторов"));
					successEnterProperty = true;
				}
				catch (FormatException ex)
				{
					ShowException(ex);
				}
			}

			while (authorsCount > 0)
			{
				Console.WriteLine();
				author = CreateAuthor();
				authors.Add(author);
				authorsCount--;
			}
			book.Authors = authors;
			Console.WriteLine();

			successEnterProperty = false;
			while (successEnterProperty == false)
			{
				try
				{
					book.Title = GetUserInput("название");
					successEnterProperty = true;
				}
				catch (Exception ex)
				{
					ShowException(ex);
				}
			}

			successEnterProperty = false;
			while (successEnterProperty == false)
			{
				try
				{
					book.PublishingHouse =
						GetUserInput("название издательства");
					successEnterProperty = true;
				}
				catch (Exception ex)
				{
					ShowException(ex);
				}
			}

			successEnterProperty = false;
			while (successEnterProperty == false)
			{
				try
				{
					book.City =
						GetUserInput("город");
					successEnterProperty = true;
				}
				catch (Exception ex)
				{
					ShowException(ex);
				}
			}

			successEnterProperty = false;
			while (successEnterProperty == false)
			{
				try
				{
					book.Year = Convert.ToInt16(
						GetUserInput("год публикации"));
					successEnterProperty = true;
				}
				catch (Exception ex)
				{
					ShowException(ex);
				}
			}

			successEnterProperty = false;
			while (successEnterProperty == false)
			{
				try
				{
					book.NumPages = Convert.ToInt16(
						GetUserInput("кол-во страниц"));
					successEnterProperty = true;
				}
				catch (Exception ex)
				{
					ShowException(ex);
				}
			}

			successEnterProperty = false;
			while (successEnterProperty == false)
			{
				try
				{
					book.Language = (LanguageMode)Convert.ToInt16(
						GetUserInput("0, если язык русский, иначе 1"));
					successEnterProperty = true;
				}
				catch (Exception ex)
				{
					ShowException(ex);
				}
			}

			return book;
		}

		/// <summary>
		/// Запрашивает у пользователя ввод свойства
		/// </summary>
		/// <param name="name">Название свойства</param>
		/// <returns></returns>
		private static string GetUserInput(string name)
		{
			ShowInfo(string.Format("Введите {0}: ", name));
			return Console.ReadLine();
		}

		/// <summary>
		/// Выводит на консоль сообщение об исключении
		/// </summary>
		/// <param name="ex">Исключение</param>
		private static void ShowException(Exception ex)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Ошибка!\n"
				+ ex.Message + "\n");
			Console.ForegroundColor = ConsoleColor.White;
		}

		/// <summary>
		/// Выводит на консоль информационное сообщение
		/// </summary>
		/// <param name="message">Текст сообщения</param>
		/// <param name="consoleColor">Цвет текста в консоли</param>
		private static void ShowInfo(string message,
			ConsoleColor consoleColor = ConsoleColor.Yellow)
		{
			Console.ForegroundColor = consoleColor;
			Console.WriteLine(message);
			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}
