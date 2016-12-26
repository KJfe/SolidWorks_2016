using System;
using System.Windows;
using SolidWorks_2016.Model.BuilderFigure;
using SolidWorks.Interop.sldworks;
using SolidWorks_2016.Model.MyException;
using System.Windows.Media.Media3D;

namespace SolidWorks_2016.Model
{
    public class ParametrsEndHeadModel//: INotifyPropertyChanged
    {
        public void BuildEndHead(SldWorks SwApp)
        {
            
           /* if ((_radiusFirstCylinder >= _radiusSecondCylinder) && 
                (_wallThickness < _heightFirstCylinder) &&
                (_wallThickness < _heightSecondCylinder) &&
                (_heightFirstCylinder>3))*/
            try
            {
                double FirstRadius;
                double SecondRadius;
                double HeightSecondCylinder;
                double DeepExtrusion;
                double SecondRadiusExtrusion;
                var xyz = new Point3D();
                xyz.X = 0;
                xyz.Y = 0;
                xyz.Z = 0;
                FirstRadius = _radiusFirstCylinder + _wallThickness;
                //вычисление радиуса описанной окружности квадрата
                SecondRadiusExtrusion = (_radiusSecondCylinder * Math.Sqrt(2)) / 2;
                SecondRadius = SecondRadiusExtrusion + _wallThickness;           
                HeightSecondCylinder = _heightFirstCylinder + _heightSecondCylinder;
                //DeepExtrusion = _heightFirstCylinder - 3;
                DeepExtrusion = _deepExtrusionFirstCylinder;
                InspectionParametrsForBuildEndHeadModel.Parametrs(FirstRadius, _heightFirstCylinder, SecondRadius, HeightSecondCylinder, _wallThickness, _wallThickness, DeepExtrusion);
                EndHeadFigureModel SensingHead = new EndHeadFigureModel(SwApp); 
                SensingHead.BuildNewDocSW();
                SensingHead.BuildNewCylinder(FirstRadius / 1000, _heightFirstCylinder/1000, "Спереди", "PLANE", xyz, false);
                SensingHead.BuildNewCylinder(SecondRadius / 1000, HeightSecondCylinder / 1000, "Спереди", "PLANE", xyz, false);
                SensingHead.BuildExtrusion(true, _radiusFirstCylinder / 1000, 6, DeepExtrusion / 1000);
                SensingHead.BuildExtrusion(true, SecondRadius / 1000, 4, HeightSecondCylinder / 1000);
            }
            catch(CellDeepExtrusionException cellDeepExtrusionException)
            {
                MessageBox.Show(cellDeepExtrusionException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch(CellRadiusException cellRadiusException)
            {
                MessageBox.Show(cellRadiusException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch (CellWallThicknessException cellWallThicknessException)
            {
                MessageBox.Show(cellWallThicknessException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
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
                catch (CellOutOfRangeException cellOutOfRangeException)
                {
                    MessageBox.Show(cellOutOfRangeException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
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
