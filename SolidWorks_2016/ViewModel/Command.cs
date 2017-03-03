using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SolidWorks_2016.ViewModel
{
    /// <summary>
    /// класс оброботчика нажатия на кнопку
    /// </summary>
    public class Command : ICommand
    {
        /// <summary>
        /// Принимаем параметры
        /// </summary>
        /// <param name="action"></param>
        public Command(Action<object> action)
        {
            ExecuteDelegate = action;
        }

        public Predicate<object> CanExecuteDelegate { get; set; }
        public Action<object> ExecuteDelegate { get; set; }
        /// <summary>
        /// Привязываем к событию
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (CanExecuteDelegate != null)
            {
                return CanExecuteDelegate(parameter);
            }

            return true;
        }
        /// <summary>
        /// определяем привязку к событию
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        /// <summary>
        /// Вызываем делегат
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (ExecuteDelegate != null)
            {
                ExecuteDelegate(parameter);
            }
        }

    }
}
