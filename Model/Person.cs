using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    public class Person
    {
        private string _firstName;
        private string _secondName;
        private string _patronymic;
        private TextInfo _textInfo;

        public Person()
        {
            _firstName = "";
            _secondName = "";
            _patronymic = "";
            _textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
        }
        public Person(string secondName, string firstName, string patronymic = "")
        {
            _firstName = firstName;
            _secondName = secondName;
            _patronymic = patronymic;
            _textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
        }

        /// <value>
        /// Имя
        /// </value>
        public string FirstName => _textInfo.ToTitleCase(_firstName);

        /// <value>
        /// Фамилия
        /// </value>
        public string SecondName => _textInfo.ToTitleCase(_secondName);

        /// <value>
        /// Отчество
        /// </value>
        public string Patronymic => _textInfo.ToTitleCase(_patronymic);

        public string GetInitials()
        {
            if (string.IsNullOrEmpty(Patronymic))
                return FirstName[0] + ".";
            else return FirstName[0] + ". " + Patronymic[0] + ".";
        }
    }
}
