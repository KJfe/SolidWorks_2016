using System;
using System.Windows.Controls;

namespace SolidWorks_2016.ViewModel
{
    /// <summary>
    /// Класс для Проверки введенных параметров в GUI (TextBox)
    /// </summary>
    public class ParametrRule : ValidationRule
    {
        private double _min = 1;
        private double _max = Double.MaxValue;
        /// <summary>
        /// Минимальное значение для TextBox
        /// </summary>
        public double Min
        {
            get { return _min; }
            set { _min = value; }
        }
        /// <summary>
        /// Максимальное значение для TextBox
        /// </summary>
        public double Max
        {
            get { return _max; }
            set { _max = value; }
        }
        /// <summary>
        /// свойство принимающее имя ячейки
        /// </summary>
        private string _propertyName;
        public string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
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

            if (_result <= 0)
            {
                return new ValidationResult(false, PropertyName + " не может быть <0.");
            }
            else
            {
                if (_result > Max)
                {
                    return new ValidationResult(false, PropertyName + " не может быть больше " + Max + ".");
                }

                else
                {
                    return ValidationResult.ValidResult;
                }
            }
                
            


            
        }

    }
}
