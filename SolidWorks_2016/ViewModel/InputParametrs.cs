﻿namespace SolidWorks_2016.ViewModel
{
    using System.Windows;
    using SolidWorks_2016.Model.MyException;
    using SolidWorks_2016.Model;
    using System.Windows.Media.Media3D;
    using System;
    using System.Windows.Controls;
    using System.Collections.Generic;

    public class InputParametrs
    {
        //Сигма 0,04 мм 
        private const double sigma = 0.04/mm;
        private const double mm = 1000;

        /// <summary>
        /// Расчет необходимых параметров для построения и передача их
        /// </summary>
        /// <param name="SwApp"></param>
        public ParametrsForBuilder InspectionInputParametrs()
        {
            ParametrsForBuilder inputParametrsForBuilder = new ParametrsForBuilder();
            try
            {
                //расчет необходимых параметров
                double radiusForSizeOfWorkingSurface;
                double radiusForSizeAttachmentPortion;
                double radiusFirstCylinder;
                double radiusSecondCylinder;
                double heightFirstCylinder;
                double heightSecondCylinder;

                double depthOfWorkSurface;
                Point3D xyz = new Point3D(0, 0, 0);

                radiusForSizeOfWorkingSurface = (_sizeOfWorkingSurface + sigma) / (mm * 2);
                radiusForSizeAttachmentPortion = (_sizeAttachmentPortion + sigma) / (mm * 2);

                radiusFirstCylinder = radiusForSizeOfWorkingSurface + _wallThicknessFirstCylinder/mm;
                radiusSecondCylinder = radiusForSizeAttachmentPortion + _wallThicknessSecondCylinder/mm;

                heightFirstCylinder = _heightFirstCylinder/mm;
                heightSecondCylinder = _heightFirstCylinder/mm + _heightSecondCylinder/mm;
                depthOfWorkSurface = _depthOfWorkSurface/mm;


                //проверяем высоту первого цилиндра что бы была меньше глубины выреза под рабочубю поверхность
                InspectionParametrsForBuildEndHeadModel.InspectionHeightAndDeep(
                    heightFirstCylinder,
                    depthOfWorkSurface);
                //проверяем радиус целиндров
                InspectionParametrsForBuildEndHeadModel.InspectionFirstAndSecondRadius(
                    radiusFirstCylinder,
                    radiusSecondCylinder);

                //передача параметров в класс для хранения 
                List<double> ParametrsList= new List<double>();
                ParametrsList.Add(radiusFirstCylinder);
                ParametrsList.Add(radiusSecondCylinder);
                ParametrsList.Add(heightFirstCylinder);
                ParametrsList.Add(heightSecondCylinder);
                ParametrsList.Add(radiusForSizeOfWorkingSurface);
                ParametrsList.Add(radiusForSizeAttachmentPortion);
                ParametrsList.Add(depthOfWorkSurface);
                inputParametrsForBuilder.Parametrs=ParametrsList;
                return inputParametrsForBuilder;
            }
            catch (CellDeepExtrusionException cellDeepExtrusionException)
            {
                MessageBox.Show(cellDeepExtrusionException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                inputParametrsForBuilder = null;
                return null;
            }
            catch (CellRadiusException сellRadiusException)
            {
                MessageBox.Show(сellRadiusException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                inputParametrsForBuilder = null;
                return null;
            }
        }

        /// <summary>
        /// Толщена стенки первого цилиндра
        /// </summary>
        private double _wallThicknessFirstCylinder;
        public string WallThicknessFirstCylinder
        {
            get
            {
                return _wallThicknessFirstCylinder.ToString();
            }
            set
            {
                try
                {
                    _wallThicknessFirstCylinder = InspectionParametrModel.Parametr(value, "Wall Thickness");
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
        /// Толщена стенки второго цилиндра
        /// </summary>
        private double _wallThicknessSecondCylinder;
        public string WallThicknessSecondCylinder
        {
            get
            {
                return _wallThicknessSecondCylinder.ToString();
            }
            set
            {
                try
                {
                    _wallThicknessSecondCylinder = InspectionParametrModel.Parametr(value, "Wall Thickness");
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
        /// Размер рабочая поверхности торцевой головки
        /// </summary>
        private double _sizeOfWorkingSurface;
        public string SizeOfWorkingSurface
        {
            get
            {
                return _sizeOfWorkingSurface.ToString();
            }
            set
            {
                try
                {
                    _sizeOfWorkingSurface = InspectionParametrModel.Parametr(value, "Radius");
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
        /// Размер посадочной части торцевой головки
        /// </summary>
        private double _sizeAttachmentPortion;
        public string SizeAttachmentPortion
        {
            get
            {
                return _sizeAttachmentPortion.ToString();
            }
            set
            {
                try
                {
                    _sizeAttachmentPortion = InspectionParametrModel.Parametr(value, "Радиус второго цилиндра");
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
        /// Глубина рабочей поверхности
        /// </summary>
        private double _depthOfWorkSurface;
        public string DepthOfWorkSurface
        {
            get
            {
                return _depthOfWorkSurface.ToString();
            }
            set
            {
                try
                {
                    _depthOfWorkSurface = InspectionParametrModel.Parametr(value, "Глубина выреза в цилиндра");
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
    }
}
