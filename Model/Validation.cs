using System;

namespace Model
{
	/// <summary>
	/// Класс с методами валидации полей
	/// </summary>
	internal class Validation
	{

		/// <summary>
		/// Возвращает значение строкового свойства объекта
		/// при успешном прохождении валидации
		/// </summary>
		/// <param name="value">значение, введенное пользователем</param>
		/// <param name="propertyName">имя свойства</param>
		/// <returns></returns>
		internal static string CheckStringValue(string value,
			string propertyName)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw (value == null ?
					new ArgumentNullException(
						propertyName,
						string.Format(
							"Нельзя пропустить свойство объекта: {0}",
							propertyName)) :
						new ArgumentException(propertyName,
							string.Format(
								"{0} не может быть пустой строкой",
								propertyName)));
			}
			return value;
		}

		internal static int CheckNumber(int number,
			int? lowerLimit,
			int? upperLimit,
			string propertyName)
		{
			//if (int.TryParse(value, out number) == false)
			//{
			//	throw new InvalidCastException(
			//		"Убедитесь, что Вы вводите целое число");
			//}

			if (upperLimit.HasValue && number > upperLimit.Value)
			{
				throw new ArgumentException(propertyName,
					string.Format("Значение не может быть больше {0}",
						upperLimit));
			}
			else if (lowerLimit.HasValue && number < lowerLimit.Value)
			{
				throw new ArgumentException(propertyName,
					string.Format("Значение не может быть меньше {0}",
						lowerLimit));
			}
			else
				return number;
		}
	}
}
