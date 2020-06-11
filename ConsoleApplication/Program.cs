using Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ConsoleApplication
{
	/// <summary>
	/// Класс для сбора и обработки данных пользователя 
	/// с консоли для создания библиографического списка
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Инициирует создание библиографического списка
		/// путем последующего ввода данных пользователем в консоли
		/// </summary>
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
			ShowInfo("Создание диссертации\n");
			Person author = CreateAuthor();
			disser.Authors = new List<Person> { author };
			Console.WriteLine();

			SetProperties(ref disser, new string[] { nameof(disser.Authors) });
			return disser;
		}

		/// <summary>
		/// Используется для создания автора издания
		/// </summary>
		/// <returns>Автор издания</returns>
		private static Person CreateAuthor()
		{
			ShowInfo("Создание автора");
			Person p = new Person();
			SetProperties(ref p);
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
			bool successEnterProperty = false;

			ShowInfo("Создание книги\n");
			Book book = new Book();

			while (successEnterProperty == false)
			{
				try
				{
					authorsCount =
						(int)GetUserInput(authorsCount.GetType(),
							"количество авторов");
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

			SetProperties(ref book, new string[] { nameof(book.Authors) });
			return book;
		}

		/// <summary>
		/// Запрашивает и считывает свойство объекта
		/// </summary>
		/// <param name="type">Ожидаемый тип свойства</param>
		/// <param name="name">Название свойства</param>
		/// <returns>Объект ожидаемого типа</returns>
		private static object GetUserInput(Type type, string name)
		{
			ShowInfo(string.Format("Введите {0}: ", name));

			if (type.IsEnum)
				return Enum.Parse(type, Console.ReadLine(), false);
			else
				return Convert.ChangeType(Console.ReadLine(), type);
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
		/// Выводит на консоль информационное сообщение,
		/// окрашивая текст в указанный цвет
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

		/// <summary>
		/// Метод для заполнения свойств объекта
		/// </summary>
		/// <param name="instance">объект для заполнения</param>
		/// <param name="ignoredProperties">свойства, 
		/// которые не надо заполнять
		/// </param>
		private static void SetProperties<T>(ref T instance,
			string[] ignoredProperties = null)
		{
			bool successEnterProperty;
			Dictionary<string, string> propertyTexts =
				new Dictionary<string, string>();
			Type type = instance.GetType();

			switch (type.Name)
			{
				case nameof(Person):
					propertyTexts = new Dictionary<string, string>
					{
						["SecondName"] = "фамилию",
						["FirstName"] = "имя",
						["Patronymic"] = "отчество"
					};
					break;
				case nameof(Book):
					propertyTexts = new Dictionary<string, string>
					{
						["Title"] = "название",
						["PublishingHouse"] = "название издательства",
						["City"] = "город",
						["Year"] = "год публикации",
						["NumPages"] = "кол-во страниц",
						["Language"] = "0, если язык русский, иначе 1"
					};
					break;
				case nameof(Dissertation):
					propertyTexts = new Dictionary<string, string>
					{
						["Title"] = "заголовок диссертации",
						["Year"] = "год публикации",
						["NumPages"] = "кол-во страниц",
						["University"] = "название вуза",
						["Degree"] = "ученую степень",
						["SpecialityCode"] = "код специальности",
						["City"] = "город"
					};
					break;
				default:
					throw new ArgumentException("Недопустимый тип объекта");
			}

			foreach (var propertyInfo in type.GetProperties())
			{
				successEnterProperty = false;
				if (ignoredProperties != null &&
					Array.Exists(ignoredProperties,
						e => e == propertyInfo.Name))
					continue;
				
				if (propertyInfo.GetSetMethod() != null)
				{
					successEnterProperty = false;
					while (!successEnterProperty)
					{
						try
						{
							propertyInfo.SetValue(instance,
								GetUserInput(propertyInfo.PropertyType,
									propertyTexts[propertyInfo.Name]));
							successEnterProperty = true;
						}
						catch (Exception ex)
						{
							ShowException(ex.InnerException ?? ex);
						}
					}
					Console.WriteLine();
				}
			}
		}
	}
}
