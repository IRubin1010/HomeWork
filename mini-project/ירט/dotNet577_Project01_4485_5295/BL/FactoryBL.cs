﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class FactoryBL
    {
        // retrun the instance of Bl_imp
        public static IBL GetBL()
        {
            return new Bl_imp();
        }
    }
}
