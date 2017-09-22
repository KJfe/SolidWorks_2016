﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidWorks_2016.Model.MyException
{
    public class CellOutOfRangeException : ApplicationException
    {
        public CellOutOfRangeException(string editDesc) : base(string.Format("Неверный диапозон в яейке {0} ", editDesc))
        {

        }
    }
}
