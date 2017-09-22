using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidWorks_2016.ViewModel
{
    /// <summary>
    /// Класс для сохранения детали по определенному пути
    /// </summary>
    public class SaveDialog
    {
        /// <summary>
        /// метод открытия SaveDialog для выбора пути сохранения
        /// </summary>
        /// <returns></returns>
        public string SaveDialogFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SolidWorks file (*.SLDPRT)|*.SLDPRT";
            saveFileDialog.FileName = "Detail1";
            saveFileDialog.ShowDialog();
            return saveFileDialog.FileName;
        }
    }
}
