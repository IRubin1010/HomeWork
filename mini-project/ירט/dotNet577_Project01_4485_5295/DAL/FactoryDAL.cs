﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class FactoryDAL
    {
        // retrun the instance of Dal_imp
        public static IDAL GetIDAL()
        {
            return Dal_XML_imp.Instance;
        }
    }
}
