using System;
using System.Linq;

namespace Model
{
    /// <summary>
    /// Книга
    /// </summary>
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw (value == null ?
                        new ArgumentNullException(nameof(PublishingHouse),
                            "Должен быть указан издательский дом") :
                        new ArgumentException(nameof(PublishingHouse),
                            "Издательский дом не может быть пустой строкой"));
                }
                else _publishingHouse = value;
            }
        }
      
        /// <summary>
        /// Язык
        /// </summary>
        public LanguageMode Language { get; set; }

        public override string GetStandartName()
        {
            string result = string.Empty;

            if (Authors.Count > 3)
            {
                result += string.Format("{0} / {1} {2}",
                    Title,
                    Authors.First().GetInitials(),
                    Authors.First().SecondName);

                result += " " + Texts.GetValue("Others", Language) + " ";
            }
            else
            {
                result += string.Format("{0}, {1}{2} / ",
                    Authors.First().SecondName,
                    Authors.First().GetInitials(), Title);

                Authors.ForEach(x =>
                {
                    result += string.Format("{0} {1}, ",
                        x.GetInitials(), x.SecondName);
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