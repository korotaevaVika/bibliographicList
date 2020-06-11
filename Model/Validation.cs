using System;

namespace Model
{
	/// <summary>
	/// Класс с методами валидации полей
	/// </summary>
	internal static class Validation
	{
		/// <summary>
		/// Возвращает значение строкового свойства объекта
		/// при успешном прохождении валидации
		/// </summary>
		/// <param name="value">значение, введенное пользователем</param>
		/// <param name="propertyName">имя свойства</param>
		/// <returns>строка со значением</returns>
		internal static string CheckStringValue(string value,
			string propertyName)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				if (value == null)
				{
					throw new ArgumentNullException(propertyName,
						string.Format("Нельзя пропустить свойство: {0}",
							propertyName));
				}
				else
				{
					throw new ArgumentException(propertyName,
						string.Format("{0} не может быть пустой строкой",
							propertyName));
				}
			}
			else
				return value;
		}

		/// <summary>
		/// Возвращает значение числового свойства объекта
		/// при успешном прохождении валидации
		/// </summary>
		/// <param name="number">значение, введенное пользователем</param>
		/// <param name="lowerLimit">нижний допустимый предел</param>
		/// <param name="upperLimit">верхний допустимый предел</param>
		/// <param name="propertyName">имя свойства</param>
		/// <returns>число</returns>
		internal static int CheckNumber(int number,
			int? lowerLimit,
			int? upperLimit,
			string propertyName)
		{
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
