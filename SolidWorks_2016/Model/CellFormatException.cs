using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidWorks_2016.Model
{
    public class CellFormatException:Exception
    {
        public CellFormatException(string editDesc) : base(string.Format("hg {0} ", editDesc))
        {

        }
    }
}
