namespace SolidWorks_2016.Model.BuilderFigure
{
    using SolidWorks.Interop.sldworks;
    /// <summary>
    /// Класс строющий цилиндр
    /// </summary>
    class CylinderModel:IBuildFigureModel
    {
        private IModelDoc2 _swModel;
        private double _radius;
        private double _height;
        private string _name;
        private string _type;
        private double _x;
        private double _y;
        private double _z;
        private bool _dir;

        public CylinderModel(double radius, double height, IModelDoc2 swModel, string name, string type, double x, double y, double z, bool dir)
        {
            _radius = radius;
            _height = height;
            _swModel = swModel;
            _name = name;
            _type = type;
            _x = x;
            _y = y;
            _z = z;
            _dir = dir;
        }

        public IModelDoc2 Build
        {
            get
            {
                _swModel.Extension.SelectByID2(_name, _type, _x, _y, _z, false, 0, null, 0);//задаем плоскость
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
