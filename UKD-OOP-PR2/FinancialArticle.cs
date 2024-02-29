using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKD_OOP_PR2
{
    public class FinancialArticle
    {
        public string name;
        public double cost;
        public DateTime creationDate;

        public FinancialArticle(string _name, double _cost, DateTime _creationDate)
        {
            name = _name;
            cost = _cost;
            creationDate = _creationDate;
        }
    }
}
