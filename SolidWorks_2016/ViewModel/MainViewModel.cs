using SolidWorks_2016.Model;
using SolidWorks_2016.Model.MyException;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Media.Media3D;
using System.Windows.Controls;

namespace SolidWorks_2016.ViewModel
{
    class MainViewModel: INotifyPropertyChanged
    {
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
            Application app = Application.Current;
            var openOrClose = new OpenOrCloseSWModel();
            SaveDialog saveDialog = new SaveDialog();

            ClickCommandOpenSolidWorks = new Command(arg => { openOrClose.OpenSW(); IsEnabledOpenSW = true; });
            ClickCommandCloseSolidWorks = new Command(arg => { openOrClose.CloseSW();app.Shutdown();});
            
            InputParametr = new InputParametrs
            {
                SizeOfWorkingSurface = "0",
                SizeAttachmentPortion = "0",
                HeightFirstCylinder = "0",
                HeightSecondCylinder = "0",
                DepthOfWorkSurface = "0",
                WallThicknessFirstCylinder = "1",
                WallThicknessSecondCylinder = "1"
            };
            ParametrsForBuilder parametrsForBuilder = new ParametrsForBuilder();
            BuildEndHeadFigure buildEndHeadFigure = new BuildEndHeadFigure();
            ClickCommandBuilder = new Command(arg => {
                //свойство вилимости кнопки Builder
                //IsEnabledOpenSW = !openOrClose.IsOpenSW();
                if ((openOrClose.IsOpenSW()!=true)&&(InputParametr.InspectionInputParametrs() != null))
                {
                    parametrsForBuilder = InputParametr.InspectionInputParametrs();
                    buildEndHeadFigure.InputParametrsForBuilding(parametrsForBuilder);
                    buildEndHeadFigure.BuildEndHead(openOrClose.SwApp, saveDialog.SaveDialogFile());
                }
                
            });            
        }

        /// <summary>
        /// Вводим парамтры с View в Model
        /// </summary>
        private InputParametrs _inputParametr;
        public InputParametrs InputParametr
        {
            get
            {
                return _inputParametr;
            }
            set
            {
                try
                {
                    _inputParametr = value;
                }
                catch(CellFormatException exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }   
            }
        }
        
        /// <summary>
        /// Создание торцевой головки
        /// </summary>
        public ICommand ClickCommandBuilder { get; set; }

        /// <summary>
        /// Открытие SolidWorks v2016
        /// </summary>
        public ICommand ClickCommandOpenSolidWorks { get; set; }

        /// <summary>
        /// Закрытие SolidWorks
        /// </summary>
        public ICommand ClickCommandCloseSolidWorks { get; set; }

        /// <summary>
        /// Открыт ли солид воркс
        /// </summary>
        public ICommand IsEnabledCommandOpenSW { get; set; }

        /// <summary>
        /// Открыт ли SW
        /// </summary>
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
