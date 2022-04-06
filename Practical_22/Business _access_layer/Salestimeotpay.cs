using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business__access_layer
{
    public class Salestimeotpay : Iotpay
    {
        public int MyOverTimePay(int hour)
        {
            int departmentpay = 100;
            return hour * departmentpay;
        }
    }
}
