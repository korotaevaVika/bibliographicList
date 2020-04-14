using System.Collections.Generic;
using System.Linq;

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

        public static string GetValue(string name, LanguageMode language)
        {
            return _languageTexts.FirstOrDefault(x => x.Language == language && x.Name == name).Value;
        }
    }
}
