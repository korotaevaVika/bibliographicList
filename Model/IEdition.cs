using System.Collections.Generic;

namespace Model
{
    public interface IEdition
    {
        /// <value>
        /// Название издания
        /// </value>
        string Title { get; set; }

        /// <summary>
        /// Авторы издания
        /// </summary>
        List<Person> Authors { get; }

        ///// <value>
        ///// Название издательства
        ///// </value>
        //string PublishingHouseName { get; }

        /// <value>
        /// Год публикации
        /// </value>
        int Year { get; set; }

        /// <summary>
        /// Возвращает название издания по ГОСТ
        /// Т.к. указанный ресурс ostu.ru/libraries/bibl_opisanie.php 
        /// недоступен,
        /// ГОСТ взят из
        /// https://gsom.spbu.ru/files/upload/library/list_of_literature.pdf
        /// </summary>
        string GetStandartName();
    }
}
