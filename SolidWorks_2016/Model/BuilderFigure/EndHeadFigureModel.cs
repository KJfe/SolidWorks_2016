namespace SolidWorks_2016.Model.BuilderFigure
{
    using SolidWorks.Interop.sldworks;
    using System.Windows.Media.Media3D;

    /// <summary>
    /// Класс собирающий Торцевую головку
    /// </summary>
    class EndHeadFigureModel
    {

        #region Private Fileds
        // отвечает за получение обекта в солиде
        // создаем  (деталь чертеж и т.д.) 
        private IModelDoc2 swModel;
        private SldWorks _SwApp; 
        #endregion

        /// <summary>
        /// конструктор класса
        /// </summary>
        /// <param name="SwApp"></param>
        public EndHeadFigureModel(SldWorks SwApp)
        {
            _SwApp = SwApp;
        }

        /// <summary>
        /// Создает новый документ
        /// </summary>
        public void BuildNewDocSW()
        {
            var newdoc = new NewFileSW_Model(_SwApp, swModel);
            swModel = newdoc.Build;
        }

        /// <summary>
        /// Строит цилиндр
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="height"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="xyz"></param>
        /// <param name="dir"></param>
        public  void BuildNewCylinder(double radius, double height, string name, string type, Point3D xyz, bool dir)
        {
            var cylinder = new CylinderModel(radius, height, swModel, name, type, xyz, dir);
            swModel = cylinder.Build;
        }

        /// <summary>
        /// Построить вырез 
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="radiusPolygon"></param>
        /// <param name="numberPolygon"></param>
        /// <param name="deepPolygon"></param>
        /// <param name="inscribed"></param>
        public  void BuildExtrusion(bool dir, double radiusPolygon, int numberPolygon, double deepPolygon, bool inscribed)
        {
            var extrutionCylinder = new ExtrusionModel(swModel, dir, radiusPolygon, numberPolygon, deepPolygon, inscribed);
            swModel = extrutionCylinder.Build;
        }

        /// <summary>
        /// Строим сглаживание
        /// </summary>
        /// <param name="radiiArray0"></param>
        /// <param name="dist2Array0"></param>
        /// <param name="conicRhosArray0"></param>
        /// <param name="setBackArray0"></param>
        /// <param name="pointArray0"></param>
        /// <param name="pointRhoArray0"></param>
        public  void BuildRounding(double radiiArray0, double dist2Array0, double conicRhosArray0, bool setBackArray0, int pointArray0, int pointRhoArray0)
        {
            var roundingEdge = new RoundingModel(swModel, radiiArray0, dist2Array0, conicRhosArray0, setBackArray0, pointArray0, pointRhoArray0);
            swModel = roundingEdge.Build;
        }

        /// <summary>
        /// Сохраняем деталь
        /// </summary>
        /// <param name="path"></param>
        public void SaveDetail(string path)
        {
            var saveDetail = new SaveDetail(swModel ,path);
            swModel = saveDetail.Build;
        }
    }
}
