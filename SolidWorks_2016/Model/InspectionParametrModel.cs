using System;
using SolidWorks_2016.Model.MyException;

namespace SolidWorks_2016.Model
{
    /// <summary>
    /// Класс проверяющий корректность введенных данных
    /// </summary>
    public class InspectionParametrModel
    {
        /// <summary>
        /// метод проверяющий данные, 
        /// что бы не были меньше или равны 0 
        /// и были корректны
        /// </summary>
        /// <param name="edit"></param>
        /// <param name="editDesc"></param>
        /// <returns></returns>
        public static double Parametr(string edit, string editDesc)
        {
            double doubleEdit = 0;
            try
            {
                doubleEdit = Convert.ToDouble(edit);
            }
            catch (Exception)
            {
                throw new CellFormatException(editDesc);
            }

            if (doubleEdit < 0)
            {
                throw new CellOutOfRangeException(editDesc);
            }
            return doubleEdit;
        }
    }
}
