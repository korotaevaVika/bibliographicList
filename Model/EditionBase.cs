using System;
using System.Collections.Generic;

namespace Model
{
    public abstract class EditionBase : IEdition
    {
        const int MIN_PUBLISHING_YEAR = 868;
        protected string _title;
        protected int _publishedYear;
        protected List<Person> authors;
        protected LanguageEnum _language;

        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw (value == null ? new ArgumentNullException(nameof(Title)
                       , "У книги должно быть указано название")
                       : new ArgumentException(nameof(Title)
                        , "Название книги не может быть пустой строкой"));
                }
                else
                    _title = value;
            }
        }

        public int PublishedYear
        {
            get { return _publishedYear; }
            set
            {
                if (value > DateTime.Today.Year)
                {
                    throw new ArgumentException(nameof(PublishedYear)
                       , "Год издания не может быть больше текущего");
                } else if (value < MIN_PUBLISHING_YEAR)
                {
                    throw new ArgumentException(nameof(PublishedYear)
                          , string.Format("Год издания не может быть менее {0}", MIN_PUBLISHING_YEAR));
                }
                else
                    _publishedYear = value;
            }
        }

        public List<Person> Authors
        {
            get { return authors; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Authors), "Список авторов/редакторов не задан");
                }
                else if (value.Count == 0)
                {
                    throw new ArgumentException(nameof(Authors), "Список авторов/редакторов не может быть пуст");
                }
                else authors = new List<Person>(value);
            }
        }

        public abstract string GetStandartName();
    }

}