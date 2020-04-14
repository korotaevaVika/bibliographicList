using System;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Базовый класс издания
    /// </summary>
    public abstract class EditionBase : IEdition
    {
        const int MIN_PUBLISHING_YEAR = 868;
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw (value == null ?
                        new ArgumentNullException(nameof(City),
                            "Должен быть указан город издательства") :
                        new ArgumentException(nameof(City),
                            "Город не может быть пустой строкой"));
                }
                else _city = value;
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw (value == null ?
                        new ArgumentNullException(nameof(Title),
                            "Должно быть указано название") :
                            new ArgumentException(nameof(Title),
                                "Название не может быть пустой строкой"));
                }
                else _title = value;
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
                if (value > DateTime.Today.Year)
                {
                    throw new ArgumentException(nameof(Year),
                        "Год издания не может быть больше текущего");
                }
                else if (value < MIN_PUBLISHING_YEAR)
                {
                    throw new ArgumentException(nameof(Year),
                        string.Format("Год издания не может быть менее {0}",
                            MIN_PUBLISHING_YEAR));
                }
                else _year = value;
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
                else _authors = new List<Person>(value);
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
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(NumPages),
                        "Количество страниц должно быть больше 0");
                }
                else _numPages = value;
            }
        }

        public abstract string GetStandartName();
    }
}