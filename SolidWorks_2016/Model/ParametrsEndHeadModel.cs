using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BuilderFigure.Model;
using SolidWorks.Interop.sldworks;

namespace SolidWorks_2016.Model
{
    class ParametrsEndHeadModel//: INotifyPropertyChanged
    {
        public void BuildEndHead(SldWorks SwApp)
        {
            if ((_radiusFirstCylinder >= _radiusSecondCylinder) && 
                (_wallThickness < _heightFirstCylinder) &&
                (_wallThickness < _heightSecondCylinder) &&
                (_heightFirstCylinder>3))
            {
                double FerstRadius;
                double SecondRadius;
                double HeightSecondCylinder;
                double DeepExtrusion;
                FerstRadius = _radiusFirstCylinder + _wallThickness;
                SecondRadius = (_radiusSecondCylinder * Math.Sqrt(2)) / 2 + _wallThickness;
                HeightSecondCylinder = _heightFirstCylinder + _heightSecondCylinder;
                DeepExtrusion = _heightFirstCylinder - 3;
                EndHeadFigureModel SensingHead = new EndHeadFigureModel(SwApp); 
                SensingHead.BuildNewDocSW();
                SensingHead.BuildNewCylinder(FerstRadius, _heightFirstCylinder, "Спереди", "PLANE", 0, 0, 0, false);
                SensingHead.BuildNewCylinder(SecondRadius, HeightSecondCylinder, "Спереди", "PLANE", 0, 0, 0, false);
                SensingHead.BuildExtrusion(true, _radiusFirstCylinder, 6, DeepExtrusion);
                SensingHead.BuildExtrusion(true, _radiusSecondCylinder, 4, HeightSecondCylinder);
            }
        }
        /// <summary>
        /// Толщена стенок
        /// </summary>
        private double _wallThickness;
        public string WallThickness
        {
            get
            {
                return _wallThickness.ToString();
            }
            set
            {
                try
                {
                    _wallThickness = InspectionParametrModel.Parametr(value, "Wall Thichess");
                    /*if(_radiusFirstCylinder.ToString() != value)
                                    {
                                        _radiusFirstCylinder = InspectionParametrModel.Parametr(value, "Radius");
                                        OnPropertyChanged("RadiusFirstCylinder");
                                    }         */
                }
                catch (CellOutOfRangeException cellOutOfRangeExxeption)
                {
                    MessageBox.Show(cellOutOfRangeExxeption.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                catch (CellFormatException cellFormatError)
                {
                    MessageBox.Show(cellFormatError.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }

        /// <summary>
        /// Запись радиуса первого цилиндра
        /// </summary>
        private double _radiusFirstCylinder;
        public string RadiusFirstCylinder
        {
            get
            {
                return _radiusFirstCylinder.ToString();
            }
            set
            {
                try
                {
                    _radiusFirstCylinder = InspectionParametrModel.Parametr(value, "Radius");
                    /*if(_radiusFirstCylinder.ToString() != value)
                                    {
                                        _radiusFirstCylinder = InspectionParametrModel.Parametr(value, "Radius");
                                        OnPropertyChanged("RadiusFirstCylinder");
                                    }         */
                }
                catch (CellOutOfRangeException cellOutOfRangeExxeption)
                {
                    MessageBox.Show(cellOutOfRangeExxeption.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                catch (CellFormatException cellFormatError)
                {
                    MessageBox.Show(cellFormatError.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }
        /// <summary>
        /// Запись радиуса второго цилиндра
        /// </summary>
        private double _radiusSecondCylinder;
        public string RadiusSecondCylinder
        {
            get
            {
                return _radiusSecondCylinder.ToString();
            }
            set
            {
                try
                {
                    _radiusSecondCylinder = InspectionParametrModel.Parametr(value, "Радиус второго цилиндра");
                }
                catch (CellOutOfRangeException cellOutOfRangeExxeption)
                {
                    MessageBox.Show(cellOutOfRangeExxeption.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                catch (CellFormatException cellFormatError)
                {
                    MessageBox.Show(cellFormatError.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }

            }
        }
        /// <summary>
        /// Высота первого цилиндра
        /// </summary>
        private double _heightFirstCylinder;
        public string HeightFirstCylinder
        {
            get
            {
                return _heightFirstCylinder.ToString();
            }
            set
            {
                try
                {
                    _heightFirstCylinder = InspectionParametrModel.Parametr(value, "Высота первого цилиндра");
                }
                catch (CellOutOfRangeException cellOutOfRangeExxeption)
                {
                    MessageBox.Show(cellOutOfRangeExxeption.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                catch (CellFormatException cellFormatError)
                {
                    MessageBox.Show(cellFormatError.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }
        /// <summary>
        /// высота второго цилиндра
        /// </summary>
        private double _heightSecondCylinder;
        public string HeightSecondCylinder
        {
            get
            {
                return _heightSecondCylinder.ToString();
            }
            set
            {
                try
                {

                    _heightSecondCylinder = InspectionParametrModel.Parametr(value, "Высота второго цилиндра");
                }
                catch (CellOutOfRangeException cellOutOfRangeExxeption)
                {
                    MessageBox.Show(cellOutOfRangeExxeption.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                catch (CellFormatException cellFormatError)
                {
                    MessageBox.Show(cellFormatError.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }
        /// <summary>
        /// Глубина выреза первого цилиндра
        /// </summary>
        private double _deepExtrusionFirstCylinder;
        public string DeepExtrusionFirstCylinder
        {
            get
            {
                return _deepExtrusionFirstCylinder.ToString();
            }
            set
            {
                try
                {
                    _deepExtrusionFirstCylinder = InspectionParametrModel.Parametr(value, "Глубина выреза в цилиндра");
                }
                catch (CellOutOfRangeException cellOutOfRangeExxeption)
                {
                    MessageBox.Show(cellOutOfRangeExxeption.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                catch (CellFormatException cellFormatError)
                {
                    MessageBox.Show(cellFormatError.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }

       /* 
        private void ExceptionParametrs()
        {
            try
            {
                RadiusFirstCylinder();
                DeepExtrusionFirstCylinder{};
            }
            catch (CellOutOfRangeException cellOutOfRangeExxeption)
            {
                MessageBox.Show(cellOutOfRangeExxeption.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch (CellFormatException cellFormatError)
            {
                MessageBox.Show(cellFormatError.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }
        */

        /*
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        */

    }
}
