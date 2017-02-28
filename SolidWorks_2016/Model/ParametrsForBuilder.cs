using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace SolidWorks_2016.Model
{
    public class ParametrsForBuilder
    {
        private double _radiusFirstCylinder;
        private double _radiusSecondCylinder;
        private double _heightFirstCylinder;
        private double _heightSecondCylinder;
        private double _depthOfWorkSurface;
        private double _radiusForSizeOfWorkingSurface;
        private double _radiusForSizeAttachmentPortion;

        public void InputParametrsFigure(
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
            _radiusForSizeOfWorkingSurface= radiusForSizeOfWorkingSurface;
            _radiusForSizeAttachmentPortion = radiusForSizeAttachmentPortion;

            _optionsParametrs = new double[] { _radiusFirstCylinder, _radiusSecondCylinder, _heightFirstCylinder, _heightSecondCylinder, _radiusForSizeOfWorkingSurface, _radiusForSizeAttachmentPortion, _depthOfWorkSurface };
        }

        private double[] _optionsParametrs;
        public double[] OptionsParametrs
        {
            get
            {
                return _optionsParametrs;
            }
            set
            {
                _optionsParametrs = value;
            }
        }
    }
}
