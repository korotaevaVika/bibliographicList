using System.Linq;
using System.Xml.Serialization;

namespace Model
{
	/// <summary>
	/// Диссертация
	/// </summary>
	[XmlRoot(ElementName = "Dissertation")]
	public class Dissertation : EditionBase
	{
		private string _degree;
		private string _specialityCode;
		private string _university;

		/// <summary>
		/// Автор
		/// </summary>
		public Person Author => Authors.First();

		/// <summary>
		/// Ученая степень 
		/// </summary>
		public string Degree
		{
			get { return _degree; }
			set
			{
				_degree = Validation.
					CheckStringValue(value, "Степень автора");
			}
		}

		/// <summary>
		/// Код специальности
		/// </summary>
		public string SpecialityCode
		{
			get { return _specialityCode; }
			set
			{
				_specialityCode = Validation.
					CheckStringValue(value, "Код специальности");
			}
		}
		
		/// <summary>
		/// Название университета
		/// </summary>
		public string University
		{
			get { return _university; }
			set
			{
				_university = Validation.
					CheckStringValue(value, "Университет");
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
				result += string.Format("{0}, {1} {2}: дис. ...{3} : {4} "
								+ "/ {5} {6}{0} ; {7}. − {8}, "
								+ "{9}. − {10} л.",
								Author.SecondName,
								Author.Initials,
								Title,
								Degree,
								SpecialityCode,
								Author.FirstName,
								Author.Patronymic.Length > 0 ?
									Author.Patronymic + " " : "",
								University,
								City,
								Year,
								NumPages);
				return result;
			}
		}
	}
}