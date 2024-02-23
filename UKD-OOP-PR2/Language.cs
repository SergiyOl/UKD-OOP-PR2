using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKD_OOP_PR2
{
    public class Language
    {
        public string lang;
        public string level;
        public string status;

        public Language(string _lang, string _level, string _status)
        {
            lang = _lang;
            level = _level;
            status = _status;
        }
    }
}
