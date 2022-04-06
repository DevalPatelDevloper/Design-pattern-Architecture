using Business__access_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_AbstractDeptFactory
{
    class OutdoorFactory : AbstractDepartFactory
    {
        public Iotpay GetFactory(string deptname)
        {
            if (deptname.Equals("Sales"))
            {
                return new Salestimeotpay();
            }
            else if (deptname.Equals("On-Site"))
            {
                return new Ontimesitepay();
            }
            return null;
        }
    }
}
