namespace SolidWorks_2016.Model.BuilderFigure
{
    using SolidWorks.Interop.sldworks;
    class RoundingModel:IBuildFigureModel
    {
        private IModelDoc2 _swModel;
        private double _radiiArray0;
        private double _dist2Array0;
        private double _conicRhosArray0;
        private bool _setBackArray0;
        private int _pointArray0;
        //private  _pointDist2Array0=null;
        private int _pointRhoArray0;


        public RoundingModel(IModelDoc2 swModel, double radiiArray0, double dist2Array0, double conicRhosArray0, bool setBackArray0, int pointArray0/*, double pointDist2Array0*/, int pointRhoArray0)
        {
            _swModel = swModel;
            _radiiArray0 = radiiArray0;
            _dist2Array0 = dist2Array0;
            _conicRhosArray0 = conicRhosArray0;
            _setBackArray0 = setBackArray0;
            _pointArray0 = pointArray0;
            // _pointDist2Array0 = null;
            _pointRhoArray0 = pointRhoArray0;
        }

        public IModelDoc2 Build
        {
            get
            {
                _swModel.Extension.SelectByID2("", "EDGE", (_radiiArray0), (_dist2Array0), (_conicRhosArray0), (_setBackArray0), (_pointArray0), (null), (_pointRhoArray0));
                //Part.Extension.SelectByID2("", "EDGE", 8.21274659045912E-03, 2.21102871208245E-02, 2.98767229137411E-02, False, 1, Nothing, 0);
                _swModel.FeatureManager.FeatureFillet3(16579, 0.01, 0.03, 0, 0, 0, 0, (_radiiArray0), (_dist2Array0), (_conicRhosArray0), (_setBackArray0), (_pointArray0), (null), (_pointRhoArray0));
                return _swModel;
            }
        }
    }
}
