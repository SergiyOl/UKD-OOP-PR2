using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKD_OOP_PR2
{
    public class Phone
    {
        public string emailAdress;
        public string mobileOperator;
        public int costPerMonth;

        public Phone(string _emailAdress, string _mobileOperator, int _costPerMonth)
        {
            emailAdress = _emailAdress;
            mobileOperator = _mobileOperator;
            costPerMonth = _costPerMonth;
        }
    }
}
