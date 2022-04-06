using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business__access_layer
{
    public class DeptFactory
    {
        public Iotpay Getobj(string DeptName)
        {
            switch (DeptName)
            {
                case "IT":
                    return new ITotpay();
                case "HR":
                    return new HROtpay();
                case "Admin":
                    return new AdminOTPay();
                case "Sales":
                    return new Salestimeotpay();
                case "On-Site":
                    return new Ontimesitepay();
                default:
                    return null;

            }
        }
    }
}
