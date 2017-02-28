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
        /// <summary>
        /// Свойство позволяюще принять/передать лист параметров
        /// </summary>
        private List<double> _inputParametrs;
        public List<double> Parametrs
        {
            get
            {
                return _inputParametrs;
            }
            set
            {
                _inputParametrs = value;
            }
        }

    }
}
