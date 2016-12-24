using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks_2016.Model;
using System.Windows;
using System.Windows.Input;
using SolidWorks.Interop.sldworks;
using System.Diagnostics;

namespace SolidWorks_2016.ViewModel
{
    class MainViewModel
    {
        private SldWorks _SwApp;
        /// <summary>
        /// Constructor.
        /// </summary>
        public MainViewModel()
        {
            ClickCommandOpenSolidWorks = new Command(arg => ClickOpenSolidWorks());
            
            ParametrsEndHead = new ParametrsEndHeadModel
            {
                RadiusFirstCylinder = "0",
                RadiusSecondCylinder = "0",
                HeightFirstCylinder = "0",
                HeightSecondCylinder = "0",
                DeepExtrusionFirstCylinder = "0",
                WallThickness="3"
            };
            //var BuildEndHead = new ParametrsEndHeadModel();
            ClickCommandBuilder = new Command(arg => ParametrsEndHead.BuildEndHead(_SwApp));
        }

        public ParametrsEndHeadModel ParametrsEndHead { get; set; }
        
        /// <summary>
        /// Создание торцевой головки
        /// </summary>
        public ICommand ClickCommandBuilder { get; set; }
        private void ClickBuildEndHead()
        {
            MessageBox.Show("This is click command.");
        }

        /// <summary>
        /// Открытие SolidWorks v2016
        /// </summary>
        public ICommand ClickCommandOpenSolidWorks { get; set; }
        public void ClickOpenSolidWorks()
        {
            // убиваем солид если запущен
            Process[] processes = Process.GetProcessesByName("SLDWORKS 2016");
            foreach (Process process in processes)
                {
                    process.CloseMainWindow();
                    process.Kill();
                }
            // запуск солид
            object processSW = Activator.CreateInstance(Type.GetTypeFromProgID("SldWorks.Application"));
            _SwApp = (SldWorks)processSW;
            _SwApp.Visible = true;
        }

    }
}
