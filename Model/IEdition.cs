using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //    public abstract class EditionBase : IEdition
    //    {
    //        const int MIN_PUBLISHING_YEAR = 868;
    //        private string _title;
    //        private int _publishedYear;

    //        public string Title
    //        {
    //            get { return _title; }
    //            set
    //            {
    //                if (string.IsNullOrWhiteSpace(value))
    //                {
    //                    throw (value == null ? new ArgumentException(nameof(Title)
    //                       , "У книги должно быть указано название")
    //                       : new ArgumentException(nameof(value)
    //                        , "Название книги не может быть пустой строкой"));
    //                }
    //                else
    //                    _title = value;
    //            }
    //        }

    //        public int PublishedYear
    //        {
    //            get { return _publishedYear; }
    //            set
    //            {
    //                if (value > DateTime.Today.Year)
    //                    throw new ArgumentException(nameof(PublishedYear)
    //                        , "Год публикации не может превосходить текущий");
    //                else if (value < MIN_PUBLISHING_YEAR)
    //                    throw new ArgumentException(nameof(PublishedYear)
    //                         , string.Format("Год публикации не может быть меньше {0}", MIN_PUBLISHING_YEAR));
    //                else _publishedYear = value;
    //            }
    //        }
    //    }

    //    public abstract string GetStandartName();
    //}

    public interface IEdition
    {
        /// <value>
        /// Название издания
        /// </value>
        string Title { get; set; }

        List<Person> Authors { get; }

        ///// <value>
        ///// Название издательства
        ///// </value>
        //string PublishingHouseName { get; }

        /// <value>
        /// Год публикации
        /// </value>
        int PublishedYear { get; set; }

        /// <summary>
        /// Возвращает название издания по ГОСТ
        /// Т.к. указанный ресурс ostu.ru/libraries/bibl_opisanie.php недоступен,
        /// ГОСТ взят из https://gsom.spbu.ru/files/upload/library/list_of_literature.pdf
        /// </summary>
        string GetStandartName();
    }
}
