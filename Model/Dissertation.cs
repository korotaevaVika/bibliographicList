using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Dissertation : EditionBase
    {
        private string _city;
        private string _university;
        private string _degree;
        private string _specialityCode;
        private int _numPages;

        //public Dissertation(string title
        //            , string city, DateTime published
        //            , Person author, int numPages
        //            , string university, string degree, string specialityCode)
        //{
        //    //_title = title;
        //    _city = city;
        //    _university = university;
        //    _degree = degree;
        //    _specialityCode = specialityCode;
        //    _author = author;
        //    //_numPages = numPages;
        //}

        public string City
        {
            get { return _city; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw (value == null ? new ArgumentNullException(nameof(City)
                       , "У диссертации должен быть указан город университета")
                       : new ArgumentException(nameof(City)
                        , "Город университета не может быть пустой строкой"));
                }
                else
                    _city = value;
            }
        }
        public string University
        {
            get { return _university; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw (value == null ? new ArgumentNullException(nameof(University)
                       , "У диссертации должен быть указан университет")
                       : new ArgumentException(nameof(University)
                        , "Университет не может быть пустой строкой"));
                }
                else
                    _university = value;
            }
        }
        public string Degree
        {
            get { return _degree; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw (value == null ? new ArgumentNullException(nameof(Degree)
                       , "У диссертации должен быть указана степень автора")
                       : new ArgumentException(nameof(Degree)
                        , "Степень не может быть пустой строкой"));
                }
                else
                    _degree = value;
            }
        }
        public string SpecialityCode
        {
            get { return _specialityCode; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw (value == null ? new ArgumentNullException(nameof(SpecialityCode)
                       , "У диссертации должен быть указан код специальности")
                       : new ArgumentException(nameof(SpecialityCode)
                        , "Код специальности не может быть пустой строкой"));
                }
                else
                    _specialityCode = value;
            }
        }
        public Person Author => Authors.First();

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

        public override string GetStandartName()
        {
            string result = string.Empty;
            result += string.Format("{0}, {1} {2}: дис. ...{3} : {4} / {5} {6}{0} ; {7}. − {8}, {9}. − {10} л."
                , Author.SecondName
                , Author.GetInitials()
                , Title
                , Degree
                , SpecialityCode
                , Author.FirstName
                , Author.Patronymic.Length > 0 ? Author.Patronymic + " " : ""
                , University
                , City
                , PublishedYear
                , NumPages);
            return result;
        }

        //Шекова, Е.Л.Совершенствование механизма управления некоммерческими
        //организациями культуры в условиях переходной экономики : дис. ...канд.экон.наук :
        //08.00.05 / Екатерина Леонидовна Шекова ; С.-Петербург.гос.ун-т. − СПб., 2002. − 192 л.
    }

}
