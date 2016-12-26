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
using System.ComponentModel;

namespace SolidWorks_2016.ViewModel
{
    class MainViewModel: INotifyPropertyChanged
    {
        //private SldWorks _SwApp;

        /// <summary>
        /// Метод проверяющий изменилось ли свойство
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Реализвация конструктора
        /// </summary>
        public MainViewModel()
        {
            var OpenOrClose = new OpenSolidWorksModel();
            ClickCommandOpenSolidWorks = new Command(arg => OpenOrClose.OpenSW());
        
            ClickCommandCloseSolidWorks = new Command(arg => OpenOrClose.CloseSW());
            ParametrsEndHead = new ParametrsEndHeadModel
            {
                RadiusFirstCylinder = "0",
                RadiusSecondCylinder = "0",
                HeightFirstCylinder = "0",
                HeightSecondCylinder = "0",
                DeepExtrusionFirstCylinder = "0",
                WallThickness="3"
            };
            ClickCommandBuilder = new Command(arg => ParametrsEndHead.BuildEndHead(OpenOrClose.SwApp));
        }

        public ParametrsEndHeadModel ParametrsEndHead { get; set; }
        
        /// <summary>
        /// Создание торцевой головки
        /// </summary>
        public ICommand ClickCommandBuilder { get; set; }

        /// <summary>
        /// Открытие SolidWorks v2016
        /// </summary>
        public ICommand ClickCommandOpenSolidWorks { get; set; }
        public void ClickOpenSolidWorks(OpenSolidWorksModel OpenOrClose)
        {
            /* // убиваем солид если запущен
             Process[] processes = Process.GetProcessesByName("SLDWORKS 2016");
             foreach (Process process in processes)
                 {
                     process.CloseMainWindow();
                     process.Kill();
                 }
             // запуск солид
             object processSW = Activator.CreateInstance(Type.GetTypeFromProgID("SldWorks.Application"));
             _SwApp = (SldWorks)processSW;
             _SwApp.Visible = true;*/
        }
        /// <summary>
        /// Закрытие SolidWorks
        /// </summary>
        public ICommand ClickCommandCloseSolidWorks { get; set; }
        public void ClickCloseSolidWorks(OpenSolidWorksModel OpenOrClose)
        {
            //_SwApp.ExitApp();
        }
        /// <summary>
        /// Открыт ли солид воркс
        /// </summary>
        public ICommand IsEnabledCommandOpenSW { get; set; }
        private bool _isEnabledOpenSW;
        public bool IsEnabledOpenSW
        {
            get
            {
                return _isEnabledOpenSW;
            }
            set
            {
                _isEnabledOpenSW = value;
                OnPropertyChanged("IsEnabledOpenSW");
            }
        }


    }
}
