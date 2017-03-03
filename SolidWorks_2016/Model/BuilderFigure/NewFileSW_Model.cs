namespace SolidWorks_2016.Model.BuilderFigure
{
    using SolidWorks.Interop.sldworks;
    /// <summary>
    /// Класс создающий новый документ в SolidWorks
    /// </summary>
    class NewFileSW_Model : IBuildFigureModel
    {
        #region Private Fields
        private SldWorks _SwApp;
        private IModelDoc2 _swModel; 
        #endregion
        /// <summary>
        /// Создани Нового докуента в SW 
        /// </summary>
        /// <param name="SwApp"></param>
        /// <param name="swModel"></param>
        public NewFileSW_Model(SldWorks SwApp, IModelDoc2 swModel)
        {
            _SwApp = SwApp;
            _swModel = swModel;
        }

        public IModelDoc2 Build
        {
            get
            {
                //создание нового файла в solidworks
                _SwApp.NewPart();

                _swModel = _SwApp.IActiveDoc2;

                ModelDoc2 swDoc = null;
                swDoc = (ModelDoc2)_SwApp.ActiveDoc;
                return _swModel;
            }
        }

    }
}
