using System;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace Model
{
	/// <summary>
	/// Книга
	/// </summary>
	[XmlRoot(ElementName = "Book")]
	public class Book : EditionBase
	{
		private string _publishingHouse;

		/// <summary>
		/// Издательский дом
		/// </summary>
		public string PublishingHouse
		{
			get { return _publishingHouse; }
			set
			{
				_publishingHouse = Validation.
					CheckStringValue(value, "Издательский дом");
			}
		}

		/// <summary>
		/// Язык книги
		/// </summary>
		public LanguageMode Language
		{
			get
			{ return _language; }
			set
			{
				if (!Enum.IsDefined(typeof(LanguageMode), value))
				{
					throw new InvalidEnumArgumentException(
						"Значение в перечислении языков не определено");
				}
				_language = value;
			}
		}

		/// <summary>
		/// Наименование по ГОСТу
		/// </summary>
		public override string StandartName
		{
			get
			{
				string result = string.Empty;

				if (Authors.Count > 3)
				{
					result += string.Format("{0} / {1} {2}",
						Title,
						Authors.First().Initials,
						Authors.First().SecondName);

					result += $" {Texts.GetValue("Others", Language)} ";
				}
				else
				{
					result += string.Format("{0}, {1}{2} / ",
						Authors.First().SecondName,
						Authors.First().Initials, Title);

					Authors.ForEach(x =>
					{
						result += string.Format("{0} {1}, ",
							x.Initials, x.SecondName);
					});
					result = result.Remove(result.Length - 2, 2);
				}
				result += string.Format(". – {0}: {1}, {2}. – {3} ",
					City, PublishingHouse, Year, NumPages);

				result += Texts.GetValue("Pages", Language);
				result += ".";
				return result;
			}
		}
	}
}