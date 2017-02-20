using System;
using System.Windows.Controls;

namespace SolidWorks_2016.ViewModel
{
    /// <summary>
    /// Класс для Проверки введенных параметров в GUI (TextBox)
    /// </summary>
    public class ParametrRule : ValidationRule
    {
        private double min = 1;
        private double max = Double.MaxValue;
        /// <summary>
        /// Минимальное значение для TextBox
        /// </summary>
        public double Min
        {
            get { return min; }
            set { min = value; }
        }
        /// <summary>
        /// Максимальное значение для TextBox
        /// </summary>
        public double Max
        {
            get { return max; }
            set { max = value; }
        }
        /// <summary>
        /// Проверям TextBox и возвращаем Текст ошибки
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ci"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo ci)
        {
            double _result;
            try
            {
                _result = Double.Parse(value as string);
            }
            catch
            {
                return new ValidationResult(false, "Недопустимые символы.");
            }        
            if ((_result <= 0) || (_result > Max))
            {
                return new ValidationResult(false, "Значение не может быть меньше 0 и больше"+ Max +".");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }

    }
}
