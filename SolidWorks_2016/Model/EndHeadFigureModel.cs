namespace BuilderFigure.Model
{
    using SolidWorks.Interop.sldworks;
    /// <summary>
    /// Класс собирающий Торцевую головку
    /// </summary>
    class EndHeadFigureModel
    {
        private SldWorks _SwApp;

        public EndHeadFigureModel(SldWorks SwApp)
        {
            _SwApp = SwApp;
        }

        // SldWorks SwApp; // отвечает за получение обекта в солиде
        IModelDoc2 swModel; // создаем  (деталь чертеж и т.д.) 

        public void BuildNewDocSW()
        {
            var newdoc = new NewFileSW_Model(_SwApp, swModel);
            swModel = newdoc.Build;
        }

        public void BuildNewCylinder(double radius, double height, string name, string type, double x, double y, double z, bool dir)
        {
            var cylinder = new CylinderModel(radius, height, swModel, name, type, x, y, z, dir);
            swModel = cylinder.Build;
        }

        public void BuildExtrusion(bool dir, double radiusPolygon, int numberPolygon, double deepPolygon)
        {
            var extrutionCylinder = new ExtrusionModel(swModel, dir, radiusPolygon, numberPolygon, deepPolygon);
            swModel = extrutionCylinder.Build;
        }

        public void BuildRounding(double radiiArray0, double dist2Array0, double conicRhosArray0, bool setBackArray0, int pointArray0, int pointRhoArray0)
        {
            var roundingEdge = new RoundingModel(swModel, radiiArray0, dist2Array0, conicRhosArray0, setBackArray0, pointArray0, pointRhoArray0);
            swModel = roundingEdge.Build;
        }
    }
}
