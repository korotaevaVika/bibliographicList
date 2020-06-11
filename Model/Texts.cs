using System.Collections.Generic;
using System.Linq;

namespace Model
{
	/// <summary>
	/// Словарь терминов на разных языках
	/// </summary>
	public static class Texts
	{
		private static List<LanguageText> _languageTexts =
					new List<LanguageText>(){
				new LanguageText {
					Language = LanguageMode.Russian,
					Name = "Pages",
					Value = "с"
				},
				new LanguageText {
					Language = LanguageMode.English,
					Name = "Pages",
					Value = "p"
				},
				new LanguageText {
					Language = LanguageMode.Russian,
					Name = "Others",
					Value = "[и др.]"
				},
				new LanguageText {
					Language = LanguageMode.English,
					Name = "Others",
					Value = "[et al.]"
				}
				};

		/// <summary>
		/// Возвращает значение объекта в определенном языке
		/// </summary>
		/// <param name="name">идентификатор (название) объекта</param>
		/// <param name="language">язык</param>
		/// <returns>название объекта на требуемом языке</returns>
		public static string GetValue(string name, LanguageMode language)
		{
			return _languageTexts.
						FirstOrDefault(x =>
							x.Language == language && x.Name == name).Value;
		}
	}
}
