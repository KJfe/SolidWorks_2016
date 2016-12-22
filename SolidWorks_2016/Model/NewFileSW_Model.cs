namespace BuilderFigure.Model
{
    using SolidWorks.Interop.sldworks;
    /// <summary>
    /// Класс создающий новый документ в SolidWorks
    /// </summary>
    class NewFileSW_Model:IBuildFigureModel
    {
        private SldWorks _SwApp;
        private IModelDoc2 _swModel;

        public NewFileSW_Model(SldWorks SwApp, IModelDoc2 swModel)
        {
            _SwApp = SwApp;
            _swModel = swModel;
        }

        public IModelDoc2 Build
        {
            get
            {
                _SwApp.NewPart();//создание нового файла в solidworks

                _swModel = _SwApp.IActiveDoc2;

                ModelDoc2 swDoc = null;
                swDoc = (ModelDoc2)_SwApp.ActiveDoc;
                return _swModel;
            }
        }

    }
}
