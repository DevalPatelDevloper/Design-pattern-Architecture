using Business__access_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_AbstractDeptFactory
{
    public interface AbstractDepartFactory
    {
        Iotpay GetFactory(string deptname);
    }

}
