namespace SolidWorks_2016.Model.BuilderFigure
{
    using SolidWorks.Interop.sldworks;
    /// <summary>
    /// класс сохраняющий деталь
    /// </summary>
    class SaveDetail:IBuildFigureModel
    {
        #region Private Fields
        private IModelDoc2 _swModel;
        private string _path;
        #endregion

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

        /// <summary>
        /// Реализация интерфейса
        /// </summary>
        public IModelDoc2 Build
        {
            get
            {
                if ((_path != "") && (_path != null)) 
                {
                    _swModel.SaveAs4(_path, 0, 2, 0, 0);
                }
                return _swModel;
            }
        }

    }
}
