using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SolidWorks_2016.Model
{
    class OpenOrCloseSWModel
    {
        /// <summary>
        /// свойство передающее 
        /// </summary>
        private SldWorks _SwApp;
        public SldWorks SwApp
        {
            get { return _SwApp; }
            set { _SwApp = value; }
        }
        /// <summary>
        /// Открыт ли Solid Works
        /// </summary>
        /// <returns></returns>
        public bool IsOpenSW()
        {
            Process[] processes = Process.GetProcessesByName("SLDWORKS");
            foreach (Process process in processes)
            {
                //return true;
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
            _SwApp.UserControl = true;
            _SwApp.Visible = true;
            SwApp = _SwApp;
        }
        /// <summary>
        /// Закрытие SolidWorks
        /// </summary>
        public void CloseSW()
        {
            if (IsOpenSW()&&(SwApp!=null))
            {
                SwApp.ExitApp();
            }
        }
    }
}
