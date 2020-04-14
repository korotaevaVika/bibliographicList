using System.Globalization;
using System.Threading;

namespace Model
{
    /// <summary>
    /// Человек. Используется для хранения авторов изданий
    /// </summary>
    public class Person
    {
        private string _firstName;
        private string _secondName;
        private string _patronymic;
        private TextInfo _textInfo = 
            Thread.CurrentThread.CurrentCulture.TextInfo;

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName
        {
            get { return _textInfo.ToTitleCase(_firstName); }
            set { _firstName = value; }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string SecondName
        {
            get { return _textInfo.ToTitleCase(_secondName); }
            set { _secondName = value; }
        }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic
        {
            get { return _textInfo.ToTitleCase(_patronymic); }
            set { _patronymic = value; }
        }

        public string GetInitials()
        {
            if (string.IsNullOrEmpty(Patronymic))
                return FirstName[0] + ".";
            else return FirstName[0] + ". " + Patronymic[0] + ".";
        }
    }
}
