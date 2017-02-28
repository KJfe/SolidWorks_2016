namespace SolidWorks_2016.Model.BuilderFigure
{
    using SolidWorks.Interop.sldworks;
    /// <summary>
    /// класс сохраняющий деталь
    /// </summary>
    class SaveDetail:IBuildFigureModel
    {
        private IModelDoc2 _swModel;
        private string _path;

        /// <summary>
        /// конструктор принимающий параметры
        /// </summary>
        /// <param name="swApp"></param>
        /// <param name="path"></param>
        public SaveDetail(IModelDoc2 swModel, string path)
        {
            _swModel = swModel;
            _path = path;
        }
        public IModelDoc2 Build
        {
            get
            {
                _swModel.SaveAs4("C:\\temp\\test.SLDPRT", 0, 2, 0, 0);
                return _swModel;
            }
        }

    }
}
