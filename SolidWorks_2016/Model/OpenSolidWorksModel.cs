using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidWorks_2016.Model
{
    class OpenSolidWorksModel
    {
        private SldWorks _SwApp;
        public SldWorks SwApp
        {
            get { return _SwApp; }
            set { _SwApp = value; }
        }
        public bool IsOpenSW()
        {
            // убиваем солид если запущен

            Process[] processes = Process.GetProcessesByName("SLDWORKS 2016");
            foreach (Process process in processes)
            {
                process.CloseMainWindow();
                process.Kill();
            }
            return false;
        }
        /// <summary>
        /// Открытие SolidWorks
        /// </summary>
        /// <returns></returns>
        public void OpenSW()
        {
            // запуск солид
            object processSW = Activator.CreateInstance(Type.GetTypeFromProgID("SldWorks.Application"));
            _SwApp = (SldWorks)processSW;
            _SwApp.Visible = true;
            SwApp=_SwApp;
        }
        /// <summary>
        /// Закрытие SolidWorks
        /// </summary>
        public void CloseSW()
        {
            SwApp.ExitApp();
        }
    }
}
