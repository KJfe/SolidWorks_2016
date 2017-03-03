using System;
namespace SolidWorks_2016.Model.MyException
{
    /// <summary>
    /// Класс представляет Exception для толщены стенок
    /// </summary>
    public class CellWallThicknessException : ApplicationException
    {
        public CellWallThicknessException(string editDesc) : base(string.Format("Толщина стенки не может быть меньше 1 мм, в {0}", editDesc)) { }
    }
}
