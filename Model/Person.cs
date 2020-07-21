using System;
using System.Globalization;
using System.Threading;
using System.Xml.Serialization;

namespace Model
{
	/// <summary>
	/// Класс для хранения данных человека. 
	/// Используется для хранения авторов изданий
	/// </summary>
	public class Person
	{
		private string _firstName;
		private string _secondName;
		private string _patronymic;
		private TextInfo _textInfo =
			Thread.CurrentThread.CurrentCulture.TextInfo;

		/// <summary>
		/// Имя
		/// </summary>
		public string FirstName
		{
			get { return _textInfo.ToTitleCase(_firstName); }
			set
			{
				_firstName = Validation.
					CheckStringValue(value, "Имя");
			}
		}

		/// <summary>
		/// Фамилия
		/// </summary>
		public string SecondName
		{
			get { return _textInfo.ToTitleCase(_secondName); }
			set
			{
				_secondName = Validation.
					CheckStringValue(value, "Фамилия");
			}
		}

		/// <summary>
		/// Отчество
		/// </summary>
		public string Patronymic
		{
			get { return _textInfo.ToTitleCase(_patronymic); }
			set
			{
				_patronymic = value;
			}
		}

		/// <summary>
		/// Инициалы человека
		/// </summary>
		public string Initials
		{
			get
			{
				if (string.IsNullOrEmpty(Patronymic))
					return FirstName[0] + ".";
				else
					return FirstName[0] + ". " + Patronymic[0] + ".";
			}
		}

		/// <summary>
		/// Метод для получения полного имени
		/// </summary>
		/// <returns>полное имя человека</returns>
		public override string ToString()
		{
			return string.Concat(SecondName, " ", FirstName, " ", Patronymic);
		}
	}
}
