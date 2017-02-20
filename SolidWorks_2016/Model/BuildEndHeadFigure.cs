namespace SolidWorks_2016.Model
{
    using System;
    using System.Windows;
    using SolidWorks_2016.Model.BuilderFigure;
    using SolidWorks.Interop.sldworks;
    using SolidWorks_2016.Model.MyException;
    using System.Windows.Media.Media3D;

    public class BuildEndHeadFigure
    {
        private double _radiusFirstCylinder;
        private double _radiusSecondCylinder;
        private double _heightFirstCylinder;
        private double _heightSecondCylinder;
        private double _depthOfWorkSurface;
        private double _radiusForSizeOfWorkingSurface;
        private double _radiusForSizeAttachmentPortion;
        private Point3D _xyz = new Point3D(0, 0, 0);

        /*public void BuildEndHeadFigure2(
            double radiusFirstCylinder,
            double radiusSecondCylinder,
            double heightFirstCylinder,
            double heightSecondCylinder,
            double radiusForSizeOfWorkingSurface,
            double radiusForSizeAttachmentPortion,
            double depthOfWorkSurface)
        {
            _radiusFirstCylinder = radiusFirstCylinder;
            _radiusSecondCylinder = radiusSecondCylinder;
            _heightFirstCylinder = heightFirstCylinder;
            _heightSecondCylinder = heightSecondCylinder;
            _depthOfWorkSurface = depthOfWorkSurface;
            _radiusForSizeOfWorkingSurface = radiusForSizeOfWorkingSurface;
            _radiusForSizeAttachmentPortion = radiusForSizeAttachmentPortion;
        }*/

        public void ff(ParametrsForBuilder parametrForBuilder)
        {
            double[] parametrs = parametrForBuilder.OptionsParametrs;
            _radiusFirstCylinder = parametrs[0];
            _radiusSecondCylinder = parametrs[1];
            _heightFirstCylinder = parametrs[2];
            _heightSecondCylinder = parametrs[3];
            
            _radiusForSizeOfWorkingSurface = parametrs[4];
            _radiusForSizeAttachmentPortion = parametrs[5];
            _depthOfWorkSurface = parametrs[6];
        }
       

        public void BuildEndHead(SldWorks SwApp)
        {
            EndHeadFigureModel SensingHead = new EndHeadFigureModel(SwApp);
            SensingHead.BuildNewDocSW();
            //SensingHead.BuildNewCylinder(_radiusFirstCylinder, _heightFirstCylinder, "Спереди", "PLANE", _xyz, false);
            //SensingHead.BuildNewCylinder(_radiusSecondCylinder, _heightSecondCylinder, "Спереди", "PLANE", _xyz, false);
            //SensingHead.BuildExtrusion(true, _radiusForSizeOfWorkingSurface, 6, _depthOfWorkSurface, true);
            //SensingHead.BuildExtrusion(true, _radiusForSizeAttachmentPortion, 4, _heightSecondCylinder, true);
        }
    }
}
