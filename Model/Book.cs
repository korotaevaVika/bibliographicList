using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class Book : EditionBase
    {
        //private string _title;
        private string _publishingHouseName;
        private string _city;
        //private DateTime _published;
        //private List<Person> _authors;
        private int _numPages;
        //private LanguageEnum _language;

        //public Book(string title, string publishingHouseName
        //            , string city, int publishedYear
        //            , Person[] authors, int numPages
        //            , LanguageEnum language = LanguageEnum.Russian)
        //{
        //    _language = language;
        //}

        public string City
        {
            get { return _city; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw (value == null ? new ArgumentNullException(nameof(City)
                       , "У книги должен быть указан город издательства")
                       : new ArgumentException(nameof(City)
                        , "Город издательства не может быть пустой строкой"));
                }
                else
                    _city = value;
            }
        }

        public string PublishingHouseName
        {
            get { return _publishingHouseName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw (value == null ? new ArgumentNullException(nameof(PublishingHouseName)
                       , "У книги должен быть указан издательский дом")
                       : new ArgumentException(nameof(PublishingHouseName)
                        , "Издательский дом не может быть пустой строкой"));
                }
                else
                    _publishingHouseName = value;
            }
        }
        public int NumPages
        {
            get { return _numPages; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(NumPages)
                       , "Количество страниц должно быть больше 0");
                }
                else _numPages = value;
            }
        }

        public LanguageEnum Language
        {
            get { return _language; }
            set
            {
                _language = value;
            }
        }

        public override string GetStandartName()
        {
            string result = string.Empty;
            if (Authors.Count > 3)
            {
                result += string.Format("{0} / {1} {2}",
                    Title, Authors.First().GetInitials(), Authors.First().SecondName);

                switch (Language)
                {
                    case LanguageEnum.Russian:
                        result += " [и др.]";
                        break;
                    case LanguageEnum.English:
                        result += " [et al.]";
                        break;
                    default:
                        break;
                }

                //Экономика и финансы недвижимости / Д. Л. Волков [и др.] ; под ред. Ю. В. Пашкуса. –
                //СПб. : Изд - во СПбГУ, 1999. – 186 с.
                //Strategic management cases / N.Snyder[et al.]. – Reading: Addison - Wesley,
                // 1991. – 769 p.
            }
            else
            {
                result += string.Format("{0}, {1}{2} / ",
                    Authors.First().SecondName, Authors.First().GetInitials(), Title);

                Authors.ForEach(x => { result += string.Format("{0} {1}, ", x.GetInitials(), x.SecondName); });
                result = result.Remove(result.Length - 2, 2);
            }
            result += string.Format(". – {0}: {1}, {2}. – {3} ", City, PublishingHouseName, PublishedYear, NumPages);

            switch (Language)
            {
                case LanguageEnum.Russian:
                    result += "c";
                    break;
                case LanguageEnum.English:
                    result += "p";
                    break;
                default:
                    break;
            }
            result += ".";
            //Федотов, Ю.В.Методы и модели построения эмпирических производственных
            //функций / Ю.В.Федотов. – СПб. : Изд - во СПбГУ, 1997. – 220 с.

            return result;
        }
    }

}
