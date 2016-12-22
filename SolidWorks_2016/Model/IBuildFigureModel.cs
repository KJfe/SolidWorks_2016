namespace BuilderFigure.Model
{
    using SolidWorks.Interop.sldworks;
    interface IBuildFigureModel
    {
        IModelDoc2 Build
        {
            get;
        }
    }
}
