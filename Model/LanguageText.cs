namespace Model
{
	/// <summary>
	/// Класс для хранения сокращений
	/// терминов для разных языков
	/// </summary>
	public class LanguageText
	{
		/// <summary>
		/// Язык
		/// </summary>
		public LanguageMode Language { get; set; }

		/// <summary>
		/// Название термина
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Значение термина в определенном языке
		/// </summary>
		public string Value { get; set; }
	}
}
