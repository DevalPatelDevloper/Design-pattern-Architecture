using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_AbstractDeptFactory
{
        public class FactoryType
        {
            public AbstractDepartFactory getfactorytype(string factname)
            {
                if (factname.Equals("Indoor"))
                {
                    return new IndoorFactory();
                }
                else if (factname.Equals("Outdoor"))
                {
                    return new OutdoorFactory();
                }
                return null;
            }
        }
    
}
