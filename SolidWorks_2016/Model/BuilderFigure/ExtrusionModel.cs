namespace SolidWorks_2016.Model.BuilderFigure
{
    using SolidWorks.Interop.sldworks;
    /// <summary>
    /// Класс делающий вырез в форме многоугольника
    /// </summary>
    class ExtrusionModel:IBuildFigureModel
    {
        private IModelDoc2 _swModel;
        private double _radiusPolygon;
        private int _numberPolygon;
        private double _deepPolygon;
        private bool _dir;
        private bool _inscribed;


        public ExtrusionModel(IModelDoc2 swModel, bool dir, double radiusPolygon, int numberPolygon, double deepPolygon, bool inscribed)
        {
            _swModel = swModel;
            _dir = dir;
            _radiusPolygon = radiusPolygon;
            _numberPolygon = numberPolygon;
            _deepPolygon = deepPolygon;
            _inscribed = inscribed;
        }

        public IModelDoc2 Build
        {
            get
            {
                //многоугольник 
                //выбираем плоскость
                _swModel.Extension.SelectByID2("Спереди", "PLANE", 0, 0, 0, false, 0, null, 0); 
                _swModel.SketchManager.CreatePolygon(0, 0, 0, 0, _radiusPolygon, 0, _numberPolygon, _inscribed); 
                //создаем многогранник
                _swModel.FeatureManager.FeatureCut3(true, false, _dir, 0, 0, _deepPolygon, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false); 
                //вырез многоугольника
                _swModel.ClearSelection2(true);
                return _swModel;
            }
        }
    }
}
