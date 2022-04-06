using Business__access_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_AbstractDeptFactory
{
    class IndoorFactory : AbstractDepartFactory
    {
        public Iotpay GetFactory(string deptname)
        {
            if (deptname.Equals("IT"))
            {
                return new ITotpay();
            }
            else if (deptname.Equals("HR"))
            {
                return new HROtpay();
            }
            return null;
        }
    }
}
