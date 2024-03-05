using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKD_OOP_PR2
{
    public class Contacts
    {
        public List<string> emailAdresses = new();
        public List<Phone> phoneNumbers = new();

        public Contacts(List<string> _emailAdresses, List<Phone> _phoneNumbers)
        {
            emailAdresses = _emailAdresses;
            phoneNumbers = _phoneNumbers;
        }

        public int SummaryPhoneCost()
        {
            int cost = 0;
            foreach(var item in phoneNumbers)
            {
                cost += item.costPerMonth;
            }
            return (cost);
        }
    }
}
