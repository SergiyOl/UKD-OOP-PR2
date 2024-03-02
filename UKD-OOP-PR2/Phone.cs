using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKD_OOP_PR2
{
    public class Phone
    {
        public string number;
        public string mobileOperator;
        public int costPerMonth;

        public Phone(string _number, string _mobileOperator, int _costPerMonth)
        {
            number = _number;
            mobileOperator = _mobileOperator;
            costPerMonth = _costPerMonth;
        }
    }
}
