namespace SolidWorks_2016.Model.BuilderFigure
{
    using SolidWorks.Interop.sldworks;
    using System.Windows.Media.Media3D;

    /// <summary>
    /// Класс строющий цилиндр
    /// </summary>
    class CylinderModel:IBuildFigureModel
    {
        #region Private Fields
        private Point3D _xyz;
        private IModelDoc2 _swModel;
        private double _radius;
        private double _height;
        private string _name;
        private string _type;
        private bool _dir; 
        #endregion

        /// <summary>
        /// Конструктор принимающий параметры
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="height"></param>
        /// <param name="swModel"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="xyz"></param>
        /// <param name="dir"></param>
        public CylinderModel(double radius, double height, IModelDoc2 swModel, string name, string type, Point3D xyz, bool dir)
        {
            _radius = radius;
            _height = height;
            _swModel = swModel;
            _name = name;
            _type = type;
            _xyz = xyz;
            _dir = dir;
        }
        /// <summary>
        /// Реализация интефейса
        /// </summary>
        public IModelDoc2 Build
        {
            get
            {
                _swModel.Extension.SelectByID2(_name, _type, _xyz.X, _xyz.Y, _xyz.Z, false, 0, null, 0);//задаем плоскость
                _swModel.SketchManager.InsertSketch(true);
                _swModel.SketchManager.CreateCircle(0, 0, 0, 0, _radius, 0);     // создаем окружность
                _swModel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);     //выбираем контур для выдавливания
                _swModel.FeatureManager.FeatureExtrusion2(true, false, _dir, 0, 0, _height, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false); // выдавливание
                _swModel.ISelectionManager.EnableContourSelection = false;
                _swModel.ClearSelection2(true);
                return _swModel;
            }
        }
    }
}
