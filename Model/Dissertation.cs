using System;
using System.Linq;

namespace Model
{
    /// <summary>
    /// Диссертация
    /// </summary>
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw (value == null ?
                        new ArgumentNullException(nameof(Degree),
                            "Должен быть указана степень автора"):
                        new ArgumentException(nameof(Degree),
                            "Степень не может быть пустой строкой"));
                }
                else _degree = value;
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw (value == null ?
                        new ArgumentNullException(nameof(SpecialityCode),
                            "Должен быть указан код специальности") :
                        new ArgumentException(nameof(SpecialityCode),
                            "Код специальности не может быть пустой строкой"));
                }
                else _specialityCode = value;
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw (value == null ?
                        new ArgumentNullException(nameof(University),
                            "Должен быть указан университет") :
                        new ArgumentException(nameof(University),
                            "Университет не может быть пустой строкой"));
                }
                else _university = value;
            }
        }
        
        public override string GetStandartName()
        {
            string result = string.Empty;
            result += string.Format("{0}, {1} {2}: дис. ...{3} : {4} / {5} "
                            + "{6}{0} ; {7}. − {8}, {9}. − {10} л.",
                            Author.SecondName,
                            Author.GetInitials(),
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