namespace SolidWorks_2016.Model.BuilderFigure
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
