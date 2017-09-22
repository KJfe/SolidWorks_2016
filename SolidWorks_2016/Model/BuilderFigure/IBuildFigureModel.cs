namespace SolidWorks_2016.Model.BuilderFigure
{
    using SolidWorks.Interop.sldworks;
    /// <summary>
    /// интерфейс
    /// </summary>
    interface IBuildFigureModel
    {
        /// <summary>
        /// свойство интерфейса
        /// </summary>
        IModelDoc2 Build
        {
            get;
        }
    }
}
