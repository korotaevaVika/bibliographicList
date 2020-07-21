using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model
{
	/// <summary>
	/// Базовый класс издания
	/// </summary>
	public abstract class EditionBase : IEdition
	{
		/// <summary>
		/// Минимальный год публикации
		/// </summary>
		public const int MinPublishingYear = 868;

		protected List<Person> _authors;
		protected string _city;
		protected LanguageMode _language;
		protected int _numPages;
		protected string _title;
		protected int _year;

		/// <summary>
		/// Город издательства
		/// </summary>
		public string City
		{
			get { return _city; }
			set
			{
				_city = Validation.
					CheckStringValue(value, "Город издательства");
			}
		}

		/// <summary>
		/// Название
		/// </summary>
		public string Title
		{
			get { return _title; }
			set
			{
				_title = Validation.
					CheckStringValue(value, "Название");
			}
		}

		/// <summary>
		/// Год издания
		/// </summary>
		public int Year
		{
			get { return _year; }
			set
			{
				_year = Validation.
					CheckNumber(value,
						MinPublishingYear,
						DateTime.Today.Year,
						"Год издания");
			}
		}

		/// <summary>
		/// Авторы издания
		/// </summary>
		public List<Person> Authors
		{
			get { return _authors; }
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException(nameof(Authors),
						"Список авторов/редакторов не задан");
				}
				else if (value.Count == 0)
				{
					throw new ArgumentException(nameof(Authors),
						"Список авторов/редакторов не может быть пуст");
				}
				else
					_authors = new List<Person>(value);
			}
		}

		/// <summary>
		/// Количество страниц
		/// </summary>
		public int NumPages
		{
			get { return _numPages; }
			set
			{
				_numPages = Validation.
				CheckNumber(value,
					1,
					null,
					"Количество страниц");
			}
		}

		/// <summary>
		/// Наименование издания по ГОСТу
		/// </summary>
		public abstract string StandartName { get; }
	}
}